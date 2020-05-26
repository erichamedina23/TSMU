<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CR_UserCreateDetail
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
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameOfGoods = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Spesification = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Qty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Price = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Amount_Barang = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Curr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrRepository = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Remaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Amount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Amount_Term = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RB_Budget = New System.Windows.Forms.RadioButton()
        Me.RB_NonBudget = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_RequirementDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_Reason = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_CRNo = New DevExpress.XtraEditors.TextEdit()
        Me.Grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Term = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Percent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Percent_Term = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Tgl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Total = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Term = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.T_Dept = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.T_ParentAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.T_Parent = New DevExpress.XtraEditors.ButtonEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.T_Remark = New DevExpress.XtraEditors.TextEdit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.T_Charged = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.T_ModelName = New DevExpress.XtraEditors.TextEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.T_DS = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.T_CustomerName = New DevExpress.XtraEditors.TextEdit()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.T_CRType = New DevExpress.XtraEditors.TextEdit()
        Me.BMold = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount_Term, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.T_RequirementDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_RequirementDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CRNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Percent_Term, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Term.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Dept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ParentAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Parent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.T_Remark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Charged.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ModelName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CustomerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CRType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(361, 69)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.C_Qty, Me.C_Price, Me.C_Amount, Me.C_Amount_Barang, Me.CurrRepository, Me.BAccount})
        Me.Grid.Size = New System.Drawing.Size(1004, 577)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameOfGoods, Me.Spesification, Me.Qty, Me.Price, Me.PTotal, Me.Curr, Me.Rate, Me.Account, Me.Remaining, Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'NameOfGoods
        '
        Me.NameOfGoods.FieldName = "Name Of Goods"
        Me.NameOfGoods.Name = "NameOfGoods"
        Me.NameOfGoods.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name Of Goods", "{0:N0}")})
        Me.NameOfGoods.Visible = True
        Me.NameOfGoods.VisibleIndex = 0
        Me.NameOfGoods.Width = 142
        '
        'Spesification
        '
        Me.Spesification.FieldName = "Spesification"
        Me.Spesification.Name = "Spesification"
        Me.Spesification.Visible = True
        Me.Spesification.VisibleIndex = 1
        Me.Spesification.Width = 151
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Qty.Caption = "Qty"
        Me.Qty.ColumnEdit = Me.C_Qty
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 2
        Me.Qty.Width = 60
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
        'Price
        '
        Me.Price.AppearanceHeader.Options.UseTextOptions = True
        Me.Price.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Price.Caption = "Price"
        Me.Price.ColumnEdit = Me.C_Price
        Me.Price.DisplayFormat.FormatString = "{0:N2}"
        Me.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Price.FieldName = "Price"
        Me.Price.Name = "Price"
        Me.Price.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Price.Visible = True
        Me.Price.VisibleIndex = 3
        Me.Price.Width = 130
        '
        'C_Price
        '
        Me.C_Price.Appearance.Options.UseTextOptions = True
        Me.C_Price.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Price.AutoHeight = False
        Me.C_Price.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Price.Name = "C_Price"
        '
        'PTotal
        '
        Me.PTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.PTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PTotal.ColumnEdit = Me.C_Amount_Barang
        Me.PTotal.DisplayFormat.FormatString = "{0:N2}"
        Me.PTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PTotal.FieldName = "Amount"
        Me.PTotal.Name = "PTotal"
        Me.PTotal.OptionsColumn.AllowEdit = False
        Me.PTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:N2}")})
        Me.PTotal.Visible = True
        Me.PTotal.VisibleIndex = 5
        Me.PTotal.Width = 145
        '
        'C_Amount_Barang
        '
        Me.C_Amount_Barang.AutoHeight = False
        Me.C_Amount_Barang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount_Barang.Name = "C_Amount_Barang"
        '
        'Curr
        '
        Me.Curr.AppearanceCell.Options.UseTextOptions = True
        Me.Curr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Curr.AppearanceHeader.Options.UseTextOptions = True
        Me.Curr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Curr.ColumnEdit = Me.CurrRepository
        Me.Curr.FieldName = "Curr"
        Me.Curr.Name = "Curr"
        Me.Curr.Visible = True
        Me.Curr.VisibleIndex = 8
        Me.Curr.Width = 51
        '
        'CurrRepository
        '
        Me.CurrRepository.AutoHeight = False
        Me.CurrRepository.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrRepository.Name = "CurrRepository"
        '
        'Rate
        '
        Me.Rate.AppearanceHeader.Options.UseTextOptions = True
        Me.Rate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Rate.DisplayFormat.FormatString = "{0:N2}"
        Me.Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Rate.FieldName = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.OptionsColumn.AllowEdit = False
        Me.Rate.Visible = True
        Me.Rate.VisibleIndex = 4
        Me.Rate.Width = 106
        '
        'Account
        '
        Me.Account.AppearanceCell.Options.UseTextOptions = True
        Me.Account.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.AppearanceHeader.Options.UseTextOptions = True
        Me.Account.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.ColumnEdit = Me.BAccount
        Me.Account.FieldName = "Account"
        Me.Account.Name = "Account"
        Me.Account.Visible = True
        Me.Account.VisibleIndex = 7
        Me.Account.Width = 100
        '
        'BAccount
        '
        Me.BAccount.AutoHeight = False
        Me.BAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BAccount.Name = "BAccount"
        '
        'Remaining
        '
        Me.Remaining.AppearanceHeader.Options.UseTextOptions = True
        Me.Remaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Remaining.DisplayFormat.FormatString = "{0:N2}"
        Me.Remaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Remaining.FieldName = "Remaining Budget"
        Me.Remaining.Name = "Remaining"
        Me.Remaining.OptionsColumn.AllowEdit = False
        Me.Remaining.Visible = True
        Me.Remaining.VisibleIndex = 6
        Me.Remaining.Width = 130
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.DisplayFormat.FormatString = "{0:N2}"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "Balance"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Width = 138
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.FieldName = "Category"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 9
        '
        'C_Amount
        '
        Me.C_Amount.Appearance.Options.UseTextOptions = True
        Me.C_Amount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Amount.AutoHeight = False
        Me.C_Amount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount.Name = "C_Amount"
        '
        'C_Amount_Term
        '
        Me.C_Amount_Term.AutoHeight = False
        Me.C_Amount_Term.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount_Term.Name = "C_Amount_Term"
        '
        'RB_Budget
        '
        Me.RB_Budget.AutoSize = True
        Me.RB_Budget.Location = New System.Drawing.Point(6, 9)
        Me.RB_Budget.Name = "RB_Budget"
        Me.RB_Budget.Size = New System.Drawing.Size(59, 17)
        Me.RB_Budget.TabIndex = 2
        Me.RB_Budget.TabStop = True
        Me.RB_Budget.Text = "Budget"
        Me.RB_Budget.UseVisualStyleBackColor = True
        '
        'RB_NonBudget
        '
        Me.RB_NonBudget.AutoSize = True
        Me.RB_NonBudget.Location = New System.Drawing.Point(90, 7)
        Me.RB_NonBudget.Name = "RB_NonBudget"
        Me.RB_NonBudget.Size = New System.Drawing.Size(82, 17)
        Me.RB_NonBudget.TabIndex = 3
        Me.RB_NonBudget.TabStop = True
        Me.RB_NonBudget.Text = "Non Budget"
        Me.RB_NonBudget.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_Budget)
        Me.GroupBox1.Controls.Add(Me.RB_NonBudget)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(109, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 30)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(358, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Requirement Date"
        '
        'T_RequirementDate
        '
        Me.T_RequirementDate.EditValue = Nothing
        Me.T_RequirementDate.Location = New System.Drawing.Point(458, 42)
        Me.T_RequirementDate.Name = "T_RequirementDate"
        Me.T_RequirementDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_RequirementDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_RequirementDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.T_RequirementDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.T_RequirementDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.T_RequirementDate.Size = New System.Drawing.Size(170, 20)
        Me.T_RequirementDate.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Circulation Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Budget Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Reason"
        '
        'T_Reason
        '
        Me.T_Reason.Location = New System.Drawing.Point(109, 132)
        Me.T_Reason.Multiline = True
        Me.T_Reason.Name = "T_Reason"
        Me.T_Reason.Size = New System.Drawing.Size(240, 61)
        Me.T_Reason.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Circulation No"
        '
        'T_CRNo
        '
        Me.T_CRNo.Location = New System.Drawing.Point(109, 41)
        Me.T_CRNo.Name = "T_CRNo"
        Me.T_CRNo.Size = New System.Drawing.Size(240, 20)
        Me.T_CRNo.TabIndex = 1
        '
        'Grid1
        '
        Me.Grid1.Location = New System.Drawing.Point(3, 226)
        Me.Grid1.MainView = Me.GridView2
        Me.Grid1.Name = "Grid1"
        Me.Grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.C_Percent_Term, Me.C_Amount_Term, Me.C_Total})
        Me.Grid1.Size = New System.Drawing.Size(346, 179)
        Me.Grid1.TabIndex = 50
        Me.Grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Term, Me.Percent, Me.Tgl, Me.TTotal})
        Me.GridView2.GridControl = Me.Grid1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Term
        '
        Me.Term.AppearanceCell.Options.UseTextOptions = True
        Me.Term.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Term.AppearanceHeader.Options.UseTextOptions = True
        Me.Term.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Term.Caption = "Term"
        Me.Term.FieldName = "Term"
        Me.Term.Name = "Term"
        Me.Term.OptionsColumn.AllowEdit = False
        Me.Term.Visible = True
        Me.Term.VisibleIndex = 0
        Me.Term.Width = 126
        '
        'Percent
        '
        Me.Percent.AppearanceCell.Options.UseTextOptions = True
        Me.Percent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Percent.AppearanceHeader.Options.UseTextOptions = True
        Me.Percent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Percent.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Percent.Caption = "%"
        Me.Percent.ColumnEdit = Me.C_Percent_Term
        Me.Percent.DisplayFormat.FormatString = "{0:N2}"
        Me.Percent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Percent.FieldName = "%"
        Me.Percent.Name = "Percent"
        Me.Percent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "%", "{0:N2}")})
        Me.Percent.Visible = True
        Me.Percent.VisibleIndex = 2
        Me.Percent.Width = 169
        '
        'C_Percent_Term
        '
        Me.C_Percent_Term.AutoHeight = False
        Me.C_Percent_Term.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Percent_Term.Name = "C_Percent_Term"
        '
        'Tgl
        '
        Me.Tgl.AppearanceCell.Options.UseTextOptions = True
        Me.Tgl.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tgl.AppearanceHeader.Options.UseTextOptions = True
        Me.Tgl.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tgl.FieldName = "Date"
        Me.Tgl.Name = "Tgl"
        Me.Tgl.Visible = True
        Me.Tgl.VisibleIndex = 1
        Me.Tgl.Width = 326
        '
        'TTotal
        '
        Me.TTotal.ColumnEdit = Me.C_Total
        Me.TTotal.DisplayFormat.FormatString = "{0:N2}"
        Me.TTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TTotal.FieldName = "Total"
        Me.TTotal.Name = "TTotal"
        Me.TTotal.OptionsColumn.AllowEdit = False
        Me.TTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N2}")})
        Me.TTotal.Visible = True
        Me.TTotal.VisibleIndex = 3
        Me.TTotal.Width = 447
        '
        'C_Total
        '
        Me.C_Total.AutoHeight = False
        Me.C_Total.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Total.Name = "C_Total"
        '
        'C_Term
        '
        Me.C_Term.Location = New System.Drawing.Point(109, 198)
        Me.C_Term.Name = "C_Term"
        Me.C_Term.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Term.Properties.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.C_Term.Size = New System.Drawing.Size(57, 20)
        Me.C_Term.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Installment"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1209, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "Add Rows"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'T_Dept
        '
        Me.T_Dept.EditValue = ""
        Me.T_Dept.Location = New System.Drawing.Point(109, 109)
        Me.T_Dept.Name = "T_Dept"
        Me.T_Dept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Dept.Size = New System.Drawing.Size(240, 20)
        Me.T_Dept.TabIndex = 63
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Other Dept"
        '
        'T_ParentAmount
        '
        Me.T_ParentAmount.EditValue = "0"
        Me.T_ParentAmount.Location = New System.Drawing.Point(1025, 42)
        Me.T_ParentAmount.Name = "T_ParentAmount"
        Me.T_ParentAmount.Size = New System.Drawing.Size(170, 20)
        Me.T_ParentAmount.TabIndex = 66
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(642, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Parent Circulation"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(925, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Parent Amount"
        '
        'T_Parent
        '
        Me.T_Parent.Location = New System.Drawing.Point(742, 42)
        Me.T_Parent.Name = "T_Parent"
        Me.T_Parent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_Parent.Size = New System.Drawing.Size(170, 20)
        Me.T_Parent.TabIndex = 65
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.T_Remark)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.T_Charged)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.T_ModelName)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.T_DS)
        Me.GroupBox2.Controls.Add(Me.T_CustomerName)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 411)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(335, 177)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dies / Mold"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Remark"
        '
        'T_Remark
        '
        Me.T_Remark.Location = New System.Drawing.Point(127, 125)
        Me.T_Remark.Name = "T_Remark"
        Me.T_Remark.Size = New System.Drawing.Size(186, 20)
        Me.T_Remark.TabIndex = 45
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Charged of Customer"
        '
        'T_Charged
        '
        Me.T_Charged.Location = New System.Drawing.Point(127, 99)
        Me.T_Charged.Name = "T_Charged"
        Me.T_Charged.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Charged.Properties.Items.AddRange(New Object() {"YES", "NO"})
        Me.T_Charged.Size = New System.Drawing.Size(186, 20)
        Me.T_Charged.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 76)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Model Name"
        '
        'T_ModelName
        '
        Me.T_ModelName.Location = New System.Drawing.Point(127, 73)
        Me.T_ModelName.Name = "T_ModelName"
        Me.T_ModelName.Size = New System.Drawing.Size(186, 20)
        Me.T_ModelName.TabIndex = 41
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Customer Name"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Sales Type"
        '
        'T_DS
        '
        Me.T_DS.Location = New System.Drawing.Point(127, 25)
        Me.T_DS.Name = "T_DS"
        Me.T_DS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_DS.Properties.Items.AddRange(New Object() {"Depreciation", "Sales"})
        Me.T_DS.Size = New System.Drawing.Size(186, 20)
        Me.T_DS.TabIndex = 37
        '
        'T_CustomerName
        '
        Me.T_CustomerName.Location = New System.Drawing.Point(127, 49)
        Me.T_CustomerName.Name = "T_CustomerName"
        Me.T_CustomerName.Size = New System.Drawing.Size(186, 20)
        Me.T_CustomerName.TabIndex = 39
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button4.Location = New System.Drawing.Point(335, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 71
        Me.Button4.Text = "Submit"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'T_CRType
        '
        Me.T_CRType.EditValue = "Fixed Aset"
        Me.T_CRType.Location = New System.Drawing.Point(109, 85)
        Me.T_CRType.Name = "T_CRType"
        Me.T_CRType.Size = New System.Drawing.Size(240, 20)
        Me.T_CRType.TabIndex = 4
        '
        'BMold
        '
        Me.BMold.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BMold.Location = New System.Drawing.Point(1290, 39)
        Me.BMold.Name = "BMold"
        Me.BMold.Size = New System.Drawing.Size(75, 23)
        Me.BMold.TabIndex = 74
        Me.BMold.Text = "Mold"
        Me.BMold.UseVisualStyleBackColor = True
        '
        'Frm_CR_UserCreateDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1370, 658)
        Me.Controls.Add(Me.BMold)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.T_ParentAmount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.C_Term)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_CRNo)
        Me.Controls.Add(Me.T_Reason)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.T_RequirementDate)
        Me.Controls.Add(Me.T_Dept)
        Me.Controls.Add(Me.T_Parent)
        Me.Controls.Add(Me.T_CRType)
        Me.Name = "Frm_CR_UserCreateDetail"
        Me.Controls.SetChildIndex(Me.T_CRType, 0)
        Me.Controls.SetChildIndex(Me.T_Parent, 0)
        Me.Controls.SetChildIndex(Me.T_Dept, 0)
        Me.Controls.SetChildIndex(Me.T_RequirementDate, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.T_Reason, 0)
        Me.Controls.SetChildIndex(Me.T_CRNo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Grid1, 0)
        Me.Controls.SetChildIndex(Me.C_Term, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.T_ParentAmount, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Button4, 0)
        Me.Controls.SetChildIndex(Me.BMold, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount_Term, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.T_RequirementDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_RequirementDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CRNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Percent_Term, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Term.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Dept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ParentAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Parent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.T_Remark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Charged.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ModelName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CustomerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CRType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RB_Budget As RadioButton
    Friend WithEvents RB_NonBudget As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents T_RequirementDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents T_Reason As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents T_CRNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NameOfGoods As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Spesification As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents C_Term As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Term As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Percent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents C_Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Price As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Tgl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Percent_Term As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount_Term As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Amount_Barang As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents TTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Total As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents T_Dept As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents T_ParentAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents T_Parent As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents T_ModelName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents T_DS As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents T_CustomerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Button4 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents T_Remark As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label19 As Label
    Friend WithEvents T_Charged As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents T_CRType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BMold As Button
    Friend WithEvents Curr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrRepository As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
