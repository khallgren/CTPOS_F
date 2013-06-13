Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.OleDb


Public Class frmCCSalesPreview

    Private objCCSales As rptCCSales

    Private strCaption As String

    Private dteStart As Date
    Private dteEnd As Date

    Public Sub New(ByVal _dteStart As Date, ByVal _dteEnd As Date, ByVal _strCaption As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dteStart = _dteStart
        dteEnd = _dteEnd

        strCaption = _strCaption

    End Sub

    Private Sub subConfigureCrystalReports()

        Dim strSQL As String

        'set connection for data adapters
        Me.conPOS.ConnectionString = strPOSConn

        strSQL = "SELECT tblSales.lngSaleID, tblSales.lngStoreID, tblSales.lngPaymentTypeID, " & _
                    "tblSales.curTotalCharge, " & _
                    "tblSales.dteSaleDate, " & _
                    "tblSales.strAuthNumber, tblStores.strStoreName " & _
                "FROM tblSales " & _
                    "LEFT JOIN tblStores ON tblSales.lngStoreID = tblStores.lngStoreID " & _
                "WHERE tblSales.dteSaleDate > CONVERT(DATETIME, '" & dteStart & "', 102) AND " & _
                    "tblSales.dteSaleDate < CONVERT(DATETIME, '" & dteEnd & "', 102)"

        'set select command of adapter for main report
        daCCSales.SelectCommand.CommandText = strSQL

        Me.daCCSales.Fill(Me.dsCCSales, "qrptCCSales")

        objCCSales = New rptCCSales

        objCCSales.SetDataSource(Me.dsCCSales)

        CType(objCCSales.ReportDefinition.ReportObjects("txtCCSalesTitle"), CrystalDecisions.CrystalReports.Engine.TextObject).Text = strCaption

        rvwCCSales.ReportSource = objCCSales

        subSetLogon()

    End Sub

    Private Sub subSetLogon()

        Dim crtableLogonInfo As TableLogOnInfo = New TableLogOnInfo()
        Dim crConnectionInfo As ConnectionInfo = New ConnectionInfo()
        Dim CrTables As Tables

        'Declare ReportDocument object and load your existing report
        'Make sure that you give the correct path for the document else it will give exception
        Dim crReportDocument As ReportDocument

        crReportDocument = rvwCCSales.ReportSource

        CrTables = crReportDocument.Database.Tables

        Dim crTable As CrystalDecisions.CrystalReports.Engine.Table

        With crConnectionInfo

            .ServerName = My.Settings.SQLServer ' "KINGTUBBY\SQLEXPRESS"
            .DatabaseName = My.Settings.SQLDatabase ' "CTPOS_B"
            .UserID = My.Settings.SQLUserName ' "ctposu"
            .Password = My.Settings.SQLPassword ' "ctposp"

        End With

        For Each crTable In CrTables

            crtableLogonInfo = crTable.LogOnInfo

            crtableLogonInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)

        Next

        crReportDocument.ReportOptions.EnableSaveDataWithReport = False

        'Bind the ReportDocument to ReportViewer Object
        rvwCCSales.ReportSource = crReportDocument

    End Sub

    Private Sub frmZOutPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subConfigureCrystalReports()

    End Sub

End Class