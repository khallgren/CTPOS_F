Imports System.Data.OleDb

Public Class frmTransactionExceptions

    Dim ColumnList As ArrayList

    Dim daUnmatchedTrans As OleDbDataAdapter
    Dim srcUnmatchedTrans As BindingSource

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmTransactionExceptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'load unmatched transactions
        Dim ds As New DataSet

        subFillDataSets(ds)

        Dim dt As DataTable

        ' build a list of every column used in the result set + the joins
        ColumnList = New ArrayList
        ColumnList.Add("tblTransactions.lngTransactionID")
        ColumnList.Add("tblTransactions.lngRecordID")
        ColumnList.Add("tblTransactions.strFName")
        ColumnList.Add("tblTransactions.strLName")
        ColumnList.Add("tblTransactions.lngSaleID_Transactions")
        ColumnList.Add("tblTransactions.dteDateAdded")
        ColumnList.Add("tblTransactions.curPayment")
        ColumnList.Add("tblTransactions.curCharge")
        ColumnList.Add("tblSales.lngSaleID")

        dt = JoinTables(ds.Tables("tblTransactions"), ds.Tables("tblSales"), "lngSaleID_Transactions", "lngSaleID", "LEFT", ColumnList, ds)

        Dim dtFiltered As DataTable = dt.Clone()

        Dim rows() As DataRow = dt.Select("lngSaleID IS NULL")

        Dim row As DataRow
        For Each row In rows
            dtFiltered.ImportRow(row)
        Next

        grdUnmatchedTransactions.DataSource = dtFiltered
        grdUnmatchedTransactions.AutoResizeColumns()

    End Sub

    Private Sub subFillDataSets(ByVal ds As DataSet)

        Dim con As New OleDbConnection
        Dim da As New OleDbDataAdapter
        Dim cmd As New OleDbCommand

        con.ConnectionString = strPOSConn
        cmd.Connection = con
        da.SelectCommand = cmd
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' fill a few tables
        con.Open()

        cmd.CommandText = "SELECT tblSales.lngSaleID FROM tblSales "

        da.Fill(ds, "tblSales")
        con.Close()

        ' another test database
        con.ConnectionString = strCTConn
        con.Open()
        cmd.CommandText = "SELECT tblTransactions.lngTransactionID, tblTransactions.lngRecordID, tblTransactions.lngSaleID AS lngSaleID_Transactions, " & _
                            "tblTransactions.dteDateAdded, " & _
                            "tblTransactions.curPayment, tblTransactions.curCharge, " & _
                            "tblRecords.strFirstName AS strFName, tblRecords.strLastCoName AS strLName " & _
                        "FROM tblTransactions " & _
                            "INNER JOIN tblRecords ON tblTransactions.lngRecordID = tblRecords.lngRecordID " & _
                        "WHERE tblTransactions.lngSaleID > 0"

        da.Fill(ds, "tblTransactions")
        con.Close()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim rowTrans As DataGridViewRow

        Dim lngTransactionID As Long

        Dim strSQL As String

        Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

            conDB.Open()

            strSQL = "DELETE tblTransactions.* " & _
                    "FROM tblTransactions " & _
                    "WHERE lngTransactionID=@lngTransIDToDel"

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                cmdDB.Parameters.AddWithValue("lngTransIDToDel", 0)

                For Each rowTrans In grdUnmatchedTransactions.Rows

                    Try
                        lngTransactionID = Convert.ToInt32(rowTrans.Cells(0).Value)

                        cmdDB.Parameters(0).Value = lngTransactionID

                        Try
                            cmdDB.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("There was an error deleting transaction id " & lngTransactionID.ToString() & ": " & ex.Message)
                        End Try

                    Catch ex As Exception
                        MessageBox.Show("There was an error with the delete process: " & ex.Message)
                    End Try

                Next

            End Using

            conDB.Close()

        End Using

        MessageBox.Show("Delete process complete!")
        Close()

    End Sub

End Class