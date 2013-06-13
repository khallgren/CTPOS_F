<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStoreSummaryPreview
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
        Me.rvwStoreSummary = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dsStoreSummary = New System.Data.DataSet
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        CType(Me.dsStoreSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwStoreSummary
        '
        Me.rvwStoreSummary.ActiveViewIndex = -1
        Me.rvwStoreSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwStoreSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwStoreSummary.Location = New System.Drawing.Point(0, 0)
        Me.rvwStoreSummary.Name = "rvwStoreSummary"
        Me.rvwStoreSummary.SelectionFormula = ""
        Me.rvwStoreSummary.Size = New System.Drawing.Size(780, 516)
        Me.rvwStoreSummary.TabIndex = 0
        Me.rvwStoreSummary.ViewTimeSelectionFormula = ""
        '
        'dsStoreSummary
        '
        Me.dsStoreSummary.DataSetName = "qrptStoreSummary"
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'frmStoreSummaryPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 516)
        Me.Controls.Add(Me.rvwStoreSummary)
        Me.Name = "frmStoreSummaryPreview"
        Me.Text = "Store Summary Preview"
        CType(Me.dsStoreSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwStoreSummary As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dsStoreSummary As System.Data.DataSet
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
End Class
