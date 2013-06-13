Imports System.Data.OleDb

Module basDataForm

    Public Enum CtlArrayItems As Integer
        ControlName = 0
        LabelName = 1
        FieldName = 2
        ControlType = 3
        ComboSQL = 4
        Currency = 5
        Editable = 6
    End Enum

    Public Sub subPopulateForm(ByVal frm As Form, ByVal CtlArray(,) As String, ByVal strSQL As String, ByVal strConn As String)
        'array def:  0=control name, 1=label name, 2=field name, 3=control type, 4=combo sql, 5=currency?, 6=editable
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim dr As OleDbDataReader

        Dim Chkbox As CheckBox
        Dim ctl As Control

        Dim row As Integer

        objConn = New OleDbConnection
        objConn.ConnectionString = strConn
        objConn.Open()
        objCommand = New OleDbCommand
        objCommand.Connection = objConn

        objCommand.CommandText = strSQL
        dr = objCommand.ExecuteReader

        While dr.Read

            For row = 0 To UBound(CtlArray, 1)

                Dim buf As String = ""
                Dim column As Integer

                For column = 0 To UBound(CtlArray, 2)
                    'buf &= CtlArray(row, column) & ", "

                    'set enabled
                    If CtlArray(row, 6) = "False" Then
                        frm.Controls(CtlArray(row, 0)).Enabled = False
                    End If

                    Select Case CtlArray(row, 3).ToString

                        Case "Text"
                            frm.Controls(CtlArray(row, 0)).Text = dr(CtlArray(row, 2).ToString).ToString

                        Case "Checkbox"

                            For Each ctl In frm.Controls
                                If ctl.Name = CtlArray(row, 0).ToString Then
                                    Chkbox = ctl
                                    Select Case dr(CtlArray(row, 2).ToString).ToString
                                        Case "True"
                                            Chkbox.Checked = True
                                        Case "False"
                                            Chkbox.Checked = False
                                    End Select
                                End If
                            Next

                        Case Else
                            Stop
                    End Select

                Next

                'Console.WriteLine(buf)

            Next
        End While

        dr.Close()
        objConn.Close()
        objCommand.Dispose()
        objConn.Dispose()
        objCommand = Nothing
        objConn = Nothing

    End Sub
End Module
