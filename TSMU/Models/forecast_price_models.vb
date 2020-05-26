Imports System.Collections.ObjectModel
Public Class forecast_price_models_header
    Public Property Tahun As String
    Public Property CustID As String
    Public Property Bulan As String
    Public Property BulanAngka As String
    Public Property ObjForecastCollection() As New Collection(Of forecast_price_models)
    Public Sub DeleteByTahun(Tahun As String)
        Try
            Dim query As String = "DELETE FROM tForecastPrice WHERE Tahun = " & QVal(Tahun) & ""
            Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleleByCustomerTahun()
        Try
            Dim query As String = "DELETE FROM tForecastPrice " & vbCrLf &
            "WHERE tahun = " & QVal(Tahun) & " AND custid = " & QVal(CustID) & ""
            Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetDataADM() As DataTable
        Try
            Dim Query As String = String.Empty
            Query = "GetDataADM"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Query)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetInventoryName(CustID As String) As DataTable
        Try
            Dim Query As String = String.Empty
            Query = "Select RTRIM(Name) Name from Customer where CustID = '" + CustID + "'"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(Query)
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
                        DeleteByTahun(Tahun)
                        For i As Integer = 0 To ObjForecastCollection.Count - 1
                            With ObjForecastCollection(i)
                                .InsertData()
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

    Public Sub InsertData1()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'If CustID.ToLower <> "adm" Then
                        '    DeleleByCustomerTahun()
                        'End If
                        For i As Integer = 0 To ObjForecastCollection.Count - 1
                            With ObjForecastCollection(i)
                                Dim IsExist As Boolean = .IsDataADMExist
                                If Not IsExist Then
                                    .InsertData()
                                    .UpdateDataByBulanNew(Bulan, BulanAngka)
                                Else
                                    .UpdateData1()
                                    .UpdateDataByBulanNew(Bulan, BulanAngka)
                                End If

                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SinkronasiHarga()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        For i As Integer = 0 To ObjForecastCollection.Count - 1
                            With ObjForecastCollection(i)
                                .SinkronisasiHarga(Bulan, BulanAngka)
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataADM()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleleByCustomerTahun()
                        For i As Integer = 0 To ObjForecastCollection.Count - 1
                            With ObjForecastCollection(i)

                                .InsertData()
                                .UpdateDataByBulanADM(Bulan)
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
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
Public Class forecast_price_models
    Public Property Agt_PO1 As Integer
    Public Property Agt_PO2 As Integer
    Public Property AgtHarga1 As Double
    Public Property AgtHarga2 As Double
    Public Property AgtHarga3 As Double
    Public Property AgtQty1 As Integer
    Public Property AgtQty2 As Integer
    Public Property AgtQty3 As Integer
    Public Property Apr_PO1 As Integer
    Public Property Apr_PO2 As Integer
    Public Property AprHarga1 As Double
    Public Property AprHarga2 As Double
    Public Property AprHarga3 As Double
    Public Property AprQty1 As Integer
    Public Property AprQty2 As Integer
    Public Property AprQty3 As Integer
    Public Property created_by As String
    Public Property created_date As DateTime
    Public Property CustID As String
    Public Property Customer As String
    Public Property Des_PO1 As Integer
    Public Property Des_PO2 As Integer
    Public Property Description As String
    Public Property DesHarga1 As Double
    Public Property DesHarga2 As Double
    Public Property DesHarga3 As Double
    Public Property DesQty1 As Integer
    Public Property DesQty2 As Integer
    Public Property DesQty3 As Integer
    Public Property Feb_PO1 As Integer
    Public Property Feb_PO2 As Integer
    Public Property FebHarga1 As Double
    Public Property FebHarga2 As Double
    Public Property FebHarga3 As Double
    Public Property FebQty1 As Integer
    Public Property FebQty2 As Integer
    Public Property FebQty3 As Integer
    Public Property Id As Integer
    Public Property INSub As String
    Public Property InvtID As String
    Public Property Jan_PO1 As Integer
    Public Property Jan_PO2 As Integer
    Public Property JanHarga1 As Double
    Public Property JanHarga2 As Double
    Public Property JanHarga3 As Double
    Public Property JanQty1 As Integer
    Public Property JanQty2 As Integer
    Public Property JanQty3 As Integer
    Public Property Jul_PO1 As Integer
    Public Property Jul_PO2 As Integer
    Public Property JulHarga1 As Double
    Public Property JulHarga2 As Double
    Public Property JulHarga3 As Double
    Public Property JulQty1 As Integer
    Public Property JulQty2 As Integer
    Public Property JulQty3 As Integer
    Public Property Jun_PO1 As Integer
    Public Property Jun_PO2 As Integer
    Public Property JunHarga1 As Double
    Public Property JunHarga2 As Double
    Public Property JunHarga3 As Double
    Public Property JunQty1 As Integer
    Public Property JunQty2 As Integer
    Public Property JunQty3 As Integer
    Public Property Mar_PO1 As Integer
    Public Property Mar_PO2 As Integer
    Public Property MarHarga1 As Double
    Public Property MarHarga2 As Double
    Public Property MarHarga3 As Double
    Public Property MarQty1 As Integer
    Public Property MarQty2 As Integer
    Public Property MarQty3 As Integer
    Public Property Mei_PO1 As Integer
    Public Property Mei_PO2 As Integer
    Public Property MeiHarga1 As Double
    Public Property MeiHarga2 As Double
    Public Property MeiHarga3 As Double
    Public Property MeiQty1 As Integer
    Public Property MeiQty2 As Integer
    Public Property MeiQty3 As Integer
    Public Property Model As String
    Public Property Nov_PO1 As Integer
    Public Property Nov_PO2 As Integer
    Public Property NovHarga1 As Double
    Public Property NovHarga2 As Double
    Public Property NovHarga3 As Double
    Public Property NovQty1 As Integer
    Public Property NovQty2 As Integer
    Public Property NovQty3 As Integer
    Public Property OePe As String
    Public Property Okt_PO1 As Integer
    Public Property Okt_PO2 As Integer
    Public Property OktHarga1 As Double
    Public Property OktHarga2 As Double
    Public Property OktHarga3 As Double
    Public Property OktQty1 As Integer
    Public Property OktQty2 As Integer
    Public Property OktQty3 As Integer
    Public Property PartNo As String
    Public Property Sep_PO1 As Integer
    Public Property Sep_PO2 As Integer
    Public Property SepHarga1 As Double
    Public Property SepHarga2 As Double
    Public Property SepHarga3 As Double
    Public Property SepQty1 As Integer
    Public Property SepQty2 As Integer
    Public Property SepQty3 As Integer
    Public Property Site As String
    Public Property Tahun As String
    Public Property update_date As DateTime
    Public Property Flag As String
    Public Property updated_by As String

    Public Function GetAllDataGrid(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String = "tForecast_getDataGrid"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand_SP(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetAllDataGridById(IsExist As Boolean)
        Try

            Dim ls_SP As String = "SELECT [Id],[Tahun],[CustID],[Customer],[InvtID],[Description],[PartNo],[Model],[Oe/Pe],[IN/SUB],[Site],[Flag]
                                      ,[JanQty1],[JanQty2],[JanQty3],[Jan PO1],[Jan PO2]
                                      ,[FebQty1],[FebQty2],[FebQty3],[Feb PO1],[Feb PO2]
                                      ,[MarQty1],[MarQty2],[MarQty3],[Mar PO1],[Mar PO2]
                                      ,[AprQty1],[AprQty2],[AprQty3],[Apr PO1],[Apr PO2]
                                      ,[MeiQty1],[MeiQty2],[MeiQty3],[Mei PO1],[Mei PO2]
                                      ,[JunQty1],[JunQty2],[JunQty3],[Jun PO1],[Jun PO2]
                                      ,[JulQty1],[JulQty2],[JulQty3],[Jul PO1],[Jul PO2]
                                      ,[AgtQty1],[AgtQty2],[AgtQty3],[Agt PO1],[Agt PO2]
                                      ,[SepQty1],[SepQty2],[SepQty3],[Sep PO1],[Sep PO2]
                                      ,[OktQty1],[OktQty2],[OktQty3],[Okt PO1],[Okt PO2]
                                      ,[NovQty1],[NovQty2],[NovQty3],[Nov PO1],[Nov PO2]
                                      ,[DesQty1],[DesQty2],[DesQty3],[Des PO1],[Des PO2]
                                      ,[JanHarga1],[JanHarga2],[JanHarga3],[FebHarga1]
                                      ,[FebHarga2],[FebHarga3],[MarHarga1],[MarHarga2]
                                      ,[MarHarga3],[AprHarga1],[AprHarga2],[AprHarga3]
                                      ,[MeiHarga1],[MeiHarga2],[MeiHarga3]
                                      ,[JunHarga1],[JunHarga2],[JunHarga3]
                                      ,[JulHarga1],[JulHarga2],[JulHarga3]
                                      ,[AgtHarga1],[AgtHarga2],[AgtHarga3]
                                      ,[SepHarga1],[SepHarga2],[SepHarga3]
                                      ,[OktHarga1],[OktHarga2],[OktHarga3]
                                      ,[NovHarga1],[NovHarga2],[NovHarga3]
                                      ,[DesHarga1],[DesHarga2],[DesHarga3]
                                  FROM [tForecastPrice] "

            If Not IsExist Then
                ls_SP = ls_SP & "WHERE Id=" & QVal(Id) & ""
            Else
                ls_SP = ls_SP & "WHERE Tahun = " & QVal(Tahun) & " and InvtID= " & QVal(InvtID) & " and PartNo = " & QVal(PartNo) & " and CustID = " & QVal(CustID) & ""
            End If
            Dim dtTable As New DataTable
            dtTable = GetDataTable(ls_SP)
            If dtTable.Rows.Count > 0 Then
                Id = If(IsDBNull(dtTable.Rows(0)("Id")), 0, Convert.ToInt32(dtTable.Rows(0)("Id")))
                Tahun = If(IsDBNull(dtTable.Rows(0)("Tahun")), "", Convert.ToString(dtTable.Rows(0)("Tahun")))
                CustID = If(IsDBNull(dtTable.Rows(0)("CustID")), "", Convert.ToString(dtTable.Rows(0)("CustID")))
                Customer = If(IsDBNull(dtTable.Rows(0)("Customer")), "", Convert.ToString(dtTable.Rows(0)("Customer")))
                InvtID = If(IsDBNull(dtTable.Rows(0)("InvtID")), "", Convert.ToString(dtTable.Rows(0)("InvtID")))
                Description = If(IsDBNull(dtTable.Rows(0)("Description")), "", Convert.ToString(dtTable.Rows(0)("Description")))
                PartNo = If(IsDBNull(dtTable.Rows(0)("PartNo")), "", Convert.ToString(dtTable.Rows(0)("PartNo")))
                Model = If(IsDBNull(dtTable.Rows(0)("Model")), "", Convert.ToString(dtTable.Rows(0)("Model")))
                OePe = If(IsDBNull(dtTable.Rows(0)("Oe/Pe")), "", Convert.ToString(dtTable.Rows(0)("Oe/Pe")))
                INSub = If(IsDBNull(dtTable.Rows(0)("IN/SUB")), "", Convert.ToString(dtTable.Rows(0)("IN/SUB")))
                Site = If(IsDBNull(dtTable.Rows(0)("Site")), "", Convert.ToString(dtTable.Rows(0)("Site")))
                Flag = If(IsDBNull(dtTable.Rows(0)("Flag")), "", Convert.ToString(dtTable.Rows(0)("Flag")))

                JanQty1 = If(IsDBNull(dtTable.Rows(0)("JanQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("JanQty1")))
                JanQty2 = If(IsDBNull(dtTable.Rows(0)("JanQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("JanQty2")))
                JanQty3 = If(IsDBNull(dtTable.Rows(0)("JanQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("JanQty3")))
                Jan_PO1 = If(IsDBNull(dtTable.Rows(0)("Jan PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Jan PO1")))
                Jan_PO2 = If(IsDBNull(dtTable.Rows(0)("Jan PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Jan PO2")))

                FebQty1 = If(IsDBNull(dtTable.Rows(0)("FebQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("FebQty1")))
                FebQty2 = If(IsDBNull(dtTable.Rows(0)("FebQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("FebQty2")))
                FebQty3 = If(IsDBNull(dtTable.Rows(0)("FebQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("FebQty3")))
                Feb_PO1 = If(IsDBNull(dtTable.Rows(0)("Feb PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Feb PO1")))
                Feb_PO2 = If(IsDBNull(dtTable.Rows(0)("Feb PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Feb PO2")))

                MarQty1 = If(IsDBNull(dtTable.Rows(0)("MarQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("MarQty1")))
                MarQty2 = If(IsDBNull(dtTable.Rows(0)("MarQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("MarQty2")))
                MarQty3 = If(IsDBNull(dtTable.Rows(0)("MarQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("MarQty3")))
                Mar_PO1 = If(IsDBNull(dtTable.Rows(0)("Mar PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Mar PO1")))
                Mar_PO2 = If(IsDBNull(dtTable.Rows(0)("Mar PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Mar PO2")))

                AprQty1 = If(IsDBNull(dtTable.Rows(0)("AprQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("AprQty1")))
                AprQty2 = If(IsDBNull(dtTable.Rows(0)("AprQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("AprQty2")))
                AprQty3 = If(IsDBNull(dtTable.Rows(0)("AprQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("AprQty3")))
                Apr_PO1 = If(IsDBNull(dtTable.Rows(0)("Apr PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Apr PO1")))
                Apr_PO2 = If(IsDBNull(dtTable.Rows(0)("Apr PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Apr PO2")))

                MeiQty1 = If(IsDBNull(dtTable.Rows(0)("MeiQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("MeiQty1")))
                MeiQty2 = If(IsDBNull(dtTable.Rows(0)("MeiQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("MeiQty2")))
                MeiQty3 = If(IsDBNull(dtTable.Rows(0)("MeiQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("MeiQty3")))
                Mei_PO1 = If(IsDBNull(dtTable.Rows(0)("Mei PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Mei PO1")))
                Mei_PO2 = If(IsDBNull(dtTable.Rows(0)("Mei PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Mei PO2")))

                JunQty1 = If(IsDBNull(dtTable.Rows(0)("JunQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("JunQty1")))
                JunQty2 = If(IsDBNull(dtTable.Rows(0)("JunQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("JunQty2")))
                JunQty3 = If(IsDBNull(dtTable.Rows(0)("JunQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("JunQty3")))
                Jun_PO1 = If(IsDBNull(dtTable.Rows(0)("Jun PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Jun PO1")))
                Jun_PO2 = If(IsDBNull(dtTable.Rows(0)("Jun PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Jun PO2")))

                JulQty1 = If(IsDBNull(dtTable.Rows(0)("JulQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("JulQty1")))
                JulQty2 = If(IsDBNull(dtTable.Rows(0)("JulQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("JulQty2")))
                JulQty3 = If(IsDBNull(dtTable.Rows(0)("JulQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("JulQty3")))
                Jul_PO1 = If(IsDBNull(dtTable.Rows(0)("Jul PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Jul PO1")))
                Jul_PO2 = If(IsDBNull(dtTable.Rows(0)("Jul PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Jul PO2")))

                AgtQty1 = If(IsDBNull(dtTable.Rows(0)("AgtQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("AgtQty1")))
                AgtQty2 = If(IsDBNull(dtTable.Rows(0)("AgtQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("AgtQty2")))
                AgtQty3 = If(IsDBNull(dtTable.Rows(0)("AgtQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("AgtQty3")))
                Agt_PO1 = If(IsDBNull(dtTable.Rows(0)("Agt PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Agt PO1")))
                Agt_PO2 = If(IsDBNull(dtTable.Rows(0)("Agt PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Agt PO2")))

                SepQty1 = If(IsDBNull(dtTable.Rows(0)("SepQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("SepQty1")))
                SepQty2 = If(IsDBNull(dtTable.Rows(0)("SepQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("SepQty2")))
                SepQty3 = If(IsDBNull(dtTable.Rows(0)("SepQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("SepQty3")))
                Sep_PO1 = If(IsDBNull(dtTable.Rows(0)("Sep PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Sep PO1")))
                Sep_PO2 = If(IsDBNull(dtTable.Rows(0)("Sep PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Sep PO2")))

                OktQty1 = If(IsDBNull(dtTable.Rows(0)("OktQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("OktQty1")))
                OktQty2 = If(IsDBNull(dtTable.Rows(0)("OktQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("OktQty2")))
                OktQty3 = If(IsDBNull(dtTable.Rows(0)("OktQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("OktQty3")))
                Okt_PO1 = If(IsDBNull(dtTable.Rows(0)("Okt PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Okt PO1")))
                Okt_PO2 = If(IsDBNull(dtTable.Rows(0)("Okt PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Okt PO2")))

                NovQty1 = If(IsDBNull(dtTable.Rows(0)("NovQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("NovQty1")))
                NovQty2 = If(IsDBNull(dtTable.Rows(0)("NovQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("NovQty2")))
                NovQty3 = If(IsDBNull(dtTable.Rows(0)("NovQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("NovQty3")))
                Nov_PO1 = If(IsDBNull(dtTable.Rows(0)("Nov PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Nov PO1")))
                Nov_PO2 = If(IsDBNull(dtTable.Rows(0)("Nov PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Nov PO2")))

                DesQty1 = If(IsDBNull(dtTable.Rows(0)("DesQty1")), 0, Convert.ToInt32(dtTable.Rows(0)("DesQty1")))
                DesQty2 = If(IsDBNull(dtTable.Rows(0)("DesQty2")), 0, Convert.ToInt32(dtTable.Rows(0)("DesQty2")))
                DesQty3 = If(IsDBNull(dtTable.Rows(0)("DesQty3")), 0, Convert.ToInt32(dtTable.Rows(0)("DesQty3")))
                Des_PO1 = If(IsDBNull(dtTable.Rows(0)("Des PO1")), 0, Convert.ToInt32(dtTable.Rows(0)("Des PO1")))
                Des_PO2 = If(IsDBNull(dtTable.Rows(0)("Des PO2")), 0, Convert.ToInt32(dtTable.Rows(0)("Des PO2")))

                JanHarga1 = If(IsDBNull(dtTable.Rows(0)("JanHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("JanHarga1")))
                JanHarga2 = If(IsDBNull(dtTable.Rows(0)("JanHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("JanHarga2")))
                JanHarga3 = If(IsDBNull(dtTable.Rows(0)("JanHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("JanHarga3")))
                FebHarga1 = If(IsDBNull(dtTable.Rows(0)("FebHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("FebHarga1")))
                FebHarga2 = If(IsDBNull(dtTable.Rows(0)("FebHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("FebHarga2")))
                FebHarga3 = If(IsDBNull(dtTable.Rows(0)("FebHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("FebHarga3")))
                MarHarga1 = If(IsDBNull(dtTable.Rows(0)("MarHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("MarHarga1")))
                MarHarga2 = If(IsDBNull(dtTable.Rows(0)("MarHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("MarHarga2")))
                MarHarga3 = If(IsDBNull(dtTable.Rows(0)("MarHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("MarHarga3")))
                AprHarga1 = If(IsDBNull(dtTable.Rows(0)("AprHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("AprHarga1")))
                AprHarga2 = If(IsDBNull(dtTable.Rows(0)("AprHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("AprHarga2")))
                AprHarga3 = If(IsDBNull(dtTable.Rows(0)("AprHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("AprHarga3")))
                MeiHarga1 = If(IsDBNull(dtTable.Rows(0)("MeiHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("MeiHarga1")))
                MeiHarga2 = If(IsDBNull(dtTable.Rows(0)("MeiHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("MeiHarga2")))
                MeiHarga3 = If(IsDBNull(dtTable.Rows(0)("MeiHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("MeiHarga3")))
                JunHarga1 = If(IsDBNull(dtTable.Rows(0)("JunHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("JunHarga1")))
                JunHarga2 = If(IsDBNull(dtTable.Rows(0)("JunHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("JunHarga2")))
                JunHarga3 = If(IsDBNull(dtTable.Rows(0)("JunHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("JunHarga3")))
                JulHarga1 = If(IsDBNull(dtTable.Rows(0)("JulHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("JulHarga1")))
                JulHarga2 = If(IsDBNull(dtTable.Rows(0)("JulHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("JulHarga2")))
                JulHarga3 = If(IsDBNull(dtTable.Rows(0)("JulHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("JulHarga3")))
                AgtHarga1 = If(IsDBNull(dtTable.Rows(0)("AgtHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("AgtHarga1")))
                AgtHarga2 = If(IsDBNull(dtTable.Rows(0)("AgtHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("AgtHarga2")))
                AgtHarga3 = If(IsDBNull(dtTable.Rows(0)("AgtHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("AgtHarga3")))
                SepHarga1 = If(IsDBNull(dtTable.Rows(0)("SepHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("SepHarga1")))
                SepHarga2 = If(IsDBNull(dtTable.Rows(0)("SepHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("SepHarga2")))
                SepHarga3 = If(IsDBNull(dtTable.Rows(0)("SepHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("SepHarga3")))
                OktHarga1 = If(IsDBNull(dtTable.Rows(0)("OktHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("OktHarga1")))
                OktHarga2 = If(IsDBNull(dtTable.Rows(0)("OktHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("OktHarga2")))
                OktHarga3 = If(IsDBNull(dtTable.Rows(0)("OktHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("OktHarga3")))
                NovHarga1 = If(IsDBNull(dtTable.Rows(0)("NovHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("NovHarga1")))
                NovHarga2 = If(IsDBNull(dtTable.Rows(0)("NovHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("NovHarga2")))
                NovHarga3 = If(IsDBNull(dtTable.Rows(0)("NovHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("NovHarga3")))
                DesHarga1 = If(IsDBNull(dtTable.Rows(0)("DesHarga1")), 0, Convert.ToDouble(dtTable.Rows(0)("DesHarga1")))
                DesHarga2 = If(IsDBNull(dtTable.Rows(0)("DesHarga2")), 0, Convert.ToDouble(dtTable.Rows(0)("DesHarga2")))
                DesHarga3 = If(IsDBNull(dtTable.Rows(0)("DesHarga3")), 0, Convert.ToDouble(dtTable.Rows(0)("DesHarga3")))

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleleByTahunCustPartInvt()
        Try
            Dim query As String = "DELETE FROM tForecastPrice " & vbCrLf &
            "WHERE tahun = " & QVal(Tahun) & " AND partno= " & QVal(PartNo) & " AND invtid = " & QVal(InvtID) & " AND custid = " & QVal(CustID) & ""
            Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub DeleteById()
        Try
            Dim query As String = "DELETE FROM tForecastPrice WHERE id = " & QVal(Me.Id) & " "
            Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteByTahun(Tahun As String, CustID As String)
        Try
            Dim query As String = "DELETE FROM tForecastPrice WHERE Tahun = " & QVal(Tahun) & " AND RTRIM(CustID)= " & QVal(CustID.TrimEnd) & " "
            Dim li_Row = ExecQuery(query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function getSalesPrice(bulan As String, tahun As String) As Double
        Dim salesPrice As Double = 0

        Try

            Dim Sql As String = "SO_getLastPrice"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
            pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.VarChar)
            pParam(0).Value = tahun
            pParam(1) = New SqlClient.SqlParameter("@bulan", SqlDbType.VarChar)
            pParam(1).Value = bulan
            pParam(2) = New SqlClient.SqlParameter("@custId", SqlDbType.Char)
            pParam(2).Value = CustID
            pParam(3) = New SqlClient.SqlParameter("@invtId", SqlDbType.Char)
            pParam(3).Value = InvtID
            pParam(4) = New SqlClient.SqlParameter("@alternateId", SqlDbType.Char)
            pParam(4).Value = PartNo

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(Sql, pParam)
            If dt.Rows.Count > 0 Then
                salesPrice = Convert.ToDouble(dt.Rows(0)(0))
            End If
            Return salesPrice
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertData()
        Try

            Dim Query As String = String.Empty
            Query = "INSERT INTO [tForecastPrice]([Tahun],[CustID],[Customer],[InvtID],[Description],[PartNo],[Model],[Oe/Pe],[IN/SUB],[Site],[Flag]
                            ,[JanQty1],[JanQty2],[JanQty3],[Jan PO1],[Jan PO2]
                            ,[FebQty1],[FebQty2],[FebQty3],[Feb PO1],[Feb PO2]
                            ,[MarQty1],[MarQty2],[MarQty3],[Mar PO1],[Mar PO2]
                            ,[AprQty1],[AprQty2],[AprQty3],[Apr PO1],[Apr PO2]
                            ,[MeiQty1],[MeiQty2],[MeiQty3],[Mei PO1],[Mei PO2]
                            ,[JunQty1],[JunQty2],[JunQty3],[Jun PO1],[Jun PO2]
                            ,[JulQty1],[JulQty2],[JulQty3],[Jul PO1],[Jul PO2]
                            ,[AgtQty1],[AgtQty2],[AgtQty3],[Agt PO1],[Agt PO2]
                            ,[SepQty1],[SepQty2],[SepQty3],[Sep PO1],[Sep PO2]
                            ,[OktQty1],[OktQty2],[OktQty3],[Okt PO1],[Okt PO2]
                            ,[NovQty1],[NovQty2],[NovQty3],[Nov PO1],[Nov PO2]
                            ,[DesQty1],[DesQty2],[DesQty3],[Des PO1],[Des PO2]
                            ,[created_date],[created_by])
                    Values(" & QVal(Tahun) & "," & QVal(CustID) & "," & QVal(Customer) & "," & QVal(InvtID) & "," & QVal(Description) & "," & QVal(PartNo) & "," & QVal(Model) & "," & QVal(OePe) & "," & QVal(INSub) & "," & QVal(Site) & "," & QVal(Flag) & "
                           ," & QVal(JanQty1) & "," & QVal(JanQty2) & "," & QVal(JanQty3) & "," & QVal(Jan_PO1) & "," & QVal(Jan_PO2) & "
                           ," & QVal(FebQty1) & "," & QVal(FebQty2) & "," & QVal(FebQty3) & "," & QVal(Feb_PO1) & "," & QVal(Feb_PO2) & "
                           ," & QVal(MarQty1) & "," & QVal(MarQty2) & "," & QVal(MarQty3) & "," & QVal(Mar_PO1) & "," & QVal(Mar_PO2) & "
                           ," & QVal(AprQty1) & "," & QVal(AprQty2) & "," & QVal(AprQty3) & "," & QVal(Apr_PO1) & "," & QVal(Apr_PO2) & "
                           ," & QVal(MeiQty1) & "," & QVal(MeiQty2) & "," & QVal(MeiQty3) & "," & QVal(Mei_PO1) & "," & QVal(Mei_PO2) & "
                           ," & QVal(JunQty1) & "," & QVal(JunQty2) & "," & QVal(JunQty3) & "," & QVal(Jun_PO1) & "," & QVal(Jun_PO2) & "
                           ," & QVal(JulQty1) & "," & QVal(JulQty2) & "," & QVal(JulQty3) & "," & QVal(Jul_PO1) & "," & QVal(Jul_PO2) & "
                           ," & QVal(AgtQty1) & "," & QVal(AgtQty2) & "," & QVal(AgtQty3) & "," & QVal(Agt_PO1) & "," & QVal(Agt_PO2) & "
                           ," & QVal(SepQty1) & "," & QVal(SepQty2) & "," & QVal(SepQty3) & "," & QVal(Sep_PO1) & "," & QVal(Sep_PO2) & "
                           ," & QVal(OktQty1) & "," & QVal(OktQty2) & "," & QVal(OktQty3) & "," & QVal(Okt_PO1) & "," & QVal(Okt_PO2) & "
                           ," & QVal(NovQty1) & "," & QVal(NovQty2) & "," & QVal(NovQty3) & "," & QVal(Nov_PO1) & "," & QVal(Nov_PO2) & "
                           ," & QVal(DesQty1) & "," & QVal(DesQty2) & "," & QVal(DesQty3) & "," & QVal(Des_PO1) & "," & QVal(Des_PO2) & "
                           ," & QVal(created_date) & "," & QVal(created_by) & ")"
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataTempTable()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [tForecastPrice_Temp]([Tahun],[CustID],[Customer],[InvtID],[Description],[PartNo],[Model],[Oe/Pe],[IN/SUB],[Site] 
                            ,[JanQty1],[JanQty2],[JanQty3],[Jan PO1],[Jan PO2],[JanHarga1],[JanHarga2],[JanHarga3]
                            ,[FebQty1],[FebQty2],[FebQty3],[Feb PO1],[Feb PO2],[FebHarga1],[FebHarga2],[FebHarga3]
                            ,[MarQty1],[MarQty2],[MarQty3],[Mar PO1],[Mar PO2],[MarHarga1],[MarHarga2],[MarHarga3]
                            ,[AprQty1],[AprQty2],[AprQty3],[Apr PO1],[Apr PO2],[AprHarga1],[AprHarga2],[AprHarga3]
                            ,[MeiQty1],[MeiQty2],[MeiQty3],[Mei PO1],[Mei PO2],[MeiHarga1],[MeiHarga2],[MeiHarga3]
                            ,[JunQty1],[JunQty2],[JunQty3],[Jun PO1],[Jun PO2],[JunHarga1],[JunHarga2],[JunHarga3]
                            ,[JulQty1],[JulQty2],[JulQty3],[Jul PO1],[Jul PO2],[JulHarga1],[JulHarga2],[JulHarga3]
                            ,[AgtQty1],[AgtQty2],[AgtQty3],[Agt PO1],[Agt PO2],[AgtHarga1],[AgtHarga2],[AgtHarga3]
                            ,[SepQty1],[SepQty2],[SepQty3],[Sep PO1],[Sep PO2],[SepHarga1],[SepHarga2],[SepHarga3]
                            ,[OktQty1],[OktQty2],[OktQty3],[Okt PO1],[Okt PO2],[OktHarga1],[OktHarga2],[OktHarga3]
                            ,[NovQty1],[NovQty2],[NovQty3],[Nov PO1],[Nov PO2],[NovHarga1],[NovHarga2],[NovHarga3]
                            ,[DesQty1],[DesQty2],[DesQty3],[Des PO1],[Des PO2],[DesHarga1],[DesHarga2],[DesHarga3]
                            ,[created_date],[created_by])
                    Values(" & QVal(Tahun) & "," & QVal(CustID) & "," & QVal(Customer) & "," & QVal(InvtID) & "," & QVal(Description) & "," & QVal(PartNo) & "," & QVal(Model) & "," & QVal(OePe) & "," & QVal(INSub) & "," & QVal(Site) & "
                           ," & QVal(JanQty1) & "," & QVal(JanQty2) & "," & QVal(JanQty3) & "," & QVal(Jan_PO1) & "," & QVal(Jan_PO2) & "," & QVal(JanHarga1) & "," & QVal(JanHarga2) & "," & QVal(JanHarga3) & "
                           ," & QVal(FebQty1) & "," & QVal(FebQty2) & "," & QVal(FebQty3) & "," & QVal(Feb_PO1) & "," & QVal(Feb_PO2) & "," & QVal(FebHarga1) & "," & QVal(FebHarga2) & "," & QVal(FebHarga3) & "
                           ," & QVal(MarQty1) & "," & QVal(MarQty2) & "," & QVal(MarQty3) & "," & QVal(Mar_PO1) & "," & QVal(Mar_PO2) & "," & QVal(MarHarga1) & "," & QVal(MarHarga2) & "," & QVal(MarHarga3) & "
                           ," & QVal(AprQty1) & "," & QVal(AprQty2) & "," & QVal(AprQty3) & "," & QVal(Apr_PO1) & "," & QVal(Apr_PO2) & "," & QVal(AprHarga1) & "," & QVal(AprHarga2) & "," & QVal(AprHarga3) & "
                           ," & QVal(MeiQty1) & "," & QVal(MeiQty2) & "," & QVal(MeiQty3) & "," & QVal(Mei_PO1) & "," & QVal(Mei_PO2) & "," & QVal(MeiHarga1) & "," & QVal(MeiHarga2) & "," & QVal(MeiHarga3) & "
                           ," & QVal(JunQty1) & "," & QVal(JunQty2) & "," & QVal(JunQty3) & "," & QVal(Jun_PO1) & "," & QVal(Jun_PO2) & "," & QVal(JunHarga1) & "," & QVal(JunHarga2) & "," & QVal(JunHarga3) & "
                           ," & QVal(JulQty1) & "," & QVal(JulQty2) & "," & QVal(JulQty3) & "," & QVal(Jul_PO1) & "," & QVal(Jul_PO2) & "," & QVal(JulHarga1) & "," & QVal(JulHarga2) & "," & QVal(JulHarga3) & "
                           ," & QVal(AgtQty1) & "," & QVal(AgtQty2) & "," & QVal(AgtQty3) & "," & QVal(Agt_PO1) & "," & QVal(Agt_PO2) & "," & QVal(AgtHarga1) & "," & QVal(AgtHarga2) & "," & QVal(AgtHarga3) & "
                           ," & QVal(SepQty1) & "," & QVal(SepQty2) & "," & QVal(SepQty3) & "," & QVal(Sep_PO1) & "," & QVal(Sep_PO2) & "," & QVal(SepHarga1) & "," & QVal(SepHarga2) & "," & QVal(SepHarga3) & "
                           ," & QVal(OktQty1) & "," & QVal(OktQty2) & "," & QVal(OktQty3) & "," & QVal(Okt_PO1) & "," & QVal(Okt_PO2) & "," & QVal(OktHarga1) & "," & QVal(OktHarga2) & "," & QVal(OktHarga3) & "
                           ," & QVal(NovQty1) & "," & QVal(NovQty2) & "," & QVal(NovQty3) & "," & QVal(Nov_PO1) & "," & QVal(Nov_PO2) & "," & QVal(NovHarga1) & "," & QVal(NovHarga2) & "," & QVal(NovHarga3) & "
                           ," & QVal(DesQty1) & "," & QVal(DesQty2) & "," & QVal(DesQty3) & "," & QVal(Des_PO1) & "," & QVal(Des_PO2) & "," & QVal(DesHarga1) & "," & QVal(DesHarga2) & "," & QVal(DesHarga3) & "
                           ," & QVal(created_date) & "," & QVal(created_by) & ")"
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDataByBulanADM(Bulan As String)
        Dim sql As String = String.Empty
        Dim Harga As Double = 0
        Dim Query1 As String = String.Empty
        Try
            If Bulan.ToLower = "januari" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [JanHarga1] =  " & QVal(JanHarga1) & " 
                                    ,[JanHarga2] =  " & QVal(JanHarga2) & " 
                                    ,[JanHarga3] =  " & QVal(JanHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_jan =
	                                CASE 
	                                        WHEN JanHarga1!=0 and JanHarga2=0  and JanHarga3=0 THEN JanHarga1  
	                                        WHEN JanHarga1!=0 and JanHarga2!=0 and JanHarga3=0 THEN JanHarga2  
	                                        WHEN JanHarga1!=0 and JanHarga2!=0 and JanHarga3!=0 THEN JanHarga3  
	                                        WHEN JanHarga1=0  and JanHarga2!=0 and JanHarga3=0 THEN JanHarga2  
	                                        WHEN JanHarga1=0 and JanHarga2=0  and JanHarga3!=0 THEN JanHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [FebHarga1] =  " & QVal(Harga) & " 
                                    ,[MarHarga1] =  " & QVal(Harga) & "
                                    ,[AprHarga1] =  " & QVal(Harga) & "
                                    ,[MeiHarga1] =  " & QVal(Harga) & "
                                    ,[JunHarga1] =  " & QVal(Harga) & "
                                    ,[JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[JanQty1] = " & QVal(JanQty1) & "
                                    ,[JanQty2] = " & QVal(JanQty2) & "
                                    ,[JanQty3] = " & QVal(JanQty3) & "
                                    ,[Jan PO1] =  " & QVal(Jan_PO1) & "
                                    ,[Jan PO2] =  " & QVal(Jan_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========FEBRUARI===============
            ElseIf Bulan.ToLower = "februari" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [FebHarga1] =  " & QVal(FebHarga1) & " 
                                    ,[FebHarga2] =  " & QVal(FebHarga2) & " 
                                    ,[FebHarga3] =  " & QVal(FebHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Feb =
	                                CASE 
	                                        WHEN FebHarga1!=0 and FebHarga2=0  and FebHarga3=0 THEN FebHarga1  
	                                        WHEN FebHarga1!=0 and FebHarga2!=0 and FebHarga3=0 THEN FebHarga2  
	                                        WHEN FebHarga1!=0 and FebHarga2!=0 and FebHarga3!=0 THEN FebHarga3  
	                                        WHEN FebHarga1=0  and FebHarga2!=0 and FebHarga3=0 THEN FebHarga2  
	                                        WHEN FebHarga1=0 and FebHarga2=0  and FebHarga3!=0 THEN FebHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [MarHarga1] =  " & QVal(Harga) & "
                                    ,[AprHarga1] =  " & QVal(Harga) & "
                                    ,[MeiHarga1] =  " & QVal(Harga) & "
                                    ,[JunHarga1] =  " & QVal(Harga) & "
                                    ,[JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[FebQty1] = " & QVal(FebQty1) & "
                                    ,[FebQty2] = " & QVal(FebQty2) & "
                                    ,[FebQty3] = " & QVal(FebQty3) & "
                                    ,[Feb PO1] =  " & QVal(Feb_PO1) & "
                                    ,[Feb PO2] =  " & QVal(Feb_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========MARET===============
            ElseIf Bulan.ToLower = "maret" Then
                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [MarHarga1] =  " & QVal(MarHarga1) & " 
                                    ,[MarHarga2] =  " & QVal(MarHarga2) & " 
                                    ,[MarHarga3] =  " & QVal(MarHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Mar =
	                                CASE 
	                                        WHEN MarHarga1!=0 and MarHarga2=0  and MarHarga3=0 THEN MarHarga1  
	                                        WHEN MarHarga1!=0 and MarHarga2!=0 and MarHarga3=0 THEN MarHarga2  
	                                        WHEN MarHarga1!=0 and MarHarga2!=0 and MarHarga3!=0 THEN MarHarga3  
	                                        WHEN MarHarga1=0  and MarHarga2!=0 and MarHarga3=0 THEN MarHarga2  
	                                        WHEN MarHarga1=0 and MarHarga2=0  and MarHarga3!=0 THEN MarHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [AprHarga1] =  " & QVal(Harga) & "
                                    ,[MeiHarga1] =  " & QVal(Harga) & "
                                    ,[JunHarga1] =  " & QVal(Harga) & "
                                    ,[JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[MarQty1] = " & QVal(MarQty1) & "
                                    ,[MarQty2] = " & QVal(MarQty2) & "
                                    ,[MarQty3] = " & QVal(MarQty3) & "
                                    ,[Mar PO1] =  " & QVal(Mar_PO1) & "
                                    ,[Mar PO2] =  " & QVal(Mar_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========APRIL===============
            ElseIf Bulan.ToLower = "april" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [AprHarga1] =  " & QVal(AprHarga1) & " 
                                    ,[AprHarga2] =  " & QVal(AprHarga2) & " 
                                    ,[AprHarga3] =  " & QVal(AprHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN AprHarga1!=0 and AprHarga2=0  and AprHarga3=0 THEN AprHarga1  
	                                        WHEN AprHarga1!=0 and AprHarga2!=0 and AprHarga3=0 THEN AprHarga2  
	                                        WHEN AprHarga1!=0 and AprHarga2!=0 and AprHarga3!=0 THEN AprHarga3  
	                                        WHEN AprHarga1=0  and AprHarga2!=0 and AprHarga3=0 THEN AprHarga2  
	                                        WHEN AprHarga1=0 and AprHarga2=0  and AprHarga3!=0 THEN AprHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [MeiHarga1] =  " & QVal(Harga) & "
                                    ,[JunHarga1] =  " & QVal(Harga) & "
                                    ,[JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[AprQty1] = " & QVal(AprQty1) & "
                                    ,[AprQty2] = " & QVal(AprQty2) & "
                                    ,[AprQty3] = " & QVal(AprQty3) & "
                                    ,[Apr PO1] =  " & QVal(Apr_PO1) & "
                                    ,[Apr PO2] =  " & QVal(Apr_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========MEI===============
            ElseIf Bulan.ToLower = "mei" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [MeiHarga1] =  " & QVal(MeiHarga1) & " 
                                    ,[MeiHarga2] =  " & QVal(MeiHarga2) & " 
                                    ,[MeiHarga3] =  " & QVal(MeiHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN MeiHarga1!=0 and MeiHarga2=0  and MeiHarga3=0 THEN MeiHarga1  
	                                        WHEN MeiHarga1!=0 and MeiHarga2!=0 and MeiHarga3=0 THEN MeiHarga2  
	                                        WHEN MeiHarga1!=0 and MeiHarga2!=0 and MeiHarga3!=0 THEN MeiHarga3  
	                                        WHEN MeiHarga1=0  and MeiHarga2!=0 and MeiHarga3=0 THEN MeiHarga2  
	                                        WHEN MeiHarga1=0 and MeiHarga2=0  and MeiHarga3!=0 THEN MeiHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [JunHarga1] =  " & QVal(Harga) & "
                                    ,[JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[MeiQty1] = " & QVal(MeiQty1) & "
                                    ,[MeiQty2] = " & QVal(MeiQty2) & "
                                    ,[MeiQty3] = " & QVal(MeiQty3) & "
                                    ,[Mei PO1] =  " & QVal(Mei_PO1) & "
                                    ,[Mei PO2] =  " & QVal(Mei_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========JUNI===============
            ElseIf Bulan.ToLower = "juni" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [JunHarga1] =  " & QVal(JunHarga1) & " 
                                    ,[JunHarga2] =  " & QVal(JunHarga2) & " 
                                    ,[JunHarga3] =  " & QVal(JunHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN JunHarga1!=0 and JunHarga2=0  and JunHarga3=0 THEN JunHarga1  
	                                        WHEN JunHarga1!=0 and JunHarga2!=0 and JunHarga3=0 THEN JunHarga2  
	                                        WHEN JunHarga1!=0 and JunHarga2!=0 and JunHarga3!=0 THEN JunHarga3  
	                                        WHEN JunHarga1=0  and JunHarga2!=0 and JunHarga3=0 THEN JunHarga2  
	                                        WHEN JunHarga1=0 and JunHarga2=0  and JunHarga3!=0 THEN JunHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [JulHarga1] =  " & QVal(Harga) & "
                                    ,[AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[JunQty1] = " & QVal(JunQty1) & "
                                    ,[JunQty2] = " & QVal(JunQty2) & "
                                    ,[JunQty3] = " & QVal(JunQty3) & "
                                    ,[Jun PO1] =  " & QVal(Jun_PO1) & "
                                    ,[Jun PO2] =  " & QVal(Jun_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========JULI===============
            ElseIf Bulan.ToLower = "juli" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [JulHarga1] =  " & QVal(JulHarga1) & " 
                                    ,[JulHarga2] =  " & QVal(JulHarga2) & " 
                                    ,[JulHarga3] =  " & QVal(JulHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN JulHarga1!=0 and JulHarga2=0  and JulHarga3=0 THEN JulHarga1  
	                                        WHEN JulHarga1!=0 and JulHarga2!=0 and JulHarga3=0 THEN JulHarga2  
	                                        WHEN JulHarga1!=0 and JulHarga2!=0 and JulHarga3!=0 THEN JulHarga3  
	                                        WHEN JulHarga1=0  and JulHarga2!=0 and JulHarga3=0 THEN JulHarga2  
	                                        WHEN JulHarga1=0 and JulHarga2=0  and JulHarga3!=0 THEN JulHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [AgtHarga1] =  " & QVal(Harga) & "
                                    ,[SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[JulQty1] = " & QVal(JulQty1) & "
                                    ,[JulQty2] = " & QVal(JulQty2) & "
                                    ,[JulQty3] = " & QVal(JulQty3) & "
                                    ,[Jul PO1] =  " & QVal(Jul_PO1) & "
                                    ,[Jul PO2] =  " & QVal(Jul_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========AGUSTUS===============
            ElseIf Bulan.ToLower = "agustus" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [AgtHarga1] =  " & QVal(AgtHarga1) & " 
                                    ,[AgtHarga2] =  " & QVal(AgtHarga2) & " 
                                    ,[AgtHarga3] =  " & QVal(AgtHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN AgtHarga1!=0 and AgtHarga2=0  and AgtHarga3=0 THEN AgtHarga1  
	                                        WHEN AgtHarga1!=0 and AgtHarga2!=0 and AgtHarga3=0 THEN AgtHarga2  
	                                        WHEN AgtHarga1!=0 and AgtHarga2!=0 and AgtHarga3!=0 THEN AgtHarga3  
	                                        WHEN AgtHarga1=0  and AgtHarga2!=0 and AgtHarga3=0 THEN AgtHarga2  
	                                        WHEN AgtHarga1=0 and AgtHarga2=0  and AgtHarga3!=0 THEN AgtHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [SepHarga1] =  " & QVal(Harga) & "
                                    ,[OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[AgtQty1] = " & QVal(AgtQty1) & "
                                    ,[AgtQty2] = " & QVal(AgtQty2) & "
                                    ,[AgtQty3] = " & QVal(AgtQty3) & "
                                    ,[Agt PO1] =  " & QVal(Agt_PO1) & "
                                    ,[Agt PO2] =  " & QVal(Agt_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========SEPTEMBER===============
            ElseIf Bulan.ToLower = "september" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [SepHarga1] =  " & QVal(SepHarga1) & " 
                                    ,[SepHarga2] =  " & QVal(SepHarga2) & " 
                                    ,[SepHarga3] =  " & QVal(SepHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN SepHarga1!=0 and SepHarga2=0  and SepHarga3=0 THEN SepHarga1  
	                                        WHEN SepHarga1!=0 and SepHarga2!=0 and SepHarga3=0 THEN SepHarga2  
	                                        WHEN SepHarga1!=0 and SepHarga2!=0 and SepHarga3!=0 THEN SepHarga3  
	                                        WHEN SepHarga1=0  and SepHarga2!=0 and SepHarga3=0 THEN SepHarga2  
	                                        WHEN SepHarga1=0 and SepHarga2=0  and SepHarga3!=0 THEN SepHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [OktHarga1] =  " & QVal(Harga) & "
                                    ,[NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[SepQty1] = " & QVal(SepQty1) & "
                                    ,[SepQty2] = " & QVal(SepQty2) & "
                                    ,[SepQty3] = " & QVal(SepQty3) & "
                                    ,[Sep PO1] =  " & QVal(Sep_PO1) & "
                                    ,[Sep PO2] =  " & QVal(Sep_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========OKTOBER===============
            ElseIf Bulan.ToLower = "oktober" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [OktHarga1] =  " & QVal(OktHarga1) & " 
                                    ,[OktHarga2] =  " & QVal(OktHarga2) & " 
                                    ,[OktHarga3] =  " & QVal(OktHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN OktHarga1!=0 and OktHarga2=0  and OktHarga3=0 THEN OktHarga1  
	                                        WHEN OktHarga1!=0 and OktHarga2!=0 and OktHarga3=0 THEN OktHarga2  
	                                        WHEN OktHarga1!=0 and OktHarga2!=0 and OktHarga3!=0 THEN OktHarga3  
	                                        WHEN OktHarga1=0  and OktHarga2!=0 and OktHarga3=0 THEN OktHarga2  
	                                        WHEN OktHarga1=0 and OktHarga2=0  and OktHarga3!=0 THEN OktHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [NovHarga1] =  " & QVal(Harga) & "
                                    ,[DesHarga1] =  " & QVal(Harga) & "
                                    ,[OktQty1] = " & QVal(OktQty1) & "
                                    ,[OktQty2] = " & QVal(OktQty2) & "
                                    ,[OktQty3] = " & QVal(OktQty3) & "
                                    ,[Okt PO1] =  " & QVal(Okt_PO1) & "
                                    ,[Okt PO2] =  " & QVal(Okt_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                '===========NOVEMBER===============
            ElseIf Bulan.ToLower = "november" Then

                Dim query2 As String =
                    "UPDATE [tForecastPrice] SET [NovHarga1] =  " & QVal(NovHarga1) & " 
                                    ,[NovHarga2] =  " & QVal(NovHarga2) & " 
                                    ,[NovHarga3] =  " & QVal(NovHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query2)

                sql =
                    "SELECT
                                    Harga_Apr =
	                                CASE 
	                                        WHEN NovHarga1!=0 and NovHarga2=0  and NovHarga3=0 THEN NovHarga1  
	                                        WHEN NovHarga1!=0 and NovHarga2!=0 and NovHarga3=0 THEN NovHarga2  
	                                        WHEN NovHarga1!=0 and NovHarga2!=0 and NovHarga3!=0 THEN NovHarga3  
	                                        WHEN NovHarga1=0  and NovHarga2!=0 and NovHarga3=0 THEN NovHarga2  
	                                        WHEN NovHarga1=0 and NovHarga2=0  and NovHarga3!=0 THEN NovHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [DesHarga1] =  " & QVal(Harga) & "
                                    ,[NovQty1] = " & QVal(NovQty1) & "
                                    ,[NovQty2] = " & QVal(NovQty2) & "
                                    ,[NovQty3] = " & QVal(NovQty3) & "
                                    ,[Nov PO1] =  " & QVal(Nov_PO1) & "
                                    ,[Nov PO2] =  " & QVal(Nov_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)


                '===========DESEMBER===============
            ElseIf Bulan.ToLower = "desember" Then

                Dim t As Integer = Convert.ToInt32(Tahun) + 1
                'Query = Sql1 & "   ,[DesQty1],[DesQty2],[DesQty3],[Des PO1],[Des PO2]
                '       ,[DesHarga1],[DesHarga2],[DesHarga3]
                '       ,[created_date]
                '       ,[created_by])
                ' VALUES
                '       (" & QVal(Tahun) & "," & QVal(CustID) & "," & QVal(Customer) & "," & QVal(InvtID) & "," & QVal(Description) & "
                '       ," & QVal(PartNo) & "," & QVal(Model) & "," & QVal(OePe) & "," & QVal(INSub) & "," & QVal(Site) & "
                '       ," & QVal(DesQty1) & "," & QVal(DesQty2) & "," & QVal(DesQty3) & "," & QVal(Des_PO1) & "," & QVal(Des_PO2) & "
                '       ," & QVal(DesHarga1) & "," & QVal(DesHarga2) & "," & QVal(DesHarga3) & "," & QVal(created_date) & "," & QVal(created_by) & " )"
                'ExecQuery(Query)
                Dim query3 As String =
                    "UPDATE [tForecastPrice] SET [DesHarga1] =  " & QVal(DesHarga1) & " 
                                    ,[DesHarga2] =  " & QVal(DesHarga2) & " 
                                    ,[DesHarga3] =  " & QVal(DesHarga3) & " 
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(query3)

                sql =
                    "SELECT
                                    Harga_Des =
	                                CASE 
	                                        WHEN DesHarga1!=0 and DesHarga2=0  and DesHarga3=0 THEN DesHarga1  
	                                        WHEN DesHarga1!=0 and DesHarga2!=0 and DesHarga3=0 THEN DesHarga2  
	                                        WHEN DesHarga1!=0 and DesHarga2!=0 and DesHarga3!=0 THEN DesHarga3  
	                                        WHEN DesHarga1=0  and DesHarga2!=0 and DesHarga3=0 THEN DesHarga2  
	                                        WHEN DesHarga1=0 and DesHarga2=0  and DesHarga3!=0 THEN DesHarga3 
                                            ELSE 0 
	                                END
                                FROM tForecastPrice
                                WHERE
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                Dim dt As DataTable = New DataTable
                dt = MainModul.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    Harga = Double.Parse(dt.Rows(0)(0).ToString())
                End If

                Query1 =
                    "UPDATE [tForecastPrice] 
                                SET [JanHarga1] =  " & QVal(Harga) & "
                                WHERE 
                                    Tahun =  " & QVal(t.ToString()) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query1)

                Dim Query2 As String =
                    "UPDATE [tForecastPrice] 
                                SET [DesQty1] = " & QVal(DesQty1) & "
                                    ,[DesQty2] = " & QVal(DesQty2) & "
                                    ,[DesQty3] = " & QVal(DesQty3) & "
                                    ,[Des PO1] =  " & QVal(Des_PO1) & "
                                    ,[Des PO2] =  " & QVal(Des_PO2) & "
                                WHERE 
                                    Tahun =  " & QVal(Tahun) & " AND
                                    PartNo = " & QVal(PartNo) & " AND
                                    InvtID = " & QVal(InvtID) & " AND
                                    Flag = " & QVal(Flag) & " AND
                                    CustID = " & QVal(CustID) & ""
                ExecQuery(Query2)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataByBulanNew(Bulan As String, BulanAngka As String)
        Try
            Dim salesPrice As Double = 0
            salesPrice = getSalesPrice(BulanAngka, Tahun)

            Dim Sql As String = "tForecastPrice_updateHarga"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
            pParam(0) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(0).Value = Tahun
            pParam(1) = New SqlClient.SqlParameter("@columnName", SqlDbType.VarChar)
            pParam(1).Value = Bulan
            pParam(2) = New SqlClient.SqlParameter("@CustID", SqlDbType.VarChar)
            pParam(2).Value = CustID
            pParam(3) = New SqlClient.SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(3).Value = InvtID
            pParam(4) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(4).Value = PartNo
            pParam(5) = New SqlClient.SqlParameter("@salesPrice", SqlDbType.VarChar)
            pParam(5).Value = salesPrice

            'pParam(6) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            'pParam(6).Value = PartNo
            'pParam(7) = New SqlClient.SqlParameter("@Model", SqlDbType.VarChar)
            'pParam(7).Value = Model
            'pParam(8) = New SqlClient.SqlParameter("@Oe", SqlDbType.VarChar)
            'pParam(8).Value = OePe
            'pParam(9) = New SqlClient.SqlParameter("@IN", SqlDbType.VarChar)
            'pParam(9).Value = INSub
            'pParam(10) = New SqlClient.SqlParameter("@Site", SqlDbType.VarChar)
            'pParam(10).Value = Site
            'pParam(11) = New SqlClient.SqlParameter("@Flag", SqlDbType.VarChar)
            'pParam(11).Value = Flag
            'pParam(12) = New SqlClient.SqlParameter("@salesPrice", SqlDbType.Float)
            'pParam(12).Value = salesPrice
            'pParam(13) = New SqlClient.SqlParameter("@created_by", SqlDbType.VarChar)
            'pParam(13).Value = gh_Common.Username

            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub SinkronisasiHarga(Bulan As String, BulanAngka As String)
        Try
            Dim salesPrice As Double = 0
            salesPrice = getSalesPrice(BulanAngka, Tahun)

            Dim Sql As String = "tForecastPrice_SinkornisasiHarga"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
            pParam(0) = New SqlClient.SqlParameter("@Tahun", SqlDbType.VarChar)
            pParam(0).Value = Tahun
            pParam(1) = New SqlClient.SqlParameter("@columnName", SqlDbType.VarChar)
            pParam(1).Value = Bulan
            pParam(2) = New SqlClient.SqlParameter("@CustID", SqlDbType.VarChar)
            pParam(2).Value = CustID
            pParam(3) = New SqlClient.SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(3).Value = InvtID
            pParam(4) = New SqlClient.SqlParameter("@PartNo", SqlDbType.VarChar)
            pParam(4).Value = PartNo
            pParam(5) = New SqlClient.SqlParameter("@salesPrice", SqlDbType.Float)
            pParam(5).Value = salesPrice
            'pParam(6) = New SqlClient.SqlParameter("@created_by", SqlDbType.VarChar)
            'pParam(6).Value = gh_Common.Username

            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Dim Query As String = String.Empty
            Query = "UPDATE [tForecastPrice]
                    SET [Tahun] = " & QVal(Tahun) & "
                        ,[CustID] = " & QVal(CustID) & "
                        ,[Customer] = " & QVal(Customer) & "
                        ,[InvtID] = " & QVal(InvtID) & "
                        ,[Description] = " & QVal(Description) & "
                        ,[PartNo] = " & QVal(PartNo) & "
                        ,[Model] = " & QVal(Model) & "
                        ,[Oe/Pe] = " & QVal(OePe) & "
                        ,[IN/SUB] = " & QVal(INSub) & "
                        ,[Site] = " & QVal(Site) & "
                        ,[Flag] = " & QVal(Flag) & "
                        ,[JanQty1] = " & QVal(JanQty1) & "
                        ,[JanQty2] = " & QVal(JanQty2) & "
                        ,[JanQty3] = " & QVal(JanQty3) & "
                        ,[Jan PO1] = " & QVal(Jan_PO1) & "
                        ,[Jan PO2] = " & QVal(Jan_PO2) & "
                        ,[FebQty1] = " & QVal(FebQty1) & "
                        ,[FebQty2] = " & QVal(FebQty2) & "
                        ,[FebQty3] = " & QVal(FebQty3) & "
                        ,[Feb PO1] = " & QVal(Feb_PO1) & "
                        ,[Feb PO2] = " & QVal(Feb_PO2) & "
                        ,[MarQty1] = " & QVal(MarQty1) & "
                        ,[MarQty2] = " & QVal(MarQty2) & "
                        ,[MarQty3] = " & QVal(MarQty3) & "
                        ,[Mar PO1] = " & QVal(Mar_PO1) & "
                        ,[Mar PO2] = " & QVal(Mar_PO2) & "
                        ,[AprQty1] = " & QVal(AprQty1) & "
                        ,[AprQty2] = " & QVal(AprQty2) & "
                        ,[AprQty3] = " & QVal(AprQty3) & "
                        ,[Apr PO1] = " & QVal(Apr_PO1) & "
                        ,[Apr PO2] = " & QVal(Apr_PO2) & "
                        ,[MeiQty1] = " & QVal(MeiQty1) & "
                        ,[MeiQty2] = " & QVal(MeiQty2) & "
                        ,[MeiQty3] = " & QVal(MeiQty3) & "
                        ,[Mei PO1] = " & QVal(Mei_PO1) & "
                        ,[Mei PO2] = " & QVal(Mei_PO2) & "
                        ,[JunQty1] = " & QVal(JunQty1) & "
                        ,[JunQty2] = " & QVal(JunQty2) & "
                        ,[JunQty3] = " & QVal(JunQty3) & "
                        ,[Jun PO1] = " & QVal(Jun_PO1) & "
                        ,[Jun PO2] = " & QVal(Jun_PO2) & "
                        ,[JulQty1] = " & QVal(JulQty1) & "
                        ,[JulQty2] = " & QVal(JulQty2) & "
                        ,[JulQty3] = " & QVal(JulQty3) & "
                        ,[Jul PO1] = " & QVal(Jul_PO1) & "
                        ,[Jul PO2] = " & QVal(Jul_PO2) & "
                        ,[AgtQty1] = " & QVal(AgtQty1) & "
                        ,[AgtQty2] = " & QVal(AgtQty2) & "
                        ,[AgtQty3] = " & QVal(AgtQty3) & "
                        ,[Agt PO1] = " & QVal(Agt_PO1) & "
                        ,[Agt PO2] = " & QVal(Agt_PO2) & "
                        ,[SepQty1] = " & QVal(SepQty1) & "
                        ,[SepQty2] = " & QVal(SepQty2) & "
                        ,[SepQty3] = " & QVal(SepQty3) & "
                        ,[Sep PO1] = " & QVal(Sep_PO1) & "
                        ,[Sep PO2] = " & QVal(Sep_PO2) & "
                        ,[OktQty1] = " & QVal(OktQty1) & "
                        ,[OktQty2] = " & QVal(OktQty2) & "
                        ,[OktQty3] = " & QVal(OktQty3) & "
                        ,[Okt PO1] = " & QVal(Okt_PO1) & "
                        ,[Okt PO2] = " & QVal(Okt_PO2) & "
                        ,[NovQty1] = " & QVal(NovQty1) & "
                        ,[NovQty2] = " & QVal(NovQty2) & "
                        ,[NovQty3] = " & QVal(NovQty3) & "
                        ,[Nov PO1] = " & QVal(Nov_PO1) & "
                        ,[Nov PO2] = " & QVal(Nov_PO2) & "
                        ,[DesQty1] = " & QVal(DesQty1) & "
                        ,[DesQty2] = " & QVal(DesQty2) & "
                        ,[DesQty3] = " & QVal(DesQty3) & "
                        ,[Des PO1] = " & QVal(Des_PO1) & "
                        ,[Des PO2] = " & QVal(Des_PO2) & "
                        ,[JanHarga1] = " & QVal(JanHarga1) & "
                        ,[JanHarga2] = " & QVal(JanHarga2) & "
                        ,[JanHarga3] = " & QVal(JanHarga3) & "
                        ,[FebHarga1] = " & QVal(FebHarga1) & "
                        ,[FebHarga2] = " & QVal(FebHarga2) & "
                        ,[FebHarga3] = " & QVal(FebHarga3) & "
                        ,[MarHarga1] = " & QVal(MarHarga1) & "
                        ,[MarHarga2] = " & QVal(MarHarga2) & "
                        ,[MarHarga3] = " & QVal(MarHarga3) & "
                        ,[AprHarga1] = " & QVal(AprHarga1) & "
                        ,[AprHarga2] = " & QVal(AprHarga2) & "
                        ,[AprHarga3] = " & QVal(AprHarga3) & "
                        ,[MeiHarga1] = " & QVal(MeiHarga1) & "
                        ,[MeiHarga2] = " & QVal(MeiHarga2) & "
                        ,[MeiHarga3] = " & QVal(MeiHarga3) & "
                        ,[JunHarga1] = " & QVal(JunHarga1) & "
                        ,[JunHarga2] = " & QVal(JunHarga2) & "
                        ,[JunHarga3] = " & QVal(JunHarga3) & "
                        ,[JulHarga1] = " & QVal(JulHarga1) & "
                        ,[JulHarga2] = " & QVal(JulHarga2) & "
                        ,[JulHarga3] = " & QVal(JulHarga3) & "
                        ,[AgtHarga1] = " & QVal(AgtHarga1) & "
                        ,[AgtHarga2] = " & QVal(AgtHarga2) & "
                        ,[AgtHarga3] = " & QVal(AgtHarga3) & "
                        ,[SepHarga1] = " & QVal(SepHarga1) & "
                        ,[SepHarga2] = " & QVal(SepHarga2) & "
                        ,[SepHarga3] = " & QVal(SepHarga3) & "
                        ,[OktHarga1] = " & QVal(OktHarga1) & "
                        ,[OktHarga2] = " & QVal(OktHarga2) & "
                        ,[OktHarga3] = " & QVal(OktHarga3) & "
                        ,[NovHarga1] = " & QVal(NovHarga1) & "
                        ,[NovHarga2] = " & QVal(NovHarga2) & "
                        ,[NovHarga3] = " & QVal(NovHarga3) & "
                        ,[DesHarga1] = " & QVal(DesHarga1) & "
                        ,[DesHarga2] = " & QVal(DesHarga2) & "
                        ,[DesHarga3] = " & QVal(DesHarga3) & "
                        ,[update_date] = " & QVal(update_date) & "
                        ,[updated_by] = " & QVal(updated_by) & " 
                    WHERE Id = " & QVal(Id) & ""
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData1()
        Try
            Dim Query As String = String.Empty
            Query = "UPDATE [tForecastPrice]
                    SET [Tahun] = " & QVal(Tahun) & "
                        ,[CustID] = " & QVal(CustID) & "
                        ,[Customer] = " & QVal(Customer) & "
                        ,[InvtID] = " & QVal(InvtID) & "
                        ,[Description] = " & QVal(Description) & "
                        ,[PartNo] = " & QVal(PartNo) & "
                        ,[Model] = " & QVal(Model) & "
                        ,[Oe/Pe] = " & QVal(OePe) & "
                        ,[IN/SUB] = " & QVal(INSub) & "
                        ,[Site] = " & QVal(Site) & "
                        ,[Flag] = " & QVal(Flag) & "
                        ,[JanQty1] = " & QVal(JanQty1) & "
                        ,[JanQty2] = " & QVal(JanQty2) & "
                        ,[JanQty3] = " & QVal(JanQty3) & "
                        ,[Jan PO1] = " & QVal(Jan_PO1) & "
                        ,[Jan PO2] = " & QVal(Jan_PO2) & "
                        ,[FebQty1] = " & QVal(FebQty1) & "
                        ,[FebQty2] = " & QVal(FebQty2) & "
                        ,[FebQty3] = " & QVal(FebQty3) & "
                        ,[Feb PO1] = " & QVal(Feb_PO1) & "
                        ,[Feb PO2] = " & QVal(Feb_PO2) & "
                        ,[MarQty1] = " & QVal(MarQty1) & "
                        ,[MarQty2] = " & QVal(MarQty2) & "
                        ,[MarQty3] = " & QVal(MarQty3) & "
                        ,[Mar PO1] = " & QVal(Mar_PO1) & "
                        ,[Mar PO2] = " & QVal(Mar_PO2) & "
                        ,[AprQty1] = " & QVal(AprQty1) & "
                        ,[AprQty2] = " & QVal(AprQty2) & "
                        ,[AprQty3] = " & QVal(AprQty3) & "
                        ,[Apr PO1] = " & QVal(Apr_PO1) & "
                        ,[Apr PO2] = " & QVal(Apr_PO2) & "
                        ,[MeiQty1] = " & QVal(MeiQty1) & "
                        ,[MeiQty2] = " & QVal(MeiQty2) & "
                        ,[MeiQty3] = " & QVal(MeiQty3) & "
                        ,[Mei PO1] = " & QVal(Mei_PO1) & "
                        ,[Mei PO2] = " & QVal(Mei_PO2) & "
                        ,[JunQty1] = " & QVal(JunQty1) & "
                        ,[JunQty2] = " & QVal(JunQty2) & "
                        ,[JunQty3] = " & QVal(JunQty3) & "
                        ,[Jun PO1] = " & QVal(Jun_PO1) & "
                        ,[Jun PO2] = " & QVal(Jun_PO2) & "
                        ,[JulQty1] = " & QVal(JulQty1) & "
                        ,[JulQty2] = " & QVal(JulQty2) & "
                        ,[JulQty3] = " & QVal(JulQty3) & "
                        ,[Jul PO1] = " & QVal(Jul_PO1) & "
                        ,[Jul PO2] = " & QVal(Jul_PO2) & "
                        ,[AgtQty1] = " & QVal(AgtQty1) & "
                        ,[AgtQty2] = " & QVal(AgtQty2) & "
                        ,[AgtQty3] = " & QVal(AgtQty3) & "
                        ,[Agt PO1] = " & QVal(Agt_PO1) & "
                        ,[Agt PO2] = " & QVal(Agt_PO2) & "
                        ,[SepQty1] = " & QVal(SepQty1) & "
                        ,[SepQty2] = " & QVal(SepQty2) & "
                        ,[SepQty3] = " & QVal(SepQty3) & "
                        ,[Sep PO1] = " & QVal(Sep_PO1) & "
                        ,[Sep PO2] = " & QVal(Sep_PO2) & "
                        ,[OktQty1] = " & QVal(OktQty1) & "
                        ,[OktQty2] = " & QVal(OktQty2) & "
                        ,[OktQty3] = " & QVal(OktQty3) & "
                        ,[Okt PO1] = " & QVal(Okt_PO1) & "
                        ,[Okt PO2] = " & QVal(Okt_PO2) & "
                        ,[NovQty1] = " & QVal(NovQty1) & "
                        ,[NovQty2] = " & QVal(NovQty2) & "
                        ,[NovQty3] = " & QVal(NovQty3) & "
                        ,[Nov PO1] = " & QVal(Nov_PO1) & "
                        ,[Nov PO2] = " & QVal(Nov_PO2) & "
                        ,[DesQty1] = " & QVal(DesQty1) & "
                        ,[DesQty2] = " & QVal(DesQty2) & "
                        ,[DesQty3] = " & QVal(DesQty3) & "
                        ,[Des PO1] = " & QVal(Des_PO1) & "
                        ,[Des PO2] = " & QVal(Des_PO2) & "WHERE 
                Tahun =  " & QVal(Tahun) & " AND 
                PartNo = " & QVal(PartNo) & " AND 
                InvtID = " & QVal(InvtID) & " AND 
                Flag = " & QVal(Flag) & " AND 
                CustID = " & QVal(CustID) & ""
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateHarga()
        Try
            Dim Query As String = String.Empty
            Query = "UPDATE [tForecastPrice]
                    SET 
                        [JanHarga1] = " & QVal(JanHarga1) & "
                        ,[JanHarga2] = " & QVal(JanHarga2) & "
                        ,[JanHarga3] = " & QVal(JanHarga3) & "
                        ,[FebHarga1] = " & QVal(FebHarga1) & "
                        ,[FebHarga2] = " & QVal(FebHarga2) & "
                        ,[FebHarga3] = " & QVal(FebHarga3) & "
                        ,[MarHarga1] = " & QVal(MarHarga1) & "
                        ,[MarHarga2] = " & QVal(MarHarga2) & "
                        ,[MarHarga3] = " & QVal(MarHarga3) & "
                        ,[AprHarga1] = " & QVal(AprHarga1) & "
                        ,[AprHarga2] = " & QVal(AprHarga2) & "
                        ,[AprHarga3] = " & QVal(AprHarga3) & "
                        ,[MeiHarga1] = " & QVal(MeiHarga1) & "
                        ,[MeiHarga2] = " & QVal(MeiHarga2) & "
                        ,[MeiHarga3] = " & QVal(MeiHarga3) & "
                        ,[JunHarga1] = " & QVal(JunHarga1) & "
                        ,[JunHarga2] = " & QVal(JunHarga2) & "
                        ,[JunHarga3] = " & QVal(JunHarga3) & "
                        ,[JulHarga1] = " & QVal(JulHarga1) & "
                        ,[JulHarga2] = " & QVal(JulHarga2) & "
                        ,[JulHarga3] = " & QVal(JulHarga3) & "
                        ,[AgtHarga1] = " & QVal(AgtHarga1) & "
                        ,[AgtHarga2] = " & QVal(AgtHarga2) & "
                        ,[AgtHarga3] = " & QVal(AgtHarga3) & "
                        ,[SepHarga1] = " & QVal(SepHarga1) & "
                        ,[SepHarga2] = " & QVal(SepHarga2) & "
                        ,[SepHarga3] = " & QVal(SepHarga3) & "
                        ,[OktHarga1] = " & QVal(OktHarga1) & "
                        ,[OktHarga2] = " & QVal(OktHarga2) & "
                        ,[OktHarga3] = " & QVal(OktHarga3) & "
                        ,[NovHarga1] = " & QVal(NovHarga1) & "
                        ,[NovHarga2] = " & QVal(NovHarga2) & "
                        ,[NovHarga3] = " & QVal(NovHarga3) & "
                        ,[DesHarga1] = " & QVal(DesHarga1) & "
                        ,[DesHarga2] = " & QVal(DesHarga2) & "
                        ,[DesHarga3] = " & QVal(DesHarga3) & "
                        ,[update_date] = GETDATE()
                        ,[updated_by] = " & QVal(gh_Common.Username) & " 
                    WHERE Id = " & QVal(Id) & ""
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM tForecastPrice WHERE id = " & QVal(Id) & " "
            Dim li_Row = MainModul.ExecQuery(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ValidateUpdate() As Boolean
        Dim IsExist As Boolean = False
        'If Me._custid = "" OrElse Me._partno = "" OrElse Me._tahun = "" OrElse Me._invtid = "" Then
        '    IsExist = False
        '    'Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        'End If
        Try
            Dim ls_SP As String = "Select * from tForecastPrice where Tahun = " & QVal(Tahun) & " and InvtID= " & QVal(InvtID) & " and PartNo = " & QVal(PartNo) & " and CustID = " & QVal(CustID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                IsExist = True
            End If
        Catch ex As Exception
            IsExist = False
            Throw
        End Try
        Return IsExist
    End Function

    Public Function IsDataExist() As Boolean
        Dim hasil As Boolean = False
        Try
            Dim query As String =
                "SELECT InvtID FROM [tForecastPrice] WHERE 
                Tahun =  " & QVal(Tahun) & " AND 
                PartNo = " & QVal(PartNo) & " AND 
                InvtID = " & QVal(InvtID) & " AND 
                CustID = " & QVal(CustID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function IsDataADMExist() As Boolean
        Dim hasil As Boolean = False
        Try
            Dim query As String =
                "SELECT InvtID FROM [tForecastPrice] WHERE 
                Tahun =  " & QVal(Tahun) & " AND 
                PartNo = " & QVal(PartNo) & " AND 
                InvtID = " & QVal(InvtID) & " AND 
                Flag = " & QVal(Flag) & " AND 
                CustID = " & QVal(CustID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(query)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub ValidateInsert()
        If Tahun = "" OrElse PartNo = "" OrElse InvtID = "" OrElse CustID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 Tahun from tForecastPrice where Tahun = " & QVal(Tahun) & " and InvtID= " & QVal(InvtID) & " and PartNo = " & QVal(PartNo) & " and CustID = " & QVal(CustID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[ " & Me.InvtID & " ]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateUpdate1()
        If Tahun = "" OrElse PartNo = "" OrElse InvtID = "" OrElse CustID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 Tahun from tForecastPrice where Tahun = " & QVal(Tahun) & " and InvtID= " & QVal(InvtID) & " and PartNo = " & QVal(PartNo) & " and CustID = " & QVal(CustID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count = 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTidakKetemu) &
                "[ " & Me.InvtID & " ]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetHargaSAPKAP_ADM() As DataTable
        Try
            Dim sql As String = "tForecastPrice_get_adm_doubledata"

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(sql)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDoubleInvtID() As DataTable
        Try
            Dim sql As String = "Bom_GetDoubleInvtID"

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(sql)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetListInveortoryDetails(InvtID As String) As DataTable
        Try
            Dim sql As String = "tForecast_GetListInveortoryDetails"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(0).Value = InvtID
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
