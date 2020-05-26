Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmMaterialDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New MaterialModel
    Dim GridDtl As GridControl

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
    Private Sub FrmMaterialDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
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
                Me.Text = "Master Departemen " & fs_Code
            Else
                Me.Text = "Master New Departemen"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmDepartemen"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TxtIDMaterial.Text = .IDMaterial
                    TxtDescription.Text = .Description
                    CmbJenis.Text = .Jenis
                    TxtHarga.Text = .Harga
                    TxtIDMaterial.Enabled = False
                    Call FillComboJenis()
                    'TxtDeptID.Focus()
                End With
            Else
                TxtIDMaterial.Text = ""
                TxtDescription.Text = ""
                CmbJenis.Text = ""
                TxtHarga.Text = "0"
                TxtIDMaterial.Focus()
                Call FillComboJenis()
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
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(TxtIDMaterial.Text) Then
                ErrorProvider.SetError(TxtIDMaterial, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtIDMaterial, "")
            End If


            If String.IsNullOrEmpty(TxtDescription.Text) Then
                ErrorProvider.SetError(TxtDescription, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtDescription, "")
            End If

            If String.IsNullOrEmpty(CmbJenis.Text) Then
                ErrorProvider.SetError(CmbJenis, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(CmbJenis, "")
            End If

            If String.IsNullOrEmpty(TxtHarga.Text) Then
                ErrorProvider.SetError(TxtHarga, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtHarga, "")
            End If

            Dim success As Boolean = True
            For Each c As Control In LayoutControl1.Controls
                If ErrorProvider.GetError(c).Length > 0 Then
                    success = False
                End If
            Next

            If success Then
                lb_Validated = True
            End If

            If lb_Validated Then
                With fc_Class
                    .IDMaterial = TxtIDMaterial.Text
                    .Description = TxtDescription.Text
                    '.IDJenis = CmbJenis.ValueMember
                    .Harga = Val(TxtHarga.Text)

                    If CmbJenis.Text = "" Then
                        .IDJenis = CmbJenis.SelectedValue.ToString.ToUpper
                    ElseIf CmbJenis.Text <> "" Then
                        .IDJenis = CmbJenis.SelectedValue.ToString.ToUpper
                    End If

                    'Dim oDate As DateTime = DateTime.ParseExact(TxtTanggalAbsen.Text, "dd-MM-yyyy", provider)
                    '.TanggalAbsen = oDate

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

    Private Sub FillComboJenis()
        Try
            Dim Jenis As JenisModel = New JenisModel
            Dim dt As New DataTable
            dt = Jenis.GetAllDataTableJenis()
            CmbJenis.DataSource = Nothing
            CmbJenis.Items.Clear()
            CmbJenis.DataSource = dt
            CmbJenis.DisplayMember = "Description"
            CmbJenis.ValueMember = "IDJenis"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                fc_Class.Insert()
            Else
                fc_Class.Update(fs_Code)
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)

            IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
