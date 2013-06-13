Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Namespace CurrencyTextBox

	''' <summary>
	''' Extended Textbox Control used to display Currency
	''' </summary>
	Public Partial Class CurrencyTextBox
		Inherits TextBox
		' member variable used to keep dollar value
		Private mDollarValue As Decimal



		' constructor
		Public Sub New()
			InitializeComponent()
			DollarValue = 0
		End Sub



		' default OnPaint
		Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
			' Calling the base class OnPaint
			MyBase.OnPaint(pe)
		End Sub


		''' <summary>
		''' Keypress handler used to restrict user input
		''' to numbers and control characters
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub CurrencyTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
			' allows only numbers, decimals and control characters
			If (Not Char.IsDigit(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) AndAlso e.KeyChar <> "."c Then
				e.Handled = True
			End If

			If e.KeyChar = "."c AndAlso Me.Text.Contains(".") Then
				e.Handled = True
			End If

			If e.KeyChar = "."c AndAlso Me.Text.Length < 1 Then
				e.Handled = True
			End If
		End Sub



		''' <summary>
		''' Update display to show decimal as currency
		''' whenver it is validated
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub CurrencyTextBox_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Validated
			Try
				' format the value as currency
				Dim dTmp As Decimal = Convert.ToDecimal(Me.Text)
				Me.Text = dTmp.ToString("C")
			Catch
			End Try
		End Sub



		''' <summary>
		''' Revert back to the display of numbers only
		''' whenever the user clicks in the box for
		''' editing purposes
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub CurrencyTextBox_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Click
			Me.Text = mDollarValue.ToString()

			If Me.Text = "0" Then
				Me.Clear()
			End If

			Me.SelectionStart = Me.Text.Length
		End Sub




		''' <summary>
		''' Update the dollar value each time the value is changed
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub CurrencyTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.TextChanged
			Try
                DollarValue = CDec(Me.Text)
			Catch
			End Try
		End Sub




		''' <summary>
		''' property to maintain value of control
		''' </summary>
		Public Property DollarValue() As Decimal
			Get
				Return mDollarValue
			End Get
			Set(ByVal value As Decimal)
				mDollarValue = value
			End Set
		End Property


	End Class
End Namespace
