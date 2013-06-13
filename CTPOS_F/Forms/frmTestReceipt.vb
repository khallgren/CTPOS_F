Imports System.Data.OleDb
Imports Microsoft.Win32


Public Class frmTestReceipt

    Private Sub TestReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsRecords.tblRecords' table. You can move, or remove it, as needed.
        Me.TblRecordsTableAdapter.Fill(Me.DsRecords.tblRecords)
    End Sub

    Private Sub CamperNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamperNames.SelectedIndexChanged

        'Dim _strPaymentType As String


        If blnUseBell Then
            rcptInit = ""
            rcptLeftJustify = ""
            rcptCenterJustify = ""
            rcptRightJustify = ""
            rcptReverseOn = ""
            rcptReverseOff = ""
            rcptLargeFont = ""
            rcptRegularFont = ""
            rcptFeedandCut = ""
            rcptKickDrawer = ""
        Else
            rcptInit = Chr(&H1B) & "@" & Chr(1)
            rcptNewLine = Chr(13) & Chr(10)
            rcptLeftJustify = Chr(&H1B) & "a" & Chr(0)
            rcptCenterJustify = Chr(&H1B) & "a" & Chr(1)
            rcptRightJustify = Chr(&H1B) & "a" & Chr(2)
            rcptReverseOn = Chr(&H1B) & "b" & Chr(1)
            rcptReverseOff = Chr(&H1B) & "b" & Chr(0)
            rcptLargeFont = Chr(&H1B) & "!" & Chr(17)
            rcptRegularFont = Chr(&H1B) & "!" & Chr(1)
            rcptFeedandCut = Chr(&H1D) & "V" & Chr(66) & Chr(0)
            rcptKickDrawer = Chr(&H1B) & Chr(&H70) & Chr(&H0) & Chr(60) & Chr(120)
        End If


        Dim x As Integer = 0
        If blnUsePrinter = False Then Exit Sub

        Try

            'If _strPaymentType = "" Then _strPaymentType = "unknown"


            Dim objConn As OleDbConnection

            Dim objCommand As OleDbCommand
            Dim objCommand1 As OleDbCommand

            Dim rs As OleDbDataReader
            Dim rs1 As OleDbDataReader

            Dim strOutput As String = ""
            Dim strRegularOutput As String = ""
            Dim strCCOutput As String = ""
            Dim strDetailsSQL As String
            Dim strBalancesSQL As String

            Dim strItemLine As String = ""

            Dim curTotalCharge As Double = 0
            Dim curSubTotal As Double = 0
            Dim curTax As Double = 0

            Dim blnCC As Boolean = False
            Dim blnFirst As Boolean = False

            ''init
            blnFirst = False

            objConn = New OleDbConnection

            objConn.ConnectionString = strCTConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strDetailsSQL = "SELECT     dbo.tblInventory.strItemName, dbo.tblSalesDetail.lngQuantity, dbo.tblSalesDetail.curPrice, dbo.tblSales.dteSaleDate, dbo.tblSales.curTotalCharge,  dbo.tblSales.lngRegistrationID FROM         dbo.tblInventory INNER JOIN dbo.tblSalesDetail ON dbo.tblInventory.lngInventoryID = dbo.tblSalesDetail.lngInventoryID INNER JOIN dbo.tblSales ON dbo.tblSalesDetail.lngSaleID = dbo.tblSales.lngSaleID WHERE     (dbo.tblSales.lngRegistrationID = 6;"

            objCommand.CommandText = strDetailsSQL

            rs = objCommand.ExecuteReader
            'subPrintHeader()

            ' strOutput = rcptInit & _
            '            rcptCenterJustify & strHeader & rcptNewLine & rcptNewLine
            strOutput = strOutput & vbCrLf & vbCrLf & vbCrLf
            strOutput = "-------------------DETAILS------------------" & vbCrLf & vbCrLf & vbCrLf
            strOutput = strOutput & " Item Name          Quantity           Price" & vbCrLf
            strOutput = strOutput & "_________________________________________" & vbCrLf

            Do While rs.Read
                strOutput = strOutput & rs("ItemName") & " : " & rs("lngQuantity") & " : " & rs("curTotal") & vbCrLf
            Loop


            strOutput = strOutput & "__________________________________________" & vbCrLf & vbCrLf & vbCrLf
            strOutput = strOutput & "-------------------BALANCES------------------" & vbCrLf

            objCommand1 = New OleDbCommand
            objCommand1.Connection = objConn

            'Query For Printing Balance Report
            strBalancesSQL = "SELECT     tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, SUM(tblTransactions.curPayment) AS Payments, SUM(tblTransactions.curCharge) AS Charges, charges - payments AS Balance, tblBlock.lngWeekID, tblBlock.lngSiteID FROM ((tblBlock INNER JOIN (tblRecords INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON  tblRecords.lngRecordID = tblTransactions.lngRecordID AND tblRecords.lngRecordID = tblRegistrations.lngRecordID) ON  tblBlock.lngBlockID = tblRegistrations.lngBlockID) INNER JOIN  tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID) WHERE (tlkpTransType.blnSpending = -1) and tblRecords.lngRecordID = " & CType(Me.CamperNames.SelectedValue, Integer) & " GROUP BY tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, tblBlock.lngWeekID, tblBlock.lngSiteID "

            objCommand1.CommandText = strBalancesSQL
            rs1 = objCommand1.ExecuteReader

            Do While rs1.Read
                strOutput = strOutput & "Payments_______________ $" & CType(rs1("Payments"), Double) & vbCrLf
                strOutput = strOutput & "Charges _______________ $" & CType(rs1("Charges"), Double) & vbCrLf
                strOutput = strOutput & "Balance _______________ $" & CType(rs1("Balance"), Double) & vbCrLf & vbCrLf
            Loop

            Me.Receipt.Text = strOutput

            objConn.Close()

            objConn = Nothing
            objCommand = Nothing
            rs = Nothing
            objCommand1 = Nothing
            rs1 = Nothing

        Catch ex As Exception
            subLogErr("subPrintReceipt", ex)
        End Try

    End Sub

   
    Private Sub frmTestReceipt_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
        Me.CamperNames = Nothing
        Me.Receipt = Nothing
        Me.DsRecords = Nothing
        Me.TblRecordsBindingSource = Nothing
        Me.TblRecordsTableAdapter = Nothing

    End Sub
End Class