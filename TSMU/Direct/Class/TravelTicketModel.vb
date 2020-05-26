Imports System.Collections.ObjectModel

Public Class TravelTicketModel
    Public Property NoVoucher As String
    Public Property Tanggal As Date
    Public Property VendorID As String
    Public Property NoInvoice As String
    Public Property CuryID As String
    Public Property TotAmount As Double

    Dim strQuery As String

    Public Property ObjTravelTicketDetail() As New Collection(Of TravelTicketDetailModel)

    Public Function TravelAutoNoVoucher() As String
        Try
            strQuery = " DECLARE @bulan VARCHAR(4) " &
                        " DECLARE @tahun VARCHAR(4) " &
                        " DECLARE @seq VARCHAR(4) " &
                        " SET @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                        " SET @tahun = DATEPART(YEAR, GETDATE()) " &
                        " SET @seq = ( SELECT RIGHT('0000' " &
                        "                           + CAST(RIGHT(RTRIM(MAX(NoVoucher)), 4) + 1 AS VARCHAR), " &
                        "                           4) " &
                        "              From dbo.TravelTicket " &
                        "              WHERE  SUBSTRING(NoVoucher, 1, 7) = 'TT' + '-' + RIGHT(@tahun, 4) " &
                        "                     And SUBSTRING(NoVoucher, 9, 2) = RIGHT(@bulan, 2) " &
                        "            ) " &
                        " SELECT 'TT' + '-' + RIGHT(@tahun, 4) + '-' + @bulan + '-' + COALESCE(@seq, " &
                        "                                                               '0001') "

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetTravelRequest() As DataTable
        Try
            strQuery = " SELECT  trh.NoRequest ,
                                trh.Nama ,
                                trh.DeptID ,
                                trh.Purpose ,
                                trh.TravelType ,
                                trd.Destination ,
                                trd.Negara ,
                                trd.Visa ,
                                trd.DepartureDate ,
                                trd.ArrivalDate
                        FROM    dbo.TravelRequestHeader AS trh
                                LEFT JOIN dbo.TravelRequestDetail AS trd ON trd.NoRequest = trh.NoRequest
                                LEFT JOIN dbo.TravelTicketDetail AS ttd ON ttd.NoRequest = trd.NoRequest
                                                                            AND ttd.Seq = trd.Seq
                        WHERE   ttd.NoRequest IS NULL "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelTicket() As DataTable
        Try
            strQuery = " SELECT  NoVoucher ,
                                Tanggal ,
                                VendorID ,
                                NoInvoice ,
                                CuryID ,
                                TotAmount
                        FROM    dbo.TravelTicket "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelTicketDetail() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Get_TravelTicketDetail"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NoVoucher", SqlDbType.VarChar)
            pParam(0).Value = IIf(NoVoucher = Nothing, "", NoVoucher)

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelRequestByID() As DataTable
        Try
            strQuery = " SELECT  trh.NoRequest ,
                                trh.Nama ,
                                trh.DeptID ,
                                trh.Purpose ,
                                trh.TravelType ,
                                trd.Destination ,
                                trd.Negara ,
                                trd.Visa ,
                                trd.DepartureDate ,
                                trd.ArrivalDate
                        FROM    dbo.TravelRequestHeader AS trh
                                LEFT JOIN dbo.TravelRequestDetail AS trd ON trd.NoRequest = trh.NoRequest "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetTravelTicketByID()
        Try
            strQuery = " SELECT  NoVoucher ,
                                Tanggal ,
                                VendorID ,
                                NoInvoice ,
                                CuryID ,
                                TotAmount
                        FROM    dbo.TravelTicket
                        WHERE   NoVoucher = " & QVal(NoVoucher) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            If dt.Rows.Count > 0 Then
                NoVoucher = If(IsDBNull(dt.Rows(0).Item("NoVoucher")), "", Trim(dt.Rows(0).Item("NoVoucher").ToString()))
                Tanggal = If(IsDBNull(dt.Rows(0).Item("Tanggal")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tanggal")))
                VendorID = If(IsDBNull(dt.Rows(0).Item("VendorID")), "", Trim(dt.Rows(0).Item("VendorID").ToString()))
                NoInvoice = If(IsDBNull(dt.Rows(0).Item("NoInvoice")), "", Trim(dt.Rows(0).Item("NoInvoice").ToString()))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Trim(dt.Rows(0).Item("CuryID").ToString()))
                TotAmount = If(IsDBNull(dt.Rows(0).Item("TotAmount")), 0, Convert.ToDouble(dt.Rows(0).Item("TotAmount")))
            End If
        Catch ex As Exception
            Throw ex
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

                        For i As Integer = 0 To ObjTravelTicketDetail.Count - 1
                            With ObjTravelTicketDetail(i)
                                .InsertDetail()
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

    Public Sub InsertHeader()
        Try
            Dim SP_Name As String = "Travel_Insert_TravelTicketHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

            pParam(0) = New SqlClient.SqlParameter("@NoVoucher", SqlDbType.VarChar)
            pParam(0).Value = NoVoucher
            pParam(1) = New SqlClient.SqlParameter("@Tanggal", SqlDbType.Date)
            pParam(1).Value = Tanggal
            pParam(2) = New SqlClient.SqlParameter("@VendorID", SqlDbType.VarChar)
            pParam(2).Value = VendorID
            pParam(3) = New SqlClient.SqlParameter("@NoInvoice", SqlDbType.VarChar)
            pParam(3).Value = NoInvoice
            pParam(4) = New SqlClient.SqlParameter("@CuryID", SqlDbType.VarChar)
            pParam(4).Value = CuryID
            pParam(5) = New SqlClient.SqlParameter("@TotAmount", SqlDbType.Float)
            pParam(5).Value = TotAmount
            pParam(6) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(6).Value = gh_Common.Username

            MainModul.ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        UpdateHeader()

                        Dim ObjTicketDetail As New TravelTicketDetailModel
                        ObjTicketDetail.DeleteDetail(NoVoucher)

                        For i As Integer = 0 To ObjTravelTicketDetail.Count - 1
                            With ObjTravelTicketDetail(i)
                                .InsertDetail()
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

    Public Sub UpdateHeader()
        Try
            strQuery = " UPDATE  dbo.TravelTicket " & vbCrLf &
                        " SET     VendorID = " & QVal(VendorID) & " , " & vbCrLf &
                        "         NoInvoice = " & QVal(NoInvoice) & " , " & vbCrLf &
                        "         CuryID = " & QVal(CuryID) & " , " & vbCrLf &
                        "         TotAmount = " & QVal(TotAmount) & " , " & vbCrLf &
                        "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
                        "         UpdatedDate = GETDATE() " & vbCrLf &
                        " WHERE   NoVoucher = " & QVal(NoVoucher) & " "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        DeleteHeader(NoVoucher)

                        Dim ObjTicketDetail As New TravelTicketDetailModel
                        ObjTicketDetail.DeleteDetail(NoVoucher)

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
            Throw ex
        End Try
    End Sub

    Public Sub DeleteHeader(ByVal _NoVoucher As String)
        Try
            Dim ls_SP As String = " DELETE FROM dbo.TravelTicket
                                    WHERE NoVoucher = " & QVal(_NoVoucher) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetTravelVendor() As DataTable
        Try
            strQuery = " SELECT  VendId ,
                                Name
                        FROM    dbo.Vendor "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class TravelTicketDetailModel

    Public Property NoRequest As String
    Public Property NoVoucher As String
    Public Property Seq As Integer
    Public Property TicketNumber As String
    Public Property CuryID As String
    Public Property Amount As Double

    Dim strQuery As String

    Public Sub InsertDetail()
        Try
            Dim SP_Name As String = "Travel_Insert_TravelTicketDetail"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

            pParam(0) = New SqlClient.SqlParameter("@NoVoucher", SqlDbType.VarChar)
            pParam(0).Value = NoVoucher
            pParam(1) = New SqlClient.SqlParameter("@NoRequest", SqlDbType.VarChar)
            pParam(1).Value = NoRequest
            pParam(2) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(2).Value = Seq
            pParam(3) = New SqlClient.SqlParameter("@TicketNumber", SqlDbType.VarChar)
            pParam(3).Value = TicketNumber
            pParam(4) = New SqlClient.SqlParameter("@CuryID", SqlDbType.VarChar)
            pParam(4).Value = CuryID
            pParam(5) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
            pParam(5).Value = Amount

            MainModul.ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal _NoVoucher As String)
        Try
            Dim ls_SP As String = " DELETE FROM dbo.TravelTicketDetail
                                    WHERE NoVoucher = " & QVal(_NoVoucher) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
