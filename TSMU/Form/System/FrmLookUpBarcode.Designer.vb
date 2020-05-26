<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLookUpBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLookUpBarcode))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodePart = New DevExpress.XtraEditors.TextEdit()
        Me.CmbBulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtFrom = New DevExpress.XtraEditors.SpinEdit()
        Me.TxtTo = New DevExpress.XtraEditors.SpinEdit()
        Me.TxtSite = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtTgl = New DevExpress.XtraEditors.DateEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cmbTahun = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodePart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtNo)
        Me.LayoutControl1.Controls.Add(Me.TxtKodePart)
        Me.LayoutControl1.Controls.Add(Me.CmbBulan)
        Me.LayoutControl1.Controls.Add(Me.TxtFrom)
        Me.LayoutControl1.Controls.Add(Me.TxtTo)
        Me.LayoutControl1.Controls.Add(Me.TxtSite)
        Me.LayoutControl1.Controls.Add(Me.TxtTgl)
        Me.LayoutControl1.Controls.Add(Me.cmbTahun)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(395, 313)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtNo
        '
        Me.txtNo.Location = New System.Drawing.Point(12, 145)
        Me.txtNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 60.0!, System.Drawing.FontStyle.Bold)
        Me.txtNo.Properties.Appearance.Options.UseFont = True
        Me.txtNo.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtNo.Properties.ReadOnly = True
        Me.txtNo.Size = New System.Drawing.Size(358, 128)
        Me.txtNo.StyleController = Me.LayoutControl1
        Me.txtNo.TabIndex = 7
        '
        'TxtKodePart
        '
        Me.TxtKodePart.Location = New System.Drawing.Point(119, 64)
        Me.TxtKodePart.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtKodePart.Name = "TxtKodePart"
        Me.TxtKodePart.Size = New System.Drawing.Size(264, 22)
        Me.TxtKodePart.StyleController = Me.LayoutControl1
        Me.TxtKodePart.TabIndex = 2
        '
        'CmbBulan
        '
        Me.CmbBulan.Location = New System.Drawing.Point(119, 90)
        Me.CmbBulan.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbBulan.Name = "CmbBulan"
        Me.CmbBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbBulan.Properties.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CmbBulan.Size = New System.Drawing.Size(97, 22)
        Me.CmbBulan.StyleController = Me.LayoutControl1
        Me.CmbBulan.TabIndex = 3
        '
        'TxtFrom
        '
        Me.TxtFrom.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtFrom.Location = New System.Drawing.Point(119, 116)
        Me.TxtFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFrom.Name = "TxtFrom"
        Me.TxtFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtFrom.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TxtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtFrom.Size = New System.Drawing.Size(97, 22)
        Me.TxtFrom.StyleController = Me.LayoutControl1
        Me.TxtFrom.TabIndex = 4
        '
        'TxtTo
        '
        Me.TxtTo.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtTo.Location = New System.Drawing.Point(292, 116)
        Me.TxtTo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TxtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtTo.Size = New System.Drawing.Size(91, 22)
        Me.TxtTo.StyleController = Me.LayoutControl1
        Me.TxtTo.TabIndex = 5
        '
        'TxtSite
        '
        Me.TxtSite.Location = New System.Drawing.Point(119, 38)
        Me.TxtSite.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtSite.Properties.Items.AddRange(New Object() {"INJECTION", "PAINTING"})
        Me.TxtSite.Size = New System.Drawing.Size(264, 22)
        Me.TxtSite.StyleController = Me.LayoutControl1
        Me.TxtSite.TabIndex = 1
        '
        'TxtTgl
        '
        Me.TxtTgl.EditValue = Nothing
        Me.TxtTgl.Location = New System.Drawing.Point(119, 12)
        Me.TxtTgl.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTgl.Name = "TxtTgl"
        Me.TxtTgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtTgl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtTgl.Properties.Mask.EditMask = ""
        Me.TxtTgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtTgl.Size = New System.Drawing.Size(264, 22)
        Me.TxtTgl.StyleController = Me.LayoutControl1
        Me.TxtTgl.TabIndex = 8
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(395, 313)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(362, 133)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(13, 160)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtKodePart
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(375, 26)
        Me.LayoutControlItem3.Text = "Kode Part"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(104, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtFrom
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(208, 29)
        Me.LayoutControlItem4.Text = "No Passcard From"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(104, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtTo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(208, 104)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(167, 29)
        Me.LayoutControlItem5.Text = "To"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(67, 25)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtSite
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(375, 26)
        Me.LayoutControlItem6.Text = "Proses"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(104, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CmbBulan
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(208, 26)
        Me.LayoutControlItem2.Text = "Bulan"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(104, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtNo
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 133)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(362, 160)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TxtTgl
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(375, 26)
        Me.LayoutControlItem8.Text = "Tanggal"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(104, 16)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(395, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(63, 24)
        Me.BtnPrint.Text = "Print"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmbTahun
        Me.LayoutControlItem1.Location = New System.Drawing.Point(208, 78)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(167, 26)
        Me.LayoutControlItem1.Text = "Tahun"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(67, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'cmbTahun
        '
        Me.cmbTahun.Location = New System.Drawing.Point(292, 90)
        Me.cmbTahun.Name = "cmbTahun"
        Me.cmbTahun.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTahun.Size = New System.Drawing.Size(91, 22)
        Me.cmbTahun.StyleController = Me.LayoutControl1
        Me.cmbTahun.TabIndex = 9
        '
        'FrmLookUpBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 340)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLookUpBarcode"
        Me.Text = "Filter"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodePart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnPrint As ToolStripButton
    Friend WithEvents TxtKodePart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CmbBulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtFrom As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents TxtTo As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents TxtSite As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtTgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbTahun As DevExpress.XtraEditors.ComboBoxEdit
End Class
