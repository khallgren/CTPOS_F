Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmInvRptPreview

    Private blnInactive As Boolean

    Private lngCategoryID As Long
    Private lngStoreID As Long

    Private objInventory As rptInventory
    
    Public Sub New(ByVal _blnInactive As Boolean, ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long)

        blnInactive = _blnInactive
        lngCategoryID = _lngCategoryID
        lngStoreID = _lngStoreID

        InitializeComponent()

    End Sub

    Private Sub frmInvRptPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        Dim strWhere As String = ""
        Dim strHaving As String = ""

        If lngStoreID > 0 Then
            If strWhere = "" Then
                strWhere = "WHERE qryInvQOH.lngStoreID = " & lngStoreID.ToString() & " "
            Else
                strWhere = strWhere & "AND qryInvQOH.lngStoreID = " & lngStoreID.ToString() & " "
            End If
        End If

        If lngCategoryID > 0 Then
            If strHaving = "" Then
                strHaving = "HAVING tblInventory.lngInvCategoryID = " & lngCategoryID.ToString() & " "
            Else
                strHaving = strHaving & "AND tblInventory.lngInvCategoryID = " & lngCategoryID.ToString() & " "
            End If
        End If

        If Not blnInactive Then
            If strHaving = "" Then
                strHaving = "HAVING (tblInventory.blnInactive = 0)"
            Else
                strHaving = strHaving & " AND (tblInventory.blnInactive = 0)"
            End If
        End If

        strSQL = "CREATE VIEW qrptInventory AS " & _
                "SELECT tblInventory.blnInactive, " & _
                    "tblInventory.lngInventoryID, tblInventory.lngInvCategoryID, MIN(qryInvQOH.lngStoreID) AS lngStoreID, SUM(qryInvQOH.lngQuantity) AS intCurrentQty, " & _
                    "tblInventory.curCost, tblInventory.curListPrice, " & _
                    "tblInventory.strStockCode, tblInventory.strItemName, tblInventory.strDescription, tblInvCodeCategory.strInvCategory " & _
                "FROM tblInventory " & _
                    "INNER JOIN " & _
                        "(SELECT qryInvPerStore.lngInventoryID, qryInvPerStore.lngStoreID, ISNULL(qryInvQtyAdjByStore.lngQuantity, 0) - ISNULL(qryInvQtySoldByStore.lngQuantity, 0) AS lngQuantity " & _
                        "FROM " & _
                                "(SELECT tblInventory_2.lngInventoryID, tblStores.lngStoreID " & _
                                "FROM tblInventory AS tblInventory_2 " & _
                                    "CROSS JOIN tblStores " & _
                                "UNION " & _
                                "SELECT lngInventoryID, 0 AS lngStoreID " & _
                                "FROM tblInventory AS tblInventory_1) AS qryInvPerStore " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT tblSalesDetail.lngInventoryID, ISNULL(tblStores_1.lngStoreID, 0) AS lngStoreID, SUM(dbo.tblSalesDetail.lngQuantity) AS lngQuantity " & _
                                "FROM tblSales " & _
                                    "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
                                    "LEFT OUTER JOIN tblStores AS tblStores_1 ON tblSales.lngStoreID = tblStores_1.lngStoreID " & _
                                "GROUP BY tblSalesDetail.lngInventoryID, ISNULL(tblStores_1.lngStoreID, 0)) AS qryInvQtySoldByStore " & _
                                "ON qryInvPerStore.lngStoreID = qryInvQtySoldByStore.lngStoreID AND " & _
                                    "qryInvPerStore.lngInventoryID = qryInvQtySoldByStore.lngInventoryID " & _
                            "LEFT OUTER JOIN " & _
                                "(SELECT tblAdjustment.lngInventoryID, ISNULL(tblStores_2.lngStoreID, 0) AS lngStoreID, SUM(dbo.tblAdjustment.intAdjustmentQty) AS lngQuantity " & _
                                "FROM tblAdjustment " & _
                                    "LEFT OUTER JOIN tblStores AS tblStores_2 ON dbo.tblAdjustment.lngStoreID = tblStores_2.lngStoreID " & _
                                "GROUP BY tblAdjustment.lngInventoryID, ISNULL(tblStores_2.lngStoreID, 0)) AS qryInvQtyAdjByStore " & _
                                "ON qryInvPerStore.lngStoreID = qryInvQtyAdjByStore.lngStoreID AND " & _
                                    "qryInvPerStore.lngInventoryID = qryInvQtyAdjByStore.lngInventoryID) AS qryInvQOH " & _
                        "ON tblInventory.lngInventoryID = qryInvQOH.lngInventoryID " & _
                    "INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID " & _
                strWhere & _
                "GROUP BY tblInventory.lngInventoryID, tblInventory.lngInvCategoryID, " & _
                    "tblInventory.curCost, tblInventory.curListPrice, " & _
                    "tblInventory.strStockCode, tblInventory.strItemName, tblInventory.strDescription, tblInvCodeCategory.strInvCategory, tblInventory.blnInactive " & _
                strHaving

        subCreateView("qrptInventory", strSQL)

        subConfigureRpt()

    End Sub

    Private Sub subConfigureRpt()

        Dim strSQL As String

        strSQL = "SELECT * " & _
                "FROM qrptInventory"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsInventory, "qrptInventory")

        objInventory = New rptInventory

        objInventory.SetDataSource(Me.dsInventory)

        rvwInvRpt.ReportSource = objInventory

        subSetLogon()
        'rvwInvRpt.ReportSource = objInventory

    End Sub

    Private Sub subSetLogon()

        Dim crtableLogonInfo As TableLogOnInfo = New TableLogOnInfo()
        Dim crConnectionInfo As ConnectionInfo = New ConnectionInfo()
        Dim CrTables As Tables

        'Declare ReportDocument object and load your existing report
        'Make sure that you give the correct path for the document else it will give exception
        Dim crReportDocument As ReportDocument

        crReportDocument = rvwInvRpt.ReportSource

        CrTables = crReportDocument.Database.Tables

        Dim crTable As CrystalDecisions.CrystalReports.Engine.Table

        With crConnectionInfo

            .ServerName = My.Settings.SQLServer ' "KINGTUBBY\SQLEXPRESS"
            .DatabaseName = My.Settings.SQLDatabase ' "CTPOS_B"
            .UserID = My.Settings.SQLUserName ' "ctposu"
            .Password = My.Settings.SQLPassword ' "ctposp"

        End With

        For Each crTable In CrTables

            crtableLogonInfo = crTable.LogOnInfo

            crtableLogonInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)

        Next

        crReportDocument.ReportOptions.EnableSaveDataWithReport = False

        'Bind the ReportDocument to ReportViewer Object
        rvwInvRpt.ReportSource = crReportDocument

    End Sub

End Class