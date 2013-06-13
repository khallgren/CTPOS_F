Public Class frmStoreSummaryPreview

    Private objStoreSummary As rptStoreSummary

    Private strCaption As String

    Private dteStart As Date
    Private dteEnd As Date

    Public Sub New(ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strCaption As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dteStart = _dteStart
        dteEnd = _dteEnd

        strCaption = _strCaption

    End Sub

    Private Sub frmStoreSummaryPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        dteEnd = DateAdd(DateInterval.Day, 1, dteEnd)

        strSQL = "SELECT SUM(tblSalesDetail.curTotal) AS curTotalSales, " & _
                    "tblInvCodeCategory.strInvCategory AS strCategory " & _
                "FROM tblSales " & _
                    "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
                    "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                    "INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID " & _
                "WHERE (tblSales.dteSaleDate >= CONVERT(DATETIME, '" & dteStart.Year & "-" & dteStart.Month & "-" & dteStart.Day & " 00:00:00', 102) AND " & _
                    "tblSales.dteSaleDate <= CONVERT(DATETIME, '" & dteEnd.Year & "-" & dteEnd.Month & "-" & dteEnd.Day & " 00:00:00', 102)) " & _
                "GROUP BY tblInvCodeCategory.strInvCategory"

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daPOS.SelectCommand.CommandText = strSQL

        'fill dataset
        Me.daPOS.Fill(Me.dsStoreSummary, "qrptStoreSummary")

        objStoreSummary = New rptStoreSummary

        objStoreSummary.SetDataSource(Me.dsStoreSummary)

        CType(objStoreSummary.ReportDefinition.ReportObjects("txtFilterCriteria"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = strCaption

        rvwStoreSummary.ReportSource = objStoreSummary

        '        subSetLogon()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub
End Class