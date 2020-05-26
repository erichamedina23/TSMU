Imports System
Imports System.Drawing
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraTabbedMdi
Partial Public Class FrmMain
    Inherits RibbonForm

    Private _manager As MenuManager
    Dim fs_AssProduct As String = ""
    Dim HasLoad As Boolean = False

    Public Sub New()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2010 Blue" ' <<< NEW LINE 
        InitializeComponent()
    End Sub

    Public Sub LoadMenu()
        _manager = New MenuManager()
        '_manager.Add(New Page2Interface())
        _manager.Add(New Page1Interface())
        _manager.RemomeEmpty()

        For Each item As Page In _manager.Pages.OrderBy(Function(c) c.Index)
            Dim page As RibbonPage = New RibbonPage(item.Text)
            ribbon.DefaultPageCategory.Pages.Add(page)

            For Each group As Group In item.Groups.OrderBy(Function(c) c.Index)
                Dim ribbonPageGroup As RibbonPageGroup = New RibbonPageGroup(group.Text) With {
                    .ShowCaptionButton = True,
                    .AllowTextClipping = True,
                    .ItemsLayout = RibbonPageGroupItemsLayout.ThreeRows,
                    .Alignment = RibbonPageGroupAlignment.Near
                }
                page.Groups.Add(ribbonPageGroup)


                For Each mnuItem As Item In group.Items.OrderBy(Function(c) c.Index)
                    If mnuItem.FormType = 2 Then
                    Else
                        Dim barButtonItem As BarButtonItem = New BarButtonItem With {
                        .Caption = mnuItem.Text,
                        .Tag = mnuItem
                    }
                        barButtonItem.ItemAppearance.Disabled.Options.UseTextOptions = True
                        barButtonItem.ItemAppearance.Disabled.TextOptions.WordWrap = WordWrap.NoWrap
                        barButtonItem.ItemAppearance.Hovered.Options.UseTextOptions = True
                        barButtonItem.ItemAppearance.Hovered.TextOptions.WordWrap = WordWrap.NoWrap
                        barButtonItem.ItemAppearance.Normal.Options.UseTextOptions = True
                        barButtonItem.ItemAppearance.Normal.TextOptions.WordWrap = WordWrap.NoWrap
                        barButtonItem.ItemAppearance.Pressed.Options.UseTextOptions = True
                        barButtonItem.ItemAppearance.Pressed.TextOptions.WordWrap = WordWrap.NoWrap

                        If mnuItem.Items.Count = 0 Then
                            barButtonItem.RibbonStyle = RibbonItemStyles.SmallWithText
                            barButtonItem.Glyph = mnuItem.Image
                        Else
                            barButtonItem.ButtonStyle = BarButtonStyle.DropDown
                            barButtonItem.RibbonStyle = RibbonItemStyles.Large
                            barButtonItem.LargeGlyph = mnuItem.Image
                            barButtonItem.ActAsDropDown = True
                            Dim popup As PopupMenu = New PopupMenu(barManager1) With {
                                .Ribbon = ribbon
                            }

                            For Each child As Item In mnuItem.Items.OrderBy(Function(c) c.Index)

                                Dim childButton As BarButtonItem = New BarButtonItem With {
                                    .Caption = child.Text,
                                    .Tag = child,
                                    .Glyph = child.Image
                                }
                                popup.AddItem(childButton)
                                AddHandler childButton.ItemClick, AddressOf barButtonItem_ItemClick
                            Next

                            barButtonItem.DropDownControl = popup
                        End If

                        AddHandler barButtonItem.ItemClick, AddressOf barButtonItem_ItemClick
                        ribbonPageGroup.ItemLinks.Add(barButtonItem)
                    End If

                Next
            Next
        Next
    End Sub
    Dim MenuItem As Object = Nothing
    Private Sub barButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        Dim item As Item = Nothing
        MenuItem = sender
#Disable Warning BC40000 ' Type or member is obsolete
        If CSharpImpl.__Assign(item, TryCast(e?.Item?.Tag, Item)) IsNot Nothing Then
#Enable Warning BC40000 ' Type or member is obsolete

            If item.ActionType = ActionType.URL Then
                'Dim form As FormBrowser = New FormBrowser With {
                '    .Text = item.Text,
                '    .Url = item.Url,
                '    .Tag = item,
                '    .MdiParent = Me
                '}
                'Form.Show()
            Else
                AddForm(item.Type, item, True)
            End If
        End If
    End Sub

    Friend Function AddForm(ByVal form As String, ByVal item As Item, ByVal focus As Boolean) As Form
        If form <> "" Then
            If item.Duplicate Then
                Dim _form As Form = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & form)
                If _form IsNot Nothing Then
                    _form.Tag = item

                    If item.Popup = False Then
                        _form.MdiParent = Me
                    End If

                    'If item.FormType = FormTypes.FORM_CALLCENTER Then
                    '    _form.TopMost = True
                    '    _form.ShowIcon = False
                    '    _form.ShowInTaskbar = False
                    '    _form.FormBorderStyle = FormBorderStyle.None
                    '    _form.Location = New Point(Screen.PrimaryScreen.WorkingArea.Right - _form.Width, Screen.PrimaryScreen.WorkingArea.Bottom - _form.Height)
                    'End If

                    _form.Show()
                    Return _form
                End If
            ElseIf item.Dialog Then
                Dim _form As Form = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & form)
                If _form IsNot Nothing Then
                    _form.ShowDialog()
                End If
            Else
                For Each page As XtraMdiTabPage In xtraTabbedMdiManager1.Pages

                    If page.MdiChild.Name = form Then

                        If focus Then
                            xtraTabbedMdiManager1.SelectedPage = page
                        End If

                        Return page.MdiChild
                    End If
                Next

                Dim _form As Form = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & form)
                If _form IsNot Nothing Then
                    _form.Tag = item
                    _form.MdiParent = Me
                    _form.Show()
                    Return _form
                End If
            End If
        End If

        Return Nothing
    End Function

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ribbon.Minimized = True
        'Me.MaximizeBox = False
        'HasLoad = True
        LblLogin.Caption = ""
        lblGroup.Caption = "0 record(s)"
        LblRecords.Caption = ""
        LblDatabase.Caption = ""
        'StatMsg.Text = " Shortcut : F1 - View Detail"

        fs_AssProduct = My.Application.Info.AssemblyName

        Dim separatorFormat As New System.Globalization.NumberFormatInfo()
        If System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "," Then
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            separatorFormat.NumberDecimalSeparator = "."
        End If

        Call gf_GetDatabaseVariables()


        '# List forms...
        Call ListAppForms()

        ribbon.Enabled = True
        LoginBar.Enabled = True
        ChngePasBar.Enabled = False
        ExitBar.Enabled = True

        If gs_TerminalUsername <> "" AndAlso gs_TerminalPassword <> "" AndAlso gs_AutomaticForm <> "" Then
            FrmLogin.UsernameTextBox.Text = gs_TerminalUsername
            FrmLogin.PasswordTextBox.Text = gs_TerminalPassword
            Call FrmLogin.OK_Click(Me, New System.EventArgs)

            If gs_Error <> "" Then
                Exit Sub
            End If


            LblDatabase.Caption = "Database : " & gs_Database & " (" & gs_DBServer & ")"
            ChngePasBar.Enabled = False

            Dim _form As Form = Nothing
            _form = MyAss.CreateInstance(fs_AssProduct & "." & gs_AutomaticForm)
            _form.ShowDialog()
        Else
            FrmLogin.ShowDialog()
        End If
        'LoadMenu()

    End Sub

    Private Sub ribbon_Merge(ByVal sender As Object, ByVal e As RibbonMergeEventArgs)
        Dim page As RibbonPage = Nothing

        If e.MergedChild.PageCategories.Count > 0 Then

            If e.MergedChild.PageCategories(0).Pages.Count > 0 Then
                page = e.MergedChild.PageCategories(0).Pages(0)
            End If
        Else

            If e.MergedChild.DefaultPageCategory.Pages.Count > 0 Then
                page = e.MergedChild.DefaultPageCategory.Pages(0)
            End If
        End If

        If page IsNot Nothing Then
            ribbon.SelectedPage = page
        End If

        Dim parentRRibbon As RibbonControl = TryCast(sender, RibbonControl)
        Dim childRibbon As RibbonControl = e.MergedChild

        If childRibbon.StatusBar IsNot Nothing Then

            If parentRRibbon IsNot Nothing Then
                parentRRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar)
            End If
        End If
    End Sub

    Private Sub ribbon_UnMerge(ByVal sender As Object, ByVal e As RibbonMergeEventArgs)
        Dim parentRRibbon As RibbonControl = TryCast(sender, RibbonControl)

        If parentRRibbon IsNot Nothing Then
            parentRRibbon.StatusBar.UnMergeStatusBar()
        End If
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
    Private Sub ListAppForms()

        '# Load default forms...
        Dim frm As Form = Nothing
        Dim ObjType As Type = Nothing
        Try
            For Each MyType As Type In MyAss.GetTypes
                ObjType = MyType.BaseType
                Do While ObjType IsNot Nothing AndAlso ObjType.Name <> "Form"
                    ObjType = ObjType.BaseType
                Loop
                If ObjType IsNot Nothing AndAlso ObjType.Name = "Form" Then
                    If MyType.BaseType.Name.ToLower.Trim = "baseform" Then
                        Try
                            frm = MyAss.CreateInstance(MyType.FullName)
                        Catch ex As Exception
                            frm = Nothing
                        End Try
                        If frm IsNot Nothing Then
                            MyForms.Add(frm)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            If TypeOf ex Is System.Reflection.ReflectionTypeLoadException Then
                Dim typeLoadException = TryCast(ex, ReflectionTypeLoadException)
                Dim loaderExceptions = typeLoadException.LoaderExceptions
            End If
        End Try

        '# Additional forms...
        Try
            frm = MyAss.CreateInstance(fs_AssProduct & ".FrmTrans_Closing")
            If frm IsNot Nothing Then
                MyForms.Add(frm)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoginBar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoginBar.ItemClick
        If LoginBar.Caption = "Log In" Then
        ElseIf LoginBar.Caption = "Log Out" Then
            LoginBar.Caption = "Log In"
            '# Close opened forms...
            For iCount As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                If Application.OpenForms(iCount).IsMdiChild Then
                    Application.OpenForms(iCount).Dispose()
                End If
            Next

            For Each item As Page In _manager.Pages.OrderBy(Function(c) c.Index)
                'Dim page As RibbonPage = New RibbonPage(item.Text)
                ribbon.Pages.Remove(ribbon.Pages(item.Text))
                'RemoveRibbonPageWithBarItems(page, ribbon)
            Next
            '_manager = Nothing
        End If
        FrmLogin.ShowDialog()
    End Sub

    Private Sub ChngePasBar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ChngePasBar.ItemClick
        FrmSystem_ChangePassword.Show()
    End Sub

    Private Sub ExitBar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ExitBar.ItemClick

        If MsgBox("Exit Application ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit ?") = MsgBoxResult.Yes Then
            CloseALl()
            End
        End If
    End Sub
    Private Sub RemoveRibbonPageWithBarItems(ByVal ribbonPage As RibbonPage, ByVal ribbon As RibbonControl)
        Dim groups As RibbonPageGroupCollection = ribbonPage.Groups
        For Each group As RibbonPageGroup In groups
            Dim itemLinks As RibbonPageGroupItemLinkCollection = group.ItemLinks
            For i As Integer = 0 To itemLinks.Count - 1
                Dim item As BarItem = TryCast(itemLinks(i).Item, BarItem)
                ribbon.Items.Remove(item)
            Next i
        Next group
        ribbonPage.Groups.Clear()
        ribbon.Pages.Remove(ribbonPage)
    End Sub

    Private Sub CloseAllBar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CloseAllBar.ItemClick
        CloseALl()
    End Sub
    Private Sub CloseALl()
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
End Class
