Imports System.Collections.ObjectModel

Public Class TravelSettleHeader
    Public Property TravelHeaderID As Integer
    Public Property DeptID As String
    Public Property Destination As String
    ' Public Property ID As Integer
    Public Property Nama As String
    Public Property PickUp As String
    Public Property Purpose As String
    Public Property Term As String
    Public Property TotalAdvanceYEN As Double
    Public Property TotalAdvanceIDR As Double
    Public Property TotalAdvanceUSD As Double
    Public Property TotalAdvIDR As Double
    Public Property TravelID As String
    Public Property TravelSettleID As String
    Public Property Visa As String
    Public Property Tgl As DateTime
    Public Property Depdate As DateTime
    Public Property Arrdate As DateTime
    Public Property TglTiba As DateTime
    Public Property TglBerangkat As DateTime
    Public Property _id As String
    Public Property pay As Single
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Public Property ObjDetails() As New Collection(Of TravelSettleDetail)

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable

            Dim sql As String = "SELECT TravelSettleHeaderID      ,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba FROM TravelSettleHeader where pay=0 AND DeptID='" & gh_Common.GroupID & "'"

            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function loadreport2a() As DataSet
        Dim query As String
        query = "SELECT settle_detail.TravelSettleID
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
                      FROM settle_header left join settle_detail on settle_detail.TravelSettleID=settle_header.TravelSettleID where settle_header.TravelSettleID='" & TravelSettleID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "settle")
        Return ds

    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dt As New DataTable

            Dim sql As String = "SELECT TravelHeaderID      ,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba  FROM TravelHeader where pay=1 AND DeptID='" & gh_Common.GroupID & "'"

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
	, settle_header.TravelSettleID
	, settle_header.TravelID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.TravelSettleID=settle_detail.TravelSettleID 
where DeptID='" & gh_Common.GroupID & "' and settle_header.TravelSettleID like '%ET%' 
group by settle_header.ID
	, settle_header.TravelSettleID
	, settle_header.TravelID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.TravelSettleID, settle_header.TravelID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.TravelSettleID=settle_detail.TravelSettleID 
            'where settle_header.TravelID like '%EN%'"
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
	, settle_header.TravelSettleID
	, settle_header.TravelID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.TravelSettleID=settle_detail.TravelSettleID 
where DeptID='" & gh_Common.GroupID & "' and (settle_header.TravelID like '%EN%' AND settle_header.TravelID is null)  OR settle_header.TravelID like '%EN%'
 and status='Close' and pay='1'
group by settle_header.ID
	, settle_header.TravelSettleID
	, settle_header.TravelID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.TravelSettleID, settle_header.TravelID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.TravelSettleID=settle_detail.TravelSettleID 
            'where settle_header.TravelID like '%EN%'"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub GetSettleById()
        Try
            Dim sql As String =
            "SELECT TravelHeaderID,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba    FROM TravelHeader where TravelHeaderID=" & QVal(TravelHeaderID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                '  ID = If(IsDBNull(dt.Rows(0).Item("TravelHeaderID")), "", Trim(dt.Rows(0).Item("TravelHeaderID").ToString()))
                TravelID = If(IsDBNull(dt.Rows(0).Item("TravelID")), "", Trim(dt.Rows(0).Item("TravelID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Depdate = If(IsDBNull(dt.Rows(0).Item("TglBerangkat")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Arrdate = If(IsDBNull(dt.Rows(0).Item("TglTiba")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalAdvIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                Purpose = If(IsDBNull(dt.Rows(0).Item("Purpose")), "", Convert.ToString(dt.Rows(0).Item("Purpose")))
                Visa = If(IsDBNull(dt.Rows(0).Item("Visa")), "", Trim(dt.Rows(0).Item("Visa").ToString()))
                PickUp = If(IsDBNull(dt.Rows(0).Item("PickUp")), "", Trim(dt.Rows(0).Item("PickUp").ToString()))

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetSettleByIdEnt()
        Try
            Dim sql As String =
            "SELECT TravelHeaderID,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba    FROM TravelHeader where TravelHeaderID=" & QVal(TravelHeaderID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                '  ID = If(IsDBNull(dt.Rows(0).Item("TravelHeaderID")), "", Trim(dt.Rows(0).Item("TravelHeaderID").ToString()))
                TravelID = If(IsDBNull(dt.Rows(0).Item("TravelID")), "", Trim(dt.Rows(0).Item("TravelID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Depdate = If(IsDBNull(dt.Rows(0).Item("TglBerangkat")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Arrdate = If(IsDBNull(dt.Rows(0).Item("TglTiba")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalAdvIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                Purpose = If(IsDBNull(dt.Rows(0).Item("Purpose")), "", Convert.ToString(dt.Rows(0).Item("Purpose")))
                Visa = If(IsDBNull(dt.Rows(0).Item("Visa")), "", Trim(dt.Rows(0).Item("Visa").ToString()))
                PickUp = If(IsDBNull(dt.Rows(0).Item("PickUp")), "", Trim(dt.Rows(0).Item("PickUp").ToString()))

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetListSuspend() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID ID, TravelID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND Tipe = 'S' AND Pay=1 AND Status ='Approved' Order by TravelID"
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
            "SELECT SuspendHeaderID ID, TravelID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE Tipe = 'E' AND Pay=1 AND Status='Approved' Order by TravelID"
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
                "set @seq= (select right('0000'+cast(right(rtrim(max(TravelSettleID)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(TravelSettleID,1,2) = 'ST' and SUBSTRING(TravelSettleID,4,4) = RIGHT(@tahun,4) AND SUBSTRING(TravelSettleID,9,2) = RIGHT(@bulan,2)) " &
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
                "set @seq= (select right('0000'+cast(right(rtrim(max(TravelSettleID)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(TravelSettleID,1,2)='ET' AND SUBSTRING(TravelSettleID,4,4) = RIGHT(@tahun,4) AND SUBSTRING(TravelSettleID,9,2) = RIGHT(@bulan,2)) " &
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
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TravelHeader (TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Destination) & ", " & vbCrLf &
            "       " & QVal(Term) & ", " & vbCrLf &
            "       " & QVal(Purpose) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PickUp) & ", " & vbCrLf &
            "       " & QVal(Visa) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
            "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Depdate) & ", " & vbCrLf &
             "       " & QVal(Arrdate) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub InsertHeaderEntSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO TravelSettleHeader
           (TravelSettleID
           ,TravelID
           ,Nama
           ,Destination
           ,Term
           ,Purpose
           ,DeptID
           ,PickUp
           ,Visa
           ,TotalAdvanceIDR
           ,TotalAdvanceUSD
           ,TotalAdvanceYEN
           ,Tgl
           ,TglBerangkat
           ,TglTiba
           ,TotalAdvIDR
           ,Status
           ,pay) " & vbCrLf &
     "Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(Nama) & ", " & vbCrLf &
           "       " & QVal(Destination) & ", " & vbCrLf &
           "       " & QVal(Term) & ", " & vbCrLf &
           "       " & QVal(Purpose) & ", " & vbCrLf &
           "       " & QVal(DeptID) & ", " & vbCrLf &
           "       " & QVal(PickUp) & ", " & vbCrLf &
           "       " & QVal(Visa) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
           "       " & QVal(Tgl) & ", " & vbCrLf &
           "       " & QVal(TglBerangkat) & ", " & vbCrLf &
           "       " & QVal(TglTiba) & ", " & vbCrLf &
           "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(pay) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try



    End Sub


    Public Sub InsertHeaderEntSettleDirect()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO TravelSettleHeader
           (TravelSettleID
           ,TravelID
           ,Nama
           ,Destination
           ,Term
           ,Purpose
           ,DeptID
           ,PickUp
           ,Visa
           ,TotalAdvanceIDR
           ,TotalAdvanceUSD
           ,TotalAdvanceYEN
           ,Tgl
           ,TglBerangkat
           ,TglTiba
           ,TotalAdvIDR
           ,Status
           ,pay) " & vbCrLf &
     "Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(Nama) & ", " & vbCrLf &
           "       " & QVal(Destination) & ", " & vbCrLf &
           "       " & QVal(Term) & ", " & vbCrLf &
           "       " & QVal(Purpose) & ", " & vbCrLf &
           "       " & QVal(DeptID) & ", " & vbCrLf &
           "       " & QVal(PickUp) & ", " & vbCrLf &
           "       " & QVal(Visa) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
           "       " & QVal(Tgl) & ", " & vbCrLf &
           "       " & QVal(TglBerangkat) & ", " & vbCrLf &
           "       " & QVal(TglTiba) & ", " & vbCrLf &
           "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(pay) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        'Try
        '    Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(TravelID)=" & QVal(_TravelID.TrimEnd) & ""
        '    ExecQuery_Solomon(ls_SP)
        'Catch ex As Exception
        '    Throw
        'End Try

    End Sub



    Public Sub InsertHeader2()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO TravelSettleHeader
           (TravelSettleID
           ,TravelID
           ,Nama
           ,Destination
           ,Term
           ,Purpose
           ,DeptID
           ,PickUp
           ,Visa
           ,TotalAdvanceIDR
           ,TotalAdvanceUSD
           ,TotalAdvanceYEN
           ,Tgl
           ,TglBerangkat
           ,TglTiba
           ,TotalAdvIDR
           ,Status
           ,pay) " & vbCrLf &
     "Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(Nama) & ", " & vbCrLf &
           "       " & QVal(Destination) & ", " & vbCrLf &
           "       " & QVal(Term) & ", " & vbCrLf &
           "       " & QVal(Purpose) & ", " & vbCrLf &
           "       " & QVal(DeptID) & ", " & vbCrLf &
           "       " & QVal(PickUp) & ", " & vbCrLf &
           "       " & QVal(Visa) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
           "       " & QVal(Tgl) & ", " & vbCrLf &
           "       " & QVal(TglBerangkat) & ", " & vbCrLf &
           "       " & QVal(TglTiba) & ", " & vbCrLf &
           "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(pay) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        Try
            Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(TravelID)=" & QVal(_TravelID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub InsertHeaderDirectSettle()
        Dim ls_SP As String = String.Empty
        Try
            ls_SP = "INSERT INTO TravelSettleHeader
           (TravelSettleID
           ,TravelID
           ,Nama
           ,Destination
           ,Term
           ,Purpose
           ,DeptID
           ,PickUp
           ,Visa
           ,TotalAdvanceIDR
           ,TotalAdvanceUSD
           ,TotalAdvanceYEN
           ,Tgl
           ,TglBerangkat
           ,TglTiba
           ,TotalAdvIDR
           ,Status
           ,pay) " & vbCrLf &
     "Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(Nama) & ", " & vbCrLf &
           "       " & QVal(Destination) & ", " & vbCrLf &
           "       " & QVal(Term) & ", " & vbCrLf &
           "       " & QVal(Purpose) & ", " & vbCrLf &
           "       " & QVal(DeptID) & ", " & vbCrLf &
           "       " & QVal(PickUp) & ", " & vbCrLf &
           "       " & QVal(Visa) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
           "       " & QVal(Tgl) & ", " & vbCrLf &
           "       " & QVal(TglBerangkat) & ", " & vbCrLf &
           "       " & QVal(TglTiba) & ", " & vbCrLf &
           "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(pay) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub InsertHeaderEntDirectSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO TravelSettleHeader
           (TravelSettleID
           ,TravelID
           ,Nama
           ,Destination
           ,Term
           ,Purpose
           ,DeptID
           ,PickUp
           ,Visa
           ,TotalAdvanceIDR
           ,TotalAdvanceUSD
           ,TotalAdvanceYEN
           ,Tgl
           ,TglBerangkat
           ,TglTiba
           ,TotalAdvIDR
           ,Status
           ,pay) " & vbCrLf &
     "Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(Nama) & ", " & vbCrLf &
           "       " & QVal(Destination) & ", " & vbCrLf &
           "       " & QVal(Term) & ", " & vbCrLf &
           "       " & QVal(Purpose) & ", " & vbCrLf &
           "       " & QVal(DeptID) & ", " & vbCrLf &
           "       " & QVal(PickUp) & ", " & vbCrLf &
           "       " & QVal(Visa) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
           "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
           "       " & QVal(Tgl) & ", " & vbCrLf &
           "       " & QVal(TglBerangkat) & ", " & vbCrLf &
           "       " & QVal(TglTiba) & ", " & vbCrLf &
           "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(pay) & ")"
            ExecQuery_Solomon(ls_SP)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub UpdateHeader(ByVal _TravelSettleID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
 "UPDATE TravelSettleHeader " & vbCrLf &
  " SET TravelSettleID = " & QVal(TravelSettleID) & ", " & vbCrLf &
" TravelID = " & QVal(TravelID) & ", " & vbCrLf &
" Nama = " & QVal(Nama) & ", " & vbCrLf &
" Destination = " & QVal(Destination) & ", " & vbCrLf &
" Term = " & QVal(Term) & ", " & vbCrLf &
" Purpose = " & QVal(Purpose) & ", " & vbCrLf &
" DeptID = " & QVal(DeptID) & ", " & vbCrLf &
" PickUp = " & QVal(PickUp) & ", " & vbCrLf &
" Visa = " & QVal(Visa) & ", " & vbCrLf &
" TotalAdvanceIDR = " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
" TotalAdvanceUSD = " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
" TotalAdvanceYEN = " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
" Tgl = " & QVal(Tgl) & ", " & vbCrLf &
" TglBerangkat = " & QVal(TglBerangkat) & ", " & vbCrLf &
" TglTiba = " & QVal(TglTiba) & ", " & vbCrLf &
" TotalAdvIDR = " & QVal(TotalAdvIDR) & ", " & vbCrLf &
" Status = 'Close', " & vbCrLf &
" pay = " & QVal(pay) & " WHERE TravelSettleID = '" & _TravelSettleID & "'"
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


    Public Sub UpdateData(_TravelSettleID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_TravelSettleID)

                        Dim ObjTravelSettleDetail As New TravelSettleDetail
                        ObjTravelSettleDetail.DeleteDetail(_TravelSettleID)

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
Public Class TravelSettleDetail
    Public Property AcctID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double
    Public Property CuryID As String
    Public Property Description As String
    Public Property EntertainID As String
    Public Property Proses As Boolean
    Public Property Rate As Double
    Public Property SubAcct As String
    Public Property TravelID As String
    Public Property TravelSettleDetailID As Integer
    Public Property TravelSettleID As String

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
"INSERT INTO TravelSettleDetail
           (TravelSettleID
           ,TravelID
           ,EntertainID
           ,Description
           ,Amount
           ,Rate
           ,AmountIDR
           ,AcctID
           ,SubAcct
           ,CuryID
           ,Proses) " & vbCrLf &
"Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(EntertainID) & ", " & vbCrLf &
           "       " & QVal(Description) & ", " & vbCrLf &
           "       " & QVal(Amount) & ", " & vbCrLf &
           "       " & QVal(Rate) & ", " & vbCrLf &
           "       " & QVal(AmountIDR) & ", " & vbCrLf &
           "       " & QVal(AcctID) & ", " & vbCrLf &
           "       " & QVal(SubAcct) & ", " & vbCrLf &
           "       " & QVal(CuryID) & ", " & vbCrLf &
           "       " & QVal(Proses) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEnt()
        Try
            Dim ls_SP As String = " " & vbCrLf &
"INSERT INTO TravelSettleDetail
           (TravelSettleID
           ,TravelID
           ,EntertainID
           ,Description
           ,Amount
           ,Rate
           ,AmountIDR
           ,AcctID
           ,SubAcct
           ,CuryID
           ,Proses) " & vbCrLf &
"Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(EntertainID) & ", " & vbCrLf &
           "       " & QVal(Description) & ", " & vbCrLf &
           "       " & QVal(Amount) & ", " & vbCrLf &
           "       " & QVal(Rate) & ", " & vbCrLf &
           "       " & QVal(AmountIDR) & ", " & vbCrLf &
           "       " & QVal(AcctID) & ", " & vbCrLf &
           "       " & QVal(SubAcct) & ", " & vbCrLf &
           "       " & QVal(CuryID) & ", " & vbCrLf &
           "       " & QVal(Proses) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertDetailsEntSettle()
        Try
            Dim ls_SP As String = " " & vbCrLf &
"INSERT INTO TravelSettleDetail
           (TravelSettleID
           ,TravelID
           ,EntertainID
           ,Description
           ,Amount
           ,Rate
           ,AmountIDR
           ,AcctID
           ,SubAcct
           ,CuryID
           ,Proses) " & vbCrLf &
"Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(EntertainID) & ", " & vbCrLf &
           "       " & QVal(Description) & ", " & vbCrLf &
           "       " & QVal(Amount) & ", " & vbCrLf &
           "       " & QVal(Rate) & ", " & vbCrLf &
           "       " & QVal(AmountIDR) & ", " & vbCrLf &
           "       " & QVal(AcctID) & ", " & vbCrLf &
           "       " & QVal(SubAcct) & ", " & vbCrLf &
           "       " & QVal(CuryID) & ", " & vbCrLf &
           "       " & QVal(Proses) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEntSettle1()
        Try
            Dim ls_SP As String = " " & vbCrLf &
"INSERT INTO TravelSettleDetail
           (TravelSettleID
           ,TravelID
           ,EntertainID
           ,Description
           ,Amount
           ,Rate
           ,AmountIDR
           ,AcctID
           ,SubAcct
           ,CuryID
           ,Proses) " & vbCrLf &
"Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(EntertainID) & ", " & vbCrLf &
           "       " & QVal(Description) & ", " & vbCrLf &
           "       " & QVal(Amount) & ", " & vbCrLf &
           "       " & QVal(Rate) & ", " & vbCrLf &
           "       " & QVal(AmountIDR) & ", " & vbCrLf &
           "       " & QVal(AcctID) & ", " & vbCrLf &
           "       " & QVal(SubAcct) & ", " & vbCrLf &
           "       " & QVal(CuryID) & ", " & vbCrLf &
           "       " & QVal(Proses) & ")"
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertDetailsEntSettleDirect()
        Try
            Dim ls_SP As String = " " & vbCrLf &
"INSERT INTO TravelSettleDetail
           (TravelSettleID
           ,TravelID
           ,EntertainID
           ,Description
           ,Amount
           ,Rate
           ,AmountIDR
           ,AcctID
           ,SubAcct
           ,CuryID
           ,Proses) " & vbCrLf &
"Values(" & QVal(TravelSettleID) & ", " & vbCrLf &
           "       " & QVal(TravelID) & ", " & vbCrLf &
           "       " & QVal(EntertainID) & ", " & vbCrLf &
           "       " & QVal(Description) & ", " & vbCrLf &
           "       " & QVal(Amount) & ", " & vbCrLf &
           "       " & QVal(Rate) & ", " & vbCrLf &
           "       " & QVal(AmountIDR) & ", " & vbCrLf &
           "       " & QVal(AcctID) & ", " & vbCrLf &
           "       " & QVal(SubAcct) & ", " & vbCrLf &
           "       " & QVal(CuryID) & ", " & vbCrLf &
           "       " & QVal(Proses) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub DeleteDetail(_TravelSettleID As String)
        Try
            Dim ls_SP As String = "DELETE FROM settle_detail WHERE rtrim(TravelSettleID)=" & QVal(_TravelSettleID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataDetailByID(_TravelSettleID As String) As DataTable
        Try
            Dim sql As String = "
            SELECT 
	            Tgl,
	            SubAcct SubAccount,
	            AcctID Account,
	            Description,
                SettleAmount ActualAmount
            FROM settle_detail WHERE TravelSettleID = " & QVal(_TravelSettleID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
