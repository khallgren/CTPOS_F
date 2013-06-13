Imports System.Data.OleDb
Imports CTPOS_F.clsGlobalEnum

Public Class frmDeptXFerRptPreview

    Public objDeptXFer As rptDeptXFer

    Public dteStart As Date
    Public dteEnd As Date
    Public dteXFer As Date

    Public lngDateCriter As conDATECRITER
    Public lngDeptID As Long

    Private Sub frmDeptXFerRptPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objPOSConn As OleDbConnection
        Dim comPOS As OleDbCommand
        Dim daPOS As OleDbDataAdapter
        Dim dsDeptXFer As DataSet

        Dim strSQL As String
        Dim strWhere As String

        objPOSConn = New OleDbConnection

        objPOSConn.ConnectionString = strPOSConn

        objPOSConn.Open()

        daPOS = New OleDbDataAdapter

        comPOS = New OleDbCommand

        comPOS.Connection = objPOSConn

        daPOS.SelectCommand = comPOS

        dsDeptXFer = New DataSet("dsDeptXFer")

        strWhere = "WHERE tblSales.lngSaleTypeID=7 "

        Select Case Me.lngDateCriter
            Case conDATECRITER.conSpecificDate
                If blnUseSQLServer Then
                    strWhere = strWhere & " AND DateDiff(d, tblSales.dteSaleDate, '" & Me.dteXFer & "')=0"
                Else
                    strWhere = strWhere & " AND DateDiff('d', tblSales.dteSaleDate, '" & Me.dteXFer & "')=0"
                End If

            Case conDATECRITER.conDateRange
                If blnUseSQLServer Then
                    strWhere = strWhere & " AND DateDiff(d, '" & Me.dteStart & "', tblSales.dteSaleDate)>=0 AND " & _
                                        "DateDiff(d, tblSales.dteSaleDate, '" & Me.dteEnd & "')>=0"

                Else
                    strWhere = strWhere & " AND DateDiff('d', '" & Me.dteStart & "', tblSales.dteSaleDate)>=0 AND " & _
                                        "DateDiff('d', tblSales.dteSaleDate, '" & Me.dteEnd & "')>=0"
                End If
        End Select

        If Me.lngDeptID <> 0 Then strWhere = strWhere & " AND tblSales.lngDeptID=" & Me.lngDeptID

        strSQL = "SELECT tblSales.lngSaleID, tblSalesDetail.lngQuantity, " & _
                    "tblSales.dteSaleDate, " & _
                    "tblSalesDetail.curTotal, " & _
                    "tblDepartments.strDepartmentName, tblInventory.strItemName " & _
                "FROM ((tblSales " & _
                    "INNER JOIN tblDepartments ON tblSales.lngDeptID = tblDepartments.lngDeptID) " & _
                    "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) " & _
                    "INNER JOIN tblInventory ON tblSalesDetail.lngInventoryID = tblInventory.lngInventoryID " & _
                strWhere

        daPOS.SelectCommand.CommandText = strSQL

        daPOS.Fill(dsDeptXFer, "tblSales")

        objDeptXFer = New rptDeptXFer

        objDeptXFer.SetDataSource(dsDeptXFer)

        dsDeptXFer.WriteXml("Schema.xml", XmlWriteMode.WriteSchema)
        rvwDeptXFer.ReportSource = objDeptXFer

    End Sub

    Private Sub rvwDeptXFer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rvwDeptXFer.Load

    End Sub
End Class