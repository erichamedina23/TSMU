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
Public Class FrmMaterialPainting

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New PemakaianPaintingModel

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim KodeTrans As String = ""

    Dim ObjPaintingDetail As New PemakaianPaintinglDetailModel
    Dim TanggalMulai As Date
    Dim TanggalSampai As Date
    Dim Keterangan As String = ""


    Dim FileLokasi As String

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
    Private Sub FrmMaterialPainting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)      'Kondisi Jika Edit Belum Di Set di Modelnya
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Penggunaan Painting " & fs_Code
            Else
                Me.Text = "Penggunaan Painting"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmMaterialPaintingHeader"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            TxtTotalRP.ReadOnly = True
            TxtAkumulasiPemakaianRp.ReadOnly = True
            TxtAktualRp.ReadOnly = True
            TxtSales.ReadOnly = True
            TxtPercentSales.ReadOnly = True
            TxtTotalLiter.ReadOnly = True
            TxtAkumulasiPemakaianLiter.ReadOnly = True
            TxtAktualLiter.ReadOnly = True
            TxtProduksiOKInj.ReadOnly = True
            TxtProduksiOKPaint.ReadOnly = True
            TxtProduksiOKAll.ReadOnly = True
            TxtPercentAll.ReadOnly = True
            TxtPercentTarget.ReadOnly = True
            txtPercentPainting.ReadOnly = True

            If fs_Code <> "" Then
                With fc_Class

                    TxtTotalRP.Text = Format(Double.Parse(.HeadTotalRP), "###,###,##0.00")
                    TxtAkumulasiPemakaianRp.Text = Format(Double.Parse(.HeadAkumulasiRpSebelumnya), "###,###,##0.00")
                    TxtAktualRp.Text = Format(Double.Parse(.HeadAktualRP), "###,###,##0.00")
                    TxtSales.Text = Format(Double.Parse(.HeadSales), "###,###,##0.00")
                    TxtPercentSales.Text = Format(Double.Parse(.HeadPercentSales), "###,###,##0.00")
                    TxtTotalLiter.Text = Format(Double.Parse(.HeadTotalLiter), "###,###,##0.00")
                    TxtAkumulasiPemakaianLiter.Text = Format(Double.Parse(.HeadAkumulasiLiterSebelumnya), "###,###,##0.00")
                    TxtAktualLiter.Text = Format(Double.Parse(.HeadAktualLiter), "###,###,##0.00")
                    TxtProduksiOKInj.Text = Format(Double.Parse(.HeadProduksiInjection), "###,###,##0.00")
                    TxtProduksiOKPaint.Text = Format(Double.Parse(.HeadProduksiPaint), "###,###,##0.00")
                    TxtProduksiOKAll.Text = Format(Double.Parse(.HeadTotalProduksi), "###,###,##0.00")
                    TxtPercentAll.Text = Format(Double.Parse(.HeadPercentAll), "###,###,##0.00")
                    TxtPercentTarget.Text = Format(Double.Parse(.HeadPercentTarget), "###,###,##0.00")
                    txtPercentPainting.Text = Format(Double.Parse(.HeadPercentPainting), "###,###,##0.00")
                End With
            Else
                TxtTotalRP.Text = "0"
                TxtAkumulasiPemakaianRp.Text = "0"
                TxtAktualRp.Text = "0"
                TxtSales.Text = "0"
                TxtPercentSales.Text = "0"
                TxtTotalLiter.Text = "0"
                TxtAkumulasiPemakaianLiter.Text = "0"
                TxtAktualLiter.Text = "0"
                TxtProduksiOKInj.Text = "0"
                TxtProduksiOKPaint.Text = "0"
                TxtProduksiOKAll.Text = "0"
                TxtPercentAll.Text = "0"
                TxtPercentTarget.Text = "0"
                txtPercentPainting.Text = "0"


            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridPainting As New DataTable
                dtGridPainting = fc_Class.GetDataDetailPainting(fs_Code)
                Grid.DataSource = dtGridPainting
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
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(TxtTotalRP.Text) Then
                ErrorProvider1.SetError(TxtTotalRP, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtAkumulasiPemakaianRp.Text) Then
                ErrorProvider1.SetError(TxtAkumulasiPemakaianRp, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtAktualRp.Text) Then
                ErrorProvider1.SetError(TxtAktualRp, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtSales.Text) Then
                ErrorProvider1.SetError(TxtSales, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtPercentSales.Text) Then
                ErrorProvider1.SetError(TxtPercentSales, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtTotalLiter.Text) Then
                ErrorProvider1.SetError(TxtTotalLiter, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtAkumulasiPemakaianLiter.Text) Then
                ErrorProvider1.SetError(TxtAkumulasiPemakaianLiter, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtAktualLiter.Text) Then
                ErrorProvider1.SetError(TxtAktualLiter, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtProduksiOKInj.Text) Then
                ErrorProvider1.SetError(TxtProduksiOKInj, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtProduksiOKPaint.Text) Then
                ErrorProvider1.SetError(TxtProduksiOKPaint, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtProduksiOKAll.Text) Then
                ErrorProvider1.SetError(TxtProduksiOKAll, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtPercentAll.Text) Then
                ErrorProvider1.SetError(TxtPercentAll, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtPercentTarget.Text) Then
                ErrorProvider1.SetError(TxtPercentTarget, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(txtPercentPainting.Text) Then
                ErrorProvider1.SetError(txtPercentPainting, "Value cannot be empty")
            ElseIf GridView1.RowCount = 0 Then
                ErrorProvider1.SetError(Grid, "Please Input Data In Grid")

            Else

                ErrorProvider1.Clear()
                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class


                    .HeadTanggalDari = Format(CDate(TanggalMulai))
                    .HeadTanggalSampai = Format(CDate(TanggalSampai))
                    '.HeadTanggalDari = "2019-10-30"
                    '.HeadTanggalSampai = "2019-10-30"
                    .HeadKeterangan = Keterangan
                    .HeadStokAwal = Convert.ToDouble(GridView1.Columns("StockAwal04").SummaryItem.SummaryValue)
                    .HeadTotalMasuk = Convert.ToDouble(GridView1.Columns("Masuk").SummaryItem.SummaryValue)
                    .HeadTotalStokAwalHeader = Convert.ToDouble(GridView1.Columns("TotalStokAwal").SummaryItem.SummaryValue)
                    .HeadTotalStokAkhirHeader = Convert.ToDouble(GridView1.Columns("TotalStokAkhir").SummaryItem.SummaryValue)
                    '.HeadTotalOut = Convert.ToDouble(GridView1.Columns("Pemakaian").SummaryItem.SummaryValue)
                    .HeadOutNonProduksi = Convert.ToDouble(GridView1.Columns("PemakaianNonProduksi").SummaryItem.SummaryValue)
                    .HeadTotalPemakaian = Convert.ToDouble(GridView1.Columns("Pemakaian").SummaryItem.SummaryValue)
                    .HeadAktualRP = TxtAktualRp.Text
                    .HeadTotalRP = TxtTotalRP.Text


                    .HeadAkumulasiRpSebelumnya = TxtAkumulasiPemakaianRp.Text
                    .HeadSales = TxtSales.Text
                    .HeadPercentSales = TxtPercentSales.Text
                    .HeadTotalLiter = TxtTotalLiter.Text
                    .HeadAkumulasiLiterSebelumnya = TxtAkumulasiPemakaianLiter.Text
                    .HeadAktualLiter = TxtAktualLiter.Text
                    .HeadProduksiInjection = TxtProduksiOKInj.Text
                    .HeadProduksiPaint = TxtProduksiOKPaint.Text
                    .HeadTotalProduksi = TxtProduksiOKAll.Text
                    .HeadPercentAll = TxtPercentAll.Text
                    .HeadPercentTarget = TxtPercentTarget.Text
                    .HeadPercentPainting = txtPercentPainting.Text

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

                If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(1)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(2)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(3)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(4)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(5)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(6)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(7)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(8)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(9)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(10)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(11)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(12)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(13)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(14)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(15)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(16)).ToString = "" Then
                    IsEmpty = True
                    'GridView2.DeleteRow(i)
                    MessageBox.Show("Pastikan Data tidak ada yang kosong")
                    Exit Sub
                End If
            Next


            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.IDTrans
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailPainting.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjPaintingDetail = New PemakaianPaintinglDetailModel
                    With ObjPaintingDetail
                        .IDTrans = KodeTrans
                        .invtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtID"))
                        .StokAwalTNG02 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG02"))
                        .StokAkhirTNG04 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG04"))
                        .Masuk = Convert.ToDouble(GridView1.GetRowCellValue(i, "Masuk"))
                        .StokAwalTNG04BelumKonversi = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG04BelumKonv"))
                        .TotalStokawal = Convert.ToDouble(GridView1.GetRowCellValue(i, "TotalStokAwal"))
                        .StokAkhirTNG02 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG02"))
                        .StokAkhirTNG04 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04"))
                        .StokAkhirTNG04Utuh = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04UTUH"))
                        .StokAkhirTNG04Pecah = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04Pecahan"))
                        .TotalStokAkhir = Convert.ToDouble(GridView1.GetRowCellValue(i, "TotalStokAkhir"))
                        .PemakaianNonProduksi = Convert.ToDouble(GridView1.GetRowCellValue(i, "PemakaianNonProduksi"))
                        .Pemakaian = Convert.ToDouble(GridView1.GetRowCellValue(i, "Pemakaian"))
                        .Harga = Convert.ToDouble(GridView1.GetRowCellValue(i, "Harga"))
                        .TotalRP = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                    End With
                    fc_Class.ObjDetailPainting.Add(ObjPaintingDetail)

                Next

                fc_Class.InsertPainting()
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fc_Class.IDTrans
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailPainting.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjPaintingDetail = New PemakaianPaintinglDetailModel
                    With ObjPaintingDetail
                        .IDTrans = KodeTrans
                        .invtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtID"))
                        .StokAwalTNG02 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG02"))
                        .StokAkhirTNG04 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG04"))
                        .Masuk = Convert.ToDouble(GridView1.GetRowCellValue(i, "Masuk"))
                        .StokAwalTNG04BelumKonversi = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAwalTNG04BelumKonv"))
                        .TotalStokawal = Convert.ToDouble(GridView1.GetRowCellValue(i, "TotalStokAwal"))
                        .StokAkhirTNG02 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG02"))
                        .StokAkhirTNG04 = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04"))
                        .StokAkhirTNG04Utuh = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04UTUH"))
                        .StokAkhirTNG04Pecah = Convert.ToDouble(GridView1.GetRowCellValue(i, "StockAkhirTNG04Pecahan"))
                        .TotalStokAkhir = Convert.ToDouble(GridView1.GetRowCellValue(i, "TotalStokAkhir"))
                        .PemakaianNonProduksi = Convert.ToDouble(GridView1.GetRowCellValue(i, "PemakaianNonProduksi"))
                        .Pemakaian = Convert.ToDouble(GridView1.GetRowCellValue(i, "Pemakaian"))
                        .Harga = Convert.ToDouble(GridView1.GetRowCellValue(i, "Harga"))
                        .TotalRP = Convert.ToDouble(GridView1.GetRowCellValue(i, "Amount"))
                    End With
                    fc_Class.ObjDetailPainting.Add(ObjPaintingDetail)

                Next


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



    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BBrowse.Click
        Try
            Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}


                If ofd.ShowDialog() = DialogResult.OK Then
                    FileLokasi = ofd.FileName

                    If IO.File.Exists(FileLokasi) Then
                        Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                        cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                        Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                        cn.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("SELECT F1 as InvtID
                                                                        ,F2 as Material
                                                                        ,F3 as StockAwal02
                                                                        ,F4 as StockAwal04
                                                                        ,F5 as StockAwal04Blm
                                                                        ,F6 as Masuk
                                                                        ,F7 as TotalStokAwal
                                                                        ,F8 as StockAkhir02
                                                                        ,F9 as StockAkhir04
                                                                        ,F10 as StockAkhir04UTUH
                                                                        ,F11 as StockAkhir04Pecahan
                                                                        ,F12 as TotalStokAhir4
                                                                        ,F13 as TotalStokAkhir
                                                                        ,F15 as PemakaianNonProduksi
                                                                        ,F16 as Pemakaian
                                                                        ,F17 as Harga
                                                                        ,F18 as Amount
                                                                         FROM [Pemakaian$A11:Z345] where F1 <> '' ", cn) '
                        Dim dt As New DataTable
                        dt.Load(cmd.ExecuteReader)


                        Dim cbHeader As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                        cbHeader.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                        Dim cnHeader As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbHeader.ConnectionString}
                        cnHeader.Open()
                        Dim cmdHeader As OleDbCommand = New OleDbCommand("SELECT F1 as A
                                                                         ,F2 as B
                                                                        ,F3 as C
                                                                        ,F4 as D
                                                                        ,F5 as E
                                                                         FROM [Pemakaian$A1:M9]", cnHeader)
                        Dim dtHeader As New DataTable
                        dtHeader.Load(cmdHeader.ExecuteReader)

                        cn.Close()
                        Grid.DataSource = dt

                        cnHeader.Close()




                        TxtProduksiOKInj.Text = Format$(((dtHeader.Rows(1).Item("D")) / 1000), "#,###.##")
                        TxtProduksiOKPaint.Text = Format$(((dtHeader.Rows(2).Item("D")) / 1000), "#,###.##")
                        TxtProduksiOKAll.Text = Format$(((dtHeader.Rows(3).Item("D")) / 1000), "#,###.##")
                        TxtSales.Text = Format$(((dtHeader.Rows(4).Item("B")) / 1000), "#,###.##")

                        Dim TotalRp As Double = Convert.ToDouble((GridView1.Columns("Amount").SummaryItem.SummaryValue) / 1000000)
                        Dim TotalLiter As Double = Convert.ToDouble(GridView1.Columns("Pemakaian").SummaryItem.SummaryValue)
                        TxtTotalRP.Text = Format(Double.Parse((TotalRp).ToString), "###,###,##0.00")
                        TxtTotalLiter.Text = Format(Double.Parse(TotalLiter.ToString), "###,###,##0.00")






                        TanggalMulai = dtHeader.Rows(1).Item("B")
                        TanggalSampai = dtHeader.Rows(2).Item("B")
                        Keterangan = dtHeader.Rows(7).Item("B").ToString

                        Dim tgl As Date = Format(CDate(TanggalMulai), gs_FormatSQLDate)

                        fc_Class.tahun = Convert.ToString(tgl.Year)
                        fc_Class.bulan = Convert.ToString(tgl.Month)
                        fc_Class.tanggal = Convert.ToString(tgl.Day)

                        fc_Class.GetSumaryPemakaian()
                        TxtAkumulasiPemakaianRp.Text = Format(Double.Parse(fc_Class.SummaryPemakaianRP), "###,###,##0.00")
                        TxtAkumulasiPemakaianLiter.Text = Format(Double.Parse(fc_Class.SummaryPemakaianLiter), "###,###,##0.00")
                        TxtAktualRp.Text = Format(Double.Parse(Val(TxtTotalRP.Text - TxtAkumulasiPemakaianRp.Text).ToString), "###,###,##0.00")
                        TxtAktualLiter.Text = Format(Double.Parse(Val(TxtTotalLiter.Text - TxtAkumulasiPemakaianLiter.Text).ToString), "###,###,##0.00")


                        TxtPercentSales.Text = Format(Double.Parse(Val(TxtAktualRp.Text / TxtSales.Text) * 100), "###,###,##0.00")
                        TxtPercentTarget.Text = Format$(dtHeader.Rows(5).Item("D"), "#,###.##")
                        TxtPercentAll.Text = Math.Round((Val(TxtAktualRp.Text / TxtProduksiOKAll.Text) * 100), 2)
                        txtPercentPainting.Text = Math.Round((Val(TxtAktualRp.Text / TxtProduksiOKPaint.Text) * 100), 2)
                        'Format(Double.Parse(txtCAmount.Text), "###,###,##0.00")

                    End If
                End If
            End Using
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

    End Sub
End Class
