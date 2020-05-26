<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportTravelSett
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.txtTravelID = New DevExpress.XtraEditors.TextEdit()
        Me.txtTravelSettleID = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtTravelID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelSettleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1055, 600)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'txtTravelID
        '
        Me.txtTravelID.Location = New System.Drawing.Point(506, 12)
        Me.txtTravelID.Name = "txtTravelID"
        Me.txtTravelID.Size = New System.Drawing.Size(125, 22)
        Me.txtTravelID.TabIndex = 1
        Me.txtTravelID.Visible = False
        '
        'txtTravelSettleID
        '
        Me.txtTravelSettleID.Location = New System.Drawing.Point(674, 15)
        Me.txtTravelSettleID.Name = "txtTravelSettleID"
        Me.txtTravelSettleID.Size = New System.Drawing.Size(125, 22)
        Me.txtTravelSettleID.TabIndex = 2
        '
        'FrmReportTravelSett
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 600)
        Me.Controls.Add(Me.txtTravelSettleID)
        Me.Controls.Add(Me.txtTravelID)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrmReportTravelSett"
        Me.Text = "FrmReportTravelSett"
        CType(Me.txtTravelID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelSettleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtTravelID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTravelSettleID As DevExpress.XtraEditors.TextEdit
End Class
