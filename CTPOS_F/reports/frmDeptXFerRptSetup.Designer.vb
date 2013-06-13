<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeptXFerRptSetup
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
        Me.fraDept = New System.Windows.Forms.GroupBox
        Me.radSpecificDept = New System.Windows.Forms.RadioButton
        Me.radAllDepts = New System.Windows.Forms.RadioButton
        Me.fraDates = New System.Windows.Forms.GroupBox
        Me.radSpecificDate = New System.Windows.Forms.RadioButton
        Me.radDateRange = New System.Windows.Forms.RadioButton
        Me.radAllDates = New System.Windows.Forms.RadioButton
        Me.cboDept = New System.Windows.Forms.ComboBox
        Me.cboDate = New System.Windows.Forms.ComboBox
        Me.txtStartDate = New System.Windows.Forms.TextBox
        Me.txtEndDate = New System.Windows.Forms.TextBox
        Me.fraDept.SuspendLayout()
        Me.fraDates.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(143, 12)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 0
        Me.btnPreview.Text = "Pre&view"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(226, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "C&ancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'fraDept
        '
        Me.fraDept.Controls.Add(Me.radSpecificDept)
        Me.fraDept.Controls.Add(Me.radAllDepts)
        Me.fraDept.Location = New System.Drawing.Point(12, 42)
        Me.fraDept.Name = "fraDept"
        Me.fraDept.Size = New System.Drawing.Size(137, 79)
        Me.fraDept.TabIndex = 2
        Me.fraDept.TabStop = False
        '
        'radSpecificDept
        '
        Me.radSpecificDept.AutoSize = True
        Me.radSpecificDept.Location = New System.Drawing.Point(6, 42)
        Me.radSpecificDept.Name = "radSpecificDept"
        Me.radSpecificDept.Size = New System.Drawing.Size(121, 17)
        Me.radSpecificDept.TabIndex = 1
        Me.radSpecificDept.TabStop = True
        Me.radSpecificDept.Text = "Specific Department"
        Me.radSpecificDept.UseVisualStyleBackColor = True
        '
        'radAllDepts
        '
        Me.radAllDepts.AutoSize = True
        Me.radAllDepts.Checked = True
        Me.radAllDepts.Location = New System.Drawing.Point(6, 19)
        Me.radAllDepts.Name = "radAllDepts"
        Me.radAllDepts.Size = New System.Drawing.Size(99, 17)
        Me.radAllDepts.TabIndex = 0
        Me.radAllDepts.TabStop = True
        Me.radAllDepts.Text = "All Departments"
        Me.radAllDepts.UseVisualStyleBackColor = True
        '
        'fraDates
        '
        Me.fraDates.Controls.Add(Me.radSpecificDate)
        Me.fraDates.Controls.Add(Me.radDateRange)
        Me.fraDates.Controls.Add(Me.radAllDates)
        Me.fraDates.Location = New System.Drawing.Point(18, 127)
        Me.fraDates.Name = "fraDates"
        Me.fraDates.Size = New System.Drawing.Size(110, 96)
        Me.fraDates.TabIndex = 3
        Me.fraDates.TabStop = False
        '
        'radSpecificDate
        '
        Me.radSpecificDate.AutoSize = True
        Me.radSpecificDate.Location = New System.Drawing.Point(6, 42)
        Me.radSpecificDate.Name = "radSpecificDate"
        Me.radSpecificDate.Size = New System.Drawing.Size(89, 17)
        Me.radSpecificDate.TabIndex = 2
        Me.radSpecificDate.TabStop = True
        Me.radSpecificDate.Text = "Specific Date"
        Me.radSpecificDate.UseVisualStyleBackColor = True
        '
        'radDateRange
        '
        Me.radDateRange.AutoSize = True
        Me.radDateRange.Location = New System.Drawing.Point(6, 65)
        Me.radDateRange.Name = "radDateRange"
        Me.radDateRange.Size = New System.Drawing.Size(83, 17)
        Me.radDateRange.TabIndex = 1
        Me.radDateRange.TabStop = True
        Me.radDateRange.Text = "Date Range"
        Me.radDateRange.UseVisualStyleBackColor = True
        '
        'radAllDates
        '
        Me.radAllDates.AutoSize = True
        Me.radAllDates.Checked = True
        Me.radAllDates.Location = New System.Drawing.Point(6, 19)
        Me.radAllDates.Name = "radAllDates"
        Me.radAllDates.Size = New System.Drawing.Size(67, 17)
        Me.radAllDates.TabIndex = 0
        Me.radAllDates.TabStop = True
        Me.radAllDates.Text = "All Dates"
        Me.radAllDates.UseVisualStyleBackColor = True
        '
        'cboDept
        '
        Me.cboDept.Enabled = False
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(155, 84)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(121, 21)
        Me.cboDept.TabIndex = 4
        '
        'cboDate
        '
        Me.cboDate.Enabled = False
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(155, 169)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(121, 21)
        Me.cboDate.TabIndex = 5
        '
        'txtStartDate
        '
        Me.txtStartDate.Enabled = False
        Me.txtStartDate.Location = New System.Drawing.Point(155, 196)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Size = New System.Drawing.Size(76, 20)
        Me.txtStartDate.TabIndex = 6
        '
        'txtEndDate
        '
        Me.txtEndDate.Enabled = False
        Me.txtEndDate.Location = New System.Drawing.Point(237, 196)
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.Size = New System.Drawing.Size(76, 20)
        Me.txtEndDate.TabIndex = 7
        '
        'frmDeptXFerRptSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 261)
        Me.Controls.Add(Me.txtEndDate)
        Me.Controls.Add(Me.txtStartDate)
        Me.Controls.Add(Me.cboDate)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.fraDates)
        Me.Controls.Add(Me.fraDept)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Name = "frmDeptXFerRptSetup"
        Me.Text = "Department Transfer Report Setup"
        Me.fraDept.ResumeLayout(False)
        Me.fraDept.PerformLayout()
        Me.fraDates.ResumeLayout(False)
        Me.fraDates.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents fraDept As System.Windows.Forms.GroupBox
    Friend WithEvents radSpecificDept As System.Windows.Forms.RadioButton
    Friend WithEvents radAllDepts As System.Windows.Forms.RadioButton
    Friend WithEvents fraDates As System.Windows.Forms.GroupBox
    Friend WithEvents radSpecificDate As System.Windows.Forms.RadioButton
    Friend WithEvents radDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents radAllDates As System.Windows.Forms.RadioButton
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
End Class
