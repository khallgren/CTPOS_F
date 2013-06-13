<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvRptSetup
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
        Me.lblChkInActive = New System.Windows.Forms.Label
        Me.lblPickCatagory = New System.Windows.Forms.Label
        Me.lblStore = New System.Windows.Forms.Label
        Me.chkIncludeInactive = New System.Windows.Forms.CheckBox
        Me.cboPickCatagory = New System.Windows.Forms.ComboBox
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblChkInActive
        '
        Me.lblChkInActive.AutoSize = True
        Me.lblChkInActive.Location = New System.Drawing.Point(47, 27)
        Me.lblChkInActive.Name = "lblChkInActive"
        Me.lblChkInActive.Size = New System.Drawing.Size(83, 13)
        Me.lblChkInActive.TabIndex = 0
        Me.lblChkInActive.Text = "Include Inactive"
        '
        'lblPickCatagory
        '
        Me.lblPickCatagory.AutoSize = True
        Me.lblPickCatagory.Location = New System.Drawing.Point(47, 61)
        Me.lblPickCatagory.Name = "lblPickCatagory"
        Me.lblPickCatagory.Size = New System.Drawing.Size(79, 13)
        Me.lblPickCatagory.TabIndex = 1
        Me.lblPickCatagory.Text = "Pick Catagory :"
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Location = New System.Drawing.Point(47, 94)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(38, 13)
        Me.lblStore.TabIndex = 2
        Me.lblStore.Text = "Store :"
        '
        'chkIncludeInactive
        '
        Me.chkIncludeInactive.AutoSize = True
        Me.chkIncludeInactive.Location = New System.Drawing.Point(136, 27)
        Me.chkIncludeInactive.Name = "chkIncludeInactive"
        Me.chkIncludeInactive.Size = New System.Drawing.Size(15, 14)
        Me.chkIncludeInactive.TabIndex = 3
        Me.chkIncludeInactive.UseVisualStyleBackColor = True
        '
        'cboPickCatagory
        '
        Me.cboPickCatagory.FormattingEnabled = True
        Me.cboPickCatagory.Location = New System.Drawing.Point(136, 61)
        Me.cboPickCatagory.Name = "cboPickCatagory"
        Me.cboPickCatagory.Size = New System.Drawing.Size(121, 21)
        Me.cboPickCatagory.TabIndex = 4
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(136, 94)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 21)
        Me.cboStore.TabIndex = 5
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(95, 134)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Preview"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmInvRptSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 188)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cboStore)
        Me.Controls.Add(Me.cboPickCatagory)
        Me.Controls.Add(Me.chkIncludeInactive)
        Me.Controls.Add(Me.lblStore)
        Me.Controls.Add(Me.lblPickCatagory)
        Me.Controls.Add(Me.lblChkInActive)
        Me.Name = "frmInvRptSetup"
        Me.Text = "Inventory Report Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblChkInActive As System.Windows.Forms.Label
    Friend WithEvents lblPickCatagory As System.Windows.Forms.Label
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents chkIncludeInactive As System.Windows.Forms.CheckBox
    Friend WithEvents cboPickCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
