Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb
Public Class frmStaffAccountsPreview
    Private objStaffAccounts As rptStaffAccounts

    Private dteStart As Date
    Private dteEnd As Date

    Public Sub New(ByVal _dteStart As Date, ByVal _dteEnd As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dteStart = _dteStart
        dteEnd = _dteEnd

    End Sub

    Private Sub subConfigureCrystalReports()
        Dim objPOSConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsStaffAccounts As DataSet

        Dim strSQL As String

        Try

            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn

            objPOSConn.Open()

            strSQL = "SELECT tblResidentStaff.lngStaffID, tblSales.lngSaleID, " & _
                        "tblSales.dteSaleDate, " & _
                        "tblSalesDetail.curTotal, tblSales.curTotalCharge, tblSales.curTax, tblSales.curSubTotal, qryStaffTot.curStaffTotalCharge, qryStaffTot.curStaffTotalTax, qryStaffTot.curStaffSubTotal, " & _
                        "tblResidentStaff.strStaffFName, tblResidentStaff.strStaffLName, tblInventory.strItemName " & _
                    "FROM (((tblResidentStaff " & _
                        "INNER JOIN tblSales ON tblResidentStaff.lngStaffID = tblSales.lngStaffID) " & _
                        "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) " & _
                        "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) " & _
                        "LEFT JOIN " & _
                            "(SELECT tblResidentStaff_1.lngStaffID, " & _
                                "SUM(tblSales_1.curTotalCharge) AS curStaffTotalCharge, SUM(tblSales_1.curTax) AS curStaffTotalTax, SUM(tblSales_1.curSubTotal) AS curStaffSubTotal " & _
                            "FROM tblResidentStaff AS tblResidentStaff_1 " & _
                                "INNER JOIN tblSales AS tblSales_1 ON tblResidentStaff_1.lngStaffID = tblSales_1.lngStaffID " & _
                            "WHERE (tblSales_1.dteSaleDate >= CONVERT(DATETIME, '" & Format(dteStart, "short date") & " 00:00:00', 102)) AND " & _
                                "(tblSales_1.dteSaleDate <= CONVERT(DATETIME, '" & Format(dteEnd, "short date") & " 23:59:59', 102)) " & _
                            "GROUP BY tblResidentStaff_1.lngStaffID) AS qryStaffTot ON dbo.tblResidentStaff.lngStaffID = qryStaffTot.lngStaffID " & _
                    "WHERE  (dteSaleDate >= '" & Format(dteStart, "short date") & " 00:00:00' AND " & _
                        "dteSaleDate <='" & Format(dteEnd, "short date") & " 23:59:59')"

            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand

            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS

            daPOS.SelectCommand.CommandText = strSQL
            dsStaffAccounts = New DataSet("dsStaffAccounts")
            daPOS.Fill(dsStaffAccounts, "qryStaffAccounts")

            objStaffAccounts = New rptStaffAccounts
            objStaffAccounts.SetDataSource(dsStaffAccounts)

            dsStaffAccounts.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objStaffAccounts

        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try

    End Sub

    Private Sub frmStaffAccountsPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class