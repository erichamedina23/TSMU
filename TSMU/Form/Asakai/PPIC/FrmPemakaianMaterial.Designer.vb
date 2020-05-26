<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPemakaianMaterial
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtKolomQty = New System.Windows.Forms.TextBox()
        Me.TxtKolomHarga = New System.Windows.Forms.TextBox()
        Me.TxtBarisMaterial1 = New System.Windows.Forms.TextBox()
        Me.TxtBarisMaterial2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtBarisKomponen2 = New System.Windows.Forms.TextBox()
        Me.TxtBarisKomponen1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TargetMaterial = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtInjectionMaterial = New System.Windows.Forms.TextBox()
        Me.TxtAktualProduksiMaterial = New System.Windows.Forms.TextBox()
        Me.TxtPercentMaterial = New System.Windows.Forms.TextBox()
        Me.TxtSalesMaterial = New System.Windows.Forms.TextBox()
        Me.TxtAktualRpMaterial = New System.Windows.Forms.TextBox()
        Me.GridMaterial = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TargetKomponen = New System.Windows.Forms.TextBox()
        Me.GridKomponen = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtInjectionKomponen = New System.Windows.Forms.TextBox()
        Me.TxtAktualProduksiKomponen = New System.Windows.Forms.TextBox()
        Me.TxtPercentKomponen = New System.Windows.Forms.TextBox()
        Me.TxtSalesKomponen = New System.Windows.Forms.TextBox()
        Me.TxtAktualRpKomponen = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TanggalMulai = New System.Windows.Forms.DateTimePicker()
        Me.TanggalSampai = New System.Windows.Forms.DateTimePicker()
        Me.TxtKeterangan = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridKomponen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(545, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Browse Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtKolomQty
        '
        Me.TxtKolomQty.Location = New System.Drawing.Point(420, 32)
        Me.TxtKolomQty.Name = "TxtKolomQty"
        Me.TxtKolomQty.Size = New System.Drawing.Size(69, 20)
        Me.TxtKolomQty.TabIndex = 6
        Me.TxtKolomQty.Text = "3"
        '
        'TxtKolomHarga
        '
        Me.TxtKolomHarga.Location = New System.Drawing.Point(420, 55)
        Me.TxtKolomHarga.Name = "TxtKolomHarga"
        Me.TxtKolomHarga.Size = New System.Drawing.Size(69, 20)
        Me.TxtKolomHarga.TabIndex = 7
        Me.TxtKolomHarga.Text = "4"
        '
        'TxtBarisMaterial1
        '
        Me.TxtBarisMaterial1.Location = New System.Drawing.Point(105, 35)
        Me.TxtBarisMaterial1.Name = "TxtBarisMaterial1"
        Me.TxtBarisMaterial1.Size = New System.Drawing.Size(78, 20)
        Me.TxtBarisMaterial1.TabIndex = 8
        Me.TxtBarisMaterial1.Text = "A19"
        '
        'TxtBarisMaterial2
        '
        Me.TxtBarisMaterial2.Location = New System.Drawing.Point(224, 35)
        Me.TxtBarisMaterial2.Name = "TxtBarisMaterial2"
        Me.TxtBarisMaterial2.Size = New System.Drawing.Size(69, 20)
        Me.TxtBarisMaterial2.TabIndex = 9
        Me.TxtBarisMaterial2.Text = "CN286"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Kolom Qty"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(325, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Kolom Harga"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Baris Material"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "s/d"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Baris Komponen"
        '
        'TxtBarisKomponen2
        '
        Me.TxtBarisKomponen2.Location = New System.Drawing.Point(224, 58)
        Me.TxtBarisKomponen2.Name = "TxtBarisKomponen2"
        Me.TxtBarisKomponen2.Size = New System.Drawing.Size(69, 20)
        Me.TxtBarisKomponen2.TabIndex = 16
        Me.TxtBarisKomponen2.Text = "CN588"
        '
        'TxtBarisKomponen1
        '
        Me.TxtBarisKomponen1.Location = New System.Drawing.Point(105, 58)
        Me.TxtBarisKomponen1.Name = "TxtBarisKomponen1"
        Me.TxtBarisKomponen1.Size = New System.Drawing.Size(78, 20)
        Me.TxtBarisKomponen1.TabIndex = 15
        Me.TxtBarisKomponen1.Text = "A293"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(195, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "s/d"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TargetMaterial)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtInjectionMaterial)
        Me.GroupBox1.Controls.Add(Me.TxtAktualProduksiMaterial)
        Me.GroupBox1.Controls.Add(Me.TxtPercentMaterial)
        Me.GroupBox1.Controls.Add(Me.TxtSalesMaterial)
        Me.GroupBox1.Controls.Add(Me.TxtAktualRpMaterial)
        Me.GroupBox1.Controls.Add(Me.GridMaterial)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 519)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material"
        '
        'TargetMaterial
        '
        Me.TargetMaterial.Location = New System.Drawing.Point(312, 83)
        Me.TargetMaterial.Name = "TargetMaterial"
        Me.TargetMaterial.ReadOnly = True
        Me.TargetMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TargetMaterial.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(226, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "% Target"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(226, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "% Injection"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(226, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Aktual Produksi"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Sales"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Aktual Rp"
        '
        'TxtInjectionMaterial
        '
        Me.TxtInjectionMaterial.Location = New System.Drawing.Point(312, 53)
        Me.TxtInjectionMaterial.Name = "TxtInjectionMaterial"
        Me.TxtInjectionMaterial.ReadOnly = True
        Me.TxtInjectionMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtInjectionMaterial.TabIndex = 20
        '
        'TxtAktualProduksiMaterial
        '
        Me.TxtAktualProduksiMaterial.Location = New System.Drawing.Point(312, 27)
        Me.TxtAktualProduksiMaterial.Name = "TxtAktualProduksiMaterial"
        Me.TxtAktualProduksiMaterial.ReadOnly = True
        Me.TxtAktualProduksiMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualProduksiMaterial.TabIndex = 19
        '
        'TxtPercentMaterial
        '
        Me.TxtPercentMaterial.Location = New System.Drawing.Point(80, 79)
        Me.TxtPercentMaterial.Name = "TxtPercentMaterial"
        Me.TxtPercentMaterial.ReadOnly = True
        Me.TxtPercentMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercentMaterial.TabIndex = 18
        '
        'TxtSalesMaterial
        '
        Me.TxtSalesMaterial.Location = New System.Drawing.Point(80, 53)
        Me.TxtSalesMaterial.Name = "TxtSalesMaterial"
        Me.TxtSalesMaterial.ReadOnly = True
        Me.TxtSalesMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtSalesMaterial.TabIndex = 17
        '
        'TxtAktualRpMaterial
        '
        Me.TxtAktualRpMaterial.Location = New System.Drawing.Point(80, 27)
        Me.TxtAktualRpMaterial.Name = "TxtAktualRpMaterial"
        Me.TxtAktualRpMaterial.ReadOnly = True
        Me.TxtAktualRpMaterial.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualRpMaterial.TabIndex = 16
        '
        'GridMaterial
        '
        Me.GridMaterial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridMaterial.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridMaterial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridMaterial.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridMaterial.Location = New System.Drawing.Point(9, 120)
        Me.GridMaterial.Name = "GridMaterial"
        Me.GridMaterial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridMaterial.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GridMaterial.Size = New System.Drawing.Size(651, 385)
        Me.GridMaterial.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TargetKomponen)
        Me.GroupBox2.Controls.Add(Me.GridKomponen)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TxtInjectionKomponen)
        Me.GroupBox2.Controls.Add(Me.TxtAktualProduksiKomponen)
        Me.GroupBox2.Controls.Add(Me.TxtPercentKomponen)
        Me.GroupBox2.Controls.Add(Me.TxtSalesKomponen)
        Me.GroupBox2.Controls.Add(Me.TxtAktualRpKomponen)
        Me.GroupBox2.Location = New System.Drawing.Point(704, 132)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(489, 519)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Komponen"
        '
        'TargetKomponen
        '
        Me.TargetKomponen.Location = New System.Drawing.Point(312, 82)
        Me.TargetKomponen.Name = "TargetKomponen"
        Me.TargetKomponen.ReadOnly = True
        Me.TargetKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TargetKomponen.TabIndex = 51
        '
        'GridKomponen
        '
        Me.GridKomponen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridKomponen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridKomponen.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridKomponen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridKomponen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridKomponen.DefaultCellStyle = DataGridViewCellStyle5
        Me.GridKomponen.Location = New System.Drawing.Point(9, 120)
        Me.GridKomponen.Name = "GridKomponen"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridKomponen.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GridKomponen.Size = New System.Drawing.Size(474, 385)
        Me.GridKomponen.TabIndex = 50
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(226, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "% Target"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(226, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "% Injection"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(226, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Aktual Produksi"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 85)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Sales"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Aktual Rp"
        '
        'TxtInjectionKomponen
        '
        Me.TxtInjectionKomponen.Location = New System.Drawing.Point(312, 52)
        Me.TxtInjectionKomponen.Name = "TxtInjectionKomponen"
        Me.TxtInjectionKomponen.ReadOnly = True
        Me.TxtInjectionKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TxtInjectionKomponen.TabIndex = 42
        '
        'TxtAktualProduksiKomponen
        '
        Me.TxtAktualProduksiKomponen.Location = New System.Drawing.Point(312, 26)
        Me.TxtAktualProduksiKomponen.Name = "TxtAktualProduksiKomponen"
        Me.TxtAktualProduksiKomponen.ReadOnly = True
        Me.TxtAktualProduksiKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualProduksiKomponen.TabIndex = 41
        '
        'TxtPercentKomponen
        '
        Me.TxtPercentKomponen.Location = New System.Drawing.Point(80, 78)
        Me.TxtPercentKomponen.Name = "TxtPercentKomponen"
        Me.TxtPercentKomponen.ReadOnly = True
        Me.TxtPercentKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercentKomponen.TabIndex = 40
        '
        'TxtSalesKomponen
        '
        Me.TxtSalesKomponen.Location = New System.Drawing.Point(80, 52)
        Me.TxtSalesKomponen.Name = "TxtSalesKomponen"
        Me.TxtSalesKomponen.ReadOnly = True
        Me.TxtSalesKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TxtSalesKomponen.TabIndex = 39
        '
        'TxtAktualRpKomponen
        '
        Me.TxtAktualRpKomponen.Location = New System.Drawing.Point(80, 26)
        Me.TxtAktualRpKomponen.Name = "TxtAktualRpKomponen"
        Me.TxtAktualRpKomponen.ReadOnly = True
        Me.TxtAktualRpKomponen.Size = New System.Drawing.Size(100, 20)
        Me.TxtAktualRpKomponen.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Tanggal Mulai"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Tanggal Sampai"
        '
        'TanggalMulai
        '
        Me.TanggalMulai.CustomFormat = "dd-MMMM-yyyy"
        Me.TanggalMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TanggalMulai.Location = New System.Drawing.Point(105, 81)
        Me.TanggalMulai.Name = "TanggalMulai"
        Me.TanggalMulai.Size = New System.Drawing.Size(188, 20)
        Me.TanggalMulai.TabIndex = 41
        Me.TanggalMulai.Value = New Date(2019, 10, 1, 0, 0, 0, 0)
        '
        'TanggalSampai
        '
        Me.TanggalSampai.CustomFormat = "dd-MMMM-yyyy"
        Me.TanggalSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TanggalSampai.Location = New System.Drawing.Point(105, 104)
        Me.TanggalSampai.Name = "TanggalSampai"
        Me.TanggalSampai.Size = New System.Drawing.Size(188, 20)
        Me.TanggalSampai.TabIndex = 42
        Me.TanggalSampai.Value = New Date(2019, 10, 1, 0, 0, 0, 0)
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKeterangan.Location = New System.Drawing.Point(328, 81)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.ReadOnly = True
        Me.TxtKeterangan.Size = New System.Drawing.Size(327, 45)
        Me.TxtKeterangan.TabIndex = 43
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmPemakaianMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1205, 663)
        Me.Controls.Add(Me.TxtKeterangan)
        Me.Controls.Add(Me.TanggalSampai)
        Me.Controls.Add(Me.TanggalMulai)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtBarisKomponen2)
        Me.Controls.Add(Me.TxtBarisKomponen1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBarisMaterial2)
        Me.Controls.Add(Me.TxtBarisMaterial1)
        Me.Controls.Add(Me.TxtKolomHarga)
        Me.Controls.Add(Me.TxtKolomQty)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmPemakaianMaterial"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.TxtKolomQty, 0)
        Me.Controls.SetChildIndex(Me.TxtKolomHarga, 0)
        Me.Controls.SetChildIndex(Me.TxtBarisMaterial1, 0)
        Me.Controls.SetChildIndex(Me.TxtBarisMaterial2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtBarisKomponen1, 0)
        Me.Controls.SetChildIndex(Me.TxtBarisKomponen2, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.TanggalMulai, 0)
        Me.Controls.SetChildIndex(Me.TanggalSampai, 0)
        Me.Controls.SetChildIndex(Me.TxtKeterangan, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridKomponen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TxtKolomQty As TextBox
    Friend WithEvents TxtKolomHarga As TextBox
    Friend WithEvents TxtBarisMaterial1 As TextBox
    Friend WithEvents TxtBarisMaterial2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtBarisKomponen2 As TextBox
    Friend WithEvents TxtBarisKomponen1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtInjectionMaterial As TextBox
    Friend WithEvents TxtAktualProduksiMaterial As TextBox
    Friend WithEvents TxtPercentMaterial As TextBox
    Friend WithEvents TxtSalesMaterial As TextBox
    Friend WithEvents TxtAktualRpMaterial As TextBox
    Friend WithEvents GridMaterial As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GridKomponen As DataGridView
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TxtInjectionKomponen As TextBox
    Friend WithEvents TxtAktualProduksiKomponen As TextBox
    Friend WithEvents TxtPercentKomponen As TextBox
    Friend WithEvents TxtSalesKomponen As TextBox
    Friend WithEvents TxtAktualRpKomponen As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TargetMaterial As TextBox
    Friend WithEvents TargetKomponen As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TanggalMulai As DateTimePicker
    Friend WithEvents TanggalSampai As DateTimePicker
    Friend WithEvents TxtKeterangan As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
