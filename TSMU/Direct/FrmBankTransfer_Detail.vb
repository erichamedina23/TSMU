Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmBankTransfer_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New TransferModel
    Dim ObjSuspendHeader As New TransferModel
    Dim GridDtl As GridControl
    Dim f As FrmBankTransfer_Detail 
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ObjSuspend As New ClsSuspend
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _SuspendID As String = ""
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

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Bank Transfer " & fs_Code
            Else
                Me.Text = "New Bank Transfer"
            End If

            'TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmBankTransfer"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TxtTgl.EditValue = .Tgl
                    TxtNoBukti.Text = .NoBukti
                    TxtPerpost.Text = .Perpost
                    TxtNoRekAsal.Text = .AcctID_Asal
                    TxtNoRekAsalname.Text = .Descr_Asal
                    TxtCheckNo.Text = .CheckNo
                    TxtNoRekTujuan.Text = .AcctID_tujuan
                    TxtNoRekTujuanname.Text = .Descr_tujuan
                    TxtCuryID.Text = .CurryID
                    TxtAmount.Text = .Jumlah
                    TxtRemark.Text = .Remark
                    TxtNoBukti.ReadOnly = True
                    TxtCuryTujuan.Text = .CuryID_tujuan
                    TxtRate.Text = .Rate_Transaksi
                    TxtRateSolomon.Text = .Rate_Solomon
                    TxtSelisihRate.Text = .Selisih_Kursi
                    TxtAmount1.Text = Format(.Jumlah * .Rate_Solomon, "##,0")
                    TxtAmount2.Text = Format(.Jumlah * .Rate_Transaksi, "##,0")

                    ''_txtaccname.focus()
                End With
            Else
                ' TxtTgl.Text = Date()
                TxtTgl.EditValue = DateTime.Today
                TxtNoBukti.Text = ""
                ''TxtPerpost.Text = ""
                TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
                TxtNoRekTujuan.Text = ""
                TxtNoRekTujuanname.Text = ""
                TxtCheckNo.Text = ""
                '        TxtNoRekTujuan.Text = ""
                '       TxtNoRekTujuanname.Text = ""
                '      TxtCuryID.SelectedIndex = 0
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
            If String.IsNullOrEmpty(TxtNoRekAsal.Text) Then
                errProvider.SetError(TxtNoRekAsal, "Value cannot be empty.")
            Else
                errProvider.SetError(TxtNoRekAsal, "")
            End If
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

            If errProvider.GetError(TxtNoRekAsal).Length > 0 Then
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
                        TxtNoBukti.Text = .TransferAutoNo()
                    End If
                    .NoBukti = TxtNoBukti.Text
                    .Perpost = TxtPerpost.Text
                    .AcctID_Asal = TxtNoRekAsal.Text
                    .Descr_Asal = TxtNoRekAsalname.Text
                    .CheckNo = TxtCheckNo.Text
                    .AcctID_tujuan = TxtNoRekTujuan.Text
                    .Descr_tujuan = TxtNoRekTujuanname.Text
                    .CurryID = TxtCuryID.Text
                    .Jumlah = TxtAmount.Text
                    .Remark = TxtRemark.Text
                    .CuryID_tujuan = TxtCuryTujuan.Text
                    .Rate_Transaksi = TxtRate.Text
                    .Rate_Solomon = TxtRateSolomon.Text
                    .Selisih_Kursi = TxtSelisihRate.Text
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
                fc_Class.NoVouch = fc_Class.autononb()
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
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub TxtNoRekAsal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoRekAsal.EditValueChanged
        'Try
        '    Dim ls_Judul As String = ""
        '    Dim dtSearch As New DataTable
        '    Dim ls_OldKode As String = ""

        '    Dim ObjSuspend As New ClsSuspend
        '    If sender.Name = TxtNoRekAsal.Name Then
        '        dtSearch = ObjSuspend.GetBank
        '        ls_OldKode = TxtNoRekAsal.Text.Trim
        '        ls_Judul = "Account"
        '    End If

        '    Dim lF_SearchData As FrmSystem_LookupGrid
        '    lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        '    lF_SearchData.Text = "Select Data " & ls_Judul
        '    lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        '    lF_SearchData.ShowDialog()
        '    Dim Value1 As String = ""
        '    Dim Value2 As String = ""
        '    Dim Value3 As String = ""
        '    Dim Rate1 As String = ""

        '    If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
        '        If sender.Name = TxtNoRekAsal.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
        '            Value1 = lF_SearchData.Values.Item(0).ToString.Trim
        '            Value2 = lF_SearchData.Values.Item(1).ToString.Trim
        '            Value3 = lF_SearchData.Values.Item(2).ToString.Trim
        '            TxtNoRekAsal.Text = Value1
        '            TxtNoRekAsalname.Text = Value2
        '            TxtCuryID.Text = Value3
        '        End If
        '    End If

        '    Dim Rate As String
        '    Rate = ObjSuspendHeader.GetRate(Value3.TrimEnd)
        '    TxtRateSolomon.Text = Rate

        '    lF_SearchData.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub

    Private Sub TxtNoRekAsal_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRekAsal.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtNoRekAsal.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = TxtNoRekAsal.Text.Trim
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

                If sender.Name = TxtNoRekAsal.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    TxtNoRekAsal.Text = Value1
                    TxtNoRekAsalname.Text = Value2
                    TxtCuryID.Text = Value3
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
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
            Dim Rate1 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                If sender.Name = TxtNoRekTujuan.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    TxtNoRekTujuan.Text = Value1
                    TxtNoRekTujuanname.Text = Value2
                    TxtCuryTujuan.Text = Value3
                End If
            End If

            Dim Rate As String
            Rate = ObjSuspendHeader.GetRate(Value3.TrimEnd)
            TxtRateSolomon.Text = Rate

            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Public Overrides Sub Proc_print()
        Try
            Dim newform As New FrmReportBankTransfer(TxtNoBukti.Text, TxtCuryID.Text, TxtCuryTujuan.Text)
            newform.StartPosition = FormStartPosition.CenterScreen
            newform.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmBankTransfer_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)

        Call InitialSetForm()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub TxtAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAmount.EditValueChanged

    End Sub

    Private Sub TxtAmount_LostFocus(sender As Object, e As EventArgs) Handles TxtAmount.LostFocus
        'TxtAmount1.Text = TxtRateSolomon.Text * TxtAmount.Text
        'TxtAmount2.Text = TxtRate.Text * TxtAmount.Text
        'TxtSelisihRate.Text = TxtAmount1.Text - TxtAmount2.Text

        'TxtAmount1.Text = Format(TxtRateSolomon.Text * TxtAmount.Text, "##,0")
        'TxtAmount2.Text = Format(TxtRate.Text * TxtAmount.Text, "##,0")
        'TxtSelisihRate.Text = Format(TxtAmount1.Text - TxtAmount2.Text, "##,0")

        'TxtAmount1.Text = Format(TxtRateSolomon.Text * TxtAmount.Text, gs_FormatBulat)
        'TxtAmount2.Text = Format(TxtRate.Text * TxtAmount.Text, gs_FormatBulat)
        'TxtSelisihRate.Text = Format(TxtAmount1.Text - TxtAmount2.Text, gs_FormatBulat)

        TxtAmount1.EditValue = Format(TxtRateSolomon.EditValue * TxtAmount.EditValue, gs_FormatBulat)
        TxtAmount2.EditValue = Format(TxtRate.EditValue * TxtAmount.EditValue, gs_FormatBulat)
        TxtSelisihRate.EditValue = Format(TxtAmount1.EditValue - TxtAmount2.EditValue, gs_FormatBulat)

    End Sub

End Class
