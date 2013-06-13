<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryLookup
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
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.lstInventory = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnContinue = New System.Windows.Forms.Button
        Me.txtItemNumber = New System.Windows.Forms.TextBox
        Me.lblRegistrationID = New System.Windows.Forms.Label
        Me.chkIncludeInactive = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(687, 53)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(158, 28)
        Me.cboCategory.TabIndex = 3
        '
        'lstInventory
        '
        Me.lstInventory.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.ItemHeight = 20
        Me.lstInventory.Location = New System.Drawing.Point(0, 0)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(598, 484)
        Me.lstInventory.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(604, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Category:"
        '
        'btnContinue
        '
        Me.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinue.Location = New System.Drawing.Point(608, 396)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(237, 79)
        Me.btnContinue.TabIndex = 5
        Me.btnContinue.Text = "&Ok"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'txtItemNumber
        '
        Me.txtItemNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemNumber.Location = New System.Drawing.Point(745, 12)
        Me.txtItemNumber.Name = "txtItemNumber"
        Me.txtItemNumber.Size = New System.Drawing.Size(100, 26)
        Me.txtItemNumber.TabIndex = 1
        '
        'lblRegistrationID
        '
        Me.lblRegistrationID.AutoSize = True
        Me.lblRegistrationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrationID.Location = New System.Drawing.Point(604, 18)
        Me.lblRegistrationID.Name = "lblRegistrationID"
        Me.lblRegistrationID.Size = New System.Drawing.Size(101, 20)
        Me.lblRegistrationID.TabIndex = 6
        Me.lblRegistrationID.Text = "Item Number"
        '
        'chkIncludeInactive
        '
        Me.chkIncludeInactive.AutoSize = True
        Me.chkIncludeInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncludeInactive.Location = New System.Drawing.Point(608, 96)
        Me.chkIncludeInactive.Name = "chkIncludeInactive"
        Me.chkIncludeInactive.Size = New System.Drawing.Size(148, 24)
        Me.chkIncludeInactive.TabIndex = 7
        Me.chkIncludeInactive.Text = "Include Inactive?"
        Me.chkIncludeInactive.UseVisualStyleBackColor = True
        '
        'frmInventoryLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 487)
        Me.Controls.Add(Me.chkIncludeInactive)
        Me.Controls.Add(Me.lblRegistrationID)
        Me.Controls.Add(Me.txtItemNumber)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstInventory)
        Me.Controls.Add(Me.cboCategory)
        Me.Name = "frmInventoryLookup"
        Me.Text = "Inventory Lookup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lstInventory As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents txtItemNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblRegistrationID As System.Windows.Forms.Label
    Friend WithEvents chkIncludeInactive As System.Windows.Forms.CheckBox
End Class
