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
        Me.fraZDOut = New System.Windows.Forms.GroupBox
        Me.radDateRange = New System.Windows.Forms.RadioButton
        Me.radPrevZDOut = New System.Windows.Forms.RadioButton
        Me.radNotZDOut = New System.Windows.Forms.RadioButton
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboZdOut = New System.Windows.Forms.ComboBox
        Me.cboWS = New System.Windows.Forms.ComboBox
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
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
        'fraZDOut
        '
        Me.fraZDOut.Controls.Add(Me.radDateRange)
        Me.fraZDOut.Controls.Add(Me.radPrevZDOut)
        Me.fraZDOut.Controls.Add(Me.radNotZDOut)
        Me.fraZDOut.Location = New System.Drawing.Point(12, 199)
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
        Me.txtStart.Location = New System.Drawing.Point(12, 305)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(100, 20)
        Me.txtStart.TabIndex = 4
        '
        'txtEnd
        '
        Me.txtEnd.Enabled = False
        Me.txtEnd.Location = New System.Drawing.Point(140, 305)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(100, 20)
        Me.txtEnd.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "to"
        '
        'cboZdOut
        '
        Me.cboZdOut.Enabled = False
        Me.cboZdOut.FormattingEnabled = True
        Me.cboZdOut.Location = New System.Drawing.Point(169, 240)
        Me.cboZdOut.Name = "cboZdOut"
        Me.cboZdOut.Size = New System.Drawing.Size(121, 21)
        Me.cboZdOut.TabIndex = 7
        '
        'cboWS
        '
        Me.cboWS.FormattingEnabled = True
        Me.cboWS.Location = New System.Drawing.Point(97, 92)
        Me.cboWS.Name = "cboWS"
        Me.cboWS.Size = New System.Drawing.Size(121, 21)
        Me.cboWS.TabIndex = 8
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(97, 65)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 21)
        Me.cboStore.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Store:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Workstation:"
        '
        'frmZOutSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 360)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboStore)
        Me.Controls.Add(Me.cboWS)
        Me.Controls.Add(Me.cboZdOut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.fraZDOut)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Name = "frmZOutSetup"
        Me.Text = "Z-Out Setup"
        Me.fraZDOut.ResumeLayout(False)
        Me.fraZDOut.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents fraZDOut As System.Windows.Forms.GroupBox
    Friend WithEvents radDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents radPrevZDOut As System.Windows.Forms.RadioButton
    Friend WithEvents radNotZDOut As System.Windows.Forms.RadioButton
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboZdOut As System.Windows.Forms.ComboBox
    Friend WithEvents cboWS As System.Windows.Forms.ComboBox
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
