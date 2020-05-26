Public Class CustomMsgBox
    Private WithEvents tm As New Timer
    Private Sub CustomMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = _labelPesan
        tm.Interval = 1500
        tm.Start()
    End Sub

    Private Sub tm_Tick(sender As Object, e As EventArgs) Handles tm.Tick
        Close()
    End Sub

    Private _labelPesan As String
    Public Property LabelPesan() As String
        Get
            Return _labelPesan
        End Get
        Set(ByVal value As String)
            _labelPesan = value
        End Set
    End Property
End Class