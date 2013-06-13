Imports System.Data.OleDb

Public Class frmChooseDept

    Public lngDeptID As Long = 0

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Try

            If Me.lstDeptID.SelectedIndex < 0 Then
                MsgBox("Please select a department.")
                Me.lstDeptID.Focus()
                Exit Sub
            End If

            Me.lngDeptID = CType(CType(Me.lstDeptID.SelectedItem, clsCboItem).ID, Long)

            Me.Close()

        Catch ex As Exception

            subLogErr("frmChooseDept.btnContinue", ex)

        End Try

    End Sub

    Private Sub frmChooseDept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drDept As OleDbDataReader

        Dim cboDept As clsCboItem

        Dim strSQL As String

        Try

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT lngDeptID, " & _
                        "strDepartmentName " & _
                    "FROM tblDepartments " & _
                    "ORDER BY strDepartmentName;"

            objCommand.CommandText = strSQL

            drDept = objCommand.ExecuteReader

            If drDept.HasRows Then

                While drDept.Read

                    cboDept = New clsCboItem(CType(drDept("lngDeptID"), Long), CType(drDept("strDepartmentName"), String))

                    Me.lstDeptID.Items.Add(cboDept)

                End While
            End If

            drDept.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr("frmChooseDept_Load", ex)

        End Try

        drDept = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.lngDeptID = 0

        Me.Close()

    End Sub

End Class