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
Imports GemBox.Spreadsheet
Imports System.Data.OleDb

Public Class FrmInjectionShotDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New InjectionShotModel

    Dim GridDtl As GridControl
    Dim dt As New DataTable

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Dim ObjDetail As New InjectionShortDetailModel
    Dim Tanggal As Date
    Dim Keterangan As String = ""
    Dim IdTransaksi As String = ""

    Dim FileLokasi As String


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmInjectionShotDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
        DateTanggal.EditValue = (Date.Now)
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
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                Tanggal = fc_Class.Tanggal
                IdTransaksi = fc_Class.IDTransaksi
                DateTanggal.Enabled = False
                T_Shift.Enabled = False
                T_Pic.Enabled = False
                DateTanggal.EditValue = fc_Class.Tanggal
                T_Shift.EditValue = fc_Class.Shift
                T_Pic.EditValue = fc_Class.Pic

                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Analisa Shot " & fs_Code
            Else
                Me.Text = "Analisa Shot"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmInjectionShot"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    'LblTanggal.Text = Format(fc_Class.Tanggal, gs_FormatSQLDateIn)

                End With
            Else
                'LblTanggal.Text = Format(Date.Now, gs_FormatSQLDateIn)

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dt2 As New DataTable
                dt2 = fc_Class.GetDataDetail(fs_Code)
                Grid.DataSource = dt2
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_Browse_Click(sender As Object, e As EventArgs) Handles Btn_Browse.Click

        If T_Shift.EditValue = "" Then
            MessageBox.Show("Harap Isi Shift",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        ElseIf T_Pic.EditValue = "" Then
            MessageBox.Show("Harap Isi PIC",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            Try
                Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}


                    If ofd.ShowDialog() = DialogResult.OK Then
                        FileLokasi = ofd.FileName

                        If IO.File.Exists(FileLokasi) Then
                            Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                            cn.Open()

                            Dim cmd As OleDbCommand = New OleDbCommand("SELECT F1 as Mesin
                                                                           , F2 as Merek
                                                                           , F3 as [Nama Part]
                                                                           , F4 as Type
                                                                           , F5 as 1
                                                                           , F6 as 2
                                                                           , F7 as 3
                                                                           , F8 as 4
                                                                           , F9 as 5
                                                                           , F10 as 6
                                                                           , F11 as 7
                                                                           , F12 as 8
                                                                           , F13 as 9
                                                                           , F14 as 10
                                                                           , F15 as Keterangan
                                                                            FROM [SHOT$B7:Z205] where F1 <>''", cn)

                            dt.Load(cmd.ExecuteReader)
                            cn.Close()
                            Grid.DataSource = dt
                        End If
                    End If
                End Using
            Catch ex As Exception
                ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
        End If




    End Sub



    Private Sub T_Shift_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_Shift.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DateTanggal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTanggal.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If

    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub

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
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()

                If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(1)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(2)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(3)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(4)).ToString = "" Then
                    IsEmpty = True
                    MessageBox.Show("Pastikan Data tidak ada yang kosong")
                    Exit Sub
                End If
            Next


            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                IdTransaksi = fc_Class.IDTransaksi
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailColection.Clear()


                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDetail = New InjectionShortDetailModel
                    With ObjDetail

                        .D_Transaksi = IdTransaksi
                        .D_Mesin = Convert.ToString(GridView1.GetRowCellValue(i, "Mesin"))
                        .D_Merek = Convert.ToString(GridView1.GetRowCellValue(i, "Merek"))
                        .D_NamaPart = Convert.ToString(GridView1.GetRowCellValue(i, "Nama Part"))
                        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .D_1 = Convert.ToString(GridView1.GetRowCellValue(i, "1"))
                        .D_2 = Convert.ToString(GridView1.GetRowCellValue(i, "2"))
                        .D_3 = Convert.ToString(GridView1.GetRowCellValue(i, "3"))
                        .D_4 = Convert.ToString(GridView1.GetRowCellValue(i, "4"))
                        .D_5 = Convert.ToString(GridView1.GetRowCellValue(i, "5"))
                        .D_6 = Convert.ToString(GridView1.GetRowCellValue(i, "6"))
                        .D_7 = Convert.ToString(GridView1.GetRowCellValue(i, "7"))
                        .D_8 = Convert.ToString(GridView1.GetRowCellValue(i, "8"))
                        .D_9 = Convert.ToString(GridView1.GetRowCellValue(i, "9"))
                        .D_10 = Convert.ToString(GridView1.GetRowCellValue(i, "10"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))

                    End With
                    fc_Class.ObjDetailColection.Add(ObjDetail)

                Next

                fc_Class.Insert()
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                IdTransaksi = fc_Class.IDTransaksi
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailColection.Clear()


                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDetail = New InjectionShortDetailModel
                    With ObjDetail

                        .D_Transaksi = IdTransaksi
                        .D_Mesin = Convert.ToString(GridView1.GetRowCellValue(i, "Mesin"))
                        .D_Merek = Convert.ToString(GridView1.GetRowCellValue(i, "Merek"))
                        .D_NamaPart = Convert.ToString(GridView1.GetRowCellValue(i, "Nama Part"))
                        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .D_1 = Convert.ToString(GridView1.GetRowCellValue(i, "1"))
                        .D_2 = Convert.ToString(GridView1.GetRowCellValue(i, "2"))
                        .D_3 = Convert.ToString(GridView1.GetRowCellValue(i, "3"))
                        .D_4 = Convert.ToString(GridView1.GetRowCellValue(i, "4"))
                        .D_5 = Convert.ToString(GridView1.GetRowCellValue(i, "5"))
                        .D_6 = Convert.ToString(GridView1.GetRowCellValue(i, "6"))
                        .D_7 = Convert.ToString(GridView1.GetRowCellValue(i, "7"))
                        .D_8 = Convert.ToString(GridView1.GetRowCellValue(i, "8"))
                        .D_9 = Convert.ToString(GridView1.GetRowCellValue(i, "9"))
                        .D_10 = Convert.ToString(GridView1.GetRowCellValue(i, "10"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))

                    End With
                    fc_Class.ObjDetailColection.Add(ObjDetail)

                Next

                fc_Class.Tanggal = Tanggal
                fc_Class.UpdateData()
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

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(DateTanggal.EditValue) Then
                ErrorProvider1.SetError(DateTanggal, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(T_Shift.EditValue) Then
                ErrorProvider1.SetError(T_Shift, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(T_Pic.EditValue) Then
                ErrorProvider1.SetError(T_Pic, "Value cannot be empty")
            ElseIf GridView1.RowCount = 0 Then
                ErrorProvider1.SetError(Grid, "Please Input Data In Grid")
            Else

                ErrorProvider1.Clear()
                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class

                    .Tanggal = Format(CDate(DateTanggal.EditValue))
                    .Shift = Trim(T_Shift.EditValue)
                    .Pic = Trim(T_Pic.EditValue)

                    If isUpdate = False Then      'Belum Di Edit
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

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub
End Class
