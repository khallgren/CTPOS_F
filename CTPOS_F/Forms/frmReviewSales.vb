
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


Public Class frmReviewSales

    Private Sub btnRefreshRvSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRvSales.Click
        subChangeRS()
    End Sub
    Private Sub subChangeRS()

        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter
        Dim strSQL As String

        Try
            strSQL = "SELECT tblSales.lngSaleID AS SaleID, tblSales.dteSaleDate AS SaleDate, tlkpPaymentType.strPaymentType as PaymentType, tblSales.curTotalCharge AS Total, tblSales.lngClerkID , tblSales.lngTransactionID as TrId, tblSales.lngWSID, tblSales.dteZdOut, tblSales.strPhone FROM tblSales INNER JOIN tlkpPaymentType ON tblSales.lngPaymentTypeID = tlkpPaymentType.lngPaymentTypeID WHERE (((tblSales.lngSaleTypeID)<>7))"
            If Me.chkClerkOnly.Checked Then
                strSQL = strSQL & " and lngClerkID=" & lngClerkID.ToString()
            End If

            If Me.chkTodayOnly.Checked Then
                If blnUseSQLServer Then
                    strSQL = strSQL & " and (DATEDIFF(day, tblSales.dteSaleDate, GETDATE()) = 0)"
                Else
                    strSQL = strSQL & " and dteSaleDate=#" & Format(Now, "short date") & "#"
                End If

            End If

            Dim phone = Me.txtPhone.Text
            If Len(Me.txtPhone.Text) > 0 Then
                strSQL = strSQL & " and ((tblSales.strphone) ='" & phone & "')"
            End If

            If Me.chkWSOnly.Checked Then
                strSQL = strSQL & " and lngWSID=" & CType(My.Settings.lngWSID, Long)
            End If

            If Me.chkZoutOnly.Checked Then
                strSQL = strSQL & " and ((tblSales.dteZdOut) Is Not Null)"
            Else
                'strSQL = strSQL & " and ((tblSales.dteZdOut) Is Null)"
            End If

            If Len(Me.txtPhone.Text) > 0 Then
                strSQL = strSQL & " and ((tblSales.strphone) ='" & phone & "')"
            End If

            strSQL = strSQL & " ORDER BY tblSales.lngSaleID;"

            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            DataAdapter = New OleDbDataAdapter(strSQL, objConn)
            ' create a new dataset
            Dim ds As DataSet = New DataSet
            ' fill dataset
            DataAdapter.Fill(ds)

            Me.grdRevSales.DataSource = ds.Tables(0)
            Me.grdRevSales.Refresh()

        Catch ex As Exception
            subLogErr("subChangeRS", ex)
        End Try

    End Sub


    Private Sub grdRevSales_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRevSales.CellClick
        Select Case e.ColumnIndex
            Case Is = 0
                subPrintReceipt(CType(grdRevSales.Rows.Item(e.RowIndex).Cells(2).Value, Long))
            Case Is = 1
                Dim lngSaleID As Long
                Dim lngTransID As Long

                Try
                    lngSaleID = CType(grdRevSales.Rows.Item(e.RowIndex).Cells(2).Value, Long)
                Catch ex As Exception
                    lngSaleID = 0
                End Try

                Try
                    lngTransID = CType(grdRevSales.Rows.Item(e.RowIndex).Cells(7).Value, Long)
                Catch ex As Exception
                    lngTransID = 0
                End Try

                Void_Sales(lngSaleID, lngTransID)
                subChangeRS()
        End Select
    End Sub

  

    Private Sub Void_Sales(ByVal lngSaleID As Long, ByVal lngTransactionID As Long)
        Dim varPassword As Object
        Dim strSQL As String
        Dim strSQL2 As String
        Dim lngSale As Long

        Dim objPOSConn As OleDbConnection
        Dim objCTConn As OleDbConnection
        Dim objCmdDeleteSales As OleDbCommand
        Dim objCmdDeleteTRans As OleDbCommand

        Try
            objPOSConn = New OleDbConnection
            objPOSConn.ConnectionString = strPOSConn
            objPOSConn.Open()

            objCTConn = New OleDbConnection
            objCTConn.ConnectionString = strCTConn
            objCTConn.Open()

            strSQL = "delete from tblsales where [lngSaleId]="
            strSQL2 = "DELETE from tblTransactions WHERE [lngTransactionID]="

            varPassword = InputBox("Input your user password to void sale", "CampTrak")
            If varPassword = "" Then Exit Sub
            If varPassword = strPassword Then
                lngSale = lngSaleID
                strSQL = strSQL & lngSale

                If Not IsDBNull(lngTransactionID) Then
                    strSQL2 = strSQL2 & lngTransactionID
                End If

                objCmdDeleteSales = New OleDbCommand

                objCmdDeleteSales.Connection = objPOSConn
                objCmdDeleteSales.CommandText = strSQL
                objCmdDeleteSales.ExecuteNonQuery()

                objCmdDeleteTRans = New OleDbCommand

                objCmdDeleteTRans.Connection = objCTConn
                objCmdDeleteTRans.CommandText = strSQL2
                objCmdDeleteTRans.ExecuteNonQuery()

                objCTConn.Close()
                objPOSConn.Close()

                MsgBox("Sale Removed")
            End If
        Catch ex As Exception
            subLogErr("Void_Sales", ex)
        Finally
     
        End Try

    End Sub

   
   
   

End Class