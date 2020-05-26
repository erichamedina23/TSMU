Public Class frmLokasi_detail_input
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsLokasiDetail
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As DataGridView)
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
    Private Sub frmCoA_detail_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Me.Text = "Master Lokasi Details " & fs_Code
            Else
                Me.Text = "Master New Lokasi Details"
            End If
            FillComboLokasi()
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmLokasi_detail"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtId.Text = .ID
                    _txtDeskripsi.Text = .Deskripsi
                    _cmbLokasi.Text = .IDLokasi
                    _txtId.Focus()
                End With
            Else
                _txtId.Text = ""
                _txtDeskripsi.Text = ""
                _cmbLokasi.Text = ""
                _txtId.Focus()
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
        Try
            If String.IsNullOrEmpty(_txtId.Text) Then
                errProvider.SetError(_txtId, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtId, "")
            End If

            If String.IsNullOrEmpty(_txtDeskripsi.Text) Then
                errProvider.SetError(_txtDeskripsi, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtDeskripsi, "")
            End If

            If String.IsNullOrEmpty(_cmbLokasi.Text) Then
                errProvider.SetError(_cmbLokasi, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbLokasi, "")
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
                    .ID = _txtId.Text.Trim.ToUpper
                    .Deskripsi = _txtDeskripsi.Text.Trim.ToUpper
                    .IDLokasi = _cmbLokasi.SelectedValue.ToString.ToUpper
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
                fc_Class.Update(fs_Code)
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            Dim targetString As String = _txtId.Text
            For Each row As DataGridViewRow In Me.GridDtl.Rows
                If RTrim(row.Cells(0).Value.ToString) = targetString Then
                    Me.GridDtl.ClearSelection()
                    Me.GridDtl.Rows(row.Index).Selected = True
                    Exit For
                End If
            Next
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

    Private Sub FillComboLokasi()
        Try
            Dim lokasi As clsLokasi = New clsLokasi
            Dim dt As New DataTable
            dt = lokasi.GetAllData
            _cmbLokasi.DataSource = Nothing
            _cmbLokasi.Items.Clear()
            _cmbLokasi.DataSource = dt
            _cmbLokasi.DisplayMember = "Deskripsi"
            _cmbLokasi.ValueMember = "ID Lokasi"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
