<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventorySetup
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFilterStockCode = New System.Windows.Forms.TextBox
        Me.cboFilterCategory = New System.Windows.Forms.ComboBox
        Me.chkFilterInactive = New System.Windows.Forms.CheckBox
        Me.lstInventory = New System.Windows.Forms.ListBox
        Me.txtStockCode = New System.Windows.Forms.TextBox
        Me.lblStockCode = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtQuantityToDeplete = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkInactive = New System.Windows.Forms.CheckBox
        Me.chkTaxable = New System.Windows.Forms.CheckBox
        Me.chkNonStock = New System.Windows.Forms.CheckBox
        Me.chkSpendingMoney = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtReorderLevel = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabRetail = New System.Windows.Forms.TabPage
        Me.txtListMthd = New System.Windows.Forms.TextBox
        Me.lblPercentage = New System.Windows.Forms.Label
        Me.txtRetailPercentage = New System.Windows.Forms.TextBox
        Me.grpRetailMethod = New System.Windows.Forms.GroupBox
        Me.radRetailMarginfromCost = New System.Windows.Forms.RadioButton
        Me.radRetailMarkupfromCost = New System.Windows.Forms.RadioButton
        Me.radRetailManual = New System.Windows.Forms.RadioButton
        Me.tabSummer = New System.Windows.Forms.TabPage
        Me.txtSummerMthd = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSummerPercentage = New System.Windows.Forms.TextBox
        Me.grpSummerStaffMethod = New System.Windows.Forms.GroupBox
        Me.radSummerMarkdownfromRetail = New System.Windows.Forms.RadioButton
        Me.radSummerMarginfromCost = New System.Windows.Forms.RadioButton
        Me.radSummerMarkupfromCost = New System.Windows.Forms.RadioButton
        Me.radSummerManual = New System.Windows.Forms.RadioButton
        Me.tabResident = New System.Windows.Forms.TabPage
        Me.txtResidentMthd = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtResidentPercentage = New System.Windows.Forms.TextBox
        Me.grpResidentStaffMethod = New System.Windows.Forms.GroupBox
        Me.radResidentMarkdownfromRetail = New System.Windows.Forms.RadioButton
        Me.radResidentMarginfromCost = New System.Windows.Forms.RadioButton
        Me.radResidentMarkupfromCost = New System.Windows.Forms.RadioButton
        Me.radResidentManual = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnLabels = New System.Windows.Forms.Button
        Me.txtInventoryID = New System.Windows.Forms.TextBox
        Me.txtCost = New CurrencyTextBox.CurrencyTextBox
        Me.txtListPrice = New CurrencyTextBox.CurrencyTextBox
        Me.txtSummerStaffPrice = New CurrencyTextBox.CurrencyTextBox
        Me.txtResidentStaffPrice = New CurrencyTextBox.CurrencyTextBox
        Me.btnAdjustQty = New System.Windows.Forms.Button
        Me.lblInvLevel = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.tabRetail.SuspendLayout()
        Me.grpRetailMethod.SuspendLayout()
        Me.tabSummer.SuspendLayout()
        Me.grpSummerStaffMethod.SuspendLayout()
        Me.tabResident.SuspendLayout()
        Me.grpResidentStaffMethod.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Find by Stock Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Filter by Category"
        '
        'txtFilterStockCode
        '
        Me.txtFilterStockCode.Location = New System.Drawing.Point(118, 9)
        Me.txtFilterStockCode.Name = "txtFilterStockCode"
        Me.txtFilterStockCode.Size = New System.Drawing.Size(100, 20)
        Me.txtFilterStockCode.TabIndex = 3
        '
        'cboFilterCategory
        '
        Me.cboFilterCategory.FormattingEnabled = True
        Me.cboFilterCategory.Location = New System.Drawing.Point(118, 35)
        Me.cboFilterCategory.Name = "cboFilterCategory"
        Me.cboFilterCategory.Size = New System.Drawing.Size(121, 21)
        Me.cboFilterCategory.TabIndex = 4
        '
        'chkFilterInactive
        '
        Me.chkFilterInactive.AutoSize = True
        Me.chkFilterInactive.Location = New System.Drawing.Point(118, 62)
        Me.chkFilterInactive.Name = "chkFilterInactive"
        Me.chkFilterInactive.Size = New System.Drawing.Size(102, 17)
        Me.chkFilterInactive.TabIndex = 5
        Me.chkFilterInactive.Text = "Include Inactive"
        Me.chkFilterInactive.UseVisualStyleBackColor = True
        '
        'lstInventory
        '
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.Location = New System.Drawing.Point(12, 90)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(226, 407)
        Me.lstInventory.TabIndex = 6
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(335, 5)
        Me.txtStockCode.MaxLength = 15
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(135, 20)
        Me.txtStockCode.TabIndex = 7
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Location = New System.Drawing.Point(266, 8)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(63, 13)
        Me.lblStockCode.TabIndex = 8
        Me.lblStockCode.Text = "Stock Code"
        Me.lblStockCode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(271, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Item Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(335, 34)
        Me.txtItemName.MaxLength = 24
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(135, 20)
        Me.txtItemName.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(335, 367)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(415, 66)
        Me.txtDescription.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Vendor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(280, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Category"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboVendor
        '
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(335, 62)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(135, 21)
        Me.cboVendor.TabIndex = 17
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(335, 92)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(135, 21)
        Me.cboCategory.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(279, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "List Price"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(301, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Cost"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(508, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Qty to Deplete "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtQuantityToDeplete
        '
        Me.txtQuantityToDeplete.Location = New System.Drawing.Point(592, 126)
        Me.txtQuantityToDeplete.Name = "txtQuantityToDeplete"
        Me.txtQuantityToDeplete.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantityToDeplete.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(255, 294)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Resident Staff"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(259, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Summer Staff"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkInactive
        '
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Location = New System.Drawing.Point(592, 8)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(64, 17)
        Me.chkInactive.TabIndex = 29
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'chkTaxable
        '
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(592, 31)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(70, 17)
        Me.chkTaxable.TabIndex = 30
        Me.chkTaxable.Text = "Taxable?"
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'chkNonStock
        '
        Me.chkNonStock.AutoSize = True
        Me.chkNonStock.Location = New System.Drawing.Point(592, 54)
        Me.chkNonStock.Name = "chkNonStock"
        Me.chkNonStock.Size = New System.Drawing.Size(100, 17)
        Me.chkNonStock.TabIndex = 31
        Me.chkNonStock.Text = "Non-Stock Item"
        Me.chkNonStock.UseVisualStyleBackColor = True
        '
        'chkSpendingMoney
        '
        Me.chkSpendingMoney.AutoSize = True
        Me.chkSpendingMoney.Location = New System.Drawing.Point(592, 77)
        Me.chkSpendingMoney.Name = "chkSpendingMoney"
        Me.chkSpendingMoney.Size = New System.Drawing.Size(129, 17)
        Me.chkSpendingMoney.TabIndex = 32
        Me.chkSpendingMoney.Text = "Spending Money Item"
        Me.chkSpendingMoney.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(512, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Reorder Level"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtReorderLevel
        '
        Me.txtReorderLevel.Location = New System.Drawing.Point(592, 100)
        Me.txtReorderLevel.Name = "txtReorderLevel"
        Me.txtReorderLevel.Size = New System.Drawing.Size(100, 20)
        Me.txtReorderLevel.TabIndex = 33
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabRetail)
        Me.TabControl1.Controls.Add(Me.tabSummer)
        Me.TabControl1.Controls.Add(Me.tabResident)
        Me.TabControl1.Location = New System.Drawing.Point(487, 172)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(267, 179)
        Me.TabControl1.TabIndex = 37
        '
        'tabRetail
        '
        Me.tabRetail.Controls.Add(Me.txtListMthd)
        Me.tabRetail.Controls.Add(Me.lblPercentage)
        Me.tabRetail.Controls.Add(Me.txtRetailPercentage)
        Me.tabRetail.Controls.Add(Me.grpRetailMethod)
        Me.tabRetail.Location = New System.Drawing.Point(4, 22)
        Me.tabRetail.Name = "tabRetail"
        Me.tabRetail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRetail.Size = New System.Drawing.Size(259, 153)
        Me.tabRetail.TabIndex = 0
        Me.tabRetail.Text = "Retail"
        Me.tabRetail.UseVisualStyleBackColor = True
        '
        'txtListMthd
        '
        Me.txtListMthd.Location = New System.Drawing.Point(8, 26)
        Me.txtListMthd.Name = "txtListMthd"
        Me.txtListMthd.Size = New System.Drawing.Size(27, 20)
        Me.txtListMthd.TabIndex = 3
        Me.txtListMthd.Visible = False
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.Location = New System.Drawing.Point(6, 127)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(62, 13)
        Me.lblPercentage.TabIndex = 2
        Me.lblPercentage.Text = "Percentage"
        '
        'txtRetailPercentage
        '
        Me.txtRetailPercentage.Location = New System.Drawing.Point(81, 124)
        Me.txtRetailPercentage.Name = "txtRetailPercentage"
        Me.txtRetailPercentage.Size = New System.Drawing.Size(100, 20)
        Me.txtRetailPercentage.TabIndex = 1
        '
        'grpRetailMethod
        '
        Me.grpRetailMethod.Controls.Add(Me.radRetailMarginfromCost)
        Me.grpRetailMethod.Controls.Add(Me.radRetailMarkupfromCost)
        Me.grpRetailMethod.Controls.Add(Me.radRetailManual)
        Me.grpRetailMethod.Location = New System.Drawing.Point(47, 12)
        Me.grpRetailMethod.Name = "grpRetailMethod"
        Me.grpRetailMethod.Size = New System.Drawing.Size(201, 104)
        Me.grpRetailMethod.TabIndex = 0
        Me.grpRetailMethod.TabStop = False
        Me.grpRetailMethod.Text = "Method"
        '
        'radRetailMarginfromCost
        '
        Me.radRetailMarginfromCost.AutoSize = True
        Me.radRetailMarginfromCost.Location = New System.Drawing.Point(22, 52)
        Me.radRetailMarginfromCost.Name = "radRetailMarginfromCost"
        Me.radRetailMarginfromCost.Size = New System.Drawing.Size(104, 17)
        Me.radRetailMarginfromCost.TabIndex = 2
        Me.radRetailMarginfromCost.TabStop = True
        Me.radRetailMarginfromCost.Text = "Margin from Cost"
        Me.radRetailMarginfromCost.UseVisualStyleBackColor = True
        '
        'radRetailMarkupfromCost
        '
        Me.radRetailMarkupfromCost.AutoSize = True
        Me.radRetailMarkupfromCost.Location = New System.Drawing.Point(22, 34)
        Me.radRetailMarkupfromCost.Name = "radRetailMarkupfromCost"
        Me.radRetailMarkupfromCost.Size = New System.Drawing.Size(119, 17)
        Me.radRetailMarkupfromCost.TabIndex = 1
        Me.radRetailMarkupfromCost.TabStop = True
        Me.radRetailMarkupfromCost.Text = "% Markup from Cost"
        Me.radRetailMarkupfromCost.UseVisualStyleBackColor = True
        '
        'radRetailManual
        '
        Me.radRetailManual.AutoSize = True
        Me.radRetailManual.Location = New System.Drawing.Point(22, 16)
        Me.radRetailManual.Name = "radRetailManual"
        Me.radRetailManual.Size = New System.Drawing.Size(60, 17)
        Me.radRetailManual.TabIndex = 0
        Me.radRetailManual.TabStop = True
        Me.radRetailManual.Text = "Manual"
        Me.radRetailManual.UseVisualStyleBackColor = True
        '
        'tabSummer
        '
        Me.tabSummer.Controls.Add(Me.txtSummerMthd)
        Me.tabSummer.Controls.Add(Me.Label14)
        Me.tabSummer.Controls.Add(Me.txtSummerPercentage)
        Me.tabSummer.Controls.Add(Me.grpSummerStaffMethod)
        Me.tabSummer.Location = New System.Drawing.Point(4, 22)
        Me.tabSummer.Name = "tabSummer"
        Me.tabSummer.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSummer.Size = New System.Drawing.Size(259, 153)
        Me.tabSummer.TabIndex = 1
        Me.tabSummer.Text = "Summer Staff"
        Me.tabSummer.UseVisualStyleBackColor = True
        '
        'txtSummerMthd
        '
        Me.txtSummerMthd.Location = New System.Drawing.Point(11, 25)
        Me.txtSummerMthd.Name = "txtSummerMthd"
        Me.txtSummerMthd.Size = New System.Drawing.Size(27, 20)
        Me.txtSummerMthd.TabIndex = 6
        Me.txtSummerMthd.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Percentage"
        '
        'txtSummerPercentage
        '
        Me.txtSummerPercentage.Location = New System.Drawing.Point(83, 122)
        Me.txtSummerPercentage.Name = "txtSummerPercentage"
        Me.txtSummerPercentage.Size = New System.Drawing.Size(100, 20)
        Me.txtSummerPercentage.TabIndex = 4
        '
        'grpSummerStaffMethod
        '
        Me.grpSummerStaffMethod.Controls.Add(Me.radSummerMarkdownfromRetail)
        Me.grpSummerStaffMethod.Controls.Add(Me.radSummerMarginfromCost)
        Me.grpSummerStaffMethod.Controls.Add(Me.radSummerMarkupfromCost)
        Me.grpSummerStaffMethod.Controls.Add(Me.radSummerManual)
        Me.grpSummerStaffMethod.Location = New System.Drawing.Point(49, 10)
        Me.grpSummerStaffMethod.Name = "grpSummerStaffMethod"
        Me.grpSummerStaffMethod.Size = New System.Drawing.Size(201, 104)
        Me.grpSummerStaffMethod.TabIndex = 3
        Me.grpSummerStaffMethod.TabStop = False
        Me.grpSummerStaffMethod.Text = "Method"
        '
        'radSummerMarkdownfromRetail
        '
        Me.radSummerMarkdownfromRetail.AutoSize = True
        Me.radSummerMarkdownfromRetail.Location = New System.Drawing.Point(22, 73)
        Me.radSummerMarkdownfromRetail.Name = "radSummerMarkdownfromRetail"
        Me.radSummerMarkdownfromRetail.Size = New System.Drawing.Size(139, 17)
        Me.radSummerMarkdownfromRetail.TabIndex = 3
        Me.radSummerMarkdownfromRetail.TabStop = True
        Me.radSummerMarkdownfromRetail.Text = "% Markdown from Retail"
        Me.radSummerMarkdownfromRetail.UseVisualStyleBackColor = True
        '
        'radSummerMarginfromCost
        '
        Me.radSummerMarginfromCost.AutoSize = True
        Me.radSummerMarginfromCost.Location = New System.Drawing.Point(22, 54)
        Me.radSummerMarginfromCost.Name = "radSummerMarginfromCost"
        Me.radSummerMarginfromCost.Size = New System.Drawing.Size(104, 17)
        Me.radSummerMarginfromCost.TabIndex = 2
        Me.radSummerMarginfromCost.TabStop = True
        Me.radSummerMarginfromCost.Text = "Margin from Cost"
        Me.radSummerMarginfromCost.UseVisualStyleBackColor = True
        '
        'radSummerMarkupfromCost
        '
        Me.radSummerMarkupfromCost.AutoSize = True
        Me.radSummerMarkupfromCost.Location = New System.Drawing.Point(22, 35)
        Me.radSummerMarkupfromCost.Name = "radSummerMarkupfromCost"
        Me.radSummerMarkupfromCost.Size = New System.Drawing.Size(119, 17)
        Me.radSummerMarkupfromCost.TabIndex = 1
        Me.radSummerMarkupfromCost.TabStop = True
        Me.radSummerMarkupfromCost.Text = "% Markup from Cost"
        Me.radSummerMarkupfromCost.UseVisualStyleBackColor = True
        '
        'radSummerManual
        '
        Me.radSummerManual.AutoSize = True
        Me.radSummerManual.Location = New System.Drawing.Point(22, 16)
        Me.radSummerManual.Name = "radSummerManual"
        Me.radSummerManual.Size = New System.Drawing.Size(60, 17)
        Me.radSummerManual.TabIndex = 0
        Me.radSummerManual.TabStop = True
        Me.radSummerManual.Text = "Manual"
        Me.radSummerManual.UseVisualStyleBackColor = True
        '
        'tabResident
        '
        Me.tabResident.Controls.Add(Me.txtResidentMthd)
        Me.tabResident.Controls.Add(Me.Label15)
        Me.tabResident.Controls.Add(Me.txtResidentPercentage)
        Me.tabResident.Controls.Add(Me.grpResidentStaffMethod)
        Me.tabResident.Location = New System.Drawing.Point(4, 22)
        Me.tabResident.Name = "tabResident"
        Me.tabResident.Size = New System.Drawing.Size(259, 153)
        Me.tabResident.TabIndex = 2
        Me.tabResident.Text = "Resident Staff"
        Me.tabResident.UseVisualStyleBackColor = True
        '
        'txtResidentMthd
        '
        Me.txtResidentMthd.Location = New System.Drawing.Point(11, 23)
        Me.txtResidentMthd.Name = "txtResidentMthd"
        Me.txtResidentMthd.Size = New System.Drawing.Size(27, 20)
        Me.txtResidentMthd.TabIndex = 9
        Me.txtResidentMthd.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Percentage"
        '
        'txtResidentPercentage
        '
        Me.txtResidentPercentage.Location = New System.Drawing.Point(83, 122)
        Me.txtResidentPercentage.Name = "txtResidentPercentage"
        Me.txtResidentPercentage.Size = New System.Drawing.Size(100, 20)
        Me.txtResidentPercentage.TabIndex = 7
        '
        'grpResidentStaffMethod
        '
        Me.grpResidentStaffMethod.Controls.Add(Me.radResidentMarkdownfromRetail)
        Me.grpResidentStaffMethod.Controls.Add(Me.radResidentMarginfromCost)
        Me.grpResidentStaffMethod.Controls.Add(Me.radResidentMarkupfromCost)
        Me.grpResidentStaffMethod.Controls.Add(Me.radResidentManual)
        Me.grpResidentStaffMethod.Location = New System.Drawing.Point(49, 10)
        Me.grpResidentStaffMethod.Name = "grpResidentStaffMethod"
        Me.grpResidentStaffMethod.Size = New System.Drawing.Size(201, 104)
        Me.grpResidentStaffMethod.TabIndex = 6
        Me.grpResidentStaffMethod.TabStop = False
        Me.grpResidentStaffMethod.Text = "Method"
        '
        'radResidentMarkdownfromRetail
        '
        Me.radResidentMarkdownfromRetail.AutoSize = True
        Me.radResidentMarkdownfromRetail.Location = New System.Drawing.Point(22, 73)
        Me.radResidentMarkdownfromRetail.Name = "radResidentMarkdownfromRetail"
        Me.radResidentMarkdownfromRetail.Size = New System.Drawing.Size(139, 17)
        Me.radResidentMarkdownfromRetail.TabIndex = 3
        Me.radResidentMarkdownfromRetail.TabStop = True
        Me.radResidentMarkdownfromRetail.Text = "% Markdown from Retail"
        Me.radResidentMarkdownfromRetail.UseVisualStyleBackColor = True
        '
        'radResidentMarginfromCost
        '
        Me.radResidentMarginfromCost.AutoSize = True
        Me.radResidentMarginfromCost.Location = New System.Drawing.Point(22, 54)
        Me.radResidentMarginfromCost.Name = "radResidentMarginfromCost"
        Me.radResidentMarginfromCost.Size = New System.Drawing.Size(104, 17)
        Me.radResidentMarginfromCost.TabIndex = 2
        Me.radResidentMarginfromCost.TabStop = True
        Me.radResidentMarginfromCost.Text = "Margin from Cost"
        Me.radResidentMarginfromCost.UseVisualStyleBackColor = True
        '
        'radResidentMarkupfromCost
        '
        Me.radResidentMarkupfromCost.AutoSize = True
        Me.radResidentMarkupfromCost.Location = New System.Drawing.Point(22, 35)
        Me.radResidentMarkupfromCost.Name = "radResidentMarkupfromCost"
        Me.radResidentMarkupfromCost.Size = New System.Drawing.Size(119, 17)
        Me.radResidentMarkupfromCost.TabIndex = 1
        Me.radResidentMarkupfromCost.TabStop = True
        Me.radResidentMarkupfromCost.Text = "% Markup from Cost"
        Me.radResidentMarkupfromCost.UseVisualStyleBackColor = True
        '
        'radResidentManual
        '
        Me.radResidentManual.AutoSize = True
        Me.radResidentManual.Location = New System.Drawing.Point(22, 16)
        Me.radResidentManual.Name = "radResidentManual"
        Me.radResidentManual.Size = New System.Drawing.Size(60, 17)
        Me.radResidentManual.TabIndex = 0
        Me.radResidentManual.TabStop = True
        Me.radResidentManual.Text = "Manual"
        Me.radResidentManual.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(0, 0)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(104, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Margin from Cost"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(22, 33)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(119, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "% Markup from Cost"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(22, 16)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Manual"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(665, 470)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 31)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(282, 470)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 31)
        Me.btnNew.TabIndex = 39
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(373, 470)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 31)
        Me.btnDelete.TabIndex = 40
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnLabels
        '
        Me.btnLabels.Location = New System.Drawing.Point(464, 470)
        Me.btnLabels.Name = "btnLabels"
        Me.btnLabels.Size = New System.Drawing.Size(85, 31)
        Me.btnLabels.TabIndex = 41
        Me.btnLabels.Text = "Labels"
        Me.btnLabels.UseVisualStyleBackColor = True
        '
        'txtInventoryID
        '
        Me.txtInventoryID.Location = New System.Drawing.Point(338, 124)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.Size = New System.Drawing.Size(100, 20)
        Me.txtInventoryID.TabIndex = 42
        Me.txtInventoryID.Visible = False
        '
        'txtCost
        '
        Me.txtCost.DollarValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCost.Location = New System.Drawing.Point(335, 183)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(100, 20)
        Me.txtCost.TabIndex = 43
        '
        'txtListPrice
        '
        Me.txtListPrice.DollarValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtListPrice.Location = New System.Drawing.Point(335, 235)
        Me.txtListPrice.Name = "txtListPrice"
        Me.txtListPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtListPrice.TabIndex = 44
        '
        'txtSummerStaffPrice
        '
        Me.txtSummerStaffPrice.DollarValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSummerStaffPrice.Location = New System.Drawing.Point(335, 262)
        Me.txtSummerStaffPrice.Name = "txtSummerStaffPrice"
        Me.txtSummerStaffPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtSummerStaffPrice.TabIndex = 45
        '
        'txtResidentStaffPrice
        '
        Me.txtResidentStaffPrice.DollarValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtResidentStaffPrice.Location = New System.Drawing.Point(335, 289)
        Me.txtResidentStaffPrice.Name = "txtResidentStaffPrice"
        Me.txtResidentStaffPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtResidentStaffPrice.TabIndex = 46
        '
        'btnAdjustQty
        '
        Me.btnAdjustQty.Location = New System.Drawing.Point(555, 470)
        Me.btnAdjustQty.Name = "btnAdjustQty"
        Me.btnAdjustQty.Size = New System.Drawing.Size(98, 31)
        Me.btnAdjustQty.TabIndex = 47
        Me.btnAdjustQty.Text = "Adjust Qty"
        Me.btnAdjustQty.UseVisualStyleBackColor = True
        '
        'lblInvLevel
        '
        Me.lblInvLevel.AutoSize = True
        Me.lblInvLevel.Location = New System.Drawing.Point(336, 443)
        Me.lblInvLevel.Name = "lblInvLevel"
        Me.lblInvLevel.Size = New System.Drawing.Size(0, 13)
        Me.lblInvLevel.TabIndex = 48
        '
        'frmInventorySetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 512)
        Me.Controls.Add(Me.lblInvLevel)
        Me.Controls.Add(Me.btnAdjustQty)
        Me.Controls.Add(Me.txtResidentStaffPrice)
        Me.Controls.Add(Me.txtSummerStaffPrice)
        Me.Controls.Add(Me.txtListPrice)
        Me.Controls.Add(Me.txtCost)
        Me.Controls.Add(Me.txtInventoryID)
        Me.Controls.Add(Me.btnLabels)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtReorderLevel)
        Me.Controls.Add(Me.chkSpendingMoney)
        Me.Controls.Add(Me.chkNonStock)
        Me.Controls.Add(Me.chkTaxable)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.txtQuantityToDeplete)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.lblStockCode)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.lstInventory)
        Me.Controls.Add(Me.chkFilterInactive)
        Me.Controls.Add(Me.cboFilterCategory)
        Me.Controls.Add(Me.txtFilterStockCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label13)
        Me.Name = "frmInventorySetup"
        Me.Text = "Inventory Setup"
        Me.TabControl1.ResumeLayout(False)
        Me.tabRetail.ResumeLayout(False)
        Me.tabRetail.PerformLayout()
        Me.grpRetailMethod.ResumeLayout(False)
        Me.grpRetailMethod.PerformLayout()
        Me.tabSummer.ResumeLayout(False)
        Me.tabSummer.PerformLayout()
        Me.grpSummerStaffMethod.ResumeLayout(False)
        Me.grpSummerStaffMethod.PerformLayout()
        Me.tabResident.ResumeLayout(False)
        Me.tabResident.PerformLayout()
        Me.grpResidentStaffMethod.ResumeLayout(False)
        Me.grpResidentStaffMethod.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilterStockCode As System.Windows.Forms.TextBox
    Friend WithEvents cboFilterCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chkFilterInactive As System.Windows.Forms.CheckBox
    Friend WithEvents lstInventory As System.Windows.Forms.ListBox
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtQuantityToDeplete As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents chkNonStock As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpendingMoney As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabRetail As System.Windows.Forms.TabPage
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents txtRetailPercentage As System.Windows.Forms.TextBox
    Friend WithEvents grpRetailMethod As System.Windows.Forms.GroupBox
    Friend WithEvents radRetailMarginfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radRetailMarkupfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radRetailManual As System.Windows.Forms.RadioButton
    Friend WithEvents tabSummer As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSummerPercentage As System.Windows.Forms.TextBox
    Friend WithEvents grpSummerStaffMethod As System.Windows.Forms.GroupBox
    Friend WithEvents radSummerMarginfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radSummerMarkupfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radSummerManual As System.Windows.Forms.RadioButton
    Friend WithEvents tabResident As System.Windows.Forms.TabPage
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents radSummerMarkdownfromRetail As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtResidentPercentage As System.Windows.Forms.TextBox
    Friend WithEvents grpResidentStaffMethod As System.Windows.Forms.GroupBox
    Friend WithEvents radResidentMarkdownfromRetail As System.Windows.Forms.RadioButton
    Friend WithEvents radResidentMarginfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radResidentMarkupfromCost As System.Windows.Forms.RadioButton
    Friend WithEvents radResidentManual As System.Windows.Forms.RadioButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnLabels As System.Windows.Forms.Button
    Friend WithEvents txtInventoryID As System.Windows.Forms.TextBox
    Friend WithEvents txtListMthd As System.Windows.Forms.TextBox
    Friend WithEvents txtSummerMthd As System.Windows.Forms.TextBox
    Friend WithEvents txtResidentMthd As System.Windows.Forms.TextBox
    Friend WithEvents txtCost As CurrencyTextBox.CurrencyTextBox
    Friend WithEvents txtListPrice As CurrencyTextBox.CurrencyTextBox
    Friend WithEvents txtSummerStaffPrice As CurrencyTextBox.CurrencyTextBox
    Friend WithEvents txtResidentStaffPrice As CurrencyTextBox.CurrencyTextBox
    Friend WithEvents btnAdjustQty As System.Windows.Forms.Button
    Friend WithEvents lblInvLevel As System.Windows.Forms.Label
End Class
