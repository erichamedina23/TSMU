Imports System.Globalization

Public Class Frm_NPP_Header

    Dim ff_Detail As Frm_NPP_Detail
    Dim dtGrid As DataTable
    Dim DtDelete As DataTable
    Dim fc_Class As New Cls_NPP_Header

    Dim FrmReport As ReportNPWO


    Private Sub Frm_Npwo_Header_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        dtGrid = New DataTable
        dtGrid.Columns.AddRange(New DataColumn(6) {New DataColumn("NPP", GetType(String)),
                                                            New DataColumn("Issue Date", GetType(String)),
                                                            New DataColumn("Model", GetType(String)),
                                                            New DataColumn("Customer", GetType(String)),
                                                            New DataColumn("Order Of Month", GetType(String)),
                                                            New DataColumn("Approve", GetType(Boolean)),
                                                            New DataColumn("Rev", GetType(Int32))})
        Grid.DataSource = dtGrid




        bb_SetDisplayChangeConfirmation = False
        LoadGrid()
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)

    End Sub
    Private Sub LoadGrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class.Get_NPP()
            Grid.DataSource = dt
            'Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
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
        ff_Detail = New Frm_NPP_Detail(ls_Code, ls_Code2, Me, li_Row, Grid)
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
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_DeleteData()

        Dim NP As String = ""


        Dim selectedRows() As Integer = GridView1.GetSelectedRows()

        If GridView1.RowCount > 0 Then
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NP = GridView1.GetRowCellValue(rowHandle, "NPP")
                End If
            Next rowHandle

            DtDelete = New DataTable
            DtDelete = fc_Class.GetDelete(NP)

            If DtDelete.Rows.Count <= 0 Then
                fc_Class.Delete(NP)
                Call LoadGrid()
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            Else
                MessageBox.Show("Data Cannot be Deleted
                                 (Already in NPWO)",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            End If



        Else

        End If


    End Sub


    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim NoNpwo As String = ""
            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoNpwo = GridView1.GetRowCellValue(rowHandle, "NPP")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoNpwo, "",
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        FrmReport = New ReportNPWO()
        FrmReport.StartPosition = FormStartPosition.CenterScreen
        FrmReport.MaximizeBox = False
        FrmReport.ShowDialog()
    End Sub
End Class
