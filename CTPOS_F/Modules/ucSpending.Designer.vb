Imports Xceed.DockingWindows
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSpending
    Inherits ToolWindow

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.btnQuickPrint = New System.Windows.Forms.Button
        Me.lblWeek = New System.Windows.Forms.Label
        Me.cboWeekCode = New System.Windows.Forms.ComboBox
        Me.lblRegistrationID = New System.Windows.Forms.Label
        Me.txtRegistrationID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBlockCode = New System.Windows.Forms.ComboBox
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.btnAddSpendingMoney = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnContinue = New System.Windows.Forms.Button
        Me.pnlFill = New System.Windows.Forms.Panel
        Me.lstCampers = New System.Windows.Forms.ListBox
        Me.tmrRefreshSpending = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlFill.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.AutoSize = True
        Me.pnlTop.Controls.Add(Me.btnQuickPrint)
        Me.pnlTop.Controls.Add(Me.lblWeek)
        Me.pnlTop.Controls.Add(Me.cboWeekCode)
        Me.pnlTop.Controls.Add(Me.lblRegistrationID)
        Me.pnlTop.Controls.Add(Me.txtRegistrationID)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.cboBlockCode)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(300, 119)
        Me.pnlTop.TabIndex = 0
        '
        'btnQuickPrint
        '
        Me.btnQuickPrint.Location = New System.Drawing.Point(198, 13)
        Me.btnQuickPrint.Name = "btnQuickPrint"
        Me.btnQuickPrint.Size = New System.Drawing.Size(84, 29)
        Me.btnQuickPrint.TabIndex = 21
        Me.btnQuickPrint.Text = "Quick Print"
        Me.btnQuickPrint.UseVisualStyleBackColor = True
        '
        'lblWeek
        '
        Me.lblWeek.AutoSize = True
        Me.lblWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek.Location = New System.Drawing.Point(-2, 55)
        Me.lblWeek.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWeek.Name = "lblWeek"
        Me.lblWeek.Size = New System.Drawing.Size(54, 20)
        Me.lblWeek.TabIndex = 20
        Me.lblWeek.Text = "Week:"
        '
        'cboWeekCode
        '
        Me.cboWeekCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboWeekCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWeekCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWeekCode.FormattingEnabled = True
        Me.cboWeekCode.Location = New System.Drawing.Point(53, 53)
        Me.cboWeekCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboWeekCode.Name = "cboWeekCode"
        Me.cboWeekCode.Size = New System.Drawing.Size(243, 28)
        Me.cboWeekCode.TabIndex = 17
        '
        'lblRegistrationID
        '
        Me.lblRegistrationID.AutoSize = True
        Me.lblRegistrationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrationID.Location = New System.Drawing.Point(0, 17)
        Me.lblRegistrationID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegistrationID.Name = "lblRegistrationID"
        Me.lblRegistrationID.Size = New System.Drawing.Size(64, 20)
        Me.lblRegistrationID.TabIndex = 19
        Me.lblRegistrationID.Text = "Reg ID:"
        '
        'txtRegistrationID
        '
        Me.txtRegistrationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistrationID.Location = New System.Drawing.Point(72, 17)
        Me.txtRegistrationID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRegistrationID.Name = "txtRegistrationID"
        Me.txtRegistrationID.Size = New System.Drawing.Size(106, 26)
        Me.txtRegistrationID.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-5, 87)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Block Code:"
        '
        'cboBlockCode
        '
        Me.cboBlockCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboBlockCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlockCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBlockCode.FormattingEnabled = True
        Me.cboBlockCode.Location = New System.Drawing.Point(89, 86)
        Me.cboBlockCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboBlockCode.Name = "cboBlockCode"
        Me.cboBlockCode.Size = New System.Drawing.Size(207, 28)
        Me.cboBlockCode.TabIndex = 18
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnAddSpendingMoney)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnContinue)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 646)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(300, 73)
        Me.pnlBottom.TabIndex = 1
        '
        'btnAddSpendingMoney
        '
        Me.btnAddSpendingMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSpendingMoney.Location = New System.Drawing.Point(72, 8)
        Me.btnAddSpendingMoney.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddSpendingMoney.Name = "btnAddSpendingMoney"
        Me.btnAddSpendingMoney.Size = New System.Drawing.Size(186, 42)
        Me.btnAddSpendingMoney.TabIndex = 9
        Me.btnAddSpendingMoney.Text = "Add Spending Money"
        Me.btnAddSpendingMoney.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(202, 8)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 42)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "C&ancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnContinue
        '
        Me.btnContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinue.Location = New System.Drawing.Point(17, 7)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(110, 42)
        Me.btnContinue.TabIndex = 7
        Me.btnContinue.Text = "&Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        Me.btnContinue.Visible = False
        '
        'pnlFill
        '
        Me.pnlFill.Controls.Add(Me.lstCampers)
        Me.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFill.Location = New System.Drawing.Point(0, 119)
        Me.pnlFill.Name = "pnlFill"
        Me.pnlFill.Size = New System.Drawing.Size(300, 527)
        Me.pnlFill.TabIndex = 2
        '
        'lstCampers
        '
        Me.lstCampers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCampers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCampers.FormattingEnabled = True
        Me.lstCampers.ItemHeight = 20
        Me.lstCampers.Location = New System.Drawing.Point(0, 0)
        Me.lstCampers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstCampers.Name = "lstCampers"
        Me.lstCampers.Size = New System.Drawing.Size(300, 524)
        Me.lstCampers.TabIndex = 13
        '
        'tmrRefreshSpending
        '
        Me.tmrRefreshSpending.Enabled = True
        Me.tmrRefreshSpending.Interval = 30000
        '
        'ucSpending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlFill)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.Key = "ucSpending"
        Me.Name = "ucSpending"
        Me.Size = New System.Drawing.Size(300, 719)
        Me.Text = "Spending Money"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlFill.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlFill As System.Windows.Forms.Panel
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lstCampers As System.Windows.Forms.ListBox
    Friend WithEvents lblWeek As System.Windows.Forms.Label
    Friend WithEvents cboWeekCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegistrationID As System.Windows.Forms.Label
    Friend WithEvents txtRegistrationID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBlockCode As System.Windows.Forms.ComboBox
    Friend WithEvents tmrRefreshSpending As System.Windows.Forms.Timer
    Friend WithEvents btnAddSpendingMoney As System.Windows.Forms.Button
    Friend WithEvents btnQuickPrint As System.Windows.Forms.Button

End Class
