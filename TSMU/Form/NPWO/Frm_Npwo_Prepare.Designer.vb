<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Npwo_Prepare
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
        Me.TPrepare = New DevExpress.XtraEditors.LookUpEdit()
        Me.BCancel = New System.Windows.Forms.Button()
        Me.Bok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.TPrepare.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TPrepare
        '
        Me.TPrepare.Location = New System.Drawing.Point(96, 21)
        Me.TPrepare.Name = "TPrepare"
        Me.TPrepare.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TPrepare.Properties.DropDownRows = 4
        Me.TPrepare.Properties.MaxLength = 6
        Me.TPrepare.Properties.NullText = ""
        Me.TPrepare.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TPrepare.Properties.PopupSizeable = False
        Me.TPrepare.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TPrepare.Size = New System.Drawing.Size(158, 20)
        Me.TPrepare.TabIndex = 28
        '
        'BCancel
        '
        Me.BCancel.Location = New System.Drawing.Point(184, 64)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 27
        Me.BCancel.Text = "Cancel"
        Me.BCancel.UseVisualStyleBackColor = True
        '
        'Bok
        '
        Me.Bok.Location = New System.Drawing.Point(96, 64)
        Me.Bok.Name = "Bok"
        Me.Bok.Size = New System.Drawing.Size(70, 23)
        Me.Bok.TabIndex = 26
        Me.Bok.Text = "OK"
        Me.Bok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Prepared By"
        '
        'Frm_Npwo_Prepare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 109)
        Me.Controls.Add(Me.TPrepare)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.Bok)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frm_Npwo_Prepare"
        Me.Text = "NPWO Prepare By"
        CType(Me.TPrepare.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TPrepare As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BCancel As Button
    Friend WithEvents Bok As Button
    Friend WithEvents Label1 As Label
End Class
