Imports System.Data.OleDb
Imports CTPOS_F.clsGlobalEnum
Imports Xceed.DockingWindows

Module basSales

    Public Function fcnNewSale(ByVal _lngSaleTypeID As conSALETYPE) As Long
        'add a sale of the passed type
        'return the id of the new sale

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Dim lngSaleID As Long

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "INSERT INTO tblSales " & _
                    "( lngStoreID, lngClerkID, lngSaleTypeID, lngWSID, " & _
                        "dteSaleDate ) " & _
                    "SELECT " & lngStoreID & ", " & lngClerkID & ", " & _lngSaleTypeID & ", " & lngWSID & ", '" & Now & "';"


            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            strSQL = "SELECT @@IDENTITY;"

            objCommand.CommandText = strSQL

            lngSaleID = CType(objCommand.ExecuteScalar, Long)

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("fcnNewSale", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

        fcnNewSale = lngSaleID

    End Function

    Public Function fcnAddSaleDetail(ByVal _strItem As String, ByVal _lngSaleID As Long, ByVal _strPriceLevel As String, ByVal _blnReturn As Boolean) As Boolean
        'add a sale detail to the passed sale id
        'inventory code matching _strItem
        'returns true if successful

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Dim lngSaleDetailID As Long = 0
        Dim lngCurrentQty As Long = 0

        Dim blnRes As Boolean = False

        Dim intQty As Integer = 1

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            'check to see if item exists in sale already
            strSQL = "SELECT tblsalesdetail.lngQuantity " & _
                    "FROM tblSalesDetail " & _
                        "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                    "WHERE tblSalesDetail.lngSaleID=" & _lngSaleID & " AND " & _
                        "tblInventory.strStockCode='" & _strItem & "';"

            objCommand.CommandText = strSQL

            lngCurrentQty = CType(objCommand.ExecuteScalar, Long)

            strSQL = "SELECT tblsalesdetail.lngSalesDetailID " & _
                    "FROM tblSalesDetail " & _
                        "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                    "WHERE tblSalesDetail.lngSaleID=" & _lngSaleID & " AND " & _
                        "tblInventory.strStockCode='" & _strItem & "';"

            objCommand.CommandText = strSQL

            lngSaleDetailID = CType(objCommand.ExecuteScalar, Long)


            If _blnReturn Then
                intQty = -intQty
            End If

            'If lngSaleDetailID = 0 Then

            If lngCurrentQty = 0 Then
                strSQL = "INSERT INTO tblSalesDetail " & _
                        "( lngSaleID, lngInventoryID, lngQuantity, " & _
                            "curPrice, curTotal ) " & _
                        "SELECT " & _lngSaleID & ", tblInventory.lngInventoryID, " & intQty & ", " & _
                            "tblInventory." & _strPriceLevel & ", (tblInventory." & _strPriceLevel & " * " & intQty & ") " & _
                        "FROM tblInventory " & _
                        "WHERE tblInventory.strStockCode='" & _strItem & "';"

            Else
                If lngCurrentQty > 1 Then
                    intQty = CType(InputBox("How many would you like to add?", , "1"), Integer)

                    If intQty > 99 Then
                        If MsgBox("Are you sure you want to add qty " & intQty & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Function
                        End If
                    End If

                End If

                If intQty < 1 Then Exit Try

                strSQL = "UPDATE tblSalesDetail " & _
                        "SET tblSalesDetail.lngQuantity = [tblSalesDetail].[lngQuantity]+" & intQty & ", " & _
                            "tblSalesDetail.curTotal = ([tblSalesDetail].[curPrice])*([tblSalesDetail].[lngQuantity]+" & intQty & ") " & _
                        "WHERE tblSalesDetail.lngSalesDetailID=" & lngSaleDetailID & ";"

            End If

            objCommand.CommandText = strSQL

            If objCommand.ExecuteNonQuery > 0 Then blnRes = True

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("fcnAddSaleDetail", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

        fcnAddSaleDetail = blnRes

    End Function

    Public Function fcnCompleteSale(ByVal _lngSaleID As Long, ByVal _lngPaymentType As clsGlobalEnum.conPMTTYPE) As Boolean
        'this function receives a sale id and payment type used for completing the sale
        'it calls appropriate routines for collecting payment, prints a receipt and completes the sale

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String
        Dim strPrintArgs As String = ""

        Dim dblTotalCharge As Double
        Dim dblSubTotal As Double
        Dim dblTax As Double


        Dim blnComplete As Boolean = False

        Try

            'init global variables
            dblCashIn = 0
            dblChange = 0

            'collect money
            subGetTotals(_lngSaleID, dblTotalCharge, dblSubTotal, dblTax, _lngPaymentType)

            Select Case _lngPaymentType

                Case conPMTTYPE.conPMTTYPE_CASH

                    subMakeChange(blnComplete, dblTotalCharge)

                    strPrintArgs = "Cash"

                Case conPMTTYPE.conPMTTYPE_CHECK

                    subMakeChange(blnComplete, dblTotalCharge)

                    strPrintArgs = "Check"

                Case conPMTTYPE.conPMTTYPE_CC

                    subPayByCC(blnComplete, _lngSaleID, dblTotalCharge)

                Case conPMTTYPE.conPMTTYPE_SPENDMNY

                    subPayBySpendingMoney(blnComplete, _lngSaleID, dblTotalCharge)

                Case conPMTTYPE.conPMTTYPE_StaffChg
                    subStaffCharge(blnComplete, _lngSaleID, dblTotalCharge)

                Case conPMTTYPE.conPMTTYPE_DEPTTRNSFR
                    'dept xfer is not taxable, regardless of item
                    subCompleteDeptXFer(blnComplete, _lngSaleID)
                    dblTax = 0
            End Select

            If blnComplete Then
                'update sale details
                objConn = New OleDbConnection(strPOSConn)

                objConn.Open()

                objCommand = New OleDbCommand

                objCommand.Connection = objConn

                strSQL = "UPDATE tblSales " & _
                        "SET lngPaymentTypeID=" & _lngPaymentType & ", " & _
                            "curTax = " & dblTax & ", curTotalCharge = " & dblTotalCharge & ", curSubTotal = " & dblSubTotal & " " & _
                        "WHERE lngSaleID=" & _lngSaleID & ";"

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

                objConn.Close()

                objCommand.Dispose()
                objConn.Dispose()

                objCommand = Nothing
                objConn = Nothing

                If _lngPaymentType = conPMTTYPE.conPMTTYPE_CASH Or _lngPaymentType = conPMTTYPE.conPMTTYPE_CHECK Or _lngPaymentType = conPMTTYPE.conPMTTYPE_CC Or _lngPaymentType = conPMTTYPE.conPMTTYPE_DEPTTRNSFR Then

                    Try
                        dblCashIn = NZ(dblCashIn, 0)
                        dblCashIn = dblCashIn / 100
                    Catch ex As Exception
                        dblCashIn = 0
                    End Try

                    Try
                        dblChange = NZ(dblChange, 0)
                        'dblChange = dblChange / 100
                    Catch ex As Exception
                        dblChange = 0
                    End Try

                    subPrintReceipt(_lngSaleID, , , strPrintArgs, dblCashIn, dblChange)

                End If


            End If

        Catch ex As Exception

            subLogErr("subCompleteSale", ex)

        End Try

        fcnCompleteSale = blnComplete
        blnSaleOpen = Not fcnCompleteSale

    End Function

    Public Sub subCompleteDeptXFer(ByRef _blnComplete As Boolean, ByVal _lngSaleID As Long)

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim objChooseDept As frmChooseDept

        Dim strSQL As String

        Dim lngDeptID As Long

        Try

            objChooseDept = New frmChooseDept

            objChooseDept.ShowDialog()

            lngDeptID = objChooseDept.lngDeptID

            If lngDeptID = 0 Then

                _blnComplete = False

            Else

                'update deptid, saletype
                objConn = New OleDbConnection(strPOSConn)

                objConn.Open()

                objCommand = New OleDbCommand

                objCommand.Connection = objConn

                strSQL = "UPDATE tblSales " & _
                        "SET lngDeptID=" & lngDeptID & ", lngSaleTypeID=7 " & _
                        "WHERE lngSaleID=" & _lngSaleID & ";"

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

                objConn.Close()

                objCommand.Dispose()
                objConn.Dispose()

                objCommand = Nothing
                objConn = Nothing

                _blnComplete = True

                'print dept xfer rcpt

            End If

        Catch ex As Exception

            subLogErr("subCompleteDeptXFer", ex)

        End Try

    End Sub

    Public Sub subMakeChange(ByRef _blnComplete As Boolean, ByVal _dblTotalCharge As Double)

        Dim objChangeMaker As frmChangeMaker

        Try

            objChangeMaker = New frmChangeMaker

            objChangeMaker.dblAmtDue = _dblTotalCharge

            objChangeMaker.ShowDialog()

            _blnComplete = objChangeMaker.blnComplete

            objChangeMaker.Dispose()

            objChangeMaker = Nothing

        Catch ex As Exception

            subLogErr("subMakeChange", ex)

        End Try

    End Sub

    Public Sub subPayByCCXCharge(ByRef _blnComplete As Boolean, ByVal _lngSaleID As Long, ByVal _dblAmt As Double)

        Dim strSQL As String = ""
        Dim strCardNumber As String = ""
        Dim strExpDate As String = ""
        Dim strCVV2 As String = ""
        Dim strBillAddress As String = ""
        Dim strBillZip As String = ""
        Dim strPNRef As String = ""
        Dim strPNRefForReturn As String = ""
        Dim strIn As String = ""
        Dim strSaleType As String = ""

        Dim lngReturnSaleID As Long = 0

        Dim blnProcess As Boolean = True
        Dim strXCTransID As String = ""
        Dim strXCAuthCode As String = ""
        Dim decApprovedAmt As Decimal = 0

        Try

            If _dblAmt < 0 Then

                strSaleType = "Refund"

                strIn = InputBox("Please enter the original sale ID (from receipt):", "Original Sale ID")

                If IsNumeric(strIn) Then
                    lngReturnSaleID = CType(strIn, Long)

                    Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)
                        conDB.Open()

                        strSQL = "SELECT strXCTransID " & _
                                "FROM tblSales " & _
                                "WHERE lngSaleID=@lngSaleID"

                        Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                            cmdDB.Parameters.AddWithValue("@lngSaleID", lngReturnSaleID)

                            Try
                                strXCTransID = Convert.ToString(cmdDB.ExecuteScalar())
                            Catch ex As Exception
                                strXCTransID = ""
                            End Try
                        End Using

                        conDB.Close()

                    End Using
                Else
                    blnProcess = False
                End If

            Else

                strSaleType = "Sale"

            End If

            If blnProcess Then

                'run charge
                If fcnLiveXCharge(objCashSales.Handle, strCardNumber, strExpDate, strBillZip, strBillAddress, strCVV2, _dblAmt, _lngSaleID, strSaleType, "", strXCTransID, strXCAuthCode, decApprovedAmt) Then

                    strCardNumber = Right(strCardNumber, 4)

                    'update sale w/ cc info
                    Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                        conDB.Open()

                        strSQL = "UPDATE tblSales " & _
                                "SET lngPaymentTypeID = " & conPMTTYPE.conPMTTYPE_CC & ", " & _
                                    "strXCAuthCode=?, strXCTransID=?, strCCNumber=?, strZip=? " & _
                                "WHERE lngSaleID=?"

                        Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                            cmdDB.Parameters.AddWithValue("@strXCAuthCode", strXCAuthCode)
                            cmdDB.Parameters.AddWithValue("@strXCTransID", strXCTransID)
                            cmdDB.Parameters.AddWithValue("@strCCNumber", strCardNumber)
                            cmdDB.Parameters.AddWithValue("@strZip", strBillZip)
                            cmdDB.Parameters.AddWithValue("@lngSaleID", _lngSaleID)

                            'cmdDB.Parameters.Add(New OleDbParameter("@strXCAuthCode", strXCAuthCode))
                            'cmdDB.Parameters.Add(New OleDbParameter("@strXCTransID", strXCTransID))
                            'cmdDB.Parameters.Add(New OleDbParameter("@strCCNumber", strCardNumber))
                            'cmdDB.Parameters.Add(New OleDbParameter("@strZip", strBillZip))
                            'cmdDB.Parameters.Add(New OleDbParameter("@lngSaleID", _lngSaleID))

                            cmdDB.ExecuteNonQuery()

                        End Using

                        conDB.Close()

                    End Using

                    _blnComplete = True

                    subOpenDrawer()

                Else
                    MsgBox("The credit card processing failed.")
                    _blnComplete = False
                End If

            Else
                MsgBox("The credit card processing failed.")
                _blnComplete = False
            End If

        Catch ex As Exception

            subLogErr("subPayByCC", ex)

        End Try

    End Sub

    Public Sub subPayByCC(ByRef _blnComplete As Boolean, ByVal _lngSaleID As Long, ByVal _dblAmt As Double)

        If CType(My.Settings.lngLiveCharge, conLIVECHARGE) = conLIVECHARGE.XCharge Then

            subPayByCCXCharge(_blnComplete, _lngSaleID, _dblAmt)
            Exit Sub

        End If

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim objCaptureCC As frmCaptureCC

        Dim strSQL As String
        Dim strCardNumber As String
        Dim strExpDate As String
        Dim strCVV2 As String
        Dim strBillName As String
        Dim strZip As String
        Dim strPhone As String
        Dim strSwipeData As String
        Dim strAuth As String = ""
        Dim strPNRef As String = ""
        Dim strPNRefForReturn As String = ""
        Dim strIn As String

        Dim lngReturnSaleID As Long

        Dim blnChargeRes As Boolean
        Dim blnSwiped As Boolean
        Dim blnProcess As Boolean = True

        Try

            objCaptureCC = New frmCaptureCC

            objCaptureCC.ShowDialog()

            strCardNumber = objCaptureCC.strCardNumber
            strExpDate = objCaptureCC.strExpDate
            strCVV2 = objCaptureCC.strCVV2
            strBillName = objCaptureCC.strBillName
            strZip = objCaptureCC.strZip
            strPhone = objCaptureCC.strPhone
            blnSwiped = objCaptureCC.blnSwiped
            strSwipeData = objCaptureCC.strSwipeData

            objCaptureCC.Dispose()

            objCaptureCC = Nothing

            If strCardNumber = "" Then

                _blnComplete = False

            Else

                If _dblAmt < 0 Then

                    strIn = InputBox("Please enter the original sale ID (from receipt):", "Original Sale ID")

                    If IsNumeric(strIn) Then
                        lngReturnSaleID = CType(strIn, Long)

                        Using conPOS As New OleDbConnection(strPOSConn)

                            conPOS.Open()

                            strSQL = "SELECT strCCNumber, strPNRef " & _
                                    "FROM tblSales " & _
                                    "WHERE lngSaleID=" & lngReturnSaleID

                            Using cmdPOS As New OleDbCommand(strSQL, conPOS)

                                Using drSale As OleDbDataReader = cmdPOS.ExecuteReader()

                                    If drSale.Read() Then
                                        'check card number from original sale
                                        If drSale("strCCNumber").ToString().Length >= 4 Then
                                            If strCardNumber.Substring(strCardNumber.Length - 4, 4) = drSale("strCCNumber").ToString().Substring(drSale("strCCNumber").ToString().Length - 4, 4) Then
                                                strPNRefForReturn = drSale("strPNRef").ToString()
                                            Else
                                                MsgBox("The card used for the original sale does not match the submitted card.")
                                                blnProcess = False
                                            End If
                                        Else
                                            MsgBox("The original sale's card number could not be validated.")
                                            blnProcess = False
                                        End If
                                    Else
                                        MsgBox("The sale id (" & lngReturnSaleID & ") does not match an existing sale.")
                                        blnProcess = False
                                    End If

                                End Using

                            End Using

                            conPOS.Close()

                        End Using

                    Else
                        blnProcess = False
                    End If
                    
                End If

                If blnProcess Then
                    'run charge
                    Select Case CType(My.Settings.lngLiveCharge, clsGlobalEnum.conLIVECHARGE)
                        Case conLIVECHARGE.None
                            blnChargeRes = True

                        Case conLIVECHARGE.CashLinq
                            blnChargeRes = fcnLiveCashLinq(strCardNumber, strExpDate, strBillName, strZip, blnSwiped, strCVV2, _dblAmt, _lngSaleID, strAuth, strSwipeData, strPNRef, strPNRefForReturn)

                    End Select

                    If blnChargeRes Then
                        If My.Settings.lngLiveCharge <> conLIVECHARGE.None Then
                            strCardNumber = Right(strCardNumber, 4)
                        End If

                        'update sale w/ cc info
                        objConn = New OleDbConnection(strPOSConn)

                        objConn.Open()

                        objCommand = New OleDbCommand

                        objCommand.Connection = objConn

                        strSQL = "UPDATE tblSales " & _
                                "SET lngPaymentTypeID = " & conPMTTYPE.conPMTTYPE_CC & ", " & _
                                    "strAuthNumber='" & strAuth & "', strPNRef='" & strPNRef & "', strCCNumber = '" & strCardNumber & "', strCCExpDate = '" & strExpDate & "', strCVV2 = '" & strCVV2 & "', strBillName = '" & strBillName & "', strZip = '" & strZip & "', strPhone = '" & strPhone & "' " & _
                                "WHERE lngSaleID=" & _lngSaleID & ";"

                        objCommand.CommandText = strSQL

                        objCommand.ExecuteNonQuery()

                        objConn.Close()

                        objCommand.Dispose()
                        objConn.Dispose()

                        objCommand = Nothing
                        objConn = Nothing

                        _blnComplete = True

                        subOpenDrawer()

                    Else
                        MsgBox("The credit card processing failed.")
                        _blnComplete = False
                    End If

                Else
                    MsgBox("The credit card processing failed.")
                    _blnComplete = False
                End If

            End If

        Catch ex As Exception

            subLogErr("subPayByCC", ex)

        End Try

    End Sub

    Public Function fcnLiveXCharge(ByVal lngHandle As Long, ByRef str_CardNum As String, ByRef str_Exp As String, ByRef str_Zip As String, ByRef str_Address As String, ByRef str_CVV As String, ByVal dbl_Amt As Double, ByVal lng_SaleID As Long, ByVal str_SaleType As String, ByRef strXCAlias As String, ByRef strXCTransID As String, ByRef strXCAuthCode As String, ByRef curApprovedAmt As Decimal) As Boolean

        Dim objXC As New XCTransaction2.XChargeTransaction

        Dim strErr As String
        Dim strRes As String
        Dim strCVVRes As String

        Dim strXChargePath As String
        Dim strRawSwipe As String
        Dim strTrack1 As String
        Dim strTrack2 As String
        Dim strCCType As String
        Dim strExpMonth As String
        Dim strExpYear As String
        Dim strName As String

        Dim strAppAmtRes As String
        Dim strBalAmtRes As String

        Dim blnRes As Boolean

        blnRes = False

        strXChargePath = My.Settings.strXChargePath

        If strXCAlias = "" Then

            'prompt for card entry
            If objXC.PromptCreditCardEntry(lngHandle, "Enter Transaction Details", False, False, False, strRawSwipe, strTrack1, strTrack2, str_CardNum, strCCType, strExpMonth, strExpYear, strName, str_Zip, str_Address, str_CVV) Then
                'add to vault, get alias
                If Not objXC.XCArchiveVaultAdd(lngHandle, strXChargePath, "CampTrak Store Transaction", True, False, strTrack1, "", "", "USEEXISTING", strXCAlias, strErr) Then
                    strXCAlias = ""
                End If
            Else
                strXCAlias = ""
            End If

        End If

        If strXCAlias <> "" Then

            'the allow dup flag is throwing an error on first transaction...first try not allowing.
            'if dupe error is returned then try again with flag switched
            If objXC.XCPurchaseEx2(lngHandle, strXChargePath, "CampTrak Store Transactions", True, False, lngClerkID.ToString(), CStr(lng_SaleID), strXCAlias, "", strRawSwipe, CStr(dbl_Amt), str_Zip, str_Address, str_CVV, "", "", False, False, True, strErr, strXCAuthCode, strRes, strCVVRes, strXCTransID, strAppAmtRes, strBalAmtRes) Then

                blnRes = True

            Else

                If strErr = "094 AP DUPE" Then
                    If objXC.XCPurchaseEx2(lngHandle, strXChargePath, "CampTrak Store Transactions", True, False, lngClerkID.ToString(), CStr(lng_SaleID), strXCAlias, "", strRawSwipe, CStr(dbl_Amt), str_Zip, str_Address, str_CVV, "", "", False, True, True, strErr, strXCAuthCode, strRes, strCVVRes, strXCTransID, strAppAmtRes, strBalAmtRes) Then
                        blnRes = True
                    Else
                        blnRes = False
                    End If
                Else
                    blnRes = False
                End If
            End If

        End If

        If blnRes Then

            On Error Resume Next

            curApprovedAmt = CDec(strAppAmtRes)

            If curApprovedAmt < dbl_Amt Then
                MsgBox("Partial Approval" & vbNewLine & vbNewLine & "Requested Amount: " & dbl_Amt & vbNewLine & "Approved Amount: " & strAppAmtRes & vbNewLine & "Amount Remaining: " & dbl_Amt - curApprovedAmt)
            Else
                MsgBox("Approved")
            End If

            On Error GoTo 0

        Else
            MsgBox("Error processing card: " & strErr)
        End If

        fcnLiveXCharge = blnRes

    End Function

    Public Function fcnLiveXCharge_20130529(ByVal _strCardNum As String, ByVal _strExp As String, ByVal _strZip As String, ByVal _strSwipeData As String, ByVal _strcvv As String, ByVal _dblAmt As Double, ByVal _lngSaleID As Long, ByRef strAuth As String) As Boolean

        Dim objXC As New XCTransaction2.XChargeTransaction

        Dim strErr As String
        Dim strApp As String
        Dim strRes As String
        Dim strCVVRes As String
        Dim strEXP As String

        Dim blnRes As Boolean

        strErr = ""
        strApp = ""
        strRes = ""
        strCVVRes = ""

        strEXP = Right(_strExp, 2) & Left(_strExp, 2)

        If _dblAmt < 0 Then
            blnRes = objXC.XCReturn(CType(objCashSales.Handle, Integer), My.Settings.strXChargePath, "CampTrak POS Transaction", _
                        True, True, objLogin.cboClerks.Text, _lngSaleID.ToString, _strCardNum, _
                        strEXP, _strSwipeData, Math.Abs(_dblAmt).ToString, strErr, strApp)

        Else
            blnRes = objXC.XCPurchase(CType(objCashSales.Handle, Integer), My.Settings.strXChargePath, "CampTrak POS Transaction", _
            True, True, objLogin.cboClerks.Text, _lngSaleID.ToString, _strCardNum, _
            strEXP, _strSwipeData, _dblAmt.ToString, _strZip, _
            "", _strcvv, strErr, strApp, strRes, strCVVRes)
        End If

        strAuth = strApp

        fcnLiveXCharge_20130529 = blnRes

        objXC = Nothing

    End Function

    Public Function fcnLiveCashLinq(ByVal _strCardNumber As String, ByVal _strExp As String, ByVal _strBillName As String, ByVal _strBillZip As String, ByVal blnSwiped As Boolean, ByVal _strCVV As String, ByVal _dblAmt As Double, ByVal _lngSaleID As Long, ByRef strAuth As String, ByVal _strSwipeData As String, ByRef strPNRefOut As String, ByVal _strPNRefForReturn As String) As Boolean

        Dim wsCashLinq As CashLinq.SmartPayments
        Dim wsCLResponse As CashLinq.Response

        wsCashLinq = New CashLinq.SmartPayments

        If _dblAmt < 0 Then
            wsCLResponse = wsCashLinq.ProcessCreditCard(My.Settings.strCashLinqUName, My.Settings.strCashLinqPW, "Return", _strCardNumber, _strExp, "", _strBillName, Math.Abs(_dblAmt).ToString(), _lngSaleID.ToString, _strPNRefForReturn, _strBillZip, "", _strCVV, "")
        Else
            wsCLResponse = wsCashLinq.ProcessCreditCard(My.Settings.strCashLinqUName, My.Settings.strCashLinqPW, "Sale", _strCardNumber, _strExp, "", _strBillName, _dblAmt.ToString, _lngSaleID.ToString, "", _strBillZip, "", _strCVV, "")
        End If

        strAuth = wsCLResponse.AuthCode
        strPNRefOut = wsCLResponse.PNRef

        If wsCLResponse.RespMSG = "Approved" Then
            fcnLiveCashLinq = True
        Else
            fcnLiveCashLinq = False
        End If

    End Function

    Public Sub subPayBySpendingMoney(ByRef _blnComplete As Boolean, ByVal _lngSaleID As Long, ByVal _dblTotal As Double)

        Dim objCTConn As OleDbConnection
        Dim objPOSConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Dim lngRegistrationID As Long
        Dim lngRecordID As Long
        Dim lngTransactionID As Long

        Try
            'tony

            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btncontinue").Visible = True
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btnCancel").Visible = True
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btnaddspendingmoney").Visible = False

            'CType(objSwitchboard.dlmSwitchboard.ToolWindows(0), ucSpending).subLoadDefaultCampers()

            objSwitchboard.dlmSwitchboard.ToolWindows(0).SuspendLayout()
            objSwitchboard.dlmSwitchboard.ToolWindows(0).State = Xceed.DockingWindows.ToolWindowState.Docked
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Width = 300
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Update()
            objSwitchboard.dlmSwitchboard.ToolWindows(0).ResumeLayout()

            lngRegId = -1
            lngRegistrationID = -1

            Do While lngRegId < 0
                If lngRegId = -2 Then
                    Exit Sub
                End If
                lngRegistrationID = lngRegId
                Application.DoEvents()
            Loop
            lngRegistrationID = lngRegId
            objSwitchboard.dlmSwitchboard.SuspendLayout()
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btncontinue").Visible = False
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btncancel").Visible = False
            objSwitchboard.dlmSwitchboard.ToolWindows(0).Controls(1).Controls("btnaddspendingmoney").Visible = True
            objSwitchboard.dlmSwitchboard.ToolWindows(0).State = ToolWindowState.AutoHide

            objSwitchboard.dlmSwitchboard.ResumeLayout()

            If lngRegistrationID = 0 Then

                _blnComplete = False

                Exit Sub

            Else
                'validate balance
                If Not fcnVerifyBalance(lngRegistrationID, _dblTotal) Then

                    _blnComplete = False
                    Exit Sub

                End If
                'add transaction
                objCTConn = New OleDbConnection

                objCTConn.ConnectionString = strCTConn

                objCTConn.Open()

                objCommand = New OleDbCommand

                objCommand.Connection = objCTConn

                strSQL = "SELECT lngRecordID " & _
                        "FROM tblRegistrations " & _
                        "WHERE lngRegistrationID=" & lngRegistrationID & ";"

                objCommand.CommandText = strSQL

                lngRecordID = CType(objCommand.ExecuteScalar, Long)

                'with sale id
                strSQL = "INSERT INTO tblTransactions " & _
                        "( lngTransTypeID, lngRecordID, lngRegistrationID, lngPaymentTypeID, lngWSID, lngSaleID, " & _
                            "curCharge, " & _
                            "dteDateAdded ) " & _
                        "SELECT " & conTRANSTYPE.conStoreCharge & ", " & lngRecordID & ", " & lngRegistrationID & ", " & conPMTTYPE.conPMTTYPE_SPENDMNY & ", " & lngWSID & ", " & _lngSaleID & ", " & _
                            _dblTotal & ", " & _
                            "Now();"

                'no sale id
                'strSQL = "INSERT INTO tblTransactions " & _
                '        "( lngTransTypeID, lngRecordID, lngRegistrationID, lngPaymentTypeID, lngWSID, " & _
                '            "curCharge, " & _
                '            "dteDateAdded ) " & _
                '        "SELECT " & conTRANSTYPE.conStoreCharge & ", " & lngRecordID & ", " & lngRegistrationID & ", " & conPMTTYPE.conPMTTYPE_SPENDMNY & ", " & lngWSID & ", " & _
                '            _dblTotal & ", " & _
                '            "Now();"

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

                strSQL = "SELECT @@IDENTITY;"

                objCommand.CommandText = strSQL

                lngTransactionID = CType(objCommand.ExecuteScalar, Long)

                objPOSConn = New OleDbConnection(strPOSConn)

                objPOSConn.Open()

                objCommand.Connection = objPOSConn

                'update sale
                strSQL = "UPDATE tblSales " & _
                        "SET lngCamperID=" & lngRecordID & ", lngRegistrationID=" & lngRegistrationID & ", lngTransactionID = " & lngTransactionID & " " & _
                        "WHERE lngSaleID=" & _lngSaleID

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

                _blnComplete = True

            End If

            objCTConn.Close()
            objPOSConn.Close()

            objCommand.Dispose()
            objCTConn.Dispose()
            objPOSConn.Dispose()

        Catch ex As Exception

            subLogErr("subPayBySpendingMoney", ex)

        End Try

        objCommand = Nothing
        objCTConn = Nothing
        objPOSConn = Nothing

    End Sub

    Public Function fcnVerifyBalance(ByVal lngREgID As Long, ByVal _dblAmt As Double) As Boolean
        'check amount against camper balance 

        Dim objConn As OleDbConnection
        Dim objPOSConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String
        Dim strPW As String

        Dim dblBalance As Double

        Dim lngAdminID As Long

        Dim blnRes As Boolean = False

        Try

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            strSQL = "SELECT [curPayments]-[curCharges] AS curBalance, Sum(tblTransactions.curPayment) AS curPayments, Sum(tblTransactions.curCharge) AS curCharges " & _
                    "FROM ((tblRegistrations " & _
                        "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                        "INNER JOIN tblTransactions ON (tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID) AND " & _
                            "(tblRecords.lngRecordID = tblTransactions.lngRecordID)) " & _
                        "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                    "WHERE tblRegistrations.lngRegistrationID=" & lngREgID & " " & _
                        "AND tlkpTransType.blnSpending=True;"

            objCommand = New OleDbCommand(strSQL, objConn)

            dblBalance = CType(objCommand.ExecuteScalar, Double)

            If dblBalance >= _dblAmt Then
                blnRes = True
            Else
                If MsgBox("Balance due greater than camper spending money available." & vbNewLine & vbNewLine & "Continue?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    blnRes = False
                Else

                    objPOSConn = New OleDbConnection(strPOSConn)

                    objPOSConn.Open()

                    objCommand.Connection = objPOSConn

                    Using objInput As frmMaskedInputBox = New frmMaskedInputBox("Enter admin password to continue:")

                        If objInput.ShowDialog() = DialogResult.OK Then
                            strPW = objInput.strInput
                        Else
                            strPW = ""
                        End If

                    End Using

                    strSQL = "SELECT lngClerkID " & _
                            "FROM tblClerks " & _
                            "WHERE blnAdmin<>0 AND " & _
                                "strPassword='" & strPW & "'"

                    objCommand.CommandText = strSQL

                    lngAdminID = CType(objCommand.ExecuteScalar, Long)

                    If strPW = "" Then
                        lngAdminID = 0
                        MsgBox("Password must not be blank to authenticate over-charge.")
                    End If

                    If lngAdminID > 0 Then
                        blnRes = True
                    Else
                        MsgBox("Invalid admin password.")
                        blnRes = False
                    End If

                    objPOSConn.Close()

                    objPOSConn.Dispose()

                    objPOSConn = Nothing

                End If
            End If

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr("fcnVerifyBalance", ex)

        End Try

        fcnVerifyBalance = blnRes

    End Function

    Public Sub subStaffCharge(ByRef _blnComplete As Boolean, ByVal _lngSaleID As Long, ByVal _dblTotal As Double)

        Dim objStaffChg As New frmStaffCharge

        Dim objPOSConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Dim lngStaffID As Long

        Try

            objStaffChg.ShowDialog()

            lngStaffID = objStaffChg.lngStaffID

            objStaffChg.Dispose()

            objStaffChg = Nothing

            If lngStaffID = 0 Then

                _blnComplete = False

                Exit Sub

            Else
                'update Sale with Staff ID

                objCommand = New OleDbCommand

                objPOSConn = New OleDbConnection(strPOSConn)

                objPOSConn.Open()

                objCommand.Connection = objPOSConn

                'update sale
                strSQL = "UPDATE tblSales " & _
                        "SET lngSTaffID = " & lngStaffID & " " & _
                        "WHERE lngSaleID=" & _lngSaleID

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

                _blnComplete = True

            End If

            objPOSConn.Close()
            objCommand.Dispose()
            objPOSConn.Dispose()

        Catch ex As Exception

            subLogErr("subStaffCharge", ex)

        End Try

        objCommand = Nothing
        objPOSConn = Nothing

    End Sub

    Public Sub subGetTotals(ByVal _lngSaleID As Long, ByRef _dblTotal As Double, ByRef _dblSubTotal As Double, ByRef _dblTax As Double, ByVal lngPaymentType As Long)

        Dim strSQL As String

        Dim dblTaxRate As Double

        Dim decTaxable As Decimal = 0
        Dim decNonTaxable As Decimal = 0

        Try

            If lngPaymentType = conPMTTYPE.conPMTTYPE_DEPTTRNSFR Then
                dblTaxRate = 0
            Else
                dblTaxRate = fcnTaxRate()
            End If

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT tblInventory.blnTaxable, Sum(tblSalesDetail.curTotal) AS curTotal " & _
                        "FROM tblSalesDetail " & _
                            "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                        "WHERE tblSalesDetail.lngSaleID=" & _lngSaleID.ToString() & " " & _
                        "GROUP BY tblInventory.blnTaxable;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drSales As OleDbDataReader = cmdDB.ExecuteReader()
                        
                        While drSales.Read

                            _dblSubTotal += Math.Round(CType(drSales("curTotal"), Double), 2)

                            If CType(drSales("blnTaxable"), Boolean) Then
                                Try
                                    decTaxable += Convert.ToDecimal(drSales("curTotal"))
                                Catch ex As Exception
                                    subLogErr("basSales.subGetTotals", ex)
                                End Try
                            Else
                                decNonTaxable += Math.Round(CType(drSales("curTotal"), Double), 2)
                            End If

                        End While

                        drSales.Close()

                    End Using

                End Using

                conDB.Close()

                _dblTotal = (decTaxable * dblTaxRate) + decTaxable + decNonTaxable

                _dblTotal = Convert.ToDouble(_dblTotal.ToString("C").Replace("$", "").Replace("(", "-").Replace(")", ""))


                _dblTax = decTaxable * dblTaxRate
                _dblTax = Convert.ToDouble(_dblTax.ToString("C").Replace("$", "").Replace("(", "-").Replace(")", ""))

            End Using
            
        Catch ex As Exception

            subLogErr("subGetTotals", ex)

        End Try

    End Sub

    Public Sub subTestPrinter()

        Dim strOut As String

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

        strOut = ""
        strOut = strOut & "rcptInit: " & rcptInit
        strOut = strOut & "rcptNewLine: " & rcptNewLine
        strOut = strOut & "rcptLeftJustify: " & rcptLeftJustify
        strOut = strOut & "rcptCenterJustify: " & rcptCenterJustify
        strOut = strOut & "rcptRightJustify: " & rcptRightJustify
        strOut = strOut & "rcptReverseOn: " & rcptReverseOn
        strOut = strOut & "rcptReverseOff: " & rcptReverseOff
        strOut = strOut & "rcptLargeFont: " & rcptLargeFont
        strOut = strOut & "rcptRegularFont: " & rcptRegularFont
        strOut = strOut & "rcptFeedandCut: " & rcptFeedandCut
        strOut = strOut & "rcptKickDrawer: " & rcptKickDrawer

        Try

            fcnPrintReceipt(strOut)

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " (" & ex.StackTrace & ")")

        End Try

    End Sub

    Public Sub subPrintReceipt(ByVal _lngSaleID As Long, Optional ByVal _lngWSID As Long = 0, Optional ByVal _lngPCCTransID As Long = 0, Optional ByVal _strPaymentType As String = "", Optional ByVal _decCashGiven As Decimal = 0, Optional ByVal _decChangeDue As Decimal = 0)

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

            If _strPaymentType = "" Then _strPaymentType = "unknown"

            Dim strOutput As String = ""
            Dim strRegularOutput As String = ""
            Dim strCCOutput As String = ""
            Dim strSQL As String

            Dim strCCNumber$
            Dim strAuthNumber$
            Dim strItemLine As String = ""

            Dim curTotalCharge As Double = 0
            Dim curSubTotal As Double = 0
            Dim curTax As Double = 0

            Dim blnCC As Boolean = False
            Dim blnFirst As Boolean = False

            ''init
            blnFirst = False

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT tblSales.lngSaleID, tblSales.lngSaleTypeID, tblSales.lngDeptID, tblSales.dteSaleDate, tblClerks.strUserName, tlkpPaymentType.strPaymentType, tblInventory.strItemName, tblSalesDetail.lngQuantity, tblSalesDetail.curPrice, tblSalesDetail.curTotal, tlkpSalesType.strSaleType, tblSales.strCCNumber, tblSales.strCCExpDate, tblSales.strZip, tblSales.curTax, tblSales.curTotalCharge, tblSales.curSubTotal, tblSales.curDiscount, tblSales.strAuthNumber, tblSales.lngPaymentTypeID, tblDepartments.strDepartmentName " & _
                    "FROM (((tlkpSalesType INNER JOIN (tblSales LEFT JOIN tlkpPaymentType ON tblSales.lngPaymentTypeID = tlkpPaymentType.lngPaymentTypeID) ON tlkpSalesType.lngSaleTypeID = tblSales.lngSaleTypeID) INNER JOIN (tblInventory INNER JOIN tblSalesDetail ON tblInventory.lngInventoryID = tblSalesDetail.lngInventoryID) ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) INNER JOIN tblClerks ON tblSales.lngClerkID = tblClerks.lngClerkID) LEFT JOIN tblDepartments ON tblSales.lngDeptID = tblDepartments.lngDeptID " & _
                    "WHERE (((tblSales.lngSaleID)=" & _lngSaleID & "));"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using rs As OleDbDataReader = cmdDB.ExecuteReader()

                        strOutput = rcptInit & _
                                    rcptCenterJustify & strHeader & rcptNewLine & rcptNewLine

                        Do While rs.Read

firstline:
                            If blnFirst = False Then
                                If IsNumeric(rs("cursubtotal").ToString) Then curSubTotal = CType(rs("cursubtotal").ToString, Double)
                                If IsNumeric(rs("curTax").ToString) Then curTax = CType(rs("curTax").ToString, Double)
                                If IsNumeric(rs("curTotalCharge").ToString) Then curTotalCharge = CType(rs("curTotalCharge").ToString, Double)

                                'strOutput = strOutput.ToString & rcptReverseOn & "Sale ID: " & rs("lngSaleID").ToString & rcptNewLine
                                strOutput = strOutput.ToString & "Sale ID: " & rs("lngSaleID").ToString & rcptNewLine
                                strOutput = strOutput & "Date: " & rs("dteSaleDate").ToString & rcptNewLine
                                strOutput = strOutput.ToString & "Clerk: " & rs("strUserName").ToString & rcptNewLine
                                strOutput = strOutput.ToString & "Payment Type: " & rs("strPaymentType").ToString & rcptNewLine
                                strOutput = strOutput.ToString & "Sale Type: " & rs("strSaleType").ToString & rcptNewLine & rcptNewLine

                                If Len(rs("strDepartmentName").ToString) > 0 Then
                                    strOutput = strOutput.ToString & "Department: " & rs("strDepartmentName").ToString & rcptNewLine & rcptNewLine
                                End If

                                If rs("strPaymentType").ToString = "Credit Card" Then

                                    strCCNumber = rs("strCCNumber").ToString
                                    strAuthNumber = rs("strAuthNumber").ToString

                                    If Len(strCCNumber) > 4 Then strCCNumber = "XXXXXXXXXXXX" & Right(strCCNumber, 4)

                                    strOutput = strOutput.ToString & "Card #: " & strCCNumber & rcptNewLine
                                    strOutput = strOutput.ToString & "Auth #: " & strAuthNumber & rcptNewLine
                                    If Len(rs("strzip").ToString) > 0 Then strOutput = strOutput.ToString & "Zip: " & rs("strZip").ToString & rcptNewLine

                                    blnCC = True

                                End If

                                blnFirst = True

                                GoTo firstline

                            End If

                            strOutput = strOutput.ToString & rcptLeftJustify

                            strOutput = strOutput.ToString & Left(rs("strItemName").ToString, 38) & rcptNewLine

                            strItemLine = strItemLine.ToString & rs("lngQuantity").ToString & " @ "

                            If IsNumeric(rs("curprice")) Then strItemLine = strItemLine.ToString & Format(rs("curPrice").ToString, "Currency") & "    "

                            If IsNumeric(rs("curtotal")) Then strItemLine = strItemLine.ToString & Format(rs("curTotal").ToString, "Currency")

                            strOutput = strOutput.ToString & fcnFillSpaces(38 - strItemLine.Length) & strItemLine.ToString & rcptNewLine
                            strItemLine = ""
                        Loop


                        strOutput = strOutput.ToString & rcptNewLine & rcptRightJustify & "Sub Total: " & Format(curSubTotal, "currency") & rcptNewLine
                        strOutput = strOutput.ToString & "Tax: " & Format(curTax, "currency") & rcptNewLine
                        strOutput = strOutput.ToString & "Total: " & Format(curTotalCharge, "currency") & rcptNewLine

                        If _decCashGiven > 0 And _decChangeDue > 0 Then
                            strOutput = strOutput & "Cash Received: " & Format(_decCashGiven, "Currency") & rcptNewLine & _
                                                "Change Given: " & Format(_decChangeDue, "Currency") & rcptNewLine
                        End If

                        'already printed first receipt--print 2nd (if any)
                        If blnCC = True Then
                            strCCOutput = strOutput.ToString & rcptNewLine & rcptNewLine & rcptNewLine
                            strCCOutput = strCCOutput.ToString & "Signature:_____________________________"
                            strCCOutput = strCCOutput.ToString & rcptNewLine & rcptNewLine & rcptNewLine
                            strCCOutput = strCCOutput.ToString & "Phone:_____________________________"
                            strCCOutput = strCCOutput.ToString & rcptNewLine & rcptNewLine
                            strCCOutput = strCCOutput.ToString & rcptNewLine & rcptNewLine
                            'strCCOutput = strCCOutput.ToString & rcptCenterJustify & rcptNewLine & rcptNewLine & strFooter1 & rcptNewLine & rcptLargeFont & strFooter2 & rcptNewLine & rcptNewLine & rcptNewLine
                            strCCOutput = strCCOutput.ToString & rcptCenterJustify & rcptNewLine & rcptNewLine & strFooter1 & rcptNewLine & rcptLargeFont & strFooter2

                            For x = 1 To intLinesBefore
                                strCCOutput = rcptNewLine & strCCOutput
                            Next x

                            For x = 1 To intLinesAfter
                                strCCOutput = strCCOutput & rcptNewLine
                            Next x

                            If Not blnUseBell Then strCCOutput = strCCOutput.ToString & rcptFeedandCut

                        End If

                        'strOutput = strOutput.ToString & rcptCenterJustify & rcptNewLine & rcptNewLine & strFooter1 & rcptNewLine & rcptLargeFont & strFooter2 & rcptNewLine & rcptNewLine & rcptNewLine
                        strOutput = strOutput.ToString & rcptCenterJustify & rcptNewLine & rcptNewLine & strFooter1 & rcptNewLine & rcptLargeFont & strFooter2

                        For x = 1 To intLinesBefore
                            strOutput = rcptNewLine & strOutput
                        Next x

                        For x = 1 To intLinesAfter
                            strOutput = strOutput & rcptNewLine
                        Next x

                        If blnOneCCReceipt Then

                            If blnCC Then
                                fcnPrintReceipt(strCCOutput.ToString & rcptFeedandCut & rcptKickDrawer)
                            Else
                                fcnPrintReceipt(strOutput & rcptFeedandCut)
                            End If

                        Else

                            fcnPrintReceipt(strCCOutput & strOutput & rcptFeedandCut & rcptKickDrawer)

                        End If

                        rs.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr("subPrintReceipt", ex)

        End Try

    End Sub

    Public Function fcnVoidSale(ByVal _lngSaleID As Long) As Boolean

        Dim strSQL As String

        Try

            If _lngSaleID <= 0 Then
                MsgBox("Invalid sale id." & vbNewLine & vbNewLine & "Cannot void sale.")
                fcnVoidSale = False
                Exit Function
            End If

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "DELETE  " & _
                        "FROM tblSalesDetail " & _
                        "WHERE lngSaleID=" & _lngSaleID & ";"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Try
                        cmdDB.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                    strSQL = "DELETE  " & _
                            "FROM tblSales " & _
                            "WHERE lngSaleID=" & _lngSaleID & ";"

                    cmdDB.CommandText = strSQL
                    cmdDB.Parameters.Clear()

                    Try
                        cmdDB.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                    strSQL = "DELETE * " & _
                            "FROM tblTransactions " & _
                            "WHERE lngSaleID=" & _lngSaleID.ToString()

                    Using conCT As OleDbConnection = New OleDbConnection(strCTConn)

                        conCT.Open()

                        Using cmdCT As OleDbCommand = New OleDbCommand(strSQL, conCT)
                            Try
                                cmdCT.ExecuteNonQuery()
                            Catch ex As Exception

                            End Try
                        End Using

                        conCT.Close()

                    End Using

                    conDB.Close()

                End Using

                blnSaleOpen = False

            End Using

        Catch ex As Exception

            subLogErr("fcnVoidSale", ex)

        End Try

        fcnVoidSale = True

    End Function

    Public Sub subRemoveDetails(ByVal _lngSaleID As Long, ByVal _strPriceLevel As String)

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim drSaleDetails As OleDbDataReader

        Dim strInvCode As String
        Dim strSQL As String

        Dim lngItemCount As Long = 0

        Try

            If _lngSaleID <= 0 Then
                MsgBox("Invalid sale id." & vbNewLine & vbNewLine & "Cannot remove sale details.")
                Exit Sub
            End If

            strInvCode = InputBox("Enter item to remove:")

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT SUM(tblSalesDetail.lngQuantity) AS lngTotalCount " & _
                    "FROM tblSalesDetail " & _
                        "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                    "GROUP BY tblSalesDetail.lngSaleID, tblInventory.strStockCode " & _
                    "HAVING tblSalesDetail.lngSaleID=" & _lngSaleID & " AND " & _
                        "tblInventory.strStockCode='" & strInvCode & "';"

            objCommand.CommandText = strSQL

            drSaleDetails = objCommand.ExecuteReader()

            While drSaleDetails.Read

                lngItemCount += CType(drSaleDetails("lngTotalCount"), Long)

            End While

            drSaleDetails.Close()
            If lngItemCount = 1 Then


                strSQL = "DELETE tblSalesDetail.* " & _
                        "FROM tblSalesDetail " & _
                            "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                        "WHERE tblSalesDetail.lngSaleID=" & _lngSaleID & " AND " & _
                            "tblInventory.strStockCode='" & strInvCode & "';"

                strSQL = "DELETE FROM tblSalesDetail " & _
                            "WHERE     (lngSalesDetailID IN " & _
                          "(SELECT     tblSalesDetail.lngSalesDetailID " & _
                            "FROM          tblSalesDetail INNER JOIN " & _
                             "                      tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                            "WHERE      (tblSalesDetail.lngSaleID=" & _lngSaleID & ") AND (tblInventory.strStockCode='" & strInvCode & "')))"

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

            ElseIf lngItemCount > 1 Then

                If MsgBox("Remove all " & lngItemCount & " from sale?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then

                    strSQL = "UPDATE tblSalesDetail " & _
                                "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                            "SET tblSalesDetail.lngQuantity = [tblSalesDetail].[lngQuantity]-1, " & _
                                "tblSalesDetail.curTotal = (([tblSalesDetail].[lngQuantity]-1) * [tblSalesDetail].[curPrice]) " & _
                            "WHERE tblSalesDetail.lngSaleID=" & _lngSaleID & " AND " & _
                                "tblInventory.strStockCode='" & strInvCode & "';"

                    strSQL = "UPDATE    tblSalesDetail " & _
                            "SET              lngQuantity = lngQuantity - 1, curTotal = curPrice * (lngQuantity - 1) " & _
                            "WHERE     (lngSalesDetailID IN " & _
                          "(SELECT     tblSalesDetail.lngSalesDetailID " & _
                            "FROM          tblSalesDetail INNER JOIN " & _
                             "                      tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                            "WHERE      (tblSalesDetail.lngSaleID = " & _lngSaleID & ") AND (tblInventory.strStockCode = '" & strInvCode & "')))"
                Else


                    strSQL = "DELETE FROM tblSalesDetail " & _
                                "WHERE     (lngSalesDetailID IN " & _
                              "(SELECT     tblSalesDetail.lngSalesDetailID " & _
                                "FROM          tblSalesDetail INNER JOIN " & _
                                 "                      tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                                "WHERE      (tblSalesDetail.lngSaleID=" & _lngSaleID & ") AND (tblInventory.strStockCode='" & strInvCode & "')))"

                End If

                objCommand.CommandText = strSQL

                objCommand.ExecuteNonQuery()

            ElseIf lngItemCount < 1 Then
                fcnAddSaleDetail(strInvCode, _lngSaleID, _strPriceLevel, True)
            End If




            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("subRemoveDetails", ex)

        End Try

        drSaleDetails = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Public Sub subOpenDrawer(Optional ByVal blnTesting As Boolean = False)
        Try
            If blnUseDrawer Then
                Select Case blnUseBell
                    Case True
                        fcnPrintReceipt(Chr(7))
                    Case False
                        Dim prt As System.IO.Ports.SerialPort
                        prt = New System.IO.Ports.SerialPort(strDrawerPort)
                        prt.Open()
                        prt.WriteLine(Chr(27) + Chr(112) + Chr(0) + Chr(25) + Chr(250))
                        prt.Close()
                        prt.Dispose()
                        prt = Nothing

                End Select
            End If



        Catch ex As Exception
            MsgBox("It appears your system is not configured to pop open a cash drawer correctly.")
            'subLogErr("subOpenDrawer", ex)

        End Try

    End Sub

    Public Function fcnTaxRate() As Double
        'this function returns the tax rate defined in tlkpTax

        Dim strSQL As String

        Dim dblTaxRate As Double = 0

        Try

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT dblTax " & _
                        "FROM tlkpTax;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Try
                        dblTaxRate = Convert.ToDouble(cmdDB.ExecuteScalar)
                    Catch ex As Exception
                        dblTaxRate = 0
                    End Try
                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr("fcnTaxRate", ex)

        End Try

        fcnTaxRate = dblTaxRate

    End Function

    Public Sub subNoSale()

        Dim strSQL As String

        Try

            Using conDB As OleDbConnection =New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "INSERT INTO tblSales ( lngClerkID, lngSaleTypeID, lngWSID, lngStoreID, " & _
                            "dteSaleDate ) " & _
                        "SELECT " & lngClerkID & ", 6, " & lngWSID & ", " & lngStoreID & ", " & _
                            "GETDATE();"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)
                    
                    cmdDB.ExecuteNonQuery()

                End Using

                conDB.Close()

            End Using

            subOpenDrawer()

        Catch ex As Exception

            subLogErr("subNoSale", ex)

        End Try

    End Sub

    Public Function fcnInvLookup(ByVal strItemName As String) As String
        'this function returns the stock code of inventory item

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Dim strResult As String = ""

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblInventory.strStockCode " & _
                    "FROM tblInventory " & _
                    "WHERE (((tblInventory.strItemName)='" & strItemName & "'));"


            objCommand.CommandText = strSQL

            strResult = CType(objCommand.ExecuteScalar, String)
            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("fcnInvLookup", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

        fcnInvLookup = strResult.ToString
    End Function

    Public Sub subAddSpendingMoney(ByVal lngRegistrationID As Long, ByVal dblAmount As Double)

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim objConnPOS As OleDbConnection
        Dim objCommandPOS As OleDbCommand

        Dim strSQL As String
        Dim lngRecordID As Long

        Dim blnRes As Boolean = False


        'Try

        objConn = New OleDbConnection(strCTConn)
        objConnPOS = New OleDbConnection(strPOSConn)

        objConn.Open()
        objConnPOS.Open()

        objCommand = New OleDbCommand
        objCommandPOS = New OleDbCommand

        objCommand.Connection = objConn
        objCommandPOS.Connection = objConnPOS

        strSQL = "SELECT lngRecordID " & _
    "FROM tblRegistrations " & _
    "WHERE lngRegistrationID=" & lngRegistrationID & ";"

        objCommand.CommandText = strSQL

        lngRecordID = CType(objCommand.ExecuteScalar, Long)

        'insert trans
        strSQL = "INSERT INTO tblTransactions " & _
                "( lngRecordID, curPayment, strTransactionDesc, dteDateAdded, lngTransTypeID, lngPaymentTypeID, lngRegistrationID, lngWSID ) " & _
                "SELECT " & lngRecordID & ", " & dblAmount & ", 'Addl Money From POS', Now(), 27, 3, " & lngRegistrationID & ", " & lngWSID & ";"

        objCommand.CommandText = strSQL

        If objCommand.ExecuteNonQuery > 0 Then
            blnRes = True
        Else
            blnRes = False
        End If

        'insert sale
        If blnRes = True Then
            strSQL = "INSERT INTO tblSales " & _
                            "( lngStoreID, lngClerkID, lngSaleTypeID, lngPaymentTypeID, lngWSID, " & _
                            "dteSaleDate, curSubTotal, curTotalCharge, curTax ) " & _
                            "SELECT " & lngStoreID & ", " & lngClerkID & ", 9, 14, " & lngWSID & ", '" & Now & "', " & dblAmount & ", " & dblAmount & ", 0;"

            objCommandPOS.CommandText = strSQL

            If objCommandPOS.ExecuteNonQuery > 0 Then
                blnRes = True
            Else
                blnRes = False
            End If

        End If

        If Not blnRes Then
            MsgBox("The spending money did NOT save correctly.")
        Else
            MsgBox("Complete")
        End If
        objConn.Close()

        objCommand.Dispose()
        objConn.Dispose()

        'Catch ex As Exception

        'subLogErr("subAddSpendingMoney", ex)

        'End Try

        objCommand = Nothing
        objConn = Nothing

    End Sub

    Public Function fcnEditSaleDetail(ByVal _lngSaleDetailID As String, ByVal _IntQty As Int16, ByVal _lngPrice As Double, ByVal _blnReturn As Boolean) As Boolean
        'add a sale detail to the passed sale id
        'inventory code matching _strItem
        'returns true if successful

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        'Dim lngSaleDetailID As Long = 0
        'Dim lngCurrentQty As Long = 0

        Dim blnRes As Boolean = False

        'Dim intQty As Integer = _IntQty

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn


            strSQL = "UPDATE tblSalesDetail " & _
                    "SET tblSalesDetail.lngQuantity = " & _IntQty & ", " & _
                        "tblSalesDetail.curPrice = " & _lngPrice & ", " & _
                        "tblSalesDetail.curTotal = (" & _lngPrice & ")*(" & _IntQty & ") " & _
                    "WHERE tblSalesDetail.lngSalesDetailID=" & _lngSaleDetailID & ";"



            objCommand.CommandText = strSQL

            If objCommand.ExecuteNonQuery > 0 Then blnRes = True

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("fcnEditSaleDetail", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

        fcnEditSaleDetail = blnRes

    End Function

    Public Sub subRefundBalance(ByVal lngWeekID As Long, ByVal lngSiteID As Long)

        Dim strSQL As String
        Dim strWhere As String

        If MsgBox("This process creates refund transactions in CampTrak, it is not reversable.  Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try

            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                strWhere = "WHERE tblBlock.lngWeekID=" & lngWeekID & " AND tblBlock.lngSiteID=" & lngSiteID

                If strWhere = "" Then
                    strWhere = "WHERE tlkpTransType.blnSpending=True"
                Else
                    strWhere = strWhere & " AND tlkpTransType.blnSpending=True"
                End If

                strSQL = "SELECT tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                            "Sum(tblTransactions.curPayment) AS curPayments, Sum(tblTransactions.curCharge) AS curCharges, [curPayments]-[curCharges] AS curBalance, " & _
                            "tblRecords.strFirstName, tblRecords.strLastCoName " & _
                        "FROM (((tblRegistrations " & _
                            "INNER JOIN tblRecords ON tblRegistrations.lngRecordID = tblRecords.lngRecordID) " & _
                            "INNER JOIN tblTransactions ON tblRegistrations.lngRegistrationID = tblTransactions.lngRegistrationID AND " & _
                                "tblRecords.lngRecordID = tblTransactions.lngRecordID) " & _
                            "INNER JOIN tblBlock ON tblRegistrations.lngBlockID = tblBlock.lngBlockID) " & _
                            "INNER JOIN tlkpTransType ON tblTransactions.lngTransTypeID = tlkpTransType.lngTransTypeID " & _
                        strWhere & " " & _
                        "GROUP BY tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, " & _
                            "tblRecords.strFirstName, tblRecords.strLastCoName"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drReg As OleDbDataReader = cmdDB.ExecuteReader()

                        Dim decBalance As Decimal

                        While drReg.Read

                            Try
                                decBalance = Convert.ToDecimal(drReg("curBalance"))
                            Catch ex As Exception
                                decBalance = 0
                            End Try

                            If decBalance > 0 Then

                                strSQL = "INSERT INTO tblTransactions " & _
                                        "( lngRecordID, lngTransTypeID, lngRegistrationID, " & _
                                            "curCharge, " & _
                                            "dteDateAdded, " & _
                                            "strTransactionDesc ) " & _
                                        "SELECT " & CType(drReg("lngRecordID"), Long) & " AS lngRecordID, 24 AS lngTransTypeID, " & CType(drReg("lngRegistrationID"), Long) & " AS lngRegisrationID, " & _
                                            decBalance & " AS curCharge, " & _
                                            "Now() AS dteDateAdded, " & _
                                            "'store closing refund' AS strTransactionDesc;"

                                subExecuteSQL(strSQL, strCTConn)

                            End If

                        End While
                        
                        drReg.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr("subRefundBalance", ex)

        End Try

        MsgBox("Complete")
        
    End Sub
    
     Public Sub subUpdateSalesTransTotal()
        'update sales total and transaction amounts based on sale details.
        Dim conPOS As OleDbConnection
        Dim conCTMain As OleDbConnection

        Dim cmdPOS As OleDbCommand
        Dim cmdCTMain As OleDbCommand

        Dim drPOS As OleDbDataReader

        Dim strSQL As String

        Dim decTax As Decimal
        Dim decTotal As Decimal


        Try
            objSwitchboard.Cursor = Cursors.WaitCursor

            conPOS = New OleDbConnection(strPOSConn)

            conPOS.Open()

            strSQL = "SELECT dblTax " & _
                    "FROM tlkpTax"

            cmdPOS = New OleDbCommand(strSQL, conPOS)

            decTax = cmdPOS.ExecuteScalar

            'update sales subtotal, tax
            strSQL = "UPDATE    tblSales " & _
                        "SET              curSubTotal = " & _
                          "(SELECT     SUM(curTotal) AS curSaleSubtotal " & _
                            "FROM          tblSalesDetail " & _
                            "WHERE      (lngSaleID = tblSales.lngSaleID) " & _
                            "GROUP BY lngSaleID), curTax = ISNULL " & _
                          "((SELECT     SUM(tblSalesDetail_1.curTotal) AS curTotalTax " & _
                              "FROM         tblSalesDetail AS tblSalesDetail_1 INNER JOIN " & _
                                                    "tblInventory ON tblSalesDetail_1.lngInventoryID = tblInventory.lngInventoryID " & _
                              "WHERE     (tblInventory.blnTaxable <> 0) AND (tblSalesDetail_1.lngSaleID = tblSales.lngSaleID) " & _
                              "GROUP BY tblSalesDetail_1.lngSaleID), 0) * 0.06, curTotalCharge = " & _
                          "(SELECT     SUM(curTotal) AS curSaleSubtotal " & _
                            "FROM          tblSalesDetail AS tblSalesDetail_2 " & _
                            "WHERE      (lngSaleID = tblSales.lngSaleID) " & _
                            "GROUP BY lngSaleID) + ISNULL " & _
                          "((SELECT     SUM(tblSalesDetail_1.curTotal) AS curTotalTax " & _
                              "FROM         tblSalesDetail AS tblSalesDetail_1 INNER JOIN " & _
                                                    "tblInventory AS tblInventory_1 ON tblSalesDetail_1.lngInventoryID = tblInventory_1.lngInventoryID " & _
                              "WHERE     (tblInventory_1.blnTaxable <> 0) AND (tblSalesDetail_1.lngSaleID = tblSales.lngSaleID) " & _
                              "GROUP BY tblSalesDetail_1.lngSaleID), 0) * 0.06 " & _
                        "WHERE     (lngSaleID IN " & _
                          "(SELECT     tblSales_1.lngSaleID " & _
                            "FROM          (SELECT     lngSaleID, SUM(curTotal) AS SaleSubTotal " & _
                                                    "FROM          tblSalesDetail AS tblSalesDetail_1 " & _
                                                    "GROUP BY lngSaleID " & _
                                                    ") AS qrySaleSubTotals INNER JOIN " & _
                                                   "tblSales AS tblSales_1 ON qrySaleSubTotals.lngSaleID = tblSales_1.lngSaleID AND  " & _
                                                   "qrySaleSubTotals.SaleSubTotal <> ISNULL(tblSales_1.curSubTotal, 0)))"

            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & strSQL

            cmdPOS.CommandText = strSQL

            cmdPOS.ExecuteNonQuery()

            'update transactions associated w/ sales
            'open datareader of sales totals, trans id
            strSQL = "SELECT lngSaleID, lngTransactionID, " & _
                        "curTotalCharge " & _
                    "FROM tblSales " & _
                    "WHERE lngTransactionID > 0"

            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & strSQL

            cmdPOS.CommandText = strSQL

            drPOS = cmdPOS.ExecuteReader

            conCTMain = New OleDbConnection(strCTConn)

            conCTMain.Open()

            cmdCTMain = New OleDbCommand
            cmdCTMain.Connection = conCTMain

            While drPOS.Read

                If IsDBNull(drPOS("curTotalCharge")) Then
                    decTotal = 0
                Else
                    decTotal = CType(drPOS("curTotalCharge"), Decimal)
                End If
                strSQL = "UPDATE tblTransactions " & _
                        "SET curCharge=" & decTotal & " " & _
                        "WHERE lngTransTypeID = 6 and lngTransactionID=" & drPOS("lngTransactionID")

                cmdCTMain.CommandText = strSQL

                cmdCTMain.ExecuteNonQuery()

            End While

            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & strSQL

            conCTMain.Close()

            drPOS.Close()

            conPOS.Close()

            cmdPOS.Dispose()
            cmdCTMain.Dispose()
            conPOS.Dispose()
            conCTMain.Dispose()

        Catch ex As Exception
            subLogErr("subUpdateSalesTransTotal", ex)

        End Try

        drPOS = Nothing
        cmdPOS = Nothing
        cmdCTMain = Nothing
        conPOS = Nothing
        conCTMain = Nothing

        objSwitchboard.Cursor = Cursors.Default

        MsgBox("Sales totals updated.")

    End Sub

    Public Sub subRecalcTaxTotals()

        Try

            Dim strSQL As String

            Using conPOS As New OleDbConnection(strPOSConn)

                conPOS.Open()

                strSQL = "UPDATE tblSalesDetail " & _
                        "SET curTotal = ROUND(ISNULL(curTotal, 0), 2) " & _
                        "WHERE (ISNULL(curTotal, 0) <> ROUND(ISNULL(curTotal, 0), 2))"

                Using cmdPOS As New OleDbCommand(strSQL, conPOS)

                    'update line totals for sales detail (round existing value)
                    cmdPOS.ExecuteNonQuery()

                    'update sub-total for sale (sum sale details)
                    strSQL = "UPDATE tblSales " & _
                            "SET curSubTotal = " & _
                                "(SELECT SUM(ISNULL(curTotal, 0)) AS curSubTotal " & _
                                "FROM tblSalesDetail " & _
                                "WHERE tblSalesDetail.lngSaleID=tblSales.lngSaleID " & _
                                "GROUP BY lngSaleID) " & _
                            "WHERE (lngSaleID IN " & _
                                "(SELECT tblSales_1.lngSaleID " & _
                                "FROM tblSales AS tblSales_1 " & _
                                    "INNER JOIN " & _
                                        "(SELECT lngSaleID, " & _
                                            "SUM(ISNULL(curTotal, 0)) AS curSubTotal " & _
                                        "FROM tblSalesDetail AS tblSalesDetail_1 " & _
                                        "GROUP BY lngSaleID) AS qrySubTotal " & _
                                        "ON tblSales_1.lngSaleID = qrySubTotal.lngSaleID AND " & _
                                            "ISNULL(tblSales_1.curSubTotal, 0) <> ISNULL(qrySubTotal.curSubTotal, 0)))"

                    cmdPOS.CommandText = strSQL

                    cmdPOS.ExecuteNonQuery()

                    'update tax for sale (round existing value)
                    strSQL = "UPDATE tblSales " & _
                            "SET curTax = ROUND(ISNULL(curTax, 0), 2) " & _
                            "WHERE (ISNULL(curTax, 0) <> ROUND(ISNULL(curTax, 0), 2))"

                    cmdPOS.CommandText = strSQL

                    cmdPOS.ExecuteNonQuery()

                    'update grand total for sale (subtotal+tax)
                    strSQL = "UPDATE tblSales " & _
                            "SET curTotalCharge = ISNULL(curSubTotal, 0) + ISNULL(curTax, 0) " & _
                            "WHERE (ISNULL(curTotalCharge, 0) <> ISNULL(curSubTotal, 0) + ISNULL(curTax, 0))"

                    cmdPOS.CommandText = strSQL

                    cmdPOS.ExecuteNonQuery()

                    MsgBox("Sales updated.")

                End Using

                conPOS.Close()

            End Using

        Catch ex As Exception
            subLogErr("subRecalcTaxTotals", ex)

        End Try

    End Sub

End Module
