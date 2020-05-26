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



Public Class FrmProblemDeliveryDetail

    Private dt As DataTable

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ProblemDeliveryModel
    Dim ObjProblemDeliveryDetail As New ProblemDeliveryDetailModel
    Dim KodeTrans As String = ""

    Dim GridDtl As GridControl


    'variable foto

    Dim PathFoto As String = ""
    Dim NamaFile As String = ""

    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"
    'Dim SimpanFoto As String = "\\srv12\E$\Aplikasi IIS\Asakai\Foto\"
    'Dim SimpanFoto As String = "\\srv12\E\Aplikasi IIS\Asakai\Foto\"
    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
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
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub


    Private Sub FrmProblemDeliveryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = New DataTable
        dt.Columns.Add("Customer") '0
        dt.Columns.Add("Tanggal Kejadian") '1
        dt.Columns.Add("Tanggal Kiriman") '2
        dt.Columns.Add("Standar") '3
        dt.Columns.Add("Aktual") '4
        dt.Columns.Add("Qty") '5
        dt.Columns.Add("Jenis Problem") '6
        dt.Columns.Add("Pic") '7
        dt.Columns.Add("Status") '8
        dt.Columns.Add("Inventory ID") '9
        dt.Columns.Add("Inventory Name") '10
        dt.Columns.Add("Gambar") '10
        dt.Columns.Add("Target Close") '10
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
                Me.Text = "Problem Delivery " & fs_Code
            Else
                Me.Text = "Problem Delivery"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmProblemDelivery"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DtTanggalLapoan.Value = fc_Class.H_Tanggal
                    Call TextKosong()

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
        Call LoadTxtBox()
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


                    .H_Tanggal = Format(CDate(Format(DtTanggalLapoan.Value, "yyyy-MM-dd")))

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
                fc_Class.H_Tanggal = Format(DtTanggalLapoan.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailProblemDelivery.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjProblemDeliveryDetail = New ProblemDeliveryDetailModel
                    With ObjProblemDeliveryDetail
                        '.D_IDTrans = KodeTrans
                        '.D_Tanggal = Format(DtTanggalLapoan.Value, "yyyy-MM-dd")
                        '.D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        '.D_InvtID = Convert.ToString(GridView1.GetRowCellValue(i, "Inventory ID"))
                        '.D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "Inventory Name"))
                        '.D_Tanggal_Kejadian = GridView1.GetRowCellValue(i, "Tanggal Kejadian")
                        '.D_Tanggal_Kiriman = GridView1.GetRowCellValue(i, "Tanggal Kiriman")
                        '.D_Standar = Convert.ToString(GridView1.GetRowCellValue(i, "Standar"))
                        '.D_Aktual = Convert.ToString(GridView1.GetRowCellValue(i, "Aktual"))
                        '.D_Qty = Convert.ToInt32(GridView1.GetRowCellValue(i, "Qty"))
                        '.D_JenisProblem = Convert.ToString(GridView1.GetRowCellValue(i, "Jenis Problem"))
                        '.D_PIC = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        '.D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        '.D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))
                        '.D_Target_Close = GridView1.GetRowCellValue(i, "Target Close")

                    End With
                    fc_Class.ObjDetailProblemDelivery.Add(ObjProblemDeliveryDetail)

                Next

                fc_Class.InsertProblemDelivery(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                fc_Class.H_Tanggal = Format(DtTanggalLapoan.Value, "yyyy-MM-dd")

                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailProblemDelivery.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjProblemDeliveryDetail = New ProblemDeliveryDetailModel
                    With ObjProblemDeliveryDetail
                        '.D_IDTrans = KodeTrans
                        '.D_Tanggal = Format(DtTanggalLapoan.Value, "yyyy-MM-dd")
                        '.D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        '.D_InvtID = Convert.ToString(GridView1.GetRowCellValue(i, "Inventory ID"))
                        '.D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "Inventory Name"))
                        '.D_Tanggal_Kejadian = GridView1.GetRowCellValue(i, "Tanggal Kejadian")
                        '.D_Tanggal_Kiriman = GridView1.GetRowCellValue(i, "Tanggal Kiriman")
                        '.D_Standar = Convert.ToString(GridView1.GetRowCellValue(i, "Standar"))
                        '.D_Aktual = Convert.ToString(GridView1.GetRowCellValue(i, "Aktual"))
                        '.D_Qty = Convert.ToInt32(GridView1.GetRowCellValue(i, "Qty"))
                        '.D_JenisProblem = Convert.ToString(GridView1.GetRowCellValue(i, "Jenis Problem"))
                        '.D_PIC = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        '.D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        '.D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))
                        '.D_Target_Close = GridView1.GetRowCellValue(i, "Target Close")
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




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
#Region "DR"
        'Dim dr As DataRow = dt.NewRow()

        'dr(0) = TxtCustomer.Text
        'dr(1) = Format(DtTanggalKejadian.Value, "dd-MM-yyyy")
        'dr(2) = Format(DtTanggalKiriman.Value, "dd-MM-yyyy")
        'dr(3) = TxtCustomer.Text.Text
        'dr(4) = TxtAktual.Text
        'dr(5) = TxtQty.Text
        'dr(6) = CmbJenisProblem.Text
        'dr(7) = txtKeterangan.Text
        'dr(8) = CmbStatus.Text
        'dr(9) = CmbInvtID.Text
        'dr(10) = TxtInvtName.Text
        'dt.Rows.Add(dr)
        'Grid.DataSource = dt
#End Region

        If TxtCustomer.Text = "" Then
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
        ElseIf TxtJenisProblem.Text = "" Then
            MessageBox.Show("Problem Harus di isi",
                          "Warning",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation,
                          MessageBoxDefaultButton.Button1)
        ElseIf TxtQty.Text = "" Then
            MessageBox.Show("Qty Harus di isi",
                          "Warning",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation,
                          MessageBoxDefaultButton.Button1)
        ElseIf CmbStatus.Text = "" Then
            MessageBox.Show("Status Harus di isi",
                         "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)
        ElseIf TxtPIC.Text = "" Then
            MessageBox.Show("PIC Harus di isi",
                         "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)
        ElseIf TxtAktual.Text = "" Then
            MessageBox.Show("Aktual Harus di isi",
                         "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)
        ElseIf TxtStandar.Text = "" Then
            MessageBox.Show("Standar Harus di isi",
                         "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)
            'ElseIf NamaFile = "" Then
            '    MessageBox.Show("Pilih Foto Harus di isi",
            '                 "Warning",
            '                 MessageBoxButtons.OK,
            '                 MessageBoxIcon.Exclamation,
            '                 MessageBoxDefaultButton.Button1)
        Else
            GridView1.AddNewRow()
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Customer, TxtCustomer.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TanggalKejadian, Format(DtTanggalKejadian.Value, "yyyy-MM-dd"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TanggalKiriman, Format(DtTanggalKiriman.Value, "yyyy-MM-dd"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtID, TxtInvtID.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtName, TxtInvtName.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Standar, TxtStandar.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Aktual, TxtAktual.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Qty, TxtQty.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, JenisProblem, TxtJenisProblem.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Status, CmbStatus.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Pic, TxtPIC.Text)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TargetClose, Format(DtTargetClose.Value, "yyyy-MM-dd"))
            GridView1.UpdateCurrentRow()
            Call TextKosong()
        End If




    End Sub



    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) 
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

    Private Sub BtnPicture_Click(sender As Object, e As EventArgs) Handles BtnPicture.Click

        'Dim opfImage As New OpenFileDialog
        ' Dim fileName = Path.GetFileName(File.FileName); //only filename

        opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;*.Jpeg"

        If opfImage.ShowDialog = DialogResult.OK Then


            PictureBox1.Image = Image.FromFile(opfImage.FileName)
            PathFoto = opfImage.FileName
            'NamaFile = Path.GetFileName(PathFoto)
            Dim extension As String = Path.GetExtension(PathFoto)
            NamaFile = "DEL" + Path.GetRandomFileName() + extension
            fileSavePath = Path.Combine(SimpanFoto, NamaFile)
            File.Copy(opfImage.FileName, fileSavePath, True)


        End If

    End Sub

    Private Sub TextKosong()

        TxtCustomer.Text = ""
        TxtInvtID.Text = ""
        TxtInvtName.Text = ""
        TxtJenisProblem.Text = ""
        TxtQty.Text = "0"
        CmbStatus.Text = ""
        TxtPIC.Text = ""
        TxtAktual.Text = ""
        TxtStandar.Text = ""

    End Sub



    Private Sub CmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbStatus.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCustomer_TextChanged(sender As Object, e As EventArgs) Handles TxtCustomer.TextChanged
        Dim selStart As Integer = TxtCustomer.SelectionStart
        TxtCustomer.Text = TxtCustomer.Text.ToUpper()
        TxtCustomer.SelectionStart = selStart
    End Sub

    Private Sub TxtInvtID_TextChanged(sender As Object, e As EventArgs) Handles TxtInvtID.TextChanged
        Dim selStart As Integer = TxtInvtID.SelectionStart
        TxtInvtID.Text = TxtInvtID.Text.ToUpper()
        TxtInvtID.SelectionStart = selStart
    End Sub

    Private Sub TxtInvtName_TextChanged(sender As Object, e As EventArgs) Handles TxtInvtName.TextChanged
        Dim selStart As Integer = TxtInvtName.SelectionStart
        TxtInvtName.Text = TxtInvtName.Text.ToUpper()
        TxtInvtName.SelectionStart = selStart
    End Sub

    Private Sub TxtJenisProblem_TextChanged(sender As Object, e As EventArgs) Handles TxtJenisProblem.TextChanged
        Dim selStart As Integer = TxtJenisProblem.SelectionStart
        TxtJenisProblem.Text = TxtJenisProblem.Text.ToUpper()
        TxtJenisProblem.SelectionStart = selStart
    End Sub

    Private Sub TxtPIC_TextChanged(sender As Object, e As EventArgs) Handles TxtPIC.TextChanged
        Dim selStart As Integer = TxtPIC.SelectionStart
        TxtPIC.Text = TxtPIC.Text.ToUpper()
        TxtPIC.SelectionStart = selStart
    End Sub

    Private Sub TxtAktual_TextChanged(sender As Object, e As EventArgs) Handles TxtAktual.TextChanged
        Dim selStart As Integer = TxtAktual.SelectionStart
        TxtAktual.Text = TxtAktual.Text.ToUpper()
        TxtAktual.SelectionStart = selStart
    End Sub

    Private Sub TxtStandar_TextChanged(sender As Object, e As EventArgs) Handles TxtStandar.TextChanged
        Dim selStart As Integer = TxtStandar.SelectionStart
        TxtStandar.Text = TxtStandar.Text.ToUpper()
        TxtStandar.SelectionStart = selStart
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) 

        opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;*.Jpeg"

        If opfImage.ShowDialog = DialogResult.OK Then


            PictureBox1.Image = Image.FromFile(opfImage.FileName)
            PathFoto = opfImage.FileName
            'NamaFile = Path.GetFileName(PathFoto)
            Dim extension As String = Path.GetExtension(PathFoto)
            NamaFile = "DEL" + Path.GetRandomFileName() + extension
            fileSavePath = Path.Combine(SimpanFoto, NamaFile)
            File.Copy(opfImage.FileName, fileSavePath, True)

            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, "")
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)

        End If






    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) 

    End Sub
End Class
