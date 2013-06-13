Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb

Public Class frmItemLablePreview
    Public lngInvID As Long = -1
    Public lngInputLabel As Long = 0
    Private objItemLabelsrpt As rptItemLables

    Private Sub subConfigureCrystalReports()


        Dim objPOSConn As OleDbConnection


        Dim comPOS As OleDbCommand


        Dim daPOS As OleDbDataAdapter


        Dim dsQueryLable As DataSet
        Dim DSQueryLableRpt As DataSet

        Dim strSQLQueryCamperCheckOut As String
     
        Dim strWhere As String = ""

        Try


            objPOSConn = New OleDbConnection()
            objPOSConn.ConnectionString = strPOSConn
            objPOSConn.Open()
            daPOS = New OleDbDataAdapter
            comPOS = New OleDbCommand
            comPOS.Connection = objPOSConn
            daPOS.SelectCommand = comPOS


            dsQueryLable = New DataSet("QueryLable")
            DSQueryLableRpt = New DataSet("QueryLable")
            If lngInvID = -1 Then
                strSQLQueryCamperCheckOut = "SELECT tblInventory.lngInventoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.curListPrice, tblInventory.blnInactive FROM tblInventory  WHERE(((tblInventory.blnInactive) = 0)) ORDER BY tblInventory.strItemName;"
            Else
                strSQLQueryCamperCheckOut = "SELECT tblInventory.lngInventoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.curListPrice, tblInventory.blnInactive FROM tblInventory WHERE(((tblInventory.blnInactive) = 0) AND ((tblInventory.lngInventoryID) = " & lngInvID & " )) ORDER BY tblInventory.strItemName;"
            End If

            daPOS.SelectCommand.CommandText = strSQLQueryCamperCheckOut
            daPOS.Fill(dsQueryLable, "tblInventory")

            strSQLQueryCamperCheckOut = "SELECT tblInventory.lngInventoryID, tblInventory.strStockCode, tblInventory.strItemName, tblInventory.curListPrice, tblInventory.blnInactive FROM tblInventory WHERE ((tblInventory.lngInventoryID) = 0) ORDER BY tblInventory.strItemName;"
            daPOS.SelectCommand.CommandText = strSQLQueryCamperCheckOut
            daPOS.Fill(DSQueryLableRpt, "tblInventory")


            Dim i As Long
            For i = 1 To lngInputLabel
                Dim dr As DataRow
                dr = DSQueryLableRpt.Tables("tblInventory").NewRow
                dr.Item("lngInventoryID") = lngInvID
                dr.Item("strStockCode") = ""
                dr.Item("strItemName") = ""
                dr.Item("curListPrice") = 0
                dr.Item("blnInactive") = 0
                DSQueryLableRpt.Tables("tblInventory").Rows.Add(dr)
            Next i

            For i = 1 To (30 - lngInputLabel)
                Dim dr As DataRow
                dr = DSQueryLableRpt.Tables("tblInventory").NewRow
                dr.Item("lngInventoryID") = dsQueryLable.Tables("tblInventory").Rows(0).Item("lngInventoryID")
                dr.Item("strStockCode") = dsQueryLable.Tables("tblInventory").Rows(0).Item("strStockCode")
                dr.Item("strItemName") = dsQueryLable.Tables("tblInventory").Rows(0).Item("strItemName")
                dr.Item("curListPrice") = dsQueryLable.Tables("tblInventory").Rows(0).Item("curListPrice")
                dr.Item("blnInactive") = dsQueryLable.Tables("tblInventory").Rows(0).Item("blnInactive")
                DSQueryLableRpt.Tables("tblInventory").Rows.Add(dr)
            Next


            objItemLabelsrpt = New rptItemLables
            Dim rw = DSQueryLableRpt.Tables(0).Rows.Count
            objItemLabelsrpt.SetDataSource(DSQueryLableRpt)

            dsQueryLable.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
            Me.rvwReport.ReportSource = objItemLabelsrpt

        Catch ex As Exception
            subLogErr(Me.Name & ".New", ex)
        End Try

        objPOSConn = Nothing
        comPOS = Nothing
        daPOS = Nothing
        dsQueryLable = Nothing

    End Sub

    Private Sub frmItemLablePreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subConfigureCrystalReports()
    End Sub
End Class