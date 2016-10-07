Imports System.Configuration
Imports System.Data.SqlClient

Public Class ViewUser
	Inherits FriendsBase

	Protected dsUser As DataSet

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents lblName As System.Web.UI.WebControls.Label
	Protected WithEvents lblBirth As System.Web.UI.WebControls.Label
	Protected WithEvents lblPhone As System.Web.UI.WebControls.Label
	Protected WithEvents lblMobile As System.Web.UI.WebControls.Label
	Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
	Protected WithEvents lnkEmail As System.Web.UI.WebControls.HyperLink
	Protected WithEvents lblPending As System.Web.UI.WebControls.Label
	Protected WithEvents btnAuthorize As System.Web.UI.WebControls.Button

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
		Dim userID As String = Request.QueryString("RequestID")

		' Ensure we received an ID
    If userID Is Nothing Then
      userID = Request.QueryString("UserID")
      If userID Is Nothing Then
        Throw New ArgumentException("This page expects either a RequestID " + "or a UserID parameter.")
      Else
        btnAuthorize.Visible = False
      End If
    End If

    ' Create the connection and data adapter
    Dim cnFriends As New SqlConnection( _
     ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
    Dim adUser As New SqlDataAdapter( _
     "SELECT * FROM [User] WHERE UserID=@ID", cnFriends)
    adUser.SelectCommand.Parameters.Add("@ID", userID)

    ' Initialize the dataset and fill it with data
    dsUser = New DataSet
    adUser.Fill(dsUser, "User")

    ' Finally, bind all the controls on the page
    Me.DataBind()
	End Sub

	Protected Function GetPending() As String
		' Create the connection and command to execute
		Dim cnFriends As SqlConnection = New SqlConnection( _
			ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
		Dim cmd As SqlCommand = New SqlCommand( _
			"SELECT COUNT(*) FROM Contact " + _
			"WHERE IsApproved=0 AND DestinationID=@ID", cnFriends)
		cmd.Parameters.Add("@ID", Page.User.Identity.Name)
		cnFriends.Open()
		Try
			Return cmd.ExecuteScalar().ToString()
		Finally
			cnFriends.Close()
		End Try
	End Function

	Private Sub btnAuthorize_Click(ByVal sender As System.Object, _
	 ByVal e As System.EventArgs) Handles btnAuthorize.Click

		' Create the connection and command to execute
		Dim cnFriends As New SqlConnection( _
		 ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
		Dim cmd As New SqlCommand( _
		 "UPDATE Contact SET IsApproved=1 " + _
		 " WHERE RequestID=@RequestID AND DestinationID=@DestinationID", _
		 cnFriends)
		cmd.Parameters.Add("@RequestID", Request.QueryString("RequestID"))
		cmd.Parameters.Add("@DestinationID", Page.User.Identity.Name)
		cnFriends.Open()

		Try
			cmd.ExecuteNonQuery()
		Finally
			cnFriends.Close()
		End Try
		Response.Redirect("News.aspx")
	End Sub
End Class
