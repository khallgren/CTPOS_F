<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvSnapshotPreview
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
        Me.rvwInvSnapshot = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsInvSnapshot = New System.Data.DataSet
        CType(Me.dsInvSnapshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwInvSnapshot
        '
        Me.rvwInvSnapshot.ActiveViewIndex = -1
        Me.rvwInvSnapshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwInvSnapshot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwInvSnapshot.Location = New System.Drawing.Point(0, 0)
        Me.rvwInvSnapshot.Name = "rvwInvSnapshot"
        Me.rvwInvSnapshot.SelectionFormula = ""
        Me.rvwInvSnapshot.Size = New System.Drawing.Size(856, 655)
        Me.rvwInvSnapshot.TabIndex = 0
        Me.rvwInvSnapshot.ViewTimeSelectionFormula = ""
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'dsInvSnapshot
        '
        Me.dsInvSnapshot.DataSetName = "qrptInvSnapshot"
        '
        'frmInvSnapshotPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 655)
        Me.Controls.Add(Me.rvwInvSnapshot)
        Me.Name = "frmInvSnapshotPreview"
        Me.Text = "Inventory Snapshot Preview"
        CType(Me.dsInvSnapshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwInvSnapshot As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsInvSnapshot As System.Data.DataSet
End Class
