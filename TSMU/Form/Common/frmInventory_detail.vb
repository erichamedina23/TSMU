Public Class frmInventory_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsInventory
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim ff_detail As frmBoM_detail_input
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String, _
                   ByVal strCode2 As String, _
                   ByRef lf_FormParent As Form, _
                   ByVal li_GridRow As Integer, _
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
    Private Sub frmInventory_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Me.Text = "Master Inventory " & fs_Code
            Else
                Me.Text = "Master New Inventory"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmInventory"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtInvtId.Text = .InvtID
                    _txtDesc.Text = .Desc
                    _txtPartNo.Text = .Catalog
                    _txtCarModel.Text = .CarModel
                    _txtPacking.Text = .Packing
                    _cmbUnit.Text = .Unit
                    _txtMinStok.Text = .MinStok
                    _txtUnitPrice.Text = .Price
                    _txtPO.Text = .Polt
                    _txtMflg.Text = .Mfglt
                    _cmbGroup.Text = .Group
                    _txtRemark.Text = .Remark
                    _txtDesc.Focus()
                End With
            Else
                _txtInvtId.Text = ""
                _txtDesc.Text = ""
                _txtPartNo.Text = ""
                _txtCarModel.Text = ""
                _cmbUnit.Text = ""
                _txtMinStok.Text = ""
                _txtUnitPrice.Text = ""
                _txtPO.Text = ""
                _txtMflg.Text = ""
                _txtPacking.Text = ""
                _txtRemark.Text = ""
                _txtInvtId.Focus()
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
             If String.IsNullOrEmpty(_txtInvtId.Text) Then
                errProvider.SetError(_txtInvtId, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtInvtId, "")
            End If
            If String.IsNullOrEmpty(_txtDesc.Text) Then
                errProvider.SetError(_txtDesc, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtDesc, "")
            End If

            If String.IsNullOrEmpty(_txtPartNo.Text) Then
                errProvider.SetError(_txtPartNo, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtPartNo, "")
            End If

            If String.IsNullOrEmpty(_txtCarModel.Text) Then
                errProvider.SetError(_txtCarModel, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtCarModel, "")
            End If

            If String.IsNullOrEmpty(_cmbUnit.Text) Then
                errProvider.SetError(_cmbUnit, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbUnit, "")
            End If

            If String.IsNullOrEmpty(_cmbGroup.Text) Then
                errProvider.SetError(_cmbGroup, "Value cannot be empty.")
            Else
                errProvider.SetError(_cmbGroup, "")
            End If

            If Not IsNumeric(_txtPacking.Text) Then
                errProvider.SetError(_txtPacking, "Value must be a numeric.")
            Else
                errProvider.SetError(_txtPacking, "")
            End If

            If Not IsNumeric(_txtMinStok.Text) Then
                errProvider.SetError(_txtMinStok, "Value must be a numeric.")
            Else
                errProvider.SetError(_txtMinStok, "")
            End If
            If Not IsNumeric(_txtUnitPrice.Text) Then
                errProvider.SetError(_txtUnitPrice, "Value must be a numeric.")
            Else
                errProvider.SetError(_txtUnitPrice, "")
            End If

            If Not IsNumeric(_txtPO.Text) Then
                errProvider.SetError(_txtPO, "Value must be a numeric.")
            Else
                errProvider.SetError(_txtPO, "")
            End If

            If Not IsNumeric(_txtMflg.Text) Then
                errProvider.SetError(_txtMflg, "Value must be a numeric.")
            Else
                errProvider.SetError(_txtMflg, "")
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
                    .InvtID = _txtInvtId.Text.Trim
                    .Desc = _txtDesc.Text.Trim
                    .Unit = _cmbUnit.Text.Trim
                    .Catalog = _txtPartNo.Text.Trim
                    .Packing = _txtPacking.Text.Trim
                    .MinStok = _txtMinStok.Text.Trim
                    .Group = _cmbGroup.Text.Trim
                    .Polt = _txtPO.Text.Trim
                    .Mfglt = _txtMflg.Text.Trim
                    .Remark = _txtRemark.Text.Trim
                    .CarModel = _txtCarModel.Text.Trim
                    .Price = _txtUnitPrice.Text.Trim
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

                fc_Class.InsertHeader()
            Else
                fc_Class.UpdateHeader()
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            Dim targetString As String = _txtInvtId.Text
            For Each row As DataGridViewRow In Me.GridDtl.Rows
                If row.Cells(0).Value = targetString Then
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

    Private Sub _cmbUnit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _cmbUnit.KeyPress, _cmbGroup.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub _txtInvtId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles _txtInvtId.Validating
        If String.IsNullOrEmpty(_txtInvtId.Text) Then
            errProvider.SetError(_txtInvtId, "Value cannot be empty.")
        Else
            errProvider.SetError(_txtInvtId, "")
        End If
    End Sub

End Class
