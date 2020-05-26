<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSales_Forecast_detail
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSales_Forecast_detail))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me._txtModel = New System.Windows.Forms.TextBox()
        Me._btnCariPart = New System.Windows.Forms.Button()
        Me.btnCariCust = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me._cmbTahun = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._cmbInHouse = New System.Windows.Forms.ComboBox()
        Me._cmbSite = New System.Windows.Forms.ComboBox()
        Me._cmbOeRe = New System.Windows.Forms.ComboBox()
        Me._txtPartName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._txtInvtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._txtCustName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._txtCustId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.colBulan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRev0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRev1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRev2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPO0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(804, 207)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._txtModel)
        Me.TabPage1.Controls.Add(Me._btnCariPart)
        Me.TabPage1.Controls.Add(Me.btnCariCust)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me._cmbTahun)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me._cmbInHouse)
        Me.TabPage1.Controls.Add(Me._cmbSite)
        Me.TabPage1.Controls.Add(Me._cmbOeRe)
        Me.TabPage1.Controls.Add(Me._txtPartName)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me._txtInvtId)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me._txtPartNo)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me._txtCustName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me._txtCustId)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(796, 181)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sales Forecast Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_txtModel
        '
        Me._txtModel.Location = New System.Drawing.Point(140, 147)
        Me._txtModel.Name = "_txtModel"
        Me._txtModel.Size = New System.Drawing.Size(278, 20)
        Me._txtModel.TabIndex = 6
        '
        '_btnCariPart
        '
        Me._btnCariPart.Image = CType(resources.GetObject("_btnCariPart.Image"), System.Drawing.Image)
        Me._btnCariPart.Location = New System.Drawing.Point(276, 63)
        Me._btnCariPart.Name = "_btnCariPart"
        Me._btnCariPart.Size = New System.Drawing.Size(25, 22)
        Me._btnCariPart.TabIndex = 20
        Me._btnCariPart.UseVisualStyleBackColor = True
        '
        'btnCariCust
        '
        Me.btnCariCust.Image = CType(resources.GetObject("btnCariCust.Image"), System.Drawing.Image)
        Me.btnCariCust.Location = New System.Drawing.Point(276, 7)
        Me.btnCariCust.Name = "btnCariCust"
        Me.btnCariCust.Size = New System.Drawing.Size(25, 22)
        Me.btnCariCust.TabIndex = 19
        Me.btnCariCust.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(548, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Tahun"
        '
        '_cmbTahun
        '
        Me._cmbTahun.FormattingEnabled = True
        Me._cmbTahun.Location = New System.Drawing.Point(669, 90)
        Me._cmbTahun.Name = "_cmbTahun"
        Me._cmbTahun.Size = New System.Drawing.Size(121, 21)
        Me._cmbTahun.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(548, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "InHouse / Subcont"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(548, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Site"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(548, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "OE / SP"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Model"
        '
        '_cmbInHouse
        '
        Me._cmbInHouse.FormattingEnabled = True
        Me._cmbInHouse.Items.AddRange(New Object() {"", "InHouse", "SubCont"})
        Me._cmbInHouse.Location = New System.Drawing.Point(669, 63)
        Me._cmbInHouse.Name = "_cmbInHouse"
        Me._cmbInHouse.Size = New System.Drawing.Size(121, 21)
        Me._cmbInHouse.TabIndex = 9
        '
        '_cmbSite
        '
        Me._cmbSite.FormattingEnabled = True
        Me._cmbSite.Items.AddRange(New Object() {"", "TNG-U", "TSC3-U"})
        Me._cmbSite.Location = New System.Drawing.Point(669, 36)
        Me._cmbSite.Name = "_cmbSite"
        Me._cmbSite.Size = New System.Drawing.Size(121, 21)
        Me._cmbSite.TabIndex = 8
        '
        '_cmbOeRe
        '
        Me._cmbOeRe.FormattingEnabled = True
        Me._cmbOeRe.Items.AddRange(New Object() {"", "OE", "SP"})
        Me._cmbOeRe.Location = New System.Drawing.Point(669, 9)
        Me._cmbOeRe.Name = "_cmbOeRe"
        Me._cmbOeRe.Size = New System.Drawing.Size(121, 21)
        Me._cmbOeRe.TabIndex = 7
        '
        '_txtPartName
        '
        Me._txtPartName.Location = New System.Drawing.Point(140, 119)
        Me._txtPartName.Name = "_txtPartName"
        Me._txtPartName.Size = New System.Drawing.Size(278, 20)
        Me._txtPartName.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Part Name"
        '
        '_txtInvtId
        '
        Me._txtInvtId.Location = New System.Drawing.Point(140, 91)
        Me._txtInvtId.Name = "_txtInvtId"
        Me._txtInvtId.Size = New System.Drawing.Size(278, 20)
        Me._txtInvtId.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Inventory ID"
        '
        '_txtPartNo
        '
        Me._txtPartNo.Location = New System.Drawing.Point(140, 63)
        Me._txtPartNo.Name = "_txtPartNo"
        Me._txtPartNo.Size = New System.Drawing.Size(121, 20)
        Me._txtPartNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Part No"
        '
        '_txtCustName
        '
        Me._txtCustName.Location = New System.Drawing.Point(140, 35)
        Me._txtCustName.Name = "_txtCustName"
        Me._txtCustName.Size = New System.Drawing.Size(278, 20)
        Me._txtCustName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer Name"
        '
        '_txtCustId
        '
        Me._txtCustId.Location = New System.Drawing.Point(140, 7)
        Me._txtCustId.Name = "_txtCustId"
        Me._txtCustId.Size = New System.Drawing.Size(121, 20)
        Me._txtCustId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer ID"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeight = 40
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBulan, Me.colRev0, Me.colRev1, Me.colRev2, Me.colPO0, Me.colPO1})
        Me.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.Grid.Location = New System.Drawing.Point(12, 248)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(800, 321)
        Me.Grid.TabIndex = 6
        '
        'colBulan
        '
        Me.colBulan.HeaderText = "Bulan"
        Me.colBulan.Name = "colBulan"
        '
        'colRev0
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRev0.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRev0.HeaderText = "FC 0"
        Me.colRev0.Name = "colRev0"
        Me.colRev0.Width = 75
        '
        'colRev1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRev1.DefaultCellStyle = DataGridViewCellStyle2
        Me.colRev1.HeaderText = "FC 1"
        Me.colRev1.Name = "colRev1"
        Me.colRev1.Width = 75
        '
        'colRev2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRev2.DefaultCellStyle = DataGridViewCellStyle3
        Me.colRev2.HeaderText = "FC 2"
        Me.colRev2.Name = "colRev2"
        Me.colRev2.Width = 75
        '
        'colPO0
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPO0.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPO0.HeaderText = "PO 0"
        Me.colPO0.Name = "colPO0"
        Me.colPO0.Width = 75
        '
        'colPO1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPO1.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPO1.HeaderText = "PO 1"
        Me.colPO1.Name = "colPO1"
        Me.colPO1.Width = 75
        '
        'frmSales_Forecast_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmSales_Forecast_detail"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents _btnCariPart As System.Windows.Forms.Button
    Friend WithEvents btnCariCust As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents _cmbTahun As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents _cmbInHouse As System.Windows.Forms.ComboBox
    Friend WithEvents _cmbSite As System.Windows.Forms.ComboBox
    Friend WithEvents _cmbOeRe As System.Windows.Forms.ComboBox
    Friend WithEvents _txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents _txtInvtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents _txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents _txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _txtCustId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _txtModel As System.Windows.Forms.TextBox
    Friend WithEvents Grid As DataGridView
    Friend WithEvents colBulan As DataGridViewTextBoxColumn
    Friend WithEvents colRev0 As DataGridViewTextBoxColumn
    Friend WithEvents colRev1 As DataGridViewTextBoxColumn
    Friend WithEvents colRev2 As DataGridViewTextBoxColumn
    Friend WithEvents colPO0 As DataGridViewTextBoxColumn
    Friend WithEvents colPO1 As DataGridViewTextBoxColumn
End Class
