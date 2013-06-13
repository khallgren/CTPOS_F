<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailedSalesSetup
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
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboClerk = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radAllWS = New System.Windows.Forms.RadioButton
        Me.radCurrentWS = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.radAllDates = New System.Windows.Forms.RadioButton
        Me.radDateRange = New System.Windows.Forms.RadioButton
        Me.radSpecificDate = New System.Windows.Forms.RadioButton
        Me.lblEnd = New System.Windows.Forms.Label
        Me.lblStart = New System.Windows.Forms.Label
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(70, 61)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 21)
        Me.cboStore.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Store:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(70, 115)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(121, 21)
        Me.cboCategory.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Clerk:"
        '
        'cboClerk
        '
        Me.cboClerk.FormattingEnabled = True
        Me.cboClerk.Location = New System.Drawing.Point(70, 88)
        Me.cboClerk.Name = "cboClerk"
        Me.cboClerk.Size = New System.Drawing.Size(121, 21)
        Me.cboClerk.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radAllWS)
        Me.GroupBox1.Controls.Add(Me.radCurrentWS)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 70)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'radAllWS
        '
        Me.radAllWS.AutoSize = True
        Me.radAllWS.Location = New System.Drawing.Point(6, 42)
        Me.radAllWS.Name = "radAllWS"
        Me.radAllWS.Size = New System.Drawing.Size(101, 17)
        Me.radAllWS.TabIndex = 1
        Me.radAllWS.Text = "All Workstations"
        Me.radAllWS.UseVisualStyleBackColor = True
        '
        'radCurrentWS
        '
        Me.radCurrentWS.AutoSize = True
        Me.radCurrentWS.Checked = True
        Me.radCurrentWS.Location = New System.Drawing.Point(6, 19)
        Me.radCurrentWS.Name = "radCurrentWS"
        Me.radCurrentWS.Size = New System.Drawing.Size(119, 17)
        Me.radCurrentWS.TabIndex = 0
        Me.radCurrentWS.TabStop = True
        Me.radCurrentWS.Text = "Current Workstation"
        Me.radCurrentWS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radAllDates)
        Me.GroupBox2.Controls.Add(Me.radDateRange)
        Me.GroupBox2.Controls.Add(Me.radSpecificDate)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(130, 95)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
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
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(162, 285)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(29, 13)
        Me.lblEnd.TabIndex = 10
        Me.lblEnd.Text = "End:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(162, 262)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(32, 13)
        Me.lblStart.TabIndex = 11
        Me.lblStart.Text = "Start:"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(167, 12)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 12
        Me.btnPreview.Text = "&Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(248, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(224, 258)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(200, 20)
        Me.dtpStart.TabIndex = 14
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(224, 281)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(200, 20)
        Me.dtpEnd.TabIndex = 15
        '
        'frmDetailedSalesSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 323)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboClerk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStore)
        Me.Name = "frmDetailedSalesSetup"
        Me.Text = "Detailed Sales Report Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboClerk As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radAllWS As System.Windows.Forms.RadioButton
    Friend WithEvents radCurrentWS As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radAllDates As System.Windows.Forms.RadioButton
    Friend WithEvents radDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents radSpecificDate As System.Windows.Forms.RadioButton
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
End Class
