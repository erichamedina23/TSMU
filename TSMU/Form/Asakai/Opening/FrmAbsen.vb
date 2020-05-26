Public Class FrmAbsen

    Dim ff_Detail As FrmAbsenDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New AbsenModel
    Dim ObjAbsen As New AbsenModel
    Dim ObjAbsenDetail As New AbsenModelDetail


    Dim TanggalAbsen As Date
    Dim DeptID As String
    Dim IDAbsen As String
    Dim Jumlah As Integer
    Dim Percentage As Double

    'Dim laporan As Form_Report



    Private Sub FrmAbsen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = GridControl.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)


    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetDataLoad()
            GridControl.DataSource = dtGrid
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
        ff_Detail = New FrmAbsenDetail(ls_Code, ls_Code2, Me, li_Row, GridControl)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Group"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            GridControl.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub GridControl_DoubleClick(sender As Object, e As EventArgs) Handles GridControl.DoubleClick
        Try
            DeptID = String.Empty
            Percentage = 0

            ObjAbsen = New AbsenModel
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ObjAbsen.NoIncrement = GridView1.GetRowCellValue(rowHandle, "ID")
                    TanggalAbsen = Convert.ToDateTime(GridView1.GetRowCellValue(rowHandle, "TanggalAbsen"))
                    DeptID = GridView1.GetRowCellValue(rowHandle, "DeptID")
                    Percentage = GridView1.GetRowCellValue(rowHandle, "Percentage")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(DeptID,
                            Format(TanggalAbsen, gs_FormatSQLDate),
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Public Overrides Sub Proc_DeleteData()
        Dim ID As Integer = 0

        Try
            ObjAbsen.ObjDetails.Clear()
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            ObjAbsenDetail = New AbsenModelDetail
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ObjAbsenDetail.NoAbsen = GridView1.GetRowCellValue(rowHandle, "ID")
                    ID = GridView1.GetRowCellValue(rowHandle, "ID")
                End If
            Next rowHandle

            ObjAbsen.ObjDetails.Add(ObjAbsenDetail)

            fc_Class.DeleteHeader(ID)
            Call LoadGrid()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridControl_Click(sender As Object, e As EventArgs) Handles GridControl.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
