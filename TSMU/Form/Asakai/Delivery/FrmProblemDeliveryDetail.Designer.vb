<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProblemDeliveryDetail
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtTanggalKiriman = New System.Windows.Forms.DateTimePicker()
        Me.DtTanggalKejadian = New System.Windows.Forms.DateTimePicker()
        Me.TxtCustomer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.TxtStandar = New System.Windows.Forms.TextBox()
        Me.TxtAktual = New System.Windows.Forms.TextBox()
        Me.CmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtInvtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DtTanggalLapoan = New System.Windows.Forms.DateTimePicker()
        Me.TxtInvtID = New System.Windows.Forms.TextBox()
        Me.TxtJenisProblem = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnPicture = New System.Windows.Forms.Button()
        Me.DtTargetClose = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPIC = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalKejadian = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalKiriman = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Standar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Aktual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JenisProblem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TargetClose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepBtnGambar = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Pic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BtnGambar = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepBtnGambar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGambar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tanggal Kejadian"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tanggal Kiriman"
        '
        'DtTanggalKiriman
        '
        Me.DtTanggalKiriman.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalKiriman.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalKiriman.Location = New System.Drawing.Point(106, 116)
        Me.DtTanggalKiriman.Name = "DtTanggalKiriman"
        Me.DtTanggalKiriman.Size = New System.Drawing.Size(261, 20)
        Me.DtTanggalKiriman.TabIndex = 8
        '
        'DtTanggalKejadian
        '
        Me.DtTanggalKejadian.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalKejadian.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalKejadian.Location = New System.Drawing.Point(106, 90)
        Me.DtTanggalKejadian.Name = "DtTanggalKejadian"
        Me.DtTanggalKejadian.Size = New System.Drawing.Size(261, 20)
        Me.DtTanggalKejadian.TabIndex = 9
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(106, 38)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(261, 20)
        Me.TxtCustomer.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(748, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Standar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(748, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Aktual"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(459, 119)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(95, 20)
        Me.TxtQty.TabIndex = 18
        '
        'TxtStandar
        '
        Me.TxtStandar.Location = New System.Drawing.Point(798, 41)
        Me.TxtStandar.Multiline = True
        Me.TxtStandar.Name = "TxtStandar"
        Me.TxtStandar.Size = New System.Drawing.Size(247, 60)
        Me.TxtStandar.TabIndex = 20
        '
        'TxtAktual
        '
        Me.TxtAktual.Location = New System.Drawing.Point(798, 107)
        Me.TxtAktual.Multiline = True
        Me.TxtAktual.Name = "TxtAktual"
        Me.TxtAktual.Size = New System.Drawing.Size(247, 60)
        Me.TxtAktual.TabIndex = 21
        '
        'CmbStatus
        '
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.Items.AddRange(New Object() {"Open", "Close"})
        Me.CmbStatus.Location = New System.Drawing.Point(560, 117)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(161, 21)
        Me.CmbStatus.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(382, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Qty - Status"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 27)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Add Problem"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtInvtName
        '
        Me.TxtInvtName.Location = New System.Drawing.Point(459, 67)
        Me.TxtInvtName.Name = "TxtInvtName"
        Me.TxtInvtName.Size = New System.Drawing.Size(262, 20)
        Me.TxtInvtName.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(382, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Invt ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(382, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Jenis Problem"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Tanggal Laporan"
        '
        'DtTanggalLapoan
        '
        Me.DtTanggalLapoan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLapoan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLapoan.Location = New System.Drawing.Point(106, 64)
        Me.DtTanggalLapoan.Name = "DtTanggalLapoan"
        Me.DtTanggalLapoan.Size = New System.Drawing.Size(261, 20)
        Me.DtTanggalLapoan.TabIndex = 35
        '
        'TxtInvtID
        '
        Me.TxtInvtID.Location = New System.Drawing.Point(459, 41)
        Me.TxtInvtID.Name = "TxtInvtID"
        Me.TxtInvtID.Size = New System.Drawing.Size(262, 20)
        Me.TxtInvtID.TabIndex = 36
        '
        'TxtJenisProblem
        '
        Me.TxtJenisProblem.Location = New System.Drawing.Point(459, 91)
        Me.TxtJenisProblem.Name = "TxtJenisProblem"
        Me.TxtJenisProblem.Size = New System.Drawing.Size(262, 20)
        Me.TxtJenisProblem.TabIndex = 37
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1051, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(169, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'BtnPicture
        '
        Me.BtnPicture.Location = New System.Drawing.Point(1226, 38)
        Me.BtnPicture.Name = "BtnPicture"
        Me.BtnPicture.Size = New System.Drawing.Size(53, 127)
        Me.BtnPicture.TabIndex = 39
        Me.BtnPicture.Text = "Gambar"
        Me.BtnPicture.UseVisualStyleBackColor = True
        '
        'DtTargetClose
        '
        Me.DtTargetClose.CustomFormat = "dd-MM-yyyy"
        Me.DtTargetClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTargetClose.Location = New System.Drawing.Point(106, 142)
        Me.DtTargetClose.Name = "DtTargetClose"
        Me.DtTargetClose.Size = New System.Drawing.Size(261, 20)
        Me.DtTargetClose.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Target Close"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(382, 144)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Pic"
        '
        'TxtPIC
        '
        Me.TxtPIC.Location = New System.Drawing.Point(459, 145)
        Me.TxtPIC.Name = "TxtPIC"
        Me.TxtPIC.Size = New System.Drawing.Size(262, 20)
        Me.TxtPIC.TabIndex = 43
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(382, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Invt Name"
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(15, 211)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.BtnGambar, Me.RepBtnGambar})
        Me.Grid.Size = New System.Drawing.Size(1276, 284)
        Me.Grid.TabIndex = 45
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Customer, Me.TanggalKejadian, Me.TanggalKiriman, Me.Standar, Me.Aktual, Me.Qty, Me.JenisProblem, Me.TargetClose, Me.Status, Me.InvtID, Me.InvtName, Me.Gambar, Me.Pic})
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
        'TanggalKejadian
        '
        Me.TanggalKejadian.FieldName = "Tanggal Kejadian"
        Me.TanggalKejadian.Name = "TanggalKejadian"
        Me.TanggalKejadian.Visible = True
        Me.TanggalKejadian.VisibleIndex = 3
        Me.TanggalKejadian.Width = 110
        '
        'TanggalKiriman
        '
        Me.TanggalKiriman.FieldName = "Tanggal Kiriman"
        Me.TanggalKiriman.Name = "TanggalKiriman"
        Me.TanggalKiriman.Visible = True
        Me.TanggalKiriman.VisibleIndex = 4
        Me.TanggalKiriman.Width = 110
        '
        'Standar
        '
        Me.Standar.FieldName = "Standar"
        Me.Standar.Name = "Standar"
        Me.Standar.Visible = True
        Me.Standar.VisibleIndex = 6
        Me.Standar.Width = 187
        '
        'Aktual
        '
        Me.Aktual.FieldName = "Aktual"
        Me.Aktual.Name = "Aktual"
        Me.Aktual.Visible = True
        Me.Aktual.VisibleIndex = 7
        Me.Aktual.Width = 182
        '
        'Qty
        '
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 8
        Me.Qty.Width = 110
        '
        'JenisProblem
        '
        Me.JenisProblem.FieldName = "Jenis Problem"
        Me.JenisProblem.Name = "JenisProblem"
        Me.JenisProblem.Visible = True
        Me.JenisProblem.VisibleIndex = 5
        Me.JenisProblem.Width = 110
        '
        'TargetClose
        '
        Me.TargetClose.FieldName = "Target Close"
        Me.TargetClose.Name = "TargetClose"
        Me.TargetClose.Visible = True
        Me.TargetClose.VisibleIndex = 9
        '
        'Status
        '
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 11
        '
        'InvtID
        '
        Me.InvtID.FieldName = "Inventory ID"
        Me.InvtID.Name = "InvtID"
        Me.InvtID.Visible = True
        Me.InvtID.VisibleIndex = 1
        Me.InvtID.Width = 131
        '
        'InvtName
        '
        Me.InvtName.FieldName = "Inventory Name"
        Me.InvtName.Name = "InvtName"
        Me.InvtName.Visible = True
        Me.InvtName.VisibleIndex = 2
        Me.InvtName.Width = 132
        '
        'Gambar
        '
        Me.Gambar.ColumnEdit = Me.RepBtnGambar
        Me.Gambar.FieldName = "Gambar"
        Me.Gambar.Name = "Gambar"
        Me.Gambar.Visible = True
        Me.Gambar.VisibleIndex = 12
        '
        'RepBtnGambar
        '
        Me.RepBtnGambar.AutoHeight = False
        Me.RepBtnGambar.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepBtnGambar.Name = "RepBtnGambar"
        '
        'Pic
        '
        Me.Pic.FieldName = "Pic"
        Me.Pic.Name = "Pic"
        Me.Pic.Visible = True
        Me.Pic.VisibleIndex = 10
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
        'FrmProblemDeliveryDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1370, 547)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPIC)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DtTargetClose)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnPicture)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtJenisProblem)
        Me.Controls.Add(Me.TxtInvtID)
        Me.Controls.Add(Me.DtTanggalLapoan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtInvtName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CmbStatus)
        Me.Controls.Add(Me.TxtAktual)
        Me.Controls.Add(Me.TxtStandar)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCustomer)
        Me.Controls.Add(Me.DtTanggalKejadian)
        Me.Controls.Add(Me.DtTanggalKiriman)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmProblemDeliveryDetail"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalKiriman, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalKejadian, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomer, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.Controls.SetChildIndex(Me.TxtStandar, 0)
        Me.Controls.SetChildIndex(Me.TxtAktual, 0)
        Me.Controls.SetChildIndex(Me.CmbStatus, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLapoan, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtID, 0)
        Me.Controls.SetChildIndex(Me.TxtJenisProblem, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.BtnPicture, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.DtTargetClose, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.TxtPIC, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepBtnGambar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGambar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DtTanggalKiriman As DateTimePicker
    Friend WithEvents DtTanggalKejadian As DateTimePicker
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents TxtStandar As TextBox
    Friend WithEvents TxtAktual As TextBox
    Friend WithEvents CmbStatus As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtInvtName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents DtTanggalLapoan As DateTimePicker
    Friend WithEvents TxtInvtID As TextBox
    Friend WithEvents TxtJenisProblem As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnPicture As Button
    Friend WithEvents DtTargetClose As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtPIC As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalKejadian As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalKiriman As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Standar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Aktual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JenisProblem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TargetClose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepBtnGambar As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Pic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BtnGambar As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
