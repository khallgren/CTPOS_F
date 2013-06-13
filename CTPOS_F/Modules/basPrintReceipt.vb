Module basPrintReceipt
    Public Function fcnPrintReceipt(ByVal strOutput As String) As Boolean

        Dim x As Integer = 0

        Dim retval As Boolean
        Dim FormFeed As Boolean = True
        Dim Data As String
        If strRcptPrinter = "" Or IsDBNull(strRcptPrinter) Then Exit Function

        'Replcae each occurance of ESC with CHR(27)
        Data = Replace(strOutput, "ESC", Chr(27))
        'Data = Data & Chr(&H1B) & "d" & Chr(3)

        'Send the data (as raw data) to the printer
        'retval = RDP.PrintRawData(Data, , strRcptPrinter, , , , True, , , , )
        retval = RDP.PrintRawData(Data, , strRcptPrinter, , , , False, , , , )
    
    End Function
End Module
