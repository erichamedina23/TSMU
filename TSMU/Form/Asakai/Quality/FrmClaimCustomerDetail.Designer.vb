<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClaimCustomerDetail
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
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalClaim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Problem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Dokumen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TargetClose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Lot = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GambarHapus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PathGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DtTanggalClaim = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCustomer = New System.Windows.Forms.TextBox()
        Me.DtTanggalLaporan = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtInvtID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtInvtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtProblem = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtPIC = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDokumen = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.DtTargetClose = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbStatus = New System.Windows.Forms.ComboBox()
        Me.BGambar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtLotNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtType = New System.Windows.Forms.TextBox()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 163)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.Grid.Size = New System.Drawing.Size(1091, 253)
        Me.Grid.TabIndex = 25
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Customer, Me.TanggalClaim, Me.InvtID, Me.InvtName, Me.Problem, Me.Qty, Me.Pic, Me.Status, Me.Dokumen, Me.TargetClose, Me.Gambar, Me.Lot, Me.Type, Me.GambarHapus, Me.PathGrid})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Customer
        '
        Me.Customer.FieldName = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.Visible = True
        Me.Customer.VisibleIndex = 0
        Me.Customer.Width = 104
        '
        'TanggalClaim
        '
        Me.TanggalClaim.DisplayFormat.FormatString = "yyyy-MM-dd"
        Me.TanggalClaim.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalClaim.FieldName = "TanggalClaim"
        Me.TanggalClaim.Name = "TanggalClaim"
        Me.TanggalClaim.Visible = True
        Me.TanggalClaim.VisibleIndex = 1
        Me.TanggalClaim.Width = 119
        '
        'InvtID
        '
        Me.InvtID.FieldName = "InvtId"
        Me.InvtID.Name = "InvtID"
        Me.InvtID.Visible = True
        Me.InvtID.VisibleIndex = 2
        Me.InvtID.Width = 112
        '
        'InvtName
        '
        Me.InvtName.FieldName = "Invt Name"
        Me.InvtName.Name = "InvtName"
        Me.InvtName.Visible = True
        Me.InvtName.VisibleIndex = 3
        Me.InvtName.Width = 108
        '
        'Problem
        '
        Me.Problem.FieldName = "Problem"
        Me.Problem.Name = "Problem"
        Me.Problem.Visible = True
        Me.Problem.VisibleIndex = 4
        Me.Problem.Width = 199
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 5
        Me.Qty.Width = 92
        '
        'Pic
        '
        Me.Pic.AppearanceCell.Options.UseTextOptions = True
        Me.Pic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Pic.AppearanceHeader.Options.UseTextOptions = True
        Me.Pic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Pic.FieldName = "Pic"
        Me.Pic.Name = "Pic"
        Me.Pic.Visible = True
        Me.Pic.VisibleIndex = 6
        Me.Pic.Width = 92
        '
        'Status
        '
        Me.Status.AppearanceCell.Options.UseTextOptions = True
        Me.Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Status.AppearanceHeader.Options.UseTextOptions = True
        Me.Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 8
        Me.Status.Width = 114
        '
        'Dokumen
        '
        Me.Dokumen.AppearanceCell.Options.UseTextOptions = True
        Me.Dokumen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dokumen.AppearanceHeader.Options.UseTextOptions = True
        Me.Dokumen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dokumen.FieldName = "Dokumen"
        Me.Dokumen.Name = "Dokumen"
        Me.Dokumen.Visible = True
        Me.Dokumen.VisibleIndex = 7
        Me.Dokumen.Width = 102
        '
        'TargetClose
        '
        Me.TargetClose.AppearanceCell.Options.UseTextOptions = True
        Me.TargetClose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TargetClose.AppearanceHeader.Options.UseTextOptions = True
        Me.TargetClose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TargetClose.DisplayFormat.FormatString = "yyyy-MM-dd"
        Me.TargetClose.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TargetClose.FieldName = "TargetClose"
        Me.TargetClose.Name = "TargetClose"
        Me.TargetClose.Visible = True
        Me.TargetClose.VisibleIndex = 9
        Me.TargetClose.Width = 118
        '
        'Gambar
        '
        Me.Gambar.AppearanceCell.Options.UseTextOptions = True
        Me.Gambar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Gambar.AppearanceHeader.Options.UseTextOptions = True
        Me.Gambar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Gambar.FieldName = "Gambar"
        Me.Gambar.Name = "Gambar"
        Me.Gambar.Visible = True
        Me.Gambar.VisibleIndex = 10
        Me.Gambar.Width = 285
        '
        'Lot
        '
        Me.Lot.AppearanceCell.Options.UseTextOptions = True
        Me.Lot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Lot.AppearanceHeader.Options.UseTextOptions = True
        Me.Lot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Lot.FieldName = "Lot"
        Me.Lot.Name = "Lot"
        Me.Lot.Visible = True
        Me.Lot.VisibleIndex = 11
        Me.Lot.Width = 105
        '
        'Type
        '
        Me.Type.AppearanceCell.Options.UseTextOptions = True
        Me.Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.AppearanceHeader.Options.UseTextOptions = True
        Me.Type.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 12
        Me.Type.Width = 105
        '
        'GambarHapus
        '
        Me.GambarHapus.FieldName = "Gambar Hapus"
        Me.GambarHapus.Name = "GambarHapus"
        Me.GambarHapus.Visible = True
        Me.GambarHapus.VisibleIndex = 13
        Me.GambarHapus.Width = 220
        '
        'PathGrid
        '
        Me.PathGrid.FieldName = "Path"
        Me.PathGrid.Name = "PathGrid"
        Me.PathGrid.Visible = True
        Me.PathGrid.VisibleIndex = 14
        Me.PathGrid.Width = 183
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
        'DtTanggalClaim
        '
        Me.DtTanggalClaim.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalClaim.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalClaim.Location = New System.Drawing.Point(110, 85)
        Me.DtTanggalClaim.Name = "DtTanggalClaim"
        Me.DtTanggalClaim.Size = New System.Drawing.Size(146, 20)
        Me.DtTanggalClaim.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "TANGGAL CLAIM"
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(110, 42)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(146, 20)
        Me.TxtCustomer.TabIndex = 1
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(110, 63)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(146, 20)
        Me.DtTanggalLaporan.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "TANGGAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "CUSTOMER"
        '
        'TxtInvtID
        '
        Me.TxtInvtID.Location = New System.Drawing.Point(345, 42)
        Me.TxtInvtID.Name = "TxtInvtID"
        Me.TxtInvtID.Size = New System.Drawing.Size(146, 20)
        Me.TxtInvtID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(268, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "PART NO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(268, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "PART NAME"
        '
        'TxtInvtName
        '
        Me.TxtInvtName.Location = New System.Drawing.Point(345, 63)
        Me.TxtInvtName.Name = "TxtInvtName"
        Me.TxtInvtName.Size = New System.Drawing.Size(146, 20)
        Me.TxtInvtName.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(497, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "PROBLEM"
        '
        'TxtProblem
        '
        Me.TxtProblem.Location = New System.Drawing.Point(562, 43)
        Me.TxtProblem.Multiline = True
        Me.TxtProblem.Name = "TxtProblem"
        Me.TxtProblem.Size = New System.Drawing.Size(146, 40)
        Me.TxtProblem.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(268, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "QTY"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(345, 85)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(146, 20)
        Me.TxtQty.TabIndex = 7
        Me.TxtQty.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(497, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "PIC"
        '
        'TxtPIC
        '
        Me.TxtPIC.Location = New System.Drawing.Point(562, 85)
        Me.TxtPIC.Name = "TxtPIC"
        Me.TxtPIC.Size = New System.Drawing.Size(146, 20)
        Me.TxtPIC.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(714, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "DOKUMEN"
        '
        'TxtDokumen
        '
        Me.TxtDokumen.Location = New System.Drawing.Point(784, 46)
        Me.TxtDokumen.Name = "TxtDokumen"
        Me.TxtDokumen.Size = New System.Drawing.Size(154, 20)
        Me.TxtDokumen.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(714, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "STATUS"
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(12, 131)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(76, 21)
        Me.BAdd.TabIndex = 62
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'DtTargetClose
        '
        Me.DtTargetClose.CustomFormat = "dd-MM-yyyy"
        Me.DtTargetClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTargetClose.Location = New System.Drawing.Point(110, 107)
        Me.DtTargetClose.Name = "DtTargetClose"
        Me.DtTargetClose.Size = New System.Drawing.Size(146, 20)
        Me.DtTargetClose.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "TARGET CLOSE"
        '
        'CmbStatus
        '
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.Items.AddRange(New Object() {"OPEN", "CLOSE"})
        Me.CmbStatus.Location = New System.Drawing.Point(784, 67)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(154, 21)
        Me.CmbStatus.TabIndex = 13
        '
        'BGambar
        '
        Me.BGambar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BGambar.Location = New System.Drawing.Point(983, 131)
        Me.BGambar.Name = "BGambar"
        Me.BGambar.Size = New System.Drawing.Size(95, 26)
        Me.BGambar.TabIndex = 104
        Me.BGambar.Text = "Cari Gambar"
        Me.BGambar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(949, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 103
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(497, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "LOT NO"
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(562, 107)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.Size = New System.Drawing.Size(146, 20)
        Me.TxtLotNo.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(268, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = "TYPE"
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(345, 107)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(146, 20)
        Me.TxtType.TabIndex = 8
        '
        'FrmClaimCustomerDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1115, 428)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtLotNo)
        Me.Controls.Add(Me.BGambar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbStatus)
        Me.Controls.Add(Me.DtTargetClose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtDokumen)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtPIC)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtProblem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtInvtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtInvtID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtTanggalLaporan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCustomer)
        Me.Controls.Add(Me.DtTanggalClaim)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmClaimCustomerDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalClaim, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomer, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLaporan, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtID, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtProblem, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtPIC, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtDokumen, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.BAdd, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.DtTargetClose, 0)
        Me.Controls.SetChildIndex(Me.CmbStatus, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.BGambar, 0)
        Me.Controls.SetChildIndex(Me.TxtLotNo, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TxtType, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DtTanggalClaim As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents DtTanggalLaporan As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtInvtID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtInvtName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtProblem As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtPIC As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtDokumen As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BAdd As Button
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalClaim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Problem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Dokumen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DtTargetClose As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbStatus As ComboBox
    Friend WithEvents TargetClose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGambar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtLotNo As TextBox
    Friend WithEvents Lot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtType As TextBox
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GambarHapus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PathGrid As DevExpress.XtraGrid.Columns.GridColumn
End Class
