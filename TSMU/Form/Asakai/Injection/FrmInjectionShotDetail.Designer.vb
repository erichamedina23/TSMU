<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInjectionShotDetail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Mesin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Merek = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NamaPart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Satu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Dua = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Tiga = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Empat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Lima = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Enam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Tujuh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delapan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Sembilan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Sepuluh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Keterangann = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_Pic = New DevExpress.XtraEditors.TextEdit()
        Me.DateTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.T_Shift = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Btn_Browse = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.T_Pic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Shift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(19, 165)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(797, 363)
        Me.Grid.TabIndex = 23
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Mesin, Me.Merek, Me.NamaPart, Me.Type, Me.Satu, Me.Dua, Me.Tiga, Me.Empat, Me.Lima, Me.Enam, Me.Tujuh, Me.Delapan, Me.Sembilan, Me.Sepuluh, Me.Keterangann})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(687, 284, 260, 232)
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Mesin
        '
        Me.Mesin.AppearanceCell.Options.UseTextOptions = True
        Me.Mesin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Mesin.AppearanceHeader.Options.UseTextOptions = True
        Me.Mesin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Mesin.FieldName = "Mesin"
        Me.Mesin.Name = "Mesin"
        Me.Mesin.Visible = True
        Me.Mesin.VisibleIndex = 0
        Me.Mesin.Width = 57
        '
        'Merek
        '
        Me.Merek.FieldName = "Merek"
        Me.Merek.Name = "Merek"
        Me.Merek.Visible = True
        Me.Merek.VisibleIndex = 1
        Me.Merek.Width = 253
        '
        'NamaPart
        '
        Me.NamaPart.FieldName = "Nama Part"
        Me.NamaPart.Name = "NamaPart"
        Me.NamaPart.Visible = True
        Me.NamaPart.VisibleIndex = 2
        Me.NamaPart.Width = 228
        '
        'Type
        '
        Me.Type.AppearanceCell.Options.UseTextOptions = True
        Me.Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.AppearanceHeader.Options.UseTextOptions = True
        Me.Type.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 3
        Me.Type.Width = 135
        '
        'Satu
        '
        Me.Satu.AppearanceCell.Options.UseTextOptions = True
        Me.Satu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Satu.AppearanceHeader.Options.UseTextOptions = True
        Me.Satu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Satu.FieldName = "1"
        Me.Satu.Name = "Satu"
        Me.Satu.Visible = True
        Me.Satu.VisibleIndex = 4
        Me.Satu.Width = 42
        '
        'Dua
        '
        Me.Dua.AppearanceCell.Options.UseTextOptions = True
        Me.Dua.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dua.AppearanceHeader.Options.UseTextOptions = True
        Me.Dua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dua.FieldName = "2"
        Me.Dua.Name = "Dua"
        Me.Dua.Visible = True
        Me.Dua.VisibleIndex = 5
        Me.Dua.Width = 42
        '
        'Tiga
        '
        Me.Tiga.AppearanceCell.Options.UseTextOptions = True
        Me.Tiga.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tiga.AppearanceHeader.Options.UseTextOptions = True
        Me.Tiga.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tiga.FieldName = "3"
        Me.Tiga.Name = "Tiga"
        Me.Tiga.Visible = True
        Me.Tiga.VisibleIndex = 6
        Me.Tiga.Width = 40
        '
        'Empat
        '
        Me.Empat.AppearanceCell.Options.UseTextOptions = True
        Me.Empat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Empat.AppearanceHeader.Options.UseTextOptions = True
        Me.Empat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Empat.FieldName = "4"
        Me.Empat.Name = "Empat"
        Me.Empat.Visible = True
        Me.Empat.VisibleIndex = 7
        Me.Empat.Width = 39
        '
        'Lima
        '
        Me.Lima.AppearanceCell.Options.UseTextOptions = True
        Me.Lima.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Lima.AppearanceHeader.Options.UseTextOptions = True
        Me.Lima.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Lima.FieldName = "5"
        Me.Lima.Name = "Lima"
        Me.Lima.Visible = True
        Me.Lima.VisibleIndex = 8
        Me.Lima.Width = 39
        '
        'Enam
        '
        Me.Enam.AppearanceCell.Options.UseTextOptions = True
        Me.Enam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Enam.AppearanceHeader.Options.UseTextOptions = True
        Me.Enam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Enam.FieldName = "6"
        Me.Enam.Name = "Enam"
        Me.Enam.Visible = True
        Me.Enam.VisibleIndex = 9
        Me.Enam.Width = 41
        '
        'Tujuh
        '
        Me.Tujuh.AppearanceCell.Options.UseTextOptions = True
        Me.Tujuh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tujuh.AppearanceHeader.Options.UseTextOptions = True
        Me.Tujuh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tujuh.FieldName = "7"
        Me.Tujuh.Name = "Tujuh"
        Me.Tujuh.Visible = True
        Me.Tujuh.VisibleIndex = 10
        Me.Tujuh.Width = 41
        '
        'Delapan
        '
        Me.Delapan.AppearanceCell.Options.UseTextOptions = True
        Me.Delapan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Delapan.AppearanceHeader.Options.UseTextOptions = True
        Me.Delapan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Delapan.FieldName = "8"
        Me.Delapan.Name = "Delapan"
        Me.Delapan.Visible = True
        Me.Delapan.VisibleIndex = 11
        Me.Delapan.Width = 47
        '
        'Sembilan
        '
        Me.Sembilan.AppearanceCell.Options.UseTextOptions = True
        Me.Sembilan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Sembilan.AppearanceHeader.Options.UseTextOptions = True
        Me.Sembilan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Sembilan.FieldName = "9"
        Me.Sembilan.Name = "Sembilan"
        Me.Sembilan.Visible = True
        Me.Sembilan.VisibleIndex = 12
        Me.Sembilan.Width = 39
        '
        'Sepuluh
        '
        Me.Sepuluh.AppearanceCell.Options.UseTextOptions = True
        Me.Sepuluh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Sepuluh.AppearanceHeader.Options.UseTextOptions = True
        Me.Sepuluh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Sepuluh.FieldName = "10"
        Me.Sepuluh.Name = "Sepuluh"
        Me.Sepuluh.Visible = True
        Me.Sepuluh.VisibleIndex = 13
        Me.Sepuluh.Width = 43
        '
        'Keterangann
        '
        Me.Keterangann.FieldName = "Keterangan"
        Me.Keterangann.Name = "Keterangann"
        Me.Keterangann.Visible = True
        Me.Keterangann.VisibleIndex = 14
        Me.Keterangann.Width = 221
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LayoutControl1.Controls.Add(Me.T_Pic)
        Me.LayoutControl1.Controls.Add(Me.DateTanggal)
        Me.LayoutControl1.Controls.Add(Me.T_Shift)
        Me.LayoutControl1.Location = New System.Drawing.Point(12, 28)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(543, 300, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(809, 106)
        Me.LayoutControl1.TabIndex = 24
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'T_Pic
        '
        Me.T_Pic.Location = New System.Drawing.Point(61, 60)
        Me.T_Pic.Name = "T_Pic"
        Me.T_Pic.Size = New System.Drawing.Size(81, 20)
        Me.T_Pic.StyleController = Me.LayoutControl1
        Me.T_Pic.TabIndex = 6
        '
        'DateTanggal
        '
        Me.DateTanggal.EditValue = Nothing
        Me.DateTanggal.Location = New System.Drawing.Point(61, 12)
        Me.DateTanggal.Name = "DateTanggal"
        Me.DateTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTanggal.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.DateTanggal.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DateTanggal.Properties.Mask.EditMask = ""
        Me.DateTanggal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.DateTanggal.Size = New System.Drawing.Size(81, 20)
        Me.DateTanggal.StyleController = Me.LayoutControl1
        Me.DateTanggal.TabIndex = 4
        '
        'T_Shift
        '
        Me.T_Shift.Location = New System.Drawing.Point(61, 36)
        Me.T_Shift.Name = "T_Shift"
        Me.T_Shift.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Shift.Properties.Items.AddRange(New Object() {"1", "2", "3"})
        Me.T_Shift.Size = New System.Drawing.Size(81, 20)
        Me.T_Shift.StyleController = Me.LayoutControl1
        Me.T_Shift.TabIndex = 5
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(809, 106)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DateTanggal
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem1.Text = "TANGGAL"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(46, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(789, 14)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.T_Shift
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem2.Text = "SHIFT"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.T_Pic
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(134, 24)
        Me.LayoutControlItem3.Text = "PIC"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(46, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(134, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(655, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(134, 24)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(655, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(134, 48)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(655, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'Btn_Browse
        '
        Me.Btn_Browse.Location = New System.Drawing.Point(19, 133)
        Me.Btn_Browse.Name = "Btn_Browse"
        Me.Btn_Browse.Size = New System.Drawing.Size(91, 28)
        Me.Btn_Browse.TabIndex = 25
        Me.Btn_Browse.Text = "Browse"
        Me.Btn_Browse.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmInjectionShotDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(828, 530)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Btn_Browse)
        Me.Name = "FrmInjectionShotDetail"
        Me.Controls.SetChildIndex(Me.Btn_Browse, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.T_Pic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Shift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents T_Pic As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Btn_Browse As Button
    Friend WithEvents T_Shift As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Mesin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Merek As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NamaPart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Satu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Dua As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Tiga As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Empat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Lima As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Enam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Tujuh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Delapan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Sembilan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Sepuluh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Keterangann As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
