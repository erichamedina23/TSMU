<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSuspendSettleDetail
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
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtNoSettlement = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTotExpense = New DevExpress.XtraEditors.TextEdit()
        Me.TxtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TxtRemark = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDep = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCurrency = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTgl = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNoSuspend = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Label10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Label9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.GAmount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GSubAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReposDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me._account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._subaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReposActual = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtNoSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoSuspend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReposDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReposDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReposActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtNoSettlement)
        Me.LayoutControl1.Controls.Add(Me.TxtTotExpense)
        Me.LayoutControl1.Controls.Add(Me.TxtStatus)
        Me.LayoutControl1.Controls.Add(Me.TxtTotal)
        Me.LayoutControl1.Controls.Add(Me.TxtRemark)
        Me.LayoutControl1.Controls.Add(Me.TxtDep)
        Me.LayoutControl1.Controls.Add(Me.TxtCurrency)
        Me.LayoutControl1.Controls.Add(Me.TxtTgl)
        Me.LayoutControl1.Controls.Add(Me.TxtNoSuspend)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(796, 104)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtNoSettlement
        '
        Me.TxtNoSettlement.Location = New System.Drawing.Point(87, 36)
        Me.TxtNoSettlement.Name = "TxtNoSettlement"
        Me.TxtNoSettlement.Properties.ReadOnly = True
        Me.TxtNoSettlement.Size = New System.Drawing.Size(168, 20)
        Me.TxtNoSettlement.StyleController = Me.LayoutControl1
        Me.TxtNoSettlement.TabIndex = 14
        '
        'TxtTotExpense
        '
        Me.TxtTotExpense.EditValue = "0"
        Me.TxtTotExpense.Location = New System.Drawing.Point(595, 60)
        Me.TxtTotExpense.Name = "TxtTotExpense"
        Me.TxtTotExpense.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTotExpense.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtTotExpense.Properties.ReadOnly = True
        Me.TxtTotExpense.Size = New System.Drawing.Size(189, 20)
        Me.TxtTotExpense.StyleController = Me.LayoutControl1
        Me.TxtTotExpense.TabIndex = 13
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(595, 36)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Properties.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(189, 20)
        Me.TxtStatus.StyleController = Me.LayoutControl1
        Me.TxtStatus.TabIndex = 12
        '
        'TxtTotal
        '
        Me.TxtTotal.EditValue = "0"
        Me.TxtTotal.Location = New System.Drawing.Point(334, 60)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtTotal.Properties.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(182, 20)
        Me.TxtTotal.StyleController = Me.LayoutControl1
        Me.TxtTotal.TabIndex = 9
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(595, 12)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Properties.ReadOnly = True
        Me.TxtRemark.Size = New System.Drawing.Size(189, 20)
        Me.TxtRemark.StyleController = Me.LayoutControl1
        Me.TxtRemark.TabIndex = 6
        '
        'TxtDep
        '
        Me.TxtDep.Location = New System.Drawing.Point(87, 60)
        Me.TxtDep.Name = "TxtDep"
        Me.TxtDep.Properties.ReadOnly = True
        Me.TxtDep.Size = New System.Drawing.Size(168, 20)
        Me.TxtDep.StyleController = Me.LayoutControl1
        Me.TxtDep.TabIndex = 11
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(334, 12)
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Properties.ReadOnly = True
        Me.TxtCurrency.Size = New System.Drawing.Size(182, 20)
        Me.TxtCurrency.StyleController = Me.LayoutControl1
        Me.TxtCurrency.TabIndex = 8
        '
        'TxtTgl
        '
        Me.TxtTgl.Location = New System.Drawing.Point(334, 36)
        Me.TxtTgl.Name = "TxtTgl"
        Me.TxtTgl.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.ReadOnly = True
        Me.TxtTgl.Size = New System.Drawing.Size(182, 20)
        Me.TxtTgl.StyleController = Me.LayoutControl1
        Me.TxtTgl.TabIndex = 7
        '
        'TxtNoSuspend
        '
        Me.TxtNoSuspend.Location = New System.Drawing.Point(87, 12)
        Me.TxtNoSuspend.Name = "TxtNoSuspend"
        Me.TxtNoSuspend.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtNoSuspend.Size = New System.Drawing.Size(168, 20)
        Me.TxtNoSuspend.StyleController = Me.LayoutControl1
        Me.TxtNoSuspend.TabIndex = 4
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Suspend cannot be empty !"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.TxtNoSuspend, ConditionValidationRule1)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.Label10, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.Label9})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(796, 104)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtNoSuspend
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(247, 24)
        Me.LayoutControlItem1.Text = "Advance No."
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(72, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(776, 12)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtCurrency
        Me.LayoutControlItem5.Location = New System.Drawing.Point(247, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(261, 24)
        Me.LayoutControlItem5.Text = "Currency"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtTgl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(247, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(261, 24)
        Me.LayoutControlItem4.Text = "Date"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtRemark
        Me.LayoutControlItem3.Location = New System.Drawing.Point(508, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(268, 24)
        Me.LayoutControlItem3.Text = "Remark"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(72, 13)
        '
        'Label10
        '
        Me.Label10.Control = Me.TxtStatus
        Me.Label10.Location = New System.Drawing.Point(508, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(268, 24)
        Me.Label10.Text = "Status"
        Me.Label10.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TxtNoSettlement
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(247, 24)
        Me.LayoutControlItem8.Text = "Settlement No."
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtTotal
        Me.LayoutControlItem6.Location = New System.Drawing.Point(247, 48)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(261, 24)
        Me.LayoutControlItem6.Text = "Total Advance"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtTotExpense
        Me.LayoutControlItem7.Location = New System.Drawing.Point(508, 48)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(268, 24)
        Me.LayoutControlItem7.Text = "Total Expense"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(72, 13)
        '
        'Label9
        '
        Me.Label9.Control = Me.TxtDep
        Me.Label9.Location = New System.Drawing.Point(0, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(247, 24)
        Me.Label9.Text = "Dept"
        Me.Label9.TextSize = New System.Drawing.Size(72, 13)
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'GAmount
        '
        Me.GAmount.AutoHeight = False
        Me.GAmount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GAmount.Name = "GAmount"
        '
        'GSubAccount
        '
        Me.GSubAccount.AutoHeight = False
        Me.GSubAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GSubAccount.Name = "GSubAccount"
        '
        'GAccount
        '
        Me.GAccount.AutoHeight = False
        Me.GAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GAccount.Name = "GAccount"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me._account, Me._subaccount, Me._description, Me.GridColumn2})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Date"
        Me.GridColumn1.ColumnEdit = Me.ReposDate
        Me.GridColumn1.FieldName = "Tgl"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'ReposDate
        '
        Me.ReposDate.AutoHeight = False
        Me.ReposDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReposDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReposDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.ReposDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ReposDate.EditFormat.FormatString = "dd-MM-yyyy"
        Me.ReposDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ReposDate.Mask.EditMask = "dd-MM-yyyy"
        Me.ReposDate.Name = "ReposDate"
        '
        '_account
        '
        Me._account.Caption = "Account"
        Me._account.ColumnEdit = Me.GAccount
        Me._account.FieldName = "Account"
        Me._account.Name = "_account"
        Me._account.OptionsColumn.FixedWidth = True
        Me._account.Visible = True
        Me._account.VisibleIndex = 1
        '
        '_subaccount
        '
        Me._subaccount.Caption = "SubAccount"
        Me._subaccount.ColumnEdit = Me.GSubAccount
        Me._subaccount.FieldName = "SubAccount"
        Me._subaccount.Name = "_subaccount"
        Me._subaccount.OptionsColumn.FixedWidth = True
        Me._subaccount.Visible = True
        Me._subaccount.VisibleIndex = 2
        '
        '_description
        '
        Me._description.Caption = "Description"
        Me._description.FieldName = "Description"
        Me._description.Name = "_description"
        Me._description.Visible = True
        Me._description.VisibleIndex = 3
        Me._description.Width = 250
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Actual Amount"
        Me.GridColumn2.ColumnEdit = Me.ReposActual
        Me.GridColumn2.FieldName = "ActualAmount"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 100
        '
        'ReposActual
        '
        Me.ReposActual.AutoHeight = False
        Me.ReposActual.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReposActual.Name = "ReposActual"
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 135)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.GAmount, Me.GSubAccount, Me.GAccount, Me.ReposDate, Me.ReposActual})
        Me.Grid.Size = New System.Drawing.Size(772, 434)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'FrmSuspendSettleDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(796, 581)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.KeyPreview = True
        Me.Name = "FrmSuspendSettleDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtNoSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoSuspend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReposDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReposDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReposActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtRemark As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GAmount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GSubAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _subaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReposDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReposActual As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents TxtDep As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCurrency As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTgl As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNoSuspend As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtTotExpense As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtNoSettlement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
