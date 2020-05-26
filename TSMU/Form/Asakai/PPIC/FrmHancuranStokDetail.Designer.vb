<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHancuranStokDetail
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DtTanggal = New System.Windows.Forms.DateTimePicker()
        Me.TxtTarget = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtStokNG = New System.Windows.Forms.TextBox()
        Me.TxtStokMix = New System.Windows.Forms.TextBox()
        Me.TxtStokPallet = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStokAkhir = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtOut = New System.Windows.Forms.TextBox()
        Me.TxtIN = New System.Windows.Forms.TextBox()
        Me.TxtTotalPagi = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTotalOK = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'DtTanggal
        '
        Me.DtTanggal.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggal.Location = New System.Drawing.Point(190, 39)
        Me.DtTanggal.Name = "DtTanggal"
        Me.DtTanggal.Size = New System.Drawing.Size(171, 20)
        Me.DtTanggal.TabIndex = 12
        '
        'TxtTarget
        '
        Me.TxtTarget.Location = New System.Drawing.Point(190, 155)
        Me.TxtTarget.Name = "TxtTarget"
        Me.TxtTarget.Size = New System.Drawing.Size(171, 20)
        Me.TxtTarget.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "TARGET"
        '
        'TxtStokNG
        '
        Me.TxtStokNG.Location = New System.Drawing.Point(190, 125)
        Me.TxtStokNG.Name = "TxtStokNG"
        Me.TxtStokNG.Size = New System.Drawing.Size(171, 20)
        Me.TxtStokNG.TabIndex = 35
        '
        'TxtStokMix
        '
        Me.TxtStokMix.Location = New System.Drawing.Point(190, 96)
        Me.TxtStokMix.Name = "TxtStokMix"
        Me.TxtStokMix.Size = New System.Drawing.Size(171, 20)
        Me.TxtStokMix.TabIndex = 34
        '
        'TxtStokPallet
        '
        Me.TxtStokPallet.Location = New System.Drawing.Point(190, 68)
        Me.TxtStokPallet.Name = "TxtStokPallet"
        Me.TxtStokPallet.Size = New System.Drawing.Size(171, 20)
        Me.TxtStokPallet.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "STOK GRI NG (KG)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "STOK GRI PROSES MIX (KG)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "STOK GRI PROSES PALLET (KG)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "TANGGAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(381, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "TOTAL HANCURAN OK"
        '
        'TxtStokAkhir
        '
        Me.TxtStokAkhir.BackColor = System.Drawing.SystemColors.Window
        Me.TxtStokAkhir.Location = New System.Drawing.Point(559, 155)
        Me.TxtStokAkhir.Name = "TxtStokAkhir"
        Me.TxtStokAkhir.ReadOnly = True
        Me.TxtStokAkhir.Size = New System.Drawing.Size(171, 20)
        Me.TxtStokAkhir.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(381, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "STOK AHIR"
        '
        'TxtOut
        '
        Me.TxtOut.Location = New System.Drawing.Point(559, 125)
        Me.TxtOut.Name = "TxtOut"
        Me.TxtOut.Size = New System.Drawing.Size(171, 20)
        Me.TxtOut.TabIndex = 45
        '
        'TxtIN
        '
        Me.TxtIN.Location = New System.Drawing.Point(559, 96)
        Me.TxtIN.Name = "TxtIN"
        Me.TxtIN.Size = New System.Drawing.Size(171, 20)
        Me.TxtIN.TabIndex = 44
        '
        'TxtTotalPagi
        '
        Me.TxtTotalPagi.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalPagi.Location = New System.Drawing.Point(559, 68)
        Me.TxtTotalPagi.Name = "TxtTotalPagi"
        Me.TxtTotalPagi.ReadOnly = True
        Me.TxtTotalPagi.Size = New System.Drawing.Size(171, 20)
        Me.TxtTotalPagi.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(381, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "HANCURAN KELUAR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(381, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "HANCURAN MASUK"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(381, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "TOTAL HANCURAN PAGI"
        '
        'TxtTotalOK
        '
        Me.TxtTotalOK.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalOK.Location = New System.Drawing.Point(559, 40)
        Me.TxtTotalOK.Name = "TxtTotalOK"
        Me.TxtTotalOK.ReadOnly = True
        Me.TxtTotalOK.Size = New System.Drawing.Size(171, 20)
        Me.TxtTotalOK.TabIndex = 49
        '
        'FrmHancuranStokDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.TxtTotalOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtStokAkhir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtOut)
        Me.Controls.Add(Me.TxtIN)
        Me.Controls.Add(Me.TxtTotalPagi)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTarget)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtStokNG)
        Me.Controls.Add(Me.TxtStokMix)
        Me.Controls.Add(Me.TxtStokPallet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtTanggal)
        Me.Name = "FrmHancuranStokDetail"
        Me.Controls.SetChildIndex(Me.DtTanggal, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtStokPallet, 0)
        Me.Controls.SetChildIndex(Me.TxtStokMix, 0)
        Me.Controls.SetChildIndex(Me.TxtStokNG, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtTarget, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtTotalPagi, 0)
        Me.Controls.SetChildIndex(Me.TxtIN, 0)
        Me.Controls.SetChildIndex(Me.TxtOut, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtStokAkhir, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtTotalOK, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtTanggal As DateTimePicker
    Friend WithEvents TxtTarget As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtStokNG As TextBox
    Friend WithEvents TxtStokMix As TextBox
    Friend WithEvents TxtStokPallet As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtStokAkhir As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtOut As TextBox
    Friend WithEvents TxtIN As TextBox
    Friend WithEvents TxtTotalPagi As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtTotalOK As TextBox
End Class
