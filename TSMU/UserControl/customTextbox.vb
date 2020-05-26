Public Class customTextbox
    Private txt As New TextBox
    Private btn As New Button

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Add the textbox to me
        Me.Controls.Add(txt)

        'Add the button to the textbox
        txt.Controls.Add(btn)

        'Dock the textbox to fill
        txt.Dock = DockStyle.Fill

        'Dock the button to the right and set the text as ...
        btn.Dock = DockStyle.Right
        btn.Text = "..."

        'Set the size for me
        Me.Size = txt.Size

    End Sub
    Private Sub customTextbox_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Height = txt.Height
    End Sub
End Class
