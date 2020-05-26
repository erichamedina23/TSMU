Imports System.ComponentModel
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frm_fp_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim IsFilter As Boolean
    Dim ObjFP As New Cls_FP
    Dim ObjFPHeader As New fp_header_models
    Dim ObjFPTransaction As New fp_transaction_models
    Dim ObjPayment As New Cls_Payment
    Private Check As New RepositoryItemCheckEdit()

    Dim _emptyItem As RepositoryItem
    Dim btnActivate As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
    Dim btnDeactivate As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
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

    Private Sub frm_fp_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjFPHeader.id = fs_Code
                ObjFPHeader.GetFakturPajakById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "FP " & fs_Code
            Else
                Me.Text = "FP New Data"
            End If
            LoadGridDetil()
            Call LoadTxtBox()
            Call LoadGridNew()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_fp_new"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjFPHeader
                    _TxtNoTrans.Text = .FPNo
                    _LookUpSupplier.Text = .VendID
                    _TxtVendorName.Text = .Vend_Name
                    _TxtNPWP.Text = .npwp
                    _TxtJenisJasa.Text = .Jenis_Jasa
                    _DeDate.EditValue = .Tgl_fp
                    _TxtCurrency.Text = .CuryID
                    _TxtPPN.Text = Format(.Tot_Ppn, "##,0")
                    _TxtDppInvoice.Text = Format(.Tot_Dpp_Invoice, "##,0")
                    _TxtTotal.Text = Format(.Tot_Voucher, "##,0")
                    _TxtPPH.Text = Format(.Tot_Pph, "##,0")
                    _LookUpSupplier.Properties.Buttons(0).Visible = False
                    _LookUpSupplier.Properties.ReadOnly = True
                End With
            Else
                ObjFP = New Cls_FP
                _TxtNoTrans.Text = ObjFP.autono()
                _LookUpSupplier.Text = ""
                _TxtVendorName.Text = ""
                _TxtNPWP.Text = ""
                _TxtJenisJasa.Text = ""
                _DeDate.EditValue = DateTime.Today
                _TxtCurrency.Text = ""
                _TxtPPN.Text = "0"
                _TxtDppInvoice.Text = "0"
                _TxtTotal.Text = "0"
                _TxtPPH.Text = "0"
                _LookUpSupplier.Properties.Buttons(0).Visible = True
                _LookUpSupplier.Properties.ReadOnly = False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        '_LookUpSupplier.EditValue = "N0329          "
        Call LoadTxtBox()
        LoadGridDetil()
        LoadGridNew()
    End Sub

    Private Sub loadGridByVendor()
        Try
            Dim dt As New DataTable
            If _LookUpSupplier.Text = "" Then
                Exit Sub
            End If
            dt = ObjFP.GetDetailsGridFP(_LookUpSupplier.EditValue)
            If dt.Rows.Count > 0 Then
                _GridDetails.DataSource = dt
            Else
                _GridDetails.DataSource = dt
                XtraMessageBox.Show("Data tidak ditemukan !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetil()
        Dim IsExist As Boolean = False
        Try
            Dim dtGrid As New DataTable
            ObjFP.Fp = fs_Code2
            dtGrid = ObjFPHeader.GetGridDetails
            _GridDetails.DataSource = dtGrid
            'If GridView1.RowCount > 0 Then
            '    GetTot()
            'End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If
            If lb_Validated Then
                With ObjFPTransaction
                    .FPNo = _TxtNoTrans.Text
                    .VendID = _LookUpSupplier.Text.TrimEnd
                    .Vend_Name = _TxtVendorName.Text.TrimEnd
                    .npwp = _TxtNPWP.Text.TrimEnd
                    .Jenis_Jasa = _TxtJenisJasa.Text.TrimEnd
                    .Tgl_fp = _DeDate.EditValue
                    .CuryID = _TxtCurrency.Text.TrimEnd
                    .Tot_Ppn = _TxtPPN.Text
                    .Tot_Dpp_Invoice = _TxtDppInvoice.Text
                    .Tot_Voucher = _TxtTotal.Text
                    .Tot_Pph = _TxtPPH.Text
                    .Status = "1"
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try
            ObjFPTransaction.ObjFPDetails.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    Dim ObjFPDetails As New fp_details_models
                    With ObjFPDetails
                        .FPNo = _TxtNoTrans.Text.TrimEnd
                        .No_Invoice = GridView1.GetRowCellValue(i, "invcNbr").ToString().TrimEnd
                        .Tgl_Invoice = DateTime.Parse(GridView1.GetRowCellValue(i, "invcDate").ToString())
                        .Jml_Invoice = GridView1.GetRowCellValue(i, "Amount")
                        .CuryID = GridView1.GetRowCellValue(i, "CuryId")
                        .Ppn = GridView1.GetRowCellValue(i, "Ppn")
                        .Check_PPN = GridView1.GetRowCellValue(i, "Check_PPN")
                        .Dpp = GridView1.GetRowCellValue(i, "DPP")
                        .No_Faktur = GridView1.GetRowCellValue(i, "fp").ToString().TrimEnd
                        .link_barcode = "1"
                        .Pph = GridView1.GetRowCellValue(i, "Pph")
                        .No_Bukti_Potong = GridView1.GetRowCellValue(i, "NBP").ToString().TrimEnd
                    End With
                    ObjFPTransaction.ObjFPDetails.Add(ObjFPDetails)
                End If
            Next

            If isUpdate = False Then
                ObjFPTransaction.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjFPTransaction.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            GridDtl.DataSource = ObjFP.GetDataGridNew()

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Dim TotPPH As Double
    Dim TotAmount As Double
    Dim TotDpp As Double
    Dim TotPPn As Double
    Private Sub GetTot()
        TotPPH = 0
        TotAmount = 0
        TotDpp = 0
        TotPPn = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    TotPPH = TotPPH + CDbl(GridView1.GetRowCellValue(i, "Pph"))
                    TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "Amount"))
                    TotDpp = TotDpp + CDbl(GridView1.GetRowCellValue(i, "DPP"))
                    TotPPn = TotPPn + CDbl(GridView1.GetRowCellValue(i, "Ppn"))
                End If

            Next

            If TotPPn = 0 Then
                _TxtPPN.Text = "0"
            Else
                _TxtPPN.Text = Format(TotPPn, "#,#.##")
            End If

            If TotDpp = 0 Then
                _TxtDppInvoice.Text = "0"
            Else
                _TxtDppInvoice.Text = Format(TotDpp, "#,#.##")
            End If

            If TotAmount = 0 Then
                _TxtTotal.Text = "0"
            Else

                _TxtTotal.Text = Format(TotAmount, "#,#.##")
            End If
            If TotPPH = 0 Then
                _TxtPPH.Text = "0"
            Else

                _TxtPPH.Text = Format(TotPPH, "#,#.##")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub _LookUpSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles _LookUpSupplier.KeyDown, _TxtNPWP.KeyDown,
            _TxtJenisJasa.KeyDown, _TxtNoBuktiPot.KeyDown, _DeDate.KeyDown, _TxtCurrency.KeyDown, _TxtPPN.KeyDown, _TxtDppInvoice.KeyDown,
            _TxtTotal.KeyDown, _TxtPPH.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Dim Amount As Double = 0
    Dim DPP As Double = 0
    Dim PPN As Double = 0
    Private Sub _LookUpSupplier_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _LookUpSupplier.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            If sender.Name = _LookUpSupplier.Name Then
                ObjFP = New Cls_FP()
                dtSearch = ObjFP.GetSupplierLookup
                ls_OldKode = _LookUpSupplier.Text.Trim
                ls_Judul = "Vendor"

            End If
            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim VendorID As String = ""
            Dim VendorName As String = ""
            Dim JenisJasa As String = ""
            Dim NPWP As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                VendorID = lF_SearchData.Values.Item(0).ToString.Trim
                VendorName = lF_SearchData.Values.Item(1).ToString.Trim
                JenisJasa = lF_SearchData.Values.Item(2).ToString.Trim
                NPWP = lF_SearchData.Values.Item(3).ToString.Trim

                _LookUpSupplier.Text = VendorID
                _TxtVendorName.Text = VendorName
                _TxtJenisJasa.Text = JenisJasa
                _TxtNPWP.Text = NPWP

                Dim dt As New DataTable
                If VendorID = "" Then
                    Exit Sub
                End If
                dt = ObjFP.GetDetailsGridFP(VendorID)
                If dt.Rows.Count > 0 Then
                    _GridDetails.DataSource = dt
                    _DeDate.Focus()
                Else
                    _GridDetails.DataSource = dt
                    XtraMessageBox.Show("Invoice " & "[" & VendorName & "]" & " Kosong !")
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGridNew()
        Try
            Dim dtTable As New DataTable
            dtTable = ObjFP.GetDetailsGridFP(_LookUpSupplier.Text)
            If dtTable.Rows.Count > 0 Then
                _GridDetailsNew.DataSource = dtTable
                _DeDate.Focus()
            Else
                _GridDetailsNew.DataSource = dtTable
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnPPH2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnPPH2.ButtonClick
        Dim FP As String = String.Empty
        Dim InvcNbr As String = String.Empty
        Dim DPP As String = String.Empty
        Try
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Check") = True Then
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        FP = GridView2.GetRowCellValue(rowHandle, "fp").ToString().TrimEnd
                        InvcNbr = GridView2.GetRowCellValue(rowHandle, "invcNbr")
                        DPP = GridView2.GetRowCellValue(rowHandle, "DPP")
                    End If
                Next rowHandle

                Dim f As frm_lookup_pph = New frm_lookup_pph(FP, _TxtNoTrans.Text, InvcNbr, DPP, True)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Pph", f.PPHDetails)
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "NBP", f.NoBuktiPotong)
                '_TxtNoBuktiPot.Text = f.NoBuktiPotong

                'Tambahkan data ke Grid yang di atas
                Dim IsExist As Boolean = False
                Dim InvcNo As String = String.Empty
                'Dim view As GridView = TryCast(sender, GridView)
                Dim selRows As Integer() = DirectCast(_GridDetailsNew.MainView, GridView).GetSelectedRows()
                Dim selRow As DataRowView = DirectCast(DirectCast(_GridDetailsNew.MainView, GridView).GetRow(selRows(0)), DataRowView)

                With GridView1
                    For i As Integer = 0 To .RowCount - 1
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "invcNbr") = .GetRowCellValue(i, "invcNbr") Then
                            IsExist = True
                            Exit For
                        End If
                    Next
                    If IsExist Then
                        Throw New Exception("[ " & GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "invcNbr") & " ]" & " Sudah ada !")
                    End If
                    .AddNewRow()
                    .SetRowCellValue(.FocusedRowHandle, "invcNbr", selRow(0))
                    .SetRowCellValue(.FocusedRowHandle, "invcDate", selRow(1))
                    .SetRowCellValue(.FocusedRowHandle, "Amount", selRow(2))
                    .SetRowCellValue(.FocusedRowHandle, "CuryId", selRow(3))
                    .SetRowCellValue(.FocusedRowHandle, "Ppn", selRow(4))
                    .SetRowCellValue(.FocusedRowHandle, "DPP", selRow(5))
                    .SetRowCellValue(.FocusedRowHandle, "fp", selRow(6))
                    .SetRowCellValue(.FocusedRowHandle, "NBP", selRow(7))
                    .SetRowCellValue(.FocusedRowHandle, "Check", selRow(8))
                    .SetRowCellValue(.FocusedRowHandle, "Scan", selRow(9))
                    .SetRowCellValue(.FocusedRowHandle, "Pph", selRow(10))
                    .SetRowCellValue(.FocusedRowHandle, "Status", "0")
                    .UpdateCurrentRow()
                End With


                GetTot()

            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Check1_EditValueChanged(sender As Object, e As EventArgs)
        _GridDetails.FocusedView.PostEditor()
    End Sub

    Private Sub BtnScand2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnScand2.ButtonClick
        Try
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Check") = True Then
                Dim f As Frm_ScanFP = New Frm_ScanFP("", True)
                With f

                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Check2_EditValueChanged(sender As Object, e As EventArgs) Handles Check2.EditValueChanged
        _GridDetailsNew.FocusedView.PostEditor()
    End Sub

    Private Sub BtnPPH2_EditValueChanged(sender As Object, e As EventArgs) Handles BtnPPH2.EditValueChanged
        _GridDetailsNew.FocusedView.PostEditor()
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            Dim IsExist As Boolean = False
            Dim InvcNo As String = String.Empty
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = _GridDetailsNew.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim selRows As Integer() = DirectCast(_GridDetailsNew.MainView, GridView).GetSelectedRows()
                Dim selRow As DataRowView = DirectCast(DirectCast(_GridDetailsNew.MainView, GridView).GetRow(selRows(0)), DataRowView)

                With GridView1
                    For i As Integer = 0 To .RowCount - 1
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "invcNbr") = .GetRowCellValue(i, "invcNbr") Then
                            IsExist = True
                            Exit For
                        End If
                    Next
                    If IsExist Then
                        Throw New Exception("[" & GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "invcNbr") & "]" & " Sudah ada !")
                    End If
                    .AddNewRow()
                    .SetRowCellValue(.FocusedRowHandle, "invcNbr", selRow(0))
                    .SetRowCellValue(.FocusedRowHandle, "invcDate", selRow(1))
                    .SetRowCellValue(.FocusedRowHandle, "Amount", selRow(2))
                    .SetRowCellValue(.FocusedRowHandle, "CuryId", selRow(3))
                    .SetRowCellValue(.FocusedRowHandle, "Ppn", selRow(4))
                    .SetRowCellValue(.FocusedRowHandle, "DPP", selRow(5))
                    .SetRowCellValue(.FocusedRowHandle, "fp", selRow(6))
                    .SetRowCellValue(.FocusedRowHandle, "Check", selRow(7))
                    .SetRowCellValue(.FocusedRowHandle, "Scan", selRow(8))
                    .SetRowCellValue(.FocusedRowHandle, "Pph", selRow(9))
                    .UpdateCurrentRow()
                End With
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
                If Status Is DBNull.Value Then
                    Exit Sub
                End If
                If Status = "1" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.SeaShell
                    e.HighPriority = True
                End If
            End If
        Catch ex As Exception
            ex = Nothing
        End Try
    End Sub

    Private Sub BtnScan1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnScan1.ButtonClick
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                Dim NoFaktur As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fp")
                Dim NoFakturNew As String = Microsoft.VisualBasic.Mid(Replace(Replace(NoFaktur.TrimEnd, ".", ""), "-", ""), 4, 14)
                If fs_Code <> "" Then
                    Dim f As Frm_ScanFP = New Frm_ScanFP(NoFakturNew.TrimEnd, False)
                    With f
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                    End With
                Else
                    Dim f As Frm_ScanFP = New Frm_ScanFP("", True)
                    With f
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                    End With
                End If

            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnPPH1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnPPH1.ButtonClick
        Dim FP As String = String.Empty
        Dim InvcNbr As String = String.Empty
        Dim DPP As String = String.Empty
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        FP = GridView1.GetRowCellValue(rowHandle, "fp")
                        InvcNbr = GridView1.GetRowCellValue(rowHandle, "invcNbr")
                        DPP = GridView1.GetRowCellValue(rowHandle, "DPP")
                    End If
                Next rowHandle

                If fs_Code <> "" Then
                    Dim f As frm_lookup_pph = New frm_lookup_pph(FP, _TxtNoTrans.Text, InvcNbr, DPP, False)
                    With f
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                    End With
                Else
                    Dim f As frm_lookup_pph = New frm_lookup_pph(FP, _TxtNoTrans.Text, InvcNbr, DPP, True)
                    With f
                        .StartPosition = FormStartPosition.CenterScreen
                        .ShowDialog()
                    End With

                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Pph", f.PPHDetails)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "NBP", f.NoBuktiPotong)
                    ' _TxtNoBuktiPot.Text = f.NoBuktiPotong

                    GetTot()

                End If

            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEdit
        Try
            If e.Column.Equals(ColCheck1) Then
                Dim val As Integer = Convert.ToInt32(GridView1.GetRowCellValue(e.RowHandle, "Status"))
                If val.ToString Is DBNull.Value Then
                    Exit Sub
                End If
                If val = 1 Then
                    Dim ritem As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()

                    ritem.ReadOnly = True
                    e.RepositoryItem = ritem
                End If
            End If
        Catch ex As Exception
            ex = Nothing
        End Try

        'If e.Column.Equals(ColScan1) Then
        '    Dim val As Integer = Convert.ToInt32(GridView1.GetRowCellValue(e.RowHandle, "Status"))

        '    If val = 1 Then
        '        Dim ritem As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
        '        ritem.TextEditStyle = TextEditStyles.HideTextEditor
        '        ritem.[ReadOnly] = True
        '        ritem.Buttons(0).Enabled = False
        '        ritem.Buttons(0).Kind = ButtonPredefines.Glyph
        '        ritem.Buttons(0).ImageOptions.Image = TSMU.My.Resources.Barcode2_16x16()
        '        'ritem.ContextImage = TSMU.My.Resources.Barcode2_16x16()
        '        e.RepositoryItem = ritem
        '    End If
        'End If
        'If e.Column.Equals(ColPph1) Then
        '    Dim val As Integer = Convert.ToInt32(GridView1.GetRowCellValue(e.RowHandle, "Status"))

        '    If val = 1 Then
        '        Dim ritem As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
        '        ritem.TextEditStyle = TextEditStyles.Standard
        '        ritem.[ReadOnly] = True
        '        ritem.Buttons(0).Enabled = False
        '        e.RepositoryItem = ritem
        '    End If
        'End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If e.Column.FieldName = "Check" Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                    GetTot()
                Else
                    GetTot()

                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _GridDetails_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles _GridDetails.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)
            If view.GetRowCellValue(view.FocusedRowHandle, "Status") <> "1" Then
                If e.KeyData = Keys.Delete Then
                    view.DeleteSelectedRows()
                    GetTot()
                    e.Handled = True
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnPPH1_EditValueChanged(sender As Object, e As EventArgs) Handles BtnPPH1.EditValueChanged
        _GridDetails.FocusedView.PostEditor()
    End Sub


End Class
