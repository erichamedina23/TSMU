<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Input_NPPDetail
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Input_NPPDetail))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TPartNo = New DevExpress.XtraEditors.TextEdit()
        Me.TPartName = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TMaterial = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbVibration = New System.Windows.Forms.CheckBox()
        Me.CUltrasonic = New System.Windows.Forms.CheckBox()
        Me.CAssy = New System.Windows.Forms.CheckBox()
        Me.CChrome = New System.Windows.Forms.CheckBox()
        Me.CPainting = New System.Windows.Forms.CheckBox()
        Me.CInjection = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TStatusMold = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TOrder = New DevExpress.XtraEditors.TextEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BFinish = New System.Windows.Forms.Button()
        Me.TMachine = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCt = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCav = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BPrev = New System.Windows.Forms.Button()
        Me.BNext = New System.Windows.Forms.Button()
        Me.TID = New DevExpress.XtraEditors.TextEdit()
        Me.TWeight = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TPartNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPartName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TStatusMold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCav.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.TID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Part No"
        '
        'TPartNo
        '
        Me.TPartNo.Location = New System.Drawing.Point(104, 40)
        Me.TPartNo.Name = "TPartNo"
        Me.TPartNo.Size = New System.Drawing.Size(210, 20)
        Me.TPartNo.TabIndex = 1
        '
        'TPartName
        '
        Me.TPartName.Location = New System.Drawing.Point(104, 66)
        Me.TPartName.Name = "TPartName"
        Me.TPartName.Size = New System.Drawing.Size(210, 20)
        Me.TPartName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Part Name"
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(266, 283)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(75, 23)
        Me.BAdd.TabIndex = 16
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Weight"
        '
        'TMaterial
        '
        Me.TMaterial.Location = New System.Drawing.Point(104, 170)
        Me.TMaterial.Name = "TMaterial"
        Me.TMaterial.Size = New System.Drawing.Size(210, 20)
        Me.TMaterial.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Material / Resin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbVibration)
        Me.GroupBox1.Controls.Add(Me.CUltrasonic)
        Me.GroupBox1.Controls.Add(Me.CAssy)
        Me.GroupBox1.Controls.Add(Me.CChrome)
        Me.GroupBox1.Controls.Add(Me.CPainting)
        Me.GroupBox1.Controls.Add(Me.CInjection)
        Me.GroupBox1.Location = New System.Drawing.Point(325, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(107, 206)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'CbVibration
        '
        Me.CbVibration.AutoSize = True
        Me.CbVibration.Location = New System.Drawing.Point(13, 158)
        Me.CbVibration.Name = "CbVibration"
        Me.CbVibration.Size = New System.Drawing.Size(67, 17)
        Me.CbVibration.TabIndex = 15
        Me.CbVibration.Text = "Vibration"
        Me.CbVibration.UseVisualStyleBackColor = True
        '
        'CUltrasonic
        '
        Me.CUltrasonic.AutoSize = True
        Me.CUltrasonic.Location = New System.Drawing.Point(13, 132)
        Me.CUltrasonic.Name = "CUltrasonic"
        Me.CUltrasonic.Size = New System.Drawing.Size(73, 17)
        Me.CUltrasonic.TabIndex = 14
        Me.CUltrasonic.Text = "Ultrasonic"
        Me.CUltrasonic.UseVisualStyleBackColor = True
        '
        'CAssy
        '
        Me.CAssy.AutoSize = True
        Me.CAssy.Location = New System.Drawing.Point(13, 106)
        Me.CAssy.Name = "CAssy"
        Me.CAssy.Size = New System.Drawing.Size(48, 17)
        Me.CAssy.TabIndex = 13
        Me.CAssy.Text = "Assy"
        Me.CAssy.UseVisualStyleBackColor = True
        '
        'CChrome
        '
        Me.CChrome.AutoSize = True
        Me.CChrome.Location = New System.Drawing.Point(13, 80)
        Me.CChrome.Name = "CChrome"
        Me.CChrome.Size = New System.Drawing.Size(62, 17)
        Me.CChrome.TabIndex = 12
        Me.CChrome.Text = "Chrome"
        Me.CChrome.UseVisualStyleBackColor = True
        '
        'CPainting
        '
        Me.CPainting.AutoSize = True
        Me.CPainting.Location = New System.Drawing.Point(13, 52)
        Me.CPainting.Name = "CPainting"
        Me.CPainting.Size = New System.Drawing.Size(64, 17)
        Me.CPainting.TabIndex = 11
        Me.CPainting.Text = "Painting"
        Me.CPainting.UseVisualStyleBackColor = True
        '
        'CInjection
        '
        Me.CInjection.AutoSize = True
        Me.CInjection.Location = New System.Drawing.Point(13, 22)
        Me.CInjection.Name = "CInjection"
        Me.CInjection.Size = New System.Drawing.Size(66, 17)
        Me.CInjection.TabIndex = 10
        Me.CInjection.Text = "Injection"
        Me.CInjection.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Status Mold"
        '
        'TStatusMold
        '
        Me.TStatusMold.Location = New System.Drawing.Point(104, 222)
        Me.TStatusMold.Name = "TStatusMold"
        Me.TStatusMold.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TStatusMold.Properties.Items.AddRange(New Object() {"Paid", "Depre", "Trans"})
        Me.TStatusMold.Size = New System.Drawing.Size(210, 20)
        Me.TStatusMold.TabIndex = 8
        '
        'TOrder
        '
        Me.TOrder.Location = New System.Drawing.Point(104, 247)
        Me.TOrder.Name = "TOrder"
        Me.TOrder.Properties.DisplayFormat.FormatString = "{0:N0}"
        Me.TOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TOrder.Size = New System.Drawing.Size(210, 20)
        Me.TOrder.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 246)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Order Of Month"
        '
        'BFinish
        '
        Me.BFinish.Location = New System.Drawing.Point(347, 283)
        Me.BFinish.Name = "BFinish"
        Me.BFinish.Size = New System.Drawing.Size(75, 23)
        Me.BFinish.TabIndex = 17
        Me.BFinish.Text = "Finish"
        Me.BFinish.UseVisualStyleBackColor = True
        '
        'TMachine
        '
        Me.TMachine.Location = New System.Drawing.Point(104, 92)
        Me.TMachine.Name = "TMachine"
        Me.TMachine.Size = New System.Drawing.Size(210, 20)
        Me.TMachine.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Machine"
        '
        'TCt
        '
        Me.TCt.Location = New System.Drawing.Point(104, 118)
        Me.TCt.Name = "TCt"
        Me.TCt.Size = New System.Drawing.Size(210, 20)
        Me.TCt.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "C/T"
        '
        'TCav
        '
        Me.TCav.Location = New System.Drawing.Point(104, 144)
        Me.TCav.Name = "TCav"
        Me.TCav.Size = New System.Drawing.Size(210, 20)
        Me.TCav.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Cav"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(453, 25)
        Me.BindingNavigator1.TabIndex = 32
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BPrev
        '
        Me.BPrev.Location = New System.Drawing.Point(104, 283)
        Me.BPrev.Name = "BPrev"
        Me.BPrev.Size = New System.Drawing.Size(75, 23)
        Me.BPrev.TabIndex = 33
        Me.BPrev.Text = "<"
        Me.BPrev.UseVisualStyleBackColor = True
        '
        'BNext
        '
        Me.BNext.Location = New System.Drawing.Point(185, 283)
        Me.BNext.Name = "BNext"
        Me.BNext.Size = New System.Drawing.Size(75, 23)
        Me.BNext.TabIndex = 34
        Me.BNext.Text = ">"
        Me.BNext.UseVisualStyleBackColor = True
        '
        'TID
        '
        Me.TID.Enabled = False
        Me.TID.Location = New System.Drawing.Point(325, 246)
        Me.TID.Name = "TID"
        Me.TID.Size = New System.Drawing.Size(107, 20)
        Me.TID.TabIndex = 35
        '
        'TWeight
        '
        Me.TWeight.Location = New System.Drawing.Point(104, 196)
        Me.TWeight.Name = "TWeight"
        Me.TWeight.Properties.DisplayFormat.FormatString = "{0:N0}"
        Me.TWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TWeight.Size = New System.Drawing.Size(210, 20)
        Me.TWeight.TabIndex = 36
        '
        'Frm_Input_NPPDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(453, 315)
        Me.Controls.Add(Me.TWeight)
        Me.Controls.Add(Me.TID)
        Me.Controls.Add(Me.BNext)
        Me.Controls.Add(Me.BPrev)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.TCav)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TCt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TMachine)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BFinish)
        Me.Controls.Add(Me.TOrder)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TMaterial)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.TPartName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TPartNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TStatusMold)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Input_NPPDetail"
        Me.Text = "NPP Detail"
        CType(Me.TPartNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPartName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TStatusMold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCav.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.TID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents Label1 As Label
    Friend WithEvents TPartNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TPartName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents BAdd As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TMaterial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CAssy As CheckBox
    Friend WithEvents CChrome As CheckBox
    Friend WithEvents CPainting As CheckBox
    Friend WithEvents CInjection As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TStatusMold As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TOrder As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label12 As Label
    Friend WithEvents BFinish As Button
    Friend WithEvents CUltrasonic As CheckBox
    Friend WithEvents CbVibration As CheckBox
    Friend WithEvents TMachine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TCt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TCav As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents BPrev As Button
    Friend WithEvents BNext As Button
    Friend WithEvents TID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TWeight As DevExpress.XtraEditors.TextEdit
End Class
