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

Public Class FrmProblemDeliveryUpload

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ProblemDeliveryModel
    Dim ObjProblemDeliveryDetail As New ProblemDeliveryDetailModel

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Dim ObjDeliveryDetail As New DeliveryDetailModel
    Dim Tanggal As Date
    Dim Keterangan As String = ""
    Dim KodeTrans As String = ""
    Dim dt As New DataTable

    Dim FileLokasi As String


    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"
    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim DirectoryFoto As String = ""
    Dim extension As String = ""
    Dim fileSavePath As String = ""
    Dim opfImage As New OpenFileDialog
    Private dt1 As DataTable


    Private Sub FrmProblemDeliveryUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid.DataSource = dt
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()



    End Sub



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmDeliveryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
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

    Private Sub BCari_Click(sender As Object, e As EventArgs) Handles BCari.Click

        If DateTanggal.EditValue = Nothing Then
            MessageBox.Show("Harap Pilih Tanggal",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
        Else
            Try
                Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}

                    Dim tanggal As Date = Convert.ToDateTime(DateTanggal.EditValue)

                    If ofd.ShowDialog() = DialogResult.OK Then
                        FileLokasi = ofd.FileName

                        If IO.File.Exists(FileLokasi) Then
                            Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                            cn.Open()
                            Dim cmd As OleDbCommand = New OleDbCommand("SELECT F2 as [Tanggal]
                                                                        ,F3 as [Customer]
                                                                        ,F4 as [Standar]
                                                                        ,F5 as [Aktual]
                                                                        ,F6 as [Kirim Kurang]
                                                                        ,F7 as [Campur]
                                                                        ,F8 as [Kirim Lebih Isi]
                                                                        ,F9 as [Salah Isi]
                                                                        ,F10 as [Salah Passcard]
                                                                        ,F11 as [Lain Lain]
                                                                        ,F12 as [Transporter]
                                                                        ,F13 as [Keterangan]
                                                                        ,F14 as [Gambar]
                                                                         FROM [PROBLEM$A8:Z300] 
                                                                         where F2 = #" & tanggal & "#", cn)

                            'Dim dt As New DataTable
                            dt.Load(cmd.ExecuteReader)

                            For i As Integer = 0 To dt.Rows.Count - 1


                                If dt.Rows(i).Item(4) Is DBNull.Value Then
                                    dt.Rows(i).Item(4) = "0"
                                End If

                                If dt.Rows(i).Item(5) Is DBNull.Value Then
                                    dt.Rows(i).Item(5) = "0"
                                End If

                                If dt.Rows(i).Item(6) Is DBNull.Value Then
                                    dt.Rows(i).Item(6) = "0"
                                End If


                                If dt.Rows(i).Item(7) Is DBNull.Value Then
                                    dt.Rows(i).Item(7) = "0"
                                End If

                                If dt.Rows(i).Item(8) Is DBNull.Value Then
                                    dt.Rows(i).Item(8) = "0"
                                End If

                                If dt.Rows(i).Item(9) Is DBNull.Value Then
                                    dt.Rows(i).Item(9) = "0"
                                End If

                                If dt.Rows(i).Item(10) Is DBNull.Value Then
                                    dt.Rows(i).Item(10) = "0"
                                End If


                                dt.Rows(i).Item(12) = ""



                            Next

                            cn.Close()
                            Grid.DataSource = dt

                            'Dim cbHeader As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            'cbHeader.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            'Dim cnHeader As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbHeader.ConnectionString}





                        End If
                    End If
                End Using
            Catch ex As Exception
                ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
        End If



    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try

            opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;*.Jpeg"

            If opfImage.ShowDialog = DialogResult.OK Then


                PathFoto = opfImage.FileName
                Dim extension As String = Path.GetExtension(PathFoto)
                NamaFile = "PD_" + Path.GetRandomFileName() + extension
                fileSavePath = Path.Combine(SimpanFoto, NamaFile)
                File.Copy(opfImage.FileName, fileSavePath, True)

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, "")
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)

            End If
        Catch ex As Exception

        End Try
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
                Me.Text = "Problem Delivery " & fs_Code
                DateTanggal.EditValue = fc_Class.H_Tanggal
            Else
                Me.Text = "Problem Delivery"
            End If
            ' Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmProblemDelivery"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridProblem As New DataTable
                dtGridProblem = fc_Class.GetDataDetailProblemDelivery(fs_Code)
                Grid.DataSource = dtGridProblem
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        'Call LoadTxtBox()
        'LoadGridDetail()
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
                With fc_Class


                    .H_Tanggal = Format(CDate(Format(DateTanggal.EditValue, "yyyy-MM-dd")))

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
                If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                    IsEmpty = True
                    'GridView2.DeleteRow(i)
                    MessageBox.Show("Pastikan Data tidak ada yang kosong")
                    Exit Sub
                End If
            Next
            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailProblemDelivery.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjProblemDeliveryDetail = New ProblemDeliveryDetailModel
                    With ObjProblemDeliveryDetail
                        .D_IDTrans = KodeTrans
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_Standar = Convert.ToString(GridView1.GetRowCellValue(i, "Standar"))
                        .D_Aktual = Convert.ToString(GridView1.GetRowCellValue(i, "Aktual"))
                        .D_KirimKurang = Convert.ToInt32(GridView1.GetRowCellValue(i, "Kirim Kurang"))
                        .D_Campur = Convert.ToInt32(GridView1.GetRowCellValue(i, "Campur"))
                        .D_KirimLebihIsi = Convert.ToInt32(GridView1.GetRowCellValue(i, "Kirim Lebih Isi"))
                        .D_SalahIsi = Convert.ToInt32(GridView1.GetRowCellValue(i, "Salah Isi"))
                        .D_SalahPasscard = Convert.ToInt32(GridView1.GetRowCellValue(i, "Salah Passcard"))
                        .D_Transporter = Convert.ToInt32(GridView1.GetRowCellValue(i, "Transporter"))
                        .D_LainLain = Convert.ToInt32(GridView1.GetRowCellValue(i, "Lain Lain"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))
                    End With
                    fc_Class.ObjDetailProblemDelivery.Add(ObjProblemDeliveryDetail)

                Next

                fc_Class.InsertProblemDelivery(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                fc_Class.H_Tanggal = Format(DateTanggal.EditValue, "yyyy-MM-dd")

                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailProblemDelivery.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjProblemDeliveryDetail = New ProblemDeliveryDetailModel
                    With ObjProblemDeliveryDetail
                        .D_IDTrans = KodeTrans
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_Standar = Convert.ToString(GridView1.GetRowCellValue(i, "Standar"))
                        .D_Aktual = Convert.ToString(GridView1.GetRowCellValue(i, "Aktual"))
                        .D_KirimKurang = Convert.ToInt32(GridView1.GetRowCellValue(i, "Kirim Kurang"))
                        .D_Campur = Convert.ToInt32(GridView1.GetRowCellValue(i, "Campur"))
                        .D_KirimLebihIsi = Convert.ToInt32(GridView1.GetRowCellValue(i, "Kirim Lebih Isi"))
                        .D_SalahIsi = Convert.ToInt32(GridView1.GetRowCellValue(i, "Salah Isi"))
                        .D_SalahPasscard = Convert.ToInt32(GridView1.GetRowCellValue(i, "Salah Passcard"))
                        .D_Transporter = Convert.ToInt32(GridView1.GetRowCellValue(i, "Transporter"))
                        .D_LainLain = Convert.ToInt32(GridView1.GetRowCellValue(i, "Lain Lain"))
                        .D_Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))
                    End With
                    fc_Class.ObjDetailProblemDelivery.Add(ObjProblemDeliveryDetail)

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
