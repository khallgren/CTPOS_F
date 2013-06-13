Imports System.Data.OleDb
Imports Microsoft.Win32
Imports CTPOS_F.clsGlobalEnum
Imports System.IO

Public Class frmSystemSetup

    Dim blnDirtyClerks As Boolean = False
    Dim blnDirtyStoreSetup As Boolean = False
    Dim blnDirtyPrinters As Boolean = False
    Dim blnDirtyCashDrawer As Boolean = False
    Dim blnDirtyData As Boolean = False
    Dim blnDirtySettings As Boolean = False
    Dim blnDirtyDepartments As Boolean = False
    Dim blnDirtyStores As Boolean = False
    Dim blnLoading As Boolean = True

    Private Sub frmSystemSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If blnDirtyClerks Or blnDirtyStoreSetup Or blnDirtyPrinters Or blnDirtyCashDrawer Or blnDirtyData Or blnDirtySettings Or blnDirtyDepartments Or blnDirtyStores Then
            MsgBox("Data unsaved, cannot close")
            e.Cancel = True
        End If
    End Sub


    Private Sub frmReceiptSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim lngCCMethod As clsGlobalEnum.conLIVECHARGE
        Dim cboCCMethodID As clsCboItem

        '-------------------settings tab init --------------------
        Me.txtStoreID.Text = My.Settings.lngStoreID.ToString
        Me.txtStationID.Text = My.Settings.lngWSID.ToString
        'Me.txtTaxRate.Text = My.Settings.dblTaxRate.ToString

        Me.chkCamperSort.Checked = My.Settings.blnCamperSort

        '----------------Connect Tab init --------------------------------
        Me.txtMainConnection.Text = My.Settings.MainPath
        Me.txtPOSConnection.Text = My.Settings.POSPath
        Me.txtSQLServer.Text = My.Settings.SQLServer
        Me.txtSQLDatabase.Text = My.Settings.SQLDatabase
        Me.txtSQLUsername.Text = My.Settings.SQLUserName
        Me.txtSQLPassword.Text = My.Settings.SQLPassword

        If blnUseSQLServer Then
            Me.radSQLServer.Checked = True
        Else
            Me.radMSAccess.Checked = True
        End If

        subSetPOSControls()

        '----------------Printer Tab init --------------------------------
        Me.chkOneCCReceipt.Checked = blnOneCCReceipt
        Dim setupRDP As New RawDataPrinter.Printer
        Dim x As Integer = 0
        Dim Printers As Object
        Me.chkUsePrinter.Checked = My.Settings.blnUsePrinter

        Printers = setupRDP.GetPrinters()

        Me.cboPrinterSelect.Items.Add("--- Select Printer ---")
        Me.cboPrinterSelect.DataSource = Printers

        Me.cboPrinterSelect.SelectedIndex = 0

        For x = 0 To Me.cboPrinterSelect.Items.Count - 1
            If Me.cboPrinterSelect.Items.Item(x).ToString = strRcptPrinter Then
                Me.cboPrinterSelect.SelectedIndex = x
            End If
        Next

        Me.txtHeader.Text = strHeader
        Me.txtFooter1.Text = strFooter1
        Me.txtFooter2.Text = strFooter2
        Me.TBLinesAfter.Value = intLinesAfter
        Me.tbLinesBefore.Value = intLinesBefore

        setupRDP = Nothing

        Me.cboPrinterSelect.Enabled = Me.chkUsePrinter.Checked
        Me.txtHeader.Enabled = Me.chkUsePrinter.Checked
        Me.txtFooter1.Enabled = Me.chkUsePrinter.Checked
        Me.txtFooter2.Enabled = Me.chkUsePrinter.Checked


        '------------------cc setup----------------------
        For Each lngCCMethod In [Enum].GetValues(GetType(clsGlobalEnum.conLIVECHARGE))

            cboCCMethodID = New clsCboItem(lngCCMethod, [Enum].GetName(GetType(clsGlobalEnum.conLIVECHARGE), lngCCMethod))

            Me.cboCCMethod.Items.Add(cboCCMethodID)

            If CType(cboCCMethodID.ID, Long) = My.Settings.lngLiveCharge Then Me.cboCCMethod.SelectedItem = cboCCMethodID

        Next

        Me.txtCashLinqUser.Text = My.Settings.strCashLinqUName
        Me.txtCashLinqPW.Text = My.Settings.strCashLinqPW

        If CType(My.Settings.lngLiveCharge, clsGlobalEnum.conLIVECHARGE) = clsGlobalEnum.conLIVECHARGE.XCharge Then
            Me.txtXChargePath.Visible = True
            Me.btnSetXChargePath.Visible = True
            Me.lblXChargePath.Visible = True
            Me.txtCashLinqUser.Visible = False
            Me.txtCashLinqPW.Visible = False
            Me.lblCashLinqUser.Visible = False
            Me.lblCashLinqPW.Visible = False
        ElseIf CType(My.Settings.lngLiveCharge, clsGlobalEnum.conLIVECHARGE) = clsGlobalEnum.conLIVECHARGE.CashLinq Then
            Me.txtXChargePath.Visible = False
            Me.btnSetXChargePath.Visible = False
            Me.lblXChargePath.Visible = False
            Me.txtCashLinqUser.Visible = True
            Me.txtCashLinqPW.Visible = True
            Me.lblCashLinqUser.Visible = True
            Me.lblCashLinqPW.Visible = True
        Else
            Me.txtXChargePath.Visible = False
            Me.btnSetXChargePath.Visible = False
            Me.lblXChargePath.Visible = False
            Me.txtCashLinqUser.Visible = False
            Me.txtCashLinqPW.Visible = False
            Me.lblCashLinqUser.Visible = False
            Me.lblCashLinqPW.Visible = False
        End If

        'drawer tab
        Me.chkUseBell.Checked = My.Settings.blnUseBell
        Me.txtDrawerPort.Text = My.Settings.strDrawerPort
        If blnUseBell Then
            Me.txtDrawerPort.Enabled = False
        Else
            Me.txtDrawerPort.Enabled = True
        End If

        'store setup init ---------------------------------------------------------
        subLoadStoreSetup()

        'clerk setup init -----------------------------------------------
        subLoadUsers()

        'store list edit -----------------------------------
        subLoadStores()
        subLoadSites()

        subLoadInvCbo()

        'department setup init------------------------
        subLoadDepartments()
        subLoadSettings()

        blnLoading = False ' finished loading controls
    End Sub

    Private Sub subLoadSettings()

        Try

            Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                conDB.Open()

                Dim strSQL As String

                strSQL = "SELECT strXChargePath " & _
                        "FROM tblCampDefaults"

                Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                    Using drDef As OleDbDataReader = cmdDB.ExecuteReader()

                        If drDef.Read() Then

                            Dim strXChargePath As String

                            Try
                                strXChargePath = Convert.ToString(drDef("strXChargePath"))
                                My.Settings.strXChargePath = strXChargePath
                                My.Settings.Save()
                            Catch ex As Exception
                                strXChargePath = ""
                            End Try

                            txtXChargePath.Text = strXChargePath

                        End If

                        drDef.Close()

                    End Using

                End Using

                conDB.Close()

            End Using

        Catch ex As Exception

            MessageBox.Show("There was an error loading defaults: " & ex.Message)

        End Try

    End Sub

    Private Sub subSaveSettings()

        Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

            conDB.Open()

            Dim strSQL As String

            strSQL = "UPDATE tblCampDefaults " & _
                    "SET strXChargePath=?"

            Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                cmdDB.Parameters.AddWithValue("@strXChargePath", txtXChargePath.Text)

                Try
                    cmdDB.ExecuteNonQuery()
                Catch ex As Exception

                End Try

                My.Settings.strXChargePath = txtXChargePath.Text
                My.Settings.Save()

            End Using

            conDB.Close()

        End Using

    End Sub

    Private Sub subLoadInvCbo()

        Dim strSQL As String

        Dim cboInv As clsCboItem

        Try
            If strPOSConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                    conDB.Open()

                    strSQL = "SELECT lngInventoryID, " & _
                                "strItemName " & _
                            "FROM tblInventory " & _
                            "ORDER BY strItemName"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drInv As OleDbDataReader = cmdDB.ExecuteReader()

                            While drInv.Read

                                cboInv = New clsCboItem(CType(drInv("lngInventoryID"), Long), drInv("strItemName").ToString())

                                Me.cboInventory.Items.Add(cboInv)

                            End While

                            drInv.Close()

                        End Using

                    End Using

                    conDB.Close()

                    'select default craft item (used for craft sales)
                    subSetSelectedIndex(Me.cboInventory, lngCraftID)

                End Using

            End If

        Catch ex As Exception

            subLogErr("frmSystemSetup_subLoadInvCbo", ex, False)

        End Try

    End Sub

    Private Sub subLoadStoreSetup()

        Dim strSQL As String

        Try

            If strCTConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                    conDB.Open()

                    strSQL = "SELECT tblCampDefaults.blnAlwaysPrintReciept, " & _
                                "intSpendingRefDur, tblCampDefaults.lngCampDefaultID, " & _
                                "tblCampDefaults.strStoreName, tblCampDefaults.strReceiptSignOff1, tblCampDefaults.strReceiptSignOff2 " & _
                            "FROM tblCampDefaults " & _
                            "ORDER BY tblCampDefaults.lngCampDefaultID;"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drDef As OleDbDataReader = cmdDB.ExecuteReader()

                            While drDef.Read

                                Me.txtStoreName.Text = drDef("strStoreName").ToString
                                Me.txtRecptSignOff1.Text = drDef("strReceiptSignOff1").ToString
                                Me.txtRecptSignOff2.Text = drDef("strReceiptSignOff2").ToString
                                Select Case drDef("blnAlwaysPrintReciept").ToString
                                    Case "True"
                                        Me.chkAlwaysPrintReceipt.Checked = True
                                    Case "False"
                                        Me.chkAlwaysPrintReceipt.Checked = False
                                End Select

                                txtSpendingRefDur.Text = drDef("intSpendingRefDur").ToString()

                            End While

                            drDef.Close()

                        End Using

                    End Using

                    conDB.Close()

                End Using

            End If

            If strPOSConn <> "" Then

                Using conCTPOS As New OleDbConnection(strPOSConn)

                    conCTPOS.Open()

                    strSQL = "SELECT dblTax " & _
                            "FROM tlkpTax;"

                    Using cmdCTPOS As New OleDbCommand(strSQL, conCTPOS)

                        Try
                            txtTaxRate.Text = cmdCTPOS.ExecuteScalar()
                        Catch ex As Exception
                            subLogErr("frmSystemSetup.subLoadStoreSetup", ex)
                        End Try

                    End Using

                    conCTPOS.Close()

                End Using

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadStoreSetup", ex, False)

        End Try
    End Sub

    Private Sub btnTestPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestPrint.Click

        Dim x As Integer = 0

        If blnUseBell Then
            rcptInit = ""
            rcptLeftJustify = ""
            rcptCenterJustify = ""
            rcptRightJustify = ""
            rcptReverseOn = ""
            rcptReverseOff = ""
            rcptLargeFont = ""
            rcptRegularFont = ""
            rcptFeedandCut = ""
            rcptKickDrawer = ""
        Else
            rcptInit = Chr(&H1B) & "@" & Chr(1)
            rcptNewLine = Chr(13) & Chr(10)
            rcptLeftJustify = Chr(&H1B) & "a" & Chr(0)
            rcptCenterJustify = Chr(&H1B) & "a" & Chr(1)
            rcptRightJustify = Chr(&H1B) & "a" & Chr(2)
            rcptReverseOn = Chr(&H1B) & "b" & Chr(1)
            rcptReverseOff = Chr(&H1B) & "b" & Chr(0)
            rcptLargeFont = Chr(&H1B) & "!" & Chr(17)
            rcptRegularFont = Chr(&H1B) & "!" & Chr(1)
            rcptFeedandCut = Chr(&H1D) & "V" & Chr(66) & Chr(0)
            rcptKickDrawer = Chr(&H1B) & Chr(&H70) & Chr(&H0) & Chr(60) & Chr(120)
        End If

        Dim strOutput As String = rcptInit & rcptCenterJustify & Me.txtHeader.Text & rcptNewLine & rcptLeftJustify & _
                                "Sale ID: 222 - Date: 4/1/2007 10:51:48 AM" & rcptNewLine & _
                                "Clerk: Admin" & rcptNewLine & _
                                "Payment Type: Cash" & rcptNewLine & _
                                "Sale Type: Sale" & rcptNewLine & rcptNewLine & _
                                rcptRightJustify & "1 Coke            $3.00        $3.00" & rcptNewLine & _
                                rcptRightJustify & "1 Icee Drink            $6.00        $6.00" & rcptNewLine & _
                                rcptCenterJustify & Me.txtFooter1.Text & rcptNewLine & _
                                rcptLargeFont & rcptCenterJustify & Me.txtFooter2.Text & rcptNewLine & rcptFeedandCut & rcptKickDrawer


        For x = 1 To intLinesBefore
            strOutput = rcptNewLine & strOutput
        Next x

        For x = 1 To intLinesAfter
            strOutput = strOutput & rcptNewLine
        Next x

        If blnUseBell Then
            strOutput = strOutput.ToString
        End If

        fcnPrintReceipt(strOutput)

    End Sub

    Private Sub btnSetPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPrinter.Click

        Try

            If Me.cboPrinterSelect.SelectedIndex > -1 Then
                strRcptPrinter = Me.cboPrinterSelect.SelectedValue.ToString
            Else
                strRcptPrinter = ""
            End If

            strFooter1 = Me.txtFooter1.Text
            strFooter2 = Me.txtFooter2.Text
            strHeader = Me.txtHeader.Text
            blnUsePrinter = Me.chkUsePrinter.Checked
            intLinesBefore = Me.tbLinesBefore.Value
            intLinesAfter = Me.TBLinesAfter.Value
            blnOneCCReceipt = Me.chkOneCCReceipt.Checked

            My.Settings.blnOneCCReceipt = Me.chkOneCCReceipt.Checked
            My.Settings.blnUsePrinter = Me.chkUsePrinter.Checked
            My.Settings.RcptPrinter = strRcptPrinter
            My.Settings.RcptHeader = strHeader
            My.Settings.RcptFooter1 = strFooter1
            My.Settings.RcptFooter2 = strFooter2
            My.Settings.intLinesBefore = intLinesBefore
            My.Settings.intLinesAfter = intLinesAfter
            My.Settings.Save()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSetPrinter_Click", ex)

        End Try

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub subExportSettings()

        Dim strXMLFile As String

        Try

            Using dlgDir As FolderBrowserDialog = New FolderBrowserDialog()

                dlgDir.SelectedPath = "C:\CampTrak"

                If dlgDir.ShowDialog = Windows.Forms.DialogResult.OK Then

                    strXMLFile = dlgDir.SelectedPath & "\POSUserSettings.xml"

                    File.Copy(Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath, strXMLFile, True)

                End If

            End Using

        Catch ex As Exception
            subLogErr("subExportSettings", ex)

        End Try

    End Sub

    Public Sub subSetPOSControls()
        Me.lblSQLDatabase.Visible = Me.radSQLServer.Checked
        Me.lblSQLPassword.Visible = Me.radSQLServer.Checked
        Me.lblSQLServer.Visible = Me.radSQLServer.Checked
        Me.lblSQLUsername.Visible = Me.radSQLServer.Checked

        Me.txtSQLDatabase.Visible = Me.radSQLServer.Checked
        Me.txtSQLPassword.Visible = Me.radSQLServer.Checked
        Me.txtSQLServer.Visible = Me.radSQLServer.Checked
        Me.txtSQLUsername.Visible = Me.radSQLServer.Checked
        Me.txtSQLServer.Visible = Me.radSQLServer.Checked

        Me.lblPOSConnection.Visible = Me.radMSAccess.Checked
        Me.txtPOSConnection.Visible = Me.radMSAccess.Checked
        Me.btnFindCTPOS_B.Visible = Me.radMSAccess.Checked

    End Sub

    Private Sub radMSAccess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radMSAccess.CheckedChanged
        subSetPOSControls()
    End Sub

    Private Sub radSQLServer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSQLServer.CheckedChanged
        subSetPOSControls()
    End Sub

    Private Sub btnSetConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetConnection.Click

        My.Settings.MainPath = Me.txtMainConnection.Text
        My.Settings.UseSQLServer = Me.radSQLServer.Checked
        If Me.radMSAccess.Checked Then
            My.Settings.POSPath = Me.txtPOSConnection.Text
        ElseIf Me.radSQLServer.Checked Then
            My.Settings.SQLServer = Me.txtSQLServer.Text
            My.Settings.SQLDatabase = Me.txtSQLDatabase.Text
            My.Settings.SQLUserName = Me.txtSQLUsername.Text
            My.Settings.SQLPassword = Me.txtSQLPassword.Text
        End If

        My.Settings.Save()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub cmdTestMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestMain.Click
        Dim objconn As OleDbConnection
        Dim strConn As String

        objconn = New OleDbConnection

        If (Me.txtMainConnection.Text.EndsWith("accdb")) Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Me.txtMainConnection.Text & "; User Id=admin; Password="
        Else
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Me.txtMainConnection.Text & "; User Id=admin; Password="
        End If

        objconn.ConnectionString = strConn
        Try
            objconn.Open()
            objconn.Close()
        Catch ex As Exception
            MsgBox("No connection possible")
            Exit Sub
        End Try

        MsgBox("Connection OK")
    End Sub

    Private Sub cmdTestPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestPOS.Click
        Dim strConn As String = ""
        Dim objconn As OleDbConnection

        objconn = New OleDbConnection


        If Me.radSQLServer.Checked Then
            strConn = "Provider=sqloledb;Data Source=" & Me.txtSQLServer.Text & ";Initial Catalog=" & Me.txtSQLDatabase.Text & ";User Id=" & Me.txtSQLUsername.Text & ";Password=" & Me.txtSQLPassword.Text & ";"
        ElseIf Me.radMSAccess.Checked Then

            If (Me.txtPOSConnection.Text.EndsWith("accdb")) Then
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Me.txtPOSConnection.Text & "; User Id=admin; Password="
            Else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Me.txtPOSConnection.Text & "; User Id=admin; Password="
            End If

        End If

        objconn.ConnectionString = strConn

        Try
            objconn.Open()
            objconn.Close()
        Catch ex As Exception
            MsgBox("No connection possible: " & ex.Message)
            Exit Sub
        End Try
        Me.txtConnString.Text = strConn

        MsgBox("Connection OK")
    End Sub

    Private Sub btnTestDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestDrawer.Click
        If blnUseBell Then
            fcnPrintReceipt(Chr(7))
        Else
            strDrawerPort = Me.txtDrawerPort.Text
            subOpenDrawer(True)
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If Me.txtDrawerPort.Text = "" And Not Me.chkUseBell.Checked Then
            My.Settings.blnUseDrawer = False
            blnUseDrawer = False
        Else
            My.Settings.blnUseDrawer = True
            blnUseDrawer = True
        End If

        strDrawerPort = Me.txtDrawerPort.Text
        blnUseBell = Me.chkUseBell.Checked
        My.Settings.blnUseBell = Me.chkUseBell.Checked
        My.Settings.strDrawerPort = Me.txtDrawerPort.Text
        My.Settings.Save()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub cmdSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveSettings.Click

        subSaveSettings()

        Dim strSQL As String

        My.Settings.blnCamperSort = Me.chkCamperSort.Checked()
        blnCamperSort = Me.chkCamperSort.Checked
        If IsNumeric(Me.txtTaxRate.Text) And CType(Me.txtTaxRate.Text, Double) < 1 Then
            Using conPOS As New OleDbConnection(strPOSConn)
                conPOS.Open()

                strSQL = "UPDATE tlkpTax " & _
                        "SET dblTax=" & Me.txtTaxRate.Text

                Using cmdPOS As New OleDbCommand(strSQL, conPOS)
                    cmdPOS.ExecuteNonQuery()
                End Using

                conPOS.Close()

            End Using

            My.Settings.dblTaxRate = CType(Me.txtTaxRate.Text, Double)
        Else
            MsgBox("Tax rate must be numeric and less than 1 (example: .06")
            Exit Sub
        End If

        If IsNumeric(Me.txtSpendingRefDur.Text) Then

            Using conDB As New OleDbConnection(strCTConn)

                conDB.Open()

                strSQL = "UPDATE tblCampDefaults " & _
                        "SET intSpendingRefDur=" & Me.txtSpendingRefDur.Text

                Using cmdDB As New OleDbCommand(strSQL, conDB)
                    cmdDB.ExecuteNonQuery()
                End Using

                conDB.Close()

            End Using

        Else
            MsgBox("Please enter a numeric value for spending refresh duration.")
            Exit Sub
        End If

        If IsNumeric(Me.txtStoreID.Text) Then
            My.Settings.lngStoreID = CType(Me.txtStoreID.Text, Long)
        Else
            MsgBox("Store ID must be numeric")
            Exit Sub
        End If

        If IsNumeric(Me.txtStationID.Text) Then
            My.Settings.lngWSID = CType(Me.txtStationID.Text, Long)
        Else
            MsgBox("Station ID must be numeric")
            Exit Sub
        End If

        If Me.cboCCMethod.SelectedIndex <= 0 Then
            My.Settings.lngLiveCharge = 0
        Else
            My.Settings.lngLiveCharge = CType(CType(Me.cboCCMethod.SelectedItem, clsCboItem).ID, Long)
        End If

        My.Settings.strCashLinqUName = Me.txtCashLinqUser.Text
        My.Settings.strCashLinqPW = Me.txtCashLinqPW.Text

        My.Settings.Save()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub btnFindCTMain_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCTMain_B.Click

        Dim dlgCTMain As OpenFileDialog

        Dim strFileName As String

        dlgCTMain = New OpenFileDialog

        dlgCTMain.Filter = "MSAccess Databases (*.mdb, *.accdb)|*.mdb;*.accdb|All Files|*.*"
        dlgCTMain.Title = "Find CTMain_B.mdb"

        If dlgCTMain.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFileName = dlgCTMain.FileName
        Else
            strFileName = ""
        End If

        Me.txtMainConnection.Text = strFileName

    End Sub

    Private Sub btnFindCTPOS_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCTPOS_B.Click

        Dim dlgPOS As OpenFileDialog

        Dim strFileName As String

        dlgPOS = New OpenFileDialog

        dlgPOS.Filter = "MSAccess Databases (*.mdb, *.accdb)|*.mdb;*.accdb|All Files|*.*"
        dlgPOS.Title = "Find CTPOS_B.mdb"

        If dlgPOS.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFileName = dlgPOS.FileName
        Else
            strFileName = ""
        End If

        Me.txtPOSConnection.Text = strFileName

    End Sub

    Private Sub cboCCMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCCMethod.SelectedIndexChanged

        If CType(CType(Me.cboCCMethod.SelectedItem, clsCboItem).ID, clsGlobalEnum.conLIVECHARGE) = clsGlobalEnum.conLIVECHARGE.XCharge Then
            Me.txtXChargePath.Visible = True
            Me.btnSetXChargePath.Visible = True
            Me.lblXChargePath.Visible = True
            Me.txtCashLinqUser.Visible = False
            Me.txtCashLinqPW.Visible = False
            Me.lblCashLinqUser.Visible = False
            Me.lblCashLinqPW.Visible = False
        ElseIf CType(CType(Me.cboCCMethod.SelectedItem, clsCboItem).ID, clsGlobalEnum.conLIVECHARGE) = clsGlobalEnum.conLIVECHARGE.CashLinq Then
            Me.txtXChargePath.Visible = False
            Me.btnSetXChargePath.Visible = False
            Me.lblXChargePath.Visible = False
            Me.txtCashLinqUser.Visible = True
            Me.txtCashLinqPW.Visible = True
            Me.lblCashLinqUser.Visible = True
            Me.lblCashLinqPW.Visible = True
        Else
            Me.txtXChargePath.Visible = False
            Me.btnSetXChargePath.Visible = False
            Me.lblXChargePath.Visible = False
            Me.txtCashLinqUser.Visible = False
            Me.txtCashLinqPW.Visible = False
            Me.lblCashLinqUser.Visible = False
            Me.lblCashLinqPW.Visible = False
        End If

    End Sub

    Private Sub btnSetXChargePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetXChargePath.Click

        Dim dlgXCharge As FolderBrowserDialog

        Dim strFolder As String

        dlgXCharge = New FolderBrowserDialog

        If dlgXCharge.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFolder = dlgXCharge.SelectedPath
        Else
            strFolder = ""
        End If

        Me.txtXChargePath.Text = strFolder

    End Sub

    Private Sub chkUseBell_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseBell.CheckedChanged
        Me.txtDrawerPort.Enabled = Not Me.chkUseBell.Checked
    End Sub

    Private Sub btnNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.cboPrinterSelect.SelectedIndex = -1
        strRcptPrinter = ""

    End Sub

    Private Sub chkUsePrinter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsePrinter.CheckedChanged
        Me.cboPrinterSelect.Enabled = Me.chkUsePrinter.Checked
        Me.txtHeader.Enabled = Me.chkUsePrinter.Checked
        Me.txtFooter1.Enabled = Me.chkUsePrinter.Checked
        Me.txtFooter2.Enabled = Me.chkUsePrinter.Checked
    End Sub

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim strChecked As String = ""

        Dim strSQL As String

        Try

            Select Case Me.chkAlwaysPrintReceipt.Checked
                Case True
                    strChecked = "-1"
                Case False
                    strChecked = "0"
            End Select


            My.Settings.strCraftID = CType(Me.cboInventory.SelectedItem, clsCboItem).ID
            lngCraftID = CType(Me.cboInventory.SelectedItem, clsCboItem).ID
            My.Settings.Save()

            objConn = New OleDbConnection(strCTConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "UPDATE tblCampDefaults SET " & _
                        "tblCampDefaults.strStoreName = '" & Me.txtStoreName.Text & "', " & _
                        "tblCampDefaults.strReceiptSignOff1 = '" & Me.txtRecptSignOff1.Text & "', " & _
                        "tblCampDefaults.strReceiptSignOff2 = '" & Me.txtRecptSignOff2.Text & "', " & _
                        "tblCampDefaults.blnAlwaysPrintReciept = " & strChecked


            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()



        Catch ex As Exception

            subLogErr(Me.Name & ".btnSaveClose_Click", ex)
        Finally

            objCommand = Nothing
            objConn = Nothing
            blnDirtyStoreSetup = False
            Me.tabStoreSetup.Text = "Store Setup"

        End Try

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub subLoadUsers()

        Dim cboUser As clsCboItem

        Dim strSQL As String

        Try

            Me.lstUsers.Items.Clear()

            If strPOSConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                    conDB.Open()

                    strSQL = "SELECT blnActive, " & _
                            "lngClerkID, " & _
                            "strUserName, strPassword " & _
                        "FROM tblClerks;"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drUsers As OleDbDataReader = cmdDB.ExecuteReader

                            While drUsers.Read

                                cboUser = New clsCboItem(CType(drUsers("lngClerkID"), Long), CType(drUsers("strUserName"), String))

                                Me.lstUsers.Items.Add(cboUser)

                            End While

                            drUsers.Close()

                        End Using

                    End Using

                    conDB.Close()

                End Using
                
            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".LoadEditUsers", ex, False)

        End Try

    End Sub

    Private Sub lstUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsers.Click
        blnLoading = True
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim drClerks As OleDbDataReader

        Dim cboClerk As clsCboItem

        Dim strSQL As String

        Dim lngClerkID As Long

        Try

            cboClerk = CType(Me.lstUsers.SelectedItem, clsCboItem)

            lngClerkID = CType(cboClerk.ID, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT blnActive, " & _
                    "strUserName, strPassword, strClerkFirstName, strClerkLastName, blnAdmin " & _
                "FROM tblClerks " & _
                "WHERE lngClerkID=" & lngClerkID

            objCommand.CommandText = strSQL

            drClerks = objCommand.ExecuteReader

            If drClerks.Read Then

                Me.chkNewUser.Checked = False
                Me.txtFirstName.Enabled = True
                Me.txtLastName.Enabled = True

                Me.txtUserName.Enabled = True
                Me.txtPassword.Enabled = True
                Me.chkActive.Enabled = True
                Me.chkAdmin.Enabled = True

                Me.txtUserName.Text = CType(NZ(drClerks("strUserName")), String)
                Me.txtFirstName.Text = CType(NZ(drClerks("strClerkFirstName")), String)
                Me.txtLastName.Text = CType(NZ(drClerks("strClerkLastName")), String)
                Me.txtPassword.Text = CType(NZ(drClerks("strPassword")), String)
                Me.chkActive.Checked = CType(drClerks("blnActive"), Boolean)
                Me.chkAdmin.Checked = CType(drClerks("blnAdmin"), Boolean)

            Else
                MsgBox("Error looking up user information.")
            End If

            cboClerk = CType(Me.lstUsers.SelectedItem, clsCboItem)

            lngClerkID = CType(cboClerk.ID, Long)
            Me.txtUserID.Text = lngClerkID.ToString

            drClerks.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".lstUser_DoubleClick", ex)

        End Try

        drClerks = Nothing
        objCommand = Nothing
        objConn = Nothing
        blnLoading = False
    End Sub

    Private Sub btnSaveClerks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClerks.Click
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        
        Dim strSQL As String = ""

        Dim lngClerkID As Long
        Dim strActiveChecked As String = ""
        Dim strAdminChecked As String = ""

        Try
            Select Case Me.chkActive.Checked
                Case True
                    strActiveChecked = "-1"
                Case False
                    strActiveChecked = "0"
            End Select

            Select Case Me.chkAdmin.Checked
                Case True
                    strAdminChecked = "-1"
                Case False
                    strAdminChecked = "0"
            End Select

            lngClerkID = CType(Me.txtUserID.Text, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            Select Case Me.chkNewUser.Checked
                Case True
                    strSQL = "INSERT INTO tblClerks " & _
                            "( blnReset, blnAdmin, blnActive, blnClerk, " & _
                                "strClerkFirstName, strClerkLastName, strUserName, strPassword ) " & _
                            "SELECT 0, " & strAdminChecked & " AS Expr5, " & strActiveChecked & " AS Expr6, -1, " & _
                                "'" & Me.txtFirstName.Text & "' AS Expr1, '" & Me.txtLastName.Text & "' AS Expr2, '" & Me.txtUserName.Text & "' AS Expr3, '" & Me.txtPassword.Text & "' AS Expr4"

                Case False
                    strSQL = "UPDATE tblClerks " & _
                                        "SET blnActive=" & strActiveChecked & ", " & _
                                            "blnAdmin=" & strAdminChecked & ", " & _
                                            "strPassword='" & Me.txtPassword.Text & "', " & _
                                            "strUserName='" & Me.txtUserName.Text & "', " & _
                                            "strClerkFirstName='" & Me.txtFirstName.Text & "', " & _
                                            "strClerkLastName='" & Me.txtLastName.Text & "' " & _
                                        "WHERE lngClerkID=" & lngClerkID

            End Select

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSave_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing
        blnDirtyStoreSetup = False

        subClerksDirty(False)
        subLoadUsers()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub chkAdmin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdmin.CheckedChanged, txtUserName.TextChanged, txtLastName.TextChanged, txtFirstName.TextChanged, txtPassword.TextChanged, chkActive.CheckedChanged, chkAdmin.CheckedChanged
        subClerksDirty(True)
    End Sub

    Private Sub subClerksDirty(ByVal blnDirty As Boolean)
        Select Case blnDirty
            Case True
                If Not blnLoading Then
                    blnDirtyClerks = True
                    Me.tabClerks.Text = "Clerks *"
                    Me.btnNewClerk.Enabled = False
                    Me.btnDeleteClerk.Enabled = False
                    Me.lstUsers.Enabled = False
                End If
            Case False
                blnDirtyClerks = False
                Me.tabClerks.Text = "Clerks"
                Me.btnNewClerk.Enabled = True
                Me.btnDeleteClerk.Enabled = True
                Me.lstUsers.Enabled = True
        End Select

    End Sub

    Private Sub subStoresDirty(ByVal blnDirty As Boolean)
        Select Case blnDirty
            Case True
                If Not blnLoading Then
                    blnDirtyStores = True
                    Me.tabStores.Text = "Stores *"
                    Me.btnNewStore.Enabled = False
                    Me.btnDeleteStore.Enabled = False
                    Me.lstStores.Enabled = False
                End If
            Case False
                blnDirtyStores = False
                Me.tabStores.Text = "Stores"
                Me.btnNewStore.Enabled = True
                Me.btnDeleteStore.Enabled = True
                Me.lstStores.Enabled = True
        End Select

    End Sub

    Private Sub subDepartmentDirty(ByVal blnDirty As Boolean)
        Select Case blnDirty
            Case True
                If Not blnLoading Then
                    blnDirtyDepartments = True
                    Me.tabDepartments.Text = "Departments *"
                    Me.btnNewDept.Enabled = False
                    Me.btnDeleteDept.Enabled = True
                    Me.lstDepartments.Enabled = False
                End If
            Case False
                blnDirtyDepartments = False
                Me.tabDepartments.Text = "Departments"
                Me.btnNewDept.Enabled = True
                Me.btnDeleteDept.Enabled = True
                Me.lstDepartments.Enabled = True
        End Select

    End Sub

    Private Sub subStoreSetupDirty()
        If Not blnLoading Then
            blnDirtyStoreSetup = True
            Me.tabStoreSetup.Text = "Store Setup *"
        End If
    End Sub

    Private Sub txtStoreName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoreName.TextChanged, txtRecptSignOff1.TextChanged, txtRecptSignOff2.TextChanged, chkAlwaysPrintReceipt.CheckedChanged
        subStoreSetupDirty()
    End Sub

    Private Sub btnNewClerk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewClerk.Click
        Me.chkNewUser.Checked = True
        subClerksDirty(False)

        Me.txtUserID.Text = "0"
        Me.txtUserName.Text = ""
        Me.txtPassword.Text = ""
        Me.txtFirstName.Text = ""
        Me.txtLastName.Text = ""


        Me.txtFirstName.Enabled = True
        Me.txtLastName.Enabled = True

        Me.txtUserName.Enabled = True
        Me.txtPassword.Enabled = True
        Me.chkActive.Enabled = True
        Me.chkAdmin.Enabled = True

        Me.chkActive.Checked = True
        Me.chkAdmin.Checked = False

        Me.txtUserName.Focus()
    End Sub

    Private Sub btnDeleteClerk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteClerk.Click

        Dim strMsg As String

        strMsg = "Are you sure you wish to delete this clerk?  Marking inactive is a better option if the clerk has any past sales in the system."

        If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String = ""

        Dim lngClerkID As Long
        
        Try
        
            lngClerkID = CType(Me.txtUserID.Text, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "DELETE FROM tblClerks " & _
                    "WHERE tblClerks.lngClerkID=" & lngClerkID

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnDelete_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing
        blnDirtyStoreSetup = False

        Me.txtUserName.Text = ""
        Me.txtFirstName.Text = ""
        Me.txtLastName.Text = ""
        Me.txtPassword.Text = ""
        Me.chkActive.Checked = False
        Me.chkAdmin.Checked = False

        subClerksDirty(False)
        subLoadUsers()

    End Sub

    Private Sub subLoadStores()

        Dim cboStores As clsCboItem

        Dim strSQL As String

        Try

            Me.lstStores.Items.Clear()

            If strPOSConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                    conDB.Open()

                    strSQL = "SELECT strStoreName, " & _
                            "lngStoreID " & _
                        "FROM tblStores;"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drStores As OleDbDataReader = cmdDB.ExecuteReader()

                            While drStores.Read

                                cboStores = New clsCboItem(CType(drStores("lngStoreID"), Long), CType(NZ(drStores("strStoreName")), String))

                                Me.lstStores.Items.Add(cboStores)

                            End While

                            drStores.Close()

                        End Using

                    End Using

                    conDB.Close()

                End Using
                
            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".LoadEditStores", ex, False)

        End Try

    End Sub

    Private Sub lstStores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstStores.Click
        blnLoading = True
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim dr As OleDbDataReader

        Dim cboStores As clsCboItem

        Dim strSQL As String

        Dim lngStoreID As Long

        Try

            cboStores = CType(Me.lstStores.SelectedItem, clsCboItem)

            lngStoreID = CType(cboStores.ID, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT " & _
                    "strStoreName, lngSiteID " & _
                "FROM tblStores " & _
                "WHERE lngStoreID=" & lngStoreID

            objCommand.CommandText = strSQL

            dr = objCommand.ExecuteReader

            If dr.Read Then

                Me.chkNewStore.Checked = False
                Me.txtStoreNameEdit.Enabled = True
                Me.cboSite.Enabled = True
                Me.txtStoreNameEdit.Text = CType(NZ(dr("strStoreName")), String)
                subSetSelectedIndex(Me.cboSite, CType(dr("lngSiteID").ToString, Long))
            Else
                MsgBox("Error looking up user information.")
            End If

            cboStores = CType(Me.lstStores.SelectedItem, clsCboItem)

            lngStoreID = CType(cboStores.ID, Long)
            Me.txtStoreEditID.Text = lngStoreID.ToString


            dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

            'set site selected


        Catch ex As Exception

            subLogErr(Me.Name & ".lstStore_Click", ex)

        End Try

        dr = Nothing
        objCommand = Nothing
        objConn = Nothing
        blnLoading = False


    End Sub

    Private Sub btnNewStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewStore.Click
        Me.chkNewStore.Checked = True

        subStoresDirty(False)
        Me.txtStoreNameEdit.Text = ""
        Me.cboSite.SelectedItem = 0
        Me.txtStoreNameEdit.Enabled = True
        Me.cboSite.Enabled = True
        Me.chkNewStore.Checked = True
        Me.txtStoreEditID.Text = "0"
        Me.txtStoreNameEdit.Focus()

    End Sub

    Private Sub btnDeleteStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteStore.Click
        If MsgBox("Are you sure you wish to delete this store?  Do not delete if there are any past sales in the system.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String = ""

        Dim lngStoreID As Long

        Try

            lngStoreID = CType(Me.txtStoreEditID.Text, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "DELETE tblStores.lngStoreID FROM(tblStores) WHERE (((tblStores.lngStoreID)=" & lngStoreID & "));"

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnDelete_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing
        blnDirtyStoreSetup = False

        Me.txtStoreNameEdit.Text = ""
        Me.cboSite.SelectedIndex = -1
        Me.txtStoreEditID.Text = "0"

        subStoresDirty(False)
        subLoadStores()
    End Sub

    Private Sub btnSaveStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveStore.Click
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand


        Dim strSQL As String = ""

        Dim lngStoreID As Long
        Dim lngSiteID As Long

        Try

            lngStoreID = CType(Me.txtStoreEditID.Text, Long)
            lngSiteID = 0

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            Select Case Me.chkNewStore.Checked
                Case True
                    strSQL = "INSERT INTO tblStores ( lngSiteID, strStoreName ) SELECT " & CType(CType(Me.cboSite.SelectedItem, clsCboItem).ID, Long) & " AS Expr2, '" & Me.txtStoreNameEdit.Text & "' AS Expr3 FROM tblStores;"

                Case False
                    strSQL = "UPDATE tblStores SET tblStores.lngSiteID = " & CType(CType(Me.cboSite.SelectedItem, clsCboItem).ID, Long) & _
                    ", tblStores.strStoreName = '" & Me.txtStoreNameEdit.Text & "' WHERE (tblStores.lngStoreID)=" & lngStoreID


            End Select

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSaveStore_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing

        Me.txtStoreNameEdit.Enabled = False
        Me.cboSite.Enabled = False

        blnDirtyStores = False

        subStoresDirty(False)
        subLoadStores()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

    Private Sub subLoadSites()

        Dim strSQL As String

        Try

            If strCTConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strCTConn)

                    conDB.Open()

                    strSQL = "SELECT lngSiteID, " & _
                                "strSiteName " & _
                            "FROM tblSites " & _
                            "ORDER BY strSiteName;"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drSites As OleDbDataReader = cmdDB.ExecuteReader()

                            While drSites.Read

                                Me.cboSite.Items.Add(New clsCboItem(CType(drSites("lngSiteID"), Long), CType(drSites("strSiteName"), String)))

                            End While

                            drSites.Close()

                        End Using

                    End Using

                    conDB.Close()

                End Using

            End If
            
        Catch ex As Exception

            subLogErr(Me.Name & ".subLoadSites", ex, False)

        End Try

    End Sub

    Private Sub txtStoreNameEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStoreNameEdit.TextChanged, cboSite.SelectedIndexChanged
        subStoresDirty(True)
    End Sub

    Private Sub subLoadDepartments()

        Dim cboDepartments As clsCboItem

        Dim strSQL As String

        Try

            Me.lstDepartments.Items.Clear()

            If strPOSConn <> "" Then

                Using conDB As OleDbConnection = New OleDbConnection(strPOSConn)

                    conDB.Open()

                    strSQL = "SELECT strDepartmentName, " & _
                            "lngDeptID " & _
                        "FROM tblDepartments order by strdepartmentname;"

                    Using cmdDB As OleDbCommand = New OleDbCommand(strSQL, conDB)

                        Using drDept As OleDbDataReader = cmdDB.ExecuteReader()

                            While drDept.Read

                                cboDepartments = New clsCboItem(CType(drDept("lngDeptID"), Long), CType(drDept("strDepartmentName"), String))

                                Me.lstDepartments.Items.Add(cboDepartments)

                            End While

                            drDept.Close()

                        End Using

                    End Using

                    conDB.Close()

                End Using

            End If

        Catch ex As Exception

            subLogErr(Me.Name & ".LoadDepartments", ex, False)

        End Try

    End Sub

    Private Sub lstDepartments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDepartments.Click
        blnLoading = True
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand
        Dim dr As OleDbDataReader

        Dim cboDepts As clsCboItem

        Dim strSQL As String

        Dim lngDeptID As Long

        Try

            cboDepts = CType(Me.lstDepartments.SelectedItem, clsCboItem)

            lngDeptID = CType(cboDepts.ID, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "SELECT " & _
                    "strDepartmentName " & _
                "FROM tblDepartments " & _
                "WHERE lngDeptID=" & lngDeptID

            objCommand.CommandText = strSQL

            dr = objCommand.ExecuteReader

            If dr.Read Then

                Me.txtDepartment.Text = CType(dr("strDepartmentName"), String)

            Else
                MsgBox("Error looking up department information.")
            End If

            Me.txtDepartmentID.Text = lngDeptID.ToString

            dr.Close()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()



        Catch ex As Exception

            subLogErr(Me.Name & ".lstDepartment_Click", ex)

        End Try

        dr = Nothing
        objCommand = Nothing
        objConn = Nothing

        Me.txtDepartment.Enabled = True
        Me.chkNewDepartment.Checked = False


        blnLoading = False
        subDepartmentDirty(True)

    End Sub
    
    Private Sub btnNewDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDept.Click
        Me.chkNewDepartment.Checked = True

        subDepartmentDirty(False)
        Me.txtDepartment.Text = ""
        Me.txtDepartment.Enabled = True
        Me.chkNewDepartment.Checked = True
        Me.txtDepartmentID.Text = "0"
        Me.txtDepartment.Focus()

    End Sub

    Private Sub btnDeleteDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDept.Click
        If MsgBox("Are you sure you wish to delete this department?  Do not delete if there are any past sales in the system.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand

        Dim strSQL As String = ""

        Dim lngDeptID As Long

        Try

            lngDeptID = CType(Me.txtDepartmentID.Text, Long)

            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            strSQL = "DELETE tblDepartments.lngDeptID FROM(tblDepartments) WHERE (((lngDeptID)=" & lngDeptID & "));"

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnDeleteDept_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing
        blnDirtyDepartments = False

        Me.txtDepartment.Text = ""
        subDepartmentDirty(False)
        subLoadDepartments()
    End Sub

    Private Sub btnSaveDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDepartment.Click
        Dim objConn As OleDbConnection
        Dim objCommand As OleDbCommand


        Dim strSQL As String = ""
        Dim lngDeptID As Long

        Try

            lngDeptID = CType(Me.txtDepartmentID.Text, Long)
        
            objConn = New OleDbConnection(strPOSConn)

            objConn.Open()

            objCommand = New OleDbCommand

            objCommand.Connection = objConn

            Select Case Me.chkNewDepartment.Checked
                Case True
                    strSQL = "INSERT INTO tblDepartments ( strDepartmentName ) SELECT '" & Me.txtDepartment.Text & "';"

                Case False
                    strSQL = "UPDATE tblDepartments SET " & _
                    "tblDepartments.strDepartmentName = '" & Me.txtDepartment.Text & "' WHERE (tblDepartments.lngDeptID)=" & lngDeptID

            End Select

            objCommand.CommandText = strSQL

            objCommand.ExecuteNonQuery()

            objConn.Close()

            objCommand.Dispose()
            objConn.Dispose()

        Catch ex As Exception

            subLogErr(Me.Name & ".btnSaveDepartment_Click", ex)

        End Try

        objCommand = Nothing
        objConn = Nothing


        Me.txtDepartment.Enabled = False

        blnDirtyDepartments = False

        subDepartmentDirty(False)
        subLoadDepartments()

        If MessageBox.Show("Your settings have been saved." & vbNewLine & vbNewLine & "Would you like to export your settings to a file as well?" & vbNewLine & vbNewLine & "This allows you to move the file to other workstations and import the settings there." & vbNewLine & "It also allows you to maintain workstation-level settings between updates to the CampTrak store software.", "Export Settings?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then subExportSettings()

    End Sub

 
    Private Sub btnTestLiveCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestLiveCharge.Click

        Dim strAuth As String = ""
        Dim strPNRef As String = ""

        Dim dblAmount = CType(Me.txtTestAmount.Text, Double)

        Dim blnChargeRes As Boolean = False

        Select Case CType(My.Settings.lngLiveCharge, clsGlobalEnum.conLIVECHARGE)
            Case conLIVECHARGE.None
                blnChargeRes = True
            Case conLIVECHARGE.XCharge
                blnChargeRes = fcnLiveXCharge(objSystemSetup.Handle, "4003000123456781", "0809", "", "", "123", dblAmount, 1, "Sale", "", "", "", 0)

            Case conLIVECHARGE.CashLinq
                blnChargeRes = fcnLiveCashLinq("4003000123456781", "0809", "John Doe", "", 0, "123", dblAmount, 1, strAuth, "", strPNRef, "")

        End Select

        If blnChargeRes Then
            MsgBox("Test transaction processed successfully: " & strAuth)
        Else
            MsgBox("There was an error processing the test transaction.")
        End If

    End Sub

    Private Sub btnImportSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportSettings.Click

        If fcnImportSettings() Then

            MessageBox.Show("Please restart the CampTrak Store software to update settings.")

            Application.Exit()

        End If

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        subExportSettings()

    End Sub

End Class