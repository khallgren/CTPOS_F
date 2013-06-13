<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCraftSales
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbtAmount = New System.Windows.Forms.Label
        Me.lblBlkCode = New System.Windows.Forms.Label
        Me.cboBlockCode = New System.Windows.Forms.ComboBox
        Me.dtinputDate = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lbltxtTotal = New System.Windows.Forms.Label
        Me.grdCraftSales = New System.Windows.Forms.DataGridView
        Me.grpParameters = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnEnter = New System.Windows.Forms.Button
        Me.btnBlankSht = New System.Windows.Forms.Button
        Me.btnBalanceRpt = New System.Windows.Forms.Button
        Me.ttlMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttlUpdate = New System.Windows.Forms.ToolTip(Me.components)
        Me.fstName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnUpdate = New System.Windows.Forms.DataGridViewButtonColumn
        Me.SaleDetailID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCraftSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbtAmount
        '
        Me.lbtAmount.AutoSize = True
        Me.lbtAmount.Location = New System.Drawing.Point(28, 51)
        Me.lbtAmount.Name = "lbtAmount"
        Me.lbtAmount.Size = New System.Drawing.Size(36, 13)
        Me.lbtAmount.TabIndex = 9
        Me.lbtAmount.Text = "Date :"
        '
        'lblBlkCode
        '
        Me.lblBlkCode.AutoSize = True
        Me.lblBlkCode.Location = New System.Drawing.Point(24, 25)
        Me.lblBlkCode.Name = "lblBlkCode"
        Me.lblBlkCode.Size = New System.Drawing.Size(40, 13)
        Me.lblBlkCode.TabIndex = 8
        Me.lblBlkCode.Text = "Block :"
        '
        'cboBlockCode
        '
        Me.cboBlockCode.FormattingEnabled = True
        Me.cboBlockCode.Location = New System.Drawing.Point(70, 22)
        Me.cboBlockCode.Name = "cboBlockCode"
        Me.cboBlockCode.Size = New System.Drawing.Size(121, 21)
        Me.cboBlockCode.TabIndex = 7
        '
        'dtinputDate
        '
        Me.dtinputDate.CustomFormat = "dd/MM/yyyy"
        Me.dtinputDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtinputDate.Location = New System.Drawing.Point(70, 49)
        Me.dtinputDate.Name = "dtinputDate"
        Me.dtinputDate.Size = New System.Drawing.Size(121, 20)
        Me.dtinputDate.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.grdCraftSales)
        Me.Panel1.Location = New System.Drawing.Point(7, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 312)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.lbltxtTotal)
        Me.Panel2.Location = New System.Drawing.Point(5, 276)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(540, 27)
        Me.Panel2.TabIndex = 4
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(360, 4)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 16)
        Me.lblTotal.TabIndex = 3
        '
        'lbltxtTotal
        '
        Me.lbltxtTotal.AutoSize = True
        Me.lbltxtTotal.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtTotal.Location = New System.Drawing.Point(309, 4)
        Me.lbltxtTotal.Name = "lbltxtTotal"
        Me.lbltxtTotal.Size = New System.Drawing.Size(53, 16)
        Me.lbltxtTotal.TabIndex = 1
        Me.lbltxtTotal.Text = "Total :"
        Me.lbltxtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdCraftSales
        '
        Me.grdCraftSales.AllowUserToAddRows = False
        Me.grdCraftSales.AllowUserToDeleteRows = False
        Me.grdCraftSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCraftSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fstName, Me.lstName, Me.Total, Me.btnUpdate, Me.SaleDetailID, Me.BlockID, Me.dte})
        Me.grdCraftSales.Location = New System.Drawing.Point(3, 6)
        Me.grdCraftSales.Name = "grdCraftSales"
        Me.grdCraftSales.Size = New System.Drawing.Size(542, 266)
        Me.grdCraftSales.TabIndex = 0
        '
        'grpParameters
        '
        Me.grpParameters.Controls.Add(Me.btnRefresh)
        Me.grpParameters.Controls.Add(Me.btnEnter)
        Me.grpParameters.Controls.Add(Me.lblBlkCode)
        Me.grpParameters.Controls.Add(Me.cboBlockCode)
        Me.grpParameters.Controls.Add(Me.lbtAmount)
        Me.grpParameters.Controls.Add(Me.dtinputDate)
        Me.grpParameters.Location = New System.Drawing.Point(7, 1)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(550, 79)
        Me.grpParameters.TabIndex = 0
        Me.grpParameters.TabStop = False
        Me.grpParameters.Text = "Parameters"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(212, 32)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 16
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(429, 34)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(104, 27)
        Me.btnEnter.TabIndex = 15
        Me.btnEnter.Text = "Enter Craft Sales"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btnBlankSht
        '
        Me.btnBlankSht.Location = New System.Drawing.Point(309, 404)
        Me.btnBlankSht.Name = "btnBlankSht"
        Me.btnBlankSht.Size = New System.Drawing.Size(121, 30)
        Me.btnBlankSht.TabIndex = 16
        Me.btnBlankSht.Text = "Print Blank Sheets"
        Me.btnBlankSht.UseVisualStyleBackColor = True
        '
        'btnBalanceRpt
        '
        Me.btnBalanceRpt.Location = New System.Drawing.Point(436, 404)
        Me.btnBalanceRpt.Name = "btnBalanceRpt"
        Me.btnBalanceRpt.Size = New System.Drawing.Size(121, 30)
        Me.btnBalanceRpt.TabIndex = 17
        Me.btnBalanceRpt.Text = "Print Balance Reports"
        Me.btnBalanceRpt.UseVisualStyleBackColor = True
        '
        'ttlMain
        '
        Me.ttlMain.IsBalloon = True
        Me.ttlMain.ToolTipTitle = "Help !!!"
        '
        'fstName
        '
        Me.fstName.DataPropertyName = "fstName"
        Me.fstName.FillWeight = 165.0!
        Me.fstName.HeaderText = "First Name"
        Me.fstName.Name = "fstName"
        Me.fstName.ReadOnly = True
        Me.fstName.Width = 165
        '
        'lstName
        '
        Me.lstName.DataPropertyName = "lstName"
        Me.lstName.FillWeight = 175.0!
        Me.lstName.HeaderText = "Last Name"
        Me.lstName.Name = "lstName"
        Me.lstName.ReadOnly = True
        Me.lstName.Width = 165
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle1
        Me.Total.FillWeight = 150.0!
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.ToolTipText = "Click 'Update' Button to Modify. "
        Me.Total.Width = 70
        '
        'btnUpdate
        '
        Me.btnUpdate.HeaderText = ""
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.ToolTipText = "Update"
        Me.btnUpdate.UseColumnTextForButtonValue = True
        Me.btnUpdate.Width = 99
        '
        'SaleDetailID
        '
        Me.SaleDetailID.DataPropertyName = "SaleDetailID"
        Me.SaleDetailID.HeaderText = "SaleDetailID"
        Me.SaleDetailID.Name = "SaleDetailID"
        Me.SaleDetailID.Visible = False
        '
        'BlockID
        '
        Me.BlockID.DataPropertyName = "BlockID"
        Me.BlockID.HeaderText = "BlockID"
        Me.BlockID.Name = "BlockID"
        Me.BlockID.Visible = False
        '
        'dte
        '
        Me.dte.DataPropertyName = "dte"
        Me.dte.HeaderText = "dte"
        Me.dte.Name = "dte"
        Me.dte.Visible = False
        '
        'frmCraftSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 439)
        Me.Controls.Add(Me.btnBalanceRpt)
        Me.Controls.Add(Me.btnBlankSht)
        Me.Controls.Add(Me.grpParameters)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCraftSales"
        Me.Text = "Craft Sales"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdCraftSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpParameters.ResumeLayout(False)
        Me.grpParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbtAmount As System.Windows.Forms.Label
    Friend WithEvents lblBlkCode As System.Windows.Forms.Label
    Friend WithEvents cboBlockCode As System.Windows.Forms.ComboBox
    Friend WithEvents dtinputDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpParameters As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnBlankSht As System.Windows.Forms.Button
    Friend WithEvents btnBalanceRpt As System.Windows.Forms.Button
    Friend WithEvents grdCraftSales As System.Windows.Forms.DataGridView
    Friend WithEvents lbltxtTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ttlMain As System.Windows.Forms.ToolTip
    Friend WithEvents ttlUpdate As System.Windows.Forms.ToolTip
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents fstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUpdate As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SaleDetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dte As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
