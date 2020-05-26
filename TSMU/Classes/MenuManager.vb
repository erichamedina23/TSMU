Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Public Class MenuManager
    Public Sub New()
        Pages = New List(Of Page)()
    End Sub

    Public Property Pages As List(Of Page)

    Public Sub Add(ByVal mdl As IUserInterface)
        For Each mnu As MenuItem In mdl.GetUserInterface()
            Dim page As Page = Pages.FirstOrDefault(Function(c) c.Text.Equals(mnu.Page, StringComparison.CurrentCultureIgnoreCase))

            If page Is Nothing Then
                page = New Page With {
                        .Text = mnu.Page,
                        .Index = mnu.PageIndex
                    }
                Pages.Add(page)
            End If

            Dim group As Group = page.Groups.FirstOrDefault(Function(c) c.Text.Equals(mnu.Group, StringComparison.CurrentCultureIgnoreCase))

            If group Is Nothing Then
                group = New Group With {
                        .Text = mnu.Group,
                        .Index = mnu.GroupIndex
                    }
                page.Groups.Add(group)
            End If

            Dim ids As List(Of Integer) = New List(Of Integer)()

            If mnu.Items.Any() Then

                For Each menuItem As MenuItem In mnu.Items
                    ids.Add(menuItem.Key)
                Next
            End If

            Dim item As Item = New Item With {
                    .Text = mnu.Text,
                    .Index = mnu.Index,
                    .Image = mnu.Image,
                    .Type = mnu.Type,
                    .Icon = mnu.Icon,
                    .ActionType = mnu.ActionType,
                    .Url = mnu.Url,
                    .Dialog = mnu.Dialog,
                    .Duplicate = mnu.Duplicate,
                    .Popup = mnu.Popup,
                    .FormType = mnu.FormType
                }
            group.Items.Add(item)

            If mnu.Items.Count > 0 Then

                For Each menuItem As MenuItem In mnu.Items
                    Dim subItem As Item = New Item With {
                            .Text = menuItem.Text,
                            .Index = menuItem.Index,
                            .Image = menuItem.Image,
                            .Type = menuItem.Type,
                            .Icon = menuItem.Icon,
                            .ActionType = menuItem.ActionType,
                            .Url = menuItem.Url,
                            .Dialog = menuItem.Dialog,
                            .Duplicate = mnu.Duplicate,
                            .Popup = mnu.Popup,
                            .FormType = mnu.FormType
                        }
                    item.Items.Add(subItem)
                Next
            End If
        Next
    End Sub

    Public Sub RemomeEmpty()
        For i As Integer = 0 To Pages.Count - 1

            For j As Integer = 0 To Pages(i).Groups.Count - 1

                If Pages(i).Groups(j).Items.Count = 0 Then
                    Pages(i).Groups.RemoveAt(Math.Max(System.Threading.Interlocked.Decrement(j), j + 1))
                End If
            Next

            If Pages(i).Groups.Count = 0 Then
                Pages.RemoveAt(Math.Max(System.Threading.Interlocked.Decrement(i), i + 1))
            End If
        Next
    End Sub

    Public Function GetMenuFromFormType(ByVal type As Integer) As Item
        Return Pages.SelectMany(Function(c) c.Groups).SelectMany(Function(c) c.Items).FirstOrDefault(Function(c) c.FormType = type)
    End Function

    Public Function GetMenuFromFormType2(ByVal type As Integer) As Item
        Return Pages.SelectMany(Function(c) c.Groups).SelectMany(Function(c) c.Items).SelectMany(Function(c) c.Items).FirstOrDefault(Function(c) c.FormType = type)
    End Function

    Public Function GetTypeFromFormType(ByVal type As Integer) As String
        Dim item As Item = GetMenuFromFormType(type)

        If item IsNot Nothing Then
            Return item.Type
        End If

        Return Nothing
    End Function

    Public Function GetMenuItemFromFormType(ByVal type As Integer) As Item
        Dim item As Item = GetMenuFromFormType(type)

        If item IsNot Nothing Then
            Return item
        End If

        Return Nothing
    End Function
End Class

Public Class Page
    Public Sub New()
        Groups = New List(Of Group)()
    End Sub

    Public Property Text As String
    Public Property Index As Integer
    Public Property Groups As List(Of Group)
End Class

Public Class Group
    Public Sub New()
        Items = New List(Of Item)()
    End Sub

    Public Property Text As String
    Public Property Index As Integer
    Public Property Items As List(Of Item)
End Class

Public Class Item
    Public Sub New()
        Items = New List(Of Item)()
        Dialog = False
        Duplicate = False
        Popup = False
        FormType = 0
    End Sub

    Friend Property Text As String
    Friend Property Index As Integer
    Friend Property Type As String
    Friend Property Image As Image
    Friend Property Icon As Image
    Friend Property ActionType As Integer
    Friend Property FormType As Integer
    Friend Property Items As List(Of Item)
    Friend Property Url As String
    Public Property Dialog As Boolean
    Public Property Popup As Boolean
    Public Property Duplicate As Boolean
End Class
