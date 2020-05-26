Imports System.Collections.ObjectModel
Public Class ClsDelviTransaction
    Dim _ObjDelviDetails As New Collection(Of ClsDelvi)
    Dim ObjHeader As New ClsDelvi
    Public Property BATNBR() As String
    Public Property SHIPPERID() As String
    Public Property CUSTORDNBR() As String
    Public Property InvcDate() As String
    Public Property RefNbr() As String
    Public Property NoFP() As String
    Public Property NoSertifikat() As String

    Public Property ObjDelviDetails() As Collection(Of ClsDelvi)
        Get
            Return Me._ObjDelviDetails
        End Get
        Set(ByVal value As Collection(Of ClsDelvi))
            Me._ObjDelviDetails = value
        End Set
    End Property

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        With ObjHeader
                            .BATNBR = BATNBR
                            .InvcDate = InvcDate
                            .RefNbr = RefNbr
                            .NoSertifikat = NoSertifikat
                            .NoFP = NoFP
                        End With

                        ObjHeader.Insert()

                        For i As Integer = 0 To Me._ObjDelviDetails.Count - 1
                            With Me._ObjDelviDetails(i)
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
End Class
