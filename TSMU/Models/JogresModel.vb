Imports System.Collections.ObjectModel

Public Class JogresModel
    Public Property AlternateId As String
    Public Property Custid As String
    Public Property DeliveryDate As DateTime
    Public Property DeliveryTime As String
    Public Property Id As Integer
    Public Property InvtId As String
    Public Property ItemName As String
    Public Property PartNo As String
    Public Property Plan As String
    Public Property PlantOK As String
    Public Property PO As String
    Public Property Qty As Integer
    Public Property SITEID As String
    Public Property SO As String
    Public Property Time As String
    Public Property TimeOK As String
    Public Property Tujuan As String

    Public Sub SimpanData()
        Try
            Dim query As String = "Jogres_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(13) {}
            pParam(0) = New SqlClient.SqlParameter("@AlternateId", SqlDbType.VarChar)
            pParam(0).Value = AlternateId
            pParam(1) = New SqlClient.SqlParameter("@DeliveryDate", SqlDbType.Date)
            pParam(1).Value = DeliveryDate
            pParam(2) = New SqlClient.SqlParameter("@DeliveryTime", SqlDbType.VarChar)
            pParam(2).Value = DeliveryTime
            pParam(3) = New SqlClient.SqlParameter("@InvtId", SqlDbType.VarChar)
            pParam(3).Value = InvtId
            pParam(4) = New SqlClient.SqlParameter("@ItemName", SqlDbType.VarChar)
            pParam(4).Value = ItemName
            pParam(5) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(5).Value = PartNo
            pParam(6) = New SqlClient.SqlParameter("@Plan", SqlDbType.VarChar)
            pParam(6).Value = Plan
            pParam(7) = New SqlClient.SqlParameter("@PlantOK", SqlDbType.VarChar)
            pParam(7).Value = PlantOK
            pParam(8) = New SqlClient.SqlParameter("@PO", SqlDbType.VarChar)
            pParam(8).Value = PO
            pParam(9) = New SqlClient.SqlParameter("@Qty", SqlDbType.Int)
            pParam(9).Value = Qty
            pParam(10) = New SqlClient.SqlParameter("@Time", SqlDbType.VarChar)
            pParam(10).Value = Time
            pParam(11) = New SqlClient.SqlParameter("@TimeOK", SqlDbType.VarChar)
            pParam(11).Value = TimeOK
            pParam(12) = New SqlClient.SqlParameter("@Tujuan", SqlDbType.VarChar)
            pParam(12).Value = Tujuan
            pParam(13) = New SqlClient.SqlParameter("@SO", SqlDbType.VarChar)
            pParam(13).Value = SO
            ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

Public Class JogressService
    Public Property ObjCollection() As New Collection(Of JogresModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim query As String = "Jogres_GetDataGrid"
            Dim dt As New DataTable
            dt = GetDataTableSP(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridReport(soType As String) As DataTable
        Try
            Dim query As String = "Jogres_getReport"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@type", SqlDbType.VarChar)
            pParam(0).Value = soType
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Delete()
        Try
            Dim query As String = "Jogres_Delete"
            ExecQueryByCommand_SP(query)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        Delete()

                        For i As Integer = 0 To ObjCollection.Count - 1
                            With ObjCollection(i)
                                .SimpanData()
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
            Throw ex
        End Try
    End Sub

End Class
