
Public Class frmCaptureCC

    Public strCardNumber As String
    Public strExpDate As String
    Public strCVV2 As String
    Public strBillName As String
    Public strZip As String
    Public strPhone As String
    Public blnSwiped As Boolean
    Public strSwipeData As String

    Private Sub btnManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManual.Click

        Try

            Me.txtCardNumber.Enabled = True
            Me.txtExpDate.Enabled = True
            Me.txtCVV2.Enabled = True
            Me.txtBillName.Enabled = True
            Me.txtZip.Enabled = True
            Me.txtPhone.Enabled = True
            Me.txtCardNumber.Focus()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnManual_Click", ex)

        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Try

            Me.strCardNumber = ""

            Me.Close()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnCancel_Click", ex)

        End Try

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Dim strMsg As String

        'MsgBox(My.Settings.lngLiveCharge)

        If My.Settings.lngLiveCharge = CTPOS_F.clsGlobalEnum.conLIVECHARGE.None Then
            'If Me.txtPhone.Text.Length = 0 Then
            '    MsgBox("Phone required.")
            '    Me.txtPhone.Focus()
            '    Exit Sub
            'End If
            If Me.txtCVV2.Text.Length = 0 Then
                MsgBox("Security Code Required")
                Me.txtCVV2.Focus()
                Exit Sub
            End If
            'If Me.txtZip.Text.Length = 0 Then
            '    MsgBox("Zip Required")
            '    Me.txtZip.Focus()
            '    Exit Sub
            'End If
        End If

        Try

            'validate
            If fcnValidCCNumber(Me.txtCardNumber.Text) Then

                Me.strCardNumber = Me.txtCardNumber.Text
                Me.strExpDate = Me.txtExpDate.Text
                Me.strCVV2 = Me.txtCVV2.Text
                Me.strBillName = Me.txtBillName.Text
                Me.strZip = Me.txtZip.Text
                Me.strPhone = Me.txtPhone.Text
                If Me.txtCCIn.Text.Length > 0 Then Me.blnSwiped = True

                Me.Close()
                'subOpenDrawer()
            Else

                strMsg = "Invalid card number." & vbNewLine & _
                        vbNewLine & _
                        "Please re-enter or click 'Cancel'."

                MsgBox(strMsg)

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".btnContinue_Click", ex)

        End Try

    End Sub

    Private Sub subParse()
        Try

        Dim strTxt$
            Dim strLeft$
            Dim strName$
            Dim strFName$
            Dim strLName$

            strTxt = Me.txtCCIn.Text

            strLeft = LeftStr(strTxt, InStr(strTxt, "^") - 1)

            Me.txtCardNumber.Text = RightStr(strLeft, Len(strLeft) - 2)
            Me.txtCardNumber.Text = Me.txtCardNumber.Text.Replace(" ", "")

            strTxt = RightStr(strTxt, Len(strTxt) - InStr(strTxt, "^"))

            strName = LeftStr(strTxt, InStr(strTxt, "^") - 1)

            strFName = RightStr(strName, Len(strName) - InStr(strName, "/"))
            strLName = LeftStr(strName, InStr(strName, "/") - 1)

            strName = Trim(strFName.ToString) & " " & Trim(strLName.ToString)

            Me.txtBillName.Text = strName

            strLeft = RightStr(strTxt, Len(strTxt) - InStr(strTxt, "^"))

            Me.txtExpDate.Text = Mid(strLeft, 3, 2) & LeftStr(strLeft, 2)

            Me.txtCVV2.Enabled = True
            Me.txtPhone.Enabled = True
            Me.txtZip.Enabled = True

            'Me.txtCVV2.Focus()
        Catch ex As Exception
            Me.strSwipeData = "Error"
            Me.txtBillName.Text = ""
            Me.txtExpDate.Text = ""
            Me.txtCardNumber.Text = ""
            Exit Sub
        End Try

    End Sub

    Private Sub subParse2()

        Dim strTxt$ = ""
        Dim strLeft$ = ""
        Dim strName$ = ""
        Dim strFName$ = ""
        Dim strLName$ = ""
        Dim strCCTypeName$ = ""
        Dim strExpMonth$ = ""
        Dim strExpYear$ = ""
        Dim strTrack1$ = ""
        Dim strTrack2$ = ""


        strTxt = Me.txtCCIn.Text

        'MsgBox("before set")
        Dim objXC As New XCTransaction2.XChargeTransaction
        'MsgBox("after set")

        If objXC.ParseTrackData(strTxt, strTrack1$, strTrack2$, Me.txtCardNumber.Text, strCCTypeName$, strExpMonth$, strExpYear$, strName$) Then
            Me.txtExpDate.Text = strExpMonth & strExpYear$
            Me.txtCVV2.Enabled = True
            Me.txtBillName.Enabled = True
            Me.txtZip.Enabled = True

            Me.txtPhone.Enabled = True
            'Me.txtCVV2.Focus()
        End If

    End Sub

    Private Sub txtCCIn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCCIn.KeyPress

        If txtCCIn.Text.Length > 0 Then
            If txtCCIn.Text.Substring(txtCCIn.Text.Length - 1, 1) = "?" Then subParse()
        End If

    End Sub

    Private Sub frmCaptureCC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtCCIn.Focus()
    End Sub

    Private Sub txtCCIn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCCIn.LostFocus
        Dim strIn$ = ""

        strIn = Me.txtCCIn.Text

        If Len(strIn) > 0 Then
            'MsgBox(strIn)
            subParse()
            If Me.strSwipeData <> "Error" Then
                Me.strSwipeData = strIn
                ' Me.txtZip.Focus()
            Else
                Me.txtCCIn.Text = ""
                Me.txtCCIn.Focus()
            End If
        End If
    End Sub

    Private Sub frmCaptureCC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                btnContinue_Click(sender, e)
            Case Keys.F11
                Me.btnManual_Click(sender, e)
            Case Keys.F10
                Me.btnCancel_Click(sender, e)
        End Select
    End Sub
End Class