<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Input_NpwoDetail
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
        Me.BFinish = New System.Windows.Forms.Button()
        Me.TOrder = New DevExpress.XtraEditors.TextEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbVibration = New System.Windows.Forms.CheckBox()
        Me.CUltrasonic = New System.Windows.Forms.CheckBox()
        Me.CAssy = New System.Windows.Forms.CheckBox()
        Me.CChrome = New System.Windows.Forms.CheckBox()
        Me.CPainting = New System.Windows.Forms.CheckBox()
        Me.CInjection = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TStatusMold = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TWeight = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.TMaterial = New DevExpress.XtraEditors.TextEdit()
        Me.TPartName = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TPartNo = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TMachine = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCT = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCav = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TQtyMold = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TLOI = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TType = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.TOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TStatusMold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPartName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPartNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCav.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TQtyMold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLOI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BFinish
        '
        Me.BFinish.Location = New System.Drawing.Point(326, 293)
        Me.BFinish.Name = "BFinish"
        Me.BFinish.Size = New System.Drawing.Size(107, 23)
        Me.BFinish.TabIndex = 40
        Me.BFinish.Text = "Finish"
        Me.BFinish.UseVisualStyleBackColor = True
        '
        'TOrder
        '
        Me.TOrder.Location = New System.Drawing.Point(105, 244)
        Me.TOrder.Name = "TOrder"
        Me.TOrder.Size = New System.Drawing.Size(210, 20)
        Me.TOrder.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 247)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Order Of Month"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Status Mold"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbVibration)
        Me.GroupBox1.Controls.Add(Me.CUltrasonic)
        Me.GroupBox1.Controls.Add(Me.CAssy)
        Me.GroupBox1.Controls.Add(Me.CChrome)
        Me.GroupBox1.Controls.Add(Me.CPainting)
        Me.GroupBox1.Controls.Add(Me.CInjection)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(107, 229)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'CbVibration
        '
        Me.CbVibration.AutoSize = True
        Me.CbVibration.Location = New System.Drawing.Point(6, 190)
        Me.CbVibration.Name = "CbVibration"
        Me.CbVibration.Size = New System.Drawing.Size(67, 17)
        Me.CbVibration.TabIndex = 17
        Me.CbVibration.Text = "Vibration"
        Me.CbVibration.UseVisualStyleBackColor = True
        '
        'CUltrasonic
        '
        Me.CUltrasonic.AutoSize = True
        Me.CUltrasonic.Location = New System.Drawing.Point(6, 152)
        Me.CUltrasonic.Name = "CUltrasonic"
        Me.CUltrasonic.Size = New System.Drawing.Size(73, 17)
        Me.CUltrasonic.TabIndex = 16
        Me.CUltrasonic.Text = "Ultrasonic"
        Me.CUltrasonic.UseVisualStyleBackColor = True
        '
        'CAssy
        '
        Me.CAssy.AutoSize = True
        Me.CAssy.Location = New System.Drawing.Point(6, 116)
        Me.CAssy.Name = "CAssy"
        Me.CAssy.Size = New System.Drawing.Size(48, 17)
        Me.CAssy.TabIndex = 15
        Me.CAssy.Text = "Assy"
        Me.CAssy.UseVisualStyleBackColor = True
        '
        'CChrome
        '
        Me.CChrome.AutoSize = True
        Me.CChrome.Location = New System.Drawing.Point(6, 83)
        Me.CChrome.Name = "CChrome"
        Me.CChrome.Size = New System.Drawing.Size(62, 17)
        Me.CChrome.TabIndex = 14
        Me.CChrome.Text = "Chrome"
        Me.CChrome.UseVisualStyleBackColor = True
        '
        'CPainting
        '
        Me.CPainting.AutoSize = True
        Me.CPainting.Location = New System.Drawing.Point(6, 52)
        Me.CPainting.Name = "CPainting"
        Me.CPainting.Size = New System.Drawing.Size(64, 17)
        Me.CPainting.TabIndex = 13
        Me.CPainting.Text = "Painting"
        Me.CPainting.UseVisualStyleBackColor = True
        '
        'CInjection
        '
        Me.CInjection.AutoSize = True
        Me.CInjection.Location = New System.Drawing.Point(6, 19)
        Me.CInjection.Name = "CInjection"
        Me.CInjection.Size = New System.Drawing.Size(66, 17)
        Me.CInjection.TabIndex = 12
        Me.CInjection.Text = "Injection"
        Me.CInjection.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Material / Resin"
        '
        'TStatusMold
        '
        Me.TStatusMold.Location = New System.Drawing.Point(105, 215)
        Me.TStatusMold.Name = "TStatusMold"
        Me.TStatusMold.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TStatusMold.Properties.Items.AddRange(New Object() {"PAID", "DEPRE", "TRANS"})
        Me.TStatusMold.Size = New System.Drawing.Size(210, 20)
        Me.TStatusMold.TabIndex = 9
        '
        'TWeight
        '
        Me.TWeight.Location = New System.Drawing.Point(105, 137)
        Me.TWeight.Name = "TWeight"
        Me.TWeight.Size = New System.Drawing.Size(210, 20)
        Me.TWeight.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Weight"
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(326, 267)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(107, 23)
        Me.BAdd.TabIndex = 37
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'TMaterial
        '
        Me.TMaterial.Location = New System.Drawing.Point(105, 189)
        Me.TMaterial.Name = "TMaterial"
        Me.TMaterial.Size = New System.Drawing.Size(210, 20)
        Me.TMaterial.TabIndex = 8
        '
        'TPartName
        '
        Me.TPartName.Location = New System.Drawing.Point(105, 33)
        Me.TPartName.Name = "TPartName"
        Me.TPartName.Size = New System.Drawing.Size(210, 20)
        Me.TPartName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Part Name"
        '
        'TPartNo
        '
        Me.TPartNo.Location = New System.Drawing.Point(105, 6)
        Me.TPartNo.Name = "TPartNo"
        Me.TPartNo.Size = New System.Drawing.Size(210, 20)
        Me.TPartNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Part No"
        '
        'TMachine
        '
        Me.TMachine.Location = New System.Drawing.Point(105, 59)
        Me.TMachine.Name = "TMachine"
        Me.TMachine.Size = New System.Drawing.Size(210, 20)
        Me.TMachine.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Machine"
        '
        'TCT
        '
        Me.TCT.Location = New System.Drawing.Point(105, 85)
        Me.TCT.Name = "TCT"
        Me.TCT.Size = New System.Drawing.Size(210, 20)
        Me.TCT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Cycle Time"
        '
        'TCav
        '
        Me.TCav.Location = New System.Drawing.Point(105, 111)
        Me.TCav.Name = "TCav"
        Me.TCav.Size = New System.Drawing.Size(210, 20)
        Me.TCav.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Cav"
        '
        'TQtyMold
        '
        Me.TQtyMold.Location = New System.Drawing.Point(105, 163)
        Me.TQtyMold.Name = "TQtyMold"
        Me.TQtyMold.Size = New System.Drawing.Size(210, 20)
        Me.TQtyMold.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Qty Mold"
        '
        'TLOI
        '
        Me.TLOI.Location = New System.Drawing.Point(105, 270)
        Me.TLOI.Name = "TLOI"
        Me.TLOI.Size = New System.Drawing.Size(210, 20)
        Me.TLOI.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 273)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "LOI"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Type"
        '
        'TType
        '
        Me.TType.Location = New System.Drawing.Point(105, 296)
        Me.TType.Name = "TType"
        Me.TType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TType.Properties.Items.AddRange(New Object() {"MOLD", "PROCESS"})
        Me.TType.Size = New System.Drawing.Size(210, 20)
        Me.TType.TabIndex = 51
        '
        'Frm_Input_NpwoDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 335)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TType)
        Me.Controls.Add(Me.TLOI)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TQtyMold)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TCav)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TCT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TMachine)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BFinish)
        Me.Controls.Add(Me.TOrder)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TStatusMold)
        Me.Controls.Add(Me.TWeight)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.TMaterial)
        Me.Controls.Add(Me.TPartName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TPartNo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frm_Input_NpwoDetail"
        Me.Text = "Frm Input NPWO Detail"
        CType(Me.TOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TStatusMold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPartName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPartNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCav.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TQtyMold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLOI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BFinish As Button
    Friend WithEvents TOrder As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CbVibration As CheckBox
    Friend WithEvents CUltrasonic As CheckBox
    Friend WithEvents CAssy As CheckBox
    Friend WithEvents CChrome As CheckBox
    Friend WithEvents CPainting As CheckBox
    Friend WithEvents CInjection As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TStatusMold As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents BAdd As Button
    Friend WithEvents TMaterial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TPartName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TPartNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents TMachine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TCT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TCav As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents TQtyMold As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents TLOI As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TType As DevExpress.XtraEditors.ComboBoxEdit
End Class
