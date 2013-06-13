Imports System.Data.OleDb

Public Class frmZOutSetup

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim strTitle As String

        Dim dteCounter As Date = Now
        Dim dteStart As Date
        Dim dteEnd As Date

        Dim lngStoreID As Long
        Dim lngWSID As Long

        Try

            lngWSID = CType(Me.cboWS.SelectedItem, clsCboItem).ID

            If lngWSID = 0 Then
                strTitle = "Z-Out Report, All Workstations"
            Else
                strTitle = "Z-Out Report, Workstation ID " & lngWSID
            End If

            lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID

            If lngStoreID = 0 Then
                strTitle += ", all stores"
            Else
                strTitle += ", " & CType(Me.cboStore.SelectedItem, clsCboItem).Item
            End If

            If Me.radPrevZDOut.Checked Then

                strTitle = strTitle & ", Z'd Out " & CType(Me.cboZdOut.SelectedItem, clsCboItem).ToString

                If Me.cboZdOut.SelectedIndex = -1 Then
                    MsgBox("Please select a Z-Out date.")
                    Me.cboZdOut.Focus()
                    Exit Sub
                End If

                dteStart = CType(CType(Me.cboZdOut.SelectedItem, clsCboItem).ToString, Date)

            ElseIf Me.radDateRange.Checked Then

                If Not IsDate(Me.txtStart.Text) Then
                    MsgBox("Please enter a valid start date.")
                    Me.txtStart.Focus()
                    Exit Sub
                ElseIf Not IsDate(Me.txtEnd.Text) Then
                    MsgBox("Please enter a valid end date.")
                    Me.txtEnd.Focus()
                    Exit Sub
                End If

                dteStart = CDate(Me.txtStart.Text)
                dteEnd = CDate(Me.txtEnd.Text)

                strTitle = strTitle & ", Z'd Out Between " & Me.txtStart.Text & " and " & Me.txtEnd.Text

            Else

                strTitle += " as of " & Now.ToString("MM/dd/yyyy h:mm tt")

            End If

            Me.Cursor = Cursors.WaitCursor

            subShowZOutPreview(lngStoreID, lngWSID, dteStart, dteEnd, strTitle, Me.MdiParent)

            Console.WriteLine("Setup1: " & DateDiff(DateInterval.Second, dteCounter, Now))
            dteCounter = Now

            subCloseZOutSetup()

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            subLogErr("frmZOutSetup.btnPreview", ex)

        End Try

        Console.WriteLine("Setup2: " & DateDiff(DateInterval.Second, dteCounter, Now))
        dteCounter = Now

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        subCloseZOutSetup()

    End Sub

    Private Sub frmZOutSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFillCbos()

    End Sub

    Private Sub subFillCbos()

        Dim drCbo As OleDbDataReader

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Try

            Using conPOS As New OleDbConnection(strPOSConn)

                conPOS.Open()

                strSQL = "SELECT dteZdOut " & _
                        "FROM tblSales " & _
                        "GROUP BY dteZdOut " & _
                        "HAVING dteZdOut Is Not Null " & _
                        "ORDER BY dteZdOut DESC "

                Using cmdPOS As New OleDbCommand(strSQL, conPOS)

                    drCbo = cmdPOS.ExecuteReader

                    While drCbo.Read

                        cboItem = New clsCboItem(drCbo("dteZdOut").ToString, drCbo("dteZdOut").ToString)

                        Me.cboZdOut.Items.Add(cboItem)

                    End While

                    drCbo.Close()

                    strSQL = "SELECT lngStoreID, " & _
                                "strStoreName " & _
                            "FROM tblStores " & _
                            "ORDER BY strStoreName"

                    cmdPOS.CommandText = strSQL

                    drCbo = cmdPOS.ExecuteReader()

                    While drCbo.Read

                        cboItem = New clsCboItem(CType(drCbo("lngStoreID"), Long), drCbo("strStoreName").ToString)

                        Me.cboStore.Items.Add(cboItem)

                    End While

                    drCbo.Close()

                    strSQL = "SELECT lngWSID " & _
                            "FROM tblSales " & _
                            "GROUP BY lngWSID " & _
                            "HAVING      (NOT (lngWSID IS NULL)) " & _
                            "ORDER BY lngWSID"

                    cmdPOS.CommandText = strSQL

                    drCbo = cmdPOS.ExecuteReader()

                    While drCbo.Read

                        cboItem = New clsCboItem(CType(drCbo("lngWSID"), Long), drCbo("lngWSID").ToString)

                        Me.cboWS.Items.Add(cboItem)

                    End While

                    drCbo.Close()

                End Using

                conPOS.Close()

            End Using

            'add static choices to cbos
            cboStore.Items.Insert(0, New clsCboItem(0, "All stores"))
            cboWS.Items.Insert(0, New clsCboItem(0, "All workstations"))

            'select defaults for cbos
            cboWS.SelectedIndex = cboWS.FindString(My.Settings.lngWSID.ToString())
            cboStore.SelectedIndex = 0

            If cboWS.SelectedIndex < 0 Then cboWS.SelectedIndex = 0

        Catch ex As Exception
            subLogErr("frmZOutSetup.subFillCbos", ex)

        End Try

    End Sub

    Private Sub radPrevZDOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPrevZDOut.CheckedChanged

        Me.cboZdOut.Enabled = False

        If Me.radPrevZDOut.Checked Then Me.cboZdOut.Enabled = True

    End Sub

    Private Sub radDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDateRange.CheckedChanged

        Me.txtEnd.Enabled = False
        Me.txtStart.Enabled = False

        If Me.radDateRange.Checked Then
            Me.txtStart.Enabled = True
            Me.txtEnd.Enabled = True
        End If

    End Sub

End Class