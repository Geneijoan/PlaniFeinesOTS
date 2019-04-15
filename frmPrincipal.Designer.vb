<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Clients_nomLabel As System.Windows.Forms.Label
        Dim Clients_NIFLabel As System.Windows.Forms.Label
        Dim Clients_adreçaLabel As System.Windows.Forms.Label
        Dim Clients_poblacioLabel As System.Windows.Forms.Label
        Dim Clients_codi_postalLabel As System.Windows.Forms.Label
        Dim Clients_telefonsLabel As System.Windows.Forms.Label
        Dim Clients_data_altaLabel As System.Windows.Forms.Label
        Dim Clients_xecsLabel As System.Windows.Forms.Label
        Dim Clients_cccLabel As System.Windows.Forms.Label
        Dim Clients_emailLabel As System.Windows.Forms.Label
        Dim Clients_observacionsLabel As System.Windows.Forms.Label
        Dim Llocs_nomLabel As System.Windows.Forms.Label
        Dim Llocs_adreçaLabel As System.Windows.Forms.Label
        Dim Llocs_poblacioLabel As System.Windows.Forms.Label
        Dim Llocs_telefonLabel As System.Windows.Forms.Label
        Dim Llocs_periodicitat_diesLabel As System.Windows.Forms.Label
        Dim Llocs_dia_setmanaLabel As System.Windows.Forms.Label
        Dim Llocs_horaLabel As System.Windows.Forms.Label
        Dim Llocs_minuts_previstLabel As System.Windows.Forms.Label
        Dim Recursos_nomLabel As System.Windows.Forms.Label
        Dim Llocs_quotaLabel As System.Windows.Forms.Label
        Dim Llocs_observacionsLabel As System.Windows.Forms.Label
        Dim Xecs_idLabel As System.Windows.Forms.Label
        Dim Xecs_data_entregaLabel As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Llocs_nomLabel1 As System.Windows.Forms.Label
        Dim Serveis_nomLabel As System.Windows.Forms.Label
        Dim Llocs_serveis_quantitatLabel As System.Windows.Forms.Label
        Dim Llocs_serveis_preu_unLabel As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Xecs_valorLabel As System.Windows.Forms.Label
        Dim Feines_idLabel As System.Windows.Forms.Label
        Dim Xecs_data_liquidatLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle73 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle74 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle75 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle76 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle77 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle78 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle79 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle80 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle81 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle85 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle86 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle87 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle88 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle91 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle89 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle90 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Dim TextShadower4 As gCursorLib.TextShadower = New gCursorLib.TextShadower()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageAgenda = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.LlocsSelDataGridView = New System.Windows.Forms.DataGridView()
        Me.llocs_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clients_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_adreça = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_poblacio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_telefon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_minuts_previst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_periodicitat_dies = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_dia_setmana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_dissabte = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.llocs_diumenge = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.llocs_hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_recursos_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_observacions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_quota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.llocs_primer_dia_mes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.llocs_ultim_dia_mes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LlocsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlaniFeinesDataSet = New PlaniFeinesOTS.PlaniFeinesDataSet()
        Me.Calendari = New PlaniSoftwareControlLibrary.PlaniMonthView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RecursosSelDataGridView = New System.Windows.Forms.DataGridView()
        Me.recursos_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recursos_grup = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.recursos_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecursosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtNumFeina = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnImprimirAgenda = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AgendaGrid = New PlaniSoftwareControlLibrary.PlaniGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvHoresExtra = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPageFacturacio = New System.Windows.Forms.TabPage()
        Me.btnImprimirHoresTotals = New System.Windows.Forms.Button()
        Me.btnImprimirFacturacio = New System.Windows.Forms.Button()
        Me.btnImprimirXecs = New System.Windows.Forms.Button()
        Me.btnImprimirHores = New System.Windows.Forms.Button()
        Me.txtTotalFacturar = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalHores = New System.Windows.Forms.TextBox()
        Me.txtTotalServeis = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvFactura = New System.Windows.Forms.DataGridView()
        Me.Feina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recurs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Feta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataFra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportServei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalNXecs = New System.Windows.Forms.TextBox()
        Me.txtTotalXecs = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dgvXecs = New System.Windows.Forms.DataGridView()
        Me.DataEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroXec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeinaXec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataLiquidat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServeiFeina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantitatFeina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitatFeina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportXec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPagaments = New System.Windows.Forms.TextBox()
        Me.chkPdtFacturar = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbSelClients = New System.Windows.Forms.ComboBox()
        Me.ClientsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpSelMes = New System.Windows.Forms.DateTimePicker()
        Me.TabPageClients = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.tvClients = New System.Windows.Forms.TreeView()
        Me.pnlClients = New System.Windows.Forms.Panel()
        Me.Clients_observacionsTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_emailTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_cccTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_xecsCheckBox = New System.Windows.Forms.CheckBox()
        Me.Clients_data_altaTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_telefonsTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_codi_postalMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Clients_poblacioTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_adreçaTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_NIFTextBox = New System.Windows.Forms.TextBox()
        Me.Clients_nomTextBox = New System.Windows.Forms.TextBox()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.pnlServeis = New System.Windows.Forms.Panel()
        Me.Llocs_serveis_preu_unTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_ServeisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Llocs_serveis_quantitatTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnitat = New System.Windows.Forms.TextBox()
        Me.ServeisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Serveis_nomComboBox = New System.Windows.Forms.ComboBox()
        Me.Llocs_nomTextBox1 = New System.Windows.Forms.TextBox()
        Me.lblServei = New System.Windows.Forms.Label()
        Me.pnlXecs = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblQuants = New System.Windows.Forms.Label()
        Me.txtQuants = New System.Windows.Forms.TextBox()
        Me.Xecs_data_liquidatTextBox = New System.Windows.Forms.TextBox()
        Me.XecsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Feines_idTextBox = New System.Windows.Forms.TextBox()
        Me.Xecs_valorTextBox = New System.Windows.Forms.TextBox()
        Me.Xecs_idTextBox = New System.Windows.Forms.TextBox()
        Me.Xecs_data_entregaDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Clients_nomTextBox2 = New System.Windows.Forms.TextBox()
        Me.lblXec = New System.Windows.Forms.Label()
        Me.pnlLlocs = New System.Windows.Forms.Panel()
        Me.Llocs_horaComboBox = New System.Windows.Forms.ComboBox()
        Me.Llocs_periodicitat_diesTextBox = New System.Windows.Forms.TextBox()
        Me.lblLloc = New System.Windows.Forms.Label()
        Me.Llocs_quotaTextBox = New System.Windows.Forms.TextBox()
        Me.Recursos_nomComboBox = New System.Windows.Forms.ComboBox()
        Me.Clients_nomTextBox1 = New System.Windows.Forms.TextBox()
        Me.cmbDiesSetmana = New System.Windows.Forms.ComboBox()
        Me.Llocs_observacionsTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_minuts_previstMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Llocs_ultim_dia_mesCheckBox = New System.Windows.Forms.CheckBox()
        Me.Llocs_primer_dia_mesCheckBox = New System.Windows.Forms.CheckBox()
        Me.Llocs_diumengeCheckBox = New System.Windows.Forms.CheckBox()
        Me.Llocs_dissabteCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Llocs_telefonTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_poblacioTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_adreçaTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_nomTextBox = New System.Windows.Forms.TextBox()
        Me.Llocs_dia_setmanaTextBox = New System.Windows.Forms.TextBox()
        Me.TabPageRecursosIServeis = New System.Windows.Forms.TabPage()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.RecursosDataGridView = New System.Windows.Forms.DataGridView()
        Me.cRecurs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cGrup = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ServeisDataGridView = New System.Windows.Forms.DataGridView()
        Me.cNomServei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUnitatServei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreuServei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMinutsUnitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cComuServei = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabPageInformes = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnInfHoresFetes = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSelClientInformes = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PlaniMonthViewFins = New PlaniSoftwareControlLibrary.PlaniMonthView()
        Me.PlaniMonthViewDesDe = New PlaniSoftwareControlLibrary.PlaniMonthView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LlocsClientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Recursos_ComponentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DragCursor = New gCursorLib.gCursor(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ClientsTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ClientsTableAdapter()
        Me.TableAdapterManager = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.TableAdapterManager()
        Me.Llocs_ServeisTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.Llocs_ServeisTableAdapter()
        Me.LlocsTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.LlocsTableAdapter()
        Me.Recursos_ComponentsTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.Recursos_ComponentsTableAdapter()
        Me.RecursosTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.RecursosTableAdapter()
        Me.ServeisTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ServeisTableAdapter()
        Me.XecsTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.XecsTableAdapter()
        Clients_nomLabel = New System.Windows.Forms.Label()
        Clients_NIFLabel = New System.Windows.Forms.Label()
        Clients_adreçaLabel = New System.Windows.Forms.Label()
        Clients_poblacioLabel = New System.Windows.Forms.Label()
        Clients_codi_postalLabel = New System.Windows.Forms.Label()
        Clients_telefonsLabel = New System.Windows.Forms.Label()
        Clients_data_altaLabel = New System.Windows.Forms.Label()
        Clients_xecsLabel = New System.Windows.Forms.Label()
        Clients_cccLabel = New System.Windows.Forms.Label()
        Clients_emailLabel = New System.Windows.Forms.Label()
        Clients_observacionsLabel = New System.Windows.Forms.Label()
        Llocs_nomLabel = New System.Windows.Forms.Label()
        Llocs_adreçaLabel = New System.Windows.Forms.Label()
        Llocs_poblacioLabel = New System.Windows.Forms.Label()
        Llocs_telefonLabel = New System.Windows.Forms.Label()
        Llocs_periodicitat_diesLabel = New System.Windows.Forms.Label()
        Llocs_dia_setmanaLabel = New System.Windows.Forms.Label()
        Llocs_horaLabel = New System.Windows.Forms.Label()
        Llocs_minuts_previstLabel = New System.Windows.Forms.Label()
        Recursos_nomLabel = New System.Windows.Forms.Label()
        Llocs_quotaLabel = New System.Windows.Forms.Label()
        Llocs_observacionsLabel = New System.Windows.Forms.Label()
        Xecs_idLabel = New System.Windows.Forms.Label()
        Xecs_data_entregaLabel = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Llocs_nomLabel1 = New System.Windows.Forms.Label()
        Serveis_nomLabel = New System.Windows.Forms.Label()
        Llocs_serveis_quantitatLabel = New System.Windows.Forms.Label()
        Llocs_serveis_preu_unLabel = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Xecs_valorLabel = New System.Windows.Forms.Label()
        Feines_idLabel = New System.Windows.Forms.Label()
        Xecs_data_liquidatLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPageAgenda.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.LlocsSelDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LlocsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlaniFeinesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecursosSelDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecursosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHoresExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageFacturacio.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvXecs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageClients.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.pnlClients.SuspendLayout()
        Me.pnlServeis.SuspendLayout()
        CType(Me.Llocs_ServeisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServeisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlXecs.SuspendLayout()
        CType(Me.XecsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLlocs.SuspendLayout()
        Me.TabPageRecursosIServeis.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.RecursosDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServeisDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageInformes.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LlocsClientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Recursos_ComponentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Clients_nomLabel
        '
        Clients_nomLabel.AutoSize = True
        Clients_nomLabel.Location = New System.Drawing.Point(60, 57)
        Clients_nomLabel.Name = "Clients_nomLabel"
        Clients_nomLabel.Size = New System.Drawing.Size(32, 13)
        Clients_nomLabel.TabIndex = 1
        Clients_nomLabel.Text = "Nom:"
        '
        'Clients_NIFLabel
        '
        Clients_NIFLabel.AutoSize = True
        Clients_NIFLabel.Location = New System.Drawing.Point(65, 83)
        Clients_NIFLabel.Name = "Clients_NIFLabel"
        Clients_NIFLabel.Size = New System.Drawing.Size(27, 13)
        Clients_NIFLabel.TabIndex = 3
        Clients_NIFLabel.Text = "NIF:"
        '
        'Clients_adreçaLabel
        '
        Clients_adreçaLabel.AutoSize = True
        Clients_adreçaLabel.Location = New System.Drawing.Point(48, 109)
        Clients_adreçaLabel.Name = "Clients_adreçaLabel"
        Clients_adreçaLabel.Size = New System.Drawing.Size(44, 13)
        Clients_adreçaLabel.TabIndex = 5
        Clients_adreçaLabel.Text = "Adreça:"
        '
        'Clients_poblacioLabel
        '
        Clients_poblacioLabel.AutoSize = True
        Clients_poblacioLabel.Location = New System.Drawing.Point(41, 135)
        Clients_poblacioLabel.Name = "Clients_poblacioLabel"
        Clients_poblacioLabel.Size = New System.Drawing.Size(51, 13)
        Clients_poblacioLabel.TabIndex = 7
        Clients_poblacioLabel.Text = "Població:"
        '
        'Clients_codi_postalLabel
        '
        Clients_codi_postalLabel.AutoSize = True
        Clients_codi_postalLabel.Location = New System.Drawing.Point(30, 161)
        Clients_codi_postalLabel.Name = "Clients_codi_postalLabel"
        Clients_codi_postalLabel.Size = New System.Drawing.Size(62, 13)
        Clients_codi_postalLabel.TabIndex = 9
        Clients_codi_postalLabel.Text = "Codi postal:"
        '
        'Clients_telefonsLabel
        '
        Clients_telefonsLabel.AutoSize = True
        Clients_telefonsLabel.Location = New System.Drawing.Point(41, 187)
        Clients_telefonsLabel.Name = "Clients_telefonsLabel"
        Clients_telefonsLabel.Size = New System.Drawing.Size(51, 13)
        Clients_telefonsLabel.TabIndex = 11
        Clients_telefonsLabel.Text = "Telèfons:"
        '
        'Clients_data_altaLabel
        '
        Clients_data_altaLabel.AutoSize = True
        Clients_data_altaLabel.Location = New System.Drawing.Point(63, 31)
        Clients_data_altaLabel.Name = "Clients_data_altaLabel"
        Clients_data_altaLabel.Size = New System.Drawing.Size(28, 13)
        Clients_data_altaLabel.TabIndex = 13
        Clients_data_altaLabel.Text = "Alta:"
        '
        'Clients_xecsLabel
        '
        Clients_xecsLabel.AutoSize = True
        Clients_xecsLabel.Location = New System.Drawing.Point(57, 214)
        Clients_xecsLabel.Name = "Clients_xecsLabel"
        Clients_xecsLabel.Size = New System.Drawing.Size(34, 13)
        Clients_xecsLabel.TabIndex = 15
        Clients_xecsLabel.Text = "Xecs:"
        '
        'Clients_cccLabel
        '
        Clients_cccLabel.AutoSize = True
        Clients_cccLabel.Location = New System.Drawing.Point(63, 242)
        Clients_cccLabel.Name = "Clients_cccLabel"
        Clients_cccLabel.Size = New System.Drawing.Size(28, 13)
        Clients_cccLabel.TabIndex = 17
        Clients_cccLabel.Text = "ccc:"
        '
        'Clients_emailLabel
        '
        Clients_emailLabel.AutoSize = True
        Clients_emailLabel.Location = New System.Drawing.Point(54, 270)
        Clients_emailLabel.Name = "Clients_emailLabel"
        Clients_emailLabel.Size = New System.Drawing.Size(37, 13)
        Clients_emailLabel.TabIndex = 19
        Clients_emailLabel.Text = "e-mail:"
        '
        'Clients_observacionsLabel
        '
        Clients_observacionsLabel.AutoSize = True
        Clients_observacionsLabel.Location = New System.Drawing.Point(17, 299)
        Clients_observacionsLabel.Name = "Clients_observacionsLabel"
        Clients_observacionsLabel.Size = New System.Drawing.Size(75, 13)
        Clients_observacionsLabel.TabIndex = 21
        Clients_observacionsLabel.Text = "Observacions:"
        '
        'Llocs_nomLabel
        '
        Llocs_nomLabel.AutoSize = True
        Llocs_nomLabel.Location = New System.Drawing.Point(56, 54)
        Llocs_nomLabel.Name = "Llocs_nomLabel"
        Llocs_nomLabel.Size = New System.Drawing.Size(32, 13)
        Llocs_nomLabel.TabIndex = 1
        Llocs_nomLabel.Text = "Nom:"
        '
        'Llocs_adreçaLabel
        '
        Llocs_adreçaLabel.AutoSize = True
        Llocs_adreçaLabel.Location = New System.Drawing.Point(44, 79)
        Llocs_adreçaLabel.Name = "Llocs_adreçaLabel"
        Llocs_adreçaLabel.Size = New System.Drawing.Size(44, 13)
        Llocs_adreçaLabel.TabIndex = 3
        Llocs_adreçaLabel.Text = "Adreça:"
        '
        'Llocs_poblacioLabel
        '
        Llocs_poblacioLabel.AutoSize = True
        Llocs_poblacioLabel.Location = New System.Drawing.Point(37, 105)
        Llocs_poblacioLabel.Name = "Llocs_poblacioLabel"
        Llocs_poblacioLabel.Size = New System.Drawing.Size(51, 13)
        Llocs_poblacioLabel.TabIndex = 5
        Llocs_poblacioLabel.Text = "Població:"
        '
        'Llocs_telefonLabel
        '
        Llocs_telefonLabel.AutoSize = True
        Llocs_telefonLabel.Location = New System.Drawing.Point(41, 131)
        Llocs_telefonLabel.Name = "Llocs_telefonLabel"
        Llocs_telefonLabel.Size = New System.Drawing.Size(46, 13)
        Llocs_telefonLabel.TabIndex = 7
        Llocs_telefonLabel.Text = "Telèfon:"
        '
        'Llocs_periodicitat_diesLabel
        '
        Llocs_periodicitat_diesLabel.AutoSize = True
        Llocs_periodicitat_diesLabel.Location = New System.Drawing.Point(8, 167)
        Llocs_periodicitat_diesLabel.Name = "Llocs_periodicitat_diesLabel"
        Llocs_periodicitat_diesLabel.Size = New System.Drawing.Size(80, 13)
        Llocs_periodicitat_diesLabel.TabIndex = 9
        Llocs_periodicitat_diesLabel.Text = "Planificar cada:"
        '
        'Llocs_dia_setmanaLabel
        '
        Llocs_dia_setmanaLabel.AutoSize = True
        Llocs_dia_setmanaLabel.Location = New System.Drawing.Point(19, 250)
        Llocs_dia_setmanaLabel.Name = "Llocs_dia_setmanaLabel"
        Llocs_dia_setmanaLabel.Size = New System.Drawing.Size(69, 13)
        Llocs_dia_setmanaLabel.TabIndex = 16
        Llocs_dia_setmanaLabel.Text = "Planificar els:"
        '
        'Llocs_horaLabel
        '
        Llocs_horaLabel.AutoSize = True
        Llocs_horaLabel.Location = New System.Drawing.Point(209, 250)
        Llocs_horaLabel.Name = "Llocs_horaLabel"
        Llocs_horaLabel.Size = New System.Drawing.Size(32, 13)
        Llocs_horaLabel.TabIndex = 19
        Llocs_horaLabel.Text = "a les:"
        '
        'Llocs_minuts_previstLabel
        '
        Llocs_minuts_previstLabel.AutoSize = True
        Llocs_minuts_previstLabel.Location = New System.Drawing.Point(13, 279)
        Llocs_minuts_previstLabel.Name = "Llocs_minuts_previstLabel"
        Llocs_minuts_previstLabel.Size = New System.Drawing.Size(75, 13)
        Llocs_minuts_previstLabel.TabIndex = 21
        Llocs_minuts_previstLabel.Text = "Minuts previst:"
        '
        'Recursos_nomLabel
        '
        Recursos_nomLabel.AutoSize = True
        Recursos_nomLabel.Location = New System.Drawing.Point(42, 306)
        Recursos_nomLabel.Name = "Recursos_nomLabel"
        Recursos_nomLabel.Size = New System.Drawing.Size(44, 13)
        Recursos_nomLabel.TabIndex = 23
        Recursos_nomLabel.Text = "Recurs:"
        '
        'Llocs_quotaLabel
        '
        Llocs_quotaLabel.AutoSize = True
        Llocs_quotaLabel.Location = New System.Drawing.Point(6, 343)
        Llocs_quotaLabel.Name = "Llocs_quotaLabel"
        Llocs_quotaLabel.Size = New System.Drawing.Size(81, 13)
        Llocs_quotaLabel.TabIndex = 25
        Llocs_quotaLabel.Text = "Quota mensual:"
        '
        'Llocs_observacionsLabel
        '
        Llocs_observacionsLabel.AutoSize = True
        Llocs_observacionsLabel.Location = New System.Drawing.Point(12, 373)
        Llocs_observacionsLabel.Name = "Llocs_observacionsLabel"
        Llocs_observacionsLabel.Size = New System.Drawing.Size(75, 13)
        Llocs_observacionsLabel.TabIndex = 27
        Llocs_observacionsLabel.Text = "Observacions:"
        '
        'Xecs_idLabel
        '
        Xecs_idLabel.AutoSize = True
        Xecs_idLabel.Location = New System.Drawing.Point(26, 53)
        Xecs_idLabel.Name = "Xecs_idLabel"
        Xecs_idLabel.Size = New System.Drawing.Size(65, 13)
        Xecs_idLabel.TabIndex = 1
        Xecs_idLabel.Text = "Nro. de xec:"
        '
        'Xecs_data_entregaLabel
        '
        Xecs_data_entregaLabel.AutoSize = True
        Xecs_data_entregaLabel.Location = New System.Drawing.Point(11, 79)
        Xecs_data_entregaLabel.Name = "Xecs_data_entregaLabel"
        Xecs_data_entregaLabel.Size = New System.Drawing.Size(80, 13)
        Xecs_data_entregaLabel.TabIndex = 4
        Xecs_data_entregaLabel.Text = "Data d'entrega:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(50, 28)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(36, 13)
        Label7.TabIndex = 33
        Label7.Text = "Client:"
        '
        'Llocs_nomLabel1
        '
        Llocs_nomLabel1.AutoSize = True
        Llocs_nomLabel1.Location = New System.Drawing.Point(46, 30)
        Llocs_nomLabel1.Name = "Llocs_nomLabel1"
        Llocs_nomLabel1.Size = New System.Drawing.Size(30, 13)
        Llocs_nomLabel1.TabIndex = 1
        Llocs_nomLabel1.Text = "Lloc:"
        '
        'Serveis_nomLabel
        '
        Serveis_nomLabel.AutoSize = True
        Serveis_nomLabel.Location = New System.Drawing.Point(36, 59)
        Serveis_nomLabel.Name = "Serveis_nomLabel"
        Serveis_nomLabel.Size = New System.Drawing.Size(40, 13)
        Serveis_nomLabel.TabIndex = 3
        Serveis_nomLabel.Text = "Servei:"
        '
        'Llocs_serveis_quantitatLabel
        '
        Llocs_serveis_quantitatLabel.AutoSize = True
        Llocs_serveis_quantitatLabel.Location = New System.Drawing.Point(23, 91)
        Llocs_serveis_quantitatLabel.Name = "Llocs_serveis_quantitatLabel"
        Llocs_serveis_quantitatLabel.Size = New System.Drawing.Size(53, 13)
        Llocs_serveis_quantitatLabel.TabIndex = 5
        Llocs_serveis_quantitatLabel.Text = "Quantitat:"
        '
        'Llocs_serveis_preu_unLabel
        '
        Llocs_serveis_preu_unLabel.AutoSize = True
        Llocs_serveis_preu_unLabel.Location = New System.Drawing.Point(13, 122)
        Llocs_serveis_preu_unLabel.Name = "Llocs_serveis_preu_unLabel"
        Llocs_serveis_preu_unLabel.Size = New System.Drawing.Size(63, 13)
        Llocs_serveis_preu_unLabel.TabIndex = 8
        Llocs_serveis_preu_unLabel.Text = "Preu unitari:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(55, 27)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(36, 13)
        Label9.TabIndex = 6
        Label9.Text = "Client:"
        '
        'Xecs_valorLabel
        '
        Xecs_valorLabel.AutoSize = True
        Xecs_valorLabel.Location = New System.Drawing.Point(57, 108)
        Xecs_valorLabel.Name = "Xecs_valorLabel"
        Xecs_valorLabel.Size = New System.Drawing.Size(34, 13)
        Xecs_valorLabel.TabIndex = 7
        Xecs_valorLabel.Text = "Valor:"
        '
        'Feines_idLabel
        '
        Feines_idLabel.AutoSize = True
        Feines_idLabel.Location = New System.Drawing.Point(4, 134)
        Feines_idLabel.Name = "Feines_idLabel"
        Feines_idLabel.Size = New System.Drawing.Size(87, 13)
        Feines_idLabel.TabIndex = 9
        Feines_idLabel.Text = "Feina assignada:"
        '
        'Xecs_data_liquidatLabel
        '
        Xecs_data_liquidatLabel.AutoSize = True
        Xecs_data_liquidatLabel.Location = New System.Drawing.Point(22, 162)
        Xecs_data_liquidatLabel.Name = "Xecs_data_liquidatLabel"
        Xecs_data_liquidatLabel.Size = New System.Drawing.Size(69, 13)
        Xecs_data_liquidatLabel.TabIndex = 11
        Xecs_data_liquidatLabel.Text = "Data liquidat:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageAgenda)
        Me.TabControl1.Controls.Add(Me.TabPageFacturacio)
        Me.TabControl1.Controls.Add(Me.TabPageClients)
        Me.TabControl1.Controls.Add(Me.TabPageRecursosIServeis)
        Me.TabControl1.Controls.Add(Me.TabPageInformes)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(771, 529)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageAgenda
        '
        Me.TabPageAgenda.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageAgenda.Controls.Add(Me.SplitContainer1)
        Me.TabPageAgenda.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAgenda.Name = "TabPageAgenda"
        Me.TabPageAgenda.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAgenda.Size = New System.Drawing.Size(763, 503)
        Me.TabPageAgenda.TabIndex = 0
        Me.TabPageAgenda.Text = "Agenda"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Panel1MinSize = 240
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.AgendaGrid)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvHoresExtra)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Panel2MinSize = 100
        Me.SplitContainer1.Size = New System.Drawing.Size(757, 497)
        Me.SplitContainer1.SplitterDistance = 242
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 4
        Me.SplitContainer1.TabStop = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.LlocsSelDataGridView)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Calendari)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Panel1MinSize = 200
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.RecursosSelDataGridView)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtNumFeina)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label19)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnImprimirAgenda)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Panel2MinSize = 50
        Me.SplitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Size = New System.Drawing.Size(242, 497)
        Me.SplitContainer2.SplitterDistance = 323
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 0
        Me.SplitContainer2.TabStop = False
        '
        'LlocsSelDataGridView
        '
        Me.LlocsSelDataGridView.AllowUserToAddRows = False
        Me.LlocsSelDataGridView.AllowUserToDeleteRows = False
        Me.LlocsSelDataGridView.AllowUserToResizeColumns = False
        Me.LlocsSelDataGridView.AllowUserToResizeRows = False
        Me.LlocsSelDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LlocsSelDataGridView.AutoGenerateColumns = False
        Me.LlocsSelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LlocsSelDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LlocsSelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LlocsSelDataGridView.ColumnHeadersVisible = False
        Me.LlocsSelDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.llocs_nom, Me.clients_nom, Me.llocs_adreça, Me.llocs_poblacio, Me.llocs_telefon, Me.llocs_minuts_previst, Me.llocs_periodicitat_dies, Me.llocs_dia_setmana, Me.llocs_dissabte, Me.llocs_diumenge, Me.llocs_hora, Me.llocs_recursos_nom, Me.llocs_observacions, Me.llocs_quota, Me.llocs_primer_dia_mes, Me.llocs_ultim_dia_mes})
        Me.LlocsSelDataGridView.DataSource = Me.LlocsBindingSource
        Me.LlocsSelDataGridView.Location = New System.Drawing.Point(3, 172)
        Me.LlocsSelDataGridView.MultiSelect = False
        Me.LlocsSelDataGridView.Name = "LlocsSelDataGridView"
        Me.LlocsSelDataGridView.ReadOnly = True
        Me.LlocsSelDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LlocsSelDataGridView.RowHeadersVisible = False
        Me.LlocsSelDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LlocsSelDataGridView.Size = New System.Drawing.Size(232, 144)
        Me.LlocsSelDataGridView.TabIndex = 6
        '
        'llocs_nom
        '
        Me.llocs_nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.llocs_nom.DataPropertyName = "llocs_nom"
        Me.llocs_nom.HeaderText = "llocs_nom"
        Me.llocs_nom.Name = "llocs_nom"
        Me.llocs_nom.ReadOnly = True
        '
        'clients_nom
        '
        Me.clients_nom.DataPropertyName = "clients_nom"
        Me.clients_nom.HeaderText = "clients_nom"
        Me.clients_nom.Name = "clients_nom"
        Me.clients_nom.ReadOnly = True
        Me.clients_nom.Visible = False
        '
        'llocs_adreça
        '
        Me.llocs_adreça.DataPropertyName = "llocs_adreça"
        Me.llocs_adreça.HeaderText = "llocs_adreça"
        Me.llocs_adreça.Name = "llocs_adreça"
        Me.llocs_adreça.ReadOnly = True
        Me.llocs_adreça.Visible = False
        '
        'llocs_poblacio
        '
        Me.llocs_poblacio.DataPropertyName = "llocs_poblacio"
        Me.llocs_poblacio.HeaderText = "llocs_poblacio"
        Me.llocs_poblacio.Name = "llocs_poblacio"
        Me.llocs_poblacio.ReadOnly = True
        Me.llocs_poblacio.Visible = False
        '
        'llocs_telefon
        '
        Me.llocs_telefon.DataPropertyName = "llocs_telefon"
        Me.llocs_telefon.HeaderText = "llocs_telefon"
        Me.llocs_telefon.Name = "llocs_telefon"
        Me.llocs_telefon.ReadOnly = True
        Me.llocs_telefon.Visible = False
        '
        'llocs_minuts_previst
        '
        Me.llocs_minuts_previst.DataPropertyName = "llocs_minuts_previst"
        Me.llocs_minuts_previst.HeaderText = "llocs_minuts_previst"
        Me.llocs_minuts_previst.Name = "llocs_minuts_previst"
        Me.llocs_minuts_previst.ReadOnly = True
        Me.llocs_minuts_previst.Visible = False
        '
        'llocs_periodicitat_dies
        '
        Me.llocs_periodicitat_dies.DataPropertyName = "llocs_periodicitat_dies"
        Me.llocs_periodicitat_dies.HeaderText = "llocs_periodicitat_dies"
        Me.llocs_periodicitat_dies.Name = "llocs_periodicitat_dies"
        Me.llocs_periodicitat_dies.ReadOnly = True
        Me.llocs_periodicitat_dies.Visible = False
        '
        'llocs_dia_setmana
        '
        Me.llocs_dia_setmana.DataPropertyName = "llocs_dia_setmana"
        Me.llocs_dia_setmana.HeaderText = "llocs_dia_setmana"
        Me.llocs_dia_setmana.Name = "llocs_dia_setmana"
        Me.llocs_dia_setmana.ReadOnly = True
        Me.llocs_dia_setmana.Visible = False
        '
        'llocs_dissabte
        '
        Me.llocs_dissabte.DataPropertyName = "llocs_dissabte"
        Me.llocs_dissabte.HeaderText = "llocs_dissabte"
        Me.llocs_dissabte.Name = "llocs_dissabte"
        Me.llocs_dissabte.ReadOnly = True
        Me.llocs_dissabte.Visible = False
        '
        'llocs_diumenge
        '
        Me.llocs_diumenge.DataPropertyName = "llocs_diumenge"
        Me.llocs_diumenge.HeaderText = "llocs_diumenge"
        Me.llocs_diumenge.Name = "llocs_diumenge"
        Me.llocs_diumenge.ReadOnly = True
        Me.llocs_diumenge.Visible = False
        '
        'llocs_hora
        '
        Me.llocs_hora.DataPropertyName = "llocs_hora"
        Me.llocs_hora.HeaderText = "llocs_hora"
        Me.llocs_hora.Name = "llocs_hora"
        Me.llocs_hora.ReadOnly = True
        Me.llocs_hora.Visible = False
        '
        'llocs_recursos_nom
        '
        Me.llocs_recursos_nom.DataPropertyName = "recursos_nom"
        Me.llocs_recursos_nom.HeaderText = "recursos_nom"
        Me.llocs_recursos_nom.Name = "llocs_recursos_nom"
        Me.llocs_recursos_nom.ReadOnly = True
        Me.llocs_recursos_nom.Visible = False
        '
        'llocs_observacions
        '
        Me.llocs_observacions.DataPropertyName = "llocs_observacions"
        Me.llocs_observacions.HeaderText = "llocs_observacions"
        Me.llocs_observacions.Name = "llocs_observacions"
        Me.llocs_observacions.ReadOnly = True
        Me.llocs_observacions.Visible = False
        '
        'llocs_quota
        '
        Me.llocs_quota.DataPropertyName = "llocs_quota"
        Me.llocs_quota.HeaderText = "llocs_quota"
        Me.llocs_quota.Name = "llocs_quota"
        Me.llocs_quota.ReadOnly = True
        Me.llocs_quota.Visible = False
        '
        'llocs_primer_dia_mes
        '
        Me.llocs_primer_dia_mes.DataPropertyName = "llocs_primer_dia_mes"
        Me.llocs_primer_dia_mes.HeaderText = "llocs_primer_dia_mes"
        Me.llocs_primer_dia_mes.Name = "llocs_primer_dia_mes"
        Me.llocs_primer_dia_mes.ReadOnly = True
        Me.llocs_primer_dia_mes.Visible = False
        '
        'llocs_ultim_dia_mes
        '
        Me.llocs_ultim_dia_mes.DataPropertyName = "llocs_ultim_dia_mes"
        Me.llocs_ultim_dia_mes.HeaderText = "llocs_ultim_dia_mes"
        Me.llocs_ultim_dia_mes.Name = "llocs_ultim_dia_mes"
        Me.llocs_ultim_dia_mes.ReadOnly = True
        Me.llocs_ultim_dia_mes.Visible = False
        '
        'LlocsBindingSource
        '
        Me.LlocsBindingSource.DataMember = "Llocs"
        Me.LlocsBindingSource.DataSource = Me.PlaniFeinesDataSet
        '
        'PlaniFeinesDataSet
        '
        Me.PlaniFeinesDataSet.DataSetName = "PlaniFeinesDataSet"
        Me.PlaniFeinesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Calendari
        '
        Me.Calendari.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Calendari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Calendari.GridBackColor = System.Drawing.SystemColors.Window
        Me.Calendari.Language = PlaniSoftwareControlLibrary.PlaniMonthView.Idiom.Català
        Me.Calendari.Location = New System.Drawing.Point(2, 2)
        Me.Calendari.Margin = New System.Windows.Forms.Padding(2)
        Me.Calendari.MaximumSize = New System.Drawing.Size(234, 150)
        Me.Calendari.MinimumSize = New System.Drawing.Size(234, 150)
        Me.Calendari.Name = "Calendari"
        Me.Calendari.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Calendari.SelectedDate = New Date(2019, 4, 14, 0, 0, 0, 0)
        Me.Calendari.Size = New System.Drawing.Size(234, 150)
        Me.Calendari.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 156)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Llocs"
        '
        'RecursosSelDataGridView
        '
        Me.RecursosSelDataGridView.AllowUserToAddRows = False
        Me.RecursosSelDataGridView.AllowUserToDeleteRows = False
        Me.RecursosSelDataGridView.AllowUserToResizeColumns = False
        Me.RecursosSelDataGridView.AllowUserToResizeRows = False
        Me.RecursosSelDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RecursosSelDataGridView.AutoGenerateColumns = False
        Me.RecursosSelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.RecursosSelDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RecursosSelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RecursosSelDataGridView.ColumnHeadersVisible = False
        Me.RecursosSelDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.recursos_nom, Me.recursos_grup, Me.recursos_color})
        Me.RecursosSelDataGridView.DataSource = Me.RecursosBindingSource
        Me.RecursosSelDataGridView.Location = New System.Drawing.Point(3, 18)
        Me.RecursosSelDataGridView.Margin = New System.Windows.Forms.Padding(2)
        Me.RecursosSelDataGridView.MultiSelect = False
        Me.RecursosSelDataGridView.Name = "RecursosSelDataGridView"
        Me.RecursosSelDataGridView.ReadOnly = True
        Me.RecursosSelDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RecursosSelDataGridView.RowHeadersVisible = False
        Me.RecursosSelDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RecursosSelDataGridView.Size = New System.Drawing.Size(232, 119)
        Me.RecursosSelDataGridView.TabIndex = 7
        '
        'recursos_nom
        '
        Me.recursos_nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.recursos_nom.DataPropertyName = "recursos_nom"
        Me.recursos_nom.HeaderText = "recursos_nom"
        Me.recursos_nom.Name = "recursos_nom"
        Me.recursos_nom.ReadOnly = True
        Me.recursos_nom.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'recursos_grup
        '
        Me.recursos_grup.DataPropertyName = "recursos_grup"
        Me.recursos_grup.HeaderText = "recursos_grup"
        Me.recursos_grup.Name = "recursos_grup"
        Me.recursos_grup.ReadOnly = True
        Me.recursos_grup.Visible = False
        '
        'recursos_color
        '
        Me.recursos_color.DataPropertyName = "recursos_color"
        Me.recursos_color.HeaderText = "recursos_color"
        Me.recursos_color.Name = "recursos_color"
        Me.recursos_color.ReadOnly = True
        Me.recursos_color.Visible = False
        '
        'RecursosBindingSource
        '
        Me.RecursosBindingSource.DataMember = "Recursos"
        Me.RecursosBindingSource.DataSource = Me.PlaniFeinesDataSet
        Me.RecursosBindingSource.Sort = "recursos_nom"
        '
        'txtNumFeina
        '
        Me.txtNumFeina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNumFeina.Location = New System.Drawing.Point(74, 144)
        Me.txtNumFeina.MaxLength = 10
        Me.txtNumFeina.Name = "txtNumFeina"
        Me.txtNumFeina.Size = New System.Drawing.Size(60, 20)
        Me.txtNumFeina.TabIndex = 8
        Me.txtNumFeina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "# Veure feina"
        '
        'btnImprimirAgenda
        '
        Me.btnImprimirAgenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirAgenda.Location = New System.Drawing.Point(139, 142)
        Me.btnImprimirAgenda.Name = "btnImprimirAgenda"
        Me.btnImprimirAgenda.Size = New System.Drawing.Size(96, 23)
        Me.btnImprimirAgenda.TabIndex = 9
        Me.btnImprimirAgenda.Text = "Imprimir Agenda"
        Me.btnImprimirAgenda.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Recursos"
        '
        'AgendaGrid
        '
        Me.AgendaGrid.AllowMultiDayElements = False
        Me.AgendaGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AgendaGrid.BackColor = System.Drawing.SystemColors.ControlDark
        Me.AgendaGrid.DisplayDate = New Date(2019, 4, 14, 0, 0, 0, 0)
        Me.AgendaGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.AgendaGrid.EndTimeOfDay = "24:00"
        Me.AgendaGrid.ExtResourceOverlap = True
        Me.AgendaGrid.GridBackColor = System.Drawing.SystemColors.Window
        Me.AgendaGrid.HeaderBackColor = System.Drawing.SystemColors.ControlDark
        Me.AgendaGrid.HeaderFontColor = System.Drawing.SystemColors.Window
        Me.AgendaGrid.HLinesColor = System.Drawing.SystemColors.Control
        Me.AgendaGrid.Language = PlaniSoftwareControlLibrary.PlaniGrid.PGIdioma.Català
        Me.AgendaGrid.LastWorkingDayOfWeek = System.DayOfWeek.Saturday
        Me.AgendaGrid.Location = New System.Drawing.Point(0, 0)
        Me.AgendaGrid.LunchTimeEnd = "15:00"
        Me.AgendaGrid.LunchTimeStart = "13:00"
        Me.AgendaGrid.MarkDoneElements = PlaniSoftwareControlLibrary.PlaniGrid.PGVistaFetes.Underline
        Me.AgendaGrid.MinColsWidth = 100
        Me.AgendaGrid.MinRowsHeight = 13
        Me.AgendaGrid.MinutesGap = 30
        Me.AgendaGrid.Name = "AgendaGrid"
        Me.AgendaGrid.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.AgendaGrid.Size = New System.Drawing.Size(508, 463)
        Me.AgendaGrid.SnapToGrid = True
        Me.AgendaGrid.StartTimeOfDay = "00:00"
        Me.AgendaGrid.TabIndex = 4
        Me.AgendaGrid.VisualizationMode = PlaniSoftwareControlLibrary.PlaniGrid.PGMode.Month
        Me.AgendaGrid.VLinesColor = System.Drawing.SystemColors.ButtonShadow
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 476)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "extra"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(1, 463)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Hores"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvHoresExtra
        '
        Me.dgvHoresExtra.AllowUserToAddRows = False
        Me.dgvHoresExtra.AllowUserToDeleteRows = False
        Me.dgvHoresExtra.AllowUserToOrderColumns = True
        Me.dgvHoresExtra.AllowUserToResizeColumns = False
        Me.dgvHoresExtra.AllowUserToResizeRows = False
        Me.dgvHoresExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHoresExtra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvHoresExtra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHoresExtra.ColumnHeadersVisible = False
        Me.dgvHoresExtra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        DataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle70.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle70.Format = "N2"
        DataGridViewCellStyle70.NullValue = "0"
        DataGridViewCellStyle70.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle70.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHoresExtra.DefaultCellStyle = DataGridViewCellStyle70
        Me.dgvHoresExtra.Location = New System.Drawing.Point(36, 467)
        Me.dgvHoresExtra.MultiSelect = False
        Me.dgvHoresExtra.Name = "dgvHoresExtra"
        Me.dgvHoresExtra.RowHeadersVisible = False
        Me.dgvHoresExtra.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvHoresExtra.RowTemplate.DefaultCellStyle.Format = "N2"
        Me.dgvHoresExtra.RowTemplate.DefaultCellStyle.NullValue = "0"
        Me.dgvHoresExtra.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvHoresExtra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvHoresExtra.ShowEditingIcon = False
        Me.dgvHoresExtra.ShowRowErrors = False
        Me.dgvHoresExtra.Size = New System.Drawing.Size(488, 22)
        Me.dgvHoresExtra.StandardTab = True
        Me.dgvHoresExtra.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        '
        'TabPageFacturacio
        '
        Me.TabPageFacturacio.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageFacturacio.Controls.Add(Me.btnImprimirHoresTotals)
        Me.TabPageFacturacio.Controls.Add(Me.btnImprimirFacturacio)
        Me.TabPageFacturacio.Controls.Add(Me.btnImprimirXecs)
        Me.TabPageFacturacio.Controls.Add(Me.btnImprimirHores)
        Me.TabPageFacturacio.Controls.Add(Me.txtTotalFacturar)
        Me.TabPageFacturacio.Controls.Add(Me.Label24)
        Me.TabPageFacturacio.Controls.Add(Me.SplitContainer4)
        Me.TabPageFacturacio.Controls.Add(Me.txtPagaments)
        Me.TabPageFacturacio.Controls.Add(Me.chkPdtFacturar)
        Me.TabPageFacturacio.Controls.Add(Me.Label15)
        Me.TabPageFacturacio.Controls.Add(Me.cmbSelClients)
        Me.TabPageFacturacio.Controls.Add(Me.Label14)
        Me.TabPageFacturacio.Controls.Add(Me.Label13)
        Me.TabPageFacturacio.Controls.Add(Me.dtpSelMes)
        Me.TabPageFacturacio.Location = New System.Drawing.Point(4, 22)
        Me.TabPageFacturacio.Name = "TabPageFacturacio"
        Me.TabPageFacturacio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageFacturacio.Size = New System.Drawing.Size(763, 503)
        Me.TabPageFacturacio.TabIndex = 1
        Me.TabPageFacturacio.Text = "Facturació"
        '
        'btnImprimirHoresTotals
        '
        Me.btnImprimirHoresTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirHoresTotals.Location = New System.Drawing.Point(123, 473)
        Me.btnImprimirHoresTotals.Name = "btnImprimirHoresTotals"
        Me.btnImprimirHoresTotals.Size = New System.Drawing.Size(115, 23)
        Me.btnImprimirHoresTotals.TabIndex = 15
        Me.btnImprimirHoresTotals.Text = "Imprimir hores total"
        Me.btnImprimirHoresTotals.UseVisualStyleBackColor = True
        '
        'btnImprimirFacturacio
        '
        Me.btnImprimirFacturacio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirFacturacio.Location = New System.Drawing.Point(394, 473)
        Me.btnImprimirFacturacio.Name = "btnImprimirFacturacio"
        Me.btnImprimirFacturacio.Size = New System.Drawing.Size(115, 23)
        Me.btnImprimirFacturacio.TabIndex = 17
        Me.btnImprimirFacturacio.Text = "Imprimir dades facturació"
        Me.btnImprimirFacturacio.UseVisualStyleBackColor = True
        '
        'btnImprimirXecs
        '
        Me.btnImprimirXecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirXecs.Location = New System.Drawing.Point(244, 473)
        Me.btnImprimirXecs.Name = "btnImprimirXecs"
        Me.btnImprimirXecs.Size = New System.Drawing.Size(115, 23)
        Me.btnImprimirXecs.TabIndex = 16
        Me.btnImprimirXecs.Text = "Imprimir xecs liquidats"
        Me.btnImprimirXecs.UseVisualStyleBackColor = True
        '
        'btnImprimirHores
        '
        Me.btnImprimirHores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirHores.Location = New System.Drawing.Point(5, 473)
        Me.btnImprimirHores.Name = "btnImprimirHores"
        Me.btnImprimirHores.Size = New System.Drawing.Size(115, 23)
        Me.btnImprimirHores.TabIndex = 14
        Me.btnImprimirHores.Text = "Imprimir hores extra"
        Me.btnImprimirHores.UseVisualStyleBackColor = True
        '
        'txtTotalFacturar
        '
        Me.txtTotalFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFacturar.Location = New System.Drawing.Point(664, 475)
        Me.txtTotalFacturar.MaxLength = 10
        Me.txtTotalFacturar.Name = "txtTotalFacturar"
        Me.txtTotalFacturar.ReadOnly = True
        Me.txtTotalFacturar.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalFacturar.TabIndex = 12
        Me.txtTotalFacturar.Text = "0,00"
        Me.txtTotalFacturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(542, 478)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 13)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Total a facturar:"
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer4.Location = New System.Drawing.Point(5, 33)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtTotalHores)
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtTotalServeis)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer4.Panel1.Controls.Add(Me.dgvFactura)
        Me.SplitContainer4.Panel1MinSize = 100
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.txtTotalNXecs)
        Me.SplitContainer4.Panel2.Controls.Add(Me.txtTotalXecs)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label22)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label18)
        Me.SplitContainer4.Panel2.Controls.Add(Me.dgvXecs)
        Me.SplitContainer4.Panel2MinSize = 100
        Me.SplitContainer4.Size = New System.Drawing.Size(755, 433)
        Me.SplitContainer4.SplitterDistance = 270
        Me.SplitContainer4.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(609, 246)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Hores"
        '
        'txtTotalHores
        '
        Me.txtTotalHores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalHores.Location = New System.Drawing.Point(538, 243)
        Me.txtTotalHores.MaxLength = 10
        Me.txtTotalHores.Name = "txtTotalHores"
        Me.txtTotalHores.ReadOnly = True
        Me.txtTotalHores.Size = New System.Drawing.Size(65, 20)
        Me.txtTotalHores.TabIndex = 10
        Me.txtTotalHores.Text = "0,00"
        Me.txtTotalHores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalServeis
        '
        Me.txtTotalServeis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalServeis.Location = New System.Drawing.Point(657, 243)
        Me.txtTotalServeis.MaxLength = 10
        Me.txtTotalServeis.Name = "txtTotalServeis"
        Me.txtTotalServeis.ReadOnly = True
        Me.txtTotalServeis.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalServeis.TabIndex = 9
        Me.txtTotalServeis.Text = "0,00"
        Me.txtTotalServeis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(418, 246)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Total serveis realitzats:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Serveis:"
        '
        'dgvFactura
        '
        Me.dgvFactura.AllowUserToAddRows = False
        Me.dgvFactura.AllowUserToDeleteRows = False
        Me.dgvFactura.AllowUserToResizeRows = False
        Me.dgvFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle71.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle71.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle71.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle71.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle71
        Me.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Feina, Me.Quota, Me.Data, Me.Lloc, Me.Recurs, Me.Feta, Me.DataFra, Me.Servei, Me.Quantitat, Me.Unitat, Me.ImportServei, Me.Observacions})
        Me.dgvFactura.Location = New System.Drawing.Point(3, 16)
        Me.dgvFactura.MultiSelect = False
        Me.dgvFactura.Name = "dgvFactura"
        Me.dgvFactura.ReadOnly = True
        Me.dgvFactura.RowHeadersVisible = False
        Me.dgvFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFactura.Size = New System.Drawing.Size(745, 221)
        Me.dgvFactura.TabIndex = 0
        '
        'Feina
        '
        Me.Feina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Feina.DefaultCellStyle = DataGridViewCellStyle72
        Me.Feina.HeaderText = "Feina"
        Me.Feina.MinimumWidth = 60
        Me.Feina.Name = "Feina"
        Me.Feina.ReadOnly = True
        Me.Feina.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Feina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Feina.Width = 60
        '
        'Quota
        '
        Me.Quota.HeaderText = "Quota"
        Me.Quota.Name = "Quota"
        Me.Quota.ReadOnly = True
        Me.Quota.Visible = False
        '
        'Data
        '
        Me.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle73.Format = "d"
        Me.Data.DefaultCellStyle = DataGridViewCellStyle73
        Me.Data.FillWeight = 48.39608!
        Me.Data.HeaderText = "Data"
        Me.Data.MinimumWidth = 80
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Data.Width = 80
        '
        'Lloc
        '
        Me.Lloc.FillWeight = 433.0371!
        Me.Lloc.HeaderText = "Lloc"
        Me.Lloc.MinimumWidth = 80
        Me.Lloc.Name = "Lloc"
        Me.Lloc.ReadOnly = True
        Me.Lloc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Recurs
        '
        Me.Recurs.FillWeight = 8.84741!
        Me.Recurs.HeaderText = "Recurs"
        Me.Recurs.MinimumWidth = 120
        Me.Recurs.Name = "Recurs"
        Me.Recurs.ReadOnly = True
        Me.Recurs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Feta
        '
        Me.Feta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Feta.DefaultCellStyle = DataGridViewCellStyle74
        Me.Feta.FillWeight = 8.84741!
        Me.Feta.HeaderText = "Feta"
        Me.Feta.MinimumWidth = 40
        Me.Feta.Name = "Feta"
        Me.Feta.ReadOnly = True
        Me.Feta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Feta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Feta.Width = 40
        '
        'DataFra
        '
        Me.DataFra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle75.Format = "d"
        Me.DataFra.DefaultCellStyle = DataGridViewCellStyle75
        Me.DataFra.FillWeight = 8.84741!
        Me.DataFra.HeaderText = "Data fra."
        Me.DataFra.MinimumWidth = 80
        Me.DataFra.Name = "DataFra"
        Me.DataFra.ReadOnly = True
        Me.DataFra.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataFra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataFra.Width = 80
        '
        'Servei
        '
        Me.Servei.FillWeight = 8.84741!
        Me.Servei.HeaderText = "Servei"
        Me.Servei.MinimumWidth = 80
        Me.Servei.Name = "Servei"
        Me.Servei.ReadOnly = True
        Me.Servei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Quantitat
        '
        Me.Quantitat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle76.Format = "N"
        Me.Quantitat.DefaultCellStyle = DataGridViewCellStyle76
        Me.Quantitat.FillWeight = 8.84741!
        Me.Quantitat.HeaderText = "Quantitat"
        Me.Quantitat.MinimumWidth = 60
        Me.Quantitat.Name = "Quantitat"
        Me.Quantitat.ReadOnly = True
        Me.Quantitat.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Quantitat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Quantitat.Width = 60
        '
        'Unitat
        '
        Me.Unitat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Unitat.FillWeight = 8.84741!
        Me.Unitat.HeaderText = "Unitat"
        Me.Unitat.MinimumWidth = 60
        Me.Unitat.Name = "Unitat"
        Me.Unitat.ReadOnly = True
        Me.Unitat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Unitat.Width = 60
        '
        'ImportServei
        '
        Me.ImportServei.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle77.Format = "c"
        Me.ImportServei.DefaultCellStyle = DataGridViewCellStyle77
        Me.ImportServei.FillWeight = 365.4822!
        Me.ImportServei.HeaderText = "Import"
        Me.ImportServei.MinimumWidth = 80
        Me.ImportServei.Name = "ImportServei"
        Me.ImportServei.ReadOnly = True
        Me.ImportServei.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ImportServei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImportServei.Width = 80
        '
        'Observacions
        '
        Me.Observacions.HeaderText = "Observacions"
        Me.Observacions.Name = "Observacions"
        Me.Observacions.ReadOnly = True
        Me.Observacions.Visible = False
        '
        'txtTotalNXecs
        '
        Me.txtTotalNXecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalNXecs.Location = New System.Drawing.Point(538, 128)
        Me.txtTotalNXecs.MaxLength = 10
        Me.txtTotalNXecs.Name = "txtTotalNXecs"
        Me.txtTotalNXecs.ReadOnly = True
        Me.txtTotalNXecs.Size = New System.Drawing.Size(41, 20)
        Me.txtTotalNXecs.TabIndex = 14
        Me.txtTotalNXecs.Text = "0"
        Me.txtTotalNXecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalXecs
        '
        Me.txtTotalXecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalXecs.Location = New System.Drawing.Point(657, 128)
        Me.txtTotalXecs.MaxLength = 10
        Me.txtTotalXecs.Name = "txtTotalXecs"
        Me.txtTotalXecs.ReadOnly = True
        Me.txtTotalXecs.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalXecs.TabIndex = 12
        Me.txtTotalXecs.Text = "0,00"
        Me.txtTotalXecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(432, 130)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Total xecs liquidats:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Xecs:"
        '
        'dgvXecs
        '
        Me.dgvXecs.AllowUserToAddRows = False
        Me.dgvXecs.AllowUserToDeleteRows = False
        Me.dgvXecs.AllowUserToResizeRows = False
        Me.dgvXecs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvXecs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvXecs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle78.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle78.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle78.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle78.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle78.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvXecs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle78
        Me.dgvXecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvXecs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataEntrega, Me.NroXec, Me.Client, Me.FeinaXec, Me.DataLiquidat, Me.ServeiFeina, Me.QuantitatFeina, Me.UnitatFeina, Me.ImportXec})
        Me.dgvXecs.Location = New System.Drawing.Point(3, 16)
        Me.dgvXecs.MultiSelect = False
        Me.dgvXecs.Name = "dgvXecs"
        Me.dgvXecs.ReadOnly = True
        Me.dgvXecs.RowHeadersVisible = False
        Me.dgvXecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvXecs.Size = New System.Drawing.Size(745, 106)
        Me.dgvXecs.TabIndex = 1
        '
        'DataEntrega
        '
        Me.DataEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle79.Format = "d"
        DataGridViewCellStyle79.NullValue = Nothing
        Me.DataEntrega.DefaultCellStyle = DataGridViewCellStyle79
        Me.DataEntrega.FillWeight = 365.4822!
        Me.DataEntrega.HeaderText = "Data entr."
        Me.DataEntrega.MinimumWidth = 80
        Me.DataEntrega.Name = "DataEntrega"
        Me.DataEntrega.ReadOnly = True
        Me.DataEntrega.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataEntrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataEntrega.Width = 80
        '
        'NroXec
        '
        Me.NroXec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NroXec.DefaultCellStyle = DataGridViewCellStyle80
        Me.NroXec.FillWeight = 365.4822!
        Me.NroXec.HeaderText = "Nro. Xec"
        Me.NroXec.MinimumWidth = 80
        Me.NroXec.Name = "NroXec"
        Me.NroXec.ReadOnly = True
        Me.NroXec.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NroXec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NroXec.Width = 80
        '
        'Client
        '
        Me.Client.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Client.FillWeight = 24.14793!
        Me.Client.HeaderText = "Client"
        Me.Client.Name = "Client"
        Me.Client.ReadOnly = True
        Me.Client.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FeinaXec
        '
        Me.FeinaXec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FeinaXec.DefaultCellStyle = DataGridViewCellStyle81
        Me.FeinaXec.FillWeight = 24.14793!
        Me.FeinaXec.HeaderText = "Feina"
        Me.FeinaXec.MinimumWidth = 80
        Me.FeinaXec.Name = "FeinaXec"
        Me.FeinaXec.ReadOnly = True
        Me.FeinaXec.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FeinaXec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FeinaXec.Width = 80
        '
        'DataLiquidat
        '
        Me.DataLiquidat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle82.Format = "d"
        Me.DataLiquidat.DefaultCellStyle = DataGridViewCellStyle82
        Me.DataLiquidat.FillWeight = 24.14793!
        Me.DataLiquidat.HeaderText = "Data liquidat"
        Me.DataLiquidat.MinimumWidth = 80
        Me.DataLiquidat.Name = "DataLiquidat"
        Me.DataLiquidat.ReadOnly = True
        Me.DataLiquidat.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataLiquidat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataLiquidat.Width = 80
        '
        'ServeiFeina
        '
        Me.ServeiFeina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ServeiFeina.FillWeight = 24.14793!
        Me.ServeiFeina.HeaderText = "Servei"
        Me.ServeiFeina.MinimumWidth = 80
        Me.ServeiFeina.Name = "ServeiFeina"
        Me.ServeiFeina.ReadOnly = True
        Me.ServeiFeina.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ServeiFeina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ServeiFeina.Width = 80
        '
        'QuantitatFeina
        '
        Me.QuantitatFeina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle83.Format = "N"
        Me.QuantitatFeina.DefaultCellStyle = DataGridViewCellStyle83
        Me.QuantitatFeina.FillWeight = 24.14793!
        Me.QuantitatFeina.HeaderText = "Quantitat"
        Me.QuantitatFeina.MinimumWidth = 80
        Me.QuantitatFeina.Name = "QuantitatFeina"
        Me.QuantitatFeina.ReadOnly = True
        Me.QuantitatFeina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.QuantitatFeina.Width = 80
        '
        'UnitatFeina
        '
        Me.UnitatFeina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UnitatFeina.FillWeight = 24.14793!
        Me.UnitatFeina.HeaderText = "Unitat"
        Me.UnitatFeina.MinimumWidth = 80
        Me.UnitatFeina.Name = "UnitatFeina"
        Me.UnitatFeina.ReadOnly = True
        Me.UnitatFeina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UnitatFeina.Width = 80
        '
        'ImportXec
        '
        Me.ImportXec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle84.Format = "c"
        Me.ImportXec.DefaultCellStyle = DataGridViewCellStyle84
        Me.ImportXec.FillWeight = 24.14793!
        Me.ImportXec.HeaderText = "Import"
        Me.ImportXec.MinimumWidth = 80
        Me.ImportXec.Name = "ImportXec"
        Me.ImportXec.ReadOnly = True
        Me.ImportXec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ImportXec.Width = 80
        '
        'txtPagaments
        '
        Me.txtPagaments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPagaments.Location = New System.Drawing.Point(657, 6)
        Me.txtPagaments.MaxLength = 10
        Me.txtPagaments.Name = "txtPagaments"
        Me.txtPagaments.Size = New System.Drawing.Size(98, 20)
        Me.txtPagaments.TabIndex = 6
        Me.txtPagaments.Text = "0,00"
        Me.txtPagaments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkPdtFacturar
        '
        Me.chkPdtFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPdtFacturar.AutoSize = True
        Me.chkPdtFacturar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPdtFacturar.Location = New System.Drawing.Point(411, 8)
        Me.chkPdtFacturar.Name = "chkPdtFacturar"
        Me.chkPdtFacturar.Size = New System.Drawing.Size(102, 17)
        Me.chkPdtFacturar.TabIndex = 5
        Me.chkPdtFacturar.Text = "Pdt. de facturar:"
        Me.chkPdtFacturar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(521, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Total pagaments efectuats:"
        '
        'cmbSelClients
        '
        Me.cmbSelClients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSelClients.DataSource = Me.ClientsBindingSource
        Me.cmbSelClients.DisplayMember = "clients_nom"
        Me.cmbSelClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelClients.FormattingEnabled = True
        Me.cmbSelClients.Location = New System.Drawing.Point(156, 6)
        Me.cmbSelClients.Name = "cmbSelClients"
        Me.cmbSelClients.Size = New System.Drawing.Size(247, 21)
        Me.cmbSelClients.TabIndex = 3
        Me.cmbSelClients.ValueMember = "clients_nom"
        '
        'ClientsBindingSource
        '
        Me.ClientsBindingSource.DataMember = "Clients"
        Me.ClientsBindingSource.DataSource = Me.PlaniFeinesDataSet
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(114, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Client:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Mes:"
        '
        'dtpSelMes
        '
        Me.dtpSelMes.CustomFormat = "MM/yyyy"
        Me.dtpSelMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSelMes.Location = New System.Drawing.Point(39, 6)
        Me.dtpSelMes.Name = "dtpSelMes"
        Me.dtpSelMes.ShowUpDown = True
        Me.dtpSelMes.Size = New System.Drawing.Size(69, 20)
        Me.dtpSelMes.TabIndex = 0
        '
        'TabPageClients
        '
        Me.TabPageClients.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageClients.Controls.Add(Me.SplitContainer3)
        Me.TabPageClients.Location = New System.Drawing.Point(4, 22)
        Me.TabPageClients.Name = "TabPageClients"
        Me.TabPageClients.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageClients.Size = New System.Drawing.Size(763, 503)
        Me.TabPageClients.TabIndex = 2
        Me.TabPageClients.Text = "Clients"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.tvClients)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.pnlClients)
        Me.SplitContainer3.Panel2.Controls.Add(Me.pnlServeis)
        Me.SplitContainer3.Panel2.Controls.Add(Me.pnlXecs)
        Me.SplitContainer3.Panel2.Controls.Add(Me.pnlLlocs)
        Me.SplitContainer3.Size = New System.Drawing.Size(757, 497)
        Me.SplitContainer3.SplitterDistance = 376
        Me.SplitContainer3.TabIndex = 0
        Me.SplitContainer3.TabStop = False
        '
        'tvClients
        '
        Me.tvClients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvClients.HideSelection = False
        Me.tvClients.Location = New System.Drawing.Point(0, 0)
        Me.tvClients.Name = "tvClients"
        Me.tvClients.ShowNodeToolTips = True
        Me.tvClients.ShowPlusMinus = False
        Me.tvClients.ShowRootLines = False
        Me.tvClients.Size = New System.Drawing.Size(372, 493)
        Me.tvClients.TabIndex = 2
        '
        'pnlClients
        '
        Me.pnlClients.AutoScroll = True
        Me.pnlClients.Controls.Add(Clients_observacionsLabel)
        Me.pnlClients.Controls.Add(Me.Clients_observacionsTextBox)
        Me.pnlClients.Controls.Add(Clients_emailLabel)
        Me.pnlClients.Controls.Add(Me.Clients_emailTextBox)
        Me.pnlClients.Controls.Add(Clients_cccLabel)
        Me.pnlClients.Controls.Add(Me.Clients_cccTextBox)
        Me.pnlClients.Controls.Add(Clients_xecsLabel)
        Me.pnlClients.Controls.Add(Me.Clients_xecsCheckBox)
        Me.pnlClients.Controls.Add(Clients_data_altaLabel)
        Me.pnlClients.Controls.Add(Me.Clients_data_altaTextBox)
        Me.pnlClients.Controls.Add(Clients_telefonsLabel)
        Me.pnlClients.Controls.Add(Me.Clients_telefonsTextBox)
        Me.pnlClients.Controls.Add(Clients_codi_postalLabel)
        Me.pnlClients.Controls.Add(Me.Clients_codi_postalMaskedTextBox)
        Me.pnlClients.Controls.Add(Clients_poblacioLabel)
        Me.pnlClients.Controls.Add(Me.Clients_poblacioTextBox)
        Me.pnlClients.Controls.Add(Clients_adreçaLabel)
        Me.pnlClients.Controls.Add(Me.Clients_adreçaTextBox)
        Me.pnlClients.Controls.Add(Clients_NIFLabel)
        Me.pnlClients.Controls.Add(Me.Clients_NIFTextBox)
        Me.pnlClients.Controls.Add(Clients_nomLabel)
        Me.pnlClients.Controls.Add(Me.Clients_nomTextBox)
        Me.pnlClients.Controls.Add(Me.lblClient)
        Me.pnlClients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClients.Location = New System.Drawing.Point(0, 0)
        Me.pnlClients.Name = "pnlClients"
        Me.pnlClients.Size = New System.Drawing.Size(373, 493)
        Me.pnlClients.TabIndex = 0
        Me.pnlClients.Visible = False
        '
        'Clients_observacionsTextBox
        '
        Me.Clients_observacionsTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_observacionsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_observacions", True))
        Me.Clients_observacionsTextBox.Location = New System.Drawing.Point(98, 299)
        Me.Clients_observacionsTextBox.Multiline = True
        Me.Clients_observacionsTextBox.Name = "Clients_observacionsTextBox"
        Me.Clients_observacionsTextBox.Size = New System.Drawing.Size(261, 181)
        Me.Clients_observacionsTextBox.TabIndex = 11
        '
        'Clients_emailTextBox
        '
        Me.Clients_emailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_email", True))
        Me.Clients_emailTextBox.Location = New System.Drawing.Point(98, 267)
        Me.Clients_emailTextBox.MaxLength = 50
        Me.Clients_emailTextBox.Name = "Clients_emailTextBox"
        Me.Clients_emailTextBox.Size = New System.Drawing.Size(264, 20)
        Me.Clients_emailTextBox.TabIndex = 10
        '
        'Clients_cccTextBox
        '
        Me.Clients_cccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_ccc", True))
        Me.Clients_cccTextBox.Location = New System.Drawing.Point(98, 239)
        Me.Clients_cccTextBox.MaxLength = 23
        Me.Clients_cccTextBox.Name = "Clients_cccTextBox"
        Me.Clients_cccTextBox.Size = New System.Drawing.Size(175, 20)
        Me.Clients_cccTextBox.TabIndex = 9
        '
        'Clients_xecsCheckBox
        '
        Me.Clients_xecsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ClientsBindingSource, "clients_xecs", True))
        Me.Clients_xecsCheckBox.Location = New System.Drawing.Point(98, 209)
        Me.Clients_xecsCheckBox.Name = "Clients_xecsCheckBox"
        Me.Clients_xecsCheckBox.Size = New System.Drawing.Size(23, 24)
        Me.Clients_xecsCheckBox.TabIndex = 8
        Me.Clients_xecsCheckBox.UseVisualStyleBackColor = True
        '
        'Clients_data_altaTextBox
        '
        Me.Clients_data_altaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_data_alta", True))
        Me.Clients_data_altaTextBox.Location = New System.Drawing.Point(97, 27)
        Me.Clients_data_altaTextBox.Name = "Clients_data_altaTextBox"
        Me.Clients_data_altaTextBox.ReadOnly = True
        Me.Clients_data_altaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Clients_data_altaTextBox.TabIndex = 14
        Me.Clients_data_altaTextBox.TabStop = False
        '
        'Clients_telefonsTextBox
        '
        Me.Clients_telefonsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_telefons", True))
        Me.Clients_telefonsTextBox.Location = New System.Drawing.Point(98, 184)
        Me.Clients_telefonsTextBox.MaxLength = 50
        Me.Clients_telefonsTextBox.Name = "Clients_telefonsTextBox"
        Me.Clients_telefonsTextBox.Size = New System.Drawing.Size(175, 20)
        Me.Clients_telefonsTextBox.TabIndex = 7
        '
        'Clients_codi_postalMaskedTextBox
        '
        Me.Clients_codi_postalMaskedTextBox.AllowPromptAsInput = False
        Me.Clients_codi_postalMaskedTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_codi_postal", True))
        Me.Clients_codi_postalMaskedTextBox.HidePromptOnLeave = True
        Me.Clients_codi_postalMaskedTextBox.Location = New System.Drawing.Point(98, 158)
        Me.Clients_codi_postalMaskedTextBox.Mask = "00000"
        Me.Clients_codi_postalMaskedTextBox.Name = "Clients_codi_postalMaskedTextBox"
        Me.Clients_codi_postalMaskedTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Clients_codi_postalMaskedTextBox.Size = New System.Drawing.Size(54, 20)
        Me.Clients_codi_postalMaskedTextBox.TabIndex = 6
        '
        'Clients_poblacioTextBox
        '
        Me.Clients_poblacioTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_poblacioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_poblacio", True))
        Me.Clients_poblacioTextBox.Location = New System.Drawing.Point(98, 132)
        Me.Clients_poblacioTextBox.MaxLength = 50
        Me.Clients_poblacioTextBox.Name = "Clients_poblacioTextBox"
        Me.Clients_poblacioTextBox.Size = New System.Drawing.Size(261, 20)
        Me.Clients_poblacioTextBox.TabIndex = 5
        '
        'Clients_adreçaTextBox
        '
        Me.Clients_adreçaTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_adreçaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_adreça", True))
        Me.Clients_adreçaTextBox.Location = New System.Drawing.Point(98, 106)
        Me.Clients_adreçaTextBox.MaxLength = 50
        Me.Clients_adreçaTextBox.Name = "Clients_adreçaTextBox"
        Me.Clients_adreçaTextBox.Size = New System.Drawing.Size(261, 20)
        Me.Clients_adreçaTextBox.TabIndex = 4
        '
        'Clients_NIFTextBox
        '
        Me.Clients_NIFTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_NIF", True))
        Me.Clients_NIFTextBox.Location = New System.Drawing.Point(98, 80)
        Me.Clients_NIFTextBox.MaxLength = 10
        Me.Clients_NIFTextBox.Name = "Clients_NIFTextBox"
        Me.Clients_NIFTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Clients_NIFTextBox.TabIndex = 3
        '
        'Clients_nomTextBox
        '
        Me.Clients_nomTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_nomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsBindingSource, "clients_nom", True))
        Me.Clients_nomTextBox.Location = New System.Drawing.Point(98, 54)
        Me.Clients_nomTextBox.MaxLength = 50
        Me.Clients_nomTextBox.Name = "Clients_nomTextBox"
        Me.Clients_nomTextBox.Size = New System.Drawing.Size(261, 20)
        Me.Clients_nomTextBox.TabIndex = 2
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(4, 4)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(39, 13)
        Me.lblClient.TabIndex = 0
        Me.lblClient.Text = "Client"
        '
        'pnlServeis
        '
        Me.pnlServeis.AutoScroll = True
        Me.pnlServeis.Controls.Add(Me.Llocs_serveis_preu_unTextBox)
        Me.pnlServeis.Controls.Add(Me.Llocs_serveis_quantitatTextBox)
        Me.pnlServeis.Controls.Add(Me.Label8)
        Me.pnlServeis.Controls.Add(Llocs_serveis_preu_unLabel)
        Me.pnlServeis.Controls.Add(Me.txtUnitat)
        Me.pnlServeis.Controls.Add(Llocs_serveis_quantitatLabel)
        Me.pnlServeis.Controls.Add(Serveis_nomLabel)
        Me.pnlServeis.Controls.Add(Me.Serveis_nomComboBox)
        Me.pnlServeis.Controls.Add(Llocs_nomLabel1)
        Me.pnlServeis.Controls.Add(Me.Llocs_nomTextBox1)
        Me.pnlServeis.Controls.Add(Me.lblServei)
        Me.pnlServeis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlServeis.Location = New System.Drawing.Point(0, 0)
        Me.pnlServeis.Name = "pnlServeis"
        Me.pnlServeis.Size = New System.Drawing.Size(373, 493)
        Me.pnlServeis.TabIndex = 2
        Me.pnlServeis.Visible = False
        '
        'Llocs_serveis_preu_unTextBox
        '
        Me.Llocs_serveis_preu_unTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Llocs_ServeisBindingSource, "llocs_serveis_preu_un", True))
        Me.Llocs_serveis_preu_unTextBox.Location = New System.Drawing.Point(82, 119)
        Me.Llocs_serveis_preu_unTextBox.MaxLength = 12
        Me.Llocs_serveis_preu_unTextBox.Name = "Llocs_serveis_preu_unTextBox"
        Me.Llocs_serveis_preu_unTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Llocs_serveis_preu_unTextBox.TabIndex = 6
        Me.Llocs_serveis_preu_unTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Llocs_ServeisBindingSource
        '
        Me.Llocs_ServeisBindingSource.DataMember = "LlocsLlocs_Serveis"
        Me.Llocs_ServeisBindingSource.DataSource = Me.LlocsBindingSource
        '
        'Llocs_serveis_quantitatTextBox
        '
        Me.Llocs_serveis_quantitatTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Llocs_ServeisBindingSource, "llocs_serveis_quantitat", True))
        Me.Llocs_serveis_quantitatTextBox.Location = New System.Drawing.Point(82, 88)
        Me.Llocs_serveis_quantitatTextBox.MaxLength = 12
        Me.Llocs_serveis_quantitatTextBox.Name = "Llocs_serveis_quantitatTextBox"
        Me.Llocs_serveis_quantitatTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Llocs_serveis_quantitatTextBox.TabIndex = 5
        Me.Llocs_serveis_quantitatTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(189, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "€"
        '
        'txtUnitat
        '
        Me.txtUnitat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnitat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUnitat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServeisBindingSource, "serveis_unitat", True))
        Me.txtUnitat.Location = New System.Drawing.Point(188, 91)
        Me.txtUnitat.Name = "txtUnitat"
        Me.txtUnitat.ReadOnly = True
        Me.txtUnitat.Size = New System.Drawing.Size(171, 13)
        Me.txtUnitat.TabIndex = 7
        Me.txtUnitat.TabStop = False
        '
        'ServeisBindingSource
        '
        Me.ServeisBindingSource.DataMember = "Serveis"
        Me.ServeisBindingSource.DataSource = Me.PlaniFeinesDataSet
        '
        'Serveis_nomComboBox
        '
        Me.Serveis_nomComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Llocs_ServeisBindingSource, "serveis_nom", True))
        Me.Serveis_nomComboBox.DataSource = Me.ServeisBindingSource
        Me.Serveis_nomComboBox.DisplayMember = "serveis_nom"
        Me.Serveis_nomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Serveis_nomComboBox.FormattingEnabled = True
        Me.Serveis_nomComboBox.Location = New System.Drawing.Point(82, 57)
        Me.Serveis_nomComboBox.Name = "Serveis_nomComboBox"
        Me.Serveis_nomComboBox.Size = New System.Drawing.Size(144, 21)
        Me.Serveis_nomComboBox.TabIndex = 4
        Me.Serveis_nomComboBox.ValueMember = "serveis_nom"
        '
        'Llocs_nomTextBox1
        '
        Me.Llocs_nomTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Llocs_nomTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Llocs_ServeisBindingSource, "llocs_nom", True))
        Me.Llocs_nomTextBox1.Location = New System.Drawing.Point(82, 28)
        Me.Llocs_nomTextBox1.Name = "Llocs_nomTextBox1"
        Me.Llocs_nomTextBox1.ReadOnly = True
        Me.Llocs_nomTextBox1.Size = New System.Drawing.Size(277, 20)
        Me.Llocs_nomTextBox1.TabIndex = 2
        Me.Llocs_nomTextBox1.TabStop = False
        '
        'lblServei
        '
        Me.lblServei.AutoSize = True
        Me.lblServei.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServei.Location = New System.Drawing.Point(4, 4)
        Me.lblServei.Name = "lblServei"
        Me.lblServei.Size = New System.Drawing.Size(43, 13)
        Me.lblServei.TabIndex = 0
        Me.lblServei.Text = "Servei"
        '
        'pnlXecs
        '
        Me.pnlXecs.AutoScroll = True
        Me.pnlXecs.Controls.Add(Me.Label11)
        Me.pnlXecs.Controls.Add(Me.lblQuants)
        Me.pnlXecs.Controls.Add(Me.txtQuants)
        Me.pnlXecs.Controls.Add(Xecs_data_liquidatLabel)
        Me.pnlXecs.Controls.Add(Me.Xecs_data_liquidatTextBox)
        Me.pnlXecs.Controls.Add(Feines_idLabel)
        Me.pnlXecs.Controls.Add(Me.Feines_idTextBox)
        Me.pnlXecs.Controls.Add(Xecs_valorLabel)
        Me.pnlXecs.Controls.Add(Me.Xecs_valorTextBox)
        Me.pnlXecs.Controls.Add(Me.Xecs_idTextBox)
        Me.pnlXecs.Controls.Add(Label9)
        Me.pnlXecs.Controls.Add(Xecs_data_entregaLabel)
        Me.pnlXecs.Controls.Add(Me.Xecs_data_entregaDateTimePicker)
        Me.pnlXecs.Controls.Add(Me.Clients_nomTextBox2)
        Me.pnlXecs.Controls.Add(Xecs_idLabel)
        Me.pnlXecs.Controls.Add(Me.lblXec)
        Me.pnlXecs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlXecs.Location = New System.Drawing.Point(0, 0)
        Me.pnlXecs.Name = "pnlXecs"
        Me.pnlXecs.Size = New System.Drawing.Size(373, 493)
        Me.pnlXecs.TabIndex = 3
        Me.pnlXecs.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(202, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "€"
        '
        'lblQuants
        '
        Me.lblQuants.AutoSize = True
        Me.lblQuants.Location = New System.Drawing.Point(209, 53)
        Me.lblQuants.Name = "lblQuants"
        Me.lblQuants.Size = New System.Drawing.Size(44, 13)
        Me.lblQuants.TabIndex = 14
        Me.lblQuants.Text = "Quants:"
        '
        'txtQuants
        '
        Me.txtQuants.Location = New System.Drawing.Point(262, 50)
        Me.txtQuants.MaxLength = 3
        Me.txtQuants.Name = "txtQuants"
        Me.txtQuants.Size = New System.Drawing.Size(40, 20)
        Me.txtQuants.TabIndex = 6
        '
        'Xecs_data_liquidatTextBox
        '
        Me.Xecs_data_liquidatTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.XecsBindingSource, "xecs_data_liquidat", True))
        Me.Xecs_data_liquidatTextBox.Location = New System.Drawing.Point(99, 158)
        Me.Xecs_data_liquidatTextBox.Name = "Xecs_data_liquidatTextBox"
        Me.Xecs_data_liquidatTextBox.ReadOnly = True
        Me.Xecs_data_liquidatTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Xecs_data_liquidatTextBox.TabIndex = 12
        Me.Xecs_data_liquidatTextBox.TabStop = False
        '
        'XecsBindingSource
        '
        Me.XecsBindingSource.DataMember = "Xecs"
        Me.XecsBindingSource.DataSource = Me.PlaniFeinesDataSet
        '
        'Feines_idTextBox
        '
        Me.Feines_idTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.XecsBindingSource, "feines_id", True))
        Me.Feines_idTextBox.Location = New System.Drawing.Point(99, 132)
        Me.Feines_idTextBox.Name = "Feines_idTextBox"
        Me.Feines_idTextBox.ReadOnly = True
        Me.Feines_idTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Feines_idTextBox.TabIndex = 10
        Me.Feines_idTextBox.TabStop = False
        '
        'Xecs_valorTextBox
        '
        Me.Xecs_valorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.XecsBindingSource, "xecs_valor", True))
        Me.Xecs_valorTextBox.Location = New System.Drawing.Point(98, 106)
        Me.Xecs_valorTextBox.Name = "Xecs_valorTextBox"
        Me.Xecs_valorTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Xecs_valorTextBox.TabIndex = 7
        Me.Xecs_valorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Xecs_idTextBox
        '
        Me.Xecs_idTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.XecsBindingSource, "xecs_id", True))
        Me.Xecs_idTextBox.Location = New System.Drawing.Point(98, 51)
        Me.Xecs_idTextBox.MaxLength = 5
        Me.Xecs_idTextBox.Name = "Xecs_idTextBox"
        Me.Xecs_idTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Xecs_idTextBox.TabIndex = 5
        '
        'Xecs_data_entregaDateTimePicker
        '
        Me.Xecs_data_entregaDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.XecsBindingSource, "xecs_data_entrega", True))
        Me.Xecs_data_entregaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Xecs_data_entregaDateTimePicker.Location = New System.Drawing.Point(98, 77)
        Me.Xecs_data_entregaDateTimePicker.Name = "Xecs_data_entregaDateTimePicker"
        Me.Xecs_data_entregaDateTimePicker.Size = New System.Drawing.Size(99, 20)
        Me.Xecs_data_entregaDateTimePicker.TabIndex = 6
        '
        'Clients_nomTextBox2
        '
        Me.Clients_nomTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_nomTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.XecsBindingSource, "clients_nom", True))
        Me.Clients_nomTextBox2.Location = New System.Drawing.Point(99, 24)
        Me.Clients_nomTextBox2.Name = "Clients_nomTextBox2"
        Me.Clients_nomTextBox2.ReadOnly = True
        Me.Clients_nomTextBox2.Size = New System.Drawing.Size(260, 20)
        Me.Clients_nomTextBox2.TabIndex = 4
        Me.Clients_nomTextBox2.TabStop = False
        '
        'lblXec
        '
        Me.lblXec.AutoSize = True
        Me.lblXec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXec.Location = New System.Drawing.Point(4, 4)
        Me.lblXec.Name = "lblXec"
        Me.lblXec.Size = New System.Drawing.Size(29, 13)
        Me.lblXec.TabIndex = 0
        Me.lblXec.Text = "Xec"
        '
        'pnlLlocs
        '
        Me.pnlLlocs.AutoScroll = True
        Me.pnlLlocs.Controls.Add(Me.Llocs_horaComboBox)
        Me.pnlLlocs.Controls.Add(Me.Llocs_periodicitat_diesTextBox)
        Me.pnlLlocs.Controls.Add(Me.lblLloc)
        Me.pnlLlocs.Controls.Add(Me.Llocs_quotaTextBox)
        Me.pnlLlocs.Controls.Add(Label7)
        Me.pnlLlocs.Controls.Add(Me.Recursos_nomComboBox)
        Me.pnlLlocs.Controls.Add(Me.Clients_nomTextBox1)
        Me.pnlLlocs.Controls.Add(Me.cmbDiesSetmana)
        Me.pnlLlocs.Controls.Add(Llocs_observacionsLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_observacionsTextBox)
        Me.pnlLlocs.Controls.Add(Llocs_quotaLabel)
        Me.pnlLlocs.Controls.Add(Recursos_nomLabel)
        Me.pnlLlocs.Controls.Add(Llocs_minuts_previstLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_minuts_previstMaskedTextBox)
        Me.pnlLlocs.Controls.Add(Llocs_horaLabel)
        Me.pnlLlocs.Controls.Add(Me.Label6)
        Me.pnlLlocs.Controls.Add(Llocs_dia_setmanaLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_ultim_dia_mesCheckBox)
        Me.pnlLlocs.Controls.Add(Me.Llocs_primer_dia_mesCheckBox)
        Me.pnlLlocs.Controls.Add(Me.Llocs_diumengeCheckBox)
        Me.pnlLlocs.Controls.Add(Me.Llocs_dissabteCheckBox)
        Me.pnlLlocs.Controls.Add(Me.Label5)
        Me.pnlLlocs.Controls.Add(Llocs_periodicitat_diesLabel)
        Me.pnlLlocs.Controls.Add(Llocs_telefonLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_telefonTextBox)
        Me.pnlLlocs.Controls.Add(Llocs_poblacioLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_poblacioTextBox)
        Me.pnlLlocs.Controls.Add(Llocs_adreçaLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_adreçaTextBox)
        Me.pnlLlocs.Controls.Add(Llocs_nomLabel)
        Me.pnlLlocs.Controls.Add(Me.Llocs_nomTextBox)
        Me.pnlLlocs.Controls.Add(Me.Llocs_dia_setmanaTextBox)
        Me.pnlLlocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLlocs.Location = New System.Drawing.Point(0, 0)
        Me.pnlLlocs.Name = "pnlLlocs"
        Me.pnlLlocs.Size = New System.Drawing.Size(373, 493)
        Me.pnlLlocs.TabIndex = 1
        Me.pnlLlocs.Visible = False
        '
        'Llocs_horaComboBox
        '
        Me.Llocs_horaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_hora", True))
        Me.Llocs_horaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Llocs_horaComboBox.FormattingEnabled = True
        Me.Llocs_horaComboBox.Location = New System.Drawing.Point(247, 245)
        Me.Llocs_horaComboBox.Name = "Llocs_horaComboBox"
        Me.Llocs_horaComboBox.Size = New System.Drawing.Size(64, 21)
        Me.Llocs_horaComboBox.TabIndex = 12
        '
        'Llocs_periodicitat_diesTextBox
        '
        Me.Llocs_periodicitat_diesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_periodicitat_dies", True))
        Me.Llocs_periodicitat_diesTextBox.Location = New System.Drawing.Point(93, 164)
        Me.Llocs_periodicitat_diesTextBox.MaxLength = 3
        Me.Llocs_periodicitat_diesTextBox.Name = "Llocs_periodicitat_diesTextBox"
        Me.Llocs_periodicitat_diesTextBox.Size = New System.Drawing.Size(46, 20)
        Me.Llocs_periodicitat_diesTextBox.TabIndex = 6
        Me.Llocs_periodicitat_diesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLloc
        '
        Me.lblLloc.AutoSize = True
        Me.lblLloc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLloc.Location = New System.Drawing.Point(4, 4)
        Me.lblLloc.Name = "lblLloc"
        Me.lblLloc.Size = New System.Drawing.Size(31, 13)
        Me.lblLloc.TabIndex = 0
        Me.lblLloc.Text = "Lloc"
        '
        'Llocs_quotaTextBox
        '
        Me.Llocs_quotaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_quota", True))
        Me.Llocs_quotaTextBox.Location = New System.Drawing.Point(93, 340)
        Me.Llocs_quotaTextBox.MaxLength = 9
        Me.Llocs_quotaTextBox.Name = "Llocs_quotaTextBox"
        Me.Llocs_quotaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Llocs_quotaTextBox.TabIndex = 15
        Me.Llocs_quotaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Recursos_nomComboBox
        '
        Me.Recursos_nomComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Recursos_nomComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.LlocsBindingSource, "recursos_nom", True))
        Me.Recursos_nomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Recursos_nomComboBox.FormattingEnabled = True
        Me.Recursos_nomComboBox.Location = New System.Drawing.Point(94, 306)
        Me.Recursos_nomComboBox.Name = "Recursos_nomComboBox"
        Me.Recursos_nomComboBox.Size = New System.Drawing.Size(265, 21)
        Me.Recursos_nomComboBox.TabIndex = 14
        '
        'Clients_nomTextBox1
        '
        Me.Clients_nomTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clients_nomTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "clients_nom", True))
        Me.Clients_nomTextBox1.Location = New System.Drawing.Point(93, 25)
        Me.Clients_nomTextBox1.Name = "Clients_nomTextBox1"
        Me.Clients_nomTextBox1.ReadOnly = True
        Me.Clients_nomTextBox1.Size = New System.Drawing.Size(266, 20)
        Me.Clients_nomTextBox1.TabIndex = 31
        Me.Clients_nomTextBox1.TabStop = False
        '
        'cmbDiesSetmana
        '
        Me.cmbDiesSetmana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiesSetmana.FormattingEnabled = True
        Me.cmbDiesSetmana.Items.AddRange(New Object() {"", "diumenges", "dilluns", "dimarts", "dimecres", "dijous", "divendres", "dissabtes"})
        Me.cmbDiesSetmana.Location = New System.Drawing.Point(94, 246)
        Me.cmbDiesSetmana.MaxDropDownItems = 7
        Me.cmbDiesSetmana.Name = "cmbDiesSetmana"
        Me.cmbDiesSetmana.Size = New System.Drawing.Size(109, 21)
        Me.cmbDiesSetmana.TabIndex = 11
        '
        'Llocs_observacionsTextBox
        '
        Me.Llocs_observacionsTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Llocs_observacionsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_observacions", True))
        Me.Llocs_observacionsTextBox.Location = New System.Drawing.Point(94, 373)
        Me.Llocs_observacionsTextBox.Multiline = True
        Me.Llocs_observacionsTextBox.Name = "Llocs_observacionsTextBox"
        Me.Llocs_observacionsTextBox.Size = New System.Drawing.Size(265, 107)
        Me.Llocs_observacionsTextBox.TabIndex = 16
        '
        'Llocs_minuts_previstMaskedTextBox
        '
        Me.Llocs_minuts_previstMaskedTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_minuts_previst", True))
        Me.Llocs_minuts_previstMaskedTextBox.HidePromptOnLeave = True
        Me.Llocs_minuts_previstMaskedTextBox.Location = New System.Drawing.Point(94, 276)
        Me.Llocs_minuts_previstMaskedTextBox.Mask = "9999"
        Me.Llocs_minuts_previstMaskedTextBox.Name = "Llocs_minuts_previstMaskedTextBox"
        Me.Llocs_minuts_previstMaskedTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Llocs_minuts_previstMaskedTextBox.ReadOnly = True
        Me.Llocs_minuts_previstMaskedTextBox.Size = New System.Drawing.Size(45, 20)
        Me.Llocs_minuts_previstMaskedTextBox.TabIndex = 13
        Me.Llocs_minuts_previstMaskedTextBox.TabStop = False
        Me.Llocs_minuts_previstMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Planificar:"
        '
        'Llocs_ultim_dia_mesCheckBox
        '
        Me.Llocs_ultim_dia_mesCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LlocsBindingSource, "llocs_ultim_dia_mes", True))
        Me.Llocs_ultim_dia_mesCheckBox.Location = New System.Drawing.Point(94, 217)
        Me.Llocs_ultim_dia_mesCheckBox.Name = "Llocs_ultim_dia_mesCheckBox"
        Me.Llocs_ultim_dia_mesCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Llocs_ultim_dia_mesCheckBox.TabIndex = 10
        Me.Llocs_ultim_dia_mesCheckBox.Text = "Últim dia de mes"
        Me.Llocs_ultim_dia_mesCheckBox.UseVisualStyleBackColor = True
        '
        'Llocs_primer_dia_mesCheckBox
        '
        Me.Llocs_primer_dia_mesCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LlocsBindingSource, "llocs_primer_dia_mes", True))
        Me.Llocs_primer_dia_mesCheckBox.Location = New System.Drawing.Point(94, 196)
        Me.Llocs_primer_dia_mesCheckBox.Name = "Llocs_primer_dia_mesCheckBox"
        Me.Llocs_primer_dia_mesCheckBox.Size = New System.Drawing.Size(146, 24)
        Me.Llocs_primer_dia_mesCheckBox.TabIndex = 9
        Me.Llocs_primer_dia_mesCheckBox.Text = "Primer dia de mes"
        Me.Llocs_primer_dia_mesCheckBox.UseVisualStyleBackColor = True
        '
        'Llocs_diumengeCheckBox
        '
        Me.Llocs_diumengeCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LlocsBindingSource, "llocs_diumenge", True))
        Me.Llocs_diumengeCheckBox.Location = New System.Drawing.Point(177, 170)
        Me.Llocs_diumengeCheckBox.Name = "Llocs_diumengeCheckBox"
        Me.Llocs_diumengeCheckBox.Size = New System.Drawing.Size(134, 24)
        Me.Llocs_diumengeCheckBox.TabIndex = 8
        Me.Llocs_diumengeCheckBox.Text = "Diumenges inclòs"
        Me.Llocs_diumengeCheckBox.UseVisualStyleBackColor = True
        '
        'Llocs_dissabteCheckBox
        '
        Me.Llocs_dissabteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LlocsBindingSource, "llocs_dissabte", True))
        Me.Llocs_dissabteCheckBox.Location = New System.Drawing.Point(177, 151)
        Me.Llocs_dissabteCheckBox.Name = "Llocs_dissabteCheckBox"
        Me.Llocs_dissabteCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Llocs_dissabteCheckBox.TabIndex = 7
        Me.Llocs_dissabteCheckBox.Text = "Dissabtes inclòs"
        Me.Llocs_dissabteCheckBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(145, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "dies"
        '
        'Llocs_telefonTextBox
        '
        Me.Llocs_telefonTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_telefon", True))
        Me.Llocs_telefonTextBox.Location = New System.Drawing.Point(93, 128)
        Me.Llocs_telefonTextBox.MaxLength = 15
        Me.Llocs_telefonTextBox.Name = "Llocs_telefonTextBox"
        Me.Llocs_telefonTextBox.Size = New System.Drawing.Size(113, 20)
        Me.Llocs_telefonTextBox.TabIndex = 5
        '
        'Llocs_poblacioTextBox
        '
        Me.Llocs_poblacioTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Llocs_poblacioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_poblacio", True))
        Me.Llocs_poblacioTextBox.Location = New System.Drawing.Point(94, 102)
        Me.Llocs_poblacioTextBox.MaxLength = 50
        Me.Llocs_poblacioTextBox.Name = "Llocs_poblacioTextBox"
        Me.Llocs_poblacioTextBox.Size = New System.Drawing.Size(265, 20)
        Me.Llocs_poblacioTextBox.TabIndex = 4
        '
        'Llocs_adreçaTextBox
        '
        Me.Llocs_adreçaTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Llocs_adreçaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_adreça", True))
        Me.Llocs_adreçaTextBox.Location = New System.Drawing.Point(94, 76)
        Me.Llocs_adreçaTextBox.MaxLength = 50
        Me.Llocs_adreçaTextBox.Name = "Llocs_adreçaTextBox"
        Me.Llocs_adreçaTextBox.Size = New System.Drawing.Size(265, 20)
        Me.Llocs_adreçaTextBox.TabIndex = 3
        '
        'Llocs_nomTextBox
        '
        Me.Llocs_nomTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Llocs_nomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_nom", True))
        Me.Llocs_nomTextBox.Location = New System.Drawing.Point(94, 50)
        Me.Llocs_nomTextBox.MaxLength = 50
        Me.Llocs_nomTextBox.Name = "Llocs_nomTextBox"
        Me.Llocs_nomTextBox.Size = New System.Drawing.Size(265, 20)
        Me.Llocs_nomTextBox.TabIndex = 2
        '
        'Llocs_dia_setmanaTextBox
        '
        Me.Llocs_dia_setmanaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LlocsBindingSource, "llocs_dia_setmana", True))
        Me.Llocs_dia_setmanaTextBox.Enabled = False
        Me.Llocs_dia_setmanaTextBox.Location = New System.Drawing.Point(169, 246)
        Me.Llocs_dia_setmanaTextBox.Name = "Llocs_dia_setmanaTextBox"
        Me.Llocs_dia_setmanaTextBox.Size = New System.Drawing.Size(25, 20)
        Me.Llocs_dia_setmanaTextBox.TabIndex = 30
        Me.Llocs_dia_setmanaTextBox.TabStop = False
        '
        'TabPageRecursosIServeis
        '
        Me.TabPageRecursosIServeis.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageRecursosIServeis.Controls.Add(Me.SplitContainer6)
        Me.TabPageRecursosIServeis.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRecursosIServeis.Name = "TabPageRecursosIServeis"
        Me.TabPageRecursosIServeis.Size = New System.Drawing.Size(763, 503)
        Me.TabPageRecursosIServeis.TabIndex = 3
        Me.TabPageRecursosIServeis.Text = "Recursos i Serveis"
        '
        'SplitContainer6
        '
        Me.SplitContainer6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.AutoScroll = True
        Me.SplitContainer6.Panel1.Controls.Add(Me.RecursosDataGridView)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.ServeisDataGridView)
        Me.SplitContainer6.Size = New System.Drawing.Size(763, 503)
        Me.SplitContainer6.SplitterDistance = 389
        Me.SplitContainer6.TabIndex = 0
        '
        'RecursosDataGridView
        '
        Me.RecursosDataGridView.AllowUserToResizeColumns = False
        Me.RecursosDataGridView.AllowUserToResizeRows = False
        Me.RecursosDataGridView.AutoGenerateColumns = False
        Me.RecursosDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle85.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle85.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RecursosDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle85
        Me.RecursosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RecursosDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cRecurs, Me.cColor, Me.cGrup})
        Me.RecursosDataGridView.DataSource = Me.RecursosBindingSource
        DataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle86.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle86.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle86.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle86.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle86.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RecursosDataGridView.DefaultCellStyle = DataGridViewCellStyle86
        Me.RecursosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecursosDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RecursosDataGridView.MultiSelect = False
        Me.RecursosDataGridView.Name = "RecursosDataGridView"
        DataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle87.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle87.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle87.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle87.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle87.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RecursosDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle87
        Me.RecursosDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.RecursosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RecursosDataGridView.Size = New System.Drawing.Size(385, 499)
        Me.RecursosDataGridView.TabIndex = 0
        '
        'cRecurs
        '
        Me.cRecurs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cRecurs.DataPropertyName = "recursos_nom"
        Me.cRecurs.HeaderText = "Recurs"
        Me.cRecurs.MaxInputLength = 50
        Me.cRecurs.Name = "cRecurs"
        '
        'cColor
        '
        Me.cColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.cColor.DataPropertyName = "recursos_color"
        Me.cColor.HeaderText = "Color"
        Me.cColor.Name = "cColor"
        Me.cColor.ReadOnly = True
        Me.cColor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cColor.Width = 37
        '
        'cGrup
        '
        Me.cGrup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.cGrup.DataPropertyName = "recursos_grup"
        Me.cGrup.FalseValue = "False"
        Me.cGrup.HeaderText = "Grup"
        Me.cGrup.IndeterminateValue = "False"
        Me.cGrup.Name = "cGrup"
        Me.cGrup.ReadOnly = True
        Me.cGrup.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cGrup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cGrup.TrueValue = "True"
        Me.cGrup.Width = 55
        '
        'ServeisDataGridView
        '
        Me.ServeisDataGridView.AllowUserToResizeRows = False
        Me.ServeisDataGridView.AutoGenerateColumns = False
        Me.ServeisDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle88.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle88.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle88.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle88.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ServeisDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle88
        Me.ServeisDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ServeisDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cNomServei, Me.cUnitatServei, Me.cPreuServei, Me.cMinutsUnitat, Me.cComuServei})
        Me.ServeisDataGridView.DataSource = Me.ServeisBindingSource
        DataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle91.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle91.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle91.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle91.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle91.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ServeisDataGridView.DefaultCellStyle = DataGridViewCellStyle91
        Me.ServeisDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServeisDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ServeisDataGridView.MultiSelect = False
        Me.ServeisDataGridView.Name = "ServeisDataGridView"
        DataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle92.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle92.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle92.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle92.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle92.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ServeisDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle92
        Me.ServeisDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ServeisDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ServeisDataGridView.Size = New System.Drawing.Size(366, 499)
        Me.ServeisDataGridView.TabIndex = 0
        '
        'cNomServei
        '
        Me.cNomServei.DataPropertyName = "serveis_nom"
        Me.cNomServei.HeaderText = "Servei"
        Me.cNomServei.MaxInputLength = 50
        Me.cNomServei.MinimumWidth = 50
        Me.cNomServei.Name = "cNomServei"
        Me.cNomServei.Width = 150
        '
        'cUnitatServei
        '
        Me.cUnitatServei.DataPropertyName = "serveis_unitat"
        Me.cUnitatServei.HeaderText = "Unitat"
        Me.cUnitatServei.MaxInputLength = 25
        Me.cUnitatServei.MinimumWidth = 50
        Me.cUnitatServei.Name = "cUnitatServei"
        Me.cUnitatServei.Width = 60
        '
        'cPreuServei
        '
        Me.cPreuServei.DataPropertyName = "serveis_preu_un"
        DataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle89.Format = "N4"
        DataGridViewCellStyle89.NullValue = Nothing
        Me.cPreuServei.DefaultCellStyle = DataGridViewCellStyle89
        Me.cPreuServei.HeaderText = "Preu unitari"
        Me.cPreuServei.MaxInputLength = 10
        Me.cPreuServei.MinimumWidth = 50
        Me.cPreuServei.Name = "cPreuServei"
        Me.cPreuServei.Width = 85
        '
        'cMinutsUnitat
        '
        Me.cMinutsUnitat.DataPropertyName = "serveis_minuts_per_unitat"
        DataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle90.Format = "N0"
        DataGridViewCellStyle90.NullValue = Nothing
        Me.cMinutsUnitat.DefaultCellStyle = DataGridViewCellStyle90
        Me.cMinutsUnitat.HeaderText = "Equivalència en minuts"
        Me.cMinutsUnitat.MaxInputLength = 10
        Me.cMinutsUnitat.MinimumWidth = 50
        Me.cMinutsUnitat.Name = "cMinutsUnitat"
        Me.cMinutsUnitat.ToolTipText = "Per calcular la duració de la feina."
        Me.cMinutsUnitat.Width = 141
        '
        'cComuServei
        '
        Me.cComuServei.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cComuServei.DataPropertyName = "serveis_comu_per_recursos"
        Me.cComuServei.HeaderText = "Comú pels recursos S/N"
        Me.cComuServei.MinimumWidth = 50
        Me.cComuServei.Name = "cComuServei"
        Me.cComuServei.ToolTipText = "Marca'l si has informat equivalència i el nro. de recursos assignats no afecta a " &
    "la duració del servei."
        '
        'TabPageInformes
        '
        Me.TabPageInformes.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageInformes.Controls.Add(Me.GroupBox3)
        Me.TabPageInformes.Controls.Add(Me.GroupBox2)
        Me.TabPageInformes.Controls.Add(Me.GroupBox1)
        Me.TabPageInformes.Location = New System.Drawing.Point(4, 22)
        Me.TabPageInformes.Name = "TabPageInformes"
        Me.TabPageInformes.Size = New System.Drawing.Size(763, 503)
        Me.TabPageInformes.TabIndex = 4
        Me.TabPageInformes.Text = "Informes"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnInfHoresFetes)
        Me.GroupBox3.Location = New System.Drawing.Point(578, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 496)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Selecció d'informe"
        '
        'btnInfHoresFetes
        '
        Me.btnInfHoresFetes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInfHoresFetes.Location = New System.Drawing.Point(6, 19)
        Me.btnInfHoresFetes.Name = "btnInfHoresFetes"
        Me.btnInfHoresFetes.Size = New System.Drawing.Size(170, 23)
        Me.btnInfHoresFetes.TabIndex = 9
        Me.btnInfHoresFetes.Text = "Hores fetes en periode"
        Me.btnInfHoresFetes.UseVisualStyleBackColor = True
        Me.btnInfHoresFetes.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSelClientInformes)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 54)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selecció de Client"
        '
        'cmbSelClientInformes
        '
        Me.cmbSelClientInformes.DataSource = Me.ClientsBindingSource
        Me.cmbSelClientInformes.DisplayMember = "clients_nom"
        Me.cmbSelClientInformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelClientInformes.FormattingEnabled = True
        Me.cmbSelClientInformes.Location = New System.Drawing.Point(8, 19)
        Me.cmbSelClientInformes.Name = "cmbSelClientInformes"
        Me.cmbSelClientInformes.Size = New System.Drawing.Size(548, 21)
        Me.cmbSelClientInformes.TabIndex = 7
        Me.cmbSelClientInformes.ValueMember = "clients_nom"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PlaniMonthViewFins)
        Me.GroupBox1.Controls.Add(Me.PlaniMonthViewDesDe)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 180)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecció de periode"
        '
        'PlaniMonthViewFins
        '
        Me.PlaniMonthViewFins.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PlaniMonthViewFins.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PlaniMonthViewFins.GridBackColor = System.Drawing.SystemColors.Window
        Me.PlaniMonthViewFins.Language = PlaniSoftwareControlLibrary.PlaniMonthView.Idiom.Català
        Me.PlaniMonthViewFins.Location = New System.Drawing.Point(322, 19)
        Me.PlaniMonthViewFins.MaximumSize = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewFins.MinimumSize = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewFins.Name = "PlaniMonthViewFins"
        Me.PlaniMonthViewFins.SelectedDate = New Date(2019, 4, 14, 0, 0, 0, 0)
        Me.PlaniMonthViewFins.Size = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewFins.TabIndex = 10
        '
        'PlaniMonthViewDesDe
        '
        Me.PlaniMonthViewDesDe.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PlaniMonthViewDesDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PlaniMonthViewDesDe.GridBackColor = System.Drawing.SystemColors.Window
        Me.PlaniMonthViewDesDe.Language = PlaniSoftwareControlLibrary.PlaniMonthView.Idiom.Català
        Me.PlaniMonthViewDesDe.Location = New System.Drawing.Point(50, 19)
        Me.PlaniMonthViewDesDe.MaximumSize = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewDesDe.MinimumSize = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewDesDe.Name = "PlaniMonthViewDesDe"
        Me.PlaniMonthViewDesDe.SelectedDate = New Date(2019, 4, 14, 0, 0, 0, 0)
        Me.PlaniMonthViewDesDe.Size = New System.Drawing.Size(234, 150)
        Me.PlaniMonthViewDesDe.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(290, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "fins:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Des de:"
        '
        'LlocsClientBindingSource
        '
        Me.LlocsClientBindingSource.AllowNew = True
        Me.LlocsClientBindingSource.DataMember = "ClientsLlocs"
        Me.LlocsClientBindingSource.DataSource = Me.ClientsBindingSource
        '
        'Recursos_ComponentsBindingSource
        '
        Me.Recursos_ComponentsBindingSource.DataMember = "RecursosRecursos_Components"
        Me.Recursos_ComponentsBindingSource.DataSource = Me.RecursosBindingSource
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(769, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'DragCursor
        '
        Me.DragCursor.gBlackBitBack = False
        Me.DragCursor.gBoxShadow = True
        Me.DragCursor.gCursorImage = CType(resources.GetObject("DragCursor.gCursorImage"), System.Drawing.Bitmap)
        Me.DragCursor.gEffect = gCursorLib.gCursor.eEffect.No
        Me.DragCursor.gFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DragCursor.gHotSpot = System.Drawing.ContentAlignment.MiddleCenter
        Me.DragCursor.gIBTransp = 80
        Me.DragCursor.gImage = CType(resources.GetObject("DragCursor.gImage"), System.Drawing.Bitmap)
        Me.DragCursor.gImageBorderColor = System.Drawing.Color.Black
        Me.DragCursor.gImageBox = New System.Drawing.Size(75, 56)
        Me.DragCursor.gImageBoxColor = System.Drawing.Color.White
        Me.DragCursor.gITransp = 0
        Me.DragCursor.gScrolling = gCursorLib.gCursor.eScrolling.No
        Me.DragCursor.gShowImageBox = False
        Me.DragCursor.gShowTextBox = True
        Me.DragCursor.gTBTransp = 33
        Me.DragCursor.gText = "Example Text" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Second Line" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Third Line"
        Me.DragCursor.gTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.DragCursor.gTextAutoFit = gCursorLib.gCursor.eTextAutoFit.All
        Me.DragCursor.gTextBorderColor = System.Drawing.Color.Black
        Me.DragCursor.gTextBox = New System.Drawing.Size(100, 30)
        Me.DragCursor.gTextBoxColor = System.Drawing.Color.White
        Me.DragCursor.gTextColor = System.Drawing.Color.Black
        Me.DragCursor.gTextFade = gCursorLib.gCursor.eTextFade.Solid
        Me.DragCursor.gTextMultiline = False
        Me.DragCursor.gTextShadow = False
        Me.DragCursor.gTextShadowColor = System.Drawing.Color.Black
        TextShadower4.Alignment = System.Drawing.ContentAlignment.MiddleCenter
        TextShadower4.Blur = 2.0!
        TextShadower4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        TextShadower4.Offset = CType(resources.GetObject("TextShadower4.Offset"), System.Drawing.PointF)
        TextShadower4.Padding = New System.Windows.Forms.Padding(0)
        TextShadower4.ShadowColor = System.Drawing.Color.Black
        TextShadower4.ShadowTransp = 128
        TextShadower4.Text = "Drop Shadow"
        TextShadower4.TextColor = System.Drawing.Color.Blue
        Me.DragCursor.gTextShadower = TextShadower4
        Me.DragCursor.gTTransp = 0
        Me.DragCursor.gType = gCursorLib.gCursor.eType.Text
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.SolidColorOnly = True
        '
        'ClientsTableAdapter
        '
        Me.ClientsTableAdapter.ClearBeforeFill = False
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ClientsTableAdapter = Me.ClientsTableAdapter
        Me.TableAdapterManager.Feines_DetallTableAdapter = Nothing
        Me.TableAdapterManager.FeinesTableAdapter = Nothing
        Me.TableAdapterManager.Hores_FetesTableAdapter = Nothing
        Me.TableAdapterManager.Llocs_ServeisTableAdapter = Me.Llocs_ServeisTableAdapter
        Me.TableAdapterManager.LlocsTableAdapter = Me.LlocsTableAdapter
        Me.TableAdapterManager.PagamentsTableAdapter = Nothing
        Me.TableAdapterManager.Recursos_ComponentsTableAdapter = Me.Recursos_ComponentsTableAdapter
        Me.TableAdapterManager.RecursosTableAdapter = Me.RecursosTableAdapter
        Me.TableAdapterManager.ServeisTableAdapter = Me.ServeisTableAdapter
        Me.TableAdapterManager.UpdateOrder = PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.XecsTableAdapter = Me.XecsTableAdapter
        '
        'Llocs_ServeisTableAdapter
        '
        Me.Llocs_ServeisTableAdapter.ClearBeforeFill = True
        '
        'LlocsTableAdapter
        '
        Me.LlocsTableAdapter.ClearBeforeFill = False
        '
        'Recursos_ComponentsTableAdapter
        '
        Me.Recursos_ComponentsTableAdapter.ClearBeforeFill = True
        '
        'RecursosTableAdapter
        '
        Me.RecursosTableAdapter.ClearBeforeFill = False
        '
        'ServeisTableAdapter
        '
        Me.ServeisTableAdapter.ClearBeforeFill = True
        '
        'XecsTableAdapter
        '
        Me.XecsTableAdapter.ClearBeforeFill = True
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmPrincipal"
        Me.Text = "PlaniFeines"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageAgenda.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.LlocsSelDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LlocsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlaniFeinesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecursosSelDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecursosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHoresExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageFacturacio.ResumeLayout(False)
        Me.TabPageFacturacio.PerformLayout()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.Panel2.PerformLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvXecs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageClients.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.pnlClients.ResumeLayout(False)
        Me.pnlClients.PerformLayout()
        Me.pnlServeis.ResumeLayout(False)
        Me.pnlServeis.PerformLayout()
        CType(Me.Llocs_ServeisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServeisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlXecs.ResumeLayout(False)
        Me.pnlXecs.PerformLayout()
        CType(Me.XecsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLlocs.ResumeLayout(False)
        Me.pnlLlocs.PerformLayout()
        Me.TabPageRecursosIServeis.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        CType(Me.RecursosDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServeisDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageInformes.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LlocsClientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Recursos_ComponentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageAgenda As System.Windows.Forms.TabPage
    Friend WithEvents TabPageFacturacio As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TabPageClients As System.Windows.Forms.TabPage
    Friend WithEvents TabPageRecursosIServeis As System.Windows.Forms.TabPage
    Friend WithEvents TabPageInformes As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents PlaniFeinesDataSet As PlaniFeinesOTS.PlaniFeinesDataSet
    Friend WithEvents ClientsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClientsTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ClientsTableAdapter
    Friend WithEvents TableAdapterManager As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LlocsTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.LlocsTableAdapter
    Friend WithEvents LlocsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecursosTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.RecursosTableAdapter
    Friend WithEvents RecursosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LlocsClientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DragCursor As gCursorLib.gCursor
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents RecursosDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Recursos_ComponentsTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.Recursos_ComponentsTableAdapter
    Friend WithEvents Recursos_ComponentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ServeisTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ServeisTableAdapter
    Friend WithEvents ServeisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServeisDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Llocs_ServeisTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.Llocs_ServeisTableAdapter
    Friend WithEvents Llocs_ServeisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cRecurs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cGrup As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tvClients As System.Windows.Forms.TreeView
    Friend WithEvents pnlClients As System.Windows.Forms.Panel
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents pnlLlocs As System.Windows.Forms.Panel
    Friend WithEvents lblLloc As System.Windows.Forms.Label
    Friend WithEvents pnlXecs As System.Windows.Forms.Panel
    Friend WithEvents lblXec As System.Windows.Forms.Label
    Friend WithEvents pnlServeis As System.Windows.Forms.Panel
    Friend WithEvents lblServei As System.Windows.Forms.Label
    Friend WithEvents XecsTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.XecsTableAdapter
    Friend WithEvents XecsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Clients_nomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_adreçaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_NIFTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_cccTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_xecsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Clients_data_altaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_telefonsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_codi_postalMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Clients_poblacioTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_observacionsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_emailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_nomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_telefonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_poblacioTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_adreçaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_diumengeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Llocs_dissabteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Llocs_ultim_dia_mesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Llocs_primer_dia_mesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Llocs_minuts_previstMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Llocs_observacionsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cmbDiesSetmana As System.Windows.Forms.ComboBox
    Friend WithEvents Llocs_dia_setmanaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Clients_nomTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Clients_nomTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Xecs_data_entregaDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Recursos_nomComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Serveis_nomComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Llocs_nomTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitat As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Llocs_quotaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_serveis_preu_unTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Llocs_serveis_quantitatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Xecs_idTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Xecs_valorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents txtQuants As System.Windows.Forms.TextBox
    Friend WithEvents Xecs_data_liquidatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Feines_idTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lblQuants As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvHoresExtra As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Llocs_periodicitat_diesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dtpSelMes As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSelClients As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkPdtFacturar As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPagaments As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvFactura As System.Windows.Forms.DataGridView
    Friend WithEvents dgvXecs As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalServeis As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalXecs As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNXecs As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFacturar As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirFacturacio As System.Windows.Forms.Button
    Friend WithEvents btnImprimirXecs As System.Windows.Forms.Button
    Friend WithEvents btnImprimirHores As System.Windows.Forms.Button
    Friend WithEvents cNomServei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUnitatServei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPreuServei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMinutsUnitat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cComuServei As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroXec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Client As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeinaXec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataLiquidat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServeiFeina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantitatFeina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitatFeina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportXec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimirAgenda As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSelClientInformes As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnInfHoresFetes As System.Windows.Forms.Button
    Friend WithEvents PlaniMonthViewFins As PlaniSoftwareControlLibrary.PlaniMonthView
    Friend WithEvents PlaniMonthViewDesDe As PlaniSoftwareControlLibrary.PlaniMonthView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalHores As System.Windows.Forms.TextBox
    Friend WithEvents Feina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lloc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recurs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Feta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataFra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Servei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantitat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unitat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportServei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimirHoresTotals As System.Windows.Forms.Button
    Friend WithEvents Llocs_horaComboBox As ComboBox
    Friend WithEvents txtNumFeina As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Calendari As PlaniMonthView
    Friend WithEvents LlocsSelDataGridView As DataGridView
    Friend WithEvents llocs_nom As DataGridViewTextBoxColumn
    Friend WithEvents clients_nom As DataGridViewTextBoxColumn
    Friend WithEvents llocs_adreça As DataGridViewTextBoxColumn
    Friend WithEvents llocs_poblacio As DataGridViewTextBoxColumn
    Friend WithEvents llocs_telefon As DataGridViewTextBoxColumn
    Friend WithEvents llocs_minuts_previst As DataGridViewTextBoxColumn
    Friend WithEvents llocs_periodicitat_dies As DataGridViewTextBoxColumn
    Friend WithEvents llocs_dia_setmana As DataGridViewTextBoxColumn
    Friend WithEvents llocs_dissabte As DataGridViewCheckBoxColumn
    Friend WithEvents llocs_diumenge As DataGridViewCheckBoxColumn
    Friend WithEvents llocs_hora As DataGridViewTextBoxColumn
    Friend WithEvents llocs_recursos_nom As DataGridViewTextBoxColumn
    Friend WithEvents llocs_observacions As DataGridViewTextBoxColumn
    Friend WithEvents llocs_quota As DataGridViewTextBoxColumn
    Friend WithEvents llocs_primer_dia_mes As DataGridViewCheckBoxColumn
    Friend WithEvents llocs_ultim_dia_mes As DataGridViewCheckBoxColumn
    Friend WithEvents RecursosSelDataGridView As DataGridView
    Friend WithEvents recursos_nom As DataGridViewTextBoxColumn
    Friend WithEvents recursos_grup As DataGridViewCheckBoxColumn
    Friend WithEvents recursos_color As DataGridViewTextBoxColumn
    Public WithEvents AgendaGrid As PlaniGrid
End Class
