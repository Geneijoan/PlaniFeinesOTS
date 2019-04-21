Module DAOs

    'objectes per accés manual a la BBDD
    Private CNS As String
    Private CN As OleDbConnection
    Private CNN As Integer = 0  'per saber la profundiat dels open-close connection

    Public Function ConnexioConfigurada() As Boolean
        Return Not CN Is Nothing
    End Function

    Public Function ObtenirConnexio() As OleDbConnection
        Return CN
    End Function

    Public Function ObtenirCNN() As Integer
        Return CNN
    End Function

    Public Function ObtenirCNS() As String
        Return CNS
    End Function

    Public Sub ConfigurarConnexio(pBDConn As String)
        CNS = pBDConn
        CN = New OleDbConnection(CNS)
    End Sub

    Public Function ObrirConnexio() As Boolean

        If CN Is Nothing Then
            Return False
        Else
            If CN.State = ConnectionState.Open Then
                CNN = CNN + 1
                'Debug.WriteLine("Obrir  CNN = " & CNN.ToString & " " & CN.State.ToString)
                Return True
            Else
                Try
                    CN.Open()
                Catch ex As Exception
                    Return False
                End Try
                CNN = CNN + 1
                'Debug.WriteLine("Obrir  CNN = " & CNN.ToString & " " & CN.State.ToString)
                Return True
            End If
        End If

    End Function

    Public Sub TancarConnexio()

        CNN = CNN - 1

        If CNN = 0 And CN.State <> ConnectionState.Closed Then CN.Close()

        'Debug.WriteLine("Tancar CNN = " & CNN.ToString & " " & CN.State.ToString)

    End Sub

    Public Function AfegirRecursCompost(pNomCompost As String, pColorCompost As Color, pComponents As Collection) As Boolean
        Dim TRANS As OleDbTransaction
        Dim CMDafegeixRecurs As New OleDbCommand
        Dim CMDafegeixDetallRecurs As New OleDbCommand

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        TRANS = ObtenirConnexio().BeginTransaction

        CMDafegeixRecurs.Connection = ObtenirConnexio()
        CMDafegeixRecurs.CommandText = "INSERT INTO Recursos " &
        "(recursos_nom, recursos_grup, recursos_color) " &
        "VALUES(@recurs, @grup, @color)"
        CMDafegeixRecurs.Parameters.Add("@recurs", OleDbType.Char, 50).Value = pNomCompost
        CMDafegeixRecurs.Parameters.Add("@grup", OleDbType.Boolean).Value = True
        CMDafegeixRecurs.Parameters.Add("@color", OleDbType.BigInt).Value = ColorTranslator.ToWin32(pColorCompost)

        CMDafegeixRecurs.Transaction = TRANS

        If CMDafegeixRecurs.ExecuteNonQuery < 1 Then
            TRANS.Rollback()
            TancarConnexio()
            Return False
        End If

        'afegim els components del recurs
        CMDafegeixDetallRecurs.Connection = ObtenirConnexio()
        CMDafegeixDetallRecurs.CommandText = "INSERT INTO Recursos_Components " &
        "(recursos_nom, recursos_component_nom) " &
        "VALUES (@recurs, @component)"
        CMDafegeixDetallRecurs.Parameters.Add("@recurs", OleDbType.Char, 50)
        CMDafegeixDetallRecurs.Parameters.Add("@component", OleDbType.Char, 50)

        CMDafegeixDetallRecurs.Transaction = TRANS

        For Each c In pComponents
            CMDafegeixDetallRecurs.Parameters.Item("@recurs").Value = pNomCompost
            CMDafegeixDetallRecurs.Parameters.Item("@component").Value = CType(c, String)
            Try
                If CMDafegeixDetallRecurs.ExecuteNonQuery < 1 Then
                    MsgBox("Error al gravar component '" & CType(c, String) & "' de recurs " & pNomCompost, MsgBoxStyle.OkOnly, "ERROR")
                    TRANS.Rollback()
                    TancarConnexio()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                TancarConnexio()
                Return False
            End Try
        Next

        TRANS.Commit()
        TancarConnexio()
        Return True

    End Function

    Public Function ActualitzarComponentsRecursCompost(pNomCompost As String, pComponents As Collection) As Boolean
        Dim CMDeliminaComps As New OleDbCommand
        Dim CMDafegeixComps As New OleDbCommand
        Dim TRANS As OleDbTransaction

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        TRANS = ObtenirConnexio().BeginTransaction

        'eliminem els components del recurs
        CMDeliminaComps.Connection = ObtenirConnexio()
        CMDeliminaComps.CommandText = "DELETE FROM Recursos_Components " &
        "WHERE recursos_nom = @recurs"
        CMDeliminaComps.Parameters.Add("@recurs", OleDbType.Char).Value = pNomCompost

        CMDeliminaComps.Transaction = TRANS

        Try
            CMDeliminaComps.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            TRANS.Rollback()
            TancarConnexio()
            Return False
        End Try

        'afegim els components del recurs
        CMDafegeixComps.Connection = ObtenirConnexio()
        CMDafegeixComps.CommandText = "INSERT INTO Recursos_Components " &
        "(recursos_nom, recursos_component_nom) " &
        "VALUES (@recurs, @component)"
        CMDafegeixComps.Parameters.Add("@recurs", OleDbType.Char, 50)
        CMDafegeixComps.Parameters.Add("@component", OleDbType.Char, 50)

        CMDafegeixComps.Transaction = TRANS

        For Each c In pComponents
            CMDafegeixComps.Parameters.Item("@recurs").Value = pNomCompost
            CMDafegeixComps.Parameters.Item("@component").Value = CType(c, String)
            Try
                If CMDafegeixComps.ExecuteNonQuery < 1 Then
                    MsgBox("Error al gravar component '" & CType(c, String) & "' de recurs " & pNomCompost, MsgBoxStyle.OkOnly, "ERROR")
                    TRANS.Rollback()
                    TancarConnexio()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                TancarConnexio()
                Return False
            End Try
        Next

        TRANS.Commit()
        TancarConnexio()
        Return True

    End Function

    Public Function ObtenirRecursosSimples(ByRef pRecursos As Collection) As Boolean
        Dim CMDllegeixRecursos As New OleDbCommand
        Dim RDllegeixRecursos As OleDbDataReader
        Dim auxStr As String

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        pRecursos.Clear()

        'carreguem recursos simples de BBDD
        CMDllegeixRecursos.Connection = ObtenirConnexio()
        CMDllegeixRecursos.CommandText = "SELECT recursos_nom " &
        "FROM Recursos " &
        "WHERE recursos_grup = False " &
        "ORDER BY recursos_nom"

        RDllegeixRecursos = CMDllegeixRecursos.ExecuteReader
        While RDllegeixRecursos.Read
            auxStr = RDllegeixRecursos.GetString(RDllegeixRecursos.GetOrdinal("recursos_nom"))
            pRecursos.Add(auxStr, auxStr)
        End While

        TancarConnexio()
        Return True

    End Function

    Public Function ObtenirComponentsRecurs(pRecurs As String, ByRef pComponents As Collection) As Boolean
        Dim CMDllegeixComponents As New OleDbCommand
        Dim RDllegeixComponents As OleDbDataReader
        Dim auxStr As String

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        pComponents.Clear()

        'carreguem components de BBDD
        CMDllegeixComponents.Connection = ObtenirConnexio()
        CMDllegeixComponents.CommandText = "SELECT recursos_component_nom " &
        "FROM Recursos_Components " &
        "WHERE recursos_nom = @recurs " &
        "ORDER BY recursos_component_nom"
        CMDllegeixComponents.Parameters.Add("@recurs", OleDbType.Char).Value = pRecurs

        RDllegeixComponents = CMDllegeixComponents.ExecuteReader
        While RDllegeixComponents.Read
            auxStr = RDllegeixComponents.GetString(RDllegeixComponents.GetOrdinal("recursos_component_nom"))
            pComponents.Add(auxStr, auxStr)
        End While

        TancarConnexio()
        Return True

    End Function

    Public Function ConstruirNouElement(ByVal pLlocReg As Object(), ByVal pData As Date, ByVal phora As String) As PlaniGrid.PGElement
        'pLlocReg es el registre de valors del Lloc 
        Dim auxPGElement As PlaniGrid.PGElement

        Dim CMDRecursosLloc As New OleDbCommand
        Dim RDRecursosLloc As OleDbDataReader
        Dim CMDServeisLloc As New OleDbCommand
        Dim RDServeisLloc As OleDbDataReader

        Dim auxPGResources As New Dictionary(Of String, Color)
        Dim auxDuradaNoComp As TimeSpan
        Dim auxDuradaComp As TimeSpan
        Dim auxDataHoraIni As DateTime
        Dim auxTsIni As TimeSpan

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return Nothing
        End If

        CMDRecursosLloc.Connection = ObtenirConnexio()
        CMDRecursosLloc.CommandText = "SELECT Recursos.recursos_nom, Recursos.recursos_color, Recursos_Components.recursos_component_nom, Recursos_1.recursos_color " &
        "FROM (Recursos LEFT JOIN Recursos_Components ON Recursos.recursos_nom = Recursos_Components.recursos_nom) LEFT JOIN Recursos AS Recursos_1 ON Recursos_Components.recursos_component_nom = Recursos_1.recursos_nom " &
        "WHERE (((Recursos.recursos_nom)=@recurs));"
        CMDRecursosLloc.Parameters.Add("@recurs", OleDbType.Char).Value = pLlocReg(11).ToString

        RDRecursosLloc = CMDRecursosLloc.ExecuteReader

        While RDRecursosLloc.Read
            If RDRecursosLloc.IsDBNull(RDRecursosLloc.GetOrdinal("recursos_component_nom")) Then
                auxPGResources.Add(RDRecursosLloc.GetString(RDRecursosLloc.GetOrdinal("recursos_nom")), IntegerToColor(RDRecursosLloc.GetInt32(RDRecursosLloc.GetOrdinal("Recursos.recursos_color"))))
            Else
                auxPGResources.Add(RDRecursosLloc.GetString(RDRecursosLloc.GetOrdinal("recursos_component_nom")), IntegerToColor(RDRecursosLloc.GetInt32(RDRecursosLloc.GetOrdinal("Recursos_1.recursos_color"))))
            End If
        End While
        RDRecursosLloc.Close()

        'obtenim els serveis del lloc per calcular les durades
        CMDServeisLloc.Connection = ObtenirConnexio()
        CMDServeisLloc.CommandText = "SELECT Llocs_Serveis.llocs_serveis_quantitat, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " &
        "FROM Serveis INNER JOIN Llocs_Serveis ON Serveis.serveis_nom = Llocs_Serveis.serveis_nom " &
        "WHERE (((Llocs_Serveis.llocs_nom)=@lloc));"
        CMDServeisLloc.Parameters.Add("@lloc", OleDbType.Char).Value = pLlocReg(0).ToString

        auxDuradaNoComp = TimeSpan.Zero
        auxDuradaComp = TimeSpan.Zero

        RDServeisLloc = CMDServeisLloc.ExecuteReader

        While RDServeisLloc.Read
            If RDServeisLloc.Item("serveis_comu_per_recursos") Then
                auxDuradaComp += New TimeSpan(0, RDServeisLloc.Item("llocs_serveis_quantitat") * RDServeisLloc.Item("serveis_minuts_per_unitat"), 0)
            Else
                auxDuradaNoComp += New TimeSpan(0, RDServeisLloc.Item("llocs_serveis_quantitat") * RDServeisLloc.Item("serveis_minuts_per_unitat"), 0)
            End If
        End While
        RDServeisLloc.Close()

        Try
            auxTsIni = TimeSpan.Parse(phora)
        Catch ex As Exception
            auxTsIni = New TimeSpan(0)
        End Try
        auxDataHoraIni = pData + auxTsIni

        'construim el PGElement
        auxPGElement = New PlaniGrid.PGElement("", pLlocReg(0).ToString, auxDataHoraIni, auxDuradaNoComp, auxDuradaComp, Color.Empty, auxPGResources)

        TancarConnexio()

        Return auxPGElement

    End Function

    Public Function ValidarRecursFeina(ByVal pPGElement As PlaniGrid.PGElement, ByRef pRecurs As String) As Boolean
        'valida el recurs a gravar en la feina a partir dels recursos de l'element
        'si és compost i no existeix, retorna false i el nom proposat segons els components
        Dim CMDrecursos As OleDbCommand
        Dim CMDrecursosicomps As OleDbCommand
        Dim RDrecursosicomps As OleDbDataReader
        Dim cmdText As String = ""
        Dim nRecTrobats As Integer = 0
        Dim compostActual As String = ""
        Dim auxInt As Integer
        Dim nomNouCompost As String = ""
        Dim colornoucompost As Color = Color.Empty
        Dim auxComps As New Collection

        pRecurs = ""

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        'validar que tots els recursos de l'element existeixen a la BBDD
        CMDrecursos = New OleDbCommand()
        CMDrecursos.Connection = ObtenirConnexio()
        CMDrecursos.CommandText = "SELECT Count(*) FROM Recursos WHERE recursos_nom = @recurs"
        CMDrecursos.Parameters.Add("@recurs", OleDbType.Char)
        For Each r In pPGElement.Resources
            CMDrecursos.Parameters("@recurs").Value = r.Key
            auxInt = CMDrecursos.ExecuteScalar
            If auxInt <= 0 Then
                MsgBox("Recurs '" & r.Key & "' en element " & pPGElement.Id & " inexistent", MsgBoxStyle.OkOnly, "ERROR")
                TancarConnexio()
                Return False
            End If
            If nomNouCompost = "" Then
                nomNouCompost = r.Key
            Else
                nomNouCompost &= ("+" & r.Key)
            End If
        Next

        Select Case pPGElement.Resources.Count
            Case 0
                pRecurs = ""
                TancarConnexio()
                Return True

            Case 1
                pRecurs = pPGElement.Resources.First.Key
                TancarConnexio()
                Return True

            Case Else
                'busquem recurs compost dels recursos del PGE
                cmdText = "SELECT * FROM Recursos_Components ORDER BY recursos_nom, recursos_component_nom"
                CMDrecursosicomps = New OleDbCommand(cmdText, ObtenirConnexio())
                RDrecursosicomps = CMDrecursosicomps.ExecuteReader
                While RDrecursosicomps.Read
                    If nRecTrobats = pPGElement.Resources.Count And compostActual <> "" And compostActual <> RDrecursosicomps.Item("recursos_nom") Then
                        Exit While
                    End If
                    If compostActual <> RDrecursosicomps.Item("recursos_nom") Then
                        compostActual = RDrecursosicomps.Item("recursos_nom")
                        nRecTrobats = 0
                    End If
                    If pPGElement.Resources.ContainsKey(RDrecursosicomps.Item("recursos_component_nom")) Then
                        If nRecTrobats >= 0 Then nRecTrobats += 1
                    Else
                        nRecTrobats = -1
                    End If
                End While
                RDrecursosicomps.Close()

                If nRecTrobats = pPGElement.Resources.Count Then
                    pRecurs = compostActual
                    TancarConnexio()
                    Return True
                Else
                    pRecurs = nomNouCompost
                    TancarConnexio()
                    Return False
                End If

        End Select

    End Function

    Public Function AfegirFeina(ByRef pPGElement As PlaniGrid.PGElement, pRecurs As String) As Boolean
        Dim CMDaddFeina As New OleDbCommand
        Dim CMDSel As New OleDbCommand
        Dim RDSel As OleDbDataReader
        Dim CMDactualitzaDetall As New OleDbCommand
        Dim CMDNewID As New OleDbCommand
        Dim TRANS As OleDbTransaction

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        TRANS = ObtenirConnexio().BeginTransaction

        CMDaddFeina.Connection = ObtenirConnexio()
        CMDaddFeina.CommandText = "INSERT INTO Feines " &
        "(llocs_nom, feines_data, feines_hora_inici, feines_hora_fi, recursos_nom) " &
        "VALUES(@lloc, @data, @horainici, @horafi, @recurs)"
        CMDaddFeina.Parameters.Add("@lloc", OleDbType.Char, 50).Value = pPGElement.Name
        CMDaddFeina.Parameters.Add("@data", OleDbType.Date).Value = pPGElement.Starts.Date
        CMDaddFeina.Parameters.Add("@horainici", OleDbType.Char, 5).Value = pPGElement.Starts.TimeOfDay.ToString
        CMDaddFeina.Parameters.Add("@horafi", OleDbType.Char, 5).Value = pPGElement.Ends.TimeOfDay.ToString
        CMDaddFeina.Parameters.Add("@recurs", OleDbType.Char, 50).Value = IIf(pRecurs = "", DBNull.Value, pRecurs)

        CMDaddFeina.Transaction = TRANS

        'per recuperar el ID de la feina creada
        CMDNewID.Connection = ObtenirConnexio()
        CMDNewID.CommandText = "SELECT @@IDENTITY"

        CMDNewID.Transaction = TRANS

        If CMDaddFeina.ExecuteNonQuery > 0 Then
            pPGElement.Id = CMDNewID.ExecuteScalar.ToString
        Else
            TRANS.Rollback()
            TancarConnexio()
            Return False
        End If

        'afegim el detall de la feina (serveis del lloc)
        CMDactualitzaDetall.Connection = ObtenirConnexio()
        CMDactualitzaDetall.CommandText = "INSERT INTO Feines_Detall " &
        "(feines_id, serveis_nom, feines_detall_quantitat, feines_detall_preu_un, feines_detall_unitat) " &
        "VALUES (@id, @servei, @quantitat, @preu, @unitat)"
        CMDactualitzaDetall.Parameters.Add("@id", OleDbType.Integer)
        CMDactualitzaDetall.Parameters.Add("@servei", OleDbType.Char, 50)
        CMDactualitzaDetall.Parameters.Add("@quantitat", OleDbType.Single)
        CMDactualitzaDetall.Parameters.Add("@preu", OleDbType.Single)
        CMDactualitzaDetall.Parameters.Add("@unitat", OleDbType.Char, 25)

        CMDactualitzaDetall.Transaction = TRANS

        'obtenim els serveis del lloc
        CMDSel.Connection = ObtenirConnexio()
        CMDSel.CommandText = "SELECT Llocs_Serveis.serveis_nom, Llocs_Serveis.llocs_serveis_quantitat, Llocs_Serveis.llocs_serveis_preu_un, Serveis.serveis_unitat " &
        "FROM Serveis INNER JOIN Llocs_Serveis ON Serveis.serveis_nom = Llocs_Serveis.serveis_nom " &
        "WHERE (((Llocs_Serveis.llocs_nom)= @lloc ))"
        CMDSel.Parameters.Add("@lloc", OleDbType.Char).Value = pPGElement.Name

        CMDSel.Transaction = TRANS

        RDSel = CMDSel.ExecuteReader
        While RDSel.Read
            CMDactualitzaDetall.Parameters("@id").Value = CInt(pPGElement.Id)
            CMDactualitzaDetall.Parameters("@servei").Value = RDSel.GetString(RDSel.GetOrdinal("serveis_nom"))
            CMDactualitzaDetall.Parameters("@quantitat").Value = RDSel.GetFloat(RDSel.GetOrdinal("llocs_serveis_quantitat"))
            CMDactualitzaDetall.Parameters("@preu").Value = RDSel.GetFloat(RDSel.GetOrdinal("llocs_serveis_preu_un"))
            CMDactualitzaDetall.Parameters("@unitat").Value = RDSel.GetString(RDSel.GetOrdinal("serveis_unitat"))
            Try
                If CMDactualitzaDetall.ExecuteNonQuery < 1 Then
                    MsgBox("Error al gravar detall feina #" & pPGElement.Id & " " & RDSel.GetString(RDSel.GetOrdinal("serveis_nom")), MsgBoxStyle.OkOnly, "ERROR")
                    TRANS.Rollback()
                    TancarConnexio()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                TancarConnexio()
                Return False
            End Try

        End While

        TRANS.Commit()
        TancarConnexio()
        Return True

    End Function


    Public Function ActualitzarFeina(ByRef pPGElement As PlaniGrid.PGElement, pRecurs As String) As Boolean
        Dim CMDactualitzafeina As New OleDbCommand

        If Not ObrirConnexio() Then
            MsgBox("Error al obrir connexió a BD: " + ObtenirCNS(), MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End If

        CMDactualitzafeina.Connection = ObtenirConnexio()
        CMDactualitzafeina.CommandText = "UPDATE Feines " &
        "SET llocs_nom = @lloc, feines_data = @data, feines_hora_inici = @horainici, feines_hora_fi = @horafi, recursos_nom = @recurs, feines_feta = @feta " &
        "WHERE feines_id = @id"
        CMDactualitzafeina.Parameters.Add("@lloc", OleDbType.Char, 50).Value = pPGElement.Name
        CMDactualitzafeina.Parameters.Add("@data", OleDbType.Date).Value = pPGElement.Starts.Date
        CMDactualitzafeina.Parameters.Add("@horainici", OleDbType.Char, 5).Value = pPGElement.Starts.TimeOfDay.ToString
        CMDactualitzafeina.Parameters.Add("@horafi", OleDbType.Char, 5).Value = pPGElement.Ends.TimeOfDay.ToString
        CMDactualitzafeina.Parameters.Add("@recurs", OleDbType.Char, 50).Value = IIf(pRecurs = "", DBNull.Value, pRecurs)
        CMDactualitzafeina.Parameters.Add("@feta", OleDbType.Boolean).Value = pPGElement.Done
        CMDactualitzafeina.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

        If CMDactualitzafeina.ExecuteNonQuery >= 1 Then
            ActualitzarFeina = True
        Else
            ActualitzarFeina = False
        End If

        TancarConnexio()

    End Function

End Module
