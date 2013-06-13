<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactionExceptions
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdUnmatchedTransactions = New System.Windows.Forms.DataGridView
        Me.colTransactionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRecordID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDateAdded = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPayment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSaleIDTrans = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSaleIDSales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelete = New System.Windows.Forms.Button
        CType(Me.grdUnmatchedTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(647, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(356, 39)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Occasionally there can be transactions created for sales that were voided." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Use" & _
            " this form to identify and delete these transactions."
        '
        'grdUnmatchedTransactions
        '
        Me.grdUnmatchedTransactions.AllowUserToAddRows = False
        Me.grdUnmatchedTransactions.AllowUserToDeleteRows = False
        Me.grdUnmatchedTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdUnmatchedTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUnmatchedTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTransactionID, Me.colRecordID, Me.colFName, Me.colLName, Me.colDateAdded, Me.colPayment, Me.colCharge, Me.colSaleIDTrans, Me.colSaleIDSales})
        Me.grdUnmatchedTransactions.Location = New System.Drawing.Point(12, 69)
        Me.grdUnmatchedTransactions.Name = "grdUnmatchedTransactions"
        Me.grdUnmatchedTransactions.Size = New System.Drawing.Size(710, 343)
        Me.grdUnmatchedTransactions.TabIndex = 2
        '
        'colTransactionID
        '
        Me.colTransactionID.DataPropertyName = "lngTransactionID"
        Me.colTransactionID.HeaderText = "Transaction ID"
        Me.colTransactionID.Name = "colTransactionID"
        '
        'colRecordID
        '
        Me.colRecordID.DataPropertyName = "lngRecordID"
        Me.colRecordID.HeaderText = "Record ID"
        Me.colRecordID.Name = "colRecordID"
        '
        'colFName
        '
        Me.colFName.DataPropertyName = "strFName"
        Me.colFName.HeaderText = "First Name"
        Me.colFName.Name = "colFName"
        '
        'colLName
        '
        Me.colLName.DataPropertyName = "strLName"
        Me.colLName.HeaderText = "Last Name"
        Me.colLName.Name = "colLName"
        '
        'colDateAdded
        '
        Me.colDateAdded.DataPropertyName = "dteDateAdded"
        Me.colDateAdded.HeaderText = "Date Added"
        Me.colDateAdded.Name = "colDateAdded"
        '
        'colPayment
        '
        Me.colPayment.DataPropertyName = "curPayment"
        Me.colPayment.HeaderText = "Payment Amt"
        Me.colPayment.Name = "colPayment"
        '
        'colCharge
        '
        Me.colCharge.DataPropertyName = "curCharge"
        Me.colCharge.HeaderText = "Charge Amt"
        Me.colCharge.Name = "colCharge"
        '
        'colSaleIDTrans
        '
        Me.colSaleIDTrans.DataPropertyName = "lngSaleID_Transactions"
        Me.colSaleIDTrans.HeaderText = "Sale ID"
        Me.colSaleIDTrans.Name = "colSaleIDTrans"
        '
        'colSaleIDSales
        '
        Me.colSaleIDSales.DataPropertyName = "lngSaleID"
        Me.colSaleIDSales.HeaderText = "Sale ID Sales"
        Me.colSaleIDSales.Name = "colSaleIDSales"
        Me.colSaleIDSales.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(505, 421)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(217, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "DELETE THESE TRANSACTIONS"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmTransactionExceptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 456)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.grdUnmatchedTransactions)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmTransactionExceptions"
        Me.Text = "Transaction Exceptions"
        CType(Me.grdUnmatchedTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdUnmatchedTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents colTransactionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDateAdded As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaleIDTrans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaleIDSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
