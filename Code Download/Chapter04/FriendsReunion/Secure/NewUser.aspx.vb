Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Text

Public Class NewUser
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
  Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqLogin As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqPwd As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtFName As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqFName As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtLName As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqLName As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPhone As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqPhone As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents regPhone As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtMobile As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqEmail As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents regEmail As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtBirth As System.Web.UI.WebControls.TextBox
  Protected WithEvents compBirth As System.Web.UI.WebControls.CompareValidator
  Protected WithEvents btnAccept As System.Web.UI.WebControls.Button
  Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
  Protected WithEvents valErrors As System.Web.UI.WebControls.ValidationSummary

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
		MyBase.HeaderMessage = "Registration Form"

		' Postbacks will typically be caused by the validator
		' controls in non-IE browsers
		If Page.IsPostBack Then Return

		' If this is an update, preload the values
		If Context.User.Identity.IsAuthenticated Then
			' Change the header message
			MyBase.HeaderMessage = "Update my profile"

			Dim con As New SqlConnection( _
			 "data source=.;initial catalog=FriendsData;" + _
			 "user id=apress;pwd=apress")
			Dim cmd As New SqlCommand( _
			 "SELECT * FROM [User] WHERE UserID=@ID", con)
			cmd.Parameters.Add("@ID", Page.User.Identity.Name)

			con.Open()
			Try
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				If reader.Read() Then
					' Retrieve a typed value using the column's ordinal position
					Dim pos As Integer = reader.GetOrdinal("Address")
					txtAddress.Text = reader.GetString(pos).ToString()

					' Avoid using the pos variable altogether, 
					' but get the typed value
					txtBirth.Text = reader.GetDateTime( _
						reader.GetOrdinal("DateOfBirth")).ToShortDateString()

					' Convert directly the untyped Object returned by the
					' default property to a string
					txtEmail.Text = reader("Email").ToString()
					txtFName.Text = reader("FirstName").ToString()
					txtLName.Text = reader("LastName").ToString()
					txtLogin.Text = reader("Login").ToString()
					txtPhone.Text = reader("PhoneNumber").ToString()
					txtPwd.Text = reader("Password").ToString()

					' Use SQL Server type to have additional features 
					pos = reader.GetOrdinal("CellNumber")
					Dim cel As SqlString = reader.GetSqlString(pos)
					If Not cel.IsNull Then txtMobile.Text = cel.Value
				End If
			Finally
				' Ensure connection is ALWAYS closed.
				con.Close()
			End Try
		End If
	End Sub

	Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
		If Page.IsValid Then
			If Context.User.Identity.IsAuthenticated Then
				UpdateUser()
			Else
				InsertUser()
			End If
		Else
			lblMessage.Text = "Fix the following errors and retry:"
		End If
	End Sub

	Private Sub InsertUser()
		Dim values As New ArrayList(11)

		' Optional values without quotes as they can be the Null value.
		Dim sql As String
		sql = "INSERT INTO [User] " + _
		 "(UserID, Login, Password, FirstName, LastName," + _
		 "PhoneNumber, Email, IsAdministrator, Address," + _
		 "CellNumber, DateOfBirth)" + _
		 "VALUES " + _
		 "('{0}', '{1}', '{2}', '{3}', '{4}'," + _
		 "'{5}', '{6}', '{7}', {8}, {9}, {10})"

		' Add required values to replace
		values.Add(Guid.NewGuid().ToString())
		values.Add(txtLogin.Text)
		values.Add(txtPwd.Text)
		values.Add(txtFName.Text)
		values.Add(txtLName.Text)
		values.Add(txtPhone.Text)
		values.Add(txtEmail.Text)
		values.Add(0)

		' Add the optional values or Null
		If (txtAddress.Text.Length <> 0) Then
			values.Add("'" + txtAddress.Text + "'")
		Else
			values.Add("Null")
		End If

		If (txtMobile.Text.Length <> 0) Then
			values.Add("'" + txtMobile.Text + "'")
		Else
			values.Add("Null")
		End If

		If (txtBirth.Text.Length <> 0) Then
			values.Add("'" + txtBirth.Text + "'")
		Else
			values.Add("Null")
		End If

		' Format the string with the array of values
		sql = String.Format(sql, values.ToArray())

		' Connect and execute the query
		Dim con As New SqlConnection( _
		 "data source=.;initial catalog=FriendsData;" + _
		 "user id=apress;pwd=apress")
		Dim cmd As New SqlCommand(sql, con)
		con.Open()

		Dim doredirect As Boolean = True

		Try
			cmd.ExecuteNonQuery()
		Catch ex As SqlException
			doredirect = False
			lblMessage.Visible = True
			lblMessage.Text = _
			 "Insert couldn't be performed. User name may be already taken."
		Finally
			' Ensure connection is closed always.
			con.Close()
		End Try

		If (doredirect) Then Response.Redirect("Login.aspx")
	End Sub

	Private Sub UpdateUser()
		Dim values As New ArrayList

		' Optional values without quotes as they can be the Null value.
		Dim sql As String
		sql = "UPDATE [User] SET " + _
		 "Login='{0}', Password='{1}', FirstName='{2}', " + _
		 "LastName='{3}', PhoneNumber='{4}', Email='{5}',  " + _
		 "Address={6}, CellNumber={7}, DateOfBirth={8} " + _
		 "WHERE UserID='{9}'"

		' Add required values to replace
		values.Add(txtLogin.Text)
		values.Add(txtPwd.Text)
		values.Add(txtFName.Text)
		values.Add(txtLName.Text)
		values.Add(txtPhone.Text)
		values.Add(txtEmail.Text)

		' Add the optional values or Null
		If (txtAddress.Text.Length <> 0) Then
			values.Add("'" + txtAddress.Text + "'")
		Else
			values.Add("Null")
		End If

		If (txtMobile.Text.Length <> 0) Then
			values.Add("'" + txtMobile.Text + "'")
		Else
			values.Add("Null")
		End If

		If txtBirth.Text.Length <> 0 Then
			Dim dt As DateTime = DateTime.Parse(txtBirth.Text)
			' Pass date in ISO format YYYYMMDD
			values.Add("'" + dt.ToString("yyyyMMdd") + "'")
		Else
			values.Add("Null")
		End If

		' Get the UserID from the context.
		values.Add(Context.User.Identity.Name)

		' Format the query with the values
		sql = String.Format(sql, values.ToArray())

		' Connect and execute the query
		Dim con As New SqlConnection( _
			"data source=.;initial catalog=FriendsData;" + _
			"user id=apress;pwd=apress")
		Dim cmd As New SqlCommand(sql, con)
		con.Open()

		Dim doredirect As Boolean = True

		Try
			cmd.ExecuteNonQuery()
		Catch ex As SqlException
			doredirect = False
			lblMessage.Visible = True
			lblMessage.Text = "Couldn't update your profile!"
		Finally
			con.Close()
		End Try

		If doredirect Then Response.Redirect("../Default.aspx")
	End Sub
End Class
