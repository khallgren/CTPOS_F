Imports System.Data.OleDb

Public Class frmZOutSetup

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim dteCounter As Date = Now

        Try

            If IsNothing(objZOutPreview) Then objZOutPreview = New frmZOutPreview

            If Me.radAllWS.Checked Then
                objZOutPreview.lngWSID = 0
                objZOutPreview.strTitle = "Z-Out Report, All Workstations"
            ElseIf Me.radCurrentWS.Checked Then
                objZOutPreview.lngWSID = lngWSID
                objZOutPreview.strTitle = "Z-Out Report, Workstation ID " & lngWSID
            End If

            If Me.radNotZDOut.Checked Then
                objZOutPreview.lngZOutStatus = clsGlobalEnum.conZOUTSTATUS.conNotZDOut
            ElseIf Me.radPrevZDOut.Checked Then

                objZOutPreview.lngZOutStatus = clsGlobalEnum.conZOUTSTATUS.conPrevZDOut
                objZOutPreview.strTitle = objZOutPreview.strTitle & ", Z'd Out " & CType(Me.cboZdOut.SelectedItem, clsCboItem).ToString

                If Me.cboZdOut.SelectedIndex = -1 Then
                    MsgBox("Please select a Z-Out date.")
                    Me.cboZdOut.Focus()
                    Exit Sub
                End If

                objZOutPreview.dteZdOut = CType(CType(Me.cboZdOut.SelectedItem, clsCboItem).ToString, Date)

            ElseIf Me.radDateRange.Checked Then

                objZOutPreview.lngZOutStatus = clsGlobalEnum.conZOUTSTATUS.conDateRange

                If Not IsDate(Me.txtStart.Text) Then
                    MsgBox("Please enter a valid start date.")
                    Me.txtStart.Focus()
                    Exit Sub
                ElseIf Not IsDate(Me.txtEnd.Text) Then
                    MsgBox("Please enter a valid end date.")
                    Me.txtEnd.Focus()
                    Exit Sub
                End If

                objZOutPreview.dteStart = CDate(Me.txtStart.Text)
                objZOutPreview.dteEnd = CDate(Me.txtEnd.Text)

                objZOutPreview.strTitle = objZOutPreview.strTitle & ", Z'd Out Between " & Me.txtStart.Text & " and " & Me.txtEnd.Text

            End If

            Me.Cursor = Cursors.WaitCursor

            subShowZOutPreview(Me.MdiParent)

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

        Dim objConn As New OleDbConnection(strPOSConn)
        Dim objCommand As OleDbCommand

        Dim drZdOut As OleDbDataReader

        Dim strSQL As String

        objConn.Open()

        strSQL = "SELECT dteZdOut " & _
                "FROM tblSales " & _
                "GROUP BY dteZdOut " & _
                "HAVING dteZdOut Is Not Null " & _
                "ORDER BY dteZdOut "

        objCommand = New OleDbCommand(strSQL, objConn)

        drZdOut = objCommand.ExecuteReader

        While drZdOut.Read

            Dim cboZdOut As New clsCboItem(drZdOut("dteZdOut").ToString, drZdOut("dteZdOut").ToString)

            Me.cboZdOut.Items.Add(cboZdOut)

        End While

        drZdOut.Close()

        objConn.Close()

        objCommand.Dispose()
        objConn.Dispose()

        drZdOut = Nothing
        objCommand = Nothing
        objConn = Nothing

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