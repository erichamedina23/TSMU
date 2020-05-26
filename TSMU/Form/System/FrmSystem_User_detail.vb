Public Class FrmSystem_User_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClassSystemUser1
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim dtGrid1 As New DataTable
    Dim intRevisi As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String, _
                   ByRef lf_FormParent As Form, _
                   ByVal li_GridRow As Integer, _
                   ByRef _Grid As DataGridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub FrmSystem_User_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByUsername(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Master User " & fs_Code
            Else
                Me.Text = "Master New User"
            End If
            Call fillGroupCombo()
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmBoM"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtUsername.Text = .Username
                    _txtDesc.Text = .Name
                    _txtPass.Text = .Password
                    If .AdminStatus = "1" Then
                        _chkAdmin.Checked = True
                    Else
                        _chkAdmin.Checked = False
                    End If
                    If .FlagActive = "1" Then
                        _chkAktif.Checked = True
                    Else
                        _chkAktif.Checked = False
                    End If
                    _cmbGroup.Text = .UserGroupName
                    _txtRemark.Text = .Remark
                    _txtUsername.ReadOnly = True
                    _txtPass.Focus()
                End With
            Else
                _txtUsername.Text = ""
                _txtDesc.Text = ""
                _txtPass.Text = ""

                _chkAdmin.Checked = False

                _chkAktif.Checked = False
                _cmbGroup.Text = ""
                _txtRemark.Text = ""
                _txtUsername.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub fillGroupCombo()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetComboGroup
            _cmbGroup.DataSource = Nothing
            _cmbGroup.Items.Clear()
            _cmbGroup.DataSource = dt
            _cmbGroup.ValueMember = "UserGroupCode"
            _cmbGroup.DisplayMember = "UserGroupName"

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
