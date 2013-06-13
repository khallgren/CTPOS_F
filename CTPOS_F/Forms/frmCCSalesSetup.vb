Public Class frmCCSalesSetup

    Private Sub frmCCSalesSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtStart.Text = FormatDateTime(DateAdd(DateInterval.Day, -1, Now), DateFormat.ShortDate)
        Me.txtEnd.Text = FormatDateTime(Now, DateFormat.ShortDate)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        subCloseCCSalesSetup()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click

        Dim strCaption As String

        Dim dteStart As Date
        Dim dteEnd As Date

        If IsDate(Me.txtStart.Text) Then
            dteStart = CType(Me.txtStart.Text, Date)
        Else
            MsgBox("Please enter a valid start date.")
            Me.txtStart.Focus()
            Exit Sub
        End If

        If IsDate(Me.txtEnd.Text) Then
            dteEnd = CType(Me.txtEnd.Text, Date)
        Else
            MsgBox("Please enter a valid end date.")
            Me.txtEnd.Focus()
            Exit Sub
        End If

        strCaption = "Credit Card Sales Report, " & dteStart.ToShortDateString() & "-" & dteEnd.ToShortDateString()

        subShowCCSalesPreview(dteStart, dteEnd, strCaption, Me.MdiParent)

    End Sub
End Class