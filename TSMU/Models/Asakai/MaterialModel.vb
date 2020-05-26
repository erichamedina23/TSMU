Imports System.Collections.ObjectModel
Public Class MaterialModel

    Dim _Query As String
    Public Property IDMaterial() As String
    Public Property IDJenis() As String
    Public Property Jenis() As String
    Public Property Description() As String
    Public Property Harga() As Double

    Public Sub New()
        Me._Query = "SELECT A.IDMaterial,A.Description,B.Description[Jenis],A.Harga FROM AsakaiMaterial A Inner Join AsakaiJenis B On A.IdJenis =B.IdJenis"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT AsakaiMaterial.IDMaterial
                                    ,AsakaiMaterial.Description
                                    ,AsakaiJenis.IDJenis
                                    ,AsakaiJenis.Description
                                    ,AsakaiMaterial.Harga
                                    FROM AsakaiMaterial Inner Join AsakaiJenis On AsakaiMaterial.IDJenis=AsakaiJenis.IDJenis WHERE AsakaiMaterial.IDMaterial = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDMaterial = Trim(.Item(0) & "")
                    Me.Description = Trim(.Item(1) & "")
                    Me.IDJenis = Trim(.Item(2) & "")
                    Me.Jenis = Trim(.Item(3) & "")
                    Me.Harga = Trim(.Item(4) & "")
                End With
            Else
                IDMaterial = ""
                IDJenis = ""
                Description = ""
                Jenis = ""
                Harga = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.IDMaterial = "" OrElse Me.Description = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDMaterial]
                                               ,[Description]                     
                                                FROM [AsakaiMaterial] where [IDMaterial] = " & QVal(IDMaterial) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.IDMaterial & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


#Region "CRUD"

    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [AsakaiMaterial]
                                           ([IDMaterial]
                                           ,[IDJenis]
                                           ,[Description]
                                           ,[Harga]
                                           ,[Createdby]
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(IDMaterial) & " 
                                           ," & QVal(IDJenis) & "
                                           ," & QVal(Description) & "
                                           ," & QVal(Harga) & "
                                           ," & QVal(gh_Common.Username) & "
                                           ,GETDATE())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [AsakaiMaterial]
                                   SET [Description] = " & QVal(Description) & "
                                      ,[IDJenis] = " & QVal(IDJenis) & "
                                      ,[Harga] = " & QVal(Harga) & "
                                      ,[UpdatedBy] = " & QVal(gh_Common.Username) & "
                                      ,[UpdatedDate] = GETDATE()
                                   WHERE IDMaterial = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [AsakaiMaterial] WHERE IDMaterial =" & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

End Class
