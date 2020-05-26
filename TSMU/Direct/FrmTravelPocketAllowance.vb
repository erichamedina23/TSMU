Public Class FrmTravelPocketAllowance

    Dim ff_Detail As FrmTravelPocketAllowanceDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New TravelPocketAllowanceModel

    Private Sub FrmTravelPocketAllowance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = GridPocketAllowance.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            GridPocketAllowance.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravelPocketAllowanceDetail(ls_Code, ls_Code2, Me, li_Row, GridPocketAllowance)
        ff_Detail.MdiParent = MenuUtamaForm
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub
End Class
