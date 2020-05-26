Imports System.Collections.ObjectModel

Public Class SettleHeader
    Public Property CuryID As String
    Public Property DeptID As String
    Public Property ID As Integer
    Public Property pay As Short
    Public Property Remark As String
    Public Property SettleID As String
    Public Property Status As String
    Public Property PRNo As String
    Public Property SuspendID As String
    Public Property Tgl As Date
    Public Property Total As Double
    Public Property TotalSuspend As Double
    Public Property Tgl1 As Date
    Public Property Tgl2 As Date
    Public Property Jenis As String
    Public Property noPR As String
    Public Property Date1 As Date
    Public Property Date2 As Date
    Public Property ObjDetails() As New Collection(Of SettleDetail)

    Public Function SubReport() As DataSet
        Dim query As String
        query = "SELECT [SettleRelasiID]
                      ,[SettleID]
                      ,[Nama]
                      ,[Posisi]
                      ,[Perusahaan]
                      ,[JenisUsaha]
                      ,[Remark]
                  FROM [SettleRelasi] Where [SettleID] = '" & SettleID & "'"
        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "SettleRelasi")
        Return ds

    End Function



    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header left join settle_detail on settle_header.settleID=settle_detail.settleID 
where settle_header.DeptID='" & gh_Common.GroupID & "' AND  pay=0 and (settle_header.SuspendID not like '%EN%'  OR settle_header.SuspendID Is Null) group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '                "SELECT settle_header.ID
            '	, settle_header.SettleID
            '	, settle_header.SuspendID, 
            '            settle_header.DeptID
            '            , Remark, settle_header.Tgl
            '            , settle_header.CuryID
            '            , settle_header.Total,
            '            sum(settle_detail.suspendAmount)suspendAmount
            '            ,sum(settle_detail.SettleAmount)SettleAmount
            '            , settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID not like '%EN%' or settle_header.SuspendID is null and pay=0 group by settle_header.ID
            '	, settle_header.SettleID
            '	, settle_header.SuspendID, 
            '            settle_header.DeptID
            '            , Remark, settle_header.Tgl
            '            , settle_header.CuryID
            '            , settle_header.Total,settle_header.pay
            ''"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID not like '%EN%' or settle_header.SuspendID is null"
            '"SELECT ID, SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Total, pay
            'FROM settle_header"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridRpt() As DataTable

        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where pay=0 and settle_header.SuspendID like '" & Jenis & " %' and settle_header.Tgl>='" & Tgl1 & "' and settle_header.Tgl<='" & Tgl2 & "' and  group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"

            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT settle_detail.SettleID
                    ,settle_header.suspendid
                    ,settle_detail.Description
                    ,settle_detail.Tgl as Tgl2
                    ,suspend_header.Total as SuspendAmount
                    ,settle_detail.SettleAmount
                    ,settle_detail.AcctID
                    ,settle_detail.SubAcct
                    ,settle_detail.Nama
                    ,settle_detail.Tempat
                    ,settle_detail.Alamat
                    ,settle_detail.Jenis
                    ,settle_detail.NamaRelasi
                    ,settle_detail.Posisi
                    ,settle_detail.Relasi
                    ,settle_detail.JenisRelasi
                    ,settle_detail.Nota
                    ,settle_header.Tgl
                    ,settle_header.DeptID
                    ,settle_header.Remark
                    ,settle_header.CuryID
                    ,settle_header.Status
                    ,settle_header.Total
                    ,settle_header.pay
                    ,settle_header.Proses
                     ,settle_header.PRNo
                      FROM settle_header left join settle_detail on settle_detail.SettleID=settle_header.SettleID left join suspend_header on suspend_header.SuspendID=settle_header.SuspendID where settle_header.SettleID='" & SettleID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "settle")
        Return ds

    End Function



    Public Function loadreportAPSolomon() As DataSet
        Dim query As String

        query = "SELECT     CONVERT(VARCHAR(6), tgl, 112) AS tgl1, docbal, BankID, cashsub, refnbr1, vrno, tgl,
VendId, origdocamt, RefNbr, curydocbal FROM dataupload
where cek1=1 and prosespay=1 and uploaded=0 or 
uploaded Is null and tgl >='" & Date1 & "' And Tgl <='" & Date2 & "' order by vrno"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "dataupload")
        Return ds

    End Function






    Public Function loadreport2a() As DataSet
        Dim query As String
        query = "SELECT settle_detail.SettleID
                    ,settle_detail.Description
                    ,settle_detail.Tgl as Tgl2
                    ,settle_detail.SettleAmount
                    ,settle_detail.AcctID
                    ,settle_detail.SubAcct
                    ,settle_detail.Nama
                    ,settle_detail.Tempat
                    ,settle_detail.Alamat
                    ,settle_detail.Jenis
                    ,settle_detail.NamaRelasi
                    ,settle_detail.Posisi
                    ,settle_detail.Relasi
                    ,settle_detail.JenisRelasi
                    ,settle_detail.Nota
                    ,settle_header.Tgl
                    ,settle_header.DeptID
                    ,settle_header.Remark
                    ,settle_header.CuryID
                    ,settle_header.Status
                    ,settle_header.Total
                    ,settle_header.pay
                    ,settle_header.Proses
                    ,settle_header.PRNo
                      FROM settle_header left join settle_detail on settle_detail.SettleID=settle_header.SettleID where settle_header.SettleID='" & SettleID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "settle")
        Return ds

    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where pay=1 and settle_header.SuspendID not like '%EN%' group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID not like '%EN%' or settle_header.SuspendID is null"
            '"SELECT ID, SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Total, pay
            'FROM settle_header"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function GetDataGridEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
"SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where DeptID='" & gh_Common.GroupID & "' and settle_header.settleid like '%ET%' 
group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID like '%EN%'"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEntPaid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
"SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where DeptID='" & gh_Common.GroupID & "' and (settle_header.SuspendID like '%EN%' AND settle_header.SuspendID is null)  OR settle_header.SuspendID like '%EN%'
 and status='Close' and pay='1'
group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID like '%EN%'"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub GetSettleById()
        Try
            Dim sql As String =
            "SELECT t.ID, t.SettleID, t.SuspendID, t.DeptID, t.Remark, t.Tgl, t.CuryID, t.Status, t.Total, t.pay, s.Total TotSuspend,t.PRNo
            FROM settle_header t left join suspend_header s on t.SuspendID = s.SuspendID 
            where t.ID=" & QVal(ID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                ID = If(IsDBNull(dt.Rows(0).Item("ID")), "", Trim(dt.Rows(0).Item("ID").ToString()))
                SettleID = If(IsDBNull(dt.Rows(0).Item("SettleID")), "", Trim(dt.Rows(0).Item("SettleID").ToString()))
                SuspendID = If(IsDBNull(dt.Rows(0).Item("SuspendID")), "", Trim(dt.Rows(0).Item("SuspendID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("Status")), "", Trim(dt.Rows(0).Item("Status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                TotalSuspend = If(IsDBNull(dt.Rows(0).Item("TotSuspend")), 0, Convert.ToDouble(dt.Rows(0).Item("TotSuspend")))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Convert.ToString(dt.Rows(0).Item("CuryID")))
                PRNo = If(IsDBNull(dt.Rows(0).Item("PRNo")), "", Convert.ToString(dt.Rows(0).Item("PRNo")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetSettleByIdEnt()
        Try
            Dim sql As String =
            "SELECT t.ID, t.SettleID, t.SuspendID, t.DeptID, t.Remark, t.Tgl, t.CuryID, t.Status, t.Total, t.pay, s.Total TotSuspend
            FROM settle_header t Inner join suspend_header s on t.SuspendID = s.SuspendID 
            where t.ID=" & QVal(ID) & " and t.suspendid like '%EN%'"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                ID = If(IsDBNull(dt.Rows(0).Item("ID")), "", Trim(dt.Rows(0).Item("ID").ToString()))
                SettleID = If(IsDBNull(dt.Rows(0).Item("SettleID")), "", Trim(dt.Rows(0).Item("SettleID").ToString()))
                SuspendID = If(IsDBNull(dt.Rows(0).Item("SuspendID")), "", Trim(dt.Rows(0).Item("SuspendID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("Status")), "", Trim(dt.Rows(0).Item("Status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                TotalSuspend = If(IsDBNull(dt.Rows(0).Item("TotSuspend")), 0, Convert.ToDouble(dt.Rows(0).Item("TotSuspend")))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Convert.ToString(dt.Rows(0).Item("CuryID")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetListSuspend() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID ID, SuspendID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND Tipe = 'S' AND Pay=1 AND Status ='Approved' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListSettleEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID ID, SuspendID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE Tipe = 'E' AND Pay=1 AND Status='Approved' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SettleAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(settleid)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(settleid,1,2) = 'ST' and SUBSTRING(settleid,4,4) = RIGHT(@tahun,4) AND SUBSTRING(settleid,9,2) = RIGHT(@bulan,2)) " &
                "select 'ST' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function SettleAutoNoEnt() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(settleid)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(settleid,1,2)='ET' AND SUBSTRING(settleid,4,4) = RIGHT(@tahun,4) AND SUBSTRING(settleid,9,2) = RIGHT(@bulan,2)) " &
                "select 'ET' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function


    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        Try
            Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub InsertHeaderEntSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        'Try
        '    Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
        '    ExecQuery_Solomon(ls_SP)
        'Catch ex As Exception
        '    Throw
        'End Try

    End Sub


    Public Sub InsertHeaderEntSettleDirect()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, DeptID, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        'Try
        '    Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
        '    ExecQuery_Solomon(ls_SP)
        'Catch ex As Exception
        '    Throw
        'End Try

    End Sub



    Public Sub InsertHeader2()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Status,PRNo, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(noPR.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        Try
            Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub InsertHeaderDirectSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, DeptID,PRNo, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(PRNo.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub InsertHeaderEntDirectSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, DeptID,PRNo, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(PRNo.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub UpdateHeader(ByVal _SettleID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE settle_header " & vbCrLf &
                                    "SET    SuspendID = " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
                                    "       PRNo = " & QVal(PRNo.TrimEnd) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       CuryID = " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
                                    "       Status = 'Close', " & vbCrLf &
                                    "       Total = " & QVal(Total) & " WHERE SettleID = '" & _SettleID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertData1()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderDirectSettle()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDataEntSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderEntSettle()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettle1()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDataEntSettleDirect()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderEntSettleDirect()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettleDirect()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData(_SettleID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(_SettleID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
Public Class SettleDetail
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property SuspendAmount As Long
    Public Property SettleAmount As Long
    Public Property Description As String
    Public Property ID As Integer
    Public Property Jenis As String
    Public Property JenisRelasi As String
    Public Property Nama As String
    Public Property NamaRelasi As String
    Public Property Nota As String
    Public Property Posisi As String
    Public Property proses As Boolean
    Public Property Relasi As String
    Public Property SettleID As String
    Public Property SubAcct As String
    Public Property Tempat As String
    Public Property Tgl As DateTime

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Description, Tgl, SuspendAmount, SettleAmount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEnt()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Description, Tgl, SuspendAmount, SettleAmount, AcctID, SubAcct,Nama,Tempat,Alamat,Jenis,NamaRelasi,Posisi,Relasi,JenisRelasi,Nota) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Posisi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Relasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nota.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertDetailsEntSettle()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SettleAmount,NamaRelasi,Posisi,Relasi,JenisRelasi,Nota ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Posisi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Relasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nota.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEntSettle1()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SuspendAmount,SettleAmount ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertDetailsEntSettleDirect()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SettleAmount ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub DeleteDetail(_SettleID As String)
        Try
            Dim ls_SP As String = "DELETE FROM settle_detail WHERE rtrim(SettleID)=" & QVal(_SettleID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    'Public Function GetDataDetailByID(_SettleID As String) As DataTable
    '    Try
    '        Dim sql As String = "
    '        SELECT
    '         settle.Tgl,
    '         settle.SubAcct SubAccount,
    '         settle.AcctID Account,
    '         settle.Description,
    '         suspend.Amount,
    '         settle.ActulAmount
    '        FROM
    '        (
    '        SELECT 
    '         sth.SuspendID,
    '         std.Tgl,
    '         std.SubAcct,
    '         std.AcctID,
    '         std.Description,
    '         std.Amount ActulAmount
    '        FROM dbo.settle_header sth INNER JOIN 
    '        dbo.settle_detail std on sth.SettleID = std.SettleID WHERE sth.SettleID = " & QVal(_SettleID) & ") settle Inner JOIN
    '        (
    '        SELECT 
    '         sph.SuspendID,
    '         spd.Amount
    '        FROM dbo.suspend_header sph INNER JOIN 
    '        dbo.suspend_detail spd on spd.SuspendID = spd.SuspendID
    '        WHERE sph.Tipe ='s'
    '        ) [suspend] on settle.SuspendID = suspend.SuspendID"
    '        Dim dt As New DataTable
    '        dt = GetDataTable_Solomon(sql)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetDataDetailByID(_SettleID As String) As DataTable
        Try
            Dim sql As String = "
            SELECT 
	            Tgl,
	            SubAcct SubAccount,
	            AcctID Account,
	            Description,
                SettleAmount ActualAmount
            FROM settle_detail WHERE SettleID = " & QVal(_SettleID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
