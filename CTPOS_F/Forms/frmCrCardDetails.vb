Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class frmCrCardDetails
    Public Shared strSQL As String
    Private Sub frmCrCardDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombo()
    End Sub

    Public Sub FillCombo()
        Dim strSQL1 As String

        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter

        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            strSQL1 = "SELECT tblStores.lngStoreID, tblStores.strStoreName FROM tblStores ORDER BY tblStores.strStoreName;"

            DataAdapter = New OleDbDataAdapter(strSQL1, objConn)
            ' create a new dataset
            Dim ds As DataSet = New DataSet
            ' fill dataset
            DataAdapter.Fill(ds)

            Me.cboStore.DataSource = ds.Tables(0)
            Me.cboStore.DisplayMember = ds.Tables(0).Columns(1).ToString
            Me.cboStore.ValueMember = ds.Tables(0).Columns(0).ToString

            Me.cboStore.Refresh()
            'subSetSelectedIndex(Me.cboStore, lngStoreID)

            DataAdapter = Nothing
            ds = Nothing

            strSQL1 = "SELECT tblClerks.lngClerkID, tblClerks.strUserName FROM tblClerks ORDER BY tblClerks.strUserName;"
           
            DataAdapter = New OleDbDataAdapter(strSQL1, objConn)

            ds = New DataSet

            DataAdapter.Fill(ds)

            Me.cboClerk.DataSource = ds.Tables(0)
            Me.cboClerk.DisplayMember = ds.Tables(0).Columns(1).ToString
            Me.cboClerk.ValueMember = ds.Tables(0).Columns(0).ToString

            Me.cboClerk.Refresh()

            'subSetSelectedIndex(Me.cboClerk, lngClerkID)

            objConn.Close()
            DataAdapter = Nothing
            ds = Nothing

        Catch ex As Exception
            subLogErr(Me.Name & ".FillCombo", ex)

        End Try


    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click

        Dim strWhere As String
        Dim strAnd As String

        If Len(Me.cboClerk.Text) = 0 And Len(Me.cboStore.Text) = 0 And Len(Me.dteSaleDate.Text) = 0 And Trim(Me.txtWSID.Text) = "" Then
            MsgBox("You must fill in at least one criteria (date required).")
            Exit Sub

        End If

        If Not IsDate(Me.dteSaleDate.Text) Then
            MsgBox("Properly formated date required")
            Exit Sub
        End If

        
        strWhere = ""
        strAnd = ""


        If Len(strWhere) > 0 Then
            strAnd = " And "
        Else
            strWhere = " Where "
        End If
        strWhere = strWhere & strAnd & " tblSales.lngClerkID=" & Me.cboClerk.SelectedValue


        If Not Len(Me.cboClerk.Text) = 0 Then
            If Len(strWhere) > 0 Then
                strAnd = " And "
            Else
                strWhere = " Where "
            End If
            strWhere = strWhere & strAnd & " tblSales.lngStoreID=" & Me.cboStore.SelectedValue
        End If

        If Not Len(Trim(Me.dteSaleDate.Text)) = 0 Then
            If Len(strWhere) > 0 Then
                strAnd = " And "
            Else
                strWhere = " Where "
            End If
            Dim SelectedDate = CType(Me.dteSaleDate.Text, Date)
            Dim DayAfterSelectedDate = FormatDateTime(DateAdd("d", 1, SelectedDate))
            strWhere = strWhere & strAnd & " tblSales.dteSaleDate >= #" & Me.dteSaleDate.Text & " 00:00:00 #  And  tblSales.dteSaleDate <= #" & DayAfterSelectedDate & " 00:00:00 #"
        End If

        If NZ(Me.txtWSID.Text) <> "" Then
            If Len(strWhere) > 0 Then
                strAnd = " And "
            Else
                strWhere = " Where "
            End If
            strWhere = strWhere & strAnd & " tblSales.lngWSid=" & Me.txtWSID.Text
        End If


        If Len(strWhere) > 0 Then
            strAnd = " And "
        Else
            strWhere = " Where "
        End If
        strWhere = strWhere & strAnd & " tblSales.strCCNumber <> """""

        strSQL = "SELECT     tblSales.lngSaleID, tblStores.strStoreName, tblSales.lngStoreID, tblSales.dteSaleDate, tblClerks.strUserName, tblSales.lngClerkID, " & _
                      "tblSales.lngSaleTypeID, tlkpSalesType.strSaleType, tblSales.lngTransactionID, tblSales.lngPaymentTypeID, tlkpPaymentType.strPaymentType, " & _
                      "tblSales.strCCNumber, tblSales.strCCExpDate, tblSales.dteZdOut, tblSales.lngWSID, tblSales.strAuthNumber, tblSalesDetail.lngSaleID AS Expr1, " & _
                      "SUM(tblSalesDetail.curTotal) AS SumOfcurTotal " & _
"FROM         (((((tblSales LEFT OUTER JOIN " & _
                      "tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) LEFT OUTER JOIN " & _
                      "tblStores ON tblSales.lngStoreID = tblStores.lngStoreID) INNER JOIN " & _
                      "tblClerks ON tblSales.lngClerkID = tblClerks.lngClerkID) INNER JOIN " & _
                      "tlkpSalesType ON tblSales.lngSaleTypeID = tlkpSalesType.lngSaleTypeID) INNER JOIN " & _
                      "tlkpPaymentType ON tblSales.lngPaymentTypeID = tlkpPaymentType.lngPaymentTypeID)" & strWhere & " " & _
" GROUP BY tblSales.lngSaleID, tblStores.strStoreName, tblSales.lngStoreID, tblSales.dteSaleDate, tblClerks.strUserName, tblSales.lngClerkID, " & _
                      "tblSales.lngSaleTypeID, tlkpSalesType.strSaleType, tblSales.lngTransactionID, tblSales.lngPaymentTypeID, tlkpPaymentType.strPaymentType, " & _
                      "tblSales.strCCNumber, tblSales.strCCExpDate, tblSales.dteZdOut, tblSales.lngWSID, tblSales.strAuthNumber, tblSalesDetail.lngSaleID; "
        strSQL = strSQL & strWhere

        'DoCmd.OpenReport("rptCreditCardDetailReport", acViewPreview, , , , strSQL)

        subShowCrCardDetails(Me.MdiParent)

    End Sub

End Class