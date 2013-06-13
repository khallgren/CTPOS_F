Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMonthlyInvPreview

    Private objMonthlyInv As rptMonthlyInv

    Private lngStoreID As Long

    Private blnIncludeInactive As Boolean

    Public Sub New(ByVal _blnIncludeInactive As Boolean, ByVal _lngMonth As Long, ByVal _lngYear As Long, ByVal _lngStoreID As Long)

        Dim strSQL As String

        blnIncludeInactive = _blnIncludeInactive
        lngStoreID = _lngStoreID

        Dim lngEndMonth As Long
        Dim lngEndYear As Long

        If _lngMonth = 12 Then
            lngEndMonth = 1
            lngEndYear = _lngYear + 1
        Else
            lngEndMonth = _lngMonth + 1
            lngEndYear = _lngYear
        End If

        'modify view to use current date restrictions
        strSQL = "CREATE VIEW qrptMonthlyInv AS " & _
                "SELECT qryInvAllStores.lngInventoryID, ISNULL(qryAdjBeg.intTotAdj, 0) - ISNULL(qrySalesBeg.intSalesQty, 0) AS intBegQty, ISNULL(qryAdjEnd.intTotAdj, 0) - ISNULL(qrySalesEnd.intSalesQty, 0) AS intEndQty, " & _
                    "qryInvAllStores.curCost, " & _
                    "qryInvAllStores.strItemName " & _
                "FROM " & _
                        "(SELECT tblInventory.lngInventoryID, tblStores.lngStoreID, tblInventory.intCurrentQty, " & _
                            "tblInventory.curCost, " & _
                            "tblInventory.strItemName " & _
                        "FROM tblInventory " & _
                            "CROSS JOIN tblStores " & _
                        "WHERE tblStores.lngStoreID = " & lngStoreID & " "

        If Not blnIncludeInactive Then strSQL = strSQL & "AND tblInventory.blnInactive=0 "

        strSQL = strSQL & ") AS qryInvAllStores " & _
                "LEFT OUTER JOIN " & _
                    "(SELECT SUM(intAdjustmentQty) AS intTotAdj, lngInventoryID, lngStoreID " & _
                    "FROM tblAdjustment " & _
                    "WHERE (dteAdjustmentDate < CONVERT(DATETIME, '" & _lngYear.ToString() & "-" & _lngMonth.ToString() & "-01 00:00:00', 102)) " & _
                    "GROUP BY lngInventoryID, lngStoreID) AS qryAdjBeg " & _
                    "ON qryInvAllStores.lngInventoryID = qryAdjBeg.lngInventoryID AND " & _
                        "qryInvAllStores.lngStoreID = qryAdjBeg.lngStoreID " & _
                "LEFT OUTER JOIN " & _
                    "(SELECT SUM(tblSalesDetail.lngQuantity) AS intSalesQty, tblSalesDetail.lngInventoryID, tblSales.lngStoreID " & _
                    "FROM tblSalesDetail " & _
                        "INNER JOIN tblSales ON tblSalesDetail.lngSaleID = tblSales.lngSaleID " & _
                    "WHERE (tblSales.dteSaleDate < CONVERT(DATETIME, '" & _lngYear.ToString() & "-" & _lngMonth.ToString() & "-01 00:00:00', 102)) " & _
                    "GROUP BY tblSalesDetail.lngInventoryID, tblSales.lngStoreID) AS qrySalesBeg " & _
                    "ON qryInvAllStores.lngInventoryID = qrySalesBeg.lngInventoryID AND " & _
                        "qryInvAllStores.lngStoreID = qrySalesBeg.lngStoreID " & _
                "LEFT OUTER JOIN " & _
                    "(SELECT SUM(intAdjustmentQty) AS intTotAdj, lngInventoryID, lngStoreID " & _
                    "FROM tblAdjustment AS tblAdjustment_1 " & _
                    "WHERE (dteAdjustmentDate < CONVERT(DATETIME, '" & lngEndYear.ToString() & "-" & lngEndMonth.ToString() & "-01 00:00:00', 102)) " & _
                    "GROUP BY lngInventoryID, lngStoreID) AS qryAdjEnd " & _
                    "ON qryInvAllStores.lngInventoryID = qryAdjEnd.lngInventoryID AND " & _
                        "qryInvAllStores.lngStoreID = qryAdjEnd.lngStoreID " & _
                "LEFT OUTER JOIN " & _
                    "(SELECT SUM(tblSalesDetail_1.lngQuantity) AS intSalesQty, tblSalesDetail_1.lngInventoryID, tblSales_1.lngStoreID " & _
                    "FROM tblSalesDetail AS tblSalesDetail_1 " & _
                        "INNER JOIN tblSales AS tblSales_1 ON tblSalesDetail_1.lngSaleID = tblSales_1.lngSaleID " & _
                    "WHERE (tblSales_1.dteSaleDate < CONVERT(DATETIME, '" & lngEndYear.ToString() & "-" & lngEndMonth.ToString() & "-01 00:00:00', 102)) " & _
                    "GROUP BY tblSalesDetail_1.lngInventoryID, tblSales_1.lngStoreID) AS qrySalesEnd " & _
                    "ON qryInvAllStores.lngInventoryID = qrySalesEnd.lngInventoryID AND " & _
                        "qryInvAllStores.lngStoreID = qrySalesEnd.lngStoreID "

        subCreateView("qrptMonthlyInv", strSQL)

        InitializeComponent()

    End Sub

    Private Sub frmMonthlyInvPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        strSQL = "SELECT * FROM qrptMonthlyInv"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsPOS, "qrptMonthlyInv")

        objMonthlyInv = New rptMonthlyInv

        objMonthlyInv.SetDataSource(Me.dsPOS)

        rvwRpt.ReportSource = objMonthlyInv

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

End Class