<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSystem_FilterData
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridFilter = New System.Windows.Forms.DataGridView()
        Me.colFilter = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colOperator = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNilai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnClearFilter = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        CType(Me.GridFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridFilter
        '
        Me.GridFilter.AllowUserToAddRows = False
        Me.GridFilter.ColumnHeadersHeight = 40
        Me.GridFilter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFilter, Me.colOperator, Me.colNilai})
        Me.GridFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GridFilter.Location = New System.Drawing.Point(13, 13)
        Me.GridFilter.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GridFilter.Name = "GridFilter"
        Me.GridFilter.Size = New System.Drawing.Size(485, 262)
        Me.GridFilter.TabIndex = 0
        '
        'colFilter
        '
        Me.colFilter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colFilter.DefaultCellStyle = DataGridViewCellStyle4
        Me.colFilter.HeaderText = "Filter"
        Me.colFilter.Name = "colFilter"
        '
        'colOperator
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colOperator.DefaultCellStyle = DataGridViewCellStyle5
        Me.colOperator.HeaderText = "Operator"
        Me.colOperator.Items.AddRange(New Object() {"=", "LIKE", "<>", ">=", "<="})
        Me.colOperator.Name = "colOperator"
        '
        'colNilai
        '
        Me.colNilai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNilai.DefaultCellStyle = DataGridViewCellStyle6
        Me.colNilai.HeaderText = "Nilai"
        Me.colNilai.Name = "colNilai"
        '
        'BtnClearFilter
        '
        Me.BtnClearFilter.Location = New System.Drawing.Point(13, 281)
        Me.BtnClearFilter.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnClearFilter.Name = "BtnClearFilter"
        Me.BtnClearFilter.Size = New System.Drawing.Size(86, 32)
        Me.BtnClearFilter.TabIndex = 6
        Me.BtnClearFilter.Text = "Clear Filter"
        Me.BtnClearFilter.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(317, 281)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 32)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(410, 281)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(86, 32)
        Me.BtnOK.TabIndex = 4
        Me.BtnOK.Text = "Ok"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'FrmSystem_FilterData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 325)
        Me.Controls.Add(Me.BtnClearFilter)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GridFilter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "FrmSystem_FilterData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSystem_FilterData"
        CType(Me.GridFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridFilter As System.Windows.Forms.DataGridView
    Friend WithEvents BtnClearFilter As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents colFilter As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOperator As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNilai As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
