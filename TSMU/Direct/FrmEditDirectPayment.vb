Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmEditDirectPayment
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String
    Dim ff_Detail As FrmPaymentDirect
    Public ReadOnly Property Perpost() As String
        Get
            Return _txtperpost.Text
        End Get

    End Property

    Public ReadOnly Property Rekening() As String
        Get
            Return _txtaccount.Text
        End Get
    End Property
    Sub New(NoBukti As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = NoBukti
    End Sub
    Private Sub FrmEditDirectPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataCashBank()
    End Sub
    Private Sub _txtaccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _txtaccount.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = _txtaccount.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = _txtaccount.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _txtaccount.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    _txtaccount.Text = Value1
                    _txtaccountname.Text = Value2
                    _txtcuryid.Text = Value3
                    ObjCashBank.curyid = Value3
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub DataCashBank()

        'ObjCashBank.Perpost = _txtperpost.Text
        'ObjCashBank.AcctID = _txtaccount.Text
        ObjCashBank.GetDirekPaymentById(_NoBukti)

        With ObjCashBank
            _TxtNoBukti.Text = .NoBukti
            _TxtTgl.Text = .Tgl
            _TxtTransaksi.Text = .Transaksi
            _TxtSuspendAmount.Text = .SettleAmount
            _TxtSettleAmount.Text = .SuspendAmount
            _txtperpost.Text = .Perpost
            _txtaccount.Text = .AcctID
            _txtcuryid.Text = .curyid

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "")
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        '  FrmPaymentDirect.Close()
        ff_Detail = New FrmPaymentDirect(ls_Code, ls_Code2, Me)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Call CallFrm(_txtperpost.Text, _txtaccount.Text)
        tabu1()
        Me.Close()
    End Sub
    Private Sub tabu1()

        Dim ObjDetails As New cashbank_models
        With ObjDetails
            .NoBukti = _TxtNoBukti.Text
            .Perpost = _txtperpost.Text
            .AcctID = _txtaccount.Text
            .UpdateVoucher()
        End With

    End Sub

End Class