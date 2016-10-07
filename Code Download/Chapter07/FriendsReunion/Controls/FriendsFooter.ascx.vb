Imports System.ComponentModel
Imports System.Collections

Public Class FriendsFooter
  Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents pnlFooterGlobal As System.Web.UI.WebControls.Panel
  Protected WithEvents lblCounter As System.Web.UI.WebControls.Label
  Protected WithEvents imgShow As System.Web.UI.WebControls.Image
  Protected WithEvents cbBackColor As System.Web.UI.WebControls.DropDownList

  'NOTE: The following placeholder declaration is required by the Web Form Designer.
  'Do not delete or move it.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles MyBase.Load
    lblCounter.Text = Application("counter").ToString()

    ' Script to show/hide the options and change the image.
    Dim script As String = _
      " var table=document.getElementById('tbPrefs'); " + _
      " if (table.style.display=='block') { " + _
      "   this.src='%down%'; table.style.display='none'; " + _
      " } else { " + _
      "   this.src='%up%'; table.style.display='block'; " + _
      " } "

    ' Resolve images relative to the current context.
    script = script.Replace("%down%", _
      ResolveUrl("../Images/down.gif"))
    script = script.Replace("%up%", _
      ResolveUrl("../Images/up.gif"))

    imgShow.Attributes.Add("onclick", script)
    imgShow.Style.Add("cursor", "pointer")

    If Not Page.IsPostBack Then
      ' Empty item to clear color preference
      cbBackColor.Items.Add(String.Empty)
      Dim cv As ColorConverter = New ColorConverter

      ' Retrieve current color preference to preselect the item
      Dim selected As Color = Color.Empty
      If Not Request.Cookies("backcolor") Is Nothing AndAlso _
        Not Request.Cookies("backcolor").Value Is Nothing AndAlso _
        Not Request.Cookies("backcolor").Value = String.Empty Then
        selected = CType(cv.ConvertFromString( _
          Request.Cookies("backcolor").Value), Color)
      End If

      ' Get all standard colors.
      Dim col As ICollection = cv.GetStandardValues()
      For Each c As Color In col
        ' Convert each color to its HTML equivalent.
        Dim li As ListItem = New ListItem(c.Name, _
          ColorTranslator.ToHtml(c))
        If c.Equals(selected) Then
          li.Selected = True
        End If
        cbBackColor.Items.Add(li)
      Next
    End If
  End Sub

  Private Sub cbBackColor_SelectedIndexChanged(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles cbBackColor.SelectedIndexChanged
    Response.Cookies.Add(New HttpCookie("backcolor", _
      CType(sender, DropDownList).SelectedItem.Value))
  End Sub
End Class
