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

    ' Always render a link to the registration/edit profile page
    Dim reg As New HyperLink

    ' If a URL isn't provided, use a default URL to the
    ' registration page
    If _register = "" Then
      reg.NavigateUrl = "~\Secure\NewUser.aspx"
    Else
      reg.NavigateUrl = _register
    End If

    If (Context.User.Identity.IsAuthenticated) Then
      reg.Text = "Edit my profile"
      reg.ToolTip = "Modify your personal information"
      Dim signout As New HyperLink
      signout.NavigateUrl = "~\Logout.aspx"
      signout.Text = "Logout"
      signout.ToolTip = "Leave the application"
      Controls.Add(New LiteralControl("&nbsp;|&nbsp;"))
      Controls.Add(signout)
    Else
      reg.Text = "Register"
    End If

    ' Add the newly created link to our 
    ' collection of child controls
    Controls.AddAt(0, reg)

    ' Add a couple of blank spaces and a separator character
    Controls.Add(New LiteralControl("&nbsp-&nbsp"))

    ' Add a label with the current data
    lbl = New Label
    lbl.Text = DateTime.Now.ToLongDateString()
    Controls.Add(lbl)
  End Sub
End Class
