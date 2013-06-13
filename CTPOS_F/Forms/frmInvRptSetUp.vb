Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class frmInvRptSetup

    Public Shared strSQLGlobal As String

    Private Sub frmInvRptSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFillCbos()

    End Sub

    Private Sub subFillCbos()

        Dim strSQL As String

        Dim cboItm As clsCboItem

        'add blank items
        cboItm = New clsCboItem(0, "All Categories")

        cboPickCatagory.Items.Add(cboItm)

        'add blank items
        cboItm = New clsCboItem(0, "All Stores")

        cboStore.Items.Add(cboItm)

        Try

            Using conPOSDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conPOSDB.Open()

                strSQL = "SELECT tblInvCodeCategory.lngInvCategoryID, " & _
                            "tblInvCodeCategory.strInvCategory " & _
                        "FROM tblInvCodeCategory " & _
                        "ORDER BY tblInvCodeCategory.strInvCategory;"

                Using cmdPOSDB As OleDbCommand = New OleDbCommand(strSQL, conPOSDB)

                    Using drInv As OleDbDataReader = cmdPOSDB.ExecuteReader()
                        
                        While drInv.Read()

                            cboItm = New clsCboItem(CType(drInv("lngInvCategoryID"), Long), drInv("strInvCategory").ToString())

                            cboPickCatagory.Items.Add(cboItm)

                        End While

                        drInv.Close()

                    End Using

                    strSQL = "SELECT tblStores.lngStoreID, " & _
                                "tblStores.strStoreName " & _
                            "FROM tblStores " & _
                            "ORDER BY tblStores.strStoreName;"

                    cmdPOSDB.Parameters.Clear()
                    cmdPOSDB.CommandText = strSQL

                    Using drStores As OleDbDataReader = cmdPOSDB.ExecuteReader()
                        
                        While drStores.Read()

                            cboItm = New clsCboItem(CType(drStores("lngStoreID"), Long), drStores("strStoreName").ToString())

                            cboStore.Items.Add(cboItm)

                        End While

                        drStores.Close()

                    End Using

                End Using

                conPOSDB.Close()

            End Using

        Catch ex As Exception

            subLogErr(Me.Name & ".FillCombo", ex)

        End Try

        subSetSelectedIndex(Me.cboStore, lngStoreID)

        If Me.cboPickCatagory.Items.Count > 0 Then Me.cboPickCatagory.SelectedIndex = 0

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim lngStoreID As Long
        Dim lngCategoryID As Long

        If Me.cboStore.SelectedItem Is Nothing Then
            MsgBox("Please select a store to report on.")
            Me.cboStore.Focus()
            Exit Sub
        End If

        If Me.cboPickCatagory.SelectedItem Is Nothing Then
            MsgBox("Please select a category to report on.")
            Me.cboPickCatagory.Focus()
            Exit Sub
        End If

        lngStoreID = CType(Me.cboStore.SelectedItem, clsCboItem).ID
        lngCategoryID = CType(Me.cboPickCatagory.SelectedItem, clsCboItem).ID

        subShowInvRptPreview(Me.chkIncludeInactive.Checked, lngCategoryID, lngStoreID, Me.MdiParent)

    End Sub

End Class