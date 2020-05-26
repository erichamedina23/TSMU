<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelRequestDetail
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CDepartureDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.CArrivalDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtNIK = New DevExpress.XtraEditors.TextEdit()
        Me.txtNoRequest = New DevExpress.XtraEditors.TextEdit()
        Me.txtDepartement = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtTravelType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Destination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Negara = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CNegara = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Visa = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DepartureDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ArrivalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtGolongan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtPurpose = New DevExpress.XtraEditors.TextEdit()
        Me.GridAdvance = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAdvance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CostType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtAdvanceIDR = New DevExpress.XtraEditors.TextEdit()
        Me.txtAdvanceUSD = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAdvanceYEN = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CDepartureDate
        '
        Me.CDepartureDate.AutoHeight = False
        Me.CDepartureDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDepartureDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDepartureDate.Name = "CDepartureDate"
        Me.CDepartureDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'CArrivalDate
        '
        Me.CArrivalDate.AutoHeight = False
        Me.CArrivalDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CArrivalDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CArrivalDate.Name = "CArrivalDate"
        Me.CArrivalDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(1403, 86)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(124, 37)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add Detail ++"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtNIK
        '
        Me.txtNIK.EditValue = ""
        Me.txtNIK.Location = New System.Drawing.Point(466, 48)
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Properties.MaxLength = 9
        Me.txtNIK.Size = New System.Drawing.Size(105, 22)
        Me.txtNIK.TabIndex = 8
        '
        'txtNoRequest
        '
        Me.txtNoRequest.EditValue = ""
        Me.txtNoRequest.Enabled = False
        Me.txtNoRequest.Location = New System.Drawing.Point(120, 48)
        Me.txtNoRequest.Name = "txtNoRequest"
        Me.txtNoRequest.Size = New System.Drawing.Size(130, 22)
        Me.txtNoRequest.TabIndex = 7
        '
        'txtDepartement
        '
        Me.txtDepartement.EditValue = ""
        Me.txtDepartement.Enabled = False
        Me.txtDepartement.Location = New System.Drawing.Point(316, 48)
        Me.txtDepartement.Name = "txtDepartement"
        Me.txtDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtDepartement.Size = New System.Drawing.Size(83, 22)
        Me.txtDepartement.TabIndex = 5
        '
        'txtTravelType
        '
        Me.txtTravelType.EditValue = ""
        Me.txtTravelType.Location = New System.Drawing.Point(679, 88)
        Me.txtTravelType.Name = "txtTravelType"
        Me.txtTravelType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelType.Properties.Items.AddRange(New Object() {"DN", "LN"})
        Me.txtTravelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtTravelType.Size = New System.Drawing.Size(69, 22)
        Me.txtTravelType.TabIndex = 12
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1077, 94)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'GridDetail
        '
        Me.GridDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetail.Location = New System.Drawing.Point(25, 134)
        Me.GridDetail.MainView = Me.GridViewDetail
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CNegara})
        Me.GridDetail.Size = New System.Drawing.Size(1502, 520)
        Me.GridDetail.TabIndex = 2
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetail})
        '
        'GridViewDetail
        '
        Me.GridViewDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Destination, Me.Negara, Me.Visa, Me.DepartureDate, Me.ArrivalDate})
        Me.GridViewDetail.GridControl = Me.GridDetail
        Me.GridViewDetail.Name = "GridViewDetail"
        Me.GridViewDetail.OptionsView.ShowGroupPanel = False
        '
        'Destination
        '
        Me.Destination.Caption = "Destination"
        Me.Destination.FieldName = "Destination"
        Me.Destination.MinWidth = 25
        Me.Destination.Name = "Destination"
        Me.Destination.Visible = True
        Me.Destination.VisibleIndex = 0
        Me.Destination.Width = 863
        '
        'Negara
        '
        Me.Negara.Caption = "Negara"
        Me.Negara.ColumnEdit = Me.CNegara
        Me.Negara.FieldName = "Negara"
        Me.Negara.MinWidth = 25
        Me.Negara.Name = "Negara"
        Me.Negara.OptionsColumn.FixedWidth = True
        Me.Negara.Visible = True
        Me.Negara.VisibleIndex = 1
        Me.Negara.Width = 150
        '
        'CNegara
        '
        Me.CNegara.AutoHeight = False
        Me.CNegara.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CNegara.Name = "CNegara"
        Me.CNegara.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'Visa
        '
        Me.Visa.Caption = "Visa"
        Me.Visa.FieldName = "Visa"
        Me.Visa.MinWidth = 25
        Me.Visa.Name = "Visa"
        Me.Visa.Visible = True
        Me.Visa.VisibleIndex = 2
        Me.Visa.Width = 94
        '
        'DepartureDate
        '
        Me.DepartureDate.Caption = "Departure Date"
        Me.DepartureDate.ColumnEdit = Me.CDepartureDate
        Me.DepartureDate.FieldName = "DepartureDate"
        Me.DepartureDate.MinWidth = 25
        Me.DepartureDate.Name = "DepartureDate"
        Me.DepartureDate.OptionsColumn.FixedWidth = True
        Me.DepartureDate.Visible = True
        Me.DepartureDate.VisibleIndex = 3
        Me.DepartureDate.Width = 150
        '
        'ArrivalDate
        '
        Me.ArrivalDate.Caption = "Arrival Date"
        Me.ArrivalDate.ColumnEdit = Me.CArrivalDate
        Me.ArrivalDate.FieldName = "ArrivalDate"
        Me.ArrivalDate.MinWidth = 25
        Me.ArrivalDate.Name = "ArrivalDate"
        Me.ArrivalDate.OptionsColumn.FixedWidth = True
        Me.ArrivalDate.Visible = True
        Me.ArrivalDate.VisibleIndex = 4
        Me.ArrivalDate.Width = 150
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 16)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "No Request"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(272, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 16)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "Dept"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(424, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 16)
        Me.LabelControl3.TabIndex = 16
        Me.LabelControl3.Text = "NIK"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 91)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(33, 16)
        Me.LabelControl4.TabIndex = 17
        Me.LabelControl4.Text = "Nama"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(594, 51)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(53, 16)
        Me.LabelControl5.TabIndex = 18
        Me.LabelControl5.Text = "Golongan"
        '
        'txtNama
        '
        Me.txtNama.EditValue = ""
        Me.txtNama.Location = New System.Drawing.Point(120, 88)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Size = New System.Drawing.Size(451, 22)
        Me.txtNama.TabIndex = 4
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(784, 51)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 16)
        Me.LabelControl6.TabIndex = 19
        Me.LabelControl6.Text = "Pupose"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(594, 91)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(68, 16)
        Me.LabelControl8.TabIndex = 21
        Me.LabelControl8.Text = "Travel Type"
        '
        'txtGolongan
        '
        Me.txtGolongan.Location = New System.Drawing.Point(679, 48)
        Me.txtGolongan.Name = "txtGolongan"
        Me.txtGolongan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtGolongan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtGolongan.Size = New System.Drawing.Size(69, 22)
        Me.txtGolongan.TabIndex = 22
        '
        'txtPurpose
        '
        Me.txtPurpose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPurpose.Location = New System.Drawing.Point(848, 48)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(679, 22)
        Me.txtPurpose.TabIndex = 9
        '
        'GridAdvance
        '
        Me.GridAdvance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAdvance.Location = New System.Drawing.Point(6, 22)
        Me.GridAdvance.MainView = Me.GridViewAdvance
        Me.GridAdvance.Name = "GridAdvance"
        Me.GridAdvance.Size = New System.Drawing.Size(1490, 156)
        Me.GridAdvance.TabIndex = 23
        Me.GridAdvance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAdvance})
        '
        'GridViewAdvance
        '
        Me.GridViewAdvance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CostType, Me.Description, Me.GridColumn4, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GridViewAdvance.GridControl = Me.GridAdvance
        Me.GridViewAdvance.Name = "GridViewAdvance"
        Me.GridViewAdvance.OptionsBehavior.Editable = False
        Me.GridViewAdvance.OptionsBehavior.KeepGroupExpandedOnSorting = False
        Me.GridViewAdvance.OptionsBehavior.ReadOnly = True
        Me.GridViewAdvance.OptionsView.ShowGroupPanel = False
        '
        'CostType
        '
        Me.CostType.Caption = "Cost Type"
        Me.CostType.FieldName = "CostType"
        Me.CostType.MinWidth = 25
        Me.CostType.Name = "CostType"
        Me.CostType.Width = 94
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.FieldName = "Description"
        Me.Description.MinWidth = 25
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 0
        Me.Description.Width = 94
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Days"
        Me.GridColumn4.FieldName = "Days"
        Me.GridColumn4.MinWidth = 25
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 100
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Advance IDR"
        Me.GridColumn1.FieldName = "AdvanceIDR"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 200
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Advance USD"
        Me.GridColumn2.FieldName = "AdvanceUSD"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        Me.GridColumn2.Width = 200
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Advance YEN"
        Me.GridColumn3.FieldName = "AdvanceYEN"
        Me.GridColumn3.MinWidth = 25
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        Me.GridColumn3.Width = 200
        '
        'txtAdvanceIDR
        '
        Me.txtAdvanceIDR.EditValue = ""
        Me.txtAdvanceIDR.Location = New System.Drawing.Point(74, 19)
        Me.txtAdvanceIDR.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.Properties.Mask.EditMask = "n0"
        Me.txtAdvanceIDR.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceIDR.Properties.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceIDR.Size = New System.Drawing.Size(190, 22)
        Me.txtAdvanceIDR.TabIndex = 24
        '
        'txtAdvanceUSD
        '
        Me.txtAdvanceUSD.EditValue = ""
        Me.txtAdvanceUSD.Location = New System.Drawing.Point(331, 19)
        Me.txtAdvanceUSD.Name = "txtAdvanceUSD"
        Me.txtAdvanceUSD.Properties.Mask.EditMask = "n0"
        Me.txtAdvanceUSD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceUSD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceUSD.Size = New System.Drawing.Size(190, 22)
        Me.txtAdvanceUSD.TabIndex = 26
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(21, 22)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(21, 16)
        Me.LabelControl7.TabIndex = 28
        Me.LabelControl7.Text = "IDR"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(286, 22)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(24, 16)
        Me.LabelControl9.TabIndex = 29
        Me.LabelControl9.Text = "USD"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(550, 22)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(22, 16)
        Me.LabelControl10.TabIndex = 30
        Me.LabelControl10.Text = "YEN"
        '
        'txtAdvanceYEN
        '
        Me.txtAdvanceYEN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvanceYEN.EditValue = ""
        Me.txtAdvanceYEN.Location = New System.Drawing.Point(592, 19)
        Me.txtAdvanceYEN.MaximumSize = New System.Drawing.Size(190, 0)
        Me.txtAdvanceYEN.Name = "txtAdvanceYEN"
        Me.txtAdvanceYEN.Properties.Mask.EditMask = "n0"
        Me.txtAdvanceYEN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceYEN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceYEN.Size = New System.Drawing.Size(10, 22)
        Me.txtAdvanceYEN.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridAdvance)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 660)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1502, 184)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advance dan Pocket Allowance"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LabelControl9)
        Me.GroupBox2.Controls.Add(Me.LabelControl7)
        Me.GroupBox2.Controls.Add(Me.LabelControl10)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceYEN)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceIDR)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceUSD)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 7.6!)
        Me.GroupBox2.Location = New System.Drawing.Point(774, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 53)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Advance"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(311, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(275, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "l"
        '
        'FrmTravelRequestDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1552, 875)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtGolongan)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridDetail)
        Me.Controls.Add(Me.txtNoRequest)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.txtDepartement)
        Me.Controls.Add(Me.txtNIK)
        Me.Controls.Add(Me.txtTravelType)
        Me.Controls.Add(Me.txtNama)
        Me.Name = "FrmTravelRequestDetail"
        Me.Controls.SetChildIndex(Me.txtNama, 0)
        Me.Controls.SetChildIndex(Me.txtTravelType, 0)
        Me.Controls.SetChildIndex(Me.txtNIK, 0)
        Me.Controls.SetChildIndex(Me.txtDepartement, 0)
        Me.Controls.SetChildIndex(Me.txtPurpose, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.txtNoRequest, 0)
        Me.Controls.SetChildIndex(Me.GridDetail, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.Controls.SetChildIndex(Me.LabelControl4, 0)
        Me.Controls.SetChildIndex(Me.LabelControl5, 0)
        Me.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.Controls.SetChildIndex(Me.LabelControl8, 0)
        Me.Controls.SetChildIndex(Me.txtGolongan, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As Button
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtNoRequest As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DepartureDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ArrivalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Destination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtDepartement As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtNIK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTravelType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents Negara As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGolongan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtPurpose As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridAdvance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAdvance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtAdvanceIDR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAdvanceUSD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAdvanceYEN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Visa As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CNegara As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CDepartureDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CArrivalDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents CostType As DevExpress.XtraGrid.Columns.GridColumn
End Class
