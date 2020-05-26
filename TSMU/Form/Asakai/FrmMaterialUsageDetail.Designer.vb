<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMaterialUsageDetail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Material = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Jumlah = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Browse = New System.Windows.Forms.Button()
        Me.DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtPersentaseTarget = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPersentaseInjection = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAktualProduksi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPersentaseMaterial = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSalesRp = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAktualRp = New DevExpress.XtraEditors.TextEdit()
        Me.TxtIDMaterialUsage = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Quantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalHarga = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DataLayoutControl1.SuspendLayout()
        CType(Me.TxtPersentaseTarget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPersentaseInjection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAktualProduksi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPersentaseMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSalesRp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAktualRp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIDMaterialUsage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 132)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(644, 20)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.Material, Me.Qty, Me.Jumlah})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ID
        '
        Me.ID.FieldName = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = True
        Me.ID.VisibleIndex = 0
        '
        'Material
        '
        Me.Material.FieldName = "Material"
        Me.Material.Name = "Material"
        Me.Material.Visible = True
        Me.Material.VisibleIndex = 1
        '
        'Qty
        '
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 2
        '
        'Jumlah
        '
        Me.Jumlah.FieldName = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.Visible = True
        Me.Jumlah.VisibleIndex = 3
        '
        'Browse
        '
        Me.Browse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Browse.Location = New System.Drawing.Point(12, 435)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(75, 23)
        Me.Browse.TabIndex = 5
        Me.Browse.Text = "Browse File Excel"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'DataLayoutControl1
        '
        Me.DataLayoutControl1.Controls.Add(Me.Panel5)
        Me.DataLayoutControl1.Controls.Add(Me.Panel4)
        Me.DataLayoutControl1.Controls.Add(Me.Panel3)
        Me.DataLayoutControl1.Controls.Add(Me.Panel2)
        Me.DataLayoutControl1.Controls.Add(Me.Panel1)
        Me.DataLayoutControl1.Controls.Add(Me.TxtPersentaseTarget)
        Me.DataLayoutControl1.Controls.Add(Me.TxtPersentaseInjection)
        Me.DataLayoutControl1.Controls.Add(Me.TxtAktualProduksi)
        Me.DataLayoutControl1.Controls.Add(Me.TxtPersentaseMaterial)
        Me.DataLayoutControl1.Controls.Add(Me.TxtSalesRp)
        Me.DataLayoutControl1.Controls.Add(Me.TxtAktualRp)
        Me.DataLayoutControl1.Controls.Add(Me.TxtIDMaterialUsage)
        Me.DataLayoutControl1.Controls.Add(Me.TxtTanggal)
        Me.DataLayoutControl1.Location = New System.Drawing.Point(12, 12)
        Me.DataLayoutControl1.Name = "DataLayoutControl1"
        Me.DataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(716, 7, 650, 400)
        Me.DataLayoutControl1.Root = Me.LayoutControlGroup1
        Me.DataLayoutControl1.Size = New System.Drawing.Size(729, 149)
        Me.DataLayoutControl1.TabIndex = 4
        Me.DataLayoutControl1.Text = "DataLayoutControl1"
        '
        'Panel5
        '
        Me.Panel5.Location = New System.Drawing.Point(411, 108)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(306, 29)
        Me.Panel5.TabIndex = 15
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(411, 84)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(306, 20)
        Me.Panel4.TabIndex = 14
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(411, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(306, 20)
        Me.Panel3.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(212, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 20)
        Me.Panel2.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(212, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 20)
        Me.Panel1.TabIndex = 0
        '
        'TxtPersentaseTarget
        '
        Me.TxtPersentaseTarget.Location = New System.Drawing.Point(318, 108)
        Me.TxtPersentaseTarget.Name = "TxtPersentaseTarget"
        Me.TxtPersentaseTarget.Size = New System.Drawing.Size(89, 20)
        Me.TxtPersentaseTarget.StyleController = Me.DataLayoutControl1
        Me.TxtPersentaseTarget.TabIndex = 11
        Me.TxtPersentaseTarget.Visible = False
        '
        'TxtPersentaseInjection
        '
        Me.TxtPersentaseInjection.Enabled = False
        Me.TxtPersentaseInjection.Location = New System.Drawing.Point(318, 84)
        Me.TxtPersentaseInjection.Name = "TxtPersentaseInjection"
        Me.TxtPersentaseInjection.Size = New System.Drawing.Size(89, 20)
        Me.TxtPersentaseInjection.StyleController = Me.DataLayoutControl1
        Me.TxtPersentaseInjection.TabIndex = 10
        Me.TxtPersentaseInjection.Visible = False
        '
        'TxtAktualProduksi
        '
        Me.TxtAktualProduksi.Location = New System.Drawing.Point(318, 60)
        Me.TxtAktualProduksi.Name = "TxtAktualProduksi"
        Me.TxtAktualProduksi.Size = New System.Drawing.Size(89, 20)
        Me.TxtAktualProduksi.StyleController = Me.DataLayoutControl1
        Me.TxtAktualProduksi.TabIndex = 9
        '
        'TxtPersentaseMaterial
        '
        Me.TxtPersentaseMaterial.Enabled = False
        Me.TxtPersentaseMaterial.Location = New System.Drawing.Point(118, 108)
        Me.TxtPersentaseMaterial.Name = "TxtPersentaseMaterial"
        Me.TxtPersentaseMaterial.Size = New System.Drawing.Size(90, 20)
        Me.TxtPersentaseMaterial.StyleController = Me.DataLayoutControl1
        Me.TxtPersentaseMaterial.TabIndex = 8
        Me.TxtPersentaseMaterial.Visible = False
        '
        'TxtSalesRp
        '
        Me.TxtSalesRp.Location = New System.Drawing.Point(118, 84)
        Me.TxtSalesRp.Name = "TxtSalesRp"
        Me.TxtSalesRp.Size = New System.Drawing.Size(90, 20)
        Me.TxtSalesRp.StyleController = Me.DataLayoutControl1
        Me.TxtSalesRp.TabIndex = 7
        '
        'TxtAktualRp
        '
        Me.TxtAktualRp.Location = New System.Drawing.Point(118, 60)
        Me.TxtAktualRp.Name = "TxtAktualRp"
        Me.TxtAktualRp.Size = New System.Drawing.Size(90, 20)
        Me.TxtAktualRp.StyleController = Me.DataLayoutControl1
        Me.TxtAktualRp.TabIndex = 6
        '
        'TxtIDMaterialUsage
        '
        Me.TxtIDMaterialUsage.Location = New System.Drawing.Point(118, 12)
        Me.TxtIDMaterialUsage.Name = "TxtIDMaterialUsage"
        Me.TxtIDMaterialUsage.Size = New System.Drawing.Size(90, 20)
        Me.TxtIDMaterialUsage.StyleController = Me.DataLayoutControl1
        Me.TxtIDMaterialUsage.TabIndex = 4
        '
        'TxtTanggal
        '
        Me.TxtTanggal.EditValue = Nothing
        Me.TxtTanggal.Location = New System.Drawing.Point(118, 36)
        Me.TxtTanggal.Name = "TxtTanggal"
        Me.TxtTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTanggal.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTanggal.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTanggal.Properties.Mask.EditMask = ""
        Me.TxtTanggal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtTanggal.Size = New System.Drawing.Size(90, 20)
        Me.TxtTanggal.StyleController = Me.DataLayoutControl1
        Me.TxtTanggal.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(729, 149)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtIDMaterialUsage
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem2.Text = "ID Material Usage"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtTanggal
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem3.Text = "Tanggal"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtAktualRp
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem4.Text = "Aktual Rp"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtSalesRp
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem5.Text = "Sales Rp"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtPersentaseMaterial
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(200, 33)
        Me.LayoutControlItem6.Text = "Persentase %"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtAktualProduksi
        Me.LayoutControlItem7.Location = New System.Drawing.Point(200, 48)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(199, 24)
        Me.LayoutControlItem7.Text = "Aktual Produksi"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TxtPersentaseInjection
        Me.LayoutControlItem8.Location = New System.Drawing.Point(200, 72)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(199, 24)
        Me.LayoutControlItem8.Text = "Persentase Inject %"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TxtPersentaseTarget
        Me.LayoutControlItem9.Location = New System.Drawing.Point(200, 96)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(199, 33)
        Me.LayoutControlItem9.Text = "Persentase Target %"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(103, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.Panel1
        Me.LayoutControlItem10.Location = New System.Drawing.Point(200, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(509, 24)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.Panel2
        Me.LayoutControlItem11.Location = New System.Drawing.Point(200, 24)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(509, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.Panel3
        Me.LayoutControlItem12.Location = New System.Drawing.Point(399, 48)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.Panel4
        Me.LayoutControlItem13.Location = New System.Drawing.Point(399, 72)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(310, 24)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.Panel5
        Me.LayoutControlItem14.Location = New System.Drawing.Point(399, 96)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(310, 33)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(753, 173)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DataLayoutControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(733, 153)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.DataLayoutControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(5, 28)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(753, 173)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Grid1
        '
        Me.Grid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid1.Location = New System.Drawing.Point(12, 195)
        Me.Grid1.MainView = Me.GridView2
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(734, 234)
        Me.Grid1.TabIndex = 7
        Me.Grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDMaterial, Me.Description, Me.Quantity, Me.TotalHarga})
        Me.GridView2.GridControl = Me.Grid1
        Me.GridView2.Name = "GridView2"
        '
        'IDMaterial
        '
        Me.IDMaterial.FieldName = "IDMaterial"
        Me.IDMaterial.Name = "IDMaterial"
        Me.IDMaterial.Visible = True
        Me.IDMaterial.VisibleIndex = 0
        '
        'Description
        '
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 1
        '
        'Quantity
        '
        Me.Quantity.FieldName = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Visible = True
        Me.Quantity.VisibleIndex = 2
        '
        'TotalHarga
        '
        Me.TotalHarga.FieldName = "Total Harga"
        Me.TotalHarga.Name = "TotalHarga"
        Me.TotalHarga.Visible = True
        Me.TotalHarga.VisibleIndex = 3
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrmMaterialUsageDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(762, 470)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmMaterialUsageDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Browse, 0)
        Me.Controls.SetChildIndex(Me.Grid1, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DataLayoutControl1.ResumeLayout(False)
        CType(Me.TxtPersentaseTarget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPersentaseInjection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAktualProduksi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPersentaseMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSalesRp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAktualRp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIDMaterialUsage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Browse As Button
    Friend WithEvents ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Material As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Jumlah As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtPersentaseInjection As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAktualProduksi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPersentaseMaterial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtSalesRp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAktualRp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtIDMaterialUsage As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtPersentaseTarget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Quantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalHarga As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ErrorProvider As ErrorProvider
End Class
