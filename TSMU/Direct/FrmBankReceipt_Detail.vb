Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmBankReceipt_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ReceiptModel
    Dim ObjSuspendHeader As New ReceiptModel
    Dim GridDtl As GridControl
    Dim f As FrmBankReceipt_Detail
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable
    Dim ObjCashBank As New cashbank_models
    Dim ObjSuspend As New ClsSuspend
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SuspendID As String = ""
    Dim fs_kode3 As String
    Dim fs_kode4 As String
    Dim sts_screen2 As Byte


    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal strCode3 As String,
                   ByVal strCode4 As String,
                   ByVal stsscreen As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            fs_kode3 = strCode3
            fs_kode4 = strCode4
            sts_screen2 = stsscreen
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" And sts_screen2 <> 1 Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Bank receipt " & fs_Code
            Else
                Me.Text = "New Bank receipt"
            End If

            'TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmBankReceipt"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" And sts_screen2 <> 1 Then
                With fc_Class
                    TxtTgl.EditValue = .Tgl
                    TxtNoBukti.Text = .NoBukti
                    TxtPerpost.Text = .Perpost
                    TxtCheckNo.Text = .CheckNo
                    TxtNoRekTujuan.Text = .AcctID_tujuan
                    TxtNoRekTujuanname.Text = .Descr_tujuan
                    TxtNoRek.Text = .AcctID
                    TxtNoRekName.Text = .AcctID_Name
                    TxtCuryID.Text = .CurryID
                    TxtCustID.Text = .CustID
                    TxtCustomer.Text = .Customer
                    TxtAmount.Text = .Jumlah
                    TxtRemark.Text = .Remark
                    TxtNoBukti.ReadOnly = True
                    ''_txtaccname.focus()
                End With
            ElseIf fs_Code <> "" And sts_screen2 = 1 Then
                TxtTgl.EditValue = DateTime.Today
                TxtNoBukti.Text = ""
                TxtPerpost.EditValue = fs_kode4
                TxtCheckNo.Text = ""
                TxtNoRekTujuan.Text = fs_Code
                TxtNoRekTujuanname.Text = fs_Code2
                TxtNoRek.Text = ""
                TxtNoRekName.Text = ""
                TxtCuryID.Text = fs_kode3
                TxtAmount.Text = 0
                TxtRemark.Text = ""
                TxtNoBukti.Focus()
            Else
                ' TxtTgl.Text = Date()
                TxtTgl.EditValue = DateTime.Today
                TxtNoBukti.Text = ""
                TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
                TxtCheckNo.Text = ""
                '            TxtNoRekTujuan.Text = ""
                '           TxtNoRekTujuanname.Text = ""
                ' TxtCuryID.SelectedIndex = 0
                TxtAmount.Text = 0
                TxtRemark.Text = ""
                TxtNoBukti.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Try

            If String.IsNullOrEmpty(TxtNoRekTujuan.Text) Then
                errProvider.SetError(TxtNoRekTujuan, "Value cannot be empty.")
            Else
                errProvider.SetError(TxtNoRekTujuan, "")
            End If
            If String.IsNullOrEmpty(TxtPerpost.Text) Then
                errProvider.SetError(TxtPerpost, "Value cannot be empty.")
            Else
                errProvider.SetError(TxtPerpost, "")
            End If

            If String.IsNullOrEmpty(TxtCuryID.Text) Then
                errProvider.SetError(TxtCuryID, "Value cannot be empty.")
            Else
                errProvider.SetError(TxtCuryID, "")
            End If
            If String.IsNullOrEmpty(TxtAmount.Text) Then
                errProvider.SetError(TxtAmount, "Value cannot be empty.")
            Else
                errProvider.SetError(TxtAmount, "")
            End If

            Dim success As Boolean = True

            If errProvider.GetError(TxtNoRekTujuan).Length > 0 Then
                success = False
            End If


            If success Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Please check your input field !")
            End If
            If lb_Validated Then


                With fc_Class
                    Dim oDate As DateTime = DateTime.ParseExact(TxtTgl.Text, "dd-MM-yyyy", provider)
                    .Tgl = oDate
                    ' .Tgl = TxtTgl.Text
                    If isUpdate = False Then
                        TxtNoBukti.Text = .receiptAutoNo()
                    End If
                    .NoBukti = TxtNoBukti.Text
                    .Perpost = TxtPerpost.Text
                    .CustID = TxtCustID.Text
                    .Customer = TxtCustomer.Text
                    .CheckNo = TxtCheckNo.Text
                    .AcctID_tujuan = TxtNoRekTujuan.Text
                    .Descr_tujuan = TxtNoRekTujuanname.Text
                    .CurryID = TxtCuryID.Text
                    .CustID = TxtCustID.Text
                    .Customer = TxtCustomer.Text
                    .Jumlah = TxtAmount.Text
                    .Remark = TxtRemark.Text
                    .AcctID = TxtNoRek.Text
                    .AcctID_Name = TxtNoRekName.Text
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try



            If isUpdate = False Then
                fc_Class.Insert()
                fc_Class.NoVouch = fc_Class.autononb()
                fc_Class.InsertToTable2()
                fc_Class.InsertToTable3()
            Else
                fc_Class.Update()
            End If

            '' GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            'Dim targetString As String = TxtNoRekAsalId.Text
            'For Each row As DataGridViewRow In Me.GridDtl.Rows
            '    If RTrim(row.Cells(0).Value.ToString) = targetString Then
            '        Me.GridDtl.ClearSelection()
            '        Me.GridDtl.Rows(row.Index).Selected = True
            '        Exit For
            '    End If
            'Next
            IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            If sts_screen2 = 1 Then
                ObjCashBank.Perpost = _TxtPerpost.Text
                ObjCashBank.AcctID = TxtNoRekTujuan.Text
                GridDtl.DataSource = ObjCashBank.GetGridDetailCashBankByAccountID02()
            Else
                GridDtl.DataSource = fc_Class.GetDataGrid
            End If

            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub



    Private Sub TxtNoRekTujuan_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRekTujuan.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtNoRekTujuan.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = TxtNoRekTujuan.Text.Trim
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

                If sender.Name = TxtNoRekTujuan.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    TxtNoRekTujuan.Text = Value1
                    TxtNoRekTujuanname.Text = Value2
                    TxtCuryID.Text = Value3
                    If Trim(TxtCuryID.Text) = "IDR" And Trim(TxtCustID.Text) <> "" Then
                        TxtNoRek.Text = "11440"
                        TxtNoRekName.Text = "Trade Receivable Third Party"

                    ElseIf Trim(TxtCuryID.Text) = "USD" And Trim(TxtCustID.Text) <> "" Then
                        TxtNoRek.Text = "11442"
                        TxtNoRekName.Text = "Trade Receivable Third Party-$"
                    ElseIf Trim(TxtCustID.Text) <> "" Then
                        TxtNoRek.Text = "11441"
                        TxtNoRekName.Text = "Trade Receivable Third Party-"
                    Else
                        TxtNoRek.Text = ""
                        TxtNoRekName.Text = ""
                    End If
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub FrmBankReceipt_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call InitialSetForm()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TxtCustID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtCustID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtCustID.Name Then
                dtSearch = ObjSuspend.GetCustomer
                ls_OldKode = TxtCustID.Text.Trim
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

                If sender.Name = TxtCustID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    TxtCustID.Text = Value1
                    TxtCustomer.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtNoRek_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRek.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtNoRek.Name Then
                dtSearch = ObjSuspend.GetAccount
                ls_OldKode = TxtNoRek.Text.Trim
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

                If sender.Name = TxtNoRek.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    TxtNoRek.Text = Value1
                    TxtNoRekName.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
