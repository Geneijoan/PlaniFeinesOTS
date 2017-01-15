<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeina
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLloc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkFeta = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObservacions = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDataFra = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.txtHoraInici = New System.Windows.Forms.TextBox()
        Me.txtHoraFinal = New System.Windows.Forms.TextBox()
        Me.txtRecurs = New System.Windows.Forms.TextBox()
        Me.cmbServeis = New System.Windows.Forms.ComboBox()
        Me.ServeisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlaniFeinesDataSet = New PlaniFeinesOTS.PlaniFeinesDataSet()
        Me.ServeisTableAdapter = New PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ServeisTableAdapter()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtQuantitat = New System.Windows.Forms.TextBox()
        Me.txtUnitat = New System.Windows.Forms.TextBox()
        Me.txtPreu = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvDetall = New System.Windows.Forms.DataGridView()
        Me.clServei = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clQuantitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clUnitat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clPreu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMinuts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clComu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtMinuts = New System.Windows.Forms.TextBox()
        Me.txtComu = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ServeisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlaniFeinesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(276, 499)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(79, 12)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(100, 20)
        Me.txtId.TabIndex = 1
        Me.txtId.TabStop = False
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Id."
        '
        'txtLloc
        '
        Me.txtLloc.Location = New System.Drawing.Point(79, 65)
        Me.txtLloc.Name = "txtLloc"
        Me.txtLloc.ReadOnly = True
        Me.txtLloc.Size = New System.Drawing.Size(344, 20)
        Me.txtLloc.TabIndex = 3
        Me.txtLloc.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lloc"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(198, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Hora inici"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Final"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Recurs"
        '
        'chkFeta
        '
        Me.chkFeta.AutoSize = True
        Me.chkFeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFeta.Location = New System.Drawing.Point(12, 145)
        Me.chkFeta.Name = "chkFeta"
        Me.chkFeta.Size = New System.Drawing.Size(80, 17)
        Me.chkFeta.TabIndex = 13
        Me.chkFeta.Text = "Feta           "
        Me.chkFeta.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(241, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Data factura"
        '
        'txtObservacions
        '
        Me.txtObservacions.Location = New System.Drawing.Point(79, 169)
        Me.txtObservacions.MaxLength = 255
        Me.txtObservacions.Multiline = True
        Me.txtObservacions.Name = "txtObservacions"
        Me.txtObservacions.Size = New System.Drawing.Size(344, 77)
        Me.txtObservacions.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Observac."
        '
        'txtDataFra
        '
        Me.txtDataFra.Location = New System.Drawing.Point(313, 143)
        Me.txtDataFra.Name = "txtDataFra"
        Me.txtDataFra.ReadOnly = True
        Me.txtDataFra.Size = New System.Drawing.Size(110, 20)
        Me.txtDataFra.TabIndex = 18
        Me.txtDataFra.TabStop = False
        Me.txtDataFra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(79, 91)
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.Size = New System.Drawing.Size(100, 20)
        Me.txtData.TabIndex = 19
        Me.txtData.TabStop = False
        Me.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHoraInici
        '
        Me.txtHoraInici.Location = New System.Drawing.Point(255, 91)
        Me.txtHoraInici.Name = "txtHoraInici"
        Me.txtHoraInici.ReadOnly = True
        Me.txtHoraInici.Size = New System.Drawing.Size(55, 20)
        Me.txtHoraInici.TabIndex = 20
        Me.txtHoraInici.TabStop = False
        Me.txtHoraInici.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHoraFinal
        '
        Me.txtHoraFinal.Location = New System.Drawing.Point(367, 91)
        Me.txtHoraFinal.Name = "txtHoraFinal"
        Me.txtHoraFinal.ReadOnly = True
        Me.txtHoraFinal.Size = New System.Drawing.Size(55, 20)
        Me.txtHoraFinal.TabIndex = 21
        Me.txtHoraFinal.TabStop = False
        Me.txtHoraFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecurs
        '
        Me.txtRecurs.Location = New System.Drawing.Point(78, 117)
        Me.txtRecurs.Name = "txtRecurs"
        Me.txtRecurs.ReadOnly = True
        Me.txtRecurs.Size = New System.Drawing.Size(344, 20)
        Me.txtRecurs.TabIndex = 22
        Me.txtRecurs.TabStop = False
        '
        'cmbServeis
        '
        Me.cmbServeis.DataSource = Me.ServeisBindingSource
        Me.cmbServeis.DisplayMember = "serveis_nom"
        Me.cmbServeis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServeis.FormattingEnabled = True
        Me.cmbServeis.Location = New System.Drawing.Point(15, 272)
        Me.cmbServeis.Name = "cmbServeis"
        Me.cmbServeis.Size = New System.Drawing.Size(121, 21)
        Me.cmbServeis.TabIndex = 23
        Me.cmbServeis.ValueMember = "serveis_nom"
        '
        'ServeisBindingSource
        '
        Me.ServeisBindingSource.DataMember = "Serveis"
        Me.ServeisBindingSource.DataSource = Me.PlaniFeinesDataSet
        '
        'PlaniFeinesDataSet
        '
        Me.PlaniFeinesDataSet.DataSetName = "PlaniFeinesDataSet"
        Me.PlaniFeinesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ServeisTableAdapter
        '
        Me.ServeisTableAdapter.ClearBeforeFill = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 256)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Servei"
        '
        'txtQuantitat
        '
        Me.txtQuantitat.Location = New System.Drawing.Point(142, 272)
        Me.txtQuantitat.MaxLength = 12
        Me.txtQuantitat.Name = "txtQuantitat"
        Me.txtQuantitat.Size = New System.Drawing.Size(80, 20)
        Me.txtQuantitat.TabIndex = 25
        Me.txtQuantitat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnitat
        '
        Me.txtUnitat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServeisBindingSource, "serveis_unitat", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.txtUnitat.Location = New System.Drawing.Point(228, 272)
        Me.txtUnitat.Name = "txtUnitat"
        Me.txtUnitat.ReadOnly = True
        Me.txtUnitat.Size = New System.Drawing.Size(108, 20)
        Me.txtUnitat.TabIndex = 26
        Me.txtUnitat.TabStop = False
        Me.txtUnitat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPreu
        '
        Me.txtPreu.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServeisBindingSource, "serveis_preu_un", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.txtPreu.Location = New System.Drawing.Point(342, 272)
        Me.txtPreu.MaxLength = 12
        Me.txtPreu.Name = "txtPreu"
        Me.txtPreu.Size = New System.Drawing.Size(80, 20)
        Me.txtPreu.TabIndex = 27
        Me.txtPreu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(172, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Quantitat"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(262, 256)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Unitat"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(394, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Preu"
        '
        'dgvDetall
        '
        Me.dgvDetall.AllowUserToAddRows = False
        Me.dgvDetall.AllowUserToDeleteRows = False
        Me.dgvDetall.AllowUserToResizeColumns = False
        Me.dgvDetall.AllowUserToResizeRows = False
        Me.dgvDetall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetall.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDetall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetall.ColumnHeadersVisible = False
        Me.dgvDetall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clServei, Me.clQuantitat, Me.clUnitat, Me.clPreu, Me.clMinuts, Me.clComu})
        Me.dgvDetall.Location = New System.Drawing.Point(15, 299)
        Me.dgvDetall.MultiSelect = False
        Me.dgvDetall.Name = "dgvDetall"
        Me.dgvDetall.ReadOnly = True
        Me.dgvDetall.RowHeadersVisible = False
        Me.dgvDetall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetall.Size = New System.Drawing.Size(407, 170)
        Me.dgvDetall.TabIndex = 31
        '
        'clServei
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clServei.DefaultCellStyle = DataGridViewCellStyle1
        Me.clServei.Frozen = True
        Me.clServei.HeaderText = "Servei"
        Me.clServei.Name = "clServei"
        Me.clServei.ReadOnly = True
        Me.clServei.Width = 125
        '
        'clQuantitat
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.clQuantitat.DefaultCellStyle = DataGridViewCellStyle2
        Me.clQuantitat.Frozen = True
        Me.clQuantitat.HeaderText = "Quantitat"
        Me.clQuantitat.Name = "clQuantitat"
        Me.clQuantitat.ReadOnly = True
        Me.clQuantitat.Width = 85
        '
        'clUnitat
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clUnitat.DefaultCellStyle = DataGridViewCellStyle3
        Me.clUnitat.Frozen = True
        Me.clUnitat.HeaderText = "Unitat"
        Me.clUnitat.Name = "clUnitat"
        Me.clUnitat.ReadOnly = True
        Me.clUnitat.Width = 115
        '
        'clPreu
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clPreu.DefaultCellStyle = DataGridViewCellStyle4
        Me.clPreu.Frozen = True
        Me.clPreu.HeaderText = "Preu"
        Me.clPreu.Name = "clPreu"
        Me.clPreu.ReadOnly = True
        Me.clPreu.Width = 80
        '
        'clMinuts
        '
        Me.clMinuts.Frozen = True
        Me.clMinuts.HeaderText = "Minuts"
        Me.clMinuts.Name = "clMinuts"
        Me.clMinuts.ReadOnly = True
        Me.clMinuts.Visible = False
        '
        'clComu
        '
        Me.clComu.Frozen = True
        Me.clComu.HeaderText = "Comu"
        Me.clComu.Name = "clComu"
        Me.clComu.ReadOnly = True
        Me.clComu.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(241, 475)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "TOTAL FEINA"
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(323, 475)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(96, 20)
        Me.txtTotal.TabIndex = 33
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinuts
        '
        Me.txtMinuts.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServeisBindingSource, "serveis_minuts_per_unitat", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.txtMinuts.Location = New System.Drawing.Point(342, 272)
        Me.txtMinuts.Name = "txtMinuts"
        Me.txtMinuts.Size = New System.Drawing.Size(33, 20)
        Me.txtMinuts.TabIndex = 34
        '
        'txtComu
        '
        Me.txtComu.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServeisBindingSource, "serveis_comu_per_recursos", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.txtComu.Location = New System.Drawing.Point(381, 272)
        Me.txtComu.Name = "txtComu"
        Me.txtComu.Size = New System.Drawing.Size(42, 20)
        Me.txtComu.TabIndex = 35
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Client"
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(79, 39)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ReadOnly = True
        Me.txtClient.Size = New System.Drawing.Size(344, 20)
        Me.txtClient.TabIndex = 36
        Me.txtClient.TabStop = False
        '
        'frmFeina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(441, 540)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtClient)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvDetall)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPreu)
        Me.Controls.Add(Me.txtUnitat)
        Me.Controls.Add(Me.txtQuantitat)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbServeis)
        Me.Controls.Add(Me.txtRecurs)
        Me.Controls.Add(Me.txtHoraFinal)
        Me.Controls.Add(Me.txtHoraInici)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.txtDataFra)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtObservacions)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkFeta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLloc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtComu)
        Me.Controls.Add(Me.txtMinuts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFeina"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detall de Feina"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ServeisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlaniFeinesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLloc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkFeta As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtObservacions As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDataFra As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraInici As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtRecurs As System.Windows.Forms.TextBox
    Friend WithEvents cmbServeis As System.Windows.Forms.ComboBox
    Friend WithEvents PlaniFeinesDataSet As PlaniFeinesOTS.PlaniFeinesDataSet
    Friend WithEvents ServeisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServeisTableAdapter As PlaniFeinesOTS.PlaniFeinesDataSetTableAdapters.ServeisTableAdapter
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtQuantitat As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitat As System.Windows.Forms.TextBox
    Friend WithEvents txtPreu As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvDetall As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents clServei As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clQuantitat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clUnitat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clPreu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMinuts As System.Windows.Forms.TextBox
    Friend WithEvents txtComu As System.Windows.Forms.TextBox
    Friend WithEvents clMinuts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clComu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtClient As System.Windows.Forms.TextBox

End Class
