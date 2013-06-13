Imports System.Data.OleDb
Imports Microsoft.Win32

Public Module basDBConnect
    Public Function fcnBuildSQLConnect(ByVal strRegKey As String, ByRef strConn As String) As Boolean
        Dim objConn As OleDbConnection


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUsername As String = ""
        Dim strPassword As String = ""

        strServer = My.Settings.SQLServer
        strDatabase = My.Settings.SQLDatabase
        strUsername = My.Settings.SQLUserName
        strPassword = My.Settings.SQLPassword

        strConn = "Provider=sqloledb;Data Source=" & strServer & ";Initial Catalog=" & strDatabase & ";User Id=" & strUsername & ";Password=" & strPassword & ";"

        'try connection
        Try
            objConn = New OleDbConnection

            objConn.ConnectionString = strConn

            objConn.Open()
            objConn.Close()

            fcnBuildSQLConnect = True
        Catch ex As Exception
            strConn = "failed"
            subLogErr("fcnBuildSQLConnect", ex)
            fcnBuildSQLConnect = False
        End Try
    End Function

    Public Function fcnRelink(ByVal strFile As String, ByVal strRegKey As String, ByVal strRegistry As String, ByRef strConn As String) As Boolean

        Dim objConn As OleDbConnection
        Dim strMsg As String = ""

        Dim blnRes As Boolean

        Try

            strFile = My.Settings.Item(strRegistry).ToString


            If strFile = "" Then

                fcnRelink = False
                Exit Function

            End If

            If System.IO.File.Exists(strFile) Then

                If (strFile.EndsWith("accdb")) Then
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & strFile & "; User Id=admin; Password="
                Else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & strFile & "; User Id=admin; Password="
                End If

            Else

                strFile = fcnFindFile("Find ctMain_b.mdb file:")

                If (strFile.EndsWith("accdb")) Then
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & strFile & "; User Id=admin; Password="
                Else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & strFile & "; User Id=admin; Password="
                End If

            End If

            objConn = New OleDbConnection

            'try connection
            Try

                objConn.ConnectionString = strConn

                objConn.Open()
                objConn.Close()

                blnRes = True

            Catch ex As Exception

                strMsg = "Error on relink: " & ex.Message & vbNewLine & _
                        "Connection: " & strConn

                MsgBox(strMsg)

                strFile = fcnFindFile("Find ctMain_b.mdb file:")

                If (strFile.EndsWith("accdb")) Then
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & strFile & "; User Id=admin; Password="
                Else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & strFile & "; User Id=admin; Password="
                End If

                Try

                    objConn.ConnectionString = strConn

                    objConn.Open()
                    objConn.Close()

                    blnRes = True

                Catch ex2 As Exception

                    blnRes = False

                    strMsg = "Error (2) on relink: " & MsgBox(ex2.Message) & vbNewLine & _
                        "Connection: " & strConn


                    MsgBox(strMsg)

                End Try

            End Try

            objConn.Dispose()

            objConn = Nothing


            If blnRes Then
                My.Settings.Item(strRegistry) = strFile
                My.Settings.Save()
            End If

            fcnRelink = blnRes

        Catch ex As Exception

            subLogErr("fcnRelink", ex)

        End Try

    End Function

    Public Function fcnFindFile(ByVal strCaption As String) As String

        Dim dlgFile As New OpenFileDialog

        Dim strRes As String = ""

        Try

            dlgFile.Filter = "MSAccess Database Files (*.mdb)|*.mdb"
            dlgFile.Title = strCaption

            If dlgFile.ShowDialog = DialogResult.OK Then
                strRes = dlgFile.FileName
            Else
                strRes = ""
            End If

        Catch ex As Exception

            subLogErr("fcnFindFile", ex)

        End Try

        fcnFindFile = strRes

    End Function

End Module
