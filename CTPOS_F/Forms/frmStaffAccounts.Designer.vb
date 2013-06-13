<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffAccounts
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
        Me.btnPrint = New System.Windows.Forms.Button
        Me.lblBeginDate = New System.Windows.Forms.Label
        Me.dteBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.dteEndDate = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(166, 147)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblBeginDate
        '
        Me.lblBeginDate.AutoSize = True
        Me.lblBeginDate.Enabled = False
        Me.lblBeginDate.Location = New System.Drawing.Point(45, 73)
        Me.lblBeginDate.Name = "lblBeginDate"
        Me.lblBeginDate.Size = New System.Drawing.Size(86, 13)
        Me.lblBeginDate.TabIndex = 8
        Me.lblBeginDate.Text = "Begining  Date : "
        Me.lblBeginDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dteBeginDate
        '
        Me.dteBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dteBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteBeginDate.Location = New System.Drawing.Point(137, 69)
        Me.dteBeginDate.Name = "dteBeginDate"
        Me.dteBeginDate.Size = New System.Drawing.Size(102, 20)
        Me.dteBeginDate.TabIndex = 9
        Me.dteBeginDate.Value = New Date(2008, 4, 17, 0, 0, 0, 0)
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Enabled = False
        Me.lblEndDate.Location = New System.Drawing.Point(53, 106)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(78, 13)
        Me.lblEndDate.TabIndex = 10
        Me.lblEndDate.Text = "Ending  Date : "
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dteEndDate
        '
        Me.dteEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dteEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dteEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteEndDate.Location = New System.Drawing.Point(137, 102)
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Size = New System.Drawing.Size(104, 20)
        Me.dteEndDate.TabIndex = 11
        '
        'frmStaffAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 204)
        Me.Controls.Add(Me.lblBeginDate)
        Me.Controls.Add(Me.dteBeginDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.dteEndDate)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "frmStaffAccounts"
        Me.Text = "Staff Accounts Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblBeginDate As System.Windows.Forms.Label
    Friend WithEvents dteBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dteEndDate As System.Windows.Forms.DateTimePicker
End Class
