<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaintenanceDetail
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
        Me.DtTanggalLaporan = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Mesin_Old = New System.Windows.Forms.TextBox()
        Me.Ket_Mesin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Balance_Mesin = New System.Windows.Forms.TextBox()
        Me.Act_Mesin = New System.Windows.Forms.TextBox()
        Me.Plan_Mesin = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Mold_Old = New System.Windows.Forms.TextBox()
        Me.Ket_Mold = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Balance_Mold = New System.Windows.Forms.TextBox()
        Me.Act_Mold = New System.Windows.Forms.TextBox()
        Me.Plan_Mold = New System.Windows.Forms.TextBox()
        Me.BtnBulan = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtTanggalLaporan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(148, 91)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(154, 26)
        Me.DtTanggalLaporan.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Tanggal "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Mesin_Old)
        Me.GroupBox1.Controls.Add(Me.Ket_Mesin)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Balance_Mesin)
        Me.GroupBox1.Controls.Add(Me.Act_Mesin)
        Me.GroupBox1.Controls.Add(Me.Plan_Mesin)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 317)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mesin"
        '
        'Mesin_Old
        '
        Me.Mesin_Old.BackColor = System.Drawing.Color.White
        Me.Mesin_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mesin_Old.Location = New System.Drawing.Point(293, 158)
        Me.Mesin_Old.Name = "Mesin_Old"
        Me.Mesin_Old.ReadOnly = True
        Me.Mesin_Old.Size = New System.Drawing.Size(103, 26)
        Me.Mesin_Old.TabIndex = 89
        Me.Mesin_Old.Text = "0"
        Me.Mesin_Old.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mesin_Old.Visible = False
        '
        'Ket_Mesin
        '
        Me.Ket_Mesin.BackColor = System.Drawing.Color.White
        Me.Ket_Mesin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ket_Mesin.Location = New System.Drawing.Point(133, 215)
        Me.Ket_Mesin.Multiline = True
        Me.Ket_Mesin.Name = "Ket_Mesin"
        Me.Ket_Mesin.Size = New System.Drawing.Size(263, 75)
        Me.Ket_Mesin.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 20)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Keterangan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Balance"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 20)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Actual"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Planning"
        '
        'Balance_Mesin
        '
        Me.Balance_Mesin.BackColor = System.Drawing.Color.White
        Me.Balance_Mesin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Balance_Mesin.Location = New System.Drawing.Point(133, 158)
        Me.Balance_Mesin.Name = "Balance_Mesin"
        Me.Balance_Mesin.ReadOnly = True
        Me.Balance_Mesin.Size = New System.Drawing.Size(154, 26)
        Me.Balance_Mesin.TabIndex = 3
        Me.Balance_Mesin.Text = "0"
        Me.Balance_Mesin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Act_Mesin
        '
        Me.Act_Mesin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Act_Mesin.Location = New System.Drawing.Point(133, 102)
        Me.Act_Mesin.Name = "Act_Mesin"
        Me.Act_Mesin.Size = New System.Drawing.Size(154, 26)
        Me.Act_Mesin.TabIndex = 2
        Me.Act_Mesin.Text = "0"
        Me.Act_Mesin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Plan_Mesin
        '
        Me.Plan_Mesin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Plan_Mesin.Location = New System.Drawing.Point(133, 44)
        Me.Plan_Mesin.Name = "Plan_Mesin"
        Me.Plan_Mesin.Size = New System.Drawing.Size(154, 26)
        Me.Plan_Mesin.TabIndex = 1
        Me.Plan_Mesin.Text = "0"
        Me.Plan_Mesin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Mold_Old)
        Me.GroupBox2.Controls.Add(Me.Ket_Mold)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Balance_Mold)
        Me.GroupBox2.Controls.Add(Me.Act_Mold)
        Me.GroupBox2.Controls.Add(Me.Plan_Mold)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(516, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(447, 317)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mold"
        '
        'Mold_Old
        '
        Me.Mold_Old.BackColor = System.Drawing.Color.White
        Me.Mold_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mold_Old.Location = New System.Drawing.Point(327, 158)
        Me.Mold_Old.Name = "Mold_Old"
        Me.Mold_Old.ReadOnly = True
        Me.Mold_Old.Size = New System.Drawing.Size(97, 26)
        Me.Mold_Old.TabIndex = 91
        Me.Mold_Old.Text = "0"
        Me.Mold_Old.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Mold_Old.Visible = False
        '
        'Ket_Mold
        '
        Me.Ket_Mold.BackColor = System.Drawing.Color.White
        Me.Ket_Mold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ket_Mold.Location = New System.Drawing.Point(127, 215)
        Me.Ket_Mold.Multiline = True
        Me.Ket_Mold.Name = "Ket_Mold"
        Me.Ket_Mold.Size = New System.Drawing.Size(297, 75)
        Me.Ket_Mold.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 20)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Keterangan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Balance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Actual"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 20)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Planning"
        '
        'Balance_Mold
        '
        Me.Balance_Mold.BackColor = System.Drawing.Color.White
        Me.Balance_Mold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Balance_Mold.Location = New System.Drawing.Point(127, 157)
        Me.Balance_Mold.Name = "Balance_Mold"
        Me.Balance_Mold.ReadOnly = True
        Me.Balance_Mold.Size = New System.Drawing.Size(194, 26)
        Me.Balance_Mold.TabIndex = 7
        Me.Balance_Mold.Text = "0"
        Me.Balance_Mold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Act_Mold
        '
        Me.Act_Mold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Act_Mold.Location = New System.Drawing.Point(127, 101)
        Me.Act_Mold.Name = "Act_Mold"
        Me.Act_Mold.Size = New System.Drawing.Size(194, 26)
        Me.Act_Mold.TabIndex = 6
        Me.Act_Mold.Text = "0"
        Me.Act_Mold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Plan_Mold
        '
        Me.Plan_Mold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Plan_Mold.Location = New System.Drawing.Point(127, 43)
        Me.Plan_Mold.Name = "Plan_Mold"
        Me.Plan_Mold.Size = New System.Drawing.Size(194, 26)
        Me.Plan_Mold.TabIndex = 5
        Me.Plan_Mold.Text = "0"
        Me.Plan_Mold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnBulan
        '
        Me.BtnBulan.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnBulan.Location = New System.Drawing.Point(15, 42)
        Me.BtnBulan.Name = "BtnBulan"
        Me.BtnBulan.Size = New System.Drawing.Size(138, 23)
        Me.BtnBulan.TabIndex = 84
        Me.BtnBulan.Text = "Target Bulanan"
        Me.BtnBulan.UseVisualStyleBackColor = False
        '
        'FrmMaintenanceDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(990, 441)
        Me.Controls.Add(Me.BtnBulan)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DtTanggalLaporan)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMaintenanceDetail"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLaporan, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.BtnBulan, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtTanggalLaporan As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Balance_Mesin As TextBox
    Friend WithEvents Act_Mesin As TextBox
    Friend WithEvents Plan_Mesin As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Balance_Mold As TextBox
    Friend WithEvents Act_Mold As TextBox
    Friend WithEvents Plan_Mold As TextBox
    Friend WithEvents Ket_Mesin As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Ket_Mold As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Mesin_Old As TextBox
    Friend WithEvents Mold_Old As TextBox
    Friend WithEvents BtnBulan As Button
End Class
