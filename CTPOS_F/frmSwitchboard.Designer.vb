<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchboard
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSwitchboard))
        Me.mnuPOSMain = New Xceed.SmartUI.Controls.ExplorerTaskPane.SmartExplorerTaskPane(Me.components)
        Me.grpSales = New Xceed.SmartUI.Controls.ExplorerTaskPane.Group("Activity")
        Me.tskCashSales = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Sales")
        Me.tskInventoryLookup = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Inventory Lookup")
        Me.tskNoSale = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("No Sale")
        Me.tskReceipt = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Receipt Print ")
        Me.tskRevSales = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Review Sales")
        Me.tskBatWithdrawls = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Any Time Batch Withdrawls")
        Me.tskCraftSale = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Craft Sales")
        Me.Group1 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Group("Reporting")
        Me.tskZOut = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Z-Out")
        Me.tskCamperCheckout = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Checkout Rpt")
        Me.tskSaleDetailLU = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Sale Detail Look up")
        Me.tskCrdCardDetails = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("credit card detail report")
        Me.grpLogout = New Xceed.SmartUI.Controls.ExplorerTaskPane.Group("Exit")
        Me.tskLogout = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Log Out")
        Me.tskEnterRcvr = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Enter Receiver")
        Me.mnuNavigation = New Xceed.SmartUI.Controls.ExplorerTaskPane.Group
        Me.tskBrowser = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Return to Browser")
        Me.Task1 = New Xceed.SmartUI.Controls.OfficeTaskPane.Task("Task1")
        Me.lblQuickKeys = New System.Windows.Forms.Label
        Me.dlmSwitchboard = New Xceed.DockingWindows.DockLayoutManager
        Me.Task2 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Checkout Rpt")
        Me.Task3 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Checkout Rpt")
        Me.Task4 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Print all Active Items on  Lables")
        Me.tskRVSales = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Review Sales")
        Me.Task5 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Receipt Print ")
        Me.Task6 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Staff Accounts")
        Me.tskSaleDetail = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Sale Detail Look up")
        Me.Task7 = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Sale Detail Look up")
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AdministrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SystemSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventorySetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdjustInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdjustmentTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryCategoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VendorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResidentStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateSalesTot = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuImportSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRecalcSalesTotals = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTestPrinter = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateLog = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTransactionExceptions = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInvRpt = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMonthlyInv = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInvSnapshot = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdjSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAllActiveItemsLbls = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuInvCodeCountSheet = New System.Windows.Forms.ToolStripMenuItem
        Me.StoreSummaryReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStoreSummaryByDate = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDetailedSalesReport = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDetSalesRptByCat = New System.Windows.Forms.ToolStripMenuItem
        Me.DeptTransferReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StaffAccountsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCCSales = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDevTest = New System.Windows.Forms.ToolStripMenuItem
        Me.txtDebug = New System.Windows.Forms.TextBox
        Me.lblRefreshStatus = New System.Windows.Forms.Label
        Me.tskServiceQueue = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Service Queue")
        Me.tskMiLook = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Inventory Status")
        Me.tskSpecialInstructions = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Special Instructions")
        Me.tskReservations = New Xceed.SmartUI.Controls.ExplorerTaskPane.Task("Reservations")
        CType(Me.mnuPOSMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dlmSwitchboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPOSMain
        '
        Me.mnuPOSMain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuPOSMain.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.grpSales, Me.Group1, Me.grpLogout})
        Me.mnuPOSMain.Location = New System.Drawing.Point(0, 24)
        Me.mnuPOSMain.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.mnuPOSMain.MarginWidth = 10
        Me.mnuPOSMain.Name = "mnuPOSMain"
        Me.mnuPOSMain.Size = New System.Drawing.Size(200, 684)
        Me.mnuPOSMain.TabIndex = 5
        Me.mnuPOSMain.Text = "mnuPOSMain"
        '
        'grpSales
        '
        Me.grpSales.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSales.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tskCashSales, Me.tskInventoryLookup, Me.tskNoSale, Me.tskReceipt, Me.tskRevSales, Me.tskBatWithdrawls, Me.tskCraftSale})
        Me.grpSales.ItemSpacing = 4
        Me.grpSales.Name = "grpSales"
        Me.grpSales.Text = "Activity"
        '
        'tskCashSales
        '
        Me.tskCashSales.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskCashSales.Image = Global.CTPOS_F.My.Resources.Resources.shopping_cart__add__16x16
        Me.tskCashSales.Name = "tskCashSales"
        Me.tskCashSales.Text = "Sales"
        '
        'tskInventoryLookup
        '
        Me.tskInventoryLookup.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskInventoryLookup.Image = Global.CTPOS_F.My.Resources.Resources.unordered_list_16x16
        Me.tskInventoryLookup.Name = "tskInventoryLookup"
        Me.tskInventoryLookup.Text = "Inventory Lookup"
        '
        'tskNoSale
        '
        Me.tskNoSale.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskNoSale.Image = Global.CTPOS_F.My.Resources.Resources.shopping_cart__delete__16x16
        Me.tskNoSale.Name = "tskNoSale"
        Me.tskNoSale.Text = "No Sale"
        '
        'tskReceipt
        '
        Me.tskReceipt.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskReceipt.Image = Global.CTPOS_F.My.Resources.Resources.table_split_cells_16x16
        Me.tskReceipt.Name = "tskReceipt"
        Me.tskReceipt.Text = "Receipt Print "
        Me.tskReceipt.Visible = False
        '
        'tskRevSales
        '
        Me.tskRevSales.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskRevSales.Image = Global.CTPOS_F.My.Resources.Resources.shopping_cart__edit__16x16
        Me.tskRevSales.Name = "tskRevSales"
        Me.tskRevSales.Text = "Review Sales"
        '
        'tskBatWithdrawls
        '
        Me.tskBatWithdrawls.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskBatWithdrawls.Name = "tskBatWithdrawls"
        Me.tskBatWithdrawls.Text = "Any Time Batch Withdrawls"
        '
        'tskCraftSale
        '
        Me.tskCraftSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskCraftSale.Name = "tskCraftSale"
        Me.tskCraftSale.Text = "Craft Sales"
        '
        'Group1
        '
        Me.Group1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group1.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tskZOut, Me.tskCamperCheckout, Me.tskSaleDetailLU, Me.tskCrdCardDetails})
        Me.Group1.Name = "Group1"
        Me.Group1.Text = "Reporting"
        '
        'tskZOut
        '
        Me.tskZOut.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskZOut.Name = "Task2"
        Me.tskZOut.Text = "Z-Out"
        '
        'tskCamperCheckout
        '
        Me.tskCamperCheckout.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskCamperCheckout.Image = Global.CTPOS_F.My.Resources.Resources.report3_16x16
        Me.tskCamperCheckout.Name = "tskCamperCheckout"
        Me.tskCamperCheckout.Text = "Checkout Rpt"
        '
        'tskSaleDetailLU
        '
        Me.tskSaleDetailLU.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskSaleDetailLU.Name = "tskSaleDetailLU"
        Me.tskSaleDetailLU.OverFont = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskSaleDetailLU.Text = "Sale Detail Look up"
        '
        'tskCrdCardDetails
        '
        Me.tskCrdCardDetails.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskCrdCardDetails.Name = "tskCrdCardDetails"
        Me.tskCrdCardDetails.OverFont = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskCrdCardDetails.Text = "credit card detail report"
        Me.tskCrdCardDetails.Visible = False
        '
        'grpLogout
        '
        Me.grpLogout.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLogout.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tskLogout})
        Me.grpLogout.Name = "grpLogout"
        Me.grpLogout.Text = "Exit"
        '
        'tskLogout
        '
        Me.tskLogout.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskLogout.Image = Global.CTPOS_F.My.Resources.Resources.access__delete__16x16
        Me.tskLogout.Name = "Task2"
        Me.tskLogout.Text = "Log Out"
        '
        'tskEnterRcvr
        '
        Me.tskEnterRcvr.Name = "tskEnterRcvr"
        Me.tskEnterRcvr.Text = "Enter Receiver"
        '
        'mnuNavigation
        '
        Me.mnuNavigation.Name = "mnuNavigation"
        '
        'tskBrowser
        '
        Me.tskBrowser.Name = "tskBrowser"
        Me.tskBrowser.Text = "Return to Browser"
        '
        'Task1
        '
        Me.Task1.Name = "Task1"
        Me.Task1.Text = "Task1"
        '
        'lblQuickKeys
        '
        Me.lblQuickKeys.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblQuickKeys.Location = New System.Drawing.Point(12, 592)
        Me.lblQuickKeys.Name = "lblQuickKeys"
        Me.lblQuickKeys.Size = New System.Drawing.Size(176, 92)
        Me.lblQuickKeys.TabIndex = 7
        Me.lblQuickKeys.Text = "Quick Keys:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alt+F7: Inventory Lookup" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alt+F8: No Sale" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alt+F9: Sales" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F12: Log" & _
            "out" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dlmSwitchboard
        '
        Me.dlmSwitchboard.AllowFloating = False
        Me.dlmSwitchboard.AllowHide = False
        '
        'dlmSwitchboard
        '
        Me.dlmSwitchboard.Initialize(Me, Me.mnuPOSMain)
        '
        'Task2
        '
        Me.Task2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task2.Name = "tskCamperCheckout"
        Me.Task2.Text = "Checkout Rpt"
        '
        'Task3
        '
        Me.Task3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task3.Name = "tskCamperCheckout"
        Me.Task3.Text = "Checkout Rpt"
        '
        'Task4
        '
        Me.Task4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task4.Name = "Task4"
        Me.Task4.Text = "Print all Active Items on  Lables"
        '
        'tskRVSales
        '
        Me.tskRVSales.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskRVSales.Name = "Task5"
        Me.tskRVSales.Text = "Review Sales"
        '
        'Task5
        '
        Me.Task5.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task5.Name = "tskReceipt"
        Me.Task5.Text = "Receipt Print "
        '
        'Task6
        '
        Me.Task6.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task6.Name = "Task6"
        Me.Task6.Text = "Staff Accounts"
        '
        'tskSaleDetail
        '
        Me.tskSaleDetail.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskSaleDetail.Name = "Task7"
        Me.tskSaleDetail.OverFont = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tskSaleDetail.Text = "Sale Detail Look up"
        '
        'Task7
        '
        Me.Task7.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task7.Name = "Task7"
        Me.Task7.OverFont = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task7.Text = "Sale Detail Look up"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministrationToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.mnuDevTest})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(835, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministrationToolStripMenuItem
        '
        Me.AdministrationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemSetupToolStripMenuItem, Me.InventorySetupToolStripMenuItem, Me.AdjustInventoryToolStripMenuItem, Me.ListsToolStripMenuItem, Me.mnuUpdateSalesTot, Me.mnuImportSettings, Me.mnuRecalcSalesTotals, Me.mnuTestPrinter, Me.mnuUpdateLog, Me.mnuTransactionExceptions})
        Me.AdministrationToolStripMenuItem.Name = "AdministrationToolStripMenuItem"
        Me.AdministrationToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.AdministrationToolStripMenuItem.Text = "Administration"
        '
        'SystemSetupToolStripMenuItem
        '
        Me.SystemSetupToolStripMenuItem.Name = "SystemSetupToolStripMenuItem"
        Me.SystemSetupToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SystemSetupToolStripMenuItem.Text = "System Setup"
        '
        'InventorySetupToolStripMenuItem
        '
        Me.InventorySetupToolStripMenuItem.Name = "InventorySetupToolStripMenuItem"
        Me.InventorySetupToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.InventorySetupToolStripMenuItem.Text = "Inventory Setup"
        '
        'AdjustInventoryToolStripMenuItem
        '
        Me.AdjustInventoryToolStripMenuItem.Name = "AdjustInventoryToolStripMenuItem"
        Me.AdjustInventoryToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.AdjustInventoryToolStripMenuItem.Text = "Adjust Inventory"
        '
        'ListsToolStripMenuItem
        '
        Me.ListsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdjustmentTypesToolStripMenuItem, Me.InventoryCategoriesToolStripMenuItem, Me.VendorsToolStripMenuItem, Me.ResidentStaffToolStripMenuItem})
        Me.ListsToolStripMenuItem.Name = "ListsToolStripMenuItem"
        Me.ListsToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ListsToolStripMenuItem.Text = "Lists"
        '
        'AdjustmentTypesToolStripMenuItem
        '
        Me.AdjustmentTypesToolStripMenuItem.Name = "AdjustmentTypesToolStripMenuItem"
        Me.AdjustmentTypesToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AdjustmentTypesToolStripMenuItem.Text = "Adjustment Types"
        '
        'InventoryCategoriesToolStripMenuItem
        '
        Me.InventoryCategoriesToolStripMenuItem.Name = "InventoryCategoriesToolStripMenuItem"
        Me.InventoryCategoriesToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.InventoryCategoriesToolStripMenuItem.Text = "Inventory Categories"
        '
        'VendorsToolStripMenuItem
        '
        Me.VendorsToolStripMenuItem.Name = "VendorsToolStripMenuItem"
        Me.VendorsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.VendorsToolStripMenuItem.Text = "Vendors"
        '
        'ResidentStaffToolStripMenuItem
        '
        Me.ResidentStaffToolStripMenuItem.Name = "ResidentStaffToolStripMenuItem"
        Me.ResidentStaffToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ResidentStaffToolStripMenuItem.Text = "Resident Staff"
        '
        'mnuUpdateSalesTot
        '
        Me.mnuUpdateSalesTot.Name = "mnuUpdateSalesTot"
        Me.mnuUpdateSalesTot.Size = New System.Drawing.Size(195, 22)
        Me.mnuUpdateSalesTot.Text = "Update Sales Totals"
        '
        'mnuImportSettings
        '
        Me.mnuImportSettings.Name = "mnuImportSettings"
        Me.mnuImportSettings.Size = New System.Drawing.Size(195, 22)
        Me.mnuImportSettings.Text = "Import Settings"
        '
        'mnuRecalcSalesTotals
        '
        Me.mnuRecalcSalesTotals.Name = "mnuRecalcSalesTotals"
        Me.mnuRecalcSalesTotals.Size = New System.Drawing.Size(195, 22)
        Me.mnuRecalcSalesTotals.Text = "Recalc Sales Totals"
        '
        'mnuTestPrinter
        '
        Me.mnuTestPrinter.Name = "mnuTestPrinter"
        Me.mnuTestPrinter.Size = New System.Drawing.Size(195, 22)
        Me.mnuTestPrinter.Text = "Test Printer"
        Me.mnuTestPrinter.Visible = False
        '
        'mnuUpdateLog
        '
        Me.mnuUpdateLog.Name = "mnuUpdateLog"
        Me.mnuUpdateLog.Size = New System.Drawing.Size(195, 22)
        Me.mnuUpdateLog.Text = "Update Log"
        '
        'mnuTransactionExceptions
        '
        Me.mnuTransactionExceptions.Name = "mnuTransactionExceptions"
        Me.mnuTransactionExceptions.Size = New System.Drawing.Size(195, 22)
        Me.mnuTransactionExceptions.Text = "Transaction Exceptions"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryReportsToolStripMenuItem, Me.StoreSummaryReportsToolStripMenuItem, Me.DeptTransferReportToolStripMenuItem, Me.StaffAccountsReportToolStripMenuItem, Me.mnuCCSales})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'InventoryReportsToolStripMenuItem
        '
        Me.InventoryReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInvRpt, Me.mnuMonthlyInv, Me.mnuInvSnapshot, Me.mnuAdjSummary, Me.mnuAllActiveItemsLbls, Me.mnuInvCodeCountSheet})
        Me.InventoryReportsToolStripMenuItem.Name = "InventoryReportsToolStripMenuItem"
        Me.InventoryReportsToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.InventoryReportsToolStripMenuItem.Text = "Inventory Reports"
        '
        'mnuInvRpt
        '
        Me.mnuInvRpt.Name = "mnuInvRpt"
        Me.mnuInvRpt.Size = New System.Drawing.Size(237, 22)
        Me.mnuInvRpt.Text = "Inventory Report"
        '
        'mnuMonthlyInv
        '
        Me.mnuMonthlyInv.Name = "mnuMonthlyInv"
        Me.mnuMonthlyInv.Size = New System.Drawing.Size(237, 22)
        Me.mnuMonthlyInv.Text = "Monthly Inventory"
        '
        'mnuInvSnapshot
        '
        Me.mnuInvSnapshot.Name = "mnuInvSnapshot"
        Me.mnuInvSnapshot.Size = New System.Drawing.Size(237, 22)
        Me.mnuInvSnapshot.Text = "Inventory Snapshot"
        '
        'mnuAdjSummary
        '
        Me.mnuAdjSummary.Name = "mnuAdjSummary"
        Me.mnuAdjSummary.Size = New System.Drawing.Size(237, 22)
        Me.mnuAdjSummary.Text = "Adjustment Summary"
        '
        'mnuAllActiveItemsLbls
        '
        Me.mnuAllActiveItemsLbls.Name = "mnuAllActiveItemsLbls"
        Me.mnuAllActiveItemsLbls.Size = New System.Drawing.Size(237, 22)
        Me.mnuAllActiveItemsLbls.Text = "Print All Active Items on Labels"
        '
        'mnuInvCodeCountSheet
        '
        Me.mnuInvCodeCountSheet.Name = "mnuInvCodeCountSheet"
        Me.mnuInvCodeCountSheet.Size = New System.Drawing.Size(237, 22)
        Me.mnuInvCodeCountSheet.Text = "Inventory Code/Count Sheet"
        '
        'StoreSummaryReportsToolStripMenuItem
        '
        Me.StoreSummaryReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStoreSummaryByDate, Me.mnuDetailedSalesReport, Me.mnuDetSalesRptByCat})
        Me.StoreSummaryReportsToolStripMenuItem.Name = "StoreSummaryReportsToolStripMenuItem"
        Me.StoreSummaryReportsToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.StoreSummaryReportsToolStripMenuItem.Text = "Store Summary Reports"
        '
        'mnuStoreSummaryByDate
        '
        Me.mnuStoreSummaryByDate.Name = "mnuStoreSummaryByDate"
        Me.mnuStoreSummaryByDate.Size = New System.Drawing.Size(259, 22)
        Me.mnuStoreSummaryByDate.Text = "Store Summary by Date"
        '
        'mnuDetailedSalesReport
        '
        Me.mnuDetailedSalesReport.Name = "mnuDetailedSalesReport"
        Me.mnuDetailedSalesReport.Size = New System.Drawing.Size(259, 22)
        Me.mnuDetailedSalesReport.Text = "Detailed Sales Report"
        '
        'mnuDetSalesRptByCat
        '
        Me.mnuDetSalesRptByCat.Name = "mnuDetSalesRptByCat"
        Me.mnuDetSalesRptByCat.Size = New System.Drawing.Size(259, 22)
        Me.mnuDetSalesRptByCat.Text = "Detailed Sales Report (by Category)"
        Me.mnuDetSalesRptByCat.Visible = False
        '
        'DeptTransferReportToolStripMenuItem
        '
        Me.DeptTransferReportToolStripMenuItem.Name = "DeptTransferReportToolStripMenuItem"
        Me.DeptTransferReportToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.DeptTransferReportToolStripMenuItem.Text = "Department Transfer Report"
        '
        'StaffAccountsReportToolStripMenuItem
        '
        Me.StaffAccountsReportToolStripMenuItem.Name = "StaffAccountsReportToolStripMenuItem"
        Me.StaffAccountsReportToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.StaffAccountsReportToolStripMenuItem.Text = "Resident Staff Accounts Report"
        '
        'mnuCCSales
        '
        Me.mnuCCSales.Name = "mnuCCSales"
        Me.mnuCCSales.Size = New System.Drawing.Size(237, 22)
        Me.mnuCCSales.Text = "Credit Card Sales Summary"
        '
        'mnuDevTest
        '
        Me.mnuDevTest.Name = "mnuDevTest"
        Me.mnuDevTest.Size = New System.Drawing.Size(61, 20)
        Me.mnuDevTest.Text = "DevTest"
        Me.mnuDevTest.Visible = False
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(12, 505)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.Size = New System.Drawing.Size(175, 84)
        Me.txtDebug.TabIndex = 11
        Me.txtDebug.Visible = False
        '
        'lblRefreshStatus
        '
        Me.lblRefreshStatus.AutoSize = True
        Me.lblRefreshStatus.BackColor = System.Drawing.SystemColors.Window
        Me.lblRefreshStatus.Location = New System.Drawing.Point(12, 686)
        Me.lblRefreshStatus.Name = "lblRefreshStatus"
        Me.lblRefreshStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblRefreshStatus.TabIndex = 13
        '
        'tskServiceQueue
        '
        Me.tskServiceQueue.Image = CType(resources.GetObject("tskServiceQueue.Image"), System.Drawing.Image)
        Me.tskServiceQueue.Name = "tskServiceQueue"
        Me.tskServiceQueue.Text = "Service Queue"
        '
        'tskMiLook
        '
        Me.tskMiLook.Image = CType(resources.GetObject("tskMiLook.Image"), System.Drawing.Image)
        Me.tskMiLook.Name = "tskMiLook"
        Me.tskMiLook.Text = "Inventory Status"
        '
        'tskSpecialInstructions
        '
        Me.tskSpecialInstructions.Image = CType(resources.GetObject("tskSpecialInstructions.Image"), System.Drawing.Image)
        Me.tskSpecialInstructions.Name = "tskSpecialInstructions"
        Me.tskSpecialInstructions.Text = "Special Instructions"
        '
        'tskReservations
        '
        Me.tskReservations.Image = CType(resources.GetObject("tskReservations.Image"), System.Drawing.Image)
        Me.tskReservations.Name = "tskReservations"
        Me.tskReservations.Text = "Reservations"
        '
        'frmSwitchboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(835, 708)
        Me.Controls.Add(Me.lblRefreshStatus)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.lblQuickKeys)
        Me.Controls.Add(Me.mnuPOSMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmSwitchboard"
        Me.Text = "CampTrakStore"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.mnuPOSMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dlmSwitchboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuPOSMain As Xceed.SmartUI.Controls.ExplorerTaskPane.SmartExplorerTaskPane
    Friend WithEvents tskServiceQueue As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskMiLook As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskSpecialInstructions As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskReservations As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskEnterRcvr As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents mnuNavigation As Xceed.SmartUI.Controls.ExplorerTaskPane.Group
    Friend WithEvents tskBrowser As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents grpSales As Xceed.SmartUI.Controls.ExplorerTaskPane.Group
    Friend WithEvents tskCashSales As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task1 As Xceed.SmartUI.Controls.OfficeTaskPane.Task
    Friend WithEvents tskInventoryLookup As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskNoSale As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents lblQuickKeys As System.Windows.Forms.Label
    Friend WithEvents Group1 As Xceed.SmartUI.Controls.ExplorerTaskPane.Group
    Friend WithEvents tskZOut As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents grpLogout As Xceed.SmartUI.Controls.ExplorerTaskPane.Group
    Friend WithEvents tskLogout As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents dlmSwitchboard As Xceed.DockingWindows.DockLayoutManager
    Friend WithEvents tskCamperCheckout As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task2 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task3 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task4 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskReceipt As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskRVSales As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskRevSales As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task5 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskBatWithdrawls As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskCraftSale As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task6 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskSaleDetailLU As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskSaleDetail As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents Task7 As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents tskCrdCardDetails As Xceed.SmartUI.Controls.ExplorerTaskPane.Task
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AdministrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventorySetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustmentTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryCategoriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDebug As System.Windows.Forms.TextBox
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInvRpt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMonthlyInv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInvSnapshot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdjSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAllActiveItemsLbls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInvCodeCountSheet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDevTest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoreSummaryReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDetailedSalesReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStoreSummaryByDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDetSalesRptByCat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateSalesTot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResidentStaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeptTransferReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffAccountsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImportSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRecalcSalesTotals As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCCSales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRefreshStatus As System.Windows.Forms.Label
    Friend WithEvents mnuTestPrinter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransactionExceptions As System.Windows.Forms.ToolStripMenuItem
End Class
