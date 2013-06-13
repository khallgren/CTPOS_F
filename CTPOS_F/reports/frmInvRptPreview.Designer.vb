<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvRptPreview
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
        Me.rvwInvRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsInventory = New System.Data.DataSet
        CType(Me.dsInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwInvRpt
        '
        Me.rvwInvRpt.ActiveViewIndex = -1
        Me.rvwInvRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwInvRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwInvRpt.Location = New System.Drawing.Point(0, 0)
        Me.rvwInvRpt.Name = "rvwInvRpt"
        Me.rvwInvRpt.SelectionFormula = ""
        Me.rvwInvRpt.Size = New System.Drawing.Size(802, 593)
        Me.rvwInvRpt.TabIndex = 0
        Me.rvwInvRpt.ViewTimeSelectionFormula = ""
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'dsInventory
        '
        Me.dsInventory.DataSetName = "dsInventory"
        '
        'frmInvRptPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 593)
        Me.Controls.Add(Me.rvwInvRpt)
        Me.Name = "frmInvRptPreview"
        Me.Text = "Inventory Report Print Preview"
        CType(Me.dsInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwInvRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsInventory As System.Data.DataSet
End Class
