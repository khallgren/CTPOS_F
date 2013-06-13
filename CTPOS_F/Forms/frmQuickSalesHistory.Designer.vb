<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickSalesHistory
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
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.mnuQuickPrint = New System.Windows.Forms.MenuStrip
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuickPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDisplay
        '
        Me.txtDisplay.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisplay.Location = New System.Drawing.Point(12, 27)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDisplay.Size = New System.Drawing.Size(408, 356)
        Me.txtDisplay.TabIndex = 0
        '
        'mnuQuickPrint
        '
        Me.mnuQuickPrint.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrint})
        Me.mnuQuickPrint.Location = New System.Drawing.Point(0, 0)
        Me.mnuQuickPrint.Name = "mnuQuickPrint"
        Me.mnuQuickPrint.Size = New System.Drawing.Size(432, 24)
        Me.mnuQuickPrint.TabIndex = 1
        Me.mnuQuickPrint.Text = "MenuStrip1"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(70, 20)
        Me.mnuPrint.Text = "Quick Print"
        '
        'frmQuickSalesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 411)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.mnuQuickPrint)
        Me.MainMenuStrip = Me.mnuQuickPrint
        Me.Name = "frmQuickSalesHistory"
        Me.Text = "Quick Sales History"
        Me.mnuQuickPrint.ResumeLayout(False)
        Me.mnuQuickPrint.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents mnuQuickPrint As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
End Class
