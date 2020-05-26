<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_lookup_cmdm_ar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_lookup_cmdm_ar))
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnOk = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me._EntryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.filterentry = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._subaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSubAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._subtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAmount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me._idcmdm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ReposAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tcmdmno = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.filterentry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReposAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcmdmno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(0, 237)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.Grid.Size = New System.Drawing.Size(738, 253)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Date"
        Me.GridColumn1.FieldName = "docdate"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Currency"
        Me.GridColumn2.FieldName = "CuryId"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Batch"
        Me.GridColumn3.FieldName = "batnbr"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Invoice No."
        Me.GridColumn4.FieldName = "refnbr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total CMDM"
        Me.GridColumn5.FieldName = "CuryCrTot"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Check"
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn6.FieldName = "Check"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnOk})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(738, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnOk
        '
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(42, 22)
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.ToolTipText = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Offset AR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Offset AP"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 43)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.GAmount, Me.GSubAccount, Me.GAccount, Me.RepositoryItemSpinEdit1, Me.ReposAmount, Me.filterentry, Me.tcmdmno})
        Me.GridControl1.Size = New System.Drawing.Size(738, 173)
        Me.GridControl1.TabIndex = 7
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me._EntryID, Me._account, Me._subaccount, Me._description, Me._subtotal, Me._idcmdm})
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        '_EntryID
        '
        Me._EntryID.Caption = "CMDMNo"
        Me._EntryID.ColumnEdit = Me.filterentry
        Me._EntryID.FieldName = "EntryId"
        Me._EntryID.Name = "_EntryID"
        Me._EntryID.OptionsColumn.FixedWidth = True
        Me._EntryID.Visible = True
        Me._EntryID.VisibleIndex = 0
        '
        'filterentry
        '
        Me.filterentry.AutoHeight = False
        Me.filterentry.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.filterentry.Name = "filterentry"
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
        Me._account.Width = 69
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
        Me._subaccount.VisibleIndex = 2
        Me._subaccount.Width = 71
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
        Me._description.VisibleIndex = 3
        Me._description.Width = 228
        '
        '_subtotal
        '
        Me._subtotal.Caption = "Amount"
        Me._subtotal.ColumnEdit = Me.GAmount
        Me._subtotal.FieldName = "Amount"
        Me._subtotal.Name = "_subtotal"
        Me._subtotal.OptionsColumn.FixedWidth = True
        Me._subtotal.Visible = True
        Me._subtotal.VisibleIndex = 4
        Me._subtotal.Width = 84
        '
        'GAmount
        '
        Me.GAmount.AutoHeight = False
        Me.GAmount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GAmount.Name = "GAmount"
        '
        '_idcmdm
        '
        Me._idcmdm.Caption = "CMDMNo"
        Me._idcmdm.FieldName = "CMDMNo"
        Me._idcmdm.Name = "_idcmdm"
        Me._idcmdm.Visible = True
        Me._idcmdm.VisibleIndex = 5
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
        'tcmdmno
        '
        Me.tcmdmno.AutoHeight = False
        Me.tcmdmno.Name = "tcmdmno"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(488, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(645, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_lookup_cmdm_ar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 502)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_lookup_cmdm_ar"
        Me.Text = "aa"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.filterentry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSubAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReposAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcmdmno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnOk As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents _subaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSubAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents _description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _subtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAmount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ReposAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents filterentry As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents _EntryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcmdmno As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents _idcmdm As DevExpress.XtraGrid.Columns.GridColumn
End Class
