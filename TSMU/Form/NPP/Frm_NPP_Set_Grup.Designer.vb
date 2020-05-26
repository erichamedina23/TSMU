<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NPP_Set_Grup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SingleCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSetGroup = New System.Windows.Forms.Button()
        Me.TGroupID = New DevExpress.XtraEditors.TextEdit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SingleCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TGroupID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 39)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SingleCheck})
        Me.Grid.Size = New System.Drawing.Size(732, 367)
        Me.Grid.TabIndex = 8
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PartNo, Me.PartName, Me.GridColumn2, Me.GridColumn1})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PartNo
        '
        Me.PartNo.FieldName = "Part No"
        Me.PartNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.PartNo.Name = "PartNo"
        Me.PartNo.OptionsColumn.AllowEdit = False
        Me.PartNo.Visible = True
        Me.PartNo.VisibleIndex = 0
        Me.PartNo.Width = 184
        '
        'PartName
        '
        Me.PartName.FieldName = "Part Name"
        Me.PartName.Name = "PartName"
        Me.PartName.Visible = True
        Me.PartName.VisibleIndex = 1
        Me.PartName.Width = 303
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.ColumnEdit = Me.SingleCheck
        Me.GridColumn2.FieldName = "Check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'SingleCheck
        '
        Me.SingleCheck.AutoHeight = False
        Me.SingleCheck.Name = "SingleCheck"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "Group ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 149
        '
        'BSetGroup
        '
        Me.BSetGroup.Location = New System.Drawing.Point(12, 10)
        Me.BSetGroup.Name = "BSetGroup"
        Me.BSetGroup.Size = New System.Drawing.Size(75, 23)
        Me.BSetGroup.TabIndex = 9
        Me.BSetGroup.Text = "Update"
        Me.BSetGroup.UseVisualStyleBackColor = True
        '
        'TGroupID
        '
        Me.TGroupID.Location = New System.Drawing.Point(94, 10)
        Me.TGroupID.Name = "TGroupID"
        Me.TGroupID.Properties.MaxLength = 5
        Me.TGroupID.Size = New System.Drawing.Size(223, 20)
        Me.TGroupID.TabIndex = 10
        '
        'Frm_NPP_Set_Grup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 418)
        Me.Controls.Add(Me.TGroupID)
        Me.Controls.Add(Me.BSetGroup)
        Me.Controls.Add(Me.Grid)
        Me.Name = "Frm_NPP_Set_Grup"
        Me.Text = "Form Set Group Npp"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SingleCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TGroupID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Public WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SingleCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSetGroup As Button
    Friend WithEvents TGroupID As DevExpress.XtraEditors.TextEdit
End Class
