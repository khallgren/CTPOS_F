Imports System.IO

Public Module basErrorHandling

    Public blnDetailedLog As Boolean

    Public Sub subLogErr(ByVal strFrom As String, ByVal ex As Exception)

        subLogErr(strFrom, ex, True)

    End Sub

    Public Sub subLogErr(ByVal strFrom As String, ByVal ex As Exception, ByVal _blnShowMsg As Boolean)

        Dim strErrNotes As String
        Dim strWrite As String

        Try

            If _blnShowMsg Then
                strErrNotes = InputBox("An error has occurred and a log has been generated." & vbNewLine & vbNewLine & "Please enter any notes describing the conditions that raised the error." & vbNewLine & vbNewLine & "(" & ex.Message & "|" & strFrom & ")", "CampTrak Error")
                MessageBox.Show("Additional error details: " & ex.Message & "; " & ex.StackTrace)
            Else
                strErrNotes = "MSG SUPPRESSED FROM USER"
            End If

            strWrite = ex.Message & " | " & strFrom & "|" & strErrNotes

            subWriteLog(strWrite)

        Catch exErr As Exception

            MsgBox(exErr.Message)

            MessageBox.Show("Additional error details: " & ex.Message & "; " & ex.StackTrace)

        End Try

    End Sub

    Public Sub subWriteLog(ByVal strLine As String)

        Dim stwOutFile As StreamWriter

        Dim strLog As String = ""

        Try

            strLog = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\CTErr.log"

            If Mid(strLog, 1, 6) = "file:\" Then strLog = Mid(strLog, 7, Len(strLog) - 6)

            stwOutFile = New StreamWriter(strLog, True)

            stwOutFile.WriteLine(Now & ": " & strLine)

            stwOutFile.Flush()

            stwOutFile.Close()

            stwOutFile.Dispose()

            stwOutFile = Nothing

        Catch ex2 As Exception

            MsgBox("Error writing log to " & strLog & ": " & ex2.Message)

        End Try

    End Sub

    Public Sub subDebugLog(ByVal _strMsg As String)

        Dim strFileName As String
        Dim strFilePath As String

        Try

            Using conDB As OleDb.OleDbConnection = New OleDb.OleDbConnection(strCTConn)
                strFilePath = System.IO.Path.GetDirectoryName(conDB.DataSource)
            End Using

            strFileName = strFilePath & "\CTPOSDebug.log"

            Using outfile As StreamWriter = New StreamWriter(strFileName, True)
                outfile.WriteLine(Date.Now.ToString() & ": " & _strMsg)
            End Using

        Catch ex As Exception

        End Try


    End Sub

End Module

