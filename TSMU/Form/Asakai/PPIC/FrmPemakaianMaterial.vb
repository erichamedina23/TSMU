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

Public Class FrmPemakaianMaterial



    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New PemakaianMaterialModel
    Dim fc_Class_Material_Detail As New PemakaianMaterialDetail
    Dim fc_Class_Komponen_Detail As New PemakaianKomponenlDetail

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Total As Double

    Dim FileLokasi As String
    Dim sheet As String
    Dim CellValue As String
    Dim TotalPriceMaterial As Double

    Dim KolomQty As String
    Dim KolomHarga As String

    Dim BarisMaterial1 As String
    Dim BarisMAterial2 As String
    Dim BarisKompone1 As String
    Dim BarisKomponen2 As String
    Dim KodeTran As String = ""

    Private TabelExcel As DataTableCollection

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

    Private Sub FrmPemakaianMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridMaterial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        GridKomponen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

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
                Me.Text = "Penggunaan Material " & fs_Code
            Else
                Me.Text = "Penggunaan Material"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmMaterialUsage"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TxtAktualRpMaterial.Text = .MaterialAktualRP
                    TxtSalesMaterial.Text = .Sales
                    TxtPercentMaterial.Text = .MaterialPercent1 & "%"
                    TxtAktualProduksiMaterial.Text = .AktualProduksi
                    TxtInjectionMaterial.Text = .MaterialPercent2 & "%"
                    TargetMaterial.Text = .MaterialTarget & "%"

                    TxtAktualRpKomponen.Text = .KomponenAktualRP
                    TxtSalesKomponen.Text = .Sales
                    TxtPercentKomponen.Text = .KomponenPercent1 & "%"
                    TxtAktualProduksiKomponen.Text = .AktualProduksi
                    TxtInjectionKomponen.Text = .KomponenPercent2 & "%"
                    TargetKomponen.Text = .KomponenTarget & "%"

                    TxtKeterangan.Text = .Keterangan
                    TanggalMulai.Value = .TanggalDari
                    TanggalSampai.Value = .TanggalSampai
                    TxtKolomQty.Text = .KolomQty
                    TxtKolomHarga.Text = .KolomHarga
                    'IDTrans.Text = .IDTrans

                End With
            Else
                TxtAktualRpMaterial.Text = "0"
                TxtSalesMaterial.Text = "0"
                TxtPercentMaterial.Text = "0"
                TxtAktualProduksiMaterial.Text = "0"
                TxtInjectionMaterial.Text = "0"
                TargetMaterial.Text = "0"

                TxtAktualRpKomponen.Text = "0"
                TxtSalesKomponen.Text = "0"
                TxtPercentKomponen.Text = "0"
                TxtAktualProduksiKomponen.Text = "0"
                TxtInjectionKomponen.Text = "0"
                TargetKomponen.Text = "0"

                TxtKeterangan.Text = ""


            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridMaterial As New DataTable
                dtGridMaterial = fc_Class.GetDataDetailMaterial(fs_Code)
                GridMaterial.DataSource = dtGridMaterial

                Dim dtGridKomponen As New DataTable
                dtGridKomponen = fc_Class.GetDataDetailKomponen(fs_Code)
                GridKomponen.DataSource = dtGridKomponen


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
            If String.IsNullOrEmpty(TxtKeterangan.Text) Then
                ErrorProvider1.SetError(TxtKeterangan, "Value cannot be empty")
            ElseIf String.IsNullOrEmpty(TxtAktualRpMaterial.Text) Then
                ErrorProvider1.SetError(TxtAktualRpMaterial, "Value cannot be empty")
            ElseIf TanggalMulai.Value > TanggalSampai.Value Then
                MessageBox.Show("Setting Tanggal Mulai dan Sampai tidak Valid")
            Else
                ErrorProvider1.Clear()
                lb_Validated = True
            End If
            If lb_Validated Then
                With fc_Class
                    '.GetIDTransAuto() ********************
                    .TanggalDari = Format(CDate(TanggalMulai.Value))
                    .TanggalSampai = Format(CDate(TanggalSampai.Value))
                    .Keterangan = TxtKeterangan.Text
                    .KolomQty = TxtKolomQty.Text
                    .KolomHarga = TxtKolomHarga.Text


                    .Sales = TxtSalesMaterial.Text
                    .AktualProduksi = TxtAktualProduksiMaterial.Text

                    '--------------------Material
                    .MaterialAktualRP = TxtAktualRpMaterial.Text

                    Dim M1 As String = TxtPercentMaterial.Text
                    Dim mp1 As Integer = M1.IndexOf("")
                    Dim Materialpercent1 As String = M1.Substring(mp1 + 0, M1.IndexOf("%", mp1 + 1) - mp1)
                    .MaterialPercent1 = Convert.ToDouble(Materialpercent1)

                    Dim M2 As String = TxtInjectionMaterial.Text
                    Dim mp2 As Integer = M2.IndexOf("")
                    Dim Materialpercent2 As String = M2.Substring(mp2 + 0, M2.IndexOf("%", mp2 + 1) - mp2)
                    .MaterialPercent2 = Convert.ToDouble(Materialpercent2)

                    Dim MT As String = TargetMaterial.Text
                    Dim tgm As Integer = MT.IndexOf("")
                    Dim TargetMat As String = MT.Substring(tgm + 0, MT.IndexOf("%", tgm + 1) - tgm)
                    .MaterialTarget = Convert.ToDouble(TargetMat)


                    '--------------------Komponen
                    .KomponenAktualRP = TxtAktualRpKomponen.Text

                    Dim P1 As String = TxtPercentKomponen.Text
                    Dim a As Integer = P1.IndexOf("")
                    Dim Komponenpercent1 As String = P1.Substring(a + 0, P1.IndexOf("%", a + 1) - a)
                    .KomponenPercent1 = Convert.ToDouble(Komponenpercent1)

                    Dim P2 As String = TxtInjectionKomponen.Text
                    Dim b As Integer = P2.IndexOf("")
                    Dim Komponenpercent2 As String = P2.Substring(b + 0, P2.IndexOf("%", b + 1) - b)
                    .KomponenPercent2 = Convert.ToDouble(Komponenpercent2)



                    Dim KT As String = TargetKomponen.Text
                    Dim Z As Integer = KT.IndexOf("")
                    Dim KTarget As String = KT.Substring(Z + 0, KT.IndexOf("%", Z + 1) - Z)
                    .KomponenTarget = Convert.ToDouble(KTarget)

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



            For i As Integer = 0 To GridMaterial.RowCount - 1
                If GridMaterial.Rows(i).Cells(0).Value Is System.DBNull.Value OrElse
                   GridMaterial.Rows(i).Cells(2).Value Is System.DBNull.Value OrElse
                   GridMaterial.Rows(i).Cells(3).Value Is System.DBNull.Value Then
                    MessageBox.Show("Pastikan Data tidak ada yang salah")
                    Exit Sub

                End If
            Next


            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTran = fc_Class.IDTrans
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailsMaterial.Clear()
                For i As Integer = 0 To GridMaterial.RowCount - 1
                    If GridMaterial.Rows(i).Cells(0).ToString <> "" Then
                        fc_Class_Material_Detail = New PemakaianMaterialDetail
                        With fc_Class_Material_Detail
                            .IDTrans = KodeTran
                            .MaterialInvtId = Convert.ToString(GridMaterial.Rows(i).Cells(0).Value)
                            .MaterialJumlah = Convert.ToDouble(GridMaterial.Rows(i).Cells(2).Value)
                            .MaterialHarga = Convert.ToDouble(GridMaterial.Rows(i).Cells(3).Value)
                        End With
                        fc_Class.ObjDetailsMaterial.Add(fc_Class_Material_Detail)
                    End If
                Next

                'Insert To ObjDetailKomponen
                fc_Class.ObjDetailsKomponen.Clear()
                For j As Integer = 0 To GridKomponen.RowCount - 1
                    If GridKomponen.Rows(j).Cells(0).ToString <> "" Then
                        fc_Class_Komponen_Detail = New PemakaianKomponenlDetail
                        With fc_Class_Komponen_Detail
                            .IDTrans = KodeTran
                            .KomponenInvtId = Convert.ToString(GridKomponen.Rows(j).Cells(0).Value)
                            .KomponenJumlah = Convert.ToDouble(GridKomponen.Rows(j).Cells(2).Value)
                            .KomponenHarga = Convert.ToDouble(GridKomponen.Rows(j).Cells(3).Value)
                        End With
                        fc_Class.ObjDetailsKomponen.Add(fc_Class_Komponen_Detail)
                    End If
                Next



                fc_Class.InsertMaterialUsage()
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTran = fs_Code
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailsMaterial.Clear()
                For i As Integer = 0 To GridMaterial.RowCount - 1
                    If GridMaterial.Rows(i).Cells(0).ToString <> "" Then
                        fc_Class_Material_Detail = New PemakaianMaterialDetail
                        With fc_Class_Material_Detail
                            .IDTrans = KodeTran
                            .MaterialInvtId = Convert.ToString(GridMaterial.Rows(i).Cells(0).Value)
                            .MaterialJumlah = Convert.ToDouble(GridMaterial.Rows(i).Cells(2).Value)
                            .MaterialHarga = Convert.ToDouble(GridMaterial.Rows(i).Cells(3).Value)
                        End With
                        fc_Class.ObjDetailsMaterial.Add(fc_Class_Material_Detail)
                    End If
                Next

                'Insert To ObjDetailKomponen
                fc_Class.ObjDetailsKomponen.Clear()
                For j As Integer = 0 To GridKomponen.RowCount - 1
                    If GridKomponen.Rows(j).Cells(0).ToString <> "" Then
                        fc_Class_Komponen_Detail = New PemakaianKomponenlDetail
                        With fc_Class_Komponen_Detail
                            .IDTrans = KodeTran
                            .KomponenInvtId = Convert.ToString(GridKomponen.Rows(j).Cells(0).Value)
                            .KomponenJumlah = Convert.ToDouble(GridKomponen.Rows(j).Cells(2).Value)
                            .KomponenHarga = Convert.ToDouble(GridKomponen.Rows(j).Cells(3).Value)
                        End With
                        fc_Class.ObjDetailsKomponen.Add(fc_Class_Komponen_Detail)
                    End If
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If TxtKolomQty.Text = "" Or TxtKolomHarga.Text = "" Then
                MsgBox("Tentukan Kolom Quantity dan Harga yang akan di Tarik", MsgBoxStyle.Information, "Validation")
            ElseIf Val(TxtKolomQty.Text) > Val(TxtKolomHarga.Text) Then
                MsgBox("Kolom Quantiy tidak boleh lebih besar", MsgBoxStyle.Information, "Validation")
            ElseIf (Val(TxtKolomQty.Text) Mod 2 <> 1) Then
                MsgBox("Kolom Quantiy Harus Bilangan Ganjil", MsgBoxStyle.Information, "Validation")
            ElseIf (Val(TxtKolomHarga.Text) Mod 2 <> 0) Then
                MsgBox("Kolom Harga Harus Bilangan Genap", MsgBoxStyle.Information, "Validation")
            ElseIf (Val(TxtKolomHarga.Text) - Val(TxtKolomQty.Text)) <> 1 Then
                MsgBox("Penentuan Kolom Quantity dan Harga Tidak Valid", MsgBoxStyle.Information, "Validation")
            Else
                KolomQty = "F" & TxtKolomQty.Text
                KolomHarga = "F" & TxtKolomHarga.Text
                BarisMaterial1 = "Sheet2$" & TxtBarisMaterial1.Text
                BarisMAterial2 = TxtBarisMaterial2.Text
                BarisKompone1 = "Sheet2$" & TxtBarisKomponen1.Text
                BarisKomponen2 = TxtBarisKomponen2.Text

                Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}

                    If ofd.ShowDialog() = DialogResult.OK Then
                        FileLokasi = ofd.FileName
                        '_filelokasi.Text = FileLokasi
                        If IO.File.Exists(FileLokasi) Then
                            Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                            cn.Open()
                            Dim cmd As OleDbCommand = New OleDbCommand("SELECT F1 as IDMaterial, F2 as Description," & KolomQty & " as Quantity," & KolomHarga & " as TotalPrice FROM [" & BarisMaterial1 & ":" & BarisMAterial2 & "]", cn) '
                            Dim dt As New DataTable
                            dt.Load(cmd.ExecuteReader)

                            Dim cbKomponen As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            cbKomponen.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            Dim cnKomponen As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbKomponen.ConnectionString}
                            cnKomponen.Open()
                            Dim cmdKomponen As OleDbCommand = New OleDbCommand("SELECT F1 as IDMaterial, F2 as Description," & KolomQty & " as Quantity," & KolomHarga & " as TotalPrice FROM [" & BarisKompone1 & ":" & BarisKomponen2 & "]", cn) '
                            Dim dtKomponen As New DataTable
                            dtKomponen.Load(cmdKomponen.ExecuteReader)

                            Dim cbHeader As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                            cbHeader.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                            Dim cnHeader As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbHeader.ConnectionString}
                            cnHeader.Open()
                            Dim cmdHeader As OleDbCommand = New OleDbCommand("SELECT F1 as IDMaterial, F2 as Description," & KolomQty & " as Quantity," & KolomHarga & " as TotalPrice FROM [Sheet2$A1:CN600]", cn) '
                            Dim dtHeader As New DataTable
                            dtHeader.Load(cmdHeader.ExecuteReader)

                            cn.Close()
                            GridMaterial.DataSource = dt

                            cnKomponen.Close()
                            'GridControl1.DataSource = dtKomponen
                            GridKomponen.DataSource = dtKomponen

                            cnHeader.Close()
                            'GridControl3.DataSource = dtHeader
                            'DataGridView1.DataSource = dtHeader
                            TxtAktualRpMaterial.Text = Math.Round(Val(dtHeader.Rows(2).Item("TotalPrice") / 1000000), 2)
                            TxtSalesMaterial.Text = Math.Round(Val(dtHeader.Rows(3).Item("TotalPrice") / 1000000), 2)
                            TxtPercentMaterial.Text = dtHeader.Rows(4).Item("TotalPrice").ToString
                            TxtAktualProduksiMaterial.Text = Math.Round(Val(dtHeader.Rows(5).Item("TotalPrice") / 1000000), 2)
                            TxtInjectionMaterial.Text = dtHeader.Rows(6).Item("TotalPrice").ToString
                            TargetMaterial.Text = dtHeader.Rows(7).Item("TotalPrice").ToString

                            TxtAktualRpKomponen.Text = Math.Round(Val(dtHeader.Rows(8).Item("TotalPrice") / 1000000), 2)
                            TxtSalesKomponen.Text = Math.Round(Val(dtHeader.Rows(9).Item("TotalPrice") / 1000000), 2)
                            TxtPercentKomponen.Text = dtHeader.Rows(10).Item("TotalPrice").ToString
                            TxtAktualProduksiKomponen.Text = Math.Round(Val(dtHeader.Rows(11).Item("TotalPrice") / 1000000), 2)
                            TxtInjectionKomponen.Text = dtHeader.Rows(12).Item("TotalPrice").ToString
                            TargetKomponen.Text = dtHeader.Rows(13).Item("TotalPrice").ToString
                            TxtKeterangan.Text = dtHeader.Rows(1).Item("TotalPrice").ToString
                        End If
                    End If
                End Using
            End If


        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ChangeExcel()
        TxtAktualRpMaterial.Text = "0"
        TxtSalesMaterial.Text = "0"
        TxtPercentMaterial.Text = "0"
        TxtAktualProduksiMaterial.Text = "0"
        TxtInjectionMaterial.Text = "0"
        TargetMaterial.Text = "0"

        TxtAktualRpKomponen.Text = "0"
        TxtSalesKomponen.Text = "0"
        TxtPercentKomponen.Text = "0"
        TxtAktualProduksiKomponen.Text = "0"
        TxtInjectionKomponen.Text = "0"
        TargetKomponen.Text = "0"

        TxtKeterangan.Text = ""

        GridMaterial.DataSource = Nothing
        GridKomponen.DataSource = Nothing
    End Sub

    Private Sub TxtKolomQty_TextChanged(sender As Object, e As EventArgs) Handles TxtKolomQty.TextChanged

    End Sub

    Private Sub TxtKolomQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtKolomQty.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        Else
            Call ChangeExcel()
        End If
    End Sub

    Private Sub TxtKolomHarga_TextChanged(sender As Object, e As EventArgs) Handles TxtKolomHarga.TextChanged

    End Sub

    Private Sub TxtKolomHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtKolomHarga.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        Else
            Call ChangeExcel()
        End If
    End Sub
End Class
