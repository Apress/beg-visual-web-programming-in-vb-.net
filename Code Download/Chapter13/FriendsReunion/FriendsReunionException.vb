Public Class FriendsReunionException
  Inherits ApplicationException

  Public Sub New()
  End Sub

  Public Sub New(ByVal message As String, ByVal inner As Exception)
    MyBase.New(message, inner)
  End Sub

End Class
