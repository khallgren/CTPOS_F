Public Class frmAdjSummaryPreview

    Private objAdjSummary As rptAdjSummary

    Private dteStart As Date
    Private dteEnd As Date

    Private lngStoreID As Long

    Public Sub New(ByVal _lngStoreID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date)

        lngStoreID = _lngStoreID

        dteStart = _dteStart
        dteEnd = _dteEnd

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal _lngStoreID As Long)

        lngStoreID = _lngStoreID

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmAdjSummaryPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        strSQL = "SELECT TOP (100) PERCENT tblInventory.lngInventoryID, qryQOH.intQOH AS intCurrentQty, qrptAdjSummary_Adj.intAdjustmentQty, qrptAdjSummary_Sales.lngQuantity AS intTotSold, qrptAdjSummary_Adj.lngAdjustmentTypeID, " & _
                    "tblInventory.strItemName, tblInventory.strStockCode, qrptAdjSummary_Adj.strAdjustmentType " & _
                "FROM tblInventory " & _
                    "INNER JOIN " & _
                        "(SELECT tblAdjustment.lngAdjustmentTypeID, tblAdjustment.lngInventoryID, SUM(tblAdjustment.intAdjustmentQty) AS intAdjustmentQty, " & _
                            "tlkpAdjustmentType.strAdjustmentType " & _
                        "FROM tblAdjustment " & _
                            "INNER JOIN tlkpAdjustmentType ON tblAdjustment.lngAdjustmentTypeID = tlkpAdjustmentType.lngAdjustmentTypeID " & _
                        "WHERE (tblAdjustment.lngStoreID = " & lngStoreID & ") "

        If dteEnd <> #12:00:00 AM# Then dteEnd = DateAdd(DateInterval.Day, 1, dteEnd)

        If dteStart <> #12:00:00 AM# Then strSQL = strSQL & "AND (tblAdjustment.dteAdjustmentDate>CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND " & _
                                "tblAdjustment.dteAdjustmentDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "

        strSQL = strSQL & "GROUP BY tblAdjustment.lngAdjustmentTypeID, tblAdjustment.lngInventoryID, " & _
                            "tlkpAdjustmentType.strAdjustmentType) AS qrptAdjSummary_Adj " & _
                        "ON tblInventory.lngInventoryID = qrptAdjSummary_Adj.lngInventoryID " & _
                    "INNER JOIN " & _
                        "(SELECT tblSalesDetail.lngInventoryID, SUM(tblSalesDetail.lngQuantity) AS lngQuantity " & _
                        "FROM tblSales " & _
                            "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
                        "WHERE (tblSales.lngStoreID = " & lngStoreID & ") "

        If dteEnd <> #12:00:00 AM# Then strSQL = strSQL & "AND (tblSales.dteSaleDate>CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND " & _
                                "tblSales.dteSaleDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "

        strSQL = strSQL & "GROUP BY tblSalesDetail.lngInventoryID) AS qrptAdjSummary_Sales " & _
                        "ON tblInventory.lngInventoryID = qrptAdjSummary_Sales.lngInventoryID " & _
                    "INNER JOIN " & _
                        "(SELECT tblInventory_1.lngInventoryID, qryTotAdj.intTotAdj - ISNULL(qryTotSales.intQtySold, 0) AS intQOH " & _
                        "FROM tblInventory AS tblInventory_1 " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT SUM(lngQuantity) AS intQtySold, lngInventoryID " & _
                                "FROM tblSalesDetail AS tblSalesDetail_1 " & _
                                "GROUP BY lngInventoryID) AS qryTotSales " & _
                                "ON tblInventory_1.lngInventoryID = qryTotSales.lngInventoryID " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT lngInventoryID, SUM(intAdjustmentQty) AS intTotAdj " & _
                                "FROM tblAdjustment AS tblAdjustment_2 " & _
                                "GROUP BY lngInventoryID) AS qryTotAdj " & _
                                "ON tblInventory_1.lngInventoryID = qryTotAdj.lngInventoryID) AS qryQOH " & _
                        "ON tblInventory.lngInventoryID=qryQOH.lngInventoryID " & _
                    "ORDER BY tblInventory.strItemName, tblInventory.strStockCode"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsAdjSummary, "qrptAdjSummary")

        objAdjSummary=New rptAdjSummary

        objAdjSummary.SetDataSource(Me.dsAdjSummary)

        rvwAdjSummary.ReportSource=objAdjSummary

    End Sub

End Class