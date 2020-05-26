<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuNew
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuNew))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem3 = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarItem4 = New DevExpress.XtraNavBar.NavBarItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmChangePass = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LblDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblLogin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGroup = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.tsmCollapse = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(501, 35)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(267, 386)
        Me.TreeView1.TabIndex = 0
        Me.TreeView1.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "iconfinder_Folder_858721.png")
        Me.ImageList1.Images.SetKeyName(1, "iconfinder_BT_folder_blanc_open_905566.png")
        Me.ImageList1.Images.SetKeyName(2, "iconfinder_check-circle-outline-blank_326565 (1).png")
        '
        'NavBarControl1
        '
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItem1, Me.NavBarItem2, Me.NavBarItem3, Me.NavBarItem4})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 28)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 277
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl1.Size = New System.Drawing.Size(277, 518)
        Me.NavBarControl1.TabIndex = 4
        Me.NavBarControl1.Text = "NavBarControl1"
        Me.NavBarControl1.View = New DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator()
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Caption = "NavBarItem1"
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Caption = "NavBarItem2"
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'NavBarItem3
        '
        Me.NavBarItem3.Caption = "NavBarItem3"
        Me.NavBarItem3.Name = "NavBarItem3"
        '
        'NavBarItem4
        '
        Me.NavBarItem4.Caption = "NavBarItem4"
        Me.NavBarItem4.Name = "NavBarItem4"
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.tsmCollapse})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip.Size = New System.Drawing.Size(804, 28)
        Me.MenuStrip.TabIndex = 8
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmLogin, Me.TsmChangePass, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(44, 24)
        Me.FileMenu.Text = "File"
        '
        'TsmLogin
        '
        Me.TsmLogin.Name = "TsmLogin"
        Me.TsmLogin.Size = New System.Drawing.Size(216, 26)
        Me.TsmLogin.Text = "Log In"
        '
        'TsmChangePass
        '
        Me.TsmChangePass.Name = "TsmChangePass"
        Me.TsmChangePass.Size = New System.Drawing.Size(216, 26)
        Me.TsmChangePass.Text = "Change Password"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(213, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblDatabase, Me.StatMsg, Me.LblRecords, Me.LblLogin, Me.lblGroup})
        Me.StatusStrip.Location = New System.Drawing.Point(277, 521)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 13, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(527, 25)
        Me.StatusStrip.TabIndex = 10
        Me.StatusStrip.Text = "StatusStrip"
        '
        'LblDatabase
        '
        Me.LblDatabase.Name = "LblDatabase"
        Me.LblDatabase.Size = New System.Drawing.Size(72, 20)
        Me.LblDatabase.Text = "Database"
        '
        'StatMsg
        '
        Me.StatMsg.Name = "StatMsg"
        Me.StatMsg.Size = New System.Drawing.Size(95, 20)
        Me.StatMsg.Spring = True
        Me.StatMsg.Text = "Status"
        Me.StatMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRecords
        '
        Me.LblRecords.Name = "LblRecords"
        Me.LblRecords.Size = New System.Drawing.Size(80, 20)
        Me.LblRecords.Text = "0 record(s)"
        '
        'LblLogin
        '
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(79, 20)
        Me.LblLogin.Text = "Login User"
        '
        'lblGroup
        '
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(83, 20)
        Me.lblGroup.Text = "User Group"
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Location = New System.Drawing.Point(277, 28)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(6, 493)
        Me.SplitterControl1.TabIndex = 11
        Me.SplitterControl1.TabStop = False
        '
        'tsmCollapse
        '
        Me.tsmCollapse.Name = "tsmCollapse"
        Me.tsmCollapse.Size = New System.Drawing.Size(78, 24)
        Me.tsmCollapse.Text = "Collapse"
        '
        'MenuNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 546)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MenuNew"
        Me.Text = "MenuNew"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileMenu As ToolStripMenuItem
    Friend WithEvents TsmLogin As ToolStripMenuItem
    Friend WithEvents TsmChangePass As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem3 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents LblDatabase As ToolStripStatusLabel
    Friend WithEvents StatMsg As ToolStripStatusLabel
    Friend WithEvents LblRecords As ToolStripStatusLabel
    Friend WithEvents LblLogin As ToolStripStatusLabel
    Friend WithEvents lblGroup As ToolStripStatusLabel
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents tsmCollapse As ToolStripMenuItem
End Class
