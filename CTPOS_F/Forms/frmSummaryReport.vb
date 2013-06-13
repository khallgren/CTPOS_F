Imports System.Data.OleDb
Imports Microsoft.Win32

Public Class frmSummaryReport
    Public Shared strCriteria As String
    Public Shared stDocName As String
    Public Shared SummaryOnly As Boolean


    Private Sub frmSummaryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombo()
        Me.rdbsummary.Select()
        Me.rdbRecalc.Select()
    End Sub

    Public Sub FillCombo()
        Dim strSQL As String

        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter

        objConn = New OleDbConnection
        objConn.ConnectionString = strPOSConn
        objConn.Open()

        strSQL = "SELECT tblInvCodeCategory.lngInvCategoryID as lngInvCategoryID, tblInvCodeCategory.strInvCategory as strInvCategory FROM tblInvCodeCategory"

        DataAdapter = New OleDbDataAdapter(strSQL, objConn)
        ' create a new dataset
        Dim ds As DataSet = New DataSet
        ' fill dataset
        DataAdapter.Fill(ds)


        Me.cboCatagory.DataSource = ds.Tables(0)
        Me.cboCatagory.DisplayMember = ds.Tables(0).Columns(1).ToString
        Me.cboCatagory.ValueMember = ds.Tables(0).Columns(0).ToString

        Me.cboCatagory.Refresh()
        
        objConn.Close()
        DataAdapter = Nothing
        ds = Nothing

    End Sub

    Private Sub rdbSingleDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSingleDate.CheckedChanged
        If Me.rdbSingleDate.Checked Then
            Me.dteStartDate.Enabled = True
        Else
            Me.dteStartDate.Enabled = False
        End If
    End Sub

    Private Sub rdbRangeDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRangeDate.CheckedChanged
        If Me.rdbRangeDate.Checked Then
            Me.dteStartDate.Enabled = True
            Me.dteEndDate.Enabled = True
        Else
            Me.dteStartDate.Enabled = False
            Me.dteEndDate.Enabled = False
        End If
    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        'Dim strSQL As String

        Dim blnAnd As Boolean

        'fcnFixTrans()

        strCriteria = ""

        SummaryOnly = Me.chkSummaryOnly.Checked

        If Me.cboCatagory.SelectedValue Then
            strCriteria = "tblInventory.lngInvCategoryID =" & Me.cboCatagory.SelectedValue
            blnAnd = True
        End If

        
        If Me.rdbsummary.Checked Then
            stDocName = "rptSalesSummary"

        ElseIf Me.rdbSingleDate.Checked Then

            Dim SelectedDate = CType(Me.dteStartDate.Text, Date)
            Dim DayAfterSelectedDate = FormatDateTime(DateAdd("d", 1, SelectedDate))

            If blnAnd = True Then strCriteria = strCriteria & " AND "
            strCriteria = strCriteria & " dteSaleDate >='" & Me.dteStartDate.Text & " 00:00:00' AND dteSaleDate <= '" & DayAfterSelectedDate & " 00:00:00'"
            stDocName = "rptSalesSummaryByDate"
        ElseIf Me.rdbRangeDate.Checked Then
            If blnAnd = True Then strCriteria = strCriteria & " AND "
            strCriteria = strCriteria & " dteSaleDate >='" & Me.dteStartDate.Text & " 00:00:00'"
            strCriteria = strCriteria & " AND dteSaleDate <='" & Me.dteEndDate.Text & " 00:00:00'"
            stDocName = "rptSalesSummaryByDate"
        End If


        subReCalc()

        subShowSummaryReportPreview(Me.MdiParent)


    End Sub


    Public Sub subReCalc()
        '--------- this needs to be get fixed as we currently are not creating any table here.
        '--------- 'tblRecalc' is a temporary table.
        'DoCmd.SetWarnings(False)

        'If fcnDoesTableExist("tblRecalc") Then DoCmd.DeleteObject(acTable, "tblReCalc")

        'DoCmd.OpenQuery("qryReCalcCombined", acNormal)
        'DoCmd.OpenQuery("qryReCalc", acNormal)
        'DoCmd.SetWarnings(True)

    End Sub

   
End Class