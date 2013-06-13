<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestReceipt
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
        Me.Receipt = New System.Windows.Forms.TextBox
        Me.CamperNames = New System.Windows.Forms.ListBox
        Me.TblRecordsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRecords = New CTPOS_F.dsRecords
        Me.TblRecordsTableAdapter = New CTPOS_F.dsRecordsTableAdapters.tblRecordsTableAdapter
        CType(Me.TblRecordsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Receipt
        '
        Me.Receipt.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Receipt.Location = New System.Drawing.Point(12, 12)
        Me.Receipt.Multiline = True
        Me.Receipt.Name = "Receipt"
        Me.Receipt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Receipt.Size = New System.Drawing.Size(449, 355)
        Me.Receipt.TabIndex = 0
        '
        'CamperNames
        '
        Me.CamperNames.BackColor = System.Drawing.SystemColors.Menu
        Me.CamperNames.DataSource = Me.TblRecordsBindingSource
        Me.CamperNames.DisplayMember = "Name"
        Me.CamperNames.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CamperNames.FormattingEnabled = True
        Me.CamperNames.HorizontalScrollbar = True
        Me.CamperNames.ItemHeight = 16
        Me.CamperNames.Location = New System.Drawing.Point(482, 12)
        Me.CamperNames.Name = "CamperNames"
        Me.CamperNames.Size = New System.Drawing.Size(207, 356)
        Me.CamperNames.TabIndex = 3
        Me.CamperNames.ValueMember = "lngRecordID"
        '
        'TblRecordsBindingSource
        '
        Me.TblRecordsBindingSource.DataMember = "tblRecords"
        Me.TblRecordsBindingSource.DataSource = Me.DsRecords
        '
        'DsRecords
        '
        Me.DsRecords.DataSetName = "dsRecords"
        Me.DsRecords.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblRecordsTableAdapter
        '
        Me.TblRecordsTableAdapter.ClearBeforeFill = True
        '
        'frmTestReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 380)
        Me.Controls.Add(Me.CamperNames)
        Me.Controls.Add(Me.Receipt)
        Me.Name = "frmTestReceipt"
        Me.Text = "TestReceipt"
        CType(Me.TblRecordsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Receipt As System.Windows.Forms.TextBox
    Friend WithEvents CamperNames As System.Windows.Forms.ListBox
    Friend WithEvents DsRecords As CTPOS_F.dsRecords
    Friend WithEvents TblRecordsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblRecordsTableAdapter As CTPOS_F.dsRecordsTableAdapters.tblRecordsTableAdapter
End Class
