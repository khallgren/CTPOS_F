Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmDetSalesRptPreview

    Private objDetailedSales As rptDetailedSales

    Private dteStart As Date
    Private dteEnd As Date

    Private lngStoreID As Long
    Private lngClerkID As Long
    Private lngCategoryID As Long
    Private lngWSID As Long

    Public Sub New(ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngWSID = _lngWSID

        lngStoreID = _lngStoreID
        lngClerkID = _lngClerkID
        lngCategoryID = _lngCategoryID

        subCreateViews()

    End Sub

    Public Sub New(ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long, ByVal _dteSaleDate As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngWSID = _lngWSID

        dteStart = _dteSaleDate

        lngStoreID = _lngStoreID
        lngClerkID = _lngClerkID
        lngCategoryID = _lngCategoryID

        subCreateViews()

    End Sub

    Public Sub New(ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngWSID = _lngWSID

        dteStart = _dteStart
        dteEnd = _dteEnd

        lngStoreID = _lngStoreID
        lngClerkID = _lngClerkID
        lngCategoryID = _lngCategoryID

        subCreateViews()

    End Sub

    Private Sub subCreateViews()

        Dim strSQL As String
        Dim strHaving As String = ""
        Dim strWhere As String = ""

        strSQL = "CREATE VIEW qrptSalesDetail AS " & _
                "SELECT tblSales.lngWSID, tblInventory.lngInvCategoryID, " & _
                "tblInventory.strStockCode, tblInventory.strItemName, tblInventory.strDescription, tblInvCodeCategory.strInvCategory, " & _
                "tblSalesDetail.curPrice, " & _
                "SUM(tblSalesDetail.lngQuantity) AS intQtySold, qryQOH.intQOH " & _
                "FROM tblSalesDetail " & _
                    "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                    "INNER JOIN tblSales ON tblSalesDetail.lngSaleID = tblSales.lngSaleID " & _
                    "INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID " & _
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
                                "FROM tblAdjustment " & _
                                "GROUP BY lngInventoryID) AS qryTotAdj " & _
                                "ON tblInventory_1.lngInventoryID = qryTotAdj.lngInventoryID) AS qryQOH " & _
                            "ON tblInventory.lngInventoryID = qryQOH.lngInventoryID "

        If lngStoreID > 0 Then
            If strWhere.Length > 0 Then
                strWhere = strWhere & "AND tblSales.lngStoreID = " & lngStoreID & " "
            Else
                strWhere = "WHERE tblSales.lngStoreID = " & lngStoreID & " "
            End If
        End If

        If lngClerkID > 0 Then
            If strWhere.Length > 0 Then
                strWhere = strWhere & "AND tblSales.lngClerkID = " & lngClerkID & " "
            Else
                strWhere = "WHERE tblSales.lngClerkID = " & lngClerkID & " "
            End If
        End If

        If dteStart <> #12:00:00 AM# Then
            If dteEnd <> #12:00:00 AM# Then

                dteEnd = DateAdd(DateInterval.Day, 1, dteEnd)

                If strWhere.Length > 0 Then
                    strWhere = strWhere & "AND (tblSales.dteSaleDate>=CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND dteSaleDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "
                Else
                    strWhere = "WHERE (tblSales.dteSaleDate>=CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND dteSaleDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "
                End If
            Else

                dteEnd = DateAdd(DateInterval.Day, 1, dteStart)

                If strWhere.Length > 0 Then
                    strWhere = strWhere & "AND (tblSales.dteSaleDate>=CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND dteSaleDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "
                Else
                    strWhere = "WHERE (tblSales.dteSaleDate>=CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND dteSaleDate < CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) "
                End If
            End If
        End If

        strSQL = strSQL & strWhere

        strSQL = strSQL & "GROUP BY tblSales.lngWSID, tblInventory.lngInvCategoryID, " & _
                    "tblInventory.strStockCode, tblInventory.strItemName, tblInventory.strDescription, tblInvCodeCategory.strInvCategory, " & _
                    "tblSalesDetail.curPrice, qryQOH.intQOH "

        If lngCategoryID > 0 Then
            If strHaving.Length > 0 Then
                strHaving = strHaving & "AND tblInventory.lngInvCategoryID=" & lngCategoryID & " "
            Else
                strHaving = "HAVING tblInventory.lngInvCategoryID=" & lngCategoryID & " "
            End If
        End If

        If lngWSID > 0 Then
            If strHaving.Length > 0 Then
                strHaving = strHaving & "AND tblSales.lngWSID=" & lngWSID & " "
            Else
                strHaving = "HAVING tblSales.lngWSID=" & lngWSID & " "
            End If
        End If

        strSQL = strSQL & strHaving

        subCreateView("qrptSalesDetail", strSQL)

    End Sub

    Private Sub frmDetSalesRptPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        strSQL = "SELECT * FROM qrptSalesDetail"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsPOS, "qrptSalesDetail")

        objDetailedSales = New rptDetailedSales

        objDetailedSales.SetDataSource(Me.dsPOS)

        rvwDetailedSales.ReportSource = objDetailedSales

    End Sub

End Class