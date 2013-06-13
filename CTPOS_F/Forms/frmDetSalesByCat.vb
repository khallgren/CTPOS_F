Imports System.Data.OleDb

Public Class frmDetSalesByCat

    Private Sub frmDetSalesByCat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim conPOS As OleDbConnection
        Dim cmdPOS As OleDbCommand
        Dim drCbo As OleDbDataReader

        Dim cboItem As clsCboItem

        Dim strSQL As String

        Try

            cboCategory.Items.Add(New clsCboItem(0, "All Categories"))

            conPOS = New OleDbConnection(strPOSConn)

            conPOS.Open()

            strSQL = "SELECT lngInvCategoryID, " & _
                        "strInvCategory " & _
                    "FROM tblInvCodeCategory " & _
                    "ORDER BY strInvCategory"

            cmdPOS = New OleDbCommand(strSQL, conPOS)

            drCbo = cmdPOS.ExecuteReader

            While drCbo.Read
                cboItem = New clsCboItem(CType(drCbo("lngInvCategoryID").ToString, Long), drCbo("strInvCategory").ToString)
                cboCategory.Items.Add(cboItem)
            End While
            
            drCbo.Close()

            cboCategory.SelectedIndex = 0

        Catch ex As Exception
            subLogErr("frmDetailedSalesSetup_Load", ex)

        End Try

        drCbo = Nothing
        cmdPOS = Nothing
        conPOS = Nothing

    End Sub

    Private Sub subUpdateDateCriter() Handles radAllDates.CheckedChanged, radSpecificDate.CheckedChanged, radDateRange.CheckedChanged

        Me.lblStart.Visible = False
        Me.lblEnd.Visible = False
        Me.txtStart.Visible = False
        Me.txtEnd.Visible = False

        If Me.radSpecificDate.Checked Then
            Me.lblStart.Text = "Date:"
            Me.lblStart.Visible = True
            Me.txtStart.Visible = True
        ElseIf Me.radDateRange.Checked Then
            Me.lblStart.Text = "Start:"
            Me.lblStart.Visible = True
            Me.lblEnd.Visible = True
            Me.txtStart.Visible = True
            Me.txtEnd.Visible = True
        End If

    End Sub

End Class