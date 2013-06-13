<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCraftBalanceRptPreview
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
        Me.rvwReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rvwReport
        '
        Me.rvwReport.ActiveViewIndex = -1
        Me.rvwReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwReport.Location = New System.Drawing.Point(0, 0)
        Me.rvwReport.Name = "rvwReport"
        Me.rvwReport.SelectionFormula = ""
        Me.rvwReport.Size = New System.Drawing.Size(669, 374)
        Me.rvwReport.TabIndex = 0
        Me.rvwReport.ViewTimeSelectionFormula = ""
        '
        'frmCraftBalanceRptPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 374)
        Me.Controls.Add(Me.rvwReport)
        Me.Name = "frmCraftBalanceRptPreview"
        Me.Text = "Craft Balance Report Preview"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
