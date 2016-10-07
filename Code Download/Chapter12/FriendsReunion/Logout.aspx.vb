Public Class Logout
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents Image1 As System.Web.UI.WebControls.Image
  Protected WithEvents btnLogout As System.Web.UI.WebControls.Button

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
    MyBase.HeaderMessage = "Leave the Application"
    MyBase.HeaderIconImageUrl = "~\images\back.gif"
  End Sub

  Private Sub btnLogout_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnLogout.Click
    ' Remove the authentication ticket
    System.Web.Security.FormsAuthentication.SignOut()

    ' Redirect the user to the root application path
    Server.Transfer(Request.ApplicationPath)
  End Sub
End Class
