<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvCodeSheetPreview
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
        Me.rvwInvCodeSheet = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsInvCodeSheet = New System.Data.DataSet
        CType(Me.dsInvCodeSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwInvCodeSheet
        '
        Me.rvwInvCodeSheet.ActiveViewIndex = -1
        Me.rvwInvCodeSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwInvCodeSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwInvCodeSheet.Location = New System.Drawing.Point(0, 0)
        Me.rvwInvCodeSheet.Name = "rvwInvCodeSheet"
        Me.rvwInvCodeSheet.SelectionFormula = ""
        Me.rvwInvCodeSheet.Size = New System.Drawing.Size(662, 514)
        Me.rvwInvCodeSheet.TabIndex = 0
        Me.rvwInvCodeSheet.ViewTimeSelectionFormula = ""
        '
        'cmdPOS
        '
        Me.cmdPOS.Connection = Me.conPOS
        '
        'daPOS
        '
        Me.daPOS.SelectCommand = Me.cmdPOS
        '
        'dsInvCodeSheet
        '
        Me.dsInvCodeSheet.DataSetName = "qrptInvCodeSheet"
        '
        'frmInvCodeSheetPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 514)
        Me.Controls.Add(Me.rvwInvCodeSheet)
        Me.Name = "frmInvCodeSheetPreview"
        Me.Text = "Inventory Code Sheet Preview"
        CType(Me.dsInvCodeSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwInvCodeSheet As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsInvCodeSheet As System.Data.DataSet
End Class
