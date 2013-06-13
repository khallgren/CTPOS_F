<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummaryReport
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
        Me.cboCatagory = New System.Windows.Forms.ComboBox
        Me.lblCatagory = New System.Windows.Forms.Label
        Me.grpReportChoice = New System.Windows.Forms.GroupBox
        Me.rdbRangeDate = New System.Windows.Forms.RadioButton
        Me.rdbSingleDate = New System.Windows.Forms.RadioButton
        Me.rdbsummary = New System.Windows.Forms.RadioButton
        Me.grpRecalc = New System.Windows.Forms.GroupBox
        Me.rdbNoRecalc = New System.Windows.Forms.RadioButton
        Me.rdbRecalc = New System.Windows.Forms.RadioButton
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.dteStartDate = New System.Windows.Forms.DateTimePicker
        Me.dteEndDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpDates = New System.Windows.Forms.GroupBox
        Me.chkSummaryOnly = New System.Windows.Forms.CheckBox
        Me.grpReportChoice.SuspendLayout()
        Me.grpRecalc.SuspendLayout()
        Me.grpDates.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCatagory
        '
        Me.cboCatagory.FormattingEnabled = True
        Me.cboCatagory.Location = New System.Drawing.Point(148, 25)
        Me.cboCatagory.Name = "cboCatagory"
        Me.cboCatagory.Size = New System.Drawing.Size(180, 21)
        Me.cboCatagory.TabIndex = 0
        '
        'lblCatagory
        '
        Me.lblCatagory.AutoSize = True
        Me.lblCatagory.Location = New System.Drawing.Point(84, 28)
        Me.lblCatagory.Name = "lblCatagory"
        Me.lblCatagory.Size = New System.Drawing.Size(58, 13)
        Me.lblCatagory.TabIndex = 1
        Me.lblCatagory.Text = "Catagory : "
        '
        'grpReportChoice
        '
        Me.grpReportChoice.Controls.Add(Me.rdbRangeDate)
        Me.grpReportChoice.Controls.Add(Me.rdbSingleDate)
        Me.grpReportChoice.Controls.Add(Me.rdbsummary)
        Me.grpReportChoice.Location = New System.Drawing.Point(7, 52)
        Me.grpReportChoice.Name = "grpReportChoice"
        Me.grpReportChoice.Size = New System.Drawing.Size(200, 100)
        Me.grpReportChoice.TabIndex = 2
        Me.grpReportChoice.TabStop = False
        '
        'rdbRangeDate
        '
        Me.rdbRangeDate.AutoSize = True
        Me.rdbRangeDate.Location = New System.Drawing.Point(19, 65)
        Me.rdbRangeDate.Name = "rdbRangeDate"
        Me.rdbRangeDate.Size = New System.Drawing.Size(102, 17)
        Me.rdbRangeDate.TabIndex = 0
        Me.rdbRangeDate.TabStop = True
        Me.rdbRangeDate.Text = "Range Of Dates"
        Me.rdbRangeDate.UseVisualStyleBackColor = True
        '
        'rdbSingleDate
        '
        Me.rdbSingleDate.AutoSize = True
        Me.rdbSingleDate.Location = New System.Drawing.Point(19, 42)
        Me.rdbSingleDate.Name = "rdbSingleDate"
        Me.rdbSingleDate.Size = New System.Drawing.Size(80, 17)
        Me.rdbSingleDate.TabIndex = 0
        Me.rdbSingleDate.TabStop = True
        Me.rdbSingleDate.Text = "Single Date"
        Me.rdbSingleDate.UseVisualStyleBackColor = True
        '
        'rdbsummary
        '
        Me.rdbsummary.AutoSize = True
        Me.rdbsummary.Location = New System.Drawing.Point(19, 19)
        Me.rdbsummary.Name = "rdbsummary"
        Me.rdbsummary.Size = New System.Drawing.Size(68, 17)
        Me.rdbsummary.TabIndex = 0
        Me.rdbsummary.TabStop = True
        Me.rdbsummary.Text = "Summary"
        Me.rdbsummary.UseVisualStyleBackColor = True
        '
        'grpRecalc
        '
        Me.grpRecalc.Controls.Add(Me.rdbNoRecalc)
        Me.grpRecalc.Controls.Add(Me.rdbRecalc)
        Me.grpRecalc.Location = New System.Drawing.Point(213, 52)
        Me.grpRecalc.Name = "grpRecalc"
        Me.grpRecalc.Size = New System.Drawing.Size(200, 100)
        Me.grpRecalc.TabIndex = 3
        Me.grpRecalc.TabStop = False
        '
        'rdbNoRecalc
        '
        Me.rdbNoRecalc.AutoSize = True
        Me.rdbNoRecalc.Location = New System.Drawing.Point(21, 56)
        Me.rdbNoRecalc.Name = "rdbNoRecalc"
        Me.rdbNoRecalc.Size = New System.Drawing.Size(76, 17)
        Me.rdbNoRecalc.TabIndex = 1
        Me.rdbNoRecalc.TabStop = True
        Me.rdbNoRecalc.Text = "No Recalc"
        Me.rdbNoRecalc.UseVisualStyleBackColor = True
        '
        'rdbRecalc
        '
        Me.rdbRecalc.AutoSize = True
        Me.rdbRecalc.Location = New System.Drawing.Point(21, 33)
        Me.rdbRecalc.Name = "rdbRecalc"
        Me.rdbRecalc.Size = New System.Drawing.Size(59, 17)
        Me.rdbRecalc.TabIndex = 1
        Me.rdbRecalc.TabStop = True
        Me.rdbRecalc.Text = "Recalc"
        Me.rdbRecalc.UseVisualStyleBackColor = True
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Enabled = False
        Me.lblStartDate.Location = New System.Drawing.Point(28, 31)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 13)
        Me.lblStartDate.TabIndex = 4
        Me.lblStartDate.Text = "Start Date : "
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dteStartDate
        '
        Me.dteStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dteStartDate.Enabled = False
        Me.dteStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteStartDate.Location = New System.Drawing.Point(98, 27)
        Me.dteStartDate.Name = "dteStartDate"
        Me.dteStartDate.Size = New System.Drawing.Size(102, 20)
        Me.dteStartDate.TabIndex = 5
        Me.dteStartDate.Value = New Date(2008, 4, 17, 0, 0, 0, 0)
        '
        'dteEndDate
        '
        Me.dteEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dteEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dteEndDate.Enabled = False
        Me.dteEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteEndDate.Location = New System.Drawing.Point(287, 27)
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Size = New System.Drawing.Size(104, 20)
        Me.dteEndDate.TabIndex = 7
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Enabled = False
        Me.lblEndDate.Location = New System.Drawing.Point(220, 31)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(61, 13)
        Me.lblEndDate.TabIndex = 6
        Me.lblEndDate.Text = "End Date : "
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(132, 259)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 8
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(218, 259)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpDates
        '
        Me.grpDates.Controls.Add(Me.chkSummaryOnly)
        Me.grpDates.Controls.Add(Me.lblStartDate)
        Me.grpDates.Controls.Add(Me.dteStartDate)
        Me.grpDates.Controls.Add(Me.lblEndDate)
        Me.grpDates.Controls.Add(Me.dteEndDate)
        Me.grpDates.Location = New System.Drawing.Point(7, 158)
        Me.grpDates.Name = "grpDates"
        Me.grpDates.Size = New System.Drawing.Size(406, 86)
        Me.grpDates.TabIndex = 9
        Me.grpDates.TabStop = False
        Me.grpDates.Text = "Dates"
        '
        'chkSummaryOnly
        '
        Me.chkSummaryOnly.AutoSize = True
        Me.chkSummaryOnly.Location = New System.Drawing.Point(151, 61)
        Me.chkSummaryOnly.Name = "chkSummaryOnly"
        Me.chkSummaryOnly.Size = New System.Drawing.Size(93, 17)
        Me.chkSummaryOnly.TabIndex = 8
        Me.chkSummaryOnly.Text = "Summary Only"
        Me.chkSummaryOnly.UseVisualStyleBackColor = True
        '
        'frmSummaryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 296)
        Me.Controls.Add(Me.grpDates)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.grpRecalc)
        Me.Controls.Add(Me.grpReportChoice)
        Me.Controls.Add(Me.lblCatagory)
        Me.Controls.Add(Me.cboCatagory)
        Me.Name = "frmSummaryReport"
        Me.Text = "Summary Report"
        Me.grpReportChoice.ResumeLayout(False)
        Me.grpReportChoice.PerformLayout()
        Me.grpRecalc.ResumeLayout(False)
        Me.grpRecalc.PerformLayout()
        Me.grpDates.ResumeLayout(False)
        Me.grpDates.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCatagory As System.Windows.Forms.Label
    Friend WithEvents grpReportChoice As System.Windows.Forms.GroupBox
    Friend WithEvents grpRecalc As System.Windows.Forms.GroupBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dteStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dteEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents rdbRangeDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSingleDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdbsummary As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNoRecalc As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRecalc As System.Windows.Forms.RadioButton
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpDates As System.Windows.Forms.GroupBox
    Friend WithEvents chkSummaryOnly As System.Windows.Forms.CheckBox
End Class
