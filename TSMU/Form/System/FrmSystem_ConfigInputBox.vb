Public Class FrmSystem_ConfigInputBox
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim ls_Prompt As String = "Input Nilai"
    Dim ls_Titles As String = "Input Box"
    Dim ls_DefaultValue As String = ""
    Dim ls_PasswordChar As String = ""

    Public Sub New(ByVal Prompt As String, Optional ByVal Titles As String = "Input Box", Optional ByVal DefaultValues As String = "", _
         Optional ByVal PasswordChar As String = "")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ls_Prompt = Prompt
        ls_Titles = Titles
        ls_DefaultValue = DefaultValues
        ls_PasswordChar = PasswordChar
    End Sub

    Private Sub FrmSystemInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ls_Titles
        TxtLabel.Text = ls_Prompt
        TxtInput.Text = ls_DefaultValue
        TxtInput.PasswordChar = ls_PasswordChar
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        rs_ReturnCode = TxtInput.Text
        Me.Hide()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        isCancel = True
        Me.Hide()
    End Sub

    Private Sub TxtInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.SendWait(vbTab)
        End If
    End Sub
End Class