Imports CTPOS_F.clsGlobalEnum
Imports System.Data.OleDb

Public Class frmDeptXFerRptSetup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        subCloseDeptXFerRptSetup()

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Try

            subInitDeptXFerRptPreview(Me.MdiParent, False)

            If Me.radAllDepts.Checked Then
                objDeptXFerRptPreview.lngDeptID = 0
            ElseIf Me.radSpecificDept.Checked Then

                If Me.cboDept.SelectedIndex < 0 Then
                    MsgBox("Select a department or choose 'All Departments'.")
                    Me.cboDept.Focus()
                    Exit Sub
                End If

                objDeptXFerRptPreview.lngDeptID = CType(CType(Me.cboDept.SelectedItem, clsCboItem).ID, Long)

            End If

            If Me.radAllDates.Checked Then
                objDeptXFerRptPreview.lngDateCriter = conDATECRITER.conAllDates
            ElseIf Me.radSpecificDate.Checked Then

                objDeptXFerRptPreview.lngDateCriter = conDATECRITER.conSpecificDate

                If Me.cboDate.SelectedIndex < 0 Then
                    MsgBox("Please select a transfer date.")
                    Me.cboDate.Focus()
                    Exit Sub
                End If

                objDeptXFerRptPreview.dteXFer = CType(CType(Me.cboDate.SelectedItem, clsCboItem).ID, Date)

            ElseIf Me.radDateRange.Checked Then

                objDeptXFerRptPreview.lngDateCriter = conDATECRITER.conDateRange

                If Not IsDate(Me.txtStartDate.Text) Then
                    MsgBox("Please enter a valid start date.")
                    Me.txtStartDate.Focus()
                    Exit Sub
                ElseIf Not IsDate(Me.txtEndDate.Text) Then
                    MsgBox("Please enter a valid end date.")
                    Me.txtEndDate.Focus()
                    Exit Sub
                End If

                objDeptXFerRptPreview.dteStart = CDate(Me.txtStartDate.Text)
                objDeptXFerRptPreview.dteEnd = CDate(Me.txtEndDate.Text)

            End If

            Me.Cursor = Cursors.WaitCursor

            subInitDeptXFerRptPreview(Me.MdiParent, True)

            subCloseDeptXFerRptSetup()

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            subLogErr(Me.Name & ".btnPreview", ex)

        End Try

    End Sub

    Private Sub frmDeptXFerRptSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objConn As New OleDbConnection(strPOSConn)
        Dim objCommand As OleDbCommand

        Dim drDept As OleDbDataReader

        Dim strSQL As String

        objConn.Open()

        strSQL = "SELECT lngDeptID, " & _
                    "strDepartmentName " & _
                "FROM tblDepartments " & _
                "ORDER BY strDepartmentName;"

        objCommand = New OleDbCommand(strSQL, objConn)

        drDept = objCommand.ExecuteReader

        While drDept.Read

            Dim cboDeptID As New clsCboItem(drDept("lngDeptID").ToString, drDept("strDepartmentName").ToString)

            Me.cboDept.Items.Add(cboDeptID)

        End While

        drDept.Close()

        strSQL = fcnSQLStr(conSQLNAME.conDeptXFerDates)

        objCommand.CommandText = strSQL

        drDept = objCommand.ExecuteReader

        While drDept.Read

            Dim cboDeptID As New clsCboItem(drDept("dteSaleDate").ToString, drDept("dteSaleDate").ToString)

            Me.cboDate.Items.Add(cboDeptID)

        End While

        drDept.Close()

        objConn.Close()

        objCommand.Dispose()
        objConn.Dispose()

        drDept = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Private Sub subDateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAllDates.CheckedChanged, radSpecificDate.CheckedChanged, radDateRange.CheckedChanged

        Me.txtStartDate.Enabled = False
        Me.txtEndDate.Enabled = False
        Me.cboDate.Enabled = False

        Me.txtStartDate.Text = ""
        Me.txtEndDate.Text = ""
        Me.cboDate.SelectedIndex = -1

        If Me.radSpecificDate.Checked Then
            Me.cboDate.Enabled = True
        ElseIf Me.radDateRange.Checked Then
            Me.txtStartDate.Enabled = True
            Me.txtEndDate.Enabled = True
        End If

    End Sub

    Private Sub subDeptCriterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSpecificDept.CheckedChanged, radAllDepts.CheckedChanged

        Me.cboDept.Enabled = False
        Me.cboDept.SelectedIndex = -1

        If Me.radSpecificDept.Checked Then Me.cboDept.Enabled = True

    End Sub

End Class