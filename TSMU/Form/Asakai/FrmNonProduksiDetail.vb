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
Public Class FrmNonProduksiDetail

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

    Private dt As DataTable

    Dim DeptID As String
    Dim KodeTrans As String = ""


    Dim ObjNonproduksiDetail As New NonProduksiDetailModel
    '---------------------------
    Dim DtScan As DataTable
    Dim Fc_Class As New NonProduksiModel

    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"
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

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                Fc_Class.H_IDTransaksi = fs_Code
                Fc_Class.GetData(fs_Code)
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
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmNonProduksi"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With Fc_Class

                    DtTanggal.Value = Fc_Class.H_Tanggal
                    DtTanggal.Enabled = False
                    'DtDuedate.Value = Fc_Class.D_Duedate

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
                Dim dtGrid As New DataTable
                dtGrid = Fc_Class.GetDataDetailNonProduksi(fs_Code)
                Grid.DataSource = dtGrid
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub FrmNonProduksiDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = New DataTable
        dt.Columns.Add("INFORMASI")
        dt.Columns.Add("PIC")
        dt.Columns.Add("GAMBAR")
        Grid.DataSource = dt

        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Private Sub BTambah_Click(sender As Object, e As EventArgs) Handles BTambah.Click

        GridView1.AddNewRow()
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, INFORMASI, TxtInformasi.Text)
        ' GridView1.SetRowCellValue(GridView1.FocusedRowHandle, DUEDATE, DtDuedate.Value)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PIC, TxtPIC.Text)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GAMBAR, NamaFile)
        GridView1.UpdateCurrentRow()
        Call TextBoxLoad()

    End Sub
    Public Sub TextBoxLoad()
        TxtInformasi.Text = ""
        TxtPIC.Text = ""
        PictureBox1.Image = Nothing
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
            End If

            If isUpdate = False Then
                Fc_Class.GetIDTransAuto()
                KodeTrans = Fc_Class.IDTrans
                Fc_Class.H_IDTransaksi = KodeTrans
                Fc_Class.H_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                Fc_Class.ObjDetailNonProduksi.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjNonproduksiDetail = New NonProduksiDetailModel
                    With ObjNonproduksiDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Informasi = Convert.ToString(GridView1.GetRowCellValue(i, "INFORMASI"))
                        .D_PIC = Convert.ToString(GridView1.GetRowCellValue(i, "PIC"))
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "GAMBAR"))

                    End With
                    Fc_Class.ObjDetailNonProduksi.Add(ObjNonproduksiDetail)

                Next

                Fc_Class.InsertData(KodeTrans)
                GridDtl.DataSource = Fc_Class.GetDataLoad()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                Fc_Class.H_Tanggal = Format(DtTanggal.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                Fc_Class.ObjDetailNonProduksi.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjNonproduksiDetail = New NonProduksiDetailModel
                    With ObjNonproduksiDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Informasi = Convert.ToString(GridView1.GetRowCellValue(i, "INFORMASI"))
                        .D_PIC = Convert.ToString(GridView1.GetRowCellValue(i, "PIC"))
                        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "GAMBAR"))

                    End With
                    Fc_Class.ObjDetailNonProduksi.Add(ObjNonproduksiDetail)

                Next

                Fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = Fc_Class.GetDataLoad()
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
                With Fc_Class


                    .H_Tanggal = Format(CDate(Format(DtTanggal.Value, "yyyy-MM-dd")))

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

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try

            opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;*.Jpeg"

            If opfImage.ShowDialog = DialogResult.OK Then


                PictureBox1.Image = Image.FromFile(opfImage.FileName)
                PathFoto = opfImage.FileName
                'NamaFile = Path.GetFileName(PathFoto)
                Dim extension As String = Path.GetExtension(PathFoto)
                NamaFile = "NP_" + Path.GetRandomFileName() + extension
                fileSavePath = Path.Combine(SimpanFoto, NamaFile)
                File.Copy(opfImage.FileName, fileSavePath, True)

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GAMBAR, "")
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GAMBAR, NamaFile)

            End If
        Catch ex As Exception

        End Try
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

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BGambar_Click(sender As Object, e As EventArgs) Handles BGambar.Click

        opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif;*.Jpeg)|*.jpg;*.png;*.gif;*.Jpeg"

        If opfImage.ShowDialog = DialogResult.OK Then


            'PictureBox1.Image = Image.FromFile(opfImage.FileName)
            'PathFoto = opfImage.FileName
            'NamaFile = Path.GetFileName(PathFoto)


            PictureBox1.Image = Image.FromFile(opfImage.FileName)
            PathFoto = opfImage.FileName
            'NamaFile = Path.GetFileName(PathFoto)
            Dim extension As String = Path.GetExtension(PathFoto)
            NamaFile = "NP_" + Path.GetRandomFileName() + extension
            fileSavePath = Path.Combine(SimpanFoto, NamaFile)
            File.Copy(opfImage.FileName, fileSavePath, True)
        End If


    End Sub
End Class
