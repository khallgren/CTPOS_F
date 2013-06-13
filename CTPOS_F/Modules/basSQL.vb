Imports CTPOS_F.clsGlobalEnum
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports System.Windows.Forms

Module basSQL
    Dim dsl As New DataSet
    Dim ColumnList As ArrayList

   
    Public Function fcnSQLStr(ByVal _lngSQLName As conSQLNAME) As String

        Dim strSQL As String

        Dim lngDBType As conDBTYPE

        If My.Settings.UseSQLServer Then
            lngDBType = conDBTYPE.conSQLServer
        Else
            lngDBType = conDBTYPE.conMSAccess
        End If

        Select Case _lngSQLName
            Case conSQLNAME.conDeptXFerDates
                strSQL = fcnDeptXFerDatesSQL(lngDBType)

            Case Else
                strSQL = ""

        End Select

        fcnSQLStr = strSQL

    End Function

    Private Function fcnDeptXFerDatesSQL(ByVal _lngDBType As conDBTYPE) As String

        Dim strSQL As String

        Select Case _lngDBType

            Case conDBTYPE.conMSAccess
                strSQL = "SELECT Format([tblSales].[dteSaleDate],""yyyy-mm-dd"") AS dteSaleDate " & _
                        "FROM tblSales " & _
                        "WHERE tblSales.lngSaleTypeID = 7 " & _
                        "GROUP BY Format([tblSales].[dteSaleDate],""yyyy-mm-dd"");"

            Case conDBTYPE.conSQLServer
                strSQL = "SELECT CAST(DATEPART(yyyy, dteSaleDate) AS CHAR(4)) + '-' + RIGHT(CAST(100 + DATEPART(mm, dteSaleDate) AS CHAR(3)), 2) + '-' + RIGHT(CAST(100 + DATEPART(dd, dteSaleDate) AS CHAR(3)), 2) AS dteSaleDate " & _
                        "FROM tblSales " & _
                        "WHERE tblSales.lngSaleTypeID = 7 " & _
                        "GROUP BY CAST(DATEPART(yyyy, dteSaleDate) AS CHAR(4)) + '-' + RIGHT(CAST(100 + DATEPART(mm, dteSaleDate) AS CHAR(3)), 2) + '-' + RIGHT(CAST(100 + DATEPART(dd, dteSaleDate) AS CHAR(3)), 2)"

            Case Else
                strSQL = ""

        End Select

        fcnDeptXFerDatesSQL = strSQL

    End Function

    'Generic method to create temporary tables, This method internally checks if table exists or not if exists then deletes it. and then creates it.
    'parameter 1 : Name of tabel you want to create
    'parameter 2 : Create Table string of table
    'parameter 3 : Select String by which you want to fill data  you want to create
    Public Sub CreateTempTables(ByVal Name As String, ByVal strCreate As String, ByVal strSelect As String)
        Dim objConn As OleDbConnection
        Dim CreateCommand As OleDbCommand
        Dim InsertCommand As OleDbCommand
        Dim SelectCommand As OleDbCommand
        Dim rs As OleDbDataReader

        Try

            'Creating Temporary table
            DropIfExist(Name)

            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            CreateCommand = New OleDbCommand
            CreateCommand.Connection = objConn

            SelectCommand = New OleDbCommand
            SelectCommand.Connection = objConn

            InsertCommand = New OleDbCommand
            InsertCommand.Connection = objConn


            CreateCommand.CommandText = strCreate
            Dim iResult = CreateCommand.ExecuteNonQuery()




            SelectCommand.CommandText = strSelect

            rs = SelectCommand.ExecuteReader
            'DataAdapter = New OleDbDataAdapter(strSQL, objConn)
            ' create a new dataset
            Do While rs.Read
                Dim d As Integer
                Dim insertQuery As String = "INSERT INTO " & Name & " VALUES ("
                For d = 0 To rs.FieldCount - 1

                    If Not rs.IsDBNull(d) Then
                        insertQuery = insertQuery & rs(d) & " , "
                    Else
                        insertQuery = insertQuery & " 0 , "
                    End If
                    'insertQuery = insertQuery & rs(d) & " , "
                Next d

                insertQuery = (insertQuery.Substring(0, insertQuery.Length - 2))
                insertQuery = insertQuery & " ); "
                InsertCommand.CommandText = insertQuery
                InsertCommand.ExecuteNonQuery()
            Loop
            'Removing Last comma

            objConn.Close()
            rs.Close()
            strCreate = Nothing

        Catch ex As Exception
            subLogErr("CreateTempTables", ex)
        End Try
    End Sub

    Public Sub DropIfExist(ByVal name As String)
        Dim objConn As OleDbConnection
        Dim DropCommand As OleDbCommand

        Dim SchemaTable As DataTable
        Try

            objConn = New OleDbConnection
            objConn.ConnectionString = strPOSConn
            objConn.Open()

            DropCommand = New OleDbCommand
            DropCommand.Connection = objConn

            SchemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, _
          New Object() {Nothing, Nothing, Trim(name)})

            'If table with name exists Delete it
            If SchemaTable.Rows.Count <> 0 Then
                Dim strSQLDrop = " DROP TABLE " & Trim(name)
                DropCommand.CommandText = strSQLDrop
                Dim iResult = DropCommand.ExecuteNonQuery()
            End If
            objConn.Close()

        Catch ex As Exception
            subLogErr("DropIfExist", ex)
        End Try

    End Sub

    ' Join two tables together
    Public Function JoinTables(ByVal LeftTable As DataTable, ByVal RightTable As DataTable, ByVal LeftColumn As String, ByVal RightColumn As String, ByVal JoinType As String, ByVal cols As ArrayList, ByVal ds As DataSet) As DataTable
        Dim dr_left, dr_right, dr_dest, dr_temp, drs() As DataRow
        Dim dt, left_dt, right_dt As DataTable
        Dim right_col, left_col, column As String
        Dim RightColumnList, LeftColumnList As ArrayList
        Dim i As Integer
        dsl = ds
        If Not IsNothing(ColumnList) Then ColumnList.Clear()
        ColumnList = cols

        ' Make sure both tables are in the DataSet.  You can't use Relationships 
        ' unless both tables are in the same DataSet.  We take them out at the end.
        If RightTable.TableName = "" Then
            RightTable.TableName = "__RIGHTTABLE__"
            dsl.Tables.Add(RightTable)
        End If
        If LeftTable.TableName = "" Then
            LeftTable.TableName = "__LEFTTABLE__"
            dsl.Tables.Add(LeftTable)
        End If

        ' build the detached TempTable that will be returned
        dt = BuildTempTable()
        left_dt = LeftTable
        right_dt = RightTable
        left_col = LeftColumn
        right_col = RightColumn

        ' what kind of join is this?
        Select Case JoinType
            Case "INNER"
            Case "LEFT"
            Case "RIGHT"
                ' We don't really do right joins... we just flip the arguments and
                ' do a left join instead.
                left_dt = RightTable
                right_dt = LeftTable
                left_col = RightColumn
                right_col = LeftColumn
                JoinType = "LEFT"
                'Case "FULL"
                '    ' A full join is kinda complicated... we do a right join, then a left,
                '    ' then combine the two together.  The optimum execution plan for a full 
                '    ' join should be a "merge" operation... but let's not make things any
                '    ' more complicated than they already are.
                '    Dim temp As DataTable
                '    temp = JoinTables(RightTable, LeftTable, RightColumn, LeftColumn, "LEFT")
                '    dt = JoinTables(LeftTable, RightTable, LeftColumn, RightColumn, "LEFT")

                '    drs = temp.Select(TabColName(LeftTable.TableName, LeftColumn) & " is null")
                '    For Each dr_right In drs
                '        dt.ImportRow(dr_right)
                '    Next
                '    Return dt
            Case Else
                Throw New ApplicationException("SQL syntax error: Unknown Join type '" & JoinType & "'")
        End Select

        ' create a relationship between the two tables
        dsl.Relations.Add(New DataRelation("__RELATIONSHIP__", right_dt.Columns(right_col), left_dt.Columns(left_col), False))

        ' let's go!
        dr_temp = dt.NewRow
        LeftColumnList = GetTableColumns(left_dt.TableName)
        RightColumnList = GetTableColumns(right_dt.TableName)
        For Each dr_left In left_dt.Rows

            ' Get the related rows from the "right" table
            drs = dr_left.GetParentRows("__RELATIONSHIP__")

            ' For inner joins, we don't record anything unless there is a matching row
            If UBound(drs) >= 0 Or JoinType <> "INNER" Then
                dr_dest = dt.NewRow

                ' Let's start by just copying the columns from the "left" table
                If left_dt.TableName = "__LEFTTABLE__" Then
                    dr_dest.ItemArray = dr_left.ItemArray
                Else
                    For Each column In LeftColumnList
                        dr_dest(TabColName(left_dt.TableName, column)) = dr_left(column)
                    Next
                End If

                ' There are three possibilities... there are no matching rows, there is
                ' only one related row, there are many related rows.
                Select Case UBound(drs)
                    Case -1
                        ' Just record the row as it is now (with just the columns from
                        ' the left table).
                        dt.Rows.Add(dr_dest)
                    Case 0
                        dr_right = drs(0)
                        If right_dt.TableName = "__RIGHTTABLE__" Then
                            For i = 0 To right_dt.Columns.Count - 1
                                ' fill in the holes, but do not overwrite the data that
                                ' came from the left table
                                If IsDBNull(dr_dest(i)) Then
                                    dr_dest(i) = dr_right(i)
                                End If
                            Next
                        Else
                            For Each column In RightColumnList
                                dr_dest(TabColName(right_dt.TableName, column)) = dr_right(column)
                            Next
                        End If
                        dt.Rows.Add(dr_dest)
                    Case Else
                        ' Make a copy of the prototype datarow that we already filled in
                        ' above.  It already has the column data from the left table.
                        dr_temp.ItemArray = dr_dest.ItemArray
                        For Each dr_right In drs
                            dr_dest = dt.NewRow

                            ' Copy prototype row (the left table's data)
                            dr_dest.ItemArray = dr_temp.ItemArray

                            ' Copy the columns from the related rows in the right table
                            If right_dt.TableName = "__RIGHTTABLE__" Then
                                For i = 0 To right_dt.Columns.Count - 1
                                    ' fill in the holes, but do not overwrite the data
                                    ' that came from the left table
                                    If IsDBNull(dr_dest(i)) Then
                                        dr_dest(i) = dr_right(i)
                                    End If
                                Next
                            Else
                                For Each column In RightColumnList
                                    dr_dest(TabColName(right_dt.TableName, column)) = dr_right(column)
                                Next
                            End If
                            dt.Rows.Add(dr_dest)
                        Next
                End Select
            End If
        Next

        ' delete the temporary relationship we created above
        dsl.Relations.Remove("__RELATIONSHIP__")

        ' remove the temporary DataTables from the DataSet
        If LeftTable.TableName = "__LEFTTABLE__" Then
            dsl.Tables.Remove(LeftTable)
        End If
        If RightTable.TableName = "__RIGHTTABLE__" Then
            dsl.Tables.Remove(RightTable)
        End If

        Return dt
    End Function

    Function BuildTempTable() As DataTable
        Dim dt As New DataTable
        Dim c, c_in As DataColumn
        Dim column, TableName, ColumnName As String

        For Each column In ColumnList
            TableName = ParseNextToLastDot(column)
            ColumnName = ParseLastDot(column)

            If TableName = "" Then
                c = New DataColumn(ColumnName)
                c.DataType = GetType(Integer)
            Else
                c_in = dsl.Tables(TableName).Columns(ColumnName)
                ' using full two-part table column name notation
                c = New DataColumn(TabColName(TableName, ColumnName))
                c.DataType = c_in.DataType
                c.MaxLength = c_in.MaxLength
            End If

            dt.Columns.Add(c)
            'Debug.WriteLine(c.ColumnName & "(" & c.DataType.ToString & ") ")
        Next

        Return dt
    End Function

    Private Function TabColName(ByVal TableName As String, ByVal ColumnName As String) As String
        'Return (TableName.Replace(" ", "_").Trim("[]".ToCharArray) & "_" & ColumnName.Replace(" ", "_").Trim("[]".ToCharArray))
        Return (ColumnName.Replace(" ", "_").Trim("[]".ToCharArray))
    End Function

    ' return a list of columns being used from this table
    Private Function GetTableColumns(ByVal Table As String) As ArrayList
        Dim ans As New ArrayList
        Dim column, ColumnName, TableName As String

        For Each column In ColumnList
            TableName = ParseNextToLastDot(column)
            ColumnName = ParseLastDot(column)

            If TableName = Table Then
                ans.Add(ColumnName)
            End If
        Next

        Return ans
    End Function

    ' Given a Server.Database.Table.Column notation, return the Table
    Function ParseNextToLastDot(ByVal buf As String) As String
        Dim bufs() As String
        Dim ans As String = ""

        If buf.IndexOf(".") > 0 Then
            bufs = buf.Split(".")
            ans = bufs(UBound(bufs) - 1)
        End If

        Return ans
    End Function

    ' Given a Server.Database.Table.Column notation, return the Column
    Function ParseLastDot(ByVal buf As String) As String
        Dim bufs(), ans As String

        If buf.IndexOf(".") > 0 Then
            bufs = buf.Split(".")
            ans = bufs(UBound(bufs))
        Else
            ans = buf
        End If

        Return ans
    End Function

    Public Sub subCreateView(ByVal _strViewName As String, ByVal _strSQL As String)

        Try

            Dim strSQL As String

            strSQL = "SELECT object_id('" & _strViewName & "')"

            Using conPOS As OleDbConnection = New OleDbConnection(strPOSConn)

                conPOS.Open()

                Using cmdPOS As OleDbCommand = New OleDbCommand(strSQL, conPOS)

                    If Not IsDBNull(cmdPOS.ExecuteScalar()) Then

                        strSQL = "DROP VIEW " & _strViewName

                        cmdPOS.CommandText = strSQL

                        cmdPOS.ExecuteNonQuery()

                    End If

                    cmdPOS.CommandText = _strSQL
                    cmdPOS.Parameters.Clear()

                    cmdPOS.ExecuteNonQuery()

                End Using

                conPOS.Close()

            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)

        End Try

    End Sub

End Module
