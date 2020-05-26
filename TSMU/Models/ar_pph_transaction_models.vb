Imports System.Collections.ObjectModel

Public Class ar_pph_transaction_models
    Public Property ObjPPHDetails() As New Collection(Of ar_pph_detail_models)
    Public Property Bulan As String
    Public Property CuryID As String
    Public Property FPNo As String
    Public Property id As Integer
    Public Property ket_dpp As String
    Public Property Ket_Pph As String
    Public Property Lokasi As String
    Public Property No_Bukti_Potong As String
    Public Property No_Faktur As String
    Public Property Pphid As String
    Public Property Tahun As String
    Public Property Tarif As Double
    Public Property Tot_Dpp_Invoice As Double
    Public Property Tot_Pph As Double
    Public Property CMDMNo As String

    Private ObjPPHHeader As New ar_pph_header_models
    Private ObjPPHDetail As New ar_pph_detail_models

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        With ObjPPHHeader
                            .FPNo = Me.FPNo
                            .No_Bukti_Potong = Me.No_Bukti_Potong
                            .Pphid = Me.Pphid
                            .Ket_Pph = Me.Ket_Pph
                            .Tarif = Me.Tarif
                            .Tahun = Me.Tahun
                            .Bulan = Me.Bulan
                            .Lokasi = Me.Lokasi
                            .CuryID = Me.CuryID
                            .Tot_Dpp_Invoice = Me.Tot_Dpp_Invoice
                            .No_Faktur = Me.No_Faktur
                            .ket_dpp = Me.ket_dpp
                            .Tot_Pph = Me.Tot_Pph
                            .CMDMNo = Me.CMDMNo
                        End With

                        ObjPPHHeader.DeleteHeader(FPNo)
                        ObjPPHDetail.DeleteDetail(FPNo)
                        ObjPPHHeader.InsertHeader()
                        ObjPPHHeader.InsertHeadercm()
                        For i As Integer = 0 To Me.ObjPPHDetails.Count - 1
                            With Me.ObjPPHDetails(i)
                                .InsertDetail()
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

    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1
                    Try
                        ObjPPHHeader.DeleteHeader(FPNo)
                        ObjPPHDetail.DeleteDetail(FPNo)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
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
