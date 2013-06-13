<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZOutSetup
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
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.fraWS = New System.Windows.Forms.GroupBox
        Me.radCurrentWS = New System.Windows.Forms.RadioButton
        Me.radAllWS = New System.Windows.Forms.RadioButton
        Me.fraZDOut = New System.Windows.Forms.GroupBox
        Me.radDateRange = New System.Windows.Forms.RadioButton
        Me.radPrevZDOut = New System.Windows.Forms.RadioButton
        Me.radNotZDOut = New System.Windows.Forms.RadioButton
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboZdOut = New System.Windows.Forms.ComboBox
        Me.fraWS.SuspendLayout()
        Me.fraZDOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(205, 12)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 0
        Me.btnPreview.Text = "Pre&view"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(205, 41)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'fraWS
        '
        Me.fraWS.Controls.Add(Me.radCurrentWS)
        Me.fraWS.Controls.Add(Me.radAllWS)
        Me.fraWS.Location = New System.Drawing.Point(12, 12)
        Me.fraWS.Name = "fraWS"
        Me.fraWS.Size = New System.Drawing.Size(151, 74)
        Me.fraWS.TabIndex = 2
        Me.fraWS.TabStop = False
        '
        'radCurrentWS
        '
        Me.radCurrentWS.AutoSize = True
        Me.radCurrentWS.Checked = True
        Me.radCurrentWS.Location = New System.Drawing.Point(6, 42)
        Me.radCurrentWS.Name = "radCurrentWS"
        Me.radCurrentWS.Size = New System.Drawing.Size(119, 17)
        Me.radCurrentWS.TabIndex = 1
        Me.radCurrentWS.TabStop = True
        Me.radCurrentWS.Text = "Current Workstation"
        Me.radCurrentWS.UseVisualStyleBackColor = True
        '
        'radAllWS
        '
        Me.radAllWS.AutoSize = True
        Me.radAllWS.Location = New System.Drawing.Point(6, 19)
        Me.radAllWS.Name = "radAllWS"
        Me.radAllWS.Size = New System.Drawing.Size(101, 17)
        Me.radAllWS.TabIndex = 0
        Me.radAllWS.Text = "All Workstations"
        Me.radAllWS.UseVisualStyleBackColor = True
        '
        'fraZDOut
        '
        Me.fraZDOut.Controls.Add(Me.radDateRange)
        Me.fraZDOut.Controls.Add(Me.radPrevZDOut)
        Me.fraZDOut.Controls.Add(Me.radNotZDOut)
        Me.fraZDOut.Location = New System.Drawing.Point(12, 92)
        Me.fraZDOut.Name = "fraZDOut"
        Me.fraZDOut.Size = New System.Drawing.Size(151, 100)
        Me.fraZDOut.TabIndex = 3
        Me.fraZDOut.TabStop = False
        '
        'radDateRange
        '
        Me.radDateRange.AutoSize = True
        Me.radDateRange.Location = New System.Drawing.Point(6, 65)
        Me.radDateRange.Name = "radDateRange"
        Me.radDateRange.Size = New System.Drawing.Size(83, 17)
        Me.radDateRange.TabIndex = 2
        Me.radDateRange.Text = "Date Range"
        Me.radDateRange.UseVisualStyleBackColor = True
        '
        'radPrevZDOut
        '
        Me.radPrevZDOut.AutoSize = True
        Me.radPrevZDOut.Location = New System.Drawing.Point(6, 42)
        Me.radPrevZDOut.Name = "radPrevZDOut"
        Me.radPrevZDOut.Size = New System.Drawing.Size(111, 17)
        Me.radPrevZDOut.TabIndex = 1
        Me.radPrevZDOut.Text = "Previously Z'd Out"
        Me.radPrevZDOut.UseVisualStyleBackColor = True
        '
        'radNotZDOut
        '
        Me.radNotZDOut.AutoSize = True
        Me.radNotZDOut.Checked = True
        Me.radNotZDOut.Location = New System.Drawing.Point(6, 19)
        Me.radNotZDOut.Name = "radNotZDOut"
        Me.radNotZDOut.Size = New System.Drawing.Size(126, 17)
        Me.radNotZDOut.TabIndex = 0
        Me.radNotZDOut.TabStop = True
        Me.radNotZDOut.Text = "Waiting to be Z'd Out"
        Me.radNotZDOut.UseVisualStyleBackColor = True
        '
        'txtStart
        '
        Me.txtStart.Enabled = False
        Me.txtStart.Location = New System.Drawing.Point(12, 198)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(100, 20)
        Me.txtStart.TabIndex = 4
        '
        'txtEnd
        '
        Me.txtEnd.Enabled = False
        Me.txtEnd.Location = New System.Drawing.Point(140, 198)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(100, 20)
        Me.txtEnd.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "to"
        '
        'cboZdOut
        '
        Me.cboZdOut.Enabled = False
        Me.cboZdOut.FormattingEnabled = True
        Me.cboZdOut.Location = New System.Drawing.Point(169, 133)
        Me.cboZdOut.Name = "cboZdOut"
        Me.cboZdOut.Size = New System.Drawing.Size(121, 21)
        Me.cboZdOut.TabIndex = 7
        '
        'frmZOutSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.cboZdOut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.fraZDOut)
        Me.Controls.Add(Me.fraWS)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Name = "frmZOutSetup"
        Me.Text = "Z-Out Setup"
        Me.fraWS.ResumeLayout(False)
        Me.fraWS.PerformLayout()
        Me.fraZDOut.ResumeLayout(False)
        Me.fraZDOut.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents fraWS As System.Windows.Forms.GroupBox
    Friend WithEvents radCurrentWS As System.Windows.Forms.RadioButton
    Friend WithEvents radAllWS As System.Windows.Forms.RadioButton
    Friend WithEvents fraZDOut As System.Windows.Forms.GroupBox
    Friend WithEvents radDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents radPrevZDOut As System.Windows.Forms.RadioButton
    Friend WithEvents radNotZDOut As System.Windows.Forms.RadioButton
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboZdOut As System.Windows.Forms.ComboBox
End Class
