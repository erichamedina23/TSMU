Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Public Class FrmSystemLookUpCalculateSales
    Dim fc_class As New clsSales_Budget
    Dim GridData As DataTable = Nothing
    Dim Gridfilter As DataTable = Nothing
    Dim a As Integer = 0
    Dim b As Integer = 0
    Dim _class As New clsSalesForecastCalculate
    Dim _classdetail As New clsCalculateBoMdetail
    Dim _clsTrans As New clsCalculateBoMTrans
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal dt As DataTable)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
    End Sub
    ReadOnly Property Tahun As String
        Get
            Return _cmbTahun.Text.Trim
        End Get
    End Property
    ReadOnly Property Customer As String
        Get
            Return _cmbSemester.Text.Trim
        End Get
    End Property
    Private Sub FrmSystemLookUpCalculate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboTahun()
        TabControl1.TabPages(0).BackColor = tabcolour
        ProgressBar1.Visible = False
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        _cmbTahun.Items.Clear()
        For Each var As String In tahun
            _cmbTahun.Items.Add(var)
        Next
    End Sub
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
    Private Async Sub _btnExport_Click(sender As Object, e As EventArgs) Handles _btnExport.Click
        Try
            If ProgressBar1.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            'Cursor = Cursors.WaitCursor
            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() CalculatedBoM())
            MsgBox("Process Done !")

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Dim strSemester As Integer
    Dim strTahun As String
    Private Sub CalculatedBoM()
        Try

            Invoke(Sub()
                       strSemester = _cmbSemester.SelectedIndex
                       strTahun = _cmbTahun.Text
                   End Sub)
            If strTahun = "" Then
                Throw New Exception("Silahkan pilih tahun !")
            End If
            If strSemester = 1 Then
                Dim IsBudgetAlreadyCalculated As Boolean
                IsBudgetAlreadyCalculated = _class.IsForecastSemester1Exist(strTahun, strSemester, "")
                If IsBudgetAlreadyCalculated Then
                    If MsgBox("Forecast untuk tahun " & strTahun & " semester " & strSemester & " sudah di hitung, Calculate ulang ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                        _class.DeleteForecastByYearAndSemester(strTahun, strSemester, "")
                        proses_semester1()
                    Else
                        ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
                        Exit Sub
                    End If
                Else
                    proses_semester1()
                End If

            ElseIf strSemester = 2 Then
                Dim IsBudgetAlreadyCalculated As Boolean
                IsBudgetAlreadyCalculated = _class.IsForecastSemester1Exist(strTahun, strSemester, "")
                If IsBudgetAlreadyCalculated Then
                    If MsgBox("Forecast untuk tahun " & strTahun & " semester " & strSemester & " sudah di hitung, Calculate ulang ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                        _class.DeleteForecastByYearAndSemester(strTahun, strSemester, "")
                        proses_semester2()
                    Else
                        ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
                        Exit Sub
                    End If
                Else
                    proses_semester2()
                End If
            Else
                If strPesan1 = "" AndAlso strPesan2 = "" Then
                    proses_semester1()
                    proses_semester2()
                Else
                    Throw New Exception(IIf(strPesan1 = "", strPesan2, strPesan1))
                End If
            End If
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
            'Cursor = Cursors.Default

        Catch ex As Exception
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
            'Cursor = Cursors.Default
            Throw ex
        End Try
    End Sub
    Dim strPesan1 As String
    Dim strPesan2 As String
    Private Sub proses_semester2()
        Dim Id As Integer = 0
        Dim dt2 As New DataTable
        dt2 = _class.GetForecasttSemester2(strTahun)
        If dt2.Rows.Count = 0 Then
            strPesan1 = "Data to calculate is empty !"
            Exit Sub
        End If
        For i As Integer = 0 To GridData.Rows.Count - 1
            Dim bomidH As String = ""
            Dim invtid As String = ""
            Dim descr As String = ""
            Dim unit As String = ""
            Dim qty As Single = 0
            Dim po As Single = 0
            Dim level0 As String = ""
            Dim level1 As String = ""
            Dim level2 As String = ""
            Dim level3 As String = ""
            Dim level4 As String = ""
            Dim level5 As String = ""
            Dim level6 As String = ""
            Dim level7 As String = ""
            'bomidH = GridData.Rows(i).Item("Bom ID").ToString
            'invtid = GridData.Rows(i).Item("Bom ID").ToString
            descr = GridData.Rows(i).Item("Description").ToString
            unit = GridData.Rows(i).Item("Unit").ToString
            qty = GridData.Rows(i).Item("Qty").ToString
            level0 = GridData.Rows(i).Item("Level 0").ToString
            level1 = GridData.Rows(i).Item("Level 1").ToString
            level2 = GridData.Rows(i).Item("Level 2").ToString
            level3 = GridData.Rows(i).Item("Level 3").ToString
            level4 = GridData.Rows(i).Item("Level 4").ToString
            level5 = GridData.Rows(i).Item("Level 5").ToString
            level6 = GridData.Rows(i).Item("Level 6").ToString
            level7 = GridData.Rows(i).Item("Level 7").ToString
            'qty = GridData.Rows(i).Item("Qty")

            If level0 <> "" Then
                bomidH1 = bomidH
                inv = level0
                Dim strYear As String = ""
                Dim strCust As String = ""
                Invoke(Sub()
                           strYear = _cmbTahun.Text
                           strCust = _cmbSemester.Text
                       End Sub)
                With _class
                    .invtid = level0
                    .descr = descr
                    .Semester = "2"
                    .Tahun = strYear
                    .QtyBoM = 0
                    Id = .InsertHeader()
                End With

            Else
                For j As Integer = 0 To dt2.Rows.Count - 1
                    Dim invtidD As String = ""
                    invtid = dt2.Rows(j).Item("invtid").ToString
                    jul = 0
                    agt = 0
                    sep = 0
                    okt = 0
                    nov = 0
                    des = 0
                    julPO = 0
                    agtPO = 0
                    sepPO = 0
                    oktPO = 0
                    novPO = 0
                    desPO = 0
                    If inv = invtid Then

                        If dt2.Rows(j).Item("jul_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString <> "0" Then
                            jul = dt2.Rows(j).Item("jul_qty03")
                        ElseIf dt2.Rows(j).Item("jul_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString = "0" Then
                            jul = dt2.Rows(j).Item("jul_qty03")
                        ElseIf dt2.Rows(j).Item("jul_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString = "0" Then
                            jul = dt2.Rows(j).Item("jul_qty03")
                        ElseIf dt2.Rows(j).Item("jul_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString <> "0" Then
                            jul = dt2.Rows(j).Item("jul_qty02")
                        ElseIf dt2.Rows(j).Item("jul_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString = "0" Then
                            jul = dt2.Rows(j).Item("jul_qty02")
                        ElseIf dt2.Rows(j).Item("jul_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("jul_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("jul_qty01").ToString <> "0" Then
                            jul = dt2.Rows(j).Item("jul_qty01")
                        Else
                            jul = 0
                        End If

                        '===============PO Juli=====================
                        If dt2.Rows(j).Item("jul_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_po01").ToString <> "0" Then
                            julPO = dt2.Rows(j).Item("jul_po02")
                        ElseIf dt2.Rows(j).Item("jul_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("jul_po01").ToString = "0" Then
                            julPO = dt2.Rows(j).Item("jul_po02")
                        ElseIf dt2.Rows(j).Item("jul_po02").ToString = "0" AndAlso dt2.Rows(j).Item("jul_po01").ToString <> "0" Then
                            julPO = dt2.Rows(j).Item("jul_po01")
                        Else
                            julPO = 0
                        End If


                        If dt2.Rows(j).Item("agt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString <> "0" Then
                            agt = dt2.Rows(j).Item("agt_qty03")
                        ElseIf dt2.Rows(j).Item("agt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString = "0" Then
                            agt = dt2.Rows(j).Item("agt_qty03")
                        ElseIf dt2.Rows(j).Item("agt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString = "0" Then
                            agt = dt2.Rows(j).Item("agt_qty03")
                        ElseIf dt2.Rows(j).Item("agt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString <> "0" Then
                            agt = dt2.Rows(j).Item("agt_qty02")
                        ElseIf dt2.Rows(j).Item("agt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString = "0" Then
                            agt = dt2.Rows(j).Item("agt_qty02")
                        ElseIf dt2.Rows(j).Item("agt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("agt_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("agt_qty01").ToString <> "0" Then
                            agt = dt2.Rows(j).Item("agt_qty01")
                        Else
                            agt = 0
                        End If

                        '===============PO Agustus=====================
                        If dt2.Rows(j).Item("agt_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_po01").ToString <> "0" Then
                            agtPO = dt2.Rows(j).Item("agt_po02")
                        ElseIf dt2.Rows(j).Item("agt_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("agt_po01").ToString = "0" Then
                            agtPO = dt2.Rows(j).Item("agt_po02")
                        ElseIf dt2.Rows(j).Item("agt_po02").ToString = "0" AndAlso dt2.Rows(j).Item("agt_po01").ToString <> "0" Then
                            agtPO = dt2.Rows(j).Item("agt_po01")
                        Else
                            agtPO = 0
                        End If

                        If dt2.Rows(j).Item("sep_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString <> "0" Then
                            sep = dt2.Rows(j).Item("sep_qty03")
                        ElseIf dt2.Rows(j).Item("sep_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString = "0" Then
                            sep = dt2.Rows(j).Item("sep_qty03")
                        ElseIf dt2.Rows(j).Item("sep_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString = "0" Then
                            sep = dt2.Rows(j).Item("sep_qty03")
                        ElseIf dt2.Rows(j).Item("sep_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString <> "0" Then
                            sep = dt2.Rows(j).Item("sep_qty02")
                        ElseIf dt2.Rows(j).Item("sep_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString = "0" Then
                            sep = dt2.Rows(j).Item("sep_qty02")
                        ElseIf dt2.Rows(j).Item("sep_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("sep_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("sep_qty01").ToString <> "0" Then
                            sep = dt2.Rows(j).Item("sep_qty01")
                        Else
                            sep = 0
                        End If

                        '===============PO September=====================
                        If dt2.Rows(j).Item("sep_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_po01").ToString <> "0" Then
                            sepPO = dt2.Rows(j).Item("sep_po02")
                        ElseIf dt2.Rows(j).Item("sep_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("sep_po01").ToString = "0" Then
                            sepPO = dt2.Rows(j).Item("sep_po02")
                        ElseIf dt2.Rows(j).Item("sep_po02").ToString = "0" AndAlso dt2.Rows(j).Item("sep_po01").ToString <> "0" Then
                            sepPO = dt2.Rows(j).Item("sep_po01")
                        Else
                            sepPO = 0
                        End If

                        If dt2.Rows(j).Item("okt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString <> "0" Then
                            okt = dt2.Rows(j).Item("okt_qty03")
                        ElseIf dt2.Rows(j).Item("okt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString = "0" Then
                            okt = dt2.Rows(j).Item("okt_qty03")
                        ElseIf dt2.Rows(j).Item("okt_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString = "0" Then
                            okt = dt2.Rows(j).Item("okt_qty03")
                        ElseIf dt2.Rows(j).Item("okt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString <> "0" Then
                            okt = dt2.Rows(j).Item("okt_qty02")
                        ElseIf dt2.Rows(j).Item("okt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString = "0" Then
                            okt = dt2.Rows(j).Item("okt_qty02")
                        ElseIf dt2.Rows(j).Item("okt_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("okt_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("okt_qty01").ToString <> "0" Then
                            okt = dt2.Rows(j).Item("okt_qty01")
                        Else
                            okt = 0
                        End If


                        '===============PO Oktober=====================
                        If dt2.Rows(j).Item("okt_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_po01").ToString <> "0" Then
                            oktPO = dt2.Rows(j).Item("okt_po02")
                        ElseIf dt2.Rows(j).Item("okt_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("okt_po01").ToString = "0" Then
                            oktPO = dt2.Rows(j).Item("okt_po02")
                        ElseIf dt2.Rows(j).Item("okt_po02").ToString = "0" AndAlso dt2.Rows(j).Item("okt_po01").ToString <> "0" Then
                            oktPO = dt2.Rows(j).Item("okt_po01")
                        Else
                            oktPO = 0
                        End If

                        If dt2.Rows(j).Item("nov_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString <> "0" Then
                            nov = dt2.Rows(j).Item("nov_qty03")
                        ElseIf dt2.Rows(j).Item("nov_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString = "0" Then
                            nov = dt2.Rows(j).Item("nov_qty03")
                        ElseIf dt2.Rows(j).Item("nov_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString = "0" Then
                            nov = dt2.Rows(j).Item("nov_qty03")
                        ElseIf dt2.Rows(j).Item("nov_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString <> "0" Then
                            nov = dt2.Rows(j).Item("nov_qty02")
                        ElseIf dt2.Rows(j).Item("nov_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString = "0" Then
                            nov = dt2.Rows(j).Item("nov_qty02")
                        ElseIf dt2.Rows(j).Item("nov_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("nov_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("nov_qty01").ToString <> "0" Then
                            nov = dt2.Rows(j).Item("nov_qty01")
                        Else
                            nov = 0
                        End If

                        '===============PO November=====================
                        If dt2.Rows(j).Item("nov_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_po01").ToString <> "0" Then
                            novPO = dt2.Rows(j).Item("nov_po02")
                        ElseIf dt2.Rows(j).Item("nov_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("nov_po01").ToString = "0" Then
                            novPO = dt2.Rows(j).Item("nov_po02")
                        ElseIf dt2.Rows(j).Item("nov_po02").ToString = "0" AndAlso dt2.Rows(j).Item("nov_po01").ToString <> "0" Then
                            novPO = dt2.Rows(j).Item("nov_po01")
                        Else
                            novPO = 0
                        End If

                        If dt2.Rows(j).Item("des_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString <> "0" Then
                            des = dt2.Rows(j).Item("des_qty03")
                        ElseIf dt2.Rows(j).Item("des_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString <> "0" Then
                            des = dt2.Rows(j).Item("des_qty03")
                        ElseIf dt2.Rows(j).Item("des_qty03").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString = "0" Then
                            des = dt2.Rows(j).Item("des_qty03")
                        ElseIf dt2.Rows(j).Item("des_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString <> "0" Then
                            des = dt2.Rows(j).Item("des_qty02")
                        ElseIf dt2.Rows(j).Item("des_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString = "0" Then
                            des = dt2.Rows(j).Item("des_qty02")
                        ElseIf dt2.Rows(j).Item("des_qty03").ToString = "0" AndAlso dt2.Rows(j).Item("des_qty02").ToString = "0" AndAlso dt2.Rows(j).Item("des_qty01").ToString <> "0" Then
                            des = dt2.Rows(j).Item("des_qty01")
                        Else
                            des = 0
                        End If

                        '===============PO Desember=====================
                        If dt2.Rows(j).Item("des_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_po01").ToString <> "0" Then
                            desPO = dt2.Rows(j).Item("des_po02")
                        ElseIf dt2.Rows(j).Item("des_po02").ToString <> "0" AndAlso dt2.Rows(j).Item("des_po01").ToString = "0" Then
                            desPO = dt2.Rows(j).Item("des_po02")
                        ElseIf dt2.Rows(j).Item("des_po02").ToString = "0" AndAlso dt2.Rows(j).Item("des_po01").ToString <> "0" Then
                            desPO = dt2.Rows(j).Item("des_po01")
                        Else
                            desPO = 0
                        End If
                        Exit For
                    End If
                Next

                With _classdetail
                    .bomId = bomidH1
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

                    .Jan_qty = 0
                    .feb_qty = 0
                    .mar_qty = 0
                    .apr_qty = 0
                    .mei_qty = 0
                    .jun_qty = 0
                    .Jan_po = 0
                    .feb_po = 0
                    .mar_po = 0
                    .apr_po = 0
                    .mei_po = 0
                    .jun_po = 0

                    .jul_qty = qty * jul
                    .agt_qty = qty * agt
                    .sep_qty = qty * sep
                    .okt_qty = qty * okt
                    .nov_qty = qty * nov
                    .des_qty = qty * des
                    .jul_po = qty * julPO
                    .agt_po = qty * agtPO
                    .sep_po = qty * sepPO
                    .okt_po = qty * oktPO
                    .nov_po = qty * novPO
                    .des_po = qty * desPO
                    .InsertDetails(Id)
                End With
                '_clsTrans.Fc_classdetail.Add(_classdetail)
            End If

            '_clsTrans.InsertCalculatedBoM()
        Next
    End Sub

    Private Sub proses_semester1()
        Dim Id As Integer = 0
        Dim dt1 As New DataTable
        dt1 = _class.GetForecastSemester1(strTahun, "", "")
        If dt1.Rows.Count = 0 Then
            strPesan2 = "Data to calculate is empty !"
            Exit Sub
        End If
        For i As Integer = 0 To GridData.Rows.Count - 1
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
            'bomidH = GridData.Rows(i).Item("Bom ID").ToString
            'invtid = GridData.Rows(i).Item("Bom ID").ToString
            descr = GridData.Rows(i).Item("Description").ToString
            unit = GridData.Rows(i).Item("Unit").ToString
            qty = GridData.Rows(i).Item("Qty").ToString
            level0 = GridData.Rows(i).Item("Level 0").ToString
            level1 = GridData.Rows(i).Item("Level 1").ToString
            level2 = GridData.Rows(i).Item("Level 2").ToString
            level3 = GridData.Rows(i).Item("Level 3").ToString
            level4 = GridData.Rows(i).Item("Level 4").ToString
            level5 = GridData.Rows(i).Item("Level 5").ToString
            level6 = GridData.Rows(i).Item("Level 6").ToString
            level7 = GridData.Rows(i).Item("Level 7").ToString
            'qty = GridData.Rows(i).Item("Qty")

            If level0 <> "" Then
                'bomidH1 = bomidH
                inv = level0
                Dim strYear As String = ""
                Dim strCust As String = ""
                Invoke(Sub()
                           strYear = _cmbTahun.Text
                           strCust = _cmbSemester.Text
                       End Sub)
                With _class
                    .invtid = level0
                    .descr = descr
                    .Semester = "1"
                    .Tahun = strYear
                    .QtyBoM = 0
                    .QtyPO = 0
                    Id = .InsertHeader()
                End With

            Else
                For j As Integer = 0 To dt1.Rows.Count - 1
                    Dim invtidD As String = ""
                    invtid = dt1.Rows(j).Item("invtid").ToString
                    jan = 0
                    feb = 0
                    mar = 0
                    apr = 0
                    mei = 0
                    jun = 0
                    If inv = invtid Then
                        If dt1.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString <> "0" Then
                            jan = dt1.Rows(j).Item("jan_qty03")
                        ElseIf dt1.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString = "0" Then
                            jan = dt1.Rows(j).Item("jan_qty03")
                        ElseIf dt1.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString = "0" Then
                            jan = dt1.Rows(j).Item("jan_qty03")
                        ElseIf dt1.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString <> "0" Then
                            jan = dt1.Rows(j).Item("jan_qty02")
                        ElseIf dt1.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString = "0" Then
                            jan = dt1.Rows(j).Item("jan_qty02")
                        ElseIf dt1.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("jan_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("jan_qty01").ToString <> "0" Then
                            jan = dt1.Rows(j).Item("jan_qty01")
                        Else
                            jan = 0
                        End If

                        '===============PO Desember=====================
                        If dt1.Rows(j).Item("jan_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_po01").ToString <> "0" Then
                            janPO = dt1.Rows(j).Item("jan_po02")
                        ElseIf dt1.Rows(j).Item("jan_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("jan_po01").ToString = "0" Then
                            janPO = dt1.Rows(j).Item("jan_po02")
                        ElseIf dt1.Rows(j).Item("jan_po02").ToString = "0" AndAlso dt1.Rows(j).Item("jan_po01").ToString <> "0" Then
                            janPO = dt1.Rows(j).Item("jan_po01")
                        Else
                            janPO = 0
                        End If

                        If dt1.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString <> "0" Then
                            feb = dt1.Rows(j).Item("feb_qty03")
                        ElseIf dt1.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString = "0" Then
                            feb = dt1.Rows(j).Item("feb_qty03")
                        ElseIf dt1.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString = "0" Then
                            feb = dt1.Rows(j).Item("feb_qty03")
                        ElseIf dt1.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString <> "0" Then
                            feb = dt1.Rows(j).Item("feb_qty02")
                        ElseIf dt1.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString = "0" Then
                            feb = dt1.Rows(j).Item("feb_qty02")
                        ElseIf dt1.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("feb_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("feb_qty01").ToString <> "0" Then
                            feb = dt1.Rows(j).Item("feb_qty01")
                        Else
                            feb = 0
                        End If

                        '===============PO Februari=====================
                        If dt1.Rows(j).Item("feb_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_po01").ToString <> "0" Then
                            febPO = dt1.Rows(j).Item("feb_po02")
                        ElseIf dt1.Rows(j).Item("feb_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("feb_po01").ToString = "0" Then
                            febPO = dt1.Rows(j).Item("feb_po02")
                        ElseIf dt1.Rows(j).Item("feb_po02").ToString = "0" AndAlso dt1.Rows(j).Item("feb_po01").ToString <> "0" Then
                            febPO = dt1.Rows(j).Item("feb_po01")
                        Else
                            febPO = 0
                        End If

                        If dt1.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString <> "0" Then
                            mar = dt1.Rows(j).Item("mar_qty03")
                        ElseIf dt1.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString = "0" Then
                            mar = dt1.Rows(j).Item("mar_qty03")
                        ElseIf dt1.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString = "0" Then
                            mar = dt1.Rows(j).Item("mar_qty03")
                        ElseIf dt1.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString <> "0" Then
                            mar = dt1.Rows(j).Item("mar_qty02")
                        ElseIf dt1.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString = "0" Then
                            mar = dt1.Rows(j).Item("mar_qty02")
                        ElseIf dt1.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mar_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("mar_qty01").ToString <> "0" Then
                            mar = dt1.Rows(j).Item("mar_qty01")
                        Else
                            mar = 0
                        End If

                        '===============PO Maret=====================
                        If dt1.Rows(j).Item("mar_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_po01").ToString <> "0" Then
                            marPO = dt1.Rows(j).Item("mar_po02")
                        ElseIf dt1.Rows(j).Item("mar_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("mar_po01").ToString = "0" Then
                            marPO = dt1.Rows(j).Item("mar_po02")
                        ElseIf dt1.Rows(j).Item("mar_po02").ToString = "0" AndAlso dt1.Rows(j).Item("mar_po01").ToString <> "0" Then
                            marPO = dt1.Rows(j).Item("mar_po01")
                        Else
                            marPO = 0
                        End If

                        If dt1.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString <> "0" Then
                            apr = dt1.Rows(j).Item("apr_qty03")
                        ElseIf dt1.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString = "0" Then
                            apr = dt1.Rows(j).Item("apr_qty03")
                        ElseIf dt1.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString = "0" Then
                            apr = dt1.Rows(j).Item("apr_qty03")
                        ElseIf dt1.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString <> "0" Then
                            apr = dt1.Rows(j).Item("apr_qty02")
                        ElseIf dt1.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString = "0" Then
                            apr = dt1.Rows(j).Item("apr_qty02")
                        ElseIf dt1.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("apr_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("apr_qty01").ToString <> "0" Then
                            apr = dt1.Rows(j).Item("apr_qty01")
                        Else
                            apr = 0
                        End If

                        '===============PO April=====================
                        If dt1.Rows(j).Item("apr_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_po01").ToString <> "0" Then
                            aprPO = dt1.Rows(j).Item("apr_po02")
                        ElseIf dt1.Rows(j).Item("apr_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("apr_po01").ToString = "0" Then
                            aprPO = dt1.Rows(j).Item("apr_po02")
                        ElseIf dt1.Rows(j).Item("apr_po02").ToString = "0" AndAlso dt1.Rows(j).Item("apr_po01").ToString <> "0" Then
                            aprPO = dt1.Rows(j).Item("apr_po01")
                        Else
                            aprPO = 0
                        End If

                        If dt1.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString <> "0" Then
                            mei = dt1.Rows(j).Item("mei_qty03")
                        ElseIf dt1.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString = "0" Then
                            mei = dt1.Rows(j).Item("mei_qty03")
                        ElseIf dt1.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString = "0" Then
                            mei = dt1.Rows(j).Item("mei_qty03")
                        ElseIf dt1.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString <> "0" Then
                            mei = dt1.Rows(j).Item("mei_qty02")
                        ElseIf dt1.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString = "0" Then
                            mei = dt1.Rows(j).Item("mei_qty02")
                        ElseIf dt1.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("mei_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("mei_qty01").ToString <> "0" Then
                            mei = dt1.Rows(j).Item("mei_qty01")
                        Else
                            mei = 0
                        End If

                        '===============PO Mei=====================
                        If dt1.Rows(j).Item("mei_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_po01").ToString <> "0" Then
                            meiPO = dt1.Rows(j).Item("mei_po02")
                        ElseIf dt1.Rows(j).Item("mei_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("mei_po01").ToString = "0" Then
                            meiPO = dt1.Rows(j).Item("mei_po02")
                        ElseIf dt1.Rows(j).Item("mei_po02").ToString = "0" AndAlso dt1.Rows(j).Item("mei_po01").ToString <> "0" Then
                            meiPO = dt1.Rows(j).Item("mei_po01")
                        Else
                            meiPO = 0
                        End If

                        If dt1.Rows(j).Item("jun_qty03").ToString <> "0" AndAlso dt1.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jun_qty01").ToString <> "0" Then
                            jun = dt1.Rows(j).Item("jun_qty03")
                        ElseIf dt1.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt1.Rows(j).Item("jun_qty01").ToString <> "0" Then
                            jun = dt1.Rows(j).Item("jun_qty02")
                        ElseIf dt1.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt1.Rows(j).Item("jun_qty02").ToString = "0" AndAlso dt1.Rows(j).Item("jun_qty01").ToString <> "0" Then
                            jun = dt1.Rows(j).Item("jun_qty01")
                        Else
                            jun = 0
                        End If

                        '===============PO Jun=====================
                        If dt1.Rows(j).Item("Jun_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("Jun_po01").ToString <> "0" Then
                            junPO = dt1.Rows(j).Item("Jun_po02")
                        ElseIf dt1.Rows(j).Item("Jun_po02").ToString <> "0" AndAlso dt1.Rows(j).Item("Jun_po01").ToString = "0" Then
                            junPO = dt1.Rows(j).Item("Jun_po02")
                        ElseIf dt1.Rows(j).Item("Jun_po02").ToString = "0" AndAlso dt1.Rows(j).Item("Jun_po01").ToString <> "0" Then
                            junPO = dt1.Rows(j).Item("Jun_po01")
                        Else
                            junPO = 0
                        End If

                        Exit For
                    End If
                Next

                With _classdetail
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

                    .Jan_qty = qty * jan
                    .feb_qty = qty * feb
                    .mar_qty = qty * jan
                    .apr_qty = qty * apr
                    .mei_qty = qty * mei
                    .jun_qty = qty * jun
                    .Jan_po = qty * janPO
                    .feb_po = qty * febPO
                    .mar_po = qty * janPO
                    .apr_po = qty * aprPO
                    .mei_po = qty * meiPO
                    .jun_po = qty * junPO
                    .jul_qty = 0
                    .agt_qty = 0
                    .sep_qty = 0
                    .okt_qty = 0
                    .nov_qty = 0
                    .des_qty = 0
                    .jul_po = 0
                    .agt_po = 0
                    .sep_po = 0
                    .okt_po = 0
                    .nov_po = 0
                    .des_po = 0
                    .InsertDetails(Id)
                End With
                '_clsTrans.Fc_classdetail.Add(_classdetail)
            End If

            '_clsTrans.InsertCalculatedBoM()


        Next
    End Sub
End Class