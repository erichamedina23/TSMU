<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory_detail
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me._txtRemark = New System.Windows.Forms.TextBox()
        Me._txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me._cmbGroup = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me._txtMflg = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me._txtPacking = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me._txtCarModel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me._txtPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._txtMinStok = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._cmbUnit = New System.Windows.Forms.ComboBox()
        Me._txtDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._txtInvtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(804, 359)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._txtRemark)
        Me.TabPage1.Controls.Add(Me._txtPartNo)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me._cmbGroup)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me._txtMflg)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me._txtPacking)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me._txtCarModel)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me._txtPO)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me._txtUnitPrice)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me._txtMinStok)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me._cmbUnit)
        Me.TabPage1.Controls.Add(Me._txtDesc)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me._txtInvtId)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(796, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input Inventory"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_txtRemark
        '
        Me._txtRemark.Location = New System.Drawing.Point(660, 136)
        Me._txtRemark.Multiline = True
        Me._txtRemark.Name = "_txtRemark"
        Me._txtRemark.Size = New System.Drawing.Size(121, 71)
        Me._txtRemark.TabIndex = 12
        '
        '_txtPartNo
        '
        Me._txtPartNo.Location = New System.Drawing.Point(89, 59)
        Me._txtPartNo.Name = "_txtPartNo"
        Me._txtPartNo.Size = New System.Drawing.Size(121, 22)
        Me._txtPartNo.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Group"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(574, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Remark"
        '
        '_cmbGroup
        '
        Me._cmbGroup.FormattingEnabled = True
        Me._cmbGroup.Items.AddRange(New Object() {"", "FG", "PC"})
        Me._cmbGroup.Location = New System.Drawing.Point(89, 138)
        Me._cmbGroup.Name = "_cmbGroup"
        Me._cmbGroup.Size = New System.Drawing.Size(121, 21)
        Me._cmbGroup.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Part No"
        '
        '_txtMflg
        '
        Me._txtMflg.Location = New System.Drawing.Point(660, 110)
        Me._txtMflg.Name = "_txtMflg"
        Me._txtMflg.Size = New System.Drawing.Size(121, 22)
        Me._txtMflg.TabIndex = 11
        Me._txtMflg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(574, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Mfg Lead Time"
        '
        '_txtPacking
        '
        Me._txtPacking.Location = New System.Drawing.Point(660, 7)
        Me._txtPacking.Name = "_txtPacking"
        Me._txtPacking.Size = New System.Drawing.Size(121, 22)
        Me._txtPacking.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Unit"
        '
        '_txtCarModel
        '
        Me._txtCarModel.Location = New System.Drawing.Point(89, 86)
        Me._txtCarModel.Name = "_txtCarModel"
        Me._txtCarModel.Size = New System.Drawing.Size(121, 22)
        Me._txtCarModel.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Car Model"
        '
        '_txtPO
        '
        Me._txtPO.Location = New System.Drawing.Point(660, 85)
        Me._txtPO.Name = "_txtPO"
        Me._txtPO.Size = New System.Drawing.Size(121, 22)
        Me._txtPO.TabIndex = 10
        Me._txtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(574, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "PO Lead Time"
        '
        '_txtUnitPrice
        '
        Me._txtUnitPrice.Location = New System.Drawing.Point(660, 59)
        Me._txtUnitPrice.Name = "_txtUnitPrice"
        Me._txtUnitPrice.Size = New System.Drawing.Size(121, 22)
        Me._txtUnitPrice.TabIndex = 9
        Me._txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(574, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unit Price"
        '
        '_txtMinStok
        '
        Me._txtMinStok.Location = New System.Drawing.Point(660, 33)
        Me._txtMinStok.Name = "_txtMinStok"
        Me._txtMinStok.Size = New System.Drawing.Size(121, 22)
        Me._txtMinStok.TabIndex = 8
        Me._txtMinStok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(574, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Min Stok"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(574, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Packing"
        '
        '_cmbUnit
        '
        Me._cmbUnit.FormattingEnabled = True
        Me._cmbUnit.Items.AddRange(New Object() {"", "CAN", "KG", "LITER", "METER", "PCS", "ROLL", "SET", "UNIT"})
        Me._cmbUnit.Location = New System.Drawing.Point(89, 112)
        Me._cmbUnit.Name = "_cmbUnit"
        Me._cmbUnit.Size = New System.Drawing.Size(121, 21)
        Me._cmbUnit.TabIndex = 5
        '
        '_txtDesc
        '
        Me._txtDesc.Location = New System.Drawing.Point(89, 33)
        Me._txtDesc.Name = "_txtDesc"
        Me._txtDesc.Size = New System.Drawing.Size(286, 22)
        Me._txtDesc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description"
        '
        '_txtInvtId
        '
        Me._txtInvtId.Location = New System.Drawing.Point(89, 7)
        Me._txtInvtId.Name = "_txtInvtId"
        Me._txtInvtId.Size = New System.Drawing.Size(121, 22)
        Me._txtInvtId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invotory ID"
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'frmInventory_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmInventory_detail"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents _txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents _txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents _txtMinStok As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents _cmbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents _txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _txtInvtId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _txtCarModel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents _txtPacking As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents _cmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents _txtMflg As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents _txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents _txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider

End Class
