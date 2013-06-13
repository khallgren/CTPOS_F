Imports System.Windows.Forms

Public Class dlgEditItem

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtDiscount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.LostFocus
        If CType(Me.txtDiscount.Text, Double) = 0 Then Exit Sub

        If CType(Me.txtDiscount.Text, Double) > 1 Then
            Me.txtDiscount.Text = (CType(Me.txtDiscount.Text, Double) / 100)

        End If

        Me.txtPrice.Text = CType(CType(Me.txtPrice.Text, Double) - ((NZ(CType(Me.txtPrice.Text, Double) * CType(Me.txtDiscount.Text, Double), "0"))), Decimal).ToString("C")
    End Sub

End Class
