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
Imports System.Data
Imports System.Data.OleDb


'Imports GemBox.Spreadsheet.WinFormsUtilities
Public Class FrmMaterialUsageDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New PemakaianMaterialModel
    'Dim fc_Class_Detail As New MaterialUsageDetailModel
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Total As Double

    Dim FileLokasi As String

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
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub



    Private Sub FrmMaterialUsageDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                    'TxtIDMaterialUsage.Text = .IDMaterialUsage
                    'TxtTanggal.Text = Format(.Tanggal, gs_FormatSQLDateIn)
                    'TxtAktualRp.Text = .TotalMAterial
                    'TxtSalesRp.Text = .Sales
                    'TxtPersentaseMaterial.Text = .Percent1
                    'TxtAktualProduksi.Text = .TotakAktualProduksi
                    'TxtPersentaseInjection.Text = .Percent2
                    'TxtPersentaseTarget.Text = .Target
                    'TxtIDMaterialUsage.Enabled = False
                    'TxtTanggal.Enabled = False
                End With
            Else
                TxtAktualRp.Text = "0"
                TxtSalesRp.Text = "0"
                TxtPersentaseMaterial.Text = "0"
                TxtAktualProduksi.Text = "0"
                TxtPersentaseInjection.Text = "0"
                TxtPersentaseTarget.Text = "0"

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code = "" Then
                'Dim dtGrid As New DataTable
                'dtGrid = ObjAbsen.GetAllDataTableKategoriAbsen()
                'Grid.DataSource = dtGrid

                'DeptID = String.Empty
                'DeptID = gh_Common.GroupID
                'TxtDepartemen.Text = DeptID

                ''Dim dtGrid As New DataTable
                'dtGrid = Grid.DataSource
                'Call GetJumlahKaryawan()

            Else
                'Dim dtGrid As New DataTable
                ''fc_Class.IDMaterialUsage = fs_Code
                'dtGrid = fc_Class.GetDataDetail(fs_Code)
                'Grid1.DataSource = dtGrid
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Browse_Click(sender As Object, e As EventArgs) Handles Browse.Click
        Try


            Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"}

                If ofd.ShowDialog() = DialogResult.OK Then
                    'FileName.Text = ofd.FileName
                    Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                        Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                            Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                      .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                      .UseHeaderRow = True}})

                            TabelExcel = result.Tables
                            Dim Sheet As String = String.Empty
                            'ComboBoxSheet.Items.Clear()

                            'For Each table As DataTable In TabelExcel
                            '    ComboBoxSheet.Items.Add(table.TableName)
                            '    'Sheet = table.TableName = "Sheet1"
                            'Next

                            Dim dt As DataTable = TabelExcel("Sheet1")
                            Grid1.DataSource = dt
                            Call HitungTotal()
                            Call PersentaseMaterial()

                        End Using
                    End Using

                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub




    Private Sub HitungTotal()
        Dim total As Double
        Dim bagi As Integer = 1000000


        Dim selectedRows() As Integer = GridView2.GetSelectedRows()
        For a As Integer = 0 To GridView2.RowCount - 1
            total = Val(total) + Val(GridView2.GetRowCellValue(a, "Total Harga"))
        Next
        TxtAktualRp.EditValue = Math.Round((total / bagi), 2).ToString
    End Sub

    Private Sub PersentaseMaterial()

        Dim persentase As Double
        persentase = (Val(TxtAktualRp.Text) / Val(TxtSalesRp.Text)) * 100
        TxtPersentaseMaterial.Text = Math.Round(persentase, 2).ToString

    End Sub
    Private Sub PersentaseInjection()

        Dim persentase As Double
        persentase = (Val(TxtAktualRp.Text) / Val(TxtAktualProduksi.Text)) * 100
        TxtPersentaseInjection.Text = Math.Round(persentase, 2).ToString

    End Sub

    Private Sub TxtAktualProduksi_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAktualProduksi.EditValueChanged
        Call PersentaseInjection()
    End Sub

    Private Sub TxtSalesRp_EditValueChanged(sender As Object, e As EventArgs) Handles TxtSalesRp.EditValueChanged
        Call PersentaseMaterial()
    End Sub


    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        'LoadGridDetail()
    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(TxtIDMaterialUsage.Text) Then
                ErrorProvider.SetError(TxtIDMaterialUsage, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtIDMaterialUsage, "")
            End If

            If String.IsNullOrEmpty(TxtTanggal.Text) Then
                ErrorProvider.SetError(TxtTanggal, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtTanggal, "")
            End If
            If String.IsNullOrEmpty(TxtAktualRp.Text) Then
                ErrorProvider.SetError(TxtAktualRp, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtAktualRp, "")
            End If

            If String.IsNullOrEmpty(TxtSalesRp.Text) Then
                ErrorProvider.SetError(TxtSalesRp, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtSalesRp, "")
            End If

            If String.IsNullOrEmpty(TxtPersentaseMaterial.Text) Then
                ErrorProvider.SetError(TxtPersentaseMaterial, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtPersentaseMaterial, "")
            End If

            If String.IsNullOrEmpty(TxtAktualProduksi.Text) Then
                ErrorProvider.SetError(TxtAktualProduksi, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtAktualProduksi, "")
            End If

            If String.IsNullOrEmpty(TxtPersentaseInjection.Text) Then
                ErrorProvider.SetError(TxtPersentaseInjection, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtPersentaseInjection, "")
            End If


            If String.IsNullOrEmpty(TxtPersentaseTarget.Text) Then
                ErrorProvider.SetError(TxtPersentaseTarget, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtPersentaseTarget, "")
            End If

            Dim success As Boolean = True
            For Each c As Control In LayoutControl1.Controls
                If ErrorProvider.GetError(c).Length > 0 Then
                    success = False
                End If
            Next

            If success Then
                lb_Validated = True
            End If

            If lb_Validated Then
                With fc_Class
                    '.IDMaterialUsage = TxtIDMaterialUsage.Text
                    '.TotalMAterial = TxtAktualRp.Text
                    'Dim oDate As DateTime = DateTime.ParseExact(TxtTanggal.Text, "dd-MM-yyyy", provider)
                    '.Tanggal = oDate
                    '.Sales = TxtSalesRp.Text
                    '.Percent1 = TxtPersentaseMaterial.Text
                    '.TotakAktualProduksi = TxtAktualProduksi.Text
                    '.Percent2 = TxtPersentaseInjection.Text
                    '.Target = TxtPersentaseTarget.Text

                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
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
        'Try
        'getdataview1()
        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try

        Try
            'getdataview2()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try

            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridView2.RowCount - 1
                GridView2.MoveFirst()
                If GridView2.GetRowCellValue(i, GridView2.Columns("IDMaterial")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Description")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Quantity")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Total Harga")).ToString = "" Then
                    IsEmpty = True
                    'GridView2.DeleteRow(i)
                    MessageBox.Show("Pastikan Data tidak ada yang kosong")
                    Exit Sub

                End If
            Next


            'If isUpdate = False Then
            '    fc_Class.ObjDetailsMaterial.Clear()
            '    For i As Integer = 0 To GridView2.RowCount - 1
            '        If GridView2.GetRowCellValue(i, "Total Harga").ToString <> "" Then
            '            'fc_Class_Detail = New MaterialUsageDetailModel
            '            'With fc_Class_Detail
            '            '    .Tanggal = CDate(TxtTanggal.EditValue)
            '            '    .IDMaterialUsage = TxtIDMaterialUsage.Text
            '            '    .IDMaterial = Convert.ToString(GridView2.GetRowCellValue(i, "IDMaterial"))
            '            '    .Quantity = Convert.ToInt32(GridView2.GetRowCellValue(i, "Quantity"))
            '            '    .TotalHarga = Convert.ToInt32(GridView2.GetRowCellValue(i, "Total Harga"))
            '            'End With
            '            'fc_Class.ObjDetails.Add(fc_Class_Detail)
            '        End If
            '    Next
            '    fc_Class.InsertMaterialUsage()
            '    GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            '    IsClosed = True
            '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            ' Else

            'fc_Class.ObjDetails.Clear()
            'For i As Integer = 0 To GridView2.RowCount - 1
            '    If GridView2.GetRowCellValue(i, "Total Harga").ToString <> "" Then
            '        'fc_Class_Detail = New MaterialUsageDetailModel
            '        'With fc_Class_Detail
            '        '    '.Tanggal = Format(TxtTanggal.EditValue, gs_FormatSQLDateIn)
            '        '    .IDMaterialUsage = TxtIDMaterialUsage.Text
            '        '    .IDMaterial = Convert.ToString(GridView2.GetRowCellValue(i, "IDMaterial"))
            '        '    .Quantity = Convert.ToInt32(GridView2.GetRowCellValue(i, "Quantity"))
            '        '    .TotalHarga = Convert.ToInt32(GridView2.GetRowCellValue(i, "Total Harga"))

            '        'End With
            '        'fc_Class.ObjDetails.Add(fc_Class_Detail)
            '    End If
            'Next
            'fc_Class.UpdateData()
            'GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            ''IsClosed = True
            'Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            'End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    'Private Sub getdataview2()
    '    Try

    '        Dim IsEmpty As Boolean = False
    '        For i As Integer = 0 To GridView2.RowCount - 1
    '            GridView2.MoveFirst()
    '            If GridView2.GetRowCellValue(i, GridView2.Columns("IDMaterial")).ToString = "" OrElse
    '               GridView2.GetRowCellValue(i, GridView2.Columns("Description")).ToString = "" OrElse
    '               GridView2.GetRowCellValue(i, GridView2.Columns("Quantity")).ToString = "" OrElse
    '               GridView2.GetRowCellValue(i, GridView2.Columns("Total Harga")).ToString = "" Then
    '                IsEmpty = True
    '                'GridView2.DeleteRow(i)
    '                MessageBox.Show("Pastikan Data tidak ada yang kosong")
    '                Exit Sub

    '            End If
    '        Next


    '        If isUpdate = False Then
    '            Try


    '                Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"}

    '                    If ofd.ShowDialog() = DialogResult.OK Then
    '                        FileLokasi = ofd.FileName
    '                        '_filelokasi.Text = FileLokasi
    '                        'Call GetCellValue()
    '                        If IO.File.Exists(FileLokasi) Then

    '                            Dim Proceed As Boolean = False
    '                            Dim xlApp As Excel.Application = Nothing
    '                            Dim xlWorkbooks As Excel.Workbooks = Nothing
    '                            Dim xlWorkbook As Excel.Workbook = Nothing
    '                            Dim xlWorkSheet As Excel.Worksheet = Nothing
    '                            Dim xlWorkSheets As Excel.Sheets = Nothing
    '                            Dim xlCells As Excel.Range = Nothing

    '                            xlApp = New Excel.Application
    '                            xlApp.DisplayAlerts = False
    '                            xlWorkbooks = xlApp.Workbooks
    '                            xlWorkbook = xlWorkbooks.Open(FileLokasi)
    '                            xlApp.Visible = False
    '                            xlWorkSheets = xlWorkbook.Sheets
    '                            Dim cell As Excel.Range = Nothing

    '                            fc_Class.ObjDetails.Clear()
    '                            For x As Integer = 1 To xlWorkSheets.Count
    '                                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)
    '                                ' If xlWorkSheet.Name Then
    '                                For RowX As Integer = 4 To 5
    '                                    cell = Nothing
    '                                    fc_Class_Detail = New MaterialUsageDetailModel
    '                                    With fc_Class_Detail
    '                                        .Tanggal = CDate(TxtTanggal.EditValue)
    '                                        .IDMaterialUsage = TxtIDMaterialUsage.Text
    '                                        cell = xlWorkSheet.Cells(RowX, 1)
    '                                        .IDMaterial = cell.Text
    '                                        cell = xlWorkSheet.Cells(RowX, 3)
    '                                        .Quantity = Convert.ToDouble(cell.Text)
    '                                        cell = xlWorkSheet.Cells(RowX, 4)
    '                                        .TotalHarga = Convert.ToDouble(cell.Text)

    '                                        'A4.Text = cell.Text
    '                                        'cell = xlWorkSheet.Cells(RowX, 2)
    '                                        'B4.Text = cell.Text
    '                                    End With
    '                                    fc_Class.ObjDetails.Add(fc_Class_Detail)
    '                                    Next
    '                                'End If
    '                            Next
    '                            fc_Class.InsertMaterialUsage()
    '                            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
    '                            IsClosed = True
    '                            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

    '                        End If

    '                    End If
    '                End Using
    '            Catch ex As Exception

    '            End Try



    'fc_Class.ObjDetails.Clear()
    'For i As Integer = 0 To GridView2.RowCount - 1
    '    If GridView2.GetRowCellValue(i, "Total Harga").ToString <> "" Then
    '        fc_Class_Detail = New MaterialUsageDetailModel
    '        With fc_Class_Detail
    '            .Tanggal = CDate(TxtTanggal.EditValue)
    '            .IDMaterialUsage = TxtIDMaterialUsage.Text
    '            .IDMaterial = Convert.ToString(GridView2.GetRowCellValue(i, "IDMaterial"))
    '            .Quantity = Convert.ToInt32(GridView2.GetRowCellValue(i, "Quantity"))
    '            .TotalHarga = Convert.ToInt32(GridView2.GetRowCellValue(i, "Total Harga"))
    '        End With
    '        fc_Class.ObjDetails.Add(fc_Class_Detail)
    '    End If
    'Next
    'fc_Class.InsertMaterialUsage()
    'GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
    'IsClosed = True
    'Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
    'Else

    '            fc_Class.ObjDetails.Clear()
    '            For i As Integer = 0 To GridView2.RowCount - 1
    '                If GridView2.GetRowCellValue(i, "Total Harga").ToString <> "" Then
    '                    fc_Class_Detail = New MaterialUsageDetailModel
    '                    With fc_Class_Detail
    '                        '.Tanggal = Format(TxtTanggal.EditValue, gs_FormatSQLDateIn)
    '                        .IDMaterialUsage = TxtIDMaterialUsage.Text
    '                        .IDMaterial = Convert.ToString(GridView2.GetRowCellValue(i, "IDMaterial"))
    '                        .Quantity = Convert.ToInt32(GridView2.GetRowCellValue(i, "Quantity"))
    '                        .TotalHarga = Convert.ToInt32(GridView2.GetRowCellValue(i, "Total Harga"))

    '                    End With
    '                    fc_Class.ObjDetails.Add(fc_Class_Detail)
    '                End If
    '            Next
    '            fc_Class.UpdateData()
    '            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
    '            'IsClosed = True
    '            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
    '        End If

    '        IsClosed = True
    '        Me.Hide()
    '    Catch ex As Exception
    '        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try

    'End Sub



    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Try
            Call HitungTotal()
            Call PersentaseMaterial()
            Call PersentaseInjection()
        Catch ex As Exception
            MessageBox.Show("Jangan Kosong")
        End Try


    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        'Call HitungTotal()
    End Sub

    Private Sub Grid1_Click(sender As Object, e As EventArgs) Handles Grid1.Click

    End Sub
End Class
