Imports System.Collections.ObjectModel
Public Class clsLokasiDetail
    Dim _Query As String
    Public Property ID() As String
    Public Property Deskripsi() As String
    Public Property IDLokasi() As String

    Public Sub New()
        Me._Query = "SELECT b.ID 
                    , b.[ID Lokasi Details] [ID Lokasi]
                    , b.Deskripsi
                    , a.[ID Lokasi] [Lokasi]
                    , b.[Created Date]
                    , b.[Created By]
                    FROM m_lokasi a inner join
                    m_lokasi_detail b ON a.[ID Lokasi] = b.[ID Lokasi]"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT 
                                    '' [ID Lokasi Details]
                                    ,'' [Deskripsi]                   
                                    FROM [m_lokasi_detail]
                                    UNION 
                                    SELECT 
                                    [ID Lokasi Details]
                                    ,[Deskripsi]                   
                                    FROM [m_lokasi_detail]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [ID Lokasi Details]
                                    ,[Deskripsi] 
                                    ,[ID Lokasi] 
                                    FROM [m_lokasi_detail] where [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID Lokasi Details") & "")
                    Me.Deskripsi = Trim(.Item("Deskripsi") & "")
                    Me.IDLokasi = Trim(.Item("ID Lokasi") & "")
                End With
            Else
                ID = ""
                Deskripsi = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.deskripsi = "" OrElse Me.ID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [ID Lokasi Details] ID
                                    ,[Deskripsi]                     
                                    FROM [m_lokasi_detail] where [ID Lokasi Details] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.ID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [m_lokasi_detail]
                                           ([ID Lokasi Details]
                                           ,[Deskripsi]
                                           ,[ID Lokasi] 
                                           ,[Created Date]
                                           ,[Created By])
                                     VALUES
                                           (" & QVal(ID) & " 
                                           ," & QVal(Deskripsi) & "
                                           ," & QVal(IDLokasi) & "
                                           ,GETDATE()
                                           ," & QVal(gh_Common.Username) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [m_lokasi_detail]
                                   SET [ID Lokasi Details] = " & QVal(Me.ID) & "
                                      ,[Deskripsi] = " & QVal(Deskripsi) & "
                                      ,[ID Lokasi] = " & QVal(IDLokasi) & "
                                      ,[Updated Date] = GETDATE()
                                      ,[Updated By] = " & QVal(gh_Common.Username) & "
                                    WHERE ID = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [m_lokasi_detail] WHERE ID =" & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

