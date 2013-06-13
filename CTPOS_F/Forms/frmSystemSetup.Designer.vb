<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemSetup))
        Me.tabWS = New System.Windows.Forms.TabControl
        Me.TabDBConnect = New System.Windows.Forms.TabPage
        Me.txtConnString = New System.Windows.Forms.TextBox
        Me.btnFindCTPOS_B = New System.Windows.Forms.Button
        Me.btnFindCTMain_B = New System.Windows.Forms.Button
        Me.cmdTestPOS = New System.Windows.Forms.Button
        Me.cmdTestMain = New System.Windows.Forms.Button
        Me.txtSQLPassword = New System.Windows.Forms.TextBox
        Me.lblSQLPassword = New System.Windows.Forms.Label
        Me.txtSQLUsername = New System.Windows.Forms.TextBox
        Me.lblSQLUsername = New System.Windows.Forms.Label
        Me.txtSQLDatabase = New System.Windows.Forms.TextBox
        Me.lblSQLDatabase = New System.Windows.Forms.Label
        Me.txtSQLServer = New System.Windows.Forms.TextBox
        Me.lblSQLServer = New System.Windows.Forms.Label
        Me.btnSetConnection = New System.Windows.Forms.Button
        Me.lblMainConnection = New System.Windows.Forms.Label
        Me.lblPOSConnection = New System.Windows.Forms.Label
        Me.txtMainConnection = New System.Windows.Forms.TextBox
        Me.txtPOSConnection = New System.Windows.Forms.TextBox
        Me.fraPOSDBType = New System.Windows.Forms.GroupBox
        Me.radSQLServer = New System.Windows.Forms.RadioButton
        Me.radMSAccess = New System.Windows.Forms.RadioButton
        Me.tabReceiptPrinter = New System.Windows.Forms.TabPage
        Me.chkOneCCReceipt = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TBLinesAfter = New System.Windows.Forms.TrackBar
        Me.tbLinesBefore = New System.Windows.Forms.TrackBar
        Me.chkUsePrinter = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFooter2 = New System.Windows.Forms.Label
        Me.lblFooter1 = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.txtFooter2 = New System.Windows.Forms.TextBox
        Me.txtFooter1 = New System.Windows.Forms.TextBox
        Me.txtHeader = New System.Windows.Forms.TextBox
        Me.btnSetPrinter = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnTestPrint = New System.Windows.Forms.Button
        Me.cboPrinterSelect = New System.Windows.Forms.ComboBox
        Me.tabDrawer = New System.Windows.Forms.TabPage
        Me.chkUseBell = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDrawerPort = New System.Windows.Forms.Label
        Me.txtDrawerPort = New System.Windows.Forms.TextBox
        Me.btnTestDrawer = New System.Windows.Forms.Button
        Me.tabSettings = New System.Windows.Forms.TabPage
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtSpendingRefDur = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtTestAmount = New System.Windows.Forms.TextBox
        Me.btnTestLiveCharge = New System.Windows.Forms.Button
        Me.chkCamperSort = New System.Windows.Forms.CheckBox
        Me.txtCashLinqPW = New System.Windows.Forms.TextBox
        Me.txtCashLinqUser = New System.Windows.Forms.TextBox
        Me.lblCashLinqPW = New System.Windows.Forms.Label
        Me.lblCashLinqUser = New System.Windows.Forms.Label
        Me.btnSetXChargePath = New System.Windows.Forms.Button
        Me.lblXChargePath = New System.Windows.Forms.Label
        Me.txtXChargePath = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCCMethod = New System.Windows.Forms.ComboBox
        Me.cmdSaveSettings = New System.Windows.Forms.Button
        Me.txtStationID = New System.Windows.Forms.TextBox
        Me.lblStationID = New System.Windows.Forms.Label
        Me.txtStoreID = New System.Windows.Forms.TextBox
        Me.lblStoreID = New System.Windows.Forms.Label
        Me.txtTaxRate = New System.Windows.Forms.TextBox
        Me.lblTaxRate = New System.Windows.Forms.Label
        Me.tabStoreSetup = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboInventory = New System.Windows.Forms.ComboBox
        Me.btnSaveClose = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkAlwaysPrintReceipt = New System.Windows.Forms.CheckBox
        Me.txtRecptSignOff2 = New System.Windows.Forms.TextBox
        Me.txtRecptSignOff1 = New System.Windows.Forms.TextBox
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.tabClerks = New System.Windows.Forms.TabPage
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.chkAdmin = New System.Windows.Forms.CheckBox
        Me.chkNewUser = New System.Windows.Forms.CheckBox
        Me.btnDeleteClerk = New System.Windows.Forms.Button
        Me.btnNewClerk = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lstUsers = New System.Windows.Forms.ListBox
        Me.btnSaveClerks = New System.Windows.Forms.Button
        Me.tabStores = New System.Windows.Forms.TabPage
        Me.txtStoreEditID = New System.Windows.Forms.TextBox
        Me.cboSite = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtStoreNameEdit = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.chkNewStore = New System.Windows.Forms.CheckBox
        Me.btnDeleteStore = New System.Windows.Forms.Button
        Me.btnNewStore = New System.Windows.Forms.Button
        Me.lstStores = New System.Windows.Forms.ListBox
        Me.btnSaveStore = New System.Windows.Forms.Button
        Me.tabDepartments = New System.Windows.Forms.TabPage
        Me.txtDepartmentID = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.chkNewDepartment = New System.Windows.Forms.CheckBox
        Me.btnDeleteDept = New System.Windows.Forms.Button
        Me.btnNewDept = New System.Windows.Forms.Button
        Me.lstDepartments = New System.Windows.Forms.ListBox
        Me.btnSaveDepartment = New System.Windows.Forms.Button
        Me.btnImportSettings = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.tabWS.SuspendLayout()
        Me.TabDBConnect.SuspendLayout()
        Me.fraPOSDBType.SuspendLayout()
        Me.tabReceiptPrinter.SuspendLayout()
        CType(Me.TBLinesAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLinesBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDrawer.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.tabStoreSetup.SuspendLayout()
        Me.tabClerks.SuspendLayout()
        Me.tabStores.SuspendLayout()
        Me.tabDepartments.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabWS
        '
        Me.tabWS.Controls.Add(Me.TabDBConnect)
        Me.tabWS.Controls.Add(Me.tabReceiptPrinter)
        Me.tabWS.Controls.Add(Me.tabDrawer)
        Me.tabWS.Controls.Add(Me.tabSettings)
        Me.tabWS.Controls.Add(Me.tabStoreSetup)
        Me.tabWS.Controls.Add(Me.tabClerks)
        Me.tabWS.Controls.Add(Me.tabStores)
        Me.tabWS.Controls.Add(Me.tabDepartments)
        Me.tabWS.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabWS.Location = New System.Drawing.Point(0, 0)
        Me.tabWS.Name = "tabWS"
        Me.tabWS.SelectedIndex = 0
        Me.tabWS.Size = New System.Drawing.Size(766, 394)
        Me.tabWS.TabIndex = 10
        '
        'TabDBConnect
        '
        Me.TabDBConnect.Controls.Add(Me.txtConnString)
        Me.TabDBConnect.Controls.Add(Me.btnFindCTPOS_B)
        Me.TabDBConnect.Controls.Add(Me.btnFindCTMain_B)
        Me.TabDBConnect.Controls.Add(Me.cmdTestPOS)
        Me.TabDBConnect.Controls.Add(Me.cmdTestMain)
        Me.TabDBConnect.Controls.Add(Me.txtSQLPassword)
        Me.TabDBConnect.Controls.Add(Me.lblSQLPassword)
        Me.TabDBConnect.Controls.Add(Me.txtSQLUsername)
        Me.TabDBConnect.Controls.Add(Me.lblSQLUsername)
        Me.TabDBConnect.Controls.Add(Me.txtSQLDatabase)
        Me.TabDBConnect.Controls.Add(Me.lblSQLDatabase)
        Me.TabDBConnect.Controls.Add(Me.txtSQLServer)
        Me.TabDBConnect.Controls.Add(Me.lblSQLServer)
        Me.TabDBConnect.Controls.Add(Me.btnSetConnection)
        Me.TabDBConnect.Controls.Add(Me.lblMainConnection)
        Me.TabDBConnect.Controls.Add(Me.lblPOSConnection)
        Me.TabDBConnect.Controls.Add(Me.txtMainConnection)
        Me.TabDBConnect.Controls.Add(Me.txtPOSConnection)
        Me.TabDBConnect.Controls.Add(Me.fraPOSDBType)
        Me.TabDBConnect.Location = New System.Drawing.Point(4, 22)
        Me.TabDBConnect.Name = "TabDBConnect"
        Me.TabDBConnect.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDBConnect.Size = New System.Drawing.Size(758, 368)
        Me.TabDBConnect.TabIndex = 0
        Me.TabDBConnect.Text = "DB Connect"
        Me.TabDBConnect.UseVisualStyleBackColor = True
        '
        'txtConnString
        '
        Me.txtConnString.Location = New System.Drawing.Point(165, 279)
        Me.txtConnString.Name = "txtConnString"
        Me.txtConnString.Size = New System.Drawing.Size(413, 20)
        Me.txtConnString.TabIndex = 18
        '
        'btnFindCTPOS_B
        '
        Me.btnFindCTPOS_B.Location = New System.Drawing.Point(578, 192)
        Me.btnFindCTPOS_B.Name = "btnFindCTPOS_B"
        Me.btnFindCTPOS_B.Size = New System.Drawing.Size(72, 24)
        Me.btnFindCTPOS_B.TabIndex = 17
        Me.btnFindCTPOS_B.Text = "..."
        Me.btnFindCTPOS_B.UseVisualStyleBackColor = True
        '
        'btnFindCTMain_B
        '
        Me.btnFindCTMain_B.Location = New System.Drawing.Point(578, 9)
        Me.btnFindCTMain_B.Name = "btnFindCTMain_B"
        Me.btnFindCTMain_B.Size = New System.Drawing.Size(72, 24)
        Me.btnFindCTMain_B.TabIndex = 16
        Me.btnFindCTMain_B.Text = "..."
        Me.btnFindCTMain_B.UseVisualStyleBackColor = True
        '
        'cmdTestPOS
        '
        Me.cmdTestPOS.Location = New System.Drawing.Point(500, 221)
        Me.cmdTestPOS.Name = "cmdTestPOS"
        Me.cmdTestPOS.Size = New System.Drawing.Size(72, 24)
        Me.cmdTestPOS.TabIndex = 15
        Me.cmdTestPOS.Text = "Test POS"
        Me.cmdTestPOS.UseVisualStyleBackColor = True
        '
        'cmdTestMain
        '
        Me.cmdTestMain.Location = New System.Drawing.Point(500, 38)
        Me.cmdTestMain.Name = "cmdTestMain"
        Me.cmdTestMain.Size = New System.Drawing.Size(72, 24)
        Me.cmdTestMain.TabIndex = 14
        Me.cmdTestMain.Text = "Test Main"
        Me.cmdTestMain.UseVisualStyleBackColor = True
        '
        'txtSQLPassword
        '
        Me.txtSQLPassword.Location = New System.Drawing.Point(268, 166)
        Me.txtSQLPassword.Name = "txtSQLPassword"
        Me.txtSQLPassword.Size = New System.Drawing.Size(304, 20)
        Me.txtSQLPassword.TabIndex = 13
        '
        'lblSQLPassword
        '
        Me.lblSQLPassword.AutoSize = True
        Me.lblSQLPassword.Location = New System.Drawing.Point(203, 169)
        Me.lblSQLPassword.Name = "lblSQLPassword"
        Me.lblSQLPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblSQLPassword.TabIndex = 12
        Me.lblSQLPassword.Text = "Password"
        '
        'txtSQLUsername
        '
        Me.txtSQLUsername.Location = New System.Drawing.Point(267, 140)
        Me.txtSQLUsername.Name = "txtSQLUsername"
        Me.txtSQLUsername.Size = New System.Drawing.Size(304, 20)
        Me.txtSQLUsername.TabIndex = 11
        '
        'lblSQLUsername
        '
        Me.lblSQLUsername.AutoSize = True
        Me.lblSQLUsername.Location = New System.Drawing.Point(203, 143)
        Me.lblSQLUsername.Name = "lblSQLUsername"
        Me.lblSQLUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblSQLUsername.TabIndex = 10
        Me.lblSQLUsername.Text = "Username"
        '
        'txtSQLDatabase
        '
        Me.txtSQLDatabase.Location = New System.Drawing.Point(267, 112)
        Me.txtSQLDatabase.Name = "txtSQLDatabase"
        Me.txtSQLDatabase.Size = New System.Drawing.Size(304, 20)
        Me.txtSQLDatabase.TabIndex = 9
        '
        'lblSQLDatabase
        '
        Me.lblSQLDatabase.AutoSize = True
        Me.lblSQLDatabase.Location = New System.Drawing.Point(203, 115)
        Me.lblSQLDatabase.Name = "lblSQLDatabase"
        Me.lblSQLDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblSQLDatabase.TabIndex = 8
        Me.lblSQLDatabase.Text = "Database"
        '
        'txtSQLServer
        '
        Me.txtSQLServer.Location = New System.Drawing.Point(267, 84)
        Me.txtSQLServer.Name = "txtSQLServer"
        Me.txtSQLServer.Size = New System.Drawing.Size(304, 20)
        Me.txtSQLServer.TabIndex = 7
        '
        'lblSQLServer
        '
        Me.lblSQLServer.AutoSize = True
        Me.lblSQLServer.Location = New System.Drawing.Point(203, 87)
        Me.lblSQLServer.Name = "lblSQLServer"
        Me.lblSQLServer.Size = New System.Drawing.Size(38, 13)
        Me.lblSQLServer.TabIndex = 6
        Me.lblSQLServer.Text = "Server"
        '
        'btnSetConnection
        '
        Me.btnSetConnection.Location = New System.Drawing.Point(650, 312)
        Me.btnSetConnection.Name = "btnSetConnection"
        Me.btnSetConnection.Size = New System.Drawing.Size(100, 50)
        Me.btnSetConnection.TabIndex = 5
        Me.btnSetConnection.Text = "Save"
        Me.btnSetConnection.UseVisualStyleBackColor = True
        '
        'lblMainConnection
        '
        Me.lblMainConnection.AutoSize = True
        Me.lblMainConnection.Location = New System.Drawing.Point(14, 15)
        Me.lblMainConnection.Name = "lblMainConnection"
        Me.lblMainConnection.Size = New System.Drawing.Size(113, 13)
        Me.lblMainConnection.TabIndex = 4
        Me.lblMainConnection.Text = "CampTrak Connection"
        '
        'lblPOSConnection
        '
        Me.lblPOSConnection.AutoSize = True
        Me.lblPOSConnection.Location = New System.Drawing.Point(14, 198)
        Me.lblPOSConnection.Name = "lblPOSConnection"
        Me.lblPOSConnection.Size = New System.Drawing.Size(86, 13)
        Me.lblPOSConnection.TabIndex = 3
        Me.lblPOSConnection.Text = "POS Connection"
        '
        'txtMainConnection
        '
        Me.txtMainConnection.Location = New System.Drawing.Point(161, 12)
        Me.txtMainConnection.Name = "txtMainConnection"
        Me.txtMainConnection.Size = New System.Drawing.Size(411, 20)
        Me.txtMainConnection.TabIndex = 2
        '
        'txtPOSConnection
        '
        Me.txtPOSConnection.Location = New System.Drawing.Point(161, 195)
        Me.txtPOSConnection.Name = "txtPOSConnection"
        Me.txtPOSConnection.Size = New System.Drawing.Size(411, 20)
        Me.txtPOSConnection.TabIndex = 1
        '
        'fraPOSDBType
        '
        Me.fraPOSDBType.Controls.Add(Me.radSQLServer)
        Me.fraPOSDBType.Controls.Add(Me.radMSAccess)
        Me.fraPOSDBType.Location = New System.Drawing.Point(17, 85)
        Me.fraPOSDBType.Name = "fraPOSDBType"
        Me.fraPOSDBType.Size = New System.Drawing.Size(140, 71)
        Me.fraPOSDBType.TabIndex = 0
        Me.fraPOSDBType.TabStop = False
        Me.fraPOSDBType.Text = "POS Connection Type"
        '
        'radSQLServer
        '
        Me.radSQLServer.AutoSize = True
        Me.radSQLServer.Location = New System.Drawing.Point(23, 42)
        Me.radSQLServer.Name = "radSQLServer"
        Me.radSQLServer.Size = New System.Drawing.Size(80, 17)
        Me.radSQLServer.TabIndex = 1
        Me.radSQLServer.TabStop = True
        Me.radSQLServer.Text = "SQL Server"
        Me.radSQLServer.UseVisualStyleBackColor = True
        '
        'radMSAccess
        '
        Me.radMSAccess.AutoSize = True
        Me.radMSAccess.Location = New System.Drawing.Point(23, 19)
        Me.radMSAccess.Name = "radMSAccess"
        Me.radMSAccess.Size = New System.Drawing.Size(79, 17)
        Me.radMSAccess.TabIndex = 0
        Me.radMSAccess.TabStop = True
        Me.radMSAccess.Text = "MS Access"
        Me.radMSAccess.UseVisualStyleBackColor = True
        '
        'tabReceiptPrinter
        '
        Me.tabReceiptPrinter.Controls.Add(Me.chkOneCCReceipt)
        Me.tabReceiptPrinter.Controls.Add(Me.Label8)
        Me.tabReceiptPrinter.Controls.Add(Me.Label7)
        Me.tabReceiptPrinter.Controls.Add(Me.TBLinesAfter)
        Me.tabReceiptPrinter.Controls.Add(Me.tbLinesBefore)
        Me.tabReceiptPrinter.Controls.Add(Me.chkUsePrinter)
        Me.tabReceiptPrinter.Controls.Add(Me.Label4)
        Me.tabReceiptPrinter.Controls.Add(Me.lblFooter2)
        Me.tabReceiptPrinter.Controls.Add(Me.lblFooter1)
        Me.tabReceiptPrinter.Controls.Add(Me.lblHeader)
        Me.tabReceiptPrinter.Controls.Add(Me.txtFooter2)
        Me.tabReceiptPrinter.Controls.Add(Me.txtFooter1)
        Me.tabReceiptPrinter.Controls.Add(Me.txtHeader)
        Me.tabReceiptPrinter.Controls.Add(Me.btnSetPrinter)
        Me.tabReceiptPrinter.Controls.Add(Me.Label1)
        Me.tabReceiptPrinter.Controls.Add(Me.btnTestPrint)
        Me.tabReceiptPrinter.Controls.Add(Me.cboPrinterSelect)
        Me.tabReceiptPrinter.Location = New System.Drawing.Point(4, 22)
        Me.tabReceiptPrinter.Name = "tabReceiptPrinter"
        Me.tabReceiptPrinter.Padding = New System.Windows.Forms.Padding(3)
        Me.tabReceiptPrinter.Size = New System.Drawing.Size(758, 368)
        Me.tabReceiptPrinter.TabIndex = 1
        Me.tabReceiptPrinter.Text = "Receipt Printer"
        Me.tabReceiptPrinter.UseVisualStyleBackColor = True
        '
        'chkOneCCReceipt
        '
        Me.chkOneCCReceipt.AutoSize = True
        Me.chkOneCCReceipt.Location = New System.Drawing.Point(360, 99)
        Me.chkOneCCReceipt.Name = "chkOneCCReceipt"
        Me.chkOneCCReceipt.Size = New System.Drawing.Size(127, 17)
        Me.chkOneCCReceipt.TabIndex = 26
        Me.chkOneCCReceipt.Text = "Only One CC Receipt"
        Me.chkOneCCReceipt.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Lines After"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Lines Before"
        '
        'TBLinesAfter
        '
        Me.TBLinesAfter.LargeChange = 1
        Me.TBLinesAfter.Location = New System.Drawing.Point(124, 257)
        Me.TBLinesAfter.Name = "TBLinesAfter"
        Me.TBLinesAfter.Size = New System.Drawing.Size(202, 45)
        Me.TBLinesAfter.TabIndex = 23
        '
        'tbLinesBefore
        '
        Me.tbLinesBefore.LargeChange = 1
        Me.tbLinesBefore.Location = New System.Drawing.Point(124, 197)
        Me.tbLinesBefore.Name = "tbLinesBefore"
        Me.tbLinesBefore.Size = New System.Drawing.Size(202, 45)
        Me.tbLinesBefore.TabIndex = 22
        '
        'chkUsePrinter
        '
        Me.chkUsePrinter.AutoSize = True
        Me.chkUsePrinter.Location = New System.Drawing.Point(124, 10)
        Me.chkUsePrinter.Name = "chkUsePrinter"
        Me.chkUsePrinter.Size = New System.Drawing.Size(78, 17)
        Me.chkUsePrinter.TabIndex = 21
        Me.chkUsePrinter.Text = "Use Printer"
        Me.chkUsePrinter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(656, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Click Save First"
        '
        'lblFooter2
        '
        Me.lblFooter2.AutoSize = True
        Me.lblFooter2.Location = New System.Drawing.Point(29, 149)
        Me.lblFooter2.Name = "lblFooter2"
        Me.lblFooter2.Size = New System.Drawing.Size(46, 13)
        Me.lblFooter2.TabIndex = 19
        Me.lblFooter2.Text = "Footer 2"
        '
        'lblFooter1
        '
        Me.lblFooter1.AutoSize = True
        Me.lblFooter1.Location = New System.Drawing.Point(29, 123)
        Me.lblFooter1.Name = "lblFooter1"
        Me.lblFooter1.Size = New System.Drawing.Size(46, 13)
        Me.lblFooter1.TabIndex = 18
        Me.lblFooter1.Text = "Footer 1"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Location = New System.Drawing.Point(29, 97)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(42, 13)
        Me.lblHeader.TabIndex = 17
        Me.lblHeader.Text = "Header"
        '
        'txtFooter2
        '
        Me.txtFooter2.Location = New System.Drawing.Point(123, 149)
        Me.txtFooter2.Name = "txtFooter2"
        Me.txtFooter2.Size = New System.Drawing.Size(203, 20)
        Me.txtFooter2.TabIndex = 16
        '
        'txtFooter1
        '
        Me.txtFooter1.Location = New System.Drawing.Point(123, 123)
        Me.txtFooter1.Name = "txtFooter1"
        Me.txtFooter1.Size = New System.Drawing.Size(203, 20)
        Me.txtFooter1.TabIndex = 15
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(123, 97)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(203, 20)
        Me.txtHeader.TabIndex = 14
        '
        'btnSetPrinter
        '
        Me.btnSetPrinter.Location = New System.Drawing.Point(650, 312)
        Me.btnSetPrinter.Name = "btnSetPrinter"
        Me.btnSetPrinter.Size = New System.Drawing.Size(100, 50)
        Me.btnSetPrinter.TabIndex = 13
        Me.btnSetPrinter.Text = "Save"
        Me.btnSetPrinter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Printer"
        '
        'btnTestPrint
        '
        Me.btnTestPrint.Location = New System.Drawing.Point(637, 30)
        Me.btnTestPrint.Name = "btnTestPrint"
        Me.btnTestPrint.Size = New System.Drawing.Size(118, 52)
        Me.btnTestPrint.TabIndex = 11
        Me.btnTestPrint.Text = "Test Print"
        Me.btnTestPrint.UseVisualStyleBackColor = True
        '
        'cboPrinterSelect
        '
        Me.cboPrinterSelect.FormattingEnabled = True
        Me.cboPrinterSelect.Location = New System.Drawing.Point(123, 35)
        Me.cboPrinterSelect.Name = "cboPrinterSelect"
        Me.cboPrinterSelect.Size = New System.Drawing.Size(203, 21)
        Me.cboPrinterSelect.TabIndex = 10
        '
        'tabDrawer
        '
        Me.tabDrawer.Controls.Add(Me.chkUseBell)
        Me.tabDrawer.Controls.Add(Me.Label5)
        Me.tabDrawer.Controls.Add(Me.cmdSave)
        Me.tabDrawer.Controls.Add(Me.Label3)
        Me.tabDrawer.Controls.Add(Me.Label2)
        Me.tabDrawer.Controls.Add(Me.lblDrawerPort)
        Me.tabDrawer.Controls.Add(Me.txtDrawerPort)
        Me.tabDrawer.Controls.Add(Me.btnTestDrawer)
        Me.tabDrawer.Location = New System.Drawing.Point(4, 22)
        Me.tabDrawer.Name = "tabDrawer"
        Me.tabDrawer.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDrawer.Size = New System.Drawing.Size(758, 368)
        Me.tabDrawer.TabIndex = 2
        Me.tabDrawer.Text = "Cash Drawer"
        Me.tabDrawer.UseVisualStyleBackColor = True
        '
        'chkUseBell
        '
        Me.chkUseBell.AutoSize = True
        Me.chkUseBell.Location = New System.Drawing.Point(111, 23)
        Me.chkUseBell.Name = "chkUseBell"
        Me.chkUseBell.Size = New System.Drawing.Size(159, 17)
        Me.chkUseBell.TabIndex = 7
        Me.chkUseBell.Text = "Use Bell Code (Star Printers)"
        Me.chkUseBell.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(310, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Click Save First"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(650, 312)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 50)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(409, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "For drawers hooked up to receipt printers, or where no drawer is present, leave b" & _
            "lank."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Example: COM1"
        '
        'lblDrawerPort
        '
        Me.lblDrawerPort.AutoSize = True
        Me.lblDrawerPort.Location = New System.Drawing.Point(6, 56)
        Me.lblDrawerPort.Name = "lblDrawerPort"
        Me.lblDrawerPort.Size = New System.Drawing.Size(63, 13)
        Me.lblDrawerPort.TabIndex = 2
        Me.lblDrawerPort.Text = "Drawer Port"
        '
        'txtDrawerPort
        '
        Me.txtDrawerPort.Location = New System.Drawing.Point(110, 53)
        Me.txtDrawerPort.Name = "txtDrawerPort"
        Me.txtDrawerPort.Size = New System.Drawing.Size(115, 20)
        Me.txtDrawerPort.TabIndex = 1
        '
        'btnTestDrawer
        '
        Me.btnTestDrawer.Location = New System.Drawing.Point(306, 46)
        Me.btnTestDrawer.Name = "btnTestDrawer"
        Me.btnTestDrawer.Size = New System.Drawing.Size(89, 27)
        Me.btnTestDrawer.TabIndex = 0
        Me.btnTestDrawer.Text = "Test"
        Me.btnTestDrawer.UseVisualStyleBackColor = True
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.btnExport)
        Me.tabSettings.Controls.Add(Me.btnImportSettings)
        Me.tabSettings.Controls.Add(Me.Label22)
        Me.tabSettings.Controls.Add(Me.txtSpendingRefDur)
        Me.tabSettings.Controls.Add(Me.Label21)
        Me.tabSettings.Controls.Add(Me.Label20)
        Me.tabSettings.Controls.Add(Me.txtTestAmount)
        Me.tabSettings.Controls.Add(Me.btnTestLiveCharge)
        Me.tabSettings.Controls.Add(Me.chkCamperSort)
        Me.tabSettings.Controls.Add(Me.txtCashLinqPW)
        Me.tabSettings.Controls.Add(Me.txtCashLinqUser)
        Me.tabSettings.Controls.Add(Me.lblCashLinqPW)
        Me.tabSettings.Controls.Add(Me.lblCashLinqUser)
        Me.tabSettings.Controls.Add(Me.btnSetXChargePath)
        Me.tabSettings.Controls.Add(Me.lblXChargePath)
        Me.tabSettings.Controls.Add(Me.txtXChargePath)
        Me.tabSettings.Controls.Add(Me.Label6)
        Me.tabSettings.Controls.Add(Me.cboCCMethod)
        Me.tabSettings.Controls.Add(Me.cmdSaveSettings)
        Me.tabSettings.Controls.Add(Me.txtStationID)
        Me.tabSettings.Controls.Add(Me.lblStationID)
        Me.tabSettings.Controls.Add(Me.txtStoreID)
        Me.tabSettings.Controls.Add(Me.lblStoreID)
        Me.tabSettings.Controls.Add(Me.txtTaxRate)
        Me.tabSettings.Controls.Add(Me.lblTaxRate)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(758, 368)
        Me.tabSettings.TabIndex = 3
        Me.tabSettings.Text = "Settings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(293, 195)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(405, 44)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = resources.GetString("Label22.Text")
        '
        'txtSpendingRefDur
        '
        Me.txtSpendingRefDur.Location = New System.Drawing.Point(187, 192)
        Me.txtSpendingRefDur.MaxLength = 255
        Me.txtSpendingRefDur.Name = "txtSpendingRefDur"
        Me.txtSpendingRefDur.Size = New System.Drawing.Size(100, 20)
        Me.txtSpendingRefDur.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 195)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(173, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Spending Money Refresh Duration:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(400, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Test Amount (up to 1.00)"
        Me.Label20.Visible = False
        '
        'txtTestAmount
        '
        Me.txtTestAmount.Location = New System.Drawing.Point(530, 88)
        Me.txtTestAmount.Name = "txtTestAmount"
        Me.txtTestAmount.Size = New System.Drawing.Size(39, 20)
        Me.txtTestAmount.TabIndex = 19
        Me.txtTestAmount.Text = "0.01"
        Me.txtTestAmount.Visible = False
        '
        'btnTestLiveCharge
        '
        Me.btnTestLiveCharge.Location = New System.Drawing.Point(275, 85)
        Me.btnTestLiveCharge.Name = "btnTestLiveCharge"
        Me.btnTestLiveCharge.Size = New System.Drawing.Size(101, 23)
        Me.btnTestLiveCharge.TabIndex = 18
        Me.btnTestLiveCharge.Text = "&Test Live Charge"
        Me.btnTestLiveCharge.UseVisualStyleBackColor = True
        Me.btnTestLiveCharge.Visible = False
        '
        'chkCamperSort
        '
        Me.chkCamperSort.AutoSize = True
        Me.chkCamperSort.Location = New System.Drawing.Point(119, 260)
        Me.chkCamperSort.Name = "chkCamperSort"
        Me.chkCamperSort.Size = New System.Drawing.Size(157, 17)
        Me.chkCamperSort.TabIndex = 17
        Me.chkCamperSort.Text = "Sort Campers by Last Name"
        Me.chkCamperSort.UseVisualStyleBackColor = True
        '
        'txtCashLinqPW
        '
        Me.txtCashLinqPW.Location = New System.Drawing.Point(119, 166)
        Me.txtCashLinqPW.MaxLength = 255
        Me.txtCashLinqPW.Name = "txtCashLinqPW"
        Me.txtCashLinqPW.Size = New System.Drawing.Size(100, 20)
        Me.txtCashLinqPW.TabIndex = 16
        '
        'txtCashLinqUser
        '
        Me.txtCashLinqUser.Location = New System.Drawing.Point(119, 140)
        Me.txtCashLinqUser.MaxLength = 255
        Me.txtCashLinqUser.Name = "txtCashLinqUser"
        Me.txtCashLinqUser.Size = New System.Drawing.Size(100, 20)
        Me.txtCashLinqUser.TabIndex = 15
        '
        'lblCashLinqPW
        '
        Me.lblCashLinqPW.AutoSize = True
        Me.lblCashLinqPW.Location = New System.Drawing.Point(8, 168)
        Me.lblCashLinqPW.Name = "lblCashLinqPW"
        Me.lblCashLinqPW.Size = New System.Drawing.Size(103, 13)
        Me.lblCashLinqPW.TabIndex = 14
        Me.lblCashLinqPW.Text = "CashLinq Password:"
        '
        'lblCashLinqUser
        '
        Me.lblCashLinqUser.AutoSize = True
        Me.lblCashLinqUser.Location = New System.Drawing.Point(8, 142)
        Me.lblCashLinqUser.Name = "lblCashLinqUser"
        Me.lblCashLinqUser.Size = New System.Drawing.Size(79, 13)
        Me.lblCashLinqUser.TabIndex = 13
        Me.lblCashLinqUser.Text = "CashLinq User:"
        '
        'btnSetXChargePath
        '
        Me.btnSetXChargePath.Location = New System.Drawing.Point(400, 111)
        Me.btnSetXChargePath.Name = "btnSetXChargePath"
        Me.btnSetXChargePath.Size = New System.Drawing.Size(28, 23)
        Me.btnSetXChargePath.TabIndex = 12
        Me.btnSetXChargePath.Text = "..."
        Me.btnSetXChargePath.UseVisualStyleBackColor = True
        '
        'lblXChargePath
        '
        Me.lblXChargePath.AutoSize = True
        Me.lblXChargePath.Location = New System.Drawing.Point(8, 116)
        Me.lblXChargePath.Name = "lblXChargePath"
        Me.lblXChargePath.Size = New System.Drawing.Size(79, 13)
        Me.lblXChargePath.TabIndex = 11
        Me.lblXChargePath.Text = "X-Charge Path:"
        '
        'txtXChargePath
        '
        Me.txtXChargePath.Location = New System.Drawing.Point(119, 114)
        Me.txtXChargePath.MaxLength = 255
        Me.txtXChargePath.Name = "txtXChargePath"
        Me.txtXChargePath.Size = New System.Drawing.Size(275, 20)
        Me.txtXChargePath.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Live Charge:"
        '
        'cboCCMethod
        '
        Me.cboCCMethod.FormattingEnabled = True
        Me.cboCCMethod.Location = New System.Drawing.Point(119, 86)
        Me.cboCCMethod.Name = "cboCCMethod"
        Me.cboCCMethod.Size = New System.Drawing.Size(121, 21)
        Me.cboCCMethod.TabIndex = 8
        '
        'cmdSaveSettings
        '
        Me.cmdSaveSettings.Location = New System.Drawing.Point(650, 312)
        Me.cmdSaveSettings.Name = "cmdSaveSettings"
        Me.cmdSaveSettings.Size = New System.Drawing.Size(100, 50)
        Me.cmdSaveSettings.TabIndex = 7
        Me.cmdSaveSettings.Text = "Save"
        Me.cmdSaveSettings.UseVisualStyleBackColor = True
        '
        'txtStationID
        '
        Me.txtStationID.Location = New System.Drawing.Point(119, 60)
        Me.txtStationID.Name = "txtStationID"
        Me.txtStationID.Size = New System.Drawing.Size(100, 20)
        Me.txtStationID.TabIndex = 6
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(8, 62)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 5
        Me.lblStationID.Text = "Station ID"
        '
        'txtStoreID
        '
        Me.txtStoreID.Location = New System.Drawing.Point(119, 34)
        Me.txtStoreID.Name = "txtStoreID"
        Me.txtStoreID.Size = New System.Drawing.Size(100, 20)
        Me.txtStoreID.TabIndex = 4
        '
        'lblStoreID
        '
        Me.lblStoreID.AutoSize = True
        Me.lblStoreID.Location = New System.Drawing.Point(8, 36)
        Me.lblStoreID.Name = "lblStoreID"
        Me.lblStoreID.Size = New System.Drawing.Size(44, 13)
        Me.lblStoreID.TabIndex = 3
        Me.lblStoreID.Text = "Store Id"
        '
        'txtTaxRate
        '
        Me.txtTaxRate.Location = New System.Drawing.Point(119, 8)
        Me.txtTaxRate.Name = "txtTaxRate"
        Me.txtTaxRate.Size = New System.Drawing.Size(100, 20)
        Me.txtTaxRate.TabIndex = 2
        '
        'lblTaxRate
        '
        Me.lblTaxRate.AutoSize = True
        Me.lblTaxRate.Location = New System.Drawing.Point(8, 11)
        Me.lblTaxRate.Name = "lblTaxRate"
        Me.lblTaxRate.Size = New System.Drawing.Size(51, 13)
        Me.lblTaxRate.TabIndex = 1
        Me.lblTaxRate.Text = "Tax Rate"
        '
        'tabStoreSetup
        '
        Me.tabStoreSetup.Controls.Add(Me.Label19)
        Me.tabStoreSetup.Controls.Add(Me.cboInventory)
        Me.tabStoreSetup.Controls.Add(Me.btnSaveClose)
        Me.tabStoreSetup.Controls.Add(Me.Label9)
        Me.tabStoreSetup.Controls.Add(Me.Label10)
        Me.tabStoreSetup.Controls.Add(Me.Label11)
        Me.tabStoreSetup.Controls.Add(Me.chkAlwaysPrintReceipt)
        Me.tabStoreSetup.Controls.Add(Me.txtRecptSignOff2)
        Me.tabStoreSetup.Controls.Add(Me.txtRecptSignOff1)
        Me.tabStoreSetup.Controls.Add(Me.txtStoreName)
        Me.tabStoreSetup.Location = New System.Drawing.Point(4, 22)
        Me.tabStoreSetup.Name = "tabStoreSetup"
        Me.tabStoreSetup.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStoreSetup.Size = New System.Drawing.Size(758, 368)
        Me.tabStoreSetup.TabIndex = 4
        Me.tabStoreSetup.Text = "Store Setup"
        Me.tabStoreSetup.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Craft Inventory:"
        '
        'cboInventory
        '
        Me.cboInventory.FormattingEnabled = True
        Me.cboInventory.Location = New System.Drawing.Point(116, 107)
        Me.cboInventory.Name = "cboInventory"
        Me.cboInventory.Size = New System.Drawing.Size(183, 21)
        Me.cboInventory.TabIndex = 19
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Location = New System.Drawing.Point(650, 312)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(100, 50)
        Me.btnSaveClose.TabIndex = 18
        Me.btnSaveClose.Text = "Save"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Rcpt Sign-Off 1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Rcpt Sign-Off 1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Store Name"
        '
        'chkAlwaysPrintReceipt
        '
        Me.chkAlwaysPrintReceipt.AutoSize = True
        Me.chkAlwaysPrintReceipt.Location = New System.Drawing.Point(116, 134)
        Me.chkAlwaysPrintReceipt.Name = "chkAlwaysPrintReceipt"
        Me.chkAlwaysPrintReceipt.Size = New System.Drawing.Size(123, 17)
        Me.chkAlwaysPrintReceipt.TabIndex = 14
        Me.chkAlwaysPrintReceipt.Text = "Always Print Receipt"
        Me.chkAlwaysPrintReceipt.UseVisualStyleBackColor = True
        '
        'txtRecptSignOff2
        '
        Me.txtRecptSignOff2.Location = New System.Drawing.Point(116, 81)
        Me.txtRecptSignOff2.MaxLength = 50
        Me.txtRecptSignOff2.Name = "txtRecptSignOff2"
        Me.txtRecptSignOff2.Size = New System.Drawing.Size(269, 20)
        Me.txtRecptSignOff2.TabIndex = 13
        '
        'txtRecptSignOff1
        '
        Me.txtRecptSignOff1.Location = New System.Drawing.Point(116, 55)
        Me.txtRecptSignOff1.MaxLength = 50
        Me.txtRecptSignOff1.Name = "txtRecptSignOff1"
        Me.txtRecptSignOff1.Size = New System.Drawing.Size(269, 20)
        Me.txtRecptSignOff1.TabIndex = 12
        '
        'txtStoreName
        '
        Me.txtStoreName.Location = New System.Drawing.Point(116, 29)
        Me.txtStoreName.MaxLength = 50
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.Size = New System.Drawing.Size(269, 20)
        Me.txtStoreName.TabIndex = 11
        '
        'tabClerks
        '
        Me.tabClerks.Controls.Add(Me.txtUserID)
        Me.tabClerks.Controls.Add(Me.Label14)
        Me.tabClerks.Controls.Add(Me.txtFirstName)
        Me.tabClerks.Controls.Add(Me.Label15)
        Me.tabClerks.Controls.Add(Me.txtLastName)
        Me.tabClerks.Controls.Add(Me.chkAdmin)
        Me.tabClerks.Controls.Add(Me.chkNewUser)
        Me.tabClerks.Controls.Add(Me.btnDeleteClerk)
        Me.tabClerks.Controls.Add(Me.btnNewClerk)
        Me.tabClerks.Controls.Add(Me.Label13)
        Me.tabClerks.Controls.Add(Me.txtUserName)
        Me.tabClerks.Controls.Add(Me.Label12)
        Me.tabClerks.Controls.Add(Me.chkActive)
        Me.tabClerks.Controls.Add(Me.txtPassword)
        Me.tabClerks.Controls.Add(Me.lstUsers)
        Me.tabClerks.Controls.Add(Me.btnSaveClerks)
        Me.tabClerks.Location = New System.Drawing.Point(4, 22)
        Me.tabClerks.Name = "tabClerks"
        Me.tabClerks.Size = New System.Drawing.Size(758, 368)
        Me.tabClerks.TabIndex = 5
        Me.tabClerks.Text = "Clerks"
        Me.tabClerks.UseVisualStyleBackColor = True
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(176, 252)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 20)
        Me.txtUserID.TabIndex = 35
        Me.txtUserID.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(168, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Enabled = False
        Me.txtFirstName.Location = New System.Drawing.Point(237, 28)
        Me.txtFirstName.MaxLength = 8
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(100, 20)
        Me.txtFirstName.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(168, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Last Name:"
        '
        'txtLastName
        '
        Me.txtLastName.Enabled = False
        Me.txtLastName.Location = New System.Drawing.Point(237, 54)
        Me.txtLastName.MaxLength = 8
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(100, 20)
        Me.txtLastName.TabIndex = 1
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Enabled = False
        Me.chkAdmin.Location = New System.Drawing.Point(237, 157)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(61, 17)
        Me.chkAdmin.TabIndex = 5
        Me.chkAdmin.Text = "Admin?"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'chkNewUser
        '
        Me.chkNewUser.AutoSize = True
        Me.chkNewUser.Location = New System.Drawing.Point(179, 281)
        Me.chkNewUser.Name = "chkNewUser"
        Me.chkNewUser.Size = New System.Drawing.Size(73, 17)
        Me.chkNewUser.TabIndex = 29
        Me.chkNewUser.Text = "New User"
        Me.chkNewUser.UseVisualStyleBackColor = True
        Me.chkNewUser.Visible = False
        '
        'btnDeleteClerk
        '
        Me.btnDeleteClerk.Location = New System.Drawing.Point(277, 315)
        Me.btnDeleteClerk.Name = "btnDeleteClerk"
        Me.btnDeleteClerk.Size = New System.Drawing.Size(100, 50)
        Me.btnDeleteClerk.TabIndex = 28
        Me.btnDeleteClerk.Text = "&Delete Clerk"
        Me.btnDeleteClerk.UseVisualStyleBackColor = True
        '
        'btnNewClerk
        '
        Me.btnNewClerk.Location = New System.Drawing.Point(171, 315)
        Me.btnNewClerk.Name = "btnNewClerk"
        Me.btnNewClerk.Size = New System.Drawing.Size(100, 50)
        Me.btnNewClerk.TabIndex = 27
        Me.btnNewClerk.Text = "&New Clerk"
        Me.btnNewClerk.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(168, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "User Name:"
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(237, 82)
        Me.txtUserName.MaxLength = 8
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(168, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Password:"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Enabled = False
        Me.chkActive.Location = New System.Drawing.Point(237, 134)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(62, 17)
        Me.chkActive.TabIndex = 4
        Me.chkActive.Text = "Active?"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(237, 108)
        Me.txtPassword.MaxLength = 8
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 3
        '
        'lstUsers
        '
        Me.lstUsers.FormattingEnabled = True
        Me.lstUsers.Location = New System.Drawing.Point(18, 13)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(120, 342)
        Me.lstUsers.TabIndex = 20
        '
        'btnSaveClerks
        '
        Me.btnSaveClerks.Location = New System.Drawing.Point(650, 315)
        Me.btnSaveClerks.Name = "btnSaveClerks"
        Me.btnSaveClerks.Size = New System.Drawing.Size(100, 50)
        Me.btnSaveClerks.TabIndex = 6
        Me.btnSaveClerks.Text = "Save"
        Me.btnSaveClerks.UseVisualStyleBackColor = True
        '
        'tabStores
        '
        Me.tabStores.Controls.Add(Me.txtStoreEditID)
        Me.tabStores.Controls.Add(Me.cboSite)
        Me.tabStores.Controls.Add(Me.Label16)
        Me.tabStores.Controls.Add(Me.txtStoreNameEdit)
        Me.tabStores.Controls.Add(Me.Label17)
        Me.tabStores.Controls.Add(Me.chkNewStore)
        Me.tabStores.Controls.Add(Me.btnDeleteStore)
        Me.tabStores.Controls.Add(Me.btnNewStore)
        Me.tabStores.Controls.Add(Me.lstStores)
        Me.tabStores.Controls.Add(Me.btnSaveStore)
        Me.tabStores.Location = New System.Drawing.Point(4, 22)
        Me.tabStores.Name = "tabStores"
        Me.tabStores.Size = New System.Drawing.Size(758, 368)
        Me.tabStores.TabIndex = 6
        Me.tabStores.Text = "Stores"
        Me.tabStores.UseVisualStyleBackColor = True
        '
        'txtStoreEditID
        '
        Me.txtStoreEditID.Location = New System.Drawing.Point(343, 278)
        Me.txtStoreEditID.Name = "txtStoreEditID"
        Me.txtStoreEditID.Size = New System.Drawing.Size(100, 20)
        Me.txtStoreEditID.TabIndex = 51
        Me.txtStoreEditID.Visible = False
        '
        'cboSite
        '
        Me.cboSite.Enabled = False
        Me.cboSite.FormattingEnabled = True
        Me.cboSite.Location = New System.Drawing.Point(293, 48)
        Me.cboSite.Name = "cboSite"
        Me.cboSite.Size = New System.Drawing.Size(174, 21)
        Me.cboSite.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(224, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Store Name:"
        '
        'txtStoreNameEdit
        '
        Me.txtStoreNameEdit.Enabled = False
        Me.txtStoreNameEdit.Location = New System.Drawing.Point(293, 22)
        Me.txtStoreNameEdit.MaxLength = 255
        Me.txtStoreNameEdit.Name = "txtStoreNameEdit"
        Me.txtStoreNameEdit.Size = New System.Drawing.Size(174, 20)
        Me.txtStoreNameEdit.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(224, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 13)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Site:"
        '
        'chkNewStore
        '
        Me.chkNewStore.AutoSize = True
        Me.chkNewStore.Location = New System.Drawing.Point(227, 275)
        Me.chkNewStore.Name = "chkNewStore"
        Me.chkNewStore.Size = New System.Drawing.Size(76, 17)
        Me.chkNewStore.TabIndex = 47
        Me.chkNewStore.Text = "New Store"
        Me.chkNewStore.UseVisualStyleBackColor = True
        Me.chkNewStore.Visible = False
        '
        'btnDeleteStore
        '
        Me.btnDeleteStore.Location = New System.Drawing.Point(333, 308)
        Me.btnDeleteStore.Name = "btnDeleteStore"
        Me.btnDeleteStore.Size = New System.Drawing.Size(100, 50)
        Me.btnDeleteStore.TabIndex = 46
        Me.btnDeleteStore.Text = "&Delete Store"
        Me.btnDeleteStore.UseVisualStyleBackColor = True
        '
        'btnNewStore
        '
        Me.btnNewStore.Location = New System.Drawing.Point(227, 308)
        Me.btnNewStore.Name = "btnNewStore"
        Me.btnNewStore.Size = New System.Drawing.Size(100, 50)
        Me.btnNewStore.TabIndex = 45
        Me.btnNewStore.Text = "&New Store"
        Me.btnNewStore.UseVisualStyleBackColor = True
        '
        'lstStores
        '
        Me.lstStores.FormattingEnabled = True
        Me.lstStores.Location = New System.Drawing.Point(8, 3)
        Me.lstStores.Name = "lstStores"
        Me.lstStores.Size = New System.Drawing.Size(144, 355)
        Me.lstStores.TabIndex = 42
        '
        'btnSaveStore
        '
        Me.btnSaveStore.Location = New System.Drawing.Point(650, 308)
        Me.btnSaveStore.Name = "btnSaveStore"
        Me.btnSaveStore.Size = New System.Drawing.Size(100, 50)
        Me.btnSaveStore.TabIndex = 19
        Me.btnSaveStore.Text = "Save"
        Me.btnSaveStore.UseVisualStyleBackColor = True
        '
        'tabDepartments
        '
        Me.tabDepartments.Controls.Add(Me.txtDepartmentID)
        Me.tabDepartments.Controls.Add(Me.Label18)
        Me.tabDepartments.Controls.Add(Me.txtDepartment)
        Me.tabDepartments.Controls.Add(Me.chkNewDepartment)
        Me.tabDepartments.Controls.Add(Me.btnDeleteDept)
        Me.tabDepartments.Controls.Add(Me.btnNewDept)
        Me.tabDepartments.Controls.Add(Me.lstDepartments)
        Me.tabDepartments.Controls.Add(Me.btnSaveDepartment)
        Me.tabDepartments.Location = New System.Drawing.Point(4, 22)
        Me.tabDepartments.Name = "tabDepartments"
        Me.tabDepartments.Size = New System.Drawing.Size(758, 368)
        Me.tabDepartments.TabIndex = 7
        Me.tabDepartments.Text = "Departments"
        Me.tabDepartments.UseVisualStyleBackColor = True
        '
        'txtDepartmentID
        '
        Me.txtDepartmentID.Location = New System.Drawing.Point(336, 277)
        Me.txtDepartmentID.Name = "txtDepartmentID"
        Me.txtDepartmentID.Size = New System.Drawing.Size(100, 20)
        Me.txtDepartmentID.TabIndex = 59
        Me.txtDepartmentID.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(224, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "Dept Name:"
        '
        'txtDepartment
        '
        Me.txtDepartment.Enabled = False
        Me.txtDepartment.Location = New System.Drawing.Point(293, 20)
        Me.txtDepartment.MaxLength = 255
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(174, 20)
        Me.txtDepartment.TabIndex = 52
        '
        'chkNewDepartment
        '
        Me.chkNewDepartment.AutoSize = True
        Me.chkNewDepartment.Location = New System.Drawing.Point(227, 279)
        Me.chkNewDepartment.Name = "chkNewDepartment"
        Me.chkNewDepartment.Size = New System.Drawing.Size(106, 17)
        Me.chkNewDepartment.TabIndex = 56
        Me.chkNewDepartment.Text = "New Department"
        Me.chkNewDepartment.UseVisualStyleBackColor = True
        Me.chkNewDepartment.Visible = False
        '
        'btnDeleteDept
        '
        Me.btnDeleteDept.Location = New System.Drawing.Point(333, 312)
        Me.btnDeleteDept.Name = "btnDeleteDept"
        Me.btnDeleteDept.Size = New System.Drawing.Size(100, 50)
        Me.btnDeleteDept.TabIndex = 55
        Me.btnDeleteDept.Text = "&Delete Department"
        Me.btnDeleteDept.UseVisualStyleBackColor = True
        '
        'btnNewDept
        '
        Me.btnNewDept.Location = New System.Drawing.Point(227, 312)
        Me.btnNewDept.Name = "btnNewDept"
        Me.btnNewDept.Size = New System.Drawing.Size(100, 50)
        Me.btnNewDept.TabIndex = 54
        Me.btnNewDept.Text = "&New Department"
        Me.btnNewDept.UseVisualStyleBackColor = True
        '
        'lstDepartments
        '
        Me.lstDepartments.FormattingEnabled = True
        Me.lstDepartments.Location = New System.Drawing.Point(8, 7)
        Me.lstDepartments.Name = "lstDepartments"
        Me.lstDepartments.Size = New System.Drawing.Size(144, 355)
        Me.lstDepartments.TabIndex = 53
        '
        'btnSaveDepartment
        '
        Me.btnSaveDepartment.Location = New System.Drawing.Point(650, 315)
        Me.btnSaveDepartment.Name = "btnSaveDepartment"
        Me.btnSaveDepartment.Size = New System.Drawing.Size(100, 50)
        Me.btnSaveDepartment.TabIndex = 19
        Me.btnSaveDepartment.Text = "Save"
        Me.btnSaveDepartment.UseVisualStyleBackColor = True
        '
        'btnImportSettings
        '
        Me.btnImportSettings.Location = New System.Drawing.Point(11, 294)
        Me.btnImportSettings.Name = "btnImportSettings"
        Me.btnImportSettings.Size = New System.Drawing.Size(100, 23)
        Me.btnImportSettings.TabIndex = 24
        Me.btnImportSettings.Text = "&Import Settings"
        Me.btnImportSettings.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(11, 323)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(100, 23)
        Me.btnExport.TabIndex = 25
        Me.btnExport.Text = "E&xport Settings"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmSystemSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 400)
        Me.Controls.Add(Me.tabWS)
        Me.Name = "frmSystemSetup"
        Me.Text = "Receipt Printer Setup"
        Me.tabWS.ResumeLayout(False)
        Me.TabDBConnect.ResumeLayout(False)
        Me.TabDBConnect.PerformLayout()
        Me.fraPOSDBType.ResumeLayout(False)
        Me.fraPOSDBType.PerformLayout()
        Me.tabReceiptPrinter.ResumeLayout(False)
        Me.tabReceiptPrinter.PerformLayout()
        CType(Me.TBLinesAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLinesBefore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDrawer.ResumeLayout(False)
        Me.tabDrawer.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        Me.tabStoreSetup.ResumeLayout(False)
        Me.tabStoreSetup.PerformLayout()
        Me.tabClerks.ResumeLayout(False)
        Me.tabClerks.PerformLayout()
        Me.tabStores.ResumeLayout(False)
        Me.tabStores.PerformLayout()
        Me.tabDepartments.ResumeLayout(False)
        Me.tabDepartments.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabWS As System.Windows.Forms.TabControl
    Friend WithEvents TabDBConnect As System.Windows.Forms.TabPage
    Friend WithEvents tabReceiptPrinter As System.Windows.Forms.TabPage
    Friend WithEvents lblFooter2 As System.Windows.Forms.Label
    Friend WithEvents lblFooter1 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents txtFooter2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFooter1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents btnSetPrinter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTestPrint As System.Windows.Forms.Button
    Friend WithEvents cboPrinterSelect As System.Windows.Forms.ComboBox
    Friend WithEvents lblMainConnection As System.Windows.Forms.Label
    Friend WithEvents lblPOSConnection As System.Windows.Forms.Label
    Friend WithEvents txtMainConnection As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSConnection As System.Windows.Forms.TextBox
    Friend WithEvents fraPOSDBType As System.Windows.Forms.GroupBox
    Friend WithEvents radSQLServer As System.Windows.Forms.RadioButton
    Friend WithEvents radMSAccess As System.Windows.Forms.RadioButton
    Friend WithEvents btnSetConnection As System.Windows.Forms.Button
    Friend WithEvents txtSQLPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLPassword As System.Windows.Forms.Label
    Friend WithEvents txtSQLUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLUsername As System.Windows.Forms.Label
    Friend WithEvents txtSQLDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLDatabase As System.Windows.Forms.Label
    Friend WithEvents txtSQLServer As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLServer As System.Windows.Forms.Label
    Friend WithEvents cmdTestMain As System.Windows.Forms.Button
    Friend WithEvents cmdTestPOS As System.Windows.Forms.Button
    Friend WithEvents tabDrawer As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDrawerPort As System.Windows.Forms.Label
    Friend WithEvents txtDrawerPort As System.Windows.Forms.TextBox
    Friend WithEvents btnTestDrawer As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabSettings As System.Windows.Forms.TabPage
    Friend WithEvents txtStationID As System.Windows.Forms.TextBox
    Friend WithEvents lblStationID As System.Windows.Forms.Label
    Friend WithEvents txtStoreID As System.Windows.Forms.TextBox
    Friend WithEvents lblStoreID As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents cmdSaveSettings As System.Windows.Forms.Button
    Friend WithEvents btnFindCTPOS_B As System.Windows.Forms.Button
    Friend WithEvents btnFindCTMain_B As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCCMethod As System.Windows.Forms.ComboBox
    Friend WithEvents lblXChargePath As System.Windows.Forms.Label
    Friend WithEvents txtXChargePath As System.Windows.Forms.TextBox
    Friend WithEvents btnSetXChargePath As System.Windows.Forms.Button
    Friend WithEvents txtCashLinqPW As System.Windows.Forms.TextBox
    Friend WithEvents txtCashLinqUser As System.Windows.Forms.TextBox
    Friend WithEvents lblCashLinqPW As System.Windows.Forms.Label
    Friend WithEvents lblCashLinqUser As System.Windows.Forms.Label
    Friend WithEvents chkCamperSort As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseBell As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsePrinter As System.Windows.Forms.CheckBox
    Friend WithEvents tbLinesBefore As System.Windows.Forms.TrackBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TBLinesAfter As System.Windows.Forms.TrackBar
    Friend WithEvents chkOneCCReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents tabStoreSetup As System.Windows.Forms.TabPage
    Friend WithEvents tabClerks As System.Windows.Forms.TabPage
    Friend WithEvents tabStores As System.Windows.Forms.TabPage
    Friend WithEvents tabDepartments As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkAlwaysPrintReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents txtRecptSignOff2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRecptSignOff1 As System.Windows.Forms.TextBox
    Friend WithEvents txtStoreName As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveClerks As System.Windows.Forms.Button
    Friend WithEvents btnSaveStore As System.Windows.Forms.Button
    Friend WithEvents btnSaveDepartment As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lstUsers As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteClerk As System.Windows.Forms.Button
    Friend WithEvents btnNewClerk As System.Windows.Forms.Button
    Friend WithEvents chkNewUser As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtStoreNameEdit As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkNewStore As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteStore As System.Windows.Forms.Button
    Friend WithEvents btnNewStore As System.Windows.Forms.Button
    Friend WithEvents lstStores As System.Windows.Forms.ListBox
    Friend WithEvents cboSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents chkNewDepartment As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteDept As System.Windows.Forms.Button
    Friend WithEvents btnNewDept As System.Windows.Forms.Button
    Friend WithEvents lstDepartments As System.Windows.Forms.ListBox
    Friend WithEvents txtStoreEditID As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentID As System.Windows.Forms.TextBox
    Friend WithEvents txtConnString As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboInventory As System.Windows.Forms.ComboBox
    Friend WithEvents btnTestLiveCharge As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTestAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSpendingRefDur As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnImportSettings As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
