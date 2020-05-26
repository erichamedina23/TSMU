<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSuspend_Detail
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
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnAddDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtSirkulasi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPrNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTgl = New DevExpress.XtraEditors.DateEdit()
        Me.TxtDep = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtCurrency = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtNoSuspend = New DevExpress.XtraEditors.TextEdit()
        Me.TxtRemark = New DevExpress.XtraEditors.MemoEdit()
        Me.TxtAmountReq = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Label9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Label10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me._account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._subaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSubAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._subtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAmount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ReposAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtSirkulasi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoSuspend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmountReq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReposAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnAddDetail)
        Me.LayoutControl1.Controls.Add(Me.TxtSirkulasi)
        Me.LayoutControl1.Controls.Add(Me.TxtStatus)
        Me.LayoutControl1.Controls.Add(Me.TxtTotal)
        Me.LayoutControl1.Controls.Add(Me.TxtPrNo)
        Me.LayoutControl1.Controls.Add(Me.TxtTgl)
        Me.LayoutControl1.Controls.Add(Me.TxtDep)
        Me.LayoutControl1.Controls.Add(Me.TxtCurrency)
        Me.LayoutControl1.Controls.Add(Me.TxtNoSuspend)
        Me.LayoutControl1.Controls.Add(Me.TxtRemark)
        Me.LayoutControl1.Controls.Add(Me.TxtAmountReq)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(796, 123)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnAddDetail
        '
        Me.btnAddDetail.Location = New System.Drawing.Point(651, 36)
        Me.btnAddDetail.Name = "btnAddDetail"
        Me.btnAddDetail.Size = New System.Drawing.Size(133, 22)
        Me.btnAddDetail.StyleController = Me.LayoutControl1
        Me.btnAddDetail.TabIndex = 15
        Me.btnAddDetail.Text = "Add Detail (+)"
        '
        'TxtSirkulasi
        '
        Me.TxtSirkulasi.Location = New System.Drawing.Point(261, 36)
        Me.TxtSirkulasi.Name = "TxtSirkulasi"
        Me.TxtSirkulasi.Size = New System.Drawing.Size(66, 20)
        Me.TxtSirkulasi.StyleController = Me.LayoutControl1
        Me.TxtSirkulasi.TabIndex = 13
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(734, 12)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Properties.ReadOnly = True
        Me.TxtStatus.Size = New System.Drawing.Size(50, 20)
        Me.TxtStatus.StyleController = Me.LayoutControl1
        Me.TxtStatus.TabIndex = 12
        '
        'TxtTotal
        '
        Me.TxtTotal.EditValue = "0"
        Me.TxtTotal.Location = New System.Drawing.Point(565, 12)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtTotal.Properties.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(82, 20)
        Me.TxtTotal.StyleController = Me.LayoutControl1
        Me.TxtTotal.TabIndex = 9
        '
        'TxtPrNo
        '
        Me.TxtPrNo.Location = New System.Drawing.Point(95, 36)
        Me.TxtPrNo.Name = "TxtPrNo"
        Me.TxtPrNo.Size = New System.Drawing.Size(79, 20)
        Me.TxtPrNo.StyleController = Me.LayoutControl1
        Me.TxtPrNo.TabIndex = 5
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Isi PR No"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.TxtPrNo, ConditionValidationRule1)
        '
        'TxtTgl
        '
        Me.TxtTgl.EditValue = Nothing
        Me.TxtTgl.Location = New System.Drawing.Point(95, 12)
        Me.TxtTgl.Name = "TxtTgl"
        Me.TxtTgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.Mask.EditMask = ""
        Me.TxtTgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtTgl.Size = New System.Drawing.Size(79, 20)
        Me.TxtTgl.StyleController = Me.LayoutControl1
        Me.TxtTgl.TabIndex = 7
        '
        'TxtDep
        '
        Me.TxtDep.Location = New System.Drawing.Point(414, 36)
        Me.TxtDep.Name = "TxtDep"
        Me.TxtDep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDep.Size = New System.Drawing.Size(64, 20)
        Me.TxtDep.StyleController = Me.LayoutControl1
        Me.TxtDep.TabIndex = 11
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Isi Departemen"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.TxtDep, ConditionValidationRule2)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(414, 12)
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtCurrency.Properties.Items.AddRange(New Object() {"IDR", "USD"})
        Me.TxtCurrency.Size = New System.Drawing.Size(64, 20)
        Me.TxtCurrency.StyleController = Me.LayoutControl1
        Me.TxtCurrency.TabIndex = 8
        '
        'TxtNoSuspend
        '
        Me.TxtNoSuspend.Location = New System.Drawing.Point(261, 12)
        Me.TxtNoSuspend.Name = "TxtNoSuspend"
        Me.TxtNoSuspend.Properties.ReadOnly = True
        Me.TxtNoSuspend.Size = New System.Drawing.Size(66, 20)
        Me.TxtNoSuspend.StyleController = Me.LayoutControl1
        Me.TxtNoSuspend.TabIndex = 4
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(95, 62)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(689, 49)
        Me.TxtRemark.StyleController = Me.LayoutControl1
        Me.TxtRemark.TabIndex = 6
        '
        'TxtAmountReq
        '
        Me.TxtAmountReq.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtAmountReq.Location = New System.Drawing.Point(565, 36)
        Me.TxtAmountReq.Name = "TxtAmountReq"
        Me.TxtAmountReq.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtAmountReq.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtAmountReq.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtAmountReq.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TxtAmountReq.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtAmountReq.Size = New System.Drawing.Size(82, 20)
        Me.TxtAmountReq.StyleController = Me.LayoutControl1
        Me.TxtAmountReq.TabIndex = 14
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.Label9, Me.Label10, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(796, 123)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtNoSuspend
        Me.LayoutControlItem1.Location = New System.Drawing.Point(166, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(153, 24)
        Me.LayoutControlItem1.Text = "Advance No."
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtPrNo
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem2.Text = "PR No"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtSirkulasi
        Me.LayoutControlItem7.Location = New System.Drawing.Point(166, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(153, 26)
        Me.LayoutControlItem7.Text = "Circulation No."
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtTgl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(166, 24)
        Me.LayoutControlItem4.Text = "Date"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtRemark
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(776, 53)
        Me.LayoutControlItem3.Text = "Remark"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtCurrency
        Me.LayoutControlItem5.Location = New System.Drawing.Point(319, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(151, 24)
        Me.LayoutControlItem5.Text = "Currency"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(80, 13)
        '
        'Label9
        '
        Me.Label9.Control = Me.TxtDep
        Me.Label9.Location = New System.Drawing.Point(319, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 26)
        Me.Label9.Text = "Dept"
        Me.Label9.TextSize = New System.Drawing.Size(80, 13)
        '
        'Label10
        '
        Me.Label10.Control = Me.TxtStatus
        Me.Label10.Location = New System.Drawing.Point(639, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 24)
        Me.Label10.Text = "Status"
        Me.Label10.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TxtAmountReq
        Me.LayoutControlItem8.Location = New System.Drawing.Point(470, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(169, 26)
        Me.LayoutControlItem8.Text = "Amount Request"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtTotal
        Me.LayoutControlItem6.Location = New System.Drawing.Point(470, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(169, 24)
        Me.LayoutControlItem6.Text = "Total"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnAddDetail
        Me.LayoutControlItem9.Location = New System.Drawing.Point(639, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(137, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 154)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.GAmount, Me.GSubAccount, Me.GAccount, Me.RepositoryItemSpinEdit1, Me.ReposAmount})
        Me.Grid.Size = New System.Drawing.Size(772, 415)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me._account, Me._subaccount, Me._description, Me._subtotal})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        '_account
        '
        Me._account.Caption = "Account"
        Me._account.ColumnEdit = Me.GAccount
        Me._account.FieldName = "Account"
        Me._account.Name = "_account"
        Me._account.OptionsColumn.FixedWidth = True
        Me._account.Visible = True
        Me._account.VisibleIndex = 0
        Me._account.Width = 100
        '
        'GAccount
        '
        Me.GAccount.AutoHeight = False
        Me.GAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GAccount.Name = "GAccount"
        '
        '_subaccount
        '
        Me._subaccount.Caption = "SubAccount"
        Me._subaccount.ColumnEdit = Me.GSubAccount
        Me._subaccount.FieldName = "SubAccount"
        Me._subaccount.Name = "_subaccount"
        Me._subaccount.OptionsColumn.FixedWidth = True
        Me._subaccount.Visible = True
        Me._subaccount.VisibleIndex = 1
        Me._subaccount.Width = 100
        '
        'GSubAccount
        '
        Me.GSubAccount.AutoHeight = False
        Me.GSubAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GSubAccount.Name = "GSubAccount"
        '
        '_description
        '
        Me._description.Caption = "Description"
        Me._description.FieldName = "Description"
        Me._description.Name = "_description"
        Me._description.Visible = True
        Me._description.VisibleIndex = 2
        Me._description.Width = 479
        '
        '_subtotal
        '
        Me._subtotal.Caption = "Amount"
        Me._subtotal.ColumnEdit = Me.GAmount
        Me._subtotal.FieldName = "Amount"
        Me._subtotal.Name = "_subtotal"
        Me._subtotal.OptionsColumn.FixedWidth = True
        Me._subtotal.Visible = True
        Me._subtotal.VisibleIndex = 3
        Me._subtotal.Width = 100
        '
        'GAmount
        '
        Me.GAmount.AutoHeight = False
        Me.GAmount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GAmount.Name = "GAmount"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'ReposAmount
        '
        Me.ReposAmount.AutoHeight = False
        Me.ReposAmount.DisplayFormat.FormatString = "n2"
        Me.ReposAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ReposAmount.EditFormat.FormatString = "n2"
        Me.ReposAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ReposAmount.Name = "ReposAmount"
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'FrmSuspend_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(796, 581)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.KeyPreview = True
        Me.Name = "FrmSuspend_Detail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtSirkulasi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoSuspend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmountReq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReposAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPrNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _subaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _subtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAmount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents GSubAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtDep As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtCurrency As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ReposAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TxtNoSuspend As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtRemark As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TxtSirkulasi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtAmountReq As DevExpress.XtraEditors.SpinEdit
End Class
