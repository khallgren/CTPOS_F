Imports System.Data.OleDb

Public Class frmInvCodeSheetSetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseInvCodeSheetSetup()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim strSortField As String

        Dim lngCategoryID As Long
        Dim lngStoreID As Long

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

        If Me.cboOrderBy.SelectedItem Is Nothing Then
            MsgBox("Please select a sort option.")
            Me.cboOrderBy.Focus()
            Exit Sub
        End If

        lngCategoryID = CType(Me.cboCategory.SelectedItem, clsCboItem).ID
        lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID
        strSortField = CType(Me.cboOrderBy.SelectedItem, clsCboItem).ID

        subShowInvCodeSheetPreview(lngCategoryID, lngStoreID, strSortField, Me.MdiParent)

    End Sub

    Private Sub frmInvCodeSheetSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'load categories, stores
        Dim conPOS As OleDbConnection
        Dim cmdPOS As OleDbCommand
        Dim drCbo As OleDbDataReader

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Try

            Me.cboOrderBy.Items.Add(New clsCboItem("strItemName", "Item Name"))
            Me.cboOrderBy.Items.Add(New clsCboItem("strStockCode", "Stock Code"))
            Me.cboOrderBy.Items.Add(New clsCboItem("intQOH", "Current Qty"))

            conPOS = New OleDbConnection(strPOSConn)

            conPOS.Open()

            strSQL = "SELECT lngInvCategoryID, " & _
                        "strInvCategory " & _
                    "FROM tblInvCodeCategory " & _
                    "ORDER BY strInvCategory"

            cmdPOS = New OleDbCommand(strSQL, conPOS)

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngInvCategoryID"), Long), drCbo("strInvCategory").ToString)
                cboCategory.Items.Add(cboItem)
            End While

            drCbo.Close()

            strSQL = "SELECT lngStoreID, " & _
                        "strStoreName " & _
                    "FROM tblStores " & _
                    "ORDER BY strStoreName"

            cmdPOS.CommandText = strSQL

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngStoreID"), Long), drCbo("strStoreName").ToString)
                cboStore.Items.Add(cboItem)
            End While

            drCbo.Close()

            conPOS.Close()

            cmdPOS.Dispose()
            conPOS.Dispose()

            subSetSelectedIndex(Me.cboStore, lngStoreID)

        Catch ex As Exception
            subLogErr("frmInvCodeSheetSetup.Load", ex)

        End Try

        drCbo = Nothing
        cmdPOS = Nothing
        conPOS = Nothing

    End Sub

End Class