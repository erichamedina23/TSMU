<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTravelSettle
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TravelSettleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TravelID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TravelerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeptID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Destination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DepartureDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ArrivalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAdvanceIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalSettIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAdvanceUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalSettUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAdvanceYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalSettYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAmountAdvanceIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalAmountSettIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 37)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1371, 719)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Grid)
        Me.XtraTabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1364, 685)
        Me.XtraTabPage1.Text = "Settlement"
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
        Me.Grid.Size = New System.Drawing.Size(1355, 673)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TravelSettleID, Me.TravelID, Me.GridColumn4, Me.TravelerName, Me.DeptID, Me.Destination, Me.DepartureDate, Me.ArrivalDate, Me.TotalAdvanceIDR, Me.TotalSettIDR, Me.TotalAdvanceUSD, Me.TotalSettUSD, Me.TotalAdvanceYEN, Me.TotalSettYEN, Me.TotalAmountAdvanceIDR, Me.TotalAmountSettIDR})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TravelSettleID
        '
        Me.TravelSettleID.Caption = "Travel Settlement ID"
        Me.TravelSettleID.FieldName = "TravelSettleID"
        Me.TravelSettleID.MinWidth = 27
        Me.TravelSettleID.Name = "TravelSettleID"
        Me.TravelSettleID.OptionsColumn.FixedWidth = True
        Me.TravelSettleID.Visible = True
        Me.TravelSettleID.VisibleIndex = 0
        Me.TravelSettleID.Width = 130
        '
        'TravelID
        '
        Me.TravelID.Caption = "Travel No."
        Me.TravelID.FieldName = "TravelID"
        Me.TravelID.MinWidth = 27
        Me.TravelID.Name = "TravelID"
        Me.TravelID.OptionsColumn.AllowEdit = False
        Me.TravelID.OptionsColumn.FixedWidth = True
        Me.TravelID.Visible = True
        Me.TravelID.VisibleIndex = 1
        Me.TravelID.Width = 130
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
        'TravelerName
        '
        Me.TravelerName.Caption = "TravelName"
        Me.TravelerName.FieldName = "Nama"
        Me.TravelerName.MinWidth = 27
        Me.TravelerName.Name = "TravelerName"
        Me.TravelerName.OptionsColumn.AllowEdit = False
        Me.TravelerName.OptionsColumn.FixedWidth = True
        Me.TravelerName.Visible = True
        Me.TravelerName.VisibleIndex = 2
        Me.TravelerName.Width = 267
        '
        'DeptID
        '
        Me.DeptID.Caption = "Department"
        Me.DeptID.FieldName = "DeptID"
        Me.DeptID.MinWidth = 27
        Me.DeptID.Name = "DeptID"
        Me.DeptID.OptionsColumn.AllowEdit = False
        Me.DeptID.OptionsColumn.FixedWidth = True
        Me.DeptID.Visible = True
        Me.DeptID.VisibleIndex = 3
        Me.DeptID.Width = 100
        '
        'Destination
        '
        Me.Destination.Caption = "Destination"
        Me.Destination.FieldName = "Destination"
        Me.Destination.MinWidth = 27
        Me.Destination.Name = "Destination"
        Me.Destination.OptionsColumn.AllowEdit = False
        Me.Destination.OptionsColumn.FixedWidth = True
        Me.Destination.Visible = True
        Me.Destination.VisibleIndex = 4
        Me.Destination.Width = 133
        '
        'DepartureDate
        '
        Me.DepartureDate.Caption = "Departure Date"
        Me.DepartureDate.FieldName = "TglBerangkat"
        Me.DepartureDate.MinWidth = 27
        Me.DepartureDate.Name = "DepartureDate"
        Me.DepartureDate.OptionsColumn.AllowEdit = False
        Me.DepartureDate.OptionsColumn.FixedWidth = True
        Me.DepartureDate.Visible = True
        Me.DepartureDate.VisibleIndex = 5
        Me.DepartureDate.Width = 107
        '
        'ArrivalDate
        '
        Me.ArrivalDate.Caption = "Arrival Date"
        Me.ArrivalDate.FieldName = "TglTiba"
        Me.ArrivalDate.MinWidth = 27
        Me.ArrivalDate.Name = "ArrivalDate"
        Me.ArrivalDate.Visible = True
        Me.ArrivalDate.VisibleIndex = 6
        Me.ArrivalDate.Width = 100
        '
        'TotalAdvanceIDR
        '
        Me.TotalAdvanceIDR.Caption = "Total Advance IDR"
        Me.TotalAdvanceIDR.FieldName = "TotalAdvanceIDR"
        Me.TotalAdvanceIDR.MinWidth = 25
        Me.TotalAdvanceIDR.Name = "TotalAdvanceIDR"
        Me.TotalAdvanceIDR.Width = 94
        '
        'TotalSettIDR
        '
        Me.TotalSettIDR.Caption = "Total Settlement IDR"
        Me.TotalSettIDR.FieldName = "TotalSettIDR"
        Me.TotalSettIDR.MinWidth = 25
        Me.TotalSettIDR.Name = "TotalSettIDR"
        Me.TotalSettIDR.Width = 94
        '
        'TotalAdvanceUSD
        '
        Me.TotalAdvanceUSD.Caption = "Total Advance USD"
        Me.TotalAdvanceUSD.FieldName = "TotalAdvanceUSD"
        Me.TotalAdvanceUSD.MinWidth = 25
        Me.TotalAdvanceUSD.Name = "TotalAdvanceUSD"
        Me.TotalAdvanceUSD.Width = 94
        '
        'TotalSettUSD
        '
        Me.TotalSettUSD.Caption = "Total Settlement USD"
        Me.TotalSettUSD.FieldName = "TotalSettUSD"
        Me.TotalSettUSD.MinWidth = 25
        Me.TotalSettUSD.Name = "TotalSettUSD"
        Me.TotalSettUSD.Width = 94
        '
        'TotalAdvanceYEN
        '
        Me.TotalAdvanceYEN.Caption = "Total Advance YEN"
        Me.TotalAdvanceYEN.FieldName = "TotalAdvanceYEN"
        Me.TotalAdvanceYEN.MinWidth = 25
        Me.TotalAdvanceYEN.Name = "TotalAdvanceYEN"
        Me.TotalAdvanceYEN.Width = 94
        '
        'TotalSettYEN
        '
        Me.TotalSettYEN.Caption = "Total Settlement YEN"
        Me.TotalSettYEN.FieldName = "TotalSettYEN"
        Me.TotalSettYEN.MinWidth = 25
        Me.TotalSettYEN.Name = "TotalSettYEN"
        Me.TotalSettYEN.Width = 94
        '
        'TotalAmountAdvanceIDR
        '
        Me.TotalAmountAdvanceIDR.Caption = "Amount Advance IDR"
        Me.TotalAmountAdvanceIDR.FieldName = "TotalAdvIDR"
        Me.TotalAmountAdvanceIDR.MinWidth = 27
        Me.TotalAmountAdvanceIDR.Name = "TotalAmountAdvanceIDR"
        Me.TotalAmountAdvanceIDR.OptionsColumn.AllowEdit = False
        Me.TotalAmountAdvanceIDR.OptionsColumn.FixedWidth = True
        Me.TotalAmountAdvanceIDR.Visible = True
        Me.TotalAmountAdvanceIDR.VisibleIndex = 7
        Me.TotalAmountAdvanceIDR.Width = 140
        '
        'TotalAmountSettIDR
        '
        Me.TotalAmountSettIDR.Caption = "Amount Actual IDR"
        Me.TotalAmountSettIDR.FieldName = "GrandTotalSettIDR"
        Me.TotalAmountSettIDR.MinWidth = 25
        Me.TotalAmountSettIDR.Name = "TotalAmountSettIDR"
        Me.TotalAmountSettIDR.Visible = True
        Me.TotalAmountSettIDR.VisibleIndex = 8
        Me.TotalAmountSettIDR.Width = 140
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridControl1)
        Me.XtraTabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1364, 685)
        Me.XtraTabPage2.Text = "Settlement Paid"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(7, 4)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1350, 668)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView2.DetailHeight = 458
        Me.GridView2.FixedLineWidth = 3
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID"
        Me.GridColumn11.FieldName = "ID"
        Me.GridColumn11.MinWidth = 27
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Settle ID"
        Me.GridColumn12.FieldName = "SettleID"
        Me.GridColumn12.MinWidth = 27
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 133
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Suspend ID"
        Me.GridColumn13.FieldName = "SuspendID"
        Me.GridColumn13.MinWidth = 27
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 133
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Department"
        Me.GridColumn14.FieldName = "DeptID"
        Me.GridColumn14.MinWidth = 27
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 100
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Remark"
        Me.GridColumn15.FieldName = "Remark"
        Me.GridColumn15.MinWidth = 27
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        Me.GridColumn15.Width = 267
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Date"
        Me.GridColumn16.FieldName = "Tgl"
        Me.GridColumn16.MinWidth = 27
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 5
        Me.GridColumn16.Width = 107
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Currency"
        Me.GridColumn17.FieldName = "CuryID"
        Me.GridColumn17.MinWidth = 27
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.FixedWidth = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 6
        Me.GridColumn17.Width = 67
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Amount"
        Me.GridColumn18.FieldName = "Total"
        Me.GridColumn18.MinWidth = 27
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.FixedWidth = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 7
        Me.GridColumn18.Width = 133
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Suspend Amount"
        Me.GridColumn19.FieldName = "SuspendAmount"
        Me.GridColumn19.MinWidth = 27
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 8
        Me.GridColumn19.Width = 100
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Settle Amount"
        Me.GridColumn20.FieldName = "SettleAmount"
        Me.GridColumn20.MinWidth = 27
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 9
        Me.GridColumn20.Width = 100
        '
        'FrmTravelSettle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1387, 760)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmTravelSettle"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TravelSettleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TravelID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeptID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Destination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TravelerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DepartureDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ArrivalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAmountAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalSettIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAdvanceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalSettUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAdvanceYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalSettYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalAmountSettIDR As DevExpress.XtraGrid.Columns.GridColumn
End Class
