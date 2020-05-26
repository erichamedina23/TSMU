<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSystem_UserSetup
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me._CmbSite = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbGroupUser = New System.Windows.Forms.ComboBox()
        Me.G = New System.Windows.Forms.Label()
        Me.TxtConfirmation = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.ChChangePassword = New System.Windows.Forms.CheckBox()
        Me.ChActive = New System.Windows.Forms.CheckBox()
        Me.ChAdmin = New System.Windows.Forms.CheckBox()
        Me.CboUsers = New System.Windows.Forms.ComboBox()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GridUser = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridAkses = New System.Windows.Forms.DataGridView()
        Me.colHeader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMenuCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Access = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Insert = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Update = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Special = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me._TxtLevel = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridAkses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(15, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(801, 173)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._TxtLevel)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me._CmbSite)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cbGroupUser)
        Me.TabPage1.Controls.Add(Me.G)
        Me.TabPage1.Controls.Add(Me.TxtConfirmation)
        Me.TabPage1.Controls.Add(Me.TxtPassword)
        Me.TabPage1.Controls.Add(Me.ChChangePassword)
        Me.TabPage1.Controls.Add(Me.ChActive)
        Me.TabPage1.Controls.Add(Me.ChAdmin)
        Me.TabPage1.Controls.Add(Me.CboUsers)
        Me.TabPage1.Controls.Add(Me.TxtRemark)
        Me.TabPage1.Controls.Add(Me.TxtName)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TxtUsername)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(793, 147)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_CmbSite
        '
        Me._CmbSite.FormattingEnabled = True
        Me._CmbSite.Items.AddRange(New Object() {"", "ALL", "CKR A", "CKR B", "TNG", "TSC3"})
        Me._CmbSite.Location = New System.Drawing.Point(650, 5)
        Me._CmbSite.MaxLength = 15
        Me._CmbSite.Name = "_CmbSite"
        Me._CmbSite.Size = New System.Drawing.Size(84, 21)
        Me._CmbSite.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(611, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Site"
        '
        'cbGroupUser
        '
        Me.cbGroupUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupUser.FormattingEnabled = True
        Me.cbGroupUser.Location = New System.Drawing.Point(413, 35)
        Me.cbGroupUser.Name = "cbGroupUser"
        Me.cbGroupUser.Size = New System.Drawing.Size(178, 21)
        Me.cbGroupUser.TabIndex = 27
        '
        'G
        '
        Me.G.AutoSize = True
        Me.G.Location = New System.Drawing.Point(333, 35)
        Me.G.Name = "G"
        Me.G.Size = New System.Drawing.Size(61, 13)
        Me.G.TabIndex = 38
        Me.G.Text = "Group User"
        '
        'TxtConfirmation
        '
        Me.TxtConfirmation.Location = New System.Drawing.Point(191, 89)
        Me.TxtConfirmation.MaxLength = 200
        Me.TxtConfirmation.Name = "TxtConfirmation"
        Me.TxtConfirmation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmation.Size = New System.Drawing.Size(126, 20)
        Me.TxtConfirmation.TabIndex = 25
        Me.TxtConfirmation.Tag = ""
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(191, 62)
        Me.TxtPassword.MaxLength = 200
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(126, 20)
        Me.TxtPassword.TabIndex = 24
        Me.TxtPassword.Tag = ""
        '
        'ChChangePassword
        '
        Me.ChChangePassword.AutoSize = True
        Me.ChChangePassword.Location = New System.Drawing.Point(139, 64)
        Me.ChChangePassword.Name = "ChChangePassword"
        Me.ChChangePassword.Size = New System.Drawing.Size(44, 17)
        Me.ChChangePassword.TabIndex = 23
        Me.ChChangePassword.Text = "Yes"
        Me.ChChangePassword.UseVisualStyleBackColor = True
        '
        'ChActive
        '
        Me.ChActive.AutoSize = True
        Me.ChActive.Location = New System.Drawing.Point(507, 66)
        Me.ChActive.Name = "ChActive"
        Me.ChActive.Size = New System.Drawing.Size(81, 17)
        Me.ChActive.TabIndex = 29
        Me.ChActive.Text = "Active User"
        Me.ChActive.UseVisualStyleBackColor = True
        '
        'ChAdmin
        '
        Me.ChAdmin.AutoSize = True
        Me.ChAdmin.Location = New System.Drawing.Point(413, 66)
        Me.ChAdmin.Name = "ChAdmin"
        Me.ChAdmin.Size = New System.Drawing.Size(88, 17)
        Me.ChAdmin.TabIndex = 28
        Me.ChAdmin.Text = "Admin Status"
        Me.ChAdmin.UseVisualStyleBackColor = True
        '
        'CboUsers
        '
        Me.CboUsers.FormattingEnabled = True
        Me.CboUsers.Location = New System.Drawing.Point(413, 8)
        Me.CboUsers.MaxLength = 15
        Me.CboUsers.Name = "CboUsers"
        Me.CboUsers.Size = New System.Drawing.Size(178, 21)
        Me.CboUsers.TabIndex = 26
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(413, 94)
        Me.TxtRemark.MaxLength = 200
        Me.TxtRemark.Multiline = True
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(178, 47)
        Me.TxtRemark.TabIndex = 30
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(139, 35)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(178, 20)
        Me.TxtName.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(333, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Remark"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(333, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "User Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(333, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Copy Privilege"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Password Confirmation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Set Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Name"
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(139, 8)
        Me.TxtUsername.MaxLength = 15
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(178, 20)
        Me.TxtUsername.TabIndex = 21
        Me.TxtUsername.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Username"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 204)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(801, 365)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridUser)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(261, 359)
        Me.Panel1.TabIndex = 0
        '
        'GridUser
        '
        Me.GridUser.AllowUserToAddRows = False
        Me.GridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridUser.Location = New System.Drawing.Point(0, 25)
        Me.GridUser.Name = "GridUser"
        Me.GridUser.Size = New System.Drawing.Size(261, 334)
        Me.GridUser.TabIndex = 5
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(261, 25)
        Me.ToolStrip2.TabIndex = 6
        Me.ToolStrip2.Text = "User List"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripLabel2.Text = "User List"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridAkses)
        Me.Panel2.Controls.Add(Me.ToolStrip3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(270, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(528, 359)
        Me.Panel2.TabIndex = 1
        '
        'GridAkses
        '
        Me.GridAkses.AllowUserToAddRows = False
        Me.GridAkses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAkses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHeader, Me.colMenuCode, Me.colTitle, Me.Access, Me.Insert, Me.Update, Me.Delete, Me.Special, Me.Price, Me.Qty})
        Me.GridAkses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAkses.Location = New System.Drawing.Point(0, 25)
        Me.GridAkses.Name = "GridAkses"
        Me.GridAkses.Size = New System.Drawing.Size(528, 334)
        Me.GridAkses.TabIndex = 6
        '
        'colHeader
        '
        Me.colHeader.DataPropertyName = "ParentMenu"
        Me.colHeader.HeaderText = "Parent Menu"
        Me.colHeader.Name = "colHeader"
        '
        'colMenuCode
        '
        Me.colMenuCode.DataPropertyName = "MenuCode"
        Me.colMenuCode.HeaderText = "Menu Code"
        Me.colMenuCode.Name = "colMenuCode"
        '
        'colTitle
        '
        Me.colTitle.DataPropertyName = "Title"
        Me.colTitle.HeaderText = "Child Menu"
        Me.colTitle.Name = "colTitle"
        '
        'Access
        '
        Me.Access.DataPropertyName = "Access"
        Me.Access.HeaderText = "Access"
        Me.Access.Name = "Access"
        Me.Access.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Access.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Insert
        '
        Me.Insert.DataPropertyName = "Insert"
        Me.Insert.HeaderText = "Insert"
        Me.Insert.Name = "Insert"
        Me.Insert.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Insert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Update
        '
        Me.Update.DataPropertyName = "Update"
        Me.Update.HeaderText = "Update"
        Me.Update.Name = "Update"
        Me.Update.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Delete
        '
        Me.Delete.DataPropertyName = "Delete"
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Special
        '
        Me.Special.DataPropertyName = "Special"
        Me.Special.HeaderText = "Report"
        Me.Special.Name = "Special"
        Me.Special.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Special.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Price
        '
        Me.Price.DataPropertyName = "Price"
        Me.Price.HeaderText = "Edit Price"
        Me.Price.Name = "Price"
        Me.Price.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Edit Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(528, 25)
        Me.ToolStrip3.TabIndex = 7
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripLabel1.Text = "User menu access"
        '
        '_TxtLevel
        '
        Me._TxtLevel.FormattingEnabled = True
        Me._TxtLevel.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me._TxtLevel.Location = New System.Drawing.Point(650, 32)
        Me._TxtLevel.MaxLength = 15
        Me._TxtLevel.Name = "_TxtLevel"
        Me._TxtLevel.Size = New System.Drawing.Size(84, 21)
        Me._TxtLevel.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(611, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Level"
        '
        'FrmSystem_UserSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmSystem_UserSetup"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GridAkses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cbGroupUser As System.Windows.Forms.ComboBox
    Friend WithEvents G As System.Windows.Forms.Label
    Friend WithEvents TxtConfirmation As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ChChangePassword As System.Windows.Forms.CheckBox
    Friend WithEvents ChActive As System.Windows.Forms.CheckBox
    Friend WithEvents ChAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents CboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridUser As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GridAkses As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents colHeader As DataGridViewTextBoxColumn
    Friend WithEvents colMenuCode As DataGridViewTextBoxColumn
    Friend WithEvents colTitle As DataGridViewTextBoxColumn
    Friend WithEvents Access As DataGridViewCheckBoxColumn
    Friend WithEvents Insert As DataGridViewCheckBoxColumn
    Friend WithEvents Update As DataGridViewCheckBoxColumn
    Friend WithEvents Delete As DataGridViewCheckBoxColumn
    Friend WithEvents Special As DataGridViewCheckBoxColumn
    Friend WithEvents Price As DataGridViewCheckBoxColumn
    Friend WithEvents Qty As DataGridViewCheckBoxColumn
    Friend WithEvents _CmbSite As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents _TxtLevel As ComboBox
    Friend WithEvents Label9 As Label
End Class
