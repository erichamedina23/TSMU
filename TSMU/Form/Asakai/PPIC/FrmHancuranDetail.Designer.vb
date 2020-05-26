<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmHancuranDetail
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
        Me.SUPPLIER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STOKAWAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KIRIM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KEMBALI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSuplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStokAwal = New System.Windows.Forms.TextBox()
        Me.txtKirim = New System.Windows.Forms.TextBox()
        Me.txtKembali = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtHancuranInternal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBalnce = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 222)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(760, 348)
        Me.Grid.TabIndex = 5
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SUPPLIER, Me.STOKAWAL, Me.KIRIM, Me.KEMBALI, Me.BALANCE})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'SUPPLIER
        '
        Me.SUPPLIER.FieldName = "SUPPLIER"
        Me.SUPPLIER.Name = "SUPPLIER"
        Me.SUPPLIER.OptionsColumn.AllowEdit = False
        Me.SUPPLIER.Visible = True
        Me.SUPPLIER.VisibleIndex = 0
        Me.SUPPLIER.Width = 196
        '
        'STOKAWAL
        '
        Me.STOKAWAL.FieldName = "STOK AWAL"
        Me.STOKAWAL.Name = "STOKAWAL"
        Me.STOKAWAL.OptionsColumn.AllowEdit = False
        Me.STOKAWAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "STOK AWAL", "SUM={0:0.##}")})
        Me.STOKAWAL.Visible = True
        Me.STOKAWAL.VisibleIndex = 1
        Me.STOKAWAL.Width = 127
        '
        'KIRIM
        '
        Me.KIRIM.FieldName = "KIRIM"
        Me.KIRIM.Name = "KIRIM"
        Me.KIRIM.OptionsColumn.AllowEdit = False
        Me.KIRIM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KIRIM", "SUM={0:0.##}")})
        Me.KIRIM.Visible = True
        Me.KIRIM.VisibleIndex = 2
        Me.KIRIM.Width = 140
        '
        'KEMBALI
        '
        Me.KEMBALI.FieldName = "KEMBALI"
        Me.KEMBALI.Name = "KEMBALI"
        Me.KEMBALI.OptionsColumn.AllowEdit = False
        Me.KEMBALI.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KEMBALI", "SUM={0:0.##}")})
        Me.KEMBALI.Visible = True
        Me.KEMBALI.VisibleIndex = 3
        Me.KEMBALI.Width = 132
        '
        'BALANCE
        '
        Me.BALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BALANCE.FieldName = "BALANCE"
        Me.BALANCE.Name = "BALANCE"
        Me.BALANCE.OptionsColumn.AllowEdit = False
        Me.BALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BALANCE", "SUM={0:0.##}")})
        Me.BALANCE.UnboundExpression = "[STOK AWAL] + [KIRIM] - [KEMBALI]"
        Me.BALANCE.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.BALANCE.Visible = True
        Me.BALANCE.VisibleIndex = 4
        Me.BALANCE.Width = 149
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "TANGGAL"
        '
        'DtTanggal
        '
        Me.DtTanggal.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggal.Location = New System.Drawing.Point(99, 39)
        Me.DtTanggal.Name = "DtTanggal"
        Me.DtTanggal.Size = New System.Drawing.Size(171, 20)
        Me.DtTanggal.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "SUPPLIER"
        '
        'CmbSuplier
        '
        Me.CmbSuplier.FormattingEnabled = True
        Me.CmbSuplier.Items.AddRange(New Object() {"TRALON", "PCT"})
        Me.CmbSuplier.Location = New System.Drawing.Point(99, 63)
        Me.CmbSuplier.Name = "CmbSuplier"
        Me.CmbSuplier.Size = New System.Drawing.Size(171, 21)
        Me.CmbSuplier.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "STOK AWAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "KIRIM"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "KEMBALI"
        '
        'txtStokAwal
        '
        Me.txtStokAwal.Location = New System.Drawing.Point(99, 89)
        Me.txtStokAwal.Name = "txtStokAwal"
        Me.txtStokAwal.Size = New System.Drawing.Size(171, 20)
        Me.txtStokAwal.TabIndex = 17
        '
        'txtKirim
        '
        Me.txtKirim.Location = New System.Drawing.Point(99, 113)
        Me.txtKirim.Name = "txtKirim"
        Me.txtKirim.Size = New System.Drawing.Size(171, 20)
        Me.txtKirim.TabIndex = 18
        '
        'txtKembali
        '
        Me.txtKembali.Location = New System.Drawing.Point(99, 136)
        Me.txtKembali.Name = "txtKembali"
        Me.txtKembali.Size = New System.Drawing.Size(171, 20)
        Me.txtKembali.TabIndex = 19
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(439, 136)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(171, 20)
        Me.txtTotal.TabIndex = 25
        '
        'txtHancuranInternal
        '
        Me.txtHancuranInternal.Location = New System.Drawing.Point(439, 110)
        Me.txtHancuranInternal.Name = "txtHancuranInternal"
        Me.txtHancuranInternal.Size = New System.Drawing.Size(171, 20)
        Me.txtHancuranInternal.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(305, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(305, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "HANCURAN INTERNAL"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(439, 160)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(171, 20)
        Me.txtTarget.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(305, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "TARGET"
        '
        'txtBalnce
        '
        Me.txtBalnce.Location = New System.Drawing.Point(99, 160)
        Me.txtBalnce.Name = "txtBalnce"
        Me.txtBalnce.Size = New System.Drawing.Size(171, 20)
        Me.txtBalnce.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "BALANCE"
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(13, 193)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(75, 23)
        Me.BAdd.TabIndex = 30
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'FrmHancuranDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(784, 581)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.txtBalnce)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtHancuranInternal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtKembali)
        Me.Controls.Add(Me.txtKirim)
        Me.Controls.Add(Me.txtStokAwal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbSuplier)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtTanggal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmHancuranDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtTanggal, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CmbSuplier, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtStokAwal, 0)
        Me.Controls.SetChildIndex(Me.txtKirim, 0)
        Me.Controls.SetChildIndex(Me.txtKembali, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtHancuranInternal, 0)
        Me.Controls.SetChildIndex(Me.txtTotal, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtTarget, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtBalnce, 0)
        Me.Controls.SetChildIndex(Me.BAdd, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SUPPLIER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STOKAWAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents DtTanggal As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbSuplier As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtStokAwal As TextBox
    Friend WithEvents txtKirim As TextBox
    Friend WithEvents txtKembali As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtHancuranInternal As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTarget As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBalnce As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents KIRIM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KEMBALI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAdd As Button
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
End Class
