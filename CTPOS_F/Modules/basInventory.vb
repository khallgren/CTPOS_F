Imports System.Data.OleDb
Module basInventory

    Public Function fcnGetCurrentInventory(ByVal lngStoreID As Long, ByVal lngInvID As Long) As Long

        Dim strSQL As String
        Dim intSold As Long
        Dim intAdj As Long
        Dim intRes As Long

        Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

            conDB.Open()

            strSQL = "SELECT SUM(intAdjustmentQty) AS lngQuantity " & _
                    "FROM tblAdjustment " & _
                    "WHERE (((lngInventoryID)=" & lngInvID & ") AND ((lngStoreID)=" & lngStoreID & "));"

            If objLogin.chkDebug.Checked Then subDebugLog("Adjustment query: " & strSQL)

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                Try
                    intAdj = Convert.ToInt32(cmdDB.ExecuteScalar())
                    If objLogin.chkDebug.Checked Then subDebugLog("Adj count: " & intAdj.ToString())
                Catch ex As Exception
                    intAdj = 0
                    If objLogin.chkDebug.Checked Then subDebugLog("Adj err: " & ex.Message)
                End Try

                strSQL = "SELECt SUM(tblSalesDetail.lngQuantity) AS lngQuantity " & _
                            "FROM tblSales " & _
                                "INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
                            "WHERE (((lngInventoryID)=" & lngInvID & ") AND ((lngStoreID)=" & lngStoreID & "));"

                If objLogin.chkDebug.Checked Then subDebugLog("Sold query: " & strSQL)

                cmdDB.CommandText = strSQL
                cmdDB.Parameters.Clear()

                Try
                    intSold = Convert.ToInt32(cmdDB.ExecuteScalar())
                    If objLogin.chkDebug.Checked Then subDebugLog("Sold count: " & intSold.ToString())
                Catch ex As Exception
                    intSold = 0
                    If objLogin.chkDebug.Checked Then subDebugLog("Sold err: " & ex.Message)
                End Try

            End Using

            conDB.Close()

        End Using

        intRes = intAdj - intSold

        Return intRes

    End Function

End Module
