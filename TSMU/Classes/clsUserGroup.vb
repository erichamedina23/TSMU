Imports System.Collections.ObjectModel
Public Class clsUserGroup
    Public Property UserGroupCode() As String
    Public Property UserGroupName() As String

    Public Property FlagActive() As Integer
   

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String =
                "SELECT TOP 1000 [UserGroupCode] [Group Name] 
                ,   [UserGroupName] [Group Name]  
                ,   [FlagActive] [Status] 
                FROM [I_AccessLevel]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select bomid as [BoM ID],invtid as [Inventory ID], descr as Description, siteid as Site " &
                "from bomh order by bomid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from bomh where bomid = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.UserGroupCode = Trim(.Item("bomid") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Dim _rev As Integer = 0
    Public Function getRevisi(ByVal bomid As String) As Integer
        Try
            Dim query As String = "" & vbCrLf &
                                  "SELECT ISNULL(revisi,0) revisi " & vbCrLf &
                                  "FROM bom_header_history where bomid=" & QVal(bomid) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(query)
            If dt.Rows.Count > 0 Then
                _rev = Convert.ToInt32(dt.Rows(0)(0))
            End If
        Catch ex As Exception
            Throw
        End Try
        Return _rev
    End Function
    Public Function getRoutingBoM(ByVal invtId As String)
        Try
            Dim query As String = "select * from fn_GetMultiLevelBOM('" & invtId & "') " &
                "union " &
                "select '' as FinishedGood,'' as parentid,b.invtid,'1' as qty, '0' as Extendedqty, b.descr, b.stkunit, a.bomid from bomh a inner join Inventory b on a.invtid=b.InvtID where b.invtid = '" & invtId & "'"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getDetailBoM(ByVal BoMID As String) As DataTable
        Try
            Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,2)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.bomid = '" & BoMID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByInvt(ByVal ID As String)
        Try
            Dim query As String = "select * from bomh where invtID = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.UserGroupCode = Trim(.Item("bomid") & "")
                End With
            Else
                UserGroupCode = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function getDetailBoM_Part(ByVal invtid As String) As DataTable
        Try
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,2)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.parentid = '" & BoMID & "'"
            Dim query As String = "SELECT descr, qty, unit from bom where invtid = '" & invtid & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getDetailBoM_Part_n(ByVal invtid As String) As DataTable
        Try
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,2)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.parentid = '" & BoMID & "'"
            Dim query As String = "SELECT Invtid as [Invetory ID],descr as Description, qty Qty, unit Unit from bom where parentid = '" & invtid & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function AutoNoBoMID() As DataTable
        Try
            Dim query As String = "select MAX(SUBSTRING(bomid,1,7))+1 AS bomid from bomh"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getInvtItem() As DataTable
        Try
            Dim query As String = "select InvtID as [Invetory ID], Descr as Description, StkUnit as Unit from Inventory where TranStatusCode='AC'  order by Descr"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getInvtItem_project() As DataTable
        Try
            Dim query As String = "select InvtID as [Invetory ID], Descr as Description, StkUnit as Unit from Inventory_lc where TranStatusCode='AC'  order by Descr"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "CRUD"
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeader(ByVal rev As Int32)
        Try
            Dim ls_SP As String = ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeader(ByVal bomid As String)
        Try
            Dim ls_SP As String = "Delete from bomh where bomid =" & QVal(bomid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

