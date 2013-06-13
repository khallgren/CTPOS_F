Imports System.Data.OleDb
Imports Microsoft.Win32

Public Class frmVendors

    Public aListSelectedIndex As ArrayList
    Public iRowsToInsert As Integer
    Public iRowsCount As Integer



    Public Sub FillGrid()
        Dim objConn As OleDbConnection
        Dim DataAdapter As OleDbDataAdapter
        Dim ds As DataSet
        Dim RowCount As Integer

        'Try
        objConn = New OleDbConnection
        objConn.ConnectionString = strPOSConn
        objConn.Open()


        Dim strSQL = "Select * from tlkpVendor ORDER BY strVendorName;"
        DataAdapter = New OleDbDataAdapter(strSQL, objConn)
        ' create a new dataset
        ds = New DataSet
        ' fill dataset
        DataAdapter.Fill(ds)

        grdAdjustmentTypes.DataSource = ds.Tables(0)
        grdAdjustmentTypes.Refresh()

        RowCount = Me.grdAdjustmentTypes.RowCount

        objConn.Close()
        DataAdapter = Nothing
        strSQL = Nothing
        ds = Nothing

        'Catch ex As Exception
        '    subLogErr(Me.Name & ".FillGrid", ex)
        'End Try
    End Sub

    Private Sub frmAdjustmentTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aListSelectedIndex = New ArrayList
        FillGrid()
        iRowsCount = Me.grdAdjustmentTypes.RowCount

    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        UpdateRecords()
        InsertRecords()
        FillGrid()

    End Sub

    Private Sub UpdateRecords()

        Dim objConn As OleDbConnection
        Dim objCommandUpdate As OleDbCommand
        Dim RowCount As Integer
        Dim strSQL As String

        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            objCommandUpdate = New OleDbCommand
            objCommandUpdate.Connection = objConn

            Dim iCount As Integer
            Dim iSecondColumn As Integer
            Dim szAdjType As String


            For iCount = 0 To iRowsCount - 1
                iSecondColumn = grdAdjustmentTypes.Item(0, iCount).Value()
                szAdjType = grdAdjustmentTypes.Item(1, iCount).Value()
                strSQL = "UPDATE tlkpVendor SET strVendorName = " + "'" + Replace(szAdjType, "'", "''") + "'" + " WHERE lngVendorID = " + iSecondColumn.ToString()
                objCommandUpdate.CommandText = strSQL
                RowCount = objCommandUpdate.ExecuteNonQuery()
            Next iCount


            'FillGrid()

            objCommandUpdate = Nothing
            objConn.Close()

        Catch ex As Exception
            subLogErr(Me.Name & ".FillGrid", ex)
        End Try


    End Sub

    Private Sub InsertRecords()

        Dim objConn As OleDbConnection
        'Dim DataAdapter As OleDbDataAdapter
        Dim objCommandInsert As OleDbCommand

        Dim strSQL As String
        Dim strLastValue As String
        Dim strNewValue As String

        Try
            iRowsToInsert = iRowsToInsert
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()
            Dim iCount As Integer
            iCount = Convert.ToInt32(grdAdjustmentTypes.Item(0, iRowsCount - 1).Value().ToString())


            While iRowsToInsert > 1
                iCount = iCount + 1
                strLastValue = iCount.ToString()
                strNewValue = "'" + grdAdjustmentTypes.Item(1, iRowsCount).Value().ToString() + "'"
                objCommandInsert = New OleDbCommand
                objCommandInsert.Connection = objConn

                strSQL = "INSERT INTO tlkpVendor (strVendorName) VALUES ( " + strNewValue + ")"

                objCommandInsert.CommandText = strSQL

                Dim i = objCommandInsert.ExecuteNonQuery()

                iRowsCount = iRowsCount + 1
                iRowsToInsert = iRowsToInsert - 1
            End While

            objConn.Close()

        Catch ex As Exception
            subLogErr(Me.Name & ".FillGrid", ex)
        End Try

    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub grdAdjustmentTypes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAdjustmentTypes.CellClick

    '    Try

    '        If e.RowIndex > Me.grdAdjustmentTypes.RowCount - 2 Then
    '            Me.grdAdjustmentTypes.AllowUserToAddRows = False
    '            btnAddNew.Enabled() = True
    '            btnAddNew.Visible() = True
    '        Else
    '            btnAddNew.Enabled() = False
    '            btnAddNew.Visible() = False
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub   

    Private Sub grdAdjustmentTypes_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAdjustmentTypes.CellEnter
        Try
            If (e.RowIndex > Me.grdAdjustmentTypes.RowCount - 2) Then
                iRowsToInsert = iRowsToInsert + 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAdjustmentTypes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        iRowsToInsert = 1
        Me.grdAdjustmentTypes.AllowUserToAddRows = True
    End Sub

    Private Sub grdAdjustmentTypes_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdAdjustmentTypes.CellBeginEdit
        btnUpdate.Enabled = True
    End Sub
End Class