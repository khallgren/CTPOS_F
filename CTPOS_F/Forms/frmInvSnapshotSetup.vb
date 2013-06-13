Imports System.Data.OleDb

Public Class frmInvSnapshotSetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseInvSnapshotSetup()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim dteRptDate As Date

        Dim lngCategoryID As Long
        Dim lngStoreID As Long

        If Not IsDate(Me.dtpDate.Value) Then
            MsgBox("Please enter a valid date to report on.")
            Me.dtpDate.Focus()
            Exit Sub
        End If

        If Me.cboCategory.SelectedItem Is Nothing Then
            MsgBox("Please select a category.")
            Me.cboCategory.Focus()
            Exit Sub
        End If

        If Me.cboStore.SelectedItem Is Nothing Then
            MsgBox("Please select a store.")
            Me.cboStore.Focus()
            Exit Sub
        End If

        dteRptDate = Me.dtpDate.Value ' CType(Me.txtDate.Text, Date)

        lngCategoryID = CType(Me.cboCategory.SelectedItem, clsCboItem).ID
        lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID

        subShowInvSnapshotPreview(lngCategoryID, lngStoreID, dteRptDate, Me.MdiParent)

    End Sub

    Private Sub frmInvSnapshotSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'load categories, stores
        Dim strSQL As String

        Try

            cboCategory.Items.Add(New clsCboItem(0, "All Categories"))
            cboStore.Items.Add(New clsCboItem(0, "All Stores"))

            Using conDB As New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT lngInvCategoryID, " & _
                            "strInvCategory " & _
                        "FROM tblInvCodeCategory " & _
                        "ORDER BY strInvCategory"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drCat As OleDbDataReader = cmdDB.ExecuteReader()

                        While drCat.Read

                            cboCategory.Items.Add(New clsCboItem(CType(drCat("lngInvCategoryID"), Long), drCat("strInvCategory").ToString))

                        End While

                        drCat.Close()

                    End Using

                    strSQL = "SELECT lngStoreID, " & _
                                "strStoreName " & _
                            "FROM tblStores " & _
                            "ORDER BY strStoreName"

                    cmdDB.CommandText = strSQL
                    cmdDB.Parameters.Clear()

                    Using drStores As OleDbDataReader = cmdDB.ExecuteReader()

                        While drStores.Read()

                            cboStore.Items.Add(New clsCboItem(CType(drStores("lngStoreID"), Long), drStores("strStoreName").ToString))

                        End While

                        drStores.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

            subSetSelectedIndex(Me.cboStore, lngStoreID)

        Catch ex As Exception
            subLogErr("frmInvSnapshotSetup.Load", ex)

        End Try

    End Sub
End Class