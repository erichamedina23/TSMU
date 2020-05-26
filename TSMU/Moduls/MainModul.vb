Imports System.Data.SqlClient
Imports System.Xml
Imports System.Collections.ObjectModel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting

Module MainModul
#Region "--Global Enumerations--"

    Public Enum MessageEnum As Integer
        SimpanBerhasil = 1000
        SimpanGagal = 1001
        HapusBerhasil = 3000
        HapusGagal = 3001
        PropertyKosong = 555
        ListPropertyKosong = 556
        HakAksesGagal = 2001
        HakInsertGagal = 2002
        HakUpdateGagal = 2003
        HakDeleteGagal = 2004
        HakSpesialGagal = 2005
        DataTidakKetemu = 2006
        UserPassTidakCocok = 2007
        InsertGagal = 2008
        DataTelahDigunakan = 2010
        ValidasiInsertGagal = 4000
        ValidasiUpdateGagal = 4001
        ValidasiDeleteGagal = 4002
        UpdateBerhasil = 5000
        UpdateGagal = 50001
    End Enum

    Public Enum MessageTypeEnum As Byte
        NormalMessage = 0
        ErrorMessage = 1
        NotBoxMessage = 2
    End Enum

    Public Enum TagEnum As Byte
        DataType = 0
        OldData = 1
    End Enum

    Public Enum SeqMaintenance As Byte
        dailyfirm = 0
        hold = 1
        unhold = 2
        resequence = 3
        nonactive = 4
        delete = 5
        deleteweekly = 6
    End Enum

#End Region

#Region "--Global Variables--"
    Public MyAss As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
    '# Menu Collection...
    Public MyMenus As New Collection(Of ToolStripMenuItem)
    '# Form Collection...
    Public MyForms As New Collection(Of Form)

    '# Server Instance...  Local
    Public gs_Database As String = "New_BoM"
    Public gs_DBServer As String = "10.10.1.10"
    Public gs_DBAuthMode As String = "mixed"
    Public gs_DBUserName As String = "sa"
    Public gs_DBPassword As String = "Tsc2011"
    Public gs_DBPasswordDefault As String = "Tsc2011"

    Public gs_Database1 As String = "Tsc16Application"
    Public gs_DBServer1 As String = "10.10.1.10"
    Public gs_DBAuthMode1 As String = "mixed"
    Public gs_DBUserName1 As String = "sa"
    Public gs_DBPassword1 As String = "Tsc2011"
    Public gs_DBPasswordDefault1 As String = "Tsc2011"

    Public gs_Database2 As String = "DbCKR"
    Public gs_DBServer2 As String = "10.10.3.6"
    Public gs_DBAuthMode2 As String = "mixed"
    Public gs_DBUserName2 As String = "sa"
    Public gs_DBPassword2 As String = "Tsc2011"
    Public gs_DBPasswordDefault2 As String = "Tsc2011"

    '# Server Instance Server Takagi
    '    Public gs_Database As String = "New_BoM"
    '    Public gs_DBServer As String = "10.10.1.10"
    '    Public gs_DBAuthMode As String = "mixed"
    '    Public gs_DBUserName As String = "sa"
    '    Public gs_DBPassword As String = "Tsc2011"
    '    Public gs_DBPasswordDefault As String = "Tsc2011"

    '    Public gs_Database1 As String = "Tsc16Application"
    '    Public gs_DBServer1 As String = "10.10.1.10"
    '    Public gs_DBAuthMode1 As String = "mixed"
    '    Public gs_DBUserName1 As String = "sa"
    '    Public gs_DBPassword1 As String = "Tsc2011"
    '    Public gs_DBPasswordDefault1 As String = "Tsc2011"

    '    Public gs_Database2 As String = "DbCKR"
    '    Public gs_DBServer2 As String = "10.10.3.6"
    '    Public gs_DBAuthMode2 As String = "mixed"
    '    Public gs_DBUserName2 As String = "sa"
    '    Public gs_DBPassword2 As String = "Tsc2011"
    '    Public gs_DBPasswordDefault2 As String = "Tsc2011"





    Public gs_TerminalUsername As String = ""
    Public gs_TerminalPassword As String = ""
    Public gs_AutomaticForm As String = ""
    Public gs_InstructionSetting As String = ""

    Public gi_ConnTimeOutMin As Integer = 10
    Public Const gi_DBMax As Integer = 20
    Public gs_AppID As String = "1"
    Public gs_AppFontName As String = "Segoe UI"
    Public gsi_AppFontSize As String = 8.25!

    Public gs_KodeSetting As String = "01"
    Public gc_Setting As ClassSystemConfiguration
    Public gs_CompanyName As String = "Takagi"
    Public gs_CompanyAddress As String = ""
    Public gs_CompanyPhoneNo As String = ""
    Public gs_CompanyFaxNo As String = ""

    Public tabcolour As Color = Color.FromArgb(240, 240, 240)
    Public gcl_GridFixedBlue As Color = Color.FromArgb(0, 122, 204) 'Color.BurlyWood
    Public gcl_GridFixedBack As Color = Color.FromArgb(129, 116, 99) 'Color.BurlyWood '77, 96, 130 - 207, 214, 229 - 230, 231, 232
    Public gcl_GridFixedDarkblue As Color = Color.FromArgb(77, 96, 130)
    Public gcl_GridNormalBack As Color = Color.FromArgb(203, 198, 192) 'System.Drawing.SystemColors.Window
    Public gcl_GridNormalBack1 As Color = Color.FromArgb(230, 231, 232) 'System.Drawing.SystemColors.Window
    Public gcl_GridAlternateBack As Color = Color.FromArgb(222, 219, 214) 'Color.FromArgb(-2829100)
    Public gcl_GridAlternateBack1 As Color = Color.FromArgb(207, 214, 229) 'Color.FromArgb(-2829100)
    Public gcl_GridFixedFore As Color = Color.White
    Public gcl_GridInactiveForeColor As Color = System.Drawing.SystemColors.InactiveCaptionText
    Public gcl_StokMin As Color = Color.Red
    Public gcl_StokMax As Color = Color.LightBlue

    Public SQL_MaxLKode As Integer = 10
    Public SQL_MaxLNama As Integer = 50
    Public SQL_MaxLKeterangan As Integer = 200
    Public SQL_MaxLHarga As Integer = 23
    Public SQL_MaxLTransNo As Integer = 20
    Public SQL_MaxLQty As Integer = 13
    Public SQL_MaxLTelpFax As Integer = 20
    Public SQL_MaxLPercent As Integer = 5
    Public SQL_MaxLKodePanjang As Integer = 25
    Public SQL_MaxLProperty As Integer = 20
    Public SQL_MaxLBarcode As Integer = 20
    Public SQL_MaxLTeksTampil As Integer = 20
    Public SQL_MaxLHari As Integer = 3
    Public SQL_MaxLNamaPendek As Integer = 30
    Public SQL_MaxLNomor As Integer = 4
    Public SQL_MaxLKodePrefix As Integer = 5
    Public SQL_MaxLFlag As Integer = 1
    Public SQL_MaxLDate As Integer = 8

    Public SQL_MaxVHarga As Double = 99999999999999.9
    Public SQL_MaxVQty As Double = 99999999.999
    Public SQL_MaxVPercent As Double = 999.99
    Public SQL_MaxVNomor As Double = 9999

    Public Que As String
    Public MyMinDate As Date = "2000-01-01 00:00:00"
    Public MyMaxDate As Date = "9998-12-31 23:59:59"
    Public ErrNumber As Integer = 8888


    Public gs_Error As String = ""
    Public gs_SQL As String = ""
    Public ge_Error As Exception

    Public gs_FormatPecahan As String = "#,##0.####"
    Public gs_FormatDecimal As String = "#,##0.#0"
    Public gs_FormatDecimal1 As String = "#,##0.#00000"
    Public gs_FormatBulat As String = "#,##0"
    Public gs_FormatSQLDateIn As String = "dd-MM-yyyy"
    Public gs_FormatSQLDate As String = "yyyy-MM-dd"
    Public gs_FormatGenNoDate As String = "yyyyMM"
    Public gs_FormatReportDate As String = "dd MMMM yyyy"
    Public Const gs_ALL As String = "ALL"

    Public gs_RptPaperName As String = "LetterHalfS2" '"1/2Letter" '"LetterHS2"
    Public gsg_RptWidth As Single = 803 'inc '850
    Public gsg_RptHeight As Single = 550 'inc '551
    Public gi_PrintIdx As Integer = -1
    Public gi_RptBatasRow As Integer = 15
    Public gs_ConfirmDetailOpen As String = "Form Detail already open. Do you want to close previous data?"
    Public gb_ControlFocus As Boolean = False
    Public gs_ControlFocusName As String = ""
    Public gs_ControlClickFocusName As String = ""
    Public gi_ControlFocusCounter As Integer = 0

    Public gh_Common As InstanceVariables.CommonHelper
    Public gh_Trans As InstanceVariables.TransactionHelper
    'Public gh_SQL As InstanceVariables.SQLHelper
    Public g_FirstDayOfWeek As FirstDayOfWeek = FirstDayOfWeek.Monday
    Public g_FirstWeekOfYear As FirstWeekOfYear = FirstWeekOfYear.FirstFourDays

#End Region

#Region "Transaction Variables"
    'Public gSC_Command As SqlCommand = Nothing
#End Region

#Region "Global Functions"
    Public Function GetMessage(ByVal msgType As MessageEnum) As String
        Select Case msgType
            Case MessageEnum.SimpanBerhasil
                Return "Data saved!"
            Case MessageEnum.SimpanGagal
                Return "Data cannot be saved!"
            Case MessageEnum.HapusBerhasil
                Return "Data deleted!"
            Case MessageEnum.HapusGagal
                Return "Data cannot be deleted!"
            Case MessageEnum.PropertyKosong
                Return "Data required!"
            Case MessageEnum.ListPropertyKosong
                Return "Fill data below : "
            Case MessageEnum.HakAksesGagal
                Return "Access denied!"
            Case MessageEnum.HakInsertGagal
                Return "Insert data denied!"
            Case MessageEnum.HakUpdateGagal
                Return "Update data denied!"
            Case MessageEnum.HakDeleteGagal
                Return "Delete data denied!"
            Case MessageEnum.HakSpesialGagal
                Return "Special access denied!"
            Case MessageEnum.DataTidakKetemu
                Return "Data is not found!"
            Case MessageEnum.UserPassTidakCocok
                Return "Wrong username / password!"
            Case MessageEnum.InsertGagal
                Return "Data already exists!"
            Case MessageEnum.DataTelahDigunakan
                Return "Data telah di gunakan"
            Case MessageEnum.ValidasiInsertGagal
                Return "Insert validation is failed!"
            Case MessageEnum.ValidasiUpdateGagal
                Return "Update validation is failed!"
            Case MessageEnum.ValidasiDeleteGagal
                Return "Delete validation is failed!"
            Case Else
                Return ""
        End Select
    End Function

    Public Sub ShowMessage(ByVal message As String, Optional ByVal Flag As MessageTypeEnum = MessageTypeEnum.NormalMessage, Optional ByVal ls_StackTrace As String = "")
        If ls_StackTrace <> "" Then Call WriteToErrorLog(message, gh_Common.Username, ls_StackTrace)
        If Flag = MessageTypeEnum.NormalMessage Then
            MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            'frmMain.StatMsg.ForeColor = Color.Black
        ElseIf Flag = MessageTypeEnum.ErrorMessage Then
            '# Checkbox...
            MsgBox(message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            'frmMain.StatMsg.ForeColor = Color.Red
        Else
            'frmMain.StatMsg.ForeColor = Color.Black
        End If
        'frmMain.StatMsg.Text = message
    End Sub

    Public Sub WriteToErrorLog(ByVal ls_Message As String, ByVal ls_User As String, ByVal ls_StackTrace As String)
        Dim ls_Path As String = Application.StartupPath & "\Logs\"
        Dim ls_FileName As String = "logs.txt"
        Dim lb_CheckSize As Boolean = True
        Dim ll_MaxLogByte As Long = 10000000

        Try
            If Not System.IO.Directory.Exists(ls_Path) Then
                System.IO.Directory.CreateDirectory(ls_Path)
                lb_CheckSize = False
            End If

            'check the file
            Dim fs As System.IO.FileStream = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite)
            If lb_CheckSize Then
                If fs.Length > ll_MaxLogByte Then
                    fs.Close()
                    My.Computer.FileSystem.RenameFile(ls_Path & ls_FileName, DateTime.Now.ToString("yyyyMMddHHmmss") & ls_FileName)
                    fs = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite)
                End If
            End If
            Dim s As System.IO.StreamWriter = New System.IO.StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As System.IO.FileStream = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.Append, System.IO.FileAccess.Write)
            Dim s1 As System.IO.StreamWriter = New System.IO.StreamWriter(fs1)
            Dim ls_String = ""
            Dim sb_String As New System.Text.StringBuilder

            sb_String.AppendLine("" & Application.ProductName & ";")
            sb_String.AppendLine("W: " & DateTime.Now.ToString() & ";")
            sb_String.AppendLine("U: " & ls_User & ";")
            sb_String.AppendLine("M: " & ls_Message & ";")
            sb_String.AppendLine("" & IIf(ls_StackTrace.Trim <> "", "ST: " & ls_StackTrace & ";", ""))
            s1.WriteLine(sb_String.ToString)
            's1.Write("User: " & ls_User & vbCrLf)
            's1.Write("Message: " & ls_Message & vbCrLf)
            's1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
            's1.Write("================================================" & vbCrLf)
            s1.Close()
            fs1.Close()
            sb_String = Nothing
        Catch ex As Exception
            Call ShowMessage("Write to Log Error !" & ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Public Sub WriteSalesToErrorLog(ByVal FolderType As String, ByVal Filename As String, ByVal dt As DataTable, ByVal row As Integer, ByVal col As String, ByVal ls_user As String)
        Dim ls_Path As String = Application.StartupPath & "\LogsImportExcel\" & FolderType & "\"
        Dim ls_FileName As String = Filename & ".txt"
        Dim lb_CheckSize As Boolean = True
        Dim ll_MaxLogByte As Long = 10000000

        Try
            If Not System.IO.Directory.Exists(ls_Path) Then
                System.IO.Directory.CreateDirectory(ls_Path)
                lb_CheckSize = False
            End If

            'check the file
            Dim fs As System.IO.FileStream = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite)
            If lb_CheckSize Then
                If fs.Length > ll_MaxLogByte Then
                    fs.Close()
                    My.Computer.FileSystem.RenameFile(ls_Path & ls_FileName, DateTime.Now.ToString("yyyyMMddHHmmss") & ls_FileName)
                    fs = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite)
                End If
            End If
            Dim s As System.IO.StreamWriter = New System.IO.StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As System.IO.FileStream = New System.IO.FileStream(ls_Path & ls_FileName, System.IO.FileMode.Append, System.IO.FileAccess.Write)
            Dim s1 As System.IO.StreamWriter = New System.IO.StreamWriter(fs1)
            Dim ls_String = ""
            Dim sb_String As New System.Text.StringBuilder
            sb_String.AppendLine("Date          : " & DateTime.Now.ToString() & ";")
            sb_String.AppendLine("User          : " & ls_user & ";")
            sb_String.AppendLine("Inventory ID  : " & dt.Rows(row)(col).ToString & ";")
            s1.WriteLine(sb_String.ToString)
            s1.Close()
            fs1.Close()
            sb_String = Nothing
        Catch ex As Exception
            Call ShowMessage("Write to Log Error !" & ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Function GetConnString(Optional ByVal DBMS As String = "SQLServer") As String
        Select Case DBMS
            Case "SQLServer"
                If gs_DBAuthMode = "win" Then
                    Return "Data Source=" & gs_DBServer & ";Initial Catalog=" & gs_Database & ";Integrated Security=True"
                Else
                    Return "Data Source=" & gs_DBServer & ";Initial Catalog=" & gs_Database & ";User ID=" & gs_DBUserName & ";pwd=" & gs_DBPassword
                End If
            Case Else
                Return ""
        End Select
    End Function


    Public Function GetConnStringSolomon(Optional ByVal DBMS As String = "SQLServer") As String
        Select Case DBMS
            Case "SQLServer"
                If gs_DBAuthMode = "win" Then
                    Return "Data Source=" & gs_DBServer1 & ";Initial Catalog=" & gs_Database1 & ";Integrated Security=True"
                Else
                    Return "Data Source=" & gs_DBServer1 & ";Initial Catalog=" & gs_Database1 & ";User ID=" & gs_DBUserName1 & ";pwd=" & gs_DBPassword1
                End If
            Case Else
                Return ""
        End Select
    End Function
    Public Function GetConnStringDbCKR(Optional ByVal DBMS As String = "SQLServer") As String
        Select Case DBMS
            Case "SQLServer"
                Return "Data Source=" & gs_DBServer2 & ";Initial Catalog=" & gs_Database2 & ";User ID=" & gs_DBUserName2 & ";pwd=" & gs_DBPassword2
            Case Else
                Return ""
        End Select
    End Function

    Public Function NumValue(ByVal value As Object) As Double
        '# Check if value is numeric...
        If IsNumeric(value & "0") Then
            Dim numstring As String = value & ""
            'numstring = CDbl(numstring & "0") '.ToString()
            If numstring.IndexOf(".") > 0 Then
                Return CDbl(numstring & "0")
            Else
                Return CDbl(numstring & "0") / 10
            End If
        Else
            Return 0
        End If
    End Function

    Public Function ServerDate() As DateTime
        Dim svrdate As DateTime = Now
        Try
            Dim dt As DataTable = GetDataTable("SELECT HariIni = GETDATE()")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then svrdate = dt.Rows(0)("HariIni")
            Return svrdate
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            Return svrdate
        End Try
    End Function

    Public Function QVal(ByVal value As Object, Optional ByVal pLongDate As Boolean = True, Optional ByVal pMiddleDate As Boolean = False) As Object
        Dim result As Object = ""
        If value Is Nothing OrElse (value = Nothing AndAlso value.ToString <> "0" AndAlso value.ToString <> "False") Then
            result = "NULL"
        ElseIf TypeOf value Is String Then
            If value.ToString.Trim.ToLower = "null" OrElse value.ToString.Trim = "" Then
                result = "NULL"
            Else
                result = "'" & CStr(value & "").Replace("'", "''") & "'"
            End If
        ElseIf TypeOf value Is Boolean Then
            If value = True Then
                result = "1"
            Else
                result = "0"
            End If
        ElseIf IsNumeric(value) Then
            result = value
        ElseIf TypeOf value Is Date Then
            If pLongDate = True Then
                result = "'" & Format(value, "yyyy-MM-dd HH:mm:ss") & "'"
            ElseIf pMiddleDate = True Then
                result = "'" & Format(value, "yyyy-MM-dd HH:mm") & "'"
            Else
                result = "'" & Format(value, "yyyy-MM-dd") & "'"
            End If
        ElseIf TypeOf value Is Image Then
            Return value
        ElseIf TypeOf value Is Byte() Then
            Return value
        ElseIf TypeOf value Is Single Then
            Return value
        ElseIf TypeOf value Is Double Then
            Return value
        End If
        Return result
    End Function

    Public Function gf_DefaultPrinterName() As String
        Dim oPS As New System.Drawing.Printing.PrinterSettings
        Dim ls_PrinterName As String
        Try
            ls_PrinterName = oPS.PrinterName
        Catch ex As System.Exception
            ls_PrinterName = ""
        Finally
            oPS = Nothing
        End Try
        Return ls_PrinterName
    End Function

    Public Sub gf_PopulateSQLInstalledPrinters(ByRef ls_PrinterListSQL As String)
        Try
            Dim MyComputerName As String = System.Net.Dns.GetHostName()
            Dim ls_PrinterName As String = ""
            Dim ls_PrinterLocation As String = ""
            ls_PrinterListSQL = ""

            ' Add list of installed printers found to the combo box.
            For Each strPrinter As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                ls_PrinterName = strPrinter.Trim
                ls_PrinterLocation = ls_PrinterName
                If Not strPrinter.Contains("\\") Then
                    ls_PrinterLocation = "\\" & MyComputerName.Trim.ToUpper & "\" & strPrinter
                End If
                ls_PrinterListSQL &=
                    "Select '" & ls_PrinterName & "' AS 'Printer', '" & ls_PrinterLocation & "' AS 'Location'" & vbCrLf &
                    "UNION ALL" & vbCrLf &
                    ""
            Next
            ls_PrinterListSQL = ls_PrinterListSQL.Remove(ls_PrinterListSQL.LastIndexOf("UNION ALL"))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function gf_GetCrPaperSize(ByVal ls_PrinterName As String, ByVal ls_PaperName As String, ByVal lsg_WidthMm As Single, ByVal lsg_HeightMm As Single) As Integer
        Dim li_Return As Integer = -1
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        doctoprint.PrinterSettings.PrinterName = ls_PrinterName '(ex. "Epson SQ-1170 ESC/P 2")
        Dim lb_Found As Boolean = False

        If gi_PrintIdx > -1 Then
            Try
                If doctoprint.PrinterSettings.PaperSizes(gi_PrintIdx).PaperName = ls_PaperName OrElse (doctoprint.PrinterSettings.PaperSizes(gi_PrintIdx).Width = lsg_WidthMm AndAlso doctoprint.PrinterSettings.PaperSizes(gi_PrintIdx).Height = lsg_HeightMm) Then
                    Dim rawKind As Integer
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(gi_PrintIdx).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(gi_PrintIdx)))
                    li_Return = rawKind
                    lb_Found = True
                End If
            Catch ex As Exception

            End Try
        End If
        If lb_Found = False Then
            For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                Dim rawKind As Integer
                Dim li_Width As Integer = doctoprint.PrinterSettings.PaperSizes(i).Width
                Dim li_Height As Integer = doctoprint.PrinterSettings.PaperSizes(i).Height
                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ls_PaperName OrElse (li_Width = lsg_WidthMm AndAlso li_Height = lsg_HeightMm) Then
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                    li_Return = rawKind
                    gi_PrintIdx = i
                    Exit For
                End If
            Next
        End If
        Return li_Return
    End Function

    Public Function gf_GetHakByForm(ByVal pAppID As String, ByVal pUser As String, ByVal pFormName As String,
                                    ByRef pAkses As String, ByRef pInsert As String, ByRef pUpdate As String,
                                    ByRef pDelete As String, ByRef pSpesial As String) As String
        Try
            pAkses = "0"
            pInsert = "0"
            pUpdate = "0"
            pDelete = "0"
            pSpesial = "0"
            Que = "SELECT TOP 1 " & vbLf &
            "   COALESCE(HakAkses,0) AS HakAkses " & vbLf &
            "   , COALESCE(HakInsert,0) AS HakInsert " & vbLf &
            "   , COALESCE(HakUpdate,0) AS HakUpdate " & vbLf &
            "   , COALESCE(HakDelete,0) AS HakDelete " & vbLf &
            "   , COALESCE(HakSpesial,0) AS HakSpesial " & vbLf &
            "FROM tb_SystemUserAkses " & vbLf &
            "WHERE AppID = " & QVal(pAppID) & " " & vbLf &
            "   AND UserName = " & QVal(pUser) & " " & vbLf &
            "   AND KodeMenu = " & QVal(pFormName) & " "
            Dim dt As DataTable = GetDataTable(Que)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                pAkses = dt.Rows(0).Item("HakAkses").ToString.Trim
                pInsert = dt.Rows(0).Item("HakInsert").ToString.Trim
                pUpdate = dt.Rows(0).Item("HakUpdate").ToString.Trim
                pSpesial = dt.Rows(0).Item("HakSpesial").ToString.Trim
            End If
            Return ""
        Catch ex As Exception
            Return "Pengambilan Hak Privilege Form gagal ! (" & ex.Message & ")"
        End Try
        Return ""
    End Function


    Public Function Num2Word(ByVal n As Double) As String 'max 2.147.483.647
        Dim satuan() As String
        satuan = New String() {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}
        Select Case n
            Case 0 To 11
                Num2Word = satuan(Fix(n))
            Case 12 To 19
                Num2Word = Trim(Num2Word(n Mod 10)) + " Belas "
            Case 20 To 99
                Num2Word = Trim(Num2Word(Fix(n / 10))) + " Puluh " + Trim(Num2Word(n Mod 10))
            Case 100 To 199
                Num2Word = " Seratus " + Trim(Num2Word(n - 100))
            Case 200 To 999
                Num2Word = Trim(Num2Word(Fix(n / 100))) + " Ratus " + Trim(Num2Word(n Mod 100))
            Case 1000 To 1999
                Num2Word = " Seribu " + Trim(Num2Word(n - 1000))
            Case 2000 To 999999
                Num2Word = Trim(Num2Word(Fix(n / 1000))) + " Ribu " + Trim(Num2Word(n Mod 1000))
            Case 1000000 To 999999999
                Num2Word = Trim(Num2Word(Fix(n / 1000000))) + " Juta " + Trim(Num2Word(n Mod 1000000))
            Case Else
                Num2Word = Trim(Num2Word(Fix(n / 1000000000))) + " Milyar " + Trim(Num2Word(n Mod 1000000000))
        End Select
    End Function

    Public Sub gf_GetDatabaseVariables()
        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"

        Dim AppSettingFileName As String = Application.StartupPath & "\AS.XML"

        Dim FileInfo As New IO.FileInfo(AppSettingFileName)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(AppSettingFileName)

            dtTableAppSetting = DS.Tables("AS")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 9 Then
                    gs_DBServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))
                    gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    gs_InstructionSetting = DataDecrypt(dtTableAppSetting.Rows(0).Item("IS"))
                Else
                    gs_DBServer = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))
                    gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    gs_InstructionSetting = ""

                    Kill(AppSettingFileName)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(AppSettingFileName, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("AS") ' Root.

                        With writer
                            .WriteStartElement("AS")
                            .WriteElementString("S", DataEncrypt(gs_DBServer.Trim))
                            .WriteElementString("D", DataEncrypt(gs_Database.Trim))
                            .WriteElementString("U", DataEncrypt(gs_DBUserName.Trim))
                            .WriteElementString("PW", DataEncrypt(gs_DBPassword.Trim))
                            .WriteElementString("AU", DataEncrypt(gs_DBAuthMode.Trim))
                            .WriteElementString("TU", DataEncrypt(gs_TerminalUsername.Trim))
                            .WriteElementString("TPW", DataEncrypt(gs_TerminalPassword.Trim))
                            .WriteElementString("AF", DataEncrypt(gs_AutomaticForm.Trim))
                            .WriteElementString("IS", DataEncrypt(gs_InstructionSetting.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using


                End If

            End If
        Else
            gs_DBServer = ""
            gs_Database = ""
            gs_DBUserName = ""
            gs_DBPassword = ""
            gs_DBAuthMode = ""
            gs_AutomaticForm = ""
            gs_InstructionSetting = ""
        End If

        If gs_DBPassword.Trim = "" Then gs_DBPassword = gs_DBPasswordDefault

    End Sub
    Public Sub gf_GetDatabaseVariablesSolomon()
        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"

        Dim SolomonConfig As String = Application.StartupPath & "\Solomon.XML"

        Dim FileInfo As New IO.FileInfo(SolomonConfig)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(SolomonConfig)

            dtTableAppSetting = DS.Tables("Solomon")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 9 Then
                    gs_DBServer1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))
                    gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    gs_InstructionSetting = DataDecrypt(dtTableAppSetting.Rows(0).Item("IS"))
                Else
                    gs_DBServer1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    gs_DBAuthMode1 = DataDecrypt(dtTableAppSetting.Rows(0).Item("AU"))
                    gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    gs_InstructionSetting = ""

                    Kill(SolomonConfig)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(SolomonConfig, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("Solomon") ' Root.

                        With writer
                            .WriteStartElement("Solomon")
                            .WriteElementString("S", DataEncrypt(gs_DBServer1.Trim))
                            .WriteElementString("D", DataEncrypt(gs_Database1.Trim))
                            .WriteElementString("U", DataEncrypt(gs_DBUserName1.Trim))
                            .WriteElementString("PW", DataEncrypt(gs_DBPassword1.Trim))
                            .WriteElementString("AU", DataEncrypt(gs_DBAuthMode1.Trim))
                            .WriteElementString("TU", DataEncrypt(gs_TerminalUsername.Trim))
                            .WriteElementString("TPW", DataEncrypt(gs_TerminalPassword.Trim))
                            .WriteElementString("AF", DataEncrypt(gs_AutomaticForm.Trim))
                            .WriteElementString("IS", DataEncrypt(gs_InstructionSetting.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using


                End If

            End If
        Else
            gs_DBServer1 = ""
            gs_Database1 = ""
            gs_DBUserName1 = ""
            gs_DBPassword1 = ""
            gs_DBAuthMode1 = ""
            gs_AutomaticForm = ""
            gs_InstructionSetting = ""
        End If

        If gs_DBPassword1.Trim = "" Then gs_DBPassword1 = gs_DBPasswordDefault1

    End Sub

    Public Sub gf_GetDatabaseVariablesDbCKR()
        Dim ls_Product As String = My.Application.Info.ProductName.Trim
        Dim ls_Description As String = My.Application.Info.Description.Trim
        If ls_Description = "" Then ls_Description = "Takagi"

        Dim CKRConfig As String = Application.StartupPath & "\CKR.XML"

        Dim FileInfo As New IO.FileInfo(CKRConfig)

        'check existing file
        If FileInfo.Exists Then
            Dim dtTableAppSetting As DataTable
            Dim DS As New DataSet()

            DS.ReadXml(CKRConfig)

            dtTableAppSetting = DS.Tables("CKR")

            If dtTableAppSetting.Rows.Count > 0 Then
                If dtTableAppSetting.Columns.Count = 7 Then
                    gs_DBServer2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    'gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    'gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    'gs_InstructionSetting = DataDecrypt(dtTableAppSetting.Rows(0).Item("IS"))
                Else
                    gs_DBServer2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("S"))
                    gs_Database2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("D"))
                    gs_DBUserName2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("U"))
                    gs_DBPassword2 = DataDecrypt(dtTableAppSetting.Rows(0).Item("PW"))
                    'gs_TerminalUsername = DataDecrypt(dtTableAppSetting.Rows(0).Item("TU"))
                    'gs_TerminalPassword = DataDecrypt(dtTableAppSetting.Rows(0).Item("TPW"))
                    'gs_AutomaticForm = DataDecrypt(dtTableAppSetting.Rows(0).Item("AF"))
                    gs_InstructionSetting = ""

                    Kill(CKRConfig)

                    Dim settings As XmlWriterSettings = New XmlWriterSettings()
                    settings.Indent = True

                    Using writer As XmlWriter = XmlWriter.Create(CKRConfig, settings)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("CKR") ' Root.

                        With writer
                            .WriteStartElement("CKR")
                            .WriteElementString("S", DataEncrypt(gs_DBServer2.Trim))
                            .WriteElementString("D", DataEncrypt(gs_Database2.Trim))
                            .WriteElementString("U", DataEncrypt(gs_DBUserName2.Trim))
                            .WriteElementString("PW", DataEncrypt(gs_DBPassword2.Trim))
                            .WriteElementString("TU", DataEncrypt(gs_TerminalUsername.Trim))
                            .WriteElementString("TPW", DataEncrypt(gs_TerminalPassword.Trim))
                            .WriteElementString("AF", DataEncrypt(gs_AutomaticForm.Trim))
                            .WriteElementString("IS", DataEncrypt(gs_InstructionSetting.Trim))
                            .WriteEndElement()
                        End With

                        writer.WriteEndElement()
                        writer.WriteEndDocument()
                    End Using


                End If

            End If
        Else
            gs_DBServer2 = ""
            gs_Database2 = ""
            gs_DBUserName2 = ""
            gs_DBPassword2 = ""
            gs_DBAuthMode2 = ""
            gs_AutomaticForm = ""
            gs_InstructionSetting = ""
        End If

        If gs_DBPassword2.Trim = "" Then gs_DBPassword2 = gs_DBPasswordDefault2

    End Sub

    Public Function DataEncrypt(ByVal StringToEncrypt As String, Optional ByVal AlphaEncoding As Boolean = False) As String
        Dim ls_Results As String = "", ls_Char As String = ""
        If StringToEncrypt.Trim <> "" Then
            Try
                For i As Integer = 1 To Len(StringToEncrypt)
                    ls_Char = Asc(Mid(StringToEncrypt, i, 1))
                    ls_Results = ls_Results & Len(ls_Char) & ls_Char
                Next i
                If AlphaEncoding Then
                    StringToEncrypt = ls_Results
                    ls_Results = ""
                    For i As Integer = 1 To Len(StringToEncrypt)
                        ls_Results = ls_Results & Chr(Mid(StringToEncrypt, i, 1) + 147)
                    Next i
                End If
            Catch ex As Exception
                gs_Error = "Error encrypting string"
                Call ShowMessage(gs_Error, MessageTypeEnum.ErrorMessage)
                Return ""
            End Try
        End If
        Return ls_Results
    End Function

    Public Function HashData(ByVal s As String) As String
        Try
            'Convert the string to a byte array
            Dim bytDataToHash As Byte() = (New System.Text.UnicodeEncoding()).GetBytes(s)

            'Compute the MD5 hash algorithm
            Dim bytHashValue As Byte() = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(bytDataToHash)

            Return BitConverter.ToString(bytHashValue)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function DataDecrypt(ByVal StringToDecrypt As String, Optional ByVal AlphaDecoding As Boolean = False) As String
        Dim ls_Results As String = ""
        Dim CharCode As String
        Dim CharPos As Integer
        gs_Error = ""
        If StringToDecrypt.Trim <> "" Then
            Try
                If AlphaDecoding Then
                    ls_Results = StringToDecrypt
                    StringToDecrypt = ""
                    For i As Integer = 1 To Len(ls_Results)
                        StringToDecrypt = StringToDecrypt & (Asc(Mid(ls_Results, i, 1)) - 147)
                    Next i
                End If
                ls_Results = ""
                Do
                    CharPos = Left(StringToDecrypt, 1)
                    StringToDecrypt = Mid(StringToDecrypt, 2)
                    CharCode = Left(StringToDecrypt, CharPos)
                    StringToDecrypt = Mid(StringToDecrypt, Len(CharCode) + 1)
                    ls_Results = ls_Results & Chr(CharCode)
                Loop Until StringToDecrypt = ""
            Catch ex As Exception
                gs_Error = "Error decrypting string"
                Call ShowMessage(gs_Error, MessageTypeEnum.ErrorMessage)
                Return ""
            End Try
        End If
        Return ls_Results
    End Function

#End Region

#Region "SQLHelper Functions"
    Public Function GetDataSet(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDsReport(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim conn As SqlConnection = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa, dtTable)
            Else
                Using kon As New SqlConnection
                    kon.ConnectionString = GetConnString()
                    kon.Open()
                    da = New SqlDataAdapter(pQuery, kon)
                    da.Fill(dsa, dtTable)
                End Using
                'conn = New SqlConnection(GetConnString)
                'da = New SqlDataAdapter(pQuery, conn)
            End If

            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDsReport_Solomon(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim conn As SqlConnection = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa, dtTable)
            Else
                Using kon As New SqlConnection
                    kon.ConnectionString = GetConnStringSolomon()
                    kon.Open()
                    da = New SqlDataAdapter(pQuery, kon)
                    da.Fill(dsa, dtTable)
                End Using
                'conn = New SqlConnection(GetConnStringSolomon)
                'da = New SqlDataAdapter(pQuery, conn)
            End If

            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDsReport2_Solomon(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pTimeOut As Integer = 0) As dsLaporan2
        Dim conn As SqlConnection = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan2
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa, dtTable)
            Else
                Using kon As New SqlConnection
                    kon.ConnectionString = GetConnStringSolomon()
                    kon.Open()
                    da = New SqlDataAdapter(pQuery, kon)
                    da.Fill(dsa, dtTable)
                End Using
                'conn = New SqlConnection(GetConnStringSolomon)
                'da = New SqlDataAdapter(pQuery, conn)
            End If

            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataSetByCommand_SP(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa, dtTable)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSetByCommand_StoreP(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringSolomon()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa, dtTable)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataSetByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableByCommand_StoreP(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringSolomon()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTable(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataTableSP(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataTable_Solomon(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringSolomon()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataTableByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function GetDataTableByCommand_sol(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringSolomon()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableByCommand_SP(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataTableByCommand_SP_Solomon(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            Using conn As New SqlClient.SqlConnection
                conn.ConnectionString = GetConnStringSolomon()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = pQuery
                cmd.CommandTimeout = pTimeOut
                cmd.Connection = conn
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        cmd.Parameters.Add(pParam(i))
                    Next
                End If
                conn.Open()
                da = New SqlDataAdapter(cmd)
                da.Fill(dta)
            End Using
            'If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
            '    gh_Trans.Command.CommandType = CommandType.StoredProcedure
            '    gh_Trans.Command.CommandText = pQuery
            '    gh_Trans.Command.CommandTimeout = pTimeOut
            '    gh_Trans.Command.Parameters.Clear()
            '    If pParam IsNot Nothing Then
            '        For i As Integer = 0 To pParam.Length - 1
            '            gh_Trans.Command.Parameters.Add(pParam(i))
            '        Next
            '    End If
            '    da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
            '    da.Fill(dta)
            'Else

            'End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQuery(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    Conn1.ConnectionString = GetConnString()
                    Dim cmd As New SqlClient.SqlCommand(pQuery, Conn1)
                    cmd.CommandTimeout = pTimeOut
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQuery_Solomon(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    Conn1.ConnectionString = GetConnStringSolomon()
                    Dim cmd As New SqlClient.SqlCommand(pQuery, Conn1)
                    cmd.CommandTimeout = pTimeOut
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQueryByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnString()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQueryByAddWithValue(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnString()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryByCommandSolomon(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnStringSolomon()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryByCommand_SP(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnString()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQueryByCommand_SP_Solomon(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnStringSolomon()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "Koneksi ke DbCKR"
    Public Function GetDataSetCKR(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDsReportCKR(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim conn As SqlConnection = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
            Else
                conn = New SqlConnection(GetConnStringDbCKR)
                da = New SqlDataAdapter(pQuery, conn)
            End If
            da.Fill(dsa, dtTable)
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSetByCommand_SPCKR(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa, dtTable)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSetByCommand_StorePCKR(ByVal pQuery As String, ByVal dtTable As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As dsLaporan
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New dsLaporan
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa, dtTable)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function GetDataSetByCommandCKR(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableByCommand_StorePCKR(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableCKR(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringDbCKR()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryCKR(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    Conn1.ConnectionString = GetConnStringDbCKR()
                    Dim cmd As New SqlClient.SqlCommand(pQuery, Conn1)
                    cmd.CommandTimeout = pTimeOut
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryByCommandCKR(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnStringDbCKR()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryByCommand_SPCKR(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 0) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.Command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnStringDbCKR()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region
    Public Function GetCheckConnString(Optional ByVal DBMS As String = "SQLServer",
                                       Optional ByVal pTimeOut As Integer = 3) As String
        Select Case DBMS
            Case "SQLServer"
                If gs_DBAuthMode = "win" Then
                    Return "Data Source=" & gs_DBServer & ";Initial Catalog=" & gs_Database & ";Integrated Security=True; Connection Timeout= " & pTimeOut & ""
                Else
                    Return "Data Source=" & gs_DBServer & ";Initial Catalog=" & gs_Database & ";User ID=" & gs_DBUserName & ";pwd=" & gs_DBPassword & " ; Connection Timeout= " & pTimeOut & ""
                End If
            Case Else
                Return ""
        End Select
    End Function

    Public Sub CheckDBConnection()
        Dim conn As SqlConnection = Nothing
        Dim query As String = "SELECT TOP 1 Column_Name FROM Information_Schema.Columns"
        Dim cmd As New SqlCommand
        Dim pRowAff As Integer = -1

        Try
            Using Conn1 As New SqlClient.SqlConnection
                Conn1.ConnectionString = GetConnString()
                Dim command As New SqlClient.SqlCommand(query, Conn1)
                Conn1.Open()
                pRowAff = command.ExecuteNonQuery()
                gs_Error = ""
            End Using

        Catch ex As Exception
            gs_Error = "Error Connection"
        Finally

        End Try
    End Sub

    Public Function ByPassConnectionAfterOffline()
        Dim _Stat As String = ""
        Try
            Using conn1 As New SqlClient.SqlConnection(GetConnString)
                conn1.Open()
                Using trans1 As SqlClient.SqlTransaction = conn1.BeginTransaction
                End Using
            End Using
            _Stat = ""
            Return _Stat
        Catch ex As Exception
            _Stat = "Error"
            Return _Stat
        Finally
            gh_Trans = Nothing
        End Try
    End Function

#End Region

    Public Function ConnectionString(ByVal FileName As String) As String
        Dim Builder As New System.Data.OleDb.OleDbConnectionStringBuilder
        If IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            Builder.Add("Extended Properties", "Excel 8.0;IMEX=1;HDR=Yes;")
        Else
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            Builder.Add("Extended Properties", "Excel 12.0;IMEX=1;HDR=Yes;")
        End If

        Builder.DataSource = FileName

        Return Builder.ConnectionString

    End Function

    Public Sub AturGrid(ByVal Grid As DataGridView, ByVal f As Form)
        Dim StyleColumn As DataGridViewCellStyle = New DataGridViewCellStyle
        'Normal Row
        Dim StyleNormal As DataGridViewCellStyle = New DataGridViewCellStyle
        'Alternate Row
        Dim StyleAlternate As DataGridViewCellStyle = New DataGridViewCellStyle

        With StyleColumn
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .BackColor = gcl_GridFixedDarkblue
            .Font = New Font(gs_AppFontName, gsi_AppFontSize, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .ForeColor = gcl_GridFixedFore
            .SelectionBackColor = SystemColors.Highlight
            .SelectionForeColor = SystemColors.HighlightText
            .WrapMode = DataGridViewTriState.False
        End With
        StyleAlternate.BackColor = gcl_GridNormalBack1
        With StyleNormal
            .BackColor = gcl_GridAlternateBack1 'gcl_GridNormalBack
            .WrapMode = DataGridViewTriState.[False]
            .Padding = New Padding(5, 0, 5, 0)
        End With

        With Grid
            .Font = f.Font
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .AlternatingRowsDefaultCellStyle = StyleAlternate
            '.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            '            Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            .Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            '.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            .ColumnHeadersDefaultCellStyle = StyleColumn
            .ColumnHeadersHeight = 30
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .EnableHeadersVisualStyles = False
            .ReadOnly = False
            .RowHeadersVisible = False
            .RowsDefaultCellStyle = StyleNormal
            .ShowEditingIcon = False
            .ShowRowErrors = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            '.BackgroundColor = tabcolour
            '.Dock = DockStyle.Fill
        End With
        Grid.ClearSelection()
    End Sub
    Private bia_FormatPecahan() As Integer = Nothing
    Private bia_FormatBulat() As Integer = Nothing
    Public Sub FormatGridView(ByVal View As GridView)
        With View
            For i As Integer = 0 To .Columns.Count - 1
                If .Columns(i).ColumnType Is GetType(Date) Then
                    If .Columns(i).DisplayFormat.FormatString <> "dd MMM yyyy" AndAlso .Columns(i).DisplayFormat.FormatString <> "dd MMMM yyyy" Then .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                ElseIf .Columns(i).ColumnType Is GetType(Integer) Then
                    Dim lb_Nothing As Boolean = True
                    .Columns(i).DisplayFormat.Format = GetType(String)
                    If bia_FormatPecahan IsNot Nothing AndAlso bia_FormatPecahan.Length > 0 Then
                        Array.Sort(bia_FormatPecahan)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatPecahan, .Columns(i).ColumnHandle)
                        If li_Found > -1 Then
                            .Columns(i).DisplayFormat.FormatString = gs_FormatPecahan
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True AndAlso bia_FormatBulat IsNot Nothing AndAlso bia_FormatBulat.Length > 0 Then
                        Array.Sort(bia_FormatBulat)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatBulat, .Columns(i).ColumnHandle)
                        If li_Found > -1 Then
                            .Columns(i).DisplayFormat.FormatString = gs_FormatBulat
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True Then
                        .Columns(i).DisplayFormat.FormatString = gs_FormatDecimal
                    End If
                    .Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

            Next
            .RefreshData()
            'FrmMain.LblRecords.Caption = CStr(.RowCount) & " record(s)"

        End With
    End Sub

    Public Sub GridCellFormat(ByVal View As GridView, Optional ByVal IsIndonesianDate As Boolean = True)
        With View
            For Each col As Columns.GridColumn In .Columns
                If col.ColumnType Is GetType(Date) Then
                    If IsIndonesianDate Then
                        If col.DisplayFormat.FormatString <> "dd MMM yyyy" AndAlso col.DisplayFormat.FormatString <> "dd MMMM yyyy" Then
                            col.DisplayFormat.FormatType = FormatType.DateTime
                            col.DisplayFormat.FormatString = "dd-MM-yyyy"
                        End If
                    Else
                        If col.DisplayFormat.FormatString <> "dd/MMM/yyyy" AndAlso col.DisplayFormat.FormatString <> "dd/MMMM/yyyy" Then
                            col.DisplayFormat.FormatType = FormatType.DateTime
                            col.DisplayFormat.FormatString = "MM/dd/yyyy"
                        End If
                    End If

                ElseIf col.ColumnType Is GetType(Decimal) OrElse col.ColumnType Is GetType(Double) Then
                    Dim lb_Nothing As Boolean = True
                    col.DisplayFormat.FormatString = gs_FormatPecahan
                    If bia_FormatPecahan IsNot Nothing AndAlso bia_FormatPecahan.Length > 0 Then
                        Array.Sort(bia_FormatPecahan)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatPecahan, col.ColumnHandle)
                        If li_Found > -1 Then
                            col.DisplayFormat.FormatType = FormatType.Numeric
                            col.DisplayFormat.FormatString = gs_FormatPecahan
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True AndAlso bia_FormatBulat IsNot Nothing AndAlso bia_FormatBulat.Length > 0 Then
                        Array.Sort(bia_FormatBulat)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatBulat, col.ColumnHandle)
                        If li_Found > -1 Then
                            col.DisplayFormat.FormatType = FormatType.Numeric
                            col.DisplayFormat.FormatString = gs_FormatBulat
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True Then
                        col.DisplayFormat.FormatType = FormatType.Numeric
                        col.DisplayFormat.FormatString = gs_FormatPecahan
                    End If
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                ElseIf col.ColumnType Is GetType(Integer) Then
                    col.DisplayFormat.FormatType = FormatType.Numeric
                    col.DisplayFormat.FormatString = gs_FormatBulat
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                End If

            Next
            .RefreshData()
            'FrmMain.LblRecords.Caption = CStr(.RowCount) & " record(s)"
        End With
    End Sub
    Public Sub GridCellFormatDatewithTime(ByVal View As GridView)
        With View
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If col.ColumnType Is GetType(DateTime) Then
                    If col.DisplayFormat.FormatString <> "dd MMM yyyy" AndAlso col.DisplayFormat.FormatString <> "dd MMMM yyyy" Then
                        col.DisplayFormat.FormatType = FormatType.DateTime
                        col.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                    End If
                ElseIf col.ColumnType Is GetType(Decimal) OrElse col.ColumnType Is GetType(Double) Then
                    Dim lb_Nothing As Boolean = True
                    col.DisplayFormat.FormatString = gs_FormatPecahan
                    If bia_FormatPecahan IsNot Nothing AndAlso bia_FormatPecahan.Length > 0 Then
                        Array.Sort(bia_FormatPecahan)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatPecahan, col.ColumnHandle)
                        If li_Found > -1 Then
                            col.DisplayFormat.FormatType = FormatType.Numeric
                            col.DisplayFormat.FormatString = gs_FormatPecahan
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True AndAlso bia_FormatBulat IsNot Nothing AndAlso bia_FormatBulat.Length > 0 Then
                        Array.Sort(bia_FormatBulat)
                        Dim li_Found As Integer = Array.BinarySearch(bia_FormatBulat, col.ColumnHandle)
                        If li_Found > -1 Then
                            col.DisplayFormat.FormatType = FormatType.Numeric
                            col.DisplayFormat.FormatString = gs_FormatBulat
                            lb_Nothing = False
                        End If
                    End If
                    If lb_Nothing = True Then
                        col.DisplayFormat.FormatType = FormatType.Numeric
                        col.DisplayFormat.FormatString = gs_FormatDecimal
                    End If
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
            Next
            .RefreshData()
            'FrmMain.LblRecords.Caption = CStr(.RowCount) & " record(s)"
        End With
    End Sub

    Public Function isOpen(ByVal name As String) As Boolean
        isOpen = False

        For Each f As Form In Application.OpenForms

            If f.Name = name Then
                isOpen = True
                f.Focus()
                Exit For
            End If
        Next

        If isOpen = False Then
            Return isOpen
        End If

        Return isOpen
    End Function

    Public Sub SaveToExcel(_Grid As GridControl, Optional sheetName As String = "", Optional _name As String = "", Optional ByVal xls As Boolean = True)
        Dim save As New SaveFileDialog
        If xls Then
            save.Filter = "Excel File|*.xls"
            save.Title = "Save an Excel File"
            save.FileName = _name
            Dim options As XlsExportOptionsEx = New XlsExportOptionsEx()

            options.SheetName = sheetName
            options.ShowGridLines = True
            options.AllowSortingAndFiltering = DefaultBoolean.False
            If save.ShowDialog = DialogResult.OK Then
                _Grid.ExportToXls(save.FileName, options)
            End If
        Else
            save.Filter = "Excel File|*.xlsx"
            save.Title = "Save an Excel File"
            Dim options As XlsxExportOptionsEx = New XlsxExportOptionsEx()

            options.SheetName = sheetName
            options.ShowGridLines = True
            save.FileName = _name
            options.AllowSortingAndFiltering = DefaultBoolean.False
            If save.ShowDialog = DialogResult.OK Then
                _Grid.ExportToXlsx(save.FileName, options)
            End If
        End If

    End Sub

    Public Function GetConnStringTsc(Optional ByVal DBMS As String = "SQLServer") As String
        Return "Data Source=NOTE\SQL2008R2;Initial Catalog=tsc;User ID=sa;pwd=admin12345"

    End Function

    Public Function GetDataTableByCommand_SP_Tsc(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.StoredProcedure
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnStringTsc()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataTableByCommand_HotReload(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 0, Optional ByVal dep_onchange As OnChangeEventHandler = Nothing) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            SqlDependency.Stop(GetConnString)
            SqlDependency.Start(GetConnString)

            If gh_Trans IsNot Nothing AndAlso gh_Trans.Command IsNot Nothing Then
                gh_Trans.Command.CommandType = CommandType.Text
                gh_Trans.Command.CommandText = pQuery
                gh_Trans.Command.CommandTimeout = pTimeOut
                gh_Trans.Command.Parameters.Clear()

                gh_Trans.Command.Notification = Nothing

                Dim dep As SqlDependency = New SqlDependency(gh_Trans.Command)
                AddHandler dep.OnChange, dep_onchange

                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.Command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlDataAdapter(gh_Trans.Command)
                da.Fill(dta)
            Else

                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn

                    cmd.Notification = Nothing

                    Dim dep As SqlDependency = New SqlDependency(cmd)
                    AddHandler dep.OnChange, dep_onchange

                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Module
