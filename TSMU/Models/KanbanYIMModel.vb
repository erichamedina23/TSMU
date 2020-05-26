Public Class KanbanYIMModel
    Public Property Delay_Days As String
    Public Property Delivery_Due_Date As Date?
    Public Property Delivery_Slip_No As String
    Public Property Delivery_Time_From As TimeSpan?
    Public Property Delivery_Time_To As TimeSpan?
    Public Property ID As Integer
    Public Property Item_Class As String
    Public Property Item_Name As String
    Public Property Item_Number As String
    Public Property Item_Status As String
    Public Property Order_No As String
    Public Property Order_Quantity As Integer
    Public Property Output_date As Date?
    Public Property PF As String
    Public Property PF_Name As String
    Public Property Production_Classification As String
    Public Property Remain_Quantity As Integer
    Public Property SEQ As Integer
    Public Property Shipping_LOC As String
    Public Property Supplier_Code As String
    Public Property Supplier_Name As String
    Public Property Unit As String
    Public Property UploadedBy As String
    Public Property UploadedDate As Date?
    Public Property User_Code As String
    Public Property User_Name As String

    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String = "KanbanYIM_GetAllDataGrid"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand_SP(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub InsertData()
        Try
            Dim Query As String = "KanbanYIM_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(23) {}
            pParam(0) = New SqlClient.SqlParameter("@Delay_Days", SqlDbType.VarChar)
            pParam(0).Value = Delay_Days
            pParam(1) = New SqlClient.SqlParameter("@Delivery_Due_Date", SqlDbType.Date)
            pParam(1).Value = Delivery_Due_Date
            pParam(2) = New SqlClient.SqlParameter("@Delivery_Slip_No", SqlDbType.VarChar)
            pParam(2).Value = Delivery_Slip_No
            pParam(3) = New SqlClient.SqlParameter("@Delivery_Time_From", SqlDbType.Time)
            pParam(3).Value = Delivery_Time_From
            pParam(4) = New SqlClient.SqlParameter("@Delivery_Time_To", SqlDbType.Time)
            pParam(4).Value = Delivery_Time_To
            pParam(5) = New SqlClient.SqlParameter("@Item_Class", SqlDbType.VarChar)
            pParam(5).Value = Item_Class
            pParam(6) = New SqlClient.SqlParameter("@Item_Name", SqlDbType.VarChar)
            pParam(6).Value = Item_Name
            pParam(7) = New SqlClient.SqlParameter("@Item_Number", SqlDbType.VarChar)
            pParam(7).Value = Item_Number
            pParam(8) = New SqlClient.SqlParameter("@Item_Status", SqlDbType.VarChar)
            pParam(8).Value = Item_Status
            pParam(9) = New SqlClient.SqlParameter("@Order_No", SqlDbType.VarChar)
            pParam(9).Value = Order_No
            pParam(10) = New SqlClient.SqlParameter("@Order_Quantity", SqlDbType.Int)
            pParam(10).Value = Order_Quantity
            pParam(11) = New SqlClient.SqlParameter("@Output_date", SqlDbType.DateTime)
            pParam(11).Value = Output_date
            pParam(12) = New SqlClient.SqlParameter("@PF", SqlDbType.VarChar)
            pParam(12).Value = PF
            pParam(13) = New SqlClient.SqlParameter("@PF_Name", SqlDbType.VarChar)
            pParam(13).Value = PF_Name
            pParam(14) = New SqlClient.SqlParameter("@Production_Classification", SqlDbType.VarChar)
            pParam(14).Value = Production_Classification
            pParam(15) = New SqlClient.SqlParameter("@Remain_Quantity", SqlDbType.Int)
            pParam(15).Value = Remain_Quantity
            pParam(16) = New SqlClient.SqlParameter("@SEQ", SqlDbType.Int)
            pParam(16).Value = SEQ
            pParam(17) = New SqlClient.SqlParameter("@Shipping_LOC", SqlDbType.VarChar)
            pParam(17).Value = Shipping_LOC
            pParam(18) = New SqlClient.SqlParameter("@Supplier_Code", SqlDbType.VarChar)
            pParam(18).Value = Supplier_Code
            pParam(19) = New SqlClient.SqlParameter("@Supplier_Name", SqlDbType.VarChar)
            pParam(19).Value = Supplier_Name
            pParam(20) = New SqlClient.SqlParameter("@Unit", SqlDbType.VarChar)
            pParam(20).Value = Unit
            pParam(21) = New SqlClient.SqlParameter("@User_Code", SqlDbType.VarChar)
            pParam(21).Value = User_Code
            pParam(22) = New SqlClient.SqlParameter("@User_Name", SqlDbType.VarChar)
            pParam(22).Value = User_Name
            pParam(23) = New SqlClient.SqlParameter("@UploadedBy", SqlDbType.VarChar)
            pParam(23).Value = gh_Common.Username
            ExecQueryByCommand_SP(Query, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetKanban() As DataTable
        Try
            Dim sql As String = "KanbanYIM_GetSummaryOrderQty"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(sql)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub SaveKanbanSum(tgl As String, plant As String, user As String, qty As Integer)
        Try
            Dim sql As String = "KanbanYIMSum_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@tgl", SqlDbType.VarChar)
            pParam(0).Value = tgl
            pParam(1) = New SqlClient.SqlParameter("@plant", SqlDbType.VarChar)
            pParam(1).Value = plant
            pParam(2) = New SqlClient.SqlParameter("@user", SqlDbType.VarChar)
            pParam(2).Value = user
            pParam(3) = New SqlClient.SqlParameter("@qty", SqlDbType.Int)
            pParam(3).Value = qty
            ExecQueryByCommand_SP(sql, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function IsKanbanExist(tgl As String, plant As String, user As String) As Boolean
        Dim hasil As Boolean = False
        Try
            Dim sql As String = "KanbanYIMSum_CekKanban"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@tgl", SqlDbType.VarChar)
            pParam(0).Value = tgl
            pParam(1) = New SqlClient.SqlParameter("@plant", SqlDbType.VarChar)
            pParam(1).Value = plant
            pParam(2) = New SqlClient.SqlParameter("@user", SqlDbType.VarChar)
            pParam(2).Value = user

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(sql, pParam)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
