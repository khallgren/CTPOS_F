<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeptXFerRptPreview
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
        Me.rvwDeptXFer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rvwDeptXFer
        '
        Me.rvwDeptXFer.ActiveViewIndex = -1
        Me.rvwDeptXFer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwDeptXFer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwDeptXFer.Location = New System.Drawing.Point(0, 0)
        Me.rvwDeptXFer.Name = "rvwDeptXFer"
        Me.rvwDeptXFer.SelectionFormula = ""
        Me.rvwDeptXFer.Size = New System.Drawing.Size(678, 340)
        Me.rvwDeptXFer.TabIndex = 0
        Me.rvwDeptXFer.ViewTimeSelectionFormula = ""
        '
        'frmDeptXFerRptPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 340)
        Me.Controls.Add(Me.rvwDeptXFer)
        Me.Name = "frmDeptXFerRptPreview"
        Me.Text = "Department Transfer Report Preview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvwDeptXFer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
