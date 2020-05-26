<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Dim XrDesignPanelListener1 As DevExpress.XtraReports.UserDesigner.XRDesignPanelListener = New DevExpress.XtraReports.UserDesigner.XRDesignPanelListener()
        Me.XrDesignBarManager1 = New DevExpress.XtraReports.UserDesigner.XRDesignBarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RecentlyUsedItemsComboBox1 = New DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox()
        Me.DesignRepositoryItemComboBox1 = New DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnLoad = New System.Windows.Forms.ToolStripButton()
        Me.ProgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsBtn_newData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_delete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_excel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_filter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_preview = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtn_prev = New System.Windows.Forms.ToolStripButton()
        Me.tsBtn_next = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DocumentViewer1 = New DevExpress.XtraPrinting.Preview.DocumentViewer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._totalchk = New DevExpress.XtraEditors.TextEdit()
        Me.ReportDesigner1 = New DevExpress.XtraReports.UserDesigner.XRDesignMdiController(Me.components)
        Me.XpDataView1 = New DevExpress.Xpo.XPDataView(Me.components)
        Me.ViewDataSource1 = New DevExpress.Persistent.Base.ReportsV2.ViewDataSource()
        CType(Me.XrDesignBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me._totalchk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpDataView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XrDesignBarManager1
        '
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlTop)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.XrDesignBarManager1.DockControls.Add(Me.barDockControlRight)
        Me.XrDesignBarManager1.FontNameBox = Me.RecentlyUsedItemsComboBox1
        Me.XrDesignBarManager1.FontNameEdit = Nothing
        Me.XrDesignBarManager1.FontSizeBox = Me.DesignRepositoryItemComboBox1
        Me.XrDesignBarManager1.FontSizeEdit = Nothing
        Me.XrDesignBarManager1.Form = Me
        Me.XrDesignBarManager1.FormattingToolbar = Nothing
        Me.XrDesignBarManager1.HintStaticItem = Nothing
        Me.XrDesignBarManager1.ImageStream = CType(resources.GetObject("XrDesignBarManager1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.XrDesignBarManager1.LayoutToolbar = Nothing
        Me.XrDesignBarManager1.MaxItemId = 76
        Me.XrDesignBarManager1.Toolbar = Nothing
        Me.XrDesignBarManager1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.XrDesignBarManager1.Updates.AddRange(New String() {"Toolbox"})
        Me.XrDesignBarManager1.ZoomItem = Nothing
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.XrDesignBarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(828, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 581)
        Me.barDockControlBottom.Manager = Me.XrDesignBarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(828, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.XrDesignBarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 581)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(828, 0)
        Me.barDockControlRight.Manager = Me.XrDesignBarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 581)
        '
        'RecentlyUsedItemsComboBox1
        '
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Options.UseFont = True
        Me.RecentlyUsedItemsComboBox1.AutoHeight = False
        Me.RecentlyUsedItemsComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RecentlyUsedItemsComboBox1.DropDownRows = 12
        Me.RecentlyUsedItemsComboBox1.Name = "RecentlyUsedItemsComboBox1"
        '
        'DesignRepositoryItemComboBox1
        '
        Me.DesignRepositoryItemComboBox1.AutoHeight = False
        Me.DesignRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DesignRepositoryItemComboBox1.Name = "DesignRepositoryItemComboBox1"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoad, Me.ProgBar})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(790, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnLoad
        '
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(80, 22)
        Me.btnLoad.Text = "Load Data"
        '
        'ProgBar
        '
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(100, 22)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Until :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From :"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtn_newData, Me.ToolStripSeparator1, Me.tsBtn_save, Me.ToolStripSeparator2, Me.tsBtn_delete, Me.ToolStripSeparator3, Me.tsBtn_refresh, Me.ToolStripSeparator4, Me.tsBtn_excel, Me.ToolStripSeparator5, Me.tsBtn_filter, Me.ToolStripSeparator6, Me.tsBtn_preview, Me.ToolStripSeparator7, Me.tsBtn_print, Me.ToolStripSeparator8, Me.tsBtn_prev, Me.ToolStripSeparator9, Me.tsBtn_next})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(828, 25)
        Me.ToolStrip3.TabIndex = 12
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'tsBtn_newData
        '
        Me.tsBtn_newData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_newData.Enabled = False
        Me.tsBtn_newData.Image = CType(resources.GetObject("tsBtn_newData.Image"), System.Drawing.Image)
        Me.tsBtn_newData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_newData.Name = "tsBtn_newData"
        Me.tsBtn_newData.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_newData.Text = "New"
        Me.tsBtn_newData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_save
        '
        Me.tsBtn_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_save.Enabled = False
        Me.tsBtn_save.Image = CType(resources.GetObject("tsBtn_save.Image"), System.Drawing.Image)
        Me.tsBtn_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_save.Name = "tsBtn_save"
        Me.tsBtn_save.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_save.Text = "Save"
        Me.tsBtn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_delete
        '
        Me.tsBtn_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_delete.Enabled = False
        Me.tsBtn_delete.Image = CType(resources.GetObject("tsBtn_delete.Image"), System.Drawing.Image)
        Me.tsBtn_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_delete.Name = "tsBtn_delete"
        Me.tsBtn_delete.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_delete.Text = "Delete"
        Me.tsBtn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_refresh
        '
        Me.tsBtn_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_refresh.Enabled = False
        Me.tsBtn_refresh.Image = CType(resources.GetObject("tsBtn_refresh.Image"), System.Drawing.Image)
        Me.tsBtn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_refresh.Name = "tsBtn_refresh"
        Me.tsBtn_refresh.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_refresh.Text = "Refresh"
        Me.tsBtn_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_excel
        '
        Me.tsBtn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_excel.Image = CType(resources.GetObject("tsBtn_excel.Image"), System.Drawing.Image)
        Me.tsBtn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_excel.Name = "tsBtn_excel"
        Me.tsBtn_excel.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_excel.Text = "EXCEL"
        Me.tsBtn_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_filter
        '
        Me.tsBtn_filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_filter.Enabled = False
        Me.tsBtn_filter.Image = CType(resources.GetObject("tsBtn_filter.Image"), System.Drawing.Image)
        Me.tsBtn_filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_filter.Name = "tsBtn_filter"
        Me.tsBtn_filter.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_filter.Text = "Filter"
        Me.tsBtn_filter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_preview
        '
        Me.tsBtn_preview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_preview.Enabled = False
        Me.tsBtn_preview.Image = CType(resources.GetObject("tsBtn_preview.Image"), System.Drawing.Image)
        Me.tsBtn_preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_preview.Name = "tsBtn_preview"
        Me.tsBtn_preview.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_preview.Text = "Print Preview"
        Me.tsBtn_preview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_print
        '
        Me.tsBtn_print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_print.Enabled = False
        Me.tsBtn_print.Image = CType(resources.GetObject("tsBtn_print.Image"), System.Drawing.Image)
        Me.tsBtn_print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_print.Name = "tsBtn_print"
        Me.tsBtn_print.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_print.Text = "Print"
        Me.tsBtn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtn_prev
        '
        Me.tsBtn_prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_prev.Enabled = False
        Me.tsBtn_prev.Image = CType(resources.GetObject("tsBtn_prev.Image"), System.Drawing.Image)
        Me.tsBtn_prev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_prev.Name = "tsBtn_prev"
        Me.tsBtn_prev.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_prev.Text = "Prev"
        Me.tsBtn_prev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtn_next
        '
        Me.tsBtn_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtn_next.Enabled = False
        Me.tsBtn_next.Image = CType(resources.GetObject("tsBtn_next.Image"), System.Drawing.Image)
        Me.tsBtn_next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtn_next.Name = "tsBtn_next"
        Me.tsBtn_next.Size = New System.Drawing.Size(23, 22)
        Me.tsBtn_next.Text = "Next"
        Me.tsBtn_next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(6, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(804, 554)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DateEdit2)
        Me.TabPage1.Controls.Add(Me.DateEdit1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(796, 528)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Filter By Tgl"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(251, 7)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(143, 20)
        Me.DateEdit2.TabIndex = 18
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(48, 7)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(143, 20)
        Me.DateEdit1.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.DocumentViewer1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me._totalchk)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Location = New System.Drawing.Point(3, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 489)
        Me.Panel1.TabIndex = 16
        '
        'DocumentViewer1
        '
        Me.DocumentViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentViewer1.IsMetric = False
        Me.DocumentViewer1.Location = New System.Drawing.Point(0, 25)
        Me.DocumentViewer1.Name = "DocumentViewer1"
        Me.DocumentViewer1.Size = New System.Drawing.Size(790, 464)
        Me.DocumentViewer1.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(606, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Total Supplier :"
        Me.Label3.Visible = False
        '
        '_totalchk
        '
        Me._totalchk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._totalchk.Location = New System.Drawing.Point(690, 3)
        Me._totalchk.Name = "_totalchk"
        Me._totalchk.Size = New System.Drawing.Size(100, 20)
        Me._totalchk.TabIndex = 21
        Me._totalchk.Visible = False
        '
        'ReportDesigner1
        '
        Me.ReportDesigner1.ContainerControl = Nothing
        XrDesignPanelListener1.DesignControl = Me.XrDesignBarManager1
        Me.ReportDesigner1.DesignPanelListeners.AddRange(New DevExpress.XtraReports.UserDesigner.XRDesignPanelListener() {XrDesignPanelListener1})
        Me.ReportDesigner1.Form = Me
        '
        'ViewDataSource1
        '
        Me.ViewDataSource1.Name = "ViewDataSource1"
        Me.ViewDataSource1.ObjectTypeName = Nothing
        Me.ViewDataSource1.TopReturnedRecords = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.XrDesignBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me._totalchk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpDataView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnLoad As ToolStripButton
    Friend WithEvents ProgBar As ToolStripProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents tsBtn_newData As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsBtn_save As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsBtn_delete As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsBtn_refresh As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsBtn_excel As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsBtn_filter As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsBtn_preview As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsBtn_print As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsBtn_prev As ToolStripButton
    Friend WithEvents tsBtn_next As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Panel1 As Panel
    Friend WithEvents _totalchk As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ReportDesigner1 As DevExpress.XtraReports.UserDesigner.XRDesignMdiController
    Friend WithEvents XrDesignBarManager1 As DevExpress.XtraReports.UserDesigner.XRDesignBarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RecentlyUsedItemsComboBox1 As DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox
    Friend WithEvents DesignRepositoryItemComboBox1 As DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox
    Friend WithEvents XpDataView1 As DevExpress.Xpo.XPDataView
    Friend WithEvents ViewDataSource1 As DevExpress.Persistent.Base.ReportsV2.ViewDataSource
    Friend WithEvents Label3 As Label
    Friend WithEvents DocumentViewer1 As DevExpress.XtraPrinting.Preview.DocumentViewer
End Class
