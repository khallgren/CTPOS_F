Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class frmCrCardDetailsPreview
    Public strSQL As String = frmCrCardDetails.strSQL
    Private objcrCardDetailsRpt As rptCrCardDetails

    Private Sub subConfigureCrystalReports()
        Dim objPOSConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsCrDetails As DataSet

        Try

            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn

            objPOSConn.Open()
            'strSQL = "SELECT tblResidentStaff.lngStaffID, tblResidentStaff.strStaffFName, tblResidentStaff.strStaffLName, tblSales.lngSaleID, tblSales.dteSaleDate, tblSalesDetail.curTotal, tblInventory.strItemName, tblSales.curTotalCharge, tblSales.curTax, tblSales.curSubTotal FROM (tblResidentStaff INNER JOIN tblSales ON tblResidentStaff.lngStaffID = tblSales.lngStaffID) INNER JOIN (tblSalesDetail INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID WHERE  (dteSaleDate >= #" & BeginDate & " 00:00:00# AND dteSaleDate <=#" & EndDate & " 00:00:00 #)"

            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand

            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS

            daPOS.SelectCommand.CommandText = strSQL
            dsCrDetails = New DataSet("dsCrCardDetails")
            daPOS.Fill(dsCrDetails, "qryCreditCardDetails")

            objcrCardDetailsRpt = New rptCrCardDetails
            objcrCardDetailsRpt.SetDataSource(dsCrDetails)

            dsCrDetails.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objcrCardDetailsRpt

        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try
    End Sub

    Private Sub frmCrCardDetailsPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class