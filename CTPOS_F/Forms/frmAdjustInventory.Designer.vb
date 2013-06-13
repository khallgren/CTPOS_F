<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustInventory
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
        Me.cboInventory = New System.Windows.Forms.ComboBox
        Me.cboAdjustmentType = New System.Windows.Forms.ComboBox
        Me.cboStoreID = New System.Windows.Forms.ComboBox
        Me.txtNewQty = New System.Windows.Forms.TextBox
        Me.txtAddQty = New System.Windows.Forms.TextBox
        Me.txtRemoveQty = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnComplete = New System.Windows.Forms.Button
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtStockCode = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'cboInventory
        '
        Me.cboInventory.FormattingEnabled = True
        Me.cboInventory.Location = New System.Drawing.Point(117, 130)
        Me.cboInventory.Name = "cboInventory"
        Me.cboInventory.Size = New System.Drawing.Size(207, 21)
        Me.cboInventory.TabIndex = 3
        '
        'cboAdjustmentType
        '
        Me.cboAdjustmentType.FormattingEnabled = True
        Me.cboAdjustmentType.Location = New System.Drawing.Point(117, 327)
        Me.cboAdjustmentType.Name = "cboAdjustmentType"
        Me.cboAdjustmentType.Size = New System.Drawing.Size(121, 21)
        Me.cboAdjustmentType.TabIndex = 8
        '
        'cboStoreID
        '
        Me.cboStoreID.FormattingEnabled = True
        Me.cboStoreID.Location = New System.Drawing.Point(117, 365)
        Me.cboStoreID.Name = "cboStoreID"
        Me.cboStoreID.Size = New System.Drawing.Size(121, 21)
        Me.cboStoreID.TabIndex = 9
        '
        'txtNewQty
        '
        Me.txtNewQty.Location = New System.Drawing.Point(117, 165)
        Me.txtNewQty.Name = "txtNewQty"
        Me.txtNewQty.Size = New System.Drawing.Size(47, 20)
        Me.txtNewQty.TabIndex = 4
        '
        'txtAddQty
        '
        Me.txtAddQty.Location = New System.Drawing.Point(117, 199)
        Me.txtAddQty.Name = "txtAddQty"
        Me.txtAddQty.Size = New System.Drawing.Size(47, 20)
        Me.txtAddQty.TabIndex = 5
        '
        'txtRemoveQty
        '
        Me.txtRemoveQty.Location = New System.Drawing.Point(117, 233)
        Me.txtRemoveQty.Name = "txtRemoveQty"
        Me.txtRemoveQty.Size = New System.Drawing.Size(47, 20)
        Me.txtRemoveQty.TabIndex = 6
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(264, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Inventory Item"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "New Qty"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Add Qty"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Remove Qty"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(79, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(78, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Store"
        '
        'btnComplete
        '
        Me.btnComplete.Location = New System.Drawing.Point(117, 404)
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(206, 50)
        Me.btnComplete.TabIndex = 10
        Me.btnComplete.Text = "&Complete"
        Me.btnComplete.UseVisualStyleBackColor = True
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(117, 95)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(207, 21)
        Me.cboCategory.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Inventory Category"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(47, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Stock Code"
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(117, 61)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(207, 20)
        Me.txtStockCode.TabIndex = 1
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(117, 289)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 20
        '
        'frmAdjustInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 522)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.btnComplete)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtRemoveQty)
        Me.Controls.Add(Me.txtAddQty)
        Me.Controls.Add(Me.txtNewQty)
        Me.Controls.Add(Me.cboStoreID)
        Me.Controls.Add(Me.cboAdjustmentType)
        Me.Controls.Add(Me.cboInventory)
        Me.Name = "frmAdjustInventory"
        Me.Text = "Adjust Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboInventory As System.Windows.Forms.ComboBox
    Friend WithEvents cboAdjustmentType As System.Windows.Forms.ComboBox
    Friend WithEvents cboStoreID As System.Windows.Forms.ComboBox
    Friend WithEvents txtNewQty As System.Windows.Forms.TextBox
    Friend WithEvents txtAddQty As System.Windows.Forms.TextBox
    Friend WithEvents txtRemoveQty As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnComplete As System.Windows.Forms.Button
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
End Class
