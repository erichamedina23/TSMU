Imports DevExpress.XtraGrid

Public Class frmSales_Budget_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsSales_Budget
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim id As System.Globalization.CultureInfo '= New System.Globalization.CultureInfo("id-ID")

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
    Private Sub frmSales_Budget_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call AturGrid()
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call InitialSetForm()
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
                Me.Text = "Master Budget " & fs_Code
            Else
                Me.Text = "Master New Budget"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            Call FillComboTahun()
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSales_Budget"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString}
        _cmbTahun.Items.Clear()
        For Each var As String In tahun
            _cmbTahun.Items.Add(var)
        Next
    End Sub

    Private Sub AturGrid()
        With Grid
            .Columns("colBulan").ReadOnly = True
            .Columns("colSubTotal").ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With

        Dim Jan() As String = {"Januari", "0", "0", "0"}
        Dim Feb() As String = {"Februari", "0", "0", "0"}
        Dim Mar() As String = {"Maret", "0", "0", "0"}
        Dim Apr() As String = {"April", "0", "0", "0"}
        Dim Mei() As String = {"Mei", "0", "0", "0"}
        Dim Jun() As String = {"Juni", "0", "0", "0"}
        Dim Jul() As String = {"Juli", "0", "0", "0"}
        Dim Aug() As String = {"Agustus", "0", "0", "0"}
        Dim Sep() As String = {"September", "0", "0", "0"}
        Dim Okt() As String = {"Oktober", "0", "0", "0"}
        Dim Nov() As String = {"November", "0", "0", "0"}
        Dim Des() As String = {"Desember", "0", "0", "0"}
        Dim Tot() As String = {"TOTAL", "0", "0", "0"}

        Dim rows() As Object = {Jan, Feb, Mar, Apr, Mei, Jun, Jul, Aug, Sep, Okt, Nov, Des, Tot}

        Dim row As String()
        For Each row In rows
            Grid.Rows.Add(row)
        Next row
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtCustId.Text = .CustomerId
                    _txtCustName.Text = .CustomerId
                    _txtCustName.Text = .Customer
                    _txtPartNo.Text = .PartNo
                    _txtInvtId.Text = .InvtId
                    _txtPartName.Text = .Descr
                    _txtModel.Text = .Model
                    _cmbOeRe.Text = .Oe_Re
                    _cmbSite.Text = .Site
                    _cmbInHouse.Text = .In_Sub
                    _cmbTahun.Text = .Tahun

                    'hasil = Convert.ToInt32(Val(Grid.Rows(e.RowIndex).Cells("colQty").Value) * Val(Grid.Rows(e.RowIndex).Cells("colHarga").Value))
                    'Dim strHasil As String = hasil.ToString("n", id)
                    'Grid.Rows(e.RowIndex).Cells("colSubTotal").Value = strHasil

                    Grid.Rows(0).Cells("colQty").Value = .Jan_Qty.ToString("n", id)
                    Grid.Rows(1).Cells("colQty").Value = .Feb_Qty.ToString("n", id)
                    Grid.Rows(2).Cells("colQty").Value = .Mar_Qty.ToString("n", id)
                    Grid.Rows(3).Cells("colQty").Value = .Apr_Qty.ToString("n", id)

                    Grid.Rows(4).Cells("colQty").Value = .Mei_Qty.ToString("n", id)
                    Grid.Rows(5).Cells("colQty").Value = .Jun_Qty.ToString("n", id)
                    Grid.Rows(6).Cells("colQty").Value = .Jul_Qty.ToString("n", id)
                    Grid.Rows(7).Cells("colQty").Value = .Agt_Qty.ToString("n", id)

                    Grid.Rows(8).Cells("colQty").Value = .Sep_Qty.ToString("n", id)
                    Grid.Rows(9).Cells("colQty").Value = .Okt_Qty.ToString("n", id)
                    Grid.Rows(10).Cells("colQty").Value = .Nov_Qty.ToString("n", id)
                    Grid.Rows(11).Cells("colQty").Value = .Des_Qty.ToString("n", id)

                    Grid.Rows(0).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(1).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(2).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(3).Cells("colHarga").Value = .Price.ToString("n", id)

                    Grid.Rows(4).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(5).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(6).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(7).Cells("colHarga").Value = .Price.ToString("n", id)

                    Grid.Rows(8).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(9).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(10).Cells("colHarga").Value = .Price.ToString("n", id)
                    Grid.Rows(11).Cells("colHarga").Value = .Price.ToString("n", id)

                    Grid.Rows(0).Cells("colSubTotal").Value = CDbl(.Jan_Qty * .Price).ToString("n", id)
                    Grid.Rows(1).Cells("colSubTotal").Value = CDbl(.Feb_Qty * .Price).ToString("n", id)
                    Grid.Rows(2).Cells("colSubTotal").Value = CDbl(.Mar_Qty * .Price).ToString("n", id)
                    Grid.Rows(3).Cells("colSubTotal").Value = CDbl(.Apr_Qty * .Price).ToString("n", id)
                    Grid.Rows(4).Cells("colSubTotal").Value = CDbl(.Mei_Qty * .Price).ToString("n", id)
                    Grid.Rows(5).Cells("colSubTotal").Value = CDbl(.Jun_Qty * .Price).ToString("n", id)
                    Grid.Rows(6).Cells("colSubTotal").Value = CDbl(.Jul_Qty * .Price).ToString("n", id)
                    Grid.Rows(7).Cells("colSubTotal").Value = CDbl(.Agt_Qty * .Price).ToString("n", id)
                    Grid.Rows(8).Cells("colSubTotal").Value = CDbl(.Sep_Qty * .Price).ToString("n", id)
                    Grid.Rows(9).Cells("colSubTotal").Value = CDbl(.Okt_Qty * .Price).ToString("n", id)
                    Grid.Rows(10).Cells("colSubTotal").Value = CDbl(.Nov_Qty * .Price).ToString("n", id)
                    Grid.Rows(11).Cells("colSubTotal").Value = CDbl(.Des_Qty * .Price).ToString("n", id)
                    Dim TotQty As Integer = 0
                    Dim TotHarga As Double = 0
                    Dim GrandTot As Double = 0
                    For i As Integer = 0 To Grid.Rows.Count - 1
                        If i = 12 Then
                            Exit For
                        End If
                        TotQty = TotQty + CInt(Grid.Rows(i).Cells("colQty").Value)
                        TotHarga = TotHarga + CDbl(Grid.Rows(i).Cells("colHarga").Value)
                        GrandTot = GrandTot + CDbl(Grid.Rows(i).Cells("colSubTotal").Value)
                    Next

                    Grid.Rows(12).Cells("colQty").Value = TotQty.ToString("n", id)
                    Grid.Rows(12).Cells("colHarga").Value = TotHarga.ToString("n", id)
                    Grid.Rows(12).Cells("colSubTotal").Value = GrandTot.ToString("n", id)
                End With
            Else
                _txtCustId.Text = ""
                _txtCustName.Text = ""
                _txtCustName.Text = ""
                _txtPartNo.Text = ""
                _txtInvtId.Text = ""
                _txtPartName.Text = ""
                _txtModel.Text = ""
                _cmbOeRe.Text = ""
                _cmbSite.Text = ""
                _cmbInHouse.Text = ""
                _cmbTahun.Text = ""

            End If
            _txtInvtId.ReadOnly = True
            _txtPartNo.ReadOnly = True
            _txtPartName.ReadOnly = True
            _txtCustId.ReadOnly = True
            _txtCustName.ReadOnly = True
            _txtCustId.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Try
            LoadTxtBox()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If String.IsNullOrEmpty(_txtCustId.Text) Then
                errProvider.SetError(_txtCustId, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtCustId, "")
            End If

            If String.IsNullOrEmpty(_txtCustName.Text) Then
                errProvider.SetError(_txtCustName, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtCustName, "")
            End If
            If String.IsNullOrEmpty(_txtPartNo.Text) Then
                errProvider.SetError(_txtPartNo, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtPartNo, "")
            End If
            If String.IsNullOrEmpty(_txtInvtId.Text) Then
                errProvider.SetError(_txtInvtId, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtInvtId, "")
            End If

            If String.IsNullOrEmpty(_txtPartName.Text) Then
                errProvider.SetError(_txtPartName, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtPartName, "")
            End If

            If String.IsNullOrEmpty(_txtModel.Text) Then
                errProvider.SetError(_txtModel, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtModel, "")
            End If
            If String.IsNullOrEmpty(_cmbOeRe.Text) Then
                errProvider.SetError(_cmbOeRe, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbOeRe, "")
            End If

            If String.IsNullOrEmpty(_cmbSite.Text) Then
                errProvider.SetError(_cmbSite, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbSite, "")
            End If
            If String.IsNullOrEmpty(_cmbInHouse.Text) Then
                errProvider.SetError(_cmbInHouse, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbInHouse, "")
            End If
            If String.IsNullOrEmpty(_cmbTahun.Text) Then
                errProvider.SetError(_cmbTahun, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbTahun, "")
            End If
            Dim success As Boolean = True
            For Each c As Control In TabPage1.Controls
                If errProvider.GetError(c).Length > 0 Then
                    success = False
                End If

            Next
            If success Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Please check your input field !")
            End If

            If lb_Validated Then
                With fc_Class
                    If fs_Code <> "" Then
                        .ID = fs_Code

                        .Tahun = _cmbTahun.Text.Trim
                        .CustomerId = _txtCustId.Text.Trim
                        .Customer = _txtCustName.Text.Trim
                        .PartNo = _txtPartNo.Text.Trim
                        .InvtId = _txtInvtId.Text.Trim
                        .Descr = _txtPartName.Text.Trim
                        .Model = _txtModel.Text.Trim
                        .Oe_Re = _cmbOeRe.Text.Trim
                        .Site = _cmbSite.Text.Trim
                        .In_Sub = _cmbInHouse.Text.Trim

                        .Jan_Qty = Grid.Rows(0).Cells("colQty").Value
                        .Feb_Qty = Grid.Rows(1).Cells("colQty").Value
                        .Mar_Qty = Grid.Rows(2).Cells("colQty").Value
                        .Apr_Qty = Grid.Rows(3).Cells("colQty").Value
                        .Mei_Qty = Grid.Rows(4).Cells("colQty").Value
                        .Jun_Qty = Grid.Rows(5).Cells("colQty").Value
                        .Jul_Qty = Grid.Rows(6).Cells("colQty").Value
                        .Agt_Qty = Grid.Rows(7).Cells("colQty").Value
                        .Sep_Qty = Grid.Rows(8).Cells("colQty").Value
                        .Okt_Qty = Grid.Rows(9).Cells("colQty").Value
                        .Nov_Qty = Grid.Rows(10).Cells("colQty").Value
                        .Des_Qty = Grid.Rows(11).Cells("colQty").Value

                        .Jan_Harga = Grid.Rows(0).Cells("colHarga").Value
                        .Feb_Harga = Grid.Rows(1).Cells("colHarga").Value
                        .Mar_Harga = Grid.Rows(2).Cells("colHarga").Value
                        .Apr_Harga = Grid.Rows(3).Cells("colHarga").Value
                        .Mei_Harga = Grid.Rows(4).Cells("colHarga").Value
                        .Jun_Harga = Grid.Rows(5).Cells("colHarga").Value
                        .Jul_Harga = Grid.Rows(6).Cells("colHarga").Value
                        .Agt_Harga = Grid.Rows(7).Cells("colHarga").Value
                        .Sep_Harga = Grid.Rows(8).Cells("colHarga").Value
                        .Okt_Harga = Grid.Rows(9).Cells("colHarga").Value
                        .Nov_Harga = Grid.Rows(10).Cells("colHarga").Value
                        .Des_Harga = Grid.Rows(11).Cells("colHarga").Value
                    End If
                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
                        '.ValidateUpdate()
                    End If
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
            If isUpdate = False Then
                fc_Class.Insert()
            Else
                fc_Class.Update()
            End If

            GridDtl.DataSource = fc_Class.GetAllDataGrid(bs_Filter)
            Dim targetString As String = fc_Class.ID
            frmSales_Budget.GridView1.UpdateCurrentRow()
            frmSales_Budget.GridView1.OptionsNavigation.AutoFocusNewRow = True
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
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _cmbUnit_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub _txtAccountId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If String.IsNullOrEmpty(_txtCustId.Text) Then
            errProvider.SetError(_txtCustId, "Value cannot be empty.")
        Else
            errProvider.SetError(_txtCustId, "")
        End If
    End Sub

    Private Sub _txtAccName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If String.IsNullOrEmpty(_txtCustName.Text) Then
            errProvider.SetError(_txtCustName, "Value cannot be empty.")
        Else
            errProvider.SetError(_txtCustName, "")
        End If
    End Sub

    Private Sub btnCariCust_Click(sender As Object, e As EventArgs) Handles btnCariCust.Click, _btnCariPart.Click
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            If sender.Name = btnCariCust.Name Then
                dtSearch = fc_Class.getCusst_Solomon
                ls_OldKode = _txtCustId.Text.Trim
                ls_Judul = "Customer"
            ElseIf sender.Name = _btnCariPart.Name Then
                If _txtCustId.Text <> "" Then
                    Cursor = Cursors.WaitCursor
                    dtSearch = fc_Class.getPartNo_Solomon(_txtCustId.Text)
                    ls_OldKode = _txtPartNo.Text.Trim
                    ls_Judul = "Part No"
                Else
                    _txtCustId.Focus()
                    Throw New Exception("Silahkan Pilih Customer terlebih dahulu !")
                End If
                Cursor = Cursors.Default
            End If


            'dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            'dtSearch.Rows(0).Item(0) = "ALL"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""
            Dim ls_Nama2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = btnCariCust.Name Then
                    ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                    ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                    _txtCustId.Text = ls_Kode
                    _txtCustName.Text = ls_Nama
                    _txtPartNo.Focus()
                End If
                If sender.Name = _btnCariPart.Name Then
                    ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                    ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                    ls_Nama2 = lF_SearchData.Values.Item(2).ToString.Trim
                    _txtPartNo.Text = ls_Kode
                    _txtInvtId.Text = ls_Nama
                    _txtPartName.Text = ls_Nama2
                    _txtModel.Focus()
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim Total As Integer
    Private Function CountTotal_qty() As Integer
        Try
            Total = 0
            For i As Integer = 0 To Grid.Rows.Count - 1
                Total = Total + Val(Grid.Rows(i).Cells("colQty").Value)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return Total
    End Function

    Dim Total1 As Decimal
    Private Function CountTotal_Sub() As Decimal
        Try
            Total1 = 0
            For i As Integer = 0 To Grid.Rows.Count - 1
                'Grid.Rows(i).Cells("colSubTotal").ValueType = GetType(Decimal)
                'MsgBox(Convert.ToInt32(Grid.Rows(i).Cells("colSubTotal").Value.ToString))
                Total1 = Total1 + Grid.Rows(i).Cells("colSubTotal").Value
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return Total1
    End Function

    Private Sub Grid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellEndEdit
        Try
            id = New System.Globalization.CultureInfo("id-ID")
            If e.ColumnIndex = 1 OrElse e.ColumnIndex = 2 Then
                'MsgBox("HI")
                Dim hasil As Integer
                hasil = Convert.ToInt32(Val(Grid.Rows(e.RowIndex).Cells("colQty").Value) * Val(Grid.Rows(e.RowIndex).Cells("colHarga").Value))
                Dim strHasil As String = hasil.ToString("n", id)
                Grid.Rows(e.RowIndex).Cells("colSubTotal").Value = strHasil
            End If
            Dim Total As Integer = CountTotal_qty()
            Dim strTotal As String = Total.ToString("n", id)
            Grid.Rows(12).Cells("colQty").Value = strTotal

            'Dim Total1 As Decimal = CountTotal_Sub()
            'Dim strTotal1 As String = Total1.ToString("n", id)
            'Grid.Rows(12).Cells("colSubTotal").Value = strTotal1
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    'Private Sub Grid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellValueChanged
    '    Try

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub IsControlEmpty(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles _txtCustId.Validating, _
    '    _txtPartNo.Validating, _txtModel.Validating, _cmbInHouse.Validating, _cmbOeRe.Validating, _cmbSite.Validating, _cmbTahun.Validating

    '    If sender.Name = _txtCustId.Name Then
    '        If String.IsNullOrEmpty(_txtCustId.Text) Then
    '            errProvider.SetError(_txtCustId, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtCustId, "")
    '        End If
    '        If String.IsNullOrEmpty(_txtCustName.Text) Then
    '            errProvider.SetError(_txtCustName, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtCustName, "")
    '        End If
    '    ElseIf sender.Name = _txtPartNo.Name Then
    '        If String.IsNullOrEmpty(_txtPartNo.Text) Then
    '            errProvider.SetError(_txtPartNo, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtPartNo, "")
    '        End If
    '        If String.IsNullOrEmpty(_txtInvtId.Text) Then
    '            errProvider.SetError(_txtInvtId, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtInvtId, "")
    '        End If

    '        If String.IsNullOrEmpty(_txtPartName.Text) Then
    '            errProvider.SetError(_txtPartName, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtPartName, "")
    '        End If
    '    ElseIf sender.Name = _txtModel.Name Then
    '        If String.IsNullOrEmpty(_txtModel.Text) Then
    '            errProvider.SetError(_txtModel, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_txtModel, "")
    '        End If
    '    ElseIf sender.Name = _cmbOeRe.Name Then
    '        If String.IsNullOrEmpty(_cmbOeRe.Text) Then
    '            errProvider.SetError(_cmbOeRe, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_cmbOeRe, "")
    '        End If
    '    ElseIf sender.Name = _cmbSite.Name Then
    '        If String.IsNullOrEmpty(_cmbSite.Text) Then
    '            errProvider.SetError(_cmbSite, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_cmbSite, "")
    '        End If
    '    ElseIf sender.Name = _cmbInHouse.Name Then
    '        If String.IsNullOrEmpty(_cmbInHouse.Text) Then
    '            errProvider.SetError(_cmbInHouse, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_cmbInHouse, "")
    '        End If
    '    ElseIf sender.Name = _cmbTahun.Name Then
    '        If String.IsNullOrEmpty(_cmbTahun.Text) Then
    '            errProvider.SetError(_cmbTahun, "Value cannot be empty.")
    '        Else
    '            errProvider.SetError(_cmbTahun, "")
    '        End If
    '    End If

    'End Sub

End Class
