Imports System.Data.OleDb

Public Class frmAdjSummarySetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseAdjSummarySetup()
    End Sub

    Private Sub frmAdjSummarySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim conPOS As OleDbConnection
        Dim cmdPOS As OleDbCommand
        Dim drCbo As OleDbDataReader

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Try

            conPOS = New OleDbConnection(strPOSConn)

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

            conPOS.Close()

            cmdPOS.Dispose()
            conPOS.Dispose()
            subSetSelectedIndex(Me.cboStore, lngStoreID)

        Catch ex As Exception
            subLogErr("frmAdjSummarySetup_Load", ex)

        End Try

        drCbo = Nothing
        cmdPOS = Nothing
        conPOS = Nothing

    End Sub

    Private Sub subManageVisibility(ByVal sender As Object, ByVal e As System.EventArgs) Handles radAllDates.CheckedChanged, radDateRange.CheckedChanged

        Me.lblStart.Visible = False

        Me.dtpStart.Visible = False
        Me.lblEnd.Visible = False

        Me.dtpEnd.Visible = False

        If Me.radDateRange.Checked Then
            Me.lblStart.Visible = True

            Me.dtpStart.Visible = True
            Me.lblEnd.Visible = True

            Me.dtpEnd.Visible = True
        End If

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim dteStart As Date
        Dim dteEnd As Date

        Dim lngStoreID As Long

        If Me.cboStore.SelectedItem Is Nothing Then
            MsgBox("Please select a store.")
            Me.cboStore.Focus()
            Exit Sub
        Else
            lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID
        End If

        If Me.radDateRange.Checked Then
            If Not IsDate(Me.dtpStart.Value) Then
                MsgBox("Please enter a valid start date.")
                Me.dtpStart.Focus()
                Exit Sub
            End If

            If Not IsDate(Me.dtpEnd.Value) Then
                MsgBox("Please enter a valid end date.")
                Me.dtpEnd.Focus()

                Exit Sub
            End If

            dteStart = Me.dtpStart.Value ' CType(Me.txtStart.Text, Date)
            dteEnd = Me.dtpEnd.Value ' CType(Me.txtEnd.Text, Date)

            subShowAdjSummaryPreview(lngStoreID, dteStart, dteEnd, Me.MdiParent)

        Else

            subShowAdjSummaryPreview(lngStoreID, Me.MdiParent)

        End If

    End Sub
End Class