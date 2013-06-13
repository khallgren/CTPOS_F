<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvCategories
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
        Me.grdAdjustmentTypes = New System.Windows.Forms.DataGridView
        Me.lblAdjustmentTypes = New System.Windows.Forms.Label
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.strInvCategory = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lngInvCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grdAdjustmentTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdAdjustmentTypes
        '
        Me.grdAdjustmentTypes.AllowUserToAddRows = False
        Me.grdAdjustmentTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAdjustmentTypes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.strInvCategory, Me.lngInvCategoryID})
        Me.grdAdjustmentTypes.Location = New System.Drawing.Point(12, 31)
        Me.grdAdjustmentTypes.Name = "grdAdjustmentTypes"
        Me.grdAdjustmentTypes.Size = New System.Drawing.Size(361, 239)
        Me.grdAdjustmentTypes.TabIndex = 0
        '
        'lblAdjustmentTypes
        '
        Me.lblAdjustmentTypes.AutoSize = True
        Me.lblAdjustmentTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustmentTypes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAdjustmentTypes.Location = New System.Drawing.Point(83, 21)
        Me.lblAdjustmentTypes.Name = "lblAdjustmentTypes"
        Me.lblAdjustmentTypes.Size = New System.Drawing.Size(0, 20)
        Me.lblAdjustmentTypes.TabIndex = 1
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(157, 294)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Save"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'strInvCategory
        '
        Me.strInvCategory.DataPropertyName = "strInvCategory"
        Me.strInvCategory.Frozen = True
        Me.strInvCategory.HeaderText = ""
        Me.strInvCategory.Name = "strInvCategory"
        Me.strInvCategory.Width = 330
        '
        'lngInvCategoryID
        '
        Me.lngInvCategoryID.DataPropertyName = "lngInvCategoryID"
        Me.lngInvCategoryID.Frozen = True
        Me.lngInvCategoryID.HeaderText = "lngAdjustmentTypeID"
        Me.lngInvCategoryID.Name = "lngInvCategoryID"
        Me.lngInvCategoryID.Visible = False
        '
        'frmInvCategories
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 329)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblAdjustmentTypes)
        Me.Controls.Add(Me.grdAdjustmentTypes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmInvCategories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Categories"
        CType(Me.grdAdjustmentTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdAdjustmentTypes As System.Windows.Forms.DataGridView
    Friend WithEvents lblAdjustmentTypes As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents strInvCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lngInvCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
