Imports System.Data.OleDb

Public Class frmEditUsers

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        subCloseEditUsers()

    End Sub

    Private Sub frmEditUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drUsers As OleDbDataReader

        Dim cboUser As clsCboItem

        Dim strSQL As String

        Try

            Me.lstUsers.Items.Clear()

            objConn = New OleDbConnection

            objConn.ConnectionString = strPOSConn

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT blnActive, " & _
                    "lngClerkID, " & _
                    "strUserName, strPassword " & _
                "FROM tblClerks;"

            objCommand.CommandText = strSQL

            drUsers = objCommand.ExecuteReader

            While drUsers.Read

                cboUser = New clsCboItem(CType(drUsers("lngClerkID"), Long), CType(drUsers("strUserName"), String))

                Me.lstUsers.Items.Add(cboUser)

            End While

            drUsers.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".LoadEditUsers", ex)

        End Try

    End Sub

    Private Sub lstUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsers.DoubleClick

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drClerks As OleDbDataReader

        Dim cboClerk As clsCboItem

        Dim strSQL As String

        Dim lngClerkID As Long

        Try

            cboClerk = CType(Me.lstUsers.SelectedItem, clsCboItem)

            lngClerkID = CType(cboClerk.ID, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT blnActive, " & _
                    "strUserName, strPassword " & _
                "FROM tblClerks " & _
                "WHERE lngClerkID=" & lngClerkID

            objCommand.CommandText = strSQL

            drClerks = objCommand.ExecuteReader

            If drClerks.Read Then

                Me.txtPassword.Enabled = True
                Me.chkActive.Enabled = True
                Me.btnSave.Enabled = True

                Me.txtPassword.Text = CType(drClerks("strPassword"), String)
                Me.chkActive.Checked = CType(drClerks("blnActive"), Boolean)

            Else
                MsgBox("Error looking up user information.")
            End If

            drClerks.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".lstUser_DoubleClick", ex)

        End Try

        drClerks = Nothing
        objCommand = Nothing
        objConn = Nothing

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
    
        Dim cboClerk As clsCboItem

        Dim strSQL As String

        Dim lngClerkID As Long

        Try

            cboClerk = CType(Me.lstUsers.SelectedItem, clsCboItem)

            lngClerkID = CType(cboClerk.ID, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "UPDATE tblClerks " & _
                    "SET blnActive=" & CType(Me.chkActive.Checked, Integer) & ", " & _
                        "strPassword='" & Me.txtPassword.Text & "' " & _
                    "WHERE lngClerkID=" & lngClerkID

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSave_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

    End Sub

End Class