Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class frmCraftBalanceRptPreview

    Dim arrColList As ArrayList

    Private lngBlockID As Long

    Private objCraftBalance As rptCraftBalance
    Private Date_Craft = frmCraftSales.Date_Craft

    Public Sub New(ByVal _lngBlockID As Long)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngBlockID = _lngBlockID

    End Sub

    Private Sub subConfigureCrystalReports()

        Dim objPOSConn As OleDbConnection
        Dim conCT As OleDbConnection

        Dim comPOS As OleDbCommand
        Dim cmdCT As OleDbCommand

        Dim daPOS As OleDbDataAdapter
        Dim daCT As OleDbDataAdapter

        Dim dsCraftBalance As DataSet
        Dim dtCraftBal As DataTable

        Dim strSQL As String

        Try

            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn
            objPOSConn.Open()

            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand

            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS

            conCT = New OleDbConnection(strCTConn)
            conCT.Open()

            cmdCT = New OleDbCommand
            cmdCT.Connection = conCT

            daCT = New OleDbDataAdapter(cmdCT)

            dsCraftBalance = New DataSet("dsCraftBalanceReport")

            'strSQL = "SELECT tblRegistrations.lngBlockID, tblRegistrations.lngRecordID, tblSales.lngClerkID, tblRegistrations.lngRegistrationID, " & _
            '                                "Sum(tblSalesDetail.curTotal) AS SumOfcurTotal, " & _
            '                                "dteSaleDate AS dteDate, " & _
            '                                "tblBlock.strBlockCode, tblRecords.strFirstName, tblRecords.strLastCoName " & _
            '                            "FROM ((tblBlock INNER JOIN (tblRecords INNER JOIN tblRegistrations ON tblRecords.lngRecordID=tblRegistrations.lngRecordID) ON tblBlock.lngBlockID=tblRegistrations.lngBlockID) INNER JOIN tblSales ON tblRegistrations.lngRegistrationID=tblSales.lngRegistrationID) INNER JOIN tblSalesDetail ON tblSales.lngSaleID=tblSalesDetail.lngSaleID " & _
            '                            "WHERE dteSaleDate = '" & Date_Craft & "' AND tblRegistrations.lngBlockID = " & BlockCode & " " & _
            '                            "GROUP BY tblRegistrations.lngBlockID, tblRegistrations.lngRecordID, tblSales.lngClerkID, tblRegistrations.lngRegistrationID, tblSalesDetail.lngInventoryID, " & _
            '                                "dteSaleDate, " & _
            '                                "tblBlock.strBlockCode, tblRecords.strFirstName, tblRecords.strLastCoName " & _
            '                            "HAVING (((tblSalesDetail.lngInventoryID)=" & CType(My.Settings.strCraftID, Long) & "));"

            'daPOS.SelectCommand.CommandText = strSQL
            'daPOS.Fill(dsCraftBalance, "qryCraftBalanceReportPOS")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            strSQL = "SELECT tblRegistrations.lngBlockID, tblRegistrations.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                        "tblBlock.strBlockCode, tblRecords.strFirstName, tblRecords.strLastCoName " & _
                    "FROM (tblRegistrations " & _
                        "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                        "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID " & _
                    "WHERE tblRegistrations.lngBlockID = " & lngBlockID & " " & _
                    "GROUP BY tblRegistrations.lngBlockID, tblRegistrations.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                        "tblBlock.strBlockCode, tblRecords.strFirstName, tblRecords.strLastCoName;"

            daCT.SelectCommand.CommandText = strSQL

            daCT.Fill(dsCraftBalance, "qryCraftBalanceReportCT")

            strSQL = "SELECT tblSales.lngClerkID, tblSales.lngRegistrationID, " & _
                        "Sum(tblSalesDetail.curTotal) AS SumOfcurTotal, " & _
                        "dteSaleDate AS dteDate " & _
                    "FROM tblSales  INNER JOIN tblSalesDetail ON tblSales.lngSaleID=tblSalesDetail.lngSaleID " & _
                    "WHERE dteSaleDate = '" & Date_Craft & "' " & _
                    "GROUP BY tblSales.lngClerkID, tblSales.lngRegistrationID, tblSalesDetail.lngInventoryID, " & _
                        "dteSaleDate " & _
                    "HAVING (((tblSalesDetail.lngInventoryID)=" & CType(My.Settings.strCraftID, Long) & "));"

            daPOS.SelectCommand.CommandText = strSQL

            daPOS.Fill(dsCraftBalance, "qryCraftBalanceReportPOS")

            arrColList = New ArrayList

            arrColList.Add("qryCraftBalanceReportCT.lngBlockID")
            arrColList.Add("qryCraftBalanceReportCT.lngRecordID")
            arrColList.Add("qryCraftBalanceReportCT.lngRegistrationID")
            arrColList.Add("qryCraftBalanceReportCT.strBlockCode")
            arrColList.Add("qryCraftBalanceReportCT.strFirstName")
            arrColList.Add("qryCraftBalanceReportCT.strLastCoName")
            arrColList.Add("qryCraftBalanceReportPOS.lngClerkID")
            arrColList.Add("qryCraftBalanceReportPOS.SumOfcurTotal")
            arrColList.Add("qryCraftBalanceReportPOS.dteDate")

            dtCraftBal = JoinTables(dsCraftBalance.Tables("qryCraftBalanceReportCT"), dsCraftBalance.Tables("qryCraftBalanceReportPOS"), "lngRegistrationID", "lngRegistrationID", "INNER", arrColList, dsCraftBalance)
            dtCraftBal.TableName = "qryCraftBalanceReport"
            dsCraftBalance.Tables.Add(dtCraftBal)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            objCraftBalance = New rptCraftBalance

            objCraftBalance.SetDataSource(dsCraftBalance)

            dsCraftBalance.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objCraftBalance

        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try


        objPOSConn = Nothing
        comPOS = Nothing
        daPOS = Nothing
        dsCraftBalance = Nothing

    End Sub


    Private Sub frmCraftBalanceRptPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class