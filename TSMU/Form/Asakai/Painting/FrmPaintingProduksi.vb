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

Public Class FrmPaintingProduksi

    Dim isUpdate As Boolean = False
    Dim FileLokasi As String = ""
    Dim sheet As String
    Dim CellValue As String
    Dim GridData As DataTable = Nothing
    Dim KolomTanggal As String = ""
    Dim KolomTanggalScrap As String = ""
    Dim KolomTanggalScrapDetail As String = ""

    Dim dt As DataTable
    Dim dtScrap As DataTable
    Dim dtDetailScrap As DataTable
    Dim dtProblemQty As DataTable
    Dim dtProblemAnalisa As DataTable

    Dim dtGrid As DataTable

    Dim fc_Class As New PaintingProduksiModel
    Dim ObjPaintingProduksiDetailScrap As New PaintingProduksiDetailScrapModel


    Public Sub GetKolom()
        Dim Kolom As Integer
        Kolom = Convert.ToInt64(Format(dtTanggal.Value, "dd"))

        KolomTanggal = "F" & ((Kolom + 1)).ToString
        KolomTanggalScrap = "F" & ((Kolom + 2)).ToString
        KolomTanggalScrapDetail = "F" & ((Kolom + 2)).ToString
    End Sub


    Private Sub FrmPaintingProduksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Proc_EnableButtons(True, True, True, True, True, False, False, False)
        Call LoadGrid()

    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUploadExcel_Click(sender As Object, e As EventArgs) Handles BtnUploadExcel.Click

        Dim tanggal As Date = Format(dtTanggal.Value, "yyyy-MM-dd")
        dt = New DataTable
        ProgressBar1.Value = 0
        TxtFileName.Text = ""
        Timer1.Stop()
        GetKolom()
        Dim StraightPass As String = "STR_PASS$B5:AZ63"
        Dim Scrap As String = "Scrap$A4:AZ7"
        Dim ScrapDetail As String = "ScrapDetail$A8:AZ1000"
        Dim problemQty As String = "problem$A5:Z1000"
        Dim problemAnalisa As String = "problem$A5:Z1000"




        'Dim tanggalTransaksi As Date = Format(dtTanggal.Value, "yyyy-MM-dd")
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}

            If ofd.ShowDialog() = DialogResult.OK Then
                FileLokasi = ofd.FileName
                TxtFileName.Text = FileLokasi

                If IO.File.Exists(FileLokasi) Then

                    Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                    cn.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggal & " as Nilai FROM [" & StraightPass & "]", cn) '
                    'Dim dtLimaBesar As New DataTable
                    dt = New DataTable
                    dt.Load(cmd.ExecuteReader)


                    Dim cbSCRAP As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbSCRAP.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnSCRAP As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbSCRAP.ConnectionString}
                    cnSCRAP.Open()
                    Dim cmdScrap As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggalScrap & " as Nilai FROM [" & Scrap & "]", cnSCRAP) '
                    'Dim dtLimaBesar As New DataTable
                    dtScrap = New DataTable
                    dtScrap.Load(cmdScrap.ExecuteReader)


                    Dim cbScrapDetail As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbScrapDetail.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnSCRAPDetail As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbScrapDetail.ConnectionString}
                    cnSCRAPDetail.Open()
                    Dim cmdScrapDetail As OleDbCommand = New OleDbCommand("SELECT F1 as InvtID,F2 as InvtName," & KolomTanggalScrapDetail & " as Nilai FROM [" & ScrapDetail & "] Where F1 <>'' and " & KolomTanggalScrapDetail & " <> Null", cnSCRAPDetail) '
                    'Dim dtLimaBesar As New DataTable
                    dtDetailScrap = New DataTable
                    dtDetailScrap.Load(cmdScrapDetail.ExecuteReader)


                    Dim cbProblemQty As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbProblemQty.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnProblemQty As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbProblemQty.ConnectionString}
                    cnProblemQty.Open()
                    'Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3 FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <>''", cnProblemQty) '
                    Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT * FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <> Null ", cnProblemQty)
                    'Dim dtLimaBesar As New DataTable
                    dtProblemQty = New DataTable
                    dtProblemQty.Load(cmdProblemQty.ExecuteReader)


                    Dim cbProblemAnalisa As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbProblemAnalisa.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnProblemAnalisa As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbProblemQty.ConnectionString}
                    cnProblemAnalisa.Open()
                    'Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3 FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <>''", cnProblemQty) '
                    Dim cmdProblemAnalisa As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3,F4,F20,F21,F22,F23,F24,F25 FROM [" & problemAnalisa & "] where F1 = #" & tanggal & "# ", cnProblemAnalisa)
                    'Dim dtLimaBesar As New DataTable
                    dtProblemAnalisa = New DataTable
                    dtProblemAnalisa.Load(cmdProblemAnalisa.ExecuteReader)


                    Call SetDataStraightPass()
                    Call SetDataScrap()
                    Call SetDataScrapDetail()

                    Call SetDataProblemQty()
                    Call SetDataProblemAnalisa()


                    cn.Close()
                    cnSCRAP.Close()
                    cnSCRAPDetail.Close()
                    cnProblemQty.Close()
                    cnProblemAnalisa.Close()


                    Timer1.Start()
                End If

            End If
        End Using

    End Sub

    Public Sub SetDataStraightPass()

        'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

        With fc_Class

            .IdTransaksi = fc_Class.IdTransaksi

            If dt.Rows(0).Item(1) Is DBNull.Value Then
                .A_PLAN = "0"
            Else
                .A_PLAN = Math.Round(Val(dt.Rows(0).Item(1)), 2)
            End If

            If dt.Rows(1).Item(1) Is DBNull.Value Then
                .B_ACTUAL = "0"
            Else
                .B_ACTUAL = Math.Round(Val(dt.Rows(1).Item(1)), 2)
            End If

            If dt.Rows(2).Item(1) Is DBNull.Value Then
                .C_Persen_ACTUAL = "0"
            Else
                .C_Persen_ACTUAL = Math.Round(Val((dt.Rows(2).Item(1)) * 100), 2)
            End If

            If dt.Rows(3).Item(1) Is DBNull.Value Then
                .D_TOTAL_PROD_ACTUAL = "0"
            Else
                .D_TOTAL_PROD_ACTUAL = Math.Round(Val(dt.Rows(3).Item(1)), 2)
            End If

            If dt.Rows(4).Item(1) Is DBNull.Value Then
                .E_OK_LINE = "0"
            Else
                .E_OK_LINE = Math.Round(Val(dt.Rows(4).Item(1)), 2)
            End If

            If dt.Rows(5).Item(1) Is DBNull.Value Then
                .F_NG = "0"
            Else
                .F_NG = Math.Round(Val(dt.Rows(5).Item(1)), 2)
            End If

            If dt.Rows(6).Item(1) Is DBNull.Value Then
                .G_TARGET_STRAIGHT_PASS = "0"
            Else
                .G_TARGET_STRAIGHT_PASS = Math.Round(Val((dt.Rows(6).Item(1)) * 100), 2)
            End If

            If dt.Rows(7).Item(1) Is DBNull.Value Then
                .H_STRAIGT_PASS = "0"
            Else
                .H_STRAIGT_PASS = Math.Round(Val((dt.Rows(7).Item(1)) * 100), 2)
            End If

            If dt.Rows(8).Item(1) Is DBNull.Value Then
                .J_OK_PART_LINE_OK_POLESH = "0"
            Else
                .J_OK_PART_LINE_OK_POLESH = Math.Round(Val((dt.Rows(8).Item(1))), 2)
            End If

            If dt.Rows(9).Item(1) Is DBNull.Value Then
                .K_OK_PART_Persen = "0"
            Else
                .K_OK_PART_Persen = Math.Round(Val((dt.Rows(9).Item(1)) * 100), 2)
            End If



        End With





    End Sub

    Public Sub SetDataScrap()

        'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

        With fc_Class


            If dtScrap.Rows(0).Item(1) Is DBNull.Value Then
                .Scrap_QTY_PROD = "0"
            Else
                .Scrap_QTY_PROD = Math.Round(Val(dtScrap.Rows(0).Item(1)), 2)
            End If

            If dtScrap.Rows(1).Item(1) Is DBNull.Value Then
                .Scrap_QTY_CRUSHING = "0"
            Else
                .Scrap_QTY_CRUSHING = Math.Round(Val(dtScrap.Rows(1).Item(1)), 2)
            End If

            If dtScrap.Rows(2).Item(1) Is DBNull.Value OrElse dtScrap.Rows(2).Item(1).ToString = "#DIV/0!" Then
                .Scrap_Persen_CRUSHING = "0"
            Else
                .Scrap_Persen_CRUSHING = Math.Round(Val((dtScrap.Rows(2).Item(1)) * 100), 2)
            End If

            If dtScrap.Rows(3).Item(1) Is DBNull.Value Then
                .Scrap_TARGET = "0"
            Else
                .Scrap_TARGET = Math.Round(Val((dtScrap.Rows(3).Item(1)) * 100), 2)
            End If
        End With





    End Sub

    Public Sub SetDataScrapDetail()

#Region "Lima Scrap Detail"

        fc_Class.ObjDetailScrap.Clear()

        For i As Integer = 0 To dtDetailScrap.Rows.Count - 1

            ObjPaintingProduksiDetailScrap = New PaintingProduksiDetailScrapModel
            With ObjPaintingProduksiDetailScrap


                If dtDetailScrap.Rows(i).Item(0) Is DBNull.Value Then
                    .InvtID = ""
                Else
                    .InvtID = dtDetailScrap.Rows(i).Item(0)
                End If

                If dtDetailScrap.Rows(i).Item(1) Is DBNull.Value Then
                    .InvtName = ""
                Else
                    .InvtName = dtDetailScrap.Rows(i).Item(1)
                End If

                If dtDetailScrap.Rows(i).Item(2) Is DBNull.Value Then
                    .Qty = "0"
                Else
                    .Qty = dtDetailScrap.Rows(i).Item(2)
                End If

            End With
            fc_Class.ObjDetailScrap.Add(ObjPaintingProduksiDetailScrap)

        Next


#End Region

    End Sub

    Public Sub SetDataProblemQty()

        'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

#Region "ProblemQty"

        fc_Class.ObjDetailProblemQty.Clear()

        For i As Integer = 0 To dtProblemQty.Rows.Count - 1

            ObjPaintingProduksiDetailScrap = New PaintingProduksiDetailScrapModel
            With ObjPaintingProduksiDetailScrap


                If dtProblemQty.Rows(i).Item(1) Is DBNull.Value Then
                    .PQ_SHIFT = "1"
                Else
                    .PQ_SHIFT = dtProblemQty.Rows(i).Item(1)
                End If

                If dtProblemQty.Rows(i).Item(2) Is DBNull.Value Then
                    .PQ_InvtID = ""
                Else
                    .PQ_InvtID = dtProblemQty.Rows(i).Item(2)
                End If

                If dtProblemQty.Rows(i).Item(3) Is DBNull.Value Then
                    .PQ_InvtName = ""
                Else
                    .PQ_InvtName = dtProblemQty.Rows(i).Item(3)
                End If

                If dtProblemQty.Rows(i).Item(4) Is DBNull.Value Then
                    .PQ_Warna = ""
                Else
                    .PQ_Warna = dtProblemQty.Rows(i).Item(4)
                End If

                If dtProblemQty.Rows(i).Item(5) Is DBNull.Value Then
                    .PQ_OK = "0"
                Else
                    .PQ_OK = dtProblemQty.Rows(i).Item(5)
                End If

                If dtProblemQty.Rows(i).Item(6) Is DBNull.Value Then
                    .PQ_NG = "0"
                Else
                    .PQ_NG = dtProblemQty.Rows(i).Item(6)
                End If

                If dtProblemQty.Rows(i).Item(7) Is DBNull.Value Then
                    .PQ_TOTAL_PROD = "0"
                Else
                    .PQ_TOTAL_PROD = dtProblemQty.Rows(i).Item(7)
                End If

                If dtProblemQty.Rows(i).Item(8) Is DBNull.Value Then
                    .PQ_STRIGHPASS = "0"
                Else
                    .PQ_STRIGHPASS = Math.Round(Val(dtProblemQty.Rows(i).Item(8)), 2)
                End If

                If dtProblemQty.Rows(i).Item(9) Is DBNull.Value Then
                    .PQ_BINTIK_CAT = "0"
                Else
                    .PQ_BINTIK_CAT = dtProblemQty.Rows(i).Item(9)
                End If

                If dtProblemQty.Rows(i).Item(10) Is DBNull.Value Then
                    .PQ_BINTIK_HANGER = "0"
                Else
                    .PQ_BINTIK_HANGER = dtProblemQty.Rows(i).Item(10)
                End If

                If dtProblemQty.Rows(i).Item(11) Is DBNull.Value Then
                    .PQ_KOTORAN_LUAR = "0"
                Else
                    .PQ_KOTORAN_LUAR = dtProblemQty.Rows(i).Item(11)
                End If

                If dtProblemQty.Rows(i).Item(12) Is DBNull.Value Then
                    .PQ_KEBA = "0"
                Else
                    .PQ_KEBA = dtProblemQty.Rows(i).Item(12)
                End If

                If dtProblemQty.Rows(i).Item(13) Is DBNull.Value Then
                    .PQ_SCRATCH = "0"
                Else
                    .PQ_SCRATCH = dtProblemQty.Rows(i).Item(13)
                End If

                If dtProblemQty.Rows(i).Item(14) Is DBNull.Value Then
                    .PQ_HAJIKI = "0"
                Else
                    .PQ_HAJIKI = dtProblemQty.Rows(i).Item(14)
                End If

                If dtProblemQty.Rows(i).Item(15) Is DBNull.Value Then
                    .PQ_NG_INJECT = "0"
                Else
                    .PQ_NG_INJECT = dtProblemQty.Rows(i).Item(15)
                End If

                If dtProblemQty.Rows(i).Item(16) Is DBNull.Value Then
                    .PQ_LELEH = "0"
                Else
                    .PQ_LELEH = dtProblemQty.Rows(i).Item(16)
                End If

                If dtProblemQty.Rows(i).Item(17) Is DBNull.Value Then
                    .PQ_OP_KASAR_BELANG = "0"
                Else
                    .PQ_OP_KASAR_BELANG = dtProblemQty.Rows(i).Item(17)
                End If

                If dtProblemQty.Rows(i).Item(18) Is DBNull.Value Then
                    .PQ_LAIN2 = "0"
                Else
                    .PQ_LAIN2 = dtProblemQty.Rows(i).Item(18)
                End If



                'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

            End With
            fc_Class.ObjDetailProblemQty.Add(ObjPaintingProduksiDetailScrap)

        Next


#End Region





    End Sub

    Public Sub SetDataProblemAnalisa()

        'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

#Region "Problem  Analisa"

        fc_Class.ObjDetailProblemAnalisa.Clear()



        For i As Integer = 0 To dtProblemAnalisa.Rows.Count - 1

            ObjPaintingProduksiDetailScrap = New PaintingProduksiDetailScrapModel
            With ObjPaintingProduksiDetailScrap


                If dtProblemAnalisa.Rows(i).Item(2) Is DBNull.Value Then
                    .PA_InvtID = ""
                Else
                    .PA_InvtID = dtProblemAnalisa.Rows(i).Item(2)
                End If

                If dtProblemAnalisa.Rows(i).Item(3) Is DBNull.Value Then
                    .PA_InvtName = ""
                Else
                    .PA_InvtName = dtProblemAnalisa.Rows(i).Item(3)
                End If

                If dtProblemAnalisa.Rows(i).Item(4) Is DBNull.Value Then
                    .PA_ANALISA_PROBLEM_4M = ""
                Else
                    .PA_ANALISA_PROBLEM_4M = dtProblemAnalisa.Rows(i).Item(4)
                End If

                If dtProblemAnalisa.Rows(i).Item(5) Is DBNull.Value Then
                    .PA_Perbaikan_Sementara = ""
                Else
                    .PA_Perbaikan_Sementara = dtProblemAnalisa.Rows(i).Item(5)
                End If

                If dtProblemAnalisa.Rows(i).Item(6) Is DBNull.Value Then
                    .PA_Perbaikan_Permanent = ""
                Else
                    .PA_Perbaikan_Permanent = dtProblemAnalisa.Rows(i).Item(6)
                End If

                If dtProblemAnalisa.Rows(i).Item(7) Is DBNull.Value Then
                    .PA_PIC = ""
                Else
                    .PA_PIC = dtProblemAnalisa.Rows(i).Item(7)
                End If
                .PA_Target = dtProblemAnalisa.Rows(i).Item(8)

                If dtProblemAnalisa.Rows(i).Item(9) Is DBNull.Value Then
                    .PA_Status = ""
                Else
                    .PA_Status = dtProblemAnalisa.Rows(i).Item(9)
                End If

                'Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)

            End With
            fc_Class.ObjDetailProblemAnalisa.Add(ObjPaintingProduksiDetailScrap)

        Next


#End Region





    End Sub


    Public Overrides Sub Proc_SaveData()

        ' If isUpdate = False Then


        If TxtFileName.Text = "" Then
            MessageBox.Show("Belum Uploade File",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

        Else
            fc_Class.Tanggal = Format(dtTanggal.Value, "yyyy-MM-dd")

            fc_Class.GetIDTransAuto()

            With fc_Class
                .Tanggal = Format(dtTanggal.Value, "yyyy-MM-dd")
            End With


            fc_Class.InsertInjection()
            TxtFileName.Text = ""
            MessageBox.Show("File Saved")
            Call LoadGrid()
            TxtFileName.Text = ""
        End If


    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try

            lb_Validated = True
            If lb_Validated Then
                With fc_Class
                    .Tanggal = Format(CDate(dtTanggal.Value))

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

    Public Overrides Sub Proc_DeleteData()
        Dim IDTrans As String = ""

        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "IdTransaksi")
                    End If
                Next rowHandle

                fc_Class.Delete(IDTrans)
                Call LoadGrid()
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
        End If
    End Sub

End Class
