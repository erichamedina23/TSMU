<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravel
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountIDRGrid1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountUSDGrid1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountYENGrid1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAmountIDRGrid1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridApprove = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountIDRApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountUSDApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountYENApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAmountIDRApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCheckApprove = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridApprove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCheckApprove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(16, 37)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1088, 719)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Grid)
        Me.XtraTabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1081, 685)
        Me.XtraTabPage1.Text = "Advance"
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Location = New System.Drawing.Point(4, 5)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1072, 673)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn3, Me.AmountIDRGrid1, Me.AmountUSDGrid1, Me.AmountYENGrid1, Me.TotalAmountIDRGrid1, Me.Status})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "SuspendHeaderID"
        Me.GridColumn1.MinWidth = 27
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Travel No."
        Me.GridColumn2.FieldName = "TravelID"
        Me.GridColumn2.MinWidth = 27
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 133
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Currency"
        Me.GridColumn4.FieldName = "CuryID"
        Me.GridColumn4.MinWidth = 27
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Width = 100
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Department"
        Me.GridColumn5.FieldName = "DeptID"
        Me.GridColumn5.MinWidth = 27
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 140
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Destination"
        Me.GridColumn6.FieldName = "Destination"
        Me.GridColumn6.MinWidth = 27
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.FixedWidth = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 150
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Traveler Name"
        Me.GridColumn7.FieldName = "Nama"
        Me.GridColumn7.MinWidth = 27
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 350
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Departure Date"
        Me.GridColumn8.FieldName = "TglBerangkat"
        Me.GridColumn8.MinWidth = 27
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.FixedWidth = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        Me.GridColumn8.Width = 130
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Arrival Date"
        Me.GridColumn3.FieldName = "TglTiba"
        Me.GridColumn3.MinWidth = 27
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 5
        Me.GridColumn3.Width = 130
        '
        'AmountIDRGrid1
        '
        Me.AmountIDRGrid1.Caption = "Amount IDR"
        Me.AmountIDRGrid1.FieldName = "TotalAdvanceIDR"
        Me.AmountIDRGrid1.MinWidth = 25
        Me.AmountIDRGrid1.Name = "AmountIDRGrid1"
        Me.AmountIDRGrid1.OptionsColumn.AllowEdit = False
        Me.AmountIDRGrid1.OptionsColumn.FixedWidth = True
        Me.AmountIDRGrid1.Visible = True
        Me.AmountIDRGrid1.VisibleIndex = 6
        Me.AmountIDRGrid1.Width = 130
        '
        'AmountUSDGrid1
        '
        Me.AmountUSDGrid1.Caption = "Amount USD"
        Me.AmountUSDGrid1.FieldName = "TotalAdvanceUSD"
        Me.AmountUSDGrid1.MinWidth = 25
        Me.AmountUSDGrid1.Name = "AmountUSDGrid1"
        Me.AmountUSDGrid1.OptionsColumn.AllowEdit = False
        Me.AmountUSDGrid1.OptionsColumn.FixedWidth = True
        Me.AmountUSDGrid1.Visible = True
        Me.AmountUSDGrid1.VisibleIndex = 7
        Me.AmountUSDGrid1.Width = 130
        '
        'AmountYENGrid1
        '
        Me.AmountYENGrid1.Caption = "Amount YEN"
        Me.AmountYENGrid1.FieldName = "TotalAdvanceYEN"
        Me.AmountYENGrid1.MinWidth = 25
        Me.AmountYENGrid1.Name = "AmountYENGrid1"
        Me.AmountYENGrid1.OptionsColumn.AllowEdit = False
        Me.AmountYENGrid1.OptionsColumn.FixedWidth = True
        Me.AmountYENGrid1.Visible = True
        Me.AmountYENGrid1.VisibleIndex = 8
        Me.AmountYENGrid1.Width = 130
        '
        'TotalAmountIDRGrid1
        '
        Me.TotalAmountIDRGrid1.Caption = "Total Amount IDR"
        Me.TotalAmountIDRGrid1.FieldName = "TotalAdvIDR"
        Me.TotalAmountIDRGrid1.MinWidth = 27
        Me.TotalAmountIDRGrid1.Name = "TotalAmountIDRGrid1"
        Me.TotalAmountIDRGrid1.OptionsColumn.AllowEdit = False
        Me.TotalAmountIDRGrid1.OptionsColumn.FixedWidth = True
        Me.TotalAmountIDRGrid1.Visible = True
        Me.TotalAmountIDRGrid1.VisibleIndex = 9
        Me.TotalAmountIDRGrid1.Width = 130
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.MinWidth = 25
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 10
        Me.Status.Width = 94
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridApprove)
        Me.XtraTabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1081, 685)
        Me.XtraTabPage2.Text = "Advance Approved"
        '
        'GridApprove
        '
        Me.GridApprove.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridApprove.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridApprove.Location = New System.Drawing.Point(4, 5)
        Me.GridApprove.MainView = Me.GridView2
        Me.GridApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.GridApprove.Name = "GridApprove"
        Me.GridApprove.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCheckApprove})
        Me.GridApprove.Size = New System.Drawing.Size(1072, 673)
        Me.GridApprove.TabIndex = 3
        Me.GridApprove.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn18, Me.AmountIDRApprove, Me.AmountUSDApprove, Me.AmountYENApprove, Me.TotalAmountIDRApprove, Me.CheckApprove})
        Me.GridView2.DetailHeight = 458
        Me.GridView2.FixedLineWidth = 3
        Me.GridView2.GridControl = Me.GridApprove
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "SuspendHeaderID"
        Me.GridColumn9.MinWidth = 27
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.FixedWidth = True
        Me.GridColumn9.Width = 100
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Travel No."
        Me.GridColumn11.FieldName = "TravelID"
        Me.GridColumn11.MinWidth = 27
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 133
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Currency"
        Me.GridColumn12.FieldName = "CuryID"
        Me.GridColumn12.MinWidth = 27
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Width = 100
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Department"
        Me.GridColumn13.FieldName = "DeptID"
        Me.GridColumn13.MinWidth = 27
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 140
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Destination"
        Me.GridColumn14.FieldName = "Destination"
        Me.GridColumn14.MinWidth = 27
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 2
        Me.GridColumn14.Width = 150
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Traveler Name"
        Me.GridColumn15.FieldName = "Nama"
        Me.GridColumn15.MinWidth = 27
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        Me.GridColumn15.Width = 350
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Departure Date"
        Me.GridColumn16.FieldName = "TglBerangkat"
        Me.GridColumn16.MinWidth = 27
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 4
        Me.GridColumn16.Width = 130
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Arrival Date"
        Me.GridColumn18.FieldName = "TglTiba"
        Me.GridColumn18.MinWidth = 27
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 5
        Me.GridColumn18.Width = 130
        '
        'AmountIDRApprove
        '
        Me.AmountIDRApprove.Caption = "Amount IDR"
        Me.AmountIDRApprove.FieldName = "TotalAdvanceIDR"
        Me.AmountIDRApprove.MinWidth = 25
        Me.AmountIDRApprove.Name = "AmountIDRApprove"
        Me.AmountIDRApprove.OptionsColumn.AllowEdit = False
        Me.AmountIDRApprove.OptionsColumn.FixedWidth = True
        Me.AmountIDRApprove.Visible = True
        Me.AmountIDRApprove.VisibleIndex = 6
        Me.AmountIDRApprove.Width = 130
        '
        'AmountUSDApprove
        '
        Me.AmountUSDApprove.Caption = "Amount USD"
        Me.AmountUSDApprove.FieldName = "TotalAdvanceUSD"
        Me.AmountUSDApprove.MinWidth = 25
        Me.AmountUSDApprove.Name = "AmountUSDApprove"
        Me.AmountUSDApprove.OptionsColumn.AllowEdit = False
        Me.AmountUSDApprove.OptionsColumn.FixedWidth = True
        Me.AmountUSDApprove.Visible = True
        Me.AmountUSDApprove.VisibleIndex = 7
        Me.AmountUSDApprove.Width = 130
        '
        'AmountYENApprove
        '
        Me.AmountYENApprove.Caption = "Amount YEN"
        Me.AmountYENApprove.FieldName = "TotalAdvanceYEN"
        Me.AmountYENApprove.MinWidth = 25
        Me.AmountYENApprove.Name = "AmountYENApprove"
        Me.AmountYENApprove.OptionsColumn.AllowEdit = False
        Me.AmountYENApprove.OptionsColumn.FixedWidth = True
        Me.AmountYENApprove.Visible = True
        Me.AmountYENApprove.VisibleIndex = 8
        Me.AmountYENApprove.Width = 130
        '
        'TotalAmountIDRApprove
        '
        Me.TotalAmountIDRApprove.Caption = "Total Amount IDR"
        Me.TotalAmountIDRApprove.FieldName = "TotalAdvIDR"
        Me.TotalAmountIDRApprove.MinWidth = 27
        Me.TotalAmountIDRApprove.Name = "TotalAmountIDRApprove"
        Me.TotalAmountIDRApprove.OptionsColumn.AllowEdit = False
        Me.TotalAmountIDRApprove.OptionsColumn.FixedWidth = True
        Me.TotalAmountIDRApprove.Visible = True
        Me.TotalAmountIDRApprove.VisibleIndex = 9
        Me.TotalAmountIDRApprove.Width = 130
        '
        'CheckApprove
        '
        Me.CheckApprove.Caption = "Check"
        Me.CheckApprove.ColumnEdit = Me.CCheckApprove
        Me.CheckApprove.FieldName = "CheckList"
        Me.CheckApprove.MinWidth = 25
        Me.CheckApprove.Name = "CheckApprove"
        Me.CheckApprove.Visible = True
        Me.CheckApprove.VisibleIndex = 10
        Me.CheckApprove.Width = 94
        '
        'CCheckApprove
        '
        Me.CCheckApprove.AutoHeight = False
        Me.CCheckApprove.Name = "CCheckApprove"
        '
        'FrmTravel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 760)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmTravel"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridApprove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCheckApprove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAmountIDRGrid1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridApprove As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAmountIDRApprove As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckApprove As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCheckApprove As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountIDRGrid1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountUSDGrid1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountYENGrid1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountIDRApprove As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountUSDApprove As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountYENApprove As DevExpress.XtraGrid.Columns.GridColumn
End Class
