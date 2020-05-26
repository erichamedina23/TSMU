Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports ExcelDataReader
'Imports GemBox.Spreadsheet
Imports System.Data.OleDb
Public Class FrmDetailPerbaikan
    Dim KodeTran As String = ""
    Dim GridDtl As GridControl
    Private dt As DataTable


    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim KodeTrans As String = ""
    Dim fc_Class As New MaintenanPerbaikanModel
    Dim ObjDetail As New MaintenancePerbaikanDetailModel

    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim DirectoryFoto As String = ""
    Dim extension As String = ""
    Dim fileSavePath As String = ""
    Dim opfImage As New OpenFileDialog

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
            KodeTran = fs_Code
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub FrmDetailPerbaikan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = New DataTable
        dt.Columns.Add("No")
        dt.Columns.Add("Jenis")
        dt.Columns.Add("Problem")
        dt.Columns.Add("Action")
        dt.Columns.Add("Dari")
        dt.Columns.Add("Sampai")
        dt.Columns.Add("Status")
        dt.Columns.Add("Keterangan")
        Grid.DataSource = dt
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
                Me.Text = "Perbaikan" & fs_Code
                DateTanggal.Enabled = False
            Else
                Me.Text = "Perbaikan"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FormPerbaikan"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DateTanggal.EditValue = fc_Class.H_Tanggal

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then

                dt = fc_Class.GetDataDetail(fs_Code)
                Grid.DataSource = dt
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If GridView1.RowCount < 1 Then

                MessageBox.Show("Belum Melakukan Inputan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            Else
                lb_Validated = True

            End If

            If lb_Validated Then
                fc_Class.H_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")

                With fc_Class

                    If isUpdate = False Then
                        .ValidateInsert()
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

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub

    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Belum Melakukan Inputan", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Pastikan Data Tidak ada yang kosong", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next
            End If

            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.H_IDTransaksi
                fc_Class.H_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailMaintenancePerbaikan.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDetail = New MaintenancePerbaikanDetailModel
                    With ObjDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")
                        .D_Jenis = Convert.ToString(GridView1.GetRowCellValue(i, "Jenis"))
                        .D_No = Convert.ToString(GridView1.GetRowCellValue(i, "No"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_Action = Convert.ToString(GridView1.GetRowCellValue(i, "Action"))
                        .D_TanggalDari = Convert.ToDateTime(Format(GridView1.GetRowCellValue(i, "Dari")))
                        .D_TanggalSampai = Convert.ToDateTime(Format(GridView1.GetRowCellValue(i, "Sampai")))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))

                    End With
                    fc_Class.ObjDetailMaintenancePerbaikan.Add(ObjDetail)

                Next

                fc_Class.InsertMain(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                fc_Class.H_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailMaintenancePerbaikan.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDetail = New MaintenancePerbaikanDetailModel
                    With ObjDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")
                        .D_Jenis = Convert.ToString(GridView1.GetRowCellValue(i, "Jenis"))
                        .D_No = Convert.ToString(GridView1.GetRowCellValue(i, "No"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_Action = Convert.ToString(GridView1.GetRowCellValue(i, "Action"))
                        .D_TanggalDari = Convert.ToDateTime(Format(GridView1.GetRowCellValue(i, "Dari")))
                        .D_TanggalSampai = Convert.ToDateTime(Format(GridView1.GetRowCellValue(i, "Sampai")))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))

                    End With
                    fc_Class.ObjDetailMaintenancePerbaikan.Add(ObjDetail)

                Next


                fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
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

    Private Sub BTambah_Click(sender As Object, e As EventArgs) Handles BTambah.Click
        Try
            If DateTanggal.Text = "" Then
                MessageBox.Show("Tanggal Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf DateDari.Text = "" Then
                MessageBox.Show("Tanggal Dari Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf DateSampai.Text = "" Then
                MessageBox.Show("Tanggal Sampai jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Else
                GridView1.AddNewRow()
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, No, TNoMesin.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Jenis, TJenis.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Problem, TProblem.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Action, TAction.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Dari, DateDari.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Sampai, DateSampai.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Status, CStatus.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Keterangan, TKeterangan.EditValue)
                'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TargetClose, Format(DtTargetClose.Value, "yyyy-MM-dd"))

                GridView1.UpdateCurrentRow()

                Call TextKosong()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub TextKosong()
        TNoMesin.EditValue = ""
        TJenis.EditValue = ""
        TProblem.EditValue = ""
        TAction.EditValue = ""
        CStatus.EditValue = ""
        TKeterangan.EditValue = ""

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub

    Private Sub TJenis_KeyUp(sender As Object, e As KeyEventArgs) Handles TJenis.KeyUp

    End Sub

    Private Sub CStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CStatus.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TJenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TJenis.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CStatus.SelectedIndexChanged

    End Sub
End Class
