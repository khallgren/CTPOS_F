Imports System.Data.OleDb

Public Class frmInventoryLookup

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmInventoryLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subLoadCategories()
        subLoadInventory()
        strItemCode = ""

    End Sub

    Private Sub subLoadCategories()

        Dim cboCategories As clsCboItem

        Dim strSQL As String

        Try

            Me.cboCategory.Items.Clear()

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT tblInvCodeCategory.lngInvCategoryID, " & _
                            "tblInvCodeCategory.strInvCategory " & _
                        "FROM tblInvCodeCategory " & _
                        "ORDER BY tblInvCodeCategory.strInvCategory;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drCategories As OleDbDataReader = cmdDB.ExecuteReader()

                        While drCategories.Read

                            Dim lngInvCategoryID As Long
                            Dim strInvCategory As String

                            Try
                                lngInvCategoryID = Convert.ToInt32(drCategories("lngInvCategoryID"))
                            Catch ex As Exception
                                lngInvCategoryID = 0
                            End Try
                            Try
                                strInvCategory = Convert.ToString(drCategories("strInvCategory"))
                            Catch ex As Exception
                                strInvCategory = ""
                            End Try

                            cboCategories = New clsCboItem(lngInvCategoryID, strInvCategory)

                            Me.cboCategory.Items.Add(cboCategories)

                        End While

                        drCategories.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

    End Sub

    Private Sub subLoadInventory(Optional ByVal _lngCategoryID As Long = 0, Optional ByVal _strInvID As String = "", Optional ByVal _blnIncludeInactive As Boolean = False)

        Dim cboCategory As clsCboItem
        Dim lstInventory As clsCboItem

        Dim strSQL As String
        Dim strWhere As String = ""

        Try

            cboCategory = CType(Me.cboCategory.SelectedItem, clsCboItem)

            Me.lstInventory.Items.Clear()

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                If _lngCategoryID <> 0 Then
                    strWhere = "WHERE(((tblInventory.lngInvCategoryID) = " & _lngCategoryID & ")) "
                End If

                If _strInvID <> "" And _strInvID <> "0" Then
                    strWhere = "WHERE(((tblInventory.strStockCode) = '" & _strInvID & "')) "
                End If

                If Not _blnIncludeInactive Then
                    If strWhere = "" Then
                        strWhere = " WHERE tblInventory.blnInactive=0 "
                    Else
                        strWhere = strWhere & " AND tblInventory.blnInactive=0 "
                    End If
                End If

                strSQL = "SELECT tblInventory.lngInventoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.curListPrice, tblInventory.curDiscount1, tblInventory.curDiscount2, tblInventory.curCost " & _
                            "FROM tblInventory " & _
                            strWhere & _
                            "ORDER BY tblInventory.strItemName;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drInv As OleDbDataReader = cmdDB.ExecuteReader()

                        While drInv.Read
                            Dim lngInventoryID As Long
                            Dim decListPrice As Decimal
                            Dim decDiscount1 As Decimal
                            Dim decDiscount2 As Decimal
                            Dim strItemName As String
                            Dim strStockCode As String

                            Try
                                lngInventoryID = Convert.ToInt32(drInv("lngInventoryID"))
                            Catch ex As Exception
                                lngInventoryID = 0
                            End Try
                            Try
                                decListPrice = Convert.ToDecimal(drInv("curListPrice"))
                            Catch ex As Exception
                                decListPrice = 0
                            End Try
                            Try
                                decDiscount1 = Convert.ToDecimal(drInv("curDiscount1"))
                            Catch ex As Exception
                                decDiscount1 = 0
                            End Try
                            Try
                                decDiscount2 = Convert.ToDecimal(drInv("curDiscount2"))
                            Catch ex As Exception
                                decDiscount2 = 0
                            End Try
                            Try
                                strItemName = Convert.ToString(drInv("strItemName"))
                            Catch ex As Exception
                                strItemName = ""
                            End Try
                            Try
                                strStockCode = Convert.ToString(drInv("strStockCode"))
                            Catch ex As Exception
                                strStockCode = ""
                            End Try

                            lstInventory = New clsCboItem(lngInventoryID, strItemName & ": " & decListPrice.ToString("C") & ": " & decDiscount1.ToString("C") & ": " & decDiscount2.ToString("C") & ": " & strStockCode)

                            Me.lstInventory.Items.Add(lstInventory)

                        End While

                        drInv.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr(Me.cboCategory.Name & ".SelectedIndexChanged", ex)

        End Try

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        subProceed()
    End Sub

    Private Sub subProceed()

        Try
            Me.Close()
        Catch ex As Exception
            subLogErr(Me.Name & ".btnContinue_Click", ex)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Me.Close()
        Catch ex As Exception
            subLogErr(Me.Name & ".btnCancel", ex)
        End Try

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged

        Me.txtItemNumber.Text = ""
        If Me.cboCategory.SelectedIndex = -1 Then Exit Sub
        Dim cboCategory As clsCboItem
        cboCategory = CType(Me.cboCategory.SelectedItem, clsCboItem)

        subLoadInventory(CType(cboCategory.ID, Long), (0).ToString)

    End Sub

    Private Sub txtItemNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemNumber.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            subLoadInventory(0, Me.txtItemNumber.Text)
            Me.cboCategory.SelectedIndex = -1
        End If
    End Sub

    Private Sub lstInventory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInventory.DoubleClick
        strItemCode = LeftStr(Me.lstInventory.SelectedItem.ToString, InStr(Me.lstInventory.SelectedItem.ToString, ":") - 1)
        subProceed()
        My.Computer.Clipboard.Clear()
    End Sub

    Private Sub chkIncludeInactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeInactive.CheckedChanged

        Dim lngCategoryID As Long
        Dim strStockCode As String

        Try
            lngCategoryID = Convert.ToInt32(CType(cboCategory.SelectedItem, clsCboItem).ID)
        Catch ex As Exception
            lngCategoryID = 0
        End Try

        Try
            strStockCode = txtItemNumber.Text
        Catch ex As Exception
            strStockCode = ""
        End Try

        subLoadInventory(lngCategoryID, strStockCode, chkIncludeInactive.Checked)

    End Sub

End Class