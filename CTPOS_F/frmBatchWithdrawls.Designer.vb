<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchWithdrawls
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
        Me.cmbBlkCode = New System.Windows.Forms.ComboBox
        Me.lblBlkCode = New System.Windows.Forms.Label
        Me.lbtAmount = New System.Windows.Forms.Label
        Me.btnProcess = New System.Windows.Forms.Button
        Me.btnLabels = New System.Windows.Forms.Button
        Me.txtAmount = New CurrencyTextBox.CurrencyTextBox
        Me.SuspendLayout()
        '
        'cmbBlkCode
        '
        Me.cmbBlkCode.FormattingEnabled = True
        Me.cmbBlkCode.Location = New System.Drawing.Point(105, 35)
        Me.cmbBlkCode.Name = "cmbBlkCode"
        Me.cmbBlkCode.Size = New System.Drawing.Size(121, 21)
        Me.cmbBlkCode.TabIndex = 0
        '
        'lblBlkCode
        '
        Me.lblBlkCode.AutoSize = True
        Me.lblBlkCode.Location = New System.Drawing.Point(32, 35)
        Me.lblBlkCode.Name = "lblBlkCode"
        Me.lblBlkCode.Size = New System.Drawing.Size(67, 13)
        Me.lblBlkCode.TabIndex = 1
        Me.lblBlkCode.Text = "Block code :"
        '
        'lbtAmount
        '
        Me.lbtAmount.AutoSize = True
        Me.lbtAmount.Location = New System.Drawing.Point(50, 67)
        Me.lbtAmount.Name = "lbtAmount"
        Me.lbtAmount.Size = New System.Drawing.Size(49, 13)
        Me.lbtAmount.TabIndex = 2
        Me.lbtAmount.Text = "Amount :"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(53, 114)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 4
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnLabels
        '
        Me.btnLabels.Location = New System.Drawing.Point(151, 114)
        Me.btnLabels.Name = "btnLabels"
        Me.btnLabels.Size = New System.Drawing.Size(75, 23)
        Me.btnLabels.TabIndex = 5
        Me.btnLabels.Text = "Labels"
        Me.btnLabels.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.DollarValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAmount.Location = New System.Drawing.Point(105, 67)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(121, 20)
        Me.txtAmount.TabIndex = 6
        '
        'frmBatchWithdrawls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 164)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.btnLabels)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.lbtAmount)
        Me.Controls.Add(Me.lblBlkCode)
        Me.Controls.Add(Me.cmbBlkCode)
        Me.Name = "frmBatchWithdrawls"
        Me.Text = "Batch Withdrawls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbBlkCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBlkCode As System.Windows.Forms.Label
    Friend WithEvents lbtAmount As System.Windows.Forms.Label
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnLabels As System.Windows.Forms.Button
    Friend WithEvents txtAmount As CurrencyTextBox.CurrencyTextBox
End Class
