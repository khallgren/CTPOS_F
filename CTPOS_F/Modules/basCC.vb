Module basCC

    Function fcnValidCCNumber(ByVal CreditCard$) As Boolean

        ' Input is a credit card number in the form of a string.
        ' Output is 0 if not valid, or -1 if valid.

        Dim strCC$, Temp$
        Dim Csum%, Multiplier%, i%, A%, J%

        fcnValidCCNumber = False

        strCC$ = Trim$(CreditCard$)             ' Remove lead/trail blanks.

        If Left$(strCC$, 1) = "F" Then         'its a force
            strCC$ = Mid$(strCC$, 2, Len(strCC$) - 1)
        End If

        Csum = 0                                 ' Start with 0 for check sum.

        ' Process from right to left.

        Multiplier = 2
        For i = Len(strCC$) - 1 To 1 Step -1             ' All digits except last one.
            A = Asc(Mid$(strCC$, i)) - 48                ' Get a single digit.
            If A < 0 Or A > 9 Then                   ' If not 0-9,
                Exit Function                        '   then get out.
            End If
            A = A * Multiplier
            If Multiplier = 2 Then                   ' Toggle multiplier,
                Multiplier = 1                       '   between 1 and 2.
            Else
                Multiplier = 2
            End If
            If A > 9 Then
                Temp$ = LTrim$(Str$(A))              ' Add numbers together.
                A = 0
                For J = 1 To Len(Temp$)
                    A = A + Asc(Mid$(Temp$, J, 1)) - 48 ' Faster than VAL.
                Next
            End If
            Csum = Csum + A
        Next

        ' Now we subtract the checksum from the next higher multiple of 10.

        Csum = ((Csum + 9) \ 10) * 10 - Csum
        If Val(Right$(strCC$, 1)) = Csum Then
            fcnValidCCNumber = True
        End If

    End Function

End Module
