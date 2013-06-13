<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamperCheckOutPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamperCheckOutPreview))
        Me.rvwReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.comSelectZOut = New System.Data.OleDb.OleDbCommand
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.daCamperCheckOut = New System.Data.OleDb.OleDbDataAdapter
        Me.dsCamperCheckoutRpt = New CTPOS_F.dsCamperCheckout
        CType(Me.dsCamperCheckoutRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwReport
        '
        Me.rvwReport.ActiveViewIndex = -1
        Me.rvwReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwReport.Location = New System.Drawing.Point(0, 0)
        Me.rvwReport.Name = "rvwReport"
        Me.rvwReport.SelectionFormula = ""
        Me.rvwReport.Size = New System.Drawing.Size(700, 373)
        Me.rvwReport.TabIndex = 1
        Me.rvwReport.ViewTimeSelectionFormula = ""
        '
        'comSelectZOut
        '
        Me.comSelectZOut.CommandText = resources.GetString("comSelectZOut.CommandText")
        Me.comSelectZOut.Connection = Me.conPOS
        '
        'conPOS
        '
        Me.conPOS.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\projects\CampTrak\Data\CTPOS_b.m" & _
            "db"
        '
        'daCamperCheckOut
        '
        Me.daCamperCheckOut.SelectCommand = Me.comSelectZOut
        Me.daCamperCheckOut.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "qryZOut", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("tblSales.lngSaleID", "tblSales.lngSaleID"), New System.Data.Common.DataColumnMapping("lngStoreID", "lngStoreID"), New System.Data.Common.DataColumnMapping("dteSaleDate", "dteSaleDate"), New System.Data.Common.DataColumnMapping("lngClerkID", "lngClerkID"), New System.Data.Common.DataColumnMapping("lngSaleTypeID", "lngSaleTypeID"), New System.Data.Common.DataColumnMapping("lngCamperID", "lngCamperID"), New System.Data.Common.DataColumnMapping("lngTransactionID", "lngTransactionID"), New System.Data.Common.DataColumnMapping("tblSales.lngPaymentTypeID", "tblSales.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strCheckWriter", "strCheckWriter"), New System.Data.Common.DataColumnMapping("blnMovedforCC", "blnMovedforCC"), New System.Data.Common.DataColumnMapping("strCCNumber", "strCCNumber"), New System.Data.Common.DataColumnMapping("strCCExpDate", "strCCExpDate"), New System.Data.Common.DataColumnMapping("lngStaffID", "lngStaffID"), New System.Data.Common.DataColumnMapping("lngDeptID", "lngDeptID"), New System.Data.Common.DataColumnMapping("lngRegistrationID", "lngRegistrationID"), New System.Data.Common.DataColumnMapping("dteZdOut", "dteZdOut"), New System.Data.Common.DataColumnMapping("lngWSID", "lngWSID"), New System.Data.Common.DataColumnMapping("strPhone", "strPhone"), New System.Data.Common.DataColumnMapping("strZip", "strZip"), New System.Data.Common.DataColumnMapping("strAuthNumber", "strAuthNumber"), New System.Data.Common.DataColumnMapping("curTotalCharge", "curTotalCharge"), New System.Data.Common.DataColumnMapping("tblSales.curTax", "tblSales.curTax"), New System.Data.Common.DataColumnMapping("curSubTotal", "curSubTotal"), New System.Data.Common.DataColumnMapping("curDiscount", "curDiscount"), New System.Data.Common.DataColumnMapping("strCVV2", "strCVV2"), New System.Data.Common.DataColumnMapping("strBillName", "strBillName"), New System.Data.Common.DataColumnMapping("lngSalesDetailID", "lngSalesDetailID"), New System.Data.Common.DataColumnMapping("tblSalesDetail.lngSaleID", "tblSalesDetail.lngSaleID"), New System.Data.Common.DataColumnMapping("tblSalesDetail.lngInventoryID", "tblSalesDetail.lngInventoryID"), New System.Data.Common.DataColumnMapping("lngQuantity", "lngQuantity"), New System.Data.Common.DataColumnMapping("curPrice", "curPrice"), New System.Data.Common.DataColumnMapping("tblSalesDetail.curTax", "tblSalesDetail.curTax"), New System.Data.Common.DataColumnMapping("curTotal", "curTotal"), New System.Data.Common.DataColumnMapping("tlkpPaymentType.lngPaymentTypeID", "tlkpPaymentType.lngPaymentTypeID"), New System.Data.Common.DataColumnMapping("strPaymentType", "strPaymentType"), New System.Data.Common.DataColumnMapping("blnLock", "blnLock"), New System.Data.Common.DataColumnMapping("blnAutoOnly", "blnAutoOnly"), New System.Data.Common.DataColumnMapping("blnAccounting", "blnAccounting"), New System.Data.Common.DataColumnMapping("blnMoneyPay", "blnMoneyPay"), New System.Data.Common.DataColumnMapping("blnOnSale", "blnOnSale"), New System.Data.Common.DataColumnMapping("blnTaxable", "blnTaxable"), New System.Data.Common.DataColumnMapping("blnNonStock", "blnNonStock"), New System.Data.Common.DataColumnMapping("blnAutoPrice", "blnAutoPrice"), New System.Data.Common.DataColumnMapping("blnSpending", "blnSpending"), New System.Data.Common.DataColumnMapping("intReorderQty", "intReorderQty"), New System.Data.Common.DataColumnMapping("intCurrentQty", "intCurrentQty"), New System.Data.Common.DataColumnMapping("intDepleteQty", "intDepleteQty"), New System.Data.Common.DataColumnMapping("intListMthd", "intListMthd"), New System.Data.Common.DataColumnMapping("intDisc1Mthd", "intDisc1Mthd"), New System.Data.Common.DataColumnMapping("intDisc2Mthd", "intDisc2Mthd"), New System.Data.Common.DataColumnMapping("intDisc3Mthd", "intDisc3Mthd"), New System.Data.Common.DataColumnMapping("tblInventory.lngInventoryID", "tblInventory.lngInventoryID"), New System.Data.Common.DataColumnMapping("lngVendorID", "lngVendorID"), New System.Data.Common.DataColumnMapping("tblInventory.lngInvCategoryID", "tblInventory.lngInvCategoryID"), New System.Data.Common.DataColumnMapping("dblListPct", "dblListPct"), New System.Data.Common.DataColumnMapping("dblDisc1Pct", "dblDisc1Pct"), New System.Data.Common.DataColumnMapping("dblDisc2Pct", "dblDisc2Pct"), New System.Data.Common.DataColumnMapping("dblDsic3Pct", "dblDsic3Pct"), New System.Data.Common.DataColumnMapping("curCost", "curCost"), New System.Data.Common.DataColumnMapping("curListPrice", "curListPrice"), New System.Data.Common.DataColumnMapping("curDiscount1", "curDiscount1"), New System.Data.Common.DataColumnMapping("curDiscount2", "curDiscount2"), New System.Data.Common.DataColumnMapping("curDiscount3", "curDiscount3"), New System.Data.Common.DataColumnMapping("strStockCode", "strStockCode"), New System.Data.Common.DataColumnMapping("strItemName", "strItemName"), New System.Data.Common.DataColumnMapping("strImg", "strImg"), New System.Data.Common.DataColumnMapping("strDescription", "strDescription"), New System.Data.Common.DataColumnMapping("blnInactive", "blnInactive"), New System.Data.Common.DataColumnMapping("strOnlineName", "strOnlineName"), New System.Data.Common.DataColumnMapping("dteLastUL", "dteLastUL"), New System.Data.Common.DataColumnMapping("tblInvCodeCategory.lngInvCategoryID", "tblInvCodeCategory.lngInvCategoryID"), New System.Data.Common.DataColumnMapping("strInvCategory", "strInvCategory"), New System.Data.Common.DataColumnMapping("blnPrintRecpt", "blnPrintRecpt")})})
        '
        'dsCamperCheckoutRpt
        '
        Me.dsCamperCheckoutRpt.DataSetName = "dsZOut"
        Me.dsCamperCheckoutRpt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmCamperCheckOutPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 373)
        Me.Controls.Add(Me.rvwReport)
        Me.Name = "frmCamperCheckOutPreview"
        Me.Text = "Camper Check-Out"
        CType(Me.dsCamperCheckoutRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents comSelectZOut As System.Data.OleDb.OleDbCommand
    Friend WithEvents daCamperCheckOut As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents dsCamperCheckoutRpt As CTPOS_F.dsCamperCheckout
    Friend WithEvents dsCamperCheckOutForRpt As DataSet

    
End Class
