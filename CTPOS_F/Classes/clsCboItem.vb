Public Class clsCboItem

    Private strItem As String
    Private strID As String
    Private lngID As Long


    Sub New(ByVal _lngNewID As Long, ByVal _strNewItem As String)

        strItem = _strNewItem
        lngID = _lngNewID
        strID = "0"

    End Sub

    Sub New(ByVal _strNewID As String, ByVal _strNewItem As String)

        strItem = _strNewItem
        strID = _strNewID
        lngID = 0

    End Sub

    Public Property Item() As String
        Get
            Item = strItem
        End Get
        Set(ByVal Value As String)
            strItem = Value
        End Set
    End Property

    Public Property ID() As String
        Get

            If lngID = 0 Then
                ID = strID
            Else
                ID = CType(lngID, String)
            End If
        End Get
        Set(ByVal Value As String)

            strID = Value

            If IsNumeric(Value) Then
                lngID = CType(Value, Long)
            Else
                lngID = 0
            End If

        End Set
    End Property

    
    Public Overrides Function ToString() As String
        ToString = strItem
    End Function

End Class

