<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_NPP_Detail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Machine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cav = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Weight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Material = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Inj = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Painting = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Chrome = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Assy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StatusMold = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrderMonth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Ultrasonic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SingleCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TTargetQuot = New DevExpress.XtraEditors.DateEdit()
        Me.TTargetDr = New DevExpress.XtraEditors.DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TMp = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.B_AddRows = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBCkr = New System.Windows.Forms.CheckBox()
        Me.TModelDesc = New DevExpress.XtraEditors.TextEdit()
        Me.CBTng = New System.Windows.Forms.CheckBox()
        Me.CBStr = New System.Windows.Forms.CheckBox()
        Me.CBSample = New System.Windows.Forms.CheckBox()
        Me.CBCad = New System.Windows.Forms.CheckBox()
        Me.CBDrawing = New System.Windows.Forms.CheckBox()
        Me.TCategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TRevisi = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TOrderMaxMonth = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TOrderMonth = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TModel = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TNPP_No = New DevExpress.XtraEditors.TextEdit()
        Me.TCustomer = New DevExpress.XtraEditors.LookUpEdit()
        Me.TRevisiInformasi = New DevExpress.XtraEditors.TextEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BSetGroup = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SingleCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TTargetQuot.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTargetQuot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTargetDr.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTargetDr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TModelDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TRevisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOrderMaxMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOrderMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TModel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNPP_No.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRevisiInformasi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 142)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SingleCheck})
        Me.Grid.Size = New System.Drawing.Size(1339, 292)
        Me.Grid.TabIndex = 7
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PartNo, Me.PartName, Me.Machine, Me.CT, Me.Cav, Me.Weight, Me.Material, Me.Inj, Me.Painting, Me.Chrome, Me.Assy, Me.StatusMold, Me.OrderMonth, Me.Ultrasonic, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PartNo
        '
        Me.PartNo.FieldName = "Part No"
        Me.PartNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.PartNo.Name = "PartNo"
        Me.PartNo.OptionsColumn.AllowEdit = False
        Me.PartNo.Visible = True
        Me.PartNo.VisibleIndex = 0
        Me.PartNo.Width = 167
        '
        'PartName
        '
        Me.PartName.FieldName = "Part Name"
        Me.PartName.Name = "PartName"
        Me.PartName.Visible = True
        Me.PartName.VisibleIndex = 1
        Me.PartName.Width = 190
        '
        'Machine
        '
        Me.Machine.FieldName = "Machine"
        Me.Machine.Name = "Machine"
        Me.Machine.Visible = True
        Me.Machine.VisibleIndex = 2
        Me.Machine.Width = 66
        '
        'CT
        '
        Me.CT.AppearanceCell.Options.UseTextOptions = True
        Me.CT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CT.AppearanceHeader.Options.UseTextOptions = True
        Me.CT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CT.FieldName = "C/T"
        Me.CT.Name = "CT"
        Me.CT.Visible = True
        Me.CT.VisibleIndex = 3
        Me.CT.Width = 71
        '
        'Cav
        '
        Me.Cav.AppearanceCell.Options.UseTextOptions = True
        Me.Cav.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Cav.AppearanceHeader.Options.UseTextOptions = True
        Me.Cav.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Cav.FieldName = "Cav"
        Me.Cav.Name = "Cav"
        Me.Cav.Visible = True
        Me.Cav.VisibleIndex = 4
        Me.Cav.Width = 65
        '
        'Weight
        '
        Me.Weight.AppearanceCell.Options.UseTextOptions = True
        Me.Weight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Weight.AppearanceHeader.Options.UseTextOptions = True
        Me.Weight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Weight.FieldName = "Weight"
        Me.Weight.Name = "Weight"
        Me.Weight.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Weight.Visible = True
        Me.Weight.VisibleIndex = 5
        Me.Weight.Width = 83
        '
        'Material
        '
        Me.Material.AppearanceCell.Options.UseTextOptions = True
        Me.Material.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Material.AppearanceHeader.Options.UseTextOptions = True
        Me.Material.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Material.FieldName = "Material"
        Me.Material.Name = "Material"
        Me.Material.Visible = True
        Me.Material.VisibleIndex = 6
        Me.Material.Width = 147
        '
        'Inj
        '
        Me.Inj.AppearanceCell.Options.UseTextOptions = True
        Me.Inj.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Inj.AppearanceHeader.Options.UseTextOptions = True
        Me.Inj.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Inj.FieldName = "Inj"
        Me.Inj.Name = "Inj"
        Me.Inj.Visible = True
        Me.Inj.VisibleIndex = 7
        '
        'Painting
        '
        Me.Painting.AppearanceCell.Options.UseTextOptions = True
        Me.Painting.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Painting.AppearanceHeader.Options.UseTextOptions = True
        Me.Painting.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Painting.FieldName = "Painting"
        Me.Painting.Name = "Painting"
        Me.Painting.Visible = True
        Me.Painting.VisibleIndex = 8
        '
        'Chrome
        '
        Me.Chrome.AppearanceCell.Options.UseTextOptions = True
        Me.Chrome.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Chrome.AppearanceHeader.Options.UseTextOptions = True
        Me.Chrome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Chrome.FieldName = "Chrome"
        Me.Chrome.Name = "Chrome"
        Me.Chrome.Visible = True
        Me.Chrome.VisibleIndex = 9
        Me.Chrome.Width = 81
        '
        'Assy
        '
        Me.Assy.AppearanceCell.Options.UseTextOptions = True
        Me.Assy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Assy.AppearanceHeader.Options.UseTextOptions = True
        Me.Assy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Assy.FieldName = "Assy"
        Me.Assy.Name = "Assy"
        Me.Assy.Visible = True
        Me.Assy.VisibleIndex = 10
        '
        'StatusMold
        '
        Me.StatusMold.AppearanceCell.Options.UseTextOptions = True
        Me.StatusMold.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StatusMold.AppearanceHeader.Options.UseTextOptions = True
        Me.StatusMold.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StatusMold.FieldName = "Status Mold"
        Me.StatusMold.Name = "StatusMold"
        Me.StatusMold.Visible = True
        Me.StatusMold.VisibleIndex = 13
        Me.StatusMold.Width = 145
        '
        'OrderMonth
        '
        Me.OrderMonth.AppearanceCell.Options.UseTextOptions = True
        Me.OrderMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OrderMonth.AppearanceHeader.Options.UseTextOptions = True
        Me.OrderMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OrderMonth.FieldName = "Order Month"
        Me.OrderMonth.Name = "OrderMonth"
        Me.OrderMonth.Visible = True
        Me.OrderMonth.VisibleIndex = 14
        Me.OrderMonth.Width = 130
        '
        'Ultrasonic
        '
        Me.Ultrasonic.AppearanceCell.Options.UseTextOptions = True
        Me.Ultrasonic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Ultrasonic.AppearanceHeader.Options.UseTextOptions = True
        Me.Ultrasonic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Ultrasonic.FieldName = "Ultrasonic"
        Me.Ultrasonic.Name = "Ultrasonic"
        Me.Ultrasonic.Visible = True
        Me.Ultrasonic.VisibleIndex = 11
        Me.Ultrasonic.Width = 82
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.FieldName = "Vibration"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 12
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.ColumnEdit = Me.SingleCheck
        Me.GridColumn2.FieldName = "Single"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 15
        '
        'SingleCheck
        '
        Me.SingleCheck.AutoHeight = False
        Me.SingleCheck.Name = "SingleCheck"
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.FieldName = "Group ID"
        Me.GridColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 16
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "ID"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TTargetQuot)
        Me.GroupBox1.Controls.Add(Me.TTargetDr)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TMp)
        Me.GroupBox1.Location = New System.Drawing.Point(988, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 102)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Schedule"
        '
        'TTargetQuot
        '
        Me.TTargetQuot.EditValue = Nothing
        Me.TTargetQuot.Location = New System.Drawing.Point(115, 65)
        Me.TTargetQuot.Name = "TTargetQuot"
        Me.TTargetQuot.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TTargetQuot.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TTargetQuot.Size = New System.Drawing.Size(131, 20)
        Me.TTargetQuot.TabIndex = 41
        '
        'TTargetDr
        '
        Me.TTargetDr.EditValue = Nothing
        Me.TTargetDr.Location = New System.Drawing.Point(115, 43)
        Me.TTargetDr.Name = "TTargetDr"
        Me.TTargetDr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TTargetDr.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TTargetDr.Size = New System.Drawing.Size(131, 20)
        Me.TTargetDr.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Target Quotation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Target DR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "MassPro"
        '
        'TMp
        '
        Me.TMp.Location = New System.Drawing.Point(115, 19)
        Me.TMp.Name = "TMp"
        Me.TMp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TMp.Properties.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035"})
        Me.TMp.Size = New System.Drawing.Size(131, 20)
        Me.TMp.TabIndex = 36
        '
        'B_AddRows
        '
        Me.B_AddRows.Location = New System.Drawing.Point(17, 73)
        Me.B_AddRows.Name = "B_AddRows"
        Me.B_AddRows.Size = New System.Drawing.Size(64, 21)
        Me.B_AddRows.TabIndex = 8
        Me.B_AddRows.Text = "Add Detail"
        Me.B_AddRows.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.CBCkr)
        Me.GroupBox2.Controls.Add(Me.TModelDesc)
        Me.GroupBox2.Controls.Add(Me.CBTng)
        Me.GroupBox2.Controls.Add(Me.B_AddRows)
        Me.GroupBox2.Controls.Add(Me.CBStr)
        Me.GroupBox2.Controls.Add(Me.CBSample)
        Me.GroupBox2.Controls.Add(Me.CBCad)
        Me.GroupBox2.Controls.Add(Me.CBDrawing)
        Me.GroupBox2.Controls.Add(Me.TCategory)
        Me.GroupBox2.Location = New System.Drawing.Point(450, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 102)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Technical Info (Available)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Class Category"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Model Desc"
        '
        'CBCkr
        '
        Me.CBCkr.AutoSize = True
        Me.CBCkr.Location = New System.Drawing.Point(366, 73)
        Me.CBCkr.Name = "CBCkr"
        Me.CBCkr.Size = New System.Drawing.Size(72, 17)
        Me.CBCkr.TabIndex = 43
        Me.CBCkr.Text = "TSC CKR"
        Me.CBCkr.UseVisualStyleBackColor = True
        '
        'TModelDesc
        '
        Me.TModelDesc.Location = New System.Drawing.Point(97, 45)
        Me.TModelDesc.Name = "TModelDesc"
        Me.TModelDesc.Properties.MaxLength = 30
        Me.TModelDesc.Size = New System.Drawing.Size(344, 20)
        Me.TModelDesc.TabIndex = 31
        '
        'CBTng
        '
        Me.CBTng.AutoSize = True
        Me.CBTng.Location = New System.Drawing.Point(446, 73)
        Me.CBTng.Name = "CBTng"
        Me.CBTng.Size = New System.Drawing.Size(73, 17)
        Me.CBTng.TabIndex = 42
        Me.CBTng.Text = "TSC TNG"
        Me.CBTng.UseVisualStyleBackColor = True
        '
        'CBStr
        '
        Me.CBStr.AutoSize = True
        Me.CBStr.Location = New System.Drawing.Point(308, 73)
        Me.CBStr.Name = "CBStr"
        Me.CBStr.Size = New System.Drawing.Size(48, 17)
        Me.CBStr.TabIndex = 41
        Me.CBStr.Text = "STR"
        Me.CBStr.UseVisualStyleBackColor = True
        '
        'CBSample
        '
        Me.CBSample.AutoSize = True
        Me.CBSample.Location = New System.Drawing.Point(245, 73)
        Me.CBSample.Name = "CBSample"
        Me.CBSample.Size = New System.Drawing.Size(61, 17)
        Me.CBSample.TabIndex = 40
        Me.CBSample.Text = "Sampel"
        Me.CBSample.UseVisualStyleBackColor = True
        '
        'CBCad
        '
        Me.CBCad.AutoSize = True
        Me.CBCad.Location = New System.Drawing.Point(164, 73)
        Me.CBCad.Name = "CBCad"
        Me.CBCad.Size = New System.Drawing.Size(71, 17)
        Me.CBCad.TabIndex = 39
        Me.CBCad.Text = "Cad Data"
        Me.CBCad.UseVisualStyleBackColor = True
        '
        'CBDrawing
        '
        Me.CBDrawing.AutoSize = True
        Me.CBDrawing.Location = New System.Drawing.Point(98, 73)
        Me.CBDrawing.Name = "CBDrawing"
        Me.CBDrawing.Size = New System.Drawing.Size(65, 17)
        Me.CBDrawing.TabIndex = 38
        Me.CBDrawing.Text = "Drawing"
        Me.CBDrawing.UseVisualStyleBackColor = True
        '
        'TCategory
        '
        Me.TCategory.Location = New System.Drawing.Point(97, 23)
        Me.TCategory.Name = "TCategory"
        Me.TCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TCategory.Properties.DropDownRows = 4
        Me.TCategory.Properties.NullText = ""
        Me.TCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TCategory.Size = New System.Drawing.Size(429, 20)
        Me.TCategory.TabIndex = 44
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TRevisi)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TOrderMaxMonth)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TOrderMonth)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TModel)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TNPP_No)
        Me.GroupBox3.Controls.Add(Me.TCustomer)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 102)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Model Information "
        '
        'TRevisi
        '
        Me.TRevisi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TRevisi.Enabled = False
        Me.TRevisi.Location = New System.Drawing.Point(392, 23)
        Me.TRevisi.Name = "TRevisi"
        Me.TRevisi.Size = New System.Drawing.Size(28, 20)
        Me.TRevisi.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(252, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Order Max (M)"
        '
        'TOrderMaxMonth
        '
        Me.TOrderMaxMonth.Location = New System.Drawing.Point(328, 70)
        Me.TOrderMaxMonth.Name = "TOrderMaxMonth"
        Me.TOrderMaxMonth.Properties.DisplayFormat.FormatString = "{0:N0}"
        Me.TOrderMaxMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOrderMaxMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOrderMaxMonth.Size = New System.Drawing.Size(92, 20)
        Me.TOrderMaxMonth.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Order  (M)"
        '
        'TOrderMonth
        '
        Me.TOrderMonth.Location = New System.Drawing.Point(328, 47)
        Me.TOrderMonth.Name = "TOrderMonth"
        Me.TOrderMonth.Properties.DisplayFormat.FormatString = "{0:N0}"
        Me.TOrderMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOrderMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOrderMonth.Size = New System.Drawing.Size(92, 20)
        Me.TOrderMonth.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Model"
        '
        'TModel
        '
        Me.TModel.Location = New System.Drawing.Point(76, 70)
        Me.TModel.Name = "TModel"
        Me.TModel.Properties.MaxLength = 6
        Me.TModel.Size = New System.Drawing.Size(171, 20)
        Me.TModel.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "NPP NO"
        '
        'TNPP_No
        '
        Me.TNPP_No.Enabled = False
        Me.TNPP_No.Location = New System.Drawing.Point(76, 23)
        Me.TNPP_No.Name = "TNPP_No"
        Me.TNPP_No.Size = New System.Drawing.Size(310, 20)
        Me.TNPP_No.TabIndex = 21
        '
        'TCustomer
        '
        Me.TCustomer.Location = New System.Drawing.Point(76, 47)
        Me.TCustomer.Name = "TCustomer"
        Me.TCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TCustomer.Properties.DropDownRows = 10
        Me.TCustomer.Properties.MaxLength = 6
        Me.TCustomer.Properties.NullText = ""
        Me.TCustomer.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TCustomer.Properties.PopupSizeable = False
        Me.TCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TCustomer.Size = New System.Drawing.Size(171, 20)
        Me.TCustomer.TabIndex = 23
        '
        'TRevisiInformasi
        '
        Me.TRevisiInformasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TRevisiInformasi.Location = New System.Drawing.Point(129, 440)
        Me.TRevisiInformasi.Name = "TRevisiInformasi"
        Me.TRevisiInformasi.Properties.MaxLength = 100
        Me.TRevisiInformasi.Size = New System.Drawing.Size(269, 20)
        Me.TRevisiInformasi.TabIndex = 33
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 443)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Revision Information"
        '
        'BSetGroup
        '
        Me.BSetGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BSetGroup.Location = New System.Drawing.Point(1276, 443)
        Me.BSetGroup.Name = "BSetGroup"
        Me.BSetGroup.Size = New System.Drawing.Size(75, 23)
        Me.BSetGroup.TabIndex = 34
        Me.BSetGroup.Text = "Set Group"
        Me.BSetGroup.UseVisualStyleBackColor = True
        '
        'Frm_NPP_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1363, 472)
        Me.Controls.Add(Me.BSetGroup)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TRevisiInformasi)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Grid)
        Me.Name = "Frm_NPP_Detail"
        Me.Text = " "
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.TRevisiInformasi, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.BSetGroup, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SingleCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TTargetQuot.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTargetQuot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTargetDr.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTargetDr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TModelDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TRevisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOrderMaxMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOrderMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TModel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNPP_No.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRevisiInformasi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents PartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Machine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cav As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Weight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Material As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Inj As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Painting As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Chrome As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Assy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StatusMold As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrderMonth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CBStr As CheckBox
    Friend WithEvents CBSample As CheckBox
    Friend WithEvents CBCad As CheckBox
    Friend WithEvents CBDrawing As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TOrderMaxMonth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents TOrderMonth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TModel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CBCkr As CheckBox
    Friend WithEvents CBTng As CheckBox
    Friend WithEvents B_AddRows As Button
    Friend WithEvents TCustomer As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TCategory As DevExpress.XtraEditors.LookUpEdit
    Public WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents TNPP_No As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TRevisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TRevisiInformasi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label11 As Label
    Friend WithEvents TTargetQuot As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TTargetDr As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TMp As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Ultrasonic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents TModelDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SingleCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BSetGroup As Button
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
