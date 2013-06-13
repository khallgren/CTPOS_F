Imports System.Data.OleDb


Public Class frmStaffCharge

    Public lngStaffID As Long

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Try

            Me.lngStaffID = 0

            Me.Close()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnCancel", ex)

        End Try

    End Sub

    Private Sub subLoadStaff()
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drStaff As OleDbDataReader

        Dim strSQL As String
        Dim lstStaff As clsCboItem

        Try
            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT * " & _
                        "FROM tblResidentStaff " & _
                        "ORDER BY tblResidentStaff.strStaffLName, tblResidentStaff.strStaffFName;"

            objCommand.CommandText = strSQL

            drStaff = objCommand.ExecuteReader

            While drStaff.Read

                Dim lngStaffID As Long = 0
                Dim strFName As String = ""
                Dim strLName As String = ""

                Try
                    Long.TryParse(drStaff("lngstaffID"), lngStaffID)
                    strLName = drStaff("strSTaffLName").ToString()
                    strFName = drStaff("strSTaffFName").ToString()

                Catch ex As Exception

                End Try
                lstStaff = New clsCboItem(lngStaffID, strLName & ", " & strFName)

                Me.lstStaff.Items.Add(lstStaff)


            End While

            drStaff.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            objCommand = Nothing
            objConn = Nothing

        Catch ex As Exception

            subLogErr(Me.Name & ".Load", ex)

        End Try

    End Sub

    Private Sub frmCamperSpendingMoney_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subLoadStaff()
    End Sub


    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        subProceed()
    End Sub
    Private Sub subProceed()
        Try
            If Me.lstStaff.SelectedIndex > -1 Then
                Me.lngStaffID = CType(CType(Me.lstStaff.SelectedItem, clsCboItem).ID, Long)
                Me.Close()
                'Exit Sub
            ElseIf Me.lstStaff.SelectedIndex < 0 Then

                MsgBox("Please select a staff member or click 'Cancel'.")
                Exit Sub

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".btnContinue_Click", ex)

        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


End Class