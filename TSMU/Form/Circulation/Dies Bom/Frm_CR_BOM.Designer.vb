<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CR_BOM
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
        Me.No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Qty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Price = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Amount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Amount_Barang = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.BAddRows = New System.Windows.Forms.Button()
        Me.BSave = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 37)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.C_Qty, Me.C_Price, Me.C_Amount, Me.C_Amount_Barang, Me.RepositoryItemSpinEdit1})
        Me.Grid.Size = New System.Drawing.Size(844, 506)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.No, Me.PartNo, Me.PartName, Me.Qty})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'No
        '
        Me.No.AppearanceCell.Options.UseTextOptions = True
        Me.No.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.AppearanceHeader.Options.UseTextOptions = True
        Me.No.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.FieldName = "No"
        Me.No.Name = "No"
        Me.No.OptionsColumn.AllowEdit = False
        Me.No.Visible = True
        Me.No.VisibleIndex = 0
        Me.No.Width = 62
        '
        'PartNo
        '
        Me.PartNo.FieldName = "PartNo"
        Me.PartNo.Name = "PartNo"
        Me.PartNo.Visible = True
        Me.PartNo.VisibleIndex = 1
        Me.PartNo.Width = 334
        '
        'PartName
        '
        Me.PartName.FieldName = "PartName"
        Me.PartName.Name = "PartName"
        Me.PartName.Visible = True
        Me.PartName.VisibleIndex = 2
        Me.PartName.Width = 533
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 3
        Me.Qty.Width = 139
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'C_Qty
        '
        Me.C_Qty.Appearance.Options.UseTextOptions = True
        Me.C_Qty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Qty.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.C_Qty.AutoHeight = False
        Me.C_Qty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Qty.Name = "C_Qty"
        '
        'C_Price
        '
        Me.C_Price.Appearance.Options.UseTextOptions = True
        Me.C_Price.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Price.AutoHeight = False
        Me.C_Price.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Price.Name = "C_Price"
        '
        'C_Amount
        '
        Me.C_Amount.Appearance.Options.UseTextOptions = True
        Me.C_Amount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Amount.AutoHeight = False
        Me.C_Amount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount.Name = "C_Amount"
        '
        'C_Amount_Barang
        '
        Me.C_Amount_Barang.AutoHeight = False
        Me.C_Amount_Barang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount_Barang.Name = "C_Amount_Barang"
        '
        'BAddRows
        '
        Me.BAddRows.Location = New System.Drawing.Point(12, 8)
        Me.BAddRows.Name = "BAddRows"
        Me.BAddRows.Size = New System.Drawing.Size(75, 23)
        Me.BAddRows.TabIndex = 4
        Me.BAddRows.Text = "Add Rows"
        Me.BAddRows.UseVisualStyleBackColor = True
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(93, 8)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        Me.BSave.UseVisualStyleBackColor = True
        '
        'Frm_CR_BOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 555)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.BAddRows)
        Me.Controls.Add(Me.Grid)
        Me.Name = "Frm_CR_BOM"
        Me.Text = "Frm_CR_BOM"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Price As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount_Barang As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents BAddRows As Button
    Friend WithEvents BSave As Button
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
