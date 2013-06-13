Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb


Public Class frmZOutPreview

    Private objZOutRpt As rptZOut

    Private strTitle As String

    Private dteStart As Date
    Private dteEnd As Date

    Private lngWSID As Long
    Private lngStoreID As Long

    Public Sub New(ByVal _lngStoreID As Long, ByVal _lngWSID As Long, ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strTitle As String)

        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            strTitle = _strTitle
            dteStart = _dteStart
            dteEnd = _dteEnd
            lngWSID = _lngWSID
            lngStoreID = _lngStoreID
        Catch ex As Exception
            subLogErr("frmZoutPreview_New", ex)
        End Try

    End Sub

    Private Sub subConfigureCrystalReports()

        Dim strZOutSQL As String
        Dim strZOutPmtTypeSQL As String
        Dim strZoutTotalsSQL As String
        
        Dim strWhere As String

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "start"
        Dim dteCounter As Date = Now

        If dteStart = #12:00:00 AM# Then

            strWhere = " WHERE tblSales.dteZdOut Is Null "

        ElseIf dteEnd = #12:00:00 AM# Then

            strWhere = " WHERE tblSales.dteZdOut=#" & Me.dteStart & "# "

        Else

            strWhere = " WHERE tblSales.dteSaleDate >= #" & Me.dteStart & "# AND tblSales.dteSaleDate <= #" & Me.dteEnd & "# "

        End If

        If strWhere = "" Then
            If Me.lngWSID <> 0 Then strWhere = strWhere & " WHERE lngWSID=" & Me.lngWSID & " "
        Else
            If Me.lngWSID <> 0 Then strWhere = strWhere & " AND lngWSID=" & Me.lngWSID & " "
        End If

        If strWhere = "" Then
            If Me.lngStoreID <> 0 Then strWhere = strWhere & " WHERE lngStoreID=" & Me.lngStoreID & " "
        Else
            If Me.lngStoreID <> 0 Then strWhere = strWhere & " AND lngStoreID=" & Me.lngStoreID & " "
        End If

        If blnUseSQLServer Then strWhere = Replace(strWhere, "#", "'")

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & strWhere

        strZOutSQL = "SELECT tblSales.lngSaleID, tlkpPaymentType.lngPaymentTypeID, tblSalesDetail.curPrice, tblSalesDetail.lngQuantity, tblSales.dteSaleDate, tblSales.lngWSID, tblSales.curSubTotal, tlkpPaymentType.strPaymentType, tblSales.curTotalCharge, tblSales.curTax, tblInvCodeCategory.strInvCategory " & _
                        "FROM (((tblSales " & _
                            "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) " & _
                            "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID) " & _
                            "INNER JOIN tblInvCodeCategory ON tblInventory.lngInvCategoryID = tblInvCodeCategory.lngInvCategoryID) " & _
                            "INNER JOIN tlkpPaymentType ON tblSales.lngPaymentTypeID = tlkpPaymentType.lngPaymentTypeID "
        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strzoutsql: " & strZOutSQL

        strZOutPmtTypeSQL = "SELECT tlkpPaymentType.lngPaymentTypeID, tblSales.lngWSID, SUM(tblSales.curSubTotal) AS curSubTotal, tlkpPaymentType.strPaymentType, SUM(tblSales.curTotalCharge) AS curTotalCharg, SUM(tblSales.curTax) AS curTax,  tblSales.dteZdOut " & _
                        "FROM tblSales " & _
                            "INNER JOIN tlkpPaymentType ON tblSales.lngPaymentTypeID = tlkpPaymentType.lngPaymentTypeID " & _
                        strWhere & " " & _
                        "GROUP BY tlkpPaymentType.lngPaymentTypeID, tblSales.lngWSID, tlkpPaymentType.strPaymentType, tblSales.dteZdOut " & _
                        "ORDER BY tlkpPaymentType.strPaymentType"

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strzoutpmttypesql: " & strZOutPmtTypeSQL

        strZoutTotalsSQL = "SELECT tblSales.lngSaleID, tblSales.dteSaleDate, tblSales.lngWSID, tblSales.curSubTotal, tblSales.curTotalCharge, tblSales.curTax " & _
                "FROM tblSales "

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-strzouttotalssql: " & strZoutTotalsSQL

        strZOutSQL = strZOutSQL & strWhere & ";"
        strZOutPmtTypeSQL = strZOutPmtTypeSQL
        strZoutTotalsSQL = strZoutTotalsSQL & strWhere & ";"

        Console.WriteLine("1: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        'set select command of adapter for main report
        Me.daZOut.SelectCommand.CommandText = strZOutSQL
        Me.daZOutPmtType.SelectCommand.CommandText = strZOutPmtTypeSQL
        Me.daZOutTotals.SelectCommand.CommandText = strZoutTotalsSQL

        Console.WriteLine("2: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "about to fill qryzout"
        Me.daZOut.Fill(Me.dsZOutForRpt, "qryZOut")
        Console.WriteLine("3: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "about to fill qryzoutpmttype"
        Me.daZOutPmtType.Fill(Me.dsZOutPmtTypeForRpt, "qryZOutPmtType")
        Console.WriteLine("4: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "about to fill qryZouttotals"
        Me.daZOutTotals.Fill(Me.dsZOutTotalsForRpt, "qryZOutTotals")
        Console.WriteLine("5: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        objZOutRpt = New rptZOut

        Console.WriteLine("6: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now
        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "setting rptzoutpmttype"
        objZOutRpt.Subreports("rptZOutPmtType").SetDataSource(Me.dsZOutPmtTypeForRpt)
        Console.WriteLine("7: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "setting rptzouttotals"
        objZOutRpt.Subreports("rptZOutTotals").SetDataSource(Me.dsZOutTotalsForRpt)
        Console.WriteLine("8: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "setting objzoutrpt"
        objZOutRpt.SetDataSource(Me.dsZOutForRpt)
        Console.WriteLine("9: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now
        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "formula fields"
        objZOutRpt.DataDefinition.FormulaFields("txtTitle").Text = """" & Me.strTitle & """"

        If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "setting rpt source"
        rvwZOut.ReportSource = objZOutRpt
        Console.WriteLine("10: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

    End Sub

    Private Sub frmZOutPreview_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String

        Try

            If MsgBox("Z-Out this workstation?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                objConn = New OleDbConnection(strPOSConn)

                objConn.Open()

                strSQL = "UPDATE tblSales " & _
                        "SET dteZdOut='" & Now & "' " & _
                        "WHERE dteZdOut Is Null AND " & _
                            "lngWSID=" & Me.lngWSID & ";"

                objCommand = New OleDbCommand(strSQL, objConn)

                objCommand.ExecuteNonQuery()

                objConn.Close()

                objCommand.Dispose()
                objConn.Dispose()

                objCommand = Nothing
                objConn = Nothing

            End If

            objZOutPreview.Dispose()
            objZOutPreview = Nothing

        Catch ex As Exception

            subLogErr("frmZoutPreview.Close", ex)

        End Try

    End Sub

    Private Sub frmZOutPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            subConfigureCrystalReports()
        Catch ex As Exception
            subLogErr("frmZOutPreview_Load", ex)
        End Try

    End Sub

End Class