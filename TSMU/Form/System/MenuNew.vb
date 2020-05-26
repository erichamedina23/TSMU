Imports System.Data.SqlClient
Imports System.Reflection
Imports DevExpress.XtraNavBar

Public Class MenuNew
    Dim fs_AssProduct As String
    Private Sub MenuNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fs_AssProduct = My.Application.Info.AssemblyName

        LblLogin.Text = ""
        lblGroup.Text = ""
        'LblPeriod.Text = ""
        LblDatabase.Text = ""
        StatMsg.Text = " Shortcut : F1 - View Detail"

        fs_AssProduct = My.Application.Info.AssemblyName

        Dim separatorFormat As New System.Globalization.NumberFormatInfo()
        If System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "," Then
            'Dim frmInformationBox As New InformationBox()
            'frmInformationBox.Captions("Comma Decimal Separator Format", "Volts currently supports and displays a dot(.) as a decimal separator.", "Information", "Okay")
            'frmInformationBox.ShowDialog()
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            separatorFormat.NumberDecimalSeparator = "."
        End If

        TreeView1.Nodes.Clear()

        Call gf_GetDatabaseVariables()
        Call ListAppForms()

        FileMenu.Enabled = True
        TsmLogin.Enabled = True

        With TreeView1
            .Dock = DockStyle.Top
        End With
        NavBarControl1.Controls.Add(TreeView1)
        If gs_TerminalUsername <> "" AndAlso gs_TerminalPassword <> "" AndAlso gs_AutomaticForm <> "" Then
            FrmLogin.UsernameTextBox.Text = gs_TerminalUsername
            FrmLogin.PasswordTextBox.Text = gs_TerminalPassword
            Call FrmLogin.OK_Click(Me, New System.EventArgs)

            If gs_Error <> "" Then
                Exit Sub
            End If

            LblDatabase.Text = "Database : " & gs_Database & " (" & gs_DBServer & ")"
            TsmChangePass.Enabled = False

            Dim openForm As Form = Nothing
            openForm = MyAss.CreateInstance(fs_AssProduct & "." & gs_AutomaticForm)
            openForm.ShowDialog()
        Else
            FrmLogin.ShowDialog()
        End If
        'loadmenuNavbar()

    End Sub
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


    Private Sub PopulateTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)


        For Each row As DataRow In dtParent.Rows
            Dim child As New TreeNode() With {
             .Text = row("Name").ToString(),
             .Tag = row("Id"),
             .Name = IIf(IsDBNull(row("Form")), "", row("Form"))
            }
            If parentId = 0 Then
                TreeView1.Nodes.Add(child)
                Dim dtChild As DataTable = GetDataTable("SELECT Id, Name, Form, Image FROM MenuLevel WHERE ParentNodeId = '" & child.Tag & "' And Active =1 Order by Name")
                PopulateTreeView(dtChild, Convert.ToInt32(child.Tag), child)
            Else
                treeNode.Nodes.Add(child)
                'AddHandler TreeView1.AfterSelect, AddressOf katadaMenu
            End If
        Next

    End Sub

    Public Sub loadmenuNavbar()
        Try

            Dim tbMenu As DataTable = GetDataTable("Select Name, Id From MenuLevel where id
                                                    in(
                                                    SELECT 
	                                                    su.ParentNodeId 
                                                    FROM 
	                                                    MenuLevel su 
	                                                    left JOIN S_UserPermission sup 
		                                                    ON su.Form = sup.MenuCode 
                                                    WHERE 
	                                                    ( 
		                                                    (sup.UserName = 'Nandang' AND COALESCE(sup.Access, '0') = '1') 
	                                                    ) 
	                                                    AND su.ParentNodeId <> ''
	                                                    AND su.Active = '1' ) Order by Name ")
            For i As Integer = 0 To tbMenu.Rows.Count - 1
                Dim str As String = tbMenu.Rows(i)("Name").ToString
                Dim grup As NavBarGroup = New NavBarGroup(str)
                grup.Name = str
                grup.Caption = str
                grup.Tag = tbMenu.Rows(i)("Id").ToString
                With NavBarControl1
                    .BeginUpdate()
                    .Groups.Add(grup)
                    .EndUpdate()
                    ' .LargeImages = ImageList2
                End With
            Next i
            TreeView1.Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub katadaMenu(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MenuItem As Object = sender
        Dim openForm As Form = Nothing
        Try
            For Each iForm As System.Windows.Forms.Form In My.Application.OpenForms
                If iForm.Name = MenuItem.Name Then
                    My.Application.OpenForms(iForm.Name).Focus()
                    Exit Sub
                End If
            Next
            openForm = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & MenuItem.Name)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If openForm IsNot Nothing Then

            'openForm.MdiParent = Me
            openForm.WindowState = FormWindowState.Maximized
            'openForm.StartPosition = FormStartPosition.WindowsDefaultBounds
            openForm.Show()

        End If
    End Sub

    'Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
    '    If e.Node.Name <> "" Then
    '        Dim frm As Form = DirectCast(MyAss.CreateInstance(e.Node.Name), Form)

    '    End If
    'End Sub
    'Dim openForm As Form
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim openForm As Form = Nothing

        If e.Node.Name <> "" Then
            Try
                For Each iForm As System.Windows.Forms.Form In My.Application.OpenForms
                    If iForm.Name = e.Node.Name Then
                        My.Application.OpenForms(iForm.Name).Focus()
                        Exit Sub
                    End If
                Next
                openForm = MyAss.CreateInstance(fs_AssProduct & "." & e.Node.Name)
            Catch ex As Exception

            End Try

            If openForm IsNot Nothing Then
                Try
                    Call CheckDBConnection()
                    If gs_Error = "" Then
                        Dim query As String = "SELECT COALESCE(FullScreen,0) AS [FlagFullScreen] FROM MenuLevel WHERE Form = '" & openForm.Name & "'"
                        Dim dtTable As DataTable = MainModul.GetDataTable(query)
                        If dtTable.Rows(0).Item("FlagFullScreen") = "1" Then
                            openForm.StartPosition = FormStartPosition.CenterScreen
                            openForm.ShowDialog()
                        Else
                            openForm.MdiParent = Me
                            openForm.WindowState = FormWindowState.Normal
                            'openForm.StartPosition = FormStartPosition.WindowsDefaultBounds
                            openForm.Show()
                        End If
                    Else
                        ShowMessage("Lost Connection to Database, Please re-Connect and Restart Application", MessageTypeEnum.ErrorMessage)
                    End If
                Catch ex As Exception
                    ShowMessage("", MessageTypeEnum.NotBoxMessage)
                End Try
                'Dim frm As Form = DirectCast(MyAss.CreateInstance(e.Node.Name), Form)
                'openForm = MyAss.CreateInstance(fs_AssProduct & "." & e.Node.Name)

            End If
        End If
    End Sub

    Private Sub NavBarControl1_ActiveGroupChanged(sender As Object, e As NavBarGroupEventArgs) Handles NavBarControl1.ActiveGroupChanged
        Try
            TreeView1.Nodes.Clear()
            Dim sql As String
            sql = "SELECT " & vbCrLf &
                "	su.Id " & vbCrLf &
                "	, su.Name " & vbCrLf &
                "	, su.Form " & vbCrLf &
                "	, sup.Access " & vbCrLf &
                "FROM " & vbCrLf &
                "	MenuLevel su " & vbCrLf &
                "	LEFT JOIN S_UserPermission sup " & vbCrLf &
                "		ON su.Form = sup.MenuCode " & vbCrLf &
                "WHERE " & vbCrLf &
                "	( " & vbCrLf &
                "		(sup.UserName = " & QVal(gh_Common.Username) & " AND COALESCE(sup.Access, '0') = '1') " & vbCrLf &
                "	) " & vbCrLf &
                "	AND COALESCE(su.ParentNodeId, '') <> '' " & vbCrLf &
                "	AND su.Active = '1' " & vbCrLf &
                "	AND su.ParentNodeId = '" & e.Group.Tag & "' " & vbCrLf &
                "ORDER BY " & vbCrLf &
                "	su.Name ASC "
            'MsgBox(e.Group.Tag)
            'Dim dt As DataTable = GetDataTable("SELECT Id, Name, Form, Image FROM MenuLevel WHERE ParentNodeId = '" & e.Group.Tag & "' And Active = 1 Order by Name")
            Dim dt As DataTable = GetDataTable(sql)
            Me.PopulateTreeView(dt, 0, Nothing)
            If TreeView1.Nodes IsNot Nothing Then
                TreeView1.ExpandAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMenuNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Exit Application ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit ?") = MsgBoxResult.Yes Then
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub TsmLogin_Click(sender As Object, e As EventArgs) Handles TsmLogin.Click
        If TsmLogin.Text = "Log In" Then
        ElseIf TsmLogin.Text = "Log Out" Then
            TsmLogin.Text = "Log In"
            '# Close opened forms...
            For iCount As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                If Application.OpenForms(iCount).IsMdiChild Then
                    Application.OpenForms(iCount).Dispose()
                End If
            Next

            NavBarControl1.Groups.Clear()
            TreeView1.Nodes.Clear()
        End If
        FrmLogin.ShowDialog()
    End Sub

    Private Sub TsmChangePass_Click(sender As Object, e As EventArgs) Handles TsmChangePass.Click
        FrmSystem_ChangePassword.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Global.Microsoft.VisualBasic.Interaction.MsgBox("Exit Application ?", Global.Microsoft.VisualBasic.MsgBoxStyle.Question + Global.Microsoft.VisualBasic.MsgBoxStyle.YesNo, "Exit ?") = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            End
        End If
    End Sub

    Private Sub tsmCollapse_Click(sender As Object, e As EventArgs) Handles tsmCollapse.Click
        If tsmCollapse.Text = "Collapse" Then
            tsmCollapse.Text = "Expand"
            NavBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Collapsed
        Else
            tsmCollapse.Text = "Collapse"
            NavBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Expanded
        End If
    End Sub
End Class