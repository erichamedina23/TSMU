Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI

Public Class FrmLookUpBarcode
    Dim Obj As New BarcodeGenerate
    Dim dtTemp As DataTable

    Dim PrintTool As ReportPrintTool
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("No")
        dtTemp.Columns.Add("InvtID")
        dtTemp.Columns.Add("Color")
        dtTemp.Columns.Add("PartNo")
        dtTemp.Columns.Add("KodePart")
        dtTemp.Columns.Add("JobNo")
        dtTemp.Columns.Add("PartName")
        dtTemp.Columns.Add("Bulan")
        dtTemp.Columns.Add("Status")
        dtTemp.Columns.Add("Qty")
        dtTemp.Columns.Add("QrCode")
        dtTemp.Columns.Add("Warna")
        dtTemp.Columns.Add("LR")
        dtTemp.Columns.Add("KodeWarna")
        dtTemp.Columns.Add("CustomerID")
        dtTemp.Columns.Add("QrCode1")
        dtTemp.Clear()
    End Sub
    Private Sub FillComboBulan()
        Dim tahun() As String = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "November", "Desember"}
        CmbBulan.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboTahun()
        Dim tahun() As String = {DateTime.Now.Year - 1, DateTime.Now.Year, DateTime.Now.Year + 1}
        cmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            cmbTahun.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub GenerateRow()
        Try
            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            For i As Integer = a To b - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = "Level 0"
                'dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level0") & "")
            Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            Dim Username = String.Empty
            If gh_Common.Site.ToLower = "tng" Then
                If TxtSite.Text = "" Then
                    TxtSite.Focus()
                    Throw New Exception("Silahkan lengkapi data")
                Else
                    If TxtSite.Text.ToLower = "painting" Then
                        Username = "Aini"

                    Else
                        Username = "Nunik"
                    End If
                End If

            End If
            If TxtKodePart.Text = "" OrElse CmbBulan.Text = "" OrElse TxtFrom.Text = "" OrElse TxtTo.Text = "" Then
                Throw New Exception("Silahkan lengkapi data")
            ElseIf TxtFrom.Text = "0" OrElse TxtTo.Text = "0" Then
                TxtFrom.Focus()
                TxtFrom.SelectAll()
                Throw New Exception("No Passcard From/To tidak boleh '0'")
            ElseIf Val(TxtFrom.Text) > Val(TxtTo.Text) Then
                TxtFrom.Focus()
                TxtFrom.SelectAll()
                Throw New Exception("No Passcard From tidak boleh lebih besar dari To")
            ElseIf Val(TxtFrom.Text) <= txtNo.Text Then
                TxtFrom.Focus()
                TxtFrom.SelectAll()
                Throw New Exception("No Passcard From harus lebih besar dari '[" & txtNo.Text & "]'")
            End If

            'If gh_Common.Site.ToLower = "tng" Then

            '    If TxtFrom.EditValue < "7" Then
            '        TxtFrom.Focus()
            '        TxtFrom.SelectAll()
            '        Throw New Exception("No Passcard From harus di mulai dari angka '7'")
            '    End If
            'End If

            Dim ds As DataSet = New DataSet
            Dim dt As DataTable = New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                ds = Obj.PrintQRCOde(TxtKodePart.Text, gh_Common.Site, Username.ToLower)
            Else
                ds = Obj.PrintQRCOdeCkr(TxtKodePart.Text, gh_Common.Site)
            End If

            dt = ds.Tables("QRCode")

            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            If dt.Rows.Count = 0 Then
                Throw New Exception("Kode Part tidak ditemukan, Silahkan input kode yang lain")
            End If
            TempTable()

            For i As Integer = a To b
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = i
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(0).Item("InvtID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(dt.Rows(0).Item("Color") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(dt.Rows(0).Item("PartNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(dt.Rows(0).Item("KodePart") & "")
                If Trim(dt.Rows(0).Item("CustomerID") & "").ToLower = "yim" Then
                    dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Microsoft.VisualBasic.Left(Trim(dt.Rows(0).Item("JobNo") & ""), 3)
                Else
                    dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(dt.Rows(0).Item("JobNo") & "")
                End If

                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(dt.Rows(0).Item("PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = CmbBulan.Text
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(dt.Rows(0).Item("Status") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(dt.Rows(0).Item("Qty") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(dt.Rows(0).Item("JobNo") & "") & "-" & CmbBulan.Text & "-" & i
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(11) = Trim(dt.Rows(0).Item("Warna") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(dt.Rows(0).Item("LR") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(dt.Rows(0).Item("KodeWarna") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(dt.Rows(0).Item("CustomerID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(dt.Rows(0).Item("InvtID") & "") & "-" & Trim(dt.Rows(0).Item("JobNo") & "") & "-" & CmbBulan.Text & "-" & i
            Next

            If gh_Common.Site.ToLower = "tng" Then
                Dim Laporan As New Testing()
                With Laporan
                    .param1 = TxtKodePart.Text
                    .param2 = CmbBulan.Text
                    .param3 = "TSC1"
                    .param4 = TxtTgl.Text
                    .DataSource = dtTemp
                    AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
                End With

                PrintTool = New ReportPrintTool(Laporan)
                TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                'PrintTool.ShowPreviewDialog()
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            Else
                'Dim Laporan1 As New Testing()
                Dim Laporan1 As New Passcard()
                With Laporan1
                    .param1 = TxtKodePart.Text
                    .param2 = CmbBulan.Text
                    .param3 = "TSC3"
                    .param4 = TxtTgl.Text
                    .DataSource = dtTemp
                    AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
                End With

                PrintTool = New ReportPrintTool(Laporan1)
                TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                'PrintTool.ShowPreviewDialog()
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            End If

            'Dim Laporan As New Testing()
            'With Laporan
            '    .param1 = TxtKodePart.Text
            '    .param2 = CmbBulan.Text
            '    If gh_Common.Site.ToLower = "tng" Then
            '        .param3 = "TSC1"
            '        .param4 = TxtTgl.Text
            '    Else
            '        .param3 = "TSC3"
            '        .param4 = TxtTgl.Text
            '    End If
            '    .DataSource = dtTemp
            '    AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            'End With
            'PrintTool = New ReportPrintTool(Laporan)
            'TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            ''PrintTool.ShowPreviewDialog()
            'PrintTool.ShowPreview(UserLookAndFeel.Default)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmLookUpBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gh_Common.Site.ToLower <> "tng" Then
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        FillComboTahun()
        cmbTahun.EditValue = DateTime.Now.Year
        CmbBulan.EditValue = DateTime.Now.Month
    End Sub

    Private Sub CmbBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbBulan.KeyPress
        e.Handled = True
    End Sub

    Private Sub TxtSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSite.KeyPress
        e.Handled = True
    End Sub

    Private Sub CmbBulan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBulan.SelectedIndexChanged
        Try
            If TxtKodePart.Text = "" Then
                TxtKodePart.Focus()
                CmbBulan.Text = ""
                Throw New Exception("Silahkan isi kode part dulu")
            End If
            txtNo.Text = Obj.GetNoPrint(cmbTahun.Text, CmbBulan.Text, TxtKodePart.Text)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
        'TxtFrom.Text = Obj.GetNoPrint(CmbBulan.Text, TxtKodePart.Text)

    End Sub
    Private Sub PrintingSystem_EndPrint(sender As Object, e As EventArgs)
        Try
            Obj.InsertLog(cmbTahun.Text, CmbBulan.Text, TxtKodePart.Text, TxtTo.Text, dtTemp.Rows(0)("CustomerID").ToString(),
                            dtTemp.Rows(0)("InvtID").ToString(), dtTemp.Rows(0)("PartName").ToString(),
                            dtTemp.Rows(0)("PartNo").ToString())
            PrintTool.ClosePreview()
            CmbBulan_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TxtKodePart_EditValueChanged(sender As Object, e As EventArgs) Handles TxtKodePart.EditValueChanged
        txtNo.Text = Obj.GetNoPrint(cmbTahun.Text, CmbBulan.Text, TxtKodePart.Text)
    End Sub

    Private Sub cmbTahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTahun.SelectedIndexChanged
        Try
            If TxtKodePart.Text = "" Then
                TxtKodePart.Focus()
                cmbTahun.Text = ""
                Throw New Exception("Silahkan isi kode part dulu")
            End If
            txtNo.Text = Obj.GetNoPrint(cmbTahun.Text, CmbBulan.Text, TxtKodePart.Text)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
