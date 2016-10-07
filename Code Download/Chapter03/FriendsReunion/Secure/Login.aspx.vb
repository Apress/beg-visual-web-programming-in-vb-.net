Public Class Login
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents txtLogin As System.Web.UI.HtmlControls.HtmlInputText
	Protected WithEvents txtPwd As System.Web.UI.HtmlControls.HtmlInputText
	Protected WithEvents btnLogin As System.Web.UI.HtmlControls.HtmlInputButton
	Protected WithEvents lblMessage As System.Web.UI.HtmlControls.HtmlGenericControl

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

	Private Sub btnLogin_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.ServerClick
		lblMessage.InnerText = "Welcome " + txtLogin.Value
	End Sub
End Class
