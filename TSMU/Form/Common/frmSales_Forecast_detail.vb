Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmSales_Forecast_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsSales_Forecast
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim id As System.Globalization.CultureInfo
    Dim EdtiPrice As Boolean

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
    Private Sub frmSales_Forecast_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call AturGrid()
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
                Me.Text = "Sales Forecast " & fs_Code2
            Else
                Me.Text = "New Sales Forecast"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            'If Grid.RowCount = 0 Then
            'Else
            Call LoadTxtBox()
            'End If
            Call InputBeginState(Me)
            Call FillComboTahun()
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSales_Forecast"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub FillComboTahun()
        Try
            Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString}
            _cmbTahun.Items.Clear()
            For Each var As String In tahun
                _cmbTahun.Items.Add(var)
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AturGrid()
        With Grid
            If AllowEditPrice = False Then
                .Columns("colRev0").ReadOnly = True
                .Columns("colRev1").ReadOnly = True
                .Columns("colRev2").ReadOnly = True
                For Each ctl As Control In TabControl1.Controls
                    ctl.Enabled = False
                Next
            End If

            If AllowEditQty = False Then
                .Columns("colPO0").ReadOnly = True
                .Columns("colPO1").ReadOnly = True
                For Each ctl As Control In TabControl1.Controls
                    ctl.Enabled = False
                Next
            End If
            .Columns("colBulan").ReadOnly = True
            '.Columns("colSubTotal").ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With

        Dim Jan() As String = {"Januari", "0", "0", "0", "0", "0"}
        Dim Feb() As String = {"Februari", "0", "0", "0", "0", "0"}
        Dim Mar() As String = {"Maret", "0", "0", "0", "0", "0"}
        Dim Apr() As String = {"April", "0", "0", "0", "0", "0"}
        Dim Mei() As String = {"Mei", "0", "0", "0", "0", "0"}
        Dim Jun() As String = {"Juni", "0", "0", "0", "0", "0"}
        Dim Jul() As String = {"Juli", "0", "0", "0", "0", "0"}
        Dim Aug() As String = {"Agustus", "0", "0", "0", "0", "0"}
        Dim Sep() As String = {"September", "0", "0", "0", "0", "0"}
        Dim Okt() As String = {"Oktober", "0", "0", "0", "0", "0"}
        Dim Nov() As String = {"November", "0", "0", "0", "0", "0"}
        Dim Des() As String = {"Desember", "0", "0", "0", "0", "0"}

        Dim rows() As Object = {Jan, Feb, Mar, Apr, Mei, Jun, Jul, Aug, Sep, Okt, Nov, Des}

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
        Call LoadTxtBox()
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
            'If String.IsNullOrEmpty(_cmbInHouse.Text) Then
            '    errProvider.SetError(_cmbInHouse, "Value cannot be empty.")
            'Else
            '    errProvider.SetError(_cmbInHouse, "")
            'End If
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
                    End If
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

                    .Jan_Qty01 = Grid.Rows(0).Cells("colRev0").Value
                    .Feb_Qty01 = Grid.Rows(1).Cells("colRev0").Value
                    .Mar_Qty01 = Grid.Rows(2).Cells("colRev0").Value
                    .Apr_Qty01 = Grid.Rows(3).Cells("colRev0").Value
                    .Mei_Qty01 = Grid.Rows(4).Cells("colRev0").Value
                    .Jun_Qty01 = Grid.Rows(5).Cells("colRev0").Value
                    .Jul_Qty01 = Grid.Rows(6).Cells("colRev0").Value
                    .Agt_Qty01 = Grid.Rows(7).Cells("colRev0").Value
                    .Sep_Qty01 = Grid.Rows(8).Cells("colRev0").Value
                    .Okt_Qty01 = Grid.Rows(9).Cells("colRev0").Value
                    .Nov_Qty01 = Grid.Rows(10).Cells("colRev0").Value
                    .Des_Qty01 = Grid.Rows(11).Cells("colRev0").Value

                    .Jan_Qty02 = Grid.Rows(0).Cells("colRev1").Value
                    .Feb_Qty02 = Grid.Rows(1).Cells("colRev1").Value
                    .Mar_Qty02 = Grid.Rows(2).Cells("colRev1").Value
                    .Apr_Qty02 = Grid.Rows(3).Cells("colRev1").Value
                    .Mei_Qty02 = Grid.Rows(4).Cells("colRev1").Value
                    .Jun_Qty02 = Grid.Rows(5).Cells("colRev1").Value
                    .Jul_Qty02 = Grid.Rows(6).Cells("colRev1").Value
                    .Agt_Qty02 = Grid.Rows(7).Cells("colRev1").Value
                    .Sep_Qty02 = Grid.Rows(8).Cells("colRev1").Value
                    .Okt_Qty02 = Grid.Rows(9).Cells("colRev1").Value
                    .Nov_Qty02 = Grid.Rows(10).Cells("colRev1").Value
                    .Des_Qty02 = Grid.Rows(11).Cells("colRev1").Value

                    .Jan_Qty03 = Grid.Rows(0).Cells("colRev2").Value
                    .Feb_Qty03 = Grid.Rows(1).Cells("colRev2").Value
                    .Mar_Qty03 = Grid.Rows(2).Cells("colRev2").Value
                    .Apr_Qty03 = Grid.Rows(3).Cells("colRev2").Value
                    .Mei_Qty03 = Grid.Rows(4).Cells("colRev2").Value
                    .Jun_Qty03 = Grid.Rows(5).Cells("colRev2").Value
                    .Jul_Qty03 = Grid.Rows(6).Cells("colRev2").Value
                    .Agt_Qty03 = Grid.Rows(7).Cells("colRev2").Value
                    .Sep_Qty03 = Grid.Rows(8).Cells("colRev2").Value
                    .Okt_Qty03 = Grid.Rows(9).Cells("colRev2").Value
                    .Nov_Qty03 = Grid.Rows(10).Cells("colRev2").Value
                    .Des_Qty03 = Grid.Rows(11).Cells("colRev2").Value

                    .Jan_PO01 = Grid.Rows(0).Cells("colPO0").Value
                    .Feb_PO01 = Grid.Rows(1).Cells("colPO0").Value
                    .Mar_PO01 = Grid.Rows(2).Cells("colPO0").Value
                    .Apr_PO01 = Grid.Rows(3).Cells("colPO0").Value
                    .Mei_PO01 = Grid.Rows(4).Cells("colPO0").Value
                    .Jun_PO01 = Grid.Rows(5).Cells("colPO0").Value
                    .Jul_PO01 = Grid.Rows(6).Cells("colPO0").Value
                    .Agt_PO01 = Grid.Rows(7).Cells("colPO0").Value
                    .Sep_PO01 = Grid.Rows(8).Cells("colPO0").Value
                    .Okt_PO01 = Grid.Rows(9).Cells("colPO0").Value
                    .Nov_PO01 = Grid.Rows(10).Cells("colPO0").Value
                    .Des_PO01 = Grid.Rows(11).Cells("colPO0").Value

                    .Jan_PO02 = Grid.Rows(0).Cells("colPO1").Value
                    .Feb_PO02 = Grid.Rows(1).Cells("colPO1").Value
                    .Mar_PO02 = Grid.Rows(2).Cells("colPO1").Value
                    .Apr_PO02 = Grid.Rows(3).Cells("colPO1").Value
                    .Mei_PO02 = Grid.Rows(4).Cells("colPO1").Value
                    .Jun_PO02 = Grid.Rows(5).Cells("colPO1").Value
                    .Jul_PO02 = Grid.Rows(6).Cells("colPO1").Value
                    .Agt_PO02 = Grid.Rows(7).Cells("colPO1").Value
                    .Sep_PO02 = Grid.Rows(8).Cells("colPO1").Value
                    .Okt_PO02 = Grid.Rows(9).Cells("colPO1").Value
                    .Nov_PO02 = Grid.Rows(10).Cells("colPO1").Value
                    .Des_PO02 = Grid.Rows(11).Cells("colPO1").Value

                    '.Jan_PO03 = Grid.Rows(0).Cells("colPO2").Value
                    '.Feb_PO03 = Grid.Rows(1).Cells("colPO2").Value
                    '.Mar_PO03 = Grid.Rows(2).Cells("colPO2").Value
                    '.Apr_PO03 = Grid.Rows(3).Cells("colPO2").Value
                    '.Mei_PO03 = Grid.Rows(4).Cells("colPO2").Value
                    '.Jun_PO03 = Grid.Rows(5).Cells("colPO2").Value
                    '.Jul_PO03 = Grid.Rows(6).Cells("colPO2").Value
                    '.Agt_PO03 = Grid.Rows(7).Cells("colPO2").Value
                    '.Sep_PO03 = Grid.Rows(8).Cells("colPO2").Value
                    '.Okt_PO03 = Grid.Rows(9).Cells("colPO2").Value
                    '.Nov_PO03 = Grid.Rows(10).Cells("colPO2").Value
                    '.Des_PO03 = Grid.Rows(11).Cells("colPO2").Value

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
            frmSales_Forecast.GridView1.UpdateCurrentRow()
            frmSales_Forecast.GridView1.OptionsNavigation.AutoFocusNewRow = True
            'Dim targetString As String = fc_Class.ID
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
                    Cursor = Cursors.Default
                End If
            Else
                _txtCustId.Focus()
                Throw New Exception("Silahkan Pilih Customer terlebih dahulu !")

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

    Private Sub frmSales_Forecast_detail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With fc_Class
            AturGrid()
            Grid.Rows(0).Cells("colRev0").Value = .Jan_Qty01
            Grid.Rows(1).Cells("colRev0").Value = .Feb_Qty01
            Grid.Rows(2).Cells("colRev0").Value = .Mar_Qty01
            Grid.Rows(3).Cells("colRev0").Value = .Apr_Qty01
            Grid.Rows(4).Cells("colRev0").Value = .Mei_Qty01
            Grid.Rows(5).Cells("colRev0").Value = .Jun_Qty01
            Grid.Rows(6).Cells("colRev0").Value = .Jul_Qty01
            Grid.Rows(7).Cells("colRev0").Value = .Agt_Qty01
            Grid.Rows(8).Cells("colRev0").Value = .Sep_Qty01
            Grid.Rows(9).Cells("colRev0").Value = .Okt_Qty01
            Grid.Rows(10).Cells("colRev0").Value = .Nov_Qty01
            Grid.Rows(11).Cells("colRev0").Value = .Des_Qty01

            Grid.Rows(0).Cells("colRev1").Value = .Jan_Qty02
            Grid.Rows(1).Cells("colRev1").Value = .Feb_Qty02
            Grid.Rows(2).Cells("colRev1").Value = .Mar_Qty02
            Grid.Rows(3).Cells("colRev1").Value = .Apr_Qty02
            Grid.Rows(4).Cells("colRev1").Value = .Mei_Qty02
            Grid.Rows(5).Cells("colRev1").Value = .Jun_Qty02
            Grid.Rows(6).Cells("colRev1").Value = .Jul_Qty02
            Grid.Rows(7).Cells("colRev1").Value = .Agt_Qty02
            Grid.Rows(8).Cells("colRev1").Value = .Sep_Qty02
            Grid.Rows(9).Cells("colRev1").Value = .Okt_Qty02
            Grid.Rows(10).Cells("colRev1").Value = .Nov_Qty02
            Grid.Rows(11).Cells("colRev1").Value = .Des_Qty02

            Grid.Rows(0).Cells("colRev2").Value = .Jan_Qty03
            Grid.Rows(1).Cells("colRev2").Value = .Feb_Qty03
            Grid.Rows(2).Cells("colRev2").Value = .Mar_Qty03
            Grid.Rows(3).Cells("colRev2").Value = .Apr_Qty03
            Grid.Rows(4).Cells("colRev2").Value = .Mei_Qty03
            Grid.Rows(5).Cells("colRev2").Value = .Jun_Qty03
            Grid.Rows(6).Cells("colRev2").Value = .Jul_Qty03
            Grid.Rows(7).Cells("colRev2").Value = .Agt_Qty03
            Grid.Rows(8).Cells("colRev2").Value = .Sep_Qty03
            Grid.Rows(9).Cells("colRev2").Value = .Okt_Qty03
            Grid.Rows(10).Cells("colRev2").Value = .Nov_Qty03
            Grid.Rows(11).Cells("colRev2").Value = .Des_Qty03

            Grid.Rows(0).Cells("colPO0").Value = .Jan_PO01
            Grid.Rows(1).Cells("colPO0").Value = .Feb_PO01
            Grid.Rows(2).Cells("colPO0").Value = .Mar_PO01
            Grid.Rows(3).Cells("colPO0").Value = .Apr_PO01
            Grid.Rows(4).Cells("colPO0").Value = .Mei_PO01
            Grid.Rows(5).Cells("colPO0").Value = .Jun_PO01
            Grid.Rows(6).Cells("colPO0").Value = .Jul_PO01
            Grid.Rows(7).Cells("colPO0").Value = .Agt_PO01
            Grid.Rows(8).Cells("colPO0").Value = .Sep_PO01
            Grid.Rows(9).Cells("colPO0").Value = .Okt_PO01
            Grid.Rows(10).Cells("colPO0").Value = .Nov_PO01
            Grid.Rows(11).Cells("colPO0").Value = .Des_PO01

            Grid.Rows(0).Cells("colPO1").Value = .Jan_PO02
            Grid.Rows(1).Cells("colPO1").Value = .Feb_PO02
            Grid.Rows(2).Cells("colPO1").Value = .Mar_PO02
            Grid.Rows(3).Cells("colPO1").Value = .Apr_PO02
            Grid.Rows(4).Cells("colPO1").Value = .Mei_PO02
            Grid.Rows(5).Cells("colPO1").Value = .Jun_PO02
            Grid.Rows(6).Cells("colPO1").Value = .Jul_PO02
            Grid.Rows(7).Cells("colPO1").Value = .Agt_PO02
            Grid.Rows(8).Cells("colPO1").Value = .Sep_PO02
            Grid.Rows(9).Cells("colPO1").Value = .Okt_PO02
            Grid.Rows(10).Cells("colPO1").Value = .Nov_PO02
            Grid.Rows(11).Cells("colPO1").Value = .Des_PO02
        End With
    End Sub

    Private Sub _cmbInHouse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbInHouse.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbOeRe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbOeRe.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbSite.KeyPress
        e.Handled = True
    End Sub

    Private Sub _cmbTahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbTahun.KeyPress
        e.Handled = True
    End Sub
End Class
