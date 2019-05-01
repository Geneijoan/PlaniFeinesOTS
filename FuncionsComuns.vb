Module Module1
    'FUNCIONS D'US COMU

    'traducció dia de la setmana al catala
    Public Function DiaCatala(ByVal textin As String) As String

        Select Case textin
            Case "lunes"
                DiaCatala = "dilluns"
            Case "martes"
                DiaCatala = "dimarts"
            Case "miércoles"
                DiaCatala = "dimecres"
            Case "jueves"
                DiaCatala = "dijous"
            Case "viernes"
                DiaCatala = "divendres"
            Case "sábado"
                DiaCatala = "dissabte"
            Case "domingo"
                DiaCatala = "diumenge"
            Case Else
                DiaCatala = textin
        End Select

    End Function

    'traducció mes 3 posicions al catala
    Public Function Mes3Catala(ByVal textin As String) As String

        Select Case textin
            Case "ene"
                Mes3Catala = "gen"
            Case "may"
                Mes3Catala = "mai"
            Case "sep"
                Mes3Catala = "set"
            Case "dic"
                Mes3Catala = "dec"
            Case Else
                Mes3Catala = textin
        End Select

    End Function

    'calcul del proper dia a planificar d'un lloc
    Public Function Obtenir_Dia_Planificacio(ByVal pdataini As Date, ByVal pdiasetmana As Integer, ByVal pprimermes As Boolean, ByVal pultimmes As Boolean) As Date
        Dim auxdate As Date

        'si dia de la setmana informat, ens posicionem al dia de la setmana
        If pdiasetmana > 0 Then
            auxdate = DateAdd(DateInterval.Day, pdiasetmana, DateAdd(DateInterval.Day, -Weekday(pdataini, FirstDayOfWeek.Sunday), pdataini))
            'si l'ajust al dia setmana es anterior a la data inicial, li sumem una setmana
            If auxdate < pdataini Then auxdate = DateAdd(DateInterval.Day, 7, auxdate)
        Else
            auxdate = pdataini
        End If

        If pprimermes Then
            'primer dia de la setmana del mes
            If pdiasetmana > 0 Then
                'avancem setmana a setmana fins que sigui el primer dia de la setmana del mes
                While DatePart("m", DateAdd(DateInterval.Day, -7, auxdate), vbMonday) = DatePart("m", auxdate, vbMonday)
                    auxdate = DateAdd(DateInterval.Day, 7, auxdate)
                End While
            Else
                'si no es primer dia del mes, anem al primer del mes seguent
                If DatePart("d", auxdate, vbMonday) <> 1 Then auxdate = DateSerial(DatePart("yyyy", auxdate, vbMonday), DatePart("m", auxdate, vbMonday) + 1, 1)
            End If
        End If

        If pultimmes Then
            'ultim dia de la setmana del mes
            If pdiasetmana > 0 Then
                'avancem setmana a setmana fins que sigui el ultim dia de la setmana del mes
                While DatePart("m", DateAdd(DateInterval.Day, 7, auxdate), vbMonday) = DatePart("m", auxdate, vbMonday)
                    auxdate = DateAdd(DateInterval.Day, 7, auxdate)
                End While
            Else
                'si no es ultim dia del mes (l'endema no es dia 1), anem al ultim del mes (dia 1 del mes seguent - 1 dia)
                If DatePart("d", DateAdd(DateInterval.Day, 1, auxdate), vbMonday) <> 1 Then auxdate = DateSerial(DatePart("yyyy", auxdate, vbMonday), DatePart("m", auxdate, vbMonday) + 1, 1 - 1)
            End If
        End If

        Obtenir_Dia_Planificacio = auxdate

    End Function

    Public Function IntegerToColor(ByVal pint As Integer) As Color
        'IntegerToColor = Color.FromArgb(255, Color.FromArgb(pint))
        IntegerToColor = ColorTranslator.FromWin32(pint)
    End Function

    Public Function ColorToInteger(ByVal pcolor As Color) As Integer
        'ColorToInteger = pcolor.ToArgb
        ColorToInteger = ColorTranslator.ToWin32(pcolor)
    End Function

    Public Function EsFestiu(ByVal pconcepte As String) As Boolean
        Return Left(pconcepte, 1) = "*"
    End Function

End Module

