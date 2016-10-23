Imports System.Windows.Forms

Public Class frmComponents

    Public Shared pRecurs As String 'parametre d'entrada al form
    Public Shared pGrup As Boolean = False 'parametre de sortida del form

    'objectes per accés manual a la BBDD
    'per accedir al .ini 
    Dim mINI As New cIniArray
    Dim ficINI As String = ".\PlaniFeines.ini"
    Dim CN As OleDbConnection
    Dim CNS As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mINI.IniGet(ficINI, "General", "BaseDatos") 'per .mdb "Microsoft.Jet.OLEDB.4.0"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim CMDeliminaComps As New OleDbCommand
        Dim CMDafegeixComps As New OleDbCommand
        Dim TRANS As OleDbTransaction
        Dim nrocomps As Integer = 0


        'validem que al menys hi hagi 2 components o bé 0
        For i = 0 To dgvComponents.Rows.Count - 1
            If CBool(dgvComponents.Item("cSel", i).Value) Then
                nrocomps += 1
            End If
        Next

        If nrocomps = 1 Then
            MsgBox("Un grup ha de tenir més d'un component.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

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

        'eliminem components
        CMDeliminaComps.Connection = CN
        CMDeliminaComps.CommandText = "DELETE FROM Recursos_Components " & _
        "WHERE recursos_nom = @recurs"
        CMDeliminaComps.Parameters.Add("@recurs", OleDbType.Char).Value = pRecurs

        CMDeliminaComps.Transaction = TRANS

        Try
            CMDeliminaComps.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            TRANS.Rollback()
            If CN.State = ConnectionState.Open Then CN.Close()
            Exit Sub
        End Try

        If nrocomps > 1 Then
            'afegim components seleccionats
            CMDafegeixComps.Connection = CN
            CMDafegeixComps.CommandText = "INSERT INTO Recursos_Components " & _
            "(recursos_nom, recursos_component_nom) " & _
            "VALUES (@recurs, @component)"
            CMDafegeixComps.Parameters.Add("@recurs", OleDbType.Char, 50)
            CMDafegeixComps.Parameters.Add("@component", OleDbType.Char, 50)

            CMDafegeixComps.Transaction = TRANS

            For i = 0 To dgvComponents.Rows.Count - 1
                If CBool(dgvComponents.Item("cSel", i).Value) Then
                    CMDafegeixComps.Parameters("@recurs").Value = pRecurs
                    CMDafegeixComps.Parameters("@component").Value = CStr(dgvComponents.Item("cComponent", i).Value)
                    Try
                        If CMDafegeixComps.ExecuteNonQuery < 1 Then
                            MsgBox("Error al actualitzar component '" & pRecurs & "->" & CStr(dgvComponents.Item("cComponent", i).Value) & "'")
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
                End If
            Next
            pGrup = True
        Else
            pGrup = False
        End If

        TRANS.Commit()

        If CN.State = ConnectionState.Open Then CN.Close()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComponents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CMD As New OleDbCommand
        Dim RD As OleDbDataReader
        Dim auxComponent As String = ""
        Dim auxTe As Boolean = False
        Dim auxPrimer As Boolean = True
        Dim auxrow As String() = {"", ""}
        Dim auxstring As String

        Me.Text = "Components de '" & pRecurs & "'"

        'obtenim recursos simples de BBDD amb els seus grups
        'inicialitzem connexio BBDD
        CN = New OleDbConnection(CNS)

        'provem la connexio
        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("Error al obrir connexió: " & CNS)
            Me.Close()
            Exit Sub
        End Try

        'carreguem recursos simples de BBDD
        CMD.Connection = CN
        CMD.CommandText = "SELECT Recursos.recursos_nom, Recursos_Components.recursos_nom " & _
        "FROM Recursos LEFT JOIN Recursos_Components ON Recursos.recursos_nom = Recursos_Components.recursos_component_nom " & _
        "WHERE (((Recursos.recursos_nom)<> @recurs ) AND ((Recursos.recursos_grup)=False)) " & _
        "ORDER BY Recursos.recursos_nom"
        CMD.Parameters.Add("@recurs", OleDbType.Char).Value = pRecurs

        dgvComponents.Rows.Clear()

        RD = CMD.ExecuteReader
        While RD.Read

            If auxPrimer Then
                auxPrimer = False
            Else
                If auxComponent <> RD.GetString(RD.GetOrdinal("Recursos.recursos_nom")) Then
                    'carreguem camps grid detall
                    auxrow(0) = CStr(auxTe)
                    auxrow(1) = auxComponent
                    dgvComponents.Rows.Add(auxrow)
                    auxTe = False
                End If
            End If

            auxComponent = RD.GetString(RD.GetOrdinal("Recursos.recursos_nom"))
            If RD.IsDBNull(RD.GetOrdinal("Recursos_Components.recursos_nom")) Then
                auxstring = ""
            Else
                auxstring = RD.GetString(RD.GetOrdinal("Recursos_Components.recursos_nom"))
            End If
            If pRecurs = auxstring Then
                auxTe = True
            End If

        End While

        If Not auxPrimer Then
            auxrow(0) = CStr(auxTe)
            auxrow(1) = auxComponent
            dgvComponents.Rows.Add(auxrow)
        End If

        If CN.State = ConnectionState.Open Then CN.Close()

    End Sub

End Class
