Imports CTPOS_F.clsGlobalEnum
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Deployment.Application
Imports System.Reflection

Module basMain

    Public blnDebug As Boolean = False

    Public objSwitchboard As frmSwitchboard
    Public objCashSales As frmCashSales
    Public objLogin As frmLogin
    Public objZOutSetup As frmZOutSetup
    Public objZOutPreview As frmZOutPreview
    Public objSystemSetup As frmSystemSetup
    Public objDeptXFerRptSetup As frmDeptXFerRptSetup
    Public objDeptXFerRptPreview As frmDeptXFerRptPreview
    Public objEditUsers As frmEditUsers
    Public objInventorySetup As frmInventorySetup
    Public objCamperCheckoutSetup As frmCamperCheckoutSetup
    Public objCamperCheckOutPreview As frmCamperCheckOutPreview
    Public objPrintLablesPreview As frmItemLablePreview
    Public objCraftSheetBlankPreview As frmCraftSheetBlankPreview
    Public objfrmCraftBalanceRptPreview As frmCraftBalanceRptPreview
    Public objSummary As frmSummaryReportPreview
    Public objStaffAccountsPreview As frmStaffAccountsPreview
    Public objCrCardDetailsPreview As frmCrCardDetailsPreview
    Public objInvRptPreview As frmInvRptPreview
    Public objResidentStaff As frmResidentStaff
    Public objCraftSales As frmCraftSales
    Public objInvRptSetup As frmInvRptSetup
    Public objMonthlyInvPreview As frmMonthlyInvPreview
    Public objMonthInvSetup As frmMonthlyInvSetup
    Public objDetSalesRptSetup As frmDetailedSalesSetup
    Public objDetSalesRptPreview As frmDetSalesRptPreview
    Public objAdjSummarySetup As frmAdjSummarySetup
    Public objAdjSummaryPreview As frmAdjSummaryPreview
    Public objInvSnapshotSetup As frmInvSnapshotSetup
    Public objInvSnapshotPreview As frmInvSnapshotPreview
    Public objInvLblsPreview As frmInvLblsPreview
    Public objInvCodeSheetSetup As frmInvCodeSheetSetup
    Public objInvCodeSheetPreview As frmInvCodeSheetPreview
    Public objStoreSummaryPreview As frmStoreSummaryPreview
    Public objStoreSummaryByDateSetup As frmStoreSummaryByDateSetup
    Public objCCSalesSetup As frmCCSalesSetup
    Public objCCSalesPreview As frmCCSalesPreview

    Public blnUseSQLServer As Boolean

    Public strPOSConn As String = ""
    Public strCTConn As String = ""

    Public strItemCode As String

    Public strPOSMDB As String
    Public lngCraftID As Long
    Public lngStoreID As Long
    Public lngClerkID As Long
    Public strPassword As String
    Public lngWSID As Long
    Public lngRegId As Long
    Public bnlIsAdmin As Boolean
    Public dblTaxRate As Double = 0

    Public blnSaleOpen As Boolean = False
    Public blnCamperSort As Boolean = True 'sort by last name =true

    'drawer stuff
    Public blnUseDrawer As Boolean
    Public blnUsePrinter As Boolean
    Public blnUseBell As Boolean
    Public strDrawerPort As String

    Public WithEvents RDP As New RawDataPrinter.Printer

    Public strRegKey As String = "Software\VB and VBA Program Settings\CampTrak\POSDefaults"

    'Receipt variables and constants
    Public blnOneCCReceipt As Boolean
    Public strRcptPrinter As String
    Public strFooter1 As String
    Public strFooter2 As String
    Public strHeader As String
    Public intLinesBefore As Integer
    Public intLinesAfter As Integer
    Public dblCashIn As Double
    Public dblChange As Double


    Public rcptInit As String = Chr(&H1B) & "@" & Chr(1)
    'Public rcptNewLine As String = Chr(&H1B) & "d" & Chr(1)
    Public rcptNewLine As String = Chr(13) & Chr(10)
    Public rcptLeftJustify As String = Chr(&H1B) & "a" & Chr(0)
    Public rcptCenterJustify As String = Chr(&H1B) & "a" & Chr(1)
    Public rcptRightJustify As String = Chr(&H1B) & "a" & Chr(2)
    Public rcptReverseOn As String = Chr(&H1B) & "b" & Chr(1)
    Public rcptReverseOff As String = Chr(&H1B) & "b" & Chr(0)
    Public rcptLargeFont As String = Chr(&H1B) & "!" & Chr(17)
    Public rcptRegularFont As String = Chr(&H1B) & "!" & Chr(1)
    Public rcptFeedandCut As String = Chr(&H1D) & "V" & Chr(66) & Chr(0)
    Public rcptKickDrawer As String = Chr(&H1B) & Chr(&H70) & Chr(&H0) & Chr(60) & Chr(120)

    Public Sub subPrintErr(ByVal ErrorNumber As Integer, ByVal ErrorDescription As String) Handles RDP.Error
        Stop
    End Sub

    Public Sub Main()

        Try
            'Dim objDev As New frmDevStartup
            'Application.Run(objDev)

            'import settings on first run
            If (ApplicationDeployment.IsNetworkDeployed) And My.Settings.blnUpdateSettings Then

                If fcnImportSettings() Then

                    MessageBox.Show("Settings were imported." & vbNewLine & vbNewLine & "Please re-start the CampTrak Store to apply the settings.")

                    Exit Sub

                End If

                My.Settings.blnUpdateSettings = False

            End If

            subCreateShortcut()

            Xceed.DockingWindows.Licenser.LicenseKey = "DWN10-DF7YB-F7UBP-1ABA"
            Xceed.Grid.Licenser.LicenseKey = "GRD25-G17KB-F7BMP-U4JA"
            Xceed.Editors.Licenser.LicenseKey = "EDN10-PF7YB-E7BUD-1AAA"
            Xceed.SmartUI.Licenser.LicenseKey = "SUN33-LF7DB-1WBBP-34CA"

            If Not fcnSetWSVars() Then
                MsgBox("This appears to be the first time you have run this program, please fill in the following setup screens.")
                Dim frmSetup As New frmSystemSetup
                Application.Run(frmSetup)

            End If

            RDP.Key = "8DFDE8FE16077599D9FB53672526F99846559CDD6102F9D41779DABFCA8D61135766659B8A7974DD027F050"
            RDP.SetPrinter(strRcptPrinter)


            Dim blnMainGood As Boolean
            Dim blnPOSGood As Boolean
            blnMainGood = fcnRelink("ctmain_b.mdb", strRegKey, "MainPath", strCTConn)

            If blnUseSQLServer Then
                blnPOSGood = fcnBuildSQLConnect(strRegKey, strPOSConn)
            Else
                blnPOSGood = fcnRelink("ctpos_b.mdb", strRegKey, "POSPath", strPOSConn)
            End If

            If Not blnMainGood Or Not blnPOSGood Then

                Dim strMsg As String

                strMsg = "Please use the settings screen to set the location of the CampTrak and Store data files." & vbNewLine & _
                        "You may also set additional store options like cash drawer and barcode scanner settings." & vbNewLine & _
                        vbNewLine & _
                        "Alternatively, you may select a previously saved settings file (named POSUserSettings.xml by default) and import it from the 'Settings' tab."

                MessageBox.Show(strMsg)

                Dim frmSetup As New frmSystemSetup
                Application.Run(frmSetup)

                strMsg = "Please restart the CampTrak store to apply the new settings."

                MessageBox.Show(strMsg)

                Exit Sub

            End If

            objLogin = New frmLogin

            subStructureMgmt()

            Application.Run(objLogin)

        Catch ex As Exception
            MessageBox.Show("Application Error: " & ex.Message)
            '            subLogErr("Main Function", ex)
        End Try
    End Sub

    Private Sub subCreateShortcut()
        'create desktop shortcut if needed.

        Try

            Dim ad As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

                Dim code As Assembly = Assembly.GetEntryAssembly()

            Dim company As String = ""
            Dim description As String = ""

            If System.Attribute.IsDefined(code, GetType(AssemblyCompanyAttribute)) Then

                Dim ascompany As System.Reflection.AssemblyCompanyAttribute = CType(Attribute.GetCustomAttribute(code, GetType(System.Reflection.AssemblyCompanyAttribute)), System.Reflection.AssemblyCompanyAttribute)

                company = ascompany.Company

            End If

            If (Attribute.IsDefined(code, GetType(AssemblyDescriptionAttribute))) Then

                Dim asdescription As AssemblyDescriptionAttribute = CType(Attribute.GetCustomAttribute(code, GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute)

                description = asdescription.Description

            End If

            If company <> "" And description <> "" Then

                Dim desktopPath As String = ""

                desktopPath = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\", description, ".appref-ms")

                Dim shortcutName As String = ""

                shortcutName = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\", company, "\", description, ".appref-ms")

                System.IO.File.Copy(shortcutName, desktopPath, True)

            End If

        Catch ex As Exception
        End Try

    End Sub

    Public Sub subStructureMgmt()

        Dim strSQL As String

        Dim blnAddFld As Boolean = False

        Dim strErr As String = ""

        Try
            Using conPOS = New OleDbConnection(strPOSConn)

                conPOS.open()

                strSQL = "ALTER TABLE dbo.tblClerks ADD blnActive bit NOT NULL CONSTRAINT DF_tblClerks_blnActive DEFAULT -1;"

                Using cmdPOS = New OleDbCommand(strSQL, conPOS)

                    Try

                        cmdPOS.ExecuteNonQuery()

                        strSQL = "UPDATE tblClerks SET blnActive=1;"

                        cmdPOS.CommandText = strSQL
                        cmdPOS.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try

                    If Not fcnAddField(cmdPOS, "tblSales", "strPNRef", "VARCHAR(50)", "", strErr) Then MessageBox.Show("There was an error adding tblSales.strPNRef:" & vbNewLine & strErr)
                    If Not fcnAddField(cmdPOS, "tblSales", "strXCTransID", "VARCHAR(50)", "", strErr) Then MessageBox.Show("There was an error adding tblSales.strXCTransID:" & vbNewLine & strErr)
                    If Not fcnAddField(cmdPOS, "tblSales", "strXCAuthCode", "VARCHAR(50)", "", strErr) Then MessageBox.Show("There was an error adding tblSales.strXCAuthCode:" & vbNewLine & strErr)

                End Using

                conPOS.close()

            End Using

            Using conCT = New OleDbConnection(strCTConn)

                conCT.Open()

                strSQL = "SELECT lngSaleID " & _
                        "FROM tblTransactions;"

                Using cmdCT As OleDbCommand = New OleDbCommand(strSQL, conCT)

                    Try
                        cmdCT.ExecuteNonQuery()
                    Catch

                        strSQL = "ALTER TABLE tblTransactions " & _
                                "ADD COLUMN lngSaleID LONG"

                        cmdCT.CommandText = strSQL

                        cmdCT.ExecuteNonQuery()

                    End Try

                    'tblCampDefaults.
                    blnAddFld = False

                    strSQL = "SELECT intSpendingRefDur " & _
                            "FROM tblCampDefaults;"

                    cmdCT.CommandText = strSQL

                    Try
                        cmdCT.ExecuteNonQuery()
                    Catch ex As Exception
                        blnAddFld = True
                    End Try

                    If blnAddFld Then

                        strSQL = "ALTER TABLE tblCampDefaults " & _
                                "ADD COLUMN intSpendingRefDur INTEGER"

                        cmdCT.CommandText = strSQL

                        cmdCT.ExecuteNonQuery()

                    End If

                    'tblUnmatchedPOSTrans
                    blnAddFld = False

                    strSQL = "SELECT lngTransactionID " & _
                            "FROM tblUnmatchedPOSTrans;"

                    cmdCT.CommandText = strSQL

                    Try
                        cmdCT.ExecuteNonQuery()
                    Catch ex As Exception
                        blnAddFld = True
                    End Try

                    If blnAddFld Then

                        strSQL = "CREATE TABLE tblUnmatchedPOSTrans " & _
                                "(lngTransactionID LONG)"

                        cmdCT.CommandText = strSQL
                        cmdCT.Parameters.Clear()

                        cmdCT.ExecuteNonQuery()

                    End If

                    subManageTlkpTransType(cmdCT)

                End Using

                conCT.Close()

            End Using

        Catch ex As Exception
            subLogErr("basMain.subStructureMgmt", ex)

        End Try

    End Sub

    Private Function fcnAddField(ByVal _cmdDB As OleDbCommand, ByVal _strTbl As String, ByVal _strField As String, ByVal _strDataType As String, ByVal _strDefault As String, ByRef _strErr As String) As Boolean

        Dim strSQL As String = ""

        Dim blnRes As Boolean = False
        Dim blnAddFields As Boolean = False

        Try
            strSQL = "SELECT " & _strField + " " & _
                    "FROM " & _strTbl

            _cmdDB.CommandText = strSQL

            Try
                _cmdDB.ExecuteNonQuery()
            Catch ex As Exception
                blnAddFields = True
            End Try

            If blnAddFields Then

                Dim strDefault As String = ""

                If _strDefault <> "" Then strDefault = " DEFAULT " & _strDefault

                If _cmdDB.Connection.ConnectionString.Contains("sqloledb") Then
                    strSQL = "ALTER TABLE " & _strTbl & " " & _
                            "ADD " & _strField & " " & _strDataType & strDefault
                Else
                    strSQL = "ALTER TABLE " & _strTbl & " " & _
                            "ADD COLUMN " & _strField & " " & _strDataType & strDefault
                End If

                _cmdDB.CommandText = strSQL

                _cmdDB.ExecuteNonQuery()

            End If

                blnRes = True

        Catch ex As Exception

            blnRes = False
            _strErr = ex.Message

        End Try

        Return blnRes

    End Function

    Private Sub subManageTlkpTransType(ByVal _cmdCT As OleDbCommand)

        'tlkpTransType
        Dim blnAddFields As Boolean = False

        Dim strSQL As String = "SELECT lngTransTypeID " & _
                                "FROM tlkpTransType"

        _cmdCT.CommandText = strSQL
        _cmdCT.Parameters.Clear()

        Try
            _cmdCT.ExecuteNonQuery()
        Catch ex As Exception
            blnAddFields = True
        End Try


        If blnAddFields Then


            strSQL = "CREATE TABLE tlkpTransType " & _
                         "( lngTransTypeID COUNTER CONSTRAINT PK_lngTransTypeID PRIMARY KEY, " & _
                                "blnAccountingEffect YESNO NULL, blnDebitCredit YESNO NULL, blnSpending YESNO NULL, blnAutoOnly YESNO NULL, blnGGType YESNO NULL, blnGiftType YESNO NULL, blnCashEffect YESNO NULL, blnAccrEffect YESNO NULL, blnLockEffects YESNO NULL, blnMoneyTrans YESNO NULL, blnScholarship YESNO NULL, " & _
                                "strTransType TEXT(50) NULL, strOldTranType TEXT(50) NULL, strNewTranType TEXT(50) NULL, strCashExplanation TEXT(255) NULL, strCashQuestions TEXT(255) NULL, strCashDate TEXT(10) NULL, strCashDebit TEXT(35) NULL, strCashCredit TEXT(35) NULL, strAccrExplanation TEXT(255) NULL, strAccrQuestions TEXT(255) NULL, strAccrDate1 TEXT(10) NULL, strAccrDebit1 TEXT(35) NULL, strAccrCredit1 TEXT(35) NULL, strAccrDate2 TEXT(10) NULL, strAccrDebit2 TEXT(35) NULL, strAccrCredit2 TEXT(35) NULL )"

            _cmdCT.CommandText = strSQL
            _cmdCT.ExecuteNonQuery()

            'add records
            subAppendTlkpTransTypeRecord(_cmdCT, 1, -1, -1, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Registration Payment", "Payment for Tuition", "Registration Payment", "Prepayment for registration fees", "", "Trans", "PaymentMethod", "ProgramRevenue", "Prepayment for registration fees", "", "Trans", "PaymentMethod", "ProgramUnearned", "EventEnd", "ProgramUnearned", "ProgramReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 2, -1, 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Registration Fee", "Tuition", "Registration Fee", "Registration fees chargd automatically to registrants", "", "", "", "", "Registration fees charged automatically to registrants", "", "EventEnd", "ProgramReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 3, 0, -1, 0, 0, 0, 0, 0, -1, 0, -1, 0, "Cancellation Credit", "Cancelation", "Cancellation Credit", "Credits for the refundable fees when a registrant cancels", "Are these credits applied automatically when registration is cancelled?", "Trans", "ProgramRevenue", "ProgramReceivables", "???", "Are these credits applied automatically when registration is cancelled?", "Trans", "ProgramUnearned", "ProgramReceivables", "EventEnd", "ProgramRevenue", "ProgramUnearned")
            subAppendTlkpTransTypeRecord(_cmdCT, 4, -1, 0, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Payment Refund", "Refund", "Payment Refund", "Cash refunds made to registrants", "Revenue effect must be made separately by discount, cancellation, etc.", "Trans", "ProgramRevenue", "PaymentMethod", "Cash refunds made to registrants", "", "Trans", "ProgramUnearned", "PaymentMethod", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 5, -1, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, "Craft House Charge", "Craft House", "Craft House Charge", "Craft House fees charged manually to registrants", "", "", "", "", "Craft House fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramActivityRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 6, 0, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, "Camp Store Charge", "CampTrak General Store", "Camp Store Charge", "", "Where is this used automatically?", "", "", "", "", "Where is this used automatically?", "", "", "", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 7, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, -1, "Scholarship", "Scholarship", "Scholarship", "Credits for internal camperships", "Better handling and tracking as split pay credit!", "Trans", "ScholarshipExpense", "ProgramRevenue", "Credits for internal camperships", "Better handling and tracking as split pay credit!", "EventEnd", "ScholarshipExpense", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 8, -1, -1, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Registration Deposit", "Deposit", "Registration Deposit", "Prepayment for registration fees", "", "Trans", "PaymentMethod", "ProgramRevenue", "Prepayment for registration fees", "", "Trans", "PaymentMethod", "ProgramUnearned", "EventEnd", "ProgramUnearned", "ProgramReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 9, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, -1, "Scholarship- Grant", "Grant", "Scholarship- Grant", "Credits for camper grants", "Better handling and tracking as split pay credit!", "Trans", "ScholarshipExpense", "ProgramRevenue", "Credits for camper grants", "Better handling and tracking as split pay credit!", "EventEnd", "ScholarshipExpense", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 10, -1, -1, 0, 0, 0, 0, 0, -1, 0, 0, 0, "Accounts Receivable Credit", "Accounts Receivable Credit", "Accounts Receivable Credit", "Is this a writeoff?", "How is this different from Payment on Accounts Receivable?", "Trans", "ProgramReceivables", "ProgramRevenue", "Payment on Accounts Receivable Balance", "How is this different from Payment on Accounts Receivable?", "EventEnd", "ProgramRevenue", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 11, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Other Credit", "Other Credit", "Non Accounting Credit", "", "", "", "", "", "", "", "", "", "", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 12, -1, -1, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Payment for Weekend Camper Fee", "Payment for Weekend Camper Fee", "Payment for Weekend Camper Fee", "Prepayment for weekend fees", "", "Trans", "PaymentMethod", "ProgramRevenue", "Prepayment for weekend fees", "", "Trans", "PaymentMethod", "ProgramUnearned", "EventEnd", "ProgramUnearned", "ProgramReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 13, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, "Weekend Camper Fee", "Weekend Camper Fee", "Weekend Camper Fee", "Weekend fees charged manually to registrants", "", "", "", "", "Weekend fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 14, -1, -1, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Payment for Miscellaneous Charges", "Payment for Misc. Charges", "Payment for Miscellaneous Charges", "Prepayment for miscellaneous registration charges", "", "Trans", "PaymentMethod", "ProgramMiscellaneous", "Prepayment for miscellaneous registration charges", "", "Trans", "PaymentMethod", "ProgramUnearned", "EventEnd", "ProgramUnearned", "ProgramReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 15, -1, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Miscellaneous Charge", "Misc. Charges", "Miscellaneous Charge", "Miscellaneous fees charged manually to registrants", "", "Trans", "ProgramReceivables", "ProgramMiscellaneous", "Miscellaneous fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramMiscellaneous", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 16, -1, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Cancellation Fee", "Cancellation Charge", "Cancellation Fee", "Cancellation fees charged manually to registrants", "", "Trans", "ProgramReceivables", "ProgramMiscellaneous", "Cancellation fees charged manually to registrants", "", "Trans", "ProgramReceivables", "ProgramMiscellaneous", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 17, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, "Spending Money Charge", "Spending Money Charge", "Spending Money Charge", "", "What happens if users enters store purchases?", "", "", "", "", "What happens if users enters store purchases?", "Trans", "ProgramReceivables", "StoreRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 18, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, "Activity Fee 2", "Both Activities", "Activity 2 Fee", "Activity fees charged manually to registrants", "", "", "", "", "Activity fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramActivityRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 19, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, -1, "Scholarship- FIA", "FIA Scholarship", "Scholarship- FIA", "Credits for FIA camperships", "Better handling and tracking as split pay credit!", "Trans", "ScholarshipExpense", "ProgramRevenue", "Credits for FIA camperships", "Better handling and tracking as split pay credit!", "EventEnd", "ScholarshipExpense", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 20, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, -1, "Scholarship- Church", "Church Scholarship", "Scholarship- Church", "Credits for church camperships", "Better handling and tracking as split pay credit!", "Trans", "ScholarshipExpense", "ProgramRevenue", "Credits for church camperships", "Better handling and tracking as split pay credit!", "EventEnd", "ScholarshipExpense", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Other Charge", "Other Debit", "Non Accounting Charge", "", "", "", "", "", "", "", "", "", "", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 22, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Staff 2", "Staff Discount", "Discount- Staff 2", "Discounts for staff applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for staff applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 24, -1, 0, -1, 0, 0, 0, -1, -1, 0, -1, 0, "Spending Money Refund", "Spending Money Refund", "Spending Money Refund", "Cash refunds of spending money", "", "Trans", "StoreRevenue", "PaymentMethod", "Cash refunds of spending money", "", "Trans", "StoreUnearned", "PaymentMethod", "EventEnd", "StoreRevenue", "StoreUnearned")
            subAppendTlkpTransTypeRecord(_cmdCT, 25, -1, -1, -1, 0, 0, 0, -1, -1, 0, -1, 0, "Spending Money: Initial Prepaid", "Spending Money Initial", "Initial Prepaid Spending Money", "Prepayment of spending money", "", "Trans", "PaymentMethod", "StoreRevenue", "Prepayment of spending money", "", "Trans", "PaymentMethod", "StoreUnearned", "EventEnd", "StoreUnearned", "StoreRevenue")
            subAppendTlkpTransTypeRecord(_cmdCT, 26, -1, 0, -1, 0, 0, 0, -1, -1, 0, -1, 0, "Spending Money Withdrawal", "Spending Money Withdrawal", "Spending Money Withdrawal", "Cash withdrawls of spending money", "", "Trans", "StoreRevenue", "PaymentMethod", "Cash withdrawls of spending money", "", "Trans", "StoreUnearned", "PaymentMethod", "EventEnd", "StoreRevenue", "StoreUnearned")
            subAppendTlkpTransTypeRecord(_cmdCT, 27, -1, -1, -1, 0, 0, 0, -1, -1, 0, -1, 0, "Spending Money: Additional Prepaid", "Spending Money Additional", "Additional Prepaid Spending Money", "Prepayment of spending money", "", "Trans", "PaymentMethod", "StoreRevenue", "Prepayment of spending money", "", "Trans", "PaymentMethod", "StoreUnearned", "EventEnd", "StoreUnearned", "StoreRevenue")
            subAppendTlkpTransTypeRecord(_cmdCT, 33, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Sibling", "Sibling Discount", "Discount- Sibling", "Discounts for siblings applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for siblings applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 34, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Camper Exchange Credit", "Camper Exchange Program", "Camper Exchange Credit", "Credits applied to registrant in exchange for tuition at another camp", "Better handling and tracking as split pay credit!", "Trans", "CamperExchangeClearing", "ProgramRevenue", "Credits applied to registrant in exchange for tuition at another camp", "Better handling and tracking as split pay credit!", "Trans", "CamperExchangeClearing", "ProgramUnearned", "EventEnd", "ProgramUnearned", "ProgramReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 35, -1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, "Photo Fee", "Photo", "Photo Fee", "Photo fees charged manually to registrants", "", "", "", "", "Photo fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramActivityRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 36, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Early Registration", "Discount - Early Reg.", "Discount- Early Registration", "Discounts for early registration applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for early registration applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 37, -1, 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Activity Fee", "Activity Charge", "Activity 1 Fee", "Activity fees charged automatically to registrants", "", "", "", "", "Activity fees charged automatically to registrants", "", "EventEnd", "ProgramReceivables", "ProgramActivityRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 38, -1, 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Registration Hold Charge", "Split Pay Amt", "Registration Hold Charge", "Charge to third party for a registration", "What is the reference info?", "", "", "", "Automatic charge to third party when using a registration hold", "", "EventEnd", "ProgramReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 39, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, 0, "Registration Hold Credit", "Split Pay Credit", "Registration Hold Credit", "Credits applied to registrants when third parties assume responsibility for payment", "What is the reference info?  Isn't this a manual trans?", "Trans", "ProgramReceivables", "ProgramRevenue", "Credits applied automatically to registrations using a hold on a block", "", "EventEnd", "ProgramRevenue", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 40, -1, 0, 0, -1, -1, 0, -1, -1, 0, 0, 0, "Group Fees Charge", "Guest Group Tuition", "Group Fees Charge", "Guest type fees charged automatically to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "Guest type fees charged automatically to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 41, -1, -1, 0, 0, -1, 0, -1, -1, 0, -1, 0, "Group Payment", "Guest Group Payment", "Group Payment", "Payments made by group sponsors after their event", "", "Trans", "PaymentMethod", "RentalReceivables", "Payments made by group sponsors after their event", "", "Trans", "PaymentMethod", "RentalReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 42, -1, -1, 0, 0, -1, 0, -1, -1, 0, -1, 0, "Group Deposit", "Guest Group Deposit", "Group Deposit", "Prepayments made by group sponsors before their event", "", "Trans", "PaymentMethod", "RentalReceivables", "Prepayments made by group sponsors before their event", "", "Trans", "PaymentMethod", "RentalUnearned", "EventEnd", "RentalUnearned", "RentalReceivables")
            subAppendTlkpTransTypeRecord(_cmdCT, 43, -1, 0, 0, -1, -1, 0, -1, -1, 0, 0, 0, "Group Activity Charge", "Guest Group Activity", "Group Activity Charge", "Activity and activity package fees charged automatically to group event sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "Activity and activity package fees charged automatically to group event sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 44, -1, -1, 0, 0, -1, 0, -1, -1, 0, 0, 0, "Group Discount", "Discount - Guest Type", "Group Discount", "Discounts applied to group charges", "", "EventEnd", "RentalDiscounts", "RentalReceivables", "Discounts applied to group charges", "", "EventEnd", "RentalDiscounts", "RentalReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 45, -1, 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Activity Package Fee", "Unlimited Activity Package", "Activity Package Fee", "Activity package fees charged automatically to registrants", "", "", "", "", "Activity package fees charged automatically to registrants", "", "EventEnd", "ProgramReceivables", "ProgramActivityRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 46, -1, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, "Group Rental Housing Charge", "Guest Group Housing", "Group Rental Housing Charge", "Housing fees charged automatically to group sponsors", "Why 2 automatic transactions?", "EventEnd", "RentalReceivables", "ProgramRevenue", "Housing fees charged automatically to group rental sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 47, -1, 0, 0, -1, -1, 0, -1, -1, 0, 0, 0, "Group Resource Charge", "Resource Charge", "Group Resource Charge", "Resource fees charged automatically to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "Resource fees charged automatically to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 48, -1, 0, 0, -1, -1, 0, -1, -1, 0, 0, 0, "Group Event Housing Charge", "Housing Charge", "Group Event Housing Charge", "Housing fees charged automatically to group sponsors", "Why 2 automatic transactions?", "EventEnd", "RentalReceivables", "ProgramRevenue", "Housing fees charged automatically to group registrations", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 49, -1, 0, 0, -1, -1, 0, 0, -1, 0, 0, 0, "Group Registration Fee", "Event Registration Tuition", "Group Registration Fee", "", "Where is this used automatically?", "", "", "", "Fees charged automatically to group event registrations based on guest type", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 50, -1, 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Accounts Receivable Charge", "Accounts Receivable Charge", "Accounts Receivable Charge", "All fees are charged to A/R at EventEnd by accrual conventions", "Is this where the automatic 'move block balances to A/R' goes?", "Trans", "ProgramReceivables", "PaymentMethod", "Miscellaneous Program Charge", "Is this where the automatic 'move block balances to A/R' goes?", "EventEnd", "ProgramReceivables", "ProgramRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 53, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Write-Off", "Write-Off", "Write-Off", "Writeoff of Accounts Receivable", "", "Trans", "ProgramDiscounts", "ProgramRevenue", "Writeoff of Accounts Receivable", "", "Trans", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 54, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, 0, "Discount- Constituent", "Discount - Const. Church", "Discount- Constituent", "Discounts applied automatically to registrants that are members of constituent congregations", "", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts applied automatically to registrants that are members of constituent congregations", "", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 55, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Rebate", "Rebate", "Rebate", "Rebates applied manually to registrants", "", "Trans", "ProgramDiscounts", "ProgramRevenue", "Rebates applied manually to registrants", "", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 56, -1, 0, 0, -1, 0, -1, -1, -1, -1, 0, 0, "Gift- Cash", "Gift - Cash", "Gift- Cash", "Cash contributions made by donors", "Why isn't this auto?", "Trans", "PaymentMethod", "GiftRevenue", "Cash contributions made by donors", "", "Trans", "PaymentMethod", "GiftRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 57, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, "Gift- Non-Cash", "Gift - Non-Cash", "Gift- Non-Cash", "Needs definition by Bob", "", "", "", "", "Needs definition by Bob", "", "", "", "", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 58, -1, 0, 0, -1, 0, -1, -1, -1, -1, -1, 0, "Gift- Pledge Payment", "Gift - Pledge Payment", "Gift- Pledge Payment", "Cash contributions that satisfy a promise to give", "Why isn't this auto?", "Trans", "PaymentMethod", "PledgeReceivables", "Cash contributions that satisfy a promise to give", "", "Trans", "PaymentMethod", "PledgeReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 59, -1, 0, 0, -1, 0, -1, -1, -1, -1, -1, 0, "Gift- Matching", "Gift - Matching", "Gift- Matching", "Cash contributions made by donors accompanied by a claim for a whole or partial matching amount from an employer, fraternal or other agency", "Could be used to classify the matching gift but more useful as a way to segregate and track gifts made with a match", "Trans", "PaymentMethod", "GiftRevenue", "Cash contributions made by donors accompanied by a claim for a whole or partial matching amount from an employer, fraternal or other agency", "", "Trans", "PaymentMethod", "GiftRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 60, -1, -1, 0, 0, 0, 0, -1, -1, 0, -1, 0, "Accounts Receivable Payment", "Payment for Accounts Receivable", "Accounts Receivable Payment", "Payments on an accounts receivable balance", "", "Trans", "PaymentMethod", "ProgramReceivables", "Payments on an accounts receivable balance", "", "Trans", "PaymentMethod", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 61, -1, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, "Group Cancellation Charge", "Group Cancellation Charge", "Group Cancellation Charge", "Cancellation fees charged manually to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "Cancellation fees charged manually to group sponsors", "", "Trans", "RentalReceivables", "RentalMiscellaneous", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 62, -1, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, "Group Payment Refund", "Group Refund Charge", "Group Payment Refund", "", "Refund and charge are opposites!", "Tran", "RentalReceivables", "PaymentMethod", "Cash refunds made to groups", "", "Trans", "RentalUnearned", "PaymentMethod", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 63, -1, 0, 0, 0, -1, 0, -1, -1, 0, 0, 0, "Group Miscellaneous Charge", "Misc Group Charge", "Group Miscellaneous Charge", "Miscellaneous fees charged manually to group sponsors", "", "EventEnd", "RentalReceivables", "ProgramRevenue", "Miscellaneous fees charged manually to group sponsors", "", "EventEnd", "RentalReceivables", "RentalMiscellaneous", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 64, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, "Spending Money Complimentary", "Spending Money Complimentary", "Spending Money Complimentary", "Could reduce revenue but that should be done at CGS", "", "", "", "", "Could reduce revenue but that should be done at CGS", "", "", "", "", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 65, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Volunteer", "Discount - Volunteer", "Discount- Volunteer", "Discounts for volunteers applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for volunteers applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 66, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Staff", "Discount - Staff", "Discount- Staff 1", "Discounts for staff applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for staff applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 67, -1, 0, 0, -1, 0, -1, -1, -1, 0, 0, 0, "Pledge- Scheduled Payment", "Pledge - Scheduled Payment", "Pledge- Scheduled Payment", "Promises to give cash or other assets", "Why isn't this auto?", "Trans", "PledgeReceivables", "GiftRevenue", "Promises to give cash or other assets", "", "Trans", "PledgeReceivables", "GiftRevenue", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 68, -1, 0, 0, -1, 0, -1, -1, -1, 0, 0, 0, "Pledge- Write Off", "Pledge - Write Off", "Pledge- Write Off", "Cancellation of promises to give", "Why isn't this auto?", "Trans", "GiftRevenue", "PledgeReceivables", "Cancellation of promises to give", "", "Trans", "GiftRevenue", "PledgeReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 69, -1, -1, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Discount- Registration", "Discount - Registration", "Discount- Registration", "Discounts for other reasons applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "Trans", "ProgramDiscounts", "ProgramRevenue", "Discounts for other reasons applied manually to registrants", "Which trantype is used for each of the new 10 registration discounts?", "EventEnd", "ProgramDiscounts", "ProgramReceivables", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 70, -1, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, "Late Fee", "Late Fee", "Late Fee", "Late fees charged manually to registrants", "", "Trans", "ProgramReceivables", "ProgramMiscellaneous", "Late fees charged manually to registrants", "", "EventEnd", "ProgramReceivables", "ProgramMiscellaneous", "", "", "")
            subAppendTlkpTransTypeRecord(_cmdCT, 71, -1, -1, 0, -1, 0, 0, 0, -1, 0, 0, 0, "Cancellation of Registration", "Cancellation of Registration", "Cancellation of Registration", "", "", "", "", "", "", "", "EventEnd", "ProgramRevenue", "ProgramReceivables", "EventEnd", "ProgramReceivables", "ProgramUnearned")
        End If

    End Sub

    Private Sub subAppendTlkpTransTypeRecord(ByVal _cmdDB As OleDbCommand, ByVal lngTransTypeID As Long, ByVal blnAccountingEffect As Int32, ByVal blnDebitCredit As Int32, ByVal blnSpending As Int32, ByVal blnAutoOnly As Int32, ByVal blnGGType As Int32, ByVal blnGiftType As Int32, ByVal blnCashEffect As Int32, ByVal blnAccrEffect As Int32, ByVal blnLockEffects As Int32, ByVal blnMoneyTrans As Int32, ByVal blnScholarship As Int32, ByVal strTransType As String, ByVal strOldTranType As String, ByVal strNewTranType As String, ByVal strCashExplanation As String, ByVal strCashQuestions As String, ByVal strCashDate As String, ByVal strCashDebit As String, ByVal strCashCredit As String, ByVal strAccrExplanation As String, ByVal strAccrQuestions As String, ByVal strAccrDate1 As String, ByVal strAccrDebit1 As String, ByVal strAccrCredit1 As String, ByVal strAccrDate2 As String, ByVal strAccrDebit2 As String, ByVal strAccrCredit2 As String)

        Dim strSQL As String = "INSERT INTO tlkpTransType " & _
                            "( lngTransTypeID, " & _
                                "blnAccountingEffect, blnDebitCredit, blnSpending, blnAutoOnly, blnGGType, blnGiftType, blnCashEffect, blnAccrEffect, blnLockEffects, blnMoneyTrans, blnScholarship, " & _
                                "strTransType, strOldTranType, strNewTranType, strCashExplanation, strCashQuestions, strCashDate, strCashDebit, strCashCredit, strAccrExplanation, strAccrQuestions, strAccrDate1, strAccrDebit1, strAccrCredit1, strAccrDate2, strAccrDebit2, strAccrCredit2 ) " & _
                            "VALUES " & _
                            "( " & lngTransTypeID.ToString() & ", " & _
                                blnAccountingEffect & ", " & blnDebitCredit & ", " & blnSpending & ", " & blnAutoOnly & ", " & blnGGType & ", " & blnGiftType & ", " & blnCashEffect & ", " & blnAccrEffect & ", " & blnLockEffects & ", " & blnMoneyTrans & ", " & blnScholarship & ", " & _
                                """" & strTransType & """, """ & strOldTranType & """, """ & strNewTranType & """, """ & strCashExplanation & """, """ & strCashQuestions & """, """ & strCashDate & """, """ & strCashDebit & """, """ & strCashCredit & """, """ & strAccrExplanation & """, """ & strAccrQuestions & """, """ & strAccrDate1 & """, """ & strAccrDebit1 & """, """ & strAccrCredit1 & """, """ & strAccrDate2 & """, """ & strAccrDebit2 & """, """ & strAccrCredit2 & """)"

        _cmdDB.CommandText = strSQL
        _cmdDB.Parameters.Clear()
        _cmdDB.ExecuteNonQuery()

    End Sub

    Public Function fcnSetWSVars() As Boolean

        Try
            strDrawerPort = My.Settings.strDrawerPort
            blnUseDrawer = My.Settings.blnUseDrawer
            blnUsePrinter = My.Settings.blnUsePrinter
            blnUseBell = My.Settings.blnUseBell
            dblTaxRate = My.Settings.dblTaxRate
            lngStoreID = My.Settings.lngStoreID
            lngWSID = My.Settings.lngWSID
            lngCraftID = CType(My.Settings.strCraftID, Long)
            blnOneCCReceipt = My.Settings.blnOneCCReceipt
            strRcptPrinter = My.Settings.RcptPrinter
            strFooter1 = My.Settings.RcptFooter1
            strFooter2 = My.Settings.RcptFooter2
            strHeader = My.Settings.RcptHeader
            intLinesBefore = My.Settings.intLinesBefore
            intLinesAfter = My.Settings.intLinesAfter

            blnUseSQLServer = My.Settings.UseSQLServer
            blnCamperSort = My.Settings.blnCamperSort

            If My.Settings.FirstSetup = False Then
                fcnSetWSVars = False
                My.Settings.FirstSetup = True
                My.Settings.Save()
            Else
                fcnSetWSVars = True
            End If


        Catch ex As Exception

            subLogErr("subSetWSVars", ex)
            fcnSetWSVars = False

        End Try

    End Function

    Public Sub subShowSwitchboard()

        Try
            If objSwitchboard.IsDisposed() Then objSwitchboard = Nothing
        Catch ex As Exception
        End Try

        Try
            If objSwitchboard Is Nothing Then objSwitchboard = New frmSwitchboard

            objSwitchboard.Show()

        Catch ex As Exception

            subLogErr("subShowSwitchboard", ex)

        End Try

    End Sub

    Public Sub subCloseSwitchboard()

        Try
            If Not IsNothing(objSwitchboard) Then
                objSwitchboard.Hide()
                objSwitchboard.Close()
                objSwitchboard.Dispose()
                objSwitchboard = Nothing
            End If

        Catch ex As Exception

            subLogErr("subCloseSwitchboard", ex)

        End Try

    End Sub

    Public Sub subShowCashSales(ByVal mdi As Form)

        Try

            Try
                If objCashSales.IsDisposed() Then objCashSales = Nothing
            Catch ex As Exception

            End Try

            If IsNothing(objCashSales) Then objCashSales = New frmCashSales

            'Set the Parent Form of the Child window.
            objCashSales.MdiParent = mdi
            'Display the new form.
            objCashSales.KeyPreview = True
            objCashSales.Dock = DockStyle.Fill
            objCashSales.Show()

        Catch ex As Exception

            subLogErr("subShowCashSales", ex)

        End Try

    End Sub

    Public Sub subShowResidentStaff(ByVal mdi As Form)

        Try

            Try
                If objResidentStaff.IsDisposed() Then objResidentStaff = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objResidentStaff) Then objResidentStaff = New frmResidentStaff

            'Set the Parent Form of the Child window.
            objResidentStaff.MdiParent = mdi

            'Display the new form.
            objResidentStaff.Show()

        Catch ex As Exception
            subLogErr("subShowResidentStaff", ex)

        End Try

    End Sub

    Public Sub subShowCraftSales(ByVal mdi As Form)

        Try

            Try
                If objSwitchboard.IsDisposed() Then objSwitchboard = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objCraftSales) Then
                objCraftSales = New frmCraftSales
            ElseIf objCraftSales.IsDisposed Then
                objCraftSales = Nothing
                objCraftSales = New frmCraftSales
            End If

            'Set the Parent Form of the Child window.
            objCraftSales.MdiParent = mdi

            'Display the new form.
            objCraftSales.Show()

        Catch ex As Exception
            subLogErr("subShowCraftSales", ex)

        End Try

    End Sub

    Public Sub subShowInvRptSetup(ByVal mdi As Form)

        If Not bnlIsAdmin Then
            MessageBox.Show("No access")
            Exit Sub
        End If

        Try

            If IsNothing(objInvRptSetup) Then
                objInvRptSetup = New frmInvRptSetup
            ElseIf objInvRptSetup.IsDisposed Then
                objInvRptSetup = Nothing
                objInvRptSetup = New frmInvRptSetup
            End If

            'Set the Parent Form of the Child window.
            objInvRptSetup.MdiParent = mdi

            'Display the new form.
            objInvRptSetup.Show()

        Catch ex As Exception
            subLogErr("subShowInvRptSetup", ex)

        End Try

    End Sub

    Public Sub subCloseInvRptSetup()

        Try
            If Not IsNothing(objInvRptSetup) Then
                objInvRptSetup.Close()
                objInvRptSetup.Dispose()
                objInvRptSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvRptSetup", ex)

        End Try

    End Sub

    Public Sub subShowEditUsers(ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objEditUsers) Then
                    objEditUsers = New frmEditUsers
                Else

                    If objEditUsers.IsDisposed Then
                        objEditUsers = Nothing
                        objEditUsers = New frmEditUsers
                    End If

                End If

                objEditUsers.MdiParent = mdi
                objEditUsers.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to modify users.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowEditUsers", ex)
        End Try

    End Sub


    Public Sub subCloseEditUsers()
        Try
            If Not IsNothing(objEditUsers) Then
                objEditUsers.Close()
                objEditUsers.Dispose()
                objEditUsers = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseEditUsers", ex)

        End Try
    End Sub

    Public Sub subShowSystemSetup(ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objSystemSetup) Then
                    objSystemSetup = New frmSystemSetup
                Else

                    If objSystemSetup.IsDisposed Then
                        objSystemSetup = Nothing
                        objSystemSetup = New frmSystemSetup
                    Else
                        objSystemSetup.Focus()
                    End If

                End If

                objSystemSetup.MdiParent = mdi
                objSystemSetup.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to modify system setup.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowSystemSetup", ex)
        End Try

    End Sub

    Public Sub subCloseSystemSetup()
        Try
            If Not IsNothing(objSystemSetup) Then
                objSystemSetup.Close()
                objSystemSetup.Dispose()
                objSystemSetup = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseSystemSetup", ex)

        End Try
    End Sub

    Public Sub subShowZOutSetup(ByVal mdi As Form)

        Try

            Try
                If objZOutSetup.IsDisposed() Then objZOutSetup = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objZOutSetup) Then objZOutSetup = New frmZOutSetup

            objZOutSetup.MdiParent = mdi

            objZOutSetup.Show()

        Catch ex As Exception

            subLogErr("subShowZOutSetup", ex)

        End Try

    End Sub

    Public Sub subShowZOutPreview(ByVal _lngStoreID As Long, ByVal _lngWSID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strTitle As String, ByVal mdi As Form)
        Dim intI As Integer
        intI = 0

        Try
            If objZOutPreview.IsDisposed() Then objZOutPreview = Nothing
        Catch ex As Exception
        End Try

        Try
            intI = 1
            If IsNothing(objZOutPreview) Then objZOutPreview = New frmZOutPreview(_lngStoreID, _lngWSID, _dteStart, _dteEnd, _strTitle)
            intI = 2
            objZOutPreview.MdiParent = mdi
            intI = 3
            objZOutPreview.Show()
            intI = 4
        Catch ex As Exception

            subLogErr("subShowZOutPreview (" & intI.ToString() & ")", ex)

        End Try

    End Sub

    Public Sub subShowCamperCheckOutPreview(ByVal strSort As String, ByVal mdi As Form)

        Try

            Try
                If objCamperCheckOutPreview.IsDisposed() Then objCamperCheckOutPreview = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objCamperCheckOutPreview) Then objCamperCheckOutPreview = New frmCamperCheckOutPreview(strSort)

            objCamperCheckOutPreview.MdiParent = mdi

            objCamperCheckOutPreview.Show()

        Catch ex As Exception

            subLogErr("subShowCamperCheckoutPreview", ex)

        End Try

    End Sub

    Public Sub subCloseCashSales()

        Try

            If Not IsNothing(objCashSales) Then
                objCashSales.Close()
                objCashSales.Dispose()
                objCashSales = Nothing
            End If

        Catch ex As Exception

            subLogErr("subCloseCashSales", ex)

        End Try

    End Sub

    Public Sub subCloseZOutSetup()

        Try
            If Not IsNothing(objZOutSetup) Then
                objZOutSetup.Close()
                objZOutSetup.Dispose()
                objZOutSetup = Nothing
            End If

        Catch ex As Exception

            subLogErr("subCloseZOutSetup", ex)

        End Try

    End Sub

    Public Sub subCloseZOutPreview()

        Try
            If Not IsNothing(objZOutPreview) Then
                objZOutPreview.Close()
                objZOutPreview.Dispose()
                objZOutPreview = Nothing
            End If

        Catch ex As Exception

            subLogErr("subCloseZOutPreview", ex)

        End Try

    End Sub

    Public Sub subShowLogin()

        Try

            Try
                If objLogin.IsDisposed() Then objLogin = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objLogin) Then objLogin = New frmLogin

            objLogin.Show()

        Catch ex As Exception

            subLogErr("subShowLogin", ex)

        End Try

    End Sub

    Public Sub subShowDeptXFerRptSetup(ByVal mdi As Form)

        Try

            Try
                If objDeptXFerRptSetup.IsDisposed() Then objDeptXFerRptSetup = Nothing
            Catch ex As Exception
            End Try

            If IsNothing(objDeptXFerRptSetup) Then objDeptXFerRptSetup = New frmDeptXFerRptSetup

            objDeptXFerRptSetup.MdiParent = mdi

            objDeptXFerRptSetup.Show()

        Catch ex As Exception

            subLogErr("subShowDeptXFerRptSetup", ex)

        End Try

    End Sub

    Public Sub subCloseDeptXFerRptSetup()

        Try
            If Not IsNothing(objDeptXFerRptSetup) Then
                objDeptXFerRptSetup.Close()
                objDeptXFerRptSetup.Dispose()
                objDeptXFerRptSetup = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseDeptXFerRptSetup", ex)

        End Try

    End Sub

    Public Sub subInitDeptXFerRptPreview(ByVal mdi As Form, ByVal _blnShow As Boolean)

        Try

            If IsNothing(objDeptXFerRptPreview) Then
                objDeptXFerRptPreview = New frmDeptXFerRptPreview
            Else
                If objDeptXFerRptPreview.IsDisposed Then
                    objDeptXFerRptPreview = Nothing
                    objDeptXFerRptPreview = New frmDeptXFerRptPreview
                End If
            End If

            objDeptXFerRptPreview.MdiParent = mdi

            If _blnShow Then objDeptXFerRptPreview.Show()

            objDeptXFerRptPreview.WindowState = FormWindowState.Maximized

        Catch ex As Exception

            subLogErr("subShowDeptXFerRptPreview", ex)

        End Try

    End Sub


    Public Sub subCloseDeptXFerRptPreview()

        Try
            If Not IsNothing(objDeptXFerRptPreview) Then
                objDeptXFerRptPreview.Close()
                objDeptXFerRptPreview.Dispose()
                objDeptXFerRptPreview = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseDeptXFerRptPreview", ex)

        End Try

    End Sub


    Public Function RightStr(ByVal strString As String, ByVal intLen As Integer) As String
        Try
            RightStr = strString.Substring(strString.Length - intLen)
        Catch
            RightStr = ""
        End Try
    End Function

    Public Function LeftStr(ByVal strString As String, ByVal intLen As Integer) As String
        Try
            LeftStr = strString.Substring(0, intLen)
        Catch
            LeftStr = ""
        End Try
    End Function

    Public Function fcnFillSpaces(ByVal intCount As Integer) As String
        fcnFillSpaces = ""
        Dim x As Integer
        For x = 1 To intCount
            fcnFillSpaces = fcnFillSpaces.ToString & " "
        Next
    End Function

    Public Function NZ(ByVal value As Object, Optional ByVal NullReturn As String = "") As String
        If IsDBNull(value.ToString) Or value.ToString = "" Then
            Return NullReturn
        Else
            Return value.ToString
        End If
    End Function
    Public Sub subShowInventorySetup(ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objInventorySetup) Then
                    objInventorySetup = New frmInventorySetup
                Else

                    If objInventorySetup.IsDisposed Then
                        objInventorySetup = Nothing
                        objInventorySetup = New frmInventorySetup
                    End If

                End If

                objInventorySetup.MdiParent = mdi
                objInventorySetup.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to modify inventory.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowInventorySetup", ex)
        End Try

    End Sub


    Public Sub subCloseInventorySetup()
        Try
            If Not IsNothing(objInventorySetup) Then
                objInventorySetup.Close()
                objInventorySetup.Dispose()
                objInventorySetup = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseInventorySetup", ex)

        End Try
    End Sub

    Public Sub subSetSelectedIndex(ByRef cboToSet As ComboBox, ByVal lngID As Long)

        Dim intI As Integer
        cboToSet.SelectedIndex = -1

        For intI = 0 To cboToSet.Items.Count - 1

            Dim cboVal As clsCboItem

            cboVal = CType(cboToSet.Items(intI), clsCboItem)

            If CType(cboVal.ID, Long) = lngID Then cboToSet.SelectedIndex = intI

        Next
    End Sub

    Public Function dCount(ByVal strPK As String, ByVal strTable As String, ByVal strWhere As String, ByVal strConn As String) As Integer
        Dim strSQL As String
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader
        Dim intCount As Integer

        Try

            objConn = New OleDbConnection(strConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "Select " & strPK & " from " & strTable & " WHERE " & strWhere

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                intCount = intCount + 1

            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing
            Return intCount

        Catch ex As Exception

            subLogErr("Dcount", ex)

        End Try


    End Function

    Public Sub subShowCamperCheckoutSetup(ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objCamperCheckoutSetup) Then
                    objCamperCheckoutSetup = New frmCamperCheckoutSetup
                Else

                    If objCamperCheckoutSetup.IsDisposed Then
                        objCamperCheckoutSetup = Nothing
                        objCamperCheckoutSetup = New frmCamperCheckoutSetup
                    End If

                End If

                objCamperCheckoutSetup.MdiParent = mdi
                objCamperCheckoutSetup.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowCamperCheckoutSetup", ex)
        End Try

    End Sub

    Public Sub subCloseCamperCheckoutSetup()
        Try
            If Not IsNothing(objCamperCheckoutSetup) Then
                objCamperCheckoutSetup.Close()
                objCamperCheckoutSetup.Dispose()
                objCamperCheckoutSetup = Nothing
            End If
        Catch ex As Exception

            subLogErr("subCloseCamperCheckoutSetup", ex)

        End Try
    End Sub

    Public Sub subCloseResidentStaff()

        Try
            If Not IsNothing(objResidentStaff) Then
                objResidentStaff.Close()
                objResidentStaff.Dispose()
                objResidentStaff = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseResidentStaff", ex)

        End Try
    End Sub

    Public Sub subCloseCraftSales()

        Try
            If Not IsNothing(objCraftSales) Then
                objCraftSales.Close()
                objCraftSales.Dispose()
                objCraftSales = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseCraftSales", ex)

        End Try
    End Sub

    Public Sub subShowCraftSheetBlank(ByVal _lngBlockID As Long, ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objCraftSheetBlankPreview) Then
                    objCraftSheetBlankPreview = New frmCraftSheetBlankPreview(_lngBlockID)
                Else

                    If objCraftSheetBlankPreview.IsDisposed Then
                        objCraftSheetBlankPreview = Nothing
                        objCraftSheetBlankPreview = New frmCraftSheetBlankPreview(_lngBlockID)
                    End If

                End If

                objCraftSheetBlankPreview.MdiParent = mdi
                objCraftSheetBlankPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowCraftSheetBlank", ex)
        End Try

    End Sub

    Public Sub subShowCraftBalance(ByVal _lngBlockID As Long, ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objfrmCraftBalanceRptPreview) Then
                    objfrmCraftBalanceRptPreview = New frmCraftBalanceRptPreview(_lngBlockID)
                Else

                    If objfrmCraftBalanceRptPreview.IsDisposed Then
                        objfrmCraftBalanceRptPreview = Nothing
                        objfrmCraftBalanceRptPreview = New frmCraftBalanceRptPreview(_lngBlockID)
                    End If

                End If

                objfrmCraftBalanceRptPreview.MdiParent = mdi
                objfrmCraftBalanceRptPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowCraftBalance", ex)
        End Try

    End Sub

    Public Sub subShowSummaryReportPreview(ByVal mdi As Form)

        Try

            If IsNothing(objSummary) Then
                objSummary = New frmSummaryReportPreview
            Else

                If objSummary.IsDisposed Then
                    objSummary = Nothing
                    objSummary = New frmSummaryReportPreview
                End If
            End If

            objSummary.MdiParent = mdi

            objSummary.Show()

        Catch ex As Exception

            subLogErr("subShowSummaryReportPreview", ex)

        End Try

    End Sub

    Public Sub subShowStaffAccounts(ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objStaffAccountsPreview) Then
                    objStaffAccountsPreview = New frmStaffAccountsPreview(_dteStart, _dteEnd)
                Else

                    If objStaffAccountsPreview.IsDisposed Then
                        objStaffAccountsPreview = Nothing
                        objStaffAccountsPreview = New frmStaffAccountsPreview(_dteStart, _dteEnd)
                    End If

                End If

                objStaffAccountsPreview.MdiParent = mdi
                objStaffAccountsPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowCraftBalance", ex)
        End Try

    End Sub


    Public Sub subShowCrCardDetails(ByVal mdi As Form)
        Try

            If objLogin.chkAdmin.Checked Then

                If IsNothing(objCrCardDetailsPreview) Then
                    objCrCardDetailsPreview = New frmCrCardDetailsPreview
                Else

                    If objCrCardDetailsPreview.IsDisposed Then
                        objCrCardDetailsPreview = Nothing
                        objCrCardDetailsPreview = New frmCrCardDetailsPreview
                    End If

                End If

                objCrCardDetailsPreview.MdiParent = mdi
                objCrCardDetailsPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowCrCardDetails", ex)
        End Try

    End Sub

    Public Sub subShowInvRptPreview(ByVal _blnInactive As Boolean, ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long, ByVal _mdi As Form)

        Try

            If objLogin.chkAdmin.Checked Then

                If objInvRptPreview Is Nothing Then
                    objInvRptPreview = New frmInvRptPreview(_blnInactive, _lngCategoryID, _lngStoreID)
                ElseIf objInvRptPreview.IsDisposed Then
                    objInvRptPreview = New frmInvRptPreview(_blnInactive, _lngCategoryID, _lngStoreID)
                End If

                objInvRptPreview.MdiParent = _mdi
                objInvRptPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowInvRptPreview", ex)
        End Try

    End Sub

    Public Sub subShowMonthlyInvPreview(ByVal _blnIncludeInactive As Boolean, ByVal _lngMonth As Long, ByVal _lngYear As Long, ByVal _lngStoreID As Long, ByVal _mdi As Form)

        Try

            If objLogin.chkAdmin.Checked Then

                If objMonthlyInvPreview Is Nothing Then
                    objMonthlyInvPreview = New frmMonthlyInvPreview(_blnIncludeInactive, _lngMonth, _lngYear, _lngStoreID)
                ElseIf objMonthlyInvPreview.IsDisposed Then
                    objMonthlyInvPreview = New frmMonthlyInvPreview(_blnIncludeInactive, _lngMonth, _lngYear, _lngStoreID)
                End If

                objMonthlyInvPreview.MdiParent = _mdi
                objMonthlyInvPreview.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowMonthlyInvPreview", ex)
        End Try

    End Sub

    Public Sub subShowMonthlyInvSetup(ByVal _mdi As Form)

        Try

            If objLogin.chkAdmin.Checked Then

                If objMonthInvSetup Is Nothing Then
                    objMonthInvSetup = New frmMonthlyInvSetup
                ElseIf objMonthInvSetup.IsDisposed Then
                    objMonthInvSetup = New frmMonthlyInvSetup
                End If

                objMonthInvSetup.MdiParent = _mdi
                objMonthInvSetup.Show()

            Else

                MsgBox("Users must have 'Admin' privileges to print reports.")
                Exit Sub

            End If

        Catch ex As Exception
            subLogErr("subShowMonthlyInvSetup", ex)
        End Try

    End Sub

    Public Sub subCloseMonthlyInvSetup()

        Try
            If Not IsNothing(objMonthInvSetup) Then
                objMonthInvSetup.Close()
                objMonthInvSetup.Dispose()
                objMonthInvSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseMonthlyInvSetup", ex)

        End Try
    End Sub

    Public Sub subShowDetSalesRptSetup(ByVal _mdi As Form)

        Try

            If objDetSalesRptSetup Is Nothing Then
                objDetSalesRptSetup = New frmDetailedSalesSetup
            ElseIf objDetSalesRptSetup.IsDisposed Then
                objDetSalesRptSetup = New frmDetailedSalesSetup
            End If

            objDetSalesRptSetup.MdiParent = _mdi
            objDetSalesRptSetup.Show()

        Catch ex As Exception
            subLogErr("subShowDetSalesRptSetup", ex)
        End Try

    End Sub

    Public Sub subCloseDetSalesRptSetup()

        Try
            If Not IsNothing(objDetSalesRptSetup) Then
                objDetSalesRptSetup.Close()
                objDetSalesRptSetup.Dispose()
                objDetSalesRptSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseDetSalesRptSetup", ex)

        End Try
    End Sub

    Public Sub subShowDetSalesRptPreview(ByVal _mdi As Form, ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long)

        Try

            If objDetSalesRptPreview Is Nothing Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID)
            ElseIf objDetSalesRptPreview.IsDisposed Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID)
            End If

            objDetSalesRptPreview.MdiParent = _mdi
            objDetSalesRptPreview.Show()

        Catch ex As Exception
            subLogErr("subShowDetSalesRptPreview", ex)
        End Try

    End Sub

    Public Sub subShowDetSalesRptPreview(ByVal _mdi As Form, ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long, ByVal _dteSaleDate As Date)

        Try

            If objDetSalesRptPreview Is Nothing Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID, _dteSaleDate)
            ElseIf objDetSalesRptPreview.IsDisposed Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID, _dteSaleDate)
            End If

            objDetSalesRptPreview.MdiParent = _mdi
            objDetSalesRptPreview.Show()

        Catch ex As Exception
            subLogErr("subShowDetSalesRptPreview", ex)
        End Try

    End Sub

    Public Sub subShowDetSalesRptPreview(ByVal _mdi As Form, ByVal _lngWSID As Long, ByVal _lngStoreID As Long, ByVal _lngClerkID As Long, ByVal _lngCategoryID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date)

        Try

            If objDetSalesRptPreview Is Nothing Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID, _dteStart, _dteEnd)
            ElseIf objDetSalesRptPreview.IsDisposed Then
                objDetSalesRptPreview = New frmDetSalesRptPreview(_lngWSID, _lngStoreID, _lngClerkID, _lngCategoryID, _dteStart, _dteEnd)
            End If

            objDetSalesRptPreview.MdiParent = _mdi
            objDetSalesRptPreview.Show()

        Catch ex As Exception
            subLogErr("subShowDetSalesRptPreview", ex)
        End Try

    End Sub

    Public Sub subCloseDetSalesRptPreview()

        Try
            If Not IsNothing(objDetSalesRptPreview) Then
                objDetSalesRptPreview.Close()
                objDetSalesRptPreview.Dispose()
                objDetSalesRptPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseDetSalesRptPreview", ex)

        End Try
    End Sub

    Public Sub subShowAdjSummarySetup(ByVal _mdi As Form)

        Try

            If objAdjSummarySetup Is Nothing Then
                objAdjSummarySetup = New frmAdjSummarySetup
            ElseIf objDetSalesRptPreview.IsDisposed Then
                objAdjSummarySetup = New frmAdjSummarySetup
            End If

            objAdjSummarySetup.MdiParent = _mdi
            objAdjSummarySetup.Show()

        Catch ex As Exception
            subLogErr("subShowAdjSummarySetup", ex)
        End Try

    End Sub

    Public Sub subCloseAdjSummarySetup()

        Try
            If Not IsNothing(objAdjSummarySetup) Then
                objAdjSummarySetup.Close()
                objAdjSummarySetup.Dispose()
                objAdjSummarySetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseAdjSummarySetup", ex)

        End Try
    End Sub

    Public Sub subShowAdjSummaryPreview(ByVal _lngStoreID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _mdi As Form)

        Try

            If objAdjSummaryPreview Is Nothing Then
                objAdjSummaryPreview = New frmAdjSummaryPreview(_lngStoreID, _dteStart, _dteEnd)
            ElseIf objAdjSummaryPreview.IsDisposed Then
                objAdjSummaryPreview = New frmAdjSummaryPreview(_lngStoreID, _dteStart, _dteEnd)
            End If

            objAdjSummaryPreview.MdiParent = _mdi
            objAdjSummaryPreview.Show()

        Catch ex As Exception
            subLogErr("subShowAdjSummaryPreview", ex)
        End Try

    End Sub

    Public Sub subShowAdjSummaryPreview(ByVal _lngStoreID As Long, ByVal _mdi As Form)

        Try

            If objAdjSummaryPreview Is Nothing Then
                objAdjSummaryPreview = New frmAdjSummaryPreview(_lngStoreID)
            ElseIf objAdjSummaryPreview.IsDisposed Then
                objAdjSummaryPreview = New frmAdjSummaryPreview(_lngStoreID)
            End If

            objAdjSummaryPreview.MdiParent = _mdi
            objAdjSummaryPreview.Show()

        Catch ex As Exception
            subLogErr("subShowAdjSummaryPreview", ex)
        End Try

    End Sub

    Public Sub subCloseAdjSummaryPreview()

        Try
            If Not IsNothing(objAdjSummaryPreview) Then
                objAdjSummaryPreview.Close()
                objAdjSummaryPreview.Dispose()
                objAdjSummaryPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseAdjSummaryPreview", ex)

        End Try
    End Sub

    Public Sub subShowInvSnapshotSetup(ByVal _mdi As Form)

        Try

            If objInvSnapshotSetup Is Nothing Then
                objInvSnapshotSetup = New frmInvSnapshotSetup
            ElseIf objInvSnapshotSetup.IsDisposed Then
                objInvSnapshotSetup = New frmInvSnapshotSetup
            End If

            objInvSnapshotSetup.MdiParent = _mdi
            objInvSnapshotSetup.Show()

        Catch ex As Exception
            subLogErr("subShowInvSnapshotSetup", ex)
        End Try

    End Sub

    Public Sub subCloseInvSnapshotSetup()

        Try
            If Not IsNothing(objInvSnapshotSetup) Then
                objInvSnapshotSetup.Close()
                objInvSnapshotSetup.Dispose()
                objInvSnapshotSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvSnapshotSetup", ex)

        End Try
    End Sub

    Public Sub subShowInvSnapshotPreview(ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long, ByVal _dteRptDate As Date, ByVal _mdi As Form)

        Try

            If objInvSnapshotPreview Is Nothing Then
                objInvSnapshotPreview = New frmInvSnapshotPreview(_lngCategoryID, _lngStoreID, _dteRptDate)
            ElseIf objInvSnapshotPreview.IsDisposed Then
                objInvSnapshotPreview = New frmInvSnapshotPreview(_lngCategoryID, _lngStoreID, _dteRptDate)
            End If

            objInvSnapshotPreview.MdiParent = _mdi
            objInvSnapshotPreview.Show()

        Catch ex As Exception
            subLogErr("subShowInvSnapshotPreview", ex)
        End Try

    End Sub

    Public Sub subCloseInvSnapshotPreview()

        Try
            If Not IsNothing(objInvSnapshotPreview) Then
                objInvSnapshotPreview.Close()
                objInvSnapshotPreview.Dispose()
                objInvSnapshotPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvSnapshotPreview", ex)

        End Try
    End Sub

    Public Sub subShowInvLblsPreview(ByVal _mdi As Form)

        Try

            If objInvLblsPreview Is Nothing Then
                objInvLblsPreview = New frmInvLblsPreview
            ElseIf objInvLblsPreview.IsDisposed Then
                objInvLblsPreview = New frmInvLblsPreview
            End If

            objInvLblsPreview.MdiParent = _mdi
            objInvLblsPreview.Show()

        Catch ex As Exception
            subLogErr("subShowInvLblsPreview", ex)
        End Try

    End Sub

    Public Sub subCloseInvLblsPreview()

        Try
            If Not IsNothing(objInvLblsPreview) Then
                objInvLblsPreview.Close()
                objInvLblsPreview.Dispose()
                objInvLblsPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvLblsPreview", ex)

        End Try
    End Sub

    Public Sub subShowInvCodeSheetSetup(ByVal _mdi As Form)

        Try

            If objInvCodeSheetSetup Is Nothing Then
                objInvCodeSheetSetup = New frmInvCodeSheetSetup
            ElseIf objInvCodeSheetSetup.IsDisposed Then
                objInvCodeSheetSetup = New frmInvCodeSheetSetup
            End If

            objInvCodeSheetSetup.MdiParent = _mdi
            objInvCodeSheetSetup.Show()

        Catch ex As Exception
            subLogErr("subShowInvCodeSheetSetup", ex)
        End Try

    End Sub

    Public Sub subCloseInvCodeSheetSetup()

        Try
            If Not IsNothing(objInvCodeSheetSetup) Then
                objInvCodeSheetSetup.Close()
                objInvCodeSheetSetup.Dispose()
                objInvCodeSheetSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvCodeSheetSetup", ex)

        End Try
    End Sub

    Public Sub subShowInvCodeSheetPreview(ByVal _lngCategoryID As Long, ByVal _lngStoreID As Long, ByVal _strSortField As String, ByVal _mdi As Form)

        Try

            If objInvCodeSheetPreview Is Nothing Then
                objInvCodeSheetPreview = New frmInvCodeSheetPreview(_lngCategoryID, _lngStoreID, _strSortField)
            ElseIf objInvCodeSheetPreview.IsDisposed Then
                objInvCodeSheetPreview = New frmInvCodeSheetPreview(_lngCategoryID, _lngStoreID, _strSortField)
            End If

            objInvCodeSheetPreview.MdiParent = _mdi
            objInvCodeSheetPreview.Show()

        Catch ex As Exception
            subLogErr("subShowInvCodeSheetPreview", ex)
        End Try

    End Sub

    Public Sub subCloseInvCodeSheetPreview()

        Try
            If Not IsNothing(objInvCodeSheetPreview) Then
                objInvCodeSheetPreview.Close()
                objInvCodeSheetPreview.Dispose()
                objInvCodeSheetPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseInvCodeSheetPreview", ex)

        End Try
    End Sub

    Public Sub subShowStoreSummaryPreview(ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strCaption As String, ByVal _mdi As Form)

        Try

            If objStoreSummaryPreview Is Nothing Then
                objStoreSummaryPreview = New frmStoreSummaryPreview(_dteStart, _dteEnd, _strCaption)
            ElseIf objStoreSummaryPreview.IsDisposed Then
                objStoreSummaryPreview = New frmStoreSummaryPreview(_dteStart, _dteEnd, _strCaption)
            End If

            objStoreSummaryPreview.MdiParent = _mdi
            objStoreSummaryPreview.Show()

        Catch ex As Exception
            subLogErr("subShowStoreSummaryPreview", ex)
        End Try

    End Sub

    Public Sub subCloseStoreSummaryPreview()

        Try
            If Not IsNothing(objStoreSummaryPreview) Then
                objStoreSummaryPreview.Close()
                objStoreSummaryPreview.Dispose()
                objStoreSummaryPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseStoreSummaryPreview", ex)

        End Try
    End Sub

    Public Sub subShowStoreSummaryByDateSetup(ByVal _mdi As Form)

        Try

            If objStoreSummaryByDateSetup Is Nothing Then
                objStoreSummaryByDateSetup = New frmStoreSummaryByDateSetup
            ElseIf objStoreSummaryByDateSetup.IsDisposed Then
                objStoreSummaryByDateSetup = New frmStoreSummaryByDateSetup
            End If

            objStoreSummaryByDateSetup.MdiParent = _mdi
            objStoreSummaryByDateSetup.Show()

        Catch ex As Exception
            subLogErr("subShowStoreSummaryByDateSetup", ex)
        End Try

    End Sub

    Public Sub subCloseStoreSummaryByDateSetup()

        Try
            If Not IsNothing(objStoreSummaryByDateSetup) Then
                objStoreSummaryByDateSetup.Close()
                objStoreSummaryByDateSetup.Dispose()
                objStoreSummaryByDateSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseStoreSummaryByDateSetup", ex)

        End Try
    End Sub

    Public Function fcnImportSettings() As Boolean

        Dim blnRes As Boolean = False

        Dim strXMLFile As String = ""

        'get xml file

        Using dlgDir = New OpenFileDialog()

            dlgDir.InitialDirectory = "C:\CampTrak"
            dlgDir.Filter = "XML Files|*.xml"
            dlgDir.RestoreDirectory = True

            Dim strMsg As String

            strMsg = "Please select a settings file to import (POSUserSettings.xml)." & vbNewLine & _
                    vbNewLine & _
                    "Click 'Cancel' on the following dialog if this is the first time you've run the CampTrak Store application or you can't find the settings file."

            MessageBox.Show(strMsg)

            dlgDir.Title = "Please select a settings file to import (POSUserSettings.xml)"

            If dlgDir.ShowDialog() = DialogResult.OK Then
                strXMLFile = dlgDir.FileName
                blnRes = True
            End If

        End Using

        Try

            'write xml file
            'strXMLFile = "C:\CampTrak\POSUserSettings.xml"

            Dim strDestPath = ""
            Dim strDestFile = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath

            strDestPath = System.IO.Path.GetDirectoryName(strDestFile)

            If Not System.IO.Directory.Exists(strDestPath) Then System.IO.Directory.CreateDirectory(strDestPath)

            If System.IO.File.Exists(strXMLFile) Then System.IO.File.Copy(strXMLFile, Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath, True)

        Catch ex As Exception
            subLogErr("subImportSettings", ex)
            blnRes = False
        End Try

        Return blnRes

    End Function

    Public Sub subShowCCSalesSetup(ByVal _mdi As Form)

        Try

            If objCCSalesSetup Is Nothing Then
                objCCSalesSetup = New frmCCSalesSetup
            ElseIf objCCSalesSetup.IsDisposed Then
                objCCSalesSetup = New frmCCSalesSetup
            End If

            objCCSalesSetup.MdiParent = _mdi
            objCCSalesSetup.Show()

        Catch ex As Exception
            subLogErr("subShowCCSalesSetup", ex)
        End Try

    End Sub

    Public Sub subCloseCCSalesSetup()

        Try
            If Not IsNothing(objCCSalesSetup) Then
                objCCSalesSetup.Close()
                objCCSalesSetup.Dispose()
                objCCSalesSetup = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseCCSalesSetup", ex)

        End Try
    End Sub

    Public Sub subShowCCSalesPreview(ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strCaption As String, ByVal _mdi As Form)

        Try

            If objCCSalesPreview Is Nothing Then
                objCCSalesPreview = New frmCCSalesPreview(_dteStart, _dteEnd, _strCaption)
            ElseIf objCCSalesPreview.IsDisposed Then
                objCCSalesPreview = New frmCCSalesPreview(_dteStart, _dteEnd, _strCaption)
            End If

            objCCSalesPreview.MdiParent = _mdi
            objCCSalesPreview.Show()

        Catch ex As Exception
            subLogErr("subShowCCSalesPreview", ex)
        End Try

    End Sub

    Public Sub subCloseCCSalesPreview()

        Try
            If Not IsNothing(objCCSalesPreview) Then
                objCCSalesPreview.Close()
                objCCSalesPreview.Dispose()
                objCCSalesPreview = Nothing
            End If

        Catch ex As Exception
            subLogErr("subCloseCCSalesPreview", ex)

        End Try
    End Sub

End Module