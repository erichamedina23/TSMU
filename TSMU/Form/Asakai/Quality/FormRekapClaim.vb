Public Class FormRekapClaim

    Dim dtGrid As DataTable
    Dim fc_Class As New ClaimCustomerModel


    Private Sub BCari_Click(sender As Object, e As EventArgs) Handles BCari.Click

        Dim Tanggalawal As Date
        Dim TanggalAhir As Date

        Tanggalawal = Convert.ToDateTime(DateAwal.EditValue)
        TanggalAhir = Convert.ToDateTime(DateAhir.EditValue)

        Call LoadGrid(Tanggalawal, TanggalAhir)


    End Sub

    Private Sub FormRekapClaim_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadGrid(TanggalAwal As Date, TanggalAhir As Date)
        Try
            dtGrid = fc_Class.GetRekapClaim(TanggalAwal, TanggalAhir)
            GridControl.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub
End Class