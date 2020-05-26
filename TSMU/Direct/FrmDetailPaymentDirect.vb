Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports TSMU
Public Class FrmDetailPaymentDirect
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String
    Dim ff_Detail As FrmSuspendSettleDetail
    Dim ff_Detail1 As FrmSuspendSettleDetailDirect
    Dim ID As String
    Dim suspendid As String
    Dim suspend1 As String

    Sub New(NoBukti As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = NoBukti
    End Sub
    Private Sub DataCashBank()
        Dim dtGrid As New DataTable
        'ObjCashBank.Perpost = _txtperpost.Text
        'ObjCashBank.AcctID = _txtaccount.Text
        dtGrid = ObjCashBank.GetGridDetailCashBankByAccountID03(_NoBukti)
        GridControl1.DataSource = dtGrid
        GridCellFormat(GridView1)

    End Sub

    Private Sub FrmDetailPaymentDirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataCashBank()
        GetTot2()
    End Sub
    Private Sub CallFrmDirect(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail1 IsNot Nothing AndAlso ff_Detail1.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail1.Close()
        End If
        ff_Detail1 = New FrmSuspendSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, GridControl1)
        ff_Detail1.MdiParent = FrmMain
        ff_Detail1.StartPosition = FormStartPosition.CenterScreen
        ff_Detail1.Show()
    End Sub
    Private Sub BtnRefNo_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnRefNo.ButtonClick

        'Try
        '    Dim newform As New FrmReportSettle
        '    Dim stext As String
        '    newform.StartPosition = FormStartPosition.CenterScreen
        '    For i As Integer = 0 To GridView1.RowCount - 1
        '        stext = GridView1.GetRowCellValue(i, "Noref")
        '        stext = Replace(stext, " / ", "")
        '        newform.TxtNosettle.Text = stext
        '    Next
        '    newform.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        Try

            'Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As BaseView = GridControl1.GetViewAt(ea.Location)
            'If view Is Nothing Then
            '    Return
            'End If
            'Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            'Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            'If info.InRow OrElse info.InRowCell Then

            ID = String.Empty
                suspendid = String.Empty
                suspend1 = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()

                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "ID")
                    suspendid = Replace(GridView1.GetRowCellValue(rowHandle, "Noref"), " ", "")
                    suspendid = RTrim(Microsoft.VisualBasic.Right(suspendid, 15))
                    ''   suspend1 = IIf(GridView1.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridView1.GetRowCellValue(rowHandle, "SuspendID")))
                End If
                Next rowHandle

                If suspend1 = "" Then

                'Call CallFrmDirect(ID, suspendid,
                '     GridView1.RowCount)

                Dim fs As FrmSuspendSettleDetailDirect
                '' belum                fs = New FrmSuspendSettleDetailDirect(suspendid)
                fs.Show()
            Else

                    ''Call CallFrm(ID,
                    ''    suspendid,
                    ''   GridView1.RowCount)
                End If
            '         End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Private Sub GetTot2()
        Dim TotAmount As Double = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "SettleAmount"))
            Next

            If TotAmount = 0 Then
                LblTotAmount2.Text = "0"
            Else
                LblTotAmount2.Text = Format(TotAmount, gs_FormatBulat)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




End Class