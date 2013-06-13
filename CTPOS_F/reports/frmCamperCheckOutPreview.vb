Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb


Public Class frmCamperCheckOutPreview
    Dim ColumnList As ArrayList
    Public iWeek = frmCamperCheckoutSetup.iWeek
    Public iSite = frmCamperCheckoutSetup.iSite
    Private objCamperCheckOutRpt As rptCamperCheckout
    Private strSort As String

    Public Sub New(ByVal _strSort As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strSort = _strSort

    End Sub

    Private Sub subConfigureCrystalReports()


        Dim objPOSConn As OleDbConnection
        Dim objMainConn As OleDbConnection

        Dim comPOS As OleDbCommand
        Dim comMain As OleDbCommand

        Dim daPOS As OleDbDataAdapter
        Dim daMain As OleDbDataAdapter

        Dim dsCamperCheckOut As DataSet

        Dim strSQLQueryCamperCheckOut As String
        Dim strSQLQueryCamperCheckOut2 As String

        Dim strSQLCamperStatementTotal As String


        Dim strCamperAdditionalDeposits As String
        Dim strCamperDeposits As String
        Dim strCamperWithdrawls As String
        Dim strCampDefaults As String
        Dim strTax As String
        Dim strWhere As String = ""

        Try

      
            objPOSConn = New OleDbConnection()
            objMainConn = New OleDbConnection()

            objPOSConn.ConnectionString = strPOSConn
            objMainConn.ConnectionString = strCTConn

            objPOSConn.Open()
            objMainConn.Open()
            daPOS = New OleDbDataAdapter
            daMain = New OleDbDataAdapter

            comPOS = New OleDbCommand
            comMain = New OleDbCommand

            comPOS.Connection = objPOSConn
            comMain.Connection = objMainConn

            daPOS.SelectCommand = comPOS
            daMain.SelectCommand = comMain

            Dim dt1 As DataTable
            Dim dt2 As DataTable

            dsCamperCheckOut = New DataSet("dsCamperCheckOut")

            'strSQLQueryCamperCheckOut = "SELECT tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, tblRecords.strLastCoName, tblRecords.strFirstName, tlkphousingname.strHousingName & ': ' & tlkpcabinnames.strcabinname AS strHousingName, tblBlock.strBlockCode, tblInventory.lngInventoryID, tblInventory.strItemName, Sum(tblSalesDetail.lngQuantity) AS lngQuantity, tblBlock.lngWeekID, tblBlock.lngSiteID, Sum(tblSalesDetail.curTotal) AS curTotal FROM (tblSales RIGHT JOIN ((((tlkpCabinNames LEFT JOIN tlkpHousingName ON tlkpCabinNames.lngHousingID = tlkpHousingName.lngHousingID) RIGHT JOIN tblRegistrations ON tlkpCabinNames.lngCabinID = tblRegistrations.lngCabinID) INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) ON tblSales.lngRegistrationID = tblRegistrations.lngRegistrationID) LEFT JOIN (tblSalesDetail LEFT JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID  GROUP BY tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, tblRecords.strLastCoName, tblRecords.strFirstName, tlkphousingname.strHousingName & ': ' & tlkpcabinnames.strcabinname, tblBlock.strBlockCode, tblInventory.lngInventoryID, tblInventory.strItemName, tblBlock.lngWeekID, tblBlock.lngSiteID;"
            strSQLQueryCamperCheckOut = "SELECT tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, tblBlock.lngWeekID, tblBlock.lngSiteID, " & _
                                            "tblRecords.strLastCoName, tblRecords.strFirstName, tlkphousingname.strHousingName & ': ' & tlkpcabinnames.strcabinname AS strHousingName, tblBlock.strBlockCode " & _
                                        "FROM (((tlkpCabinNames " & _
                                            "LEFT JOIN tlkpHousingName ON tlkpCabinNames.lngHousingID = tlkpHousingName.lngHousingID) " & _
                                            "RIGHT JOIN tblRegistrations ON tlkpCabinNames.lngCabinID = tblRegistrations.lngCabinID) " & _
                                            "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                                            "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID " & _
                                        "GROUP BY tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, tblRecords.strLastCoName, tblRecords.strFirstName, tlkphousingname.strHousingName & ': ' & tlkpcabinnames.strcabinname, tblBlock.strBlockCode, tblBlock.lngWeekID, tblBlock.lngSiteID;"

            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strSQLQueryCamperCheckOut2: " & strSQLQueryCamperCheckOut
            strSQLQueryCamperCheckOut2 = "SELECT tblSales.lngRegistrationID, tblSales.lngCamperID, tblInventory.lngInventoryID, tblInventory.strItemName, Sum(tblSalesDetail.lngQuantity) AS lngQuantity, Sum(tblSalesDetail.curTotal) AS curTotal FROM tblSales LEFT JOIN (tblSalesDetail LEFT JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID GROUP BY tblSales.lngRegistrationID, tblSales.lngCamperID, tblInventory.lngInventoryID, tblInventory.strItemName HAVING (((tblSales.lngRegistrationID) Is Not Null And Not (tblSales.lngRegistrationID)=0));"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strSQLQueryCamperCheckOut2 : " & strSQLQueryCamperCheckOut2

            
            ''POS 

            daMain.SelectCommand.CommandText = strSQLQueryCamperCheckOut
            daMain.Fill(dsCamperCheckOut, "qryCamperCheckout1")

            daPOS.SelectCommand.CommandText = strSQLQueryCamperCheckOut2
            daPOS.Fill(dsCamperCheckOut, "qryCamperCheckout2")

            ColumnList = New ArrayList
            ColumnList.Add("qryCamperCheckout1.lngRegistrationID")
            ColumnList.Add("qryCamperCheckout1.lngRecordID")
            ColumnList.Add("qryCamperCheckout1.strLastCoName")
            ColumnList.Add("qryCamperCheckout1.strFirstName")
            ColumnList.Add("qryCamperCheckout1.strHousingName")
            ColumnList.Add("qryCamperCheckout1.strBlockCode")
            ColumnList.Add("qryCamperCheckout1.lngWeekID")
            ColumnList.Add("qryCamperCheckout1.lngSiteID")
            ColumnList.Add("qryCamperCheckout2.lngCamperID")
            ColumnList.Add("qryCamperCheckout2.lngInventoryID")
            ColumnList.Add("qryCamperCheckout2.strItemName")
            ColumnList.Add("qryCamperCheckout2.lngQuantity")
            ColumnList.Add("qryCamperCheckout2.curTotal")


            dt1 = JoinTables(dsCamperCheckOut.Tables("qryCamperCheckout1"), dsCamperCheckOut.Tables("qryCamperCheckout2"), "lngRegistrationID", "lngRegistrationID", "LEFT", ColumnList, dsCamperCheckOut)
            dt1.TableName = "qryCamperCheckout"
            dsCamperCheckOut.Tables.Add(dt1)

            'strSQLCamperStatementTotal = "SELECT tblRecords.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, Sum(tblSalesDetail.curTotal) AS Total, tblRegistrations.lngRegistrationID, tblRegistrations.lngBlockID FROM tblRecords INNER JOIN ((tblSales INNER JOIN (tblInventory INNER JOIN tblSalesDetail ON tblInventory.lngInventoryID = tblSalesDetail.lngInventoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) INNER JOIN tblRegistrations ON tblSales.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblRecords.lngRecordID = tblRegistrations.lngRecordID GROUP BY tblRecords.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, tblRegistrations.lngRegistrationID, tblRegistrations.lngBlockID;"
            'SELECT tblRecords.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, tblRegistrations.lngRegistrationID, tblRegistrations.lngBlockID FROM tblRecords INNER JOIN tblRegistrations ON tblRecords.lngRecordID = tblRegistrations.lngRecordID GROUP BY tblRecords.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, tblRegistrations.lngRegistrationID, tblRegistrations.lngBlockID;
            strSQLCamperStatementTotal = "SELECT tblSales.lngCamperID, tblSales.lngRegistrationID, tblSales.curTotalCharge as total FROM tblSales GROUP BY tblSales.lngCamperID, tblSales.lngRegistrationID, tblSales.curTotalCharge HAVING (((tblSales.lngRegistrationID) Is Not Null And Not (tblSales.lngRegistrationID)=0));"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strSQLCamperStatementTotal: " & strSQLCamperStatementTotal

            daPOS.SelectCommand.CommandText = strSQLCamperStatementTotal
            daPOS.Fill(dsCamperCheckOut, "CamperStatementTotal2")

            ColumnList.Clear()
            ColumnList = New ArrayList
            ColumnList.Add("qryCamperCheckout1.lngRegistrationID")
            ColumnList.Add("qryCamperCheckout1.lngRecordID")
            ColumnList.Add("qryCamperCheckout1.lngWeekID")
            ColumnList.Add("qryCamperCheckout1.lngSiteID")
            ColumnList.Add("CamperStatementTotal2.Total")

            dt2 = JoinTables(dsCamperCheckOut.Tables("qryCamperCheckout1"), dsCamperCheckOut.Tables("CamperStatementTotal2"), "lngRegistrationID", "lngRegistrationID", "INNER", ColumnList, dsCamperCheckOut)
            dt2.TableName = "CamperStatementTotal"
            dsCamperCheckOut.Tables.Add(dt2)

            strCampDefaults = "SELECT lngCampDefaultID, strCampName, strStoreName, lngCampState, strCampAddress FROM tblCampDefaults"
            daMain.SelectCommand.CommandText = strCampDefaults
            daMain.Fill(dsCamperCheckOut, "tblCampDefaults")

            strTax = "SELECT lngRegistrationID, SUM(curTax) AS TAX, SUM(curTotalCharge) AS CurTotalCharge FROM tblSales GROUP BY lngRegistrationID;"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strTax: " & strTax
            daPOS.SelectCommand.CommandText = strTax
            daPOS.Fill(dsCamperCheckOut, "Tax")

            strCamperAdditionalDeposits = "SELECT tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, Sum(tblTransactions.curPayment) AS AddDep FROM tblBlock INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblBlock.lngBlockID = tblRegistrations.lngBlockID   WHERE(((tblTransactions.lngTransTypeID) = 27)) GROUP BY tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID;"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strCamperAdditionalDeposits: " & strCamperAdditionalDeposits
            daMain.SelectCommand.CommandText = strCamperAdditionalDeposits
            daMain.Fill(dsCamperCheckOut, "AddtionalDeposits")

            strCamperDeposits = "SELECT tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID, Sum(tblTransactions.curPayment) AS Dep , Sum(tblTransactions.curCharge) AS Refund, tblTransactions.lngTransTypeID,[Dep]-[Refund] AS InitDep FROM tblBlock INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblBlock.lngBlockID = tblRegistrations.lngBlockID WHERE((tblTransactions.lngTransTypeID) = 25) GROUP BY tblRegistrations.lngRegistrationID, tblRegistrations.lngRecordID,tblTransactions.lngTransTypeID;"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strCamperDeposits : " & strCamperDeposits
            daMain.SelectCommand.CommandText = strCamperDeposits
            daMain.Fill(dsCamperCheckOut, "Depostis")

            strCamperWithdrawls = "SELECT  tblTransactions.lngRecordID, sum(tblTransactions.curCharge) AS Withdrawal FROM tblBlock INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblBlock.lngBlockID = tblRegistrations.lngBlockID WHERE (((tblTransactions.lngTransTypeID)=24 or (tblTransactions.lngTransTypeID)=26 or (tblTransactions.lngTransTypeID)=17)) GROUP BY tblTransactions.lngRecordID;"
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strCamperWithdrawls: " & strCamperWithdrawls
            daMain.SelectCommand.CommandText = strCamperWithdrawls
            daMain.Fill(dsCamperCheckOut, "Widrawals")
            

            objCamperCheckOutRpt = New rptCamperCheckout

            objCamperCheckOutRpt.SetDataSource(dsCamperCheckOut)

            objCamperCheckOutRpt.RecordSelectionFormula = "{qrycampercheckout.lngWeekID} = " & iWeek & " and {qrycampercheckout.lngSiteID} =  " & iSite
            objCamperCheckOutRpt.SetParameterValue("parSort", strSort)
            dsCamperCheckOut.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objCamperCheckOutRpt
        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)

        End Try
        objPOSConn = Nothing
        objMainConn = Nothing
        comPOS = Nothing
        comMain = Nothing
        daPOS = Nothing
        daMain = Nothing
        dsCamperCheckOut = Nothing

    End Sub

    Private Sub frmCamperCheckOutPreview_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCamperCheckOutPreview = Nothing
    End Sub

    Private Sub frmCamperCheckOutPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub

    Private Sub rvwReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rvwReport.Load

    End Sub

    Private Sub conPOS_InfoMessage(ByVal sender As System.Object, ByVal e As System.Data.OleDb.OleDbInfoMessageEventArgs) Handles conPOS.InfoMessage

    End Sub
End Class