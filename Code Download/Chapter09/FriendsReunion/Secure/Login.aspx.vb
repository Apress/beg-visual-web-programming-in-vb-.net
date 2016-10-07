Imports System.Data.SqlClient
Imports System.Web.Security

Public Class Login
	Inherits FriendsBase

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents txtLogin As System.Web.UI.HtmlControls.HtmlInputText
	Protected WithEvents txtPwd As System.Web.UI.HtmlControls.HtmlInputText
	Protected WithEvents btnLogin As System.Web.UI.HtmlControls.HtmlInputButton
	Protected WithEvents lblError As System.Web.UI.WebControls.Label
	Protected WithEvents pnlError As System.Web.UI.WebControls.Panel

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
		MyBase.HeaderIconImageUrl = "~/Images/securekeys.gif"
		MyBase.HeaderMessage = "Login Page"
	End Sub

	Private Sub btnLogin_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.ServerClick
		Dim con As New SqlConnection( _
		 "data source=.;initial catalog=FriendsData;" + _
		 "user id=apress;pwd=apress")
		Dim cmd As New SqlCommand( _
		 "SELECT UserID FROM [User] " + _
		 "WHERE Login=@Login and Password=@Pwd", con)

		' Add parameters for the values provided.
		cmd.Parameters.Add("@Login", txtLogin.Value)
		cmd.Parameters.Add("@Pwd", txtPwd.Value)
		con.Open()
		Dim id As String = Nothing

		Try
			' Retrieve the UserID
			id = CType(cmd.ExecuteScalar(), String)
		Finally
			con.Close()
		End Try

		If Not id Is Nothing Then
			' Set the user as authenticated and send him to the
			' page originally requested.
			FormsAuthentication.RedirectFromLoginPage(id, False)
		Else
			pnlError.Visible = True
			lblError.Text = "Invalid user name or password!"
		End If
	End Sub
End Class
