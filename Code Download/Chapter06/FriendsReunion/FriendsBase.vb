Public Class FriendsBase
  Inherits Page

  Protected HeaderMessage As String = ""
  Protected HeaderIconImageUrl As String = ""

  Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    ' Get a reference to the form control
    Dim form As Control = Page.Controls(1)

    ' Create and place the page header
    Dim header As FriendsHeader
    header = CType( _
      LoadControl("~/Controls/FriendsHeader.ascx"), _
      FriendsHeader)

    header.Message = HeaderMessage
    header.IconImageUrl = HeaderIconImageUrl
    form.Controls.AddAt(0, header)

    ' Add the SubHeader custom control
    form.Controls.AddAt(1, New SubHeader)

    ' Add space separating the main content.
    form.Controls.AddAt(2, New LiteralControl("<p/>"))
    form.Controls.AddAt(form.Controls.Count, _
      New LiteralControl("<p/>"))

    ' Finally, add the page footer
    Dim footer As FriendsFooter
    footer = CType( _
      LoadControl("~/Controls/FriendsFooter.ascx"), _
      FriendsFooter)

    form.Controls.AddAt(Page.Controls(1).Controls.Count, footer)

    ' Render as usual
    MyBase.Render(writer)
  End Sub
End Class
