<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetSalesRptPreview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rvwDetailedSales = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsPOS = New System.Data.DataSet
        CType(Me.dsPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwDetailedSales
        '
        Me.rvwDetailedSales.ActiveViewIndex = -1
        Me.rvwDetailedSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwDetailedSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwDetailedSales.Location = New System.Drawing.Point(0, 0)
        Me.rvwDetailedSales.Name = "rvwDetailedSales"
        Me.rvwDetailedSales.SelectionFormula = ""
        Me.rvwDetailedSales.Size = New System.Drawing.Size(725, 577)
        Me.rvwDetailedSales.TabIndex = 0
        Me.rvwDetailedSales.ViewTimeSelectionFormula = ""
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'dsPOS
        '
        Me.dsPOS.DataSetName = "qrptDetSales"
        '
        'frmDetSalesRptPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 577)
        Me.Controls.Add(Me.rvwDetailedSales)
        Me.Name = "frmDetSalesRptPreview"
        Me.Text = "Detailed Sales Report"
        CType(Me.dsPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwDetailedSales As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsPOS As System.Data.DataSet
End Class
