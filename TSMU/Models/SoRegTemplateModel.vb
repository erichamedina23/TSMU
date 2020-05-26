Imports System.Collections.ObjectModel

Public Class SoRegTemplateModel


    Public Property ObjCollection() As New Collection(Of SORegModelColl)
    Public Function GetDataGrid() As DataTable
        Try
            Dim query As String = "SoRegTemplate_GetDataGrid"
            Dim dt As New DataTable
            dt = GetDataTableSP(query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridReport(soType As String) As DataTable
        Try
            Dim query As String = "SoRegTemplate_getReport"
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

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
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

Public Class SORegModelColl
    Public Property AlternateID As String
    Public Property CustID As String
    Public Property Description As String
    Public Property id As Integer
    Public Property InvtID As String
    Public Property Jam As String
    Public Property No As Integer
    Public Property PO As String
    Public Property PromDate As DateTime
    Public Property Qty As Decimal
    Public Property SiteID As String
    Public Property SO As String
    Public Property Tujuan As String
    Public Sub SimpanData()
        Try
            Dim query As String = "SoRegTemplate_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(11) {}
            pParam(0) = New SqlClient.SqlParameter("@AlternateID", SqlDbType.VarChar)
            pParam(0).Value = AlternateID
            pParam(1) = New SqlClient.SqlParameter("@CustID", SqlDbType.VarChar)
            pParam(1).Value = CustID
            pParam(2) = New SqlClient.SqlParameter("@Description", SqlDbType.VarChar)
            pParam(2).Value = Description
            pParam(3) = New SqlClient.SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(3).Value = InvtID
            pParam(4) = New SqlClient.SqlParameter("@Jam", SqlDbType.VarChar)
            pParam(4).Value = Jam
            pParam(5) = New SqlClient.SqlParameter("@No", SqlDbType.Int)
            pParam(5).Value = No
            pParam(6) = New SqlClient.SqlParameter("@PO", SqlDbType.VarChar)
            pParam(6).Value = PO
            pParam(7) = New SqlClient.SqlParameter("@PromDate", SqlDbType.Date)
            pParam(7).Value = PromDate
            pParam(8) = New SqlClient.SqlParameter("@Qty", SqlDbType.Decimal)
            pParam(8).Value = Qty
            pParam(9) = New SqlClient.SqlParameter("@SiteID", SqlDbType.VarChar)
            pParam(9).Value = SiteID
            pParam(10) = New SqlClient.SqlParameter("@SO", SqlDbType.VarChar)
            pParam(10).Value = SO
            pParam(11) = New SqlClient.SqlParameter("@Tujuan", SqlDbType.VarChar)
            pParam(11).Value = Tujuan
            ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
