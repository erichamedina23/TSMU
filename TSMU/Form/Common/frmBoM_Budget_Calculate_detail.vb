Public Class frmBoM_Budget_Calculate_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsBoM_Budget_Calculated
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim ff_detail As frmBoM_detail_input
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim dtGrid1 As New DataTable
    Dim intRevisi As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   strCode3 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As DataGridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            fs_Code3 = strCode3
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub


    Private Sub frmBoM_detail1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call InitialSetForm()

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                'intRevisi = fc_Class.getDetailBoM(fs_Code, fs_Code2)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Calculated BoM " & fs_Code
            Else
                Me.Text = "Master New Calculated BoM"
            End If
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call LoadGridDetil()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmBom_Budget_Calculate"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtBoMID.Text = .BoMID
                    _txtInvID.Text = .InvtID
                    _txtDesc.Text = .Desc
                    _txtTahun.Text = .Tahun
                    _txtSemester.Text = .Semester
                    _txtTotal.Text = .Total
                    _txtBoMID.Focus()
                End With
            Else
                _txtBoMID.Text = ""
                _txtInvID.Text = ""
                _txtDesc.Text = ""
                _txtTahun.Text = ""
                _txtSemester.Text = ""
                _txtTotal.Text = "0"
                _txtBoMID.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetil()
    End Sub

    Public Sub LoadGridDetil()
        Try
            dtGrid = fc_Class.getDetailBoM(_txtBoMID.Text, fs_Code2)
            GridDetail.DataSource = dtGrid
            GridDetail.ReadOnly = True
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
