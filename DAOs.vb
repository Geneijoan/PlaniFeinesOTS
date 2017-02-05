Module DAOs

    'objectes per accés manual a la BBDD
    Dim CNS As String = My.Settings.PlaniFeinesConnectionString
    Dim CN As New OleDbConnection(CNS)

    Public Function AfegirRecursCompost(nomCompost As String, colorCompost As Color, components As Collection) As Boolean
        Dim TRANS As OleDbTransaction
        Dim CMDaddRecurs As New OleDbCommand
        Dim CMDaddDetallRecurs As New OleDbCommand

        Try
            CN.Open()
        Catch ex As Exception
            MsgBox("Error al obrir connexió: " & CNS, MsgBoxStyle.OkOnly, "ERROR")
            Return False
        End Try

        TRANS = CN.BeginTransaction

        CMDaddRecurs.Connection = CN
        CMDaddRecurs.CommandText = "INSERT INTO Recursos " &
        "(recursos_nom, recursos_grup, recursos_color) " &
        "VALUES(@recurs, @grup, @color)"
        CMDaddRecurs.Parameters.Add("@recurs", OleDbType.Char, 50).Value = nomCompost
        CMDaddRecurs.Parameters.Add("@grup", OleDbType.Boolean).Value = True
        CMDaddRecurs.Parameters.Add("@color", OleDbType.BigInt).Value = ColorTranslator.ToWin32(colorCompost)

        CMDaddRecurs.Transaction = TRANS

        If CMDaddRecurs.ExecuteNonQuery < 1 Then
            TRANS.Rollback()
            CN.Close()
            Return False
        End If

        'afegim els components del recurs
        CMDaddDetallRecurs.Connection = CN
        CMDaddDetallRecurs.CommandText = "INSERT INTO Recursos_Components " &
        "(recursos_nom, recursos_component_nom) " &
        "VALUES (@recurs, @component)"
        CMDaddDetallRecurs.Parameters.Add("@recurs", OleDbType.Char, 50)
        CMDaddDetallRecurs.Parameters.Add("@component", OleDbType.Char, 50)

        CMDaddDetallRecurs.Transaction = TRANS

        For Each c In components
            CMDaddDetallRecurs.Parameters.Item("@recurs").Value = nomCompost
            CMDaddDetallRecurs.Parameters.Item("@component").Value = CType(c, String)
            Try
                If CMDaddDetallRecurs.ExecuteNonQuery < 1 Then
                    MsgBox("Error al gravar component '" & CType(c, String) & "' de recurs " & nomCompost, MsgBoxStyle.OkOnly, "ERROR")
                    TRANS.Rollback()
                    CN.Close()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                CN.Close()
                Return False
            End Try
        Next

        TRANS.Commit()
        CN.Close()
        Return True

    End Function

End Module
