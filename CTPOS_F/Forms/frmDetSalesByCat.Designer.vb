<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetSalesByCat
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.lblStart = New System.Windows.Forms.Label
        Me.lblEnd = New System.Windows.Forms.Label
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.fraDateCriter = New System.Windows.Forms.GroupBox
        Me.radAllDates = New System.Windows.Forms.RadioButton
        Me.radDateRange = New System.Windows.Forms.RadioButton
        Me.radSpecificDate = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.fraDateCriter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(276, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(195, 12)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 21
        Me.btnPreview.Text = "&Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(162, 111)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(32, 13)
        Me.lblStart.TabIndex = 20
        Me.lblStart.Text = "Start:"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(162, 134)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(29, 13)
        Me.lblEnd.TabIndex = 19
        Me.lblEnd.Text = "End:"
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(223, 131)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(100, 20)
        Me.txtEnd.TabIndex = 18
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(223, 108)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(100, 20)
        Me.txtStart.TabIndex = 17
        '
        'fraDateCriter
        '
        Me.fraDateCriter.Controls.Add(Me.radAllDates)
        Me.fraDateCriter.Controls.Add(Me.radDateRange)
        Me.fraDateCriter.Controls.Add(Me.radSpecificDate)
        Me.fraDateCriter.Location = New System.Drawing.Point(15, 67)
        Me.fraDateCriter.Name = "fraDateCriter"
        Me.fraDateCriter.Size = New System.Drawing.Size(130, 95)
        Me.fraDateCriter.TabIndex = 16
        Me.fraDateCriter.TabStop = False
        '
        'radAllDates
        '
        Me.radAllDates.AutoSize = True
        Me.radAllDates.Checked = True
        Me.radAllDates.Location = New System.Drawing.Point(6, 19)
        Me.radAllDates.Name = "radAllDates"
        Me.radAllDates.Size = New System.Drawing.Size(67, 17)
        Me.radAllDates.TabIndex = 2
        Me.radAllDates.TabStop = True
        Me.radAllDates.Text = "All Dates"
        Me.radAllDates.UseVisualStyleBackColor = True
        '
        'radDateRange
        '
        Me.radDateRange.AutoSize = True
        Me.radDateRange.Location = New System.Drawing.Point(6, 65)
        Me.radDateRange.Name = "radDateRange"
        Me.radDateRange.Size = New System.Drawing.Size(83, 17)
        Me.radDateRange.TabIndex = 1
        Me.radDateRange.Text = "Date Range"
        Me.radDateRange.UseVisualStyleBackColor = True
        '
        'radSpecificDate
        '
        Me.radSpecificDate.AutoSize = True
        Me.radSpecificDate.Location = New System.Drawing.Point(6, 42)
        Me.radSpecificDate.Name = "radSpecificDate"
        Me.radSpecificDate.Size = New System.Drawing.Size(89, 17)
        Me.radSpecificDate.TabIndex = 0
        Me.radSpecificDate.Text = "Specific Date"
        Me.radSpecificDate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(70, 40)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(121, 21)
        Me.cboCategory.TabIndex = 14
        '
        'frmDetSalesByCat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 183)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.fraDateCriter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCategory)
        Me.Name = "frmDetSalesByCat"
        Me.Text = "Detailed Sales Report (by Category)"
        Me.fraDateCriter.ResumeLayout(False)
        Me.fraDateCriter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents fraDateCriter As System.Windows.Forms.GroupBox
    Friend WithEvents radAllDates As System.Windows.Forms.RadioButton
    Friend WithEvents radDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents radSpecificDate As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
End Class
