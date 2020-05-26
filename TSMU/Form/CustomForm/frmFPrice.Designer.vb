<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFPrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFPrice))
        Me.DataSet1 = New TSMU.DataSet1()
        Me.TForecastPrice1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TForecastPrice1TableAdapter = New TSMU.DataSet1TableAdapters.tForecastPrice1TableAdapter()
        Me.TableAdapterManager = New TSMU.DataSet1TableAdapters.TableAdapterManager()
        Me.TForecastPrice1BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TForecastPrice1BindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.TForecastPrice1GridControl = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CekHargaBedaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CekInventory1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTahun = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInvtID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colModel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSite = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFlag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesPO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesPO2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJanHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAprHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeiHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgtHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSepHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOktHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNovHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesHarga1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesHarga2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesHarga3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbBulan = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TForecastPrice1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TForecastPrice1BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TForecastPrice1BindingNavigator.SuspendLayout()
        CType(Me.TForecastPrice1GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TForecastPrice1BindingSource
        '
        Me.TForecastPrice1BindingSource.DataMember = "tForecastPrice1"
        Me.TForecastPrice1BindingSource.DataSource = Me.DataSet1
        '
        'TForecastPrice1TableAdapter
        '
        Me.TForecastPrice1TableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tForecastPrice1TableAdapter = Me.TForecastPrice1TableAdapter
        Me.TableAdapterManager.tForecastPriceTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TSMU.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TForecastPrice1BindingNavigator
        '
        Me.TForecastPrice1BindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TForecastPrice1BindingNavigator.BindingSource = Me.TForecastPrice1BindingSource
        Me.TForecastPrice1BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TForecastPrice1BindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TForecastPrice1BindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TForecastPrice1BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TForecastPrice1BindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.tsbImport, Me.ToolStripSeparator2, Me.tsbRefresh, Me.ToolStripSeparator3})
        Me.TForecastPrice1BindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TForecastPrice1BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TForecastPrice1BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TForecastPrice1BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TForecastPrice1BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TForecastPrice1BindingNavigator.Name = "TForecastPrice1BindingNavigator"
        Me.TForecastPrice1BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TForecastPrice1BindingNavigator.Size = New System.Drawing.Size(895, 27)
        Me.TForecastPrice1BindingNavigator.TabIndex = 0
        Me.TForecastPrice1BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 24)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'TForecastPrice1BindingNavigatorSaveItem
        '
        Me.TForecastPrice1BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TForecastPrice1BindingNavigatorSaveItem.Image = CType(resources.GetObject("TForecastPrice1BindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TForecastPrice1BindingNavigatorSaveItem.Name = "TForecastPrice1BindingNavigatorSaveItem"
        Me.TForecastPrice1BindingNavigatorSaveItem.Size = New System.Drawing.Size(24, 24)
        Me.TForecastPrice1BindingNavigatorSaveItem.Text = "Save Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'tsbImport
        '
        Me.tsbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImport.Image = CType(resources.GetObject("tsbImport.Image"), System.Drawing.Image)
        Me.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImport.Name = "tsbImport"
        Me.tsbImport.Size = New System.Drawing.Size(24, 24)
        Me.tsbImport.Text = "Inport Data"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefresh.Image = CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image)
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(24, 24)
        Me.tsbRefresh.Text = "Refresh"
        '
        'TForecastPrice1GridControl
        '
        Me.TForecastPrice1GridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TForecastPrice1GridControl.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TForecastPrice1GridControl.DataSource = Me.TForecastPrice1BindingSource
        Me.TForecastPrice1GridControl.Location = New System.Drawing.Point(0, 68)
        Me.TForecastPrice1GridControl.MainView = Me.GridView1
        Me.TForecastPrice1GridControl.Name = "TForecastPrice1GridControl"
        Me.TForecastPrice1GridControl.Size = New System.Drawing.Size(895, 427)
        Me.TForecastPrice1GridControl.TabIndex = 1
        Me.TForecastPrice1GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem, Me.CekHargaBedaToolStripMenuItem, Me.CekInventory1ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(194, 76)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'CekHargaBedaToolStripMenuItem
        '
        Me.CekHargaBedaToolStripMenuItem.Name = "CekHargaBedaToolStripMenuItem"
        Me.CekHargaBedaToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.CekHargaBedaToolStripMenuItem.Text = "Cek Harga Beda"
        '
        'CekInventory1ToolStripMenuItem
        '
        Me.CekInventory1ToolStripMenuItem.Name = "CekInventory1ToolStripMenuItem"
        Me.CekInventory1ToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.CekInventory1ToolStripMenuItem.Text = "Cek Inventory > 1"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colId, Me.colTahun, Me.colCustID, Me.colCustomer, Me.colInvtID, Me.colDescription, Me.colPartNo, Me.colModel, Me.GridColumn1, Me.GridColumn2, Me.colSite, Me.colFlag, Me.colJanQty1, Me.colJanQty2, Me.colJanQty3, Me.colJanPO1, Me.colJanPO2, Me.colFebQty1, Me.colFebQty2, Me.colFebQty3, Me.colFebPO1, Me.colFebPO2, Me.colMarQty1, Me.colMarQty2, Me.colMarQty3, Me.colMarPO1, Me.colMarPO2, Me.colAprQty1, Me.colAprQty2, Me.colAprQty3, Me.colAprPO1, Me.colAprPO2, Me.colMeiQty1, Me.colMeiQty2, Me.colMeiQty3, Me.colMeiPO1, Me.colMeiPO2, Me.colJunQty1, Me.colJunQty2, Me.colJunQty3, Me.colJunPO1, Me.colJunPO2, Me.colJulQty1, Me.colJulQty2, Me.colJulQty3, Me.colJulPO1, Me.colJulPO2, Me.colAgtQty1, Me.colAgtQty2, Me.colAgtQty3, Me.colAgtPO1, Me.colAgtPO2, Me.colSepQty1, Me.colSepQty2, Me.colSepQty3, Me.colSepPO1, Me.colSepPO2, Me.colOktQty1, Me.colOktQty2, Me.colOktQty3, Me.colOktPO1, Me.colOktPO2, Me.colNovQty1, Me.colNovQty2, Me.colNovQty3, Me.colNovPO1, Me.colNovPO2, Me.colDesQty1, Me.colDesQty2, Me.colDesQty3, Me.colDesPO1, Me.colDesPO2, Me.colJanHarga1, Me.colJanHarga2, Me.colJanHarga3, Me.colFebHarga1, Me.colFebHarga2, Me.colFebHarga3, Me.colMarHarga1, Me.colMarHarga2, Me.colMarHarga3, Me.colAprHarga1, Me.colAprHarga2, Me.colAprHarga3, Me.colMeiHarga1, Me.colMeiHarga2, Me.colMeiHarga3, Me.colJunHarga1, Me.colJunHarga2, Me.colJunHarga3, Me.colJulHarga1, Me.colJulHarga2, Me.colJulHarga3, Me.colAgtHarga1, Me.colAgtHarga2, Me.colAgtHarga3, Me.colSepHarga1, Me.colSepHarga2, Me.colSepHarga3, Me.colOktHarga1, Me.colOktHarga2, Me.colOktHarga3, Me.colNovHarga1, Me.colNovHarga2, Me.colNovHarga3, Me.colDesHarga1, Me.colDesHarga2, Me.colDesHarga3})
        Me.GridView1.GridControl = Me.TForecastPrice1GridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colId
        '
        Me.colId.FieldName = "Id"
        Me.colId.MinWidth = 25
        Me.colId.Name = "colId"
        Me.colId.Visible = True
        Me.colId.VisibleIndex = 0
        Me.colId.Width = 94
        '
        'colTahun
        '
        Me.colTahun.FieldName = "Tahun"
        Me.colTahun.MinWidth = 25
        Me.colTahun.Name = "colTahun"
        Me.colTahun.Visible = True
        Me.colTahun.VisibleIndex = 1
        Me.colTahun.Width = 94
        '
        'colCustID
        '
        Me.colCustID.FieldName = "CustID"
        Me.colCustID.MinWidth = 25
        Me.colCustID.Name = "colCustID"
        Me.colCustID.Visible = True
        Me.colCustID.VisibleIndex = 2
        Me.colCustID.Width = 94
        '
        'colCustomer
        '
        Me.colCustomer.FieldName = "Customer"
        Me.colCustomer.MinWidth = 25
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.OptionsColumn.AllowEdit = False
        Me.colCustomer.Visible = True
        Me.colCustomer.VisibleIndex = 3
        Me.colCustomer.Width = 94
        '
        'colInvtID
        '
        Me.colInvtID.FieldName = "InvtID"
        Me.colInvtID.MinWidth = 25
        Me.colInvtID.Name = "colInvtID"
        Me.colInvtID.Visible = True
        Me.colInvtID.VisibleIndex = 4
        Me.colInvtID.Width = 94
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.MinWidth = 25
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 5
        Me.colDescription.Width = 94
        '
        'colPartNo
        '
        Me.colPartNo.FieldName = "PartNo"
        Me.colPartNo.MinWidth = 25
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.OptionsColumn.AllowEdit = False
        Me.colPartNo.Visible = True
        Me.colPartNo.VisibleIndex = 6
        Me.colPartNo.Width = 94
        '
        'colModel
        '
        Me.colModel.FieldName = "Model"
        Me.colModel.MinWidth = 25
        Me.colModel.Name = "colModel"
        Me.colModel.Visible = True
        Me.colModel.VisibleIndex = 7
        Me.colModel.Width = 94
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "Oe/Pe"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 8
        Me.GridColumn1.Width = 94
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "IN/SUB"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 9
        Me.GridColumn2.Width = 94
        '
        'colSite
        '
        Me.colSite.FieldName = "Site"
        Me.colSite.MinWidth = 25
        Me.colSite.Name = "colSite"
        Me.colSite.Visible = True
        Me.colSite.VisibleIndex = 10
        Me.colSite.Width = 94
        '
        'colFlag
        '
        Me.colFlag.FieldName = "Flag"
        Me.colFlag.MinWidth = 25
        Me.colFlag.Name = "colFlag"
        Me.colFlag.Visible = True
        Me.colFlag.VisibleIndex = 11
        Me.colFlag.Width = 94
        '
        'colJanQty1
        '
        Me.colJanQty1.FieldName = "JanQty1"
        Me.colJanQty1.MinWidth = 25
        Me.colJanQty1.Name = "colJanQty1"
        Me.colJanQty1.Visible = True
        Me.colJanQty1.VisibleIndex = 12
        Me.colJanQty1.Width = 94
        '
        'colJanQty2
        '
        Me.colJanQty2.FieldName = "JanQty2"
        Me.colJanQty2.MinWidth = 25
        Me.colJanQty2.Name = "colJanQty2"
        Me.colJanQty2.Visible = True
        Me.colJanQty2.VisibleIndex = 13
        Me.colJanQty2.Width = 94
        '
        'colJanQty3
        '
        Me.colJanQty3.FieldName = "JanQty3"
        Me.colJanQty3.MinWidth = 25
        Me.colJanQty3.Name = "colJanQty3"
        Me.colJanQty3.Visible = True
        Me.colJanQty3.VisibleIndex = 14
        Me.colJanQty3.Width = 94
        '
        'colJanPO1
        '
        Me.colJanPO1.FieldName = "Jan PO1"
        Me.colJanPO1.MinWidth = 25
        Me.colJanPO1.Name = "colJanPO1"
        Me.colJanPO1.Visible = True
        Me.colJanPO1.VisibleIndex = 15
        Me.colJanPO1.Width = 94
        '
        'colJanPO2
        '
        Me.colJanPO2.FieldName = "Jan PO2"
        Me.colJanPO2.MinWidth = 25
        Me.colJanPO2.Name = "colJanPO2"
        Me.colJanPO2.Visible = True
        Me.colJanPO2.VisibleIndex = 16
        Me.colJanPO2.Width = 94
        '
        'colFebQty1
        '
        Me.colFebQty1.FieldName = "FebQty1"
        Me.colFebQty1.MinWidth = 25
        Me.colFebQty1.Name = "colFebQty1"
        Me.colFebQty1.Visible = True
        Me.colFebQty1.VisibleIndex = 17
        Me.colFebQty1.Width = 94
        '
        'colFebQty2
        '
        Me.colFebQty2.FieldName = "FebQty2"
        Me.colFebQty2.MinWidth = 25
        Me.colFebQty2.Name = "colFebQty2"
        Me.colFebQty2.Visible = True
        Me.colFebQty2.VisibleIndex = 18
        Me.colFebQty2.Width = 94
        '
        'colFebQty3
        '
        Me.colFebQty3.FieldName = "FebQty3"
        Me.colFebQty3.MinWidth = 25
        Me.colFebQty3.Name = "colFebQty3"
        Me.colFebQty3.Visible = True
        Me.colFebQty3.VisibleIndex = 19
        Me.colFebQty3.Width = 94
        '
        'colFebPO1
        '
        Me.colFebPO1.FieldName = "Feb PO1"
        Me.colFebPO1.MinWidth = 25
        Me.colFebPO1.Name = "colFebPO1"
        Me.colFebPO1.Visible = True
        Me.colFebPO1.VisibleIndex = 20
        Me.colFebPO1.Width = 94
        '
        'colFebPO2
        '
        Me.colFebPO2.FieldName = "Feb PO2"
        Me.colFebPO2.MinWidth = 25
        Me.colFebPO2.Name = "colFebPO2"
        Me.colFebPO2.Visible = True
        Me.colFebPO2.VisibleIndex = 21
        Me.colFebPO2.Width = 94
        '
        'colMarQty1
        '
        Me.colMarQty1.FieldName = "MarQty1"
        Me.colMarQty1.MinWidth = 25
        Me.colMarQty1.Name = "colMarQty1"
        Me.colMarQty1.Visible = True
        Me.colMarQty1.VisibleIndex = 22
        Me.colMarQty1.Width = 94
        '
        'colMarQty2
        '
        Me.colMarQty2.FieldName = "MarQty2"
        Me.colMarQty2.MinWidth = 25
        Me.colMarQty2.Name = "colMarQty2"
        Me.colMarQty2.Visible = True
        Me.colMarQty2.VisibleIndex = 23
        Me.colMarQty2.Width = 94
        '
        'colMarQty3
        '
        Me.colMarQty3.FieldName = "MarQty3"
        Me.colMarQty3.MinWidth = 25
        Me.colMarQty3.Name = "colMarQty3"
        Me.colMarQty3.Visible = True
        Me.colMarQty3.VisibleIndex = 24
        Me.colMarQty3.Width = 94
        '
        'colMarPO1
        '
        Me.colMarPO1.FieldName = "Mar PO1"
        Me.colMarPO1.MinWidth = 25
        Me.colMarPO1.Name = "colMarPO1"
        Me.colMarPO1.Visible = True
        Me.colMarPO1.VisibleIndex = 25
        Me.colMarPO1.Width = 94
        '
        'colMarPO2
        '
        Me.colMarPO2.FieldName = "Mar PO2"
        Me.colMarPO2.MinWidth = 25
        Me.colMarPO2.Name = "colMarPO2"
        Me.colMarPO2.Visible = True
        Me.colMarPO2.VisibleIndex = 26
        Me.colMarPO2.Width = 94
        '
        'colAprQty1
        '
        Me.colAprQty1.FieldName = "AprQty1"
        Me.colAprQty1.MinWidth = 25
        Me.colAprQty1.Name = "colAprQty1"
        Me.colAprQty1.Visible = True
        Me.colAprQty1.VisibleIndex = 27
        Me.colAprQty1.Width = 94
        '
        'colAprQty2
        '
        Me.colAprQty2.FieldName = "AprQty2"
        Me.colAprQty2.MinWidth = 25
        Me.colAprQty2.Name = "colAprQty2"
        Me.colAprQty2.Visible = True
        Me.colAprQty2.VisibleIndex = 28
        Me.colAprQty2.Width = 94
        '
        'colAprQty3
        '
        Me.colAprQty3.FieldName = "AprQty3"
        Me.colAprQty3.MinWidth = 25
        Me.colAprQty3.Name = "colAprQty3"
        Me.colAprQty3.Visible = True
        Me.colAprQty3.VisibleIndex = 29
        Me.colAprQty3.Width = 94
        '
        'colAprPO1
        '
        Me.colAprPO1.FieldName = "Apr PO1"
        Me.colAprPO1.MinWidth = 25
        Me.colAprPO1.Name = "colAprPO1"
        Me.colAprPO1.Visible = True
        Me.colAprPO1.VisibleIndex = 30
        Me.colAprPO1.Width = 94
        '
        'colAprPO2
        '
        Me.colAprPO2.FieldName = "Apr PO2"
        Me.colAprPO2.MinWidth = 25
        Me.colAprPO2.Name = "colAprPO2"
        Me.colAprPO2.Visible = True
        Me.colAprPO2.VisibleIndex = 31
        Me.colAprPO2.Width = 94
        '
        'colMeiQty1
        '
        Me.colMeiQty1.FieldName = "MeiQty1"
        Me.colMeiQty1.MinWidth = 25
        Me.colMeiQty1.Name = "colMeiQty1"
        Me.colMeiQty1.Visible = True
        Me.colMeiQty1.VisibleIndex = 32
        Me.colMeiQty1.Width = 94
        '
        'colMeiQty2
        '
        Me.colMeiQty2.FieldName = "MeiQty2"
        Me.colMeiQty2.MinWidth = 25
        Me.colMeiQty2.Name = "colMeiQty2"
        Me.colMeiQty2.Visible = True
        Me.colMeiQty2.VisibleIndex = 33
        Me.colMeiQty2.Width = 94
        '
        'colMeiQty3
        '
        Me.colMeiQty3.FieldName = "MeiQty3"
        Me.colMeiQty3.MinWidth = 25
        Me.colMeiQty3.Name = "colMeiQty3"
        Me.colMeiQty3.Visible = True
        Me.colMeiQty3.VisibleIndex = 34
        Me.colMeiQty3.Width = 94
        '
        'colMeiPO1
        '
        Me.colMeiPO1.FieldName = "Mei PO1"
        Me.colMeiPO1.MinWidth = 25
        Me.colMeiPO1.Name = "colMeiPO1"
        Me.colMeiPO1.Visible = True
        Me.colMeiPO1.VisibleIndex = 35
        Me.colMeiPO1.Width = 94
        '
        'colMeiPO2
        '
        Me.colMeiPO2.FieldName = "Mei PO2"
        Me.colMeiPO2.MinWidth = 25
        Me.colMeiPO2.Name = "colMeiPO2"
        Me.colMeiPO2.Visible = True
        Me.colMeiPO2.VisibleIndex = 36
        Me.colMeiPO2.Width = 94
        '
        'colJunQty1
        '
        Me.colJunQty1.FieldName = "JunQty1"
        Me.colJunQty1.MinWidth = 25
        Me.colJunQty1.Name = "colJunQty1"
        Me.colJunQty1.Visible = True
        Me.colJunQty1.VisibleIndex = 37
        Me.colJunQty1.Width = 94
        '
        'colJunQty2
        '
        Me.colJunQty2.FieldName = "JunQty2"
        Me.colJunQty2.MinWidth = 25
        Me.colJunQty2.Name = "colJunQty2"
        Me.colJunQty2.Visible = True
        Me.colJunQty2.VisibleIndex = 38
        Me.colJunQty2.Width = 94
        '
        'colJunQty3
        '
        Me.colJunQty3.FieldName = "JunQty3"
        Me.colJunQty3.MinWidth = 25
        Me.colJunQty3.Name = "colJunQty3"
        Me.colJunQty3.Visible = True
        Me.colJunQty3.VisibleIndex = 39
        Me.colJunQty3.Width = 94
        '
        'colJunPO1
        '
        Me.colJunPO1.FieldName = "Jun PO1"
        Me.colJunPO1.MinWidth = 25
        Me.colJunPO1.Name = "colJunPO1"
        Me.colJunPO1.Visible = True
        Me.colJunPO1.VisibleIndex = 40
        Me.colJunPO1.Width = 94
        '
        'colJunPO2
        '
        Me.colJunPO2.FieldName = "Jun PO2"
        Me.colJunPO2.MinWidth = 25
        Me.colJunPO2.Name = "colJunPO2"
        Me.colJunPO2.Visible = True
        Me.colJunPO2.VisibleIndex = 41
        Me.colJunPO2.Width = 94
        '
        'colJulQty1
        '
        Me.colJulQty1.FieldName = "JulQty1"
        Me.colJulQty1.MinWidth = 25
        Me.colJulQty1.Name = "colJulQty1"
        Me.colJulQty1.Visible = True
        Me.colJulQty1.VisibleIndex = 42
        Me.colJulQty1.Width = 94
        '
        'colJulQty2
        '
        Me.colJulQty2.FieldName = "JulQty2"
        Me.colJulQty2.MinWidth = 25
        Me.colJulQty2.Name = "colJulQty2"
        Me.colJulQty2.Visible = True
        Me.colJulQty2.VisibleIndex = 43
        Me.colJulQty2.Width = 94
        '
        'colJulQty3
        '
        Me.colJulQty3.FieldName = "JulQty3"
        Me.colJulQty3.MinWidth = 25
        Me.colJulQty3.Name = "colJulQty3"
        Me.colJulQty3.Visible = True
        Me.colJulQty3.VisibleIndex = 44
        Me.colJulQty3.Width = 94
        '
        'colJulPO1
        '
        Me.colJulPO1.FieldName = "Jul PO1"
        Me.colJulPO1.MinWidth = 25
        Me.colJulPO1.Name = "colJulPO1"
        Me.colJulPO1.Visible = True
        Me.colJulPO1.VisibleIndex = 45
        Me.colJulPO1.Width = 94
        '
        'colJulPO2
        '
        Me.colJulPO2.FieldName = "Jul PO2"
        Me.colJulPO2.MinWidth = 25
        Me.colJulPO2.Name = "colJulPO2"
        Me.colJulPO2.Visible = True
        Me.colJulPO2.VisibleIndex = 46
        Me.colJulPO2.Width = 94
        '
        'colAgtQty1
        '
        Me.colAgtQty1.FieldName = "AgtQty1"
        Me.colAgtQty1.MinWidth = 25
        Me.colAgtQty1.Name = "colAgtQty1"
        Me.colAgtQty1.Visible = True
        Me.colAgtQty1.VisibleIndex = 47
        Me.colAgtQty1.Width = 94
        '
        'colAgtQty2
        '
        Me.colAgtQty2.FieldName = "AgtQty2"
        Me.colAgtQty2.MinWidth = 25
        Me.colAgtQty2.Name = "colAgtQty2"
        Me.colAgtQty2.Visible = True
        Me.colAgtQty2.VisibleIndex = 48
        Me.colAgtQty2.Width = 94
        '
        'colAgtQty3
        '
        Me.colAgtQty3.FieldName = "AgtQty3"
        Me.colAgtQty3.MinWidth = 25
        Me.colAgtQty3.Name = "colAgtQty3"
        Me.colAgtQty3.Visible = True
        Me.colAgtQty3.VisibleIndex = 49
        Me.colAgtQty3.Width = 94
        '
        'colAgtPO1
        '
        Me.colAgtPO1.FieldName = "Agt PO1"
        Me.colAgtPO1.MinWidth = 25
        Me.colAgtPO1.Name = "colAgtPO1"
        Me.colAgtPO1.Visible = True
        Me.colAgtPO1.VisibleIndex = 50
        Me.colAgtPO1.Width = 94
        '
        'colAgtPO2
        '
        Me.colAgtPO2.FieldName = "Agt PO2"
        Me.colAgtPO2.MinWidth = 25
        Me.colAgtPO2.Name = "colAgtPO2"
        Me.colAgtPO2.Visible = True
        Me.colAgtPO2.VisibleIndex = 51
        Me.colAgtPO2.Width = 94
        '
        'colSepQty1
        '
        Me.colSepQty1.FieldName = "SepQty1"
        Me.colSepQty1.MinWidth = 25
        Me.colSepQty1.Name = "colSepQty1"
        Me.colSepQty1.Visible = True
        Me.colSepQty1.VisibleIndex = 52
        Me.colSepQty1.Width = 94
        '
        'colSepQty2
        '
        Me.colSepQty2.FieldName = "SepQty2"
        Me.colSepQty2.MinWidth = 25
        Me.colSepQty2.Name = "colSepQty2"
        Me.colSepQty2.Visible = True
        Me.colSepQty2.VisibleIndex = 53
        Me.colSepQty2.Width = 94
        '
        'colSepQty3
        '
        Me.colSepQty3.FieldName = "SepQty3"
        Me.colSepQty3.MinWidth = 25
        Me.colSepQty3.Name = "colSepQty3"
        Me.colSepQty3.Visible = True
        Me.colSepQty3.VisibleIndex = 54
        Me.colSepQty3.Width = 94
        '
        'colSepPO1
        '
        Me.colSepPO1.FieldName = "Sep PO1"
        Me.colSepPO1.MinWidth = 25
        Me.colSepPO1.Name = "colSepPO1"
        Me.colSepPO1.Visible = True
        Me.colSepPO1.VisibleIndex = 55
        Me.colSepPO1.Width = 94
        '
        'colSepPO2
        '
        Me.colSepPO2.FieldName = "Sep PO2"
        Me.colSepPO2.MinWidth = 25
        Me.colSepPO2.Name = "colSepPO2"
        Me.colSepPO2.Visible = True
        Me.colSepPO2.VisibleIndex = 56
        Me.colSepPO2.Width = 94
        '
        'colOktQty1
        '
        Me.colOktQty1.FieldName = "OktQty1"
        Me.colOktQty1.MinWidth = 25
        Me.colOktQty1.Name = "colOktQty1"
        Me.colOktQty1.Visible = True
        Me.colOktQty1.VisibleIndex = 57
        Me.colOktQty1.Width = 94
        '
        'colOktQty2
        '
        Me.colOktQty2.FieldName = "OktQty2"
        Me.colOktQty2.MinWidth = 25
        Me.colOktQty2.Name = "colOktQty2"
        Me.colOktQty2.Visible = True
        Me.colOktQty2.VisibleIndex = 58
        Me.colOktQty2.Width = 94
        '
        'colOktQty3
        '
        Me.colOktQty3.FieldName = "OktQty3"
        Me.colOktQty3.MinWidth = 25
        Me.colOktQty3.Name = "colOktQty3"
        Me.colOktQty3.Visible = True
        Me.colOktQty3.VisibleIndex = 59
        Me.colOktQty3.Width = 94
        '
        'colOktPO1
        '
        Me.colOktPO1.FieldName = "Okt PO1"
        Me.colOktPO1.MinWidth = 25
        Me.colOktPO1.Name = "colOktPO1"
        Me.colOktPO1.Visible = True
        Me.colOktPO1.VisibleIndex = 60
        Me.colOktPO1.Width = 94
        '
        'colOktPO2
        '
        Me.colOktPO2.FieldName = "Okt PO2"
        Me.colOktPO2.MinWidth = 25
        Me.colOktPO2.Name = "colOktPO2"
        Me.colOktPO2.Visible = True
        Me.colOktPO2.VisibleIndex = 61
        Me.colOktPO2.Width = 94
        '
        'colNovQty1
        '
        Me.colNovQty1.FieldName = "NovQty1"
        Me.colNovQty1.MinWidth = 25
        Me.colNovQty1.Name = "colNovQty1"
        Me.colNovQty1.Visible = True
        Me.colNovQty1.VisibleIndex = 62
        Me.colNovQty1.Width = 94
        '
        'colNovQty2
        '
        Me.colNovQty2.FieldName = "NovQty2"
        Me.colNovQty2.MinWidth = 25
        Me.colNovQty2.Name = "colNovQty2"
        Me.colNovQty2.Visible = True
        Me.colNovQty2.VisibleIndex = 63
        Me.colNovQty2.Width = 94
        '
        'colNovQty3
        '
        Me.colNovQty3.FieldName = "NovQty3"
        Me.colNovQty3.MinWidth = 25
        Me.colNovQty3.Name = "colNovQty3"
        Me.colNovQty3.Visible = True
        Me.colNovQty3.VisibleIndex = 64
        Me.colNovQty3.Width = 94
        '
        'colNovPO1
        '
        Me.colNovPO1.FieldName = "Nov PO1"
        Me.colNovPO1.MinWidth = 25
        Me.colNovPO1.Name = "colNovPO1"
        Me.colNovPO1.Visible = True
        Me.colNovPO1.VisibleIndex = 65
        Me.colNovPO1.Width = 94
        '
        'colNovPO2
        '
        Me.colNovPO2.FieldName = "Nov PO2"
        Me.colNovPO2.MinWidth = 25
        Me.colNovPO2.Name = "colNovPO2"
        Me.colNovPO2.Visible = True
        Me.colNovPO2.VisibleIndex = 66
        Me.colNovPO2.Width = 94
        '
        'colDesQty1
        '
        Me.colDesQty1.FieldName = "DesQty1"
        Me.colDesQty1.MinWidth = 25
        Me.colDesQty1.Name = "colDesQty1"
        Me.colDesQty1.Visible = True
        Me.colDesQty1.VisibleIndex = 67
        Me.colDesQty1.Width = 94
        '
        'colDesQty2
        '
        Me.colDesQty2.FieldName = "DesQty2"
        Me.colDesQty2.MinWidth = 25
        Me.colDesQty2.Name = "colDesQty2"
        Me.colDesQty2.Visible = True
        Me.colDesQty2.VisibleIndex = 68
        Me.colDesQty2.Width = 94
        '
        'colDesQty3
        '
        Me.colDesQty3.FieldName = "DesQty3"
        Me.colDesQty3.MinWidth = 25
        Me.colDesQty3.Name = "colDesQty3"
        Me.colDesQty3.Visible = True
        Me.colDesQty3.VisibleIndex = 69
        Me.colDesQty3.Width = 94
        '
        'colDesPO1
        '
        Me.colDesPO1.FieldName = "Des PO1"
        Me.colDesPO1.MinWidth = 25
        Me.colDesPO1.Name = "colDesPO1"
        Me.colDesPO1.Visible = True
        Me.colDesPO1.VisibleIndex = 70
        Me.colDesPO1.Width = 94
        '
        'colDesPO2
        '
        Me.colDesPO2.FieldName = "Des PO2"
        Me.colDesPO2.MinWidth = 25
        Me.colDesPO2.Name = "colDesPO2"
        Me.colDesPO2.Visible = True
        Me.colDesPO2.VisibleIndex = 71
        Me.colDesPO2.Width = 94
        '
        'colJanHarga1
        '
        Me.colJanHarga1.FieldName = "JanHarga1"
        Me.colJanHarga1.MinWidth = 25
        Me.colJanHarga1.Name = "colJanHarga1"
        Me.colJanHarga1.Visible = True
        Me.colJanHarga1.VisibleIndex = 72
        Me.colJanHarga1.Width = 94
        '
        'colJanHarga2
        '
        Me.colJanHarga2.FieldName = "JanHarga2"
        Me.colJanHarga2.MinWidth = 25
        Me.colJanHarga2.Name = "colJanHarga2"
        Me.colJanHarga2.Visible = True
        Me.colJanHarga2.VisibleIndex = 73
        Me.colJanHarga2.Width = 94
        '
        'colJanHarga3
        '
        Me.colJanHarga3.FieldName = "JanHarga3"
        Me.colJanHarga3.MinWidth = 25
        Me.colJanHarga3.Name = "colJanHarga3"
        Me.colJanHarga3.Visible = True
        Me.colJanHarga3.VisibleIndex = 74
        Me.colJanHarga3.Width = 94
        '
        'colFebHarga1
        '
        Me.colFebHarga1.FieldName = "FebHarga1"
        Me.colFebHarga1.MinWidth = 25
        Me.colFebHarga1.Name = "colFebHarga1"
        Me.colFebHarga1.Visible = True
        Me.colFebHarga1.VisibleIndex = 75
        Me.colFebHarga1.Width = 94
        '
        'colFebHarga2
        '
        Me.colFebHarga2.FieldName = "FebHarga2"
        Me.colFebHarga2.MinWidth = 25
        Me.colFebHarga2.Name = "colFebHarga2"
        Me.colFebHarga2.Visible = True
        Me.colFebHarga2.VisibleIndex = 76
        Me.colFebHarga2.Width = 94
        '
        'colFebHarga3
        '
        Me.colFebHarga3.FieldName = "FebHarga3"
        Me.colFebHarga3.MinWidth = 25
        Me.colFebHarga3.Name = "colFebHarga3"
        Me.colFebHarga3.Visible = True
        Me.colFebHarga3.VisibleIndex = 77
        Me.colFebHarga3.Width = 94
        '
        'colMarHarga1
        '
        Me.colMarHarga1.FieldName = "MarHarga1"
        Me.colMarHarga1.MinWidth = 25
        Me.colMarHarga1.Name = "colMarHarga1"
        Me.colMarHarga1.Visible = True
        Me.colMarHarga1.VisibleIndex = 78
        Me.colMarHarga1.Width = 94
        '
        'colMarHarga2
        '
        Me.colMarHarga2.FieldName = "MarHarga2"
        Me.colMarHarga2.MinWidth = 25
        Me.colMarHarga2.Name = "colMarHarga2"
        Me.colMarHarga2.Visible = True
        Me.colMarHarga2.VisibleIndex = 79
        Me.colMarHarga2.Width = 94
        '
        'colMarHarga3
        '
        Me.colMarHarga3.FieldName = "MarHarga3"
        Me.colMarHarga3.MinWidth = 25
        Me.colMarHarga3.Name = "colMarHarga3"
        Me.colMarHarga3.Visible = True
        Me.colMarHarga3.VisibleIndex = 80
        Me.colMarHarga3.Width = 94
        '
        'colAprHarga1
        '
        Me.colAprHarga1.FieldName = "AprHarga1"
        Me.colAprHarga1.MinWidth = 25
        Me.colAprHarga1.Name = "colAprHarga1"
        Me.colAprHarga1.Visible = True
        Me.colAprHarga1.VisibleIndex = 81
        Me.colAprHarga1.Width = 94
        '
        'colAprHarga2
        '
        Me.colAprHarga2.FieldName = "AprHarga2"
        Me.colAprHarga2.MinWidth = 25
        Me.colAprHarga2.Name = "colAprHarga2"
        Me.colAprHarga2.Visible = True
        Me.colAprHarga2.VisibleIndex = 82
        Me.colAprHarga2.Width = 94
        '
        'colAprHarga3
        '
        Me.colAprHarga3.FieldName = "AprHarga3"
        Me.colAprHarga3.MinWidth = 25
        Me.colAprHarga3.Name = "colAprHarga3"
        Me.colAprHarga3.Visible = True
        Me.colAprHarga3.VisibleIndex = 83
        Me.colAprHarga3.Width = 94
        '
        'colMeiHarga1
        '
        Me.colMeiHarga1.FieldName = "MeiHarga1"
        Me.colMeiHarga1.MinWidth = 25
        Me.colMeiHarga1.Name = "colMeiHarga1"
        Me.colMeiHarga1.Visible = True
        Me.colMeiHarga1.VisibleIndex = 84
        Me.colMeiHarga1.Width = 94
        '
        'colMeiHarga2
        '
        Me.colMeiHarga2.FieldName = "MeiHarga2"
        Me.colMeiHarga2.MinWidth = 25
        Me.colMeiHarga2.Name = "colMeiHarga2"
        Me.colMeiHarga2.Visible = True
        Me.colMeiHarga2.VisibleIndex = 85
        Me.colMeiHarga2.Width = 94
        '
        'colMeiHarga3
        '
        Me.colMeiHarga3.FieldName = "MeiHarga3"
        Me.colMeiHarga3.MinWidth = 25
        Me.colMeiHarga3.Name = "colMeiHarga3"
        Me.colMeiHarga3.Visible = True
        Me.colMeiHarga3.VisibleIndex = 86
        Me.colMeiHarga3.Width = 94
        '
        'colJunHarga1
        '
        Me.colJunHarga1.FieldName = "JunHarga1"
        Me.colJunHarga1.MinWidth = 25
        Me.colJunHarga1.Name = "colJunHarga1"
        Me.colJunHarga1.Visible = True
        Me.colJunHarga1.VisibleIndex = 87
        Me.colJunHarga1.Width = 94
        '
        'colJunHarga2
        '
        Me.colJunHarga2.FieldName = "JunHarga2"
        Me.colJunHarga2.MinWidth = 25
        Me.colJunHarga2.Name = "colJunHarga2"
        Me.colJunHarga2.Visible = True
        Me.colJunHarga2.VisibleIndex = 88
        Me.colJunHarga2.Width = 94
        '
        'colJunHarga3
        '
        Me.colJunHarga3.FieldName = "JunHarga3"
        Me.colJunHarga3.MinWidth = 25
        Me.colJunHarga3.Name = "colJunHarga3"
        Me.colJunHarga3.Visible = True
        Me.colJunHarga3.VisibleIndex = 89
        Me.colJunHarga3.Width = 94
        '
        'colJulHarga1
        '
        Me.colJulHarga1.FieldName = "JulHarga1"
        Me.colJulHarga1.MinWidth = 25
        Me.colJulHarga1.Name = "colJulHarga1"
        Me.colJulHarga1.Visible = True
        Me.colJulHarga1.VisibleIndex = 90
        Me.colJulHarga1.Width = 94
        '
        'colJulHarga2
        '
        Me.colJulHarga2.FieldName = "JulHarga2"
        Me.colJulHarga2.MinWidth = 25
        Me.colJulHarga2.Name = "colJulHarga2"
        Me.colJulHarga2.Visible = True
        Me.colJulHarga2.VisibleIndex = 91
        Me.colJulHarga2.Width = 94
        '
        'colJulHarga3
        '
        Me.colJulHarga3.FieldName = "JulHarga3"
        Me.colJulHarga3.MinWidth = 25
        Me.colJulHarga3.Name = "colJulHarga3"
        Me.colJulHarga3.Visible = True
        Me.colJulHarga3.VisibleIndex = 92
        Me.colJulHarga3.Width = 94
        '
        'colAgtHarga1
        '
        Me.colAgtHarga1.FieldName = "AgtHarga1"
        Me.colAgtHarga1.MinWidth = 25
        Me.colAgtHarga1.Name = "colAgtHarga1"
        Me.colAgtHarga1.Visible = True
        Me.colAgtHarga1.VisibleIndex = 93
        Me.colAgtHarga1.Width = 94
        '
        'colAgtHarga2
        '
        Me.colAgtHarga2.FieldName = "AgtHarga2"
        Me.colAgtHarga2.MinWidth = 25
        Me.colAgtHarga2.Name = "colAgtHarga2"
        Me.colAgtHarga2.Visible = True
        Me.colAgtHarga2.VisibleIndex = 94
        Me.colAgtHarga2.Width = 94
        '
        'colAgtHarga3
        '
        Me.colAgtHarga3.FieldName = "AgtHarga3"
        Me.colAgtHarga3.MinWidth = 25
        Me.colAgtHarga3.Name = "colAgtHarga3"
        Me.colAgtHarga3.Visible = True
        Me.colAgtHarga3.VisibleIndex = 95
        Me.colAgtHarga3.Width = 94
        '
        'colSepHarga1
        '
        Me.colSepHarga1.FieldName = "SepHarga1"
        Me.colSepHarga1.MinWidth = 25
        Me.colSepHarga1.Name = "colSepHarga1"
        Me.colSepHarga1.Visible = True
        Me.colSepHarga1.VisibleIndex = 96
        Me.colSepHarga1.Width = 94
        '
        'colSepHarga2
        '
        Me.colSepHarga2.FieldName = "SepHarga2"
        Me.colSepHarga2.MinWidth = 25
        Me.colSepHarga2.Name = "colSepHarga2"
        Me.colSepHarga2.Visible = True
        Me.colSepHarga2.VisibleIndex = 97
        Me.colSepHarga2.Width = 94
        '
        'colSepHarga3
        '
        Me.colSepHarga3.FieldName = "SepHarga3"
        Me.colSepHarga3.MinWidth = 25
        Me.colSepHarga3.Name = "colSepHarga3"
        Me.colSepHarga3.Visible = True
        Me.colSepHarga3.VisibleIndex = 98
        Me.colSepHarga3.Width = 94
        '
        'colOktHarga1
        '
        Me.colOktHarga1.FieldName = "OktHarga1"
        Me.colOktHarga1.MinWidth = 25
        Me.colOktHarga1.Name = "colOktHarga1"
        Me.colOktHarga1.Visible = True
        Me.colOktHarga1.VisibleIndex = 99
        Me.colOktHarga1.Width = 94
        '
        'colOktHarga2
        '
        Me.colOktHarga2.FieldName = "OktHarga2"
        Me.colOktHarga2.MinWidth = 25
        Me.colOktHarga2.Name = "colOktHarga2"
        Me.colOktHarga2.Visible = True
        Me.colOktHarga2.VisibleIndex = 100
        Me.colOktHarga2.Width = 94
        '
        'colOktHarga3
        '
        Me.colOktHarga3.FieldName = "OktHarga3"
        Me.colOktHarga3.MinWidth = 25
        Me.colOktHarga3.Name = "colOktHarga3"
        Me.colOktHarga3.Visible = True
        Me.colOktHarga3.VisibleIndex = 101
        Me.colOktHarga3.Width = 94
        '
        'colNovHarga1
        '
        Me.colNovHarga1.FieldName = "NovHarga1"
        Me.colNovHarga1.MinWidth = 25
        Me.colNovHarga1.Name = "colNovHarga1"
        Me.colNovHarga1.Visible = True
        Me.colNovHarga1.VisibleIndex = 102
        Me.colNovHarga1.Width = 94
        '
        'colNovHarga2
        '
        Me.colNovHarga2.FieldName = "NovHarga2"
        Me.colNovHarga2.MinWidth = 25
        Me.colNovHarga2.Name = "colNovHarga2"
        Me.colNovHarga2.Visible = True
        Me.colNovHarga2.VisibleIndex = 103
        Me.colNovHarga2.Width = 94
        '
        'colNovHarga3
        '
        Me.colNovHarga3.FieldName = "NovHarga3"
        Me.colNovHarga3.MinWidth = 25
        Me.colNovHarga3.Name = "colNovHarga3"
        Me.colNovHarga3.Visible = True
        Me.colNovHarga3.VisibleIndex = 104
        Me.colNovHarga3.Width = 94
        '
        'colDesHarga1
        '
        Me.colDesHarga1.FieldName = "DesHarga1"
        Me.colDesHarga1.MinWidth = 25
        Me.colDesHarga1.Name = "colDesHarga1"
        Me.colDesHarga1.Visible = True
        Me.colDesHarga1.VisibleIndex = 105
        Me.colDesHarga1.Width = 94
        '
        'colDesHarga2
        '
        Me.colDesHarga2.FieldName = "DesHarga2"
        Me.colDesHarga2.MinWidth = 25
        Me.colDesHarga2.Name = "colDesHarga2"
        Me.colDesHarga2.Visible = True
        Me.colDesHarga2.VisibleIndex = 106
        Me.colDesHarga2.Width = 94
        '
        'colDesHarga3
        '
        Me.colDesHarga3.FieldName = "DesHarga3"
        Me.colDesHarga3.MinWidth = 25
        Me.colDesHarga3.Name = "colDesHarga3"
        Me.colDesHarga3.Visible = True
        Me.colDesHarga3.VisibleIndex = 107
        Me.colDesHarga3.Width = 94
        '
        'cmbBulan
        '
        Me.cmbBulan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBulan.FormattingEnabled = True
        Me.cmbBulan.Location = New System.Drawing.Point(762, 38)
        Me.cmbBulan.Name = "cmbBulan"
        Me.cmbBulan.Size = New System.Drawing.Size(121, 24)
        Me.cmbBulan.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(705, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bulan"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'frmFPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 495)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbBulan)
        Me.Controls.Add(Me.TForecastPrice1GridControl)
        Me.Controls.Add(Me.TForecastPrice1BindingNavigator)
        Me.Name = "frmFPrice"
        Me.Text = "FORECAST PRICE"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TForecastPrice1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TForecastPrice1BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TForecastPrice1BindingNavigator.ResumeLayout(False)
        Me.TForecastPrice1BindingNavigator.PerformLayout()
        CType(Me.TForecastPrice1GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents TForecastPrice1BindingSource As BindingSource
    Friend WithEvents TForecastPrice1TableAdapter As DataSet1TableAdapters.tForecastPrice1TableAdapter
    Friend WithEvents TableAdapterManager As DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents TForecastPrice1BindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents TForecastPrice1BindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents TForecastPrice1GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTahun As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInvtID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colModel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFlag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesPO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesPO2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJanHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAprHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeiHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgtHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSepHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOktHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNovHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesHarga1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesHarga2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesHarga3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbImport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbRefresh As ToolStripButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CekHargaBedaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CekInventory1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbBulan As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
