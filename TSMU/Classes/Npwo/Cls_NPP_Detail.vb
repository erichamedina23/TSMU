Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Cls_NPP_Detail

    Public Property H_No_NPP As String
    Public Property H_Issue_Date As DateTime
    Public Property H_Model_Name As String
    Public Property H_Model_Description As String

    Public Property H_Customer_Name As String
    Public Property H_Order_Month As Integer
    Public Property H_Order_Max_Month As Integer
    Public Property H_T0 As String
    Public Property H_T1 As String
    Public Property H_T2 As String
    Public Property H_MP As String
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
    Public Property H_RevInformasi As String

    Public Property H_TargetDRR As Date
    Public Property H_TargetQuot As Date

    Public Property H_Checked As String
    Public Property H_A1 As String
    Public Property H_A2 As String
    Public Property H_A3 As String
    Public Property H_A4 As String



    Public Property Collection_Detail() As New Collection(Of Col_Cls_NPP_Detail_NPP)


    Public Function NPPReport(No As String, Rev As String) As DataSet
        Dim query As String
        'Dim NP As String = "TSC/NPP/MKT/04/SIM-Y98/2020/001"
        query = "SELECT [NPP_Head].[No_NPP]
                  ,[NPP_Head].[Issue_Date]
                  ,[NPP_Head].[Model_Name]
                  ,[NPP_HEAD].[Model_Desc]
                  ,[NPP_Head].[Customer_Name] as [Customer_Name1]
                  ,[Customer].[BillName] as [Customer_Name]
                  ,[NPP_Head].[Order_Month]
                  ,[NPP_Head].[Order_Max_Month]
                  ,[NPP_Head].[T0]
                  ,[NPP_Head].[T1]
                  ,[NPP_Head].[T2]
                  ,[NPP_Head].[MP]
                  ,[NPP_Head].[Drawing]
                  ,[NPP_Head].[CAD_Data]
                  ,[NPP_Head].[Sample]
                  ,[NPP_Head].[Special_Technical_Requires]
                  ,[NPP_Head].[Category_Class]
                  ,[NPP_Head].[Factory_Tsc_TNG]
                  ,[NPP_Head].[Factory_Tsc_CKR]
                  ,[NPP_Head].[Factory_Tsc_0]
                  ,[NPP_Head].[Factory_Tsc_1]
                  ,[NPP_Head].[CreatedBy]
                  ,[NPP_Head].[CreatedDate]
                  ,[NPP_Head].[UpdatedBy]
                  ,[NPP_Head].[UpdatedDate]  as [Rev_Date]
                  ,[NPP_Head].[Approve]
                  ,[NPP_Head].[Checked]
                  ,[NPP_Head].[A1]
                  ,[NPP_Head].[A2]
                  ,[NPP_Head].[A3]
                  ,[NPP_Head].[A4]
                  ,[NPP_Head].[A4]
                  ,[NPP_Head].[Prepare]
                  ,[NPP_Head].[TargetDRR]
                  ,[NPP_Head].[TargetQuot]
                  ,[NPP_Head].[UpdatedBy] as [UpdateBy]
                  ,[NPP_Detail].[Part_No]
                  ,[NPP_Detail].[Part_Name]
                  ,[NPP_Detail].[Machine]
                  ,[NPP_Detail].[Cycle_Time]
                  ,[NPP_Detail].[Cavity]
                  ,[NPP_Detail].[Weight]
                  ,[NPP_Detail].[Qty_Mold] 
                  ,[NPP_Detail].[Material_Resin]
                  ,[NPP_Detail].[Injection]
                  ,[NPP_Detail].[Painting]
                  ,[NPP_Detail].[Chrome]
                  ,[NPP_Detail].[Assy]
                  ,[NPP_Detail].[Vibration]
                  ,[NPP_Detail].[Ultrasonic]
                  ,[NPP_Detail].[StatusMold]
                  ,[NPP_Detail].[Order_Month] as [D_Order_Month]
                  ,[NPP_Detail].[LOI_Number]
                  ,[NPP_Detail].[Forecast]
                  ,[NPP_Detail].[Factory]
                  ,[NPP_Detail].[Rev]
                  ,[NPP_Detail].[Mold_Number]
                  ,[NPP_Rev_Information].[Rev] as RevI
                  ,[NPP_Rev_Information].[Information] 
        From [NPP_Head] inner Join [NPP_Detail] On
                    [NPP_Head].[No_NPP] = [NPP_Detail].No_NPP
                    inner join [NPP_Rev_Information] on
                    [NPP_Head].[No_NPP] = [NPP_Rev_Information].No_NPP
                    inner join Customer on Customer.CustId =  [NPP_Head].[Customer_Name]
		            Where [NPP_Head].[No_NPP] = '" & No & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport(query, "NPP")
        Return ds

        'Mold_Number

    End Function

    Public Function NPPReportRev(No As String) As DataSet
        Dim query As String
        'Dim NP As String = "TSC/NPP/MKT/04/SIM-Y98/2020/001"
        query = "SELECT [No_NPP]
                  ,[Rev]
                  ,[Information]
              FROM [NPP_Rev_Information]
		           Where [No_NPP] = '" & No & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport(query, "NPPRevInfo")
        Return ds

    End Function



    Public Sub UpdateApprove(ByVal _FsCode As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE NPP_Head" & vbCrLf &
                                    "SET [Approve] = '" & H_Approve & "' WHERE [No_NPP] = '" & _FsCode & "'"
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
            Dim query As String = "[Cek_PartNo_NpwoDetail]"
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
    Public Function Get_Detail_NPP(NPP_ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[NPP_Get_Detail_NPP]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NPP", SqlDbType.VarChar)
            pParam(0).Value = NPP_
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Sub Insert(NPP_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertRevisi()
                        Insert_NPPHeader(H_No_NPP,
                                            Date.Now,
                                            H_Model_Name,
                                            H_Model_Description,
                                            H_Customer_Name,
                                            H_Order_Month,
                                            H_Order_Max_Month,
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
                                            H_TargetDRR,
                                            H_TargetQuot,
                                            H_Rev,
                                            H_Checked,
                                            H_A1,
                                            H_A2,
                                            H_A3,
                                            H_A4,
                                            gh_Common.Username,
                                            Date.Now)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .Insert_NPP_Detail(H_No_NPP)
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
    Public Sub InsertRevisi()
        Dim result As Integer = 0
        Try


            'Dim ls_SP As String = "INSERT INTO [NPP_Rev_Information]
            '                                   ([No_NPP]
            '                                   ,[Rev]
            '                                   ,[Information]
            '                                   ,[ReviceDate]
            '                                   ,[ReviceBy])
            '                         VALUES 
            '                                (" & QVal(H_No_NPP) & " 
            '                                ," & QVal(H_Rev) & "
            '                                ," & QVal(H_RevInformasi) & "
            '                                , GETDATE())
            '                                ," & QVal(gh_Common.Username) & ")"

            Dim ls_SP As String = "INSERT INTO [NPP_Rev_Information]
                                               ([No_NPP]
                                               ,[Rev]
                                               ,[Information]
                                               ,[ReviceBy]
                                               ,[ReviceDate])
                                     VALUES 
                                            (" & QVal(H_No_NPP) & " 
                                            ," & QVal(H_Rev) & "
                                            ," & QVal(H_RevInformasi) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"


            MainModul.ExecQueryByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Insert_NPPHeader(_H_No_Npwo As String,
                                        _H_Issue_Date As Date,
                                        _H_Model_Name As String,
                                        _H_Model_Desc As String,
                                        _H_Customer_Name As String,
                                        _H_Order_Month As Integer,
                                        _H_Order_Max_Month As Integer,
                                        _H_MP As String,
                                        _H_Drawing As Boolean,
                                        _H_CAD_Data As Boolean,
                                        _H_Sample As Boolean,
                                        _H_Special_Technical_Requires As Boolean,
                                        _H_Category_Class As String,
                                        _H_Factory_Tsc_TNG As Boolean,
                                        _H_Factory_Tsc_CKR As Boolean,
                                        _H_CreatedBy As String,
                                        _H_CreatedDate As Date,
                                        _H_TargetDR As Date,
                                        _H_TargetQuot As Date,
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

            If _H_T0 = "" Then
                _H_T0 = DBNull.Value.ToString
            End If

            If _H_T1 = "" Then
                _H_T1 = DBNull.Value.ToString
            End If

            If _H_T2 = "" Then
                _H_T2 = DBNull.Value.ToString
            End If
            If _H_Model_Desc = "" Then
                _H_Model_Desc = DBNull.Value.ToString
            End If


            Dim query As String = "[NPP_Insert_NPP_Head]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(26) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Issue_Date", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@Model_Name", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Customer_Name", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(5) = New SqlClient.SqlParameter("@Order_Max_Month", SqlDbType.Int)
            pParam(6) = New SqlClient.SqlParameter("@MP", SqlDbType.VarChar)
            pParam(7) = New SqlClient.SqlParameter("@Drawing", SqlDbType.Bit)
            pParam(8) = New SqlClient.SqlParameter("@CAD_Data", SqlDbType.Bit)
            pParam(9) = New SqlClient.SqlParameter("@Sample", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Special_Technical_Require", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@Category_Class", SqlDbType.VarChar)
            pParam(12) = New SqlClient.SqlParameter("@Factory_Tsc_TNG", SqlDbType.Bit)
            pParam(13) = New SqlClient.SqlParameter("@Factory_Tsc_CKR ", SqlDbType.Bit)
            pParam(14) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@CreatedDate ", SqlDbType.Date)
            pParam(16) = New SqlClient.SqlParameter("@Rev ", SqlDbType.Int)
            pParam(17) = New SqlClient.SqlParameter("@TargetDRR", SqlDbType.Date)
            pParam(18) = New SqlClient.SqlParameter("@TargetQuot", SqlDbType.Date)
            pParam(19) = New SqlClient.SqlParameter("@ModelDesc", SqlDbType.VarChar)
            pParam(20) = New SqlClient.SqlParameter("@Checked", SqlDbType.VarChar)
            pParam(21) = New SqlClient.SqlParameter("@A1", SqlDbType.VarChar)
            pParam(22) = New SqlClient.SqlParameter("@A2", SqlDbType.VarChar)
            pParam(23) = New SqlClient.SqlParameter("@A3", SqlDbType.VarChar)
            pParam(24) = New SqlClient.SqlParameter("@A4", SqlDbType.VarChar)
            pParam(25) = New SqlClient.SqlParameter("@UpdateBy", SqlDbType.VarChar)
            pParam(26) = New SqlClient.SqlParameter("@UpdateDate", SqlDbType.Date)


            pParam(0).Value = _H_No_Npwo
            pParam(1).Value = _H_Issue_Date
            pParam(2).Value = _H_Model_Name
            pParam(3).Value = _H_Customer_Name
            pParam(4).Value = _H_Order_Month
            pParam(5).Value = _H_Order_Max_Month
            pParam(6).Value = _H_MP
            pParam(7).Value = _H_Drawing
            pParam(8).Value = _H_CAD_Data
            pParam(9).Value = _H_Sample
            pParam(10).Value = _H_Special_Technical_Requires
            pParam(11).Value = _H_Category_Class
            pParam(12).Value = _H_Factory_Tsc_TNG
            pParam(13).Value = _H_Factory_Tsc_CKR
            pParam(14).Value = _H_CreatedBy
            pParam(15).Value = _H_CreatedDate
            pParam(16).Value = _H_Revisi
            pParam(17).Value = _H_TargetDR
            pParam(18).Value = _H_TargetQuot
            pParam(19).Value = _H_Model_Desc
            pParam(20).Value = _H_Checked
            pParam(21).Value = _H_A1
            pParam(22).Value = _H_A2
            pParam(23).Value = _H_A3
            pParam(24).Value = _H_A4
            pParam(25).Value = _H_UpdateBy
            pParam(26).Value = _H_UpdateDate


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub Update(NPP_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)
                        DeleteDetail(NPP_)
                        Update_NPP(H_No_NPP,
                                          H_Model_Description,
                                          H_Order_Month,
                                            H_Order_Max_Month,
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
                                            H_TargetDRR,
                                            H_TargetQuot,
                                            H_Rev)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .Insert_NPP_Detail(H_No_NPP)
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

    Public Sub UpdateaAndHistory(NPP_ As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertRevisi()
                        InsertHistory(NPP_)
                        InsertHistoryDetail(NPP_)

                        Update_NPP(H_No_NPP,
                                          H_Model_Description,
                                          H_Order_Month,
                                            H_Order_Max_Month,
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
                                            H_TargetDRR,
                                            H_TargetQuot,
                                            H_Rev)



                        DeleteDetail(NPP_)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .Insert_NPP_Detail(H_No_NPP)
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

    Public Sub InsertHistory(NPP_ As String)
        Try
            Dim query As String = "[NPP_Insert_NPP_Head_History]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(0).Value = NPP_


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHistoryDetail(NPP_ As String)
        Try
            Dim query As String = "[NPP_Insert_Npp_Detail_History]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(0).Value = NPP_


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update_NPP(_H_No_NPP As String,
                                        _H_Model_Description As String,
                                        _H_Order_Month As Integer,
                                        _H_Order_Max_Month As Integer,
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
                                        _H_TargetDRR As Date,
                                        _H_TargetQuot As Date,
                                        _H_Revisi As Int32)
        Dim result As Integer = 0


        Try


            Dim query As String = "[NPP_Update_NPP_Head]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(16) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(2) = New SqlClient.SqlParameter("@Order_Max_Month ", SqlDbType.Int)
            pParam(3) = New SqlClient.SqlParameter("@MP", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Drawing", SqlDbType.Bit)
            pParam(5) = New SqlClient.SqlParameter("@CAD_Data", SqlDbType.Bit)
            pParam(6) = New SqlClient.SqlParameter("@Sample", SqlDbType.Bit)
            pParam(7) = New SqlClient.SqlParameter("@Special_Technical_Require", SqlDbType.Bit)
            pParam(8) = New SqlClient.SqlParameter("@Category_Class", SqlDbType.VarChar)
            pParam(9) = New SqlClient.SqlParameter("@Factory_Tsc_TNG", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@Factory_Tsc_CKR", SqlDbType.Bit)
            pParam(11) = New SqlClient.SqlParameter("@UpdatedBy", SqlDbType.VarChar)
            pParam(12) = New SqlClient.SqlParameter("@UpdateDate", SqlDbType.Date)
            pParam(13) = New SqlClient.SqlParameter("@TargetDRR", SqlDbType.Date)
            pParam(14) = New SqlClient.SqlParameter("@TargetQuot", SqlDbType.Date)
            pParam(15) = New SqlClient.SqlParameter("@Revisi", SqlDbType.Int)
            pParam(16) = New SqlClient.SqlParameter("@ModelDesc", SqlDbType.VarChar)


            pParam(0).Value = _H_No_NPP
            pParam(1).Value = _H_Order_Month
            pParam(2).Value = _H_Order_Max_Month
            pParam(3).Value = _H_MP
            pParam(4).Value = _H_Drawing
            pParam(5).Value = _H_CAD_Data
            pParam(6).Value = _H_Sample
            pParam(7).Value = _H_Special_Technical_Requires
            pParam(8).Value = _H_Category_Class
            pParam(9).Value = _H_Factory_Tsc_TNG
            pParam(10).Value = _H_Factory_Tsc_CKR
            pParam(11).Value = _H_UpdateBy
            pParam(12).Value = _H_UpdateDate
            pParam(13).Value = _H_TargetDRR
            pParam(14).Value = _H_TargetQuot
            pParam(15).Value = _H_Revisi
            pParam(16).Value = _H_Model_Description


            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub UpdatePrepare(id_ As String, Prepare_ As String)
        Dim Query As String = "UPDATE [NPP_Head]
                               SET [Prepare] = '" & Prepare_ & "'
                                WHERE [No_NPP]   = '" & id_ & "'"

        MainModul.ExecQueryByCommand(Query)

    End Sub
    Public Sub UpdatePrepareNPWO(id_ As String, Prepare_ As String)
        Dim Query As String = "UPDATE [Npwo_Head]
                               SET [Prepare] = '" & Prepare_ & "'
                                WHERE [No_Npwo]   = '" & id_ & "'"

        MainModul.ExecQueryByCommand(Query)

    End Sub

    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "[NPP_Get_NPP_ByID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NPP_No", SqlDbType.VarChar)

            pParam(0).Value = ID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    H_No_NPP = Trim(.Item("No_NPP") & "")
                    H_Issue_Date = Trim(.Item("Issue_Date") & "")
                    H_Model_Name = Trim(.Item("Model_Name") & "")
                    H_Model_Description = Trim(.Item("Model_Desc") & "")
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
                    H_TargetDRR = Trim(.Item("TargetDRR") & "")
                    H_TargetQuot = Trim(.Item("TargetQuot") & "")

                End With
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(_No_NPP As String)
        Try

            Dim ls_SP As String = "Delete From NPP_Detail where No_NPP = '" & _No_NPP & "'"
            MainModul.ExecQueryByCommand(ls_SP)

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

            Dim Head As String = "TSC/NPP/MKT" & "/" & Bulan & "/" & Customer_ & "-" & Model_ & "/"


            Dim ls_SP As String = "SELECT top 1 No_NPP
		                                        ,substring(right(No_NPP,8), 1,4) AS Tahun 
		                                        ,RIGHT(No_NPP,3) AS NoUrut
                                          FROM NPP_Head order by RIGHT(No_NPP,3) desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)



            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                H_No_NPP = Head & Tahun & "/" & "001"
            Else

                Dim CekTahun As String = dtTable.Rows(0).Item("Tahun")
                Dim NoUrut As String = dtTable.Rows(0).Item("NoUrut")

                If Tahun <> CekTahun Then
                    H_No_NPP = Head & Tahun & "/" & "001"
                Else
                    NoUrut = Val(NoUrut + 1)
                    If Len(NoUrut) = 1 Then
                        H_No_NPP = Head & Tahun & "/" & "00" & NoUrut
                    ElseIf Len(NoUrut) = 2 Then
                        H_No_NPP = Head & Tahun & "/" & "0" & NoUrut
                    Else
                        H_No_NPP = Head & Tahun & "/" & "0" & NoUrut
                    End If

                End If

            End If



        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetGroupIDAuto(Row As Integer, RowsAwal As Integer) As String
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
                NoUrut = Val(NoUrut + 1) + Row - RowsAwal
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

    Public Function GetPrepare() As DataTable
        Try
            Dim query As String = "Select Prepare as Value From NPP_Prepare order by Prepare"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

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

Public Class Col_Cls_NPP_Detail_NPP


    Public Property Ultrasonic As Boolean
    Public Property Assy As Boolean
    Public Property Cavity As String
    Public Property Vibration As Boolean
    Public Property Chrome As Boolean
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
    Public Property Qty_Mold As Integer
    Public Property Weight As Double
    Public Property Forecast As Integer
    Public Property OrderMonth As Integer
    Public Property MoldNumber As String

    Public Property Rev As Integer
    Public Property Factory As String


    Public Sub Insert_NPP_Detail(NPP_No As String)

        Try

            Dim query As String = "[NPP_Insert_NPP_Detail]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(17) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Part_No", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Part_Name", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Weight", SqlDbType.Float)
            pParam(4) = New SqlClient.SqlParameter("@Material_Resin", SqlDbType.VarChar)
            pParam(5) = New SqlClient.SqlParameter("@Injection", SqlDbType.Bit)
            pParam(6) = New SqlClient.SqlParameter("@Painting", SqlDbType.Bit)
            pParam(7) = New SqlClient.SqlParameter("@Chrome", SqlDbType.Bit)
            pParam(8) = New SqlClient.SqlParameter("@Assy", SqlDbType.Bit)
            pParam(9) = New SqlClient.SqlParameter("@Ultrasonic", SqlDbType.Bit)
            pParam(10) = New SqlClient.SqlParameter("@StatusMold", SqlDbType.VarChar)
            pParam(11) = New SqlClient.SqlParameter("@Order_Month", SqlDbType.Int)
            pParam(12) = New SqlClient.SqlParameter("@Rev", SqlDbType.Int)
            pParam(13) = New SqlClient.SqlParameter("@Vibration", SqlDbType.Bit)
            pParam(14) = New SqlClient.SqlParameter("@Machine", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@Cav", SqlDbType.VarChar)
            pParam(16) = New SqlClient.SqlParameter("@CT", SqlDbType.Float)
            pParam(17) = New SqlClient.SqlParameter("@MoldNumber", SqlDbType.VarChar)


            pParam(0).Value = NPP_No
            pParam(1).Value = Part_No
            pParam(2).Value = Part_Name
            pParam(3).Value = Weight
            pParam(4).Value = Material_Resin
            pParam(5).Value = Injection
            pParam(6).Value = Painting
            pParam(7).Value = Chrome
            pParam(8).Value = Assy
            pParam(9).Value = Ultrasonic
            pParam(10).Value = StatusMold
            pParam(11).Value = OrderMonth
            pParam(12).Value = Rev
            pParam(13).Value = Vibration
            pParam(14).Value = Machine
            pParam(15).Value = Cavity
            pParam(16).Value = Cycle_Time
            pParam(17).Value = MoldNumber




            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub



End Class
