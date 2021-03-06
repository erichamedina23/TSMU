﻿Imports System.Globalization

Public Class FormPerbaikan

    Dim ff_Detail As FrmDetailPerbaikan
    Dim dtGrid As DataTable
    Dim fc_Class As New MaintenanPerbaikanModel
    Dim IDTransaksi As String
    Dim Tanggal As Date

    Private Sub FormPerbaikan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
    End Sub


    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmDetailPerbaikan(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
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
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "IDTransaksi")
                    End If
                Next rowHandle
                'fc_Class.ObjDetails.Add(ObjMaterialUsageDetail)

                fc_Class.DeleteAll(IDTrans)
                'fc_Class.DeleteDetail(IDTrans)
                Call LoadGrid()
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
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
            IDTransaksi = String.Empty

            fc_Class = New MaintenanPerbaikanModel
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IDTransaksi = GridView1.GetRowCellValue(rowHandle, "IDTransaksi")
                    Dim oDate As DateTime = DateTime.ParseExact(GridView1.GetRowCellValue(rowHandle, "Tanggal"), "dd-MM-yyyy", provider)
                    Tanggal = oDate
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(IDTransaksi,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
