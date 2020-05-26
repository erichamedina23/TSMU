Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports ExcelDataReader
Imports GemBox.Spreadsheet
Imports System.Data.OleDb
Imports System.Security.Principal

Public Class FrmIPMIDetail

    Private dt As DataTable
    Private dt1 As DataTable

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjIPMIDetailModel As New IPMIDetailModel
    Dim KodeTrans As String = ""
    Dim fc_Class As New IPMIModel
    Dim GridDtl As GridControl

    ''''''''''''Variable Foto
    'Dim CekDirectorFoto As String = "D:\@KERJA\Project\Foto"
    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"

    'Server
    'Dim CekDirectorFoto As String = "D:\@KERJA\Project\Foto"
    'Dim SimpanFoto As String = "\\srv12\E$\Aplikasi IIS\Asakai\Foto\" 'E:\Aplikasi IIS\Asakai\Foto
    'Dim SimpanFoto As String = Directory.GetCurrentDirectory & "\srv12\Asakai\Foto\"
    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"
    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim DirectoryFoto As String = ""
    Dim extension As String = ""
    Dim fileSavePath As String = ""
    Dim opfImage As New OpenFileDialog



    Private Sub FrmIPMIDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        dt = New DataTable
        dt.Columns.Add("4M") '1
        dt.Columns.Add("Perbaikan") '2
        dt.Columns.Add("Target") '3
        dt.Columns.Add("Pic") '3
        Grid.DataSource = dt

        dt1 = New DataTable
        dt1.Columns.Add("4M") '0
        dt1.Columns.Add("Problem") '0
        GridPenyebab.DataSource = dt1

        Dim M As String() = {"Man", "Method", "Machine", "Material"}

        For Each N As String In M

            If True Then
                CmbRep4MAnalisa.Items.Add(N)
                CmbRepPerbaikan.Items.Add(N)
            End If

        Next



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

    Private Sub Tambah_Click(sender As Object, e As EventArgs) Handles Tambah.Click
        If TxtPerbaikan.Text = "" Or TxtPIC.Text = "" Or Cmb4MPerbaikan.Text = "" Then
            MessageBox.Show("Lengkapi Data Rencana Perbaikan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            GridView1.AddNewRow()
            'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Analisa, TxtAnalisa.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridColumn3, Cmb4MPerbaikan.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridColumn4, TxtPerbaikan.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridColumn5, Format(DtTarget.Value, "dd-MM-yyyy"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridColumn6, TxtPIC.Text)
            GridView1.UpdateCurrentRow()
            TxtPerbaikan.Text = ""
            TxtPIC.Text = ""
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
                Me.Text = "IPMI" & fs_Code
            Else
                Me.Text = "IPMI"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmIPMI"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DtTanggalLaporan.Value = .H_Tanggal
                    TxtNoIpmi.Text = .H_NOIPMI
                    TxtNoIpmi.Enabled = False
                    TxtPartNo.Text = .H_Part_No
                    TxtPartName.Text = .H_Part_Name
                    TxtQty.Text = .H_Qty
                    TxtProblem.Text = .H_Problem
                    TxtDibuat.Text = .H_Dibuat
                    TxtMengetahui.Text = .H_Mengetahui
                    PictureBox1.Image = Image.FromFile(SimpanFoto & .H_Foto)
                    PathFoto = (SimpanFoto & .H_Foto)
                    NamaFile = .H_Foto
                    'DirectoryFoto = CekDirectorFoto

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
                Dim dtGridPerbaikan As New DataTable
                dtGridPerbaikan = fc_Class.GetDataDetailPerbaikan(fs_Code)
                Grid.DataSource = dtGridPerbaikan

                Dim dtGridPenyebab As New DataTable
                dtGridPenyebab = fc_Class.GetDataDetailPenyebab(fs_Code)
                GridPenyebab.DataSource = dtGridPenyebab

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

            If GridView1.RowCount = 0 Or GridView2.RowCount = 0 Then

                MessageBox.Show("Belum Melakukan Inputan", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub

            End If

            If isUpdate = False Then

                With fc_Class

                    .H_NOIPMI = TxtNoIpmi.Text
                    .H_Part_No = TxtPartNo.Text
                    .H_Part_Name = TxtPartName.Text
                    .H_Qty = TxtQty.Text
                    .H_Problem = TxtProblem.Text
                    .H_Dibuat = TxtDibuat.Text
                    .H_Mengetahui = TxtMengetahui.Text
                    .H_Tanggal = DtTanggalLaporan.Value
                    .H_Foto = NamaFile

                End With
                'Insert To ObjDetailMaterial

                fc_Class.ObjDetailIPMIPerbaikanColection.Clear()
                For j As Integer = 0 To GridView1.RowCount - 1
                    ObjIPMIDetailModel = New IPMIDetailModel
                    With ObjIPMIDetailModel
                        .Rencana_Perbaikan = Convert.ToString(GridView1.GetRowCellValue(j, "Perbaikan"))
                        .Target = Convert.ToString(GridView1.GetRowCellValue(j, "Target"))
                        .EmpatMPerbaikan = Convert.ToString(GridView1.GetRowCellValue(j, "4M"))
                        .PIC = Convert.ToString(GridView1.GetRowCellValue(j, "Pic"))
                    End With
                    fc_Class.ObjDetailIPMIPerbaikanColection.Add(ObjIPMIDetailModel)

                Next

                fc_Class.ObjDetailIPMIPenyebabColection.Clear()
                For i As Integer = 0 To GridView2.RowCount - 1

                    ObjIPMIDetailModel = New IPMIDetailModel
                    With ObjIPMIDetailModel
                        .Penyebab = Convert.ToString(GridView2.GetRowCellValue(i, "Problem"))
                        .EmpatMPenyebab = Convert.ToString(GridView2.GetRowCellValue(i, "4M"))
                    End With
                    fc_Class.ObjDetailIPMIPenyebabColection.Add(ObjIPMIDetailModel)

                Next

                fc_Class.InsertIPMI(TxtNoIpmi.Text)
                File.Copy(opfImage.FileName, fileSavePath, True)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else

                With fc_Class

                    .H_NOIPMI = TxtNoIpmi.Text
                    .H_Part_No = TxtPartNo.Text
                    .H_Part_Name = TxtPartName.Text
                    .H_Qty = TxtQty.Text
                    .H_Problem = TxtProblem.Text
                    .H_Dibuat = TxtDibuat.Text
                    .H_Mengetahui = TxtMengetahui.Text
                    .H_Tanggal = DtTanggalLaporan.Value
                    .H_Foto = NamaFile

                End With
                'Insert To ObjDetailMaterial

                fc_Class.ObjDetailIPMIPerbaikanColection.Clear()
                For j As Integer = 0 To GridView1.RowCount - 1
                    ObjIPMIDetailModel = New IPMIDetailModel
                    With ObjIPMIDetailModel
                        .Rencana_Perbaikan = Convert.ToString(GridView1.GetRowCellValue(j, "Perbaikan"))
                        .Target = Convert.ToString(GridView1.GetRowCellValue(j, "Target"))
                        .EmpatMPerbaikan = Convert.ToString(GridView1.GetRowCellValue(j, "4M"))
                        .PIC = Convert.ToString(GridView1.GetRowCellValue(j, "Pic"))
                    End With
                    fc_Class.ObjDetailIPMIPerbaikanColection.Add(ObjIPMIDetailModel)

                Next

                fc_Class.ObjDetailIPMIPenyebabColection.Clear()
                For i As Integer = 0 To GridView2.RowCount - 1

                    ObjIPMIDetailModel = New IPMIDetailModel
                    With ObjIPMIDetailModel
                        .Penyebab = Convert.ToString(GridView2.GetRowCellValue(i, "Problem"))
                        .EmpatMPenyebab = Convert.ToString(GridView2.GetRowCellValue(i, "4M"))
                    End With
                    fc_Class.ObjDetailIPMIPenyebabColection.Add(ObjIPMIDetailModel)

                Next

                fc_Class.UpdateData(fs_Code)
                If fileSavePath <> "" Then
                    File.Copy(opfImage.FileName, fileSavePath, True)
                End If
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

            ElseIf TxtNoIpmi.Text = "" Then
                MessageBox.Show("No IPMI Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf TxtPartNo.Text = "" Or TxtPartName.Text = "" Then
                MessageBox.Show("Part No / Name Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf TxtQty.Text = "" Then
                MessageBox.Show("Qty Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf TxtDibuat.Text = "" Then
                MessageBox.Show("Pembuat Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf TxtMengetahui.Text = "" Then
                MessageBox.Show("Mengetahui Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf TxtProblem.Text = "" Then
                MessageBox.Show("Problem Harus diisi",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf PathFoto = "" Then
                MessageBox.Show("Pilih dulu Gambar",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
                'ElseIf DirectoryFoto <> CekDirectorFoto Then
                '    MessageBox.Show("Gambar Salah Ambil",
                '                    "Warning",
                '                    MessageBoxButtons.OK,
                '                    MessageBoxIcon.Exclamation,
                '                    MessageBoxDefaultButton.Button1)
            Else

                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class

                    .H_NOIPMI = TxtNoIpmi.Text
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

    Private Sub AddPenyebab_Click(sender As Object, e As EventArgs) Handles AddPenyebab.Click

        If TxtAnalisa.Text = "" Or Cmb4MAnalisa.Text = "" Then
            MessageBox.Show("Mohon diisi Analisa 4M",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            GridView2.AddNewRow()
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, GridColumn1, Cmb4MAnalisa.Text)
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, GridColumn2, TxtAnalisa.Text)
            GridView2.UpdateCurrentRow()
            TxtAnalisa.Text = ""

        End If

    End Sub

    Private Sub TxtQty_TextChanged(sender As Object, e As EventArgs) Handles TxtQty.TextChanged

    End Sub

    Private Sub TxtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtQty.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridPenyebab_KeyDown(sender As Object, e As KeyEventArgs) Handles GridPenyebab.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView2.AddNewRow()
        End If
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim opfImage As New OpenFileDialog
        'Dim fileName = Path.GetFileName(File.FileName); //only filename

        'opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif;*.Jpeg)|*.jpg;*.png;*.gif;*.Jpeg"

        If opfImage.ShowDialog = DialogResult.OK Then

            PictureBox1.Image = Image.FromFile(opfImage.FileName)
            PathFoto = opfImage.FileName
            'NamaFile = Path.GetFileName(PathFoto)
            Dim extension As String = Path.GetExtension(PathFoto)
            NamaFile = "IPMI_" + Path.GetRandomFileName() + extension
            fileSavePath = Path.Combine(SimpanFoto, NamaFile)

        End If
    End Sub
End Class
