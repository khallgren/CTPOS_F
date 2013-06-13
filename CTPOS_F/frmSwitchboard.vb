Imports Xceed.SmartUI
Imports Xceed.DockingWindows

Public Class frmSwitchboard

    Public Sub New()

        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        Catch ex As Exception

            subLogErr(Me.Name & ".New", ex)

        End Try

    End Sub

    Private Sub tskCashSales_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskCashSales.Click

        Try

            subShowCashSales(Me)

        Catch ex As Exception

            subLogErr(Me.Name & ".tskCashSales_Click", ex)

        End Try

    End Sub

    Private Sub tskCashDrawer_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)

        Try

            subOpenDrawer()

        Catch ex As Exception

            subLogErr(Me.Name & ".tskCashDrawer_Click", ex)

        End Try

    End Sub

    Private Sub tskBalanceLookup_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)

        Me.dlmSwitchboard.SuspendLayout()
        Me.dlmSwitchboard.ToolWindows(0).State = ToolWindowState.AutoHide
        Me.dlmSwitchboard.ToolWindows(0).Width = 300
        Me.dlmSwitchboard.ResumeLayout()

    End Sub

    Private Sub tskInventoryLookup_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskInventoryLookup.Click
        Dim frm As New frmInventoryLookup
        frm.Show()
    End Sub

    Private Sub tskNoSale_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskNoSale.Click
        subNoSale()
        MsgBox("Complete")
    End Sub

    Private Sub tskLogout_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskLogout.Click

        Try

            If Not blnSaleOpen Then
                subCloseCashSales()
                subCloseSwitchboard()
                subShowLogin()
            Else
                If MsgBox("Sale in process, exit anyways?", MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.Yes Then
                    subCloseSwitchboard()
                    subShowLogin()
                End If
            End If
        Catch ex As Exception

            subLogErr(Me.Name & ".tskLogout_Click", ex)

        End Try

    End Sub

    Private Sub tskZOut_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskZOut.Click

        subShowZOutSetup(Me)

    End Sub

    Private Sub tskDeptXFer_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)

        subShowDeptXFerRptSetup(Me)


    End Sub

    Private Sub frmSwitchboard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Control And Keys.F1
                'tony
                MsgBox("Yo")
            Case Else
                'do nothing
        End Select
    End Sub

    Private Sub frmSwitchboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dlmSwitchboard.SuspendLayout()

        Me.dlmSwitchboard.AllowAutoHide = True

        Me.dlmSwitchboard.ToolWindows.Add(New ucSpending)
        Me.dlmSwitchboard.ToolWindows(0).Width = 300
        Me.dlmSwitchboard.ToolWindows(0).DockTo(DockTargetHost.DockHost, DockPosition.Right)

        Me.dlmSwitchboard.AllowHide = False
        Me.dlmSwitchboard.ResumeLayout()
        Do While Not objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide
            objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide
        Loop
        subShowCashSales(Me)

        'Me.dlmSwitchboard.SuspendLayout()

        'Me.dlmSwitchboard.AllowAutoHide = True
        'Dim uc = New ucSpending

        'Dim I = Me.dlmSwitchboard.ToolWindows.Add(uc)

        'Me.dlmSwitchboard.ToolWindows(0).Width = 300
        ''Me.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide

        'Me.dlmSwitchboard.ToolWindows(0).DockTo(DockTargetHost.DockHost, DockPosition.Right)

        'Me.dlmSwitchboard.AllowHide = False
        'Me.dlmSwitchboard.ResumeLayout()
        'Do While Not objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide
        '    objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide
        'Loop
        'subShowCashSales(Me)
        If blnDebug Then Me.txtDebug.Visible = True
    End Sub


    Private Sub tskClerkSetup_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)

        subShowEditUsers(Me)

    End Sub

  

    Private Sub tskJoinMeeting_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        If MsgBox("Click yes only if instructed by Latitude Software Support Staff.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim myURL As String = "http://www.gotomeeting.com"
            System.Diagnostics.Process.Start(myURL)
        End If
    End Sub

    Private Sub tskCamperCheckout_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskCamperCheckout.Click
        subShowCamperCheckoutSetup(Me)
    End Sub


  
    Private Sub tskReceipt_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskReceipt.Click
        Dim frm As New frmTestReceipt
        frm.Show()
    End Sub

    Private Sub tskRevSales_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskRevSales.Click
        Dim frm As New frmReviewSales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub tskBatWithdrawls_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskBatWithdrawls.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmBatchWithdrawls
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub tskCraftSale_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskCraftSale.Click

        subShowCraftSales(Me)

    End Sub

    Private Sub tskSumRpt_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        Dim frm As New frmSummaryReport
        frm.MdiParent = Me
        frm.Show()
    End Sub


  


    Private Sub tskSaleDetailLU_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskSaleDetailLU.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmSaleDetailLookUp
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub tskCrdCardDetails_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tskCrdCardDetails.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmCrCardDetails
        frm.MdiParent = Me
        frm.Show()
    End Sub

   

    
    Private Sub AdjustmentTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentTypesToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmAdjustmentTypes
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub InventoryCategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryCategoriesToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmInvCategories
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VendorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorsToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim f As New frmVendors
        f.ShowDialog()
    End Sub


    Private Sub InventorySetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventorySetupToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        subShowInventorySetup(Me)
    End Sub

    Private Sub SystemSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemSetupToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        subShowSystemSetup(Me)
    End Sub

 
    Private Sub AdjustInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustInventoryToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim f As New frmAdjustInventory
        f.ShowDialog()
    End Sub

    Private Sub Task8_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If
        Dim frm As New frmMonthlyInvSetup
        frm.MdiParent = Me
        frm.Show()
    End Sub

   
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        Const WM_KEYDOWN As Integer = &H100
        Const WM_SYSKEYDOWN As Integer = &H104

        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case (keyData)

                Case Keys.F6
                    '
                Case (Keys.Alt Or Keys.F7)
                    tskInventoryLookup.DoClick()
                Case (Keys.Alt Or Keys.F8)
                    tskNoSale.DoClick()
                Case (Keys.Alt Or Keys.F9)
                    tskCashSales.DoClick()
                Case Keys.F12
                    tskLogout.DoClick()

                    'Case (Keys.Control Or Keys.N)
                    '   Me.Text = "<CTRL> + N Captured"
                    'Case (Keys.Alt Or Keys.Z)
                    '   Me.Text = "<ALT> + Z Captured"
            End Select
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub txtDebug_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebug.GotFocus
        Me.txtDebug.Width = 800
        Me.txtDebug.ScrollBars = Windows.Forms.ScrollBars.Vertical
        System.Windows.Forms.Clipboard.SetText(Me.txtDebug.Text)
    End Sub

    Private Sub txtDebug_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebug.LostFocus
        Me.txtDebug.Width = 175
    End Sub

    
    Private Sub mnuInvRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvRpt.Click

        subShowInvRptSetup(Me)

    End Sub

    Private Sub mnuDevTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDevTest.Click

        Try

            Dim strSQL As String

            strSQL = "CREATE VIEW [dbo].[qryDevTest] AS " & _
                    "SELECT dbo.tblSales.lngSaleID " & _
                    "FROM dbo.tblSales;"

            subCreateView("qryDevTest", strSQL)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)

        End Try

    End Sub

    Private Sub mnuMonthlyInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMonthlyInv.Click
        subShowMonthlyInvSetup(Me)
    End Sub

    Private Sub mnuDetailedSalesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDetailedSalesReport.Click
        subShowDetSalesRptSetup(Me)
    End Sub

    Private Sub mnuAdjSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdjSummary.Click
        subShowAdjSummarySetup(Me)
    End Sub

    Private Sub mnuInvSnapshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvSnapshot.Click
        subShowInvSnapshotSetup(Me)
    End Sub

    Private Sub mnuAllActiveItemsLbls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAllActiveItemsLbls.Click
        subShowInvLblsPreview(Me)
    End Sub

    Private Sub mnuInvCodeCountSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvCodeCountSheet.Click
        subShowInvCodeSheetSetup(Me)
    End Sub

    Private Sub mnuStoreSummaryByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStoreSummaryByDate.Click
        subShowStoreSummaryByDateSetup(Me)
    End Sub

    Private Sub mnuUpdateSalesTot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateSalesTot.Click
        subUpdateSalesTransTotal()
    End Sub

    
    Private Sub DeptTransferReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeptTransferReportToolStripMenuItem.Click
        subShowDeptXFerRptSetup(Me)
    End Sub

  
  
    Private Sub ResidentStaffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResidentStaffToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If

        subShowResidentStaff(Me)
    End Sub

    Private Sub StaffAccountsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffAccountsReportToolStripMenuItem.Click
        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If

        Dim f As New frmStaffAccounts
        f.ShowDialog()
    End Sub

    Private Sub mnuImportSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportSettings.Click

        If fcnImportSettings() Then

            MessageBox.Show("Settings were imported." & vbNewLine & vbNewLine & "Please restart the CampTrak store to apply the settings.")

            Application.Exit()

        End If

    End Sub

    Private Sub mnuRecalcSalesTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecalcSalesTotals.Click

        Dim strMsg As String

        Try

            strMsg = "This will re-round sales sub-totals and tax amounts to 2 decimals, and re-calculate the grand total for every existing sale.\n\nAre you sure you wish to continue?"

            If MsgBox(strMsg, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

            subRecalcTaxTotals()

        Catch ex As Exception
            subLogErr("mnuRecalcSalesTotals.Click", ex)

        End Try

    End Sub

    Private Sub mnuCCSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCCSales.Click
        subShowCCSalesSetup(Me)
    End Sub

    Private Sub mnuTestPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTestPrinter.Click
        subTestPrinter()
    End Sub

    Private Sub mnuUpdateLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateLog.Click

        Using objUpdateLog As frmUpdateLog = New frmUpdateLog()
            objUpdateLog.ShowDialog()
        End Using

    End Sub

    Private Sub mnuTransactionExceptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransactionExceptions.Click
        Using objTransExceptions As frmTransactionExceptions = New frmTransactionExceptions()
            objTransExceptions.ShowDialog()
        End Using
    End Sub
End Class