Imports System.Data.OleDb


Public Class frmAdjustInventory

    Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
        Dim intCurrQty As Integer
        Dim intDiff As Integer = 0
        Dim strSQL As String = ""

        If Me.cboStoreID.SelectedIndex = -1 Then
            MsgBox("Store must be selected")
            Exit Sub
        End If

        If Me.txtNewQty.Text.Length = 0 And Me.txtRemoveQty.Text.Length = 0 And Me.txtAddQty.Text.Length = 0 Then
            MsgBox("You must enter a quantity.")
            Exit Sub
        End If

        
        If Me.cboAdjustmentType.SelectedIndex = -1 Then
            MsgBox("Please select an adjustment type.")
            cboAdjustmentType.Focus()
            Exit Sub
        End If

        Dim lngAddQty As Long = 0
        If IsNumeric(Me.txtAddQty.Text) Then
            lngAddQty = CType(Me.txtAddQty.Text, Long)
        End If

        Dim lngRemoveQty As Long = 0
        If IsNumeric(Me.txtRemoveQty.Text) Then
            lngRemoveQty = CType(Me.txtRemoveQty.Text, Long)
        End If

        Dim lngStoreID As Long = CType(CType(Me.cboStoreID.SelectedItem, clsCboItem).ID, Long)
        Dim lngInvID As Long = CType(CType(Me.cboInventory.SelectedItem, clsCboItem).ID, Long)
        Dim lngAdjustmentTypeID As Long = CType(CType(Me.cboAdjustmentType.SelectedItem, clsCboItem).ID, Long)
        Dim dteAdjDate As Date = Format(Me.dtpDate.Value, "short date")

        If IsNumeric(Me.txtNewQty.Text) Then

            'get current qty
            intCurrQty = fcnGetCurrentInventory(lngStoreID, lngInvID)

            'figure out diff
            intDiff = CType(Me.txtNewQty.Text, Int16) - intCurrQty

            'add diff
            strSQL = "INSERT INTO tblAdjustment ( intAdjustmentQty, lngAdjustmentTypeID, lngInventoryID, dteAdjustmentDate, lngStoreID ) " & _
                        "SELECT " & intDiff & "  AS adjqty,  " & lngAdjustmentTypeID & "  AS adjtype,  " & lngInvID & "  AS invid,  '" & dteAdjDate & "'  AS adjdate,  " & lngStoreID & "  AS storeid;"
        End If

        If IsNumeric(Me.txtAddQty.Text) Then
            'add diff
            strSQL = "INSERT INTO tblAdjustment ( intAdjustmentQty, lngAdjustmentTypeID, lngInventoryID, dteAdjustmentDate, lngStoreID ) " & _
                        "SELECT " & lngAddQty & "  AS adjqty,  " & lngAdjustmentTypeID & "  AS adjtype,  " & lngInvID & "  AS invid,  '" & dteAdjDate & "'  AS adjdate,  " & lngStoreID & "  AS storeid;"
        End If

        If IsNumeric(Me.txtRemoveQty.Text) Then
            'add diff
            strSQL = "INSERT INTO tblAdjustment ( intAdjustmentQty, lngAdjustmentTypeID, lngInventoryID, dteAdjustmentDate, lngStoreID ) " & _
                        "SELECT -" & lngRemoveQty & "  AS adjqty,  " & lngAdjustmentTypeID & "  AS adjtype,  " & lngInvID & "  AS invid,  '" & dteAdjDate & "'  AS adjdate,  " & lngStoreID & "  AS storeid;"
        End If

        subExecuteSQL(strSQL, strPOSConn)

        If Me.txtStockCode.Text.Length > 0 Then
            Me.Close()
        End If

        Me.cboInventory.SelectedIndex = -1
        'Me.cboCategory.SelectedIndex = -1
        'Me.cboStoreID.SelectedIndex = -1
        'Me.cboAdjustmentType.SelectedIndex = -1

        Me.txtAddQty.Text = ""
        Me.txtNewQty.Text = ""
        Me.txtRemoveQty.Text = ""

        Me.txtStockCode.Text = ""

        Me.cboInventory.Focus()



    End Sub

    Private Sub subLoadStores()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim dr As OleDbDataReader

        Dim cboStores As clsCboItem

        Dim strSQL As String

        Try

            Me.cboStoreID.Items.Clear()

            objConn = New OleDbConnection

            objConn.ConnectionString = strPOSConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT strStoreName, " & _
                    "lngStoreID " & _
                "FROM tblStores;"

            objCommand.CommandText = strSQL

            dr = objCommand.ExecuteReader

            While dr.Read

                cboStores = New clsCboItem(CType(dr("lngStoreID"), Long), CType(NZ(dr("strStoreName")), String))

                Me.cboStoreID.Items.Add(cboStores)


            End While

            dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

            If Me.cboStoreID.Items.Count = 1 Then
                Me.cboStoreID.SelectedIndex = 0
            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadStores", ex)

        End Try

    End Sub

    Private Sub subLoadAdjustmentTypes()
        
        Dim cboAdjustmentTypes As clsCboItem

        Dim strSQL As String

        Try

            Me.cboAdjustmentType.Items.Clear()

            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT lngAdjustmentTypeID, strAdjustmentType " & _
                        "FROM tlkpAdjustmentType;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drAdj As OleDbDataReader = cmdDB.ExecuteReader()

                        While drAdj.Read()

                            cboAdjustmentTypes = New clsCboItem(CType(drAdj("lngAdjustmentTypeID"), Long), CType(NZ(drAdj("strAdjustmentType")), String))

                            Me.cboAdjustmentType.Items.Add(cboAdjustmentTypes)

                        End While

                        drAdj.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

            cboAdjustmentType.SelectedIndex = 0

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadAdjustmentTypes", ex)

        End Try

    End Sub

    Public Sub subLoadInventory(Optional ByVal _lngCategoryID As Long = 0, Optional ByVal _strInvID As String = "")

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drInv As OleDbDataReader

        '        Dim cboCategory As clsCboItem
        Dim lstInventory As clsCboItem
        Dim dblListPrice As Double
        Dim dblDiscount1 As Double
        Dim dblDiscount2 As Double

        Dim strSQL As String
        Dim strWhere As String = ""

        Try

            'cboCategory = CType(Me.cboCategory.SelectedItem, clsCboItem)

            Me.cboInventory.Items.Clear()

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            If Me.txtStockCode.Text.Length > 0 Then
                _strInvID = Me.txtStockCode.Text
                Me.cboCategory.Enabled = False
                Me.cboInventory.Enabled = False
                Me.txtStockCode.Enabled = False
                Me.txtNewQty.Focus()
            End If

            If _lngCategoryID <> 0 Then
                strWhere = "WHERE(((tblInventory.lngInvCategoryID) = " & _lngCategoryID & ")) "
            End If

            If _strInvID <> "" And _strInvID <> "0" Then
                strWhere = "WHERE(((tblInventory.strStockCode) = '" & _strInvID & "')) "
            End If

            strSQL = "SELECT tblInventory.lngInventoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.curListPrice, tblInventory.curDiscount1, tblInventory.curDiscount2, tblInventory.curCost " & _
                        "FROM tblInventory " & _
                        strWhere & _
                        "ORDER BY tblInventory.strItemName;"

            objCommand.CommandText = strSQL

            drInv = objCommand.ExecuteReader
            If drInv.HasRows Then

                While drInv.Read
                    If IsNumeric(drInv("curListPrice")) Then
                        dblListPrice = CDbl(drInv("curListPrice").ToString)
                    Else
                        dblListPrice = 0
                    End If

                    If IsNumeric(drInv("curDiscount1")) Then
                        dblDiscount1 = CDbl(drInv("curDiscount1").ToString)
                    Else
                        dblDiscount1 = 0
                    End If
                    If IsNumeric(drInv("curDiscount2")) Then
                        dblDiscount2 = CDbl(drInv("curDiscount2").ToString)
                    Else
                        dblDiscount2 = 0
                    End If


                    lstInventory = New clsCboItem(CType(drInv("lngInventoryID"), Long), CType(drInv("strItemName"), String) & ": " & CType(drInv("strStockCode"), String))

                    Me.cboInventory.Items.Add(lstInventory)

                End While
            End If

            drInv.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            If Me.cboInventory.Items.Count = 1 Then
                Me.cboInventory.SelectedIndex = 0
            End If

        Catch ex As Exception

            subLogErr(Me.cboCategory.Name & ".SelectedIndexChanged", ex)

        End Try

        drInv = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Private Sub subLoadCategories()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drCategories As OleDbDataReader

        Dim cboCategories As clsCboItem

        Dim strSQL As String

        Try

            Me.cboCategory.Items.Clear()

            objConn = New OleDbConnection

            objConn.ConnectionString = strPOSConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT tblInvCodeCategory.lngInvCategoryID, tblInvCodeCategory.strInvCategory FROM tblInvCodeCategory ORDER BY tblInvCodeCategory.strInvCategory;"

            objCommand.CommandText = strSQL

            drCategories = objCommand.ExecuteReader

            While drCategories.Read

                cboCategories = New clsCboItem(CType(drCategories("lngInvCategoryID"), Long), CType(drCategories("strInvCategory"), String))

                Me.cboCategory.Items.Add(cboCategories)

            End While

            drCategories.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

    End Sub

    Private Sub frmAdjustInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        subLoadCategories()
        subLoadInventory()
        subLoadAdjustmentTypes()
        subLoadStores()
        Me.dtpDate.Value = Now
    End Sub

    Private Sub cboCategory_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.Leave
        If Not IsNothing(Me.cboCategory.SelectedItem) Then
            subLoadInventory(CType(CType(Me.cboCategory.SelectedItem, clsCboItem).ID, Long))
        Else
            subLoadInventory()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class