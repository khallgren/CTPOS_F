Imports Xceed.Grid
Imports System.Data.OleDb
Imports CTPOS_F.clsGlobalEnum


Public Class frmCashSales

    Public blnComplete As Boolean

    Public Sub New()

        Try
            'commented as we are using trial version.
            'Licenser.LicenseKey = "GRD25-G17KB-F7BMP-U4JA"

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        Catch ex As Exception

            subLogErr(Me.Name & ".New", ex)

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Try

            subCloseCashSales()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnClose_Click", ex)

        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        Const WM_KEYDOWN As Integer = &H100
        Const WM_SYSKEYDOWN As Integer = &H104

        If ((msg.Msg = WM_KEYDOWN) Or (msg.Msg = WM_SYSKEYDOWN)) Then
            Select Case (keyData)

                Case Keys.F6
                    '
                Case (Keys.Alt Or Keys.F7)
                    frmSwitchboard.tskInventoryLookup.DoClick()
                Case (Keys.Alt Or Keys.F8)
                    frmSwitchboard.tskNoSale.DoClick()
                Case (Keys.Alt Or Keys.F9)
                    frmSwitchboard.tskCashSales.DoClick()
                Case Keys.F12
                    frmSwitchboard.tskLogout.DoClick()
                Case Keys.F1
                    'tony
                    If Me.chkBeginSale.Enabled = True Then
                        Me.chkBeginSale.Checked = True
                        Me.chkBeginSale.Checked = True
                        subBeginSale()
                    End If
                Case Keys.F2
                    If Me.btnVoid.Enabled Then
                        Me.btnVoid.PerformClick()
                    End If
                Case Keys.F3
                    If Me.btnAddItems.Enabled Then

                        Me.btnAddItems.PerformClick()
                    End If
                Case Keys.F4
                    If Me.btnRemoveItems.Enabled Then
                        Me.btnRemoveItems.PerformClick()
                    End If
                Case Keys.F5
                    'do nothing
                Case Keys.F6
                    If Me.radCash.Enabled Then
                        Me.radCash.Checked = True
                        Me.radCash.PerformClick()
                    End If
                Case Keys.F7
                    If Me.radCheck.Enabled = True Then
                        Me.radCheck.Checked = True
                        Me.radCheck.PerformClick()
                    End If
                Case Keys.F8
                    If Me.radCharge.Enabled Then
                        Me.radCharge.Checked = True
                        Me.radCharge.PerformClick()
                    End If
                Case Keys.F9
                    If Me.radSpendingMoney.Enabled = True Then
                        Me.radSpendingMoney.Checked = True
                        Me.radSpendingMoney.PerformClick()
                    End If
                Case Keys.F10
                    If Me.radStaffChg.Enabled = True Then
                        Me.radStaffChg.Checked = True
                        Me.radStaffChg.PerformClick()
                    End If
                Case Keys.F11
                    If Me.radCompleteDept.Enabled = True Then
                        Me.radCompleteDept.Checked = True
                        Me.radCompleteDept.PerformClick()
                    End If

                    'Case (Keys.Control Or Keys.N)
                    '   Me.Text = "<CTRL> + N Captured"
                    'Case (Keys.Alt Or Keys.Z)
                    '   Me.Text = "<ALT> + Z Captured"
            End Select
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private Sub frmCashSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cell As Xceed.Grid.Cell

        Try

            Me.txtClerk.Text = ""
            Me.txtDate.Text = ""
            Me.txtRunningCharge.Text = ""

            'add columns to sale details grid
            Me.grdSalesDetails.Columns.Add(New Xceed.Grid.Column("strItem", GetType(String)))
            Me.grdSalesDetails.Columns.Add(New Xceed.Grid.Column("intQty", GetType(Long)))
            Me.grdSalesDetails.Columns.Add(New Xceed.Grid.Column("curPricePer", GetType(String)))
            Me.grdSalesDetails.Columns.Add(New Xceed.Grid.Column("curSubTotal", GetType(String)))

            Me.grdSalesDetails.Columns("strItem").Title = "Item"
            Me.grdSalesDetails.Columns("strItem").Width = 200
            Me.grdSalesDetails.Columns("intQty").Title = "Qty"
            Me.grdSalesDetails.Columns("intQty").Width = 40
            Me.grdSalesDetails.Columns("curPricePer").Title = "Price/Ea."
            Me.grdSalesDetails.Columns("curPricePer").HorizontalAlignment = HorizontalAlignment.Right
            Me.grdSalesDetails.Columns("curSubTotal").Title = "Sub-Total"
            Me.grdSalesDetails.Columns("curSubTotal").HorizontalAlignment = HorizontalAlignment.Right

            Me.colmgrSaleDetails.Visible = False
            Me.grdSalesDetails.ReadOnly = True

            For Each Cell In Me.grdSalesDetails.DataRowTemplate.Cells
                AddHandler cell.DoubleClick, AddressOf Me.Cel_DoubleClick
            Next Cell

            AddHandler Me.grdSalesDetails.DataRowTemplate.RowSelector.DoubleClick, AddressOf Me.Row_DoubleClick

            subInitSale()

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

    End Sub

    Private Sub subRefreshDetails()

        Dim dblTaxChg As Double = 0
        Dim dblNoTaxChg As Double = 0
        Dim dblTaxRate As Double = 0
        Dim dblPrice As Double

        Dim lngSaleID As Long

        Dim intQty As Integer

        Dim blnHasDetails As Boolean = False

        Dim strSQL As String

        Try

            Me.grdSalesDetails.DataRows.Clear()
            Me.colmgrSaleDetails.Visible = True

            If IsNumeric(Me.txtSaleID.Text) Then
                lngSaleID = CType(Me.txtSaleID.Text, Long)
            Else
                lngSaleID = 0
            End If

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT tblInventory.blnTaxable, " & _
                            "tblSalesDetail.lngSalesDetailID, tblSalesDetail.lngSaleID, tblSalesDetail.lngQuantity, " & _
                            "tblSalesDetail.curPrice, tblSalesDetail.curTotal, " & _
                            "tblInventory.strItemName " & _
                        "FROM tblSalesDetail " & _
                            "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                        "WHERE lngSaleID=" & lngSaleID.ToString() & " AND " & _
                            "lngSaleID>0;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drSaleDetails As OleDbDataReader = cmdDB.ExecuteReader()
                        
                        While (drSaleDetails.Read)

                            Dim rowSaleDetail As Xceed.Grid.DataRow = Me.grdSalesDetails.DataRows.AddNew()

                            rowSaleDetail.ReadOnly = True
                            rowSaleDetail.AllowCellNavigation = False
                            rowSaleDetail.Tag = drSaleDetails("lngSalesDetailID").ToString
                            rowSaleDetail.Cells("strItem").Value = drSaleDetails("strItemName")

                            If IsNumeric(drSaleDetails("lngQuantity")) Then

                                intQty = CType(drSaleDetails("lngQuantity"), Integer)

                            Else

                                MsgBox("Default quantity not entered for " & CType(drSaleDetails("strItemName"), String) & "!")

                                intQty = 0

                            End If

                            rowSaleDetail.Cells("intQty").Value = CType(intQty, Int64)

                            If IsNumeric(drSaleDetails("curPrice")) Then

                                dblPrice = CType(drSaleDetails("curPrice"), Double)

                            Else

                                MsgBox("Item is not priced!")

                                dblPrice = 0

                            End If

                            rowSaleDetail.Cells("curPricePer").Value = Format(dblPrice, "currency")
                            rowSaleDetail.Cells("curSubTotal").Value = Format(dblPrice * intQty, "currency")


                            If IsNumeric(drSaleDetails("curTotal")) Then
                                If CType(drSaleDetails("blnTaxable"), Boolean) Then
                                    dblTaxChg += CType(drSaleDetails("curTotal"), Double)
                                Else
                                    dblNoTaxChg += CType(drSaleDetails("curTotal"), Double)
                                End If
                            End If

                            rowSaleDetail.EndEdit()

                        End While

                        drSaleDetails.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

            Me.grdSalesDetails.SelectionMode = SelectionMode.None

            If dblTaxChg <> 0 Then

                If Me.radPriceDept.Checked Then
                    dblTaxRate = 0
                Else
                    dblTaxRate = fcnTaxRate()
                End If

                dblTaxChg = (dblTaxChg * dblTaxRate) + dblTaxChg

            End If

            Me.txtRunningCharge.Text = Format(dblTaxChg + dblNoTaxChg, "currency")

            If Me.grdSalesDetails.DataRows.Count > 0 Then

                If Me.radPriceResident.Checked Then
                    Me.radCash.Enabled = True
                    Me.radCharge.Enabled = True
                    Me.radCheck.Enabled = True
                    Me.radSpendingMoney.Enabled = False
                    Me.radStaffChg.Enabled = True
                    Me.radCompleteDept.Enabled = False
                ElseIf Me.radPriceDept.Checked Then
                    Me.radCash.Enabled = False
                    Me.radCharge.Enabled = False
                    Me.radCheck.Enabled = False
                    Me.radSpendingMoney.Enabled = False
                    Me.radStaffChg.Enabled = False
                    Me.radCompleteDept.Enabled = True
                ElseIf Me.radPriceSummerStaff.Checked Then
                    Me.radCash.Enabled = True
                    Me.radCharge.Enabled = True
                    Me.radCheck.Enabled = True
                    Me.radSpendingMoney.Enabled = True
                    Me.radStaffChg.Enabled = False
                    Me.radCompleteDept.Enabled = False
                Else
                    Me.radCash.Enabled = True
                    Me.radCharge.Enabled = True
                    Me.radCheck.Enabled = True
                    Me.radSpendingMoney.Enabled = True
                    Me.radStaffChg.Enabled = False
                    Me.radCompleteDept.Enabled = False

                End If

                Me.fraPriceLevel.Enabled = False
                Me.btnRemoveItems.Enabled = True

            Else
                Me.btnClose.Enabled = True

                Me.radCash.Enabled = False
                Me.radCharge.Enabled = False
                Me.radCheck.Enabled = False
                Me.radSpendingMoney.Enabled = False
                Me.radStaffChg.Enabled = False
                Me.radCompleteDept.Enabled = False

                Me.fraPriceLevel.Enabled = True
                Me.btnRemoveItems.Enabled = True

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".subRefreshDetails", ex)

        End Try

    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click

        Dim strPricelevel As String = "curListPrice"
        Dim strItem As String

        Try

            If Me.radPriceRetail.Checked Then strPricelevel = "curListPrice"
            If Me.radPriceSummerStaff.Checked Then strPricelevel = "curDiscount1"
            If Me.radPriceResident.Checked Then strPricelevel = "curdiscount2"
            If Me.radPriceDept.Checked Then strPricelevel = "curCost"

            If Len(strItemCode) > 0 Then
                strItem = fcnInvLookup(strItemCode)
                strItem = InputBox("Enter item:", "Enter Item", strItem)
            Else
                strItem = InputBox("Enter item:", "Enter Item")
                'Dim i As New dlgAddItem
                'i.ShowDialog()
                'strItem = i.txtItemCode.Text
            End If

            While strItem <> ""

                If fcnAddSaleDetail(strItem, CType(Me.txtSaleID.Text, Long), strPricelevel, False) Then
                    subRefreshDetails()
                Else
                    MsgBox("Item not added!" & vbNewLine & vbNewLine & "This is usually because the item is not in inventory.")
                End If

                strItem = InputBox("Enter item:", "Enter Item")

            End While

        Catch ex As Exception

            subLogErr(Me.Name & ".btnAddItems_Click", ex)

        End Try

    End Sub

    Private Sub subFinishCashSale(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCash.Click, radCharge.Click, radCheck.Click, radSpendingMoney.Click, radStaffChg.Click, radCompleteDept.Click

        Try
            If Me.txtSaleID.Text = "" Then Me.txtSaleID.Text = (0).ToString

            If CLng(Me.txtSaleID.Text) > 0 Then

                If Me.radCash.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), clsGlobalEnum.conPMTTYPE.conPMTTYPE_CASH)
                ElseIf Me.radCheck.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), conPMTTYPE.conPMTTYPE_CHECK)
                ElseIf Me.radCharge.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), conPMTTYPE.conPMTTYPE_CC)
                ElseIf Me.radSpendingMoney.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), conPMTTYPE.conPMTTYPE_SPENDMNY)
                ElseIf Me.radStaffChg.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), conPMTTYPE.conPMTTYPE_StaffChg)
                ElseIf Me.radCompleteDept.Checked Then
                    Me.blnComplete = fcnCompleteSale(CType(Me.txtSaleID.Text, Long), conPMTTYPE.conPMTTYPE_DEPTTRNSFR)
                End If

                If Me.blnComplete Then
                    subInitSale()
                Else
                    Me.radCash.Checked = False
                    Me.radCharge.Checked = False
                    Me.radCheck.Checked = False
                    Me.radSpendingMoney.Checked = False
                    Me.radStaffChg.Checked = False
                End If

                subRefreshDetails()

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".radCash_CheckedChanged", ex)

        End Try

    End Sub

    Private Sub subInitSale()

        Try

            Me.radCash.Checked = False
            Me.radCharge.Checked = False
            Me.radCheck.Checked = False
            Me.radSpendingMoney.Checked = False
            Me.radStaffChg.Checked = False
            Me.radCompleteDept.Checked = False

            Me.txtSaleID.Text = ""

            Me.txtDate.Text = ""
            Me.txtRunningCharge.Text = ""

            Me.colmgrSaleDetails.Visible = False

            Me.grdSalesDetails.DataRows.Clear()

            Me.blnComplete = False

            Me.chkBeginSale.Enabled = True
            Me.chkBeginSale.Checked = False

            Me.radCash.Enabled = False
            Me.radCharge.Enabled = False
            Me.radCheck.Enabled = False
            Me.radSpendingMoney.Enabled = False
            Me.radStaffChg.Enabled = False
            Me.radCompleteDept.Enabled = False

            Me.chkBeginSale.Enabled = True
            Me.btnAddItems.Enabled = False
            Me.btnRemoveItems.Enabled = False
            Me.btnVoid.Enabled = False
            Me.btnClose.Enabled = True

            Me.fraPriceLevel.Enabled = True

        Catch ex As Exception

            subLogErr(Me.Name & ".subInitSale", ex)

        End Try

    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

        Dim lngSaleID As Long = 0

        Try

            If IsNumeric(Me.txtSaleID.Text) Then lngSaleID = CLng(Me.txtSaleID.Text)

            If lngSaleID <= 0 Then Exit Sub

            If fcnVoidSale(lngSaleID) Then subInitSale()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnVoid_Click", ex)

        End Try

    End Sub

    Private Sub btnRemoveItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItems.Click

        Dim lngSaleID As Long = 0
        Dim strPriceLevel As String = ""

        If Me.radPriceRetail.Checked Then strPriceLevel = "curListPrice"
        If Me.radPriceSummerStaff.Checked Then strPriceLevel = "curDiscount1"
        If Me.radPriceResident.Checked Then strPriceLevel = "curdiscount2"
        If Me.radPriceDept.Checked Then strPriceLevel = "curCost"

        Try

            If IsNumeric(Me.txtSaleID.Text) Then lngSaleID = CLng(Me.txtSaleID.Text)

            If lngSaleID > 0 Then subRemoveDetails(lngSaleID, strPriceLevel)

            subRefreshDetails()

        Catch ex As Exception

            subLogErr(Me.Name & "btnRemoveItems_Click", ex)

        End Try

    End Sub

    Private Sub chkBeginSale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBeginSale.Click

        subBeginSale()

    End Sub

    Private Sub subBeginSale()

        Dim strPriceLevel As String = "curListPrice"
        Dim strItem As String

        Dim lngSaleID As Long

        Try

            If Me.radPriceRetail.Checked Then strPriceLevel = "curListPrice"
            If Me.radPriceSummerStaff.Checked Then strPriceLevel = "curDiscount1"
            If Me.radPriceResident.Checked Then strPriceLevel = "curdiscount2"
            If Me.radPriceDept.Checked Then strPriceLevel = "curCost"

            If Me.chkBeginSale.Checked Then

                blnSaleOpen = True

                lngSaleID = fcnNewSale(conSALETYPE.conSALE)

                Me.txtDate.Text = String.Format(Now.ToString, "yyyy-mm-dd hh:mm:ss ampm")

                Me.txtClerk.Text = objLogin.cboClerks.SelectedItem.ToString

                Me.txtSaleID.Text = lngSaleID.ToString

                If Len(strItemCode) > 0 Then
                    strItem = fcnInvLookup(strItemCode)
                    strItem = InputBox("Enter item:", "Enter Item", strItem)
                Else
                    strItem = InputBox("Enter item:", "Enter Item")
                End If

                While strItem <> ""

                    If fcnAddSaleDetail(strItem, lngSaleID, strPriceLevel, False) Then subRefreshDetails()

                    strItem = InputBox("Enter item:", "Enter Item")

                End While

                Me.chkBeginSale.Enabled = False
                Me.btnVoid.Enabled = True
                Me.btnAddItems.Enabled = True
                Me.btnRemoveItems.Enabled = True
                Me.btnClose.Enabled = False
                Me.fraPriceLevel.Enabled = False

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".chkBeginSale_CheckedChanged", ex)

        End Try

    End Sub

    Private Sub Cel_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cell As Cell = CType(sender, Cell)

        'parentRow's property can be used to access the rows value
        Dim parentRow As CellRow = cell.ParentRow
        MsgBox(cell.Value)

    End Sub

    Private Sub Row_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim rowsel As RowSelector = CType(sender, RowSelector)
        Dim row As DataRow = Me.grdSalesDetails.CurrentRow

        'MsgBox(rowsel.Row.Tag)
        Dim dlg As New dlgEditItem
        dlg.txtItemQty.Text = row.Cells("intQty").Value.ToString
        dlg.txtPrice.Text = row.Cells("curPricePer").Value.ToString

        dlg.txtDiscount.Text = 0
        dlg.ShowDialog()
        If fcnEditSaleDetail(rowsel.Row.Tag, dlg.txtItemQty.Text, dlg.txtPrice.Text, False) Then
            subRefreshDetails()
        End If
        'MsgBox(dlg.txtItemQty.Text)

    End Sub
End Class