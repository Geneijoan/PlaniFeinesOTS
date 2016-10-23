Imports System.Windows.Forms

Public Class frmFeina

    Public Shared pPGElement As PlaniGrid.PGElement 'parametre d'entrada al form

    'objectes per accés manual a la BBDD
    'per accedir al .ini 
    Dim mINI As New cIniArray
    Dim ficINI As String = ".\PlaniFeines.ini"
    Dim CN As OleDbConnection
    Dim CNS As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mINI.IniGet(ficINI, "General", "BaseDatos") 'per .mdb "Microsoft.Jet.OLEDB.4.0"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim CMDactualitzaFeina As New OleDbCommand
        Dim CMDeliminaDetall As New OleDbCommand
        Dim CMDactualitzaDetall As New OleDbCommand
        Dim CMDactualitzaXecs As New OleDbCommand
        Dim auxint As Integer
        Dim TRANS As OleDbTransaction

        'If Not pPGElement Is Nothing Then
        'validacions

        'avís si no hi ha serveis
        If dgvDetall.RowCount = 0 Then
            If MsgBox("La feina no té cap servei. Guardar igualment?", MsgBoxStyle.OkCancel, "AVÍS") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        'si feta ha de tenir recurs assignat
        If chkFeta.Checked And txtRecurs.Text = "" Then
            MsgBox("Una feina sense recurs no pot estar feta.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

        'si feta ha de tenir serveis
        If chkFeta.Checked And dgvDetall.Rows.Count = 0 Then
            MsgBox("Una feina sense serveis no pot estar feta.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

        'si no feta, blanquejem la data factura
        If Not chkFeta.Checked Then
            txtDataFra.Text = ""
        End If

        'calculem duracions segons serveis
        pPGElement.SharedDuration = New TimeSpan(0)
        pPGElement.NonSharedDuration = New TimeSpan(0)

        For i = 0 To dgvDetall.Rows.Count - 1
            auxint = CSng(dgvDetall.Item("clQuantitat", i).Value) * CInt(dgvDetall.Item("clMinuts", i).Value)
            If CBool(dgvDetall.Item("clComu", i).Value) Then
                pPGElement.NonSharedDuration = pPGElement.NonSharedDuration + New TimeSpan(0, auxint, 0)
            Else
                pPGElement.SharedDuration = pPGElement.SharedDuration + New TimeSpan(0, auxint, 0)
            End If
        Next

        pPGElement.Ends = frmPrincipal.AgendaGrid.PGElementGetEndTime(pPGElement)

        'si feta ha de ser passat
        If chkFeta.Checked And pPGElement.Ends > Now() Then
            MsgBox("Una feina futura no pot estar feta.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

        pPGElement.Done = chkFeta.Checked

        'validem element a grid agenda
        If frmPrincipal.AgendaGrid.PGElementAddUpdate(pPGElement) <> PlaniGrid.PGReturnCode.PGUpdated Then
            MsgBox("Error al actualitzar element a la grid.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

        'actualitzem feina i detall a BBDD

        'provem la connexio
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("Error al obrir connexió: " & CNS)
            Exit Sub
        End Try

        'iniciem transaccio
        ' Creamos el objeto Transaction
        TRANS = CN.BeginTransaction

        'actualitzem feina
        CMDactualitzaFeina.Connection = CN
        CMDactualitzaFeina.CommandText = "UPDATE Feines " & _
        "SET feines_hora_fi = @horafi, feines_feta = @feta, feines_observacions = @obs, feines_data_factura = @datafra " & _
        "WHERE feines_id = @id"
        CMDactualitzaFeina.Parameters.Add("@horafi", OleDbType.Char, 5).Value = Format(pPGElement.Ends, "HH:mm")
        CMDactualitzaFeina.Parameters.Add("@feta", OleDbType.Boolean).Value = chkFeta.Checked
        CMDactualitzaFeina.Parameters.Add("@obs", OleDbType.Char, 255).Value = txtObservacions.Text
        CMDactualitzaFeina.Parameters.Add("@datafra", OleDbType.Date)
        If txtDataFra.Text = "" Then
            CMDactualitzaFeina.Parameters("@datafra").Value = DBNull.Value
        Else
            CMDactualitzaFeina.Parameters("@datafra").Value = CDate(txtDataFra.Text)
        End If
        CMDactualitzaFeina.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

        CMDactualitzaFeina.Transaction = TRANS

        Try
            If CMDactualitzaFeina.ExecuteNonQuery < 1 Then
                MsgBox("Error al actualitzar la feina #" & pPGElement.Id)
                TRANS.Rollback()
                If CN.State = ConnectionState.Open Then CN.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            TRANS.Rollback()
            If CN.State = ConnectionState.Open Then CN.Close()
            Exit Sub
        End Try

        'eliminem detall feina
        CMDeliminaDetall.Connection = CN
        CMDeliminaDetall.CommandText = "DELETE FROM Feines_Detall " & _
        "WHERE feines_id = @id"
        CMDeliminaDetall.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

        CMDeliminaDetall.Transaction = TRANS

        Try
            CMDeliminaDetall.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            TRANS.Rollback()
            If CN.State = ConnectionState.Open Then CN.Close()
            Exit Sub
        End Try

        'afegim detall feina
        CMDactualitzaDetall.Connection = CN
        CMDactualitzaDetall.CommandText = "INSERT INTO Feines_Detall " & _
        "(feines_id, serveis_nom, feines_detall_quantitat, feines_detall_preu_un, feines_detall_unitat) " & _
        "VALUES (@id, @servei, @quantitat, @preu, @unitat)"
        CMDactualitzaDetall.Parameters.Add("@id", OleDbType.Integer)
        CMDactualitzaDetall.Parameters.Add("@servei", OleDbType.Char, 50)
        CMDactualitzaDetall.Parameters.Add("@quantitat", OleDbType.Single)
        CMDactualitzaDetall.Parameters.Add("@preu", OleDbType.Single)
        CMDactualitzaDetall.Parameters.Add("@unitat", OleDbType.Char, 25)

        CMDactualitzaDetall.Transaction = TRANS

        For i = 0 To dgvDetall.Rows.Count - 1
            CMDactualitzaDetall.Parameters("@id").Value = CInt(pPGElement.Id)
            CMDactualitzaDetall.Parameters("@servei").Value = CStr(dgvDetall.Item("clServei", i).Value)
            CMDactualitzaDetall.Parameters("@quantitat").Value = CSng(dgvDetall.Item("clQuantitat", i).Value)
            CMDactualitzaDetall.Parameters("@preu").Value = CSng(dgvDetall.Item("clPreu", i).Value)
            CMDactualitzaDetall.Parameters("@unitat").Value = CStr(dgvDetall.Item("clUnitat", i).Value)
            Try
                If CMDactualitzaDetall.ExecuteNonQuery < 1 Then
                    MsgBox("Error al actualitzar detall feina #" & pPGElement.Id & " " & CStr(dgvDetall.Item("clServei", i).Value))
                    TRANS.Rollback()
                    If CN.State = ConnectionState.Open Then CN.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                TRANS.Rollback()
                If CN.State = ConnectionState.Open Then CN.Close()
                Exit Sub
            End Try
        Next

        'si feina no feta, desmarquem els xecs associats que tingui
        If Not chkFeta.Checked Then
            CMDactualitzaXecs.Connection = CN
            CMDactualitzaXecs.CommandText = "UPDATE Xecs " & _
            "SET feines_id = Null, xecs_data_liquidat = Null " & _
            "WHERE feines_id = @id"
            CMDactualitzaXecs.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

            CMDactualitzaXecs.Transaction = TRANS

            Try
                CMDactualitzaXecs.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                TRANS.Rollback()
                If CN.State = ConnectionState.Open Then CN.Close()
                Exit Sub
        End Try
        End If

        TRANS.Commit()

        If CN.State = ConnectionState.Open Then CN.Close()

        'End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        pPGElement = Nothing
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        pPGElement = Nothing
        Me.Close()
    End Sub

    Private Sub frmFeina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim auxtotal As Single
        Dim auxint As Integer

        'Debug.WriteLine(e.KeyChar)
        'si fem intro baixem els camps a la grid
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If cmbServeis.SelectedIndex <> -1 And IsNumeric(txtQuantitat.Text) And IsNumeric(txtPreu.Text) Then
                'si hi ha una linia amb el mateix servei, la eliminem
                For i = 0 To dgvDetall.Rows.Count - 1
                    If CStr(dgvDetall.Item(0, i).Value) = cmbServeis.Text Then
                        auxtotal = CSng(txtTotal.Text) - (CSng(CStr(dgvDetall.Item(1, i).Value)) * CSng(CStr(dgvDetall.Item(3, i).Value)))
                        txtTotal.Text = Format(auxtotal, "C")
                        dgvDetall.Rows.RemoveAt(i)
                        Exit For
                    End If
                Next
                'afegim la nova linia
                Dim auxrow As String() = {cmbServeis.Text, Format(CSng(txtQuantitat.Text), "###,##0.##"), txtUnitat.Text, Format(CSng(txtPreu.Text), "###,##0.#### €"), txtMinuts.Text, txtComu.Text}
                dgvDetall.Rows.Add(auxrow)

                auxtotal = CSng(txtTotal.Text) + (CSng(txtQuantitat.Text) * CSng(txtPreu.Text))
                txtTotal.Text = Format(auxtotal, "C")

                cmbServeis.SelectedIndex = -1
                txtQuantitat.Text = ""
                txtPreu.Text = ""

                'calculem duracions segons serveis
                pPGElement.SharedDuration = New TimeSpan(0)
                pPGElement.NonSharedDuration = New TimeSpan(0)

                For i = 0 To dgvDetall.Rows.Count - 1
                    auxint = CSng(dgvDetall.Item("clQuantitat", i).Value) * CInt(dgvDetall.Item("clMinuts", i).Value)
                    If CBool(dgvDetall.Item("clComu", i).Value) Then
                        pPGElement.NonSharedDuration = pPGElement.NonSharedDuration + New TimeSpan(0, auxint, 0)
                    Else
                        pPGElement.SharedDuration = pPGElement.SharedDuration + New TimeSpan(0, auxint, 0)
                    End If
                Next

                pPGElement.Ends = frmPrincipal.AgendaGrid.PGElementGetEndTime(pPGElement)
                txtHoraFinal.Text = Format(pPGElement.Ends, "HH:mm")
            End If
        End If
    End Sub

    Private Sub frmFeina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Serveis' Puede moverla o quitarla según sea necesario.
        Me.ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Serveis)

        Dim CMDseleccionaFeina As New OleDbCommand
        Dim RDSelFeina As OleDbDataReader
        Dim CMDseleccionaDetall As New OleDbCommand
        Dim RDSelDetall As OleDbDataReader
        Dim auxtotal As Single

        txtId.Text = pPGElement.Id

        'obtenim feina de BBDD
        'inicialitzem connexio BBDD
        CN = New OleDbConnection(CNS)

        'provem la connexio
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("Error al obrir connexió: " & CNS)
            pPGElement = Nothing
            Me.Close()
            Exit Sub
        End Try

        CMDseleccionaFeina.Connection = CN
        CMDseleccionaFeina.CommandText = "SELECT * FROM Feines INNER JOIN Llocs ON Feines.llocs_nom = Llocs.llocs_nom " & _
        "WHERE feines_id = @id"
        CMDseleccionaFeina.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)
        RDSelFeina = CMDseleccionaFeina.ExecuteReader

        If RDSelFeina.Read Then
            'carreguem camps pantalla
            txtClient.Text = RDSelFeina.Item("clients_nom")
            txtLloc.Text = RDSelFeina.Item("Feines.llocs_nom")
            txtData.Text = RDSelFeina.Item("feines_data")
            txtHoraInici.Text = RDSelFeina.Item("feines_hora_inici")
            txtHoraFinal.Text = RDSelFeina.Item("feines_hora_fi")
            If Not IsDBNull(RDSelFeina.Item("Feines.recursos_nom")) Then
                txtRecurs.Text = RDSelFeina.Item("Feines.recursos_nom")
            Else
                txtRecurs.Text = ""
            End If
            chkFeta.Checked = RDSelFeina.Item("feines_feta")

            If Not IsDBNull(RDSelFeina.Item("feines_data_factura")) Then
                txtDataFra.Text = RDSelFeina.Item("feines_data_factura")
            Else
                txtDataFra.Text = ""
            End If
            txtObservacions.Text = RDSelFeina.Item("feines_observacions")
        Else
            MsgBox("Error al accedir a feina #" & pPGElement.Id)
            CN.Close()
            pPGElement = Nothing
            Me.Close()
            Exit Sub
        End If

        'inicialitzem camps serveis
        cmbServeis.SelectedIndex = -1
        txtQuantitat.Text = ""

        If chkFeta.Checked Then
            cmbServeis.Enabled = False
            txtQuantitat.Enabled = False
            txtPreu.Enabled = False
            dgvDetall.Enabled = False
        Else
            cmbServeis.Enabled = True
            txtQuantitat.Enabled = True
            txtPreu.Enabled = True
            dgvDetall.Enabled = True
        End If

        'carreguem detall feina
        CMDseleccionaDetall.Connection = CN
        CMDseleccionaDetall.CommandText = "SELECT Feines_Detall.*, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " & _
        "FROM Serveis INNER JOIN Feines_Detall ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
        "WHERE feines_id = @id"
        CMDseleccionaDetall.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)
        RDSelDetall = CMDseleccionaDetall.ExecuteReader

        dgvDetall.Rows.Clear()
        auxtotal = 0

        While RDSelDetall.Read
            'carreguem camps grid detall
            Dim auxrow As String() = {RDSelDetall.GetString(RDSelDetall.GetOrdinal("serveis_nom")), _
                                      Format(RDSelDetall.GetFloat(RDSelDetall.GetOrdinal("feines_detall_quantitat")), "###,##0.##"), _
                                      RDSelDetall.GetString(RDSelDetall.GetOrdinal("feines_detall_unitat")), _
                                      Format(RDSelDetall.GetFloat(RDSelDetall.GetOrdinal("feines_detall_preu_un")), "###,##0.#### €"), _
                                      CStr(RDSelDetall.GetInt16(RDSelDetall.GetOrdinal("serveis_minuts_per_unitat"))), _
                                      CStr(RDSelDetall.GetBoolean(RDSelDetall.GetOrdinal("serveis_comu_per_recursos")))}
            dgvDetall.Rows.Add(auxrow)
            auxtotal += CSng(Format(RDSelDetall.GetFloat(RDSelDetall.GetOrdinal("feines_detall_quantitat")), "###,##0.##")) * CSng(Format(RDSelDetall.GetFloat(RDSelDetall.GetOrdinal("feines_detall_preu_un")), "###,##0.####"))
        End While

        txtTotal.Text = Format(auxtotal, "C")

        If CN.State = ConnectionState.Open Then CN.Close()

    End Sub

    Private Sub txtQuantitat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantitat.KeyPress

        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = ",") Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtQuantitat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantitat.Validating

        If txtQuantitat.Text <> "" And Not IsNumeric(txtQuantitat.Text) Then
            MsgBox("Cal informar un valor numèric a la quantitat.", MsgBoxStyle.OkOnly, "ERROR")
            e.Cancel = True
        End If

    End Sub

    Private Sub dgvDetall_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetall.CellMouseClick
        Dim auxtotal As Single
        Dim auxint As Integer

        If e.RowIndex < 0 Then Exit Sub

        cmbServeis.Text = dgvDetall.Item(0, e.RowIndex).Value
        txtQuantitat.Text = dgvDetall.Item(1, e.RowIndex).Value
        txtUnitat.Text = dgvDetall.Item(2, e.RowIndex).Value
        txtPreu.Text = dgvDetall.Item(3, e.RowIndex).Value
        txtMinuts.Text = dgvDetall.Item(4, e.RowIndex).Value
        txtComu.Text = dgvDetall.Item(5, e.RowIndex).Value

        auxtotal = CSng(txtTotal.Text) - (CSng(txtQuantitat.Text) * CSng(txtPreu.Text))
        txtTotal.Text = Format(auxtotal, "C")

        dgvDetall.Rows.RemoveAt(e.RowIndex)

        'calculem duracions segons serveis
        pPGElement.SharedDuration = New TimeSpan(0)
        pPGElement.NonSharedDuration = New TimeSpan(0)

        For i = 0 To dgvDetall.Rows.Count - 1
            auxint = CSng(dgvDetall.Item("clQuantitat", i).Value) * CInt(dgvDetall.Item("clMinuts", i).Value)
            If CBool(dgvDetall.Item("clComu", i).Value) Then
                pPGElement.NonSharedDuration = pPGElement.NonSharedDuration + New TimeSpan(0, auxint, 0)
            Else
                pPGElement.SharedDuration = pPGElement.SharedDuration + New TimeSpan(0, auxint, 0)
            End If
        Next

        pPGElement.Ends = frmPrincipal.AgendaGrid.PGElementGetEndTime(pPGElement)
        txtHoraFinal.Text = Format(pPGElement.Ends, "HH:mm")

    End Sub

    Private Sub txtPreu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPreu.KeyPress

        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = ",") Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtPreu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPreu.Validating

        If txtPreu.Text <> "" And Not IsNumeric(txtPreu.Text) Then
            MsgBox("Cal informar un valor numèric al preu.", MsgBoxStyle.OkOnly, "ERROR")
            e.Cancel = True
        End If

    End Sub

End Class
