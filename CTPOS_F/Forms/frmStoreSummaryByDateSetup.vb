Imports System.Data.OleDb

Public Class frmStoreSummaryByDateSetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseStoreSummaryByDateSetup()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim strCaption As String

        Dim dteStart As Date
        Dim dteEnd As Date

        Try

            If dtpStart.Value <> Date.MinValue Then
                dteStart = dtpStart.Value
            Else
                MsgBox("Please enter a valid start date.")
                dtpStart.Focus()
                Exit Sub
            End If

            If dtpEnd.Value <> Date.MinValue Then
                dteEnd = dtpEnd.Value
            Else
                MsgBox("Please enter a valid end date.")
                dtpEnd.Focus()
                Exit Sub
            End If

            strCaption = dteStart.ToString("MM/dd/yyyy") & " - " & dteEnd.ToString("MM/dd/yyyy")

            subShowStoreSummaryPreview(dteStart, dteEnd, strCaption, Me.MdiParent)

        Catch ex As Exception
            subLogErr("frmStoreSummaryByDateSetup_btnPreviewClick", ex)

        End Try

    End Sub

    Private Sub cboWeek_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboWeek.MouseDown

        Me.cboWeek.DroppedDown = True

    End Sub

    Private Sub frmStoreSummaryByDateSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        Try
            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                strSQL = "SELECT tlkpWeekDesc.lngWeekID, " & _
                            "tlkpWeekDesc.strWeekDesc " & _
                        "FROM tlkpWeekDesc " & _
                        "ORDER BY tlkpWeekDesc.intSortOrder, tlkpWeekDesc.dteStartDate"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drWeeks As OleDbDataReader = cmdDB.ExecuteReader()

                        Dim lngWeekID As Long
                        Dim strWeek As String

                        While drWeeks.Read

                            Try
                                lngWeekID = Convert.ToInt32(drWeeks("lngWeekID"))
                            Catch ex As Exception
                                lngWeekID = 0
                            End Try
                            Try
                                strWeek = Convert.ToString(drWeeks("strWeekDesc"))
                            Catch ex As Exception
                                strWeek = ""
                            End Try

                            Dim cboWeekToAdd As clsCboItem = New clsCboItem(lngWeekID, strWeek)

                            cboWeek.Items.Add(cboWeekToAdd)

                        End While

                        drWeeks.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboWeek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWeek.SelectedIndexChanged

        Dim strSQL As String
        Dim lngWeekID As Long

        If cboWeek.SelectedIndex >= 0 Then

            Try
                lngWeekID = Convert.ToInt32(CType(cboWeek.SelectedItem, clsCboItem).ID)
            Catch ex As Exception
                lngWeekID = 0
            End Try

            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                strSQL = "SELECT tlkpWeekDesc.dteStartDate, tlkpWeekDesc.dteEndDate " & _
                         "FROM tlkpWeekDesc " & _
                         "WHERE tlkpWeekDesc.lngWeekID=" & lngWeekID

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drWeek As OleDbDataReader = cmdDB.ExecuteReader()

                        If drWeek.Read() Then

                            Dim dteStart As Date
                            Dim dteEnd As Date

                            Try
                                dteStart = Convert.ToDateTime(drWeek("dteStartDate"))
                            Catch ex As Exception
                                dteStart = Date.MinValue
                            End Try
                            Try
                                dteEnd = Convert.ToDateTime(drWeek("dteEndDate"))
                            Catch ex As Exception
                                dteEnd = Date.MinValue
                            End Try

                            If dteStart <> Date.MinValue Then dtpStart.Value = dteStart
                            If dteEnd <> Date.MinValue Then dtpEnd.Value = dteEnd

                        End If

                        drWeek.Close()

                    End Using

                End Using

            End Using

        Else

            dtpStart.Value = Nothing

            dtpEnd.Value = Nothing

        End If

    End Sub
End Class