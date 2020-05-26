<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSystem_ConfigInputBox
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
        Me.TxtInput = New System.Windows.Forms.TextBox()
        Me.TxtLabel = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtInput
        '
        Me.TxtInput.Location = New System.Drawing.Point(12, 91)
        Me.TxtInput.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtInput.MaxLength = 100
        Me.TxtInput.Name = "TxtInput"
        Me.TxtInput.Size = New System.Drawing.Size(332, 20)
        Me.TxtInput.TabIndex = 1
        '
        'TxtLabel
        '
        Me.TxtLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLabel.Location = New System.Drawing.Point(12, 29)
        Me.TxtLabel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TxtLabel.MaxLength = 200
        Me.TxtLabel.Multiline = True
        Me.TxtLabel.Name = "TxtLabel"
        Me.TxtLabel.ReadOnly = True
        Me.TxtLabel.Size = New System.Drawing.Size(331, 56)
        Me.TxtLabel.TabIndex = 0
        Me.TxtLabel.TabStop = False
        Me.TxtLabel.Text = "SILAHKAN MASUKKAN NILAI ?"
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(274, 140)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.Location = New System.Drawing.Point(199, 140)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(70, 23)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'FrmSystem_ConfigInputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 175)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtLabel)
        Me.Controls.Add(Me.TxtInput)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "FrmSystem_ConfigInputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input Box"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtInput As System.Windows.Forms.TextBox
    Friend WithEvents TxtLabel As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
End Class
