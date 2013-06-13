Imports System.Text

Public Class frmUpdateLog

    Private Sub frmUpdateLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim stbLog As StringBuilder = New StringBuilder()

        stbLog.AppendLine("2013-06-06: Fix for error re-opening a previously closed Cash Sales window")
        stbLog.AppendLine("2013-06-06: Default adjust inventory screen to 'New Inventory', streamlined inventory adjustment process")
        stbLog.AppendLine("2013-06-06: Adjustments to Monthly Inventory and Sales Detail reports to improve accuracy and performance")

        stbLog.AppendLine("2012-08-17:  Modified 'Generate Refund Transactions' function on checkout report to issue debits correctly")
        stbLog.AppendLine("2012-06-29:  Added Administration-->Transaction Exceptions to identify and delete orphaned transactions from voided sales")
        stbLog.AppendLine("2012-06-22:  Modifications to reduce orphaned transactions from deleted/voided sales")
        stbLog.AppendLine("2011-08-10:  Added 'All Categories' and 'All Stores' options to Inventory Snapshot report")
        stbLog.AppendLine("2011-07-15:  Modified logic for swiped card data to accomodate differing cardholder name formats")
        stbLog.AppendLine("2011-07-13:  Fixed date criteria error on Detailed Sales Report")
        stbLog.AppendLine("2011-07-13:  Fixed error on return sales to camper spending money")
        stbLog.AppendLine("2011-07-06:  Added ability to report on 'All Stores' and/or 'All Categories' to Inventory Report")
        stbLog.AppendLine("2011-07-06:  Added date and time to 'Waiting to be z-d out' report")
        stbLog.AppendLine("2011-07-06:  Fixed 1 cent rounding issues for 3-digit sales tax rates")
        stbLog.AppendLine("2011-07-06:  Added time to sale date for 'No Sale' function")
        stbLog.AppendLine("2011-06-28:  Corrected update process to import settings from previous install")
        stbLog.AppendLine("2011-06-28:  Added validation for inventory item before adding craft sales")
        stbLog.AppendLine("2011-06-20:  Masked admin password for over-riding spending money balances")
        stbLog.AppendLine("2011-06-13:  Stripping spaces from scanned credit cards (AMEX fix)")
        stbLog.AppendLine("2011-06-13:  No longer requiring phone and zip for credit card transactions")
        stbLog.AppendLine("2011-05-23:  Added cash given and change due to receipts for cash sales")
        stbLog.AppendLine("2011-05-23:  Added this update log")

        txtUpdateLog.Text = stbLog.ToString()

        txtUpdateLog.Select(0, 0)
        
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Close()

    End Sub
End Class