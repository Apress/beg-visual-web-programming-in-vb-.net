Public Class SubHeader
  Inherits WebControl

  Private _register As String = ""

  Public Sub New()
    'Initialize default values
    Me.Width = New Unit(100, UnitType.Percentage)
    Me.CssClass = "SubHeader"
  End Sub

  'Property to allow the user to define the URL for the
  'registration page
  Public Property RegisterUrl() As String
    Get
      Return _register
    End Get
    Set(ByVal Value As String)
      _register = Value
    End Set
  End Property

  Protected Overrides Sub CreateChildControls()
    Dim lbl As Label

    ' If the user is authenticated, we will render their name
    If (Context.User.Identity.IsAuthenticated) Then
      lbl = New Label
      lbl.Text = Context.User.Identity.Name

      ' Add the newly created label to our 
      ' collection of child controls
      Controls.Add(lbl)
    Else
      ' Otherwise, we will render a link to the registration page
      Dim reg As New HyperLink
      reg.Text = "Register"

      ' If a URL isn't provided, use a default URL to the
      ' registration page
      If _register = "" Then
        reg.NavigateUrl = "~\Secure\NewUser.aspx"
      Else
        reg.NavigateUrl = _register
        ' Add the newly created link to our 
        ' collection of child controls
        Controls.Add(reg)
      End If
    End If

    ' Add a couple of blank spaces and a separator character
    Controls.Add(New LiteralControl("&nbsp-&nbsp"))

    ' Add a label with the current data
    lbl = New Label
    lbl.Text = DateTime.Now.ToLongDateString()
    Controls.Add(lbl)
  End Sub
End Class
