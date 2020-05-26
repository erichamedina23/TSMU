Imports System.Collections.ObjectModel
Public Class clsCalculateBoMTrans
    Dim _clsDetail As New Collection(Of clsCalculateBoMdetail)
    Dim _clsHeader As New clsCalcultateBoM
    Public Property ID() As Integer
    Public Property bomId() As String
    Public Property invtid() As String
    Public Property descr() As String
    Public Property Semester() As String
    Public Property Tahun() As String
    Public Property Total() As Single
    Public Property Fc_classdetail() As Collection(Of clsCalculateBoMdetail)
        Get
            Return Me._clsDetail
        End Get
        Set(ByVal value As Collection(Of clsCalculateBoMdetail))
            Me._clsDetail = value
        End Set
    End Property

#Region "CRUD"
    Public Sub InsertCalculatedBoM()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        With _clsHeader
                            .bomId = Me._bomId
                            .invtid = Me.invtid
                            .descr = Me.descr
                            .Semester = Me.Semester
                            .Tahun = Me.Tahun
                            .Total = Me.Total
                        End With

                        _clsHeader.InsertHeader()

                        For i As Integer = 0 To Me._clsDetail.Count - 1
                            With Me._clsDetail(i)
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
            Throw
        End Try
    End Sub
#End Region
End Class
