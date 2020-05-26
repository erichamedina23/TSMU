Imports System.Data.SqlClient
Public Class TamScan
    Public Property NO() As String
    Public Property Vendor() As String
    Public Property PONo() As String
    Public Property PODate() As String
    Public Property ItemNO As String
    Public Property PartNo() As String
    Public Property PMPName() As String
    Public Property ModelCode() As String
    Public Property OrderQty As Integer
    Public Property CanbanCardQty() As Integer
    Public Property OtusPOQty As Integer
    Public Property PalltizeMark() As String
    Public Property DelScheduleDate() As String
    Public Property DelQty() As Integer
    Public Property PreparedBy() As String


    Public Function GetKanban(PO As String) As DataTable
        Dim dt As New DataTable
        Try

            Dim sql = "KanbanInternal_getTamByPoPartNo"
            Dim param() As SqlParameter = New SqlParameter(0) {}
            param(0) = New SqlParameter("@Po", SqlDbType.VarChar)
            param(0).Value = PO
            dt = GetDataTableByCommand_StorePCKR(sql, param)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateQtyOrder()
        Try
            Dim Sql = "KanbanInternal_Update_orderQty"
            Dim param() As SqlParameter = New SqlParameter(3) {}
            param(0) = New SqlParameter("@po", SqlDbType.VarChar)
            param(0).Value = PONo
            param(1) = New SqlParameter("@partno", SqlDbType.VarChar)
            param(1).Value = PartNo
            param(1) = New SqlParameter("@qty", SqlDbType.Int)
            param(1).Value = DelQty
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub SimpanData()
        Try
            Using Conn1 As New SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Dim trans As New Tam_Trans
                        trans.Simpan()
                        UpdateQtyOrder()
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
            Throw ex
        End Try
    End Sub
End Class

Public Class Tam_Trans
    Public Property ORIG_DELIVERY_DATE() As String
    Public Property DELIVERY_DATE As String

    Public Property SHIPMENT_DATE() As String
    Public Property CASE_NO() As String
    Public Property CASE_PALLETIZE_MARK() As String
    Public Property PO_NO() As String
    Public Property PO_DATE() As String
    Public Property ITEM_NO() As String
    Public Property FRANCHISE() As String
    Public Property PART_NO() As String
    Public Property DELIVERY_QUANTITY() As Integer
    Public Property VENDOR_CODE() As String
    Public Property DELIV_INSTRUCT_DATE() As String

    Public Sub Simpan()
        Try
            Dim Sql = "TamTrans_insert"
            Dim param() As SqlParameter = New SqlParameter(12) {}
            param(0) = New SqlParameter("@OriDelDate", SqlDbType.VarChar)
            param(0).Value = ORIG_DELIVERY_DATE
            param(1) = New SqlParameter("@DelDate", SqlDbType.VarChar)
            param(1).Value = DELIVERY_DATE
            param(2) = New SqlParameter("@ShipDate", SqlDbType.VarChar)
            param(2).Value = SHIPMENT_DATE
            param(3) = New SqlParameter("@CaseNo", SqlDbType.VarChar)
            param(3).Value = CASE_NO
            param(4) = New SqlParameter("@CasePalMark", SqlDbType.VarChar)
            param(4).Value = CASE_PALLETIZE_MARK
            param(5) = New SqlParameter("@PoNo", SqlDbType.VarChar)
            param(5).Value = PO_NO
            param(6) = New SqlParameter("@PoDate", SqlDbType.VarChar)
            param(6).Value = PO_DATE
            param(7) = New SqlParameter("@ItemNo", SqlDbType.VarChar)
            param(7).Value = ITEM_NO
            param(8) = New SqlParameter("@Frenchise", SqlDbType.VarChar)
            param(8).Value = FRANCHISE
            param(9) = New SqlParameter("@PartNo", SqlDbType.VarChar)
            param(9).Value = PART_NO
            param(10) = New SqlParameter("@DelQty", SqlDbType.VarChar)
            param(10).Value = DELIVERY_QUANTITY
            param(11) = New SqlParameter("@Vendor", SqlDbType.VarChar)
            param(11).Value = VENDOR_CODE
            param(12) = New SqlParameter("@DelInsDate", SqlDbType.VarChar)
            param(12).Value = DELIV_INSTRUCT_DATE

            ExecQueryByCommand_SPCKR(Sql, param)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetDataExcel(etd As String, flag As Integer) As DataTable
        Dim dt As New DataTable
        Try

            Dim sql = "TAMrans_getDatataExcel"
            Dim param() As SqlParameter = New SqlParameter(1) {}
            param(0) = New SqlParameter("@delDate", SqlDbType.VarChar)
            param(0).Value = etd
            param(1) = New SqlParameter("@flag", SqlDbType.Char)
            param(1).Value = flag
            dt = GetDataTableByCommand_StorePCKR(sql, param)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateFlag(ByVal DelDate As String)
        Try
            Dim query As String = "TAM_update_flag"
            Dim param() As SqlParameter = New SqlParameter(0) {}
            param(0) = New SqlParameter("@DelDate", SqlDbType.VarChar)
            param(0).Value = DelDate
            ExecQueryByCommand_SPCKR(query, param)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
