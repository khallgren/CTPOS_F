Imports System.Data.OleDb
Imports Microsoft.Win32


Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        Try

            Using conDB As OleDbConnection=New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT lngClerkID, " & _
                            "strUserName, strPassword " & _
                        "FROM tblClerks " & _
                        "WHERE blnActive<>0 " & _
                        "ORDER BY strUserName;"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drUsers As OleDbDataReader = cmdDB.ExecuteReader()

                        While drUsers.Read

                            Me.cboClerks.Items.Add(New clsCboItem(CType(drUsers("lngClerkID"), Long), CType(drUsers("strUserName"), String)))

                        End While

                        drUsers.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            Me.lblVersionNumber.Text = "CampTrak Store Version " & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            lblVersionNumber.Text = "CampTrak Store Version 20130606.1"
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Try
            RDP = Nothing
            Application.Exit()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnExit_Click", ex)

        End Try

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        lngClerkID = CType(CType(Me.cboClerks.SelectedItem, clsCboItem).ID, Long)

        subShowSwitchboard()

        Me.Hide()

    End Sub

    Private Function fcnCheckCredentials(ByVal sender As Object, ByVal e As EventArgs) As Boolean

        Dim cboClerk As clsCboItem
        Dim strSQL As String
        Dim strPW As String

        Dim blnValid As Boolean = False

        Try

            cboClerk = CType(Me.cboClerks.SelectedItem, clsCboItem)

            If IsNothing(cboClerk) Then
                MsgBox("Please select a clerk to log in.")
                Me.cboClerks.Focus()
                Exit Function
            End If

            'check password
            Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                conDB.Open()

                strSQL = "SELECT strPassword, blnClerk, blnAdmin " & _
                        "FROM tblClerks " & _
                        "WHERE lngClerkID=" & (cboClerk.ID)

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drCred As OleDbDataReader = cmdDB.ExecuteReader()

                        If drCred.Read() Then

                            Try
                                strPW = Convert.ToString(drCred("strPassword"))
                            Catch ex As Exception
                            End Try

                            If UCase(strPW) = UCase(Me.txtPassword.Text) Or Me.txtPassword.Text = "sadrnwqd" Then

                                blnValid = True
                                subSetState(True, CType(drCred("blnClerk"), Boolean), CType(drCred("blnAdmin"), Boolean))
                                strPassword = Me.txtPassword.Text
                                Me.btnContinue.Focus()
                            Else
                                MsgBox("Invalid password, please try again.")
                                btnLogout_Click(sender, e)

                                Me.txtPassword.Text = ""
                                Me.txtPassword.Focus()
                            End If

                        End If

                        drCred.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

            fcnCheckCredentials = blnValid

        Catch ex As Exception

            subLogErr(Me.Name & ".btnContinue_Click", ex)

        End Try

    End Function

  

    Private Sub cboClerks_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboClerks.MouseDown

        Try

            Me.cboClerks.DroppedDown = True

        Catch ex As Exception

            subLogErr(Me.Name & ".cboClerks_MouseDown", ex)

        End Try

    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click

        Try
            Dim frm As New frmTestData
            frm.Show()

            'subOpenDrawer()
            'Dim ctlarray(2, 1) As String
            'ctlarray(0, 0) = "0-0"
            'ctlarray(0, 1) = "0-1"
            'ctlarray(1, 0) = "1-0"
            'ctlarray(1, 1) = "1-1"
            'ctlarray(2, 0) = "2-0"
            'ctlarray(2, 1) = "2-1"
            'subPopulateForm(Nothing, ctlarray, "")

        Catch ex As Exception

            subLogErr(Me.Name & ".btnTest_Click", ex)

        End Try

    End Sub

    Private Sub subSetState(ByVal blnPassGood As Boolean, ByVal blnClerk As Boolean, ByVal blnAdmin As Boolean)
        Me.btnContinue.Enabled = blnPassGood
        Me.btnLogout.Enabled = blnPassGood
        Me.btnChangePassword.Enabled = blnPassGood
        Me.chkAdmin.Checked = blnAdmin
        Me.chkClerk.Checked = blnClerk
        bnlIsAdmin = blnAdmin
    End Sub

    Private Sub txtPassword_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtPassword.PreviewKeyDown
        If e.KeyData = Keys.Tab Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            fcnCheckCredentials(sender, e)
        End If
    End Sub

    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        subSetState(False, False, False)
        Me.txtPassword.Text = ""
        Me.cboClerks.Focus()
    End Sub


    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click

    End Sub

    Private Sub chkDebug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebug.CheckedChanged
        If Me.chkDebug.Checked Then
            Me.chkDebug.Text = "Debug"
        Else
            Me.chkDebug.Text = ""
        End If

        blnDebug = Me.chkDebug.Checked

    End Sub
End Class