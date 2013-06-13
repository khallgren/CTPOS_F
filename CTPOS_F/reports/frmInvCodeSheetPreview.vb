Public Class frmInvCodeSheetPreview

    Private objInvCodeSheet As rptInvCodeSheet

    Private strSortField As String

    Private lngCategoryID As Long
    Private lngStoreID As Long

    Public Sub New(ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long, ByVal _strSortField As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngCategoryID = _lngCategoryID
        lngStoreID = _lngStoreID
        strSortField = _strSortField

        subCreateViews()

    End Sub

    Private Sub subCreateViews()

        Dim strSQL As String
        Dim strOrderBy As String = ""

        Select Case strSortField
            Case "strItemName"
                strOrderBy = "tblInventory.strItemName"
            Case "strStockCode"
                strOrderBy = "tblInventory.strStockCode"
            Case "intCurrentQty"
                strOrderBy = "qryQOH.intQOH"

        End Select

        strSQL = "CREATE VIEW qrptInvCodeSheet AS " & _
                "SELECT TOP (100) PERCENT tblInventory.lngInvCategoryID, qryQOH.lngStoreID, qryQOH.intQOH, " & _
                    "tblInventory.strStockCode, tblInventory.strItemName, tblInvCodeCategory.strInvCategory " & _
                "FROM tblInventory " & _
                    "INNER JOIN " & _
                        "(SELECT qryInvAllStores.lngInventoryID, qryInvAllStores.lngStoreID, ISNULL(qryTotAdj.intTotAdj, 0) - ISNULL(qryTotSales.intQtySold, 0) AS intQOH " & _
                        "FROM " & _
                                "(SELECT tblInventory_1.lngInventoryID, tblStores.lngStoreID " & _
                                "FROM tblInventory AS tblInventory_1 " & _
                                    "CROSS JOIN tblStores) AS qryInvAllStores " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT SUM(tblSalesDetail.lngQuantity) AS intQtySold, tblSalesDetail.lngInventoryID, tblSales.lngStoreID " & _
                                "FROM tblSalesDetail " & _
                                    "INNER JOIN tblSales ON tblSalesDetail.lngSaleID = tblSales.lngSaleID " & _
                                "GROUP BY tblSalesDetail.lngInventoryID, tblSales.lngStoreID) AS qryTotSales " & _
                                "ON qryInvAllStores.lngStoreID = qryTotSales.lngStoreID AND " & _
                                    "qryInvAllStores.lngInventoryID = qryTotSales.lngInventoryID " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT lngInventoryID, lngStoreID, SUM(intAdjustmentQty) AS intTotAdj " & _
                                "FROM tblAdjustment " & _
                                "GROUP BY lngInventoryID, lngStoreID) AS qryTotAdj " & _
                                "ON qryInvAllStores.lngStoreID = qryTotAdj.lngStoreID AND " & _
                                    "qryInvAllStores.lngInventoryID = qryTotAdj.lngInventoryID) AS qryQOH " & _
                        "ON tblInventory.lngInventoryID = qryQOH.lngInventoryID " & _
                    "INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID " & _
                "WHERE tblInventory.lngInvCategoryID=" & lngCategoryID & " AND " & _
                    "qryQOH.lngStoreID=" & lngStoreID 

        subCreateView("qrptInvCodeSheet", strSQL)

    End Sub

    Private Sub frmInvCodeSheetPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        strSQL = "SELECT * FROM qrptInvCodeSheet"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsInvCodeSheet, "qrptInvCodeSheet")

        objInvCodeSheet = New rptInvCodeSheet

        objInvCodeSheet.SetDataSource(Me.dsInvCodeSheet)

        objInvCodeSheet.DataDefinition.SortFields(1).Field = objInvCodeSheet.Database.Tables(0).Fields(strSortField)

        rvwInvCodeSheet.ReportSource = objInvCodeSheet

    End Sub

End Class