Imports System.Data.OleDb
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Xceed.Grid
Imports Xceed.Grid.Collections
Imports Xceed.Grid.Editors
Imports Xceed.Grid.Viewers
Imports Xceed.Editors




Public Class frmSaleDetailLookUp

    Public Sub FillGrid(ByVal lngSaleId As Long)
        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter
        Dim ds As DataSet
        Dim RowCount As Integer

        'Dim i As Integer
        Dim Total As Decimal

        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            Dim strSQL = " SELECT tblInventory.strItemName as ItemName, tblSalesDetail.lngQuantity as Qty, tblSalesDetail.curPrice as Price, tblSalesDetail.curTax as Tax, tblSalesDetail.curTotal as Total , tblSalesDetail.lngSalesDetailID as SaleDetailID FROM tblSalesDetail INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID where tblSalesDetail.lngSaleID = " & lngSaleId & " ;"

            DataAdapter = New OleDbDataAdapter(strSQL, objConn)
            ' create a new dataset
            ds = New DataSet
            ' fill dataset
            DataAdapter.Fill(ds)


            Me.grdSaleDetails.DataSource = ds.Tables(0)
            Me.grdSaleDetails.Refresh()

            RowCount = Me.grdSaleDetails.RowCount
            Total = 0

            objConn.Close()
            DataAdapter = Nothing
            strSQL = Nothing
            ds = Nothing

        Catch ex As Exception
            subLogErr(Me.Name & ".FillGrid", ex)
        End Try
    End Sub

    

    Private Sub subSetSaleTotal()
        Dim objConn As OleDbConnection
        Dim strSQL As String
        Dim objCommand
        Dim rs As OleDbDataReader


        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()
            strSQL = "SELECT Sum(tblSalesDetail.curTotal) AS SumOfcurTotal FROM tblSalesDetail WHERE (((tblSalesDetail.lngSaleID)=" & Me.txtSaleIdDetails.Text & "));"

            objCommand = New OleDbCommand
            objCommand.connection = objConn
            objCommand.CommandText = strSQL

            rs = objCommand.ExecuteReader

            Do While rs.Read
                If Not rs.IsDBNull(0) Then
                    Me.txtSaleTotal.Text = rs("SumOfcurTotal")
                Else
                    Me.txtSaleTotal.Text = ""
                End If
            Loop

            objConn.Close()
            rs.Close()
            rs = Nothing
            objCommand = Nothing

        Catch ex As Exception
            subLogErr(Me.Name & ".txtSaleID_TextChanged", ex)

        End Try
    End Sub

    Public Sub FillDetails(ByVal strSQL As String)
        Dim objConn As OleDbConnection

        Dim objCommand
        Dim rs As OleDbDataReader

        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            objCommand = New OleDbCommand
            objCommand.connection = objConn
            objCommand.CommandText = strSQL

            rs = objCommand.ExecuteReader
            If rs.HasRows Then

                Do While rs.Read

                    Me.txtSaleIdDetails.Text = rs(0)
                    If Not rs.IsDBNull(2) Then
                        Me.txtSaleDate.Text = (rs("dteSaleDate"))
                    Else
                        Me.txtSaleDate.Text = ""
                    End If

                    ' Me.txtSaleDate.Text = rs("dteSaleDate")

                    If Not rs.IsDBNull(1) Then
                        Me.txtStore.Text = (rs("lngStoreID"))
                    Else
                        Me.txtStore.Text = ""
                    End If
                    'Me.txtStore.Text = rs("lngStoreID")

                    If Not rs.IsDBNull(3) Then
                        Me.txtClerk.Text = (rs("lngClerkID"))
                    Else
                        Me.txtClerk.Text = ""
                    End If

                    'Me.txtClerk.Text = rs("lngClerkID")

                    If Not rs.IsDBNull(16) Then
                        Me.txtWorkStationID.Text = (rs("lngWSID"))
                    Else
                        Me.txtWorkStationID.Text = ""
                    End If
                    'Me.txtWorkStationID.Text = rs("lngWSID")

                    If Not rs.IsDBNull(4) Then
                        Me.txtSaleType.Text = (rs("lngSaleTypeID"))
                    Else
                        Me.txtSaleType.Text = ""
                    End If
                    ' Me.txtSaleType.Text = rs("lngSaleTypeID")

                    If Not rs.IsDBNull(5) Then
                        Me.txtCamperID.Text = (rs("lngCamperID"))
                    Else
                        Me.txtCamperID.Text = ""
                    End If
                    'Me.txtCamperID.Text = rs("lngCamperID")

                    If Not rs.IsDBNull(14) Then
                        Me.txtRegistrationID.Text = (rs("lngRegistrationID"))
                    Else
                        Me.txtRegistrationID.Text = ""
                    End If

                    'Me.txtRegistrationID.Text = rs("lngRegistrationID")


                    If Not rs.IsDBNull(6) Then
                        'Me.txtTransactionID.Text = (rs("lngTransactionID"))
                        Me.txtTransactionID.Text = (rs(6))
                    Else
                        Me.txtTransactionID.Text = ""
                    End If
                    ' Me.txtTransactionID.Text = rs("lngTransactionID")

                    If Not rs.IsDBNull(7) Then
                        Me.txtPaymentType.Text = (rs("lngPaymentTypeID"))
                    Else
                        Me.txtPaymentType.Text = ""
                    End If


                    'Me.txtPaymentType.Text = rs("lngPaymentTypeID")

                    If Not rs.IsDBNull(8) Then
                        Me.txtCheckWriter.Text = (rs("strCheckWriter"))
                    Else
                        Me.txtCheckWriter.Text = ""
                    End If

                    If Not rs.IsDBNull(rs.GetOrdinal("blnmovedforcc")) Then
                        If (rs("blnMovedforCC")) Then
                            Me.chk4CCExpert.Checked = True
                        End If
                    End If

                    If Not rs.IsDBNull(10) Then
                        Me.txtCCNumber.Text = (rs("strCCNumber"))
                    Else
                        Me.txtCCNumber.Text = ""
                    End If


                    'Me.txtCCNumber.Text = rs("strCCNumber")

                    If Not rs.IsDBNull(11) Then
                        Me.txtExpDate.Text = (rs("strCCExpDate"))
                    Else
                        Me.txtExpDate.Text = ""
                    End If

                    'Me.txtExpDate.Text = rs("strCCExpDate")


                    If Not rs.IsDBNull(19) Then
                        Me.txtAuthNum.Text = (rs("strAuthNumber"))
                    Else
                        Me.txtAuthNum.Text = ""
                    End If

                    'Me.txtAuthNum.Text = rs("strAuthNumber")


                    If Not rs.IsDBNull(17) Then
                        Me.txtPhone.Text = (rs("strPhone"))
                    Else
                        Me.txtPhone.Text = ""
                    End If
                    ' Me.txtPhone.Text = rs("strPhone")

                    If Not rs.IsDBNull(18) Then
                        Me.txtZip.Text = (rs("strZip"))
                    Else
                        Me.txtZip.Text = ""
                    End If
                    'Me.txtZip.Text = rs("strZip")

                    If Not IsDBNull(rs("lngstaffID")) Then
                        Me.txtStaffCharge.Text = rs("lngStaffID")
                    Else
                        Me.txtStaffCharge.Text = ""
                    End If

                    If Not rs.IsDBNull(13) Then
                        Me.txtDeptCharge.Text = (rs("lngDeptID"))
                    Else
                        Me.txtDeptCharge.Text = ""
                    End If
                    ' Me.txtDeptCharge.Text = rs("lngDeptID")

                    If Not rs.IsDBNull(15) Then
                        Me.txtZdOut.Text = (rs("dteZdOut"))
                    Else
                        Me.txtZdOut.Text = ""
                    End If
                    'Me.txtZdOut.Text = rs("dteZdOut")

                    If Not rs.IsDBNull(21) Then
                        Me.txtTax.Text = (rs("curTax"))
                    Else
                        Me.txtTax.Text = ""
                    End If
                    'Me.txtTax.Text = rs("curTax")

                    If Not rs.IsDBNull(20) Then
                        Me.txtSaleTotal.Text = (rs("curTotalCharge"))
                    Else
                        Me.txtSaleTotal.Text = ""
                    End If
                    ' Me.txtSaleTotal.Text = rs("curTotalCharge")
                Loop

                FillGrid(CLng(Trim(Me.txtSaleIdDetails.Text)))

                Me.grpDetails.Visible = True
                subSetSaleTotal()
                Me.txtSaleID.Text = ""
            Else
                MsgBox("Sale Not Found.", MsgBoxStyle.Critical)
            End If

            objConn.Close()
            rs.Close()
            rs = Nothing
            objCommand = Nothing

        Catch ex As Exception
            subLogErr(Me.Name & ".btnGet_Click", ex)

        End Try

    End Sub
   

    Private Sub txtSaleID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSaleID.KeyPress
        Dim strSQL As String
        If Asc(e.KeyChar) = Keys.Enter Then
            strSQL = "select  lngSaleID, lngStoreID, dteSaleDate, lngClerkID, lngSaleTypeID, lngCamperID, lngTransactionID, lngPaymentTypeID, strCheckWriter, blnMovedforCC, strCCNumber, strCCExpDate, lngStaffID, lngDeptID, lngRegistrationID, dteZdOut, lngWSID, strPhone, strZip, strAuthNumber, curTotalCharge, curTax, curSubTotal, curDiscount, strCVV2, strBillName from tblSales where lngSaleID=" & Trim(Me.txtSaleID.Text) & " order by lngsaleID"
            FillDetails(strSQL)
            Me.txtSaleID.Text = ""
        End If
    End Sub

    Private Sub txtCC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCC.KeyPress
        Dim strSQL As String
        If Asc(e.KeyChar) = Keys.Enter Then
            strSQL = "select * from tblSales where strCCNumber='" & Trim(Me.txtCC.Text) & "' order by lngSaleID"
            FillDetails(strSQL)
            Me.txtCC.Text = ""
        End If

    End Sub

   
    Private Sub grdSaleDetails_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSaleDetails.CellClick
        Try
            Select Case e.ColumnIndex
                Case 0
                    'lagUpdate = flagUpdate + 1
                    'Me.grdCraftSales.Item(5, e.RowIndex).ReadOnly = False
                    'Me.grdCraftSales.Item(5, e.RowIndex).Selected = True

                    'If CLng(Me.grdSaleDetails.Item(3, e.RowIndex).Value).CompareTo("") Then
                    'Me.grdSaleDetails.DataSource
                    Dim strIn = InputBox("Enter New Quantity of this Item")

                    If strIn = "" Or Not IsNumeric(strIn) Then
                        MsgBox("Invalid Amount !!!", MsgBoxStyle.Critical, "CampTrak")
                    Else
                        Dim newTotal = CLng(strIn) * CLng(Me.grdSaleDetails.Item(3, e.RowIndex).Value)
                        fcwUpdate(CLng(strIn), newTotal, CLng(Me.grdSaleDetails.Item(6, e.RowIndex).Value))
                    End If


            End Select
        Catch ex As Exception
            subLogErr(Me.Name & ".grdSaleDetails_CellClick", ex)

        End Try
    End Sub

    Private Sub fcwUpdate(ByVal newQty As Long, ByVal newTotal As Decimal, ByVal SaleDetailID As Long)
        Dim objConnPOS As OleDbConnection
        Dim objCommandUpdateSalesDetail As OleDbCommand
        'Dim rs As OleDbDataReader

        Try

            objConnPOS = New OleDbConnection
            objConnPOS.ConnectionString = strPOSConn
            objConnPOS.Open()

            objCommandUpdateSalesDetail = New OleDbCommand
            objCommandUpdateSalesDetail.Connection = objConnPOS
            objCommandUpdateSalesDetail.CommandText = "UPDATE tblSalesDetail SET lngQuantity = '" & newQty & "' , curTotal = '" & newTotal & "' Where lngSalesDetailID = " & SaleDetailID
            Dim rows = objCommandUpdateSalesDetail.ExecuteNonQuery()

            FillGrid(Me.txtSaleIdDetails.Text)

            objConnPOS.Close()
            objCommandUpdateSalesDetail = Nothing

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.btnSave.Visible = True
        Me.btnEdit.Visible = False

        Me.txtCCNumber.Enabled = True
        Me.txtExpDate.Enabled = True

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        Dim objConnPOS As OleDbConnection
        Dim objCommandUpdateSales As OleDbCommand
       
        Try

            objConnPOS = New OleDbConnection
            objConnPOS.ConnectionString = strPOSConn
            objConnPOS.Open()

            objCommandUpdateSales = New OleDbCommand
            objCommandUpdateSales.Connection = objConnPOS

            Dim new_Date = Format(Me.txtExpDate.Text, "Short Date")
            objCommandUpdateSales.CommandType = CommandType.Text
            objCommandUpdateSales.CommandText = "UPDATE tblSales SET strCCNumber = " & Trim(Me.txtCCNumber.Text) & " , strCCExpDate = '" & new_Date & "' Where lngSaleID = " & Me.txtSaleIdDetails.Text
            objCommandUpdateSales.ExecuteNonQuery()

            FillGrid(Me.txtSaleIdDetails.Text)

            Me.btnSave.Visible = False
            Me.btnEdit.Visible = True
            Me.txtCCNumber.Enabled = False
            Me.txtExpDate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub



    
End Class