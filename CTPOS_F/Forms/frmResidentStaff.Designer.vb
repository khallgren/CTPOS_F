<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResidentStaff
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
        Me.grdResidentStaff = New System.Windows.Forms.DataGridView
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.colStaffID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStaffFName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStaffLName = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grdResidentStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdResidentStaff
        '
        Me.grdResidentStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdResidentStaff.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStaffID, Me.colStaffFName, Me.colStaffLName})
        Me.grdResidentStaff.Location = New System.Drawing.Point(12, 46)
        Me.grdResidentStaff.Name = "grdResidentStaff"
        Me.grdResidentStaff.Size = New System.Drawing.Size(503, 333)
        Me.grdResidentStaff.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(440, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(342, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'colStaffID
        '
        Me.colStaffID.DataPropertyName = "lngStaffID"
        Me.colStaffID.HeaderText = "Staff ID"
        Me.colStaffID.Name = "colStaffID"
        Me.colStaffID.ReadOnly = True
        Me.colStaffID.Visible = False
        '
        'colStaffFName
        '
        Me.colStaffFName.DataPropertyName = "strStaffFName"
        Me.colStaffFName.HeaderText = "First Name"
        Me.colStaffFName.Name = "colStaffFName"
        '
        'colStaffLName
        '
        Me.colStaffLName.DataPropertyName = "strStaffLName"
        Me.colStaffLName.HeaderText = "Last Name"
        Me.colStaffLName.Name = "colStaffLName"
        '
        'frmResidentStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 391)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdResidentStaff)
        Me.Name = "frmResidentStaff"
        Me.Text = "frmResidentStaff"
        CType(Me.grdResidentStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdResidentStaff As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents colStaffID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffFName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffLName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
