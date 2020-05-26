<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMesin_detail
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
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me._cmbLokasiDetail = New System.Windows.Forms.ComboBox()
        Me._dtBeli = New System.Windows.Forms.DateTimePicker()
        Me._txtAsset = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me._cmbGroup = New System.Windows.Forms.ComboBox()
        Me._cmbLokasi = New System.Windows.Forms.ComboBox()
        Me._txtdeff = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._txtIdMesin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TabPage1.Controls.Add(Me._cmbLokasiDetail)
        Me.TabPage1.Controls.Add(Me._dtBeli)
        Me.TabPage1.Controls.Add(Me._txtAsset)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me._cmbGroup)
        Me.TabPage1.Controls.Add(Me._cmbLokasi)
        Me.TabPage1.Controls.Add(Me._txtdeff)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me._txtDeskripsi)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me._txtIdMesin)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(796, 515)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input Lokasi"
        '
        '_cmbLokasiDetail
        '
        Me._cmbLokasiDetail.FormattingEnabled = True
        Me._cmbLokasiDetail.Location = New System.Drawing.Point(107, 116)
        Me._cmbLokasiDetail.MaxLength = 10
        Me._cmbLokasiDetail.Name = "_cmbLokasiDetail"
        Me._cmbLokasiDetail.Size = New System.Drawing.Size(121, 21)
        Me._cmbLokasiDetail.TabIndex = 5
        '
        '_dtBeli
        '
        Me._dtBeli.CustomFormat = "dd - MM - yyyy"
        Me._dtBeli.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me._dtBeli.Location = New System.Drawing.Point(504, 6)
        Me._dtBeli.Name = "_dtBeli"
        Me._dtBeli.Size = New System.Drawing.Size(105, 20)
        Me._dtBeli.TabIndex = 6
        '
        '_txtAsset
        '
        Me._txtAsset.Location = New System.Drawing.Point(504, 35)
        Me._txtAsset.MaxLength = 20
        Me._txtAsset.Name = "_txtAsset"
        Me._txtAsset.Size = New System.Drawing.Size(286, 20)
        Me._txtAsset.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(416, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Asset #"
        '
        '_cmbGroup
        '
        Me._cmbGroup.FormattingEnabled = True
        Me._cmbGroup.Location = New System.Drawing.Point(107, 62)
        Me._cmbGroup.MaxLength = 10
        Me._cmbGroup.Name = "_cmbGroup"
        Me._cmbGroup.Size = New System.Drawing.Size(121, 21)
        Me._cmbGroup.TabIndex = 3
        '
        '_cmbLokasi
        '
        Me._cmbLokasi.FormattingEnabled = True
        Me._cmbLokasi.Location = New System.Drawing.Point(107, 89)
        Me._cmbLokasi.MaxLength = 10
        Me._cmbLokasi.Name = "_cmbLokasi"
        Me._cmbLokasi.Size = New System.Drawing.Size(121, 21)
        Me._cmbLokasi.TabIndex = 4
        '
        '_txtdeff
        '
        Me._txtdeff.Location = New System.Drawing.Point(504, 63)
        Me._txtdeff.MaxLength = 50
        Me._txtdeff.Name = "_txtdeff"
        Me._txtdeff.Size = New System.Drawing.Size(286, 20)
        Me._txtdeff.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(416, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Defresiasi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ID Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "ID Lokasi"
        '
        '_txtDeskripsi
        '
        Me._txtDeskripsi.Location = New System.Drawing.Point(107, 35)
        Me._txtDeskripsi.MaxLength = 50
        Me._txtDeskripsi.Name = "_txtDeskripsi"
        Me._txtDeskripsi.Size = New System.Drawing.Size(286, 20)
        Me._txtDeskripsi.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tgl Beli"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Deskripsi"
        '
        '_txtIdMesin
        '
        Me._txtIdMesin.Location = New System.Drawing.Point(107, 7)
        Me._txtIdMesin.MaxLength = 10
        Me._txtIdMesin.Name = "_txtIdMesin"
        Me._txtIdMesin.Size = New System.Drawing.Size(121, 20)
        Me._txtIdMesin.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Mesin"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(804, 541)
        Me.TabControl1.TabIndex = 1
        '
        'frmMesin_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMesin_detail"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents _txtIdMesin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents _txtdeff As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents _txtDeskripsi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents _cmbGroup As ComboBox
    Friend WithEvents _cmbLokasi As ComboBox
    Friend WithEvents _txtAsset As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents _dtBeli As DateTimePicker
    Friend WithEvents _cmbLokasiDetail As ComboBox
End Class
