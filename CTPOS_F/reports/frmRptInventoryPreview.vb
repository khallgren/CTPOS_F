Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb
Public Class frmRptInventoryPreview
    Private objInventoryRpt As rptInventory
    Public strSQL As String = frmInvRptSetUp.strSQLGlobal


    Private Sub subConfigureCrystalReports()
        Dim objPOSConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsInventory As DataSet
        Try
            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn

            objPOSConn.Open()

            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand

            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "start"
            dsInventory = New DataSet("dsRptInventory")
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "1"
            daPOS.SelectCommand.CommandText = strSQL

            daPOS.Fill(dsInventory, "qrptInventory")
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "2"
            objInventoryRpt = New rptInventory
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "3"
            objInventoryRpt.SetDataSource(dsInventory)
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "4"
            dsInventory.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "5"
            Me.rvwReport.ReportSource = objInventoryRpt
            If blnDebug Then objSwitchboard.txtDebug.Text = objSwitchboard.txtDebug.Text & vbNewLine & vbNewLine & "-" & "6"
            objPOSConn.Close()
            comPOS = Nothing
            daPOS = Nothing
            dsInventory = Nothing


        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try


    End Sub

    Private Sub frmRptInventoryPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class