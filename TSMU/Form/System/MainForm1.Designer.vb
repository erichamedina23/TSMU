Partial Class MainForm1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New DevExpress.ExpressApp.Win.Templates.XafComponentResourceManager(GetType(MainForm1))
        Me.barManager = New DevExpress.ExpressApp.Win.Templates.Bars.XafBarManagerV2(Me.components)
        Me.actionContainerObjectsCreation = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerObjectsCreation = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerFile = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerFile = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerSave = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerSave = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerPrint = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerPrint = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerExport = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerExport = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerExit = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerExit = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerUndoRedo = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerUndoRedo = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerEdit = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerEdit = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerRecordEdit = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerRecordEdit = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerWorkflow = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerWorkflow = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerOpenObject = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerOpenObject = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerPanels = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerPanels = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerViewsHistoryNavigation = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerViewsHistoryNavigation = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerViewsNavigation = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerViewsNavigation = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerRecordsNavigation = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerRecordsNavigation = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerView = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerView = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerReports = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerReports = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerDefault = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerDefault = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerSearch = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerSearch = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerFilters = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerFilters = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerFullTextSearch = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerFullTextSearch = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerTools = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerTools = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerOptions = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerOptions = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerDiagnostic = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerDiagnostic = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerAbout = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerAbout = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerMenu = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerMenu = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerWindows = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerWindows = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.actionContainerNotifications = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer()
        Me.barContainerNotifications = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.barContainerStatusMessages = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.barChooseSkinActionControl = New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarChooseSkinActionControl()
        Me.barChooseSkinItem = New DevExpress.XtraBars.BarButtonItem()
        Me.mainMenuBar = New DevExpress.XtraBars.Bar()
        Me.barSubItemFile = New DevExpress.XtraBars.BarSubItem()
        Me.barSubItemEdit = New DevExpress.XtraBars.BarSubItem()
        Me.barSubItemView = New DevExpress.XtraBars.BarSubItem()
        Me.barSubItemPanels = New DevExpress.XtraBars.BarSubItem()
        Me.barSubItemTools = New DevExpress.XtraBars.BarSubItem()
        Me.barSubItemWindow = New DevExpress.XtraBars.BarSubItem()
        Me.barContainerWindow = New DevExpress.XtraBars.BarLinkContainerExItem()
        Me.barMdiChildrenListItem = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.barSubItemHelp = New DevExpress.XtraBars.BarSubItem()
        Me.standardToolBar = New DevExpress.XtraBars.Bar()
        Me.statusBar = New DevExpress.XtraBars.Bar()
        Me.barAndDockingController = New DevExpress.XtraBars.BarAndDockingController(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.dockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.dockPanelNavigation = New DevExpress.XtraBars.Docking.DockPanel()
        Me.dockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.navigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.NavigationActionContainer()
        Me.viewSitePanel = New DevExpress.XtraEditors.PanelControl()
        Me.documentManager = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.noDocumentsView = New DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(Me.components)
        Me.tabbedView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.nativeMdiView = New DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView(Me.components)
        Me.viewSiteManager = New DevExpress.ExpressApp.Win.Templates.ViewSiteManager(Me.components)
        Me.modelSynchronizationManager = New DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager(Me.components)
        Me.formStateModelSynchronizer = New DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer(Me.components)
        Me.templateContextMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerObjectsCreation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerUndoRedo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerRecordEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerWorkflow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerOpenObject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerPanels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerViewsHistoryNavigation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerViewsNavigation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerRecordsNavigation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerReports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerFilters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerFullTextSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerTools, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerWindows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actionContainerNotifications, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barChooseSkinActionControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barAndDockingController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockPanelNavigation.SuspendLayout()
        Me.dockPanel1_Container.SuspendLayout()
        CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.documentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.noDocumentsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabbedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nativeMdiView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.templateContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barManager
        '
        Me.barManager.ActionContainers.Add(Me.actionContainerObjectsCreation)
        Me.barManager.ActionContainers.Add(Me.actionContainerFile)
        Me.barManager.ActionContainers.Add(Me.actionContainerSave)
        Me.barManager.ActionContainers.Add(Me.actionContainerPrint)
        Me.barManager.ActionContainers.Add(Me.actionContainerExport)
        Me.barManager.ActionContainers.Add(Me.actionContainerExit)
        Me.barManager.ActionContainers.Add(Me.actionContainerUndoRedo)
        Me.barManager.ActionContainers.Add(Me.actionContainerEdit)
        Me.barManager.ActionContainers.Add(Me.actionContainerRecordEdit)
        Me.barManager.ActionContainers.Add(Me.actionContainerWorkflow)
        Me.barManager.ActionContainers.Add(Me.actionContainerOpenObject)
        Me.barManager.ActionContainers.Add(Me.actionContainerPanels)
        Me.barManager.ActionContainers.Add(Me.actionContainerViewsHistoryNavigation)
        Me.barManager.ActionContainers.Add(Me.actionContainerViewsNavigation)
        Me.barManager.ActionContainers.Add(Me.actionContainerRecordsNavigation)
        Me.barManager.ActionContainers.Add(Me.actionContainerView)
        Me.barManager.ActionContainers.Add(Me.actionContainerReports)
        Me.barManager.ActionContainers.Add(Me.actionContainerDefault)
        Me.barManager.ActionContainers.Add(Me.actionContainerSearch)
        Me.barManager.ActionContainers.Add(Me.actionContainerFilters)
        Me.barManager.ActionContainers.Add(Me.actionContainerFullTextSearch)
        Me.barManager.ActionContainers.Add(Me.actionContainerTools)
        Me.barManager.ActionContainers.Add(Me.actionContainerOptions)
        Me.barManager.ActionContainers.Add(Me.actionContainerDiagnostic)
        Me.barManager.ActionContainers.Add(Me.actionContainerAbout)
        Me.barManager.ActionContainers.Add(Me.actionContainerMenu)
        Me.barManager.ActionContainers.Add(Me.actionContainerWindows)
        Me.barManager.ActionContainers.Add(Me.actionContainerNotifications)
        Me.barManager.ActionControls.Add(Me.barChooseSkinActionControl)
        Me.barManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.mainMenuBar, Me.standardToolBar, Me.statusBar})
        Me.barManager.Controller = Me.barAndDockingController
        Me.barManager.DockControls.Add(Me.barDockControlTop)
        Me.barManager.DockControls.Add(Me.barDockControlBottom)
        Me.barManager.DockControls.Add(Me.barDockControlLeft)
        Me.barManager.DockControls.Add(Me.barDockControlRight)
        Me.barManager.DockManager = Me.dockManager
        Me.barManager.Form = Me
        Me.barManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barSubItemFile, Me.barSubItemEdit, Me.barSubItemView, Me.barSubItemTools, Me.barSubItemHelp, Me.barContainerFile, Me.barContainerObjectsCreation, Me.barContainerPrint, Me.barContainerExport, Me.barContainerSave, Me.barContainerEdit, Me.barContainerOpenObject, Me.barContainerUndoRedo, Me.barContainerReports, Me.barContainerExit, Me.barContainerRecordEdit, Me.barContainerWorkflow, Me.barContainerRecordsNavigation, Me.barContainerViewsHistoryNavigation, Me.barContainerSearch, Me.barContainerFullTextSearch, Me.barContainerFilters, Me.barContainerView, Me.barContainerDefault, Me.barContainerTools, Me.barContainerViewsNavigation, Me.barContainerDiagnostic, Me.barContainerOptions, Me.barContainerAbout, Me.barContainerWindow, Me.barContainerPanels, Me.barContainerMenu, Me.barSubItemWindow, Me.barMdiChildrenListItem, Me.barContainerWindows, Me.barSubItemPanels, Me.barChooseSkinItem, Me.barContainerNotifications, Me.barContainerStatusMessages})
        Me.barManager.MainMenu = Me.mainMenuBar
        Me.barManager.MaxItemId = 38
        Me.barManager.StatusBar = Me.statusBar
        '
        'actionContainerObjectsCreation
        '
        Me.actionContainerObjectsCreation.BarContainerItem = Me.barContainerObjectsCreation
        Me.actionContainerObjectsCreation.ActionCategory = "ObjectsCreation"
        '
        'barContainerObjectsCreation
        '
        resources.ApplyResources(Me.barContainerObjectsCreation, "barContainerObjectsCreation")
        Me.barContainerObjectsCreation.Id = 6
        Me.barContainerObjectsCreation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerObjectsCreation.Name = "barContainerObjectsCreation"
        '
        'actionContainerFile
        '
        Me.actionContainerFile.BarContainerItem = Me.barContainerFile
        Me.actionContainerFile.ActionCategory = "File"
        '
        'barContainerFile
        '
        resources.ApplyResources(Me.barContainerFile, "barContainerFile")
        Me.barContainerFile.Id = 7
        Me.barContainerFile.MergeOrder = 2
        Me.barContainerFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerFile.Name = "barContainerFile"
        '
        'actionContainerSave
        '
        Me.actionContainerSave.BarContainerItem = Me.barContainerSave
        Me.actionContainerSave.ActionCategory = "Save"
        '
        'barContainerSave
        '
        resources.ApplyResources(Me.barContainerSave, "barContainerSave")
        Me.barContainerSave.Id = 8
        Me.barContainerSave.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerSave.Name = "barContainerSave"
        '
        'actionContainerPrint
        '
        Me.actionContainerPrint.BarContainerItem = Me.barContainerPrint
        Me.actionContainerPrint.ActionCategory = "Print"
        '
        'barContainerPrint
        '
        resources.ApplyResources(Me.barContainerPrint, "barContainerPrint")
        Me.barContainerPrint.Id = 9
        Me.barContainerPrint.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerPrint.Name = "barContainerPrint"
        '
        'actionContainerExport
        '
        Me.actionContainerExport.BarContainerItem = Me.barContainerExport
        Me.actionContainerExport.ActionCategory = "Export"
        '
        'barContainerExport
        '
        resources.ApplyResources(Me.barContainerExport, "barContainerExport")
        Me.barContainerExport.Id = 10
        Me.barContainerExport.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerExport.Name = "barContainerExport"
        '
        'actionContainerExit
        '
        Me.actionContainerExit.BarContainerItem = Me.barContainerExit
        Me.actionContainerExit.ActionCategory = "Exit"
        '
        'barContainerExit
        '
        resources.ApplyResources(Me.barContainerExit, "barContainerExit")
        Me.barContainerExit.Id = 11
        Me.barContainerExit.MergeOrder = 900
        Me.barContainerExit.Name = "barContainerExit"
        '
        'actionContainerUndoRedo
        '
        Me.actionContainerUndoRedo.BarContainerItem = Me.barContainerUndoRedo
        Me.actionContainerUndoRedo.ActionCategory = "UndoRedo"
        '
        'barContainerUndoRedo
        '
        resources.ApplyResources(Me.barContainerUndoRedo, "barContainerUndoRedo")
        Me.barContainerUndoRedo.Id = 12
        Me.barContainerUndoRedo.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerUndoRedo.Name = "barContainerUndoRedo"
        '
        'actionContainerEdit
        '
        Me.actionContainerEdit.BarContainerItem = Me.barContainerEdit
        Me.actionContainerEdit.ActionCategory = "Edit"
        '
        'barContainerEdit
        '
        resources.ApplyResources(Me.barContainerEdit, "barContainerEdit")
        Me.barContainerEdit.Id = 13
        Me.barContainerEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerEdit.Name = "barContainerEdit"
        '
        'actionContainerRecordEdit
        '
        Me.actionContainerRecordEdit.BarContainerItem = Me.barContainerRecordEdit
        Me.actionContainerRecordEdit.ActionCategory = "RecordEdit"
        '
        'barContainerRecordEdit
        '
        resources.ApplyResources(Me.barContainerRecordEdit, "barContainerRecordEdit")
        Me.barContainerRecordEdit.Id = 14
        Me.barContainerRecordEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerRecordEdit.Name = "barContainerRecordEdit"
        '
        'actionContainerWorkflow
        '
        Me.actionContainerWorkflow.BarContainerItem = Me.barContainerWorkflow
        Me.actionContainerWorkflow.ActionCategory = "Workflow"
        '
        'barContainerWorkflow
        '
        resources.ApplyResources(Me.barContainerWorkflow, "barContainerWorkflow")
        Me.barContainerWorkflow.Id = 15
        Me.barContainerWorkflow.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerWorkflow.Name = "barContainerWorkflow"
        '
        'actionContainerOpenObject
        '
        Me.actionContainerOpenObject.BarContainerItem = Me.barContainerOpenObject
        Me.actionContainerOpenObject.ActionCategory = "OpenObject"
        '
        'barContainerOpenObject
        '
        resources.ApplyResources(Me.barContainerOpenObject, "barContainerOpenObject")
        Me.barContainerOpenObject.Id = 16
        Me.barContainerOpenObject.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerOpenObject.Name = "barContainerOpenObject"
        '
        'actionContainerPanels
        '
        Me.actionContainerPanels.BarContainerItem = Me.barContainerPanels
        Me.actionContainerPanels.ActionCategory = "Panels"
        Me.actionContainerPanels.IsMenuMode = True
        '
        'barContainerPanels
        '
        resources.ApplyResources(Me.barContainerPanels, "barContainerPanels")
        Me.barContainerPanels.Id = 17
        Me.barContainerPanels.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerPanels.Name = "barContainerPanels"
        '
        'actionContainerViewsHistoryNavigation
        '
        Me.actionContainerViewsHistoryNavigation.BarContainerItem = Me.barContainerViewsHistoryNavigation
        Me.actionContainerViewsHistoryNavigation.ActionCategory = "ViewsHistoryNavigation"
        Me.actionContainerViewsHistoryNavigation.IsMenuMode = True
        '
        'barContainerViewsHistoryNavigation
        '
        resources.ApplyResources(Me.barContainerViewsHistoryNavigation, "barContainerViewsHistoryNavigation")
        Me.barContainerViewsHistoryNavigation.Id = 18
        Me.barContainerViewsHistoryNavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerViewsHistoryNavigation.Name = "barContainerViewsHistoryNavigation"
        '
        'actionContainerViewsNavigation
        '
        Me.actionContainerViewsNavigation.BarContainerItem = Me.barContainerViewsNavigation
        Me.actionContainerViewsNavigation.ActionCategory = "ViewsNavigation"
        '
        'barContainerViewsNavigation
        '
        resources.ApplyResources(Me.barContainerViewsNavigation, "barContainerViewsNavigation")
        Me.barContainerViewsNavigation.Id = 19
        Me.barContainerViewsNavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerViewsNavigation.Name = "barContainerViewsNavigation"
        '
        'actionContainerRecordsNavigation
        '
        Me.actionContainerRecordsNavigation.BarContainerItem = Me.barContainerRecordsNavigation
        Me.actionContainerRecordsNavigation.ActionCategory = "RecordsNavigation"
        '
        'barContainerRecordsNavigation
        '
        resources.ApplyResources(Me.barContainerRecordsNavigation, "barContainerRecordsNavigation")
        Me.barContainerRecordsNavigation.Id = 20
        Me.barContainerRecordsNavigation.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerRecordsNavigation.Name = "barContainerRecordsNavigation"
        '
        'actionContainerView
        '
        Me.actionContainerView.BarContainerItem = Me.barContainerView
        Me.actionContainerView.ActionCategory = "View"
        '
        'barContainerView
        '
        resources.ApplyResources(Me.barContainerView, "barContainerView")
        Me.barContainerView.Id = 21
        Me.barContainerView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerView.Name = "barContainerView"
        '
        'actionContainerReports
        '
        Me.actionContainerReports.BarContainerItem = Me.barContainerReports
        Me.actionContainerReports.ActionCategory = "Reports"
        '
        'barContainerReports
        '
        resources.ApplyResources(Me.barContainerReports, "barContainerReports")
        Me.barContainerReports.Id = 22
        Me.barContainerReports.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerReports.Name = "barContainerReports"
        '
        'actionContainerDefault
        '
        Me.actionContainerDefault.BarContainerItem = Me.barContainerDefault
        Me.actionContainerDefault.ActionCategory = "Default"
        '
        'barContainerDefault
        '
        resources.ApplyResources(Me.barContainerDefault, "barContainerDefault")
        Me.barContainerDefault.Id = 23
        Me.barContainerDefault.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerDefault.Name = "barContainerDefault"
        '
        'actionContainerSearch
        '
        Me.actionContainerSearch.BarContainerItem = Me.barContainerSearch
        Me.actionContainerSearch.ActionCategory = "Search"
        '
        'barContainerSearch
        '
        resources.ApplyResources(Me.barContainerSearch, "barContainerSearch")
        Me.barContainerSearch.Id = 24
        Me.barContainerSearch.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerSearch.Name = "barContainerSearch"
        '
        'actionContainerFilters
        '
        Me.actionContainerFilters.BarContainerItem = Me.barContainerFilters
        Me.actionContainerFilters.ActionCategory = "Filters"
        '
        'barContainerFilters
        '
        resources.ApplyResources(Me.barContainerFilters, "barContainerFilters")
        Me.barContainerFilters.Id = 25
        Me.barContainerFilters.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerFilters.Name = "barContainerFilters"
        '
        'actionContainerFullTextSearch
        '
        Me.actionContainerFullTextSearch.BarContainerItem = Me.barContainerFullTextSearch
        Me.actionContainerFullTextSearch.ActionCategory = "FullTextSearch"
        '
        'barContainerFullTextSearch
        '
        Me.barContainerFullTextSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.barContainerFullTextSearch, "barContainerFullTextSearch")
        Me.barContainerFullTextSearch.Id = 26
        Me.barContainerFullTextSearch.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerFullTextSearch.Name = "barContainerFullTextSearch"
        '
        'actionContainerTools
        '
        Me.actionContainerTools.BarContainerItem = Me.barContainerTools
        Me.actionContainerTools.ActionCategory = "Tools"
        Me.actionContainerTools.IsMenuMode = True
        '
        'barContainerTools
        '
        resources.ApplyResources(Me.barContainerTools, "barContainerTools")
        Me.barContainerTools.Id = 27
        Me.barContainerTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerTools.Name = "barContainerTools"
        '
        'actionContainerOptions
        '
        Me.actionContainerOptions.BarContainerItem = Me.barContainerOptions
        Me.actionContainerOptions.ActionCategory = "Options"
        Me.actionContainerOptions.IsMenuMode = True
        '
        'barContainerOptions
        '
        resources.ApplyResources(Me.barContainerOptions, "barContainerOptions")
        Me.barContainerOptions.Id = 28
        Me.barContainerOptions.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerOptions.Name = "barContainerOptions"
        '
        'actionContainerDiagnostic
        '
        Me.actionContainerDiagnostic.BarContainerItem = Me.barContainerDiagnostic
        Me.actionContainerDiagnostic.ActionCategory = "Diagnostic"
        Me.actionContainerDiagnostic.IsMenuMode = True
        '
        'barContainerDiagnostic
        '
        resources.ApplyResources(Me.barContainerDiagnostic, "barContainerDiagnostic")
        Me.barContainerDiagnostic.Id = 29
        Me.barContainerDiagnostic.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerDiagnostic.Name = "barContainerDiagnostic"
        '
        'actionContainerAbout
        '
        Me.actionContainerAbout.BarContainerItem = Me.barContainerAbout
        Me.actionContainerAbout.ActionCategory = "About"
        Me.actionContainerAbout.IsMenuMode = True
        '
        'barContainerAbout
        '
        resources.ApplyResources(Me.barContainerAbout, "barContainerAbout")
        Me.barContainerAbout.Id = 30
        Me.barContainerAbout.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerAbout.Name = "barContainerAbout"
        '
        'actionContainerMenu
        '
        Me.actionContainerMenu.BarContainerItem = Me.barContainerMenu
        Me.actionContainerMenu.ActionCategory = "Menu"
        '
        'barContainerMenu
        '
        resources.ApplyResources(Me.barContainerMenu, "barContainerMenu")
        Me.barContainerMenu.Id = 31
        Me.barContainerMenu.Name = "barContainerMenu"
        '
        'actionContainerWindows
        '
        Me.actionContainerWindows.BarContainerItem = Me.barContainerWindows
        Me.actionContainerWindows.ActionCategory = "Windows"
        '
        'barContainerWindows
        '
        resources.ApplyResources(Me.barContainerWindows, "barContainerWindows")
        Me.barContainerWindows.Id = 32
        Me.barContainerWindows.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerWindows.Name = "barContainerWindows"
        ' 
        'actionContainerNotifications
        ' 
        Me.actionContainerNotifications.BarContainerItem = Me.barContainerNotifications
        Me.actionContainerNotifications.ActionCategory = "Notifications"
        ' 
        'barContainerNotifications
        ' 
        resources.ApplyResources(Me.barContainerNotifications, "barContainerNotifications")
        Me.barContainerNotifications.Id = 33
        Me.barContainerNotifications.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerNotifications.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.barContainerNotifications.Name = "barContainerNotifications"
        ' 
        'barContainerStatusMessages
        ' 
        resources.ApplyResources(Me.barContainerStatusMessages, "barContainerStatusMessages")
        Me.barContainerStatusMessages.Id = 34
        Me.barContainerStatusMessages.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerStatusMessages.Name = "barContainerStatusMessages"
        '
        'barChooseSkinActionControl
        '
        Me.barChooseSkinActionControl.BarItem = Me.barChooseSkinItem
        Me.barChooseSkinActionControl.ActionId = "ChooseSkin"
        '
        'barChooseSkinItem
        '
        Me.barChooseSkinItem.AllowDrawArrow = True
        Me.barChooseSkinItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        resources.ApplyResources(Me.barChooseSkinItem, "barChooseSkinItem")
        Me.barChooseSkinItem.Id = 35
        Me.barChooseSkinItem.Name = "barChooseSkinItem"
        '
        'mainMenuBar
        '
        Me.mainMenuBar.BarName = "Main Menu"
        Me.mainMenuBar.DockCol = 0
        Me.mainMenuBar.DockRow = 0
        Me.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.mainMenuBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemFile), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemView), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemTools), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemWindow), New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemHelp)})
        Me.mainMenuBar.OptionsBar.MultiLine = True
        Me.mainMenuBar.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.mainMenuBar, "mainMenuBar")
        '
        'barSubItemFile
        '
        resources.ApplyResources(Me.barSubItemFile, "barSubItemFile")
        Me.barSubItemFile.HideWhenEmpty = True
        Me.barSubItemFile.Id = 0
        Me.barSubItemFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerFile, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerSave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerExit, True)})
        Me.barSubItemFile.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemFile.Name = "barSubItemFile"
        '
        'barSubItemEdit
        '
        resources.ApplyResources(Me.barSubItemEdit, "barSubItemEdit")
        Me.barSubItemEdit.HideWhenEmpty = True
        Me.barSubItemEdit.Id = 1
        Me.barSubItemEdit.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerUndoRedo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerWorkflow, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerOpenObject, True)})
        Me.barSubItemEdit.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemEdit.Name = "barSubItemEdit"
        '
        'barSubItemView
        '
        resources.ApplyResources(Me.barSubItemView, "barSubItemView")
        Me.barSubItemView.HideWhenEmpty = True
        Me.barSubItemView.Id = 2
        Me.barSubItemView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItemPanels, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerViewsHistoryNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerViewsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerRecordsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerReports, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerDefault, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerSearch, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.barContainerFilters, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.barContainerFullTextSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barChooseSkinItem)})
        Me.barSubItemView.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemView.Name = "barSubItemView"
        '
        'barSubItemPanels
        '
        resources.ApplyResources(Me.barSubItemPanels, "barSubItemPanels")
        Me.barSubItemPanels.HideWhenEmpty = True
        Me.barSubItemPanels.Id = 3
        Me.barSubItemPanels.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerPanels, True)})
        Me.barSubItemPanels.Name = "barSubItemPanels"
        '
        'barSubItemTools
        '
        resources.ApplyResources(Me.barSubItemTools, "barSubItemTools")
        Me.barSubItemTools.HideWhenEmpty = True
        Me.barSubItemTools.Id = 4
        Me.barSubItemTools.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerTools, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerOptions, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerDiagnostic, True)})
        Me.barSubItemTools.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemTools.Name = "barSubItemTools"
        '
        'barSubItemWindow
        '
        resources.ApplyResources(Me.barSubItemWindow, "barSubItemWindow")
        Me.barSubItemWindow.HideWhenEmpty = True
        Me.barSubItemWindow.Id = 5
        Me.barSubItemWindow.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerWindow), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerWindows, True)})
        Me.barSubItemWindow.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemWindow.Name = "barSubItemWindow"
        '
        'barContainerWindow
        '
        resources.ApplyResources(Me.barContainerWindow, "barContainerWindow")
        Me.barContainerWindow.Id = 36
        Me.barContainerWindow.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barMdiChildrenListItem)})
        Me.barContainerWindow.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barContainerWindow.Name = "barContainerWindow"
        '
        'barMdiChildrenListItem
        '
        resources.ApplyResources(Me.barMdiChildrenListItem, "barMdiChildrenListItem")
        Me.barMdiChildrenListItem.Id = 37
        Me.barMdiChildrenListItem.Name = "barMdiChildrenListItem"
        '
        'barSubItemHelp
        '
        resources.ApplyResources(Me.barSubItemHelp, "barSubItemHelp")
        Me.barSubItemHelp.HideWhenEmpty = True
        Me.barSubItemHelp.Id = 38
        Me.barSubItemHelp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerAbout, True)})
        Me.barSubItemHelp.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
        Me.barSubItemHelp.Name = "barSubItemHelp"
        '
        'standardToolBar
        '
        Me.standardToolBar.BarName = "Main Toolbar"
        Me.standardToolBar.DockCol = 0
        Me.standardToolBar.DockRow = 1
        Me.standardToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.standardToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerViewsHistoryNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerSave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerUndoRedo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerOpenObject), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerWorkflow, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerReports), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerDefault, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerRecordsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerFilters, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerSearch, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerFullTextSearch)})
        Me.standardToolBar.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.standardToolBar, "standardToolBar")
        '
        'statusBar
        '
        Me.statusBar.BarName = "StatusBar"
        Me.statusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.statusBar.DockCol = 0
        Me.statusBar.DockRow = 0
        Me.statusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.statusBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerStatusMessages), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerNotifications)})
        Me.statusBar.OptionsBar.AllowQuickCustomization = False
        Me.statusBar.OptionsBar.DisableClose = True
        Me.statusBar.OptionsBar.DisableCustomization = True
        Me.statusBar.OptionsBar.DrawDragBorder = False
        Me.statusBar.OptionsBar.DrawSizeGrip = True
        Me.statusBar.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.statusBar, "statusBar")
        '
        'barAndDockingController
        '
        Me.barAndDockingController.PropertiesBar.AllowLinkLighting = False
        Me.barAndDockingController.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.barAndDockingController.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        '
        'dockManager
        '
        Me.dockManager.Controller = Me.barAndDockingController
        Me.dockManager.Form = Me
        Me.dockManager.MenuManager = Me.barManager
        Me.dockManager.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.dockPanelNavigation})
        Me.dockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
        '
        'dockPanelNavigation
        '
        Me.dockPanelNavigation.Controls.Add(Me.dockPanel1_Container)
        Me.dockPanelNavigation.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.dockPanelNavigation.ID = New System.Guid("a0cbae9b-d8b1-4760-9909-e8b7286fd8a0")
        resources.ApplyResources(Me.dockPanelNavigation, "dockPanelNavigation")
        Me.dockPanelNavigation.Name = "dockPanelNavigation"
        Me.dockPanelNavigation.Options.AllowDockBottom = False
        Me.dockPanelNavigation.Options.AllowDockTop = False
        Me.dockPanelNavigation.OriginalSize = New System.Drawing.Size(200, 200)
        '
        'dockPanel1_Container
        '
        Me.dockPanel1_Container.Controls.Add(Me.navigation)
        resources.ApplyResources(Me.dockPanel1_Container, "dockPanel1_Container")
        Me.dockPanel1_Container.Name = "dockPanel1_Container"
        '
        'navigation
        '
        resources.ApplyResources(Me.navigation, "navigation")
        Me.navigation.Model = Nothing
        Me.navigation.Name = "navigation"
        '
        'viewSitePanel
        '
        Me.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.viewSitePanel, "viewSitePanel")
        Me.viewSitePanel.Name = "viewSitePanel"
        '
        'documentManager
        '
        Me.documentManager.BarAndDockingController = Me.barAndDockingController
        Me.documentManager.ClientControl = Me.viewSitePanel
        Me.documentManager.MenuManager = Me.barManager
        Me.documentManager.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.[False]
        Me.documentManager.View = Me.noDocumentsView
        Me.documentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.noDocumentsView, Me.tabbedView, Me.nativeMdiView})
        '
        'tabbedView
        '
        Me.tabbedView.DocumentProperties.MaxTabWidth = 165
        Me.tabbedView.FloatingDocumentContainer = DevExpress.XtraBars.Docking2010.Views.FloatingDocumentContainer.DocumentsHost
        Me.tabbedView.OptionsLayout.PropertiesRestoreMode = DevExpress.XtraBars.Docking2010.Views.PropertiesRestoreMode.None
        Me.tabbedView.AppearancePage.Header.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.tabbedView.AppearancePage.Header.Options.UseTextOptions = True
        Me.tabbedView.AppearancePage.HeaderHotTracked.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.tabbedView.AppearancePage.HeaderHotTracked.Options.UseTextOptions = True
        '
        'nativeMdiView
        '
        Me.nativeMdiView.FloatingDocumentContainer = DevExpress.XtraBars.Docking2010.Views.FloatingDocumentContainer.DocumentsHost
        '
        'viewSiteManager
        '
        Me.viewSiteManager.ViewSiteControl = Me.viewSitePanel
        '
        'modelSynchronizationManager
        '
        Me.modelSynchronizationManager.ModelSynchronizableComponents.Add(Me.formStateModelSynchronizer)
        Me.modelSynchronizationManager.ModelSynchronizableComponents.Add(Me.navigation)
        '
        'formStateModelSynchronizer
        '
        Me.formStateModelSynchronizer.Form = Me
        '
        'templateContextMenu
        '
        Me.templateContextMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerSave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerOpenObject, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerUndoRedo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerReports, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.barContainerMenu, True)})
        Me.templateContextMenu.Manager = Me.barManager
        Me.templateContextMenu.Name = "templateContextMenu"
        '
        'MainForm1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.viewSitePanel)
        Me.Controls.Add(Me.dockPanelNavigation)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IsMdiContainer = True
        Me.Name = "MainForm1"
        CType(Me.barManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerObjectsCreation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerUndoRedo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerRecordEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerWorkflow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerOpenObject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerPanels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerViewsHistoryNavigation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerViewsNavigation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerRecordsNavigation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerReports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerFilters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerFullTextSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerTools, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerAbout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerWindows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actionContainerNotifications, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barChooseSkinActionControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barAndDockingController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockPanelNavigation.ResumeLayout(False)
        Me.dockPanel1_Container.ResumeLayout(False)
        CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.documentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.noDocumentsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabbedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nativeMdiView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.templateContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private barManager As DevExpress.ExpressApp.Win.Templates.Bars.XafBarManagerV2
    Private mainMenuBar As DevExpress.XtraBars.Bar
    Private standardToolBar As DevExpress.XtraBars.Bar
    Private statusBar As DevExpress.XtraBars.Bar
    Private barDockControlTop As DevExpress.XtraBars.BarDockControl
    Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Private barDockControlRight As DevExpress.XtraBars.BarDockControl
    Private barSubItemFile As DevExpress.XtraBars.BarSubItem
    Private barSubItemEdit As DevExpress.XtraBars.BarSubItem
    Private barSubItemView As DevExpress.XtraBars.BarSubItem
    Private barSubItemTools As DevExpress.XtraBars.BarSubItem
    Private barSubItemHelp As DevExpress.XtraBars.BarSubItem
    Private barSubItemWindow As DevExpress.XtraBars.BarSubItem
    Private barSubItemPanels As DevExpress.XtraBars.BarSubItem
    Private barContainerFile As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerObjectsCreation As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerPrint As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerExport As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerSave As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerUndoRedo As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerReports As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerEdit As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerExit As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerOpenObject As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerViewsNavigation As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerRecordEdit As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerWorkflow As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerRecordsNavigation As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerViewsHistoryNavigation As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerSearch As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerFullTextSearch As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerFilters As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerView As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerDefault As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerTools As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerDiagnostic As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerOptions As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerAbout As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerWindow As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerPanels As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerMenu As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerWindows As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerNotifications As DevExpress.XtraBars.BarLinkContainerExItem
    Private barContainerStatusMessages As DevExpress.XtraBars.BarLinkContainerExItem
    Private actionContainerFile As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerObjectsCreation As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerPrint As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerExport As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerSave As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerUndoRedo As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerReports As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerEdit As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerExit As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerOpenObject As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerViewsNavigation As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerRecordEdit As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerWorkflow As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerRecordsNavigation As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerViewsHistoryNavigation As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerSearch As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerFullTextSearch As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerFilters As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerView As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerDefault As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerTools As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerDiagnostic As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerOptions As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerAbout As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerPanels As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerMenu As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerWindows As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private actionContainerNotifications As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
    Private barMdiChildrenListItem As DevExpress.XtraBars.BarDockingMenuItem
    Private viewSitePanel As DevExpress.XtraEditors.PanelControl
    Private dockManager As DevExpress.XtraBars.Docking.DockManager
    Private dockPanelNavigation As DevExpress.XtraBars.Docking.DockPanel
    Private dockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Private navigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.NavigationActionContainer
    Private documentManager As DevExpress.XtraBars.Docking2010.DocumentManager
    Private viewSiteManager As DevExpress.ExpressApp.Win.Templates.ViewSiteManager
    Private modelSynchronizationManager As DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager
    Private formStateModelSynchronizer As DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer
    Private tabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Private nativeMdiView As DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView
    Private barAndDockingController As DevExpress.XtraBars.BarAndDockingController
    Private templateContextMenu As DevExpress.XtraBars.PopupMenu
    Private noDocumentsView As DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView
    Private barChooseSkinActionControl As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarChooseSkinActionControl
    Private barChooseSkinItem As DevExpress.XtraBars.BarButtonItem
End Class
