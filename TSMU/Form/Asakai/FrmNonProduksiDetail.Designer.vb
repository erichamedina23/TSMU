<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNonProduksiDetail
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
        Me.INFORMASI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMBAR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtInformasi = New System.Windows.Forms.TextBox()
        Me.TxtPIC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTambah = New System.Windows.Forms.Button()
        Me.BGambar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 211)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(785, 190)
        Me.Grid.TabIndex = 4
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.INFORMASI, Me.PIC, Me.GAMBAR})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'INFORMASI
        '
        Me.INFORMASI.FieldName = "INFORMASI"
        Me.INFORMASI.Name = "INFORMASI"
        Me.INFORMASI.Visible = True
        Me.INFORMASI.VisibleIndex = 0
        Me.INFORMASI.Width = 470
        '
        'PIC
        '
        Me.PIC.FieldName = "PIC"
        Me.PIC.Name = "PIC"
        Me.PIC.Visible = True
        Me.PIC.VisibleIndex = 1
        Me.PIC.Width = 127
        '
        'GAMBAR
        '
        Me.GAMBAR.FieldName = "GAMBAR"
        Me.GAMBAR.Name = "GAMBAR"
        Me.GAMBAR.Visible = True
        Me.GAMBAR.VisibleIndex = 2
        '
        'TxtInformasi
        '
        Me.TxtInformasi.Location = New System.Drawing.Point(95, 72)
        Me.TxtInformasi.Multiline = True
        Me.TxtInformasi.Name = "TxtInformasi"
        Me.TxtInformasi.Size = New System.Drawing.Size(241, 93)
        Me.TxtInformasi.TabIndex = 6
        '
        'TxtPIC
        '
        Me.TxtPIC.Location = New System.Drawing.Point(95, 51)
        Me.TxtPIC.Name = "TxtPIC"
        Me.TxtPIC.Size = New System.Drawing.Size(241, 20)
        Me.TxtPIC.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "TANGGAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "INFORMASI"
        '
        'DtTanggal
        '
        Me.DtTanggal.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggal.Location = New System.Drawing.Point(95, 29)
        Me.DtTanggal.Name = "DtTanggal"
        Me.DtTanggal.Size = New System.Drawing.Size(241, 20)
        Me.DtTanggal.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "PIC"
        '
        'BTambah
        '
        Me.BTambah.Location = New System.Drawing.Point(15, 182)
        Me.BTambah.Name = "BTambah"
        Me.BTambah.Size = New System.Drawing.Size(75, 23)
        Me.BTambah.TabIndex = 14
        Me.BTambah.Text = "TAMBAH"
        Me.BTambah.UseVisualStyleBackColor = True
        '
        'BGambar
        '
        Me.BGambar.Location = New System.Drawing.Point(370, 29)
        Me.BGambar.Name = "BGambar"
        Me.BGambar.Size = New System.Drawing.Size(95, 26)
        Me.BGambar.TabIndex = 106
        Me.BGambar.Text = "Cari Gambar"
        Me.BGambar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(342, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 105)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 105
        Me.PictureBox1.TabStop = False
        '
        'FrmNonProduksiDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(809, 413)
        Me.Controls.Add(Me.BGambar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BTambah)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtTanggal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPIC)
        Me.Controls.Add(Me.TxtInformasi)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmNonProduksiDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.TxtInformasi, 0)
        Me.Controls.SetChildIndex(Me.TxtPIC, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.DtTanggal, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.BTambah, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.BGambar, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtInformasi As TextBox
    Friend WithEvents TxtPIC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DtTanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents BTambah As Button
    Friend WithEvents INFORMASI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGambar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GAMBAR As DevExpress.XtraGrid.Columns.GridColumn
End Class
