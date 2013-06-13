Imports System.Data.OleDb
Imports Microsoft.Win32

Public Class frmBatchWithdrawls

   
    Private Sub frmBatchWithdrawls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String

        
        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter

        Dim mylngclerk = lngClerkID.ToString()

        objConn = New OleDbConnection
        objConn.ConnectionString = strCTConn
        objConn.Open()


            strSQL = "SELECT DISTINCTROW tblBlock.lngBlockID as lngBlockID, tblBlock.strBlockCode as BlockCode FROM tblBlock ORDER BY tblBlock.strBlockCode;"


            DataAdapter = New OleDbDataAdapter(strSQL, objConn)
            ' create a new dataset
            Dim ds As DataSet = New DataSet
            ' fill dataset
            DataAdapter.Fill(ds)

            Me.cmbBlkCode.DataSource = ds.Tables(0)
            Me.cmbBlkCode.DisplayMember = ds.Tables(0).Columns(1).ToString
            Me.cmbBlkCode.ValueMember = ds.Tables(0).Columns(0).ToString

            Me.cmbBlkCode.Refresh()
      

        
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If MsgBox("Are you sure you want to process this withdrawal?", vbYesNo + vbQuestion, "CampTrak") = vbYes Then
            subSale()
        End If
    End Sub


    Public Sub subSale()

        Dim objConnPos As OleDbConnection
        Dim objConnMain As OleDbConnection

        Dim objCommandReg As OleDbCommand
        Dim objCommandInsert As OleDbCommand
        Dim status As Integer
        Dim rsTST As OleDbDataReader
       
        Dim strSQL As String

        Dim lngSale As Long
        Dim lngClerk As Long = lngClerkID
        'dim lngSaleType As Long

        Try

            strSQL = "SELECT tblRegistrations.lngRecordID as lngRecordID, tblRegistrations.lngRegistrationID as lngRegistrationID, tblRegistrations.lngBlockID as lngBlockID" & _
                  " FROM tblRegistrations " & _
                 " WHERE (((tblRegistrations.lngBlockID)=" & Me.cmbBlkCode.SelectedValue & " ));"

            objConnPos = New OleDbConnection
            objConnPos.ConnectionString = strPOSConn
            objConnPos.Open()

            objConnMain = New OleDbConnection
            objConnMain.ConnectionString = strCTConn
            objConnMain.Open()

            objCommandReg = New OleDbCommand
            objCommandReg.Connection = objConnMain
            objCommandReg.CommandText = strSQL

            rsTST = objCommandReg.ExecuteReader()

            objCommandInsert = New OleDbCommand
            objCommandInsert.Connection = objConnPos

            Dim Amt = CType(Me.txtAmount.Text, Decimal)

            Do While rsTST.Read
                
                objCommandInsert.CommandText = "Insert into tblSales(curTax,curTotalCharge,curSubTotal,dteSaleDate,lngCamperID,lngRegistrationID,lngClerkID,lngSaleTypeID,lngWSID,lngPaymentTypeID,lngStoreID) Values(0," & -Amt & "," & -Amt & ",'" & Format(Now(), "Short Date") & "'," & rsTST("lngRecordID") & "," & rsTST("lngregistrationID") & "," & lngClerkID.ToString() & ",9 ," & CType(My.Settings.lngWSID, Long) & ", 13 ," & CType(My.Settings.lngStoreID, Long) & ");"
                status = objCommandInsert.ExecuteNonQuery()

                Dim temSQLstr = "Select lngSaleID from tblSales where lngCamperID = " & rsTST("lngRecordID") & " and lngClerkID=" & lngClerkID.ToString() & " and lngSaleTypeID = 9 and lngWSID =" & CType(My.Settings.lngWSID, Long) & " and lngPaymentTypeID = 6  and lngStoreID = " & CType(My.Settings.lngStoreID, Long) & ";"

                ''free Resources

                Dim tempCommand = New OleDbCommand
                tempCommand.Connection = objConnPos
                tempCommand.CommandText = temSQLstr

                Dim temprs = tempCommand.ExecuteReader()

                Do While temprs.read
                    lngSale = temprs("lngSaleID")
                Loop

                'fcnAddDetails(lngSale)
                fcnFinishSale(lngSale, rsTST("lngRecordID"))

            Loop

            objConnPos.Close()

            objConnMain.Close()
            objCommandReg = Nothing
            objCommandInsert = Nothing
            rsTST.Close()

            MsgBox("Processing Completed", MsgBoxStyle.Information, "CampTrak")
     
        Catch ex As Exception
            subLogErr("subSale", ex)
        End Try
    End Sub


    Private Sub btnLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLabels.Click
        Try
            Dim frm As New FrmTSTWidrwalLablePreview
            frm.BlockID = Me.cmbBlkCode.SelectedValue
            frm.MdiParent = Me.MdiParent
            frm.Show()
        Catch ex As Exception

        End Try

    End Sub


    Public Sub fcnAddDetails(ByVal lngSale)

        Dim objConnPos As OleDbConnection
        Dim objCommand As OleDbCommand
        'Dim rs As OleDbDataReader
        Dim strSQL As String

        Dim curPrice As Decimal

        Dim lngSaleID As Long
        Dim lngInvID As Long

        Dim intQty As Integer

        lngInvID = 1385

        If IsNumeric(CType(Me.txtAmount.Text, Decimal)) Then
            curPrice = Me.txtAmount.Text
        Else
            MsgBox("Please enter a valid amount.")
            Me.txtAmount.Select()

            Exit Sub
        End If

        Try
            lngSaleID = lngSale

            intQty = 1

            objConnPos = New OleDbConnection
            objConnPos.ConnectionString = strPOSConn
            objConnPos.Open()

            objCommand = New OleDbCommand
            objCommand.Connection = objConnPos

            strSQL = "INSERT INTO tblSalesDetail " & _
                   "( lngSaleID, lngInventoryID, lngQuantity, " & _
                       "curPrice, curTax, curTotal ) " & _
                   "SELECT " & lngSaleID & ", " & lngInvID & ", " & intQty & ", " & _
                       curPrice & ", 0, " & curPrice
            objCommand.CommandText = strSQL
            Dim status As Integer = objCommand.ExecuteNonQuery
            objConnPos.Close()

        Catch ex As Exception
            subLogErr("fcnAddDetails", ex)
        End Try


    End Sub



    Public Sub fcnFinishSale(ByVal lngSaleID, ByVal lngCamper)

        Dim objConnPos As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim objCommandUpdate As OleDbCommand
        Dim rs As OleDbDataReader

        Dim objConnMain As OleDbConnection
        Dim objCommandInsert As OleDbCommand

        Dim strSQLRegID As String

        'Dim strSQL As String

        Dim lngTransID As Long
        Dim lngRegID As Long

        Try
            objConnPos = New OleDbConnection
            objConnPos.ConnectionString = strPOSConn
            objConnPos.Open()

            objConnMain = New OleDbConnection
            objConnMain.ConnectionString = strCTConn
            objConnMain.Open()


            objCommand = New OleDbCommand
            objCommand.Connection = objConnMain

            strSQLRegID = "SELECT lngRegistrationID FROM tblRegistrations WHERE lngRecordID = " & lngCamper & " AND lngBlockID = " & Me.cmbBlkCode.SelectedValue

            objCommand.CommandText = strSQLRegID

            rs = objCommand.ExecuteReader

            Do While rs.Read
                lngRegID = rs("lngRegistrationID")
            Loop

            objCommand = Nothing
            rs.Close()

            
            objCommandInsert = New OleDbCommand
            objCommandInsert.Connection = objConnMain

            Dim curCharge = Me.txtAmount.Text

            objCommandInsert.CommandText = " INSERT INTO tblTransactions(curCharge,dteDateAdded,lngTransTypeID,lngRegistrationID,lngRecordID) VALUES (" & CType(curCharge.ToString, Decimal) & ",#" & Format(Now(), "short date") & "#, 26 ," & lngRegID & "," & lngCamper & ");"

            Dim status = objCommandInsert.ExecuteNonQuery()
            rs.Close()


            objCommand = New OleDbCommand
            objCommand.Connection = objConnMain
            strSQLRegID = "SELECT lngTransactionID FROM tblTransactions WHERE curCharge = " & CType(curCharge.ToString, Decimal) & " AND lngTransTypeID = 26 AND lngRegistrationID = " & lngRegID & " and lngRecordID = " & lngCamper
            objCommand.CommandText = strSQLRegID
            rs = objCommand.ExecuteReader

            Do While rs.Read
                lngTransID = rs("lngTransactionID")
            Loop

            'put trans id in sale table
            objCommandUpdate = New OleDbCommand
            objCommandUpdate.Connection = objConnPos
            objCommandUpdate.CommandText = "UPDATE tblSales SET lngTransactionID = " & lngTransID & " WHERE lngSaleID=" & lngSaleID

            Dim temp = objCommandUpdate.ExecuteNonQuery()

            rs = Nothing
            objConnMain.Close()
            objConnPos.Close()
            objCommand = Nothing
            objCommandInsert = Nothing

        Catch ex As Exception
            subLogErr("fcnFinishSale", ex)
        End Try

    End Sub
End Class
