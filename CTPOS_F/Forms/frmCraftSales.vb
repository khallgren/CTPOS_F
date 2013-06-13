Imports System.Data.OleDb
Imports Microsoft.Win32

Public Class frmCraftSales

    Dim ColumnList As ArrayList

    Public Shared Date_Craft As String
    Private flagUpdate = 0

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim lngCraftID As Long

        lngCraftID = 0

        Try
            lngCraftID = CType(My.Settings.strCraftID, Long)
        Catch ex As Exception
            lngCraftID = 0
        End Try

        If lngCraftID = 0 Then MessageBox.Show("There is no inventory item selected for craft sales." & vbNewLine & vbNewLine & "Select Administration-->System Setup to define one.")

    End Sub

    Private Sub frmCraftSales_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        FillGrid()
    End Sub

    Private Sub frmCraftSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillCombo()

    End Sub

    Public Sub FillGrid()

        Dim ds As New DataSet
        subFillDataSets(ds)

        Dim dt As DataTable

        ' build a list of every column used in the result set + the joins
        ColumnList = New ArrayList
        ColumnList.Add("tblRecords.fstName")
        ColumnList.Add("tblRecords.lstName")
        ColumnList.Add("tblSales.Total")
        ColumnList.Add("tblSales.SaleDetailID")
        ColumnList.Add("tblSales.dte")

        dt = JoinTables(ds.Tables("tblsales"), ds.Tables("tblrecords"), "lngRegistrationID", "lngRegistrationID", "INNER", ColumnList, ds)

        Me.grdCraftSales.DataSource = dt

    End Sub

    Public Sub FillCombo()

        Dim strSQL As String

        Dim cboItem As clsCboItem

        Try

            Using conDB As OleDbConnection=New OleDbConnection(strCTConn)

                conDB.Open()

                strSQL = "SELECT tblBlock.lngBlockID, " & _
                            "tblBlock.strBlockCode " & _
                        "FROM tblBlock " & _
                        "ORDER BY strBlockCode;"

                Using cmdDB As OleDbCommand=New OleDbCommand(strSQL, conDB)

                    Using drCbo As OleDbDataReader = cmdDB.ExecuteReader

                        While drCbo.Read
                            cboItem = New clsCboItem(CType(drCbo("lngBlockID"), Long), drCbo("strBlockCode").ToString)
                            cboBlockCode.Items.Add(cboItem)
                        End While

                        drCbo.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception
            subLogErr(Me.Name & ".FillCombo", ex)

        End Try

    End Sub

    Public Sub fcnCraftSale()

        Dim strIn As String
        Dim strSQL As String

        Dim curTotal As Double

        Dim lngRegID As Long
        Dim lngCamper As Long
        Dim lngClerk As Long
        Dim lngSaleType As Long
        Dim lngSale As Long
        Dim lngTransID As Long

        Dim flag = 0

        Try
            strIn = InputBox("Please Enter Registration ID", "CampTrak")

            If strIn = "" Or Not IsNumeric(strIn) Then
                MsgBox("Invalid Registration ID !!!", MsgBoxStyle.Critical, "CampTrak")
                GoTo FinishTransaction
            Else
                lngRegID = CLng(strIn)
            End If

            Using conCT As OleDbConnection = New OleDbConnection(strCTConn)

                conCT.Open()

                Dim lngBlockID As Long

                Try
                    lngBlockID = CType(Me.cboBlockCode.SelectedItem, clsCboItem).ID
                Catch ex As Exception
                    lngBlockID = 0
                End Try

                strSQL = "SELECT lngRecordID " & _
                        "FROM tblRegistrations " & _
                        "WHERE lngRegistrationID=" & lngRegID.ToString() & " AND " & _
                            "lngBlockID=" & lngBlockID.ToString()

                Using cmdCTMain As OleDbCommand = New OleDbCommand(strSQL, conCT)

                    flag = 0

                    Try
                        lngCamper = Convert.ToInt32(cmdCTMain.ExecuteScalar())
                    Catch ex As Exception
                        lngCamper = 0
                    End Try

                    If lngCamper > 0 Then
                        flag = 1
                    Else
                        MsgBox("Registration ID you Entered Does not match with Records", MsgBoxStyle.Information, "CampTrak")
                        GoTo FinishTransaction
                    End If

                    strIn = InputBox("Input amount with no decimals ($1.25 entered as 125):", "CampTrak")

                    If strIn = "" Or Not IsNumeric(strIn) Then
                        MsgBox("Invalid Amount !!!", MsgBoxStyle.Critical, "CampTrak")
                        GoTo FinishTransaction
                    Else
                        curTotal = CType(strIn, Double)
                    End If

                    curTotal = curTotal / 100
                    lngClerk = lngClerkID.ToString()

                    lngSaleType = 1

                    Using conPOS As OleDbConnection = New OleDbConnection(strPOSConn)

                        conPOS.Open()

                        Dim new_Date = Format(IIf(IsDate(Me.dtinputDate.Text), Me.dtinputDate.Text, Now), "Short Date")

                        Dim lngCSStoreID As Long = 0
                        Dim lngCSWSID As Long = 0

                        Try
                            If IsNumeric(My.Settings.lngStoreID) Then
                                lngCSStoreID = My.Settings.lngStoreID
                            Else
                                lngCSStoreID = 0
                            End If
                        Catch ex As Exception
                            lngCSStoreID = 0
                        End Try

                        Try
                            If IsNumeric(My.Settings.lngWSID) Then
                                lngCSWSID = My.Settings.lngWSID
                            Else
                                lngCSWSID = 0
                            End If
                        Catch ex As Exception
                            lngCSWSID = 0
                        End Try

                        strSQL = "INSERT INTO tblSales " & _
                                "(lngCamperID, lngRegistrationID, lngClerkID, lngWSID, lngSaleTypeID, lngPaymentTypeID, lngStoreID, " & _
                                    "dteSaleDate, " & _
                                    "curTotalCharge, curSubTotal) " & _
                                "VALUES " & _
                                "(" & lngCamper & ", " & lngRegID & ", " & lngClerk & ", " & lngCSWSID.ToString() & ", 5, 7," & lngCSStoreID.ToString() & ", " & _
                                    "'" & new_Date & "', " & _
                                    "" & curTotal & ", " & curTotal & ") "

                        Using cmdPOS As OleDbCommand = New OleDbCommand(strSQL, conPOS)

                            Try
                                cmdPOS.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                            strSQL = "SELECT @@IDENTITY " & _
                                    "FROM tblSales"

                            cmdPOS.CommandText = strSQL
                            cmdPOS.Parameters.Clear()

                            Try
                                lngSale = Convert.ToInt32(cmdPOS.ExecuteScalar())
                            Catch
                            End Try

                            strSQL = "INSERT INTO tblSalesDetail " & _
                                   "( lngSaleID, lngInventoryID, lngQuantity, " & _
                                       "curPrice, curTotal ) " & _
                                   "SELECT " & lngSale & ", " & CType(My.Settings.strCraftID, Long) & ", 1, " & _
                                       curTotal & ", " & curTotal

                            cmdPOS.CommandText = strSQL
                            cmdPOS.Parameters.Clear()

                            Try
                                cmdPOS.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                            strSQL = "INSERT INTO tblTransactions " & _
                                    "(curCharge,dteDateAdded,lngTransTypeID,lngRegistrationID,lngRecordID, lngSaleID) " & _
                                    "VALUES (" & curTotal & ", Now(), 5 ," & lngRegID & "," & lngCamper & ", " & lngSale & " );"

                            cmdCTMain.CommandText = strSQL
                            cmdCTMain.Parameters.Clear()

                            Try
                                cmdCTMain.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                            strSQL = "SELECT @@IDENTITY " & _
                                    "FROM tblTransactions"

                            cmdCTMain.CommandText = strSQL
                            cmdCTMain.Parameters.Clear()

                            Try
                                lngTransID = Convert.ToInt32(cmdCTMain.ExecuteScalar())
                            Catch
                            End Try

                            'put trans id in sale table
                            strSQL = "UPDATE tblSales SET lngTransactionID = " & lngTransID & " WHERE lngSaleID=" & lngSale

                            cmdPOS.CommandText = strSQL
                            cmdPOS.Parameters.Clear()

                            Try
                                cmdPOS.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                        End Using

                    conPOS.Close()

                End Using

            End Using

            conCT.Close()

            End Using

FinishTransaction:
            FillGrid()
        Catch ex As Exception
            subLogErr(Me.Name & ".fcnCraftSale", ex)

        End Try

    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click

        If cboBlockCode.SelectedIndex < 0 Then
            MessageBox.Show("Please select a block code to enter craft sales.")
            cboBlockCode.Focus()
            Exit Sub
        End If

        fcnCraftSale()

    End Sub

    Private Sub grdCraftSales_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCraftSales.CellClick

        Dim row As DataGridViewRow
        Try
            Select Case e.ColumnIndex
                Case 0
                    If flagUpdate = 0 Then

                        'only show current row (the one being edited)
                        'make sale amount editable

                        flagUpdate = flagUpdate + 1

                        For Each row In Me.grdCraftSales.Rows
                            If row.Index <> e.RowIndex Then
                                Me.grdCraftSales.Rows.Remove(row)
                            End If
                        Next

                        Me.btnUpdate.Text = "Save"
                        Me.grdCraftSales.Item(4, e.RowIndex).ReadOnly = False
                        Me.grdCraftSales.Item(4, e.RowIndex).Selected = True

                    ElseIf flagUpdate = 1 Then

                        Dim decTotal As Decimal
                        Dim lngSalesDetailID As Long

                        Try
                            decTotal = Convert.ToDecimal(grdCraftSales.Item(4, e.RowIndex).Value)
                        Catch ex As Exception
                            MessageBox.Show("Please enter a valid numeric value for the total cost!")
                            Exit Sub
                            decTotal = 0
                        End Try
                        Try
                            lngSalesDetailID = Convert.ToInt32(grdCraftSales.Item(5, e.RowIndex).Value)
                        Catch ex As Exception
                            lngSalesDetailID = 0
                        End Try

                        fcwUpdate(decTotal, lngSalesDetailID)

                        Me.btnUpdate.Text = "Update"

                        flagUpdate = 0

                    End If

            End Select
        Catch ex As Exception
            subLogErr(Me.Name & ".grdCraftSales_CellClick", ex)

        End Try

    End Sub

    Private Sub fcwUpdate(ByVal _decSalesTotal As Decimal, ByVal _lngSalesDetailID As Long)

        Dim SalesID As Long
        Dim TransID As Long
        Dim strSQL As String

        Try

            Using conPOS As OleDbConnection = New OleDbConnection(strPOSConn)

                conPOS.Open()

                strSQL = "UPDATE tblSalesDetail " & _
                        "SET curPrice = ?, curTotal  = ? " & _
                        "WHERE lngSalesDetailID = " & _lngSalesDetailID.ToString()

                Using cmdPOS As OleDbCommand = New OleDbCommand(strSQL, conPOS)

                    cmdPOS.Parameters.Clear()
                    cmdPOS.Parameters.AddWithValue("@curPrice", _decSalesTotal)
                    cmdPOS.Parameters.AddWithValue("@curTotal", _decSalesTotal)

                    Try
                        cmdPOS.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                    strSQL = "SELECT lngSaleID " & _
                            "FROM tblSalesDetail " & _
                            "WHERE lngSalesDetailID = " & _lngSalesDetailID.ToString()

                    cmdPOS.CommandText = strSQL
                    cmdPOS.Parameters.Clear()

                    Try
                        SalesID = Convert.ToInt32(cmdPOS.ExecuteScalar())
                    Catch ex As Exception
                        SalesID = 0
                    End Try

                    strSQL = "UPDATE tblSales " & _
                            "SET curTotalCharge  = ?, curSubTotal = ? " & _
                            "WHERE lngSaleID = " & SalesID.ToString()

                    cmdPOS.CommandText = strSQL
                    cmdPOS.Parameters.Clear()

                    cmdPOS.Parameters.AddWithValue("@curTotalCharge", _decSalesTotal)
                    cmdPOS.Parameters.AddWithValue("@curSubTotal", _decSalesTotal)

                    Try
                        cmdPOS.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                    strSQL = "SELECT lngTransactionID " & _
                            "FROM tblSales " & _
                            "WHERE lngSaleID = " & SalesID.ToString()

                    cmdPOS.Parameters.Clear()
                    cmdPOS.CommandText = strSQL

                    Try
                        TransID = Convert.ToInt32(cmdPOS.ExecuteScalar())
                    Catch ex As Exception
                    End Try

                End Using

                conPOS.Close()

            End Using

            Using conCT As OleDbConnection = New OleDbConnection(strCTConn)

                conCT.Open()

                strSQL = "UPDATE tblTransactions " & _
                        "SET curCharge = ? " & _
                        "WHERE lngTransactionID = " & TransID.ToString()

                Using cmdCT As OleDbCommand = New OleDbCommand(strSQL, conCT)

                    cmdCT.Parameters.AddWithValue("@curCharge", _decSalesTotal)

                    Try
                        cmdCT.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                End Using

                conCT.Close()

            End Using

            FillGrid()

        Catch ex As Exception
            subLogErr(Me.Name & ".fcwUpdate", ex)
        End Try

    End Sub

    Private Sub btnBlankSht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlankSht.Click

        Dim lngBlockID As Long

        If Me.cboBlockCode.SelectedItem Is Nothing Then
            MsgBox("Please select a block code.")
            Me.cboBlockCode.Focus()
            Exit Sub
        End If

        lngBlockID = CType(Me.cboBlockCode.SelectedItem, clsCboItem).ID

        subShowCraftSheetBlank(lngBlockID, Me.MdiParent)

    End Sub

    Private Sub btnBalanceRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBalanceRpt.Click

        Dim lngBlockID As Long

        If Me.cboBlockCode.SelectedItem Is Nothing Then
            MsgBox("Please select a block.")
            Me.cboBlockCode.Focus()
            Exit Sub
        End If

        lngBlockID = CType(Me.cboBlockCode.SelectedItem, clsCboItem).ID

        Date_Craft = Me.dtinputDate.Text.ToString

        subShowCraftBalance(lngBlockID, Me.MdiParent)

    End Sub

    Private Sub subFillDataSets(ByVal ds As DataSet)

        Dim strSQL As String = ""

        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand
        Dim strSalesWhere As String = ""
        Dim strBlockWhere As String = ""

        If Not Me.cboBlockCode.SelectedItem Is Nothing Then strBlockWhere = "Where lngBlockID = " & CType(Me.cboBlockCode.SelectedItem, clsCboItem).ID

        If blnUseSQLServer Then
            strSalesWhere = " dteSaleDate = '" & Format(Me.dtinputDate.Value, "short date") & "'"
        Else
            strSalesWhere = " dteSaleDate = #" & Format(Me.dtinputDate.Value, "short date") & "#"
        End If

        Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

            conDB.Open()

            strSQL = "SELECT tblSales.lngSaleID, " & _
                            "tblSales.dteSaleDate AS dte, tblSales.lngRegistrationID, tblSales.lngSaleTypeID, tblSales.curTotalCharge AS Total, tblSalesDetail.lngSalesDetailID AS SaleDetailID " & _
                        "FROM tblSales " & _
                            "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
                        "WHERE (tblSales.lngSaleTypeID = 5) AND " & strSalesWhere

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                Using daSales As OleDbDataAdapter = New OleDbDataAdapter(cmdDB)

                    ' fill a few tables
                    daSales.Fill(ds, "tblSales")

                End Using

            End Using

            conDB.Close()

        End Using

        Using conCT As OleDbConnection = New OleDbConnection(strCTConn)

            conCT.Open()

            strSQL = "SELECT tblRecords.lngRecordID, tblRegistrations.lngRegistrationID, tblRegistrations.lngBlockID as BlockID, tblRecords.strLastCoName as lstName, tblRecords.strFirstName as fstName FROM tblRecords INNER JOIN tblRegistrations ON tblRecords.lngRecordID = tblRegistrations.lngRecordID " & strBlockWhere & " ORDER BY tblRecords.strLastCoName, tblRecords.strFirstName"

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conCT)

                Using daReg As OleDbDataAdapter = New OleDbDataAdapter(cmdDB)

                    daReg.Fill(ds, "tblRecords")

                End Using

            End Using

            conCT.Close()

        End Using

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        FillGrid()

    End Sub

End Class