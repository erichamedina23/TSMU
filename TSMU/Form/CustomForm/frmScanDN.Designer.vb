<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanDN
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSopir = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoDn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPolisi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPolisi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSopir = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1082, 213)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtSopir)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNoDn)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtPolisi)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1074, 184)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(212, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 39)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = ":"
        '
        'txtSopir
        '
        Me.txtSopir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSopir.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSopir.Location = New System.Drawing.Point(244, 66)
        Me.txtSopir.Name = "txtSopir"
        Me.txtSopir.Size = New System.Drawing.Size(505, 45)
        Me.txtSopir.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 39)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "SOPIR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(212, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 39)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(212, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 39)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = ":"
        '
        'txtNoDn
        '
        Me.txtNoDn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoDn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoDn.Location = New System.Drawing.Point(244, 117)
        Me.txtNoDn.Name = "txtNoDn"
        Me.txtNoDn.Size = New System.Drawing.Size(505, 45)
        Me.txtNoDn.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 39)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "NO. DN"
        '
        'txtPolisi
        '
        Me.txtPolisi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPolisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolisi.Location = New System.Drawing.Point(244, 15)
        Me.txtPolisi.Name = "txtPolisi"
        Me.txtPolisi.Size = New System.Drawing.Size(349, 45)
        Me.txtPolisi.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 39)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "NO. POLISI"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(12, 231)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(1078, 57)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "CLEAR DATA"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 294)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1078, 402)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNo, Me.colPolisi, Me.colSopir, Me.colDn})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colNo
        '
        Me.colNo.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.colNo.AppearanceCell.Options.UseFont = True
        Me.colNo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.colNo.AppearanceHeader.Options.UseFont = True
        Me.colNo.Caption = "No"
        Me.colNo.FieldName = "no"
        Me.colNo.MinWidth = 25
        Me.colNo.Name = "colNo"
        Me.colNo.Visible = True
        Me.colNo.VisibleIndex = 0
        Me.colNo.Width = 94
        '
        'colPolisi
        '
        Me.colPolisi.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.colPolisi.AppearanceCell.Options.UseFont = True
        Me.colPolisi.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.colPolisi.AppearanceHeader.Options.UseFont = True
        Me.colPolisi.Caption = "No. Polisi"
        Me.colPolisi.FieldName = "noPol"
        Me.colPolisi.MinWidth = 25
        Me.colPolisi.Name = "colPolisi"
        Me.colPolisi.Visible = True
        Me.colPolisi.VisibleIndex = 1
        Me.colPolisi.Width = 221
        '
        'colSopir
        '
        Me.colSopir.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.colSopir.AppearanceCell.Options.UseFont = True
        Me.colSopir.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.colSopir.AppearanceHeader.Options.UseFont = True
        Me.colSopir.Caption = "Sopir"
        Me.colSopir.FieldName = "sopir"
        Me.colSopir.MinWidth = 25
        Me.colSopir.Name = "colSopir"
        Me.colSopir.Visible = True
        Me.colSopir.VisibleIndex = 2
        Me.colSopir.Width = 192
        '
        'colDn
        '
        Me.colDn.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.colDn.AppearanceCell.Options.UseFont = True
        Me.colDn.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.colDn.AppearanceHeader.Options.UseFont = True
        Me.colDn.Caption = "No. DN / Order No"
        Me.colDn.FieldName = "noDn"
        Me.colDn.MinWidth = 25
        Me.colDn.Name = "colDn"
        Me.colDn.Visible = True
        Me.colDn.VisibleIndex = 3
        Me.colDn.Width = 410
        '
        'frmScanDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1106, 708)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScanDN"
        Me.Text = "SCAN NO. DN"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSopir As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNoDn As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPolisi As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPolisi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSopir As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
