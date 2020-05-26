Imports System.Text
Imports CsvHelper
Imports ExcelLibrary
Public Class frmCompare_Invoice
    Dim fc_Class As New clscompare
    Dim dtGrid As DataTable
    Private Sub frmCompare_Invoice1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, True, False, False, False, True, True)
        '' _cmbperpost.Text = Year(Today) & Month(Today)
        _cmbperpost.Text = fc_Class.autoperpost
        LoadGrid2()

    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            getPath()
            If path <> "" Then
                If DataGridView1.Rows.Count > 0 Then
                    ExcelLib.ExportToExcel(path & "\", DataGridView1, "convert_")
                Else
                    Throw New Exception("Grid Kosong")
                End If

            End If
            ShowMessage("File Stored at : " & path)
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid()
        Try
            fc_Class.cekbalance = _cekbalance.Checked
            ' dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            dtGrid = fc_Class.GetAllData
            DataGridView1.DataSource = dtGrid
            '    DataGridView1.Columns(0).Visible = False
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Private Sub LoadGrid2()
        Try
            fc_Class.cmbperpost = _cmbperpost.Text
            fc_Class.cekbalance = _cekbalance.Checked
            ' dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            dtGrid = fc_Class.GetDataImport
            DataGridView2.DataSource = dtGrid
            '    DataGridView1.Columns(0).Visible = False
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid3()
        Try
            fc_Class.cekbalance = _cekbalance.Checked
            ' dtGrid = fc_Class.GetAllDataTable(bs_Filter)
            dtGrid = fc_Class.GetDataReturn
            DataGridView1.DataSource = dtGrid
            '    DataGridView1.Columns(0).Visible = False
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        fc_Class.txtFileLocation = txtFileLocation.Text

        fc_Class.Delete()

        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                '     Dim tglx As DateTime = Format(Date.Now(), "yyyy-MM-dd")
                ' Using cmd As New SqlCommand("INSERT INTO cashbank (tgl,nobukti,transaksi,keterangan,keluar,noref,perpost,acctid) VALUES ('" & Trim(tglx) & "','" & bukti & "','Suspend','" & DataGridView1.Rows(i).Cells(2).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & _perpost.Text & "','" & _acctid.Text & "')", con)
                Dim ObjDetails As New clscompare
                With ObjDetails
                    .g0 = DataGridView1.Rows(i).Cells(0).Value
                    .g1 = DataGridView1.Rows(i).Cells(1).Value
                    .g2 = DataGridView1.Rows(i).Cells(2).Value
                    .g3 = DataGridView1.Rows(i).Cells(3).Value
                    .g4 = DataGridView1.Rows(i).Cells(4).Value
                    .g5 = DataGridView1.Rows(i).Cells(5).Value
                    .g6 = DataGridView1.Rows(i).Cells(6).Value
                    .g7 = DataGridView1.Rows(i).Cells(7).Value
                    .g8 = DataGridView1.Rows(i).Cells(8).Value
                    .g9 = DataGridView1.Rows(i).Cells(9).Value
                    .g10 = DataGridView1.Rows(i).Cells(10).Value
                    .g11 = DataGridView1.Rows(i).Cells(11).Value
                    .g12 = DataGridView1.Rows(i).Cells(12).Value
                    .g13 = DataGridView1.Rows(i).Cells(13).Value
                    .g14 = DataGridView1.Rows(i).Cells(14).Value
                    .g15 = DataGridView1.Rows(i).Cells(15).Value
                    .g16 = DataGridView1.Rows(i).Cells(16).Value
                    .g17 = DataGridView1.Rows(i).Cells(17).Value
                    .g18 = DataGridView1.Rows(i).Cells(18).Value
                    .g19 = DataGridView1.Rows(i).Cells(19).Value
                    .g20 = DataGridView1.Rows(i).Cells(20).Value
                    .g21 = DataGridView1.Rows(i).Cells(21).Value
                    .g22 = DataGridView1.Rows(i).Cells(22).Value
                    .g23 = DataGridView1.Rows(i).Cells(23).Value
                    .g24 = DataGridView1.Rows(i).Cells(24).Value
                    .g25 = DataGridView1.Rows(i).Cells(25).Value
                    .g26 = DataGridView1.Rows(i).Cells(26).Value
                    .g27 = DataGridView1.Rows(i).Cells(27).Value
                    .g28 = DataGridView1.Rows(i).Cells(28).Value
                    .g29 = DataGridView1.Rows(i).Cells(29).Value
                    .g30 = DataGridView1.Rows(i).Cells(30).Value
                    .g31 = DataGridView1.Rows(i).Cells(31).Value
                    .g32 = DataGridView1.Rows(i).Cells(32).Value
                    .g33 = DataGridView1.Rows(i).Cells(33).Value
                    .g34 = DataGridView1.Rows(i).Cells(34).Value
                    .txtFileLocation = _txtFileLocation.Text
                    '      fc_Class.cmbperpost = _cmbperpost.Text
                    .Insert()
                End With
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Data Tersimpan")
        Call LoadGrid2()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fName As String = ""
        OpenFileDialog1.InitialDirectory = "D:\TestFile"
        OpenFileDialog1.Filter = "CSV files(*.csv)|*.csv"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If (OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            fName = OpenFileDialog1.FileName
        End If

        _txtFileLocation.Text = fName
        csv()
    End Sub
    Public Sub csv()
        '  Using reader = New StreamReader("C:\Users\firman\Desktop\yimvol1.csv")
        Using reader = New System.IO.StreamReader(_txtFileLocation.Text, Encoding.ASCII)

            Using csv = New CsvReader(reader)

                Using dr = New CsvDataReader(csv)
                    Dim dt = New DataTable()
                    dt.Load(dr)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strperpost As String = ""

        Invoke(Sub()
                   strperpost = _cmbperpost.Text

               End Sub)
        Dim dt As New DataTable
        dt = fc_Class.proses_compare1(strperpost)

        bb_SetDisplayChangeConfirmation = False
        fc_Class.cekbalance = _cekbalance.Checked
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = DataGridView1.DataSource
        FilterData = New FrmSystem_FilterData(dtGrid)
        MsgBox("Proses Selesai")
    End Sub
    Dim path As String
    Private Sub getPath()
        Try
            Dim folderBrowser As New FolderBrowserDialog
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            If (folderBrowser.ShowDialog() = DialogResult.OK) Then
                path = folderBrowser.SelectedPath
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub _cekbalance_CheckedChanged(sender As Object, e As EventArgs) Handles _cekbalance.CheckedChanged
        'fc_Class.cekbalance = _cekbalance.Checked
        'Call LoadGrid()
        'Dim dtGrid As New DataTable
        'dtGrid = DataGridView1.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = DataGridView1.DataSource
        FilterData = New FrmSystem_FilterData(dtGrid)
    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call LoadGrid3()
    End Sub
End Class
