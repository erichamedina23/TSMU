<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMaterialPainting
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtProduksiOKAll = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtProduksiOKPaint = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTotalLiter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAkumulasiPemakaianLiter = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtAktualRp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTotalRP = New System.Windows.Forms.TextBox()
        Me.BBrowse = New System.Windows.Forms.Button()
        Me.txtPercentPainting = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtAktualLiter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPercentTarget = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT = New System.Windows.Forms.Label()
        Me.TxtPercentAll = New System.Windows.Forms.TextBox()
        Me.TxtProduksiOKInj = New System.Windows.Forms.TextBox()
        Me.TxtPercentSales = New System.Windows.Forms.TextBox()
        Me.TxtSales = New System.Windows.Forms.TextBox()
        Me.TxtAkumulasiPemakaianRp = New System.Windows.Forms.TextBox()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.InvtID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Material = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAwalTNG02 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAwalTNG04 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Masuk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAwalTNG04BelumKonv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalStokAwal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAkhirTNG02 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAkhirTNG04 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAkhirTNG04UTUH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockAkhirTNG04Pecahan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalStokAhir4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalStokAkhir = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PemakaianNonProduksi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pemakaian = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Harga = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtProduksiOKAll)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtProduksiOKPaint)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtTotalLiter)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtAkumulasiPemakaianLiter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtAktualRp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtTotalRP)
        Me.GroupBox1.Controls.Add(Me.BBrowse)
        Me.GroupBox1.Controls.Add(Me.txtPercentPainting)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtAktualLiter)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPercentTarget)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXT)
        Me.GroupBox1.Controls.Add(Me.TxtPercentAll)
        Me.GroupBox1.Controls.Add(Me.TxtProduksiOKInj)
        Me.GroupBox1.Controls.Add(Me.TxtPercentSales)
        Me.GroupBox1.Controls.Add(Me.TxtSales)
        Me.GroupBox1.Controls.Add(Me.TxtAkumulasiPemakaianRp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1159, 188)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(576, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Produksi OK All"
        '
        'TxtProduksiOKAll
        '
        Me.TxtProduksiOKAll.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProduksiOKAll.Location = New System.Drawing.Point(691, 74)
        Me.TxtProduksiOKAll.Name = "TxtProduksiOKAll"
        Me.TxtProduksiOKAll.ReadOnly = True
        Me.TxtProduksiOKAll.Size = New System.Drawing.Size(100, 20)
        Me.TxtProduksiOKAll.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(576, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Produksi OK Painting"
        '
        'TxtProduksiOKPaint
        '
        Me.TxtProduksiOKPaint.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProduksiOKPaint.Location = New System.Drawing.Point(691, 48)
        Me.TxtProduksiOKPaint.Name = "TxtProduksiOKPaint"
        Me.TxtProduksiOKPaint.ReadOnly = True
        Me.TxtProduksiOKPaint.Size = New System.Drawing.Size(100, 20)
        Me.TxtProduksiOKPaint.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Total Liter / Kg"
        '
        'TxtTotalLiter
        '
        Me.TxtTotalLiter.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalLiter.Location = New System.Drawing.Point(442, 22)
        Me.TxtTotalLiter.Name = "TxtTotalLiter"
        Me.TxtTotalLiter.ReadOnly = True
        Me.TxtTotalLiter.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalLiter.TabIndex = 60
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(280, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Akumulasi Pemakaian Liter / Kg"
        '
        'TxtAkumulasiPemakaianLiter
        '
        Me.TxtAkumulasiPemakaianLiter.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAkumulasiPemakaianLiter.Location = New System.Drawing.Point(442, 48)
        Me.TxtAkumulasiPemakaianLiter.Name = "TxtAkumulasiPemakaianLiter"
        Me.TxtAkumulasiPemakaianLiter.ReadOnly = True
        Me.TxtAkumulasiPemakaianLiter.Size = New System.Drawing.Size(100, 20)
        Me.TxtAkumulasiPemakaianLiter.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Aktual Rp"
        '
        'TxtAktualRp
        '
        Me.TxtAktualRp.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAktualRp.Location = New System.Drawing.Point(152, 75)
        Me.TxtAktualRp.Name = "TxtAktualRp"
        Me.TxtAktualRp.ReadOnly = True
        Me.TxtAktualRp.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualRp.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Total Aktual Rp"
        '
        'TxtTotalRP
        '
        Me.TxtTotalRP.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalRP.Location = New System.Drawing.Point(152, 19)
        Me.TxtTotalRP.Name = "TxtTotalRP"
        Me.TxtTotalRP.ReadOnly = True
        Me.TxtTotalRP.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalRP.TabIndex = 54
        '
        'BBrowse
        '
        Me.BBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BBrowse.Location = New System.Drawing.Point(1043, 19)
        Me.BBrowse.Name = "BBrowse"
        Me.BBrowse.Size = New System.Drawing.Size(110, 23)
        Me.BBrowse.TabIndex = 53
        Me.BBrowse.Text = "Browse Excel"
        Me.BBrowse.UseVisualStyleBackColor = True
        '
        'txtPercentPainting
        '
        Me.txtPercentPainting.BackColor = System.Drawing.SystemColors.Window
        Me.txtPercentPainting.Location = New System.Drawing.Point(940, 78)
        Me.txtPercentPainting.Name = "txtPercentPainting"
        Me.txtPercentPainting.ReadOnly = True
        Me.txtPercentPainting.Size = New System.Drawing.Size(100, 20)
        Me.txtPercentPainting.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(839, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "% Painting"
        '
        'TxtAktualLiter
        '
        Me.TxtAktualLiter.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAktualLiter.Location = New System.Drawing.Point(442, 74)
        Me.TxtAktualLiter.Name = "TxtAktualLiter"
        Me.TxtAktualLiter.ReadOnly = True
        Me.TxtAktualLiter.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualLiter.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(280, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Aktual (Liter/Kg)"
        '
        'TxtPercentTarget
        '
        Me.TxtPercentTarget.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPercentTarget.Location = New System.Drawing.Point(940, 52)
        Me.TxtPercentTarget.Name = "TxtPercentTarget"
        Me.TxtPercentTarget.ReadOnly = True
        Me.TxtPercentTarget.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercentTarget.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(839, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "% Target"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(839, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "% ALL"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(576, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Produksi OK Injection"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Sales"
        '
        'TXT
        '
        Me.TXT.AutoSize = True
        Me.TXT.Location = New System.Drawing.Point(19, 48)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(128, 13)
        Me.TXT.TabIndex = 22
        Me.TXT.Text = "Akumulasi Pemakaian Rp"
        '
        'TxtPercentAll
        '
        Me.TxtPercentAll.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPercentAll.Location = New System.Drawing.Point(940, 22)
        Me.TxtPercentAll.Name = "TxtPercentAll"
        Me.TxtPercentAll.ReadOnly = True
        Me.TxtPercentAll.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercentAll.TabIndex = 20
        '
        'TxtProduksiOKInj
        '
        Me.TxtProduksiOKInj.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProduksiOKInj.Location = New System.Drawing.Point(691, 22)
        Me.TxtProduksiOKInj.Name = "TxtProduksiOKInj"
        Me.TxtProduksiOKInj.ReadOnly = True
        Me.TxtProduksiOKInj.Size = New System.Drawing.Size(100, 20)
        Me.TxtProduksiOKInj.TabIndex = 19
        '
        'TxtPercentSales
        '
        Me.TxtPercentSales.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPercentSales.Location = New System.Drawing.Point(152, 134)
        Me.TxtPercentSales.Name = "TxtPercentSales"
        Me.TxtPercentSales.ReadOnly = True
        Me.TxtPercentSales.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercentSales.TabIndex = 18
        '
        'TxtSales
        '
        Me.TxtSales.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSales.Location = New System.Drawing.Point(152, 108)
        Me.TxtSales.Name = "TxtSales"
        Me.TxtSales.ReadOnly = True
        Me.TxtSales.Size = New System.Drawing.Size(100, 20)
        Me.TxtSales.TabIndex = 17
        '
        'TxtAkumulasiPemakaianRp
        '
        Me.TxtAkumulasiPemakaianRp.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAkumulasiPemakaianRp.Location = New System.Drawing.Point(152, 45)
        Me.TxtAkumulasiPemakaianRp.Name = "TxtAkumulasiPemakaianRp"
        Me.TxtAkumulasiPemakaianRp.ReadOnly = True
        Me.TxtAkumulasiPemakaianRp.Size = New System.Drawing.Size(100, 20)
        Me.TxtAkumulasiPemakaianRp.TabIndex = 16
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 222)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1159, 236)
        Me.Grid.TabIndex = 21
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.InvtID, Me.Material, Me.StockAwalTNG02, Me.StockAwalTNG04, Me.Masuk, Me.StockAwalTNG04BelumKonv, Me.TotalStokAwal, Me.StockAkhirTNG02, Me.StockAkhirTNG04, Me.StockAkhirTNG04UTUH, Me.StockAkhirTNG04Pecahan, Me.TotalStokAhir4, Me.TotalStokAkhir, Me.PemakaianNonProduksi, Me.Pemakaian, Me.Harga, Me.Amount})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'InvtID
        '
        Me.InvtID.FieldName = "InvtID"
        Me.InvtID.Name = "InvtID"
        Me.InvtID.Visible = True
        Me.InvtID.VisibleIndex = 0
        Me.InvtID.Width = 48
        '
        'Material
        '
        Me.Material.FieldName = "Material"
        Me.Material.Name = "Material"
        Me.Material.Visible = True
        Me.Material.VisibleIndex = 1
        Me.Material.Width = 48
        '
        'StockAwalTNG02
        '
        Me.StockAwalTNG02.FieldName = "StockAwal02"
        Me.StockAwalTNG02.Name = "StockAwalTNG02"
        Me.StockAwalTNG02.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAwal02", "SUM={0:0.##}")})
        Me.StockAwalTNG02.Visible = True
        Me.StockAwalTNG02.VisibleIndex = 2
        Me.StockAwalTNG02.Width = 48
        '
        'StockAwalTNG04
        '
        Me.StockAwalTNG04.FieldName = "StockAwal04"
        Me.StockAwalTNG04.Name = "StockAwalTNG04"
        Me.StockAwalTNG04.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAwal04", "SUM={0:0.##}")})
        Me.StockAwalTNG04.Visible = True
        Me.StockAwalTNG04.VisibleIndex = 3
        Me.StockAwalTNG04.Width = 48
        '
        'Masuk
        '
        Me.Masuk.FieldName = "Masuk"
        Me.Masuk.Name = "Masuk"
        Me.Masuk.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Masuk", "SUM={0:0.##}")})
        Me.Masuk.Visible = True
        Me.Masuk.VisibleIndex = 5
        Me.Masuk.Width = 48
        '
        'StockAwalTNG04BelumKonv
        '
        Me.StockAwalTNG04BelumKonv.FieldName = "StockAwal04Blm"
        Me.StockAwalTNG04BelumKonv.Name = "StockAwalTNG04BelumKonv"
        Me.StockAwalTNG04BelumKonv.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAwal04Blm", "SUM={0:0.##}")})
        Me.StockAwalTNG04BelumKonv.Visible = True
        Me.StockAwalTNG04BelumKonv.VisibleIndex = 4
        Me.StockAwalTNG04BelumKonv.Width = 48
        '
        'TotalStokAwal
        '
        Me.TotalStokAwal.FieldName = "TotalStokAwal"
        Me.TotalStokAwal.Name = "TotalStokAwal"
        Me.TotalStokAwal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalStokAwal", "SUM={0:0.##}")})
        Me.TotalStokAwal.Visible = True
        Me.TotalStokAwal.VisibleIndex = 6
        Me.TotalStokAwal.Width = 48
        '
        'StockAkhirTNG02
        '
        Me.StockAkhirTNG02.FieldName = "StockAkhir02"
        Me.StockAkhirTNG02.Name = "StockAkhirTNG02"
        Me.StockAkhirTNG02.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAkhir02", "SUM={0:0.##}")})
        Me.StockAkhirTNG02.Visible = True
        Me.StockAkhirTNG02.VisibleIndex = 7
        Me.StockAkhirTNG02.Width = 48
        '
        'StockAkhirTNG04
        '
        Me.StockAkhirTNG04.FieldName = "StockAkhir04"
        Me.StockAkhirTNG04.Name = "StockAkhirTNG04"
        Me.StockAkhirTNG04.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAkhir04", "SUM={0:0.##}")})
        Me.StockAkhirTNG04.Visible = True
        Me.StockAkhirTNG04.VisibleIndex = 8
        Me.StockAkhirTNG04.Width = 48
        '
        'StockAkhirTNG04UTUH
        '
        Me.StockAkhirTNG04UTUH.FieldName = "StockAkhir04UTUH"
        Me.StockAkhirTNG04UTUH.Name = "StockAkhirTNG04UTUH"
        Me.StockAkhirTNG04UTUH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAkhir04UTUH", "SUM={0:0.##}")})
        Me.StockAkhirTNG04UTUH.Visible = True
        Me.StockAkhirTNG04UTUH.VisibleIndex = 9
        Me.StockAkhirTNG04UTUH.Width = 53
        '
        'StockAkhirTNG04Pecahan
        '
        Me.StockAkhirTNG04Pecahan.FieldName = "StockAkhir04Pecahan"
        Me.StockAkhirTNG04Pecahan.Name = "StockAkhirTNG04Pecahan"
        Me.StockAkhirTNG04Pecahan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StockAkhir04Pecahan", "SUM={0:0.##}")})
        Me.StockAkhirTNG04Pecahan.Visible = True
        Me.StockAkhirTNG04Pecahan.VisibleIndex = 10
        Me.StockAkhirTNG04Pecahan.Width = 43
        '
        'TotalStokAhir4
        '
        Me.TotalStokAhir4.FieldName = "TotalStokAhir4"
        Me.TotalStokAhir4.Name = "TotalStokAhir4"
        Me.TotalStokAhir4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalStokAhir4", "SUM={0:0.##}")})
        Me.TotalStokAhir4.Visible = True
        Me.TotalStokAhir4.VisibleIndex = 11
        Me.TotalStokAhir4.Width = 66
        '
        'TotalStokAkhir
        '
        Me.TotalStokAkhir.FieldName = "TotalStokAkhir"
        Me.TotalStokAkhir.Name = "TotalStokAkhir"
        Me.TotalStokAkhir.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalStokAkhir", "SUM={0:0.##}")})
        Me.TotalStokAkhir.Visible = True
        Me.TotalStokAkhir.VisibleIndex = 12
        Me.TotalStokAkhir.Width = 53
        '
        'PemakaianNonProduksi
        '
        Me.PemakaianNonProduksi.FieldName = "PemakaianNonProduksi"
        Me.PemakaianNonProduksi.Name = "PemakaianNonProduksi"
        Me.PemakaianNonProduksi.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PemakaianNonProduksi", "SUM={0:0.##}")})
        Me.PemakaianNonProduksi.Visible = True
        Me.PemakaianNonProduksi.VisibleIndex = 13
        Me.PemakaianNonProduksi.Width = 52
        '
        'Pemakaian
        '
        Me.Pemakaian.FieldName = "Pemakaian"
        Me.Pemakaian.Name = "Pemakaian"
        Me.Pemakaian.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pemakaian", "SUM={0:0.##}")})
        Me.Pemakaian.Visible = True
        Me.Pemakaian.VisibleIndex = 14
        Me.Pemakaian.Width = 68
        '
        'Harga
        '
        Me.Harga.DisplayFormat.FormatString = "#.00"
        Me.Harga.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.Harga.FieldName = "Harga"
        Me.Harga.Name = "Harga"
        Me.Harga.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Harga", "SUM={0:0.##}")})
        Me.Harga.Visible = True
        Me.Harga.VisibleIndex = 15
        '
        'Amount
        '
        Me.Amount.DisplayFormat.FormatString = "#.00"
        Me.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.Amount.FieldName = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "SUM={0:0.##}")})
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 16
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmMaterialPainting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1183, 470)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmMaterialPainting"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPercentPainting As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtAktualLiter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtPercentTarget As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TXT As Label
    Friend WithEvents TxtPercentAll As TextBox
    Friend WithEvents TxtProduksiOKInj As TextBox
    Friend WithEvents TxtPercentSales As TextBox
    Friend WithEvents TxtSales As TextBox
    Friend WithEvents TxtAkumulasiPemakaianRp As TextBox
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents InvtID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Material As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAwalTNG02 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAwalTNG04 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Masuk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAwalTNG04BelumKonv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalStokAwal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAkhirTNG02 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAkhirTNG04 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAkhirTNG04UTUH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockAkhirTNG04Pecahan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalStokAhir4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalStokAkhir As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BBrowse As Button
    Friend WithEvents PemakaianNonProduksi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pemakaian As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtTotalRP As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtAktualRp As TextBox
    Friend WithEvents Harga As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtTotalLiter As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtAkumulasiPemakaianLiter As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtProduksiOKAll As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtProduksiOKPaint As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
