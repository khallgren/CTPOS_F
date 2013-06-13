Public Class frmInvSnapshotPreview

    Private objInvSnapshot As rptInvSnapshot

    Private dteRptDate As Date

    Private lngCategoryID As Long
    Private lngStoreID As Long

    Public Sub New(ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long, ByVal _dteRptDate As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngCategoryID = _lngCategoryID
        lngStoreID = _lngStoreID
        dteRptDate = _dteRptDate

        subCreateViews()

    End Sub

    Private Sub subCreateViews()

        Dim strSQL As String

        Dim dteCriter As Date = DateAdd(DateInterval.Day, 1, dteRptDate)

        Dim strWhere As String = ""

        If lngCategoryID > 0 Then
            If strWhere = "" Then
                strWhere = "WHERE tblInventory.lngInvCategoryID=" & lngCategoryID.ToString() & " "
            Else
                strWhere = strWhere & "AND tblInventory.lngInvCategoryID=" & lngCategoryID.ToString() & " "
            End If
        End If

        If lngStoreID > 0 Then
            If strWhere = "" Then
                strWhere = "WHERE tblStores.lngStoreID=" & lngStoreID.ToString() & " "
            Else
                strWhere = strWhere & "AND tblStores.lngStoreID=" & lngStoreID.ToString() & " "
            End If
        End If

        strSQL = "CREATE VIEW qrptInvSnapshot AS " & _
                "SELECT qryInvDetAllStores.lngInventoryID, qryInvDetAllStores.lngInvCategoryID, qryInvDetAllStores.lngStoreID, qryQOHByDate.intQOH AS intQty, " & _
                    "qryInvDetAllStores.curCost, qryInvDetAllStores.curListPrice, " & _
                    "qryInvDetAllStores.strStockCode, qryInvDetAllStores.strItemName, qryInvDetAllStores.strDescription, dbo.tblInvCodeCategory.strInvCategory " & _
                "FROM dbo.tblInvCodeCategory " & _
                    "INNER JOIN " & _
                            "(SELECT dbo.tblInventory.lngInventoryID, dbo.tblInventory.lngInvCategoryID, dbo.tblStores.lngStoreID, " & _
                                "dbo.tblInventory.curCost, dbo.tblInventory.curListPrice, " & _
                                "dbo.tblInventory.strStockCode, dbo.tblInventory.strItemName, dbo.tblInventory.strDescription " & _
                            "FROM dbo.tblInventory " & _
                                "CROSS JOIN dbo.tblStores " & _
                            strWhere & _
                            ") AS qryInvDetAllStores " & _
                        "ON dbo.tblInvCodeCategory.lngInvCategoryID = qryInvDetAllStores.lngInvCategoryID " & _
                    "INNER JOIN " & _
                        "(SELECT qryInvAllStores.lngInventoryID, qryInvAllStores.lngStoreID, ISNULL(qryTotAdj.intTotAdj, 0) - ISNULL(qryTotSales.intQtySold, 0) AS intQOH " & _
                        "FROM " & _
                                "(SELECT tblInventory_1.lngInventoryID, tblStores_1.lngStoreID " & _
                                "FROM dbo.tblInventory AS tblInventory_1 " & _
                                    "CROSS JOIN dbo.tblStores AS tblStores_1) AS qryInvAllStores " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT SUM(dbo.tblSalesDetail.lngQuantity) AS intQtySold, dbo.tblSalesDetail.lngInventoryID, dbo.tblSales.lngStoreID " & _
                                "FROM dbo.tblSalesDetail " & _
                                    "INNER JOIN dbo.tblSales ON dbo.tblSalesDetail.lngSaleID = dbo.tblSales.lngSaleID " & _
                                "WHERE (dbo.tblSales.dteSaleDate < CONVERT(DATETIME, '" & dteCriter.Year & "-" & dteCriter.Month & "-" & dteCriter.Day & " 00:00:00', 102)) " & _
                                "GROUP BY dbo.tblSalesDetail.lngInventoryID, dbo.tblSales.lngStoreID) AS qryTotSales " & _
                                "ON qryInvAllStores.lngStoreID = qryTotSales.lngStoreID AND " & _
                                    "qryInvAllStores.lngInventoryID = qryTotSales.lngInventoryID " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT lngInventoryID, lngStoreID, SUM(intAdjustmentQty) AS intTotAdj " & _
                                "FROM dbo.tblAdjustment " & _
                                "WHERE (dteAdjustmentDate < CONVERT(DATETIME, '" & dteCriter.Year & "-" & dteCriter.Month & "-" & dteCriter.Day & " 00:00:00', 102)) " & _
                                "GROUP BY lngInventoryID, lngStoreID) AS qryTotAdj " & _
                                "ON qryInvAllStores.lngStoreID = qryTotAdj.lngStoreID AND " & _
                                    "qryInvAllStores.lngInventoryID = qryTotAdj.lngInventoryID) AS qryQOHByDate " & _
                        "ON qryInvDetAllStores.lngInventoryID = qryQOHByDate.lngInventoryID AND " & _
                            "qryInvDetAllStores.lngStoreID = qryQOHByDate.lngStoreID"

        subCreateView("qrptInvSnapshot", strSQL)

    End Sub

    Private Sub frmInvSnapshotPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        strSQL = "SELECT * FROM qrptInvSnapshot"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsInvSnapshot, "qrptInvSnapshot")

        objInvSnapshot = New rptInvSnapshot

        objInvSnapshot.SetDataSource(Me.dsInvSnapshot)

        CType(objInvSnapshot.ReportDefinition.ReportObjects("txtSnapshotDate"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = "as of " & dteRptDate.ToString

        rvwInvSnapshot.ReportSource = objInvSnapshot

    End Sub
End Class