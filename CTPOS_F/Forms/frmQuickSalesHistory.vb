Public Class frmQuickSalesHistory

    Private Sub frmQuickSalesHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click

        If blnUsePrinter Then
            fcnPrintReceipt(Me.txtDisplay.Text & rcptFeedandCut)
        Else
            MsgBox("This workstation is not configured to print to a receipt printer." & vbNewLine & "Hook up a printer and modify the settings under Administration-->System Settings-->Receipt Printer.")
            Exit Sub
        End If

    End Sub
End Class