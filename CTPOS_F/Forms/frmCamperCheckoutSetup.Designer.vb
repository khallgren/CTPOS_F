<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamperCheckoutSetup
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
        Me.cboPickSite = New System.Windows.Forms.ComboBox
        Me.cboPickWeek = New System.Windows.Forms.ComboBox
        Me.cboSortBy = New System.Windows.Forms.ComboBox
        Me.txtCoinCount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnGenerateRefundTransactions = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnRefreshCoinCount = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboPickSite
        '
        Me.cboPickSite.FormattingEnabled = True
        Me.cboPickSite.Location = New System.Drawing.Point(132, 18)
        Me.cboPickSite.Name = "cboPickSite"
        Me.cboPickSite.Size = New System.Drawing.Size(208, 21)
        Me.cboPickSite.TabIndex = 0
        '
        'cboPickWeek
        '
        Me.cboPickWeek.FormattingEnabled = True
        Me.cboPickWeek.Location = New System.Drawing.Point(132, 59)
        Me.cboPickWeek.Name = "cboPickWeek"
        Me.cboPickWeek.Size = New System.Drawing.Size(208, 21)
        Me.cboPickWeek.TabIndex = 1
        '
        'cboSortBy
        '
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Location = New System.Drawing.Point(132, 100)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(121, 21)
        Me.cboSortBy.TabIndex = 2
        '
        'txtCoinCount
        '
        Me.txtCoinCount.Location = New System.Drawing.Point(136, 162)
        Me.txtCoinCount.Multiline = True
        Me.txtCoinCount.Name = "txtCoinCount"
        Me.txtCoinCount.Size = New System.Drawing.Size(322, 165)
        Me.txtCoinCount.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pick Site:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Pick Week:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sort/Group By:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Coin Count:"
        '
        'btnGenerateRefundTransactions
        '
        Me.btnGenerateRefundTransactions.Location = New System.Drawing.Point(30, 379)
        Me.btnGenerateRefundTransactions.Name = "btnGenerateRefundTransactions"
        Me.btnGenerateRefundTransactions.Size = New System.Drawing.Size(185, 23)
        Me.btnGenerateRefundTransactions.TabIndex = 8
        Me.btnGenerateRefundTransactions.Text = "Generate Refund Transactions"
        Me.btnGenerateRefundTransactions.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.Transparent
        Me.btnPreview.Location = New System.Drawing.Point(381, 18)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(77, 21)
        Me.btnPreview.TabIndex = 9
        Me.btnPreview.Text = "&Preview"
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'btnRefreshCoinCount
        '
        Me.btnRefreshCoinCount.Location = New System.Drawing.Point(29, 194)
        Me.btnRefreshCoinCount.Name = "btnRefreshCoinCount"
        Me.btnRefreshCoinCount.Size = New System.Drawing.Size(75, 23)
        Me.btnRefreshCoinCount.TabIndex = 10
        Me.btnRefreshCoinCount.Text = "Refresh"
        Me.btnRefreshCoinCount.UseVisualStyleBackColor = True
        '
        'frmCamperCheckoutSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 424)
        Me.Controls.Add(Me.btnRefreshCoinCount)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnGenerateRefundTransactions)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCoinCount)
        Me.Controls.Add(Me.cboSortBy)
        Me.Controls.Add(Me.cboPickWeek)
        Me.Controls.Add(Me.cboPickSite)
        Me.Name = "frmCamperCheckoutSetup"
        Me.Text = "Camper Checkout Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPickSite As System.Windows.Forms.ComboBox
    Friend WithEvents cboPickWeek As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoinCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateRefundTransactions As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnRefreshCoinCount As System.Windows.Forms.Button
End Class
