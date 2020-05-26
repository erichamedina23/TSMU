<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProblemDeliveryUpload
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.BCari = New System.Windows.Forms.Button()
        Me.DateTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Standar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Aktual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KirimKurang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Campur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KirimLebihIsi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SalahIsi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SalahPasscard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Transporter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LainLain = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Ket = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BtnGambar = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepBtnGambar = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DateTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGambar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepBtnGambar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BCari)
        Me.LayoutControl1.Controls.Add(Me.DateTanggal)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(413, 328, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1311, 52)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BCari
        '
        Me.BCari.Location = New System.Drawing.Point(180, 12)
        Me.BCari.Name = "BCari"
        Me.BCari.Size = New System.Drawing.Size(69, 20)
        Me.BCari.TabIndex = 5
        Me.BCari.Text = "Cari"
        Me.BCari.UseVisualStyleBackColor = True
        '
        'DateTanggal
        '
        Me.DateTanggal.EditValue = Nothing
        Me.DateTanggal.Location = New System.Drawing.Point(53, 12)
        Me.DateTanggal.Name = "DateTanggal"
        Me.DateTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTanggal.Size = New System.Drawing.Size(113, 20)
        Me.DateTanggal.StyleController = Me.LayoutControl1
        Me.DateTanggal.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem2, Me.EmptySpaceItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1294, 54)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DateTanggal
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(158, 24)
        Me.LayoutControlItem1.Text = "Tanggal"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(38, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1274, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(241, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1033, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BCari
        Me.LayoutControlItem2.Location = New System.Drawing.Point(168, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(73, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(158, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(10, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(10, 63)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.BtnGambar, Me.RepBtnGambar})
        Me.Grid.Size = New System.Drawing.Size(1291, 360)
        Me.Grid.TabIndex = 25
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Customer, Me.Standar, Me.Aktual, Me.KirimKurang, Me.Campur, Me.KirimLebihIsi, Me.SalahIsi, Me.SalahPasscard, Me.Transporter, Me.LainLain, Me.Ket, Me.Gambar})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'Customer
        '
        Me.Customer.FieldName = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.Visible = True
        Me.Customer.VisibleIndex = 0
        Me.Customer.Width = 86
        '
        'Standar
        '
        Me.Standar.FieldName = "Standar"
        Me.Standar.Name = "Standar"
        Me.Standar.Visible = True
        Me.Standar.VisibleIndex = 1
        Me.Standar.Width = 187
        '
        'Aktual
        '
        Me.Aktual.FieldName = "Aktual"
        Me.Aktual.Name = "Aktual"
        Me.Aktual.Visible = True
        Me.Aktual.VisibleIndex = 2
        Me.Aktual.Width = 182
        '
        'KirimKurang
        '
        Me.KirimKurang.FieldName = "Kirim Kurang"
        Me.KirimKurang.Name = "KirimKurang"
        Me.KirimKurang.Visible = True
        Me.KirimKurang.VisibleIndex = 3
        '
        'Campur
        '
        Me.Campur.FieldName = "Campur"
        Me.Campur.Name = "Campur"
        Me.Campur.Visible = True
        Me.Campur.VisibleIndex = 4
        '
        'KirimLebihIsi
        '
        Me.KirimLebihIsi.FieldName = "Kirim Lebih Isi"
        Me.KirimLebihIsi.Name = "KirimLebihIsi"
        Me.KirimLebihIsi.Visible = True
        Me.KirimLebihIsi.VisibleIndex = 5
        '
        'SalahIsi
        '
        Me.SalahIsi.FieldName = "Salah Isi"
        Me.SalahIsi.Name = "SalahIsi"
        Me.SalahIsi.Visible = True
        Me.SalahIsi.VisibleIndex = 6
        '
        'SalahPasscard
        '
        Me.SalahPasscard.FieldName = "Salah Passcard"
        Me.SalahPasscard.Name = "SalahPasscard"
        Me.SalahPasscard.Visible = True
        Me.SalahPasscard.VisibleIndex = 7
        '
        'Transporter
        '
        Me.Transporter.FieldName = "Transporter"
        Me.Transporter.Name = "Transporter"
        Me.Transporter.Visible = True
        Me.Transporter.VisibleIndex = 8
        '
        'LainLain
        '
        Me.LainLain.FieldName = "Lain Lain"
        Me.LainLain.Name = "LainLain"
        Me.LainLain.Visible = True
        Me.LainLain.VisibleIndex = 9
        '
        'Ket
        '
        Me.Ket.FieldName = "Keterangan"
        Me.Ket.Name = "Ket"
        Me.Ket.Visible = True
        Me.Ket.VisibleIndex = 10
        '
        'Gambar
        '
        Me.Gambar.FieldName = "Gambar"
        Me.Gambar.Name = "Gambar"
        Me.Gambar.Visible = True
        Me.Gambar.VisibleIndex = 11
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'BtnGambar
        '
        Me.BtnGambar.AutoHeight = False
        Me.BtnGambar.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BtnGambar.Name = "BtnGambar"
        '
        'RepBtnGambar
        '
        Me.RepBtnGambar.AutoHeight = False
        Me.RepBtnGambar.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepBtnGambar.Name = "RepBtnGambar"
        '
        'FrmProblemDeliveryUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1311, 435)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmProblemDeliveryUpload"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DateTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGambar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepBtnGambar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents BCari As Button
    Friend WithEvents DateTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Standar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Aktual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepBtnGambar As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BtnGambar As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents KirimKurang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Campur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KirimLebihIsi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SalahIsi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SalahPasscard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Transporter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LainLain As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Ket As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
