Imports System.Data.OleDb
Public Class frmInventorySetup
    Dim blnDirty As Boolean = False
    Dim blnLoading As Boolean = False
   

    Private Sub txtControls_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.TextChanged, txtDescription.TextChanged, txtItemName.TextChanged, txtQuantityToDeplete.TextChanged, txtReorderLevel.TextChanged, txtResidentPercentage.TextChanged, txtRetailPercentage.TextChanged, txtStockCode.TextChanged, txtSummerPercentage.TextChanged
        blnDirty = True
        Me.Text = "Inventory Setup*"
    End Sub

    Private Sub subResetForm()
        blnDirty = False
        Me.Text = "Inventory Setup"
    End Sub
    Private Sub frmInventorySetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' load inventory list
        subLoadInventory(Me.chkFilterInactive.Checked)
        'populate category pull down
        subLoadCategories()
        'load vendor combo
        subLoadVendors()

        subChangeState(False)
    End Sub

    Private Sub subLoadInventory(ByVal blnIncludeInactive As Boolean, Optional ByVal strStockCode As String = "0", _
                                Optional ByVal lngCategoryID As Long = 0)

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim dr As OleDbDataReader

        Dim cbo As clsCboItem

        Dim strSQL As String
        Dim strWhere As String = ""

        Select Case blnIncludeInactive
            Case False
                If blnUseSQLServer Then
                    strWhere = strWhere & "(((tblInventory.blnInactive)=" & CType(blnIncludeInactive, Int16) & ")) "

                Else
                    strWhere = strWhere & "(((tblInventory.blnInactive)=" & blnIncludeInactive & ")) "
                End If

            Case True
                If blnUseSQLServer Then
                    strWhere = strWhere & "((((tblInventory.blnInactive) = 1)) or (((tblInventory.blnInactive) = 0)))"
                Else
                    strWhere = strWhere & "((((tblInventory.blnInactive) = True)) or (((tblInventory.blnInactive) = False)))"
                End If

        End Select

        Select Case lngCategoryID
            Case 0
                'do nothing
            Case Else

                If strWhere.Length > 0 Then
                    strWhere = strWhere & " and "
                End If
                strWhere = strWhere & "lngInvCategoryID= " & lngCategoryID

        End Select

        Select Case strStockCode
            Case "0"
                'do nothing
            Case Else
                If strWhere.Length > 0 Then
                    strWhere = strWhere & " and "
                End If
                strWhere = strWhere & "strStockCode='" & strStockCode & "'"

        End Select

        Try

            Me.lstInventory.Items.Clear()

            objConn = New OleDbConnection

            objConn.ConnectionString = strPOSConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblInventory.lngInventoryID, tblInventory.strItemName, tblInventory.strStockCode FROM tblInventory WHERE " & strWhere & " ORDER BY tblInventory.strItemName, tblInventory.strStockCode;"

            objCommand.CommandText = strSQL

            dr = objCommand.ExecuteReader

            While dr.Read

                cbo = New clsCboItem(CType(dr("lngInventoryID"), Long), CType(dr("strItemName"), String))

                Me.lstInventory.Items.Add(cbo)

            End While

            dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadInventory", ex)

        End Try
    End Sub

    Private Sub RequeryInventoryList(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFilterInactive.CheckedChanged, cboFilterCategory.SelectedIndexChanged, txtFilterStockCode.TextChanged

        If IsNothing(Me.cboFilterCategory.SelectedItem) Then

            subLoadInventory(Me.chkFilterInactive.Checked, NZ(Me.txtFilterStockCode.Text, "0"), 0)

        Else

            subLoadInventory(Me.chkFilterInactive.Checked, NZ(Me.txtFilterStockCode.Text, "0"), CType(NZ(CType(Me.cboFilterCategory.SelectedItem, clsCboItem).ID, "0"), Long))

        End If

    End Sub

    Private Sub subLoadCategories()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT lngInvCategoryID, " & _
                        "strInvCategory " & _
                    "FROM tblInvCodeCategory " & _
                    "ORDER BY strInvCategory;"

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                Me.cboFilterCategory.Items.Add(New clsCboItem(CType(Dr("lngInvCategoryID"), Long), CType(Dr("strInvCategory"), String)))
                Me.cboCategory.Items.Add(New clsCboItem(CType(Dr("lngInvCategoryID"), Long), CType(Dr("strInvCategory"), String)))

            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadCategories", ex)

        End Try

    End Sub

    Private Sub subLoadVendors()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tlkpVendor.lngVendorID, tlkpVendor.strVendorName FROM tlkpVendor ORDER BY tlkpVendor.strVendorName;"


            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                Me.cboVendor.Items.Add(New clsCboItem(CType(Dr("lngVendorID"), Long), CType(NZ(Dr("strVendorName")), String)))

            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadVendors", ex)

        End Try

    End Sub

    Private Sub subLoadInventory()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim Dr As OleDbDataReader

        Dim strSQL As String
        Dim lngInventoryID As Long = CType(NZ(CType(Me.lstInventory.SelectedItem, clsCboItem).ID, "0"), Long)
        blnLoading = True
        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblInventory.blnOnSale, tblInventory.blnTaxable, tblInventory.blnNonStock, tblInventory.blnAutoPrice, tblInventory.blnSpending, tblInventory.intReorderQty, tblInventory.intCurrentQty, tblInventory.intDepleteQty, tblInventory.intListMthd, tblInventory.intDisc1Mthd, tblInventory.intDisc2Mthd, tblInventory.intDisc3Mthd, tblInventory.lngInventoryID, tblInventory.lngVendorID, tblInventory.lngInvCategoryID, tblInventory.dblListPct, tblInventory.dblDisc1Pct, tblInventory.dblDisc2Pct, tblInventory.dblDsic3Pct, tblInventory.curCost, tblInventory.curListPrice, tblInventory.curDiscount1, tblInventory.curDiscount2, tblInventory.curDiscount3, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.strImg, tblInventory.strDescription, tblInventory.blnInactive, tblInventory.strOnlineName, tblInventory.dteLastUL FROM tblInventory Where lngInventoryID=" & lngInventoryID

            objCommand.CommandText = strSQL

            Dr = objCommand.ExecuteReader

            While Dr.Read

                Me.txtStockCode.Text = Dr("strStockCode").ToString
                Me.txtItemName.Text = Dr("stritemname").ToString
                'blnOnSale
                Me.chkTaxable.Checked = CType(Dr("blnTaxable").ToString, Boolean)
                Me.chkNonStock.Checked = CType(Dr("blnNonStock").ToString, Boolean)
                'blnAutoPrice
                Me.chkSpendingMoney.Checked = CType(Dr("blnSpending").ToString, Boolean)
                Me.txtReorderLevel.Text = Dr("intReorderQty").ToString
                Me.txtQuantityToDeplete.Text = Dr("intDepleteQty").ToString
                Select Case Dr("intListMthd").ToString
                    Case "1" 'Manual
                        Me.txtListPrice.Enabled = True
                        Me.radRetailManual.Checked = True
                        Me.radRetailMarginfromCost.Checked = False
                        Me.radRetailMarkupfromCost.Checked = False
                    Case "2" '% markup from cost
                        Me.txtListPrice.Enabled = False
                        Me.radRetailManual.Checked = False
                        Me.radRetailMarginfromCost.Checked = True
                        Me.radRetailMarkupfromCost.Checked = False
                    Case "3" 'Margin from cost
                        Me.txtListPrice.Enabled = False
                        Me.radRetailManual.Checked = False
                        Me.radRetailMarginfromCost.Checked = False
                        Me.radRetailMarkupfromCost.Checked = True
                End Select

                Select Case Dr("intDisc1Mthd").ToString
                    Case "1" 'Manual
                        Me.txtSummerStaffPrice.Enabled = True
                        Me.radSummerManual.Checked = True
                        Me.radSummerMarginfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = False
                    Case "2" '% markup from cost
                        Me.txtSummerStaffPrice.Enabled = False
                        Me.radSummerManual.Checked = False
                        Me.radSummerMarginfromCost.Checked = True
                        Me.radSummerMarkupfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = False
                    Case "3" 'Margin from cost
                        Me.txtSummerStaffPrice.Enabled = False
                        Me.radSummerManual.Checked = False
                        Me.radSummerMarginfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = True
                        Me.radSummerMarkupfromCost.Checked = False
                    Case "4" 'Markdown from list
                        Me.txtSummerStaffPrice.Enabled = False
                        Me.radSummerManual.Checked = False
                        Me.radSummerMarginfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = False
                        Me.radSummerMarkupfromCost.Checked = True
                End Select


                Select Case Dr("intDisc2Mthd").ToString
                    Case "1" 'Manual
                        Me.txtResidentStaffPrice.Enabled = True
                        Me.radResidentManual.Checked = True
                        Me.radResidentMarginfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = False
                    Case "2" '% markup from cost
                        Me.txtResidentStaffPrice.Enabled = False
                        Me.radResidentManual.Checked = False
                        Me.radResidentMarginfromCost.Checked = True
                        Me.radResidentMarkupfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = False
                    Case "3" 'Margin from cost
                        Me.txtResidentStaffPrice.Enabled = False
                        Me.radResidentManual.Checked = False
                        Me.radResidentMarginfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = True
                        Me.radResidentMarkupfromCost.Checked = False
                    Case "4" 'Markdown from list
                        Me.txtResidentStaffPrice.Enabled = False
                        Me.radResidentManual.Checked = False
                        Me.radResidentMarginfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = False
                        Me.radResidentMarkupfromCost.Checked = True
                End Select
                'intDisc3Mthd

                Me.txtInventoryID.Text = Dr("lngInventoryID").ToString
                subSetSelectedIndex(Me.cboVendor, Dr("lngVendorID").ToString)
                subSetSelectedIndex(Me.cboCategory, Dr("lngInvCategoryID").ToString)
                Me.txtRetailPercentage.Text = Dr("dblListPct").ToString
                Me.txtSummerPercentage.Text = Dr("dblDisc1Pct").ToString
                Me.txtResidentPercentage.Text = Dr("dblDisc2Pct").ToString
                'dblDsic3Pct
                txtCost.Text = CType(NZ(Dr("curcost").ToString, "0"), Decimal).ToString("C")
                Me.txtListPrice.Text = CType(NZ(Dr("curListPrice").ToString, "0"), Decimal).ToString("C")
                Me.txtSummerStaffPrice.Text = CType(NZ(Dr("curDiscount1").ToString, "0"), Decimal).ToString("C")
                Me.txtResidentStaffPrice.Text = CType(NZ(Dr("curDiscount2").ToString, "0"), Decimal).ToString("C")
                'curDiscount3
                Me.txtDescription.Text = Dr("strDescription").ToString
                Me.chkInactive.Checked = CType(Dr("blnInactive").ToString, Boolean)
                'strImg
                'strOnlineName
                'dteLastUL
            End While

            Dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            Dr = Nothing
            objCommand = Nothing
            objConn = Nothing

            blnDirty = False
            blnLoading = False
            Me.Text = "Inventory Setup"

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadInventory", ex)

        End Try
    End Sub

    Private Sub lstInventory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInventory.SelectedIndexChanged
        subLoadInventory()
        Me.lblInvLevel.Text = "Current Inventory level for this store: " & fcnGetCurrentInventory(lngStoreID, CType(NZ(CType(Me.lstInventory.SelectedItem, clsCboItem).ID, "0"), Long))
        subChangeState(True)
    End Sub

    Private Sub subChangeState(ByVal blnEditable As Boolean)
        Me.txtItemName.Enabled = blnEditable
        Me.txtStockCode.Enabled = blnEditable
        Me.txtCost.Enabled = blnEditable
        Me.txtDescription.Enabled = blnEditable
        Me.txtQuantityToDeplete.Enabled = blnEditable
        Me.txtReorderLevel.Enabled = blnEditable
        Me.txtResidentPercentage.Enabled = blnEditable
        Me.txtRetailPercentage.Enabled = blnEditable
        Me.txtStockCode.Enabled = blnEditable
        Me.txtSummerPercentage.Enabled = blnEditable

        Me.chkInactive.Enabled = blnEditable
        Me.chkNonStock.Enabled = blnEditable
        Me.chkSpendingMoney.Enabled = blnEditable
        Me.chkTaxable.Enabled = blnEditable

        Me.grpResidentStaffMethod.Enabled = blnEditable
        Me.grpRetailMethod.Enabled = blnEditable
        Me.grpSummerStaffMethod.Enabled = blnEditable

        Me.cboCategory.Enabled = blnEditable
        Me.cboVendor.Enabled = blnEditable


    End Sub

    Private Sub radRetailManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radResidentManual.CheckedChanged, radResidentMarginfromCost.CheckedChanged, radResidentMarkdownfromRetail.CheckedChanged, radResidentMarkupfromCost.CheckedChanged, radRetailManual.CheckedChanged, radRetailMarginfromCost.CheckedChanged, radRetailMarkupfromCost.CheckedChanged, radSummerManual.CheckedChanged, radSummerMarginfromCost.CheckedChanged, radSummerMarkdownfromRetail.CheckedChanged, radSummerMarkupfromCost.CheckedChanged
        If blnLoading Then Exit Sub

        If Me.radRetailManual.Checked Then
            Me.txtListPrice.Enabled = True
            Me.txtListPrice.Focus()
            Me.txtListMthd.Text = "1"
        End If

        If Me.radRetailMarginfromCost.Checked Then
            Me.txtListPrice.Enabled = False
            Me.txtListMthd.Text = "3"
            Me.txtListPrice.Text = CType(NZ((CType(Me.txtCost.Text, Decimal) / (1 - CType(Me.txtRetailPercentage.Text, Decimal))), "0"), Decimal).ToString("C")
        End If

        If Me.radRetailMarkupfromCost.Checked Then
            Me.txtListPrice.Enabled = False
            Me.txtListMthd.Text = "2"
            Me.txtListPrice.Text = CType(NZ(CType(Me.txtCost.Text, Decimal) + (CType(Me.txtCost.Text, Decimal) * CType(Me.txtRetailPercentage.Text, Decimal)), "0"), Decimal).ToString("C")
        End If


        If Me.radResidentManual.Checked Then
            Me.txtResidentStaffPrice.Enabled = True
            Me.txtListMthd.Text = "1"
            Me.txtResidentStaffPrice.Focus()
        End If

        If Me.radResidentMarginfromCost.Checked Then
            Me.txtResidentStaffPrice.Enabled = False
            Me.txtResidentStaffPrice.Text = CType(NZ((CType(Me.txtCost.Text, Decimal) / (1 - CType(Me.txtResidentPercentage.Text, Decimal))), "0"), Decimal).ToString("C")
            Me.txtListMthd.Text = "3"
        End If

        If Me.radResidentMarkdownfromRetail.Checked Then
            Me.txtResidentStaffPrice.Enabled = False
            Me.txtResidentStaffPrice.Text = CType(CType(Me.txtListPrice.Text, Decimal) * (1 - CType(Me.txtResidentPercentage.Text, Decimal)), Decimal).ToString("C")
            Me.txtListMthd.Text = "4"
        End If

        If Me.radResidentMarkupfromCost.Checked Then
            Me.txtResidentStaffPrice.Enabled = False
            Me.txtResidentStaffPrice.Text = CType(CType(Me.txtCost.Text, Decimal) + (CType(Me.txtCost.Text, Decimal) * CType(Me.txtResidentPercentage.Text, Decimal)), Decimal).ToString("C")
            Me.txtListMthd.Text = "2"
        End If


        If Me.radSummerManual.Checked Then
            Me.txtSummerStaffPrice.Enabled = True
            Me.txtSummerMthd.Text = "1"
            Me.txtSummerStaffPrice.Focus()
        End If

        If Me.radSummerMarginfromCost.Checked Then
            Me.txtSummerStaffPrice.Enabled = False
            Me.txtSummerMthd.Text = "3"
            Me.txtSummerStaffPrice.Text = CType(NZ((CType(Me.txtCost.Text, Decimal) / (1 - CType(Me.txtSummerPercentage.Text, Decimal))), "0"), Decimal).ToString("C")
        End If

        If Me.radSummerMarkdownfromRetail.Checked Then
            Me.txtSummerStaffPrice.Enabled = False
            Me.txtSummerMthd.Text = "4"
            Me.txtSummerStaffPrice.Text = CType(CType(Me.txtListPrice.Text, Decimal) * (1 - CType(Me.txtSummerPercentage.Text, Decimal)), Decimal).ToString("C")
        End If

        If Me.radSummerMarkupfromCost.Checked Then
            Me.txtSummerStaffPrice.Enabled = False
            Me.txtSummerMthd.Text = "2"
            Me.txtSummerStaffPrice.Text = CType(CType(Me.txtCost.Text, Decimal) + (CType(Me.txtCost.Text, Decimal) * CType(Me.txtSummerPercentage.Text, Decimal)), Decimal).ToString("C")
        End If

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        blnLoading = True
        Me.txtCost.Text = ""
        Me.txtDescription.Text = ""
        Me.txtFilterStockCode.Text = ""
        Me.txtInventoryID.Text = ""
        Me.txtItemName.Text = ""
        Me.txtListPrice.Text = ""
        Me.txtQuantityToDeplete.Text = ""
        Me.txtReorderLevel.Text = ""
        Me.txtResidentPercentage.Text = ""
        Me.txtResidentStaffPrice.Text = ""
        Me.txtRetailPercentage.Text = ""
        Me.txtStockCode.Text = ""

        Me.txtSummerPercentage.Text = ""
        Me.txtSummerStaffPrice.Text = ""

        Me.radRetailManual.Checked = False
        Me.radRetailMarginfromCost.Checked = False
        Me.radRetailMarkupfromCost.Checked = False

        Me.radSummerManual.Checked = False
        Me.radSummerMarginfromCost.Checked = False
        Me.radSummerMarkdownfromRetail.Checked = False
        Me.radSummerMarkupfromCost.Checked = False

        Me.radResidentMarkupfromCost.Checked = False
        Me.radResidentMarkdownfromRetail.Checked = False
        Me.radResidentMarginfromCost.Checked = False
        Me.radResidentManual.Checked = False

        Me.chkInactive.Checked = False
        Me.chkNonStock.Checked = False
        Me.chkSpendingMoney.Checked = False
        Me.chkTaxable.Checked = False
        Me.cboVendor.SelectedIndex = -1
        Me.cboCategory.SelectedIndex = -1
        blnLoading = False
        subChangeState(True)
        Me.txtStockCode.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'count use first
        Dim intCount As Integer = 0
        Dim intInvID As Integer = 0

        intCount = dCount("lngSalesDetailID", "tblSalesDetail", "lngInventoryID=" & Me.txtInventoryID.Text, strPOSConn)

        If intCount > 0 Then
            MsgBox("You cannot delete this item because it is used in sales details.  Please set as inactive.")
            Exit Sub
        End If

        If MsgBox("Are you sure you wish to delete this inventory item?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String = ""

        Try

            intInvID = CType(Me.txtInventoryID.Text, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "DELETE  FROM tblInventory  WHERE (((lngInventoryID)=" & intInvID & "));"

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            btnNew_Click(sender, e)
            subLoadInventory(Me.chkFilterInactive.Checked)

        Catch ex As Exception

            subLogErr(Me.Name & ".btnDelete_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing
        btnNew_Click(Me, e)
        subResetForm()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                Dim lngInvID As Long

                Try
                    lngInvID = Convert.ToInt32(txtInventoryID.Text)
                Catch ex As Exception
                    lngInvID = 0
                End Try

                Dim strSQL As String = ""

                If lngInvID > 0 Then

                    strSQL = "UPDATE tblInventory SET " & _
                              "tblInventory.blnOnSale = 0, tblInventory.blnTaxable=?, tblInventory.blnNonStock=?, tblInventory.blnAutoPrice = 0, tblInventory.blnSpending=?, tblInventory.blnInactive=?, " & _
                                "tblInventory.intReorderQty=?, tblInventory.intCurrentQty = 0, tblInventory.intDepleteQty=?, tblInventory.intListMthd=?, tblInventory.intDisc1Mthd=?, tblInventory.intDisc2Mthd=?, tblInventory.lngVendorID=?, tblInventory.lngInvCategoryID=?, " & _
                                "tblInventory.dblListPct=?, tblInventory.dblDisc1Pct=?, tblInventory.dblDisc2Pct=?, tblInventory.curCost=?, tblInventory.curListPrice=?, tblInventory.curDiscount1=?, tblInventory.curDiscount2=?, " & _
                                "tblInventory.strStockCode=?, tblInventory.strItemName=?, tblInventory.strDescription=? " & _
                            "WHERE tblInventory.lngInventoryID=" & lngInvID.ToString()
                Else

                    strSQL = "SELECT lngInventoryID " & _
                            "FROM tblInventory " & _
                            "WHERE strStockCode=?"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        cmdDB.Parameters.Add(New OleDbParameter("@strStockCode", txtStockCode.Text))

                        lngInvID = 0

                        Try
                            lngInvID = Convert.ToInt32(cmdDB.ExecuteScalar())
                        Catch ex As Exception
                            lngInvID = 0
                        End Try

                    End Using

                    If lngInvID > 0 Then
                        MessageBox.Show("Stock codes must be unique!" & vbNewLine & "Please enter a different stock code, or edit the existing inventory item.")
                        txtStockCode.Focus()
                        Return
                    End If

                    strSQL = "INSERT INTO tblInventory " & _
                                "(blnOnSale, blnTaxable, blnNonStock, blnAutoPrice, blnSpending, blnInactive, " & _
                                    "intReorderQty, intCurrentQty, intDepleteQty, intListMthd, intDisc1Mthd, intDisc2Mthd, lngVendorID, lngInvCategoryID, " & _
                                    "dblListPct, dblDisc1Pct, dblDisc2Pct, curCost, curListPrice, curDiscount1, curDiscount2, " & _
                                    "strStockCode, strItemName, strDescription ) " & _
                                "SELECT 0, ?, ?, 0, ?, ?, " & _
                                    "?, 0, ?, ?, ?, ?, ?, ?, " & _
                                    "?, ?, ?, ?, ?, ?, ?, " & _
                                    "?, ?, ?"
                    End If

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        'add parameters
                        cmdDB.Parameters.Add(New OleDbParameter("@blnTaxable", chkTaxable.Checked))
                        cmdDB.Parameters.Add(New OleDbParameter("@blnNonStock", chkNonStock.Checked))
                        cmdDB.Parameters.Add(New OleDbParameter("@blnSpending", chkSpendingMoney.Checked))
                        cmdDB.Parameters.Add(New OleDbParameter("@blnInactive", chkInactive.Checked))

                        Dim intReorderQty As Int32
                        Dim intDepleteQty As Int32
                        Dim intListMthd As Int32
                        Dim intDisc1Mthd As Int32
                        Dim intDisc2Mthd As Int32
                        Dim lngVendorID As Int32
                        Dim lngInvCategoryID As Int32

                        Dim dblListPct As Double
                        Dim dblDisc1Pct As Double
                        Dim dblDisc2Pct As Double
                        Dim curCost As Double
                        Dim curListPrice As Double
                        Dim curDiscount1 As Double
                        Dim curDiscount2 As Double

                        Try
                            intReorderQty = Convert.ToInt32(txtReorderLevel.Text)
                        Catch ex As Exception
                            intReorderQty = 0
                        End Try

                        Try
                            intDepleteQty = Convert.ToInt32(txtQuantityToDeplete.Text)
                        Catch ex As Exception
                            intDepleteQty = 0
                        End Try

                        Try
                            intListMthd = Convert.ToInt32(txtListMthd.Text)
                        Catch ex As Exception
                            intListMthd = 0
                        End Try

                        Try
                            intDisc1Mthd = Convert.ToInt32(txtSummerMthd.Text)
                        Catch ex As Exception
                            intDisc1Mthd = 0
                        End Try

                        Try
                            intDisc2Mthd = Convert.ToInt32(txtResidentMthd.Text)
                        Catch ex As Exception
                            intDisc2Mthd = 0
                        End Try

                        Try
                            lngVendorID = Convert.ToInt32(CType(Me.cboVendor.SelectedItem, clsCboItem).ID)
                        Catch ex As Exception
                            lngVendorID = 0
                        End Try

                        Try
                            lngInvCategoryID = Convert.ToInt32(CType(Me.cboCategory.SelectedItem, clsCboItem).ID)
                        Catch ex As Exception
                            lngInvCategoryID = 0
                        End Try

                        Try
                            dblListPct = Convert.ToDouble(txtRetailPercentage.Text)
                        Catch ex As Exception
                            dblListPct = 0
                        End Try

                        Try
                            dblDisc1Pct = Convert.ToDouble(txtSummerPercentage.Text)
                        Catch ex As Exception
                            dblDisc1Pct = 0
                        End Try

                        Try
                            dblDisc2Pct = Convert.ToDouble(txtResidentPercentage.Text)
                        Catch ex As Exception
                            dblDisc2Pct = 0
                        End Try

                        Try
                            curCost = Double.Parse(txtCost.Text, System.Globalization.NumberStyles.Currency)
                        Catch ex As Exception
                            curCost = 0
                        End Try

                        Try
                            curListPrice = Double.Parse(txtListPrice.Text, System.Globalization.NumberStyles.Currency)
                        Catch ex As Exception
                            curListPrice = 0
                        End Try

                        Try
                            curDiscount1 = Double.Parse(txtSummerStaffPrice.Text, System.Globalization.NumberStyles.Currency)
                        Catch ex As Exception
                            curDiscount1 = 0
                        End Try

                        Try
                            curDiscount2 = Double.Parse(txtResidentStaffPrice.Text, System.Globalization.NumberStyles.Currency)
                        Catch ex As Exception
                            curDiscount2 = 0
                        End Try

                        cmdDB.Parameters.Add(New OleDbParameter("@intReorderQty", intReorderQty))
                        cmdDB.Parameters.Add(New OleDbParameter("@intDepleteQty", intDepleteQty))
                        cmdDB.Parameters.Add(New OleDbParameter("@intListMthd", intListMthd))
                        cmdDB.Parameters.Add(New OleDbParameter("@intDisc1Mthd", intDisc1Mthd))
                        cmdDB.Parameters.Add(New OleDbParameter("@intDisc2Mthd", intDisc2Mthd))
                        cmdDB.Parameters.Add(New OleDbParameter("@lngVendorID", lngVendorID))
                        cmdDB.Parameters.Add(New OleDbParameter("@lngInvCategoryID", lngInvCategoryID))
                        cmdDB.Parameters.Add(New OleDbParameter("@dblListPct", dblListPct))
                        cmdDB.Parameters.Add(New OleDbParameter("@dblDisc1Pct", dblDisc1Pct))
                        cmdDB.Parameters.Add(New OleDbParameter("@dblDisc2Pct", dblDisc2Pct))
                        cmdDB.Parameters.Add(New OleDbParameter("@curCost", curCost))
                        cmdDB.Parameters.Add(New OleDbParameter("@curListPrice", curListPrice))
                        cmdDB.Parameters.Add(New OleDbParameter("@curDiscount1", curDiscount1))
                        cmdDB.Parameters.Add(New OleDbParameter("@curDiscount2", curDiscount2))

                        cmdDB.Parameters.Add(New OleDbParameter("@strStockCode", txtStockCode.Text))
                        cmdDB.Parameters.Add(New OleDbParameter("@strItemName", txtItemName.Text))
                        cmdDB.Parameters.Add(New OleDbParameter("@strDescription", txtDescription.Text))

                        cmdDB.ExecuteNonQuery()

                    End Using

                    conDB.Close()

            End Using

            btnNew_Click(sender, e)
            subLoadInventory(Me.chkFilterInactive.Checked)

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSave_Click", ex)

        End Try

    End Sub

    Private Sub txtCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCost.Click
        'Me.txtCost.Text = Me.txtCost.DollarValue
    End Sub

    Private Sub btnLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLabels.Click
        Dim lngInputLabel As Long

        If Me.txtInventoryID.Text.Length = 0 Then Exit Sub

        Dim strIn = InputBox("Please enter starting Label (0 for full sheet)", , "0")

        If strIn = "" Or Not IsNumeric(strIn) Then
            MsgBox("Invalid Starting Label!!!", MsgBoxStyle.Critical, "CampTrak")
        Else
            lngInputLabel = CLng(strIn)
        End If

        Dim frm As New frmItemLablePreview
        frm.lngInvID = CLng(Me.txtInventoryID.Text)
        frm.lngInputLabel = lngInputLabel
        frm.Show()

    End Sub

    Private Sub btnAdjustQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustQty.Click

        Using objAdj As frmAdjustInventory = New frmAdjustInventory()
            objAdj.txtStockCode.Text = txtStockCode.Text
            objAdj.subLoadInventory()
            objAdj.ShowDialog()
        End Using

        Me.lblInvLevel.Text = "Current Inventory level for this store: " & fcnGetCurrentInventory(lngStoreID, CType(NZ(CType(Me.lstInventory.SelectedItem, clsCboItem).ID, "0"), Long))

    End Sub

End Class