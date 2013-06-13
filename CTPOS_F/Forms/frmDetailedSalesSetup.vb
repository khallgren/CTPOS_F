Imports System.Data.OleDb

Public Class frmDetailedSalesSetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseDetSalesRptSetup()
    End Sub

    Private Sub frmDetailedSalesSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim conPOS As OleDbConnection
        Dim cmdPOS As OleDbCommand
        Dim drCbo As OleDbDataReader

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Try

            cboStore.Items.Add(New clsCboItem(0, "All Stores"))
            cboClerk.Items.Add(New clsCboItem(0, "All Clerks"))
            cboCategory.Items.Add(New clsCboItem(0, "All Categories"))

            'fill stores
            strSQL = "SELECT lngStoreID, " & _
                        "strStoreName " & _
                    "FROM tblStores " & _
                    "ORDER BY strStoreName; "

            conPOS = New OleDbConnection(strPOSConn)

            conPOS.Open()

            cmdPOS = New OleDbCommand(strSQL, conPOS)

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngStoreID").ToString, Long), drCbo("strStoreName").ToString)
                cboStore.Items.Add(cboItem)
            End While

            drCbo.Close()
            subSetSelectedIndex(Me.cboStore, lngStoreID)

            'fill clerks
            strSQL = "SELECT lngClerkID, " & _
                        "strClerkLastName + ', ' + strClerkFirstName AS strClerkName " & _
                    "FROM tblClerks " & _
                    "ORDER BY strClerkName;"

            cmdPOS.CommandText = strSQL

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngClerkID").ToString, Long), drCbo("strClerkName").ToString)
                cboClerk.Items.Add(cboItem)
            End While

            drCbo.Close()

            'fill categories
            strSQL = "SELECT lngInvCategoryID, " & _
                        "strInvCategory " & _
                    "FROM tblInvCodeCategory " & _
                    "ORDER BY strInvCategory"

            cmdPOS.CommandText = strSQL

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngInvCategoryID").ToString, Long), drCbo("strInvCategory").ToString)
                cboCategory.Items.Add(cboItem)
            End While

            drCbo.Close()

            'select defaults
            'cboStore.SelectedIndex = 0
            cboClerk.SelectedIndex = 0
            cboCategory.SelectedIndex = 0

            subSetSelectedIndex(Me.cboStore, lngStoreID)

        Catch ex As Exception
            subLogErr("frmDetailedSalesSetup_Load", ex)

        End Try

        drCbo = Nothing
        cmdPOS = Nothing
        conPOS = Nothing

    End Sub

    Private Sub subUpdateDateCriter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAllDates.CheckedChanged, radSpecificDate.CheckedChanged, radDateRange.CheckedChanged

        Me.lblStart.Visible = False
        Me.lblEnd.Visible = False
        Me.dtpStart.Visible = False
        Me.dtpEnd.Visible = False

        If Me.radSpecificDate.Checked Then
            Me.lblStart.Text = "Date:"
            Me.lblStart.Visible = True
            Me.dtpStart.Visible = True
        ElseIf Me.radDateRange.Checked Then
            Me.lblStart.Text = "Start:"
            Me.lblStart.Visible = True
            Me.lblEnd.Visible = True
            Me.dtpStart.Visible = True
            Me.dtpEnd.Visible = True
        End If

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim dteStart As Date
        Dim dteEnd As Date

        Dim lngStoreID As Long
        Dim lngClerkID As Long
        Dim lngCategoryID As Long
        Dim lngWSID As Long

        lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID
        lngClerkID = CType(Me.cboClerk.SelectedItem, clsCboItem).ID
        lngCategoryID = CType(Me.cboCategory.SelectedItem, clsCboItem).ID

        If Me.radAllWS.Checked Then
            lngWSID = 0
        Else
            lngWSID = My.Settings.lngWSID
        End If

        If Me.radAllDates.Checked Then
            subShowDetSalesRptPreview(Me.MdiParent, lngWSID, lngStoreID, lngClerkID, lngCategoryID)
        ElseIf Me.radSpecificDate.Checked Then

            If IsDate(Me.dtpStart.Text) Then
                dteStart = Me.dtpStart.Value 'CType(Me.dtpStart.Text, Date)
            Else
                MsgBox("Please enter a valid date.")
                Me.dtpStart.Focus()
                Exit Sub
            End If

            subShowDetSalesRptPreview(Me.MdiParent, lngWSID, lngStoreID, lngClerkID, lngCategoryID, dteStart)

        ElseIf Me.radDateRange.Checked Then

            If IsDate(Me.dtpStart.Text) Then
                dteStart = Me.dtpStart.Value ' CType(Me.dtpStart.Text, Date)
            Else
                MsgBox("Please enter a valid start date.")
                Me.dtpStart.Focus()
                Exit Sub
            End If

            If IsDate(Me.dtpEnd.Text) Then
                dteEnd = Me.dtpEnd.Value ' CType(Me.dtpEnd.Text, Date)
            Else
                MsgBox("Please enter a valid end date.")
                Me.dtpEnd.Focus()
                Exit Sub
            End If

            subShowDetSalesRptPreview(Me.MdiParent, lngWSID, lngStoreID, lngClerkID, lngCategoryID, dteStart, dteEnd)

        End If

    End Sub
End Class