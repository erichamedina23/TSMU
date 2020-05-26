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
Public Class FrmQualityProblemDetail

    Private dt As DataTable

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjQualityProblemDetail As New QualityProblemDetailModel
    Dim KodeTrans As String = ""
    Dim fc_Class As New QualityProblemModel
    Dim GridDtl As GridControl

    'Dim CekDirectoryFoto = "D:\@KERJA\Project\Foto"


    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto"
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim DirectoryFoto As String = ""
    Dim extension As String = ""
    Dim fileSavePath As String = ""
    Dim opfImage As New OpenFileDialog

    Dim Kode As String = ""

    Private Sub FrmQualityProblemDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = New DataTable
        dt.Columns.Add("Shift")
        dt.Columns.Add("Status")
        dt.Columns.Add("Customer")
        dt.Columns.Add("InvtId")
        dt.Columns.Add("InvtName")
        dt.Columns.Add("Type")
        dt.Columns.Add("Qty")
        dt.Columns.Add("Problem")
        dt.Columns.Add("Analisis")
        dt.Columns.Add("Correction Action")
        dt.Columns.Add("Preventive Action")
        dt.Columns.Add("Pic")
        dt.Columns.Add("Target")
        dt.Columns.Add("Gambar")
        dt.Columns.Add("Lot No")
        dt.Columns.Add("Path")
        dt.Columns.Add("Gambar Hapus")

        Grid.DataSource = dt
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()


    End Sub
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



    Private Sub CmbShift_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbShift.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (0) Then
            e.Handled = True
        End If
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
                Me.Text = "Quality Problem " & fs_Code
            Else
                Me.Text = "Quality Problem"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmQualityProblem"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DtTanggalLaporan.Value = fc_Class.H_Tanggal

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
                Dim dtGridProblem As New DataTable
                dtGridProblem = fc_Class.GetDataDetailQualityProblem(fs_Code)
                Grid.DataSource = dtGridProblem
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
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
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailQualityProblem.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjQualityProblemDetail = New QualityProblemDetailModel
                    With ObjQualityProblemDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Shift = Convert.ToString(GridView1.GetRowCellValue(i, "Shift"))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_InvtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "InvtName"))
                        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .D_Qty = Convert.ToString(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_Analisis = Convert.ToString(GridView1.GetRowCellValue(i, "Analisis"))
                        .D_CORRECTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action"))
                        .D_PREVENTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action"))
                        .D_Pic = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                        .D_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))

                    End With
                    fc_Class.ObjDetailQualityProblem.Add(ObjQualityProblemDetail)


                    fileSavePath = IO.Path.Combine(SimpanFoto, Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                    File.Copy(Convert.ToString(GridView1.GetRowCellValue(i, "Path")), fileSavePath, True)



                Next

                fc_Class.InsertQualityProblem(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailQualityProblem.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjQualityProblemDetail = New QualityProblemDetailModel
                    With ObjQualityProblemDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Shift = Convert.ToString(GridView1.GetRowCellValue(i, "Shift"))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_InvtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "InvtName"))
                        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .D_Qty = Convert.ToString(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_Analisis = Convert.ToString(GridView1.GetRowCellValue(i, "Analisis"))
                        .D_CORRECTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action"))
                        .D_PREVENTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action"))
                        .D_Lot = Convert.ToString(GridView1.GetRowCellValue(i, "Lot No"))
                        .D_Pic = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                        .D_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))

                    End With
                    fc_Class.ObjDetailQualityProblem.Add(ObjQualityProblemDetail)

                    If Convert.ToString(GridView1.GetRowCellValue(i, "Path")) <> "" And Convert.ToString(GridView1.GetRowCellValue(i, "Gambar Hapus")) <> "" Then

                        File.Delete(SimpanFoto & "/" & Convert.ToString(GridView1.GetRowCellValue(i, "Gambar Hapus")))

                        fileSavePath = IO.Path.Combine(SimpanFoto, Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                        File.Copy(Convert.ToString(GridView1.GetRowCellValue(i, "Path")), fileSavePath, True)
                    End If

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


                    .H_Tanggal = Format(CDate(Format(DtTanggalLaporan.Value, "yyyy-MM-dd")))

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

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub

    Private Sub TxtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtQty.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Try
            If TxtQty.Text = "" Then
                MessageBox.Show("Qty Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtCustomer.Text = "" Then
                MessageBox.Show("Customer Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtID.Text = "" Then
                MessageBox.Show("Invt ID Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtName.Text = "" Then
                MessageBox.Show("Invt Name Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf CmbShift.Text = "" Then
                MessageBox.Show("Pilih Shift",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtType.Text = "" Then
                MessageBox.Show("Pilih Shift",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtStatus.Text = "" Then
                MessageBox.Show("Status Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtProblem.Text = "" Then
                MessageBox.Show("Problem Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtAnalisis.Text = "" Then
                MessageBox.Show("Analisi Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtCorrection.Text = "" Then
                MessageBox.Show("Correction Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtPreventive.Text = "" Then
                MessageBox.Show("Preventive Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf NamaFile = "" Then
                MessageBox.Show("Pilih Gambar",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf PathFoto = "" Then
                MessageBox.Show("Pilih Gambar",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Else
                GridView1.AddNewRow()
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Shift, CmbShift.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Status, TxtStatus.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Customer, TxtCustomer.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtId, TxtInvtID.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtName, TxtInvtName.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Type, TxtType.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Qty, TxtQty.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Problem, TxtProblem.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Analisis, TxtAnalisis.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, CorrectionAction, TxtCorrection.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PreventiveAction, TxtPreventive.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Pic, TxtPic.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, LotNo, TxtLotNo.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Target, DtTarget.Value)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Path, PathFoto)
                GridView1.UpdateCurrentRow()
                'File.Copy(opfImage.FileName, fileSavePath, True)
                Call TextBoxLoad()
                PictureBox1.Image = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub TextBoxLoad()
        TxtStatus.Text = ""
        TxtCustomer.Text = ""
        TxtInvtID.Text = ""
        TxtInvtName.Text = ""
        TxtType.Text = ""
        TxtQty.Text = "0"
        TxtProblem.Text = ""
        TxtAnalisis.Text = ""
        TxtCorrection.Text = ""
        TxtPreventive.Text = ""
        TxtPic.Text = ""
        TxtLotNo.Text = ""

    End Sub



    Private Sub BGambar_Click(sender As Object, e As EventArgs) Handles BGambar.Click


        opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif;*.Jpeg)|*.jpg;*.png;*.gif;*.Jpeg"

        Dim a As String = "D:\@KERJA\Project\Foto\"

        If opfImage.ShowDialog = DialogResult.OK Then

            Dim Tanggal As String = Convert.ToString(Format(Date.Now, "yyyy-MM-dd"))
            PictureBox1.Image = Image.FromFile(opfImage.FileName)

            Dim NewSize As New Size(600, 400)
            Dim Resize As Image = New Bitmap(PictureBox1.Image, NewSize)
            PictureBox1.Image = Resize


            PathFoto = opfImage.FileName
            Dim extension As String = IO.Path.GetExtension(PathFoto)
            NamaFile = Tanggal & "_QCPROBLEM_" + IO.Path.GetRandomFileName() + extension
            fileSavePath = IO.Path.Combine(SimpanFoto, NamaFile)

            'File.Copy(opfImage.FileName, fileSavePath, True)

            Dim i As Image = PictureBox1.Image
            Dim i2 As Image = New Bitmap(i)
            i2.Save(SimpanFoto & NamaFile, System.Drawing.Imaging.ImageFormat.Jpeg)

        End If


    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Try

            opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif;*.Jpeg)|*.jpg;*.png;*.gif;*.Jpeg"
            Dim a As String = "D:\@KERJA\Project\Foto\"

            If opfImage.ShowDialog = DialogResult.OK Then

                Dim Tanggal As String = Convert.ToString(Format(Date.Now, "yyyy-MM-dd"))
                PictureBox1.Image = Image.FromFile(opfImage.FileName)

                Dim NewSize As New Size(600, 400)
                Dim Resize As Image = New Bitmap(PictureBox1.Image, NewSize)
                PictureBox1.Image = Resize

                PathFoto = opfImage.FileName
                Dim extension As String = IO.Path.GetExtension(PathFoto)
                NamaFile = Tanggal & "_QCPROBLEM_" + IO.Path.GetRandomFileName() + extension

                'fileSavePath = IO.Path.Combine(SimpanFoto, NamaFile)
                'File.Copy(opfImage.FileName, fileSavePath, True)

                Dim i As Image = PictureBox1.Image

                Dim i2 As Image = New Bitmap(i)
                i2.Save(SimpanFoto & NamaFile, System.Drawing.Imaging.ImageFormat.Jpeg)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Path, PathFoto)

            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


End Class
