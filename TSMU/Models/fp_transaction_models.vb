Imports System.Collections.ObjectModel

Public Class fp_transaction_models
    Public Property Bulan As String
    Public Property CuryID As String
    Public Property FPNo As String
    Public Property Jenis_Jasa As String
    Public Property Ket_Pph As String
    Public Property Lokasi As String
    Public Property nama_vendor As String
    Public Property No_Bukti_Potong As String
    Public Property npwp As String
    Public Property Pphid As String
    Public Property Status As String
    Public Property Tahun As String
    Public Property Tarif As Double
    Public Property Tgl_fp As DateTime
    Public Property Tot_Dpp_Invoice As Double
    Public Property Tot_Pph As Double
    Public Property Tot_Ppn As Double
    Public Property Tot_Voucher As Double
    Public Property Vend_Name As String
    Public Property VendID As String

    Public Property ObjFPDetails() As New Collection(Of fp_details_models)
    Private ObjFPHeader As New fp_header_models
    Public Property ObjFPDetail() As New fp_details_models
    Public Property ObjFPPphHeader As New fp_pph_header_models
    Public Property ObjFPPphDetail As New fp_pph_detail_models
    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        With ObjFPHeader
                            .FPNo = Me.FPNo
                            .VendID = VendID
                            .Vend_Name = Vend_Name
                            .npwp = npwp
                            .Jenis_Jasa = Jenis_Jasa
                            .Tgl_fp = Tgl_fp
                            .CuryID = CuryID
                            .Tot_Ppn = Tot_Ppn
                            .Tot_Dpp_Invoice = Tot_Dpp_Invoice
                            .Tot_Voucher = Tot_Voucher
                            .Tot_Pph = Tot_Pph
                            .Status = Status
                        End With

                        ObjFPHeader.InsertHeader()

                        For i As Integer = 0 To Me.ObjFPDetails.Count - 1
                            With Me.ObjFPDetails(i)
                                .InsertDetails()
                                .UpdateApDocUser3()
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
                        ObjFPHeader.UpdateApDocUser3(FPNo)
                        ObjFPHeader.DeleteHeader(FPNo)
                        ObjFPDetail.DeleteDetail(FPNo)

                        ObjFPPphHeader.DeleteHeader(FPNo)
                        ObjFPPphDetail.DeleteDetail(FPNo)


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

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1

                    Try
                        With ObjFPHeader
                            .FPNo = Me.FPNo
                            .VendID = VendID
                            .Vend_Name = Vend_Name
                            .npwp = npwp
                            .Jenis_Jasa = Jenis_Jasa
                            .Tgl_fp = Tgl_fp
                            .CuryID = CuryID
                            .Tot_Ppn = Tot_Ppn
                            .Tot_Dpp_Invoice = Tot_Dpp_Invoice
                            .Tot_Voucher = Tot_Voucher
                            .Tot_Pph = Tot_Pph
                            .Status = Status
                        End With
                        ObjFPHeader.UpdateHeader(FPNo)

                        Dim FpDetails As New fp_details_models
                        FpDetails.DeleteDetail(FPNo)

                        For i As Integer = 0 To Me.ObjFPDetails.Count - 1
                            With Me.ObjFPDetails(i)
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
