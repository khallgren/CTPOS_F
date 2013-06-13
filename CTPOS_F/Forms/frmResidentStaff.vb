Imports System.Data.OleDb

Public Class frmResidentStaff

    Private daStaff As OleDbDataAdapter = New OleDbDataAdapter()
    Private srcStaff As BindingSource = New BindingSource()

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        subCloseResidentStaff()

    End Sub

    Private Sub frmResidentStaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        grdResidentStaff.DataSource = srcStaff
        subFillGrid()

    End Sub

    Private Sub subFillGrid()

        Try

            Dim strSQL As String = "SELECT lngStaffID, " & _
                                        "strStaffFName, strStaffLName " & _
                                    "FROM tblResidentStaff;"

            daStaff = New OleDbDataAdapter(strSQL, strPOSConn)

            Dim cmdStaff As OleDbCommandBuilder = New OleDbCommandBuilder(daStaff)

            'Populate a new data table and bind it to the BindingSource.
            Dim tblStaff As DataTable = New DataTable()

            tblStaff.Locale = System.Globalization.CultureInfo.InvariantCulture

            daStaff.Fill(tblStaff)

            srcStaff.DataSource = tblStaff

            grdResidentStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)

        Catch ex As Exception

            subLogErr("frmProcessGifts.fcnFillSrc", ex)

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        subUpdate()

    End Sub

    Private Sub subUpdate()

        'I may need to do a type conversion here...
        daStaff.Update(srcStaff.DataSource)

    End Sub

    Private Sub grdResidentStaff_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdResidentStaff.CellEndEdit

        subUpdate()

    End Sub

    Private Sub grdResidentStaff_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdResidentStaff.UserAddedRow

        subUpdate()

    End Sub

    Private Sub grdResidentStaff_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdResidentStaff.UserDeletedRow

        subUpdate()

    End Sub

    Private Sub frmResidentStaff_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        subUpdate()

    End Sub

End Class
