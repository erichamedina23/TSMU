<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSales_ForecastPrice
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelTSM = New System.Windows.Forms.ToolStripMenuItem()
        Me.CekHargaADMTSM = New System.Windows.Forms.ToolStripMenuItem()
        Me.CekInventory1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SinkronasiDataTsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(0, 25)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(828, 556)
        Me.Grid.TabIndex = 1
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelTSM, Me.CekHargaADMTSM, Me.CekInventory1ToolStripMenuItem, Me.SinkronasiDataTsm})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(211, 92)
        '
        'ExportToExcelTSM
        '
        Me.ExportToExcelTSM.Name = "ExportToExcelTSM"
        Me.ExportToExcelTSM.Size = New System.Drawing.Size(210, 22)
        Me.ExportToExcelTSM.Text = "Export To Excel"
        '
        'CekHargaADMTSM
        '
        Me.CekHargaADMTSM.Name = "CekHargaADMTSM"
        Me.CekHargaADMTSM.Size = New System.Drawing.Size(210, 22)
        Me.CekHargaADMTSM.Text = "Cek Harga SAP-KAP ADM"
        Me.CekHargaADMTSM.Visible = False
        '
        'CekInventory1ToolStripMenuItem
        '
        Me.CekInventory1ToolStripMenuItem.Name = "CekInventory1ToolStripMenuItem"
        Me.CekInventory1ToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CekInventory1ToolStripMenuItem.Text = "Cek Inventory > 1"
        Me.CekInventory1ToolStripMenuItem.Visible = False
        '
        'SinkronasiDataTsm
        '
        Me.SinkronasiDataTsm.Name = "SinkronasiDataTsm"
        Me.SinkronasiDataTsm.Size = New System.Drawing.Size(210, 22)
        Me.SinkronasiDataTsm.Text = "Sinkronasi Data"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsPrint.PrintHorzLines = False
        Me.GridView1.OptionsPrint.PrintVertLines = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'frmSales_ForecastPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.Grid)
        Me.KeyPreview = True
        Me.Name = "frmSales_ForecastPrice"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ExportToExcelTSM As ToolStripMenuItem
    Friend WithEvents CekHargaADMTSM As ToolStripMenuItem
    Friend WithEvents CekInventory1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SinkronasiDataTsm As ToolStripMenuItem
End Class
