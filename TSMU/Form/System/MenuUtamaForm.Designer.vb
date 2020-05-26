<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuUtamaForm
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsnChangePass = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbForecast = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetTSM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForecastTSM = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceTSM = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateTM = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoTsm = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstax = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstaxtransaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstaxreport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsTransaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReport1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDirect = New System.Windows.Forms.ToolStripMenuItem()
        Me.SJtsb = New System.Windows.Forms.ToolStripMenuItem()
        Me.WHJtsb = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fintsb = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDirect1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSuspend = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSettlement = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuAsakai = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuPOCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuTMMIN = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMenuTAM = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LblDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatMsg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblLogin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblGroup = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tsMenuCirculation = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.tsMenuMaster, Me.tsbForecast, Me.tsMenuSetting, Me.tsReport, Me.tstax, Me.tsPayment, Me.SJtsb, Me.tsDirect1, Me.tsMenuAsakai, Me.tsMenuPOCheck, Me.WindowsMenu, Me.HelpMenu, Me.tsMenuCirculation})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1084, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmLogin, Me.tsnChangePass, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(39, 20)
        Me.FileMenu.Text = "&File"
        '
        'tsmLogin
        '
        Me.tsmLogin.Enabled = False
        Me.tsmLogin.Name = "tsmLogin"
        Me.tsmLogin.Size = New System.Drawing.Size(216, 26)
        Me.tsmLogin.Text = "Log In"
        '
        'tsnChangePass
        '
        Me.tsnChangePass.Enabled = False
        Me.tsnChangePass.Name = "tsnChangePass"
        Me.tsnChangePass.Size = New System.Drawing.Size(216, 26)
        Me.tsnChangePass.Text = "Change Password"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(213, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'tsMenuMaster
        '
        Me.tsMenuMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenuMaster.Name = "tsMenuMaster"
        Me.tsMenuMaster.Size = New System.Drawing.Size(57, 20)
        Me.tsMenuMaster.Text = "Master"
        '
        'tsbForecast
        '
        Me.tsbForecast.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BudgetTSM, Me.ForecastTSM, Me.PriceTSM, Me.CalculateTM, Me.SoTsm})
        Me.tsbForecast.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbForecast.Name = "tsbForecast"
        Me.tsbForecast.Size = New System.Drawing.Size(50, 20)
        Me.tsbForecast.Text = "Sales"
        '
        'BudgetTSM
        '
        Me.BudgetTSM.Name = "BudgetTSM"
        Me.BudgetTSM.Size = New System.Drawing.Size(125, 22)
        Me.BudgetTSM.Text = "Budget"
        '
        'ForecastTSM
        '
        Me.ForecastTSM.Name = "ForecastTSM"
        Me.ForecastTSM.Size = New System.Drawing.Size(125, 22)
        Me.ForecastTSM.Text = "Forecast"
        '
        'PriceTSM
        '
        Me.PriceTSM.Name = "PriceTSM"
        Me.PriceTSM.Size = New System.Drawing.Size(125, 22)
        Me.PriceTSM.Text = "Price"
        '
        'CalculateTM
        '
        Me.CalculateTM.Name = "CalculateTM"
        Me.CalculateTM.Size = New System.Drawing.Size(125, 22)
        Me.CalculateTM.Text = "Calculate"
        '
        'SoTsm
        '
        Me.SoTsm.Name = "SoTsm"
        Me.SoTsm.Size = New System.Drawing.Size(143, 26)
        Me.SoTsm.Text = "SO"
        '
        'tsMenuSetting
        '
        Me.tsMenuSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenuSetting.Name = "tsMenuSetting"
        Me.tsMenuSetting.Size = New System.Drawing.Size(57, 20)
        Me.tsMenuSetting.Text = "Setting"
        '
        'tsReport
        '
        Me.tsReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(56, 20)
        Me.tsReport.Text = "Report"
        '
        'tstax
        '
        Me.tstax.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstaxtransaction, Me.tstaxreport})
        Me.tstax.Name = "tstax"
        Me.tstax.Size = New System.Drawing.Size(36, 20)
        Me.tstax.Text = "Tax"
        '
        'tstaxtransaction
        '
        Me.tstaxtransaction.Name = "tstaxtransaction"
        Me.tstaxtransaction.Size = New System.Drawing.Size(134, 22)
        Me.tstaxtransaction.Text = "Transaction"
        '
        'tstaxreport
        '
        Me.tstaxreport.Name = "tstaxreport"
        Me.tstaxreport.Size = New System.Drawing.Size(134, 22)
        Me.tstaxreport.Text = "Report"
        '
        'tsPayment
        '
        Me.tsPayment.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsTransaction, Me.tsReport1, Me.tsDirect})
        Me.tsPayment.Name = "tsPayment"
        Me.tsPayment.Size = New System.Drawing.Size(66, 20)
        Me.tsPayment.Text = "Payment"
        '
        'tsTransaction
        '
        Me.tsTransaction.Name = "tsTransaction"
        Me.tsTransaction.Size = New System.Drawing.Size(155, 22)
        Me.tsTransaction.Text = "Transaction"
        '
        'tsReport1
        '
        Me.tsReport1.Name = "tsReport1"
        Me.tsReport1.Size = New System.Drawing.Size(155, 22)
        Me.tsReport1.Text = "Report"
        '
        'tsDirect
        '
        Me.tsDirect.Name = "tsDirect"
        Me.tsDirect.Size = New System.Drawing.Size(155, 22)
        Me.tsDirect.Text = "Direct Payment"
        '
        'SJtsb
        '
        Me.SJtsb.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WHJtsb, Me.Fintsb})
        Me.SJtsb.Name = "SJtsb"
        Me.SJtsb.Size = New System.Drawing.Size(75, 20)
        Me.SJtsb.Text = "Surat Jalan"
        '
        'WHJtsb
        '
        Me.WHJtsb.Name = "WHJtsb"
        Me.WHJtsb.Size = New System.Drawing.Size(115, 22)
        Me.WHJtsb.Text = "WHJ"
        '
        'Fintsb
        '
        Me.Fintsb.Name = "Fintsb"
        Me.Fintsb.Size = New System.Drawing.Size(115, 22)
        Me.Fintsb.Text = "Finance"
        '
        'tsDirect1
        '
        Me.tsDirect1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSuspend, Me.tsSettlement})
        Me.tsDirect1.Name = "tsDirect1"
        Me.tsDirect1.Size = New System.Drawing.Size(100, 20)
        Me.tsDirect1.Text = "Direct Payment"
        '
        'tsSuspend
        '
        Me.tsSuspend.Name = "tsSuspend"
        Me.tsSuspend.Size = New System.Drawing.Size(180, 22)
        Me.tsSuspend.Text = "Advance"
        '
        'tsSettlement
        '
        Me.tsSettlement.Name = "tsSettlement"
        Me.tsSettlement.Size = New System.Drawing.Size(180, 22)
        Me.tsSettlement.Text = "Settlement"
        '
        'tsMenuAsakai
        '
        Me.tsMenuAsakai.Name = "tsMenuAsakai"
        Me.tsMenuAsakai.Size = New System.Drawing.Size(53, 20)
        Me.tsMenuAsakai.Text = "Asakai"
        '
        'tsMenuPOCheck
        '
        Me.tsMenuPOCheck.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMenuTMMIN, Me.tsMenuTAM})
        Me.tsMenuPOCheck.Name = "tsMenuPOCheck"
        Me.tsMenuPOCheck.Size = New System.Drawing.Size(88, 20)
        Me.tsMenuPOCheck.Text = "PO Checking"
        '
        'tsMenuTMMIN
        '
        Me.tsMenuTMMIN.Name = "tsMenuTMMIN"
        Me.tsMenuTMMIN.Size = New System.Drawing.Size(133, 26)
        Me.tsMenuTMMIN.Text = "TMMIN"
        '
        'tsMenuTAM
        '
        Me.tsMenuTAM.Name = "tsMenuTAM"
        Me.tsMenuTAM.Size = New System.Drawing.Size(133, 26)
        Me.tsMenuTAM.Text = "TAM"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseAllToolStripMenuItem})
        Me.WindowsMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(69, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(45, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblDatabase, Me.StatMsg, Me.LblRecords, Me.LblLogin, Me.lblGroup})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 324)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1084, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'LblDatabase
        '
        Me.LblDatabase.Name = "LblDatabase"
        Me.LblDatabase.Size = New System.Drawing.Size(55, 17)
        Me.LblDatabase.Text = "Database"
        '
        'StatMsg
        '
        Me.StatMsg.Name = "StatMsg"
        Me.StatMsg.Size = New System.Drawing.Size(826, 17)
        Me.StatMsg.Spring = True
        Me.StatMsg.Text = "Status"
        Me.StatMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRecords
        '
        Me.LblRecords.Name = "LblRecords"
        Me.LblRecords.Size = New System.Drawing.Size(63, 17)
        Me.LblRecords.Text = "0 record(s)"
        '
        'LblLogin
        '
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(63, 17)
        Me.LblLogin.Text = "Login User"
        '
        'lblGroup
        '
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(66, 17)
        Me.lblGroup.Text = "User Group"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'tsMenuTAM
        '
        Me.tsMenuCirculation.Name = "tsMenuCirculation"
        Me.tsMenuCirculation.Size = New System.Drawing.Size(77, 20)
        Me.tsMenuCirculation.Text = "Circulation"
        '
        'MenuUtamaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TSMU.My.Resources.Resources._85585d27229af16
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1084, 346)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MenuUtamaForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatMsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents LblDatabase As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblRecords As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblLogin As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMenuMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsnChangePass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMenuSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbForecast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblGroup As ToolStripStatusLabel
    Friend WithEvents BudgetTSM As ToolStripMenuItem
    Friend WithEvents ForecastTSM As ToolStripMenuItem
    Friend WithEvents PriceTSM As ToolStripMenuItem
    Friend WithEvents tsPayment As ToolStripMenuItem
    Friend WithEvents tsTransaction As ToolStripMenuItem
    Friend WithEvents tsReport1 As ToolStripMenuItem
    Friend WithEvents SJtsb As ToolStripMenuItem
    Friend WithEvents WHJtsb As ToolStripMenuItem
    Friend WithEvents Fintsb As ToolStripMenuItem
    Friend WithEvents tstax As ToolStripMenuItem
    Friend WithEvents tstaxtransaction As ToolStripMenuItem
    Friend WithEvents tstaxreport As ToolStripMenuItem
    Friend WithEvents CalculateTM As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents tsDirect As ToolStripMenuItem
    Friend WithEvents tsDirect1 As ToolStripMenuItem
    Friend WithEvents tsSuspend As ToolStripMenuItem
    Friend WithEvents tsSettlement As ToolStripMenuItem
    Friend WithEvents tsMenuAsakai As ToolStripMenuItem
    Friend WithEvents tsMenuPOCheck As ToolStripMenuItem
    Friend WithEvents tsMenuTMMIN As ToolStripMenuItem
    Friend WithEvents tsMenuTAM As ToolStripMenuItem
    Friend WithEvents tsMenuCirculation As ToolStripMenuItem
    Friend WithEvents SoTsm As ToolStripMenuItem
End Class
