<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditDirectPayment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me._txtcuryid = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._txtaccountname = New System.Windows.Forms.TextBox()
        Me._txtaccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._txtperpost = New System.Windows.Forms.TextBox()
        Me._TxtSettleAmount = New System.Windows.Forms.TextBox()
        Me._TxtSuspendAmount = New System.Windows.Forms.TextBox()
        Me._TxtTransaksi = New System.Windows.Forms.TextBox()
        Me._TxtTgl = New System.Windows.Forms.DateTimePicker()
        Me._TxtNoBukti = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me._txtcuryid)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me._txtaccountname)
        Me.GroupBox1.Controls.Add(Me._txtaccount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me._txtperpost)
        Me.GroupBox1.Controls.Add(Me._TxtSettleAmount)
        Me.GroupBox1.Controls.Add(Me._TxtSuspendAmount)
        Me.GroupBox1.Controls.Add(Me._TxtTransaksi)
        Me.GroupBox1.Controls.Add(Me._TxtTgl)
        Me.GroupBox1.Controls.Add(Me._TxtNoBukti)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(758, 275)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Edit Rekening"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "CuyID"
        '
        '_txtcuryid
        '
        Me._txtcuryid.Enabled = False
        Me._txtcuryid.Location = New System.Drawing.Point(160, 220)
        Me._txtcuryid.Name = "_txtcuryid"
        Me._txtcuryid.Size = New System.Drawing.Size(78, 20)
        Me._txtcuryid.TabIndex = 22
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(387, 231)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(305, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_txtaccountname
        '
        Me._txtaccountname.Enabled = False
        Me._txtaccountname.Location = New System.Drawing.Point(244, 192)
        Me._txtaccountname.Name = "_txtaccountname"
        Me._txtaccountname.Size = New System.Drawing.Size(461, 20)
        Me._txtaccountname.TabIndex = 19
        '
        '_txtaccount
        '
        Me._txtaccount.Location = New System.Drawing.Point(160, 193)
        Me._txtaccount.Name = "_txtaccount"
        Me._txtaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._txtaccount.Size = New System.Drawing.Size(78, 20)
        Me._txtaccount.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "No. Rekening"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Perpost"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sette Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Advance Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Transaksi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tanggal"
        '
        '_txtperpost
        '
        Me._txtperpost.Enabled = False
        Me._txtperpost.Location = New System.Drawing.Point(160, 165)
        Me._txtperpost.Name = "_txtperpost"
        Me._txtperpost.Size = New System.Drawing.Size(78, 20)
        Me._txtperpost.TabIndex = 6
        '
        '_TxtSettleAmount
        '
        Me._TxtSettleAmount.Enabled = False
        Me._TxtSettleAmount.Location = New System.Drawing.Point(160, 138)
        Me._TxtSettleAmount.Name = "_TxtSettleAmount"
        Me._TxtSettleAmount.Size = New System.Drawing.Size(105, 20)
        Me._TxtSettleAmount.TabIndex = 5
        '
        '_TxtSuspendAmount
        '
        Me._TxtSuspendAmount.Enabled = False
        Me._TxtSuspendAmount.Location = New System.Drawing.Point(160, 111)
        Me._TxtSuspendAmount.Name = "_TxtSuspendAmount"
        Me._TxtSuspendAmount.Size = New System.Drawing.Size(105, 20)
        Me._TxtSuspendAmount.TabIndex = 4
        '
        '_TxtTransaksi
        '
        Me._TxtTransaksi.Enabled = False
        Me._TxtTransaksi.Location = New System.Drawing.Point(160, 84)
        Me._TxtTransaksi.Name = "_TxtTransaksi"
        Me._TxtTransaksi.Size = New System.Drawing.Size(545, 20)
        Me._TxtTransaksi.TabIndex = 3
        '
        '_TxtTgl
        '
        Me._TxtTgl.Enabled = False
        Me._TxtTgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me._TxtTgl.Location = New System.Drawing.Point(160, 57)
        Me._TxtTgl.Name = "_TxtTgl"
        Me._TxtTgl.Size = New System.Drawing.Size(134, 20)
        Me._TxtTgl.TabIndex = 2
        '
        '_TxtNoBukti
        '
        Me._TxtNoBukti.Enabled = False
        Me._TxtNoBukti.Location = New System.Drawing.Point(160, 30)
        Me._TxtNoBukti.Name = "_TxtNoBukti"
        Me._TxtNoBukti.Size = New System.Drawing.Size(105, 20)
        Me._TxtNoBukti.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No. Bukti"
        '
        'FrmEditDirectPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmEditDirectPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEditDirectPayment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents _TxtNoBukti As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents _txtperpost As TextBox
    Friend WithEvents _TxtSettleAmount As TextBox
    Friend WithEvents _TxtSuspendAmount As TextBox
    Friend WithEvents _TxtTransaksi As TextBox
    Friend WithEvents _TxtTgl As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents _txtaccountname As TextBox
    Friend WithEvents _txtaccount As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents _txtcuryid As TextBox
End Class
