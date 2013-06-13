Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class frmMonthlyInvSetup

    Private Sub frmMonthlyInvSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFillCbos()

    End Sub

    Private Sub subFillCbos()

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Dim intI As Integer

        Try

            For intI = 1 To 12

                cboItem = New clsCboItem(intI, MonthName(intI))

                Me.cboMonth.Items.Add(cboItem)

            Next

            For intI = Year(Now) + 1 To Year(Now) - 9 Step -1
                cboYear.Items.Add(intI)
            Next

            For intI = 0 To cboYear.Items.Count - 1
                If cboYear.Items(intI) = Year(Now) Then cboYear.SelectedIndex = intI
            Next

            Using conPOS As OleDbConnection = New OleDbConnection(strPOSConn)

                conPOS.Open()

                strSQL = "SELECT tblStores.lngStoreID, " & _
                            "tblStores.strStoreName " & _
                        "FROM tblStores " & _
                        "ORDER BY tblStores.strStoreName;"

                Using cmdPOS As OleDbCommand = New OleDbCommand(strSQL, conPOS)

                    Using drStores As OleDbDataReader = cmdPOS.ExecuteReader()

                        While drStores.Read

                            cboItem = New clsCboItem(CType(drStores("lngStoreID"), Long), drStores("strStoreName").ToString)

                            Me.cboStore.Items.Add(cboItem)

                        End While

                        drStores.Close()

                    End Using

                End Using

                conPOS.Close()

            End Using

            subSetSelectedIndex(Me.cboStore, lngStoreID)
            subSetSelectedIndex(Me.cboMonth, Now.Month)

        Catch ex As Exception
            subLogErr(Me.Name & ".subFillCbos", ex)

        End Try

    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click

        Dim lngMonth As Long
        Dim lngStoreID As Long

        If IsDBNull(Me.cboMonth.SelectedItem) Then
            MsgBox("Please select a month to report on.")
            Me.cboMonth.Focus()
            Exit Sub
        Else
            lngMonth = CType(Me.cboMonth.SelectedItem, clsCboItem).ID
        End If

        If cboYear.SelectedIndex < 0 Then
            MessageBox.Show("Please select a year.")
            cboYear.Focus()
            Exit Sub
        End If

        If IsDBNull(Me.cboStore.SelectedItem) Then
            MsgBox("Please select a store to report on.")
            Me.cboStore.Focus()
            Exit Sub
        Else
            lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID
        End If

        Dim lngYear As Long

        Try
            lngYear = Convert.ToInt32(cboYear.SelectedItem)
        Catch ex As Exception
            lngYear = 0
        End Try

        subShowMonthlyInvPreview(Me.chkIncludeInactive.Checked, lngMonth, lngYear, lngStoreID, Me.MdiParent)

    End Sub

End Class