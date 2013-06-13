Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class frmCraftSheetBlankPreview

    Private lngBlockID As Long

    Private objCraftSheetBlankRpt As rptCraftSheetBlank

    Public Sub New(ByVal _lngBlockID As Long)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lngBlockID = _lngBlockID

    End Sub

    Private Sub subConfigureCrystalReports()
        Dim objMainConn As OleDbConnection
        Dim comMain As OleDbCommand
        Dim daMain As OleDbDataAdapter

        Dim dsCraftSheetBlank As DataSet

        Dim strSQLQueryCraftSheetBlank As String

        Try

            objMainConn = New OleDbConnection()
            objMainConn.ConnectionString = strCTConn
            objMainConn.Open()

            daMain = New OleDbDataAdapter
            comMain = New OleDbCommand

            comMain.Connection = objMainConn
            daMain.SelectCommand = comMain

            dsCraftSheetBlank = New DataSet("dsCraftSheetBlank")

            strSQLQueryCraftSheetBlank = "SELECT tblRegistrations.lngRegistrationID, " & _
                                            "Sum(tblTransactions.curPayment) AS Spending, Sum(tblTransactions.curCharge) AS Charges, [Spending]-[Charges] AS Balance, " & _
                                            "tblRecords.strFirstName, tblRecords.strLastCoName, tblBlock.strBlockCode " & _
                                        "FROM (((tblRegistrations " & _
                                            "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                                            "INNER JOIN tblTransactions ON (tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID) AND " & _
                                                "(tblRecords.lngRecordID = tblTransactions.lngRecordID)) " & _
                                            "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                                            "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                                        "WHERE tlkpTransType.blnSpending = True AND " & _
                                            "tblRegistrations.lngBlockID=" & lngBlockID & " " & _
                                        "GROUP BY tblRegistrations.lngRegistrationID, " & _
                                            "tblRecords.strFirstName, tblRecords.strLastCoName, tblBlock.strBlockCode " & _
                                        "ORDER BY tblRecords.strLastCoName, tblRecords.strFirstName;"

            daMain.SelectCommand.CommandText = strSQLQueryCraftSheetBlank
            daMain.Fill(dsCraftSheetBlank, "querySpendingMoneyBalance")

            strSQLQueryCraftSheetBlank = "SELECT tblRegistrations.lngRegistrationID, " & _
                                            "0 AS Spending, 0 AS Charges, 0 AS Balance, " & _
                                            "tblRecords.strFirstName, tblRecords.strLastCoName, tblBlock.strBlockCode " & _
                                        "FROM (tblRegistrations " & _
                                            "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                                            "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID " & _
                                        "WHERE tblRegistrations.lngRegistrationID Not In " & _
                                                "(SELECT tblRegistrations.lngRegistrationID " & _
                                                "FROM (((tblRegistrations " & _
                                                    "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                                                    "INNER JOIN tblTransactions ON (tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID) AND " & _
                                                        "(tblRecords.lngRecordID = tblTransactions.lngRecordID)) " & _
                                                    "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                                                    "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                                                "WHERE tlkpTransType.blnSpending = True AND " & _
                                                    "tblRegistrations.lngBlockID=" & lngBlockID & ") AND " & _
                                            "tblRegistrations.lngBlockID=" & lngBlockID & " " & _
                                        "ORDER BY tblRecords.strLastCoName, tblRecords.strFirstName;"

            daMain.SelectCommand.CommandText = strSQLQueryCraftSheetBlank
            daMain.Fill(dsCraftSheetBlank, "querySpendingMoneyBalance")

            objCraftSheetBlankRpt = New rptCraftSheetBlank

            objCraftSheetBlankRpt.SetDataSource(dsCraftSheetBlank)

            dsCraftSheetBlank.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objCraftSheetBlankRpt

        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try

        objMainConn = Nothing
        comMain = Nothing
        daMain = Nothing
        dsCraftSheetBlank = Nothing

    End Sub

    Private Sub frmCraftSheetBlankPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class