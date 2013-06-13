Public Class frmMaskedInputBox

    Public strInput As String

    Public Sub New(ByVal _strMsg As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblMsg.Text = _strMsg
        strInput = ""
        txtInput.Focus()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        DialogResult = Windows.Forms.DialogResult.OK

        strInput = txtInput.Text

        Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        DialogResult = Windows.Forms.DialogResult.Cancel

        strInput = ""

        Close()

    End Sub

    Private Sub frmMaskedInputBox_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If Me.DialogResult <> Windows.Forms.DialogResult.OK Then strInput = ""

    End Sub
End Class