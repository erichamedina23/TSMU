Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Public Class ClsCR_CreateUser

    Dim _Query As String

    Public Property H_CirculationNo As String
    Public Property H_RequirementDate As DateTime
    Public Property H_DeptID As String
    Public Property H_SiteID As String
    Public Property H_PR As String
    Public Property H_Budget As Integer
    Public Property H_Account As String
    Public Property H_CR_Type As String
    Public Property H_Currency As String
    Public Property H_Rate As Double
    Public Property H_Reason As String
    Public Property H_RemainingBudget As Double
    Public Property H_CurrentCR As Double
    Public Property H_Balance As Double
    Public Property H_InvoiceNo As String
    Public Property H_UserSubmition As String
    Public Property H_DeptHead_ID As String
    Public Property H_DeptHead_Name As String
    Public Property H_DeptHead_Opinion As String
    Public Property H_DeptHead_Approve As String
    Public Property H_DeptHead_Approve_Date As Date
    Public Property H_DivHead_ID As String
    Public Property H_DivHead_Name As String
    Public Property H_DivHead_Opinion As String
    Public Property H_DivHead_Approve As String
    Public Property H_DivHead_Approve_Date As Date
    Public Property H_Status As String
    Public Property H_Parent_Circulation As String
    Public Property H_Parent_Circulation_Amount As Double

    Public Property H_Dies_Sales_Type As String
    Public Property H_Dies_Customer_Name As String
    Public Property H_Dies_Remark As String
    Public Property H_Dies_Model As String
    Public Property H_Dies As Int32
    Public Property H_ChargedOf As Int32
    Public Property H_InvoiceNumber As String
    Public Property H_InvoiceStatus As Int32






    Public Property Collection_Description_Of_Cost() As New Collection(Of ClsCR_Description_of_Cost)
    Public Property Collection_Other_Dept() As New Collection(Of ClsCR_Other_Dept)
    Public Property Collection_Installment() As New Collection(Of ClsCR_Installment)
    Public Property Collection_BomT1() As New Collection(Of ClsCR_BomT1)


    Public Function Get_Mold(NPP_ As String) As DataTable
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

    Public Function Get_Detail_DescriptionOfCost(CirculationNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Detail_DescriptionOfCost]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(0).Value = CirculationNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Detail_Installment(CirculationNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Detail_Installment]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(0).Value = CirculationNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_CRRequest(Dept As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Request]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)
            pParam(0).Value = Dept
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetMold() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "Select 
                                    Part_No as [Name Of Goods]
                                    ,Part_Name as [Spesification]
                                    ,[Check]  
                                  from Npwo_Detail"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetPR(Dept_Sub As String, Tahun As String, Bulan As Double) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query1 As String = "[CR_Get_PRNo]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@Sub", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Bulan", SqlDbType.Float)
            pParam(0).Value = Dept_Sub
            pParam(1).Value = Tahun
            pParam(2).Value = Bulan
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query1, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetBudget(Dept_Sub As String, Tahun As String, Bulan As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_AccountBudget]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@Sub", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Bulan", SqlDbType.VarChar)
            pParam(0).Value = Dept_Sub
            pParam(1).Value = Tahun
            pParam(2).Value = Bulan
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetParent_Circulation(Dept As String, Tahun As String, Bulan As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_ParentCirculation]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)
            'pParam(1) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            'pParam(2) = New SqlClient.SqlParameter("@Bulan", SqlDbType.VarChar)
            pParam(0).Value = Dept
            'pParam(1).Value = Tahun
            'pParam(2).Value = Bulan
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function getWC() As DataTable
        Try
            Dim query As String = "[CR_Get_Currency]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function Get_Other_DeptID() As DataTable
        Try
            Dim query As String = "[CR_Get_Other_DeptID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_Other_DeptID_Filter(Circulation_ As String) As DataTable
        Try
            Dim query As String = "SELECT [CirculationNo]
                                  ,[DeptID]
                                  ,[DeptHead_ID]
                                  ,[DeptHead_Name]
                                  ,[DeptHead_Email]
                                  ,[Date]
                                  ,[Opinion]
                                  ,[Approve]
                              FROM [CR_Other_Dept] where [CirculationNo] = '" & Circulation_ & "'"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function Rate(Tahun As String, Bulan As String, Curr As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Rate]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Bulan", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Cur", SqlDbType.VarChar)

            pParam(0).Value = Tahun
            pParam(1).Value = Bulan
            pParam(2).Value = Curr

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_Dept_Sub(Departemen_Sub As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Sub]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)

            pParam(0).Value = Departemen_Sub

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_Data_CR_Delete(Circulation As String, Dept As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Get_Data_CR_Delete]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Circulation", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)

            pParam(0).Value = Circulation
            pParam(1).Value = Dept

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function Get_Total_Sisa_Budget_Dept(Dept_Sub As String, Account As String, Tahun As String, Bulan As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Total_Sisa_Budget_Dept]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@Sub", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Account", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Bulan", SqlDbType.VarChar)

            pParam(0).Value = Dept_Sub
            pParam(1).Value = Account
            pParam(2).Value = Tahun
            pParam(3).Value = Bulan

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_Total_CR_Dept(Dept As String, site As String, Account As String, Tahun As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Total_CR_Dept]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Site", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Account", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)

            pParam(0).Value = Dept
            pParam(1).Value = site
            pParam(2).Value = Account
            pParam(3).Value = Tahun

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub GetCirculationNoAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")
            Dim Dept As String = gh_Common.GroupID

            Dim ls_SP As String = "SELECT [CirculationNo] FROM [CR_Request] order by CirculationNo desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                H_CirculationNo = "QP" & Tahun & "0001"
            Else
                H_CirculationNo = dtTable.Rows(0).Item("CirculationNo")
                H_CirculationNo = Microsoft.VisualBasic.Mid(H_CirculationNo, 3, 2)
                If H_CirculationNo <> Ulang Then
                    H_CirculationNo = "QP" & Tahun & "0001"
                Else
                    H_CirculationNo = dtTable.Rows(0).Item("CirculationNo")
                    H_CirculationNo = Val(Microsoft.VisualBasic.Mid(H_CirculationNo, 5, 4)) + 1
                    If Len(H_CirculationNo) = 1 Then
                        H_CirculationNo = "QP" & Tahun & "000" & H_CirculationNo & ""
                    ElseIf Len(H_CirculationNo) = 2 Then
                        H_CirculationNo = "QP" & Tahun & "00" & H_CirculationNo & ""
                    ElseIf Len(H_CirculationNo) = 3 Then
                        H_CirculationNo = "QP" & Tahun & "0" & H_CirculationNo & ""
                    Else
                        H_CirculationNo = "QP" & Tahun & H_CirculationNo & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub GetDataByID(ByVal ID As String)
        Try
            Dim query As String = "[CR_Get_Request_ByID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Circulation", SqlDbType.VarChar)

            pParam(0).Value = ID


            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    H_CirculationNo = Trim(.Item("CirculationNo") & "")
                    H_RequirementDate = Trim(.Item("RequirementDate") & "")
                    H_DeptID = Trim(.Item("DeptID") & "")
                    H_SiteID = Trim(.Item("SiteID") & "")
                    H_PR = Trim(.Item("PR_No") & "")
                    If .Item("Budget") = "True" Then
                        H_Budget = 1
                    Else
                        H_Budget = 0
                    End If

                    H_Account = Trim(.Item("Account") & "")
                    H_CR_Type = Trim(.Item("CR_Type") & "")
                    H_Currency = Trim(.Item("Currency") & "")
                    H_Rate = Trim(.Item("Rate") & "")
                    H_Reason = Trim(.Item("Reason") & "")
                    H_RemainingBudget = Trim(.Item("RemainingBudget") & "")
                    H_CurrentCR = Trim(.Item("CurrentCR") & "")
                    H_Balance = Trim(.Item("Balance") & "")
                    H_InvoiceNo = Trim(.Item("InvoiceNo") & "")
                    H_Status = Trim(.Item("Status") & "")
                    'H_UserSubmition = Trim(.Item("") & "")
                    'H_DeptHead_ID = Trim(.Item("") & "")
                    'H_DeptHead_Name = Trim(.Item("") & "")
                    'H_DeptHead_Opinion = Trim(.Item("") & "")
                    'H_DeptHead_Approve = Trim(.Item("") & "")
                    'H_DeptHead_Approve_Date = Trim(.Item("") & "")
                    'H_DivHead_ID = Trim(.Item("") & "")
                    'H_DivHead_Name = Trim(.Item("") & "")
                    'H_DivHead_Opinion = Trim(.Item("") & "")
                    'H_DivHead_Approve = Trim(.Item("") & "")
                    'H_DivHead_Approve_Date = Trim(.Item("") & "")
                    'H_Status = Trim(.Item("") & "")
                    H_Parent_Circulation = Trim(.Item("Parent_Circuation") & "")
                    H_Parent_Circulation_Amount = Trim(.Item("Parent_Circuation_Amount") & "")
                    H_Dies_Sales_Type = Trim(.Item("Dies_Sales_Type") & "")
                    H_Dies_Customer_Name = Trim(.Item("Dies_Customer_Name") & "")
                    H_Dies_Model = Trim(.Item("Dies_Model_Name") & "")
                    H_Dies_Remark = Trim(.Item("Dies_Remark") & "")

                    If .Item("ChargedOfCustomer") = "True" Then
                        H_ChargedOf = 1
                    Else
                        H_ChargedOf = 0
                    End If

                End With
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub Delete(CirculationNo As String, Dept_ As String)
        Try
            Try


                Dim query As String = "[CR_Delete_CR_Request]"
                Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
                pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
                pParam(1) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)


                pParam(0).Value = CirculationNo
                pParam(1).Value = Dept_



                'Dim dtTable As New DataTable
                'dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
                MainModul.ExecQueryByCommand_SP(query, pParam)
            Catch ex As Exception
                Throw
            End Try

        Catch ex As Exception
            Throw
        End Try
    End Sub



#Region "CRUD"

    Public Sub InsertTemp()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        For i As Integer = 0 To Collection_BomT1.Count - 1
                            With Collection_BomT1(i)
                                .InsertCR_BomTemp()
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


    Public Sub Insert(NoSirkualasi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Insert_CrRequest(H_CirculationNo,
                                         H_RequirementDate,
                                         gh_Common.GroupID,
                                         gh_Common.Site,
                                         H_Budget,
                                         H_Account,
                                         H_CR_Type,
                                         H_Reason,
                                         H_Currency,
                                         H_Rate,
                                         H_RemainingBudget,
                                         H_CurrentCR,
                                         H_Balance,
                                         H_UserSubmition,
                                         H_Status,
                                         H_Parent_Circulation,
                                         H_Parent_Circulation_Amount,
                                         gh_Common.Username,
                                         Date.Now,
                                         H_PR,
                                         H_Dies_Sales_Type,
                                         H_Dies_Customer_Name,
                                         H_Dies_Model,
                                         H_Dies,
                                         H_Dies_Remark,
                                         H_ChargedOf,
                                         H_InvoiceNo,
                                         H_InvoiceStatus)

                        For i As Integer = 0 To Collection_Description_Of_Cost.Count - 1
                            With Collection_Description_Of_Cost(i)
                                .InsertCR_Description_Of_Cost(NoSirkualasi)
                            End With
                        Next

                        For i As Integer = 0 To Collection_Other_Dept.Count - 1
                            With Collection_Other_Dept(i)
                                .InsertCR_Other_Dept(NoSirkualasi)
                            End With
                        Next

                        For i As Integer = 0 To Collection_Installment.Count - 1
                            With Collection_Installment(i)
                                .InsertCR_Installment(NoSirkualasi)
                            End With
                        Next

                        Insert_Bom(H_CirculationNo)



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


    Public Sub Insert_CrRequest(CirculationNo As String,
                                RequirementDate As Date,
                                DeptID As String,
                                SiteID As String,
                                Budget As Integer,
                                Account As String,
                                CR_Type As String,
                                Reason As String,
                                Currency As String,
                                Rate As Double,
                                RemainingBudget As Double,
                                CurrentCR As Double,
                                Balance As Double,
                                UserSubmition As Integer,
                                Status As String,
                                Parent As String,
                                ParentAmount As Double,
                                CreatedBy As String,
                                CreatedDate As Date,
                                PRNo As String,
                                Sales_Type As String,
                                Customer_Name As String,
                                Model As String,
                                Dies As Int32,
                                DiesRemark As String,
                                ChangedOf As Int32,
                                InvoiceNo As String,
                                InvoiceStatus As Int32)
        Dim result As Integer = 0


        Try

            If PRNo = "" Then
                PRNo = DBNull.Value.ToString
            End If

            If Parent = "" Then
                Parent = DBNull.Value.ToString
            End If


            If Sales_Type = "" Then
                Sales_Type = DBNull.Value.ToString
            End If

            If Customer_Name = "" Then
                Customer_Name = DBNull.Value.ToString
            End If

            If Model = "" Then
                Model = DBNull.Value.ToString
            End If

            If DiesRemark = "" Then
                DiesRemark = DBNull.Value.ToString
            End If

            If InvoiceNo = "" Then
                InvoiceNo = DBNull.Value.ToString
            End If

            If DiesRemark = "" Then
                DiesRemark = DBNull.Value.ToString
            End If

            If InvoiceNo = "" Then
                InvoiceNo = DBNull.Value.ToString
            End If




            Dim query As String = "[CR_Insert_CrRequest]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(27) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@RequirementDate", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@SiteID", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@Budget", SqlDbType.Int)
            pParam(5) = New SqlClient.SqlParameter("@Account", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@CR_Type", SqlDbType.VarChar)
            pParam(7) = New SqlClient.SqlParameter("@Reason", SqlDbType.VarChar)
            pParam(8) = New SqlClient.SqlParameter("@Currency", SqlDbType.VarChar)
            pParam(9) = New SqlClient.SqlParameter("@Rate", SqlDbType.Float)
            pParam(10) = New SqlClient.SqlParameter("@RemainingBudget", SqlDbType.Float)
            pParam(11) = New SqlClient.SqlParameter("@CurrentCR", SqlDbType.Float)
            pParam(12) = New SqlClient.SqlParameter("@Balance", SqlDbType.Float)
            pParam(13) = New SqlClient.SqlParameter("@UserSubmition", SqlDbType.Int)
            pParam(14) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
            pParam(15) = New SqlClient.SqlParameter("@Parent", SqlDbType.VarChar)
            pParam(16) = New SqlClient.SqlParameter("@ParentAmount ", SqlDbType.Float)
            pParam(17) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            pParam(18) = New SqlClient.SqlParameter("@CreatedDate ", SqlDbType.Date)
            pParam(19) = New SqlClient.SqlParameter("@PRNo ", SqlDbType.VarChar)
            pParam(20) = New SqlClient.SqlParameter("@SalesType ", SqlDbType.VarChar)
            pParam(21) = New SqlClient.SqlParameter("@CustomerName ", SqlDbType.VarChar)
            pParam(22) = New SqlClient.SqlParameter("@Model ", SqlDbType.VarChar)
            pParam(23) = New SqlClient.SqlParameter("@Dies ", SqlDbType.Int)
            pParam(24) = New SqlClient.SqlParameter("@DiesRemark ", SqlDbType.VarChar)
            pParam(25) = New SqlClient.SqlParameter("@ChargedOf ", SqlDbType.Int)
            pParam(26) = New SqlClient.SqlParameter("@InvoiceNo ", SqlDbType.VarChar)
            pParam(27) = New SqlClient.SqlParameter("@InvoiceStatus ", SqlDbType.Int)

            pParam(0).Value = CirculationNo
            pParam(1).Value = RequirementDate
            pParam(2).Value = DeptID
            pParam(3).Value = SiteID
            pParam(4).Value = Budget
            pParam(5).Value = Account
            pParam(6).Value = CR_Type
            pParam(7).Value = Reason
            pParam(8).Value = Currency
            pParam(9).Value = Rate
            pParam(10).Value = RemainingBudget
            pParam(11).Value = CurrentCR
            pParam(12).Value = Balance
            pParam(13).Value = UserSubmition
            pParam(14).Value = Status
            pParam(15).Value = Parent
            pParam(16).Value = ParentAmount
            pParam(17).Value = CreatedBy
            pParam(18).Value = CreatedDate
            pParam(19).Value = PRNo
            pParam(20).Value = Sales_Type
            pParam(21).Value = Customer_Name
            pParam(22).Value = Model
            pParam(23).Value = Dies
            pParam(24).Value = DiesRemark
            pParam(25).Value = ChangedOf
            pParam(26).Value = InvoiceNo
            pParam(27).Value = InvoiceStatus


            'Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub ValidateInsert()
        Try
            'Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi],Tanggal                   
            '                        FROM [AsakaiQualityProblem] where Tanggal = '" & H_Tanggal & "' "
            'Dim dtTable As New DataTable
            ''dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
            '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
            '    "[" & Format(Me.H_Tanggal, "dd-MM-yyyy") & "]")
            'Else

            'End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


#End Region

    Public Sub Insert_Bom(CirculationNo As String)
        Dim result As Integer = 0


        Try

            Dim query As String = "[CR_BOM_Insert]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            'pParam(1) = New SqlClient.SqlParameter("@T1", SqlDbType.VarChar)
            'pParam(2) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            'pParam(3) = New SqlClient.SqlParameter("@PartName", SqlDbType.VarChar)
            'pParam(4) = New SqlClient.SqlParameter("@Qty", SqlDbType.Float)

            pParam(0).Value = CirculationNo



            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub





End Class








Public Class ClsCR_Description_of_Cost

    Public Property D_CirculationNo As String
    Public Property D_Name_Of_Goods As String
    Public Property D_Spesification As String
    Public Property D_Qty As Double
    Public Property D_Price As Double
    Public Property D_Currency As String
    Public Property D_Rate As Double
    Public Property D_Amount As Double
    Public Property D_Amount_IDR As Double
    Public Property D_PR_No As String


    Public Sub InsertCR_Description_Of_Cost(CirculationNo As String)



        Try

            Dim query As String = "[CR_Insert_Description_Of_Cost]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(9) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Name_Of_Goods", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Spesification", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Qty", SqlDbType.Float)
            pParam(4) = New SqlClient.SqlParameter("@Price", SqlDbType.Float)
            pParam(5) = New SqlClient.SqlParameter("@Currency", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@Rate", SqlDbType.Float)
            pParam(7) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
            pParam(8) = New SqlClient.SqlParameter("@Amount_IDR", SqlDbType.Float)
            pParam(9) = New SqlClient.SqlParameter("@PR_No", SqlDbType.VarChar)


            pParam(0).Value = CirculationNo
            pParam(1).Value = D_Name_Of_Goods
            pParam(2).Value = D_Spesification
            pParam(3).Value = D_Qty
            pParam(4).Value = D_Price
            pParam(5).Value = D_Currency
            pParam(6).Value = D_Rate
            pParam(7).Value = D_Amount
            pParam(8).Value = D_Amount_IDR
            pParam(9).Value = D_PR_No



            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub

End Class

Public Class ClsCR_Other_Dept

    Public Property D_CirculationNo As String
    Public Property D_Dept As String
    Public Property D_UserName As String
    Public Property D_Name As String
    Public Property D_Date As Date
    Public Property D_Opinion As String
    Public Property D_Approve As Int32

    Public Sub InsertCR_Other_Dept(CirculationNo As String)



        Try

            Dim query As String = "[CR_Insert_Other_Dept]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)

            pParam(0).Value = CirculationNo
            pParam(1).Value = D_Dept

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub

End Class

Public Class ClsCR_Installment
    Public Property D_CirculationNo As String
    Public Property D_Term As Integer
    Public Property D_Date As Date
    Public Property D_Amount As Double
    Public Property D_Percent As Double

    Public Sub InsertCR_Installment(CirculationNo As String)



        Try



            Dim query As String = "[CR_Insert_Installment]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Term", SqlDbType.Int)
            pParam(2) = New SqlClient.SqlParameter("@Date", SqlDbType.Date)
            pParam(3) = New SqlClient.SqlParameter("@Percent", SqlDbType.Float)
            pParam(4) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)

            pParam(0).Value = CirculationNo
            pParam(1).Value = D_Term
            pParam(2).Value = D_Date
            pParam(3).Value = D_Percent
            pParam(4).Value = D_Amount

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub


End Class

Public Class ClsCR_BomT1
    Public Property D_T1 As String
    Public Property D_PartNo As String
    Public Property D_ParName As String
    Public Property D_Qty As Double


    Public Sub InsertCR_BomTemp()
        Try

            Dim query As String = "[CR_BOM_Insert_Temp]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@T1", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@PartName", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Qty", SqlDbType.Float)

            pParam(0).Value = D_T1
            pParam(1).Value = D_PartNo
            pParam(2).Value = D_ParName
            pParam(3).Value = D_Qty

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class

