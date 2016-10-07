Imports System.Web.UI.HtmlControls
Imports System.Diagnostics

Public Class FriendsBase
  Inherits Page

  Protected HeaderMessage As String = ""
  Protected HeaderIconImageUrl As String = ""

  Private _footer As FriendsFooter
  Private _header As FriendsHeader
  Private _subheader As SubHeader

  Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
    _header = CType(LoadControl("~/Controls/FriendsHeader.ascx"), FriendsHeader)
    _footer = CType(LoadControl("~/Controls/FriendsFooter.ascx"), FriendsFooter)
    _subheader = New SubHeader

    ' Add to the Controls hierarchy to get proper
    ' event handling, on rendering we reposition them.
    Page.Controls.Add(_header)
    Page.Controls.Add(_subheader)
    Page.Controls.Add(_footer)
    MyBase.OnInit(e)
  End Sub

  Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    ' Remove the controls from their current place in the hierarchy
    Page.Controls.Remove(_header)
    Page.Controls.Remove(_subheader)
    Page.Controls.Remove(_footer)

    Debug.Assert( _
       TypeOf Page.Controls(1) Is HtmlForm, _
       "Form control not found", _
       "Any FriendsReunion page requires that a form tag be " + _
       "the first child of the page body.")

    ' Get a reference to the form control
    Dim form As HtmlForm = CType(Page.Controls(1), HtmlForm)

    ' Reposition the controls on the page
    form.Controls.AddAt(0, _header)
    form.Controls.AddAt(1, _subheader)
    form.Controls.AddAt(form.Controls.Count, _footer)

    ' Set current values
    _header.Message = HeaderMessage
    _header.IconImageUrl = HeaderIconImageUrl

    ' New cookies are set to Response by the color selector
    Dim bg As String = Response.Cookies("backcolor").Value

    ' if not, check Request for a previously saved cookie
    If bg Is Nothing AndAlso Not Request.Cookies("backcolor") Is Nothing _
      AndAlso Not Request.Cookies("backcolor").Value Is Nothing _
      AndAlso Not Request.Cookies("backcolor").Value = String.Empty Then
      bg = Request.Cookies("backcolor").Value
      ' preserve cookie in the response
      Response.Cookies.Add(Request.Cookies("backcolor"))
    End If

    ' Do we have a value to work with?
    If Not bg Is Nothing AndAlso bg <> String.Empty Then
      ' Enclose form in a DIV to display the backcolor
      Dim div As HtmlGenericControl = New HtmlGenericControl("div")
      div.Style.Add("background-color", bg)

      ' Relocate the form inside the DIV
      Page.Controls.Remove(form)
      Page.Controls.AddAt(1, div)
      div.Controls.Add(form)
      Response.Cookies("backcolor").Expires = DateTime.Now.AddYears(1)
    End If

    ' Render as usual
    MyBase.Render(writer)
  End Sub
End Class
