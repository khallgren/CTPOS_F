<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrCardDetails
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
        Me.lblStore = New System.Windows.Forms.Label
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.lblClerk = New System.Windows.Forms.Label
        Me.lblWSID = New System.Windows.Forms.Label
        Me.lblSaleDate = New System.Windows.Forms.Label
        Me.cboClerk = New System.Windows.Forms.ComboBox
        Me.txtWSID = New System.Windows.Forms.TextBox
        Me.dteSaleDate = New System.Windows.Forms.DateTimePicker
        Me.btnPrev = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Location = New System.Drawing.Point(60, 32)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(38, 13)
        Me.lblStore.TabIndex = 0
        Me.lblStore.Text = "Store :"
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(157, 29)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 21)
        Me.cboStore.TabIndex = 1
        '
        'lblClerk
        '
        Me.lblClerk.AutoSize = True
        Me.lblClerk.Location = New System.Drawing.Point(60, 63)
        Me.lblClerk.Name = "lblClerk"
        Me.lblClerk.Size = New System.Drawing.Size(37, 13)
        Me.lblClerk.TabIndex = 2
        Me.lblClerk.Text = "Clerk :"
        '
        'lblWSID
        '
        Me.lblWSID.AutoSize = True
        Me.lblWSID.Location = New System.Drawing.Point(60, 92)
        Me.lblWSID.Name = "lblWSID"
        Me.lblWSID.Size = New System.Drawing.Size(86, 13)
        Me.lblWSID.TabIndex = 3
        Me.lblWSID.Text = "WorkStation ID :"
        '
        'lblSaleDate
        '
        Me.lblSaleDate.AutoSize = True
        Me.lblSaleDate.Location = New System.Drawing.Point(60, 125)
        Me.lblSaleDate.Name = "lblSaleDate"
        Me.lblSaleDate.Size = New System.Drawing.Size(60, 13)
        Me.lblSaleDate.TabIndex = 4
        Me.lblSaleDate.Text = "Sale Date :"
        '
        'cboClerk
        '
        Me.cboClerk.FormattingEnabled = True
        Me.cboClerk.Location = New System.Drawing.Point(157, 60)
        Me.cboClerk.Name = "cboClerk"
        Me.cboClerk.Size = New System.Drawing.Size(121, 21)
        Me.cboClerk.TabIndex = 5
        '
        'txtWSID
        '
        Me.txtWSID.Location = New System.Drawing.Point(157, 92)
        Me.txtWSID.Name = "txtWSID"
        Me.txtWSID.Size = New System.Drawing.Size(121, 20)
        Me.txtWSID.TabIndex = 6
        '
        'dteSaleDate
        '
        Me.dteSaleDate.CustomFormat = "dd/MM/yyyy"
        Me.dteSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteSaleDate.Location = New System.Drawing.Point(157, 121)
        Me.dteSaleDate.Name = "dteSaleDate"
        Me.dteSaleDate.Size = New System.Drawing.Size(121, 20)
        Me.dteSaleDate.TabIndex = 47
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(105, 161)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(121, 23)
        Me.btnPrev.TabIndex = 48
        Me.btnPrev.Text = "Preview"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'frmCrCardDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 206)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.dteSaleDate)
        Me.Controls.Add(Me.txtWSID)
        Me.Controls.Add(Me.cboClerk)
        Me.Controls.Add(Me.lblSaleDate)
        Me.Controls.Add(Me.lblWSID)
        Me.Controls.Add(Me.lblClerk)
        Me.Controls.Add(Me.cboStore)
        Me.Controls.Add(Me.lblStore)
        Me.Name = "frmCrCardDetails"
        Me.Text = "frmCrCardDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents lblClerk As System.Windows.Forms.Label
    Friend WithEvents lblWSID As System.Windows.Forms.Label
    Friend WithEvents lblSaleDate As System.Windows.Forms.Label
    Friend WithEvents cboClerk As System.Windows.Forms.ComboBox
    Friend WithEvents txtWSID As System.Windows.Forms.TextBox
    Friend WithEvents dteSaleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrev As System.Windows.Forms.Button
End Class
