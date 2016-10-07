Imports System.Configuration
Imports System.Data.SqlClient

Public Class News
	Inherits FriendsBase

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.adApproved = New System.Data.SqlClient.SqlDataAdapter
    Me.cmApproved = New System.Data.SqlClient.SqlCommand
    Me.dsApproved = New FriendsReunion.ContactsData
    CType(Me.dsApproved, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'adApproved
    '
    Me.adApproved.SelectCommand = Me.cmApproved
    Me.adApproved.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "User", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("UserID", "UserID")})})
    '
    'cmApproved
    '
    Me.cmApproved.CommandText = "SELECT dbo.[User].FirstName, dbo.[User].LastName, dbo.[User].PhoneNumber, dbo.[Us" & _
    "er].Address, dbo.[User].Email, dbo.[User].UserID FROM dbo.[User] INNER JOIN dbo." & _
    "Contact ON dbo.[User].UserID = dbo.Contact.RequestID WHERE (dbo.Contact.Destinat" & _
    "ionID = @ID) AND (dbo.Contact.IsApproved = 1)"
    Me.cmApproved.Connection = Me.cnFriends
    Me.cmApproved.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 36, "DestinationID"))
    '
    'dsApproved
    '
    Me.dsApproved.DataSetName = "ContactsData"
    Me.dsApproved.Locale = New System.Globalization.CultureInfo("en-US")
    CType(Me.dsApproved, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
  Protected WithEvents pnlPending As System.Web.UI.WebControls.Panel
  Protected WithEvents grdPending As System.Web.UI.WebControls.DataGrid
  Protected WithEvents pnlApproved As System.Web.UI.WebControls.Panel
  Protected WithEvents grdApproved As System.Web.UI.WebControls.DataGrid
  Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Protected WithEvents adApproved As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents cmApproved As System.Data.SqlClient.SqlCommand
  Protected WithEvents dsApproved As FriendsReunion.ContactsData

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
		' Configure the icon and message
		MyBase.HeaderIconImageUrl = "~/Images/winbook.gif"
		MyBase.HeaderMessage = "News Page"
		Dim sql As String = _
		 "SELECT " + _
		 "[User].FirstName, [User].LastName, " + _
		 "Contact.Notes, [User].UserID  " + _
		 "FROM [User], Contact  WHERE " + _
		 "DestinationID=@ID AND IsApproved=0 AND " + _
		 "[User].UserID=Contact.RequestID"

		' Create the connection and data adapter
		Dim cnFriends As New SqlConnection( _
		 ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
		Dim adUser As New SqlDataAdapter(sql, cnFriends)
		adUser.SelectCommand.Parameters.Add("@ID", Page.User.Identity.Name)
		Dim dsPending As DataSet = New DataSet

		' Fill dataset and bind to the datagrid
		adUser.Fill(dsPending, "Pending")
		grdPending.DataSource = dsPending
		grdPending.DataBind()

    ' Fill approved contacts
    adApproved.SelectCommand.Parameters("@ID").Value = _
      Page.User.Identity.Name
    adApproved.Fill(dsApproved)
    grdApproved.DataBind()

    If dsPending.Tables(0).Rows.Count = 0 Then
      pnlPending.Visible = False
    End If
    If dsApproved.User.Rows.Count = 0 Then
      pnlApproved.Visible = False
    End If
  End Sub

  Private Sub grdApproved_PageIndexChanged(ByVal source As Object, _
    ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) _
    Handles grdApproved.PageIndexChanged
    ' Set the new index
    grdApproved.CurrentPageIndex = e.NewPageIndex

    ' Fill approved contacts
    adApproved.SelectCommand.Parameters("@ID").Value = _
      Page.User.Identity.Name
    adApproved.Fill(dsApproved)
    grdApproved.DataBind()
  End Sub
End Class
