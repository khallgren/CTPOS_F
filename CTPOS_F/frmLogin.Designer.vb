<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.cboClerks = New System.Windows.Forms.ComboBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.chkClerk = New System.Windows.Forms.CheckBox
        Me.btnContinue = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkAdmin = New System.Windows.Forms.CheckBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnLogout = New System.Windows.Forms.Button
        Me.btnChangePassword = New System.Windows.Forms.Button
        Me.btnTest = New System.Windows.Forms.Button
        Me.lblVersionNumber = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkDebug = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cboClerks
        '
        Me.cboClerks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboClerks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClerks.FormattingEnabled = True
        Me.cboClerks.Location = New System.Drawing.Point(84, 12)
        Me.cboClerks.Name = "cboClerks"
        Me.cboClerks.Size = New System.Drawing.Size(121, 21)
        Me.cboClerks.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(84, 39)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(121, 20)
        Me.txtPassword.TabIndex = 1
        '
        'chkClerk
        '
        Me.chkClerk.AutoSize = True
        Me.chkClerk.Enabled = False
        Me.chkClerk.Location = New System.Drawing.Point(84, 65)
        Me.chkClerk.Name = "chkClerk"
        Me.chkClerk.Size = New System.Drawing.Size(50, 17)
        Me.chkClerk.TabIndex = 2
        Me.chkClerk.TabStop = False
        Me.chkClerk.Text = "Clerk"
        Me.chkClerk.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.Enabled = False
        Me.btnContinue.Location = New System.Drawing.Point(15, 131)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(75, 23)
        Me.btnContinue.TabIndex = 2
        Me.btnContinue.Text = "&Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Clerk Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password:"
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Enabled = False
        Me.chkAdmin.Location = New System.Drawing.Point(84, 88)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(86, 17)
        Me.chkAdmin.TabIndex = 6
        Me.chkAdmin.TabStop = False
        Me.chkAdmin.Text = "Administrator"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(292, 131)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Enabled = False
        Me.btnLogout.Location = New System.Drawing.Point(211, 131)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "&Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Enabled = False
        Me.btnChangePassword.Location = New System.Drawing.Point(95, 131)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(110, 23)
        Me.btnChangePassword.TabIndex = 3
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        Me.btnChangePassword.Visible = False
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(292, 99)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 10
        Me.btnTest.Text = "Button1"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'lblVersionNumber
        '
        Me.lblVersionNumber.AutoSize = True
        Me.lblVersionNumber.Location = New System.Drawing.Point(12, 163)
        Me.lblVersionNumber.Name = "lblVersionNumber"
        Me.lblVersionNumber.Size = New System.Drawing.Size(108, 13)
        Me.lblVersionNumber.TabIndex = 11
        Me.lblVersionNumber.Text = "Update KH20120817"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Press Enter to validate password"
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Location = New System.Drawing.Point(245, 162)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(122, 17)
        Me.chkDebug.TabIndex = 14
        Me.chkDebug.Text = "Run in Debug Mode"
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 191)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblVersionNumber)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.chkAdmin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.chkClerk)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.cboClerks)
        Me.Name = "frmLogin"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboClerks As System.Windows.Forms.ComboBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkClerk As System.Windows.Forms.CheckBox
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblVersionNumber As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox

End Class
