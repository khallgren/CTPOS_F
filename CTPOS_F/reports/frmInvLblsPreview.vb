Imports System.Data.OleDb

Public Class frmInvLblsPreview

    Private objInvLbls As rptInvLbls2

    Private Sub frmInvLblsPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strSQL As String

        Try
            Using conPOS As New OleDbConnection(strPOSConn)

                conPOS.Open()

                strSQL = "SELECT lngInventoryID, " & _
                            "curListPrice, " & _
                            "strStockCode, strItemName " & _
                        "FROM tblInventory " & _
                        "WHERE blnInactive = 0 " & _
                        "ORDER BY strItemName"

                Using cmdPOS As New OleDbCommand(strSQL, conPOS)

                    Using daLbls As New OleDbDataAdapter(cmdPOS)

                        Using dsLbls As New DataSet("dsLbls")
                            daLbls.Fill(dsLbls, "qrptInvLbls")

                            objInvLbls = New rptInvLbls2
                            objInvLbls.SetDataSource(dsLbls)

                            Me.rvwInvLbls.ReportSource = objInvLbls

                        End Using

                    End Using
                End Using

                conPOS.Close()

            End Using

        Catch ex As Exception
            subLogErr("frmInvLblsPreview.Load", ex)

        End Try

    End Sub

End Class