Public Class Frm_CR_ApproveDeptHead_Header
    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsCR_ApproveDeptHead
    Dim IdTrans As String
    Dim Dept As String
    Dim DeptHeadID As String
    Dim Tanggal As Date

    Private Sub Frm_CR_ApproveDeptHead_Header_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Dept = gh_Common.GroupID
        DeptHeadID = gh_Common.Username
        LoadGrid(DeptHeadID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(False, True, True, True, True, False, False, False, False, False, False)

    End Sub

    Private Sub LoadGrid(_DeptHeadID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class.Get_ApproveDeptHead(_DeptHeadID)
            Grid.DataSource = dt
            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class
