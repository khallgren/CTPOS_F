<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaleDetailLookUp
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grpParameters = New System.Windows.Forms.GroupBox
        Me.txtCC = New System.Windows.Forms.MaskedTextBox
        Me.lblCC = New System.Windows.Forms.Label
        Me.txtSaleID = New System.Windows.Forms.MaskedTextBox
        Me.lblSaleID = New System.Windows.Forms.Label
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.txtExpDate = New System.Windows.Forms.MaskedTextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.txtSaleTotal = New System.Windows.Forms.TextBox
        Me.lblSaleTotal = New System.Windows.Forms.Label
        Me.txtTax = New System.Windows.Forms.TextBox
        Me.lblTax = New System.Windows.Forms.Label
        Me.grdSaleDetails = New System.Windows.Forms.DataGridView
        Me.txtStaffCharge = New System.Windows.Forms.TextBox
        Me.txtDeptCharge = New System.Windows.Forms.TextBox
        Me.txtZdOut = New System.Windows.Forms.TextBox
        Me.lblZdOut = New System.Windows.Forms.Label
        Me.lblDeptCharge = New System.Windows.Forms.Label
        Me.lblStaffCharge = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.lblZip = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.lblPhone = New System.Windows.Forms.Label
        Me.txtAuthNum = New System.Windows.Forms.TextBox
        Me.lblAuthNum = New System.Windows.Forms.Label
        Me.lblCCExpiryDate = New System.Windows.Forms.Label
        Me.txtCCNumber = New System.Windows.Forms.TextBox
        Me.lblCCNumber = New System.Windows.Forms.Label
        Me.chk4CCExpert = New System.Windows.Forms.CheckBox
        Me.lblMvCCExpert = New System.Windows.Forms.Label
        Me.txtCheckWriter = New System.Windows.Forms.TextBox
        Me.lblCheckWriter = New System.Windows.Forms.Label
        Me.txtTransactionID = New System.Windows.Forms.TextBox
        Me.lblTransactionID = New System.Windows.Forms.Label
        Me.txtPaymentType = New System.Windows.Forms.TextBox
        Me.lblPaymentType = New System.Windows.Forms.Label
        Me.txtRegistrationID = New System.Windows.Forms.TextBox
        Me.lblRegistrationID = New System.Windows.Forms.Label
        Me.txtCamperID = New System.Windows.Forms.TextBox
        Me.lblCamperID = New System.Windows.Forms.Label
        Me.txtSaleType = New System.Windows.Forms.TextBox
        Me.lblSaleType = New System.Windows.Forms.Label
        Me.txtWorkStationID = New System.Windows.Forms.TextBox
        Me.lblWorkStationID = New System.Windows.Forms.Label
        Me.txtClerk = New System.Windows.Forms.TextBox
        Me.lblClerk = New System.Windows.Forms.Label
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.lblStore = New System.Windows.Forms.Label
        Me.txtSaleDate = New System.Windows.Forms.TextBox
        Me.lblSaleDate = New System.Windows.Forms.Label
        Me.txtSaleIdDetails = New System.Windows.Forms.TextBox
        Me.lblSaleIdDeatails = New System.Windows.Forms.Label
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnUpdate = New System.Windows.Forms.DataGridViewButtonColumn
        Me.SaleDetailID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpParameters.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        CType(Me.grdSaleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpParameters
        '
        Me.grpParameters.Controls.Add(Me.txtCC)
        Me.grpParameters.Controls.Add(Me.lblCC)
        Me.grpParameters.Controls.Add(Me.txtSaleID)
        Me.grpParameters.Controls.Add(Me.lblSaleID)
        Me.grpParameters.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpParameters.Location = New System.Drawing.Point(4, 0)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(817, 38)
        Me.grpParameters.TabIndex = 0
        Me.grpParameters.TabStop = False
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(552, 12)
        Me.txtCC.Mask = "00000000000000000000000000000000000000000000"
        Me.txtCC.Name = "txtCC"
        Me.txtCC.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCC.Size = New System.Drawing.Size(193, 20)
        Me.txtCC.TabIndex = 3
        '
        'lblCC
        '
        Me.lblCC.AutoSize = True
        Me.lblCC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCC.Location = New System.Drawing.Point(477, 13)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.Size = New System.Drawing.Size(82, 16)
        Me.lblCC.TabIndex = 2
        Me.lblCC.Text = "Find CC #  : "
        '
        'txtSaleID
        '
        Me.txtSaleID.Location = New System.Drawing.Point(188, 12)
        Me.txtSaleID.Mask = "0000000000000000000000000000000000"
        Me.txtSaleID.Name = "txtSaleID"
        Me.txtSaleID.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtSaleID.Size = New System.Drawing.Size(212, 20)
        Me.txtSaleID.TabIndex = 1
        '
        'lblSaleID
        '
        Me.lblSaleID.AutoSize = True
        Me.lblSaleID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaleID.Location = New System.Drawing.Point(77, 13)
        Me.lblSaleID.Name = "lblSaleID"
        Me.lblSaleID.Size = New System.Drawing.Size(107, 16)
        Me.lblSaleID.TabIndex = 0
        Me.lblSaleID.Text = "Find By Sale ID : "
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.txtExpDate)
        Me.grpDetails.Controls.Add(Me.btnSave)
        Me.grpDetails.Controls.Add(Me.btnEdit)
        Me.grpDetails.Controls.Add(Me.txtSaleTotal)
        Me.grpDetails.Controls.Add(Me.lblSaleTotal)
        Me.grpDetails.Controls.Add(Me.txtTax)
        Me.grpDetails.Controls.Add(Me.lblTax)
        Me.grpDetails.Controls.Add(Me.grdSaleDetails)
        Me.grpDetails.Controls.Add(Me.txtStaffCharge)
        Me.grpDetails.Controls.Add(Me.txtDeptCharge)
        Me.grpDetails.Controls.Add(Me.txtZdOut)
        Me.grpDetails.Controls.Add(Me.lblZdOut)
        Me.grpDetails.Controls.Add(Me.lblDeptCharge)
        Me.grpDetails.Controls.Add(Me.lblStaffCharge)
        Me.grpDetails.Controls.Add(Me.txtZip)
        Me.grpDetails.Controls.Add(Me.lblZip)
        Me.grpDetails.Controls.Add(Me.txtPhone)
        Me.grpDetails.Controls.Add(Me.lblPhone)
        Me.grpDetails.Controls.Add(Me.txtAuthNum)
        Me.grpDetails.Controls.Add(Me.lblAuthNum)
        Me.grpDetails.Controls.Add(Me.lblCCExpiryDate)
        Me.grpDetails.Controls.Add(Me.txtCCNumber)
        Me.grpDetails.Controls.Add(Me.lblCCNumber)
        Me.grpDetails.Controls.Add(Me.chk4CCExpert)
        Me.grpDetails.Controls.Add(Me.lblMvCCExpert)
        Me.grpDetails.Controls.Add(Me.txtCheckWriter)
        Me.grpDetails.Controls.Add(Me.lblCheckWriter)
        Me.grpDetails.Controls.Add(Me.txtTransactionID)
        Me.grpDetails.Controls.Add(Me.lblTransactionID)
        Me.grpDetails.Controls.Add(Me.txtPaymentType)
        Me.grpDetails.Controls.Add(Me.lblPaymentType)
        Me.grpDetails.Controls.Add(Me.txtRegistrationID)
        Me.grpDetails.Controls.Add(Me.lblRegistrationID)
        Me.grpDetails.Controls.Add(Me.txtCamperID)
        Me.grpDetails.Controls.Add(Me.lblCamperID)
        Me.grpDetails.Controls.Add(Me.txtSaleType)
        Me.grpDetails.Controls.Add(Me.lblSaleType)
        Me.grpDetails.Controls.Add(Me.txtWorkStationID)
        Me.grpDetails.Controls.Add(Me.lblWorkStationID)
        Me.grpDetails.Controls.Add(Me.txtClerk)
        Me.grpDetails.Controls.Add(Me.lblClerk)
        Me.grpDetails.Controls.Add(Me.txtStore)
        Me.grpDetails.Controls.Add(Me.lblStore)
        Me.grpDetails.Controls.Add(Me.txtSaleDate)
        Me.grpDetails.Controls.Add(Me.lblSaleDate)
        Me.grpDetails.Controls.Add(Me.txtSaleIdDetails)
        Me.grpDetails.Controls.Add(Me.lblSaleIdDeatails)
        Me.grpDetails.Location = New System.Drawing.Point(4, 44)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(817, 463)
        Me.grpDetails.TabIndex = 1
        Me.grpDetails.TabStop = False
        Me.grpDetails.Visible = False
        '
        'txtExpDate
        '
        Me.txtExpDate.Enabled = False
        Me.txtExpDate.Location = New System.Drawing.Point(131, 305)
        Me.txtExpDate.Mask = "0000"
        Me.txtExpDate.Name = "txtExpDate"
        Me.txtExpDate.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtExpDate.Size = New System.Drawing.Size(164, 20)
        Me.txtExpDate.TabIndex = 48
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(682, 391)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(116, 24)
        Me.btnSave.TabIndex = 47
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(682, 392)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(116, 23)
        Me.btnEdit.TabIndex = 45
        Me.btnEdit.Text = "Edit CC Info"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtSaleTotal
        '
        Me.txtSaleTotal.Location = New System.Drawing.Point(682, 328)
        Me.txtSaleTotal.Name = "txtSaleTotal"
        Me.txtSaleTotal.ReadOnly = True
        Me.txtSaleTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtSaleTotal.TabIndex = 44
        '
        'lblSaleTotal
        '
        Me.lblSaleTotal.AutoSize = True
        Me.lblSaleTotal.Location = New System.Drawing.Point(611, 331)
        Me.lblSaleTotal.Name = "lblSaleTotal"
        Me.lblSaleTotal.Size = New System.Drawing.Size(61, 13)
        Me.lblSaleTotal.TabIndex = 43
        Me.lblSaleTotal.Text = "Sale Total :"
        '
        'txtTax
        '
        Me.txtTax.Location = New System.Drawing.Point(682, 305)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.ReadOnly = True
        Me.txtTax.Size = New System.Drawing.Size(129, 20)
        Me.txtTax.TabIndex = 42
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Location = New System.Drawing.Point(611, 308)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(31, 13)
        Me.lblTax.TabIndex = 41
        Me.lblTax.Text = "Tax :"
        '
        'grdSaleDetails
        '
        Me.grdSaleDetails.AllowUserToAddRows = False
        Me.grdSaleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSaleDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemName, Me.Qty, Me.Price, Me.Tax, Me.Total, Me.BtnUpdate, Me.SaleDetailID})
        Me.grdSaleDetails.Location = New System.Drawing.Point(302, 13)
        Me.grdSaleDetails.Name = "grdSaleDetails"
        Me.grdSaleDetails.Size = New System.Drawing.Size(515, 285)
        Me.grdSaleDetails.TabIndex = 40
        '
        'txtStaffCharge
        '
        Me.txtStaffCharge.Location = New System.Drawing.Point(131, 397)
        Me.txtStaffCharge.Name = "txtStaffCharge"
        Me.txtStaffCharge.ReadOnly = True
        Me.txtStaffCharge.Size = New System.Drawing.Size(164, 20)
        Me.txtStaffCharge.TabIndex = 39
        '
        'txtDeptCharge
        '
        Me.txtDeptCharge.Location = New System.Drawing.Point(131, 420)
        Me.txtDeptCharge.Name = "txtDeptCharge"
        Me.txtDeptCharge.ReadOnly = True
        Me.txtDeptCharge.Size = New System.Drawing.Size(164, 20)
        Me.txtDeptCharge.TabIndex = 38
        '
        'txtZdOut
        '
        Me.txtZdOut.Location = New System.Drawing.Point(131, 443)
        Me.txtZdOut.Name = "txtZdOut"
        Me.txtZdOut.ReadOnly = True
        Me.txtZdOut.Size = New System.Drawing.Size(164, 20)
        Me.txtZdOut.TabIndex = 37
        '
        'lblZdOut
        '
        Me.lblZdOut.AutoSize = True
        Me.lblZdOut.Location = New System.Drawing.Point(6, 443)
        Me.lblZdOut.Name = "lblZdOut"
        Me.lblZdOut.Size = New System.Drawing.Size(46, 13)
        Me.lblZdOut.TabIndex = 36
        Me.lblZdOut.Text = "Zd Out :"
        '
        'lblDeptCharge
        '
        Me.lblDeptCharge.AutoSize = True
        Me.lblDeptCharge.Location = New System.Drawing.Point(6, 420)
        Me.lblDeptCharge.Name = "lblDeptCharge"
        Me.lblDeptCharge.Size = New System.Drawing.Size(73, 13)
        Me.lblDeptCharge.TabIndex = 35
        Me.lblDeptCharge.Text = "Dept Charge :"
        '
        'lblStaffCharge
        '
        Me.lblStaffCharge.AutoSize = True
        Me.lblStaffCharge.Location = New System.Drawing.Point(6, 397)
        Me.lblStaffCharge.Name = "lblStaffCharge"
        Me.lblStaffCharge.Size = New System.Drawing.Size(72, 13)
        Me.lblStaffCharge.TabIndex = 34
        Me.lblStaffCharge.Text = "Staff Charge :"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(131, 374)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = True
        Me.txtZip.Size = New System.Drawing.Size(164, 20)
        Me.txtZip.TabIndex = 33
        '
        'lblZip
        '
        Me.lblZip.AutoSize = True
        Me.lblZip.Location = New System.Drawing.Point(6, 377)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(28, 13)
        Me.lblZip.TabIndex = 32
        Me.lblZip.Text = "Zip :"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(131, 351)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(164, 20)
        Me.txtPhone.TabIndex = 31
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(6, 354)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(50, 13)
        Me.lblPhone.TabIndex = 30
        Me.lblPhone.Text = "Phone  : "
        '
        'txtAuthNum
        '
        Me.txtAuthNum.Location = New System.Drawing.Point(131, 328)
        Me.txtAuthNum.Name = "txtAuthNum"
        Me.txtAuthNum.ReadOnly = True
        Me.txtAuthNum.Size = New System.Drawing.Size(164, 20)
        Me.txtAuthNum.TabIndex = 29
        '
        'lblAuthNum
        '
        Me.lblAuthNum.AutoSize = True
        Me.lblAuthNum.Location = New System.Drawing.Point(6, 331)
        Me.lblAuthNum.Name = "lblAuthNum"
        Me.lblAuthNum.Size = New System.Drawing.Size(124, 13)
        Me.lblAuthNum.TabIndex = 28
        Me.lblAuthNum.Text = "Authentication Number : "
        '
        'lblCCExpiryDate
        '
        Me.lblCCExpiryDate.AutoSize = True
        Me.lblCCExpiryDate.Location = New System.Drawing.Point(6, 308)
        Me.lblCCExpiryDate.Name = "lblCCExpiryDate"
        Me.lblCCExpiryDate.Size = New System.Drawing.Size(77, 13)
        Me.lblCCExpiryDate.TabIndex = 26
        Me.lblCCExpiryDate.Text = "CC Exp Date : "
        '
        'txtCCNumber
        '
        Me.txtCCNumber.Enabled = False
        Me.txtCCNumber.Location = New System.Drawing.Point(131, 282)
        Me.txtCCNumber.Name = "txtCCNumber"
        Me.txtCCNumber.Size = New System.Drawing.Size(164, 20)
        Me.txtCCNumber.TabIndex = 25
        '
        'lblCCNumber
        '
        Me.lblCCNumber.AutoSize = True
        Me.lblCCNumber.Location = New System.Drawing.Point(6, 285)
        Me.lblCCNumber.Name = "lblCCNumber"
        Me.lblCCNumber.Size = New System.Drawing.Size(70, 13)
        Me.lblCCNumber.TabIndex = 24
        Me.lblCCNumber.Text = "CC Number : "
        '
        'chk4CCExpert
        '
        Me.chk4CCExpert.AutoSize = True
        Me.chk4CCExpert.Enabled = False
        Me.chk4CCExpert.Location = New System.Drawing.Point(133, 266)
        Me.chk4CCExpert.Name = "chk4CCExpert"
        Me.chk4CCExpert.Size = New System.Drawing.Size(15, 14)
        Me.chk4CCExpert.TabIndex = 23
        Me.chk4CCExpert.UseVisualStyleBackColor = True
        '
        'lblMvCCExpert
        '
        Me.lblMvCCExpert.AutoSize = True
        Me.lblMvCCExpert.Location = New System.Drawing.Point(8, 266)
        Me.lblMvCCExpert.Name = "lblMvCCExpert"
        Me.lblMvCCExpert.Size = New System.Drawing.Size(105, 13)
        Me.lblMvCCExpert.TabIndex = 22
        Me.lblMvCCExpert.Text = "Move 4 CC Expert  : "
        '
        'txtCheckWriter
        '
        Me.txtCheckWriter.Location = New System.Drawing.Point(133, 243)
        Me.txtCheckWriter.Name = "txtCheckWriter"
        Me.txtCheckWriter.ReadOnly = True
        Me.txtCheckWriter.Size = New System.Drawing.Size(162, 20)
        Me.txtCheckWriter.TabIndex = 21
        '
        'lblCheckWriter
        '
        Me.lblCheckWriter.AutoSize = True
        Me.lblCheckWriter.Location = New System.Drawing.Point(8, 246)
        Me.lblCheckWriter.Name = "lblCheckWriter"
        Me.lblCheckWriter.Size = New System.Drawing.Size(78, 13)
        Me.lblCheckWriter.TabIndex = 20
        Me.lblCheckWriter.Text = "Check Writer : "
        '
        'txtTransactionID
        '
        Me.txtTransactionID.Location = New System.Drawing.Point(133, 197)
        Me.txtTransactionID.Name = "txtTransactionID"
        Me.txtTransactionID.ReadOnly = True
        Me.txtTransactionID.Size = New System.Drawing.Size(162, 20)
        Me.txtTransactionID.TabIndex = 19
        '
        'lblTransactionID
        '
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Location = New System.Drawing.Point(6, 200)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(86, 13)
        Me.lblTransactionID.TabIndex = 18
        Me.lblTransactionID.Text = "Transaction ID : "
        '
        'txtPaymentType
        '
        Me.txtPaymentType.Location = New System.Drawing.Point(133, 220)
        Me.txtPaymentType.Name = "txtPaymentType"
        Me.txtPaymentType.ReadOnly = True
        Me.txtPaymentType.Size = New System.Drawing.Size(162, 20)
        Me.txtPaymentType.TabIndex = 17
        '
        'lblPaymentType
        '
        Me.lblPaymentType.AutoSize = True
        Me.lblPaymentType.Location = New System.Drawing.Point(8, 223)
        Me.lblPaymentType.Name = "lblPaymentType"
        Me.lblPaymentType.Size = New System.Drawing.Size(84, 13)
        Me.lblPaymentType.TabIndex = 16
        Me.lblPaymentType.Text = "Payment Type : "
        '
        'txtRegistrationID
        '
        Me.txtRegistrationID.Location = New System.Drawing.Point(133, 174)
        Me.txtRegistrationID.Name = "txtRegistrationID"
        Me.txtRegistrationID.ReadOnly = True
        Me.txtRegistrationID.Size = New System.Drawing.Size(162, 20)
        Me.txtRegistrationID.TabIndex = 15
        '
        'lblRegistrationID
        '
        Me.lblRegistrationID.AutoSize = True
        Me.lblRegistrationID.Location = New System.Drawing.Point(6, 177)
        Me.lblRegistrationID.Name = "lblRegistrationID"
        Me.lblRegistrationID.Size = New System.Drawing.Size(86, 13)
        Me.lblRegistrationID.TabIndex = 14
        Me.lblRegistrationID.Text = "Registration ID : "
        '
        'txtCamperID
        '
        Me.txtCamperID.Location = New System.Drawing.Point(133, 151)
        Me.txtCamperID.Name = "txtCamperID"
        Me.txtCamperID.ReadOnly = True
        Me.txtCamperID.Size = New System.Drawing.Size(162, 20)
        Me.txtCamperID.TabIndex = 13
        '
        'lblCamperID
        '
        Me.lblCamperID.AutoSize = True
        Me.lblCamperID.Location = New System.Drawing.Point(6, 154)
        Me.lblCamperID.Name = "lblCamperID"
        Me.lblCamperID.Size = New System.Drawing.Size(63, 13)
        Me.lblCamperID.TabIndex = 12
        Me.lblCamperID.Text = "Camper ID :"
        '
        'txtSaleType
        '
        Me.txtSaleType.Location = New System.Drawing.Point(133, 128)
        Me.txtSaleType.Name = "txtSaleType"
        Me.txtSaleType.ReadOnly = True
        Me.txtSaleType.Size = New System.Drawing.Size(162, 20)
        Me.txtSaleType.TabIndex = 11
        '
        'lblSaleType
        '
        Me.lblSaleType.AutoSize = True
        Me.lblSaleType.Location = New System.Drawing.Point(8, 131)
        Me.lblSaleType.Name = "lblSaleType"
        Me.lblSaleType.Size = New System.Drawing.Size(61, 13)
        Me.lblSaleType.TabIndex = 10
        Me.lblSaleType.Text = "Sale Type :"
        '
        'txtWorkStationID
        '
        Me.txtWorkStationID.Location = New System.Drawing.Point(133, 105)
        Me.txtWorkStationID.Name = "txtWorkStationID"
        Me.txtWorkStationID.ReadOnly = True
        Me.txtWorkStationID.Size = New System.Drawing.Size(162, 20)
        Me.txtWorkStationID.TabIndex = 9
        '
        'lblWorkStationID
        '
        Me.lblWorkStationID.AutoSize = True
        Me.lblWorkStationID.Location = New System.Drawing.Point(6, 108)
        Me.lblWorkStationID.Name = "lblWorkStationID"
        Me.lblWorkStationID.Size = New System.Drawing.Size(89, 13)
        Me.lblWorkStationID.TabIndex = 8
        Me.lblWorkStationID.Text = "Work Station ID :"
        '
        'txtClerk
        '
        Me.txtClerk.Location = New System.Drawing.Point(133, 82)
        Me.txtClerk.Name = "txtClerk"
        Me.txtClerk.ReadOnly = True
        Me.txtClerk.Size = New System.Drawing.Size(162, 20)
        Me.txtClerk.TabIndex = 7
        '
        'lblClerk
        '
        Me.lblClerk.AutoSize = True
        Me.lblClerk.Location = New System.Drawing.Point(6, 85)
        Me.lblClerk.Name = "lblClerk"
        Me.lblClerk.Size = New System.Drawing.Size(37, 13)
        Me.lblClerk.TabIndex = 6
        Me.lblClerk.Text = "Clerk :"
        '
        'txtStore
        '
        Me.txtStore.Location = New System.Drawing.Point(133, 59)
        Me.txtStore.Name = "txtStore"
        Me.txtStore.ReadOnly = True
        Me.txtStore.Size = New System.Drawing.Size(162, 20)
        Me.txtStore.TabIndex = 5
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Location = New System.Drawing.Point(6, 62)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(41, 13)
        Me.lblStore.TabIndex = 4
        Me.lblStore.Text = "Store : "
        '
        'txtSaleDate
        '
        Me.txtSaleDate.Location = New System.Drawing.Point(133, 36)
        Me.txtSaleDate.Name = "txtSaleDate"
        Me.txtSaleDate.ReadOnly = True
        Me.txtSaleDate.Size = New System.Drawing.Size(162, 20)
        Me.txtSaleDate.TabIndex = 3
        '
        'lblSaleDate
        '
        Me.lblSaleDate.AutoSize = True
        Me.lblSaleDate.Location = New System.Drawing.Point(6, 39)
        Me.lblSaleDate.Name = "lblSaleDate"
        Me.lblSaleDate.Size = New System.Drawing.Size(66, 13)
        Me.lblSaleDate.TabIndex = 2
        Me.lblSaleDate.Text = "Sale Date  : "
        '
        'txtSaleIdDetails
        '
        Me.txtSaleIdDetails.Location = New System.Drawing.Point(133, 13)
        Me.txtSaleIdDetails.Name = "txtSaleIdDetails"
        Me.txtSaleIdDetails.ReadOnly = True
        Me.txtSaleIdDetails.Size = New System.Drawing.Size(162, 20)
        Me.txtSaleIdDetails.TabIndex = 1
        '
        'lblSaleIdDeatails
        '
        Me.lblSaleIdDeatails.AutoSize = True
        Me.lblSaleIdDeatails.Location = New System.Drawing.Point(6, 16)
        Me.lblSaleIdDeatails.Name = "lblSaleIdDeatails"
        Me.lblSaleIdDeatails.Size = New System.Drawing.Size(51, 13)
        Me.lblSaleIdDeatails.TabIndex = 0
        Me.lblSaleIdDeatails.Text = "Sale ID : "
        '
        'ItemName
        '
        Me.ItemName.DataPropertyName = "ItemName"
        Me.ItemName.HeaderText = "Item"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 150
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 30
        '
        'Price
        '
        Me.Price.DataPropertyName = "Price"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Price.DefaultCellStyle = DataGridViewCellStyle1
        Me.Price.HeaderText = "Price / Ea."
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 60
        '
        'Tax
        '
        Me.Tax.DataPropertyName = "Tax"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Tax.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tax.HeaderText = "Tax"
        Me.Tax.Name = "Tax"
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle3
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 78
        '
        'BtnUpdate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.DefaultCellStyle = DataGridViewCellStyle4
        Me.BtnUpdate.HeaderText = ""
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.ToolTipText = "Update"
        Me.BtnUpdate.UseColumnTextForButtonValue = True
        Me.BtnUpdate.Visible = False
        Me.BtnUpdate.Width = 50
        '
        'SaleDetailID
        '
        Me.SaleDetailID.DataPropertyName = "SaleDetailID"
        Me.SaleDetailID.HeaderText = "SaleDetailID"
        Me.SaleDetailID.Name = "SaleDetailID"
        Me.SaleDetailID.Visible = False
        '
        'frmSaleDetailLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 514)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.grpParameters)
        Me.Name = "frmSaleDetailLookUp"
        Me.Text = "Sale Detail Look Up"
        Me.grpParameters.ResumeLayout(False)
        Me.grpParameters.PerformLayout()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        CType(Me.grdSaleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpParameters As System.Windows.Forms.GroupBox
    Friend WithEvents lblSaleID As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtStore As System.Windows.Forms.TextBox
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents txtSaleDate As System.Windows.Forms.TextBox
    Friend WithEvents lblSaleDate As System.Windows.Forms.Label
    Friend WithEvents txtSaleIdDetails As System.Windows.Forms.TextBox
    Friend WithEvents lblSaleIdDeatails As System.Windows.Forms.Label
    Friend WithEvents txtRegistrationID As System.Windows.Forms.TextBox
    Friend WithEvents lblRegistrationID As System.Windows.Forms.Label
    Friend WithEvents txtCamperID As System.Windows.Forms.TextBox
    Friend WithEvents lblCamperID As System.Windows.Forms.Label
    Friend WithEvents txtSaleType As System.Windows.Forms.TextBox
    Friend WithEvents lblSaleType As System.Windows.Forms.Label
    Friend WithEvents txtWorkStationID As System.Windows.Forms.TextBox
    Friend WithEvents lblWorkStationID As System.Windows.Forms.Label
    Friend WithEvents txtClerk As System.Windows.Forms.TextBox
    Friend WithEvents lblClerk As System.Windows.Forms.Label
    Friend WithEvents lblMvCCExpert As System.Windows.Forms.Label
    Friend WithEvents txtCheckWriter As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckWriter As System.Windows.Forms.Label
    Friend WithEvents txtTransactionID As System.Windows.Forms.TextBox
    Friend WithEvents lblTransactionID As System.Windows.Forms.Label
    Friend WithEvents txtPaymentType As System.Windows.Forms.TextBox
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents chk4CCExpert As System.Windows.Forms.CheckBox
    Friend WithEvents lblCCExpiryDate As System.Windows.Forms.Label
    Friend WithEvents lblCCNumber As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents lblZip As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtAuthNum As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthNum As System.Windows.Forms.Label
    Friend WithEvents txtStaffCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtDeptCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtZdOut As System.Windows.Forms.TextBox
    Friend WithEvents lblZdOut As System.Windows.Forms.Label
    Friend WithEvents lblDeptCharge As System.Windows.Forms.Label
    Friend WithEvents lblStaffCharge As System.Windows.Forms.Label
    Friend WithEvents grdSaleDetails As System.Windows.Forms.DataGridView
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtSaleTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblSaleTotal As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtCCNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtExpDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSaleID As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnUpdate As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SaleDetailID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
