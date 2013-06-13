
Public Class frmChangeMaker

    Public dblAmtDue As Double

    Public blnComplete As Boolean

    
    Private Sub frmChangeMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.txtAmtDue.Text = Format(dblAmtDue, "currency")

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

    End Sub

    Private Sub txtRcvd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRcvd.KeyDown

        If e.KeyCode = Keys.Enter Then Me.btnContinue.Focus()

    End Sub

    Private Sub txtRcvd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRcvd.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not e.KeyChar = ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRcvd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRcvd.LostFocus
        'when the rcvd field loses focus calculate change and open drawer

        Try

            subOpenDrawer()


        Catch ex As Exception

            subLogErr(Me.Name & ".txtRcvd_LostFocus", ex)

        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Try

            Me.blnComplete = False
            Me.Close()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnCancel_Click", ex)

        End Try

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Try

            dblCashIn = CType(Me.txtRcvd.Text, Double)
            dblChange = CType(Me.txtChangeDue.Text, Double)

            Me.blnComplete = True
            Me.Close()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnContinue_Click", ex)

        End Try

    End Sub
    Public Sub subCalcChange()
        Try

            If IsNumeric(Me.txtRcvd.Text) Then

                'Me.txtRcvd.Text = Format(CType(Me.txtRcvd.Text, Double) / 100, "Currency")
                Me.txtChangeDue.Text = Format(CType(Me.txtRcvd.Text, Double) / 100 - CType(Me.txtAmtDue.Text, Double), "Currency")
            Else
                Me.txtRcvd.Text = ""
                Me.txtRcvd.Focus()
            End If
        Catch ex As Exception

            subLogErr(Me.Name & ".subCalcChange", ex)

        End Try

    End Sub

    Public Sub subAppendString(ByVal obj As TextBox, ByVal str As String)

        Dim strText As String

        strText = obj.Text & str

        obj.Text = strText
        obj.Focus()

        obj.SelectionStart = obj.Text.Length
        obj.SelectionLength = 0

    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        subAppendString(Me.txtRcvd, "1")
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        subAppendString(Me.txtRcvd, "2")
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        subAppendString(Me.txtRcvd, "3")
    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        subAppendString(Me.txtRcvd, "4")
    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        subAppendString(Me.txtRcvd, "5")
    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        subAppendString(Me.txtRcvd, "6")
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        subAppendString(Me.txtRcvd, "7")
    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        subAppendString(Me.txtRcvd, "8")
    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        subAppendString(Me.txtRcvd, "9")
    End Sub

    Private Sub cmd10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10.Click
        subAppendString(Me.txtRcvd, "0")
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Me.txtRcvd.Text = ""
    End Sub

    Private Sub txtRcvd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRcvd.TextChanged
        subCalcChange()
    End Sub
End Class