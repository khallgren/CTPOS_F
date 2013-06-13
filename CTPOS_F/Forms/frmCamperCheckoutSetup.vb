Imports System.Data.OleDb


Public Class frmCamperCheckoutSetup
    Public Shared iWeek As Integer
    Public Shared iSite As Integer

    Private Sub subLoadSites()

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String

        Try

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT lngSiteID, " & _
                        "strSiteName " & _
                    "FROM tblSites " & _
                    "ORDER BY strSiteName;"

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                Me.cboPickSite.Items.Add(New clsCboItem(CType(Dr("lngSiteID"), Long), CType(Dr("strSiteName"), String)))

            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing
            Me.cboPickSite.SelectedIndex = 0

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadSites", ex)

        End Try


    End Sub


    Private Sub subLoadWeeks()

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String

        Try

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tlkpWeekDesc.lngWeekID, tlkpWeekDesc.strWeekDesc FROM(tlkpWeekDesc) ORDER BY tlkpWeekDesc.intSortOrder, tlkpWeekDesc.dteStartDate;"

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                Me.cboPickWeek.Items.Add(New clsCboItem(CType(Dr("lngWeekID"), Long), CType(Dr("strWeekDesc"), String)))

            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing

            Me.cboPickWeek.SelectedIndex = 0

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadWeeks", ex)

        End Try

    End Sub

    Private Sub subLoadSortCbo()

        cboSortBy.Items.Clear()

        cboSortBy.Items.Add(New clsCboItem("strLName", "Last Name"))
        cboSortBy.Items.Add(New clsCboItem("strCabin", "Cabin"))

        cboSortBy.SelectedIndex = 0

    End Sub
    
    Private Sub frmCamperCheckoutSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        subLoadSites()
        subLoadWeeks()
        subLoadSortCbo()

    End Sub

    Private Sub btnRefreshCoinCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshCoinCount.Click

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String
        Dim twenties, tens, fives, ones As Integer
        Dim quarters, dimes, nickels, pennies As Integer

        Dim strResult As String = ""
        Dim dblRefund As Decimal
        Dim dblCurSize As Decimal
        Dim intCount As Integer
        Dim dblTotal As Decimal

        If Me.cboPickSite.SelectedIndex = -1 Or Me.cboPickWeek.SelectedIndex = -1 Then
            Exit Sub
        End If


        Try

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblRegistrations.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, Sum(tblTransactions.curPayment) AS Payments, Sum(tblTransactions.curCharge) AS Charges, [Charges]-[Payments] AS Balance, tlkpWeekDesc.strWeekDesc FROM (tlkpWeekDesc INNER JOIN ((tblRecords INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON tblRecords.lngRecordID = tblRegistrations.lngRecordID) INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) ON tlkpWeekDesc.lngWeekID = tblBlock.lngWeekID) INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID WHERE(((tlkpTransType.blnSpending) = True) And ((tlkpWeekDesc.lngWeekID) = " & CType(CType(Me.cboPickWeek.SelectedItem, clsCboItem).ID, Long) & ") And ((tblBlock.lngSiteID) = " & CType(CType(Me.cboPickSite.SelectedItem, clsCboItem).ID, Long) & ")) GROUP BY tblRegistrations.lngRecordID, tblRecords.strFirstName, tblRecords.strLastCoName, tlkpWeekDesc.strWeekDesc;"

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader



            dblRefund = 0
            dblCurSize = 0
            intCount = 0
            twenties = 0
            tens = 0
            fives = 0
            ones = 0
            quarters = 0
            dimes = 0
            nickels = 0
            pennies = 0

            While Dr.Read
                dblRefund = CType(Dr("Balance"), Decimal) * -1
                'debug.print "----"
                'debug.print dblRefund & ", " & dblCurSize & ", " & intCount
                Do While dblRefund > 0

                    If dblRefund < 0.01 Then dblCurSize = dblRefund
                    If dblRefund >= 0.01 Then dblCurSize = 0.01
                    If dblRefund >= 0.05 Then dblCurSize = 0.05
                    If dblRefund >= 0.1 Then dblCurSize = 0.1
                    If dblRefund >= 0.25 Then dblCurSize = 0.25
                    If dblRefund >= 1 Then dblCurSize = 1
                    If dblRefund >= 5 Then dblCurSize = 5
                    If dblRefund >= 10 Then dblCurSize = 10
                    If dblRefund >= 20 Then dblCurSize = 20


                    Do While (dblRefund / dblCurSize) >= 1
                        dblRefund = dblRefund - dblCurSize
                        intCount = intCount + 1
                    Loop


                    Select Case dblCurSize
                        Case 0.01
                            pennies = pennies + intCount
                        Case 0.05
                            nickels = nickels + intCount
                        Case 0.1
                            dimes = dimes + intCount
                        Case 0.25
                            quarters = quarters + intCount
                        Case 1
                            ones = ones + intCount
                        Case 5
                            fives = fives + intCount
                        Case 10
                            tens = tens + intCount
                        Case 20
                            twenties = twenties + intCount
                    End Select
                    'debug.print dblRefund & ", " & dblCurSize & ", " & intCount

                    intCount = 0

                Loop



            End While


            strResult = strResult & vbNewLine & pennies & " pennies = " & (pennies * 0.01)
            dblTotal = dblTotal + (pennies * 0.01)

            strResult = strResult & vbNewLine & nickels & " nickels = " & (nickels * 0.05)
            dblTotal = dblTotal + (nickels * 0.05)

            strResult = strResult & vbNewLine & dimes & " dimes = " & (dimes * 0.1)
            dblTotal = dblTotal + (dimes * 0.1)

            strResult = strResult & vbNewLine & quarters & " quarters = " & (quarters * 0.25)
            dblTotal = dblTotal + (quarters * 0.25)

            strResult = strResult & vbNewLine & ones & " ones = " & (ones * 1)
            dblTotal = dblTotal + (ones * 1)

            strResult = strResult & vbNewLine & fives & " fives = " & (fives * 5)
            dblTotal = dblTotal + (fives * 5)

            strResult = strResult & vbNewLine & tens & " tens = " & (tens * 10)
            dblTotal = dblTotal + (tens * 10)

            strResult = strResult & vbNewLine & twenties & " twenties = " & (twenties * 20)
            dblTotal = dblTotal + (twenties * 20)

            strResult = strResult & vbNewLine & "total = " & dblTotal


            Me.txtCoinCount.Text = strResult

        Catch ex As Exception

            subLogErr(Me.Name & ".btnRefreshCoinCount", ex)

        End Try

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim strSort As String

        strSort = CType(cboSortBy.SelectedItem, clsCboItem).ID

        iWeek = CType(cboPickWeek.SelectedItem, clsCboItem).ID
        iSite = CType(cboPickSite.SelectedItem, clsCboItem).ID
        subShowCamperCheckOutPreview(strSort, Me.MdiParent)
        '-----------------------------
        'Dim cr As New rptCamperCheckout
        'cr.Load(strReportPath)
        'cr.SetDataSource(DS.Tables("Customers"))

        'cr.SetParameterValue("Text4", 4)
        'CrystalReportViewer.ReportSource = cr


    End Sub

    Private Sub btnGenerateRefundTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateRefundTransactions.Click
        subRefundBalance(CType(CType(Me.cboPickWeek.SelectedItem, clsCboItem).ID, Long), CType(CType(Me.cboPickSite.SelectedItem, clsCboItem).ID, Long))
    End Sub
End Class