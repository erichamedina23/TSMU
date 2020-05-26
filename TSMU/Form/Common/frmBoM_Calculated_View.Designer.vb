<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBoM_Calculated_View
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
        Me.components = New System.ComponentModel.Container()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.btnFunction = New System.Windows.Forms.Button()
        Me.ContextFunc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowCalculatedBoMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateBoMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowCalculateBoMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextFunc.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(12, 28)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(804, 519)
        Me.Grid.TabIndex = 1
        '
        'btnFunction
        '
        Me.btnFunction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFunction.ContextMenuStrip = Me.ContextFunc
        Me.btnFunction.Location = New System.Drawing.Point(741, 553)
        Me.btnFunction.Name = "btnFunction"
        Me.btnFunction.Size = New System.Drawing.Size(75, 23)
        Me.btnFunction.TabIndex = 2
        Me.btnFunction.Text = "Function"
        Me.btnFunction.UseVisualStyleBackColor = True
        '
        'ContextFunc
        '
        Me.ContextFunc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowCalculatedBoMToolStripMenuItem, Me.CalculateBoMToolStripMenuItem, Me.ShowCalculateBoMToolStripMenuItem})
        Me.ContextFunc.Name = "ContextFunc"
        Me.ContextFunc.Size = New System.Drawing.Size(214, 70)
        '
        'ShowCalculatedBoMToolStripMenuItem
        '
        Me.ShowCalculatedBoMToolStripMenuItem.Name = "ShowCalculatedBoMToolStripMenuItem"
        Me.ShowCalculatedBoMToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ShowCalculatedBoMToolStripMenuItem.Text = "Show BoM to be Calculate"
        '
        'CalculateBoMToolStripMenuItem
        '
        Me.CalculateBoMToolStripMenuItem.Name = "CalculateBoMToolStripMenuItem"
        Me.CalculateBoMToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CalculateBoMToolStripMenuItem.Text = "Calculate BoM"
        '
        'ShowCalculateBoMToolStripMenuItem
        '
        Me.ShowCalculateBoMToolStripMenuItem.Name = "ShowCalculateBoMToolStripMenuItem"
        Me.ShowCalculateBoMToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ShowCalculateBoMToolStripMenuItem.Text = "Show Calculated BoM"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 553)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'frmBoM_Calculated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnFunction)
        Me.Controls.Add(Me.Grid)
        Me.KeyPreview = True
        Me.Name = "frmBoM_Calculated_View"
        Me.Text = "Form BoM Calculated View"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.btnFunction, 0)
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextFunc.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnFunction As Button
    Friend WithEvents ContextFunc As ContextMenuStrip
    Friend WithEvents CalculateBoMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowCalculatedBoMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ShowCalculateBoMToolStripMenuItem As ToolStripMenuItem
End Class
