Public Class FriendsHeader
  Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents imgFriends As System.Web.UI.WebControls.Image
  Protected WithEvents pnlHeaderGlobal As System.Web.UI.WebControls.Panel
  Protected WithEvents imgIcon As System.Web.UI.WebControls.Image
  Protected WithEvents lblWelcome As System.Web.UI.WebControls.Label
  Protected WithEvents pnlHeaderLocal As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
  End Sub

  Private _message As String = ""
  Private _imageurl As String = ""

  Public Property Message() As String
    Get
      Return _message
    End Get
    Set(ByVal Value As String)
      _message = Value
    End Set
  End Property

  Public Property IconImageUrl() As String
    Get
      Return _imageurl
    End Get
    Set(ByVal Value As String)
      _imageurl = Value
    End Set
  End Property

  Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    If Message <> "" Then lblWelcome.Text = Message
    If IconImageUrl <> "" Then imgIcon.ImageUrl = IconImageUrl
    MyBase.Render(writer)
  End Sub
End Class
