Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class FrmTSTWidrwalLablePreview
    Private objTSTWithdrawalLablesRpt As rptTSTWithdrawalLables

    Private lngBlockID As Long
    Public Property BlockID() As Long
        Get
            Return lngBlockID
        End Get
        Set(ByVal value As Long)
            lngBlockID = value
        End Set
    End Property

    Private Sub subConfigureCrystalReports()


        Dim objCTConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsTSTWidrawalLables As DataSet
        Dim StrSQL As String

        Try
            objCTConn = New OleDbConnection()
            objCTConn.ConnectionString = strCTConn
            objCTConn.Open()
            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand
            comPOS.Connection = objCTConn
            daPOS.SelectCommand = comPOS
            dsTSTWidrawalLables = New DataSet("DSqryTSTWithdrawalLabels")
            StrSQL = "SELECT     tblRegistrations.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, SUM(tblTransactions.curPayment) AS Payments, SUM(tblTransactions.curCharge) AS Charges, Charges - Payments AS Balance, tlkpWeekDesc.strWeekDesc, tblRegistrations.lngBlockID FROM         (tlkpWeekDesc INNER JOIN ((tblRecords INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblRecords.lngRecordID = tblRegistrations.lngRecordID)  INNER Join tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) ON tlkpWeekDesc.lngWeekID = tblBlock.lngWeekID) GROUP BY tblRegistrations.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, tlkpWeekDesc.strWeekDesc, tblRegistrations.lngBlockID" ' & lngBlockID.ToString() & ")"
            daPOS.SelectCommand.CommandText = StrSQL
            daPOS.Fill(dsTSTWidrawalLables, "qryTSTWithdrawalLables")

            objTSTWithdrawalLablesRpt = New rptTSTWithdrawalLables

            objTSTWithdrawalLablesRpt.SetDataSource(dsTSTWidrawalLables)

            '            objTSTWithdrawalLablesRpt.RecordSelectionFormula = "{qryTSTWithdrawalLables.lngBlockID} = " + lngBlockID.ToString()

            dsTSTWidrawalLables.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objTSTWithdrawalLablesRpt
        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)

        End Try
        objCTConn = Nothing
        comPOS = Nothing
        daPOS = Nothing
        dsTSTWidrawalLables = Nothing

    End Sub

    Private Sub frmTSTWidrawalLablesPreview_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objTSTWithdrawalLablesRpt = Nothing
    End Sub

    Private Sub frmTSTWidrawalLablesPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub

End Class