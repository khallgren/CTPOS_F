<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashSales
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
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtClerk = New System.Windows.Forms.TextBox
        Me.chkBeginSale = New System.Windows.Forms.CheckBox
        Me.btnRemoveItems = New System.Windows.Forms.Button
        Me.btnAddItems = New System.Windows.Forms.Button
        Me.btnVoid = New System.Windows.Forms.Button
        Me.txtRunningCharge = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grdSalesDetails = New Xceed.Grid.GridControl
        Me.dataRowTemplate1 = New Xceed.Grid.DataRow
        Me.colmgrSaleDetails = New Xceed.Grid.ColumnManagerRow
        Me.txtSaleID = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.fraPriceLevel = New System.Windows.Forms.GroupBox
        Me.radPriceDept = New System.Windows.Forms.RadioButton
        Me.radPriceResident = New System.Windows.Forms.RadioButton
        Me.radPriceSummerStaff = New System.Windows.Forms.RadioButton
        Me.radPriceRetail = New System.Windows.Forms.RadioButton
        Me.btnClose = New System.Windows.Forms.Button
        Me.radCash = New System.Windows.Forms.RadioButton
        Me.radCheck = New System.Windows.Forms.RadioButton
        Me.radCharge = New System.Windows.Forms.RadioButton
        Me.radSpendingMoney = New System.Windows.Forms.RadioButton
        Me.fraPaymentType = New System.Windows.Forms.GroupBox
        Me.radCompleteDept = New System.Windows.Forms.RadioButton
        Me.radStaffChg = New System.Windows.Forms.RadioButton
        CType(Me.grdSalesDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataRowTemplate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.colmgrSaleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.fraPriceLevel.SuspendLayout()
        Me.fraPaymentType.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDate
        '
        Me.txtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(69, 100)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(100, 26)
        Me.txtDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Clerk:"
        '
        'txtClerk
        '
        Me.txtClerk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClerk.Location = New System.Drawing.Point(69, 126)
        Me.txtClerk.Name = "txtClerk"
        Me.txtClerk.ReadOnly = True
        Me.txtClerk.Size = New System.Drawing.Size(100, 26)
        Me.txtClerk.TabIndex = 5
        '
        'chkBeginSale
        '
        Me.chkBeginSale.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBeginSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBeginSale.Location = New System.Drawing.Point(528, 88)
        Me.chkBeginSale.Name = "chkBeginSale"
        Me.chkBeginSale.Size = New System.Drawing.Size(150, 40)
        Me.chkBeginSale.TabIndex = 6
        Me.chkBeginSale.Text = "Begin &Sale (F1)"
        Me.chkBeginSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBeginSale.UseVisualStyleBackColor = True
        '
        'btnRemoveItems
        '
        Me.btnRemoveItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItems.Location = New System.Drawing.Point(528, 232)
        Me.btnRemoveItems.Name = "btnRemoveItems"
        Me.btnRemoveItems.Size = New System.Drawing.Size(150, 50)
        Me.btnRemoveItems.TabIndex = 7
        Me.btnRemoveItems.Text = "&Remove/Return Items (F5)"
        Me.btnRemoveItems.UseVisualStyleBackColor = True
        '
        'btnAddItems
        '
        Me.btnAddItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItems.Location = New System.Drawing.Point(528, 184)
        Me.btnAddItems.Name = "btnAddItems"
        Me.btnAddItems.Size = New System.Drawing.Size(150, 40)
        Me.btnAddItems.TabIndex = 8
        Me.btnAddItems.Text = "Add &Items (F4)"
        Me.btnAddItems.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(528, 136)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(150, 40)
        Me.btnVoid.TabIndex = 9
        Me.btnVoid.Text = "&Void (F3)"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'txtRunningCharge
        '
        Me.txtRunningCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunningCharge.Location = New System.Drawing.Point(406, 504)
        Me.txtRunningCharge.Name = "txtRunningCharge"
        Me.txtRunningCharge.ReadOnly = True
        Me.txtRunningCharge.Size = New System.Drawing.Size(100, 26)
        Me.txtRunningCharge.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(271, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Running Charge:"
        '
        'grdSalesDetails
        '
        Me.grdSalesDetails.DataRowTemplate = Me.dataRowTemplate1
        Me.grdSalesDetails.FixedHeaderRows.Add(Me.colmgrSaleDetails)
        Me.grdSalesDetails.Location = New System.Drawing.Point(15, 158)
        Me.grdSalesDetails.Name = "grdSalesDetails"
        Me.grdSalesDetails.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.grdSalesDetails.Size = New System.Drawing.Size(491, 329)
        Me.grdSalesDetails.TabIndex = 13
        '
        'dataRowTemplate1
        '
        Me.dataRowTemplate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataRowTemplate1.ShowPlusMinus = Xceed.Grid.ShowPlusMinus.Never
        '
        'colmgrSaleDetails
        '
        Me.colmgrSaleDetails.Height = 17
        '
        'txtSaleID
        '
        Me.txtSaleID.Enabled = False
        Me.txtSaleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaleID.Location = New System.Drawing.Point(175, 126)
        Me.txtSaleID.Name = "txtSaleID"
        Me.txtSaleID.Size = New System.Drawing.Size(100, 26)
        Me.txtSaleID.TabIndex = 14
        Me.txtSaleID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.fraPriceLevel)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(708, 74)
        Me.Panel1.TabIndex = 15
        '
        'fraPriceLevel
        '
        Me.fraPriceLevel.Controls.Add(Me.radPriceDept)
        Me.fraPriceLevel.Controls.Add(Me.radPriceResident)
        Me.fraPriceLevel.Controls.Add(Me.radPriceSummerStaff)
        Me.fraPriceLevel.Controls.Add(Me.radPriceRetail)
        Me.fraPriceLevel.Location = New System.Drawing.Point(3, 8)
        Me.fraPriceLevel.Name = "fraPriceLevel"
        Me.fraPriceLevel.Size = New System.Drawing.Size(503, 63)
        Me.fraPriceLevel.TabIndex = 4
        Me.fraPriceLevel.TabStop = False
        Me.fraPriceLevel.Text = "Price Level"
        '
        'radPriceDept
        '
        Me.radPriceDept.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPriceDept.Location = New System.Drawing.Point(344, 16)
        Me.radPriceDept.Name = "radPriceDept"
        Me.radPriceDept.Size = New System.Drawing.Size(130, 41)
        Me.radPriceDept.TabIndex = 3
        Me.radPriceDept.Text = "Department Transfer"
        Me.radPriceDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPriceDept.UseVisualStyleBackColor = True
        '
        'radPriceResident
        '
        Me.radPriceResident.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPriceResident.Location = New System.Drawing.Point(238, 16)
        Me.radPriceResident.Name = "radPriceResident"
        Me.radPriceResident.Size = New System.Drawing.Size(87, 41)
        Me.radPriceResident.TabIndex = 2
        Me.radPriceResident.Text = "Resident Staff"
        Me.radPriceResident.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPriceResident.UseVisualStyleBackColor = True
        '
        'radPriceSummerStaff
        '
        Me.radPriceSummerStaff.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPriceSummerStaff.Location = New System.Drawing.Point(129, 16)
        Me.radPriceSummerStaff.Name = "radPriceSummerStaff"
        Me.radPriceSummerStaff.Size = New System.Drawing.Size(87, 41)
        Me.radPriceSummerStaff.TabIndex = 1
        Me.radPriceSummerStaff.TabStop = True
        Me.radPriceSummerStaff.Text = "Summer Staff"
        Me.radPriceSummerStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPriceSummerStaff.UseVisualStyleBackColor = True
        '
        'radPriceRetail
        '
        Me.radPriceRetail.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPriceRetail.Checked = True
        Me.radPriceRetail.Location = New System.Drawing.Point(20, 16)
        Me.radPriceRetail.Name = "radPriceRetail"
        Me.radPriceRetail.Size = New System.Drawing.Size(87, 41)
        Me.radPriceRetail.TabIndex = 0
        Me.radPriceRetail.TabStop = True
        Me.radPriceRetail.Text = "Retail"
        Me.radPriceRetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPriceRetail.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(528, 23)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(150, 40)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'radCash
        '
        Me.radCash.Appearance = System.Windows.Forms.Appearance.Button
        Me.radCash.Location = New System.Drawing.Point(12, 13)
        Me.radCash.Name = "radCash"
        Me.radCash.Size = New System.Drawing.Size(150, 40)
        Me.radCash.TabIndex = 0
        Me.radCash.TabStop = True
        Me.radCash.Text = "C&ash (F6)"
        Me.radCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radCash.UseVisualStyleBackColor = True
        '
        'radCheck
        '
        Me.radCheck.Appearance = System.Windows.Forms.Appearance.Button
        Me.radCheck.Location = New System.Drawing.Point(12, 59)
        Me.radCheck.Name = "radCheck"
        Me.radCheck.Size = New System.Drawing.Size(150, 40)
        Me.radCheck.TabIndex = 1
        Me.radCheck.TabStop = True
        Me.radCheck.Text = "Chec&k (F7)"
        Me.radCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radCheck.UseVisualStyleBackColor = True
        '
        'radCharge
        '
        Me.radCharge.Appearance = System.Windows.Forms.Appearance.Button
        Me.radCharge.Location = New System.Drawing.Point(12, 105)
        Me.radCharge.Name = "radCharge"
        Me.radCharge.Size = New System.Drawing.Size(150, 40)
        Me.radCharge.TabIndex = 2
        Me.radCharge.TabStop = True
        Me.radCharge.Text = "Char&ge (F8)"
        Me.radCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radCharge.UseVisualStyleBackColor = True
        '
        'radSpendingMoney
        '
        Me.radSpendingMoney.Appearance = System.Windows.Forms.Appearance.Button
        Me.radSpendingMoney.Location = New System.Drawing.Point(12, 151)
        Me.radSpendingMoney.Name = "radSpendingMoney"
        Me.radSpendingMoney.Size = New System.Drawing.Size(150, 40)
        Me.radSpendingMoney.TabIndex = 3
        Me.radSpendingMoney.TabStop = True
        Me.radSpendingMoney.Text = "S&pending $ (F9)"
        Me.radSpendingMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radSpendingMoney.UseVisualStyleBackColor = True
        '
        'fraPaymentType
        '
        Me.fraPaymentType.Controls.Add(Me.radCompleteDept)
        Me.fraPaymentType.Controls.Add(Me.radStaffChg)
        Me.fraPaymentType.Controls.Add(Me.radSpendingMoney)
        Me.fraPaymentType.Controls.Add(Me.radCharge)
        Me.fraPaymentType.Controls.Add(Me.radCheck)
        Me.fraPaymentType.Controls.Add(Me.radCash)
        Me.fraPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPaymentType.Location = New System.Drawing.Point(516, 292)
        Me.fraPaymentType.Name = "fraPaymentType"
        Me.fraPaymentType.Size = New System.Drawing.Size(181, 290)
        Me.fraPaymentType.TabIndex = 10
        Me.fraPaymentType.TabStop = False
        '
        'radCompleteDept
        '
        Me.radCompleteDept.Appearance = System.Windows.Forms.Appearance.Button
        Me.radCompleteDept.Location = New System.Drawing.Point(12, 244)
        Me.radCompleteDept.Name = "radCompleteDept"
        Me.radCompleteDept.Size = New System.Drawing.Size(150, 40)
        Me.radCompleteDept.TabIndex = 5
        Me.radCompleteDept.TabStop = True
        Me.radCompleteDept.Text = "&Dept Trans (F11)"
        Me.radCompleteDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radCompleteDept.UseVisualStyleBackColor = True
        '
        'radStaffChg
        '
        Me.radStaffChg.Appearance = System.Windows.Forms.Appearance.Button
        Me.radStaffChg.Enabled = False
        Me.radStaffChg.Location = New System.Drawing.Point(12, 197)
        Me.radStaffChg.Name = "radStaffChg"
        Me.radStaffChg.Size = New System.Drawing.Size(150, 40)
        Me.radStaffChg.TabIndex = 4
        Me.radStaffChg.TabStop = True
        Me.radStaffChg.Text = "S&taff Chg (F10)"
        Me.radStaffChg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radStaffChg.UseVisualStyleBackColor = True
        '
        'frmCashSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(708, 584)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSaleID)
        Me.Controls.Add(Me.grdSalesDetails)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRunningCharge)
        Me.Controls.Add(Me.fraPaymentType)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnAddItems)
        Me.Controls.Add(Me.btnRemoveItems)
        Me.Controls.Add(Me.chkBeginSale)
        Me.Controls.Add(Me.txtClerk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDate)
        Me.Name = "frmCashSales"
        Me.Text = "Cash Sales"
        CType(Me.grdSalesDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataRowTemplate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.colmgrSaleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.fraPriceLevel.ResumeLayout(False)
        Me.fraPaymentType.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClerk As System.Windows.Forms.TextBox
    Friend WithEvents chkBeginSale As System.Windows.Forms.CheckBox
    Friend WithEvents btnRemoveItems As System.Windows.Forms.Button
    Friend WithEvents btnAddItems As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents txtRunningCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dataRowTemplate1 As Xceed.Grid.DataRow
    Friend WithEvents grdSalesDetails As Xceed.Grid.GridControl
    Friend WithEvents txtSaleID As System.Windows.Forms.TextBox
    Friend WithEvents colmgrSaleDetails As Xceed.Grid.ColumnManagerRow
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents radCash As System.Windows.Forms.RadioButton
    Friend WithEvents radCheck As System.Windows.Forms.RadioButton
    Friend WithEvents radCharge As System.Windows.Forms.RadioButton
    Friend WithEvents radSpendingMoney As System.Windows.Forms.RadioButton
    Friend WithEvents fraPaymentType As System.Windows.Forms.GroupBox
    Friend WithEvents radStaffChg As System.Windows.Forms.RadioButton
    Friend WithEvents fraPriceLevel As System.Windows.Forms.GroupBox
    Friend WithEvents radPriceRetail As System.Windows.Forms.RadioButton
    Friend WithEvents radPriceSummerStaff As System.Windows.Forms.RadioButton
    Friend WithEvents radPriceResident As System.Windows.Forms.RadioButton
    Friend WithEvents radPriceDept As System.Windows.Forms.RadioButton
    Friend WithEvents radCompleteDept As System.Windows.Forms.RadioButton
End Class
