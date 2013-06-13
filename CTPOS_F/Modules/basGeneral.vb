Imports System.Data.OleDb
Imports Microsoft.Win32

Module basGeneral
    Public Sub fcnFixTrans()

        Dim objConnPOS As OleDbConnection
        Dim objConnMain As OleDbConnection

        Dim objCommandInsert As OleDbCommand
        Dim Command As OleDbCommand
        Dim commandUpdate As OleDbCommand

        Dim rs As OleDbDataReader
        Dim rsTrans As OleDbDataReader

        objConnPOS = New OleDbConnection
        objConnPOS.ConnectionString = strCTConn
        objConnPOS.Open()


        Dim TransID = 0, Amount As Object
        Dim strSQL As String

        strSQL = "SELECT tblTransactions.lngTransactionID as TransID, Sum(tblSalesDetail.curTotal) AS Amount, tblTransactions.curCharge FROM (tblSales INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID) INNER JOIN tblTransactions ON tblSales.lngTransactionID = tblTransactions.lngTransactionID GROUP BY tblTransactions.lngTransactionID, tblTransactions.curCharge HAVING (((Sum(tblSalesDetail.curTotal))<>[tbltransactions].[curcharge]))"
        Command = New OleDbCommand
        Command.Connection = objConnPOS
        Command.CommandText = strSQL

        rs = Command.ExecuteReader

        If Not rs.HasRows Then GoTo Done


        Do While rs.Read
            TransID = rs("TransID")
            Amount = rs("Amount")

            strSQL = "UPDATE tblTransactions SET tblTransactions.curCharge = " & Amount & " WHERE (((tblTransactions.lngTransactionID)=" & TransID & "));"

            commandUpdate = New OleDbCommand
            commandUpdate.Connection = objConnPOS
            commandUpdate.CommandText = strSQL
            Dim rows = commandUpdate.ExecuteNonQuery

            commandUpdate = Nothing
        Loop

Done:

        rs.Close()

        'fix missing trans
        strSQL = "SELECT tblSales.lngSaleID, tblSales.dteSaleDate, tblSales.lngCamperID, tblSales.lngTransactionID, tblSales.lngRegistrationID, Sum(tblSalesDetail.curTotal) AS SumOfcurTotal " & _
           "FROM ((tblSales LEFT JOIN tblTransactions ON tblSales.lngTransactionID = tblTransactions.lngTransactionID) INNER JOIN tblRegistrations ON tblSales.lngRegistrationID = tblRegistrations.lngRegistrationID) INNER JOIN tblSalesDetail ON tblSales.lngSaleID = tblSalesDetail.lngSaleID " & _
           "GROUP BY tblSales.lngSaleID, tblSales.dteSaleDate, tblSales.lngCamperID, tblSales.lngTransactionID, tblSales.lngRegistrationID, tblTransactions.lngTransactionID " & _
           "HAVING (((tblSales.dteSaleDate)>#5/1/2003#) AND ((tblSales.lngCamperID) Is Not Null) AND ((tblTransactions.lngTransactionID) Is Null));"

        Command.CommandText = strSQL
        rs = Command.ExecuteReader

        objConnMain = New OleDbConnection
        objConnMain.ConnectionString = strCTConn
        objConnMain.Open()

        objCommandInsert = New OleDbCommand
        objCommandInsert.Connection = objConnMain

        Do While rs.Read

            strSQL = "select * from tblTransactions where lngTransactionID=0;"

            Dim curCharge = rs("sumofcurtotal")
            Dim new_date = rs("dtesaledate")
            Dim lngRegId = rs("lngregistrationID")
            Dim lngCamper = rs("lngcamperid")
            Dim lngSaleID = rs("lngSaleID")
            objCommandInsert.CommandText = "INSERT INTO tblTransactions " & _
                                        "(curCharge,dteDateAdded,lngTransTypeID,lngRegistrationID,lngRecordID,lngPaymentTypeID, lngSaleID ) " & _
                                        "VALUES (" & curCharge & ", #" & new_date & "# , 6 ," & lngRegId & "," & lngCamper & " , 7, " & lngSaleID & " );"

            Dim rw = objCommandInsert.ExecuteNonQuery()

            Dim objCommandTrans = New OleDbCommand
            objCommandTrans.Connection = objConnMain
            Dim strSQLRegID = "SELECT lngTransactionID " & _
                            "FROM tblTransactions " & _
                            "WHERE curCharge = " & curCharge & " AND lngTransTypeID = 6 AND lngRegistrationID = " & lngRegId & " and lngRecordID = " & lngCamper & " and lngPaymentTypeID = 7"

            objCommandTrans.CommandText = strSQLRegID
            rsTrans = objCommandTrans.ExecuteReader

            Do While rsTrans.Read
                TransID = rsTrans("lngTransactionID")
            Loop


            commandUpdate = New OleDbCommand
            commandUpdate.Connection = objConnPOS
            commandUpdate.CommandText = "UPDATE tblsales SET lngtransactionid = " & TransID & " WHERE lngsaleID=" & lngSaleID
            Dim temp = commandUpdate.ExecuteNonQuery()
        Loop

        rs.Close()

        'delete trans missing sales
        'fix missing trans

        strSQL = "SELECT tblTransactions.lngTransactionID, tblTransactions.curCharge " & _
               "FROM tblTransactions LEFT JOIN tblSales ON tblTransactions.lngTransactionID = tblSales.lngTransactionID " & _
               "WHERE (((tblTransactions.lngTransTypeID)=6) AND ((tblSales.lngTransactionID) Is Null));"

        Dim objCommand = New OleDbCommand

        objCommand.connection = objConnPOS
        objCommand.CommandText = strSQL
        rsTrans = objCommand.ExecuteReader

        Do While rsTrans.Read
            Dim lngTransactionID = rsTrans("lngTransactionID")
            strSQL = "Delete * from tblTransactions where lngTransactionID=" & lngTransactionID

            Dim objDelCommand = New OleDbCommand
            objDelCommand.CommandText = strSQL
            objDelCommand.connection = objConnPOS
            Dim temp = objDelCommand.ExecuteNonQuery()
            objDelCommand = Nothing

        Loop

        rsTrans.Close()
        rsTrans = Nothing
        objConnMain.Close()
        objConnPOS.Close()


    End Sub

    Public Sub subExecuteSQL(ByVal strSQL, ByVal strConn)
        
        Using conDB As OleDbConnection = New OleDbConnection(strConn)

            conDB.Open()

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                Try
                    cmdDB.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("There was an error executing the command: " & ex.Message)
                End Try
            End Using

            conDB.Close()

        End Using
        
    End Sub
End Module