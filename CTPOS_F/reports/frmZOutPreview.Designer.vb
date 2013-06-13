<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZOutPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZOutPreview))
        Me.rvwZOut = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.comSelectZOut = New System.Data.OleDb.OleDbCommand
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.daZOut = New System.Data.OleDb.OleDbDataAdapter
        Me.dsZOutForRpt = New System.Data.DataSet
        Me.comSelectZOutPmtType = New System.Data.OleDb.OleDbCommand
        Me.daZOutPmtType = New System.Data.OleDb.OleDbDataAdapter
        Me.dsZOutPmtTypeForRpt = New System.Data.DataSet
        Me.comSelectZOutTotals = New System.Data.OleDb.OleDbCommand
        Me.daZOutTotals = New System.Data.OleDb.OleDbDataAdapter
        Me.dsZOutTotalsForRpt = New System.Data.DataSet
        CType(Me.dsZOutForRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsZOutPmtTypeForRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsZOutTotalsForRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwZOut
        '
        Me.rvwZOut.ActiveViewIndex = -1
        Me.rvwZOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwZOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwZOut.Location = New System.Drawing.Point(0, 0)
        Me.rvwZOut.Name = "rvwZOut"
        Me.rvwZOut.SelectionFormula = ""
        Me.rvwZOut.Size = New System.Drawing.Size(810, 516)
        Me.rvwZOut.TabIndex = 1
        Me.rvwZOut.ViewTimeSelectionFormula = ""
        '
        'comSelectZOut
        '
        Me.comSelectZOut.CommandText = resources.GetString("comSelectZOut.CommandText")
        Me.comSelectZOut.Connection = Me.conPOS
        '
        'daZOut
        '
        Me.daZOut.SelectCommand = Me.comSelectZOut
        Me.daZOut.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "qryZOut", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("tblSales.lngSaleID", "tblSales.lngSaleID"), New System.Data.Common.DataColumnMapping("lngStoreID", "lngStoreID"), New System.Data.Common.DataColumnMapping("dteSaleDate", "dteSaleDate"), New System.Data.Common.DataColumnMapping("lngClerkID", "lngClerkID"), New System.Data.Common.DataColumnMapping("lngSaleTypeID", "lngSaleTypeID"), New System.Data.Common.DataColumnMapping("lngCamperID", "lngCamperID"), New System.Data.Common.DataColumnMapping("lngTransactionID", "lngTransactionID"), New System.Data.Common.DataColumnMapping("tblSales.lngPaymentTypeID", "tblSales.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strCheckWriter", "strCheckWriter"), New System.Data.Common.DataColumnMapping("blnMovedforCC", "blnMovedforCC"), New System.Data.Common.DataColumnMapping("strCCNumber", "strCCNumber"), New System.Data.Common.DataColumnMapping("strCCExpDate", "strCCExpDate"), New System.Data.Common.DataColumnMapping("lngStaffID", "lngStaffID"), New System.Data.Common.DataColumnMapping("lngDeptID", "lngDeptID"), New System.Data.Common.DataColumnMapping("lngRegistrationID", "lngRegistrationID"), New System.Data.Common.DataColumnMapping("dteZdOut", "dteZdOut"), New System.Data.Common.DataColumnMapping("lngWSID", "lngWSID"), New System.Data.Common.DataColumnMapping("strPhone", "strPhone"), New System.Data.Common.DataColumnMapping("strZip", "strZip"), New System.Data.Common.DataColumnMapping("strAuthNumber", "strAuthNumber"), New System.Data.Common.DataColumnMapping("curTotalCharge", "curTotalCharge"), New System.Data.Common.DataColumnMapping("tblSales.curTax", "tblSales.curTax"), New System.Data.Common.DataColumnMapping("curSubTotal", "curSubTotal"), New System.Data.Common.DataColumnMapping("curDiscount", "curDiscount"), New System.Data.Common.DataColumnMapping("strCVV2", "strCVV2"), New System.Data.Common.DataColumnMapping("strBillName", "strBillName"), New System.Data.Common.DataColumnMapping("lngSalesDetailID", "lngSalesDetailID"), New System.Data.Common.DataColumnMapping("tblSalesDetail.lngSaleID", "tblSalesDetail.lngSaleID"), New System.Data.Common.DataColumnMapping("tblSalesDetail.lngInventoryID", "tblSalesDetail.lngInventoryID"), New System.Data.Common.DataColumnMapping("lngQuantity", "lngQuantity"), New System.Data.Common.DataColumnMapping("curPrice", "curPrice"), New System.Data.Common.DataColumnMapping("tblSalesDetail.curTax", "tblSalesDetail.curTax"), New System.Data.Common.DataColumnMapping("curTotal", "curTotal"), New System.Data.Common.DataColumnMapping("tlkpPaymentType.lngPaymentTypeID", "tlkpPaymentType.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strPaymentType", "strPaymentType"), New System.Data.Common.DataColumnMapping("blnLock", "blnLock"), New System.Data.Common.DataColumnMapping("blnAutoOnly", "blnAutoOnly"), New System.Data.Common.DataColumnMapping("blnAccounting", "blnAccounting"), New System.Data.Common.DataColumnMapping("blnMoneyPay", "blnMoneyPay"), New System.Data.Common.DataColumnMapping("blnOnSale", "blnOnSale"), New System.Data.Common.DataColumnMapping("blnTaxable", "blnTaxable"), New System.Data.Common.DataColumnMapping("blnNonStock", "blnNonStock"), New System.Data.Common.DataColumnMapping("blnAutoPrice", "blnAutoPrice"), New System.Data.Common.DataColumnMapping("blnSpending", "blnSpending"), New System.Data.Common.DataColumnMapping("intReorderQty", "intReorderQty"), New System.Data.Common.DataColumnMapping("intCurrentQty", "intCurrentQty"), New System.Data.Common.DataColumnMapping("intDepleteQty", "intDepleteQty"), New System.Data.Common.DataColumnMapping("intListMthd", "intListMthd"), New System.Data.Common.DataColumnMapping("intDisc1Mthd", "intDisc1Mthd"), New System.Data.Common.DataColumnMapping("intDisc2Mthd", "intDisc2Mthd"), New System.Data.Common.DataColumnMapping("intDisc3Mthd", "intDisc3Mthd"), New System.Data.Common.DataColumnMapping("tblInventory.lngInventoryID", "tblInventory.lngInventoryID"), New System.Data.Common.DataColumnMapping("lngVendorID", "lngVendorID"), New System.Data.Common.DataColumnMapping("tblInventory.lngInvCategoryID", "tblInventory.lngInvCategoryID"), New System.Data.Common.DataColumnMapping("dblListPct", "dblListPct"), New System.Data.Common.DataColumnMapping("dblDisc1Pct", "dblDisc1Pct"), New System.Data.Common.DataColumnMapping("dblDisc2Pct", "dblDisc2Pct"), New System.Data.Common.DataColumnMapping("dblDsic3Pct", "dblDsic3Pct"), New System.Data.Common.DataColumnMapping("curCost", "curCost"), New System.Data.Common.DataColumnMapping("curListPrice", "curListPrice"), New System.Data.Common.DataColumnMapping("curDiscount1", "curDiscount1"), New System.Data.Common.DataColumnMapping("curDiscount2", "curDiscount2"), New System.Data.Common.DataColumnMapping("curDiscount3", "curDiscount3"), New System.Data.Common.DataColumnMapping("strStockCode", "strStockCode"), New System.Data.Common.DataColumnMapping("strItemName", "strItemName"), New System.Data.Common.DataColumnMapping("strImg", "strImg"), New System.Data.Common.DataColumnMapping("strDescription", "strDescription"), New System.Data.Common.DataColumnMapping("blnInactive", "blnInactive"), New System.Data.Common.DataColumnMapping("strOnlineName", "strOnlineName"), New System.Data.Common.DataColumnMapping("dteLastUL", "dteLastUL"), New System.Data.Common.DataColumnMapping("tblInvCodeCategory.lngInvCategoryID", "tblInvCodeCategory.lngInvCategoryID"), New System.Data.Common.DataColumnMapping("strInvCategory", "strInvCategory"), New System.Data.Common.DataColumnMapping("blnPrintRecpt", "blnPrintRecpt")})})
        '
        'dsZOutForRpt
        '
        Me.dsZOutForRpt.DataSetName = "dsZOut"
        '
        'comSelectZOutPmtType
        '
        Me.comSelectZOutPmtType.CommandText = resources.GetString("comSelectZOutPmtType.CommandText")
        Me.comSelectZOutPmtType.Connection = Me.conPOS
        '
        'daZOutPmtType
        '
        Me.daZOutPmtType.SelectCommand = Me.comSelectZOutPmtType
        Me.daZOutPmtType.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "qryZOutPmtType", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("lngSaleID", "lngSaleID"), New System.Data.Common.DataColumnMapping("lngStoreID", "lngStoreID"), New System.Data.Common.DataColumnMapping("dteSaleDate", "dteSaleDate"), New System.Data.Common.DataColumnMapping("lngClerkID", "lngClerkID"), New System.Data.Common.DataColumnMapping("lngSaleTypeID", "lngSaleTypeID"), New System.Data.Common.DataColumnMapping("lngCamperID", "lngCamperID"), New System.Data.Common.DataColumnMapping("lngTransactionID", "lngTransactionID"), New System.Data.Common.DataColumnMapping("tblSales.lngPaymentTypeID", "tblSales.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strCheckWriter", "strCheckWriter"), New System.Data.Common.DataColumnMapping("blnMovedforCC", "blnMovedforCC"), New System.Data.Common.DataColumnMapping("strCCNumber", "strCCNumber"), New System.Data.Common.DataColumnMapping("strCCExpDate", "strCCExpDate"), New System.Data.Common.DataColumnMapping("lngStaffID", "lngStaffID"), New System.Data.Common.DataColumnMapping("lngDeptID", "lngDeptID"), New System.Data.Common.DataColumnMapping("lngRegistrationID", "lngRegistrationID"), New System.Data.Common.DataColumnMapping("dteZdOut", "dteZdOut"), New System.Data.Common.DataColumnMapping("lngWSID", "lngWSID"), New System.Data.Common.DataColumnMapping("strPhone", "strPhone"), New System.Data.Common.DataColumnMapping("strZip", "strZip"), New System.Data.Common.DataColumnMapping("strAuthNumber", "strAuthNumber"), New System.Data.Common.DataColumnMapping("curTotalCharge", "curTotalCharge"), New System.Data.Common.DataColumnMapping("curTax", "curTax"), New System.Data.Common.DataColumnMapping("curSubTotal", "curSubTotal"), New System.Data.Common.DataColumnMapping("curDiscount", "curDiscount"), New System.Data.Common.DataColumnMapping("strCVV2", "strCVV2"), New System.Data.Common.DataColumnMapping("strBillName", "strBillName"), New System.Data.Common.DataColumnMapping("tlkpPaymentType.lngPaymentTypeID", "tlkpPaymentType.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strPaymentType", "strPaymentType"), New System.Data.Common.DataColumnMapping("blnLock", "blnLock"), New System.Data.Common.DataColumnMapping("blnAutoOnly", "blnAutoOnly"), New System.Data.Common.DataColumnMapping("blnAccounting", "blnAccounting"), New System.Data.Common.DataColumnMapping("blnMoneyPay", "blnMoneyPay")})})
        '
        'dsZOutPmtTypeForRpt
        '
        Me.dsZOutPmtTypeForRpt.DataSetName = "dsZOutPmtType"
        '
        'comSelectZOutTotals
        '
        Me.comSelectZOutTotals.CommandText = resources.GetString("comSelectZOutTotals.CommandText")
        Me.comSelectZOutTotals.Connection = Me.conPOS
        '
        'daZOutTotals
        '
        Me.daZOutTotals.SelectCommand = Me.comSelectZOutTotals
        Me.daZOutTotals.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "qryZOutTotals", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("lngSaleID", "lngSaleID"), New System.Data.Common.DataColumnMapping("lngStoreID", "lngStoreID"), New System.Data.Common.DataColumnMapping("dteSaleDate", "dteSaleDate"), New System.Data.Common.DataColumnMapping("lngClerkID", "lngClerkID"), New System.Data.Common.DataColumnMapping("lngSaleTypeID", "lngSaleTypeID"), New System.Data.Common.DataColumnMapping("lngCamperID", "lngCamperID"), New System.Data.Common.DataColumnMapping("lngTransactionID", "lngTransactionID"), New System.Data.Common.DataColumnMapping("lngPaymentTypeID", "lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strCheckWriter", "strCheckWriter"), New System.Data.Common.DataColumnMapping("blnMovedforCC", "blnMovedforCC"), New System.Data.Common.DataColumnMapping("strCCNumber", "strCCNumber"), New System.Data.Common.DataColumnMapping("strCCExpDate", "strCCExpDate"), New System.Data.Common.DataColumnMapping("lngStaffID", "lngStaffID"), New System.Data.Common.DataColumnMapping("lngDeptID", "lngDeptID"), New System.Data.Common.DataColumnMapping("lngRegistrationID", "lngRegistrationID"), New System.Data.Common.DataColumnMapping("dteZdOut", "dteZdOut"), New System.Data.Common.DataColumnMapping("lngWSID", "lngWSID"), New System.Data.Common.DataColumnMapping("strPhone", "strPhone"), New System.Data.Common.DataColumnMapping("strZip", "strZip"), New System.Data.Common.DataColumnMapping("strAuthNumber", "strAuthNumber"), New System.Data.Common.DataColumnMapping("curTotalCharge", "curTotalCharge"), New System.Data.Common.DataColumnMapping("curTax", "curTax"), New System.Data.Common.DataColumnMapping("curSubTotal", "curSubTotal"), New System.Data.Common.DataColumnMapping("curDiscount", "curDiscount"), New System.Data.Common.DataColumnMapping("strCVV2", "strCVV2"), New System.Data.Common.DataColumnMapping("strBillName", "strBillName")})})
        '
        'dsZOutTotalsForRpt
        '
        Me.dsZOutTotalsForRpt.DataSetName = "dsZOutTotals"
        '
        'frmZOutPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 516)
        Me.Controls.Add(Me.rvwZOut)
        Me.Name = "frmZOutPreview"
        Me.Text = "Z-Out"
        CType(Me.dsZOutForRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsZOutPmtTypeForRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsZOutTotalsForRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwZOut As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents comSelectZOut As System.Data.OleDb.OleDbCommand
    Friend WithEvents daZOut As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents dsZOutForRpt As DataSet
    Friend WithEvents comSelectZOutPmtType As System.Data.OleDb.OleDbCommand
    Friend WithEvents daZOutPmtType As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsZOutPmtTypeForRpt As DataSet
    Friend WithEvents comSelectZOutTotals As System.Data.OleDb.OleDbCommand
    Friend WithEvents daZOutTotals As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsZOutTotalsForRpt As DataSet
End Class
