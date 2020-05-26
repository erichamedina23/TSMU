Imports DevExpress.XtraGrid

Public Class frmSales_Price_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsSales_Price
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim id As System.Globalization.CultureInfo ' = New System.Globalization.CultureInfo("id-ID")

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
    Private Sub frmSales_Price_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Me.Text = "Sales Price " & fs_Code2
            Else
                Me.Text = "New Sales Price"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            'If Grid.RowCount = 0 Then
            'Else
            Call LoadTxtBox()
            'End If
            Call InputBeginState(Me)
            Call FillComboTahun()
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSales_Price"
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
                .Columns("colRev3").ReadOnly = True
                .Columns("colRev4").ReadOnly = True

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
        Dim Tot() As String = {"TOTAL", "0", "0", "0", "0", "0"}

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
            Throw
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

                    .jan_harga01 = Grid.Rows(0).Cells("colRev0").Value
                    .feb_harga01 = Grid.Rows(1).Cells("colRev0").Value
                    .mar_harga01 = Grid.Rows(2).Cells("colRev0").Value
                    .apr_harga01 = Grid.Rows(3).Cells("colRev0").Value
                    .mei_harga01 = Grid.Rows(4).Cells("colRev0").Value
                    .jun_harga01 = Grid.Rows(5).Cells("colRev0").Value
                    .jul_harga01 = Grid.Rows(6).Cells("colRev0").Value
                    .agt_harga01 = Grid.Rows(7).Cells("colRev0").Value
                    .sep_harga01 = Grid.Rows(8).Cells("colRev0").Value
                    .okt_harga01 = Grid.Rows(9).Cells("colRev0").Value
                    .nov_harga01 = Grid.Rows(10).Cells("colRev0").Value
                    .des_harga01 = Grid.Rows(11).Cells("colRev0").Value

                    .jan_harga02 = Grid.Rows(0).Cells("colRev1").Value
                    .feb_harga02 = Grid.Rows(1).Cells("colRev1").Value
                    .mar_harga02 = Grid.Rows(2).Cells("colRev1").Value
                    .apr_harga02 = Grid.Rows(3).Cells("colRev1").Value
                    .mei_harga02 = Grid.Rows(4).Cells("colRev1").Value
                    .jun_harga02 = Grid.Rows(5).Cells("colRev1").Value
                    .jul_harga02 = Grid.Rows(6).Cells("colRev1").Value
                    .agt_harga02 = Grid.Rows(7).Cells("colRev1").Value
                    .sep_harga02 = Grid.Rows(8).Cells("colRev1").Value
                    .okt_harga02 = Grid.Rows(9).Cells("colRev1").Value
                    .nov_harga02 = Grid.Rows(10).Cells("colRev1").Value
                    .des_harga02 = Grid.Rows(11).Cells("colRev1").Value

                    .jan_harga03 = Grid.Rows(0).Cells("colRev2").Value
                    .feb_harga03 = Grid.Rows(1).Cells("colRev2").Value
                    .mar_harga03 = Grid.Rows(2).Cells("colRev2").Value
                    .apr_harga03 = Grid.Rows(3).Cells("colRev2").Value
                    .mei_harga03 = Grid.Rows(4).Cells("colRev2").Value
                    .jun_harga03 = Grid.Rows(5).Cells("colRev2").Value
                    .jul_harga03 = Grid.Rows(6).Cells("colRev2").Value
                    .agt_harga03 = Grid.Rows(7).Cells("colRev2").Value
                    .sep_harga03 = Grid.Rows(8).Cells("colRev2").Value
                    .okt_harga03 = Grid.Rows(9).Cells("colRev2").Value
                    .nov_harga03 = Grid.Rows(10).Cells("colRev2").Value
                    .des_harga03 = Grid.Rows(11).Cells("colRev2").Value

                    .jan_harga04 = Grid.Rows(0).Cells("colRev3").Value
                    .feb_harga04 = Grid.Rows(1).Cells("colRev3").Value
                    .mar_harga04 = Grid.Rows(2).Cells("colRev3").Value
                    .apr_harga04 = Grid.Rows(3).Cells("colRev3").Value
                    .mei_harga04 = Grid.Rows(4).Cells("colRev3").Value
                    .jun_harga04 = Grid.Rows(5).Cells("colRev3").Value
                    .jul_harga04 = Grid.Rows(6).Cells("colRev3").Value
                    .agt_harga04 = Grid.Rows(7).Cells("colRev3").Value
                    .sep_harga04 = Grid.Rows(8).Cells("colRev3").Value
                    .okt_harga04 = Grid.Rows(9).Cells("colRev3").Value
                    .nov_harga04 = Grid.Rows(10).Cells("colRev3").Value
                    .des_harga04 = Grid.Rows(11).Cells("colRev3").Value

                    .jan_harga05 = Grid.Rows(0).Cells("colRev4").Value
                    .feb_harga05 = Grid.Rows(1).Cells("colRev4").Value
                    .mar_harga05 = Grid.Rows(2).Cells("colRev4").Value
                    .apr_harga05 = Grid.Rows(3).Cells("colRev4").Value
                    .mei_harga05 = Grid.Rows(4).Cells("colRev4").Value
                    .jun_harga05 = Grid.Rows(5).Cells("colRev4").Value
                    .jul_harga05 = Grid.Rows(6).Cells("colRev4").Value
                    .agt_harga05 = Grid.Rows(7).Cells("colRev4").Value
                    .sep_harga05 = Grid.Rows(8).Cells("colRev4").Value
                    .okt_harga05 = Grid.Rows(9).Cells("colRev4").Value
                    .nov_harga05 = Grid.Rows(10).Cells("colRev4").Value
                    .des_harga05 = Grid.Rows(11).Cells("colRev4").Value

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
            frmSales_Price.GridView1.UpdateCurrentRow()
            frmSales_Price.GridView1.OptionsNavigation.AutoFocusNewRow = True
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
                Else
                    _txtCustId.Focus()
                    Throw New Exception("Silahkan Pilih Customer terlebih dahulu !")
                End If

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

    Private Sub frmSales_Price_detail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Call AturGrid()
        'LoadTxtBox()

        With fc_Class
            AturGrid()
            Grid.Rows(0).Cells("colRev0").Value = .jan_harga01.ToString("n", id)
            Grid.Rows(1).Cells("colRev0").Value = .feb_harga01.ToString("n", id)
            Grid.Rows(2).Cells("colRev0").Value = .mar_harga01.ToString("n", id)
            Grid.Rows(3).Cells("colRev0").Value = .apr_harga01.ToString("n", id)
            Grid.Rows(4).Cells("colRev0").Value = .mei_harga01.ToString("n", id)
            Grid.Rows(5).Cells("colRev0").Value = .jun_harga01.ToString("n", id)
            Grid.Rows(6).Cells("colRev0").Value = .jul_harga01.ToString("n", id)
            Grid.Rows(7).Cells("colRev0").Value = .agt_harga01.ToString("n", id)
            Grid.Rows(8).Cells("colRev0").Value = .sep_harga01.ToString("n", id)
            Grid.Rows(9).Cells("colRev0").Value = .okt_harga01.ToString("n", id)
            Grid.Rows(10).Cells("colRev0").Value = .nov_harga01.ToString("n", id)
            Grid.Rows(11).Cells("colRev0").Value = .des_harga01.ToString("n", id)

            Grid.Rows(0).Cells("colRev1").Value = .jan_harga02.ToString("n", id)
            Grid.Rows(1).Cells("colRev1").Value = .feb_harga02.ToString("n", id)
            Grid.Rows(2).Cells("colRev1").Value = .mar_harga02.ToString("n", id)
            Grid.Rows(3).Cells("colRev1").Value = .apr_harga02.ToString("n", id)
            Grid.Rows(4).Cells("colRev1").Value = .mei_harga02.ToString("n", id)
            Grid.Rows(5).Cells("colRev1").Value = .jun_harga02.ToString("n", id)
            Grid.Rows(6).Cells("colRev1").Value = .jul_harga02.ToString("n", id)
            Grid.Rows(7).Cells("colRev1").Value = .agt_harga02.ToString("n", id)
            Grid.Rows(8).Cells("colRev1").Value = .sep_harga02.ToString("n", id)
            Grid.Rows(9).Cells("colRev1").Value = .okt_harga02.ToString("n", id)
            Grid.Rows(10).Cells("colRev1").Value = .nov_harga02.ToString("n", id)
            Grid.Rows(11).Cells("colRev1").Value = .des_harga02.ToString("n", id)

            Grid.Rows(0).Cells("colRev2").Value = .jan_harga03.ToString("n", id)
            Grid.Rows(1).Cells("colRev2").Value = .feb_harga03.ToString("n", id)
            Grid.Rows(2).Cells("colRev2").Value = .mar_harga03.ToString("n", id)
            Grid.Rows(3).Cells("colRev2").Value = .apr_harga03.ToString("n", id)
            Grid.Rows(4).Cells("colRev2").Value = .mei_harga03.ToString("n", id)
            Grid.Rows(5).Cells("colRev2").Value = .jun_harga03.ToString("n", id)
            Grid.Rows(6).Cells("colRev2").Value = .jul_harga03.ToString("n", id)
            Grid.Rows(7).Cells("colRev2").Value = .agt_harga03.ToString("n", id)
            Grid.Rows(8).Cells("colRev2").Value = .sep_harga03.ToString("n", id)
            Grid.Rows(9).Cells("colRev2").Value = .okt_harga03.ToString("n", id)
            Grid.Rows(10).Cells("colRev2").Value = .nov_harga03.ToString("n", id)
            Grid.Rows(11).Cells("colRev2").Value = .des_harga03.ToString("n", id)

            Grid.Rows(0).Cells("colRev3").Value = .jan_harga04.ToString("n", id)
            Grid.Rows(1).Cells("colRev3").Value = .feb_harga04.ToString("n", id)
            Grid.Rows(2).Cells("colRev3").Value = .mar_harga04.ToString("n", id)
            Grid.Rows(3).Cells("colRev3").Value = .apr_harga04.ToString("n", id)
            Grid.Rows(4).Cells("colRev3").Value = .mei_harga04.ToString("n", id)
            Grid.Rows(5).Cells("colRev3").Value = .jun_harga04.ToString("n", id)
            Grid.Rows(6).Cells("colRev3").Value = .jul_harga04.ToString("n", id)
            Grid.Rows(7).Cells("colRev3").Value = .agt_harga04.ToString("n", id)
            Grid.Rows(8).Cells("colRev3").Value = .sep_harga04.ToString("n", id)
            Grid.Rows(9).Cells("colRev3").Value = .okt_harga04.ToString("n", id)
            Grid.Rows(10).Cells("colRev3").Value = .nov_harga04.ToString("n", id)
            Grid.Rows(11).Cells("colRev3").Value = .des_harga04.ToString("n", id)

            Grid.Rows(0).Cells("colRev4").Value = .jan_harga05.ToString("n", id)
            Grid.Rows(1).Cells("colRev4").Value = .feb_harga05.ToString("n", id)
            Grid.Rows(2).Cells("colRev4").Value = .mar_harga05.ToString("n", id)
            Grid.Rows(3).Cells("colRev4").Value = .apr_harga05.ToString("n", id)
            Grid.Rows(4).Cells("colRev4").Value = .mei_harga05.ToString("n", id)
            Grid.Rows(5).Cells("colRev4").Value = .jun_harga05.ToString("n", id)
            Grid.Rows(6).Cells("colRev4").Value = .jul_harga05.ToString("n", id)
            Grid.Rows(7).Cells("colRev4").Value = .agt_harga05.ToString("n", id)
            Grid.Rows(8).Cells("colRev4").Value = .sep_harga05.ToString("n", id)
            Grid.Rows(9).Cells("colRev4").Value = .okt_harga05.ToString("n", id)
            Grid.Rows(10).Cells("colRev4").Value = .nov_harga05.ToString("n", id)
            Grid.Rows(11).Cells("colRev4").Value = .des_harga05.ToString("n", id)

            Dim TotRev0 As Double = 0
            Dim TotRev1 As Double = 0
            Dim TotRev2 As Double = 0
            Dim TotRev3 As Double = 0
            Dim TotRev4 As Double = 0
            For i As Integer = 0 To Grid.Rows.Count - 1
                If i = 12 Then
                    Exit For
                End If
                TotRev0 = TotRev0 + CInt(Grid.Rows(i).Cells("colRev0").Value)
                TotRev1 = TotRev1 + CDbl(Grid.Rows(i).Cells("colRev1").Value)
                TotRev2 = TotRev2 + CDbl(Grid.Rows(i).Cells("colRev2").Value)
                TotRev3 = TotRev3 + CDbl(Grid.Rows(i).Cells("colRev3").Value)
                TotRev4 = TotRev4 + CDbl(Grid.Rows(i).Cells("colRev4").Value)
            Next

            Grid.Rows(12).Cells("colRev0").Value = TotRev0.ToString("n", id)
            Grid.Rows(12).Cells("colRev1").Value = TotRev1.ToString("n", id)
            Grid.Rows(12).Cells("colRev2").Value = TotRev2.ToString("n", id)
            Grid.Rows(12).Cells("colRev3").Value = TotRev3.ToString("n", id)
            Grid.Rows(12).Cells("colRev4").Value = TotRev4.ToString("n", id)
        End With
    End Sub
End Class
