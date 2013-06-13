<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReviewSales
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
        Me.WinPanel1 = New Xceed.Editors.WinPanel
        Me.grprvSalesPhoneno = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRefreshRvSales = New System.Windows.Forms.Button
        Me.txtPhone = New System.Windows.Forms.MaskedTextBox
        Me.grpRevSalesOption = New System.Windows.Forms.GroupBox
        Me.chkZoutOnly = New System.Windows.Forms.CheckBox
        Me.chkWSOnly = New System.Windows.Forms.CheckBox
        Me.chkClerkOnly = New System.Windows.Forms.CheckBox
        Me.chkTodayOnly = New System.Windows.Forms.CheckBox
        Me.dataRowTemplate1 = New Xceed.Grid.DataRow
        Me.celldataRowTemplate1Column1 = New Xceed.Grid.DataCell
        Me.celldataRowTemplate1Column2 = New Xceed.Grid.DataCell
        Me.celldataRowTemplate1Column3 = New Xceed.Grid.DataCell
        Me.celldataRowTemplate1Column4 = New Xceed.Grid.DataCell
        Me.celldataRowTemplate1Column5 = New Xceed.Grid.DataCell
        Me.Column1 = New Xceed.Grid.Column
        Me.Column2 = New Xceed.Grid.Column
        Me.Column3 = New Xceed.Grid.Column
        Me.Column4 = New Xceed.Grid.Column
        Me.Column5 = New Xceed.Grid.Column
        Me.Column6 = New Xceed.Grid.Column
        Me.celldataRowTemplate1Column6 = New Xceed.Grid.DataCell
        Me.GroupByRow1 = New Xceed.Grid.GroupByRow
        Me.ColumnManagerRow1 = New Xceed.Grid.ColumnManagerRow
        Me.cellColumnManagerRow1Column7 = New Xceed.Grid.ColumnManagerCell
        Me.dataRowTemplate2 = New Xceed.Grid.DataRow
        Me.celldataRowTemplate2Column7 = New Xceed.Grid.DataCell
        Me.Column7 = New Xceed.Grid.Column
        Me.WinPanel2 = New Xceed.Editors.WinPanel
        Me.grdRevSales = New System.Windows.Forms.DataGridView
        Me.SaleId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaleDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Receipt = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Void = New System.Windows.Forms.DataGridViewButtonColumn
        Me.strPhone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dteZdout = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lngClerkID1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lngWSID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WinPanel1.SuspendLayout()
        Me.grprvSalesPhoneno.SuspendLayout()
        Me.grpRevSalesOption.SuspendLayout()
        CType(Me.dataRowTemplate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColumnManagerRow1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataRowTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WinPanel2.SuspendLayout()
        CType(Me.grdRevSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WinPanel1
        '
        Me.WinPanel1.BorderStyle = Xceed.Editors.EnhancedBorderStyle.FixedSingle
        Me.WinPanel1.Controls.Add(Me.grprvSalesPhoneno)
        Me.WinPanel1.Controls.Add(Me.grpRevSalesOption)
        Me.WinPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.WinPanel1.Location = New System.Drawing.Point(5, 3)
        Me.WinPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.WinPanel1.Name = "WinPanel1"
        Me.WinPanel1.Size = New System.Drawing.Size(796, 139)
        Me.WinPanel1.TabIndex = 2
        Me.WinPanel1.UIStyle = Xceed.UI.UIStyle.WindowsXP
        '
        'grprvSalesPhoneno
        '
        Me.grprvSalesPhoneno.Controls.Add(Me.Label1)
        Me.grprvSalesPhoneno.Controls.Add(Me.btnRefreshRvSales)
        Me.grprvSalesPhoneno.Controls.Add(Me.txtPhone)
        Me.grprvSalesPhoneno.Location = New System.Drawing.Point(404, 5)
        Me.grprvSalesPhoneno.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grprvSalesPhoneno.Name = "grprvSalesPhoneno"
        Me.grprvSalesPhoneno.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grprvSalesPhoneno.Size = New System.Drawing.Size(386, 129)
        Me.grprvSalesPhoneno.TabIndex = 4
        Me.grprvSalesPhoneno.TabStop = False
        Me.grprvSalesPhoneno.Text = "Phone Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Phone Number :"
        '
        'btnRefreshRvSales
        '
        Me.btnRefreshRvSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshRvSales.Image = Global.CTPOS_F.My.Resources.Resources.refresh_16x16
        Me.btnRefreshRvSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshRvSales.Location = New System.Drawing.Point(294, 93)
        Me.btnRefreshRvSales.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnRefreshRvSales.Name = "btnRefreshRvSales"
        Me.btnRefreshRvSales.Size = New System.Drawing.Size(84, 27)
        Me.btnRefreshRvSales.TabIndex = 0
        Me.btnRefreshRvSales.Text = "Refresh"
        Me.btnRefreshRvSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefreshRvSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefreshRvSales.UseVisualStyleBackColor = True
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(126, 20)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPhone.Mask = "0000000000"
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(181, 22)
        Me.txtPhone.TabIndex = 1
        '
        'grpRevSalesOption
        '
        Me.grpRevSalesOption.Controls.Add(Me.chkZoutOnly)
        Me.grpRevSalesOption.Controls.Add(Me.chkWSOnly)
        Me.grpRevSalesOption.Controls.Add(Me.chkClerkOnly)
        Me.grpRevSalesOption.Controls.Add(Me.chkTodayOnly)
        Me.grpRevSalesOption.Location = New System.Drawing.Point(12, 3)
        Me.grpRevSalesOption.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpRevSalesOption.Name = "grpRevSalesOption"
        Me.grpRevSalesOption.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpRevSalesOption.Size = New System.Drawing.Size(384, 131)
        Me.grpRevSalesOption.TabIndex = 3
        Me.grpRevSalesOption.TabStop = False
        Me.grpRevSalesOption.Text = "Option"
        '
        'chkZoutOnly
        '
        Me.chkZoutOnly.AutoSize = True
        Me.chkZoutOnly.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.chkZoutOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkZoutOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkZoutOnly.Location = New System.Drawing.Point(40, 102)
        Me.chkZoutOnly.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkZoutOnly.Name = "chkZoutOnly"
        Me.chkZoutOnly.Size = New System.Drawing.Size(96, 20)
        Me.chkZoutOnly.TabIndex = 6
        Me.chkZoutOnly.Text = "Z'd Out Only"
        Me.chkZoutOnly.UseVisualStyleBackColor = True
        '
        'chkWSOnly
        '
        Me.chkWSOnly.AutoSize = True
        Me.chkWSOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkWSOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWSOnly.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWSOnly.Location = New System.Drawing.Point(40, 21)
        Me.chkWSOnly.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkWSOnly.Name = "chkWSOnly"
        Me.chkWSOnly.Size = New System.Drawing.Size(148, 20)
        Me.chkWSOnly.TabIndex = 3
        Me.chkWSOnly.Text = "This workstation only"
        Me.chkWSOnly.UseVisualStyleBackColor = True
        '
        'chkClerkOnly
        '
        Me.chkClerkOnly.AutoSize = True
        Me.chkClerkOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkClerkOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClerkOnly.Location = New System.Drawing.Point(40, 49)
        Me.chkClerkOnly.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkClerkOnly.Name = "chkClerkOnly"
        Me.chkClerkOnly.Size = New System.Drawing.Size(112, 20)
        Me.chkClerkOnly.TabIndex = 4
        Me.chkClerkOnly.Text = "This Clerk only"
        Me.chkClerkOnly.UseVisualStyleBackColor = True
        '
        'chkTodayOnly
        '
        Me.chkTodayOnly.AutoSize = True
        Me.chkTodayOnly.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.chkTodayOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTodayOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodayOnly.Location = New System.Drawing.Point(40, 74)
        Me.chkTodayOnly.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkTodayOnly.Name = "chkTodayOnly"
        Me.chkTodayOnly.Size = New System.Drawing.Size(94, 20)
        Me.chkTodayOnly.TabIndex = 5
        Me.chkTodayOnly.Text = "Today Only"
        Me.chkTodayOnly.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.SortDirection = Xceed.Grid.SortDirection.Ascending
        Me.Column1.VisibleIndex = 0
        Me.Column1.Initialize("Column1", GetType(String))
        '
        'Column2
        '
        Me.Column2.SortDirection = Xceed.Grid.SortDirection.None
        Me.Column2.VisibleIndex = 2
        Me.Column2.Initialize("Column2", GetType(String))
        '
        'Column3
        '
        Me.Column3.SortDirection = Xceed.Grid.SortDirection.None
        Me.Column3.VisibleIndex = 1
        Me.Column3.Initialize("Column3", GetType(String))
        '
        'Column4
        '
        Me.Column4.SortDirection = Xceed.Grid.SortDirection.None
        Me.Column4.VisibleIndex = 3
        Me.Column4.Initialize("Column4", GetType(String))
        '
        'Column5
        '
        Me.Column5.SortDirection = Xceed.Grid.SortDirection.None
        Me.Column5.VisibleIndex = 4
        Me.Column5.Initialize("Column5", GetType(String))
        '
        'Column6
        '
        Me.Column6.SortDirection = Xceed.Grid.SortDirection.None
        Me.Column6.VisibleIndex = 5
        Me.Column6.Initialize("Column6", GetType(String))
        '
        'Column7
        '
        Me.Column7.VisibleIndex = 0
        Me.Column7.Initialize("Column7", GetType(String))
        '
        'WinPanel2
        '
        Me.WinPanel2.BorderStyle = Xceed.Editors.EnhancedBorderStyle.Fixed3D
        Me.WinPanel2.Controls.Add(Me.grdRevSales)
        Me.WinPanel2.Location = New System.Drawing.Point(5, 148)
        Me.WinPanel2.Name = "WinPanel2"
        Me.WinPanel2.Size = New System.Drawing.Size(796, 317)
        Me.WinPanel2.TabIndex = 3
        Me.WinPanel2.UIStyle = Xceed.UI.UIStyle.WindowsXP
        '
        'grdRevSales
        '
        Me.grdRevSales.AllowUserToAddRows = False
        Me.grdRevSales.AllowUserToDeleteRows = False
        Me.grdRevSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdRevSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SaleId, Me.SaleDate, Me.PaymentType, Me.Total, Me.Receipt, Me.Void, Me.strPhone, Me.TransactionID, Me.dteZdout, Me.lngClerkID1, Me.lngWSID})
        Me.grdRevSales.Location = New System.Drawing.Point(5, 3)
        Me.grdRevSales.MultiSelect = False
        Me.grdRevSales.Name = "grdRevSales"
        Me.grdRevSales.ReadOnly = True
        Me.grdRevSales.ShowEditingIcon = False
        Me.grdRevSales.Size = New System.Drawing.Size(784, 312)
        Me.grdRevSales.TabIndex = 0
        '
        'SaleId
        '
        Me.SaleId.DataPropertyName = "SaleId"
        Me.SaleId.HeaderText = "Sales Id"
        Me.SaleId.Name = "SaleId"
        Me.SaleId.ReadOnly = True
        '
        'SaleDate
        '
        Me.SaleDate.DataPropertyName = "SaleDate"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.SaleDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.SaleDate.HeaderText = "Sales Date"
        Me.SaleDate.Name = "SaleDate"
        Me.SaleDate.ReadOnly = True
        Me.SaleDate.Width = 90
        '
        'PaymentType
        '
        Me.PaymentType.DataPropertyName = "PaymentType"
        Me.PaymentType.HeaderText = "Payment Type"
        Me.PaymentType.Name = "PaymentType"
        Me.PaymentType.ReadOnly = True
        Me.PaymentType.Width = 250
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle2
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 150
        '
        'Receipt
        '
        Me.Receipt.HeaderText = ""
        Me.Receipt.Name = "Receipt"
        Me.Receipt.ReadOnly = True
        Me.Receipt.Text = "Receipt"
        Me.Receipt.UseColumnTextForButtonValue = True
        Me.Receipt.Width = 90
        '
        'Void
        '
        Me.Void.HeaderText = ""
        Me.Void.Name = "Void"
        Me.Void.ReadOnly = True
        Me.Void.Text = "Void"
        Me.Void.UseColumnTextForButtonValue = True
        Me.Void.Width = 60
        '
        'strPhone
        '
        Me.strPhone.DataPropertyName = "strPhone"
        Me.strPhone.HeaderText = "Phone"
        Me.strPhone.Name = "strPhone"
        Me.strPhone.ReadOnly = True
        Me.strPhone.Visible = False
        '
        'TransactionID
        '
        Me.TransactionID.DataPropertyName = "TrId"
        Me.TransactionID.HeaderText = "TransactionID"
        Me.TransactionID.Name = "TransactionID"
        Me.TransactionID.ReadOnly = True
        Me.TransactionID.Visible = False
        '
        'dteZdout
        '
        Me.dteZdout.DataPropertyName = "dteZdout"
        Me.dteZdout.HeaderText = "dteZdout"
        Me.dteZdout.Name = "dteZdout"
        Me.dteZdout.ReadOnly = True
        Me.dteZdout.Visible = False
        '
        'lngClerkID1
        '
        Me.lngClerkID1.DataPropertyName = "lngClerkID"
        Me.lngClerkID1.HeaderText = "ClerkID"
        Me.lngClerkID1.Name = "lngClerkID1"
        Me.lngClerkID1.ReadOnly = True
        Me.lngClerkID1.Visible = False
        '
        'lngWSID
        '
        Me.lngWSID.DataPropertyName = "lngWSID"
        Me.lngWSID.HeaderText = "WSID"
        Me.lngWSID.Name = "lngWSID"
        Me.lngWSID.ReadOnly = True
        Me.lngWSID.Visible = False
        '
        'frmReviewSales
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(804, 473)
        Me.Controls.Add(Me.WinPanel2)
        Me.Controls.Add(Me.WinPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmReviewSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Review Sales"
        Me.WinPanel1.ResumeLayout(False)
        Me.grprvSalesPhoneno.ResumeLayout(False)
        Me.grprvSalesPhoneno.PerformLayout()
        Me.grpRevSalesOption.ResumeLayout(False)
        Me.grpRevSalesOption.PerformLayout()
        CType(Me.dataRowTemplate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColumnManagerRow1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataRowTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WinPanel2.ResumeLayout(False)
        CType(Me.grdRevSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WinPanel1 As Xceed.Editors.WinPanel
    Friend WithEvents btnRefreshRvSales As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWSOnly As System.Windows.Forms.CheckBox
    Friend WithEvents grpRevSalesOption As System.Windows.Forms.GroupBox
    Friend WithEvents grprvSalesPhoneno As System.Windows.Forms.GroupBox
    Friend WithEvents chkClerkOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodayOnly As System.Windows.Forms.CheckBox
    Friend WithEvents chkZoutOnly As System.Windows.Forms.CheckBox
    Friend WithEvents dataRowTemplate1 As Xceed.Grid.DataRow
    Friend WithEvents celldataRowTemplate1Column1 As Xceed.Grid.DataCell
    Friend WithEvents celldataRowTemplate1Column2 As Xceed.Grid.DataCell
    Friend WithEvents celldataRowTemplate1Column3 As Xceed.Grid.DataCell
    Friend WithEvents celldataRowTemplate1Column4 As Xceed.Grid.DataCell
    Friend WithEvents celldataRowTemplate1Column5 As Xceed.Grid.DataCell
    Friend WithEvents Column1 As Xceed.Grid.Column
    Friend WithEvents Column2 As Xceed.Grid.Column
    Friend WithEvents Column3 As Xceed.Grid.Column
    Friend WithEvents Column4 As Xceed.Grid.Column
    Friend WithEvents Column5 As Xceed.Grid.Column
    Friend WithEvents Column6 As Xceed.Grid.Column
    Friend WithEvents celldataRowTemplate1Column6 As Xceed.Grid.DataCell
    Friend WithEvents GroupByRow1 As Xceed.Grid.GroupByRow
    Friend WithEvents ColumnManagerRow1 As Xceed.Grid.ColumnManagerRow
    Friend WithEvents cellColumnManagerRow1Column7 As Xceed.Grid.ColumnManagerCell
    Friend WithEvents dataRowTemplate2 As Xceed.Grid.DataRow
    Friend WithEvents celldataRowTemplate2Column7 As Xceed.Grid.DataCell
    Friend WithEvents Column7 As Xceed.Grid.Column
    Friend WithEvents WinPanel2 As Xceed.Editors.WinPanel
    Friend WithEvents grdRevSales As System.Windows.Forms.DataGridView
    Friend WithEvents SaleId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaleDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receipt As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Void As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents strPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dteZdout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lngClerkID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lngWSID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
