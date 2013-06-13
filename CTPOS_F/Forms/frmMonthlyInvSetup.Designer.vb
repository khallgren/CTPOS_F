<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonthlyInvSetup
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
        Me.btnPreviewReport = New System.Windows.Forms.Button
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.btnSelectmonth = New System.Windows.Forms.Label
        Me.lblStore = New System.Windows.Forms.Label
        Me.chkIncludeInactive = New System.Windows.Forms.CheckBox
        Me.lblIncludeInactive = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'btnPreviewReport
        '
        Me.btnPreviewReport.Location = New System.Drawing.Point(90, 151)
        Me.btnPreviewReport.Name = "btnPreviewReport"
        Me.btnPreviewReport.Size = New System.Drawing.Size(120, 23)
        Me.btnPreviewReport.TabIndex = 0
        Me.btnPreviewReport.Text = "Preview Report"
        Me.btnPreviewReport.UseVisualStyleBackColor = True
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(128, 111)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 21)
        Me.cboStore.TabIndex = 1
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(128, 57)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(121, 21)
        Me.cboMonth.TabIndex = 2
        '
        'btnSelectmonth
        '
        Me.btnSelectmonth.AutoSize = True
        Me.btnSelectmonth.Location = New System.Drawing.Point(43, 60)
        Me.btnSelectmonth.Name = "btnSelectmonth"
        Me.btnSelectmonth.Size = New System.Drawing.Size(70, 13)
        Me.btnSelectmonth.TabIndex = 3
        Me.btnSelectmonth.Text = "Select Month"
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Location = New System.Drawing.Point(68, 119)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(32, 13)
        Me.lblStore.TabIndex = 4
        Me.lblStore.Text = "Store"
        '
        'chkIncludeInactive
        '
        Me.chkIncludeInactive.AutoSize = True
        Me.chkIncludeInactive.Location = New System.Drawing.Point(128, 24)
        Me.chkIncludeInactive.Name = "chkIncludeInactive"
        Me.chkIncludeInactive.Size = New System.Drawing.Size(15, 14)
        Me.chkIncludeInactive.TabIndex = 5
        Me.chkIncludeInactive.UseVisualStyleBackColor = True
        '
        'lblIncludeInactive
        '
        Me.lblIncludeInactive.AutoSize = True
        Me.lblIncludeInactive.Location = New System.Drawing.Point(43, 24)
        Me.lblIncludeInactive.Name = "lblIncludeInactive"
        Me.lblIncludeInactive.Size = New System.Drawing.Size(83, 13)
        Me.lblIncludeInactive.TabIndex = 6
        Me.lblIncludeInactive.Text = "Include Inactive"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select Year"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(128, 84)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(121, 21)
        Me.cboYear.TabIndex = 7
        '
        'frmMonthlyInvSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 192)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.lblIncludeInactive)
        Me.Controls.Add(Me.chkIncludeInactive)
        Me.Controls.Add(Me.lblStore)
        Me.Controls.Add(Me.btnSelectmonth)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboStore)
        Me.Controls.Add(Me.btnPreviewReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMonthlyInvSetup"
        Me.Text = "Monthly Inventory Report Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreviewReport As System.Windows.Forms.Button
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelectmonth As System.Windows.Forms.Label
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents chkIncludeInactive As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncludeInactive As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
End Class
