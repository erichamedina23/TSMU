Imports System.Globalization
Public Class Frm_CR_UserCreateHeader

    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New CR_UserCreateModel
    Dim fc_ClassCRUD As New ClsCR_CreateUser
    Dim IdTrans As String
    Dim Dept As String
    Dim Tanggal As Date
    Dim DeptSub As String = ""

    Private Sub Frm_CR_UserCreateHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bb_SetDisplayChangeConfirmation = False
        Dept = gh_Common.GroupID
        LoadGrid(Dept)
        'Call Sub_Dept(gh_Common.GroupID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
    End Sub
    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
            Dim dt As New DataTable
            dt = fc_ClassCRUD.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Sub Tidak Ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                DeptSub = (dt.Rows(0).Item("Sub"))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub LoadGrid(Dept As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class.Get_CRRequest(Dept)
            Grid.DataSource = dt
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
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
        ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid(gh_Common.GroupID)
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
        Dim IDTrans As String = ""

        Try
            'fc_Class.ObjDetails.Clear()
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            'ObjMaterialUsageDetail = New MaterialUsageDetailModel

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        'ObjMaterialUsageDetail.IDMaterialUsage = GridView1.GetRowCellValue(rowHandle, "IDMaterialUsage")
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "CirculationNo")
                    End If
                Next rowHandle

                Try

                    ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
                    Dim dt As New DataTable
                    dt = fc_ClassCRUD.Get_Data_CR_Delete(IDTrans, gh_Common.GroupID)
                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show("Circulation '" & IDTrans & "' Cannot Delete",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                        Exit Sub
                    Else

                        fc_ClassCRUD.Delete(IDTrans, gh_Common.GroupID)
                        Call LoadGrid(gh_Common.GroupID)
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    End If


                Catch ex As Exception
                    Throw
                End Try



            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView1.GetRowCellValue(rowHandle, "Circulation No")
                    'Tanggal = Convert.ToDateTime(GridView1.GetRowCellValue(rowHandle, "Tanggal"))
                    ' Dim oDate As DateTime = DateTime.ParseExact(GridView1.GetRowCellValue(rowHandle, "Tanggal"), "dd-MM-yyyy", provider)
                    'Tanggal = Convert.ToDateTime(GridView1.GetRowCellValue(rowHandle, "Tanggal"))
                    'Tanggal = oDate
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub
End Class
