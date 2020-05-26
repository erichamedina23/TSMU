Imports System.Globalization

Public Class ClsSJ

    Public Property ShipperID() As String
    Public Property RelDate() As DateTime
    Public Property RecDate() As Nullable(Of DateTime)
    Public Property TglKirim() As Nullable(Of DateTime)
    Public Property NoRec() As String
    Public Property Checked() As Single
    Public Property CreatedBy() As String
    Public Property NoTran() As String

    Public Property CheckFIn() As Nullable(Of Integer)

    Public Property TglCheckFin() As Nullable(Of DateTime)
    Public Function GetdataGrid(cust As String, tgl1 As String, tgl2 As String, lokasi As String) As DataTable
        Try

            Dim sql As String =
                "
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,'' [NoRec]
                    ,so.User7 NoMobil
                    ,Convert(bit,so.user6) as [Check] 
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                    FROM soshipheader so left join
                    snote note on so.noteid=note.nid
                where so.CustID=coalesce(nullif('" & cust & "','ALL'),so.CustID) 
                AND so.RelDate >= '" & tgl1 & "' AND so.RelDate<='" & tgl2 & "'  
                AND SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & lokasi & "') 
                AND SUBSTRING(so.ShipperID,1,3)<>'RFC' 
                AND so.User6=0 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID
                "

            ',GETDATE() [Tanggal Terima]
            ',GETDATE() [Tanggal Kirim]

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            'dt = MainModul.GetDataTable_solomon(sql)
            'CultureInfo.CurrentCulture = New CultureInfo("id-ID")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetdataGridEdit(cust As String, tgl1 As String, tgl2 As String, lokasi As String, tgl3 As String, tgl4 As String, NoTran As Boolean) As DataTable
        Try
            Dim no As String = String.Empty
            If NoTran Then
                no = " AND (sj.NoTran IS NOT NULL OR sj.NoTran <> '')"
            Else
                no = " AND (sj.NoTran IS NULL OR sj.NoTran = '')"
            End If
            Dim sql As String =
                "
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,sj.RecDate [Tanggal Terima]
                    ,sj.TglKirim [Tanggal Kirim]
                    ,sj.[NoTran]
                    ,so.User7 NoMobil
                    ,case when sj.CheckFin is null then convert(bit,0) else convert(bit,sj.CheckFin) end AS [Check Fin]
                    ,CONVERT(VARCHAR(10), sj.TglCheckFin, 105) [Tgl Check Fin]
                    ,Convert(bit,so.user6) as [Check] 
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid inner join
                    SJChecking sj on so.ShipperID= sj.ShipperID
                where so.CustID=coalesce(nullif('" & cust & "','ALL'),so.CustID) 
                AND so.RelDate >= '" & tgl1 & "' AND so.RelDate<='" & tgl2 & "' AND convert(date,sj.RecDate) >= '" & tgl3 & "' AND convert(date,sj.RecDate) <= '" & tgl4 & "'
                AND SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & lokasi & "') " & no & "
                AND so.User6=1 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID 
                "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSJ(NoSJ As String, Lokasi As String) As DataTable

        Try
            Dim sql As String =
                "
                SELECT 
                    RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,GETDATE() [Tanggal Terima]
                    ,GETDATE() [Tanggal Kirim]
                    ,'' [NoRec]
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                    FROM soshipheader so left join
                    snote note on so.noteid=note.nid
                where 
                    SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & Lokasi & "') 
                    And RTrim(so.ShipperID) = '" & NoSJ.Trim() & "' 
                    AND SUBSTRING(so.ShipperID,1,3)<>'RFC' 
                    AND so.User6=0 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID
                "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            'CultureInfo.CurrentCulture = New CultureInfo("id-ID")
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSJByPOCustomer(POCust As String, Lokasi As String) As DataTable
        'Dim site1 As String

        Try

            Dim sql As String =
                "
                SELECT 
                    RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,GETDATE() [Tanggal Terima]
                    ,GETDATE() [Tanggal Kirim]
                    ,'' [NoRec]
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                    FROM soshipheader so left join
                    snote note on so.noteid=note.nid
                where 
                    SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & Lokasi & "')
                    And RTRIM(so.CUSTORDNBR) = '" & POCust.Trim() & "' 
                    And RelDate >='2018-10-01'  
                    AND SUBSTRING(so.ShipperID,1,3)<>'RFC' 
                    AND so.User6=0 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID
                "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            'CultureInfo.CurrentCulture = New CultureInfo("id-ID")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetSJBySRYIM(SRYIM As String, Lokasi As String) As DataTable
        'Dim site1 As String

        Try

            Dim sql As String =
                "
                SELECT 
                    RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,GETDATE() [Tanggal Terima]
                    ,GETDATE() [Tanggal Kirim]
                    ,'' [NoRec]
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid
                where 
                    SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & Lokasi & "')
                    And RTRIM(User4) = '" & SRYIM.Trim() & "' 
                    And RelDate >='2018-10-01'
                    AND SUBSTRING(so.ShipperID,1,3)<>'RFC' 
                    AND so.User6=0 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID
                "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            'CultureInfo.CurrentCulture = New CultureInfo("id-ID")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCustomer() As DataTable
        Try
            Dim ls_SP As String =
                "Select CustId [Customer ID], Name from Customer"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetNoTranPrint() As DataTable
        Try
            Dim ls_SP As String =
                "Select distinct NoTran [No Tanda Terima] from SJChecking"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function IsShipperIDExist() As Boolean
        Try
            Dim ls_SP As String =
                "Select [ShipperID] FROM [SJChecking] WHERE [ShipperID] = " & QVal(ShipperID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub UpdateUser6(Shipper As String, status As Boolean)
        Try
            Dim checked As Integer
            If status Then
                checked = 1
            Else
                checked = 0
            End If
            Dim sql As String =
                "Update soshipheader 
                Set User6= " & QVal(checked) & " where ShipperID ='" & Shipper & "'"

            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable()
        Try
            Dim chek As Integer
            If Checked Then
                chek = 1
            Else
                chek = 0
            End If
            Dim sql As String =
            "INSERT INTO [SJChecking]
            ([ShipperID]
            ,[RelDate]
            ,[RecDate]
            ,[TglKirim]
            ,[NoRec]
            ,[NoTran]
            ,[Checked]
            ,CreatedBy
            ,CreatedDate)
            VALUES
            (" & QVal(ShipperID) & "
            ," & QVal(RelDate) & "
            ," & QVal(RecDate) & "
            ," & QVal(TglKirim) & "
            ," & QVal(NoRec) & "
            ," & QVal(NoTran) & "
            ," & QVal(chek) & "
            ," & QVal(CreatedBy) & "
            ,GETDATE())"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateToTable()
        Try
            Dim status As Integer
            If Checked Then
                status = 1
            Else
                status = 0
            End If
            Dim sql As String =
            "Update [SJChecking] 
            SET [RelDate] = " & QVal(RelDate) & "
            ,[RecDate] = " & QVal(RecDate) & "
            ,[NoRec] = " & QVal(NoRec) & "
            ,[NoTran] = " & QVal(NoTran) & "
            ,[TglKirim] = NULL
            ,[Checked] = " & QVal(status) & "
            ,[UpdatedBy] = " & QVal(CreatedBy) & "
            ,[UpdatedDate] = GETDATE() WHERE [ShipperID] = " & QVal(ShipperID) & ""
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateNoTran()
        Try

            Dim sql As String =
            "Update [SJChecking] 
                SET [NoTran] = " & QVal(NoTran) & "
                ,[TglKirim] = " & QVal(DateTime.Today) & " 
            WHERE [ShipperID] = " & QVal(ShipperID) & ""
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Sub UpdateTglKirim()
    '    Try

    '        Dim sql As String =
    '        "Update [SJChecking] 
    '            SET [TglKirim] = " & QVal(DateTime.Today) & " 
    '        WHERE [NoTran] = " & QVal(ShipperID) & ""
    '        MainModul.ExecQuery_solomon(sql)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub UpdateToTableNew()
        Try
            Dim status As Integer
            If Checked Then
                status = 1
            Else
                status = 0
            End If
            Dim sql As String =
            "Update [SJChecking] 
            SET [RelDate] = " & QVal(RelDate) & "
            ,[RecDate] = " & QVal(RecDate) & "
            ,[NoRec] = " & QVal(NoRec) & "
            ,[NoTran] = " & QVal(NoTran) & "
            ,[TglKirim] = " & QVal(TglKirim) & "
            ,[Checked] = " & QVal(status) & "
            ,[UpdatedBy] = " & QVal(CreatedBy) & "
            ,[UpdatedDate] = GETDATE() WHERE [ShipperID] = " & QVal(ShipperID) & ""
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateToTable_Scan()
        Try
            Dim status As Integer
            If Checked Then
                status = 1
            Else
                status = 0
            End If
            Dim sql As String =
            "Update [SJChecking] 
            SET [RelDate] = " & QVal(RelDate) & "
            ,[RecDate] = " & QVal(RecDate) & "
            ,[NoRec] = " & QVal(NoRec) & "
            ,[NoTran] = " & QVal(NoTran) & "
            ,[TglKirim] = " & QVal(TglKirim) & "
            ,[Checked] = " & QVal(status) & "
            ,[UpdatedBy] = " & QVal(CreatedBy) & "
            ,[UpdatedDate] = GETDATE() WHERE [ShipperID] = " & QVal(ShipperID) & ""
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateFin()
        Try
            Dim status As Integer
            If CheckFIn Then
                status = 1
            Else
                status = 0
            End If
            Dim sql As String =
            "Update [SJChecking] 
            SET [CheckFin] = " & QVal(status) & "
            ,[TglCheckFin] = " & QVal(TglCheckFin) & "
            ,[UpdatedBy] = " & QVal(CreatedBy) & "
            ,[UpdatedDate] = GETDATE() WHERE [ShipperID] = " & QVal(ShipperID) & ""
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateNo(tahun As String, bulan As String, no As Integer, site As String)
        Try
            Dim id As Integer
            If Left(site, 3) = "TNG" Then
                id = 1
            Else
                id = 2
            End If
            Dim query As String =
            "
                update SJNumbering set LastNO = LastNo + " & QVal(no) & "
                WHERE id = " & QVal(id) & "
            "
            MainModul.ExecQuery_Solomon(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateNoToZero(tahun As String, bulan As String, no As Integer, site As String)
        Try
            Dim id As Integer
            If Left(site, 3) = "TNG" Then
                id = 1
            Else
                id = 2
            End If
            Dim query As String =
            "
                update SJNumbering set year= " & QVal(tahun) & "
                                        ,Month = " & QVal(bulan) & "
                                        ,LastNO = " & QVal(no) & "
                WHERE id = " & QVal(id) & "
            "
            MainModul.ExecQuery_Solomon(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetNo(site As String) As DataTable
        Dim id As Integer
        Try
            If Left(site, 3) = "TNG" Then
                id = 1
            Else
                id = 2
            End If
            Dim ls_SP As String =
                "SELECT [id]
                    ,[SitePrefix]
                    ,[Year]
                    ,[Month]
                    ,[LastNo]
                FROM [SJNumbering]
                WHERE id = " & QVal(id) & "
                "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function CheckNoTran(ShipperID As String) As Boolean
        Dim IsExist As Boolean = False
        Try

            Dim ls_SP As String =
                "
                    SELECT NoTran from SJChecking where ShipperID=" & QVal(ShipperID) & "
                "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable.Rows.Count > 0 Then
                If dtTable.Rows(0)("NoTran").ToString <> "" Then
                    IsExist = True
                End If
            End If
            Return IsExist
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function PrintPO(cust As String, tgl1 As String, tgl2 As String, lokasi As String, tgl3 As String, tgl4 As String) As DataSet
        Dim ds As dsLaporan
        Try
            Dim sql As String =
                "
                    SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,CONVERT(VARCHAR(10), sj.RecDate, 105) [Tanggal Terima]
                    ,CONVERT(VARCHAR(10), sj.TglKirim, 105) [Tanggal Kirim]
                    ,sj.[NoRec]
                    ,Convert(bit,so.user6) as [Check] 
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid inner join
                    SJChecking sj on so.ShipperID= sj.ShipperID
                where so.CustID=coalesce(nullif('" & cust & "','ALL'),so.CustID) 
                AND so.RelDate >= '" & tgl1 & "' AND so.RelDate<='" & tgl2 & "' AND sj.RecDate >= '" & tgl3 & "' AND sj.RecDate <= '" & tgl4 & "'
                AND SUBSTRING(so.ShipperID,1,1) in (SELECT ShipperID FROM SJShipperSetting WHERE Site ='" & lokasi & "') 
                AND so.User6=1 AND so.User3<>1 AND so.Cancelled<>1 Order By so.ShipperID
                "
            ds = New dsLaporan
            ds = MainModul.GetDsReport_Solomon(sql, "PrintPO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Function ReprintPrintPO() As DataSet
        Dim ds As dsLaporan
        Try
            Dim sql As String =
                "
                    SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    , CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,CONVERT(VARCHAR(10), sj.RecDate, 105) [Tanggal Terima]
                    ,CONVERT(VARCHAR(10), sj.TglKirim, 105) [Tanggal Kirim]
                    ,sj.[NoRec]
                    ,Convert(bit,so.user6) as [Check] 
                    ,RTRIM(so.User4) [SR YIM]
                    ,RTRIM(so.user1) [Batch Invoice]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid inner join
                    SJChecking sj on so.ShipperID= sj.ShipperID
                where sj.notran= " & QVal(NoTran) & "
                "
            ds = New dsLaporan
            ds = MainModul.GetDsReport_Solomon(sql, "PrintPO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Function GetSJbyNoTran(IsLoad As Boolean) As DataTable
        Dim dt As DataTable
        Dim sql As String = String.Empty
        Try
            If IsLoad Then
                sql =
                "
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    ,CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,getdate() [Tanggal Terima]
                    ,getdate() [Tanggal Kirim]
                    ,sj.[NoRec]
                    ,convert(bit,1) as [Check]
                    ,case when sj.[TglCheckFin] is NULL then getdate()
                            else sj.[TglCheckFin] end as [Tgl Check Fin]
                    ,RTRIM(so.User4) [SR YIM]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid inner join
                    SJChecking sj on so.ShipperID= sj.ShipperID
                WHERE sj.NoTran = " & QVal(NoTran) & "
                "
            Else
                sql =
                "
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY so.ShipperID ASC) AS No
                    ,RTRIM(so.custid) [Customer]
                    ,RTRIM(so.ShipperID) [No Surat Jalan]
                    ,RTRIM(so.ORDNBR) [Sales Order]
                    ,RTRIM(so.CUSTORDNBR) [PO Customer]
                    ,CONVERT(VARCHAR(10), so.RelDate, 105) [Tanggal SJ]
                    ,sj.RecDate [Tanggal Terima]
                    ,sj.TglKirim [Tanggal Kirim]
                    ,sj.[NoRec]
                    ,sj.CheckFin as [Check]
                    ,sj.[TglCheckFin] as [Tgl Check Fin]
                    ,RTRIM(so.User4) [SR YIM]
                    ,note.sNoteText Ket
                    ,RTRIM(so.Inbatnbr) [Batch Issue]
                FROM soshipheader so left join
                    snote note on so.noteid=note.nid inner join
                    SJChecking sj on so.ShipperID= sj.ShipperID
                WHERE sj.NoTran = " & QVal(NoTran) & "
                "
            End If

            dt = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class
