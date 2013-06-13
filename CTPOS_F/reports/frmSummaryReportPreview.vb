Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class frmSummaryReportPreview
    Private objSummaryRpt As rptSalesSummary
    Private objSummaryByDateRpt As rptSalesSummaryByDate
    Public strCriteria As String = frmSummaryReport.strCriteria
    Public stDocName As String = frmSummaryReport.stDocName
    Public SummaryOnly As Boolean = frmSummaryReport.SummaryOnly

    Private Sub subConfigureCrystalReports()
        Dim objPOSConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsSummary As DataSet

        Dim strSQLSummary As String

        Try
            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn

            objPOSConn.Open()

            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand

            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS

            dsSummary = New DataSet("dsSummaryReport")

            If Not strCriteria.Length = 0 Then
                strCriteria = "WHERE " & strCriteria
            End If

            If stDocName = "rptSalesSummary" Then
                strSQLSummary = "SELECT tblInventory.lngInvCategoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInvCodeCategory.strInvCategory, Sum(tblSalesDetail.lngQuantity) AS SumOflngQuantity, Sum(tblSalesDetail.curTax) AS SumOfcurTax, Sum(tblSalesDetail.curTotal) AS SumOfcurTotal, tblInventory.intCurrentQty, tblInventory.curListPrice FROM tblSales RIGHT JOIN ((tblSalesDetail RIGHT JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID  " & strCriteria & " GROUP BY tblInventory.lngInvCategoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInvCodeCategory.strInvCategory, tblInventory.intCurrentQty, tblInventory.curListPrice"
                daPOS.SelectCommand.CommandText = strSQLSummary

                daPOS.Fill(dsSummary, "qrySalesSummary")
                objSummaryRpt = New rptSalesSummary
                objSummaryRpt.SetDataSource(dsSummary)

                dsSummary.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
                Me.rvwReport.ReportSource = objSummaryRpt

            ElseIf stDocName = "rptSalesSummaryByDate" Then
                strSQLSummary = "SELECT tblInventory.strStockCode, tblSales.dteSaleDate, tblInventory.strItemName, tblInvCodeCategory.strInvCategory, SUM(tblSalesDetail.lngQuantity) AS SumOflngQuantity, SUM(tblSalesDetail.curTax) AS SumOfcurTax, SUM(tblSalesDetail.curTotal) AS SumOfcurTotal, tblInventory.intCurrentQty, tblInventory.curListPrice, tblInventory.lngInvCategoryID FROM (tblSales RIGHT OUTER JOIN ((tblSalesDetail RIGHT OUTER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) " & strCriteria & " GROUP BY tblInventory.strStockCode, tblSales.dteSaleDate, tblInventory.strItemName, tblInvCodeCategory.strInvCategory, tblInventory.intCurrentQty, tblInventory.curListPrice, tblInventory.lngInvCategoryID "
                daPOS.SelectCommand.CommandText = strSQLSummary
                daPOS.Fill(dsSummary, "qrySalesSummaryByDate")

                objSummaryByDateRpt = New rptSalesSummaryByDate
                objSummaryByDateRpt.SetDataSource(dsSummary)
                If SummaryOnly Then
                    objSummaryByDateRpt.Section3.SectionFormat.EnableSuppress = True

                End If


                dsSummary.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
                Me.rvwReport.ReportSource = objSummaryByDateRpt
            End If

            objPOSConn.Close()
            comPOS = Nothing
            daPOS = Nothing
            dsSummary = Nothing


        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try

      
    End Sub


    Private Sub frmSummaryReportPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class