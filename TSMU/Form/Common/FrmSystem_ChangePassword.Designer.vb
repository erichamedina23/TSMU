<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSystem_ChangePassword
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPwdLama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPwdBaru = New System.Windows.Forms.TextBox()
        Me.TxtKonfirmasi = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(180, 84)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(253, 84)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Old Password"
        '
        'TxtPwdLama
        '
        Me.TxtPwdLama.Location = New System.Drawing.Point(148, 6)
        Me.TxtPwdLama.MaxLength = 200
        Me.TxtPwdLama.Name = "TxtPwdLama"
        Me.TxtPwdLama.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwdLama.Size = New System.Drawing.Size(172, 20)
        Me.TxtPwdLama.TabIndex = 0
        Me.TxtPwdLama.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "New Password Confirmation"
        '
        'TxtPwdBaru
        '
        Me.TxtPwdBaru.Location = New System.Drawing.Point(148, 32)
        Me.TxtPwdBaru.MaxLength = 200
        Me.TxtPwdBaru.Name = "TxtPwdBaru"
        Me.TxtPwdBaru.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwdBaru.Size = New System.Drawing.Size(172, 20)
        Me.TxtPwdBaru.TabIndex = 1
        Me.TxtPwdBaru.UseSystemPasswordChar = True
        '
        'TxtKonfirmasi
        '
        Me.TxtKonfirmasi.Location = New System.Drawing.Point(148, 58)
        Me.TxtKonfirmasi.MaxLength = 200
        Me.TxtKonfirmasi.Name = "TxtKonfirmasi"
        Me.TxtKonfirmasi.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtKonfirmasi.Size = New System.Drawing.Size(172, 20)
        Me.TxtKonfirmasi.TabIndex = 2
        Me.TxtKonfirmasi.UseSystemPasswordChar = True
        '
        'FrmSystem_ChangePassword
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(335, 118)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TxtKonfirmasi)
        Me.Controls.Add(Me.TxtPwdBaru)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPwdLama)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSystem_ChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPwdLama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPwdBaru As System.Windows.Forms.TextBox
    Friend WithEvents TxtKonfirmasi As System.Windows.Forms.TextBox

End Class
