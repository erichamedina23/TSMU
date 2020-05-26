Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Public Class frmCalculate
    Dim dtGrid As DataTable
    Dim dataTB As DataTable
    Dim ObjSales As New clsSalesForecastCalculate
    Dim ObjSalesdetail As New clsCalculateBoMdetail
    Friend Delegate Sub SetDataSourceDelegate(table As DataTable)
    Dim Bulan1 As Integer
    Dim Bulan2 As Integer
    Dim strTahun As String

    Dim jan As Single
    Dim feb As Single
    Dim mar As Single
    Dim apr As Single
    Dim mei As Single
    Dim jun As Single
    Dim jul As Single
    Dim agt As Single
    Dim sep As Single
    Dim okt As Single
    Dim nov As Single
    Dim des As Single
    Dim bomidH1 As String
    Dim janPO As Single
    Dim febPO As Single
    Dim marPO As Single
    Dim aprPO As Single
    Dim meiPO As Single
    Dim junPO As Single
    Dim julPO As Single
    Dim agtPO As Single
    Dim sepPO As Single
    Dim oktPO As Single
    Dim novPO As Single
    Dim desPO As Single
    Dim inv As String

    Dim JanPrice As Double
    Dim FebPrice As Double
    Dim MarPrice As Double
    Dim AprPrice As Double
    Dim MeiPrice As Double
    Dim JunPrice As Double
    Dim JulPrice As Double
    Dim AgtPrice As Double
    Dim SepPrice As Double
    Dim OktPrice As Double
    Dim NovPrice As Double
    Dim DesPrice As Double

    Private Sub frmCalculate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBulan()
        FillComboTahun()
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
    End Sub
    Private Sub FillHeader_fdtlConfig1()
        dataTB = New DataTable
        dataTB.Columns.Add("Level 0")
        dataTB.Columns.Add("Level 1")
        dataTB.Columns.Add("Level 2")
        dataTB.Columns.Add("Level 3")
        dataTB.Columns.Add("Level 4")
        dataTB.Columns.Add("Level 5")
        dataTB.Columns.Add("Level 6")
        dataTB.Columns.Add("Level 7")
        dataTB.Columns.Add("Description")
        dataTB.Columns.Add("Qty")
        dataTB.Columns.Add("Unit")
        dataTB.Clear()
    End Sub
    Public Enum IndexCol1 As Byte
        Level0 = 0
        Level1 = 1
        Level2 = 2
        Level3 = 3
        Level4 = 4
        Level5 = 5
        Level6 = 6
        Level7 = 7
        desc = 8
        qty = 9
        unit = 10
    End Enum
    Private Sub setDataSource(table As DataTable)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)
        Else
            Grid.DataSource = table
        End If
    End Sub
    Private Sub FillComboBulan()
        Dim tahun() As String = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "November", "Desember"}
        CmbBulan1.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan1.Properties.Items.Add(var)
        Next

        CmbBulan2.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan2.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Async Sub BtnProses_Click(sender As Object, e As EventArgs) Handles BtnProses.Click
        Try
            Await Task.Run(Sub() LoadData())
            'LoadData()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                Dim save As New SaveFileDialog
                save.Filter = "Excel File|*.xlsx"
                save.Title = "Save an Excel File"
                If save.ShowDialog = DialogResult.OK Then
                    Grid.ExportToXlsx(save.FileName)
                End If
                'getPath()
                '    Dim Filename As String = path & "\Forecast_.xls"
                '    'Dim FileName As String = "D:\Grid.xls"
                '    Grid.ExportToXls(Filename)

            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadData()
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("")
            Dim dt As New DataTable
            dt = ObjSales.GetBomToCalculate
            FillHeader_fdtlConfig1()

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0).ToString = "Level 0" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level0) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 1" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level1) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 2" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level2) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 3" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level3) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 4" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level4) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 5" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level5) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 6" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level6) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 7" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level7) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
            Next
            setDataSource(dataTB)
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Private Sub CalculatedBoM()
        Try
            Dim Id As Integer = 0
            Invoke(Sub()
                       Bulan1 = CmbBulan1.SelectedIndex
                       Bulan2 = CmbBulan2.SelectedIndex
                       strTahun = CmbTahun.Text

                       If strTahun = "" Then
                           CmbTahun.Focus()
                           Throw New Exception("Silahkan pilih tahun !")
                       End If
                       If CmbSales.Text = "" Then
                           CmbSales.Focus()
                           Throw New Exception("Pilih Sales !")
                       End If
                       If CmbBulan1.Text = "" Then
                           CmbBulan1.Focus()
                           Throw New Exception("Pilih Bulan !")
                       End If
                       If CmbBulan2.Text = "" Then
                           CmbBulan2.Focus()
                           Throw New Exception("Pilih Bulan !")
                       End If
                       If CmbBulan1.SelectedIndex > CmbBulan2.SelectedIndex Then
                           CmbBulan1.Focus()
                           Throw New Exception("Range bulan salah !")
                       End If
                   End Sub)
            If GridView1.RowCount = 0 Then
                Throw New Exception("Grid kosong, Load data terlebih dahulu !")
            End If
            Dim Status As Boolean
            'Hitung Forecast Januari terhadap BOM
            Dim dt As New DataTable
            dt = ObjSales.GetForecastAll

            If Bulan1 = 1 Then
                For i As Integer = 1 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 2 Then
                For i As Integer = 2 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 3 Then
                For i As Integer = 3 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 4 Then
                For i As Integer = 4 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 5 Then
                For i As Integer = 5 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 6 Then
                For i As Integer = 6 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 7 Then
                For i As Integer = 7 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 8 Then
                For i As Integer = 8 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 9 Then
                For i As Integer = 9 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 10 Then
                For i As Integer = 10 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 11 Then
                For i As Integer = 11 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            ElseIf Bulan1 = 12 Then
                For i As Integer = 12 To Bulan2
                    ObjSales.DeleteHeader(strTahun, i)
                    ObjSales.DeleteDetails(strTahun, i)
                Next
            End If

            For i As Integer = 0 To dataTB.Rows.Count - 1
                Dim bomidH As String = ""
                Dim invtid As String = ""
                Dim descr As String = ""
                Dim unit As String = ""
                Dim qty As Single = 0
                Dim level0 As String = ""
                Dim level1 As String = ""
                Dim level2 As String = ""
                Dim level3 As String = ""
                Dim level4 As String = ""
                Dim level5 As String = ""
                Dim level6 As String = ""
                Dim level7 As String = ""
                Dim IsForecastAlreadyCalculated As Boolean = False
                descr = dataTB.Rows(i).Item("Description").ToString
                unit = dataTB.Rows(i).Item("Unit").ToString
                qty = dataTB.Rows(i).Item("Qty").ToString
                level0 = dataTB.Rows(i).Item("Level 0").ToString
                level1 = dataTB.Rows(i).Item("Level 1").ToString
                level2 = dataTB.Rows(i).Item("Level 2").ToString
                level3 = dataTB.Rows(i).Item("Level 3").ToString
                level4 = dataTB.Rows(i).Item("Level 4").ToString
                level5 = dataTB.Rows(i).Item("Level 5").ToString
                level6 = dataTB.Rows(i).Item("Level 6").ToString
                level7 = dataTB.Rows(i).Item("Level 7").ToString
                'qty = dataTB.Rows(i).Item("Qty")

                If level0 <> "" Then
                    'IsForecastAlreadyCalculated = ObjSales.IsForecastExist(strTahun, level0)
                    ''bomidH1 = bomidH
                    'Status = IsForecastAlreadyCalculated
                    inv = level0
                    'If IsForecastAlreadyCalculated Then
                    '    Id = ObjSales.UpdateHeader(strTahun, inv)
                    'Else
                    With ObjSales
                        .invtid = level0
                        .descr = descr
                        .Semester = "0"
                        .Tahun = strTahun
                        .QtyBoM = 0
                        .QtyForecast = 0
                        .QtyPO = 0
                        Id = .InsertHeader()
                    End With
                    'End If
                Else
                    For j As Integer = 0 To dt.Rows.Count - 1
                        Dim invtidD As String = ""
                        invtid = dt.Rows(j).Item("invtid").ToString
                        jan = 0
                        feb = 0
                        mar = 0
                        apr = 0
                        mei = 0
                        jun = 0
                        jul = 0
                        agt = 0
                        sep = 0
                        nov = 0
                        okt = 0
                        des = 0
                        If inv = invtid Then
                            If dt.Rows(j).Item("JanQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty1").ToString <> "0" Then
                                jan = dt.Rows(j).Item("JanQty3")
                            ElseIf dt.Rows(j).Item("JanQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty1").ToString = "0" Then
                                jan = dt.Rows(j).Item("JanQty3")
                            ElseIf dt.Rows(j).Item("JanQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty2").ToString = "0" AndAlso dt.Rows(j).Item("JanQty1").ToString = "0" Then
                                jan = dt.Rows(j).Item("JanQty3")
                            ElseIf dt.Rows(j).Item("JanQty3").ToString = "0" AndAlso dt.Rows(j).Item("JanQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty1").ToString <> "0" Then
                                jan = dt.Rows(j).Item("JanQty2")
                            ElseIf dt.Rows(j).Item("JanQty3").ToString = "0" AndAlso dt.Rows(j).Item("JanQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JanQty1").ToString = "0" Then
                                jan = dt.Rows(j).Item("JanQty2")
                            ElseIf dt.Rows(j).Item("JanQty3").ToString = "0" AndAlso dt.Rows(j).Item("JanQty2").ToString = "0" AndAlso dt.Rows(j).Item("JanQty1").ToString <> "0" Then
                                jan = dt.Rows(j).Item("JanQty1")
                            Else
                                jan = 0
                            End If

                            If dt.Rows(j).Item("Jan PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jan PO1").ToString <> "0" Then
                                janPO = dt.Rows(j).Item("Jan PO2")
                            ElseIf dt.Rows(j).Item("Jan PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jan PO1").ToString = "0" Then
                                janPO = dt.Rows(j).Item("Jan PO2")
                            ElseIf dt.Rows(j).Item("Jan PO2").ToString = "0" AndAlso dt.Rows(j).Item("Jan PO1").ToString <> "0" Then
                                janPO = dt.Rows(j).Item("Jan PO1")
                            Else
                                janPO = 0
                            End If

                            If dt.Rows(j).Item("FebQty3").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty2").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty1").ToString <> "0" Then
                                feb = dt.Rows(j).Item("FebQty3")
                            ElseIf dt.Rows(j).Item("FebQty3").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty2").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty1").ToString = "0" Then
                                feb = dt.Rows(j).Item("FebQty3")
                            ElseIf dt.Rows(j).Item("FebQty3").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty2").ToString = "0" AndAlso dt.Rows(j).Item("FebQty1").ToString = "0" Then
                                feb = dt.Rows(j).Item("FebQty3")
                            ElseIf dt.Rows(j).Item("FebQty3").ToString = "0" AndAlso dt.Rows(j).Item("FebQty2").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty1").ToString <> "0" Then
                                feb = dt.Rows(j).Item("FebQty2")
                            ElseIf dt.Rows(j).Item("FebQty3").ToString = "0" AndAlso dt.Rows(j).Item("FebQty2").ToString <> "0" AndAlso dt.Rows(j).Item("FebQty1").ToString = "0" Then
                                feb = dt.Rows(j).Item("FebQty2")
                            ElseIf dt.Rows(j).Item("FebQty3").ToString = "0" AndAlso dt.Rows(j).Item("FebQty2").ToString = "0" AndAlso dt.Rows(j).Item("FebQty1").ToString <> "0" Then
                                feb = dt.Rows(j).Item("FebQty1")
                            Else
                                feb = 0
                            End If

                            '===============PO Februari=====================
                            If dt.Rows(j).Item("Feb PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Feb PO1").ToString <> "0" Then
                                febPO = dt.Rows(j).Item("Feb PO2")
                            ElseIf dt.Rows(j).Item("Feb PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Feb PO1").ToString = "0" Then
                                febPO = dt.Rows(j).Item("Feb PO2")
                            ElseIf dt.Rows(j).Item("Feb PO2").ToString = "0" AndAlso dt.Rows(j).Item("Feb PO1").ToString <> "0" Then
                                febPO = dt.Rows(j).Item("Feb PO1")
                            Else
                                febPO = 0
                            End If

                            If dt.Rows(j).Item("MarQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty1").ToString <> "0" Then
                                mar = dt.Rows(j).Item("MarQty3")
                            ElseIf dt.Rows(j).Item("MarQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty1").ToString = "0" Then
                                mar = dt.Rows(j).Item("MarQty3")
                            ElseIf dt.Rows(j).Item("MarQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty2").ToString = "0" AndAlso dt.Rows(j).Item("MarQty1").ToString = "0" Then
                                mar = dt.Rows(j).Item("MarQty3")
                            ElseIf dt.Rows(j).Item("MarQty3").ToString = "0" AndAlso dt.Rows(j).Item("MarQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty1").ToString <> "0" Then
                                mar = dt.Rows(j).Item("MarQty2")
                            ElseIf dt.Rows(j).Item("MarQty3").ToString = "0" AndAlso dt.Rows(j).Item("MarQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MarQty1").ToString = "0" Then
                                mar = dt.Rows(j).Item("MarQty2")
                            ElseIf dt.Rows(j).Item("MarQty3").ToString = "0" AndAlso dt.Rows(j).Item("MarQty2").ToString = "0" AndAlso dt.Rows(j).Item("MarQty1").ToString <> "0" Then
                                mar = dt.Rows(j).Item("MarQty1")
                            Else
                                mar = 0
                            End If

                            '===============PO Maret=====================
                            If dt.Rows(j).Item("Mar PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Mar PO1").ToString <> "0" Then
                                marPO = dt.Rows(j).Item("Mar PO2")
                            ElseIf dt.Rows(j).Item("Mar PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Mar PO1").ToString = "0" Then
                                marPO = dt.Rows(j).Item("Mar PO2")
                            ElseIf dt.Rows(j).Item("Mar PO2").ToString = "0" AndAlso dt.Rows(j).Item("Mar PO1").ToString <> "0" Then
                                marPO = dt.Rows(j).Item("Mar PO1")
                            Else
                                marPO = 0
                            End If

                            If dt.Rows(j).Item("AprQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString <> "0" Then
                                apr = dt.Rows(j).Item("AprQty3")
                            ElseIf dt.Rows(j).Item("AprQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString = "0" Then
                                apr = dt.Rows(j).Item("AprQty3")
                            ElseIf dt.Rows(j).Item("AprQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty2").ToString = "0" AndAlso dt.Rows(j).Item("AprQty1").ToString = "0" Then
                                apr = dt.Rows(j).Item("AprQty3")
                            ElseIf dt.Rows(j).Item("AprQty3").ToString = "0" AndAlso dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString <> "0" Then
                                apr = dt.Rows(j).Item("AprQty2")
                            ElseIf dt.Rows(j).Item("AprQty3").ToString = "0" AndAlso dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString = "0" Then
                                apr = dt.Rows(j).Item("AprQty2")
                            ElseIf dt.Rows(j).Item("AprQty3").ToString = "0" AndAlso dt.Rows(j).Item("AprQty2").ToString = "0" AndAlso dt.Rows(j).Item("AprQty1").ToString <> "0" Then
                                apr = dt.Rows(j).Item("AprQty1")
                            Else
                                apr = 0
                            End If

                            '===============PO April=====================
                            If dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString <> "0" Then
                                aprPO = dt.Rows(j).Item("AprQty2")
                            ElseIf dt.Rows(j).Item("AprQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AprQty1").ToString = "0" Then
                                aprPO = dt.Rows(j).Item("AprQty2")
                            ElseIf dt.Rows(j).Item("AprQty2").ToString = "0" AndAlso dt.Rows(j).Item("AprQty1").ToString <> "0" Then
                                aprPO = dt.Rows(j).Item("AprQty1")
                            Else
                                aprPO = 0
                            End If

                            If dt.Rows(j).Item("MeiQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString <> "0" Then
                                mei = dt.Rows(j).Item("MeiQty3")
                            ElseIf dt.Rows(j).Item("MeiQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString = "0" Then
                                mei = dt.Rows(j).Item("MeiQty3")
                            ElseIf dt.Rows(j).Item("MeiQty3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString = "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString = "0" Then
                                mei = dt.Rows(j).Item("MeiQty3")
                            ElseIf dt.Rows(j).Item("MeiQty3").ToString = "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString <> "0" Then
                                mei = dt.Rows(j).Item("MeiQty2")
                            ElseIf dt.Rows(j).Item("MeiQty3").ToString = "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString = "0" Then
                                mei = dt.Rows(j).Item("MeiQty2")
                            ElseIf dt.Rows(j).Item("MeiQty3").ToString = "0" AndAlso dt.Rows(j).Item("MeiQty2").ToString = "0" AndAlso dt.Rows(j).Item("MeiQty1").ToString <> "0" Then
                                mei = dt.Rows(j).Item("MeiQty1")
                            Else
                                mei = 0
                            End If

                            '===============PO Mei=====================
                            If dt.Rows(j).Item("Mei PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Mei PO1").ToString <> "0" Then
                                meiPO = dt.Rows(j).Item("Mei PO2")
                            ElseIf dt.Rows(j).Item("Mei PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Mei PO1").ToString = "0" Then
                                meiPO = dt.Rows(j).Item("Mei PO2")
                            ElseIf dt.Rows(j).Item("Mei PO2").ToString = "0" AndAlso dt.Rows(j).Item("Mei PO1").ToString <> "0" Then
                                meiPO = dt.Rows(j).Item("Mei PO1")
                            Else
                                meiPO = 0
                            End If

                            'JUNI
                            If dt.Rows(j).Item("JunQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JunQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JunQty1").ToString <> "0" Then
                                jun = dt.Rows(j).Item("JunQty3")
                            ElseIf dt.Rows(j).Item("JunQty3").ToString = "0" AndAlso dt.Rows(j).Item("JunQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JunQty1").ToString <> "0" Then
                                jun = dt.Rows(j).Item("JunQty2")
                            ElseIf dt.Rows(j).Item("JunQty3").ToString = "0" AndAlso dt.Rows(j).Item("JunQty2").ToString = "0" AndAlso dt.Rows(j).Item("JunQty1").ToString <> "0" Then
                                jun = dt.Rows(j).Item("JunQty1")
                            Else
                                jun = 0
                            End If

                            If dt.Rows(j).Item("Jun PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jun PO1").ToString <> "0" Then
                                junPO = dt.Rows(j).Item("Jun PO2")
                            ElseIf dt.Rows(j).Item("Jun PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jun PO1").ToString = "0" Then
                                junPO = dt.Rows(j).Item("Jun PO2")
                            ElseIf dt.Rows(j).Item("Jun PO2").ToString = "0" AndAlso dt.Rows(j).Item("Jun PO1").ToString <> "0" Then
                                junPO = dt.Rows(j).Item("Jun PO1")
                            Else
                                junPO = 0
                            End If

                            If dt.Rows(j).Item("JulQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty1").ToString <> "0" Then
                                jul = dt.Rows(j).Item("JulQty3")
                            ElseIf dt.Rows(j).Item("JulQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty1").ToString = "0" Then
                                jul = dt.Rows(j).Item("JulQty3")
                            ElseIf dt.Rows(j).Item("JulQty3").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty2").ToString = "0" AndAlso dt.Rows(j).Item("JulQty1").ToString = "0" Then
                                jul = dt.Rows(j).Item("JulQty3")
                            ElseIf dt.Rows(j).Item("JulQty3").ToString = "0" AndAlso dt.Rows(j).Item("JulQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty1").ToString <> "0" Then
                                jul = dt.Rows(j).Item("JulQty2")
                            ElseIf dt.Rows(j).Item("JulQty3").ToString = "0" AndAlso dt.Rows(j).Item("JulQty2").ToString <> "0" AndAlso dt.Rows(j).Item("JulQty1").ToString = "0" Then
                                jul = dt.Rows(j).Item("JulQty2")
                            ElseIf dt.Rows(j).Item("JulQty3").ToString = "0" AndAlso dt.Rows(j).Item("JulQty2").ToString = "0" AndAlso dt.Rows(j).Item("JulQty1").ToString <> "0" Then
                                jul = dt.Rows(j).Item("JulQty1")
                            Else
                                jul = 0
                            End If

                            '===============PO Juli=====================
                            If dt.Rows(j).Item("Jul PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jul PO1").ToString <> "0" Then
                                julPO = dt.Rows(j).Item("Jul PO2")
                            ElseIf dt.Rows(j).Item("Jul PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Jul PO1").ToString = "0" Then
                                julPO = dt.Rows(j).Item("Jul PO2")
                            ElseIf dt.Rows(j).Item("Jul PO2").ToString = "0" AndAlso dt.Rows(j).Item("Jul PO1").ToString <> "0" Then
                                julPO = dt.Rows(j).Item("Jul PO1")
                            Else
                                julPO = 0
                            End If


                            If dt.Rows(j).Item("AgtQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString <> "0" Then
                                agt = dt.Rows(j).Item("AgtQty3")
                            ElseIf dt.Rows(j).Item("AgtQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString = "0" Then
                                agt = dt.Rows(j).Item("AgtQty3")
                            ElseIf dt.Rows(j).Item("AgtQty3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString = "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString = "0" Then
                                agt = dt.Rows(j).Item("AgtQty3")
                            ElseIf dt.Rows(j).Item("AgtQty3").ToString = "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString <> "0" Then
                                agt = dt.Rows(j).Item("AgtQty2")
                            ElseIf dt.Rows(j).Item("AgtQty3").ToString = "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString = "0" Then
                                agt = dt.Rows(j).Item("AgtQty2")
                            ElseIf dt.Rows(j).Item("AgtQty3").ToString = "0" AndAlso dt.Rows(j).Item("AgtQty2").ToString = "0" AndAlso dt.Rows(j).Item("AgtQty1").ToString <> "0" Then
                                agt = dt.Rows(j).Item("AgtQty1")
                            Else
                                agt = 0
                            End If

                            '===============PO Agustus=====================
                            If dt.Rows(j).Item("Agt PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Agt PO1").ToString <> "0" Then
                                agtPO = dt.Rows(j).Item("Agt PO2")
                            ElseIf dt.Rows(j).Item("Agt PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Agt PO1").ToString = "0" Then
                                agtPO = dt.Rows(j).Item("Agt PO2")
                            ElseIf dt.Rows(j).Item("Agt PO2").ToString = "0" AndAlso dt.Rows(j).Item("Agt PO1").ToString <> "0" Then
                                agtPO = dt.Rows(j).Item("Agt PO1")
                            Else
                                agtPO = 0
                            End If

                            If dt.Rows(j).Item("SepQty3").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty2").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty1").ToString <> "0" Then
                                sep = dt.Rows(j).Item("SepQty3")
                            ElseIf dt.Rows(j).Item("SepQty3").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty2").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty1").ToString = "0" Then
                                sep = dt.Rows(j).Item("SepQty3")
                            ElseIf dt.Rows(j).Item("SepQty3").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty2").ToString = "0" AndAlso dt.Rows(j).Item("SepQty1").ToString = "0" Then
                                sep = dt.Rows(j).Item("SepQty3")
                            ElseIf dt.Rows(j).Item("SepQty3").ToString = "0" AndAlso dt.Rows(j).Item("SepQty2").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty1").ToString <> "0" Then
                                sep = dt.Rows(j).Item("SepQty2")
                            ElseIf dt.Rows(j).Item("SepQty3").ToString = "0" AndAlso dt.Rows(j).Item("SepQty2").ToString <> "0" AndAlso dt.Rows(j).Item("SepQty1").ToString = "0" Then
                                sep = dt.Rows(j).Item("SepQty2")
                            ElseIf dt.Rows(j).Item("SepQty3").ToString = "0" AndAlso dt.Rows(j).Item("SepQty2").ToString = "0" AndAlso dt.Rows(j).Item("SepQty1").ToString <> "0" Then
                                sep = dt.Rows(j).Item("SepQty1")
                            Else
                                sep = 0
                            End If

                            '===============PO September=====================
                            If dt.Rows(j).Item("Sep PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Sep PO1").ToString <> "0" Then
                                sepPO = dt.Rows(j).Item("Sep PO2")
                            ElseIf dt.Rows(j).Item("Sep PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Sep PO1").ToString = "0" Then
                                sepPO = dt.Rows(j).Item("Sep PO2")
                            ElseIf dt.Rows(j).Item("Sep PO2").ToString = "0" AndAlso dt.Rows(j).Item("Sep PO1").ToString <> "0" Then
                                sepPO = dt.Rows(j).Item("Sep PO1")
                            Else
                                sepPO = 0
                            End If

                            If dt.Rows(j).Item("OktQty3").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty2").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty1").ToString <> "0" Then
                                okt = dt.Rows(j).Item("OktQty3")
                            ElseIf dt.Rows(j).Item("OktQty3").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty2").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty1").ToString = "0" Then
                                okt = dt.Rows(j).Item("OktQty3")
                            ElseIf dt.Rows(j).Item("OktQty3").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty2").ToString = "0" AndAlso dt.Rows(j).Item("OktQty1").ToString = "0" Then
                                okt = dt.Rows(j).Item("OktQty3")
                            ElseIf dt.Rows(j).Item("OktQty3").ToString = "0" AndAlso dt.Rows(j).Item("OktQty2").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty1").ToString <> "0" Then
                                okt = dt.Rows(j).Item("OktQty2")
                            ElseIf dt.Rows(j).Item("OktQty3").ToString = "0" AndAlso dt.Rows(j).Item("OktQty2").ToString <> "0" AndAlso dt.Rows(j).Item("OktQty1").ToString = "0" Then
                                okt = dt.Rows(j).Item("OktQty2")
                            ElseIf dt.Rows(j).Item("OktQty3").ToString = "0" AndAlso dt.Rows(j).Item("OktQty2").ToString = "0" AndAlso dt.Rows(j).Item("OktQty1").ToString <> "0" Then
                                okt = dt.Rows(j).Item("OktQty1")
                            Else
                                okt = 0
                            End If


                            '===============PO Oktober=====================
                            If dt.Rows(j).Item("Okt PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Okt PO1").ToString <> "0" Then
                                oktPO = dt.Rows(j).Item("Okt PO2")
                            ElseIf dt.Rows(j).Item("Okt PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Okt PO1").ToString = "0" Then
                                oktPO = dt.Rows(j).Item("Okt PO2")
                            ElseIf dt.Rows(j).Item("Okt PO2").ToString = "0" AndAlso dt.Rows(j).Item("Okt PO1").ToString <> "0" Then
                                oktPO = dt.Rows(j).Item("Okt PO1")
                            Else
                                oktPO = 0
                            End If

                            If dt.Rows(j).Item("NovQty3").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty2").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty1").ToString <> "0" Then
                                nov = dt.Rows(j).Item("NovQty3")
                            ElseIf dt.Rows(j).Item("NovQty3").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty2").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty1").ToString = "0" Then
                                nov = dt.Rows(j).Item("NovQty3")
                            ElseIf dt.Rows(j).Item("NovQty3").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty2").ToString = "0" AndAlso dt.Rows(j).Item("NovQty1").ToString = "0" Then
                                nov = dt.Rows(j).Item("NovQty3")
                            ElseIf dt.Rows(j).Item("NovQty3").ToString = "0" AndAlso dt.Rows(j).Item("NovQty2").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty1").ToString <> "0" Then
                                nov = dt.Rows(j).Item("NovQty2")
                            ElseIf dt.Rows(j).Item("NovQty3").ToString = "0" AndAlso dt.Rows(j).Item("NovQty2").ToString <> "0" AndAlso dt.Rows(j).Item("NovQty1").ToString = "0" Then
                                nov = dt.Rows(j).Item("NovQty2")
                            ElseIf dt.Rows(j).Item("NovQty3").ToString = "0" AndAlso dt.Rows(j).Item("NovQty2").ToString = "0" AndAlso dt.Rows(j).Item("NovQty1").ToString <> "0" Then
                                nov = dt.Rows(j).Item("NovQty1")
                            Else
                                nov = 0
                            End If

                            '===============PO November=====================
                            If dt.Rows(j).Item("Nov PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Nov PO1").ToString <> "0" Then
                                novPO = dt.Rows(j).Item("Nov PO2")
                            ElseIf dt.Rows(j).Item("Nov PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Nov PO1").ToString = "0" Then
                                novPO = dt.Rows(j).Item("Nov PO2")
                            ElseIf dt.Rows(j).Item("Nov PO2").ToString = "0" AndAlso dt.Rows(j).Item("Nov PO1").ToString <> "0" Then
                                novPO = dt.Rows(j).Item("Nov PO1")
                            Else
                                novPO = 0
                            End If

                            If dt.Rows(j).Item("DesQty3").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty2").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty1").ToString <> "0" Then
                                des = dt.Rows(j).Item("DesQty3")
                            ElseIf dt.Rows(j).Item("DesQty3").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty2").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty1").ToString <> "0" Then
                                des = dt.Rows(j).Item("DesQty3")
                            ElseIf dt.Rows(j).Item("DesQty3").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty2").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty1").ToString = "0" Then
                                des = dt.Rows(j).Item("DesQty3")
                            ElseIf dt.Rows(j).Item("DesQty3").ToString = "0" AndAlso dt.Rows(j).Item("DesQty2").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty1").ToString <> "0" Then
                                des = dt.Rows(j).Item("DesQty2")
                            ElseIf dt.Rows(j).Item("DesQty3").ToString = "0" AndAlso dt.Rows(j).Item("DesQty2").ToString <> "0" AndAlso dt.Rows(j).Item("DesQty1").ToString = "0" Then
                                des = dt.Rows(j).Item("DesQty2")
                            ElseIf dt.Rows(j).Item("DesQty3").ToString = "0" AndAlso dt.Rows(j).Item("DesQty2").ToString = "0" AndAlso dt.Rows(j).Item("DesQty1").ToString <> "0" Then
                                des = dt.Rows(j).Item("DesQty1")
                            Else
                                des = 0
                            End If

                            '===============PO Desember=====================
                            If dt.Rows(j).Item("Des PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Des PO1").ToString <> "0" Then
                                desPO = dt.Rows(j).Item("Des PO2")
                            ElseIf dt.Rows(j).Item("Des PO2").ToString <> "0" AndAlso dt.Rows(j).Item("Des PO1").ToString = "0" Then
                                desPO = dt.Rows(j).Item("Des PO2")
                            ElseIf dt.Rows(j).Item("Des PO2").ToString = "0" AndAlso dt.Rows(j).Item("Des PO1").ToString <> "0" Then
                                desPO = dt.Rows(j).Item("Des PO1")
                            Else
                                desPO = 0
                            End If

                            '========================= Price ==================
                            If dt.Rows(j).Item("JanHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString <> "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga3")
                            ElseIf dt.Rows(j).Item("JanHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString <> "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga3")
                            ElseIf dt.Rows(j).Item("JanHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString = "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga3")
                            ElseIf dt.Rows(j).Item("JanHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString <> "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga2")
                            ElseIf dt.Rows(j).Item("JanHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString = "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga2")
                            ElseIf dt.Rows(j).Item("JanHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JanHarga2").ToString = "0" AndAlso dt.Rows(j).Item("JanHarga1").ToString <> "0" Then
                                JanPrice = dt.Rows(j).Item("JanHarga1")
                            Else
                                JanPrice = 0
                            End If


                            If dt.Rows(j).Item("FebHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString <> "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga3")
                            ElseIf dt.Rows(j).Item("FebHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString <> "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga3")
                            ElseIf dt.Rows(j).Item("FebHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString = "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga3")
                            ElseIf dt.Rows(j).Item("FebHarga3").ToString = "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString <> "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga2")
                            ElseIf dt.Rows(j).Item("FebHarga3").ToString = "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString = "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga2")
                            ElseIf dt.Rows(j).Item("FebHarga3").ToString = "0" AndAlso dt.Rows(j).Item("FebHarga2").ToString = "0" AndAlso dt.Rows(j).Item("FebHarga1").ToString <> "0" Then
                                FebPrice = dt.Rows(j).Item("FebHarga1")
                            Else
                                FebPrice = 0
                            End If

                            If dt.Rows(j).Item("MarHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString <> "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga3")
                            ElseIf dt.Rows(j).Item("MarHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString <> "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga3")
                            ElseIf dt.Rows(j).Item("MarHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString = "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga3")
                            ElseIf dt.Rows(j).Item("MarHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString <> "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga2")
                            ElseIf dt.Rows(j).Item("MarHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString = "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga2")
                            ElseIf dt.Rows(j).Item("MarHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MarHarga2").ToString = "0" AndAlso dt.Rows(j).Item("MarHarga1").ToString <> "0" Then
                                MarPrice = dt.Rows(j).Item("MarHarga1")
                            Else
                                MarPrice = 0
                            End If


                            If dt.Rows(j).Item("AprHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString <> "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga3")
                            ElseIf dt.Rows(j).Item("AprHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString <> "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga3")
                            ElseIf dt.Rows(j).Item("AprHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString = "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga3")
                            ElseIf dt.Rows(j).Item("AprHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString <> "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga2")
                            ElseIf dt.Rows(j).Item("AprHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString = "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga2")
                            ElseIf dt.Rows(j).Item("AprHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AprHarga2").ToString = "0" AndAlso dt.Rows(j).Item("AprHarga1").ToString <> "0" Then
                                AprPrice = dt.Rows(j).Item("AprHarga1")
                            Else
                                AprPrice = 0
                            End If

                            If dt.Rows(j).Item("MeiHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString <> "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga3")
                            ElseIf dt.Rows(j).Item("MeiHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString <> "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga3")
                            ElseIf dt.Rows(j).Item("MeiHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString = "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga3")
                            ElseIf dt.Rows(j).Item("MeiHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString <> "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga2")
                            ElseIf dt.Rows(j).Item("MeiHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString = "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga2")
                            ElseIf dt.Rows(j).Item("MeiHarga3").ToString = "0" AndAlso dt.Rows(j).Item("MeiHarga2").ToString = "0" AndAlso dt.Rows(j).Item("MeiHarga1").ToString <> "0" Then
                                MeiPrice = dt.Rows(j).Item("MeiHarga1")
                            Else
                                MeiPrice = 0
                            End If

                            If dt.Rows(j).Item("JunHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString <> "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga3")
                            ElseIf dt.Rows(j).Item("JunHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString <> "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga3")
                            ElseIf dt.Rows(j).Item("JunHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString = "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga3")
                            ElseIf dt.Rows(j).Item("JunHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString <> "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga2")
                            ElseIf dt.Rows(j).Item("JunHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString = "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga2")
                            ElseIf dt.Rows(j).Item("JunHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JunHarga2").ToString = "0" AndAlso dt.Rows(j).Item("JunHarga1").ToString <> "0" Then
                                JunPrice = dt.Rows(j).Item("JunHarga1")
                            Else
                                JunPrice = 0
                            End If

                            If dt.Rows(j).Item("JulHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString <> "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga3")
                            ElseIf dt.Rows(j).Item("JulHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString <> "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga3")
                            ElseIf dt.Rows(j).Item("JulHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString = "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga3")
                            ElseIf dt.Rows(j).Item("JulHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString <> "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga2")
                            ElseIf dt.Rows(j).Item("JulHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString = "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga2")
                            ElseIf dt.Rows(j).Item("JulHarga3").ToString = "0" AndAlso dt.Rows(j).Item("JulHarga2").ToString = "0" AndAlso dt.Rows(j).Item("JulHarga1").ToString <> "0" Then
                                JulPrice = dt.Rows(j).Item("JulHarga1")
                            Else
                                JulPrice = 0
                            End If

                            If dt.Rows(j).Item("AgtHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString <> "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga3")
                            ElseIf dt.Rows(j).Item("AgtHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString <> "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga3")
                            ElseIf dt.Rows(j).Item("AgtHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString = "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga3")
                            ElseIf dt.Rows(j).Item("AgtHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString <> "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga2")
                            ElseIf dt.Rows(j).Item("AgtHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString = "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga2")
                            ElseIf dt.Rows(j).Item("AgtHarga3").ToString = "0" AndAlso dt.Rows(j).Item("AgtHarga2").ToString = "0" AndAlso dt.Rows(j).Item("AgtHarga1").ToString <> "0" Then
                                AgtPrice = dt.Rows(j).Item("AgtHarga1")
                            Else
                                AgtPrice = 0
                            End If

                            If dt.Rows(j).Item("SepHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString <> "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga3")
                            ElseIf dt.Rows(j).Item("SepHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString <> "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga3")
                            ElseIf dt.Rows(j).Item("SepHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString = "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga3")
                            ElseIf dt.Rows(j).Item("SepHarga3").ToString = "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString <> "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga2")
                            ElseIf dt.Rows(j).Item("SepHarga3").ToString = "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString = "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga2")
                            ElseIf dt.Rows(j).Item("SepHarga3").ToString = "0" AndAlso dt.Rows(j).Item("SepHarga2").ToString = "0" AndAlso dt.Rows(j).Item("SepHarga1").ToString <> "0" Then
                                SepPrice = dt.Rows(j).Item("SepHarga1")
                            Else
                                SepPrice = 0
                            End If

                            If dt.Rows(j).Item("oktHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString <> "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga3")
                            ElseIf dt.Rows(j).Item("oktHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString <> "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga3")
                            ElseIf dt.Rows(j).Item("oktHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString = "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga3")
                            ElseIf dt.Rows(j).Item("oktHarga3").ToString = "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString <> "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga2")
                            ElseIf dt.Rows(j).Item("oktHarga3").ToString = "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString = "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga2")
                            ElseIf dt.Rows(j).Item("oktHarga3").ToString = "0" AndAlso dt.Rows(j).Item("oktHarga2").ToString = "0" AndAlso dt.Rows(j).Item("oktHarga1").ToString <> "0" Then
                                OktPrice = dt.Rows(j).Item("oktHarga1")
                            Else
                                OktPrice = 0
                            End If

                            If dt.Rows(j).Item("NovHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString <> "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga3")
                            ElseIf dt.Rows(j).Item("NovHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString <> "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga3")
                            ElseIf dt.Rows(j).Item("NovHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString = "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga3")
                            ElseIf dt.Rows(j).Item("NovHarga3").ToString = "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString <> "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga2")
                            ElseIf dt.Rows(j).Item("NovHarga3").ToString = "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString = "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga2")
                            ElseIf dt.Rows(j).Item("NovHarga3").ToString = "0" AndAlso dt.Rows(j).Item("NovHarga2").ToString = "0" AndAlso dt.Rows(j).Item("NovHarga1").ToString <> "0" Then
                                NovPrice = dt.Rows(j).Item("NovHarga1")
                            Else
                                NovPrice = 0
                            End If

                            If dt.Rows(j).Item("DesHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString <> "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga3")
                            ElseIf dt.Rows(j).Item("DesHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString <> "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga3")
                            ElseIf dt.Rows(j).Item("DesHarga3").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString = "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga3")
                            ElseIf dt.Rows(j).Item("DesHarga3").ToString = "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString <> "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga2")
                            ElseIf dt.Rows(j).Item("DesHarga3").ToString = "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString <> "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString = "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga2")
                            ElseIf dt.Rows(j).Item("DesHarga3").ToString = "0" AndAlso dt.Rows(j).Item("DesHarga2").ToString = "0" AndAlso dt.Rows(j).Item("DesHarga1").ToString <> "0" Then
                                DesPrice = dt.Rows(j).Item("DesHarga1")
                            Else
                                DesPrice = 0
                            End If

                            Exit For
                        End If
                    Next

                    With ObjSalesdetail
                        '.bomId = bomidH1
                        If level0 = "" AndAlso level1 <> "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" Then
                            .invtid = level1
                            .level = "level1"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 <> "" AndAlso level3 = "" AndAlso level4 = "" Then
                            .invtid = level2
                            .level = "level2"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 <> "" AndAlso level4 = "" Then
                            .invtid = level3
                            .level = "level3"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 <> "" Then
                            .invtid = level4
                            .level = "level4"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level4 <> "" Then
                            .invtid = level5
                            .level = "level5"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level5 = "" AndAlso level6 <> "" Then
                            .invtid = level6
                            .level = "level6"
                        ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level5 = "" AndAlso level6 = "" AndAlso level7 <> "" Then
                            .invtid = level7
                            .level = "level7"
                        End If

                        .descr = descr
                        .unit = unit
                        Dim QtyJan = qty * jan
                        Dim POJan = qty * janPO
                        Dim QtyFeb = qty * feb
                        Dim POFeb = qty * febPO
                        Dim QtyMar = qty * mar
                        Dim POMar = qty * marPO
                        Dim QtyApr = qty * apr
                        Dim POApr = qty * aprPO
                        Dim QtyMei = qty * mei
                        Dim POMei = qty * meiPO
                        Dim QtyJun = qty * jun
                        Dim POJun = qty * junPO
                        Dim QtyJul = qty * jul
                        Dim POJul = qty * julPO
                        Dim QtyAgt = qty * agt
                        Dim POAgt = qty * agtPO
                        Dim QtySep = qty * sep
                        Dim POSep = qty * sepPO
                        Dim QtyOkt = qty * okt
                        Dim POOkt = qty * oktPO
                        Dim QtyNov = qty * nov
                        Dim PONov = qty * novPO
                        Dim QtyDes = qty * des
                        Dim PODes = qty * desPO

                        Dim JanPrice1 As Double = qty * JanPrice
                        Dim FebPrice1 As Double = qty * FebPrice
                        Dim MarPrice1 As Double = qty * MarPrice
                        Dim AprPrice1 As Double = qty * AprPrice
                        Dim MeiPrice1 As Double = qty * MeiPrice
                        Dim JunPrice1 As Double = qty * JunPrice
                        Dim JulPrice1 As Double = qty * JulPrice
                        Dim AgtPrice1 As Double = qty * AgtPrice
                        Dim SepPrice1 As Double = qty * SepPrice
                        Dim OktPrice1 As Double = qty * OktPrice
                        Dim NovPrice1 As Double = qty * NovPrice
                        Dim DesPrice1 As Double = qty * DesPrice
                        Dim IsExist As Boolean = False
                        If CmbSales.SelectedIndex = 0 Then

                            If Bulan1 = 1 And Bulan2 = 1 Then
                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                            ElseIf Bulan1 = 1 And Bulan2 = 2 Then
                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                            ElseIf Bulan1 = 1 And Bulan2 = 3 Then
                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                            ElseIf Bulan1 = 1 And Bulan2 = 4 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 5 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyJan, POJan, "1", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 2 And Bulan2 = 2 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 3 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 4 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 5 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyFeb, POFeb, "2", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 3 And Bulan2 = 3 Then


                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 4 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 5 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyMar, POMar, "3", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 4 And Bulan2 = 4 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 5 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyApr, POApr, "4", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 5 And Bulan2 = 5 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyMei, POMei, "5", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 6 And Bulan2 = 6 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyJun, POJun, "6", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 7 And Bulan2 = 7 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyJul, POJul, "7", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 8 And Bulan2 = 8 Then

                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyAgt, POAgt, "8", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 9 And Bulan2 = 9 Then

                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtySep, POSep, "9", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 10 And Bulan2 = 10 Then

                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)

                            ElseIf Bulan1 = 10 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 10 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyOkt, POOkt, "10", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 11 And Bulan2 = 11 Then

                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)

                            ElseIf Bulan1 = 11 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyNov, PONov, "11", strTahun)
                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If

                            If Bulan1 = 12 And Bulan2 = 12 Then

                                .InsertCalculatedForecastDetails(Id, QtyDes, PODes, "12", strTahun)

                            End If
                        Else

                            If Bulan1 = 1 And Bulan2 = 1 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 2 Then
                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 3 Then
                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 4 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 5 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 1 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, JanPrice1, "1", strTahun)
                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 2 And Bulan2 = 2 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 3 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 4 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 5 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 2 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, FebPrice1, "2", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 3 And Bulan2 = 3 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 4 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 5 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 3 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "3", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 4 And Bulan2 = 4 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 5 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 4 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, AprPrice1, "4", strTahun)
                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 5 And Bulan2 = 5 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 5 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, MeiPrice1, "5", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 6 And Bulan2 = 6 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 6 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, JunPrice1, "6", strTahun)
                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 7 And Bulan2 = 7 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 7 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, JulPrice1, "7", strTahun)
                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 8 And Bulan2 = 8 Then

                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 8 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, AgtPrice1, "8", strTahun)
                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 9 And Bulan2 = 9 Then

                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 9 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, SepPrice1, "9", strTahun)
                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 10 And Bulan2 = 10 Then

                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)

                            ElseIf Bulan1 = 10 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 10 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, OktPrice1, "10", strTahun)
                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 11 And Bulan2 = 11 Then

                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)

                            ElseIf Bulan1 = 11 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, NovPrice1, "11", strTahun)
                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If

                            If Bulan1 = 12 And Bulan2 = 12 Then

                                .InsertCalculatedBudgetDetails(Id, DesPrice1, "12", strTahun)

                            End If
                        End If
                    End With
                End If
                Status = False
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Throw ex
        End Try
    End Sub
    Private Sub proses_semester1(Bulan1 As String, Bulan2 As String)
        Dim Id As Integer = 0
        Dim dt1 As New DataTable
        dt1 = ObjSales.GetForecastSemester1(strTahun, "", "")
        If dt1.Rows.Count = 0 Then
            XtraMessageBox.Show("Data to calculate is empty !")
            Exit Sub
        End If

    End Sub

    Private Async Sub btnPrioses1_Click(sender As Object, e As EventArgs) Handles btnPrioses1.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            Await Task.Run(Sub() CalculatedBoM())
            SplashScreenManager.CloseForm()
            MsgBox("Process Done !")
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
