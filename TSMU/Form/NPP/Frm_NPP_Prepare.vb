Public Class Frm_NPP_Prepare

    Dim fc_Class As New Cls_NPP_Detail

    Dim ID As String
    Private Sub Frm_NPP_Prepare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FillCombo()
    End Sub


    Public Sub New(ByVal _ID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ID = _ID

    End Sub

    Private Sub FillCombo()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetPrepare
            TPrepare.Properties.DataSource = Nothing
            TPrepare.Properties.DataSource = dt
            TPrepare.Properties.ValueMember = "Value"
            TPrepare.Properties.DisplayMember = "Value"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Bok_Click(sender As Object, e As EventArgs) Handles Bok.Click
        If TPrepare.Text = "" Or TPrepare.EditValue = "" Then
            MessageBox.Show("Please Select Prepare By",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            fc_Class.UpdatePrepare(ID, TPrepare.EditValue)
            Me.Close()
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click

        MessageBox.Show("Prepare is Null",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        fc_Class.UpdatePrepare(ID, "")
        Me.Close()

    End Sub
End Class