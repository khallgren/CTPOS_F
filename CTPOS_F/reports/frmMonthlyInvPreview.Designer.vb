<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonthlyInvPreview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rvwRpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.conPOS = New System.Data.OleDb.OleDbConnection
        Me.cmdPOS = New System.Data.OleDb.OleDbCommand
        Me.daPOS = New System.Data.OleDb.OleDbDataAdapter
        Me.dsPOS = New System.Data.DataSet
        CType(Me.dsPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvwRpt
        '
        Me.rvwRpt.ActiveViewIndex = -1
        Me.rvwRpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwRpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwRpt.Location = New System.Drawing.Point(0, 0)
        Me.rvwRpt.Name = "rvwRpt"
        Me.rvwRpt.SelectionFormula = ""
        Me.rvwRpt.Size = New System.Drawing.Size(688, 345)
        Me.rvwRpt.TabIndex = 0
        Me.rvwRpt.ViewTimeSelectionFormula = ""
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
        Me.dsPOS.DataSetName = "qrptMonthlyInv"
        '
        'frmMonthlyInvPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 345)
        Me.Controls.Add(Me.rvwRpt)
        Me.Name = "frmMonthlyInvPreview"
        Me.Text = "Monthly Inventory Report Preview"
        CType(Me.dsPOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwRpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents conPOS As System.Data.OleDb.OleDbConnection
    Friend WithEvents cmdPOS As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPOS As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dsPOS As System.Data.DataSet
End Class
