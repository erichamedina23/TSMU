Imports DevExpress.XtraEditors.Controls

Public Class FrmEntertain_Detail2
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    '  Dim ObjPaymentHeader As New payment_header_models
    'Dim ObjPaymentDetail As New payment_detail_models
    Dim _id As String
    Dim _nama As String
    Dim Grid As DevExpress.XtraGrid.GridControl
    Dim IsNew As Boolean
    Dim DtTabale As DataTable

    Dim fs_Split As String = "'"

    Dim ObjEntertain As New EntertainHeaderModel
    Public Sub New(ByVal ID As String,
                   ByVal Nama As String,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As DevExpress.XtraGrid.GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _id = ID
        _nama = Nama
        IsNew = _IsNew
        Grid = _grid
        DtTabale = _dt
    End Sub

    Private Sub _account_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _account.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If sender.Name = _account.Name Then
                dtSearch = ObjEntertain.GetAccount
                ls_OldKode = _account.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _account.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    '    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    '   Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                    _account.Text = Value1
                    _accountname.Text = Value2
                    '  _TxtToBank.Text = Value3
                    '  _TxtNoRek.Text = Value4

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()

    End Sub

    Private Sub _account_EditValueChanged(sender As Object, e As EventArgs) Handles _account.EditValueChanged

    End Sub

    Private Sub FrmEntertain_Detail2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
