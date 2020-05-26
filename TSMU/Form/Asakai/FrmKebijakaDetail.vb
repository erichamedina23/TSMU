Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmKebijakaDetail

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable


    Dim DeptID As String

    '---------------------------
    Dim DtScan As DataTable
    Dim ObjKebijakan As New KebijakanModel
    Dim ObjKebijakanDetail As New KebijakanDetailModel


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(ByVal strCode As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub FrmKebijakaDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub


    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjKebijakan.ID = fs_Code
                ObjKebijakan.GetData(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Kebijakan" & fs_Code
            Else
                Me.Text = "Kebijakan"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmKebijakan"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjKebijakan
                    TxtNo.Text = .ID
                    TxtKebijakan.Text = .Kebijakan
                End With
            Else
                TxtNo.Text = ""
                TxtKebijakan.Text = ""
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
            If TxtNo.Text = "" Then
                MessageBox.Show("No Harap di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtKebijakan.Text = "" Then
                MessageBox.Show("Kebijakan Harap di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Else
                lb_Validated = True
            End If

            If lb_Validated Then
                With ObjKebijakan
                    .ID = TxtNo.Text
                    .Kebijakan = TxtKebijakan.Text

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
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub getdataview1()
        Try

            Dim IsEmpty As Boolean = False

            If isUpdate = False Then

                ObjKebijakan = New KebijakanModel
                With ObjKebijakan
                    .ID = TxtNo.Text
                    .Kebijakan = TxtKebijakan.Text
                End With

                ObjKebijakan.InsertDataKebijakan()
                GridDtl.DataSource = ObjKebijakan.GetDataLoad()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else

                ObjKebijakan = New KebijakanModel
                With ObjKebijakan
                    .ID = TxtNo.Text
                    .Kebijakan = TxtKebijakan.Text
                End With

                ObjKebijakan.UpdateData()
                GridDtl.DataSource = ObjKebijakan.GetDataLoad()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub





End Class
