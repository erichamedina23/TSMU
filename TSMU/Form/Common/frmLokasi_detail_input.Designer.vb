<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLokasi_detail_input
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
        Me._cmbLokasi = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._txtId = New System.Windows.Forms.TextBox()
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
        Me.TabPage1.Controls.Add(Me._cmbLokasi)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me._txtDeskripsi)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me._txtId)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(796, 515)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input Lokasi"
        '
        '_cmbLokasi
        '
        Me._cmbLokasi.FormattingEnabled = True
        Me._cmbLokasi.Location = New System.Drawing.Point(107, 61)
        Me._cmbLokasi.MaxLength = 10
        Me._cmbLokasi.Name = "_cmbLokasi"
        Me._cmbLokasi.Size = New System.Drawing.Size(121, 21)
        Me._cmbLokasi.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Lokasi"
        '
        '_txtDeskripsi
        '
        Me._txtDeskripsi.Location = New System.Drawing.Point(107, 33)
        Me._txtDeskripsi.MaxLength = 50
        Me._txtDeskripsi.Name = "_txtDeskripsi"
        Me._txtDeskripsi.Size = New System.Drawing.Size(286, 20)
        Me._txtDeskripsi.TabIndex = 2
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
        '_txtId
        '
        Me._txtId.Location = New System.Drawing.Point(107, 7)
        Me._txtId.MaxLength = 10
        Me._txtId.Name = "_txtId"
        Me._txtId.Size = New System.Drawing.Size(121, 20)
        Me._txtId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Lokasi Detail"
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
        'frmLokasi_detail_input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmLokasi_detail_input"
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
    Friend WithEvents _txtDeskripsi As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents _txtId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents _cmbLokasi As ComboBox
    Friend WithEvents Label3 As Label
End Class
