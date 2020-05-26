Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Reflection

Public Class Page1Interface
    Implements IUserInterface

    Private Function GetUserInterface() As IEnumerable(Of MenuItem) Implements IUserInterface.GetUserInterface

        Dim sql As String = "GetMenuByUser"
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@userName", SqlDbType.VarChar)
        param(0).Value = gh_Common.Username
        Dim dt As New DataTable
        dt = GetDataTableByCommand_SP(sql, param)
        Dim menus As List(Of MenuItem) = New List(Of MenuItem)()
        For Each row As DataRow In dt.Rows
            Dim openFormH As Form = Nothing
            Dim openFormD As Form = Nothing

            'openFormH = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & row("MenuCode"))
            menus.Add(New MenuItem With {
                .Page = row("ParentMenu"),
                .PageIndex = 0,
                .Group = If(IsDBNull(row("ParentMenuChild")), row("ParentMenu"), row("ParentMenuChild")),
                .GroupIndex = 0,
                .Text = row("Title"),
                .Index = row("GroupIndex"),
                .Image = If(IsDBNull(row("Image")), My.Resources.Square, My.Resources.ResourceManager.GetObject(row("Image"))),
                .Icon = My.Resources.map,
                .Type = If(row("MenuCode") = "NotForm", "", row("MenuCode")),' GetType(), 'Type.GetType(row("MenuCode"), True, True),
                .Key = 1016,
                .Dialog = row("FlagFullScreen"),
                .Items = GetNamaForm(Convert.ToInt32(row("Id")), Convert.ToInt32(row("Level"))),
                .FormType = row("Level")
            })

            '    If IsDBNull(row("ParentMenuChild")) Then
            '        menus.Add(New MenuItem With {
            '        .Page = row("ParentMenu"),
            '        .PageIndex = 0,
            '        .Group = If(IsDBNull(row("ParentMenuChild")), row("ParentMenu"), row("ParentMenuChild")),
            '        .GroupIndex = 0,
            '        .Text = row("Title"),
            '        .Index = row("GroupIndex"),
            '        .Image = If(IsDBNull(row("Image")), My.Resources.map, My.Resources.ResourceManager.GetObject(row("Image"))),
            '        .Icon = My.Resources.map,
            '        .Type = row("MenuCode"),
            '        .Key = 1016
            '    })
            '    Else
            '        menus.Add(New MenuItem With {
            '        .Page = row("ParentMenu"),
            '        .PageIndex = 0,
            '        .Group = If(IsDBNull(row("ParentMenuChild")), row("ParentMenu"), row("ParentMenuChild")),
            '        .GroupIndex = 0,
            '        .Text = row("Title"),
            '        .Index = row("GroupIndex"),
            '        .Image = If(IsDBNull(row("Image")), My.Resources.map, My.Resources.ResourceManager.GetObject(row("Image"))),
            '        .Icon = My.Resources.map,
            '        .Key = 1016,
            '        .Items = GetNamaForm(row("ParentMenu"))
            '    })
            '    End If

        Next
        Return menus
    End Function

    Public Function GetNamaForm(ByVal NodeId As Integer, ByVal Level As Integer) As List(Of MenuItem)
        Dim List As List(Of MenuItem) = New List(Of MenuItem)
        Try
            If Level = 1 Then
                Dim sql As String = "GetMenuLevel"
                Dim param() As SqlParameter = New SqlParameter(0) {}
                param(0) = New SqlParameter("@parentNode", SqlDbType.Int)
                param(0).Value = NodeId
                'param(1) = New SqlParameter("@childMenu", SqlDbType.VarChar)
                'param(1).Value = ChildMenu
                Dim dt As New DataTable
                dt = GetDataTableByCommand_SP(sql, param)
                For Each row In dt.Rows
                    List.Add(New MenuItem With {
                        .Text = row("Title"),
                        .Index = row("GroupIndex"),
                        .Image = If(IsDBNull(row("Image")), My.Resources.Square, My.Resources.ResourceManager.GetObject(row("Image"))),
                        .Icon = My.Resources.map,
                        .Type = row("MenuCode"),
                        .Key = 1012
                    })
                Next
            End If

        Catch ex As Exception
            Throw
        End Try
        Return List
    End Function
End Class
