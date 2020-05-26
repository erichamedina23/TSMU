<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTravelRequest
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
        Me.GridApprovedReq = New DevExpress.XtraGrid.GridControl()
        Me.GridViewApproved = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CApproved = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.GridRequestAll = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPageApproved = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.GridApprovedReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TabPageRequest.SuspendLayout()
        CType(Me.GridRequestAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageApproved.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridApprovedReq
        '
        Me.GridApprovedReq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridApprovedReq.Location = New System.Drawing.Point(3, 3)
        Me.GridApprovedReq.MainView = Me.GridViewApproved
        Me.GridApprovedReq.Name = "GridApprovedReq"
        Me.GridApprovedReq.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CApproved})
        Me.GridApprovedReq.Size = New System.Drawing.Size(1149, 480)
        Me.GridApprovedReq.TabIndex = 1
        Me.GridApprovedReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewApproved})
        '
        'GridViewApproved
        '
        Me.GridViewApproved.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn19, Me.GridColumn20})
        Me.GridViewApproved.GridControl = Me.GridApprovedReq
        Me.GridViewApproved.Name = "GridViewApproved"
        Me.GridViewApproved.OptionsView.ShowAutoFilterRow = True
        Me.GridViewApproved.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No Request"
        Me.GridColumn1.FieldName = "NoRequest"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 130
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIK"
        Me.GridColumn2.FieldName = "NIK"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 100
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Nama"
        Me.GridColumn3.FieldName = "Nama"
        Me.GridColumn3.MinWidth = 25
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 200
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Tanggal"
        Me.GridColumn4.FieldName = "Date"
        Me.GridColumn4.MinWidth = 25
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 110
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Dept ID"
        Me.GridColumn5.FieldName = "DeptID"
        Me.GridColumn5.MinWidth = 25
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 70
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Travel Type"
        Me.GridColumn6.FieldName = "TravelType"
        Me.GridColumn6.MinWidth = 25
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.FixedWidth = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 90
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Golongan"
        Me.GridColumn7.FieldName = "Golongan"
        Me.GridColumn7.MinWidth = 25
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 80
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Purpose"
        Me.GridColumn8.FieldName = "Purpose"
        Me.GridColumn8.MinWidth = 25
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 500
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Approved"
        Me.GridColumn19.ColumnEdit = Me.CApproved
        Me.GridColumn19.FieldName = "Approved"
        Me.GridColumn19.MinWidth = 25
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.FixedWidth = True
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 8
        Me.GridColumn19.Width = 120
        '
        'CApproved
        '
        Me.CApproved.AutoHeight = False
        Me.CApproved.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CApproved.Items.AddRange(New Object() {"APPROVED", "REVISED", "REJECT"})
        Me.CApproved.Name = "CApproved"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Comment"
        Me.GridColumn20.FieldName = "Comment"
        Me.GridColumn20.MinWidth = 25
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 9
        Me.GridColumn20.Width = 500
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(12, 39)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.TabPageRequest
        Me.XtraTabControl1.Size = New System.Drawing.Size(1162, 520)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageRequest, Me.TabPageApproved})
        '
        'TabPageRequest
        '
        Me.TabPageRequest.Controls.Add(Me.GridRequestAll)
        Me.TabPageRequest.Name = "TabPageRequest"
        Me.TabPageRequest.Size = New System.Drawing.Size(1155, 486)
        Me.TabPageRequest.Text = "Travel Request"
        '
        'GridRequestAll
        '
        Me.GridRequestAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRequestAll.Location = New System.Drawing.Point(3, 3)
        Me.GridRequestAll.MainView = Me.GridViewAll
        Me.GridRequestAll.Name = "GridRequestAll"
        Me.GridRequestAll.Size = New System.Drawing.Size(1149, 480)
        Me.GridRequestAll.TabIndex = 2
        Me.GridRequestAll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAll})
        '
        'GridViewAll
        '
        Me.GridViewAll.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18})
        Me.GridViewAll.GridControl = Me.GridRequestAll
        Me.GridViewAll.Name = "GridViewAll"
        Me.GridViewAll.OptionsBehavior.Editable = False
        Me.GridViewAll.OptionsView.ColumnAutoWidth = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "No Request"
        Me.GridColumn10.FieldName = "NoRequest"
        Me.GridColumn10.MinWidth = 25
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.FixedWidth = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 130
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "NIK"
        Me.GridColumn11.FieldName = "NIK"
        Me.GridColumn11.MinWidth = 25
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Nama"
        Me.GridColumn12.FieldName = "Nama"
        Me.GridColumn12.MinWidth = 25
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 200
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Tanggal"
        Me.GridColumn13.FieldName = "Date"
        Me.GridColumn13.MinWidth = 25
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        Me.GridColumn13.Width = 110
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Dept ID"
        Me.GridColumn14.FieldName = "DeptID"
        Me.GridColumn14.MinWidth = 25
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 70
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Travel Type"
        Me.GridColumn15.FieldName = "TravelType"
        Me.GridColumn15.MinWidth = 25
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        Me.GridColumn15.Width = 90
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Golongan"
        Me.GridColumn16.FieldName = "Golongan"
        Me.GridColumn16.MinWidth = 25
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 6
        Me.GridColumn16.Width = 80
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Purpose"
        Me.GridColumn17.FieldName = "Purpose"
        Me.GridColumn17.MinWidth = 25
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 7
        Me.GridColumn17.Width = 500
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Status"
        Me.GridColumn18.FieldName = "Status"
        Me.GridColumn18.MinWidth = 25
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.FixedWidth = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 8
        Me.GridColumn18.Width = 80
        '
        'TabPageApproved
        '
        Me.TabPageApproved.Controls.Add(Me.GridApprovedReq)
        Me.TabPageApproved.Name = "TabPageApproved"
        Me.TabPageApproved.Size = New System.Drawing.Size(1155, 486)
        Me.TabPageApproved.Text = "Approved Request"
        '
        'FrmTravelRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1186, 564)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FrmTravelRequest"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.GridApprovedReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TabPageRequest.ResumeLayout(False)
        CType(Me.GridRequestAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageApproved.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridApprovedReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewApproved As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridRequestAll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPageApproved As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CApproved As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
