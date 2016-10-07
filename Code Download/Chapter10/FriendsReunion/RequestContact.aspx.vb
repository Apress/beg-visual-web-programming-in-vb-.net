Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Text

Public Class RequestContact
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.cmInsert = New System.Data.SqlClient.SqlCommand
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'cmInsert
    '
    Me.cmInsert.CommandText = "INSERT INTO Contact (RequestID, IsApproved, Notes, DestinationID) "

  End Sub
  Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSend As System.Web.UI.WebControls.Button
  Protected WithEvents lstUsers As System.Web.UI.WebControls.ListBox
  Protected WithEvents lblSuccess As System.Web.UI.WebControls.Label
  Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Protected WithEvents cmInsert As System.Data.SqlClient.SqlCommand

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
    MyBase.HeaderMessage = "Contact your buddies!"
    MyBase.HeaderIconImageUrl = "~/Images/contact.gif"

    ' Initialize the list of users only once
    If Not Page.IsPostBack Then
      Dim sel As StringCollection = _
        CType(Context.Items("selected"), StringCollection)
      If sel Is Nothing OrElse sel.Count = 0 Then
        Server.Transfer("Search.aspx")
      End If

      Dim sql As StringBuilder = New StringBuilder
      sql.Append("SELECT FirstName + ', ' + LastName AS FullName, ")
      sql.Append("UserID FROM [User] ")

      ' Build the WHERE clause based on the list received
      sql.Append("WHERE ")
      For Each id As String In sel
        sql.Append("UserID = '").Append(id).Append("' OR ")
      Next
      ' Remove trailing OR
      sql.Remove(sql.Length - 3, 3)
      sql.Append("ORDER BY FirstName, LastName")

      Dim cmd As SqlCommand = New SqlCommand(sql.ToString(), cnFriends)
      cnFriends.Open()
      ' Using
      Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
      Try
        ' Add the items with the corresponding ID
        While reader.Read()
          lstUsers.Items.Add(New ListItem( _
            reader(0).ToString(), _
            reader(1).ToString()))
        End While
      Finally
        reader.Close()
      End Try
    End If
  End Sub

  Private Sub btnSend_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnSend.Click
    cmInsert.Parameters("@RequestID").Value = _
      Page.User.Identity.Name
    cmInsert.Parameters("@IsApproved").Value = False
    cmInsert.Parameters("@Message").Value = txtMessage.Text
    Try
      cnFriends.Open()
      For Each it As ListItem In lstUsers.Items
        cmInsert.Parameters("@DestinationID").Value = it.Value
        cmInsert.ExecuteNonQuery()
      Next
      lblSuccess.Text = "Message successfully sent!"
    Finally
      ' Always close the connection.
      cnFriends.Close()
    End Try
  End Sub
End Class
