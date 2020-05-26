<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmQualityProblemDetail
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
        Me.Shift = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Problem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Analisis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CorrectionAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PreventiveAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Target = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LotNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Path = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GambarHapus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPic = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtInvtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtInvtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtTanggalLaporan = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCustomer = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbShift = New System.Windows.Forms.ComboBox()
        Me.TxtProblem = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtAnalisis = New System.Windows.Forms.TextBox()
        Me.DtTarget = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtPreventive = New System.Windows.Forms.TextBox()
        Me.TxtCorrection = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BGambar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtLotNo = New System.Windows.Forms.TextBox()
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
        Me.Grid.Location = New System.Drawing.Point(12, 161)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.Grid.Size = New System.Drawing.Size(1307, 408)
        Me.Grid.TabIndex = 26
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Shift, Me.Status, Me.Customer, Me.InvtId, Me.InvtName, Me.Type, Me.Qty, Me.Problem, Me.Analisis, Me.CorrectionAction, Me.PreventiveAction, Me.Pic, Me.Target, Me.Gambar, Me.LotNo, Me.Path, Me.GambarHapus})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Shift
        '
        Me.Shift.AppearanceCell.Options.UseTextOptions = True
        Me.Shift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Shift.AppearanceHeader.Options.UseTextOptions = True
        Me.Shift.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Shift.FieldName = "Shift"
        Me.Shift.Name = "Shift"
        Me.Shift.Visible = True
        Me.Shift.VisibleIndex = 0
        Me.Shift.Width = 42
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
        Me.Status.VisibleIndex = 1
        Me.Status.Width = 100
        '
        'Customer
        '
        Me.Customer.AppearanceCell.Options.UseTextOptions = True
        Me.Customer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Customer.AppearanceHeader.Options.UseTextOptions = True
        Me.Customer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Customer.FieldName = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.Visible = True
        Me.Customer.VisibleIndex = 2
        Me.Customer.Width = 124
        '
        'InvtId
        '
        Me.InvtId.FieldName = "InvtId"
        Me.InvtId.Name = "InvtId"
        Me.InvtId.Visible = True
        Me.InvtId.VisibleIndex = 3
        Me.InvtId.Width = 164
        '
        'InvtName
        '
        Me.InvtName.FieldName = "InvtName"
        Me.InvtName.Name = "InvtName"
        Me.InvtName.Visible = True
        Me.InvtName.VisibleIndex = 4
        Me.InvtName.Width = 172
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
        Me.Type.VisibleIndex = 5
        Me.Type.Width = 132
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
        Me.Qty.VisibleIndex = 6
        Me.Qty.Width = 95
        '
        'Problem
        '
        Me.Problem.FieldName = "Problem"
        Me.Problem.Name = "Problem"
        Me.Problem.Visible = True
        Me.Problem.VisibleIndex = 8
        Me.Problem.Width = 90
        '
        'Analisis
        '
        Me.Analisis.FieldName = "Analisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Visible = True
        Me.Analisis.VisibleIndex = 9
        '
        'CorrectionAction
        '
        Me.CorrectionAction.FieldName = "Correction Action"
        Me.CorrectionAction.Name = "CorrectionAction"
        Me.CorrectionAction.Visible = True
        Me.CorrectionAction.VisibleIndex = 10
        Me.CorrectionAction.Width = 254
        '
        'PreventiveAction
        '
        Me.PreventiveAction.FieldName = "Preventive Action"
        Me.PreventiveAction.Name = "PreventiveAction"
        Me.PreventiveAction.Visible = True
        Me.PreventiveAction.VisibleIndex = 11
        Me.PreventiveAction.Width = 202
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
        Me.Pic.VisibleIndex = 12
        Me.Pic.Width = 117
        '
        'Target
        '
        Me.Target.AppearanceCell.Options.UseTextOptions = True
        Me.Target.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Target.AppearanceHeader.Options.UseTextOptions = True
        Me.Target.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Target.FieldName = "Target"
        Me.Target.Name = "Target"
        Me.Target.Visible = True
        Me.Target.VisibleIndex = 13
        Me.Target.Width = 107
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
        Me.Gambar.VisibleIndex = 14
        Me.Gambar.Width = 185
        '
        'LotNo
        '
        Me.LotNo.AppearanceCell.Options.UseTextOptions = True
        Me.LotNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LotNo.AppearanceHeader.Options.UseTextOptions = True
        Me.LotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LotNo.FieldName = "Lot No"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.Visible = True
        Me.LotNo.VisibleIndex = 7
        Me.LotNo.Width = 87
        '
        'Path
        '
        Me.Path.AppearanceCell.Options.UseTextOptions = True
        Me.Path.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Path.AppearanceHeader.Options.UseTextOptions = True
        Me.Path.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Path.FieldName = "Path"
        Me.Path.Name = "Path"
        Me.Path.Width = 276
        '
        'GambarHapus
        '
        Me.GambarHapus.FieldName = "Gambar Hapus"
        Me.GambarHapus.Name = "GambarHapus"
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
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(12, 132)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(84, 23)
        Me.BAdd.TabIndex = 87
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(436, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Target"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "PIC"
        '
        'TxtPic
        '
        Me.TxtPic.Location = New System.Drawing.Point(76, 105)
        Me.TxtPic.Name = "TxtPic"
        Me.TxtPic.Size = New System.Drawing.Size(130, 20)
        Me.TxtPic.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Status"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(76, 61)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(130, 20)
        Me.TxtStatus.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(278, 83)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(154, 20)
        Me.TxtQty.TabIndex = 7
        Me.TxtQty.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(278, 105)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(154, 20)
        Me.TxtType.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Part Name"
        '
        'TxtInvtName
        '
        Me.TxtInvtName.Location = New System.Drawing.Point(278, 61)
        Me.TxtInvtName.Name = "TxtInvtName"
        Me.TxtInvtName.Size = New System.Drawing.Size(154, 20)
        Me.TxtInvtName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Part No"
        '
        'TxtInvtID
        '
        Me.TxtInvtID.Location = New System.Drawing.Point(278, 39)
        Me.TxtInvtID.Name = "TxtInvtID"
        Me.TxtInvtID.Size = New System.Drawing.Size(154, 20)
        Me.TxtInvtID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Customer"
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(76, 39)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(130, 20)
        Me.DtTanggalLaporan.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Tanggal "
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(76, 83)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(130, 20)
        Me.TxtCustomer.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(436, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Shift"
        '
        'CmbShift
        '
        Me.CmbShift.FormattingEnabled = True
        Me.CmbShift.Items.AddRange(New Object() {"1", "2", "3"})
        Me.CmbShift.Location = New System.Drawing.Point(485, 39)
        Me.CmbShift.Name = "CmbShift"
        Me.CmbShift.Size = New System.Drawing.Size(146, 21)
        Me.CmbShift.TabIndex = 9
        '
        'TxtProblem
        '
        Me.TxtProblem.Location = New System.Drawing.Point(704, 39)
        Me.TxtProblem.Multiline = True
        Me.TxtProblem.Name = "TxtProblem"
        Me.TxtProblem.Size = New System.Drawing.Size(160, 40)
        Me.TxtProblem.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(643, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Problem"
        '
        'TxtAnalisis
        '
        Me.TxtAnalisis.Location = New System.Drawing.Point(704, 84)
        Me.TxtAnalisis.Multiline = True
        Me.TxtAnalisis.Name = "TxtAnalisis"
        Me.TxtAnalisis.Size = New System.Drawing.Size(160, 40)
        Me.TxtAnalisis.TabIndex = 13
        '
        'DtTarget
        '
        Me.DtTarget.CustomFormat = "dd-MM-yyyy"
        Me.DtTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTarget.Location = New System.Drawing.Point(485, 83)
        Me.DtTarget.Name = "DtTarget"
        Me.DtTarget.Size = New System.Drawing.Size(146, 20)
        Me.DtTarget.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(643, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Analisis"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(866, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Preventive Action"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(869, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "Corrective Action"
        '
        'TxtPreventive
        '
        Me.TxtPreventive.Location = New System.Drawing.Point(963, 86)
        Me.TxtPreventive.Multiline = True
        Me.TxtPreventive.Name = "TxtPreventive"
        Me.TxtPreventive.Size = New System.Drawing.Size(160, 40)
        Me.TxtPreventive.TabIndex = 15
        '
        'TxtCorrection
        '
        Me.TxtCorrection.Location = New System.Drawing.Point(963, 41)
        Me.TxtCorrection.Multiline = True
        Me.TxtCorrection.Name = "TxtCorrection"
        Me.TxtCorrection.Size = New System.Drawing.Size(160, 40)
        Me.TxtCorrection.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1141, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(178, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'BGambar
        '
        Me.BGambar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BGambar.Location = New System.Drawing.Point(1194, 130)
        Me.BGambar.Name = "BGambar"
        Me.BGambar.Size = New System.Drawing.Size(75, 23)
        Me.BGambar.TabIndex = 102
        Me.BGambar.Text = "Cari Gambar"
        Me.BGambar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(436, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 13)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "Lot"
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(485, 61)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.Size = New System.Drawing.Size(146, 20)
        Me.TxtLotNo.TabIndex = 10
        '
        'FrmQualityProblemDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1331, 581)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtLotNo)
        Me.Controls.Add(Me.BGambar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtPreventive)
        Me.Controls.Add(Me.TxtCorrection)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DtTarget)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtAnalisis)
        Me.Controls.Add(Me.TxtProblem)
        Me.Controls.Add(Me.CmbShift)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPic)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtInvtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtInvtID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtTanggalLaporan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCustomer)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmQualityProblemDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomer, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLaporan, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtID, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtType, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtStatus, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtPic, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.BAdd, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.CmbShift, 0)
        Me.Controls.SetChildIndex(Me.TxtProblem, 0)
        Me.Controls.SetChildIndex(Me.TxtAnalisis, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.DtTarget, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtCorrection, 0)
        Me.Controls.SetChildIndex(Me.TxtPreventive, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.BGambar, 0)
        Me.Controls.SetChildIndex(Me.TxtLotNo, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
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
    Friend WithEvents BAdd As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtPic As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtType As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtInvtName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtInvtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DtTanggalLaporan As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbShift As ComboBox
    Friend WithEvents TxtProblem As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtAnalisis As TextBox
    Friend WithEvents DtTarget As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtPreventive As TextBox
    Friend WithEvents TxtCorrection As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Shift As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Problem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Analisis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CorrectionAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PreventiveAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Target As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGambar As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtLotNo As TextBox
    Friend WithEvents LotNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Path As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GambarHapus As DevExpress.XtraGrid.Columns.GridColumn
End Class
