
Public Class employeeClass

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _jabatan As String
    Public Property Jabatan() As String
        Get
            Return _jabatan
        End Get
        Set(ByVal value As String)
            _jabatan = value
        End Set
    End Property

    Private _bagian As String
    Public Property Bagian() As String
        Get
            Return _bagian
        End Get
        Set(ByVal value As String)
            _bagian = value
        End Set
    End Property


    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String = "select * from tbl_employee order by id"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

            'pParam(0) = New SqlClient.SqlParameter("@TableName", SqlDbType.VarChar)
            'pParam(0).Value = "M_BOM"
            'pParam(1) = New SqlClient.SqlParameter("@Columns", SqlDbType.VarChar)
            'pParam(1).Value = "BOMCode [BOM Code], EIMCode [EIM Code], BOMDate [BOM Date]"
            'pParam(2) = New SqlClient.SqlParameter("@Filter", SqlDbType.VarChar)
            'pParam(2).Value = ls_Filter
            'pParam(3) = New SqlClient.SqlParameter("@Order", SqlDbType.VarChar)
            'pParam(3).Value = "BOMCode ASC"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from tbl_employee where id = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = CInt(Trim(.Item("id") & ""))
                    Me.Name = Trim(.Item("name") & "")
                    Me.Jabatan = Trim(.Item("jabatan") & "")
                    Me.Bagian = Trim(.Item("bagian") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Dim ls_SP As String = "Insert into tbl_employee(name,jabatan,bagian) " &
                                "values('" + QVal(Me._name) + "', " &
                                "'" + QVal(Me._jabatan) + "', " &
                                "'" + QVal(Me._bagian) + "')"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData()
        Try
            Dim ls_SP As String = "update tbl_employee " &
                                    "set name = '" + QVal(Me._name) + "', " &
                                    "jabatan = '" + QVal(Me.Jabatan) + "', " &
                                    "bagian = '" + QVal(Me._bagian) + "' where id = '" + Me._id + "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
