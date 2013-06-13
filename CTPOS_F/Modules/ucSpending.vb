Imports System.Data.OleDb

Public Class ucSpending
    Public lngRegistrationID As Long
    Public lngWeekID As Long = 0
    Public lngBlockID As Long = 0

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            lngRegId = -2
            objSwitchboard.dlmSwitchboard.SuspendLayout()
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btncontinue").Visible = False
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btncancel").Visible = False
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btnaddspendingmoney").Visible = True
            objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.AutoHide
            objSwitchboard.dlmSwitchboard.ResumeLayout()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnCancel", ex)

        End Try
    End Sub

    Private Sub subLoadWeeks()

        Dim cboWeek As clsCboItem

        Dim strSQL As String

        Try

            Me.cboWeekCode.Items.Clear()

            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                strSQL = "SELECT tlkpWeekDesc.lngWeekID, " & _
                            "tlkpWeekDesc.strWeekDesc " & _
                        "FROM (((tlkpWeekDesc " & _
                            "INNER JOIN tblBlock ON tlkpWeekDesc.lngWeekID = tblBlock.lngWeekID) " & _
                            "INNER JOIN tblRegistrations ON tblBlock.lngBlockID = tblRegistrations.lngBlockID) " & _
                            "INNER JOIN tblTransactions ON tblRegistrations.lngRecordID = tblTransactions.lngRecordID) " & _
                            "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                        "WHERE tlkpTransType.blnSpending = True " & _
                        "GROUP BY tlkpWeekDesc.lngWeekID, tlkpWeekDesc.strWeekDesc, tlkpWeekDesc.intSortOrder, tlkpWeekDesc.dteStartDate " & _
                        "ORDER BY tlkpWeekDesc.intSortOrder, tlkpWeekDesc.dteStartDate;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drBlock As OleDbDataReader = cmdDB.ExecuteReader

                        While drBlock.Read

                            cboWeek = New clsCboItem(CType(drBlock("lngWeekID"), Long), CType(drBlock("strWeekDesc"), String))

                            Me.cboWeekCode.Items.Add(cboWeek)

                            If CType(drBlock("lngWeekID"), Long) = lngWeekID Then Me.cboWeekCode.SelectedIndex = Me.cboWeekCode.Items.Count - 1

                        End While

                        drBlock.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

            
        Catch ex As Exception

            subLogErr(Me.Name & ".LoadWeeks", ex)

        End Try

    End Sub

    Private Sub subLoadBlocks()

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drBlock As OleDbDataReader

        Dim cboBlock As clsCboItem

        Dim strSQL As String

        Try

            Me.cboBlockCode.Items.Clear()
            Me.cboBlockCode.Text = ""

            objConn = New OleDbConnection

            objConn.ConnectionString = strCTConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            If Me.cboWeekCode.SelectedIndex >= 0 Then
                lngWeekID = CType(CType(Me.cboWeekCode.SelectedItem, clsCboItem).ID, Long)
            Else
                lngWeekID = 0
            End If

            If lngWeekID = 0 Then

                strSQL = "SELECT tblBlock.lngBlockID, " & _
                            "tlkpWeekDesc.dteStartDate, " & _
                            "tblBlock.strBlockCode " & _
                        "FROM ((((tblRecords " & _
                            "INNER JOIN tblRegistrations ON tblRecords.lngRecordID = tblRegistrations.lngRecordID) " & _
                            "INNER JOIN tblBlock ON tblBlock.lngBlockID = tblRegistrations.lngBlockID) " & _
                            "INNER JOIN tlkpWeekDesc ON tblBlock.lngWeekID = tlkpWeekDesc.lngWeekID) " & _
                            "INNER JOIN tblTransactions ON tblRecords.lngRecordID = tblTransactions.lngRecordID) " & _
                            "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                        "GROUP BY tlkpTransType.blnSpending, " & _
                            "tblBlock.lngBlockID, tlkpWeekDesc.intSortOrder, " & _
                            "tlkpWeekDesc.dteStartDate, " & _
                            "tblBlock.strBlockCode " & _
                        "HAVING tlkpTransType.blnSpending = True " & _
                        "ORDER BY tlkpWeekDesc.dteStartDate, tlkpWeekDesc.intSortOrder;"

            Else

                strSQL = "SELECT tblBlock.lngBlockID, " & _
                            "tlkpWeekDesc.dteStartDate, " & _
                            "tblBlock.strBlockCode " & _
                        "FROM tblBlock " & _
                            "INNER JOIN tlkpWeekDesc ON tblBlock.lngWeekID = tlkpWeekDesc.lngWeekID " & _
                        "Where tlkpWeekDesc.lngWeekID = " & lngWeekID & " " & _
                        "ORDER BY tlkpWeekDesc.dteStartDate;"

            End If

            objCommand.CommandText = strSQL

            drBlock = objCommand.ExecuteReader

            While drBlock.Read

                Dim dteStartDate As Date

                Try
                    dteStartDate = Convert.ToDateTime(drBlock("dteStartDate"))
                Catch ex As Exception
                    dteStartDate = Date.MinValue
                End Try

                cboBlock = New clsCboItem(CType(drBlock("lngBlockID"), Long), CType(CType(drBlock("strBlockCode"), String) & ": " & dteStartDate, String))

                Me.cboBlockCode.Items.Add(cboBlock)

                If CType(drBlock("lngblockid"), Long) = lngBlockID Then
                    Me.cboBlockCode.SelectedIndex = Me.cboBlockCode.Items.Count - 1
                End If

            End While


            drBlock.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".LoadBlocks", ex)

        End Try

    End Sub

    Private Sub ucSpending_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.cboBlockCode.Items.Clear()
        Me.cboWeekCode.Items.Clear()

        subSetTimerInterval()
        subLoadBlocks()
        subLoadWeeks()

        subLoadDefaultCampers()

        Me.cboBlockCode.SelectedIndex = -1
        Me.cboWeekCode.SelectedIndex = -1
    
    End Sub

    Private Sub subSetTimerInterval()

        Dim strSQL As String = ""

        Dim intDuration As Int32 = 0

        Using conDB As New OleDbConnection(strCTConn)

            conDB.Open()

            strSQL = "SELECT intSpendingRefDur " & _
                    "FROM tblCampDefaults"

            Using cmdDB As New OleDbCommand(strSQL, conDB)

                Try
                    intDuration = Int32.Parse(cmdDB.ExecuteScalar().ToString()) * 1000
                Catch ex As Exception
                    intDuration = 30000
                End Try

            End Using

        End Using

        Me.tmrRefreshSpending.Interval = intDuration

    End Sub

    Public Sub subLoadDefaultCampers()

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drReg As OleDbDataReader

        Dim cboCamper As clsCboItem

        Dim strSQL As String

        Try

            Me.lstCampers.Items.Clear()

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                        "Sum(tblTransactions.curPayment) AS curPayments, Sum(tblTransactions.curCharge) AS curCharges, [curPayments]-[curCharges] AS curBalance, " & _
                        "tblRecords.strFirstName, tblRecords.strLastCoName " & _
                    "FROM ((((tblRegistrations " & _
                        "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                        "INNER JOIN tblTransactions ON tblRecords.lngRecordID = tblTransactions.lngRecordID AND " & _
                            "tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID) " & _
                        "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID) " & _
                        "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                        "INNER JOIN tlkpWeekDesc ON tlkpWeekDesc.lngWeekID = tblBlock.lngWeekID " & _
                    "WHERE (((tlkpTransType.blnSpending)=True) AND " & _
                        "((DateDiff('n',CDate(Format([tlkpWeekDesc].[dteStartDate],""m/d/yyyy"") & "" "" & Format([tlkpWeekDesc].[dteStartTime],""h:mm ampm"")),Now()))>=0) AND " & _
                        "((DateDiff('n',Now(),CDate(Format([tlkpWeekDesc].[dteEndDate],""m/d/yyyy"") & "" "" & Format([tlkpWeekDesc].[dteEndTime],""h:mm ampm""))))>=0)) " & _
                    "GROUP BY tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                        "tblRecords.strFirstName, tblRecords.strLastCoName"

            If blnCamperSort Then
                strSQL = strSQL & " order by tblrecords.strlastconame, tblrecords.strfirstname"
            Else
                strSQL = strSQL & " order by tblrecords.strfirstname, tblrecords.strlastconame"
            End If

            objCommand.CommandText = strSQL

            drReg = objCommand.ExecuteReader

            If drReg.HasRows Then

                Dim strFName As String
                Dim strLName As String

                While drReg.Read

                    Try
                        strFName = CType(drReg("strFirstName"), String)
                    Catch ex As Exception
                        strFName = ""
                    End Try

                    Try
                        strLName = CType(drReg("strLastCoName"), String)
                    Catch ex As Exception
                        strLName = ""
                    End Try

                    Try

                        If blnCamperSort Then
                            cboCamper = New clsCboItem(CType(drReg("lngRegistrationID"), Long), strLName & ", " & strFName & ": " & Format(drReg("curBalance"), "currency"))
                        Else
                            cboCamper = New clsCboItem(CType(drReg("lngRegistrationID"), Long), strFName & " " & strLName & ": " & Format(drReg("curBalance"), "currency"))
                        End If

                        Me.lstCampers.Items.Add(cboCamper)

                    Catch ex As Exception

                    End Try

                End While

            End If

            drReg.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.cboBlockCode.Name & ".SelectedIndexChanged", ex)

        End Try

        drReg = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        Me.btnContinue.Enabled = False
        subProceed()

    End Sub

    Private Sub subProceed()

        Try
            If Me.txtRegistrationID.Text <> "" Then

                If IsNumeric(Me.txtRegistrationID.Text) Then
                    Me.lngRegistrationID = CType(Me.txtRegistrationID.Text, Long)
                Else
                    MsgBox("Registration ID must be numeric.")
                    Me.txtRegistrationID.Focus()
                    Exit Sub
                End If

                'Exit Sub
            ElseIf Me.txtRegistrationID.Text = "" And Me.lstCampers.SelectedIndex < 0 Then

                MsgBox("Please select a camper or click 'Cancel'.")
                Exit Sub

            Else

                Me.lngRegistrationID = CType(CType(Me.lstCampers.SelectedItem, clsCboItem).ID, Long)

            End If
                lngRegId = Me.lngRegistrationID

        Catch ex As Exception

            subLogErr(Me.Name & ".btnContinue_Click", ex)

        End Try
    End Sub

    Private Sub txtRegistrationID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegistrationID.KeyPress

        Dim isKey As Boolean = Char.IsDigit(e.KeyChar)

        If Not isKey And Not e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) And Not e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) And Not e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) And Not e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Left) And Not e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Right) Then
            'Me.txtRegistrationID.Text = ""
            'Me.lstCampers.Focus()
            Me.lstCampers.SelectedIndex = Me.lstCampers.FindString(Me.txtRegistrationID.Text & e.KeyChar)

        End If


        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            If Not IsNumeric(Me.txtRegistrationID.Text) Then
                Me.txtRegistrationID.Text = ""
            End If

            subRefreshCampers(sender, e)

        End If

    End Sub

    Private Sub cboBlockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBlockCode.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            Me.cboBlockCode.SelectedItem = Nothing
            subRefreshCampers(Me, e)
        End If
    End Sub

    Private Sub subRefreshCampers(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboWeekCode.SelectedIndexChanged, cboBlockCode.SelectedIndexChanged

        subSetTimerInterval()

        If Me.cboBlockCode.SelectedItem Is Nothing And Me.cboWeekCode.SelectedItem Is Nothing And Me.txtRegistrationID.Text = "" Then
            subLoadDefaultCampers()
            Exit Sub
        End If

        Dim cboCamper As clsCboItem

        Dim strSQL As String
        Dim strWhere As String
        Dim strFName As String
        Dim strLName As String

        Dim lngRegID As Long

        Try

            If Me.txtRegistrationID.Text = "" Then
                lngRegID = 0
            Else
                If IsNumeric(Me.txtRegistrationID.Text) Then
                    lngRegID = CType(Me.txtRegistrationID.Text, Long)
                Else
                    lngRegID = 0
                End If
            End If

            If Me.cboBlockCode.SelectedIndex < 0 Or Me.cboBlockCode.Text = "" Then
                lngBlockID = 0
            Else
                lngBlockID = CType(CType(Me.cboBlockCode.SelectedItem, clsCboItem).ID, Long)
            End If

            If Me.cboWeekCode.SelectedIndex < 0 Or Me.cboWeekCode.Text = "" Then
                lngWeekID = 0
            Else
                lngWeekID = CType(CType(Me.cboWeekCode.SelectedItem, clsCboItem).ID, Long)
            End If

            If lngWeekID > 0 And sender.Equals(Me.cboWeekCode) Then subLoadBlocks()

            Me.lstCampers.Items.Clear()

            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                strWhere = ""

                If lngRegID > 0 Then
                    strWhere = "WHERE tblRegistrations.lngRegistrationID=" & lngRegID
                ElseIf lngBlockID > 0 Then
                    strWhere = "WHERE tblRegistrations.lngBlockID=" & lngBlockID
                ElseIf lngWeekID > 0 Then
                    strWhere = "WHERE tblBlock.lngWeekID=" & lngWeekID
                End If

                strSQL = "SELECT tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                            "sqryBalance.curPayments, sqryBalance.curCharges, IIf(IsNull([sqryBalance].[curBalance]), 0, [sqryBalance].[curBalance]) AS curBalance, " & _
                            "tblRecords.strFirstName, tblRecords.strLastCoName " & _
                        "FROM ((tblRegistrations " & _
                            "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                            "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                            "LEFT JOIN " & _
                                "(SELECT tblRegistrations.lngRegistrationID, " & _
                                    "Sum(tblTransactions.curPayment) AS curPayments, Sum(tblTransactions.curCharge) AS curCharges, [curPayments]-[curCharges] AS curBalance " & _
                                "FROM (tblRegistrations " & _
                                    "INNER JOIN tblTransactions ON (tblRegistrations.lngRecordID = tblTransactions.lngRecordID) AND " & _
                                        "(tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID)) " & _
                                    "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                                "WHERE tlkpTransType.blnSpending = True " & _
                                "GROUP BY tblRegistrations.lngRegistrationID) AS sqryBalance ON tblRegistrations.lngRegistrationID = sqryBalance.lngRegistrationID " & _
                        strWhere

                If blnCamperSort Then
                    strSQL = strSQL & " order by tblrecords.strlastconame, tblrecords.strfirstname"
                Else
                    strSQL = strSQL & " order by tblrecords.strfirstname, tblrecords.strlastconame"
                End If

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drReg As OleDbDataReader = cmdDB.ExecuteReader

                            While drReg.Read

                            Try
                                strLName = CType(drReg("strLastCoName"), String)
                            Catch ex As Exception
                                strLName = ""
                            End Try

                            Try
                                strFName = CType(drReg("strFirstName"), String)
                            Catch ex As Exception
                                strFName = ""
                            End Try

                            Try

                                If blnCamperSort Then
                                    cboCamper = New clsCboItem(CType(drReg("lngRegistrationID"), Long), strLName & ", " & strFName & ": " & Format(drReg("curBalance"), "currency"))
                                Else
                                    cboCamper = New clsCboItem(CType(drReg("lngRegistrationID"), Long), strFName & " " & strLName & ": " & Format(drReg("curBalance"), "currency"))
                                End If

                                Me.lstCampers.Items.Add(cboCamper)

                            Catch ex As Exception

                            End Try

                        End While
                        
                        'if only one listed, select it
                        If Me.lstCampers.Items.Count = 1 Then
                            Me.lstCampers.SelectedIndex = 0
                            Me.txtRegistrationID.Text = ""
                            Me.btnContinue.Focus()
                        End If

                        drReg.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr(Me.cboBlockCode.Name & ".SelectedIndexChanged", ex)

        End Try

    End Sub

    Private Sub tmrRefreshSpending_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshSpending.Tick

        Try
            tmrRefreshSpending.Enabled = False
            objSwitchboard.lblRefreshStatus.Text = "Refreshing spending money list..."
            Application.DoEvents()
            If Not Me.ContainsFocus And Not blnSaleOpen Then subRefreshCampers(Me, e)
            objSwitchboard.lblRefreshStatus.Text = ""
            tmrRefreshSpending.Enabled = True

        Catch ex As Exception
            subLogErr("ucSpending.trmRefreshSpending.Tick", ex)
        End Try

    End Sub

    Private Sub btnAddSpendingMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSpendingMoney.Click

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strPW As String
        Dim strSQL As String

        Dim dblAmt As Double = 0

        Dim lngAdminID As Long

        Try

            If Not objLogin.chkAdmin.Checked Then

                strPW = InputBox("Please enter the administrator password to enter spending money:")

                objConn = New OleDbConnection(strPOSConn)

                objConn.Open()

                objCommand = New OleDbCommand

                objCommand.Connection = objConn

                strSQL = "SELECT lngClerkID " & _
                        "FROM tblClerks " & _
                        "WHERE blnAdmin<>0 AND " & _
                            "strPassword='" & strPW & "'"

                objCommand.CommandText = strSQL

                lngAdminID = CType(objCommand.ExecuteScalar, Long)

                objConn.Close()

                objCommand.Dispose()
                objConn.Dispose()

                objCommand = Nothing
                objConn = Nothing

                If lngAdminID <= 0 Then
                    MsgBox("Invalid password.")
                    Exit Sub
                End If

            End If

            If Me.txtRegistrationID.Text <> "" Then
                If IsNumeric(Me.txtRegistrationID.Text) Then
                    Me.lngRegistrationID = CType(Me.txtRegistrationID.Text, Long)
                Else
                    MsgBox("Registration ID must be numeric.")
                    Me.txtRegistrationID.Focus()
                    Exit Sub
                End If

                'Exit Sub
            ElseIf Me.txtRegistrationID.Text = "" And Me.lstCampers.SelectedIndex < 0 Then

                MsgBox("You must select a camper first.")
                Exit Sub

            Else

                Dim strIn As String

                Try
                    strIn = InputBox("Please enter amount (no decimal, enter $2.50 as 250)", , "0")
                Catch ex As Exception
                    strIn = ""
                End Try

                If (IsNumeric(strIn)) Then
                    dblAmt = Convert.ToDouble(strIn)
                Else
                    dblAmt = 0
                End If

                dblAmt = dblAmt / 100

                If dblAmt <= 0 Then
                    If MsgBox("Amount is not greater than zero, deduct amount from spending money?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                If dblAmt > 1000 Then
                    If MsgBox("Amount is excessive (greater than $1000)." & vbNewLine & "Are you sure you wish to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Me.lngRegistrationID = CType(CType(Me.lstCampers.SelectedItem, clsCboItem).ID, Long)
                lngRegId = Me.lngRegistrationID

                subAddSpendingMoney(lngRegId, dblAmt)
                subRefreshCampers(Me, e)
            End If

        Catch ex As Exception
            subLogErr("btnAddSpendingMoney", ex)
        End Try

    End Sub

    Private Sub lstCampers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCampers.SelectedIndexChanged
        Me.btnContinue.Enabled = True
    End Sub

    Private Sub btnQuickPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickPrint.Click

        If Me.txtRegistrationID.Text <> "" Then

            If IsNumeric(Me.txtRegistrationID.Text) Then
                Me.lngRegistrationID = CType(Me.txtRegistrationID.Text, Long)
            Else
                MsgBox("Registration ID must be numeric.")
                Me.txtRegistrationID.Focus()
                Exit Sub
            End If

            'Exit Sub
        ElseIf Me.txtRegistrationID.Text = "" And Me.lstCampers.SelectedIndex < 0 Then

            MsgBox("Please select a camper or click 'Cancel'.")
            Exit Sub

        Else

            Me.lngRegistrationID = CType(CType(Me.lstCampers.SelectedItem, clsCboItem).ID, Long)

        End If
        lngRegId = Me.lngRegistrationID

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

        Try

            Dim strOutput As String = ""
            Dim strRegularOutput As String = ""
            Dim strCCOutput As String = ""
            Dim strDetailsSQL As String
            Dim strBalancesSQL As String
            Dim strSQL As String
            Dim strItemLine As String = ""

            Dim curTotalCharge As Double = 0
            Dim curSubTotal As Double = 0
            Dim curTax As Double = 0

            Dim blnCC As Boolean = False
            Dim blnFirst As Boolean = False

            Using conCTMain As New OleDbConnection(strCTConn)

                Try

                    conCTMain.Open()

                    strSQL = "SELECT tblRegistrations.lngRecordID, " & _
                                "strFirstName, strLastCoName " & _
                            "FROM tblRegistrations " & _
                                "INNER JOIN tblRecords ON tblRegistrations.lngRecordID=tblRecords.lngRecordID " & _
                            "WHERE tblRegistrations.lngRegistrationID=" & lngRegId

                    Using cmdCTMain As New OleDbCommand(strSQL, conCTMain)

                        Using drCTMain As OleDbDataReader = cmdCTMain.ExecuteReader()

                            If drCTMain.Read() Then

                                strOutput = strOutput & "Record ID: " & drCTMain("lngRecordID") & vbCrLf & _
                                                drCTMain("strFirstName") & " " & drCTMain("strLastCoName") & vbCrLf & _
                                                vbCrLf & _
                                                vbCrLf

                            End If

                            drCTMain.Close()

                        End Using

                    End Using

                    conCTMain.Close()

                Catch ex As Exception
                    subLogErr("", ex)

                End Try

            End Using

            ''init
            blnFirst = False

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strDetailsSQL = "SELECT     dbo.tblInventory.strItemName, " & _
                                    "dbo.tblSalesDetail.lngQuantity, " & _
                                    "dbo.tblSalesDetail.curTotal, " & _
                                    "dbo.tblSales.dteSaleDate, dbo.tblSales.curTotalCharge,  dbo.tblSales.lngRegistrationID " & _
                                "FROM         dbo.tblInventory " & _
                                    "INNER JOIN dbo.tblSalesDetail ON dbo.tblInventory.lngInventoryID = dbo.tblSalesDetail.lngInventoryID " & _
                                    "INNER JOIN dbo.tblSales ON dbo.tblSalesDetail.lngSaleID = dbo.tblSales.lngSaleID " & _
                                "WHERE     (dbo.tblSales.lngRegistrationID = " & lngRegId & ");"

                Using cmdDB = New OleDbCommand(strDetailsSQL, conDB)

                    Using rs As OleDbDataReader = cmdDB.executereader()

                        strOutput = strOutput & "------------------DETAILS-----------------" & vbCrLf & vbCrLf & vbCrLf
                        strOutput = strOutput & " Item Name                 Quantity  Price" & vbCrLf
                        strOutput = strOutput & "__________________________________________" & vbCrLf

                        Dim strItem As String

                        Dim curTotal As Double

                        Do While rs.Read

                            strItem = NZ(rs("strItemName"))

                            If strItem.Length > 27 Then
                                strItem = strItem.Substring(0, 27)
                            Else
                                strItem = strItem.PadRight(27)
                            End If

                            If IsNumeric(rs("curTotal")) Then
                                curTotal = rs("curTotal")
                            Else
                                curTotal = 0
                            End If

                            strOutput = strOutput & strItem & CType(rs("lngQuantity"), String).PadLeft(3) & FormatCurrency(curTotal, 2, TriState.False, TriState.True, ).PadLeft(12) & vbCrLf

                        Loop

                        rs.Close()

                    End Using

                    strOutput = strOutput & "__________________________________________" & vbCrLf & vbCrLf & vbCrLf
                    strOutput = strOutput & "------------------BALANCES----------------" & vbCrLf

                    Using conDBMain As OleDbConnection = New OleDbConnection(strCTConn)

                        conDBMain.Open()

                        'Query For Printing Balance Report
                        strBalancesSQL = "SELECT     tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, SUM(tblTransactions.curPayment) AS Payments, SUM(tblTransactions.curCharge) AS Charges, payments - charges AS Balance, tblBlock.lngWeekID, tblBlock.lngSiteID FROM ((tblBlock INNER JOIN (tblRecords INNER JOIN (tblTransactions INNER JOIN tblRegistrations ON tblTransactions.lngRegistrationID = tblRegistrations.lngRegistrationID) ON  tblRecords.lngRecordID = tblTransactions.lngRecordID AND tblRecords.lngRecordID = tblRegistrations.lngRecordID) ON  tblBlock.lngBlockID = tblRegistrations.lngBlockID) INNER JOIN  tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID) WHERE (tlkpTransType.blnSpending = -1) and tblRegistrations.lngRegistrationID = " & lngRegId & " GROUP BY tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, tblBlock.lngWeekID, tblBlock.lngSiteID "

                        Using cmdDBMain As OleDbCommand = New OleDbCommand(strBalancesSQL, conDBMain)

                            Using rsMain As OleDbDataReader = cmdDBMain.ExecuteReader()

                                Do While rsMain.Read
                                    strOutput = strOutput & ("Payments_____________ " & FormatCurrency(CType(rsMain("Payments"), Double), 2, TriState.False, TriState.True, )).PadLeft(42) & vbCrLf
                                    strOutput = strOutput & ("Charges _____________ " & FormatCurrency(CType(rsMain("Charges"), Double), 2, TriState.False, TriState.True, )).PadLeft(42) & vbCrLf
                                    strOutput = strOutput & ("Balance _____________ " & FormatCurrency(CType(rsMain("Balance"), Double), 2, TriState.False, TriState.True, )).PadLeft(42) & vbCrLf & vbCrLf
                                Loop

                                rsMain.Close()

                            End Using

                            Dim f As New frmQuickSalesHistory
                            f.txtDisplay.Text = strOutput
                            f.ShowDialog()

                        End Using

                        conDBMain.Close()

                    End Using

                    conDB.Close()

                End Using

            End Using

        Catch ex As Exception
            subLogErr("subPrintReceipt", ex)
        End Try
    End Sub
End Class
