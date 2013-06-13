Public Class frmStaffAccounts

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim dteStart As Date
        Dim dteEnd As Date

        dteStart = Me.dteBeginDate.Value
        dteEnd = Me.dteEndDate.Value
        subShowStaffAccounts(dteStart, dteEnd, Me.MdiParent)

    End Sub

End Class