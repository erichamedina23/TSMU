Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Cls_Npwo_Detail

    Public Property NoUrut As Integer
    Public Property H_No_Npwo As String
    Public Property H_No_NPP As String

    Public Property H_Issue_Date As DateTime
    Public Property H_Model_Name As String
    Public Property H_Model_Desc As String
    Public Property H_Customer_Name As String
    Public Property H_Order_Month As Integer
    Public Property H_Order_Max_Month As Integer
    Public Property H_T0 As Date
    Public Property H_T1 As Date
    Public Property H_T2 As Date
    Public Property H_MP As Date
    Public Property H_Drawing As Boolean
    Public Property H_CAD_Data As Boolean
    Public Property H_Sample As Boolean
    Public Property H_Special_Technical_Requires As Boolean
    Public Property H_Category_Class As String
    Public Property H_Factory_Tsc_TNG As Boolean
    Public Property H_Factory_Tsc_CKR As Boolean
    Public Property H_Factory_Tsc_0 As Boolean
    Public Property H_Factory_Tsc_1 As Boolean
    Public Property H_CreatedBy As String
    Public Property H_CreatedDate As Date
    Public Property H_UpdatedBy As String
    Public Property H_UpdatedDate As Date
    Public Property H_Approve As Boolean
    Public Property H_Rev As Integer
    Public Property H_Checked As String
    Public Property H_A1 As String
    Public Property H_A2 As String
    Public Property H_A3 As String
    Public Property H_A4 As String
    Public Property H_Rev_Info As String


    Public Property Collection_Detail() As New Collection(Of Col_Cls_Npwo_Detail_NPWO)
    Public Property Collection_Detail_1() As New Collection(Of Col_Cls_Npwo_Detail_1_NPWO)



    Public Function GetApprove() As DataTable
        Try
            Dim query As String = "Select * From NPP_Approve"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function NpwoReport(No As String, Rev As String) As DataSet
        Dim query As String
        'Dim NP As String = "TSC/NPP/MKT/04/SIM-Y98/2020/001"
        query = "SELECT Distinct [NPWO_Head].[No_NPP]
                  ,[Npwo_Head].[No_Npwo]
                  ,[Npwo_Head].[Issue_Date]
                  ,[Npwo_Head].[Model_Name]
                  ,[Customer].[BillName] as [Customer_Name]
                  ,[Npwo_Head].[Order_Month]
                  ,[Npwo_Head].[Order_Max_Month]
                  ,convert(varchar, [Npwo_Head].[T0], 110) as [T0]
                  ,convert(varchar, [Npwo_Head].[T1], 110) as [T1]
                  ,convert(varchar, [Npwo_Head].[T2], 110) as [T2]
                  ,convert(varchar, [Npwo_Head].[MP], 110) as [MP]
                  ,[Npwo_Head].[Drawing]
                  ,[Npwo_Head].[CAD_Data]
                  ,[Npwo_Head].[Sample]
                  ,[Npwo_Head].[Special_Technical_Requires]
                  ,[Npwo_Head].[Category_Class]
                  ,[Npwo_Head].[Factory_Tsc_TNG]
                  ,[Npwo_Head].[Factory_Tsc_CKR]
                  ,[Npwo_Head].[Factory_Tsc_0]
                  ,[Npwo_Head].[Factory_Tsc_1]
                  ,[Npwo_Head].[CreatedBy]
                  ,[Npwo_Head].[CreatedDate]
                  ,[Npwo_Head].[UpdatedBy]
                  ,[Npwo_Head].[UpdatedDate]
                  ,[Npwo_Head].[Approve]
                  ,[Npwo_Head].[Checked]
                  ,[Npwo_Head].[A1]
                  ,[Npwo_Head].[A2]
                  ,[Npwo_Head].[A3]
                  ,[Npwo_Head].[A4]
                  ,[Npwo_Head].[Prepare]
                  ,[Npwo_Head].[CreatedBy]
                  ,[NpwoDetail1].[Part_No]
                  ,[NpwoDetail1].[Part_Name]
                  ,[NpwoDetail1].[Machine]
                  ,[NpwoDetail1].[Cycle_Time]
                  ,[NpwoDetail1].[Cavity]
                  ,[NpwoDetail1].[Weight]
                  ,[NpwoDetail1].[Qty_Mold]
                  ,[NpwoDetail1].[Material_Resin]
                  ,[NpwoDetail1].[Injection]
                  ,[NpwoDetail1].[Painting]
                  ,[NpwoDetail1].[Chrome]
                  ,[NpwoDetail1].[Assy]
                  ,[NpwoDetail1].[Ultrasonic]
                  ,[NpwoDetail1].[Vibration]
                  ,[NpwoDetail1].[StatusMold]
                  ,[NpwoDetail1].[Order_Month]
                  ,[NpwoDetail1].[LOI_Number]
                  ,[NpwoDetail1].[Forecast]
                  ,[NpwoDetail1].[GroupID]
                  ,[NpwoDetail1].[Type]
                  ,[NpwoDetail1].[Type1]
                  ,[NpwoDetail1].[Rev]
        From [NPWO_Head] inner Join [NpwoDetail1] On
        [NPWO_Head].[No_Npwo] = [NpwoDetail1].No_Npwo
        inner join Customer on Customer.CustId =  [NPWO_Head].[Customer_Name]
		Where [NPWO_Head].[No_Npwo] = '" & No & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport(query, "NPWO")
        Return ds

    End Function

    Public Function GetGroupIDAuto(Row As Integer) As String
        Try
            Dim GroupID As String = ""

            Dim ls_SP As String = "SELECT top 1 Mold_Number as GroupID , RIGHT(Mold_Number,5) AS NoUrut
                                          FROM NPP_Detail order by Mold_Number desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)

            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                Dim NoUrut As String = "0"

                NoUrut = Val(NoUrut + 1) + Row
                GroupID = "G0000" & NoUrut
            Else
                Dim NoUrut As String = dtTable.Rows(0).Item("NoUrut")
                NoUrut = Val(NoUrut + 1) + Row
                If Len(NoUrut) = 1 Then
                    GroupID = "G0000" & NoUrut
                ElseIf Len(NoUrut) = 2 Then
                    GroupID = "G000" & NoUrut
                ElseIf Len(NoUrut) = 3 Then
                    GroupID = "G00" & NoUrut
                ElseIf Len(NoUrut) = 4 Then
                    GroupID = "G0" & NoUrut
                Else
                    GroupID = "G" & NoUrut
                End If
            End If
            Return GroupID
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function NPWOReportRev(No As String) As DataSet
        Dim query As String
        'Dim NP As String = "TSC/NPP/MKT/04/SIM-Y98/2020/001"
        query = "SELECT [No_NPWO]
                  ,[Rev]
                  ,[Information]
              FROM [NPWO_Rev_Information]
		           Where [No_Npwo] = '" & No & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport(query, "NpwoRev")
        Return ds

    End Function


    Public Sub GetNoUrut()
        Try

            Dim ls_SP As String = "SELECT top 1   NoUrut
                                          FROM Npwo_Detail order by NoUrut desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)



            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                NoUrut = 1
            Else
                NoUrut = Convert.ToInt32(dtTable.Rows.Item("NoUrut")) + 1
            End If



        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateApprove(ByVal _FsCode As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE Npwo_Head" & vbCrLf &
                                    "SET [Approve] = '" & H_Approve & "' WHERE [No_Npwo] = '" & _FsCode & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetMesin() As DataTable
        Try

            Dim query As String = "[CR_Get_Mesin]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function Cek_PartNo_Detail_Npwo(PartNo__ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[NPWO_Cek_PartNo]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(0).Value = PartNo__
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Cek_PartNo_Detail_NPP(PartNo__ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[NPP_Cek_PartNo]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(0).Value = PartNo__
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_Detail_Npwo(Npwo_ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Npwo_Get_Detail_Npwo]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Npwo", SqlDbType.VarChar)
            pParam(0).Value = Npwo_
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function



    Public Function Get_Detail1_Npwo(Npwo_ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Npwo_Get_Detail1_Npwo]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Npwo", SqlDbType.VarChar)
            pParam(0).Value = Npwo_
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Sub Insert(NPWO_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertRevisi(NPWO_)
                        Insert_NPWOHeader(H_No_Npwo,
                                            H_No_NPP,
                                            Date.Now,
                                            H_Model_Name,
                                            H_Model_Desc,
                                            H_Customer_Name,
                                            H_Order_Month,
                                            H_Order_Max_Month,
                                            H_T0,
                                            H_T1,
                                            H_T2,
                                            H_MP,
                                            H_Drawing,
                                            H_CAD_Data,
                                            H_Sample,
                                            H_Special_Technical_Requires,
                                            H_Category_Class,
                                            H_Factory_Tsc_TNG,
                                            H_Factory_Tsc_CKR,
                                            gh_Common.Username,
                                            Date.Now,
                                            H_Rev,
                                            H_Checked,
                                            H_A1,
                                            H_A2,
                                            H_A3,
                                            H_A4,
                                            gh_Common.Username,
                                            Date.Now)


                        Dim AutoIncrement As Integer
                        Dim Join1 As String = ""
                        Dim Join2 As String = ""

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)

                                AutoIncrement = .Insert_Npwo_Detail(NPWO_)

                            End With

                        Next

                        For j As Integer = 0 To Collection_Detail_1.Count - 1
                            With Collection_Detail_1(j)
                                .Insert_Npwo_Detail_1(NPWO_, AutoIncrement)

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
    Public Sub InsertRevisi(_Npwo As String)
        Dim result As Integer = 0
        Try
            Dim ls_SP As String = "INSERT INTO [NPWO_Rev_Information]
                                               ([No_Npwo]
                                               ,[Rev]
                                               ,[Information]
                                               ,[ReviceBy]
                                               ,[ReviceDate])
                                     VALUES 
                                            (" & QVal(_Npwo) & " 
                                            ," & QVal(H_Rev) & "
                                            ," & QVal(H_Rev_Info) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"


            MainModul.ExecQueryByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Insert_NPWOHeader(_H_No_Npwo As String,
                                        _H_No_NPP As String,
                                        _H_Issue_Date As Date,
                                        _H_Model_Name As String,
                                        _H_Model_Desc As String,
                                        _H_Customer_Name As String,
                                        _H_Order_Month As Integer,
                                        _H_Order_Max_Month As Integer,
                                        _H_T0 As Date,
                                        _H_T1 As Date,
                                        _H_T2 As Date,
                                        _H_MP As Date,
                                        _H_Drawing As Boolean,
                                        _H_CAD_Data As Boolean,
                                        _H_Sample As Boolean,
                                        _H_Special_Technical_Requires As Boolean,
                                        _H_Category_Class As String,
                                        _H_Factory_Tsc_TNG As Boolean,
                                        _H_Factory_Tsc_CKR As Boolean,
                                        _H_CreatedBy As String,
                                        _H_CreatedDate As Date,
                                        _H_Revisi As Integer,
                                        _H_Checked As String,
                                        _H_A1 As String,
                                        _H_A2 As String,
                                        _H_A3 As String,
                                        _H_A4 As String,
                                        _H_UpdateBy As String,
                                        _H_UpdateDate As Date)
        Dim result As Integer = 0


        Try

            'If _H_T0 = "" Then
            '    _H_T0 = DBNull.Value.ToString
            'End If

            'If _H_T1 = "" Then
            '    _H_T1 = DBNull.Value.ToString
            'End If

            'If _H_T2 = "" Then
            '    _H_T2 = DBNull.Value.ToString
            'End If


            Dim query As String = "[NPWO_Insert_Npwo_Head]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(28) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Issue_Date", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@Model_Name", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Model_Desc", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Customer_Name", SqlDbType.VarChar)
            pParam(5) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(6) = New SqlClient.SqlParameter("@Order_Max_Month", SqlDbType.Int)
            pParam(7) = New SqlClient.SqlParameter("@MP", SqlDbType.Date)
            pParam(8) = New SqlClient.SqlParameter("@Drawing", SqlDbType.Bit)
            pParam(9) = New SqlClient.SqlParameter("@CAD_Data", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Sample", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@Special_Technical_Require", SqlDbType.Bit)
            pParam(12) = New SqlClient.SqlParameter("@Category_Class", SqlDbType.VarChar)
            pParam(13) = New SqlClient.SqlParameter("@Factory_Tsc_TNG", SqlDbType.Bit)
            pParam(14) = New SqlClient.SqlParameter("@Factory_Tsc_CKR ", SqlDbType.Bit)
            pParam(15) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            pParam(16) = New SqlClient.SqlParameter("@CreatedDate ", SqlDbType.Date)
            pParam(17) = New SqlClient.SqlParameter("@Rev ", SqlDbType.Int)
            pParam(18) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(19) = New SqlClient.SqlParameter("@T0", SqlDbType.Date)
            pParam(20) = New SqlClient.SqlParameter("@T1", SqlDbType.Date)
            pParam(21) = New SqlClient.SqlParameter("@T2", SqlDbType.Date)
            pParam(22) = New SqlClient.SqlParameter("@Checked", SqlDbType.VarChar)
            pParam(23) = New SqlClient.SqlParameter("@A1", SqlDbType.VarChar)
            pParam(24) = New SqlClient.SqlParameter("@A2", SqlDbType.VarChar)
            pParam(25) = New SqlClient.SqlParameter("@A3", SqlDbType.VarChar)
            pParam(26) = New SqlClient.SqlParameter("@A4", SqlDbType.VarChar)
            pParam(27) = New SqlClient.SqlParameter("@UpdatedBy", SqlDbType.VarChar)
            pParam(28) = New SqlClient.SqlParameter("@UpdatedDate", SqlDbType.Date)



            pParam(0).Value = _H_No_Npwo
            pParam(1).Value = _H_Issue_Date
            pParam(2).Value = _H_Model_Name
            pParam(3).Value = _H_Model_Desc
            pParam(4).Value = _H_Customer_Name
            pParam(5).Value = _H_Order_Month
            pParam(6).Value = _H_Order_Max_Month
            pParam(7).Value = _H_MP
            pParam(8).Value = _H_Drawing
            pParam(9).Value = _H_CAD_Data
            pParam(10).Value = _H_Sample
            pParam(11).Value = _H_Special_Technical_Requires
            pParam(12).Value = _H_Category_Class
            pParam(13).Value = _H_Factory_Tsc_TNG
            pParam(14).Value = _H_Factory_Tsc_CKR
            pParam(15).Value = _H_CreatedBy
            pParam(16).Value = _H_CreatedDate
            pParam(17).Value = _H_Revisi
            pParam(18).Value = _H_No_NPP
            pParam(19).Value = _H_T0
            pParam(20).Value = _H_T1
            pParam(21).Value = _H_T2
            pParam(22).Value = _H_Checked
            pParam(23).Value = _H_A1
            pParam(24).Value = _H_A2
            pParam(25).Value = _H_A3
            pParam(26).Value = _H_A4
            pParam(27).Value = _H_UpdateBy
            pParam(28).Value = _H_UpdateDate


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub Update(NPWO_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)
                        DeleteDetail(NPWO_)
                        Update_NPWOHeader(H_No_Npwo,
                                          H_Order_Month,
                                            H_Order_Max_Month,
                                            H_T0,
                                            H_T1,
                                            H_T2,
                                            H_MP,
                                            H_Drawing,
                                            H_CAD_Data,
                                            H_Sample,
                                            H_Special_Technical_Requires,
                                            H_Category_Class,
                                            H_Factory_Tsc_TNG,
                                            H_Factory_Tsc_CKR,
                                            gh_Common.Username,
                                            Date.Now,
                                            H_Rev)


                        Dim AutoIncrement As Integer
                        Dim Join1 As String = ""
                        Dim Join2 As String = ""

                        'For i As Integer = 0 To Collection_Detail.Count - 1
                        '    With Collection_Detail(i)

                        '        Join1 = .Join
                        '        AutoIncrement = .Insert_Npwo_Detail(NPWO_)

                        '    End With

                        '    For j As Integer = 0 To Collection_Detail_1.Count - 1
                        '        With Collection_Detail_1(j)
                        '            Join2 = .Join

                        '            If Join1 = Join2 Then
                        '                .Insert_Npwo_Detail_1(NPWO_, AutoIncrement)
                        '            End If

                        '        End With
                        '    Next

                        'Next

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)

                                AutoIncrement = .Insert_Npwo_Detail(NPWO_)

                            End With

                        Next

                        For j As Integer = 0 To Collection_Detail_1.Count - 1
                            With Collection_Detail_1(j)
                                .Insert_Npwo_Detail_1(NPWO_, AutoIncrement)

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

    Public Sub UpdateaAndHistory(NPWO_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHistory(NPWO_)

                        InsertHistoryDetail(NPWO_)

                        Update_NPWOHeader(H_No_Npwo,
                                          H_Order_Month,
                                            H_Order_Max_Month,
                                            H_T0,
                                            H_T1,
                                            H_T2,
                                            H_MP,
                                            H_Drawing,
                                            H_CAD_Data,
                                            H_Sample,
                                            H_Special_Technical_Requires,
                                            H_Category_Class,
                                            H_Factory_Tsc_TNG,
                                            H_Factory_Tsc_CKR,
                                            gh_Common.Username,
                                            Date.Now,
                                            H_Rev)



                        DeleteDetail(NPWO_)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .Insert_Npwo_Detail(H_No_Npwo)
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

    Public Sub InsertHistory(NPWO_ As String)
        Try
            Dim query As String = "[NPWO_Insert_Npwo_Head_History]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(0).Value = _H_No_Npwo


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHistoryDetail(NPWO_ As String)
        Try
            Dim query As String = "[NPWO_Insert_Npwo_Detail_History]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(0).Value = _H_No_Npwo


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update_NPWOHeader(_H_No_Npwo As String,
                                 _H_Order_Month As Integer,
                                        _H_Order_Max_Month As Integer,
                                        _H_T0 As String,
                                        _H_T1 As String,
                                        _H_T2 As String,
                                        _H_MP As String,
                                        _H_Drawing As Boolean,
                                        _H_CAD_Data As Boolean,
                                        _H_Sample As Boolean,
                                        _H_Special_Technical_Requires As Boolean,
                                        _H_Category_Class As String,
                                        _H_Factory_Tsc_TNG As Boolean,
                                        _H_Factory_Tsc_CKR As Boolean,
                                        _H_UpdateBy As String,
                                        _H_UpdateDate As Date,
                                        _H_Rev As Integer)
        Dim result As Integer = 0


        Try


            Dim query As String = "[NPWO_Update_Npwo_Head]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(16) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(2) = New SqlClient.SqlParameter("@Order_Max_Month ", SqlDbType.Int)
            pParam(3) = New SqlClient.SqlParameter("@T0", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@T1", SqlDbType.VarChar)
            pParam(5) = New SqlClient.SqlParameter("@T2", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@MP", SqlDbType.VarChar)
            pParam(7) = New SqlClient.SqlParameter("@Drawing", SqlDbType.Bit)
            pParam(8) = New SqlClient.SqlParameter("@CAD_Data", SqlDbType.Bit)
            pParam(9) = New SqlClient.SqlParameter("@Sample", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Special_Technical_Require", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@Category_Class", SqlDbType.VarChar)
            pParam(12) = New SqlClient.SqlParameter("@Factory_Tsc_TNG", SqlDbType.Bit)
            pParam(13) = New SqlClient.SqlParameter("@Factory_Tsc_CKR", SqlDbType.Bit)
            pParam(14) = New SqlClient.SqlParameter("@UpdatedBy", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@UpdateDate", SqlDbType.Date)
            pParam(16) = New SqlClient.SqlParameter("@Revisi", SqlDbType.Int)


            pParam(0).Value = _H_No_Npwo
            pParam(1).Value = _H_Order_Month
            pParam(2).Value = _H_Order_Max_Month
            pParam(3).Value = _H_T0
            pParam(4).Value = _H_T1
            pParam(5).Value = _H_T2
            pParam(6).Value = _H_MP
            pParam(7).Value = _H_Drawing
            pParam(8).Value = _H_CAD_Data
            pParam(9).Value = _H_Sample
            pParam(10).Value = _H_Special_Technical_Requires
            pParam(11).Value = _H_Category_Class
            pParam(12).Value = _H_Factory_Tsc_TNG
            pParam(13).Value = _H_Factory_Tsc_CKR
            pParam(14).Value = _H_UpdateBy
            pParam(15).Value = _H_UpdateDate
            pParam(16).Value = _H_Rev


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub



    Public Function GetNppByID(ByVal ID As String) As DataTable
        Try
            Dim query As String = "[NPP_Get_NPP_ByID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NPP_No", SqlDbType.VarChar)

            pParam(0).Value = ID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "[NPWO_Get_NPWO_ByID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NpwoNo", SqlDbType.VarChar)

            pParam(0).Value = ID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    H_No_NPP = Trim(.Item("No_NPP") & "")
                    H_No_Npwo = Trim(.Item("No_Npwo") & "")
                    H_Issue_Date = Trim(.Item("Issue_Date") & "")
                    H_Model_Name = Trim(.Item("Model_Name") & "")
                    H_Model_Desc = Trim(.Item("Model_Desc") & "")
                    H_Customer_Name = Trim(.Item("Customer_Name") & "")
                    H_Order_Month = Trim(.Item("Order_Month") & "")
                    H_Order_Max_Month = Trim(.Item("Order_Max_Month") & "")
                    H_T0 = Trim(.Item("T0") & "")
                    H_T1 = Trim(.Item("T1") & "")
                    H_T2 = Trim(.Item("T2") & "")
                    H_MP = Trim(.Item("MP") & "")
                    H_Drawing = Trim(.Item("Drawing") & "")
                    H_CAD_Data = Trim(.Item("CAD_Data") & "")
                    H_Sample = Trim(.Item("Sample") & "")
                    H_Special_Technical_Requires = Trim(.Item("Special_Technical_Requires") & "")
                    H_Category_Class = Trim(.Item("Category_Class") & "")
                    H_Factory_Tsc_TNG = Trim(.Item("Factory_Tsc_TNG") & "")
                    H_Factory_Tsc_CKR = Trim(.Item("Factory_Tsc_CKR") & "")
                    H_Approve = Trim(.Item("Approve") & "")
                    H_Rev = Trim(.Item("Rev") & "")

                End With
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(_No_Npwo As String)
        Try

            Dim ls_NPWODetail As String = "Delete From Npwo_Detail where No_Npwo = '" & _No_Npwo & "'"
            MainModul.ExecQueryByCommand(ls_NPWODetail)

            Dim ls_NPWODetail1 As String = "Delete From NpwoDetail1 where No_Npwo = '" & _No_Npwo & "'"
            MainModul.ExecQueryByCommand(ls_NPWODetail1)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetNpwoNoAuto(Customer_ As String, Model_ As String)
        Try
            'Dim Dept_ As String = gh_Common.GroupID

            Dim Tahun As String = Format(Now, "yyyy")
            Dim Bulan As String = Format(Now, "MM")
            Dim Tanggal As String = Format(Now, "dd")

            Dim Head As String = "TSC/NPWO/MKT" & "/" & Bulan & "/" & Customer_ & "-" & Model_ & "/"


            Dim ls_SP As String = "SELECT No_Npwo
		                                        ,substring(right(No_Npwo,8), 1,4) AS Tahun 
		                                        ,RIGHT(No_Npwo,3) AS NoUrut
                                          FROM Npwo_Head order by RIGHT(No_Npwo,3) desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)



            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                H_No_Npwo = Head & Tahun & "/" & "001"
            Else

                Dim CekTahun As String = dtTable.Rows(0).Item("Tahun")
                Dim NoUrut As String = dtTable.Rows(0).Item("NoUrut")

                If Tahun <> CekTahun Then
                    H_No_Npwo = Head & Tahun & "/" & "001"
                Else
                    NoUrut = Val(NoUrut + 1)
                    If Len(NoUrut) = 1 Then
                        H_No_Npwo = Head & Tahun & "/" & "00" & NoUrut
                    ElseIf Len(NoUrut) = 2 Then
                        H_No_Npwo = Head & Tahun & "/" & "0" & NoUrut
                    Else
                        H_No_Npwo = Head & Tahun & "/" & "0" & NoUrut
                    End If

                End If

            End If



        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetNoNpp() As DataTable
        Try

            Dim ls_SP As String = "SELECT A.[No_NPP] as Value
                                        FROM [NPP_Head] A Left join [NPWO_HEAD] B 
                                        ON A.[No_NPP] = B.[No_NPP]
                                        where B.No_Npwo IS NULL and A.Approve ='True'
                                        order by RIGHT(A.No_NPP,3) asc"

            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetCustomer() As DataTable
        Try
            Dim query As String = "[NPWO_Get_Customer]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetCategory() As DataTable
        Try
            Dim query As String = "[NPWO_Get_Category]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


End Class

Public Class Col_Cls_Npwo_Detail_NPWO

    Public Property Join As String

    Public Property Assy As Boolean
    Public Property Cavity As String
    Public Property Chrome As Boolean
    Public Property Ultrasonic As Boolean
    Public Property Vibration As Boolean
    Public Property Cycle_Time As Integer
    Public Property StatusMold As String
    Public Property Injection As Boolean
    Public Property LOI_Number As String
    Public Property GroupID As String
    Public Property Machine As String
    Public Property Material_Resin As String
    Public Property No_Npwo As String
    Public Property Painting As Boolean
    Public Property Part_Name As String
    Public Property ID As String
    Public Property Part_No As String
    Public Property Qty_Mold As Integer
    Public Property Weight As Double
    Public Property Forecast As Integer
    Public Property OrderMonth As Integer
    Public Property Type As String

    Public Property Rev As Integer


    Public Function Insert_Npwo_Detail(_Npwo_No As String) As Integer

        Dim result As Integer = 0

        Try

            Dim query As String = "[NPWO_Insert_Npwo_Detail]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(21) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Part_No", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Part_Name", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Machine", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Cycle_Time", SqlDbType.Int)
            pParam(5) = New SqlClient.SqlParameter("@Cavity", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@Weight", SqlDbType.Float)
            pParam(7) = New SqlClient.SqlParameter("@Qty_Mold", SqlDbType.Int)
            pParam(8) = New SqlClient.SqlParameter("@Material_Resin", SqlDbType.VarChar)
            pParam(9) = New SqlClient.SqlParameter("@Injection", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Painting", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@Chrome", SqlDbType.Bit)
            pParam(12) = New SqlClient.SqlParameter("@Assy", SqlDbType.Bit)
            pParam(13) = New SqlClient.SqlParameter("@StatusMold", SqlDbType.VarChar)
            pParam(14) = New SqlClient.SqlParameter("@LOI_Number", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@Forecast", SqlDbType.Int)
            pParam(16) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(17) = New SqlClient.SqlParameter("@Rev", SqlDbType.Int)
            pParam(18) = New SqlClient.SqlParameter("@Ultrasonic", SqlDbType.Bit)
            pParam(19) = New SqlClient.SqlParameter("@vibration", SqlDbType.Bit)
            pParam(20) = New SqlClient.SqlParameter("@GroupID", SqlDbType.VarChar)
            pParam(21) = New SqlClient.SqlParameter("@Type", SqlDbType.VarChar)



            pParam(0).Value = _Npwo_No
            pParam(1).Value = Part_No
            pParam(2).Value = Part_Name
            pParam(3).Value = Machine
            pParam(4).Value = Cycle_Time
            pParam(5).Value = Cavity
            pParam(6).Value = Weight
            pParam(7).Value = Qty_Mold
            pParam(8).Value = Material_Resin
            pParam(9).Value = Injection
            pParam(10).Value = Painting
            pParam(11).Value = Chrome
            pParam(12).Value = Assy
            pParam(13).Value = StatusMold
            pParam(14).Value = LOI_Number
            pParam(15).Value = Forecast
            pParam(16).Value = OrderMonth
            pParam(17).Value = Rev
            pParam(18).Value = Ultrasonic
            pParam(19).Value = Vibration
            pParam(20).Value = GroupID
            pParam(21).Value = Type


            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
            result = dtTable.Rows(0).Item("identityvalue")
            Return result

        Catch ex As Exception
            Throw
        End Try

    End Function




End Class


Public Class Col_Cls_Npwo_Detail_1_NPWO

    Public Property Join As String


    Public Property NoUrut As Integer
    Public Property Assy As Boolean
    Public Property Cavity As String
    Public Property Chrome As Boolean
    Public Property Ultrasonic As Boolean
    Public Property Vibration As Boolean
    Public Property Cycle_Time As Integer
    Public Property StatusMold As String
    Public Property Injection As Boolean
    Public Property LOI_Number As String
    Public Property Machine As String
    Public Property Material_Resin As String
    Public Property No_Npwo As String
    Public Property Painting As Boolean
    Public Property Part_Name As String
    Public Property Part_No As String
    Public Property ID As String
    Public Property Qty_Mold As Integer
    Public Property Weight As Double
    Public Property Forecast As Integer
    Public Property OrderMonth As Integer
    Public Property GroupID As String
    Public Property Type As String
    Public Property Type1 As String


    Public Property Rev As Integer


    Public Sub Insert_Npwo_Detail_1(_Npwo_No As String, _NoUrut As Integer)


        Try

            Dim query As String = "[NPWO_Insert_Npwo_Detail_1]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(23) {}
            pParam(0) = New SqlClient.SqlParameter("@No_Npwo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Part_No", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Part_Name", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Machine", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Cycle_Time", SqlDbType.Int)
            pParam(5) = New SqlClient.SqlParameter("@Cavity", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@Weight", SqlDbType.Float)
            pParam(7) = New SqlClient.SqlParameter("@Qty_Mold", SqlDbType.Int)
            pParam(8) = New SqlClient.SqlParameter("@Material_Resin", SqlDbType.VarChar)
            pParam(9) = New SqlClient.SqlParameter("@Injection", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Painting", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@Chrome", SqlDbType.Bit)
            pParam(12) = New SqlClient.SqlParameter("@Assy", SqlDbType.Bit)
            pParam(13) = New SqlClient.SqlParameter("@StatusMold", SqlDbType.VarChar)
            pParam(14) = New SqlClient.SqlParameter("@LOI_Number", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@Forecast", SqlDbType.Int)
            pParam(16) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(17) = New SqlClient.SqlParameter("@Rev", SqlDbType.Int)
            pParam(18) = New SqlClient.SqlParameter("@NoUrut", SqlDbType.Int)
            pParam(19) = New SqlClient.SqlParameter("@Ultrasonic", SqlDbType.Bit)
            pParam(20) = New SqlClient.SqlParameter("@Vibration", SqlDbType.Bit)
            pParam(21) = New SqlClient.SqlParameter("@GroupID", SqlDbType.VarChar)
            pParam(22) = New SqlClient.SqlParameter("@Type", SqlDbType.VarChar)
            pParam(23) = New SqlClient.SqlParameter("@Type1", SqlDbType.VarChar)

            pParam(0).Value = _Npwo_No
            pParam(1).Value = Part_No
            pParam(2).Value = Part_Name
            pParam(3).Value = Machine
            pParam(4).Value = Cycle_Time
            pParam(5).Value = Cavity
            pParam(6).Value = Weight
            pParam(7).Value = Qty_Mold
            pParam(8).Value = Material_Resin
            pParam(9).Value = Injection
            pParam(10).Value = Painting
            pParam(11).Value = Chrome
            pParam(12).Value = Assy
            pParam(13).Value = StatusMold
            pParam(14).Value = LOI_Number
            pParam(15).Value = Forecast
            pParam(16).Value = OrderMonth
            pParam(17).Value = Rev
            pParam(18).Value = _NoUrut
            pParam(19).Value = Ultrasonic
            pParam(20).Value = Vibration
            pParam(21).Value = GroupID
            pParam(22).Value = Type
            pParam(23).Value = Type1


            MainModul.ExecQueryByCommand_SP(query, pParam)

        Catch ex As Exception
            Throw
        End Try

    End Sub




End Class
