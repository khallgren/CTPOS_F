Imports Microsoft.VisualBasic
Imports System
Namespace CurrencyTextBox
	Public Partial Class CurrencyTextBox
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (Not components Is Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' CurrencyTextBox
			' 
'			Me.Click += New System.EventHandler(Me.CurrencyTextBox_Click);
'			Me.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.CurrencyTextBox_KeyPress);
'			Me.Validated += New System.EventHandler(Me.CurrencyTextBox_Validated);
'			Me.TextChanged += New System.EventHandler(Me.CurrencyTextBox_TextChanged);
			Me.ResumeLayout(False)

		End Sub

		#End Region
	End Class
End Namespace
