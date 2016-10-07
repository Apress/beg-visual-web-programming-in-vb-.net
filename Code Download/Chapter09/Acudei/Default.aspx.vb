Imports System.Configuration
Imports System.Web.Services.Protocols
Imports System.Xml

Public Class _Default
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents txtCount As System.Web.UI.WebControls.Label
  Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
  Protected WithEvents grdContacts As System.Web.UI.WebControls.DataGrid
  Protected WithEvents lblError As System.Web.UI.WebControls.Label

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
    Dim friends = New Acudei.FriendsService.Partners

    Try
      Dim count As Integer = friends.GetAttendees( _
        ConfigurationSettings.AppSettings("PlaceID"))
      txtCount.Text = count.ToString()
    Catch se As SoapException
      lblError.Text = String.Format( _
        "<h2>An error happened connecting to Friends Reunion service.</h2>" & _
        "<h3>Service location: {0}</h3>" & _
        "Error: <br/>{1}", se.Actor, _
        se.Message.Substring(45, se.Message.IndexOf(vbLf) - 45))
      lblError.Visible = True
    End Try

  End Sub

  Private Sub btnRefresh_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnRefresh.Click
    Dim friends = New Acudei.FriendsService.Partners

    Dim contacts As FriendsService.Contact() = _
      friends.GetContactRequestsCustom( _
      txtLogin.Text, txtPassword.Text)

    grdContacts.DataSource = contacts
    grdContacts.DataBind()
  End Sub
End Class
