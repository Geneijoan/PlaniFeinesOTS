Public Class frmPrincipal

    'parametres d'aplicació 
    Public HORAINICI As System.TimeSpan      'hora inici planificació
    Public HORAFINAL As System.TimeSpan      'hora fi planificació
    Public MINGAP As System.TimeSpan         'minuts espai
    Public VALORDFTXEC As Decimal            'valor per defecte dels xecs per defecte
    Public COSTHORAXEC As Decimal            'cost de l'hora amb xec assignat
    Public NMAXXECSMES As Integer            'nro. maxim de xec/mes per client
    Public HORESDIA As System.TimeSpan       'hores estandar x dia (pel calcul d'hores extres)
    Public HORAINICIDINAR As System.TimeSpan 'horari dinar
    Public HORAFINALDINAR As System.TimeSpan 'horari dinar

    'auxiliar per components de recurs
    Private Structure RecursComponent
        Public recurs As String
        Public component As String
        Public color As Color
    End Structure

    'per accedir al .ini 
    Dim mINI As New cIniArray
    Dim ficINI As String = ".\PlaniFeines.ini"

    'parametre d'estat 
    Public ULTDIAGENERAT As Date    'ultim dia planificat

    Dim PrimerDiaVisualitzatMes As Date     'per saber quan ha saltat el mes en la grid
    Dim RecursActual As String              'per saber el recurs visualitzat en la grid (modo recurs)
    Dim PrimerDiaCarregat As Date = Date.MaxValue         'per saber si cal carregar feines
    Dim UltimDiaCarregat As Date = Date.MinValue

    Dim altPerHoresExtres As Integer = 2 * Me.FontHeight + 10

    Dim textFormMissatges As String = ""    'buffer per formulari missatges

    'objectes per accés manual a la BBDD
    Dim CN As OleDbConnection
    Dim CNS As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CNS = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & mINI.IniGet(ficINI, "General", "BaseDatos") 'Per .mdb "Microsoft.Jet.OLEDB.4.0"
        My.Settings.PlaniFeinesConnectionString = CNS
        My.Settings.Save()

    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'no mostrem pantalla fins que acabi de carregar
        'Me.Visible = False

        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Serveis' Puede moverla o quitarla según sea necesario.
        Me.ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Serveis)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Recursos' Puede moverla o quitarla según sea necesario.
        Me.RecursosTableAdapter.Fill(Me.PlaniFeinesDataSet.Recursos)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Clients' Puede moverla o quitarla según sea necesario.
        Me.ClientsTableAdapter.Fill(Me.PlaniFeinesDataSet.Clients)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Llocs' Puede moverla o quitarla según sea necesario.
        Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Recursos_Components' Puede moverla o quitarla según sea necesario.
        Me.Recursos_ComponentsTableAdapter.Fill(Me.PlaniFeinesDataSet.Recursos_Components)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Llocs_Serveis' Puede moverla o quitarla según sea necesario.
        Me.Llocs_ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs_Serveis)
        'TODO: esta línea de código carga datos en la tabla 'PlaniFeinesDataSet.Xecs' Puede moverla o quitarla según sea necesario.
        Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)

        SplitContainer1.Panel1MinSize = 4 + Calendari.Width + Calendari.Location.X * 2

        pnlClients.Dock = DockStyle.Fill
        pnlLlocs.Dock = DockStyle.Fill
        pnlServeis.Dock = DockStyle.Fill
        pnlXecs.Dock = DockStyle.Fill
        AgendaGrid.Dock = DockStyle.Fill

        'obtenim els parametres d'aplicació
        HORAINICI = New TimeSpan(CInt(mINI.IniGet(ficINI, "Parametres", "HoraInici")), 0, 0)
        HORAFINAL = New TimeSpan(CInt(mINI.IniGet(ficINI, "Parametres", "HoraFinal")), 0, 0)
        MINGAP = New TimeSpan(0, CInt(mINI.IniGet(ficINI, "Parametres", "MinutsCella")), 0)
        VALORDFTXEC = CDec(mINI.IniGet(ficINI, "Parametres", "ValorXec"))
        COSTHORAXEC = CDec(mINI.IniGet(ficINI, "Parametres", "CostHoraXec"))
        NMAXXECSMES = CInt(mINI.IniGet(ficINI, "Parametres", "MaxXecsMes"))
        HORESDIA = New TimeSpan(CInt(mINI.IniGet(ficINI, "Parametres", "HoresDia")), 0, 0)
        HORAINICIDINAR = New TimeSpan(CInt(Mid(mINI.IniGet(ficINI, "Parametres", "HoraIniciDinar"), 1, 2)), CInt(Mid(mINI.IniGet(ficINI, "Parametres", "HoraIniciDinar"), 4, 2)), 0)
        HORAFINALDINAR = New TimeSpan(CInt(Mid(mINI.IniGet(ficINI, "Parametres", "HoraFinalDinar"), 1, 2)), CInt(Mid(mINI.IniGet(ficINI, "Parametres", "HoraFinalDinar"), 4, 2)), 0)
        ULTDIAGENERAT = CDate(mINI.IniGet(ficINI, "Estat", "UltimDiaGen"))

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
        If CN.State = ConnectionState.Open Then CN.Close()

        AgendaGrid.StartTimeOfDay = Microsoft.VisualBasic.Left(HORAINICI.ToString, 5)
        AgendaGrid.EndTimeOfDay = Microsoft.VisualBasic.Left(HORAFINAL.ToString, 5)
        AgendaGrid.MinutesGap = MINGAP.TotalMinutes
        AgendaGrid.LunchTimeStart = Microsoft.VisualBasic.Left(HORAINICIDINAR.ToString, 5)
        AgendaGrid.LunchTimeEnd = Microsoft.VisualBasic.Left(HORAFINALDINAR.ToString, 5)

        'carreguem treeview clients (també cal fer-ho en els processos que act. els xecs)
        Carrega_TreeView_Clients()
        tvClients.SelectedNode = tvClients.Nodes(0)

        'informem el peu de pantalla
        ToolStripStatusLabel1.Text = "Últim dia planificat: " & ULTDIAGENERAT

        dgvHoresExtra.Rows.Add()

        Carrega_combos_fixes()

        Carrega_combo_recursos()

        'desseleccionem les grids i combos
        LlocsSelDataGridView.ClearSelection()
        RecursosSelDataGridView.ClearSelection()
        cmbSelClients.SelectedIndex = -1
        cmbSelClientInformes.SelectedIndex = -1

        PlaniMonthViewDesDe.SelectedDate = DateAdd(DateInterval.Month, -1, Now.Date)
        PlaniMonthViewFins.SelectedDate = Now.Date

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        'inicialitza variables de control de feines carregades
        PrimerDiaVisualitzatMes = AgendaGrid.DisplayFirstDate
        If PrimerDiaVisualitzatMes > UltimDiaCarregat Then
            UltimDiaCarregat = PrimerDiaVisualitzatMes
        End If
        If PrimerDiaVisualitzatMes < PrimerDiaCarregat Then
            PrimerDiaCarregat = PrimerDiaVisualitzatMes
        End If

        'carreguem grid de feines
        'AgendaGrid.VisualizationMode = PlaniGrid.PGMode.Month
        Carrega_Grid_Agenda()

        'Me.Visible = True
        Me.Activate()

    End Sub

    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If CN.State = ConnectionState.Open Then CN.Close()

        mINI.IniWrite(ficINI, "Estat", "UltimDiaGen", ULTDIAGENERAT)

    End Sub

    Private Sub Carrega_combos_fixes()
        Dim trams As Integer
        Dim hora As TimeSpan

        'combo hores del lloc
        Llocs_horaComboBox.Items.Clear()

        trams = 1 + (HORAFINAL.TotalMinutes - HORAINICI.TotalMinutes) \ MINGAP.TotalMinutes  'trams d'hora segons HORAINICI, HORAFINAL y MINGAP
        Llocs_horaComboBox.Items.Add("")
        For i = 1 To trams - 1
            hora = New TimeSpan(0, HORAINICI.TotalMinutes + MINGAP.TotalMinutes * (i - 1), 0)
            Llocs_horaComboBox.Items.Add(hora.ToString.Substring(0, 5))
        Next

    End Sub

    Private Sub Carrega_combo_recursos()

        Recursos_nomComboBox.Items.Clear()
        Recursos_nomComboBox.Items.Add("")
        For i = 0 To RecursosDataGridView.RowCount - 2
            Recursos_nomComboBox.Items.Add(RecursosDataGridView.Item(0, i).Value.ToString)
        Next

    End Sub

    Private Sub Carrega_Grid_Agenda()

        Dim CMDSelFeinesRecurs As New OleDbCommand
        Dim RDSelFeinesRecurs As OleDbDataReader
        Dim CMDComponents As New OleDbCommand
        Dim RDComponents As OleDbDataReader
        Dim CMDServeisFeina As New OleDbCommand
        Dim RDServeisFeina As OleDbDataReader
        Dim auxPGElement As PlaniGrid.PGElement
        Dim auxRecursComponent As RecursComponent
        Dim auxRecursosComponents As New List(Of RecursComponent)
        Dim auxPGResources As New Dictionary(Of String, Color)
        Dim auxId As Integer
        Dim auxDataHoraIni As DateTime
        Dim auxDataHoraFi As DateTime
        Dim auxTsIni As TimeSpan
        Dim auxTsFi As TimeSpan
        Dim auxRecurs As String
        Dim auxColorRecursFeina As Color
        Dim auxDuradaNoComp As TimeSpan
        Dim CNopen As Boolean
        Dim errorsEnCarrega As Boolean

        'si la grid no està posicionada no fem res
        If AgendaGrid.DisplayFirstDate = Date.MinValue Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: AgendaGrid.DisplayFirstDate no informada."
            Exit Sub
        End If

        'si no hi ha connexio, no fem res
        If CN Is Nothing Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Connexió nul·la."
            Exit Sub
        End If

        'obrim connexio
        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: No es pot obrir connexió."
                Exit Sub
            End Try
        End If

        'Dim comptador As Long = Now.Ticks

        Cursor.Current = Cursors.WaitCursor
        AgendaGrid.Enabled = False
        errorsEnCarrega = False

        'seleccionem sortida a formulari missatges
        textFormMissatges = "ERRORS EN CÀRREGA D'AGENDA " & AgendaGrid.DisplayFirstDate.Date & " - " & AgendaGrid.DisplayLastDate.Date & vbCrLf

        'NO netejem AgendaGrid
        'AgendaGrid.PGElementsClearList()

        'Debug.WriteLine("Carrega Grid " & AgendaGrid.DisplayFirstDate.ToString)

        'obtenim totes les feines del periode visualitzat modo mes
        CMDSelFeinesRecurs.Connection = CN
        CMDSelFeinesRecurs.CommandText = "SELECT Feines.*, Recursos.recursos_grup, Recursos.recursos_color " &
            "FROM Recursos RIGHT JOIN Feines ON Recursos.recursos_nom = Feines.recursos_nom " &
            "WHERE feines_data >= @dataini AND feines_data <= @datafi"
        CMDSelFeinesRecurs.Parameters.Add("@dataini", OleDbType.Date).Value = AgendaGrid.DisplayFirstDate
        CMDSelFeinesRecurs.Parameters.Add("@datafi", OleDbType.Date).Value = DateAdd(DateInterval.Day, 1, AgendaGrid.DisplayLastDate)

        CMDComponents.Connection = CN
        CMDComponents.CommandText = "SELECT Recursos.recursos_nom, Recursos_1.recursos_nom, Recursos_1.recursos_color " &
            "FROM ((Recursos INNER JOIN " &
            "Recursos_Components ON Recursos.recursos_nom = Recursos_Components.recursos_nom) INNER JOIN " &
            "Recursos Recursos_1 ON Recursos_Components.recursos_component_nom = Recursos_1.recursos_nom) " &
            "ORDER BY Recursos.recursos_nom, Recursos_1.recursos_nom"

        RDComponents = CMDComponents.ExecuteReader
        While RDComponents.Read
            auxRecursComponent.recurs = Convert.ToString(RDComponents.Item("Recursos.recursos_nom"))
            auxRecursComponent.component = Convert.ToString(RDComponents.Item("Recursos_1.recursos_nom"))
            auxRecursComponent.color = IntegerToColor(Convert.ToInt32(RDComponents.Item("recursos_color")))
            auxRecursosComponents.Add(auxRecursComponent)
        End While
        RDComponents.Close()

        CMDServeisFeina.Connection = CN
        CMDServeisFeina.CommandText = "SELECT Feines_Detall.feines_detall_quantitat, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " &
            "FROM Serveis INNER JOIN Feines_Detall ON Serveis.serveis_nom = Feines_Detall.serveis_nom " &
            "WHERE (((Feines_Detall.feines_id)= @feina))"
        CMDServeisFeina.Parameters.Add("@feina", OleDbType.Integer)

        'Debug.WriteLine("Inici proces feines ") ' & Format(Now.Ticks - comptador, "n"))

        RDSelFeinesRecurs = CMDSelFeinesRecurs.ExecuteReader
        While RDSelFeinesRecurs.Read
            auxId = Convert.ToInt32(RDSelFeinesRecurs.Item("feines_id"))

            'Debug.WriteLine("Inici proces feina " & auxId)

            auxRecurs = Convert.ToString(RDSelFeinesRecurs.Item("recursos_nom"))
            Try
                auxTsIni = TimeSpan.Parse(Convert.ToString(RDSelFeinesRecurs.Item("feines_hora_inici")))
            Catch ex As Exception
                auxTsIni = New TimeSpan(0)
            End Try
            Try
                auxTsFi = TimeSpan.Parse(Convert.ToString(RDSelFeinesRecurs.Item("feines_hora_fi")))
            Catch ex As Exception
                auxTsFi = New TimeSpan(auxTsIni.Ticks)
                auxTsFi += New TimeSpan(0, AgendaGrid.MinutesGap, 0)
            End Try
            auxDataHoraIni = Convert.ToDateTime(RDSelFeinesRecurs.Item("feines_data")) + auxTsIni
            auxDataHoraFi = Convert.ToDateTime(RDSelFeinesRecurs.Item("feines_data")) + auxTsFi

            'obtenim color i recursos de la feina
            auxPGResources.Clear()
            auxColorRecursFeina = Color.Empty
            If auxRecurs <> "" Then
                auxColorRecursFeina = IntegerToColor(Convert.ToInt32(RDSelFeinesRecurs.Item("recursos_color")))
                If Convert.ToBoolean(RDSelFeinesRecurs.Item("recursos_grup")) Then
                    For Each rc In auxRecursosComponents
                        If rc.recurs = auxRecurs Then
                            auxPGResources.Add(rc.component, rc.color)
                        End If
                    Next
                    If auxPGResources.Count = 0 Then
                        auxPGResources.Add(auxRecurs, auxColorRecursFeina)
                    End If
                Else
                    auxPGResources.Add(auxRecurs, auxColorRecursFeina)
                End If
            Else
                auxPGResources = New Dictionary(Of String, Color)
            End If

            'obtenim els serveis de la feina per calcular les durades
            auxDuradaNoComp = TimeSpan.Zero
            'auxDuradaComp = TimeSpan.Zero
            CMDServeisFeina.Parameters.Item("@feina").Value = auxId
            RDServeisFeina = CMDServeisFeina.ExecuteReader
            While RDServeisFeina.Read
                If RDServeisFeina.Item("serveis_comu_per_recursos") Then
                    auxDuradaNoComp += New TimeSpan(0, RDServeisFeina.Item("feines_detall_quantitat") * RDServeisFeina.Item("serveis_minuts_per_unitat"), 0)
                    'Else
                    'auxDuradaComp += New TimeSpan(0, RDServeisFeina.Item("feines_detall_quantitat") * RDServeisFeina.Item("serveis_minuts_per_unitat"), 0)
                End If
            End While
            RDServeisFeina.Close()

            'construim el PGElement i el carreguem a la grid
            auxPGElement = New PlaniGrid.PGElement(auxId, Convert.ToString(RDSelFeinesRecurs.Item("llocs_nom")), auxDataHoraIni, auxDataHoraFi, auxDuradaNoComp, Color.Empty, auxPGResources, Convert.ToBoolean(RDSelFeinesRecurs.Item("feines_feta")))

            If AgendaGrid.PGElementAddUpdate(auxPGElement) = PlaniGrid.PGReturnCode.PGError Then
                errorsEnCarrega = True
                textFormMissatges = textFormMissatges & vbCrLf & "Error al afegir Feina #" & Convert.ToString(RDSelFeinesRecurs.Item("feines_id")) & vbCrLf
                'frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & "Error al afegir Feina #" & Convert.ToString(RDSelFeinesRecurs.Item("feines_id"))
            End If

        End While
        RDSelFeinesRecurs.Close()

        'Debug.WriteLine("Fet Feines Add " & Format(Now.Ticks - comptador, "n"))
        'comptador = Now.Ticks

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        AgendaGrid.RefreshGrid()
        AgendaGrid.Enabled = True
        Cursor.Current = System.Windows.Forms.Cursors.Default

        'Debug.WriteLine("Fet ") ' & Format(Now.Ticks - comptador, "n"))

        If errorsEnCarrega Then
            frmMissatges.Show()
            frmMissatges.Text = "CÀRREGA DE FEINES DEL MES"
            frmMissatges.txtMissatges.Text = textFormMissatges
            frmMissatges.txtMissatges.Refresh()
            'frmMissatges.txtMissatges.Focus()
            'frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length
            'frmMissatges.txtMissatges.ScrollToCaret()
            frmMissatges.OK_Button.Visible = True
            'frmMissatges.OK_Button.Focus()
            Me.Enabled = False
        End If
        textFormMissatges = ""

        ' ''inhabilitem botó x imprimir feines del recurs seleccionat
        ''ImprimirFeines.Enabled = False

    End Sub


    Private Function FeinaaPGElement(ByVal pFeinaId As Long) As PlaniGrid.PGElement
        Dim CMDSelFeines As New OleDbCommand
        Dim RDSelFeines As OleDbDataReader
        Dim CMDAccesRecurs As New OleDbCommand
        Dim RDAccesRecurs As OleDbDataReader
        Dim CMDComponents As New OleDbCommand
        Dim RDComponents As OleDbDataReader
        Dim CMDServeis As New OleDbCommand
        Dim RDServeis As OleDbDataReader
        Dim auxListResources As New Dictionary(Of String, Color)
        Dim auxPGResources As Dictionary(Of String, Color)
        Dim auxLloc As String
        Dim auxDateIni As DateTime
        Dim auxDateFi As DateTime
        Dim auxTsIni As TimeSpan
        Dim auxTsFi As TimeSpan
        Dim auxRecurs As String
        Dim auxColor As Color
        Dim auxColorRecursFeina As Color
        Dim auxDuradaComp As TimeSpan
        Dim auxDuradaNoComp As TimeSpan
        Dim CNopen As Boolean

        If CN Is Nothing Then Return Nothing

        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Return Nothing
            End Try
        End If

        'obtenim feina
        CMDSelFeines.Connection = CN
        CMDSelFeines.CommandText = "SELECT * FROM Feines WHERE feines_id = @idfeina"
        CMDSelFeines.Parameters.Add("@idfeina", OleDbType.Integer).Value = pFeinaId

        RDSelFeines = CMDSelFeines.ExecuteReader
        If Not RDSelFeines.HasRows Then
            Return Nothing
        End If

        RDSelFeines.Read()

        auxRecurs = Convert.ToString(RDSelFeines.Item("recursos_nom"))
        auxLloc = Convert.ToString(RDSelFeines.Item("llocs_nom"))
        Try
            auxTsIni = TimeSpan.Parse(Convert.ToString(RDSelFeines.Item("feines_hora_inici")))
        Catch ex As Exception
            auxTsIni = New TimeSpan(0)
        End Try
        Try
            auxTsFi = TimeSpan.Parse(Convert.ToString(RDSelFeines.Item("feines_hora_fi")))
        Catch ex As Exception
            auxTsFi = New TimeSpan(auxTsIni.Ticks)
            auxTsFi += New TimeSpan(0, AgendaGrid.MinutesGap, 0)
        End Try
        auxDateIni = Convert.ToDateTime(RDSelFeines.Item("feines_data")) + auxTsIni
        auxDateFi = Convert.ToDateTime(RDSelFeines.Item("feines_data")) + auxTsFi

        'obtenim color i recursos de la feina
        CMDAccesRecurs.Connection = CN
        CMDAccesRecurs.CommandText = "SELECT * FROM Recursos WHERE recursos_nom = @recurs"
        CMDAccesRecurs.Parameters.Add("@recurs", OleDbType.VarChar)

        CMDComponents.Connection = CN
        CMDComponents.CommandText = "SELECT Recursos_1.recursos_nom, Recursos_1.recursos_color " & _
            "FROM ((Recursos INNER JOIN " & _
            "Recursos_Components ON Recursos.recursos_nom = Recursos_Components.recursos_nom) INNER JOIN " & _
            "Recursos Recursos_1 ON Recursos_Components.recursos_component_nom = Recursos_1.recursos_nom) " & _
            "WHERE (Recursos.recursos_nom = @recurs)"
        CMDComponents.Parameters.Add("@recurs", OleDbType.VarChar)

        CMDServeis.Connection = CN
        CMDServeis.CommandText = "SELECT Feines_Detall.feines_detall_quantitat, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " & _
            "FROM Serveis INNER JOIN (Feines INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
            "WHERE (((Feines.feines_id)= @feina))"
        CMDServeis.Parameters.Add("@feina", OleDbType.Integer)

        auxListResources.Clear()
        auxColorRecursFeina = Color.Empty
        CMDAccesRecurs.Parameters.Item("@recurs").Value = auxRecurs
        RDAccesRecurs = CMDAccesRecurs.ExecuteReader
        If RDAccesRecurs.Read Then
            auxColorRecursFeina = IntegerToColor(Convert.ToInt32(RDAccesRecurs.Item("recursos_color")))

            If Convert.ToBoolean(RDAccesRecurs.Item("recursos_grup")) Then
                auxColor = Color.Empty
                CMDComponents.Parameters.Item("@recurs").Value = auxRecurs
                RDComponents = CMDComponents.ExecuteReader
                While RDComponents.Read
                    auxListResources.Add(Convert.ToString(RDComponents.Item("recursos_nom")), IntegerToColor(Convert.ToInt32(RDComponents.Item("recursos_color"))))
                End While
                auxColor = AgendaGrid.PGResourcesColor(auxListResources)
                RDComponents.Close()
                If auxListResources.Count = 0 Then
                    auxListResources.Add(auxRecurs, auxColorRecursFeina)
                End If
            Else
                auxListResources.Add(auxRecurs, auxColorRecursFeina)
            End If
            auxPGResources = auxListResources
        Else
            auxPGResources = New Dictionary(Of String, Color)
        End If
        RDAccesRecurs.Close()

        'obtenim els serveis de la feina per calcular les durades
        auxDuradaNoComp = TimeSpan.Zero
        auxDuradaComp = TimeSpan.Zero
        CMDServeis.Parameters.Item("@feina").Value = pFeinaId
        RDServeis = CMDServeis.ExecuteReader
        While RDServeis.Read
            If RDServeis.Item("serveis_comu_per_recursos") Then
                auxDuradaNoComp += New TimeSpan(0, RDServeis.Item("feines_detall_quantitat") * RDServeis.Item("serveis_minuts_per_unitat"), 0)
            Else
                auxDuradaComp += New TimeSpan(0, RDServeis.Item("feines_detall_quantitat") * RDServeis.Item("serveis_minuts_per_unitat"), 0)
            End If
        End While
        RDServeis.Close()

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        'construim el PGElement
        Return New PlaniGrid.PGElement(pFeinaId, auxLloc, auxDateIni, auxDateFi, auxDuradaNoComp, Color.Empty, auxPGResources)

    End Function

    Private Sub Carrega_Grid_Hores(ByVal pRecurs As String, ByVal pData As Date)
        Dim auxData As Date
        Dim CNopen As Boolean
        Dim CMDSelHores As New OleDbCommand
        Dim RDSelHores As OleDbDataReader

        'netejem la grid
        For i = 0 To dgvHoresExtra.ColumnCount - 1
            dgvHoresExtra.Item(i, 0).Value = 0
        Next

        If pRecurs = "" Then Exit Sub

        'calculem dilluns de la setmana de pData
        auxData = DateAdd(DateInterval.Day, -((pData.DayOfWeek + 6) Mod 7), pData)

        'obtenim totes les feines del periode visualitzat modo mes
        If CN Is Nothing Then Exit Sub

        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try
        End If

        CMDSelHores.Connection = CN
        CMDSelHores.CommandText = "SELECT * FROM Hores_Fetes WHERE recursos_nom = @recurs AND hores_data = @data"
        CMDSelHores.Parameters.Add("@recurs", OleDbType.Char).Value = pRecurs
        CMDSelHores.Parameters.Add("@data", OleDbType.Date).Value = auxData

        'carreguem la grid per cada dia de la setmana
        For i = 0 To dgvHoresExtra.ColumnCount - 1
            RDSelHores = CMDSelHores.ExecuteReader
            If RDSelHores.Read Then
                dgvHoresExtra.Item(i, 0).Value = RDSelHores.Item("hores_quantitat")
            Else
                dgvHoresExtra.Item(i, 0).Value = 0
            End If
            auxData = DateAdd(DateInterval.Day, 1, auxData)
            RDSelHores.Close()
            CMDSelHores.Parameters("@data").Value = auxData
        Next

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        dgvHoresExtra.Refresh()

    End Sub

    Private Sub Carrega_Grids_Factura()
        Dim CNopen As Boolean
        Dim CMDSel As New OleDbCommand
        Dim RDSel As OleDbDataReader
        Dim auxdata As Date
        Dim auxsng As Single
        Dim i As Integer
        Dim FeinaAct As Integer = 0
        Dim FeinaFeta As Boolean = False
        Dim LlocAct As String = ""
        Dim QuotaAct As Single = 0
        Dim LlocImport As Single = 0
        Dim TotalImport As Single = 0
        Dim TotalHores As Single = 0
        Dim primer As Boolean = True
        Dim nxecs As Integer = 0
        Dim impxecs As Single = 0
        Dim idfeinasig As Integer = 0
        Dim auxFontBold As Font = New Font(dgvFactura.Font, FontStyle.Bold)

        Dim tasig() As TFeinaXec        'taula per assignar xecs
        Dim dimasig As Integer = 0      'elements de la taula

        'inicialitza grids factura i xecs
        dgvFactura.Rows.Clear()
        dgvXecs.Rows.Clear()

        If CN Is Nothing Then Exit Sub

        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try
        End If

        ReDim Preserve tasig(dimasig)

        'primer dia del mes
        auxdata = DateAdd(DateInterval.Day, -dtpSelMes.Value.Day + 1, dtpSelMes.Value).Date

        CMDSel.Connection = CN

        If cmbSelClients.Text <> "" Then
            Label17.Text = "Serveis:"
            'carrega grid factura
            If chkPdtFacturar.Checked Then
                CMDSel.CommandText = "SELECT Llocs.llocs_quota, Feines.feines_id, Feines.feines_data, Feines.llocs_nom, Feines.recursos_nom, Feines.feines_feta, Feines.feines_data_factura, Feines.feines_quota, Feines.feines_observacions, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_quantitat, Feines_Detall.feines_detall_unitat, Feines_Detall.feines_detall_preu_un, Serveis.serveis_minuts_per_unitat " & _
                "FROM Serveis INNER JOIN ((Llocs INNER JOIN Feines ON Llocs.llocs_nom = Feines.llocs_nom) INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
                "WHERE (Llocs.clients_nom=@client AND Feines.feines_data>=@dataini AND Feines.feines_data<@datafi AND (Feines.feines_data_factura Is Null)) " & _
                "ORDER BY Feines.llocs_nom, Feines.feines_data, Feines.feines_id, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_unitat"
            Else
                CMDSel.CommandText = "SELECT Llocs.llocs_quota, Feines.feines_id, Feines.feines_data, Feines.llocs_nom, Feines.recursos_nom, Feines.feines_feta, Feines.feines_data_factura, Feines.feines_quota, Feines.feines_observacions, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_quantitat, Feines_Detall.feines_detall_unitat, Feines_Detall.feines_detall_preu_un, Serveis.serveis_minuts_per_unitat " & _
               "FROM Serveis INNER JOIN ((Llocs INNER JOIN Feines ON Llocs.llocs_nom = Feines.llocs_nom) INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
               "WHERE (((Llocs.clients_nom)=@client) AND ((Feines.feines_data)>=@dataini And (Feines.feines_data)<@datafi)) " & _
               "ORDER BY Feines.llocs_nom, Feines.feines_data, Feines.feines_id, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_unitat"
            End If
            CMDSel.Parameters.Add("@client", OleDbType.Char, 50).Value = cmbSelClients.Text
            CMDSel.Parameters.Add("@dataini", OleDbType.Date).Value = auxdata
            CMDSel.Parameters.Add("@datafi", OleDbType.Date).Value = DateAdd(DateInterval.Month, 1, auxdata)

            RDSel = CMDSel.ExecuteReader
            If RDSel.HasRows Then

                i = -1
                While RDSel.Read

                    'tractament primer element
                    If primer Then
                        FeinaAct = RDSel.Item("feines_id")
                        FeinaFeta = RDSel.Item("feines_feta")
                        LlocAct = RDSel.Item("llocs_nom")
                        QuotaAct = IIf(IsDBNull(RDSel.Item("feines_data_factura")), RDSel.Item("llocs_quota"), RDSel.Item("feines_quota"))
                        LlocImport = QuotaAct
                        primer = False
                    End If

                    'si canvia el lloc
                    If LlocAct <> RDSel.Item("llocs_nom") Then
                        'gravem subtotal lloc
                        dgvFactura.Rows.Add()
                        i += 1
                        dgvFactura.Rows(i).Cells("Lloc").Value = LlocAct
                        If QuotaAct <> 0 Then
                            dgvFactura.Rows(i).Cells("Quantitat").Value = "QUOTA"
                        End If
                        dgvFactura.Rows(i).Cells("Unitat").Value = "TOTAL"
                        dgvFactura.Rows(i).Cells("ImportServei").Value = LlocImport

                        dgvFactura.Rows(i).Cells("Feina").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Data").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Lloc").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Recurs").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Feta").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Datafra").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Servei").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Quantitat").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Unitat").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("ImportServei").Style.BackColor = dgvFactura.GridColor

                        TotalImport += LlocImport

                        'inicialitzem dades lloc
                        FeinaAct = RDSel.Item("feines_id")
                        FeinaFeta = RDSel.Item("feines_feta")
                        LlocAct = RDSel.Item("llocs_nom")
                        QuotaAct = IIf(IsDBNull(RDSel.Item("feines_data_factura")), RDSel.Item("llocs_quota"), RDSel.Item("feines_quota"))
                        LlocImport = QuotaAct
                    End If

                    'si no te quota i està feta
                    If QuotaAct = 0 And RDSel.Item("feines_feta") Then
                        'acumulem import
                        auxsng = Math.Round(RDSel.Item("feines_detall_preu_un") * RDSel.Item("feines_detall_quantitat"), 2)
                        LlocImport += auxsng
                        'carreguem taula d'assignació de xecs amb 1 reg. x hora de Neteja
                        'de feines amb import >= VALORDFTXEC i sense quota
                        If RDSel.Item("serveis_nom") = "Neteja" And RDSel.Item("feines_feta") And auxsng >= VALORDFTXEC Then
                            For k = 1 To CLng(RDSel.Item("feines_detall_quantitat") - 0.1)
                                ReDim Preserve tasig(dimasig)
                                tasig(dimasig).feina = RDSel.Item("feines_id")
                                tasig(dimasig).xec = 0
                                tasig(dimasig).fila = i + 1
                                tasig(dimasig).costh = RDSel.Item("feines_detall_preu_un")
                                dimasig += 1
                            Next
                        End If
                    End If

                    'gravem registre en grid
                    dgvFactura.Rows.Add()
                    i += 1
                    dgvFactura.Rows(i).Cells("Feina").Value = RDSel.Item("feines_id")
                    dgvFactura.Rows(i).Cells("Feina").ToolTipText = "Fés click per modificar la feina #" & RDSel.Item("feines_id")
                    dgvFactura.Rows(i).Cells("Data").Value = Format(RDSel.Item("feines_data"), "d")
                    dgvFactura.Rows(i).Cells("Lloc").Value = RDSel.Item("llocs_nom")
                    dgvFactura.Rows(i).Cells("Recurs").Value = RDSel.Item("recursos_nom")
                    dgvFactura.Rows(i).Cells("Feta").Value = IIf(RDSel.Item("feines_feta"), "Si", "No")
                    If Not RDSel.Item("feines_feta") Then
                        dgvFactura.Rows(i).Cells("Feta").Style.Font = auxFontBold
                    End If
                    If IsDBNull(RDSel.Item("feines_data_factura")) Then
                        dgvFactura.Rows(i).Cells("Datafra").Value = ""
                    Else
                        dgvFactura.Rows(i).Cells("Datafra").Value = RDSel.Item("feines_data_factura")
                    End If
                    dgvFactura.Rows(i).Cells("Servei").Value = RDSel.Item("serveis_nom")
                    dgvFactura.Rows(i).Cells("Quantitat").Value = RDSel.Item("feines_detall_quantitat")
                    dgvFactura.Rows(i).Cells("Unitat").Value = RDSel.Item("feines_detall_unitat")
                    dgvFactura.Rows(i).Cells("ImportServei").Value = IIf(QuotaAct = 0 And RDSel.Item("feines_feta"), RDSel.Item("feines_detall_preu_un") * RDSel.Item("feines_detall_quantitat"), "")
                    dgvFactura.Rows(i).Cells("Quota").Value = QuotaAct
                    dgvFactura.Rows(i).Cells("Observacions").Value = RDSel.Item("feines_observacions")

                    If RDSel.Item("feines_feta") Then
                        TotalHores = TotalHores + RDSel.Item("feines_detall_quantitat") * RDSel.Item("serveis_minuts_per_unitat") / 60
                    End If

                End While

                'gravem ultim subtotal lloc
                dgvFactura.Rows.Add()
                i += 1
                dgvFactura.Rows(i).Cells("Lloc").Value = LlocAct
                If QuotaAct <> 0 Then
                    dgvFactura.Rows(i).Cells("Quantitat").Value = "QUOTA"
                End If
                dgvFactura.Rows(i).Cells("Unitat").Value = "TOTAL"
                dgvFactura.Rows(i).Cells("ImportServei").Value = LlocImport

                dgvFactura.Rows(i).Cells("Feina").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Data").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Lloc").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Recurs").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Feta").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Datafra").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Servei").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Quantitat").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Unitat").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("ImportServei").Style.BackColor = dgvFactura.GridColor

                TotalImport += LlocImport
                dgvFactura.Rows(i).Selected = True
            End If
            RDSel.Close()

            'carrega grid xecs amb els del client/mes 
            'els assignats a feines + els no assignats entrats en el mes
            CMDSel.Parameters.Clear()
            CMDSel.CommandText = "SELECT Xecs.*, Feines.feines_data, Feines.feines_data_factura" & _
            " FROM Feines RIGHT JOIN Xecs ON Feines.feines_id = Xecs.feines_id" & _
            " WHERE (((Feines.feines_data)>=@dataini And (Feines.feines_data)<@datafi) AND ((Xecs.clients_nom)=@client))" & _
            " OR (((Feines.feines_data) Is Null) AND ((Xecs.xecs_data_entrega)>=@dataini And (Xecs.xecs_data_entrega)<@datafi) AND ((Xecs.clients_nom)=@client))" & _
            " ORDER BY Xecs.xecs_data_liquidat DESC , Xecs.xecs_data_entrega"
            CMDSel.Parameters.Add("@dataini", OleDbType.Date).Value = auxdata
            CMDSel.Parameters.Add("@datafi", OleDbType.Date).Value = DateAdd(DateInterval.Month, 1, auxdata)
            CMDSel.Parameters.Add("@client", OleDbType.Char, 50).Value = cmbSelClients.Text
            RDSel = CMDSel.ExecuteReader
            primer = True
            If RDSel.HasRows Then
                'i els anem assignant a les feines de la grid, servei "Neteja"
                'fins que en tenim NMAXXECSMES (compten tots, liquidats i no)
                'cal tenir en compte que si n'hi ha d'assignats no liquidats, es matxaca l'assignació

                i = -1
                While RDSel.Read

                    'si pdt. facturar, no mostrem els liquidats (== ni feines facturades)
                    If Not (chkPdtFacturar.Checked And Not IsDBNull(RDSel.Item("xecs_data_liquidat"))) Then

                        'si xec liquidat, el mostrem tal com està asignat
                        If Not IsDBNull(RDSel.Item("xecs_data_liquidat")) Then
                            dgvXecs.Rows.Add()
                            i += 1
                            dgvXecs.Rows(i).Cells("DataEntrega").Value = RDSel.Item("xecs_data_entrega")
                            dgvXecs.Rows(i).Cells("NroXec").Value = Format(RDSel.Item("xecs_id"), "000000000")
                            dgvXecs.Rows(i).Cells("Client").Value = RDSel.Item("clients_nom")
                            dgvXecs.Rows(i).Cells("FeinaXec").Value = RDSel.Item("feines_id")
                            dgvXecs.Rows(i).Cells("DataLiquidat").Value = RDSel.Item("xecs_data_liquidat")
                            dgvXecs.Rows(i).Cells("ServeiFeina").Value = "Neteja"
                            dgvXecs.Rows(i).Cells("QuantitatFeina").Value = 1
                            dgvXecs.Rows(i).Cells("UnitatFeina").Value = "Hores"
                            dgvXecs.Rows(i).Cells("ImportXec").Value = RDSel.Item("xecs_valor")

                            primer = False

                            'eliminem un element lliure de la feina en tasig
                            For k = 0 To dimasig - 1
                                If tasig(k).feina = RDSel.Item("feines_id") And tasig(k).xec = 0 Then
                                    tasig(k).xec = RDSel.Item("xecs_id")
                                    'actualitzem el servei neteja de la feina al cost d'hora amb xec (en la grid)
                                    auxsng = COSTHORAXEC - tasig(k).costh
                                    'dgvFactura(9, tasig(k).fila).Value = CSng(dgvFactura(9, tasig(k).fila).Value) + auxsng
                                    dgvFactura.Rows(tasig(k).fila).Cells("ImportServei").Value = CSng(dgvFactura.Rows(tasig(k).fila).Cells("ImportServei").Value) + auxsng
                                    'actualitzem el total lloc (seguent)
                                    For n = tasig(k).fila + 1 To dgvFactura.RowCount - 1
                                        If dgvFactura.Rows(n).Cells("Unitat").Value = "TOTAL" Then
                                            dgvFactura.Rows(n).Cells("ImportServei").Value = CSng(dgvFactura.Rows(n).Cells("ImportServei").Value) + auxsng
                                            Exit For
                                        End If
                                    Next
                                    'actualitzem l'import total serveis
                                    TotalImport = TotalImport + auxsng
                                    Exit For
                                End If
                            Next

                            idfeinasig = RDSel.Item("feines_id")

                        Else
                            'si xec no liquidat, l'assignem/reassignem (en la grid)
                            idfeinasig = 0

                            'només fins a NMAXXECSMES
                            If nxecs < NMAXXECSMES Then

                                For k = 0 To dimasig - 1
                                    If tasig(k).xec = 0 Then
                                        tasig(k).xec = RDSel.Item("xecs_id")
                                        idfeinasig = tasig(k).feina
                                        'actualitzem el servei neteja de la feina al cost d'hora amb xec (en la grid)
                                        auxsng = COSTHORAXEC - tasig(k).costh
                                        'dgvFactura(9, tasig(k).fila).Value = CSng(dgvFactura(9, tasig(k).fila).Value) + auxsng  '"#,##0.00"
                                        dgvFactura.Rows(tasig(k).fila).Cells("ImportServei").Value = CSng(dgvFactura.Rows(tasig(k).fila).Cells("ImportServei").Value) + auxsng  '"#,##0.00"
                                        'actualitzem el total feina (seguent row a "Si")
                                        For n = tasig(k).fila + 1 To dgvFactura.RowCount - 1
                                            If dgvFactura.Rows(n).Cells("Unitat").Value = "TOTAL" Then
                                                'dgvFactura(9, n).Value = CSng(dgvFactura(9, n).Value) + auxsng
                                                dgvFactura.Rows(n).Cells("ImportServei").Value = CSng(dgvFactura.Rows(n).Cells("ImportServei").Value) + auxsng
                                                Exit For
                                            End If
                                        Next
                                        'actualitzem l'import total serveis
                                        TotalImport = TotalImport + auxsng
                                        Exit For
                                    End If
                                Next

                            End If

                            dgvXecs.Rows.Add()
                            i += 1
                            dgvXecs.Rows(i).Cells("DataEntrega").Value = RDSel.Item("xecs_data_entrega")
                            dgvXecs.Rows(i).Cells("NroXec").Value = Format(RDSel.Item("xecs_id"), "000000000")
                            dgvXecs.Rows(i).Cells("Client").Value = RDSel.Item("clients_nom")
                            dgvXecs.Rows(i).Cells("FeinaXec").Value = IIf(idfeinasig = 0, "", CStr(idfeinasig))
                            dgvXecs.Rows(i).Cells("DataLiquidat").Value = "" 'no està liquidat
                            dgvXecs.Rows(i).Cells("ServeiFeina").Value = IIf(idfeinasig <> 0, "Neteja", "")
                            dgvXecs.Rows(i).Cells("QuantitatFeina").Value = IIf(idfeinasig <> 0, 1, "")
                            dgvXecs.Rows(i).Cells("UnitatFeina").Value = IIf(idfeinasig <> 0, "Hores", "")
                            dgvXecs.Rows(i).Cells("ImportXec").Value = IIf(idfeinasig <> 0, Format(RDSel.Item("xecs_valor"), "#,##0.00"), Format(0, "#,##0.00"))

                            primer = False

                        End If

                    End If

                    If idfeinasig <> 0 Then     'només comptem els xecs assignats
                        nxecs = nxecs + 1
                        impxecs = impxecs + RDSel.Item("xecs_valor")
                    End If

                End While
                If dgvXecs.Rows.Count > 0 Then dgvXecs.Rows(i).Selected = True

            End If
            RDSel.Close()

            txtTotalFacturar.Text = Format(TotalImport - impxecs - CSng(IIf(IsNumeric(txtPagaments.Text), txtPagaments.Text, "0")), "C")

        Else    'si client no seleccionat -> grid feines no fetes + xecs liquidats mes
            Label17.Text = "Serveis no fets:"

            'carrega grid factura amb feines no fetes del mes
            CMDSel.CommandText = "SELECT Llocs.llocs_quota, Feines.feines_id, Feines.feines_data, Feines.llocs_nom, Feines.recursos_nom, Feines.feines_feta, Feines.feines_data_factura, Feines.feines_quota, Feines.feines_observacions, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_quantitat, Feines_Detall.feines_detall_unitat, Feines_Detall.feines_detall_preu_un, Serveis.serveis_minuts_per_unitat " & _
            "FROM Serveis INNER JOIN ((Llocs INNER JOIN Feines ON Llocs.llocs_nom = Feines.llocs_nom) INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
            "WHERE (NOT Feines.feines_feta AND ((Feines.feines_data)>=@dataini AND (Feines.feines_data)<@datafi)) " & _
            "ORDER BY Feines.llocs_nom, Feines.feines_data, Feines.feines_id, Feines_Detall.serveis_nom, Feines_Detall.feines_detall_unitat"
            CMDSel.Parameters.Add("@dataini", OleDbType.Date).Value = auxdata
            CMDSel.Parameters.Add("@datafi", OleDbType.Date).Value = DateAdd(DateInterval.Month, 1, auxdata)

            RDSel = CMDSel.ExecuteReader
            If RDSel.HasRows Then

                i = -1
                While RDSel.Read

                    'tractament primer element
                    If primer Then
                        FeinaAct = RDSel.Item("feines_id")
                        FeinaFeta = RDSel.Item("feines_feta")
                        LlocAct = RDSel.Item("llocs_nom")
                        QuotaAct = RDSel.Item("llocs_quota")
                        LlocImport = QuotaAct
                        primer = False
                    End If

                    'si canvia el lloc
                    If LlocAct <> RDSel.Item("llocs_nom") Then
                        'gravem subtotal lloc
                        dgvFactura.Rows.Add()
                        i += 1
                        dgvFactura.Rows(i).Cells("Lloc").Value = LlocAct
                        If QuotaAct <> 0 Then
                            dgvFactura.Rows(i).Cells("Quantitat").Value = "QUOTA"
                        End If
                        dgvFactura.Rows(i).Cells("Unitat").Value = "TOTAL"
                        dgvFactura.Rows(i).Cells("ImportServei").Value = LlocImport

                        dgvFactura.Rows(i).Cells("Feina").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Data").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Lloc").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Recurs").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Feta").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Datafra").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Servei").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Quantitat").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("Unitat").Style.BackColor = dgvFactura.GridColor
                        dgvFactura.Rows(i).Cells("ImportServei").Style.BackColor = dgvFactura.GridColor

                        'inicialitzem dades lloc
                        FeinaAct = RDSel.Item("feines_id")
                        FeinaFeta = RDSel.Item("feines_feta")
                        LlocAct = RDSel.Item("llocs_nom")
                        QuotaAct = RDSel.Item("llocs_quota")
                        LlocImport = QuotaAct
                    End If

                    'gravem registre en grid
                    dgvFactura.Rows.Add()
                    i += 1
                    dgvFactura.Rows(i).Cells("Feina").Value = RDSel.Item("feines_id")
                    dgvFactura.Rows(i).Cells("Feina").ToolTipText = "Fés click per modificar la feina #" & RDSel.Item("feines_id")
                    dgvFactura.Rows(i).Cells("Data").Value = Format(RDSel.Item("feines_data"), "d")
                    dgvFactura.Rows(i).Cells("Lloc").Value = RDSel.Item("llocs_nom")
                    dgvFactura.Rows(i).Cells("Recurs").Value = RDSel.Item("recursos_nom")
                    dgvFactura.Rows(i).Cells("Feta").Value = IIf(RDSel.Item("feines_feta"), "Si", "No")
                    dgvFactura.Rows(i).Cells("Feta").Style.Font = auxFontBold
                    dgvFactura.Rows(i).Cells("Datafra").Value = ""
                    dgvFactura.Rows(i).Cells("Servei").Value = RDSel.Item("serveis_nom")
                    dgvFactura.Rows(i).Cells("Quantitat").Value = RDSel.Item("feines_detall_quantitat")
                    dgvFactura.Rows(i).Cells("Unitat").Value = RDSel.Item("feines_detall_unitat")
                    dgvFactura.Rows(i).Cells("ImportServei").Value = IIf(QuotaAct = 0 And RDSel.Item("feines_feta"), RDSel.Item("feines_detall_preu_un") * RDSel.Item("feines_detall_quantitat"), "")
                    dgvFactura.Rows(i).Cells("Quota").Value = QuotaAct
                    dgvFactura.Rows(i).Cells("Observacions").Value = RDSel.Item("feines_observacions")
                End While

                'gravem ultim subtotal lloc
                dgvFactura.Rows.Add()
                i += 1
                dgvFactura.Rows(i).Cells("Lloc").Value = LlocAct
                If QuotaAct <> 0 Then
                    dgvFactura.Rows(i).Cells("Quantitat").Value = "QUOTA"
                End If
                dgvFactura.Rows(i).Cells("Unitat").Value = "TOTAL"
                dgvFactura.Rows(i).Cells("ImportServei").Value = LlocImport

                dgvFactura.Rows(i).Cells("Feina").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Data").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Lloc").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Recurs").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Feta").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Datafra").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Servei").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Quantitat").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("Unitat").Style.BackColor = dgvFactura.GridColor
                dgvFactura.Rows(i).Cells("ImportServei").Style.BackColor = dgvFactura.GridColor

                dgvFactura.Rows(i).Selected = True
            End If
            RDSel.Close()

            'carreguem xecs liquidats del mes (els assignats a feines del mes i liquidats)
            CMDSel.CommandText = "SELECT Xecs.xecs_data_entrega, Xecs.xecs_id, Xecs.clients_nom, Xecs.feines_id, Xecs.xecs_data_liquidat, Xecs.xecs_valor" & _
            " FROM Feines INNER JOIN Xecs ON Feines.feines_id = Xecs.feines_id" & _
            " WHERE Feines.feines_data>=@dataini And Feines.feines_data<@datafi AND Xecs.xecs_data_liquidat Is Not Null"
            CMDSel.Parameters.Add("@dataini", OleDbType.Date).Value = auxdata
            CMDSel.Parameters.Add("@datafi", OleDbType.Date).Value = DateAdd(DateInterval.Month, 1, auxdata)
            RDSel = CMDSel.ExecuteReader
            'primer = True
            If RDSel.HasRows Then
                i = -1
                While RDSel.Read

                    dgvXecs.Rows.Add()
                    i += 1
                    dgvXecs.Rows(i).Cells("DataEntrega").Value = RDSel.Item("xecs_data_entrega")
                    dgvXecs.Rows(i).Cells("NroXec").Value = Format(RDSel.Item("xecs_id"), "000000000")
                    dgvXecs.Rows(i).Cells("Client").Value = RDSel.Item("clients_nom")
                    dgvXecs.Rows(i).Cells("FeinaXec").Value = RDSel.Item("feines_id")
                    dgvXecs.Rows(i).Cells("DataLiquidat").Value = RDSel.Item("xecs_data_liquidat")
                    dgvXecs.Rows(i).Cells("ServeiFeina").Value = "Neteja"
                    dgvXecs.Rows(i).Cells("QuantitatFeina").Value = 1
                    dgvXecs.Rows(i).Cells("UnitatFeina").Value = "Hores"
                    dgvXecs.Rows(i).Cells("ImportXec").Value = RDSel.Item("xecs_valor")

                    'primer = False
                    nxecs = nxecs + 1
                    impxecs = impxecs + RDSel.Item("xecs_valor")

                End While

                If dgvXecs.Rows.Count > 0 Then dgvXecs.Rows(i).Selected = True

            End If
            RDSel.Close()

            txtTotalFacturar.Text = Format(0, "C")

        End If

        'tanquem connexió
        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        'dgvFactura.ResumeLayout()
        'dgvXecs.ResumeLayout()

        'per desactivar el roll del combobox client
        'dgvFactura.Focus()

        'mostrem totals
        txtTotalHores.Text = Format(TotalHores, "N")
        txtTotalServeis.Text = Format(TotalImport, "C")
        txtTotalNXecs.Text = nxecs
        txtTotalXecs.Text = Format(impxecs, "C")

    End Sub

    Private Sub frmPrincipal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If TabControl1.SelectedIndex = 0 Then   'pestanya agenda
            'Debug.WriteLine("frmPrincipal_KeyDown pestanya agenda " & e.Modifiers.ToString & "+" & e.KeyCode.ToString)
            If e.Modifiers.ToString = "Control" And e.KeyCode.ToString = "P" Then
                If MsgBox("Imprimir agenda?", MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
                    'imprimir l'agenda
                    Me.Cursor = Cursors.WaitCursor

                    frmImpressio.Close()
                    frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
                    'frmImpressio.CrystalReportViewer1.DisplayGroupTree = False
                    frmImpressio.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmImpressio.WindowState = FormWindowState.Maximized
                    frmImpressio.Show()
                    frmImpressio.BringToFront()

                    If AgendaGrid.VisualizationMode = PlaniGrid.PGMode.Day Then
                        frmImpressio.CrystalReportViewer1.ReportSource = AgendaGrid.PGPrint(DiaCatala(Format(AgendaGrid.DisplayDate, "dddd")))
                    Else
                        frmImpressio.CrystalReportViewer1.ReportSource = AgendaGrid.PGPrint("")
                    End If
                    frmImpressio.CrystalReportViewer1.ShowFirstPage()

                    frmImpressio.Text = frmImpressio.CrystalReportViewer1.ReportSource.SummaryInfo.ReportTitle
                    'frmImpressio.CrystalReportViewer1.Refresh()

                    Me.Cursor = Cursors.Default
                End If
            End If
        End If

        If TabControl1.SelectedIndex = 2 Then   'pestanya clients

            'Debug.WriteLine("frmPrincipal_KeyDown tab 2 " & e.KeyValue)

            If e.KeyCode = Keys.Enter Then
                'per fer que es validi el panel
                tvClients.Focus()
            End If

            'per fer que es reiniciin les dades del panell actiu
            If e.KeyCode = Keys.Escape Then

                If pnlClients.Visible Then
                    If tvClients.SelectedNode.Text = "# Nou client" Then
                        ClientsBindingSource.CancelEdit()
                        ClientsBindingSource.AddNew()
                    Else
                        ClientsBindingSource.ResetCurrentItem()
                    End If
                    StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
                    'per fer que es validi el panel
                    tvClients.Focus()
                End If

                If pnlLlocs.Visible Then
                    If tvClients.SelectedNode.Text = "# Llocs" Then
                        LlocsBindingSource.CancelEdit()
                        LlocsBindingSource.AddNew()
                        Clients_nomTextBox1.Text = tvClients.SelectedNode.Parent.Text
                    Else
                        LlocsBindingSource.ResetCurrentItem()
                        Clients_nomTextBox1.Text = tvClients.SelectedNode.Parent.Parent.Text
                    End If
                    StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
                    'per fer que es validi el panel
                    tvClients.Focus()
                End If

                If pnlServeis.Visible Then
                    If tvClients.SelectedNode.Text = "# Serveis" Then
                        Llocs_ServeisBindingSource.CancelEdit()
                        Llocs_ServeisBindingSource.AddNew()
                        Llocs_nomTextBox1.Text = tvClients.SelectedNode.Parent.Text
                        Serveis_nomComboBox.SelectedIndex = -1
                    Else
                        Llocs_ServeisBindingSource.ResetCurrentItem()
                        Llocs_nomTextBox1.Text = tvClients.SelectedNode.Parent.Parent.Text
                    End If
                    StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
                    'per fer que es validi el panel
                    tvClients.Focus()
                End If

                If pnlXecs.Visible Then
                    If tvClients.SelectedNode.Text = "# Xecs" Then
                        XecsBindingSource.CancelEdit()
                        XecsBindingSource.AddNew()
                        Clients_nomTextBox2.Text = tvClients.SelectedNode.Parent.Text
                    Else
                        XecsBindingSource.ResetCurrentItem()
                        Clients_nomTextBox2.Text = tvClients.SelectedNode.Parent.Parent.Text
                    End If
                    StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
                    'per fer que es validi el panel
                    tvClients.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub RecursosSelDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles RecursosSelDataGridView.CellFormatting

        e.CellStyle.BackColor = ObtenirColorRecurs(RecursosSelDataGridView("recursos_nom", e.RowIndex).Value)

        If RecursosSelDataGridView("recursos_grup", e.RowIndex).Value Then
            e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
        End If

        RecursosSelDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Arrossega a l'agenda o fés dobleclic per modificar. Fés <Esc> per desseleccionar."

    End Sub

    Private Function IntegerToColor(ByVal pint As Integer) As Color
        'IntegerToColor = Color.FromArgb(255, Color.FromArgb(pint))
        IntegerToColor = ColorTranslator.FromWin32(pint)
    End Function

    Private Function ColorToInteger(ByVal pcolor As Color) As Integer
        'ColorToInteger = pcolor.ToArgb
        ColorToInteger = ColorTranslator.ToWin32(pcolor)
    End Function

    Private Sub LlocsSelDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles LlocsSelDataGridView.CellFormatting
        LlocsSelDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Arrossega a l'agenda o fés dobleclic per modificar."
    End Sub

    Private Sub RecursosSelDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles RecursosSelDataGridView.CellMouseDoubleClick
        'anar a manteniment del recurs

        'ens posicionem al grid (no cal perque comparteix index amb grid seleccio
        'Debug.WriteLine(auxrecurs)

        'canviem a la pestanya recursos i serveis
        TabControl1.SelectedTab = TabControl1.TabPages("TabPageRecursosIServeis")

    End Sub


    Private Sub RecursosSelDataGridView_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles RecursosSelDataGridView.CellMouseMove
        Dim returnValue As DragDropEffects
        Dim auxPGRecurs As PlaniGrid.PGResource
        Dim auxPGRecursos As Dictionary(Of String, Color)
        Dim auxRecursSel As PlaniFeinesDataSet.RecursosRow
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow
        Dim auxRecursComp As PlaniFeinesDataSet.RecursosRow
        Dim auxColorFeina As Color

        'si estem arrossegant
        If e.Button = Windows.Forms.MouseButtons.Left Then
            auxPGRecursos = New Dictionary(Of String, Color)

            'obtenir el registre recurs associat a la fila del datagrid
            auxRecursSel = CType(RecursosBindingSource.Item(e.RowIndex), DataRowView).Row

            auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(auxRecursSel.recursos_nom, "'", "''") & "'")
            'si el recurs es compost afegim els seus components i afegim el color del compost al de la feina
            If auxRecursosComp.Count > 0 Then
                For Each r2 In auxRecursosComp
                    auxRecursComp = PlaniFeinesDataSet.Recursos.FindByrecursos_nom(r2.recursos_component_nom)
                    auxPGRecurs = New PlaniGrid.PGResource(auxRecursComp.recursos_nom, IntegerToColor(auxRecursComp.recursos_color))
                    auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
                Next
            Else
                'si el recurs es simple l'afegim i el seu color a la feina
                auxPGRecurs = New PlaniGrid.PGResource(auxRecursSel.recursos_nom, IntegerToColor(auxRecursSel.recursos_color))
                auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
            End If
            auxColorFeina = AgendaGrid.PGResourcesColor(auxPGRecursos)

            If auxPGRecursos.Count > 0 Then
                returnValue = DoDragDrop(auxPGRecursos, DragDropEffects.Copy Or DragDropEffects.Move)
            End If
        End If

    End Sub

    Private Sub RecursosSelDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RecursosSelDataGridView.KeyDown
        If e.KeyCode = Keys.Escape Then
            RecursosSelDataGridView.ClearSelection()
            e.Handled = True
        End If
    End Sub

    Private Sub AgendaGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AgendaGrid.MouseClick
        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
    End Sub

    Private Sub AgendaGrid_PGElement_Added(ByVal pPGElement As PlaniGrid.PGElement) Handles AgendaGrid.PGElement_Added

        If pPGElement.Id = "" Then
            'afegir feina a BBDD
            If AfegirFeina(pPGElement) Then
                'actualitzar id feina a PlaniGrid
                If AgendaGrid.PGElementChangeId("", pPGElement.Id) = PlaniGrid.PGReturnCode.PGError Then
                    MsgBox("error en PGElementChangeId")
                    Exit Sub
                End If
            Else
                MsgBox("error en AgendaGrid_PGElement_Added " & pPGElement.Id)
                Exit Sub
            End If
        End If

        If Not frmMissatges.Visible Then
            If textFormMissatges = "" Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "Afegit element #" & pPGElement.Id
                'Else
                '    textFormMissatges = textFormMissatges & vbCrLf & "Afegit element #" & pPGElement.Id
            End If
        End If

        AgendaGrid.Focus()
        RecursosSelDataGridView.ClearSelection()
        LlocsSelDataGridView.ClearSelection()

    End Sub

    Private Sub AgendaGrid_PGElement_Clicked(ByVal pPGElement As PlaniGrid.PGElement) Handles AgendaGrid.PGElement_Clicked

        'Debug.WriteLine("AgendaGrid_PGElement_Clicked " & pPGElement.Id)

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()

    End Sub

    Private Sub AgendaGrid_PGElement_Deleted(ByVal pPGElement As PlaniGrid.PGElement) Handles AgendaGrid.PGElement_Deleted

        If Not EliminarFeina(pPGElement) Then
            MsgBox("error en AgendaGrid_PGElement_Deleted " & pPGElement.Id)
            Exit Sub
        End If

        StatusStrip1.Items("ToolStripStatusLabel2").Text = "Eliminat element #" & pPGElement.Id

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()
    End Sub

    Private Sub AgendaGrid_PGElement_DoubleClicked(ByVal pPGElement As PlaniGrid.PGElement) Handles AgendaGrid.PGElement_DoubleClicked

        'passem parametre a frmFeina
        frmFeina.pPGElement = New PlaniGrid.PGElement(pPGElement)

        If frmFeina.ShowDialog() = Windows.Forms.DialogResult.OK Then
            AgendaGrid.RefreshGrid()
            'Carrega_Grid_Agenda()
            Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
            Carrega_TreeView_Clients()

            StatusStrip1.Items("ToolStripStatusLabel2").Text = "Actualitzat element #" & pPGElement.Id
        End If

        AgendaGrid.PGElementSelectById(pPGElement.Id)

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()

    End Sub

    Private Sub AgendaGrid_PGElement_KeyDown(ByVal pPGElement As PlaniSoftwareControlLibrary.PlaniGrid.PGElement, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles AgendaGrid.PGElement_KeyDown

        'mostra detall feina
        If e.KeyCode = Keys.Enter Then
            'passem parametre a frmFeina
            frmFeina.pPGElement = New PlaniGrid.PGElement(pPGElement)

            If frmFeina.ShowDialog() = Windows.Forms.DialogResult.OK Then
                AgendaGrid.RefreshGrid()
                Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
                Carrega_TreeView_Clients()

                StatusStrip1.Items("ToolStripStatusLabel2").Text = "Actualitzat element #" & pPGElement.Id
            End If
            AgendaGrid.PGElementSelectById(pPGElement.Id)
        End If

        'canvia feina feta/no feta
        If e.KeyCode = Keys.Space Then
            'per canvia a feta cal que tingui recurs
            If Not pPGElement.Done And pPGElement.Resources.Count = 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "La feina #" & pPGElement.Id & " no té recurs assignat. No pot estar feta."
            Else
                pPGElement.Done = Not pPGElement.Done
                If AgendaGrid.PGElementAddUpdate(pPGElement) = PlaniGrid.PGReturnCode.PGUpdated Then
                    AgendaGrid.RefreshGrid()
                Else
                    StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: A l'actualitzar element #" & pPGElement.Id
                End If
            End If
        End If

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()
    End Sub

    Private Sub AgendaGrid_PGElement_Updated(ByVal pPGElement As PlaniGrid.PGElement) Handles AgendaGrid.PGElement_Updated

        If Not ActualitzarFeina(pPGElement) Then
            MsgBox("error en AgendaGrid_PGElement_Updated " & pPGElement.Id)
            Exit Sub
        End If

        StatusStrip1.Items("ToolStripStatusLabel2").Text = "Actualitzada la feina #" & pPGElement.Id

        AgendaGrid.Focus()
        RecursosSelDataGridView.ClearSelection()
        LlocsSelDataGridView.ClearSelection()

    End Sub

    Private Sub AgendaGrid_PGElements_Unselected() Handles AgendaGrid.PGElements_Unselected
        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
    End Sub

    Private Sub AgendaGrid_PGHScroll(ByVal pOldValue As Integer, ByVal pNewValue As Integer) Handles AgendaGrid.PGHScroll

        If dgvHoresExtra.HorizontalScrollingOffset <> pNewValue Then
            dgvHoresExtra.HorizontalScrollingOffset = pNewValue
        End If

    End Sub

    Private Sub AgendaGrid_PGMessage(ByVal pTMessage As String, ByVal pMessage As String) Handles AgendaGrid.PGMessage
        If frmMissatges.Visible Then
            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & vbCrLf & pTMessage & ": " & pMessage
        Else
            If textFormMissatges = "" Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = pTMessage & ": " & pMessage
            Else
                textFormMissatges = textFormMissatges & vbCrLf & pTMessage & ": " & pMessage
            End If
        End If
        'Debug.WriteLine("AgendaGrid_PGMessage: " & pTMessage & ": " & pMessage)
    End Sub

    Private Sub AgendaGrid_PGMode_Changed(ByVal pMode As PlaniSoftwareControlLibrary.PlaniGrid.PGMode, ByVal pCurrentDate As Date, ByVal pResource As String) Handles AgendaGrid.PGMode_Changed

        'Debug.WriteLine("AgendaGrid_PGMode_Changed " & pMode.ToString & " " & pCurrentDate & " " & pResource)

        If CN Is Nothing Then Exit Sub

        If Calendari.SelectedDate <> pCurrentDate Then
            Calendari.SelectedDate = pCurrentDate
        End If

        If StatusStrip1.Items.Count > 0 Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
        End If

        If PrimerDiaVisualitzatMes <> AgendaGrid.DisplayFirstDate Then
            PrimerDiaVisualitzatMes = AgendaGrid.DisplayFirstDate
            If PrimerDiaVisualitzatMes > UltimDiaCarregat Or PrimerDiaVisualitzatMes < PrimerDiaCarregat Then
                If PrimerDiaVisualitzatMes > UltimDiaCarregat Then
                    UltimDiaCarregat = PrimerDiaVisualitzatMes
                End If
                If PrimerDiaVisualitzatMes < PrimerDiaCarregat Then
                    PrimerDiaCarregat = PrimerDiaVisualitzatMes
                End If
                Carrega_Grid_Agenda()
            End If
        End If

        RecursActual = pResource

        'en modo recurs mostrem hores extra
        If pMode = PlaniGrid.PGMode.Resource And pResource <> "" Then
            AgendaGrid.Dock = DockStyle.None
            AgendaGrid.Size = New Size(SplitContainer1.Panel2.Width, SplitContainer1.Panel2.Height - altPerHoresExtres)
            AgendaGrid.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        Else
            AgendaGrid.Dock = DockStyle.Fill
        End If
        Carrega_Grid_Hores(RecursActual, Calendari.SelectedDate)

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()
    End Sub

    Private Sub AgendaGrid_PGPeriod_Changed(ByVal pMode As PlaniGrid.PGMode, ByVal pCurrentDate As Date) Handles AgendaGrid.PGPeriod_Changed
        Dim missatge As String
        Dim dataAnt As Date = Calendari.SelectedDate

        'Debug.WriteLine("AgendaGrid_PGPeriod_Changed " & pMode.ToString & " " & pCurrentDate & " " & RecursActual)
        If CN Is Nothing Then Exit Sub

        If Calendari.SelectedDate <> pCurrentDate Then
            Calendari.SelectedDate = pCurrentDate
        End If

        If StatusStrip1.Items.Count > 0 Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
        End If

        If PrimerDiaVisualitzatMes <> AgendaGrid.DisplayFirstDate Then
            PrimerDiaVisualitzatMes = AgendaGrid.DisplayFirstDate
            If PrimerDiaVisualitzatMes > UltimDiaCarregat Or PrimerDiaVisualitzatMes < PrimerDiaCarregat Then
                If PrimerDiaVisualitzatMes > UltimDiaCarregat Then
                    UltimDiaCarregat = PrimerDiaVisualitzatMes
                End If
                If PrimerDiaVisualitzatMes < PrimerDiaCarregat Then
                    PrimerDiaCarregat = PrimerDiaVisualitzatMes
                End If
                Carrega_Grid_Agenda()
            End If
        End If

        If pMode = PlaniGrid.PGMode.Resource Then
            Carrega_Grid_Hores(RecursActual, Calendari.SelectedDate)
        End If

        'si la data seleccionada és posterior a l'ultim dia planificat, oferir generar feines
        'només si anem endavant en el temps
        If pMode = PlaniGrid.PGMode.Month And Calendari.SelectedDate > ULTDIAGENERAT And Calendari.SelectedDate > dataAnt Then
            If MsgBox("Vols generar les feines des del " & DateAdd(DateInterval.Day, 1, ULTDIAGENERAT) & " fins al " & Calendari.SelectedDate & "?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.Yes Then
                missatge = Planificar_Feines(DateAdd(DateInterval.Day, 1, ULTDIAGENERAT), Calendari.SelectedDate)
                If missatge <> "" Then
                    MsgBox(missatge)
                End If
                ULTDIAGENERAT = Calendari.SelectedDate
                'informem el peu de pantalla
                ToolStripStatusLabel1.Text = "Últim dia planificat: " & ULTDIAGENERAT
            End If
        End If

        'desselecciona per poder imprimir agenda
        RecursosSelDataGridView.ClearSelection()

    End Sub

    Private Function AfegirFeina(ByRef pPGElement As PlaniGrid.PGElement) As Boolean
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDaddFeina As New OleDbCommand
        Dim CMDSel As New OleDbCommand
        Dim RDSel As OleDbDataReader
        Dim CMDactualitzaDetall As New OleDbCommand
        Dim CMDNewID As New OleDbCommand
        Dim TRANS As OleDbTransaction
        Dim auxstr As String = ObtenirRecursFeina(pPGElement)

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Return False
            End Try
        End If

        TRANS = CN.BeginTransaction

        CMDaddFeina.Connection = CN
        CMDaddFeina.CommandText = "INSERT INTO Feines " & _
        "(llocs_nom, feines_data, feines_hora_inici, feines_hora_fi, recursos_nom) " & _
        "VALUES(@lloc, @data, @horainici, @horafi, @recurs)"
        CMDaddFeina.Parameters.Add("@lloc", OleDbType.Char, 50).Value = pPGElement.Name
        CMDaddFeina.Parameters.Add("@data", OleDbType.Date).Value = pPGElement.Starts.Date
        CMDaddFeina.Parameters.Add("@horainici", OleDbType.Char, 5).Value = pPGElement.Starts.TimeOfDay.ToString
        CMDaddFeina.Parameters.Add("@horafi", OleDbType.Char, 5).Value = pPGElement.Ends.TimeOfDay.ToString
        CMDaddFeina.Parameters.Add("@recurs", OleDbType.Char, 50).Value = IIf(auxstr = "", DBNull.Value, auxstr)

        CMDaddFeina.Transaction = TRANS

        'per recuperar el ID de la feina creada
        CMDNewID.Connection = CN
        CMDNewID.CommandText = "SELECT @@IDENTITY"

        CMDNewID.Transaction = TRANS

        If CMDaddFeina.ExecuteNonQuery > 0 Then
            pPGElement.Id = CMDNewID.ExecuteScalar.ToString
        Else
            TRANS.Rollback()
            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
            Return False
        End If

        'afegim el detall de la feina (serveis del lloc)
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

        'obtenim els serveis del lloc
        CMDSel.Connection = CN
        CMDSel.CommandText = "SELECT Llocs_Serveis.serveis_nom, Llocs_Serveis.llocs_serveis_quantitat, Llocs_Serveis.llocs_serveis_preu_un, Serveis.serveis_unitat " & _
        "FROM Serveis INNER JOIN Llocs_Serveis ON Serveis.serveis_nom = Llocs_Serveis.serveis_nom " & _
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
                    MsgBox("Error al gravar detall feina #" & pPGElement.Id & " " & RDSel.GetString(RDSel.GetOrdinal("serveis_nom")))
                    TRANS.Rollback()
                    If CN.State = ConnectionState.Open Then CN.Close()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                TRANS.Rollback()
                If CN.State = ConnectionState.Open Then CN.Close()
                Return False
            End Try

        End While

        TRANS.Commit()
        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
        Return True

    End Function

    Private Function EliminarFeina(ByRef pPGElement As PlaniGrid.PGElement) As Boolean
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDeliminafeina As New OleDbCommand

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                EliminarFeina = False
                Exit Function
            End Try
        End If

        CMDeliminafeina.Connection = CN
        CMDeliminafeina.CommandText = "DELETE FROM Feines " & _
        "WHERE feines_id = @id"
        CMDeliminafeina.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

        If CMDeliminafeina.ExecuteNonQuery >= 1 Then
            EliminarFeina = True
        Else
            EliminarFeina = False
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Private Function ActualitzarFeina(ByRef pPGElement As PlaniGrid.PGElement) As Boolean
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDactualitzafeina As New OleDbCommand
        Dim auxstr As String

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                ActualitzarFeina = False
                Exit Function
            End Try
        End If

        CMDactualitzafeina.Connection = CN
        CMDactualitzafeina.CommandText = "UPDATE Feines " & _
        "SET llocs_nom = @lloc, feines_data = @data, feines_hora_inici = @horainici, feines_hora_fi = @horafi, recursos_nom = @recurs, feines_feta = @feta " & _
        "WHERE feines_id = @id"
        CMDactualitzafeina.Parameters.Add("@lloc", OleDbType.Char, 50).Value = pPGElement.Name
        CMDactualitzafeina.Parameters.Add("@data", OleDbType.Date).Value = pPGElement.Starts.Date
        CMDactualitzafeina.Parameters.Add("@horainici", OleDbType.Char, 5).Value = pPGElement.Starts.TimeOfDay.ToString
        CMDactualitzafeina.Parameters.Add("@horafi", OleDbType.Char, 5).Value = pPGElement.Ends.TimeOfDay.ToString
        auxstr = ObtenirRecursFeina(pPGElement)
        CMDactualitzafeina.Parameters.Add("@recurs", OleDbType.Char, 50).Value = IIf(auxstr = "", DBNull.Value, auxstr)
        CMDactualitzafeina.Parameters.Add("@feta", OleDbType.Boolean).Value = pPGElement.Done
        CMDactualitzafeina.Parameters.Add("@id", OleDbType.Integer).Value = CInt(pPGElement.Id)

        If CMDactualitzafeina.ExecuteNonQuery >= 1 Then
            ActualitzarFeina = True
        Else
            ActualitzarFeina = False
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Private Function Calcular_Hores_Dia(ByVal pRecurs As String, ByVal pData As Date, ByVal pMode As String) As Single
        Dim CMDSelFeines As New OleDbCommand
        Dim RDSelFeines As OleDbDataReader
        Dim CNopen As Boolean
        Dim HoraIniJornada As TimeSpan = New TimeSpan(0)
        Dim HoraIniFeina As TimeSpan = New TimeSpan(0)
        Dim HoraFiFeina As TimeSpan = New TimeSpan(0)
        Dim foratEntreFeines As TimeSpan = New TimeSpan(0)
        Dim TempsAcum As TimeSpan = New TimeSpan(0)

        Calcular_Hores_Dia = 0

        'obtenim totes les feines del recurs i dia
        If CN Is Nothing Then Exit Function

        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Function
            End Try
        End If

        CMDSelFeines.Connection = CN
        CMDSelFeines.CommandText = "SELECT Feines.* FROM Feines LEFT JOIN Recursos_Components ON Feines.recursos_nom = Recursos_Components.recursos_nom " & _
        "WHERE (((Feines.feines_data)=@data) AND ((Recursos_Components.recursos_component_nom)=@recurs)) OR (((Feines.feines_data)=@data) AND ((Feines.recursos_nom)=@recurs) AND ((Recursos_Components.recursos_component_nom) Is Null)) " & _
        "ORDER BY Feines.feines_hora_inici"
        CMDSelFeines.Parameters.Add("@data", OleDbType.Date).Value = pData
        CMDSelFeines.Parameters.Add("@recurs", OleDbType.Char).Value = pRecurs
        RDSelFeines = CMDSelFeines.ExecuteReader

        While RDSelFeines.Read

            Try
                HoraIniFeina = TimeSpan.Parse(Convert.ToString(RDSelFeines.Item("feines_hora_inici")))
            Catch ex As Exception
                HoraIniFeina = HORAINICI
            End Try

            'calculem forat entre feines (final feina N fins inici N+1)
            'descomptant l'horari de dinar
            If HoraFiFeina <> TimeSpan.Zero Then
                foratEntreFeines = HoraIniFeina - HoraFiFeina
                If HoraFiFeina < HORAINICIDINAR And HoraIniFeina > HORAINICIDINAR And HoraIniFeina <= HORAFINALDINAR Then
                    foratEntreFeines -= (HoraIniFeina - HORAINICIDINAR)
                End If
                If HoraFiFeina >= HORAINICIDINAR And HoraIniFeina <= HORAFINALDINAR Then
                    foratEntreFeines = New TimeSpan(0)
                End If
                If HoraFiFeina >= HORAINICIDINAR And HoraFiFeina < HORAFINALDINAR And HoraIniFeina > HORAFINALDINAR Then
                    foratEntreFeines -= (HORAFINALDINAR - HoraFiFeina)
                End If
                If HoraFiFeina < HORAINICIDINAR And HoraIniFeina > HORAFINALDINAR Then
                    foratEntreFeines -= (HORAFINALDINAR - HORAINICIDINAR)
                End If
            Else
                HoraIniJornada = HoraIniFeina
            End If

            Try
                HoraFiFeina = TimeSpan.Parse(Convert.ToString(RDSelFeines.Item("feines_hora_fi")))
            Catch ex As Exception
                HoraFiFeina = New TimeSpan(HoraIniFeina.Ticks)
                HoraFiFeina += New TimeSpan(0, AgendaGrid.MinutesGap, 0)
            End Try

            Select Case pMode
                Case "EXTRA"
                    TempsAcum += HoraFiFeina - HoraIniFeina '+ foratEntreFeines CANVI CRITERI 2013
                Case "TREBALLADES"
                    TempsAcum += HoraFiFeina - HoraIniFeina
                Case Else   'JORNADA
                    TempsAcum = HoraFiFeina - HoraIniJornada
            End Select

        End While
        RDSelFeines.Close()

        If pMode = "EXTRA" Then
            Calcular_Hores_Dia = IIf((TempsAcum - HORESDIA).TotalHours < 0, 0, (TempsAcum - HORESDIA).TotalHours)
        Else
            Calcular_Hores_Dia = TempsAcum.TotalHours
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Private Function ActualitzarPagament(ByVal pMes As String, ByVal pClient As String, ByVal pImport As Single) As Boolean
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDeliminapagament As New OleDbCommand
        Dim CMDafegeixpagament As New OleDbCommand
        Dim TRANS As OleDbTransaction
        Dim auxint As Integer

        ActualitzarPagament = True

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                ActualitzarPagament = False
                Exit Function
            End Try
        End If

        'control de compromís
        TRANS = CN.BeginTransaction

        'eliminem registre (si existeix)
        CMDeliminapagament.Connection = CN
        CMDeliminapagament.CommandText = "DELETE * FROM Pagaments " & _
        "WHERE (pagaments_mes=@mes AND clients_nom=@client)"
        CMDeliminapagament.Parameters.Add("@mes", OleDbType.Char, 7).Value = pMes
        CMDeliminapagament.Parameters.Add("@client", OleDbType.Char, 50).Value = pClient
        CMDeliminapagament.Transaction = TRANS
        Try
            CMDeliminapagament.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            TRANS.Rollback()
            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
            Return False
        End Try

        'si hores > 0 afegim registre
        If pImport <> 0 Then
            CMDafegeixpagament.Connection = CN
            CMDafegeixpagament.CommandText = "INSERT INTO Pagaments (pagaments_mes, clients_nom, pagaments_import) " & _
             "VALUES (@mes, @client, @import)"
            CMDafegeixpagament.Parameters.Add("@mes", OleDbType.Char, 7).Value = pMes
            CMDafegeixpagament.Parameters.Add("@client", OleDbType.Char, 50).Value = pClient
            CMDafegeixpagament.Parameters.Add("@import", OleDbType.Single).Value = pImport
            CMDafegeixpagament.Transaction = TRANS
            Try
                auxint = CMDafegeixpagament.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
                Return False
            End Try

            If auxint < 1 Then
                MsgBox("No s'ha pogut afegir pagament", MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
                Return False
            End If
        End If

        TRANS.Commit()

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Private Sub ActualitzarHoresExtra(ByVal pRecurs As String, ByVal pData As Date, ByVal pHores As Single)
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDeliminahores As New OleDbCommand
        Dim CMDafegeixhores As New OleDbCommand
        Dim TRANS As OleDbTransaction
        Dim auxint As Integer

        If pRecurs Is Nothing Then Exit Sub

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try
        End If

        'control de compromís
        TRANS = CN.BeginTransaction

        'eliminem registre (si existeix)
        CMDeliminahores.Connection = CN
        CMDeliminahores.CommandText = "DELETE * FROM Hores_Fetes " &
        "WHERE (((Hores_Fetes.recursos_nom)=@recurs) AND ((Hores_Fetes.hores_data)=@data))"
        CMDeliminahores.Parameters.Add("@recurs", OleDbType.Char, 50).Value = pRecurs
        CMDeliminahores.Parameters.Add("@data", OleDbType.Date).Value = pData
        CMDeliminahores.Transaction = TRANS
        Try
            CMDeliminahores.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            TRANS.Rollback()
            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
            Exit Sub
        End Try

        'si hores > 0 afegim registre
        If pHores > 0 Then
            CMDafegeixhores.Connection = CN
            CMDafegeixhores.CommandText = "INSERT INTO Hores_Fetes (recursos_nom, hores_data, hores_quantitat) " &
             "VALUES (@recurs, @data, @quantitat)"
            CMDafegeixhores.Parameters.Add("@recurs", OleDbType.Char, 50).Value = pRecurs
            CMDafegeixhores.Parameters.Add("@data", OleDbType.Date).Value = pData
            CMDafegeixhores.Parameters.Add("@quantitat", OleDbType.Single).Value = pHores
            CMDafegeixhores.Transaction = TRANS
            Try
                auxint = CMDafegeixhores.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
                Exit Sub
            End Try

            If auxint < 1 Then
                MsgBox("No s'ha pogut afegir hores extres", MsgBoxStyle.OkOnly, "ERROR")
                TRANS.Rollback()
                If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
                Exit Sub
            End If
        End If

        TRANS.Commit()

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Sub

    'retorna el recurs a gravar en la feina a partir dels recursos de l'element
    'si és compost i no existeix, el dona d'alta
    Private Function ObtenirRecursFeina(ByVal pPGElement As PlaniGrid.PGElement) As String
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDrecursos As OleDbCommand
        Dim CMDrecursosicomps As OleDbCommand
        Dim RDrecursosicomps As OleDbDataReader
        Dim cmdText As String = "SELECT * FROM Recursos_Components ORDER BY recursos_nom, recursos_component_nom"
        Dim nrectrobats As Integer = 0
        Dim compostactual As String = ""
        Dim auxint As Integer
        Dim nomnoucompost As String = ""
        Dim colornoucompost As Color = Color.Empty
        Dim drvRecurs As DataRowView

        ObtenirRecursFeina = ""

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Function
            End Try
        End If

        'validar que tots els recursos de l'element existeixen a la BBDD
        CMDrecursos = New OleDbCommand()
        CMDrecursos.Connection = CN
        CMDrecursos.CommandText = "SELECT Count(*) FROM Recursos WHERE recursos_nom = @recurs"
        CMDrecursos.Parameters.Add("@recurs", OleDbType.Char)
        For Each r In pPGElement.Resources
            CMDrecursos.Parameters("@recurs").Value = r.Key
            auxint = CMDrecursos.ExecuteScalar
            If auxint <= 0 Then
                MsgBox("Recurs '" & r.Key & "' en element " & pPGElement.Id & " inexistent")
                If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
                Exit Function
            End If
            If nomnoucompost = "" Then
                nomnoucompost = r.Key
            Else
                nomnoucompost &= ("+" & r.Key)
            End If
        Next
        colornoucompost = AgendaGrid.PGResourcesColor(pPGElement.Resources)

        Select Case pPGElement.Resources.Count
            Case 0
                ObtenirRecursFeina = ""

            Case 1
                ObtenirRecursFeina = pPGElement.Resources.First.Key

            Case Else
                CMDrecursosicomps = New OleDbCommand(cmdText, CN)
                RDrecursosicomps = CMDrecursosicomps.ExecuteReader
                While RDrecursosicomps.Read
                    If nrectrobats = pPGElement.Resources.Count And compostactual <> "" And compostactual <> RDrecursosicomps.Item("recursos_nom") Then
                        Exit While
                    End If
                    If compostactual <> RDrecursosicomps.Item("recursos_nom") Then
                        compostactual = RDrecursosicomps.Item("recursos_nom")
                        nrectrobats = 0
                    End If
                    If pPGElement.Resources.ContainsKey(RDrecursosicomps.Item("recursos_component_nom")) Then
                        If nrectrobats >= 0 Then nrectrobats += 1
                    Else
                        nrectrobats = -1
                    End If
                End While
                RDrecursosicomps.Close()

                If nrectrobats = pPGElement.Resources.Count Then
                    ObtenirRecursFeina = compostactual
                End If

                If ObtenirRecursFeina = "" Then
                    ObtenirRecursFeina = nomnoucompost

                    'creem el nou recurs compost i la seva composició

                    'Cal fer-ho al bindingsource pq si no al donar-se d'alta al datagrid a traves
                    'del dataadapter.fill es torna a donar d'alta a la BBDD i dona duplicat

                    drvRecurs = CType(RecursosBindingSource.AddNew(), DataRowView)
                    drvRecurs("Recursos_nom") = nomnoucompost
                    drvRecurs("Recursos_grup") = True
                    'drvRecurs("Recursos_color") = colornoucompost.ToArgb
                    drvRecurs("Recursos_color") = ColorTranslator.ToWin32(colornoucompost)
                    drvRecurs.EndEdit()

                    'actualitzem la BBDD recurs abans de posar-hi els components
                    RecursosTableAdapter.Update(PlaniFeinesDataSet.Recursos)

                    For Each r In pPGElement.Resources
                        Recursos_ComponentsTableAdapter.Insert(nomnoucompost, r.Key)
                    Next
                    'actualitzem la BBDD components
                    Recursos_ComponentsTableAdapter.Update(PlaniFeinesDataSet.Recursos_Components)

                    'reordenem el grid de seleccio de recursos
                    RecursosSelDataGridView.Sort(RecursosSelDataGridView.Columns.Item("recursos_nom"), System.ComponentModel.ListSortDirection.Ascending)
                End If

        End Select

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Public Function Obtenir_nro_recursos(ByVal pRecurs As String) As Integer
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow

        auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(pRecurs, "'", "''") & "'")
        Obtenir_nro_recursos = IIf(auxRecursosComp.Count = 0, 1, auxRecursosComp.Count)

    End Function

    Public Function Calcular_minuts_serveis(ByVal pLloc As String, ByVal pNRecursos As Integer) As Integer
        Dim auxServeisLloc() As PlaniFeinesDataSet.Llocs_ServeisRow
        Dim auxServei As PlaniFeinesDataSet.ServeisRow

        Calcular_minuts_serveis = 0
        auxServeisLloc = PlaniFeinesDataSet.Llocs_Serveis.Select("llocs_nom ='" & Replace(pLloc, "'", "''") & "'")
        If auxServeisLloc.Count > 0 Then
            For Each s In auxServeisLloc
                auxServei = PlaniFeinesDataSet.Serveis.FindByserveis_nom(s.serveis_nom)
                If Not IsDBNull(auxServei) Then
                    If Not auxServei.serveis_comu_per_recursos Then
                        Calcular_minuts_serveis = Calcular_minuts_serveis + (s.llocs_serveis_quantitat * auxServei.serveis_minuts_per_unitat)
                    Else
                        Calcular_minuts_serveis = Calcular_minuts_serveis + ((s.llocs_serveis_quantitat * auxServei.serveis_minuts_per_unitat) / pNRecursos)
                    End If
                End If
            Next
        End If

        'arrodonim a MINGAP's per excés
        'If Calcular_minuts_serveis = 0 Or (Calcular_minuts_serveis Mod MINGAP.TotalMinutes) <> 0 Then
        '    Calcular_minuts_serveis = ((Calcular_minuts_serveis \ MINGAP.TotalMinutes) + 1) * MINGAP.TotalMinutes
        'End If

    End Function

    Private Function ObtenirPagament(ByVal pClient As String, ByVal pMes As String) As Single
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDllegeixpagament As New OleDbCommand
        Dim RDllegeixpagament As OleDbDataReader

        ObtenirPagament = 0

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                ObtenirPagament = False
                Exit Function
            End Try
        End If

        CMDllegeixpagament.Connection = CN
        CMDllegeixpagament.CommandText = "SELECT * FROM Pagaments " & _
        "WHERE (pagaments_mes=@mes AND clients_nom=@client)"
        CMDllegeixpagament.Parameters.Add("@mes", OleDbType.Char, 7).Value = pMes
        CMDllegeixpagament.Parameters.Add("@client", OleDbType.Char, 50).Value = pClient
        RDllegeixpagament = CMDllegeixpagament.ExecuteReader
        If RDllegeixpagament.Read Then
            ObtenirPagament = RDllegeixpagament("pagaments_import")
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

    End Function

    Public Function ObtenirColorRecurs(ByVal pRecurs As String) As Color
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow
        Dim auxRecursComp As PlaniFeinesDataSet.RecursosRow
        Dim auxLlistaRecursos As New Dictionary(Of String, Color)

        auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(pRecurs, "'", "''") & "'")
        'si el recurs es compost calculem el color a partir dels seus components
        If auxRecursosComp.Count > 0 Then
            For Each r2 In auxRecursosComp
                auxRecursComp = PlaniFeinesDataSet.Recursos.FindByrecursos_nom(r2.recursos_component_nom)
                auxLlistaRecursos.Add(auxRecursComp.recursos_nom, IntegerToColor(auxRecursComp.recursos_color))
            Next
            ObtenirColorRecurs = AgendaGrid.PGResourcesColor(auxLlistaRecursos)
        Else
            auxRecursComp = PlaniFeinesDataSet.Recursos.FindByrecursos_nom(pRecurs)
            If auxRecursComp Is Nothing Then
                'si el recurs no existeix, color buit
                ObtenirColorRecurs = RecursosDataGridView.DefaultCellStyle.BackColor
            Else
                'si el recurs es simple pintem del seu color
                ObtenirColorRecurs = IntegerToColor(auxRecursComp.recursos_color)
            End If
        End If

    End Function

    Private Sub Actualitzar_minuts_previst_lloc_actual()
        Dim llocrow As PlaniFeinesDataSet.LlocsRow
        Dim auxnrecursos As Integer

        'actualitzem els minuts previstos del lloc
        'obtenim el row del lloc
        llocrow = CType(CType(LlocsBindingSource.Item(LlocsBindingSource.Position), DataRowView).Row, PlaniFeinesDataSet.LlocsRow)
        If llocrow.recursos_nom = "" Then
            auxnrecursos = 1
        Else
            auxnrecursos = Obtenir_nro_recursos(llocrow.recursos_nom)
        End If
        llocrow.llocs_minuts_previst = Calcular_minuts_serveis(llocrow.llocs_nom, auxnrecursos)
        'actualitzem el lloc 
        Try
            LlocsTableAdapter.Update(PlaniFeinesDataSet.Llocs)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
            LlocsBindingSource.ResetBindings(False)
        End Try
    End Sub

    Private Sub LlocsSelDataGridView_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles LlocsSelDataGridView.GiveFeedback
        e.UseDefaultCursors = False
        If ((e.Effect And DragDropEffects.Copy) = DragDropEffects.Copy) Then
            DragCursor.gEffect = gCursorLib.gCursor.eEffect.Copy
        Else
            DragCursor.gEffect = gCursorLib.gCursor.eEffect.No
        End If
        Cursor.Current = DragCursor.gCursor
    End Sub

    Private Sub Calendari_DateChanged(ByVal pDate As Date) Handles Calendari.DateChanged
        AgendaGrid.DisplayDate = pDate
        dtpSelMes.Value = pDate
    End Sub

    Private Sub RecursosDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles RecursosDataGridView.CellFormatting
        Dim auxColor As Color

        'nomes per files existents
        If RecursosDataGridView.Rows(e.RowIndex).IsNewRow Then Exit Sub

        'formatejem la columna color 
        If e.ColumnIndex = 1 Then
            RecursosDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = ""
            If IsDBNull(RecursosDataGridView.Item("cRecurs", e.RowIndex).Value) Then
                auxColor = RecursosDataGridView.DefaultCellStyle.BackColor
            Else
                If IsDBNull(RecursosDataGridView.Item("cGrup", e.RowIndex).Value) Then
                    RecursosDataGridView.Item("cGrup", e.RowIndex).Value = False
                    RecursosDataGridView.Item("cColor", e.RowIndex).Value = ColorToInteger(RecursosDataGridView.DefaultCellStyle.BackColor)
                End If
                If RecursosDataGridView.Item("cGrup", e.RowIndex).Value Then
                    auxColor = ObtenirColorRecurs(RecursosDataGridView.Item("cRecurs", e.RowIndex).Value)
                    RecursosDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Color combinat dels components."
                Else
                    auxColor = IntegerToColor(RecursosDataGridView.Item("cColor", e.RowIndex).Value)
                    RecursosDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Fés click per seleccionar color."
                End If
            End If
            e.CellStyle.BackColor = auxColor
            e.CellStyle.ForeColor = auxColor
            e.CellStyle.SelectionBackColor = auxColor
            e.CellStyle.SelectionForeColor = auxColor
        End If

        'columna grup
        If e.ColumnIndex = 2 Then
            RecursosDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Fés click per seleccionar components."
        End If

    End Sub

    Private Sub RecursosDataGridView_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RecursosDataGridView.CellLeave
        'netejem els missatges d'error a la barra d'estat
        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""
    End Sub

    Private Sub RecursosDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles RecursosDataGridView.CellMouseClick
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow
        Dim teComponents As Boolean = False
        Dim esComponent As Boolean = False

        If e.RowIndex < 0 Then Exit Sub
        If RecursosDataGridView.Rows(e.RowIndex).IsNewRow Then Exit Sub

        'mirem si el recurs te components
        auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(RecursosDataGridView.Item("cRecurs", e.RowIndex).Value, "'", "''") & "'")
        If auxRecursosComp.Count > 0 Then
            teComponents = True
        End If

        'mirem si el recurs es component
        auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_component_nom ='" & Replace(RecursosDataGridView.Item("cRecurs", e.RowIndex).Value, "'", "''") & "'")
        If auxRecursosComp.Count > 0 Then
            esComponent = True
        End If

        Select Case e.ColumnIndex

            Case 1  'color

                'Nomes es pot fixar color pels recursos que no siguin grup
                If teComponents Then
                    RecursosDataGridView.Rows(e.RowIndex).ErrorText = "Només es pot assignar color als recursos que no siguin grup."
                    Exit Sub
                End If

                'presentem el colordialog
                If Not IsDBNull(RecursosDataGridView("cColor", e.RowIndex).Value) Then
                    ColorDialog1.Color = IntegerToColor(RecursosDataGridView("cColor", e.RowIndex).Value)
                Else
                    ColorDialog1.Color = Color.Empty
                End If

                ColorDialog1.FullOpen = True
                ColorDialog1.SolidColorOnly = True

                If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    RecursosDataGridView.Item("cColor", e.RowIndex).Value = ColorToInteger(ColorDialog1.Color)
                End If
                Me.Validate()
                Me.Refresh()

            Case 2  'grup

                If Me.Validate() Then
                    'si el recurs es component no pot ser grup
                    If esComponent Then
                        RecursosDataGridView.Rows(e.RowIndex).ErrorText = "El recurs pertany a un grup. No pot tenir components."
                        Exit Sub
                    End If

                    'presentem la pantalla components
                    frmComponents.pRecurs = RecursosDataGridView.Item("cRecurs", e.RowIndex).Value
                    If frmComponents.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If frmComponents.pGrup Then
                            RecursosDataGridView.Item("cGrup", e.RowIndex).Value = True
                        Else
                            RecursosDataGridView.Item("cGrup", e.RowIndex).Value = False
                        End If
                        'recarreguem taula components amb els canvis BBDD fets a la pantalla components
                        Me.Recursos_ComponentsTableAdapter.Fill(Me.PlaniFeinesDataSet.Recursos_Components)
                    End If

                    Me.Validate()
                    Me.Refresh()
                End If

        End Select

    End Sub

    Private Sub RecursosDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles RecursosDataGridView.DataError
        'cal mantenir la subrutina encara que no faci res!!!
        'Debug.WriteLine("RecursosDataGridView_DataError Linia " & e.RowIndex & ":" & e.Exception.Message)
    End Sub

    Private Sub RecursosDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RecursosDataGridView.RowValidated

        'Debug.WriteLine("RecursosDataGridView_RowValidated Linia " & e.RowIndex & ":" & RecursosDataGridView.Rows(e.RowIndex).State.ToString)

        RecursosDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

        'actualitzem recursos 
        Try
            Me.RecursosTableAdapter.Update(Me.PlaniFeinesDataSet.Recursos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End Try

        Carrega_combo_recursos()

    End Sub

    Private Sub RecursosDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles RecursosDataGridView.RowValidating
        Dim auxNomRecurs As String
        Dim auxColorRecurs As Integer

        'Debug.WriteLine("RecursosDataGridView_RowValidating Linia " & e.RowIndex & ":" & RecursosDataGridView.Rows(e.RowIndex).State.ToString & " IsNewRow " & RecursosDataGridView.Rows(e.RowIndex).IsNewRow)

        RecursosDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

        If RecursosDataGridView.Rows(e.RowIndex).IsNewRow Then
            Exit Sub
        End If

        'cal informar el nom
        If IsDBNull(RecursosDataGridView.Item("cRecurs", e.RowIndex).Value) Then
            RecursosDataGridView.Rows(e.RowIndex).ErrorText = "Cal assignar un nom al recurs."
            e.Cancel = True
            Exit Sub
        Else
            If RecursosDataGridView.Item("cRecurs", e.RowIndex).Value = "" Then
                RecursosDataGridView.Rows(e.RowIndex).ErrorText = "Cal assignar un nom al recurs."
                e.Cancel = True
                Exit Sub
            End If
        End If

        'cal informar el color
        If IsDBNull(RecursosDataGridView.Item("cColor", e.RowIndex).Value) Then
            RecursosDataGridView.Rows(e.RowIndex).ErrorText = "Cal assignar un color únic al recurs. Fés click a la cel·la color per seleccionar."
            e.Cancel = True
            Exit Sub
        Else
            If RecursosDataGridView.Item("cColor", e.RowIndex).Value = ColorToInteger(RecursosDataGridView.DefaultCellStyle.BackColor) Then
                RecursosDataGridView.Rows(e.RowIndex).ErrorText = "Cal assignar un color únic al recurs. Fés click a la cel·la color per seleccionar."
                e.Cancel = True
                Exit Sub
            End If
        End If

        auxNomRecurs = RecursosDataGridView.Item("cRecurs", e.RowIndex).Value
        auxColorRecurs = RecursosDataGridView.Item("cColor", e.RowIndex).Value

        For i = 0 To RecursosDataGridView.RowCount - 1
            If Not IsDBNull(RecursosDataGridView.Item("cRecurs", i).Value) Then
                'El nom del recurs ha de ser unic
                If i <> e.RowIndex And auxNomRecurs = RecursosDataGridView.Item("cRecurs", i).Value Then
                    RecursosDataGridView.Rows(e.RowIndex).ErrorText = "El nom del recurs ha de ser únic."
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            If Not IsDBNull(RecursosDataGridView.Item("cColor", i).Value) Then
                'El color del recurs ha de ser unic
                If i <> e.RowIndex And auxColorRecurs = RecursosDataGridView.Item("cColor", i).Value Then
                    RecursosDataGridView.Rows(e.RowIndex).ErrorText = "El color del recurs ha de ser únic."
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Next

    End Sub

    Private Sub RecursosDataGridView_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles RecursosDataGridView.UserDeletedRow

        'actualitzem recursos 
        Try
            Me.RecursosTableAdapter.Update(Me.PlaniFeinesDataSet.Recursos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End Try

        Carrega_combo_recursos()

    End Sub

    Private Sub RecursosDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles RecursosDataGridView.UserDeletingRow
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow
        Dim auxLlocs() As PlaniFeinesDataSet.LlocsRow
        Dim CMDFeines As New OleDbCommand
        Dim RDFeines As OleDbDataReader
        Dim CNopen As Boolean

        'validem que no hi hagi registres associats en altres taules

        'si es component d'un altre recurs
        auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_component_nom ='" & Replace(e.Row.Cells("cRecurs").Value, "'", "''") & "'")
        If auxRecursosComp.Count > 0 Then
            RecursosDataGridView.Rows(e.Row.Index).ErrorText = "El recurs forma part del grup '" & auxRecursosComp.First.recursos_nom & "'. No es pot eliminar."
            e.Cancel = True
            Exit Sub
        End If

        'si te llocs associats
        auxLlocs = PlaniFeinesDataSet.Llocs.Select("recursos_nom ='" & Replace(e.Row.Cells("cRecurs").Value, "'", "''") & "'")
        If auxLlocs.Count > 0 Then
            RecursosDataGridView.Rows(e.Row.Index).ErrorText = "El recurs està assignat als lloc '" & auxLlocs.First.recursos_nom & "'. No es pot eliminar."
            e.Cancel = True
            Exit Sub
        End If

        'si té feines associades
        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try
        End If

        CMDFeines.Connection = CN
        CMDFeines.CommandText = "SELECT * " & _
            "FROM Feines " & _
            "WHERE ((recursos_nom = @recurs))"
        CMDFeines.Parameters.Add("@recurs", OleDbType.Char).Value = e.Row.Cells("cRecurs").Value

        RDFeines = CMDFeines.ExecuteReader
        If RDFeines.Read Then
            RecursosDataGridView.Rows(e.Row.Index).ErrorText = "El recurs té feines associades. No es pot eliminar."
            e.Cancel = True
            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
            Exit Sub
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        'solicita confirmació
        If MsgBox("Eliminar recurs '" & e.Row.Cells("cRecurs").Value & "' ?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub ServeisDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles ServeisDataGridView.CellValidating

        ServeisDataGridView.Rows(e.RowIndex).ErrorText = ""

        Select Case ServeisDataGridView.Columns(e.ColumnIndex).Name

            Case "cPreuServei"
                If Not IsNumeric(e.FormattedValue) Then
                    ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: El preu ha de ser numèric."
                    e.Cancel = True
                End If

            Case "cMinutsUnitat"
                If Not IsNumeric(e.FormattedValue) Then
                    ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: La equivalència en minuts de ser numèrica."
                    e.Cancel = True
                Else
                    If CSng(e.FormattedValue) <> CInt(e.FormattedValue) Then
                        ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: La equivalència en minuts no pot ser decimal."
                        e.Cancel = True
                    End If
                End If

        End Select

    End Sub

    Private Sub ServeisDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ServeisDataGridView.DefaultValuesNeeded

        With e.Row
            .Cells("cNomServei").Value = ""
            .Cells("cUnitatServei").Value = ""
            .Cells("cPreuServei").Value = 0
            .Cells("cMinutsUnitat").Value = 0
            .Cells("cComuServei").Value = False
        End With

    End Sub

    Private Sub ServeisDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ServeisDataGridView.RowValidated

        ServeisDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

        'actualitzem servei
        Try
            Me.ServeisTableAdapter.Update(Me.PlaniFeinesDataSet.Serveis)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
        End Try

    End Sub

    Private Sub ServeisDataGridView_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles ServeisDataGridView.RowValidating
        Dim auxNomServei As String

        ServeisDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

        If ServeisDataGridView.CurrentRow.IsNewRow Then Exit Sub

        auxNomServei = ServeisDataGridView.Item("cNomServei", e.RowIndex).Value

        'cal informar el nom del servei 
        If auxNomServei = "" Then
            ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: Cal informar el nom del servei."
            e.Cancel = True
            Exit Sub
        End If

        'El nom del servei ha de ser unic
        For i = 0 To ServeisDataGridView.RowCount - 1
            If i <> e.RowIndex And auxNomServei = ServeisDataGridView.Item("cNomServei", i).Value Then
                ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: El nom del servei ha de ser únic."
                e.Cancel = True
                Exit Sub
            End If
        Next

        'cal informar la unitat del servei
        If ServeisDataGridView.Item("cUnitatServei", e.RowIndex).Value = "" Then
            ServeisDataGridView.Rows(e.RowIndex).ErrorText = "ERROR: Cal informar la unitat del servei."
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub ServeisDataGridView_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ServeisDataGridView.UserDeletedRow

        'actualitzem serveis 
        Try
            Me.ServeisTableAdapter.Update(Me.PlaniFeinesDataSet.Serveis)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
        End Try

    End Sub

    Private Sub ServeisDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles ServeisDataGridView.UserDeletingRow
        Dim auxLlocsServeis() As PlaniFeinesDataSet.Llocs_ServeisRow
        Dim CMDDetallFeines As New OleDbCommand
        Dim RDDetallFeines As OleDbDataReader
        Dim CNopen As Boolean

        'validem que no hi hagi registres associats en altres taules

        'servei en llocs
        auxLlocsServeis = PlaniFeinesDataSet.Llocs_Serveis.Select("serveis_nom ='" & Replace(e.Row.Cells("cNomServei").Value, "'", "''") & "'")
        If auxLlocsServeis.Count > 0 Then
            ServeisDataGridView.Rows(e.Row.Index).ErrorText = "El servei està associat al lloc '" & auxLlocsServeis.First.llocs_nom & "'. No es pot eliminar."
            e.Cancel = True
            Exit Sub
        End If

        'servei en feines
        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try
        End If

        CMDDetallFeines.Connection = CN
        CMDDetallFeines.CommandText = "SELECT * " & _
            "FROM Feines_Detall " & _
            "WHERE ((serveis_nom = @servei))"
        CMDDetallFeines.Parameters.Add("@servei", OleDbType.Char).Value = e.Row.Cells("cNomServei").Value

        RDDetallFeines = CMDDetallFeines.ExecuteReader
        If RDDetallFeines.Read Then
            ServeisDataGridView.Rows(e.Row.Index).ErrorText = "El servei té feines associades. No es pot eliminar."
            e.Cancel = True
            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()
            Exit Sub
        End If

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        'solicita confirmació
        If MsgBox("Eliminar servei '" & e.Row.Cells("cNomServei").Value & "' ?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub Carrega_TreeView_Clients()
        Dim auxNodeClient As TreeNode
        Dim auxNodeLlocs As TreeNode
        Dim auxNodeLloc As TreeNode
        Dim auxNodeServeis As TreeNode
        Dim auxNodeXecs As TreeNode
        Dim auxNodeXec As TreeNode
        Dim filtreLlocs As DataView
        Dim filtreServeis As DataView
        Dim filtreXecs As DataView
        Dim auxFontBold As Font = New Font(tvClients.Font, FontStyle.Bold)
        Dim auxFontItalic As Font = New Font(tvClients.Font, FontStyle.Italic)

        tvClients.BeginUpdate()
        tvClients.Nodes.Clear()

        filtreLlocs = PlaniFeinesDataSet.Llocs.DefaultView
        filtreServeis = PlaniFeinesDataSet.Llocs_Serveis.DefaultView
        filtreXecs = PlaniFeinesDataSet.Xecs.DefaultView

        auxNodeClient = tvClients.Nodes.Add("# Nou client")
        auxNodeClient.ToolTipText = "Fés click per afegir un client."
        auxNodeClient.NodeFont = auxFontBold

        For Each regClient In PlaniFeinesDataSet.Clients
            auxNodeClient = tvClients.Nodes.Add(Trim(regClient("clients_nom")))
            auxNodeLlocs = auxNodeClient.Nodes.Add("# Llocs")
            auxNodeLlocs.ToolTipText = "Fés click per afegir un lloc al client."
            auxNodeLlocs.NodeFont = auxFontBold

            filtreLlocs.RowFilter = "clients_nom = '" & Replace(Trim(regClient("clients_nom")), "'", "''") & "'"
            For i = 0 To filtreLlocs.Count - 1
                auxNodeLloc = auxNodeLlocs.Nodes.Add(filtreLlocs.Item(i).Row("llocs_nom"))
                auxNodeServeis = auxNodeLloc.Nodes.Add("# Serveis")
                auxNodeServeis.ToolTipText = "Fés click per afegir un servei al lloc."
                auxNodeServeis.NodeFont = auxFontBold

                filtreServeis.RowFilter = "llocs_nom = '" & Replace(Trim(filtreLlocs.Item(i).Row("llocs_nom")), "'", "''") & "'"
                For j = 0 To filtreServeis.Count - 1
                    auxNodeServeis.Nodes.Add(filtreServeis.Item(j).Row("serveis_nom"))
                Next
            Next
            If regClient("clients_xecs") Then
                auxNodeXecs = auxNodeClient.Nodes.Add("# Xecs")
                auxNodeXecs.ToolTipText = "Fés click per afegir un xec al client."
                auxNodeXecs.NodeFont = auxFontBold
                filtreXecs.RowFilter = "clients_nom = '" & Replace(Trim(regClient("clients_nom")), "'", "''") & "'"
                For k = 0 To filtreXecs.Count - 1
                    auxNodeXec = auxNodeXecs.Nodes.Add(Format(filtreXecs.Item(k).Row("xecs_id"), "000000000"))
                    If Not IsDBNull(filtreXecs.Item(k).Row("xecs_data_liquidat")) Then
                        auxNodeXec.ToolTipText = "Data liquidat: " & Format(filtreXecs.Item(k).Row("xecs_data_liquidat"), "d")
                        auxNodeXec.NodeFont = auxFontItalic
                    End If
                Next
            End If
        Next

        tvClients.EndUpdate()

    End Sub

    Private Sub tvClients_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvClients.AfterSelect
        Dim auxClient As String = ""
        Dim auxLloc As String = ""
        Dim auxServei As String = ""
        Dim auxXec As Long = 0
        Dim itemFound As Integer

        pnlClients.Visible = False
        lblClient.Text = "Client"
        pnlLlocs.Visible = False
        lblLloc.Text = "Lloc"
        pnlServeis.Visible = False
        lblServei.Text = "Servei"
        pnlXecs.Visible = False
        lblXec.Text = "Xec"

        'si hi ha addnews pendents, els cancelem
        ClientsBindingSource.CancelEdit()
        LlocsBindingSource.CancelEdit()
        Llocs_ServeisBindingSource.CancelEdit()
        XecsBindingSource.CancelEdit()

        Select Case e.Node.Level

            Case 0  'nou client o seleccio de client
                If e.Node.Text = "# Nou client" Then
                    lblClient.Text = "Afegir client"
                    ClientsBindingSource.AddNew()
                    pnlClients.Visible = True
                    Clients_nomTextBox.Focus()
                Else
                    auxClient = e.Node.Text
                    lblClient.Text = "Modificar client"
                    ClientsBindingSource.Position = ClientsBindingSource.Find("clients_nom", auxClient)
                    pnlClients.Visible = True
                    e.Node.ExpandAll()
                End If

            Case 1  'nou lloc o nou xec
                auxClient = e.Node.Parent.Text
                If e.Node.Text = "# Llocs" Then
                    lblLloc.Text = "Afegir lloc"
                    LlocsBindingSource.AddNew()
                    pnlLlocs.Visible = True
                    Clients_nomTextBox1.Text = auxClient
                Else 'xecs
                    lblXec.Text = "Afegir xec"
                    XecsBindingSource.AddNew()
                    pnlXecs.Visible = True
                    Clients_nomTextBox2.Text = auxClient
                    Xecs_idTextBox.ReadOnly = False
                    Xecs_idTextBox.TabStop = True
                    Xecs_data_entregaDateTimePicker.Value = Today
                    Xecs_valorTextBox.Text = VALORDFTXEC
                    txtQuants.Text = "1"
                    txtQuants.Visible = True
                    lblQuants.Visible = True
                End If
                e.Node.ExpandAll()

            Case 2  'seleccio de lloc o de xec
                auxClient = e.Node.Parent.Parent.Text
                If e.Node.Parent.Text = "# Llocs" Then
                    auxLloc = e.Node.Text
                    lblLloc.Text = "Modificar lloc"
                    'ens posicionem al lloc
                    LlocsBindingSource.Position = LlocsBindingSource.Find("llocs_nom", auxLloc)
                    pnlLlocs.Visible = True
                Else
                    auxXec = CInt(e.Node.Text)
                    lblXec.Text = "Modificar xec"
                    'ens posicionem al xec
                    XecsBindingSource.Position = XecsBindingSource.Find("xecs_id", auxXec)
                    pnlXecs.Visible = True
                    Xecs_idTextBox.Text = tvClients.SelectedNode.Text
                    Xecs_idTextBox.ReadOnly = True
                    Xecs_idTextBox.TabStop = False
                    txtQuants.Text = "1"
                    txtQuants.Visible = False
                    lblQuants.Visible = False
                End If
                e.Node.ExpandAll()

            Case 3  'nou servei de lloc
                auxLloc = e.Node.Parent.Text
                lblServei.Text = "Afegir servei"
                Llocs_ServeisBindingSource.AddNew()
                pnlServeis.Visible = True
                Llocs_nomTextBox1.Text = auxLloc
                Serveis_nomComboBox.Enabled = True
                Serveis_nomComboBox.SelectedIndex = -1
                e.Node.ExpandAll()

            Case 4  'seleccio servei de lloc
                auxLloc = e.Node.Parent.Parent.Text
                auxServei = e.Node.Text
                lblServei.Text = "Modificar servei"
                'ens posicionem al lloc
                LlocsBindingSource.Position = LlocsBindingSource.Find("llocs_nom", auxLloc)
                'ens posicionem al servei del lloc
                Llocs_ServeisBindingSource.MoveFirst()
                itemFound = -1
                For i = 0 To Llocs_ServeisBindingSource.Count - 1
                    If CType(CType(Llocs_ServeisBindingSource.Current, DataRowView).Row, PlaniFeinesDataSet.Llocs_ServeisRow).serveis_nom = auxServei Then
                        itemFound = Llocs_ServeisBindingSource.Position
                        Exit For
                    End If
                    Llocs_ServeisBindingSource.MoveNext()
                Next
                If itemFound = -1 Then
                    MsgBox("Servei/lloc no trobat: " & auxLloc & " " & auxServei)
                End If
                pnlServeis.Visible = True
                Serveis_nomComboBox.Enabled = False

        End Select

        'Debug.WriteLine(e.Node.Level & " / Client: " & auxClient & " / Lloc: " & auxLloc & " / Servei: " & auxServei & " / Xec: " & auxXec)

    End Sub

    Private Sub tvClients_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvClients.BeforeSelect
        Dim auxnode2 As TreeNode  'node seleccionat abans

        'si seleccionem un node client, colapsem l'altre client que hi hagi seleccionat
        If Not tvClients.SelectedNode Is Nothing And e.Node.Level = 0 Then
            auxnode2 = tvClients.SelectedNode
            'obtenim el node arrel del node seleccionat
            While auxnode2.Level > 0
                auxnode2 = auxnode2.Parent
            End While
            If Not e.Node.Equals(auxnode2) Then
                tvClients.BeginUpdate()
                auxnode2.Collapse()
                tvClients.EndUpdate()
            End If
        End If

    End Sub

    Private Sub pnlClients_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlClients.Validated
        Dim auxnom As String = Clients_nomTextBox.Text
        Dim auxxecs As Boolean = Clients_xecsCheckBox.Checked
        Dim auxNodeXecs As TreeNode
        Dim auxFontBold As Font = New Font(tvClients.Font, FontStyle.Bold)

        'si estem afegint o modificant un client
        If auxnom <> "" Then

            'actualitzem datatable
            Try
                ClientsBindingSource.EndEdit()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End Try

            'actualitzem la BBDD 
            Try
                ClientsTableAdapter.Update(PlaniFeinesDataSet.Clients)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Me.ClientsTableAdapter.Fill(Me.PlaniFeinesDataSet.Clients)
                ClientsBindingSource.ResetBindings(False)
                Carrega_TreeView_Clients()
                Exit Sub
            End Try

            'actualitzem controls associats
            ClientsBindingSource.ResetBindings(False)

            'recarreguem taules filles per si s'ha canviat el nom del client
            Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
            Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)

            'ens posicionem al node creat o actualitzem el nom del node modificat
            If tvClients.SelectedNode.Text = "# Nou client" Then
                Carrega_TreeView_Clients()
                'ens posicionem al node creat 
                tvClients.SelectedNode = GetNode(auxnom, tvClients.Nodes, 0)
            Else
                'actualitzem el nom del node
                tvClients.SelectedNode.Text = auxnom
            End If

            'posem o treiem el node xecs
            If auxxecs Then
                For Each n In tvClients.SelectedNode.Nodes
                    auxNodeXecs = CType(n, TreeNode)
                    If auxNodeXecs.Text = "# Xecs" Then Exit Sub
                Next

                auxNodeXecs = tvClients.SelectedNode.Nodes.Add("# Xecs")
                auxNodeXecs.ToolTipText = "Fés click per afegir un xec al client '" & auxnom & "'"
                auxNodeXecs.NodeFont = auxFontBold
            Else
                For Each n In tvClients.SelectedNode.Nodes
                    auxNodeXecs = CType(n, TreeNode)
                    If auxNodeXecs.Text = "# Xecs" Then auxNodeXecs.Remove()
                Next
            End If

            tvClients.Select()

        End If

    End Sub

    Private Sub pnlClients_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pnlClients.Validating

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        Llocs_nomTextBox.Text = Trim(Llocs_nomTextBox.Text)

        'excepte si estem afegint client i no informem el seu nom -> validem
        If Not (lblClient.Text = "Afegir client" And Clients_nomTextBox.Text = "") Then

            If Clients_nomTextBox.Text = "" Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar el nom del client."
                e.Cancel = True
                Exit Sub
            End If

            If lblClient.Text = "Afegir client" Then
                Clients_data_altaTextBox.Text = Now
            End If

        End If

    End Sub

    Private Sub tvClients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvClients.KeyDown

        If e.KeyCode = Keys.Delete Then

            If pnlClients.Visible And tvClients.SelectedNode.Text <> "# Nou client" Then
                If MsgBox("Eliminar client '" & tvClients.SelectedNode.Text & "' ?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.Yes Then
                    'borrem el registre 
                    ClientsBindingSource.RemoveCurrent()

                    'actualitzem BBDD
                    Try
                        ClientsTableAdapter.Update(PlaniFeinesDataSet.Clients)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                        Me.ClientsTableAdapter.Fill(Me.PlaniFeinesDataSet.Clients)
                        ClientsBindingSource.ResetBindings(False)
                        Carrega_TreeView_Clients()
                        Exit Sub
                    End Try

                    'recarreguem taules filles perque s'ha eliminat el client
                    Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
                    Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
                    'falte fill pagaments

                    'borrem el node
                    tvClients.SelectedNode.Remove()
                End If
            End If

            If pnlLlocs.Visible And tvClients.SelectedNode.Text <> "# Llocs" Then
                If MsgBox("Eliminar lloc '" & tvClients.SelectedNode.Text & "' ?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.Yes Then
                    'borrem el registre
                    LlocsBindingSource.RemoveCurrent()

                    'actualitzem BBDD
                    Try
                        LlocsTableAdapter.Update(PlaniFeinesDataSet.Llocs)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                        Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
                        LlocsBindingSource.ResetBindings(False)
                        Carrega_TreeView_Clients()
                        Exit Sub
                    End Try

                    'recarreguem llocs_serveis perque s'ha eliminat el lloc
                    Me.Llocs_ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs_Serveis)

                    'borrem node
                    tvClients.SelectedNode.Remove()
                End If
            End If

            If pnlServeis.Visible And tvClients.SelectedNode.Text <> "# Serveis" Then
                If MsgBox("Eliminar servei '" & tvClients.SelectedNode.Text & "' del lloc '" & Llocs_nomTextBox1.Text & "'?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.Yes Then
                    'borrem el registre
                    Llocs_ServeisBindingSource.RemoveCurrent()

                    'actualitzem BBDD
                    Try
                        Llocs_ServeisTableAdapter.Update(PlaniFeinesDataSet.Llocs_Serveis)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                        Me.Llocs_ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs_Serveis)
                        Llocs_ServeisBindingSource.ResetBindings(False)
                        Carrega_TreeView_Clients()
                        Exit Sub
                    End Try
                    'borrem el node
                    tvClients.SelectedNode.Remove()
                    Actualitzar_minuts_previst_lloc_actual()
                End If
            End If

            If pnlXecs.Visible And tvClients.SelectedNode.Text <> "# Xecs" Then
                If MsgBox("Eliminar xec '" & tvClients.SelectedNode.Text & "' del client '" & Clients_nomTextBox2.Text & "'?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.Yes Then

                    If Xecs_data_liquidatTextBox.Text <> "" Then
                        If MsgBox("El xec està liquidat. Eliminar igualment?", MsgBoxStyle.YesNo, "CONFIRMACIÓ") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    'borrem el registre
                    XecsBindingSource.RemoveCurrent()

                    'actualitzem BBDD
                    Try
                        XecsTableAdapter.Update(PlaniFeinesDataSet.Xecs)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                        Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
                        XecsBindingSource.ResetBindings(False)
                        Carrega_TreeView_Clients()
                        Exit Sub
                    End Try
                    'borrem el node
                    tvClients.SelectedNode.Remove()
                End If
            End If

        End If

    End Sub

    Private Sub cmbDiesSetmana_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDiesSetmana.SelectedIndexChanged
        Llocs_dia_setmanaTextBox.Text = cmbDiesSetmana.SelectedIndex
    End Sub

    Private Sub Llocs_dia_setmanaTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Llocs_dia_setmanaTextBox.TextChanged
        cmbDiesSetmana.SelectedIndex = CInt(Llocs_dia_setmanaTextBox.Text)
    End Sub

    Private Sub pnlLlocs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlLlocs.Validated
        Dim auxnomlloc As String = Llocs_nomTextBox.Text

        'si estem afegint o modificant un lloc
        If auxnomlloc <> "" Then

            'actualitzem datatable
            Try
                LlocsBindingSource.EndEdit()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End Try

            'actualitzem la BBDD 
            Try
                LlocsTableAdapter.Update(PlaniFeinesDataSet.Llocs)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Me.LlocsTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs)
                LlocsBindingSource.ResetBindings(False)
                Carrega_TreeView_Clients()
                Exit Sub
            End Try

            'actualitzem controls associats
            LlocsBindingSource.ResetBindings(False)

            'recarreguem llocs_serveis per si s'ha canviat el nom del lloc
            Me.Llocs_ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs_Serveis)

            'recarreguem per crear node i fills o actualitzem el nom del node modificat
            If tvClients.SelectedNode.Level = 1 Then    'nou lloc
                Carrega_TreeView_Clients()
            Else
                'actualitzem el nom del node
                tvClients.SelectedNode.Text = auxnomlloc
                'Desseleccionem node per seleccionar-lo a continuacio i disparar events
                tvClients.SelectedNode = Nothing
            End If

            'ens posicionem al node creat de nivell 2
            tvClients.SelectedNode = GetNode(auxnomlloc, tvClients.Nodes, 2)
            tvClients.Select()

        End If

    End Sub

    Private Sub pnlLlocs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pnlLlocs.Validating
        Dim auxnrecursos As Integer
        Dim auxnomllocant As String

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        Llocs_nomTextBox.Text = Trim(Llocs_nomTextBox.Text)

        'excepte si estem afegint lloc i no informem el seu nom -> validem
        If Not (lblLloc.Text = "Afegir lloc" And Llocs_nomTextBox.Text = "") Then

            If Llocs_nomTextBox.Text = "" Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar el nom del lloc."
                e.Cancel = True
                Exit Sub
            End If

            If CInt(Llocs_periodicitat_diesTextBox.Text) < 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar la periodicitat en dies (0 si no planificable)."
                e.Cancel = True
                Exit Sub
            End If

            If Not IsNumeric(Llocs_quotaTextBox.Text) Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: La quota no és un número vàlid."
                e.Cancel = True
                Exit Sub
            End If

            If CSng(Llocs_quotaTextBox.Text) < 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: La quota no pot ser menor que 0."
                e.Cancel = True
                Exit Sub
            End If

            'si el client té xecs no pot tenir quotes
            If Clients_xecsCheckBox.Checked And CSng(Llocs_quotaTextBox.Text) > 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Si el client té xecs, no pot tenir quota."
                e.Cancel = True
                Exit Sub
            End If

            'actualitzem minuts previstos
            If lblLloc.Text = "Afegir lloc" Then
                Llocs_minuts_previstMaskedTextBox.Text = MINGAP.TotalMinutes
            Else
                auxnrecursos = Obtenir_nro_recursos(Recursos_nomComboBox.Text)
                auxnomllocant = PlaniFeinesDataSet.Llocs(LlocsBindingSource.Position).Item("llocs_nom", DataRowVersion.Original)
                Llocs_minuts_previstMaskedTextBox.Text = Calcular_minuts_serveis(auxnomllocant, auxnrecursos)
            End If

        End If

    End Sub

    'busca un node per texte i nivell
    Private Function GetNode(ByVal pText As String, ByVal pParentCollection As TreeNodeCollection, ByVal pLevel As Integer) As TreeNode

        Dim ret As TreeNode = Nothing
        Dim child As TreeNode

        For Each child In pParentCollection 'step through the parentcollection
            If child.Level = pLevel And child.Text = pText Then
                ret = child
                Exit For
            ElseIf child.GetNodeCount(False) > 0 Then ' if there is child items then call this function recursively
                ret = GetNode(pText, child.Nodes, pLevel)
                If Not ret Is Nothing Then Exit For
            End If
        Next

        Return ret

    End Function

    Private Sub Llocs_nomTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Llocs_nomTextBox.KeyPress
        'evitem el caracter en el nom del lloc
        If e.KeyChar = "#" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Clients_nomTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Clients_nomTextBox.KeyPress
        'evitem el caracter en el nom del client
        If e.KeyChar = "#" Then
            e.Handled = True
        End If
    End Sub

    Private Sub pnlServeis_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlServeis.Validated
        Dim auxnomservei As String = Serveis_nomComboBox.Text
        Dim auxnomlloc As String = Llocs_nomTextBox1.Text
        Dim auxnode As TreeNode

        'si estem afegint o modificant un servei de lloc
        If Serveis_nomComboBox.SelectedIndex <> -1 Then

            'actualitzem la datatable
            Try
                Llocs_ServeisBindingSource.EndEdit()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End Try

            'actualitzem la BBDD 
            Try
                Llocs_ServeisTableAdapter.Update(PlaniFeinesDataSet.Llocs_Serveis)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Me.Llocs_ServeisTableAdapter.Fill(Me.PlaniFeinesDataSet.Llocs_Serveis)
                Llocs_ServeisBindingSource.ResetBindings(False)
                Carrega_TreeView_Clients()
                Exit Sub
            End Try

            'actualitzem controls associats
            Llocs_ServeisBindingSource.ResetBindings(False)

            'actualitzem els minuts previstos del lloc
            Actualitzar_minuts_previst_lloc_actual()

            If tvClients.SelectedNode.Level = 3 Then    'nou servei
                'creem el node 
                tvClients.SelectedNode.Nodes.Add(auxnomservei)
            Else
                'Desseleccionem node per seleccionar-lo a continuacio i disparar events
                tvClients.SelectedNode = Nothing
            End If

            'ens posicionem al node creat o modificat
            auxnode = GetNode(auxnomlloc, tvClients.Nodes, 2)
            tvClients.SelectedNode = GetNode(auxnomservei, auxnode.Nodes, 4)
            tvClients.Select()

        End If

    End Sub

    Private Sub pnlServeis_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pnlServeis.Validating

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        'excepte si estem afegint servei al lloc i no seleccionem el seu nom -> validem
        If Not (lblServei.Text = "Afegir servei" And Serveis_nomComboBox.SelectedIndex = -1) Then

            If Not IsNumeric(Llocs_serveis_quantitatTextBox.Text) Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: La quantitat no és un número vàlid."
                e.Cancel = True
                Exit Sub
            End If

            If CSng(Llocs_serveis_quantitatTextBox.Text) < 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: No es pot informar una quantitat negativa."
                e.Cancel = True
                Exit Sub
            End If

            If Not IsNumeric(Llocs_serveis_preu_unTextBox.Text) Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: El preu unitari no és un número vàlid."
                e.Cancel = True
                Exit Sub
            End If

            If CSng(Llocs_serveis_preu_unTextBox.Text) = 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar un preu unitari."
                e.Cancel = True
                Exit Sub
            End If

            'el servei ha de ser unic pel lloc. 
            If lblServei.Text = "Afegir servei" Then
                For Each n In tvClients.SelectedNode.Nodes
                    If CType(n, TreeNode).Text = Serveis_nomComboBox.Text Then
                        StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: El servei ja existeix pel lloc."
                        e.Cancel = True
                        Exit Sub
                    End If
                Next
            End If

        End If

    End Sub

    Private Sub Clients_codi_postalMaskedTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clients_codi_postalMaskedTextBox.GotFocus
        Clients_codi_postalMaskedTextBox.SelectAll()
    End Sub

    Private Sub Llocs_minuts_previstMaskedTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Llocs_minuts_previstMaskedTextBox.GotFocus
        Llocs_minuts_previstMaskedTextBox.SelectAll()
    End Sub

    Private Sub Llocs_quotaTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Llocs_quotaTextBox.GotFocus
        Llocs_quotaTextBox.SelectAll()
    End Sub

    Private Sub Llocs_quotaTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Llocs_quotaTextBox.KeyPress
        'només permetem caracters per numerics
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9") And e.KeyChar <> "-" And e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub Serveis_nomComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Serveis_nomComboBox.SelectedIndexChanged

        If pnlServeis.Visible And Serveis_nomComboBox.SelectedIndex <> -1 Then
            If Not IsNumeric(Llocs_serveis_preu_unTextBox.Text) Then
                Llocs_serveis_preu_unTextBox.Text = CType(CType(ServeisBindingSource.Item(ServeisBindingSource.Find("serveis_nom", Serveis_nomComboBox.Text)), DataRowView).Row, PlaniFeinesDataSet.ServeisRow).serveis_preu_un
            Else
                If CSng(Llocs_serveis_preu_unTextBox.Text) = 0 Then
                    Llocs_serveis_preu_unTextBox.Text = CType(CType(ServeisBindingSource.Item(ServeisBindingSource.Find("serveis_nom", Serveis_nomComboBox.Text)), DataRowView).Row, PlaniFeinesDataSet.ServeisRow).serveis_preu_un
                End If
            End If
        End If

    End Sub

    Private Sub Xecs_idTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Xecs_idTextBox.KeyPress

        'forçem caràcters numèrics o de control
        If (e.KeyChar < "0" Or e.KeyChar > "9") _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Return) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Tab) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Back) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtQuants_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuants.KeyPress

        If (e.KeyChar < "0" Or e.KeyChar > "9") _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Return) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Tab) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Back) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Xecs_valorTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Xecs_valorTextBox.KeyPress

        If (e.KeyChar < "0" Or e.KeyChar > "9") _
        And e.KeyChar <> "-" _
        And e.KeyChar <> "," _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Return) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Tab) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Back) _
        And e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            e.Handled = True
        End If

    End Sub

    Private Sub pnlXecs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlXecs.Validated
        Dim auxnumxec As Integer = CInt(Xecs_idTextBox.Text)
        Dim auxidxec As String = ""
        Dim auxClient As String = Clients_nomTextBox2.Text
        Dim auxdata As Date = Xecs_data_entregaDateTimePicker.Value
        Dim auxvalor As Single = CSng(Xecs_valorTextBox.Text)

        'si estem afegint o modificant un xec
        If auxnumxec > 0 Then

            For i = 1 To CInt(txtQuants.Text)
                If i > 1 Then
                    XecsBindingSource.AddNew()
                    Clients_nomTextBox2.Text = auxClient
                    Xecs_data_entregaDateTimePicker.Value = auxdata
                    Xecs_valorTextBox.Text = auxvalor
                End If

                auxidxec = Mid(Format(Xecs_data_entregaDateTimePicker.Value, "d"), 9, 2) & Mid(Format(Xecs_data_entregaDateTimePicker.Value, "d"), 4, 2) & Format(auxnumxec Mod 100000, "00000")
                Xecs_idTextBox.Text = auxidxec

                'actualitzem datatable
                Try
                    XecsBindingSource.EndEdit()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                    Exit Sub
                End Try

                '!!! hi ha casos en que al afegir el DateTimePicker no actualitza bé la data de l'origen de dades
                'cal fer aquest control per solventar-ho
                If CType(CType(XecsBindingSource.Current, DataRowView).Row, PlaniFeinesDataSet.XecsRow).Isxecs_data_entregaNull Then
                    CType(CType(XecsBindingSource.Current, DataRowView).Row, PlaniFeinesDataSet.XecsRow).xecs_data_entrega = Xecs_data_entregaDateTimePicker.Value
                End If

                If tvClients.SelectedNode.Level = 1 Then    'nou xec
                    'creem el node 
                    tvClients.SelectedNode.Nodes.Add(auxidxec)
                Else
                    'actualitzem el nom del node
                    tvClients.SelectedNode.Text = auxidxec
                    'Desseleccionem node per seleccionar-lo a continuacio i disparar events
                    tvClients.SelectedNode = Nothing
                End If

                auxnumxec += 1
            Next

            'actualitzem la BBDD 
            Try
                XecsTableAdapter.Update(PlaniFeinesDataSet.Xecs)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR")
                Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
                XecsBindingSource.ResetBindings(False)
                Carrega_TreeView_Clients()
                Exit Sub
            End Try

            'actualitzem controls associats
            XecsBindingSource.ResetBindings(False)

            'ens posicionem al node creat de nivell 2
            tvClients.SelectedNode = GetNode(auxidxec, tvClients.Nodes, 2)
            tvClients.Select()

        End If

    End Sub

    Private Sub pnlXecs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles pnlXecs.Validating
        Dim auxidxec As String
        Dim auxnroxec As Integer

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        'excepte si estem afegint xec i no informem el nro -> validem
        If Not (lblXec.Text = "Afegir xec" And CInt(Xecs_idTextBox.Text) = 0) Then

            If Not IsNumeric(txtQuants.Text) Then
                txtQuants.Text = "1"
            End If

            If CInt(txtQuants.Text) < 1 Then txtQuants.Text = "1"

            If Not IsNumeric(Xecs_valorTextBox.Text) Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: El valor del xec no és un número vàlid."
                e.Cancel = True
                Exit Sub
            End If

            If CSng(Xecs_valorTextBox.Text) < 0 Then
                StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: El valor del xec no pot ser una quantitat negativa."
                e.Cancel = True
                Exit Sub
            End If

            'el id de xec ha de ser unic 
            If lblXec.Text = "Afegir xec" Then
                auxnroxec = CInt(Xecs_idTextBox.Text) Mod 100000
                For i = 1 To CInt(txtQuants.Text)
                    'muntem el id de xec amb el mes 4pos + nro 5pos
                    auxidxec = Mid(Format(Xecs_data_entregaDateTimePicker.Value, "d"), 9, 2) & Mid(Format(Xecs_data_entregaDateTimePicker.Value, "d"), 4, 2) & Format(auxnroxec, "00000")
                    If XecsBindingSource.Find("xecs_id", CInt(auxidxec)) <> -1 Then
                        StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: El id. de xec '" & auxidxec & "' ja existeix."
                        e.Cancel = True
                        Exit Sub
                    End If
                    auxnroxec += 1
                Next
            End If

        End If
    End Sub

    Private Sub AgendaGrid_PGSizeChanged(ByVal pColumnsWidth As Integer, ByVal pRowsHeight As Integer) Handles AgendaGrid.PGSizeChanged
        If dgvHoresExtra.ColumnCount = 7 Then
            dgvHoresExtra.Columns(0).Width = pColumnsWidth
            dgvHoresExtra.Columns(1).Width = pColumnsWidth
            dgvHoresExtra.Columns(2).Width = pColumnsWidth
            dgvHoresExtra.Columns(3).Width = pColumnsWidth
            dgvHoresExtra.Columns(4).Width = pColumnsWidth
            dgvHoresExtra.Columns(5).Width = pColumnsWidth
            dgvHoresExtra.Columns(6).Width = pColumnsWidth
        End If
    End Sub

    Private Sub dgvHoresExtra_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvHoresExtra.CellBeginEdit
        Dim auxdata As Date = DateAdd(DateInterval.Day, e.ColumnIndex - ((Calendari.SelectedDate.DayOfWeek + 6) Mod 7), Calendari.SelectedDate)

        'calcular les hores extra
        dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).Value = Calcular_Hores_Dia(RecursActual, auxdata, "EXTRA")

    End Sub

    Private Sub dgvHoresExtra_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHoresExtra.CellMouseMove
        Dim auxdata As Date = DateAdd(DateInterval.Day, e.ColumnIndex - ((Calendari.SelectedDate.DayOfWeek + 6) Mod 7), Calendari.SelectedDate)
        Dim auxsng As Single

        'calcular les hores total
        auxsng = Calcular_Hores_Dia(RecursActual, auxdata, "TREBALLADES")

        dgvHoresExtra.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = CStr(auxsng) & " Hores Total"

    End Sub

    Private Sub dgvHoresExtra_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHoresExtra.CellValidated
        Dim auxdata As Date = DateAdd(DateInterval.Day, e.ColumnIndex - ((Calendari.SelectedDate.DayOfWeek + 6) Mod 7), Calendari.SelectedDate)

        If dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).FormattedValue = "" Then
            dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).Value = Format(0, "N2")
        Else
            dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).Value = Format(CSng(dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).Value), "N2")
        End If

        'actualitzar hores extra
        ActualitzarHoresExtra(RecursActual, auxdata, CSng(dgvHoresExtra.Item(e.ColumnIndex, e.RowIndex).FormattedValue))

    End Sub

    Private Sub dgvHoresExtra_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvHoresExtra.CellValidating
        Dim editControl As DataGridViewTextBoxEditingControl
        Dim auxdata As Date = DateAdd(DateInterval.Day, e.ColumnIndex - ((Calendari.SelectedDate.DayOfWeek + 6) Mod 7), Calendari.SelectedDate)
        Dim auxsng As Single

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        If e.FormattedValue = "" Or dgvHoresExtra.EditingControl Is Nothing Then Exit Sub

        If Not IsNumeric(e.FormattedValue) Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar un número vàlid a les hores extra."
            editControl = CType(dgvHoresExtra.EditingControl, DataGridViewTextBoxEditingControl)
            editControl.SelectionStart = 0
            editControl.SelectionLength = editControl.TextLength
            e.Cancel = True
            Exit Sub
        End If

        If CSng(e.FormattedValue) < 0 Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Les hores extra no poden ser negatives."
            editControl = CType(dgvHoresExtra.EditingControl, DataGridViewTextBoxEditingControl)
            editControl.SelectionStart = 0
            editControl.SelectionLength = editControl.TextLength
            e.Cancel = True
            Exit Sub
        End If

        'les hores extra informades no poden ser superiors que les hores fetes en el dia
        auxsng = Calcular_Hores_Dia(RecursActual, auxdata, "JORNADA")
        If CSng(e.FormattedValue) > auxsng Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Les hores extra no poden ser superiors a la jornada (" & Format(auxsng, "N2") & " hores)."
            editControl = CType(dgvHoresExtra.EditingControl, DataGridViewTextBoxEditingControl)
            editControl.SelectionStart = 0
            editControl.SelectionLength = editControl.TextLength
            e.Cancel = True
            Exit Sub
        End If

    End Sub


    Private Sub dgvHoresExtra_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvHoresExtra.Scroll
        If dgvHoresExtra.Focused Then
            AgendaGrid.ScrollPosition = New System.Drawing.Point(e.NewValue, AgendaGrid.ScrollPosition.Y)
            dgvHoresExtra.Refresh()
        End If
    End Sub

    Private Sub Llocs_periodicitat_diesTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Llocs_periodicitat_diesTextBox.GotFocus
        Llocs_periodicitat_diesTextBox.SelectAll()
    End Sub

    Private Sub Llocs_periodicitat_diesTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Llocs_periodicitat_diesTextBox.KeyPress
        'només permetem caracters per numerics
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPagaments_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagaments.GotFocus
        txtPagaments.SelectAll()
    End Sub

    Private Sub txtPagaments_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagaments.KeyPress
        'només permetem caracters per numerics
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9") And e.KeyChar <> "-" And e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPagaments_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPagaments.MouseClick
        txtPagaments.SelectAll()
    End Sub

    Private Sub txtPagaments_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagaments.Validated
        txtPagaments.Text = Format(CSng(txtPagaments.Text), "C")

        'gravar pagaments
        If cmbSelClients.Text <> "" Then
            If ActualitzarPagament(Format(dtpSelMes.Value, "MM/yyyy"), cmbSelClients.Text, CSng(txtPagaments.Text)) Then
                Carrega_Grids_Factura()
            End If
        End If

    End Sub

    Private Sub txtPagaments_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPagaments.Validating
        If txtPagaments.Text = "" Then txtPagaments.Text = "0"
        If Not IsNumeric(txtPagaments.Text) Then
            StatusStrip1.Items("ToolStripStatusLabel2").Text = "ERROR: Cal informar una quantitat vàlida."
            txtPagaments.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub dtpSelMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSelMes.ValueChanged

        If cmbSelClients.Text <> "" Then
            'recuperar pagament mes client
            txtPagaments.Text = Format(ObtenirPagament(cmbSelClients.Text, Format(dtpSelMes.Value, "MM/yyyy")), "C")
        Else
            txtPagaments.Text = Format(0, "C")
        End If

        Carrega_Grids_Factura()

        Calendari.SelectedDate = dtpSelMes.Value

    End Sub

    Private Sub cmbSelClients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSelClients.KeyDown
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            cmbSelClients.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmbSelClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSelClients.SelectedIndexChanged

        If cmbSelClients.Text <> "" Then
            'recuperar pagament mes client
            txtPagaments.Text = Format(ObtenirPagament(cmbSelClients.Text, Format(dtpSelMes.Value, "MM/yyyy")), "C") '"N2")
            chkPdtFacturar.Visible = True
            chkPdtFacturar.Checked = False
            Label15.Visible = True
            txtPagaments.Visible = True
            Label18.Text = "Xecs client:"
            btnImprimirHores.Visible = False
            btnImprimirHoresTotals.Visible = False
            btnImprimirXecs.Visible = False
            Label24.Visible = True
            txtTotalFacturar.Visible = True
            'SplitContainer4.Panel1Collapsed = False
            btnImprimirFacturacio.Text = "Facturar client"
        Else
            txtPagaments.Text = Format(0, "C")
            chkPdtFacturar.Visible = False
            chkPdtFacturar.Checked = False
            Label15.Visible = False
            txtPagaments.Visible = False
            Label18.Text = "Xecs liquidats mes:"
            btnImprimirHores.Visible = True
            btnImprimirHoresTotals.Visible = True
            btnImprimirXecs.Visible = True
            Label24.Visible = False
            txtTotalFacturar.Visible = False
            'SplitContainer4.Panel1Collapsed = True
            btnImprimirFacturacio.Text = "Imprimir dades facturació"
        End If

        Carrega_Grids_Factura()

    End Sub

    Private Sub dgvFactura_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFactura.CellMouseClick
        Dim auxint As Integer

        StatusStrip1.Items("ToolStripStatusLabel2").Text = ""

        If e.RowIndex <> -1 Then
            auxint = CInt(dgvFactura.SelectedRows(0).Cells("Feina").Value)
            If auxint <> 0 Then
                'passem parametre a frmFeina
                frmFeina.pPGElement = FeinaaPGElement(auxint)
                If frmFeina.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Carrega_Grids_Factura()
                    Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
                    Carrega_TreeView_Clients()

                    StatusStrip1.Items("ToolStripStatusLabel2").Text = "Actualitzat element #" & auxint
                End If
            End If
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Debug.WriteLine("TabControl1_SelectedIndexChanged " & TabControl1.SelectedTab.Text)
        Select Case TabControl1.SelectedTab.Text
            Case "Agenda"
                'per actualitzar grid si s'ha canviat feines en Facturació
                'NO ACTUALITZA COLORS DE RECURSOS NI DURADES SERVEIS FINS QUE ES RECARREGUI EL MES 
                AgendaGrid.RefreshGrid()

            Case "Facturació"
                Carrega_Grids_Factura()

            Case "Clients"
            Case "Recursos i Serveis"
            Case "Informes"

        End Select
    End Sub

    Private Sub chkPdtFacturar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPdtFacturar.CheckedChanged

        If cmbSelClients.Text <> "" Then
            Carrega_Grids_Factura()
        End If

        If chkPdtFacturar.Checked Then
            btnImprimirFacturacio.Enabled = False
        Else
            btnImprimirFacturacio.Enabled = True
        End If
    End Sub

    Private Sub btnImprimirXecs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirXecs.Click
        Dim CNOpen As Boolean
        Dim auxDS As New DataSet
        Dim auxXecsDA As New OleDb.OleDbDataAdapter("SELECT * FROM Xecs WHERE Xecs_data_liquidat Is Not Null", CN)
        Dim auxFeinesDA As New OleDb.OleDbDataAdapter("SELECT * FROM Feines WHERE (((Feines.feines_data)>=@dataini And (Feines.feines_data)<@datafi))", CN)
        Dim auxFeinesDetallDA As New OleDb.OleDbDataAdapter("SELECT * FROM Feines_Detall WHERE (((Feines_Detall.serveis_nom)='Neteja'))", CN)
        Dim param1 As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim param2 As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim auxdate As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim miRpt As New crpXecsLiquidatsMes

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        param1.Direction = ParameterDirection.Input
        param1.Value = auxdate
        auxFeinesDA.SelectCommand.Parameters.Add(param1)

        param2.Direction = ParameterDirection.Input
        auxdate = DateAdd(DateInterval.Month, 1, auxdate)
        param2.Value = auxdate
        auxFeinesDA.SelectCommand.Parameters.Add(param2)

        CNOpen = (CN.State = ConnectionState.Open)

        Try
            If Not CNOpen Then
                CN.Open()
            End If
            auxXecsDA.Fill(auxDS, "Xecs")
            auxFeinesDA.Fill(auxDS, "Feines")
            auxFeinesDetallDA.Fill(auxDS, "Feines_Detall")

            miRpt.SetDataSource(auxDS)
            miRpt.SetParameterValue(0, Format(dtpSelMes.Value, "yyyyMM"))
            miRpt.SummaryInfo.ReportTitle = "crpXecsLiquidatsMes"

            frmImpressio.CrystalReportViewer1.ReportSource = miRpt
            frmImpressio.WindowState = FormWindowState.Maximized
            frmImpressio.CrystalReportViewer1.ShowFirstPage()

            frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Catch ex As Exception
            MsgBox("Mensaje : " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

        If Not CNOpen Then
            CN.Close()
        End If

        '' Liberamos memoria
        'auxDS.Dispose()
        'auxXecsDA.Dispose()
        'auxFeinesDA.Dispose()
        'auxFeinesDetallDA.Dispose()

    End Sub

    Private Sub btnImprimirAgenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirAgenda.Click

        If RecursosSelDataGridView.SelectedRows.Count = 0 Then
            If MsgBox("Imprimir agenda?", MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
                'imprimir l'agenda
                Me.Cursor = Cursors.WaitCursor

                frmImpressio.Close()
                frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
                'frmImpressio.CrystalReportViewer1.DisplayGroupTree = False
                frmImpressio.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmImpressio.WindowState = FormWindowState.Maximized
                frmImpressio.Show()
                frmImpressio.BringToFront()

                If AgendaGrid.VisualizationMode = PlaniGrid.PGMode.Day Then
                    frmImpressio.CrystalReportViewer1.ReportSource = AgendaGrid.PGPrint(DiaCatala(Format(AgendaGrid.DisplayDate, "dddd")))
                Else
                    frmImpressio.CrystalReportViewer1.ReportSource = AgendaGrid.PGPrint("")
                End If

                frmImpressio.CrystalReportViewer1.ShowFirstPage()

                frmImpressio.Text = frmImpressio.CrystalReportViewer1.ReportSource.SummaryInfo.ReportTitle
                'frmImpressio.CrystalReportViewer1.Refresh()

                Me.Cursor = Cursors.Default
            End If
        Else
            'imprimir hores recurs seleccionat
            Imprimir_Llista_Feines()
        End If
 

    End Sub

    Private Sub LlocsSelDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles LlocsSelDataGridView.CellMouseDoubleClick
        Dim auxlloc As String
        Dim auxclient As String
        Dim auxNode As TreeNode

        'anar a manteniment del lloc

        'obtenim el lloc i el client seleccionat 
        auxlloc = Trim(LlocsSelDataGridView.Item("llocs_nom", e.RowIndex).Value.ToString)
        auxclient = Trim(LlocsSelDataGridView.Item("clients_nom", e.RowIndex).Value.ToString)

        'ens posicionem al treeview 
        tvClients.CollapseAll()
        For Each n1 In tvClients.Nodes
            auxNode = n1
            If auxNode.Text = auxclient Then
                tvClients.SelectedNode = auxNode
                For Each n2 In tvClients.SelectedNode.Nodes
                    auxNode = n2
                    If auxNode.Text = "# Llocs" Then
                        tvClients.SelectedNode = auxNode
                        For Each n3 In tvClients.SelectedNode.Nodes
                            auxNode = n3
                            If auxNode.Text = auxlloc Then
                                tvClients.SelectedNode = auxNode
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next

        'canviem a la pestanya clients
        TabControl1.SelectedTab = TabControl1.TabPages("TabPageClients")

    End Sub

    Private Sub LlocsSelDataGridView_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles LlocsSelDataGridView.CellMouseMove
        Dim returnValue As DragDropEffects
        Dim auxstr As String = ""
        Dim auxPGElement As PlaniGrid.PGElement
        Dim auxPGRecurs As PlaniGrid.PGResource
        Dim auxPGRecursos As Dictionary(Of String, Color)
        Dim auxRecursSel As PlaniFeinesDataSet.RecursosRow
        Dim auxRecursosComp() As PlaniFeinesDataSet.Recursos_ComponentsRow
        Dim auxRecursComp As PlaniFeinesDataSet.RecursosRow
        Dim auxColorFeina As Color
        Dim auxShared As TimeSpan = New TimeSpan(0)
        Dim auxNonShared As TimeSpan = New TimeSpan(0)
        Dim CMDSel As New OleDbCommand
        Dim RDSel As OleDbDataReader
        Dim drLlocs As DataRow = CType(LlocsBindingSource.Current, DataRowView).Row

        'si estem arrossegant
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'obtenim els recursos seleccionats i els afegim a l'element del drag
            auxPGRecursos = New Dictionary(Of String, Color)

            If RecursosSelDataGridView.SelectedRows.Count > 0 Then
                auxRecursSel = CType(RecursosBindingSource.Item(RecursosSelDataGridView.SelectedRows(0).Index), DataRowView).Row
                auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(auxRecursSel.recursos_nom, "'", "''") & "'")
                'si el recurs es compost afegim els seus components i afegim el color del compost al de la feina
                If auxRecursosComp.Count > 0 Then
                    For Each r2 In auxRecursosComp
                        auxRecursComp = PlaniFeinesDataSet.Recursos.FindByrecursos_nom(r2.recursos_component_nom)
                        auxPGRecurs = New PlaniGrid.PGResource(auxRecursComp.recursos_nom, IntegerToColor(auxRecursComp.recursos_color))
                        auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
                    Next
                Else
                    'si el recurs es simple l'agegim i el seu color a la feina
                    auxPGRecurs = New PlaniGrid.PGResource(auxRecursSel.recursos_nom, IntegerToColor(auxRecursSel.recursos_color))
                    auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
                End If
                auxColorFeina = AgendaGrid.PGResourcesColor(auxPGRecursos)
            Else
                'si no, afegim el recurs del lloc (si en té)
                If drLlocs("recursos_nom").ToString <> "" Then
                    auxRecursSel = CType(RecursosBindingSource.Item(RecursosBindingSource.Find("recursos_nom", drLlocs("recursos_nom"))), DataRowView).Row
                    auxRecursosComp = PlaniFeinesDataSet.Recursos_Components.Select("recursos_nom ='" & Replace(auxRecursSel.recursos_nom, "'", "''") & "'")
                    'si el recurs es compost afegim els seus components i afegim el color del compost al de la feina
                    If auxRecursosComp.Count > 0 Then
                        For Each r2 In auxRecursosComp
                            auxRecursComp = PlaniFeinesDataSet.Recursos.FindByrecursos_nom(r2.recursos_component_nom)
                            auxPGRecurs = New PlaniGrid.PGResource(auxRecursComp.recursos_nom, IntegerToColor(auxRecursComp.recursos_color))
                            auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
                        Next
                    Else
                        'si el recurs es simple l'agegim i el seu color a la feina
                        auxPGRecurs = New PlaniGrid.PGResource(auxRecursSel.recursos_nom, IntegerToColor(auxRecursSel.recursos_color))
                        auxPGRecursos.Add(auxPGRecurs.Name, auxPGRecurs.Color)
                    End If
                    auxColorFeina = AgendaGrid.PGResourcesColor(auxPGRecursos)
                End If
            End If

            'obtenim els serveis del lloc per calcular la durada
            'provem la connexio
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Exit Sub
            End Try

            CMDSel.Connection = CN
            CMDSel.CommandText = "SELECT Llocs_Serveis.llocs_nom, Llocs_Serveis.serveis_nom, Llocs_Serveis.llocs_serveis_quantitat, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " & _
            "FROM Serveis INNER JOIN Llocs_Serveis ON Serveis.serveis_nom = Llocs_Serveis.serveis_nom " & _
            "WHERE (((Llocs_Serveis.llocs_nom)= @lloc ))"
            CMDSel.Parameters.Add("@lloc", OleDbType.Char).Value = LlocsSelDataGridView.Item("llocs_nom", e.RowIndex).Value.ToString

            RDSel = CMDSel.ExecuteReader
            While RDSel.Read
                If RDSel.GetBoolean(RDSel.GetOrdinal("serveis_comu_per_recursos")) Then
                    auxNonShared += New TimeSpan(0, CInt(RDSel.GetFloat(RDSel.GetOrdinal("llocs_serveis_quantitat")) * RDSel.GetInt16(RDSel.GetOrdinal("serveis_minuts_per_unitat"))), 0)
                Else
                    auxShared += New TimeSpan(0, CInt(RDSel.GetFloat(RDSel.GetOrdinal("llocs_serveis_quantitat")) * RDSel.GetInt16(RDSel.GetOrdinal("serveis_minuts_per_unitat"))), 0)
                End If
            End While
            If CN.State = ConnectionState.Open Then CN.Close()

            'si els serveis no tenen durada, posem la durada en minuts de la feina
            If auxNonShared.TotalMinutes = 0 And auxShared.TotalMinutes = 0 Then
                auxNonShared = New TimeSpan(0, LlocsSelDataGridView.Item("llocs_minuts_previst", e.RowIndex).Value, 0)
            End If

            auxPGElement = New PlaniGrid.PGElement("", LlocsSelDataGridView.Item("llocs_nom", e.RowIndex).Value.ToString, auxNonShared, auxShared, auxColorFeina, auxPGRecursos)

            'montem el cursor del drop
            DragCursor.gText = auxPGElement.Name
            DragCursor.gFont = Me.Font
            DragCursor.gTextBoxColor = IIf(auxPGRecursos.Count > 0, AgendaGrid.PGResourcesColor(auxPGRecursos), LlocsSelDataGridView.BackColor)
            DragCursor.gTextColor = AgendaGrid.ContrastedColor(DragCursor.gTextBoxColor)
            DragCursor.MakeCursor()

            returnValue = LlocsSelDataGridView.DoDragDrop(auxPGElement, DragDropEffects.Copy)
            If returnValue = DragDropEffects.Copy Then
                LlocsSelDataGridView.ClearSelection()
                RecursosSelDataGridView.ClearSelection()
            End If
        End If

        'Debug.WriteLine("LlocsSelDataGridView_CellMouseMove " & e.Button.ToString)

    End Sub

    Private Sub LlocsSelDataGridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LlocsSelDataGridView.KeyPress
        Dim auxrow As DataGridViewRow
        Dim auxchar As Char = UCase(e.KeyChar)

        If auxchar >= "A" And auxchar <= "Z" Or auxchar >= "0" And auxchar <= "9" Then
            LlocsSelDataGridView.ClearSelection()
            For Each r In LlocsSelDataGridView.Rows
                auxrow = r
                If auxchar <= UCase(auxrow.Cells("llocs_nom").Value.ToString) Then
                    LlocsSelDataGridView.CurrentCell = auxrow.Cells("llocs_nom")
                    Exit For
                End If
            Next
        End If

        'Debug.WriteLine(e.KeyChar)

    End Sub

    Private Sub RecursosSelDataGridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RecursosSelDataGridView.KeyPress
        Dim auxrow As DataGridViewRow
        Dim auxchar As Char = UCase(e.KeyChar)

        If auxchar >= "A" And auxchar <= "Z" Or auxchar >= "0" And auxchar <= "9" Then
            RecursosSelDataGridView.ClearSelection()
            For Each r In RecursosSelDataGridView.Rows
                auxrow = r
                If auxchar <= UCase(auxrow.Cells("recursos_nom").Value.ToString) Then
                    RecursosSelDataGridView.CurrentCell = auxrow.Cells("recursos_nom")
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Function Planificar_Feines(ByVal pdataini As Date, ByVal pdatafin As Date) As String

        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDSelLlocsPlanif As New OleDbCommand
        Dim RDSelLlocsPlanif As OleDbDataReader
        Dim CMDSelUltFeina As New OleDbCommand
        Dim RDSelUltFeina As OleDbDataReader

        Dim datapla As Date
        Dim horapla As String
        Dim nfeinespla As Integer   'nro. de feines planificades
        Dim nsetmana As Integer
        Dim dataaux As Date
        Dim auxPGElement As PlaniGrid.PGElement
        Dim auxLloc As String
        Dim auxRecurs As String
        Dim hihaerrors As Boolean = False
        Dim ultdataplalloc As Date  'per assegurar que no es planifica 2 feines del mateix lloc en la mateixa data

        nfeinespla = 0

        'carreguem form de missatges
        frmMissatges.Show()
        frmMissatges.Text = "PLANIFICACIÓ DE FEINES"
        frmMissatges.OK_Button.Enabled = False
        Me.Enabled = False

        frmMissatges.txtMissatges.Text = "Iniciant planificació periode: " & pdataini & " - " & pdatafin & " ..." & vbCrLf & vbCrLf
        frmMissatges.txtMissatges.Refresh()
        frmMissatges.txtMissatges.Focus()

        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Return False
            End Try
        End If

        Me.Cursor = Cursors.WaitCursor

        'per obtenir tots els llocs planificables
        CMDSelLlocsPlanif.Connection = CN
        CMDSelLlocsPlanif.CommandText = "SELECT * FROM Llocs WHERE Llocs.llocs_periodicitat_dies > " & 0 & ";"

        'per obtenir la ultima feina del lloc
        CMDSelUltFeina.Connection = CN
        CMDSelUltFeina.CommandText = "SELECT * FROM Feines WHERE Feines.llocs_nom = @lloc " & _
                        "ORDER BY Feines.feines_data DESC"
        CMDSelUltFeina.Parameters.Add("@lloc", OleDbType.Char)


        RDSelLlocsPlanif = CMDSelLlocsPlanif.ExecuteReader
        Dim LlocsReg(RDSelLlocsPlanif.FieldCount - 1) As Object

        'processem tots els llocs planificables
        While RDSelLlocsPlanif.Read
            RDSelLlocsPlanif.GetValues(LlocsReg)
            auxLloc = RDSelLlocsPlanif.Item("llocs_nom")
            If RDSelLlocsPlanif.IsDBNull(RDSelLlocsPlanif.GetOrdinal("recursos_nom")) Then
                auxRecurs = ""
            Else
                auxRecurs = RDSelLlocsPlanif.Item("recursos_nom")
            End If

            datapla = pdataini
            ultdataplalloc = Date.MinValue

            If RDSelLlocsPlanif.Item("llocs_primer_dia_mes") Or RDSelLlocsPlanif.Item("llocs_ultim_dia_mes") Then
                'PLANIFICACIO PRIMER O ULTIM DIA DEL MES

                'obtenim la primera data planificable
                datapla = Obtenir_Dia_Planificacio(datapla, RDSelLlocsPlanif.Item("llocs_dia_setmana"), RDSelLlocsPlanif.Item("llocs_primer_dia_mes"), RDSelLlocsPlanif.Item("llocs_ultim_dia_mes"))

                dataaux = datapla   'pel control del bucle. assegurar que acaba si restem 1 a datapla

                'mentre la data planificada no superi datafin
                While datapla <= pdatafin

                    'si cau en dissabte i el lloc no está pre-planificat/autoritzat pels dissabtes
                    If Weekday(datapla) = vbSaturday And RDSelLlocsPlanif.Item("llocs_dia_setmana") <> vbSaturday And Not RDSelLlocsPlanif.Item("llocs_dissabte") Then
                        If RDSelLlocsPlanif.Item("llocs_primer_dia_mes") Then
                            datapla = DateAdd(DateInterval.Day, 1, datapla) 'el passem a diumenge
                        Else
                            datapla = DateAdd(DateInterval.Day, -1, datapla) 'el passem a divendres
                        End If
                    End If

                    'si cau en diumenge i el lloc no está pre-planificat/autoritzat pels diumenges, saltem a la setmana seguent (dilluns)
                    If Weekday(datapla) = vbSunday And RDSelLlocsPlanif.Item("llocs_dia_setmana") <> vbSunday And Not RDSelLlocsPlanif.Item("llocs_diumenge") Then
                        If RDSelLlocsPlanif.Item("llocs_primer_dia_mes") Then
                            datapla = DateAdd(DateInterval.Day, 1, datapla) 'saltem a la setmana seguent (dilluns)
                        Else
                            'saltem a dissabte si autoritzat, si no a divendres
                            If RDSelLlocsPlanif.Item("llocs_dissabte") Then
                                datapla = DateAdd(DateInterval.Day, -1, datapla)
                            Else
                                datapla = DateAdd(DateInterval.Day, -2, datapla)
                            End If
                        End If
                    End If

                    'planifiquem en datapla (si està en el rang de dates a planificar)
                    If datapla >= pdataini And datapla <= pdatafin And datapla > ultdataplalloc Then
                        'si no informada hora lloc, assumim HORAINICI
                        If RDSelLlocsPlanif.IsDBNull(RDSelLlocsPlanif.GetOrdinal("llocs_hora")) Then
                            horapla = Microsoft.VisualBasic.Left(HORAINICI.ToString, 5)
                        Else
                            If RDSelLlocsPlanif.Item("llocs_hora") = "" Then
                                horapla = Microsoft.VisualBasic.Left(HORAINICI.ToString, 5)
                            Else
                                horapla = RDSelLlocsPlanif.Item("llocs_hora")
                            End If
                        End If

                        'construim el PGElement
                        auxPGElement = ConstruirNouElement(LlocsReg, datapla, horapla)

                        'l'afegim a la grid
                        If AgendaGrid.PGElementAddUpdate(auxPGElement) = PlaniGrid.PGReturnCode.PGError Then
                            'gravem errors en dialogerrors
                            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & "ERROR en planificació de feina: '" & auxLloc & "' el " & DiaCatala(Format(datapla, "dddd")) & " " & datapla & " a les " & horapla & "." & vbCrLf
                            hihaerrors = True
                        Else
                            'gravem missatge ok en dialogerrors
                            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & "Feina: '" & auxLloc & "' planificada el " & DiaCatala(Format(datapla, "dddd")) & " " & datapla & " a les " & horapla & IIf(auxPGElement.Resources.Count = 0, ".", " al recurs '" & auxRecurs & "'.")
                            nfeinespla = nfeinespla + 1
                            ultdataplalloc = datapla
                        End If
                        frmMissatges.txtMissatges.Refresh()
                        'frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length - 1
                        'frmMissatges.txtMissatges.ScrollToCaret()
                    End If

                    If datapla < dataaux Then datapla = dataaux 'sempre avancem la data

                    datapla = DateAdd(DateInterval.Day, 1, datapla)
                    'obtenim la seguent data planificable
                    datapla = Obtenir_Dia_Planificacio(datapla, RDSelLlocsPlanif.GetInt16(RDSelLlocsPlanif.GetOrdinal("llocs_dia_setmana")), RDSelLlocsPlanif.GetBoolean(RDSelLlocsPlanif.GetOrdinal("llocs_primer_dia_mes")), RDSelLlocsPlanif.GetBoolean(RDSelLlocsPlanif.GetOrdinal("llocs_ultim_dia_mes")))
                    dataaux = datapla
                End While

            Else
                'PLANIFICACIO NORMAL

                'buscar la ultima feina del lloc -> data a planificar
                CMDSelUltFeina.Parameters("@lloc").Value = auxLloc
                RDSelUltFeina = CMDSelUltFeina.ExecuteReader
                If RDSelUltFeina.Read Then
                    'calculem quan li toca
                    datapla = DateAdd(DateInterval.Day, RDSelLlocsPlanif.Item("llocs_periodicitat_dies"), RDSelUltFeina.Item("feines_data"))
                    'si tocava abans de data inici -> data inici
                    If datapla < pdataini Then datapla = pdataini
                End If
                RDSelUltFeina.Close()

                nsetmana = 0    ' x control dia de la setmana quan canvia la setmana

                'mentre la data planificada no superi datafin
                While datapla <= pdatafin

                    'cada nova setmana ajustem data a planificar segons dia de la setmana de lloc
                    If nsetmana < DatePart("ww", datapla, vbMonday) And RDSelLlocsPlanif.Item("llocs_dia_setmana") > 0 Then
                        nsetmana = DatePart("ww", datapla, vbMonday)

                        datapla = DateAdd(DateInterval.Day, RDSelLlocsPlanif.Item("llocs_dia_setmana") - Weekday(datapla), datapla)

                        'si l'ajust al dia setmana es anterior al periode a planificar
                        While datapla < pdataini
                            'anem afegint periodes
                            datapla = DateAdd(DateInterval.Day, RDSelLlocsPlanif.Item("llocs_periodicitat_dies"), datapla)
                        End While

                    End If

                    'si cau en dissabte i el lloc no está pre-planificat/autoritzat pels dissabtes, el passem a diumenge
                    If Weekday(datapla) = vbSaturday And RDSelLlocsPlanif.Item("llocs_dia_setmana") <> vbSaturday And Not RDSelLlocsPlanif.Item("llocs_dissabte") Then
                        datapla = DateAdd(DateInterval.Day, 1, datapla)
                    End If

                    'si cau en diumenge i el lloc no está pre-planificat/autoritzat pels diumenges, saltem a la setmana seguent (dilluns)
                    If Weekday(datapla) = vbSunday And RDSelLlocsPlanif.Item("llocs_dia_setmana") <> vbSunday And Not RDSelLlocsPlanif.Item("llocs_diumenge") Then
                        datapla = DateAdd(DateInterval.Day, 1, datapla)
                        'si no, planifiquem en datapla (si està en el rang de dates a plaificar)
                    Else
                        If datapla >= pdataini And datapla <= pdatafin And datapla > ultdataplalloc Then
                            'si no informada hora lloc, assumim HORAINICI
                            If RDSelLlocsPlanif.IsDBNull(RDSelLlocsPlanif.GetOrdinal("llocs_hora")) Then
                                horapla = Microsoft.VisualBasic.Left(HORAINICI.ToString, 5)
                            Else
                                If RDSelLlocsPlanif.Item("llocs_hora") = "" Then
                                    horapla = Microsoft.VisualBasic.Left(HORAINICI.ToString, 5)
                                Else
                                    horapla = RDSelLlocsPlanif.Item("llocs_hora")
                                End If
                            End If

                            'construim el PGElement
                            auxPGElement = ConstruirNouElement(LlocsReg, datapla, horapla)

                            'l'afegim a la grid
                            If AgendaGrid.PGElementAddUpdate(auxPGElement) = PlaniGrid.PGReturnCode.PGError Then
                                'gravem errors en dialogerrors
                                frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & "ERROR en planificació de feina: '" & auxLloc & "' el " & DiaCatala(Format(datapla, "dddd")) & " " & datapla & " a les " & horapla & "." & vbCrLf
                                hihaerrors = True
                            Else
                                'gravem missatge ok en dialogerrors
                                frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & "Feina: '" & auxLloc & "' planificada el " & DiaCatala(Format(datapla, "dddd")) & " " & datapla & " a les " & horapla & IIf(auxPGElement.Resources.Count = 0, ".", " al recurs '" & auxRecurs & "'.")
                                nfeinespla = nfeinespla + 1
                                ultdataplalloc = datapla
                            End If
                            frmMissatges.txtMissatges.Refresh()
                            'frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length - 1
                            'frmMissatges.txtMissatges.ScrollToCaret()
                        End If

                        'sumem la periodicitat
                        datapla = DateAdd(DateInterval.Day, RDSelLlocsPlanif.Item("llocs_periodicitat_dies"), datapla)
                        End If

                End While

            End If

        End While

        RDSelLlocsPlanif.Close()

        Me.Cursor = Cursors.Default

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & vbCrLf & nfeinespla & " feines planificades." & vbCrLf
        If Not hihaerrors Then
            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & vbCrLf & "FINALITZACIÓ CORRECTA!!!"
            Planificar_Feines = ""
        Else
            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & vbCrLf & "FINALITZACIÓ AMB ERRORS!!!"
            Planificar_Feines = "Hi ha hagut errors al planificar feines."
        End If
        frmMissatges.txtMissatges.Refresh()
        frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length
        frmMissatges.txtMissatges.ScrollToCaret()
        frmMissatges.OK_Button.Enabled = True
        'Me.Enabled = True

    End Function

    Private Function ConstruirNouElement(ByVal pLlocReg As Object(), ByVal pData As Date, ByVal phora As String) As PlaniGrid.PGElement
        'pLlocReg es el registre de valors del Lloc 
        Dim CNopen As Boolean
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

        CNopen = (CN.State = ConnectionState.Open)
        If Not CNopen Then
            Try
                CN.Open()
            Catch ex As Exception
                MsgBox("Error al obrir connexió: " & CNS)
                Return Nothing
            End Try
        End If

        CMDRecursosLloc.Connection = CN
        CMDRecursosLloc.CommandText = "SELECT Recursos.recursos_nom, Recursos.recursos_color, Recursos_Components.recursos_component_nom, Recursos_1.recursos_color " & _
        "FROM (Recursos LEFT JOIN Recursos_Components ON Recursos.recursos_nom = Recursos_Components.recursos_nom) LEFT JOIN Recursos AS Recursos_1 ON Recursos_Components.recursos_component_nom = Recursos_1.recursos_nom " & _
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
        CMDServeisLloc.Connection = CN
        CMDServeisLloc.CommandText = "SELECT Llocs_Serveis.llocs_serveis_quantitat, Serveis.serveis_minuts_per_unitat, Serveis.serveis_comu_per_recursos " & _
        "FROM Serveis INNER JOIN Llocs_Serveis ON Serveis.serveis_nom = Llocs_Serveis.serveis_nom " & _
        "WHERE (((Llocs_Serveis.llocs_nom)=@lloc));"
        CMDServeisLloc.Parameters.Add("@lloc", OleDbType.Char).Value = pLlocReg(0).ToString

        auxDuradaNoComp = TimeSpan.Zero
        auxDuradaComp = TimeSpan.Zero

        RDServeisLloc = CMDServeisLloc.ExecuteReader

        While RDServeisLloc.Read
            If RDServeisLloc.Item("serveis_comu_per_recursos") Then
                auxDuradaNoComp += New TimeSpan(0, RDServeisLloc.Item("llocs_serveis_quantitat") * RDServeisLloc.Item("serveis_minuts_per_unitat"), 0)
            Else
                auxDuradaComp += New TimeSpan(0, RDServeisLloc.Item("llocs_serveis_quantitat") * RDServeisLloc.Item("serveis_minuts_per_unitat"), 0)
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

        If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

        Return auxPGElement

    End Function

    Private Sub btnImprimirFacturacio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirFacturacio.Click
        Dim CNopen As Boolean = (CN.State = ConnectionState.Open)
        Dim CMDactualitzafeina As New OleDbCommand
        Dim CMDactualitzaxec As New OleDbCommand

        If cmbSelClients.Text <> "" Then
            'facturem client

            'actualitzem feines del client/mes
            If Not CNopen Then
                Try
                    CN.Open()
                Catch ex As Exception
                    MsgBox("Error al obrir connexió: " & CNS)
                    Exit Sub
                End Try
            End If

            CMDactualitzafeina.Connection = CN
            CMDactualitzafeina.CommandText = "UPDATE Feines " & _
            "SET feines_data_factura = @data, feines_quota = @quota WHERE feines_id = @id"
            CMDactualitzafeina.Parameters.Add("@data", OleDbType.Date)
            CMDactualitzafeina.Parameters.Add("@quota", OleDbType.Single)
            CMDactualitzafeina.Parameters.Add("@id", OleDbType.Integer)

            For i = 0 To dgvFactura.RowCount - 1
                If IsNumeric(dgvFactura.Rows(i).Cells("Feina").Value) And dgvFactura.Rows(i).Cells("Feta").Value = "Si" Then
                    CMDactualitzafeina.Parameters("@data").Value = Now
                    CMDactualitzafeina.Parameters("@quota").Value = CSng(dgvFactura.Rows(i).Cells("Quota").Value)
                    CMDactualitzafeina.Parameters("@id").Value = CLng(dgvFactura.Rows(i).Cells("Feina").Value)

                    If CMDactualitzafeina.ExecuteNonQuery < 1 Then
                        'ko
                        MsgBox("Error al actualitzar feina #" & dgvFactura.Rows(i).Cells("Feina").Value)
                    End If
                End If
            Next

            'actualitzem xecs del client/mes
            CMDactualitzaxec.Connection = CN
            CMDactualitzaxec.CommandText = "UPDATE Xecs " & _
            "SET xecs_data_liquidat = @data, feines_id = @feina WHERE xecs_id = @id"
            CMDactualitzaxec.Parameters.Add("@data", OleDbType.Date)
            CMDactualitzaxec.Parameters.Add("@feina", OleDbType.Integer)
            CMDactualitzaxec.Parameters.Add("@id", OleDbType.Integer)

            For i = 0 To dgvXecs.RowCount - 1

                If IsNumeric(dgvXecs.Rows(i).Cells("FeinaXec").Value) Then
                    CMDactualitzaxec.Parameters("@data").Value = Now
                    CMDactualitzaxec.Parameters("@feina").Value = CLng(dgvXecs.Rows(i).Cells("FeinaXec").Value)
                    CMDactualitzaxec.Parameters("@id").Value = CLng(dgvXecs.Rows(i).Cells("NroXec").Value)

                    If CMDactualitzaxec.ExecuteNonQuery < 1 Then
                        'ko
                        MsgBox("Error al actualitzar xec #" & dgvXecs.Rows(i).Cells("NroXec").Value)
                    End If
                End If
            Next

            If CN.State = ConnectionState.Open And Not CNopen Then CN.Close()

            Carrega_Grids_Factura()

            'llistem les dades x facturacio client/mes (a partir de grid factura)
            Imprimir_Facturacio_Client()

            'per actualitzar els xecs liquidats en la fitxa de client
            Me.XecsTableAdapter.Fill(Me.PlaniFeinesDataSet.Xecs)
            Carrega_TreeView_Clients()

            'cmbSelClients.Focus()

        Else
            'imprimim dades facturacio mes
            Imprimir_Resum_Facturacio_Mes()
        End If

    End Sub

    Private Sub Imprimir_Facturacio_Client()
        'definim instancies del Dataset i Datatable base de l'informe
        Dim ds As New dsFactura
        Dim dt As dsFactura.dtDetallFraDataTable = ds.Tables("dtDetallFra")
        Dim dr As DataRow
        Dim auxrow As DataGridViewRow
        Dim drclient As DataRow = CType(ClientsBindingSource.Current, DataRowView).Row

        Dim miRpt As New crpFacturaClientMes

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        'carreguem la datatable a partir de la grid de factures
        dt.Clear()
        For Each r In dgvFactura.Rows
            auxrow = r
            If Not IsNothing(auxrow.Cells("Feina").Value) And auxrow.Cells("Feta").Value = "Si" Then
                dr = dt.NewRow
                dr("Feina") = auxrow.Cells("Feina").Value
                dr("Quota") = auxrow.Cells("Quota").Value
                dr("Data") = auxrow.Cells("Data").Value
                dr("Lloc") = auxrow.Cells("Lloc").Value
                dr("Recurs") = auxrow.Cells("Recurs").Value
                dr("Servei") = auxrow.Cells("Servei").Value
                dr("Quantitat") = auxrow.Cells("Quantitat").Value
                dr("Unitat") = auxrow.Cells("Unitat").Value
                dr("Import") = IIf(auxrow.Cells("ImportServei").FormattedValue = "", 0, auxrow.Cells("ImportServei").Value)
                dr("Observacions") = auxrow.Cells("Observacions").Value
                dt.Rows.Add(dr)
            End If

        Next

        'lliguem el datatable al report i el mostrem
        miRpt.SetDataSource(ds)
        miRpt.SetParameterValue(0, Format(dtpSelMes.Value, "yyyyMM"))
        miRpt.SetParameterValue(1, txtTotalServeis.Text)
        miRpt.SetParameterValue(2, txtTotalNXecs.Text)
        miRpt.SetParameterValue(3, txtTotalXecs.Text)
        miRpt.SetParameterValue(4, txtPagaments.Text)
        miRpt.SetParameterValue(5, txtTotalFacturar.Text)
        miRpt.SetParameterValue(6, drclient("clients_nom"))
        miRpt.SetParameterValue(7, IIf(Not IsDBNull(drclient("clients_NIF")), drclient("clients_NIF"), ""))
        miRpt.SetParameterValue(8, drclient("clients_adreça") & " " & drclient("clients_codi_postal") & " " & drclient("clients_poblacio"))
        miRpt.SetParameterValue(9, IIf(Not IsDBNull(drclient("clients_telefons")), drclient("clients_telefons"), ""))
        miRpt.SetParameterValue(10, IIf(Not IsDBNull(drclient("clients_ccc")), drclient("clients_ccc"), ""))

        miRpt.SummaryInfo.ReportTitle = "crpFacturaClientMes"

        frmImpressio.CrystalReportViewer1.ReportSource = miRpt
        frmImpressio.WindowState = FormWindowState.Maximized
        frmImpressio.CrystalReportViewer1.ShowFirstPage()

        frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub Imprimir_Llista_Feines()
        Dim CNOpen As Boolean
        Dim auxDS As New DataSet
        Dim auxFeinesDA As OleDb.OleDbDataAdapter
        Dim pDataIni As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim pDataFi As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim pRecurs As New OleDbParameter("@recurs", OleDbType.Char)
        Dim auxdate As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim miRpt As New crpLlistaFeines
        Dim auxtext As String
        Dim auxcomandtxt As String

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        pDataIni.Direction = ParameterDirection.Input
        pDataFi.Direction = ParameterDirection.Input
        pRecurs.Direction = ParameterDirection.Input

        auxtext = UCase(RecursosSelDataGridView.SelectedRows(0).Cells("recursos_nom").FormattedValue)

        'determinem el periode
        Select Case AgendaGrid.VisualizationMode
            Case PlaniGrid.PGMode.Day
                auxdate = AgendaGrid.DisplayDate
                pDataIni.Value = auxdate
                auxdate = DateAdd(DateInterval.Day, 1, auxdate)
                pDataFi.Value = auxdate
                auxtext = auxtext & "  Relació de FEINES del dia: " & AgendaGrid.DisplayDate.Date

            Case PlaniGrid.PGMode.Month
                auxdate = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
                pDataIni.Value = auxdate
                auxdate = DateAdd(DateInterval.Month, 1, auxdate)
                pDataFi.Value = auxdate
                auxtext = auxtext & "  Relació de FEINES del mes: " & Format(dtpSelMes.Value, "yyyyMM")

            Case Else 'setmana o recurs
                auxdate = DateAdd(DateInterval.Day, 1 - Weekday(AgendaGrid.DisplayDate, FirstDayOfWeek.Monday), AgendaGrid.DisplayDate)
                pDataIni.Value = auxdate
                auxtext = auxtext & "  Relació de FEINES del periode: " & auxdate.Date & "-"
                auxdate = DateAdd(DateInterval.Day, 7, auxdate)
                pDataFi.Value = auxdate
                auxtext = auxtext & DateAdd(DateInterval.Day, -1, auxdate)

        End Select

        pRecurs.Value = RecursosSelDataGridView.SelectedRows(0).Cells("recursos_nom").FormattedValue

        'determinem selecció segons si el recurs és compost o no
        If RecursosSelDataGridView.SelectedRows(0).Cells("recursos_grup").Value Then
            auxcomandtxt = "SELECT * FROM Feines WHERE (feines_data>=@dataini And feines_data<@datafi And recursos_nom=@recurs) ORDER BY feines_data , feines_hora_inici"
        Else
            auxcomandtxt = "SELECT Feines.*, IIf(IsNull(Recursos_Components.recursos_component_nom),Feines.recursos_nom,Recursos_Components.recursos_component_nom) AS recurs" & _
                           " FROM Feines LEFT JOIN Recursos_Components ON Feines.recursos_nom = Recursos_Components.recursos_nom" & _
                           " WHERE feines_data>=@dataini And feines_data<@datafi" & _
                           " AND IIf(IsNull(Recursos_Components.recursos_component_nom),Feines.recursos_nom,Recursos_Components.recursos_component_nom)=@recurs" & _
                           " ORDER BY Feines.feines_data, Feines.feines_hora_inici"
        End If

        auxFeinesDA = New OleDb.OleDbDataAdapter(auxcomandtxt, CN)

        auxFeinesDA.SelectCommand.Parameters.Add(pDataIni)
        auxFeinesDA.SelectCommand.Parameters.Add(pDataFi)
        auxFeinesDA.SelectCommand.Parameters.Add(pRecurs)

        CNOpen = (CN.State = ConnectionState.Open)

        Try
            If Not CNOpen Then
                CN.Open()
            End If

            auxFeinesDA.Fill(auxDS, "Feines")

            miRpt.SetDataSource(auxDS)
            miRpt.SetParameterValue(0, auxtext)
            miRpt.SummaryInfo.ReportTitle = "crpLlistaFeines"

            frmImpressio.CrystalReportViewer1.ReportSource = miRpt
            frmImpressio.WindowState = FormWindowState.Maximized
            frmImpressio.CrystalReportViewer1.ShowFirstPage()

            frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Catch ex As Exception
            MsgBox("Mensaje : " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

        If Not CNOpen Then
            CN.Close()
        End If

    End Sub

    Private Sub Imprimir_Hores_Client()
        Dim CNOpen As Boolean
        Dim auxDS As New DataSet
        Dim auxFeinesDA As OleDb.OleDbDataAdapter
        Dim auxFeinesDetallDA As OleDb.OleDbDataAdapter
        Dim auxServeisDA As OleDb.OleDbDataAdapter
        Dim pClient As New OleDbParameter("@client", OleDbType.Char)
        Dim pDataIni As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim pDataFi As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim pClientDetall As New OleDbParameter("@client", OleDbType.Char)
        Dim pDataIniDetall As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim pDataFiDetall As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim miRpt As New crpHoresClient
        Dim auxFeinesDACmd As String
        Dim auxFeinesDetallDACmd As String
        Dim auxServeisDACmd As String

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        pDataIni.Direction = ParameterDirection.Input
        pDataFi.Direction = ParameterDirection.Input
        pClient.Direction = ParameterDirection.Input
        pDataIniDetall.Direction = ParameterDirection.Input
        pDataFiDetall.Direction = ParameterDirection.Input
        pClientDetall.Direction = ParameterDirection.Input

        pClient.Value = cmbSelClientInformes.Text
        pDataIni.Value = PlaniMonthViewDesDe.SelectedDate.Date
        pDataFi.Value = PlaniMonthViewFins.SelectedDate.Date
        pClientDetall.Value = cmbSelClientInformes.Text
        pDataIniDetall.Value = PlaniMonthViewDesDe.SelectedDate.Date
        pDataFiDetall.Value = PlaniMonthViewFins.SelectedDate.Date

        auxFeinesDACmd = "SELECT DISTINCT Feines.* " & _
        "FROM Serveis INNER JOIN ((Clients INNER JOIN Llocs ON Clients.clients_nom = Llocs.clients_nom) INNER JOIN (Feines INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Llocs.llocs_nom = Feines.llocs_nom) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
        "WHERE (((Clients.clients_nom) = @client) And ((Feines.feines_data) >= @dataini AND (Feines.feines_data) <= @datafi) AND ((Serveis.serveis_minuts_per_unitat)<>0) AND ((Feines.feines_feta)=True)) " & _
        "ORDER BY Feines.feines_data"
        auxFeinesDA = New OleDb.OleDbDataAdapter(auxFeinesDACmd, CN)
        auxFeinesDA.SelectCommand.Parameters.Add(pClient)
        auxFeinesDA.SelectCommand.Parameters.Add(pDataIni)
        auxFeinesDA.SelectCommand.Parameters.Add(pDataFi)

        auxFeinesDetallDACmd = "SELECT Feines_Detall.* " & _
        "FROM Serveis INNER JOIN ((Clients INNER JOIN Llocs ON Clients.clients_nom = Llocs.clients_nom) INNER JOIN (Feines INNER JOIN Feines_Detall ON Feines.feines_id = Feines_Detall.feines_id) ON Llocs.llocs_nom = Feines.llocs_nom) ON Serveis.serveis_nom = Feines_Detall.serveis_nom " & _
        "WHERE (((Clients.clients_nom) = @client) And ((Feines.feines_data) >= @dataini AND (Feines.feines_data) <= @datafi) AND ((Serveis.serveis_minuts_per_unitat)<>0) AND ((Feines.feines_feta)=True)) " & _
        "ORDER BY Feines.feines_data"
        auxFeinesDetallDA = New OleDb.OleDbDataAdapter(auxFeinesDetallDACmd, CN)
        auxFeinesDetallDA.SelectCommand.Parameters.Add(pClientDetall)
        auxFeinesDetallDA.SelectCommand.Parameters.Add(pDataIniDetall)
        auxFeinesDetallDA.SelectCommand.Parameters.Add(pDataFiDetall)

        auxServeisDACmd = "SELECT Serveis.* FROM Serveis"
        auxServeisDA = New OleDb.OleDbDataAdapter(auxServeisDACmd, CN)

        CNOpen = (CN.State = ConnectionState.Open)

        Try
            If Not CNOpen Then
                CN.Open()
            End If

            auxFeinesDA.Fill(auxDS, "Feines")
            auxServeisDA.Fill(auxDS, "Serveis")
            auxFeinesDetallDA.Fill(auxDS, "Feines_Detall")

            miRpt.SetDataSource(auxDS)
            miRpt.SetParameterValue(0, pClient.Value.ToString)
            miRpt.SetParameterValue(1, PlaniMonthViewDesDe.SelectedDate.Date & " - " & PlaniMonthViewFins.SelectedDate.Date)
            miRpt.SummaryInfo.ReportTitle = "crpHoresClient"

            frmImpressio.CrystalReportViewer1.ReportSource = miRpt
            frmImpressio.WindowState = FormWindowState.Maximized
            frmImpressio.CrystalReportViewer1.ShowFirstPage()

            frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Catch ex As Exception
            MsgBox("Mensaje : " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

        If Not CNOpen Then
            CN.Close()
        End If

    End Sub

    Private Sub Imprimir_Hores_Mes()
        Dim miRpt As New crpHoresExtra

        miRpt.SetParameterValue(0, Format(dtpSelMes.Value, "yyyyMM"))
        miRpt.SummaryInfo.ReportTitle = "crpHoresExtra"

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        'frmImpressio.CrystalReportViewer1.DisplayGroupTree = False
        frmImpressio.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmImpressio.WindowState = FormWindowState.Maximized
        frmImpressio.Show()
        frmImpressio.BringToFront()

        frmImpressio.CrystalReportViewer1.ReportSource = miRpt
        frmImpressio.CrystalReportViewer1.ShowFirstPage()

        frmImpressio.Text = frmImpressio.CrystalReportViewer1.ReportSource.SummaryInfo.ReportTitle
        frmImpressio.CrystalReportViewer1.Refresh()

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub Imprimir_Resum_Facturacio_Mes()
        'definim instancies del Dataset i Datatable base de l'informe
        Dim ds As New dsFactura
        Dim dt As dsFactura.dtResumFracioDataTable = ds.Tables("dtResumFracio")
        Dim dr As DataRow

        Dim auxrow As DataGridViewRow
        Dim drclient As DataRow

        Dim dataini As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim datafi As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dataini))

        'Dim miRpt As New crpResumFactMes
        Dim miRpt As New crpResumFactPeriode

        'ajustem data final periode
        datafi = IIf(datafi > Now.Date, Now.Date, datafi)

        'carreguem form de missatges
        frmMissatges.Show()
        frmMissatges.Text = "CÀLCUL DE DADES DE FACTURACIÓ (Espera si et plau...)"
        frmMissatges.OK_Button.Visible = False

        frmMissatges.txtMissatges.Text = "Iniciant càlcul periode: " & dataini & " - " & datafi & " ..." & vbCrLf & vbCrLf
        frmMissatges.txtMissatges.Refresh()
        frmMissatges.txtMissatges.Focus()
        frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length
        frmMissatges.txtMissatges.ScrollToCaret()

        Me.Cursor = Cursors.WaitCursor

        'desactivem controls
        dtpSelMes.Visible = False
        cmbSelClients.Visible = False
        dgvXecs.Visible = False
        Me.Enabled = False

        dt.Clear()

        'generem dades per cada client
        For i = 0 To cmbSelClients.Items.Count - 1
            cmbSelClients.SelectedIndex = i

            frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & "Client: " & cmbSelClients.SelectedValue & vbCrLf
            frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length
            frmMissatges.txtMissatges.ScrollToCaret()

            'carreguem les dades resum del client al DataSet
            drclient = CType(ClientsBindingSource.Current, DataRowView).Row

            'carreguem la datatable a partir de la grid de factures
            For Each r In dgvFactura.Rows
                auxrow = r
                'registre de feina feta (en llocs sense quota)
                If Not IsNothing(auxrow.Cells("Feina").Value) And auxrow.Cells("Feta").Value = "Si" And auxrow.Cells("ImportServei").FormattedValue <> "" Then
                    dr = dt.NewRow
                    dr("Client") = drclient("clients_nom")
                    dr("Lloc") = " " & auxrow.Cells("Lloc").Value
                    dr("Servei") = auxrow.Cells("Servei").Value
                    dr("Quantitat") = auxrow.Cells("Quantitat").Value
                    dr("Unitat") = auxrow.Cells("Unitat").Value
                    dr("Import") = IIf(auxrow.Cells("ImportServei").FormattedValue = "", 0, auxrow.Cells("ImportServei").Value)
                    dr("ccc") = drclient("clients_ccc")

                    'dr("Quota") = auxrow.Cells("Quota").Value
                    dt.Rows.Add(dr)
                Else
                    'registre de lloc amb quota
                    If IsNothing(auxrow.Cells("Feina").Value) And auxrow.Cells("Quantitat").FormattedValue = "QUOTA" Then
                        dr = dt.NewRow
                        dr("Client") = drclient("clients_nom")
                        dr("Lloc") = " " & auxrow.Cells("Lloc").Value
                        dr("Servei") = ""
                        dr("Quantitat") = 1
                        dr("Unitat") = "Quota mensual"
                        dr("Import") = IIf(auxrow.Cells("ImportServei").FormattedValue = "", 0, auxrow.Cells("ImportServei").Value)
                        dr("ccc") = drclient("clients_ccc")
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
            'carreguem registre xecs si n'hi ha
            If dgvXecs.RowCount > 0 Then
                dr = dt.NewRow
                dr("Client") = drclient("clients_nom")
                dr("Lloc") = "."
                dr("Servei") = "XECS"
                dr("Quantitat") = CInt(txtTotalNXecs.Text)
                dr("Unitat") = "x " & VALORDFTXEC.ToString
                dr("Import") = -CSng(txtTotalXecs.Text)
                dr("ccc") = drclient("clients_ccc")
                dt.Rows.Add(dr)
            End If
        Next

        cmbSelClients.SelectedIndex = -1

        'reactivem controls
        dtpSelMes.Visible = True
        cmbSelClients.Visible = True
        dgvXecs.Visible = True
        Me.Enabled = True

        'Me.Cursor = Cursors.Default

        frmMissatges.txtMissatges.Text = frmMissatges.txtMissatges.Text & vbCrLf & vbCrLf & "FINALITZACIÓ CORRECTA!!!"
        frmMissatges.txtMissatges.Refresh()
        frmMissatges.txtMissatges.Focus()
        frmMissatges.txtMissatges.SelectionStart = frmMissatges.txtMissatges.Text.Length
        frmMissatges.txtMissatges.ScrollToCaret()

        frmMissatges.Text = "CÀLCUL DE DADES DE FACTURACIÓ"

        'mostrem l'informe
        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        'lliguem el datatable al report i el mostrem
        miRpt.SetDataSource(ds)
        miRpt.SetParameterValue(0, dataini & " - " & datafi)

        miRpt.SummaryInfo.ReportTitle = "crpResumFactPeriode"

        frmImpressio.CrystalReportViewer1.ReportSource = miRpt
        frmImpressio.WindowState = FormWindowState.Maximized
        frmImpressio.CrystalReportViewer1.ShowFirstPage()

        frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        frmMissatges.Close()
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btnImprimirHores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirHores.Click
        Dim CNOpen As Boolean
        Dim auxDS As New DataSet
        Dim auxHoresDA As New OleDb.OleDbDataAdapter("SELECT * FROM Hores_Fetes WHERE (((hores_data)>=@dataini And (hores_data)<@datafi))", CN)
        Dim param1 As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim param2 As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim auxdate As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim miRpt As New crpHoresExtra

        Me.Cursor = Cursors.WaitCursor

        'borrar hores extra errònies (sense feines del recurs en el dia)
        Borra_hores_extres_erronies()

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        param1.Direction = ParameterDirection.Input
        param1.Value = auxdate
        auxHoresDA.SelectCommand.Parameters.Add(param1)

        param2.Direction = ParameterDirection.Input
        auxdate = DateAdd(DateInterval.Month, 1, auxdate)
        param2.Value = auxdate
        auxHoresDA.SelectCommand.Parameters.Add(param2)

        CNOpen = (CN.State = ConnectionState.Open)

        Try
            If Not CNOpen Then
                CN.Open()
            End If
            auxHoresDA.Fill(auxDS, "Hores_Fetes")

            miRpt.SetDataSource(auxDS)
            miRpt.SetParameterValue(0, Format(dtpSelMes.Value, "yyyyMM"))
            miRpt.SummaryInfo.ReportTitle = "crpHoresExtra"

            frmImpressio.CrystalReportViewer1.ReportSource = miRpt
            frmImpressio.WindowState = FormWindowState.Maximized
            frmImpressio.CrystalReportViewer1.ShowFirstPage()

            frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Catch ex As Exception
            MsgBox("Mensaje : " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

        If Not CNOpen Then
            CN.Close()
        End If

    End Sub

    Public Sub Borra_hores_extres_erronies()
        Dim CNOpen As Boolean
        Dim auxDS As New DataSet
        Dim auxHoresDA As New OleDb.OleDbDataAdapter("SELECT * FROM Hores_Fetes WHERE hores_data>=@dataini And hores_data<@datafi ORDER BY hores_data", CN)
        Dim auxHoresCB As OleDbCommandBuilder = New OleDbCommandBuilder(auxHoresDA)

        Dim auxFeinesDA As New OleDb.OleDbDataAdapter("SELECT Feines.*, IIf(IsNull(Recursos_Components.recursos_component_nom),Feines.recursos_nom,Recursos_Components.recursos_component_nom) AS RECURS" & _
            " FROM Feines LEFT JOIN Recursos_Components ON Feines.recursos_nom = Recursos_Components.recursos_nom" & _
            " WHERE Feines.feines_data=@data", CN)

        Dim pdataini As New OleDbParameter("@dataini", OleDbType.DBDate)
        Dim pdatafi As New OleDbParameter("@datafi", OleDbType.DBDate)
        Dim pdata As New OleDbParameter("@dataini", OleDbType.DBDate)

        Dim auxdate As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim trobat As Boolean

        pdataini.Direction = ParameterDirection.Input
        pdatafi.Direction = ParameterDirection.Input
        pdata.Direction = ParameterDirection.Input

        pdataini.Value = auxdate
        auxdate = DateAdd(DateInterval.Month, 1, auxdate)
        pdatafi.Value = auxdate

        auxHoresDA.SelectCommand.Parameters.Add(pdataini)
        auxHoresDA.SelectCommand.Parameters.Add(pdatafi)
        auxFeinesDA.SelectCommand.Parameters.Add(pdata)

        CNOpen = (CN.State = ConnectionState.Open)

        If Not CNOpen Then
            CN.Open()
        End If

        'carreguem les hores extres del mes
        auxHoresDA.Fill(auxDS, "Hores_Fetes")

        For i = 0 To auxDS.Tables("Hores_Fetes").Rows.Count - 1
            'recarreguem taula feines si canvia la data
            If pdata.Value <> auxDS.Tables("Hores_Fetes").Rows(i).Item("hores_data") Then
                If auxDS.Tables("Feines") IsNot Nothing Then auxDS.Tables("Feines").Rows.Clear()
                pdata.Value = auxDS.Tables("Hores_Fetes").Rows(i).Item("hores_data")
                auxFeinesDA.Fill(auxDS, "Feines")
            End If
            'si no hi ha feina del recurs en la data
            trobat = False
            For j = 0 To auxDS.Tables("Feines").Rows.Count - 1
                If Not IsDBNull(auxDS.Tables("Feines").Rows(j).Item("RECURS")) Then
                    If auxDS.Tables("Feines").Rows(j).Item("RECURS") = auxDS.Tables("Hores_Fetes").Rows(i).Item("recursos_nom") Then
                        trobat = True
                        Exit For
                    End If
                End If
            Next
            If Not trobat Then
                'borrem les hores extres
                auxDS.Tables("Hores_Fetes").Rows(i).Delete()
            End If
        Next

        'actualitzar la BBDD Hores_Fetes
        auxHoresCB.GetUpdateCommand()
        auxHoresDA.Update(auxDS, "Hores_Fetes")

        If Not CNOpen Then
            CN.Close()
        End If

    End Sub


    Private Sub RecursosSelDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecursosSelDataGridView.SelectionChanged

        If RecursosSelDataGridView.SelectedRows.Count = 0 Then
            btnImprimirAgenda.Text = "Imprimir Agenda"
        Else
            btnImprimirAgenda.Text = "Imprimir Feines Recurs"
        End If

    End Sub

    Private Sub cmbSelClientInformes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSelClientInformes.KeyDown
        If e.KeyCode = Keys.Escape Then
            cmbSelClientInformes.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmbSelClientInformes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelClientInformes.SelectedIndexChanged
        If cmbSelClientInformes.SelectedIndex = -1 Then
            btnInfHoresFetes.Visible = False
        Else
            btnInfHoresFetes.Visible = True
        End If
    End Sub

    Private Sub btnInfHoresFetes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfHoresFetes.Click
        Imprimir_Hores_Client()
    End Sub

    Private Sub PlaniMonthViewDesDe_DateChanged(ByVal pDate As Date) Handles PlaniMonthViewDesDe.DateChanged
        If pDate > PlaniMonthViewFins.SelectedDate Then
            PlaniMonthViewFins.SelectedDate = pDate
        End If
    End Sub

    Private Sub PlaniMonthViewFins_DateChanged(ByVal pDate As Date) Handles PlaniMonthViewFins.DateChanged
        If pDate < PlaniMonthViewDesDe.SelectedDate Then
            PlaniMonthViewDesDe.SelectedDate = pDate
        End If
    End Sub

    Private Sub btnImprimirHoresTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirHoresTotals.Click
        Dim auxDS As New DataSet
        Dim auxDT As New PlaniFeinesDataSet.Hores_FetesDataTable
        Dim auxdate As Date = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
        Dim auxmes As Integer = Month(auxdate)
        Dim miRpt As New crpHoresTotal
        Dim dr As DataRow
        Dim auxrow As DataGridViewRow
        Dim auxsng As Single

        Me.Cursor = Cursors.WaitCursor

        frmImpressio.Close()
        frmImpressio.Text = "ESPERA SI ET PLAU. Generant informe... "
        frmImpressio.Show()
        frmImpressio.BringToFront()

        Try
            'carreguem la taula per l'informe
            auxDT.Clear()
            For Each r In RecursosSelDataGridView.Rows
                auxrow = r
                'només els no grup
                If Not auxrow.Cells("recursos_grup").Value Then
                    While Month(auxdate) = auxmes
                        auxsng = Calcular_Hores_Dia(auxrow.Cells("recursos_nom").Value, auxdate, "TREBALLADES")
                        If auxsng > 0 Then
                            dr = auxDT.NewRow
                            dr("recursos_nom") = auxrow.Cells("recursos_nom").Value
                            dr("hores_data") = auxdate.Date
                            dr("hores_quantitat") = auxsng
                            auxDT.Rows.Add(dr)
                        End If
                        auxdate = DateAdd(DateInterval.Day, 1, auxdate)
                    End While
                    auxdate = DateSerial(dtpSelMes.Value.Year, dtpSelMes.Value.Month, 1)
                End If
            Next

            auxDS.Tables.Add(auxDT)

            miRpt.SetDataSource(auxDS)
            miRpt.SetParameterValue(0, Format(dtpSelMes.Value, "yyyyMM"))
            miRpt.SummaryInfo.ReportTitle = "crpHoresTotal"

            frmImpressio.CrystalReportViewer1.ReportSource = miRpt
            frmImpressio.WindowState = FormWindowState.Maximized
            frmImpressio.CrystalReportViewer1.ShowFirstPage()

            frmImpressio.Text = miRpt.SummaryInfo.ReportTitle

        Catch ex As Exception
            MsgBox("Mensaje : " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Llocs_periodicitat_diesTextBox_TextChanged(sender As Object, e As EventArgs) Handles Llocs_periodicitat_diesTextBox.TextChanged
        If Llocs_periodicitat_diesTextBox.Text = "" Then Llocs_periodicitat_diesTextBox.Text = "0"
    End Sub
End Class
