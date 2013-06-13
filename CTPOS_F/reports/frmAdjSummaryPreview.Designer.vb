<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjSummaryPreview
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
        Me.rvwAdjSummary = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsAdjSummary = New System.Data.DataSet
        CType(Me.dsAdjSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwAdjSummary
        '
        Me.rvwAdjSummary.ActiveViewIndex = -1
        Me.rvwAdjSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwAdjSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwAdjSummary.Location = New System.Drawing.Point(0, 0)
        Me.rvwAdjSummary.Name = "rvwAdjSummary"
        Me.rvwAdjSummary.SelectionFormula = ""
        Me.rvwAdjSummary.Size = New System.Drawing.Size(735, 589)
        Me.rvwAdjSummary.TabIndex = 0
        Me.rvwAdjSummary.ViewTimeSelectionFormula = ""
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'dsAdjSummary
        '
        Me.dsAdjSummary.DataSetName = "qrptAdjSummary"
        '
        'frmAdjSummaryPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 589)
        Me.Controls.Add(Me.rvwAdjSummary)
        Me.Name = "frmAdjSummaryPreview"
        Me.Text = "Adjustment Summary Preview"
        CType(Me.dsAdjSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwAdjSummary As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsAdjSummary As System.Data.DataSet
End Class
