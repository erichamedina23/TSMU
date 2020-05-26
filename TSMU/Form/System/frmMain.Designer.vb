Partial Class FrmMain
    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.barManager1 = New DevExpress.XtraBars.BarManager()
        Me.bar1 = New DevExpress.XtraBars.Bar()
        Me.bar2 = New DevExpress.XtraBars.Bar()
        Me.bar3 = New DevExpress.XtraBars.Bar()
        Me.LblDatabase = New DevExpress.XtraBars.BarStaticItem()
        Me.LblRecords = New DevExpress.XtraBars.BarStaticItem()
        Me.LblLogin = New DevExpress.XtraBars.BarStaticItem()
        Me.lblGroup = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.xtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.Filemenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.FileRibbon = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LoginBar = New DevExpress.XtraBars.BarButtonItem()
        Me.ChngePasBar = New DevExpress.XtraBars.BarButtonItem()
        Me.ExitBar = New DevExpress.XtraBars.BarButtonItem()
        Me.CloseAllBar = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SkinRibbonGalleryBarItem2 = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.SkinRibbonGalleryBarItem1 = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.ribbon = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ribbon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barManager1
        '
        Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.bar1, Me.bar2, Me.bar3})
        Me.barManager1.DockControls.Add(Me.barDockControlTop)
        Me.barManager1.DockControls.Add(Me.barDockControlBottom)
        Me.barManager1.DockControls.Add(Me.barDockControlLeft)
        Me.barManager1.DockControls.Add(Me.barDockControlRight)
        Me.barManager1.Form = Me
        Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.LblDatabase, Me.LblRecords, Me.LblLogin, Me.lblGroup})
        Me.barManager1.MainMenu = Me.bar2
        Me.barManager1.MaxItemId = 5
        Me.barManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.barManager1.StatusBar = Me.bar3
        '
        'bar1
        '
        Me.bar1.BarName = "Tools"
        Me.bar1.DockCol = 0
        Me.bar1.DockRow = 1
        Me.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.bar1.Text = "Tools"
        Me.bar1.Visible = False
        '
        'bar2
        '
        Me.bar2.BarName = "Main menu"
        Me.bar2.DockCol = 0
        Me.bar2.DockRow = 0
        Me.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.bar2.OptionsBar.MultiLine = True
        Me.bar2.OptionsBar.UseWholeRow = True
        Me.bar2.Text = "Main menu"
        Me.bar2.Visible = False
        '
        'bar3
        '
        Me.bar3.BarName = "Status bar"
        Me.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.bar3.DockCol = 0
        Me.bar3.DockRow = 0
        Me.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.LblDatabase), New DevExpress.XtraBars.LinkPersistInfo(Me.LblRecords), New DevExpress.XtraBars.LinkPersistInfo(Me.LblLogin), New DevExpress.XtraBars.LinkPersistInfo(Me.lblGroup)})
        Me.bar3.OptionsBar.AllowQuickCustomization = False
        Me.bar3.OptionsBar.DrawDragBorder = False
        Me.bar3.OptionsBar.UseWholeRow = True
        Me.bar3.Text = "Status bar"
        '
        'LblDatabase
        '
        Me.LblDatabase.Caption = "Database"
        Me.LblDatabase.Id = 1
        Me.LblDatabase.Name = "LblDatabase"
        '
        'LblRecords
        '
        Me.LblRecords.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.LblRecords.Caption = "0 record(s)"
        Me.LblRecords.Id = 2
        Me.LblRecords.Name = "LblRecords"
        '
        'LblLogin
        '
        Me.LblLogin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.LblLogin.Caption = "User Login"
        Me.LblLogin.Id = 3
        Me.LblLogin.Name = "LblLogin"
        '
        'lblGroup
        '
        Me.lblGroup.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.lblGroup.Caption = "User Group"
        Me.lblGroup.Id = 4
        Me.lblGroup.Name = "lblGroup"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barManager1
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.barDockControlTop.Size = New System.Drawing.Size(885, 51)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 412)
        Me.barDockControlBottom.Manager = Me.barManager1
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.barDockControlBottom.Size = New System.Drawing.Size(885, 31)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 51)
        Me.barDockControlLeft.Manager = Me.barManager1
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 361)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(885, 51)
        Me.barDockControlRight.Manager = Me.barManager1
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 361)
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'xtraTabbedMdiManager1
        '
        Me.xtraTabbedMdiManager1.MdiParent = Me
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "RibbonPage3"
        '
        'Filemenu
        '
        Me.Filemenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.FileRibbon, Me.RibbonPageGroup2})
        Me.Filemenu.Name = "Filemenu"
        Me.Filemenu.Text = "File"
        '
        'FileRibbon
        '
        Me.FileRibbon.ItemLinks.Add(Me.LoginBar)
        Me.FileRibbon.ItemLinks.Add(Me.ChngePasBar)
        Me.FileRibbon.ItemLinks.Add(Me.ExitBar)
        Me.FileRibbon.ItemLinks.Add(Me.CloseAllBar)
        Me.FileRibbon.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.ThreeRows
        Me.FileRibbon.Name = "FileRibbon"
        Me.FileRibbon.Text = "File"
        '
        'LoginBar
        '
        Me.LoginBar.Caption = "Login"
        Me.LoginBar.Id = 3
        Me.LoginBar.ImageOptions.Image = CType(resources.GetObject("LoginBar.ImageOptions.Image"), System.Drawing.Image)
        Me.LoginBar.ImageOptions.LargeImage = CType(resources.GetObject("LoginBar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LoginBar.Name = "LoginBar"
        Me.LoginBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'ChngePasBar
        '
        Me.ChngePasBar.Caption = "Change Password"
        Me.ChngePasBar.Id = 7
        Me.ChngePasBar.ImageOptions.Image = CType(resources.GetObject("ChngePasBar.ImageOptions.Image"), System.Drawing.Image)
        Me.ChngePasBar.ImageOptions.LargeImage = CType(resources.GetObject("ChngePasBar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ChngePasBar.Name = "ChngePasBar"
        Me.ChngePasBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'ExitBar
        '
        Me.ExitBar.Caption = "Exit"
        Me.ExitBar.Id = 4
        Me.ExitBar.ImageOptions.Image = CType(resources.GetObject("ExitBar.ImageOptions.Image"), System.Drawing.Image)
        Me.ExitBar.ImageOptions.LargeImage = CType(resources.GetObject("ExitBar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ExitBar.Name = "ExitBar"
        Me.ExitBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'CloseAllBar
        '
        Me.CloseAllBar.Caption = "Close All"
        Me.CloseAllBar.Id = 8
        Me.CloseAllBar.ImageOptions.Image = CType(resources.GetObject("CloseAllBar.ImageOptions.Image"), System.Drawing.Image)
        Me.CloseAllBar.ImageOptions.LargeImage = CType(resources.GetObject("CloseAllBar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.CloseAllBar.Name = "CloseAllBar"
        Me.CloseAllBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.SkinRibbonGalleryBarItem2)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Theme"
        '
        'SkinRibbonGalleryBarItem2
        '
        Me.SkinRibbonGalleryBarItem2.Caption = "SkinRibbonGalleryBarItem2"
        Me.SkinRibbonGalleryBarItem2.Id = 11
        Me.SkinRibbonGalleryBarItem2.Name = "SkinRibbonGalleryBarItem2"
        '
        'SkinRibbonGalleryBarItem1
        '
        Me.SkinRibbonGalleryBarItem1.Caption = "SkinRibbonGalleryBarItem1"
        Me.SkinRibbonGalleryBarItem1.Id = 5
        Me.SkinRibbonGalleryBarItem1.Name = "SkinRibbonGalleryBarItem1"
        '
        'ribbon
        '
        Me.ribbon.ExpandCollapseItem.Id = 0
        Me.ribbon.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbon.ExpandCollapseItem, Me.LoginBar, Me.ExitBar, Me.SkinRibbonGalleryBarItem1, Me.ChngePasBar, Me.CloseAllBar, Me.SkinRibbonGalleryBarItem2})
        Me.ribbon.Location = New System.Drawing.Point(0, 51)
        Me.ribbon.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ribbon.MaxItemId = 12
        Me.ribbon.Name = "ribbon"
        Me.ribbon.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.ribbon.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.Filemenu})
        Me.ribbon.Size = New System.Drawing.Size(885, 145)
        Me.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Text = "RibbonPageCategory1"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 443)
        Me.Controls.Add(Me.ribbon)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IsMdiContainer = True
        Me.Name = "FrmMain"
        Me.ribbon = Me.ribbon
        Me.Text = "TSMU"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ribbon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private barManager1 As DevExpress.XtraBars.BarManager
    Private bar1 As DevExpress.XtraBars.Bar
    Private bar2 As DevExpress.XtraBars.Bar
    Private bar3 As DevExpress.XtraBars.Bar
    Private barDockControlTop As DevExpress.XtraBars.BarDockControl
    Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Private barDockControlRight As DevExpress.XtraBars.BarDockControl
    Private xtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents ribbon As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents LoginBar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExitBar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinRibbonGalleryBarItem1 As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Friend WithEvents Filemenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents FileRibbon As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LblDatabase As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LblRecords As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents LblLogin As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lblGroup As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents ChngePasBar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CloseAllBar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinRibbonGalleryBarItem2 As DevExpress.XtraBars.SkinRibbonGalleryBarItem
End Class

