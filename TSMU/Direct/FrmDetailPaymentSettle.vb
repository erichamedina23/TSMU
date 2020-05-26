Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmDetailPaymentSettle
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String

    Sub New(SuspendID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = SuspendID
    End Sub
    Private Sub DataCashBank()
        Dim dtGrid As New DataTable
        'ObjCashBank.Perpost = _txtperpost.Text
        'ObjCashBank.AcctID = _txtaccount.Text
        dtGrid = ObjCashBank.GetGridDetailSettleByAccountID03(_NoBukti)
        GridControl1.DataSource = dtGrid
        GridCellFormat(GridView1)

    End Sub

    Private Sub FrmDetailPaymentSuspend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataCashBank()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class