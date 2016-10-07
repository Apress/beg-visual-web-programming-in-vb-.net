Public Class Users
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.adUsers = New System.Data.SqlClient.SqlDataAdapter
    Me.cmUsers = New System.Data.SqlClient.SqlCommand
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.dsData = New FriendsReunion.UserData
    CType(Me.dsData, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'adUsers
    '
    Me.adUsers.SelectCommand = Me.cmUsers
    Me.adUsers.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "User", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("UserID", "UserID"), New System.Data.Common.DataColumnMapping("Login", "Login"), New System.Data.Common.DataColumnMapping("Password", "Password"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("DateOfBirth", "DateOfBirth"), New System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"), New System.Data.Common.DataColumnMapping("CellNumber", "CellNumber"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("IsAdministrator", "IsAdministrator")})})
    '
    'cmUsers
    '
    Me.cmUsers.CommandText = "SELECT UserID, Login, Password, FirstName, LastName, DateOfBirth, PhoneNumber, Ce" & _
    "llNumber, Address, Email, IsAdministrator FROM dbo.[User]"
    Me.cmUsers.Connection = Me.cnFriends
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'dsData
    '
    Me.dsData.DataSetName = "UserData"
    Me.dsData.Locale = New System.Globalization.CultureInfo("en-US")
    CType(Me.dsData, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
  Protected WithEvents grdUsers As System.Web.UI.WebControls.DataGrid
  Protected WithEvents adUsers As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Protected WithEvents cmUsers As System.Data.SqlClient.SqlCommand
  Protected WithEvents dsData As FriendsReunion.UserData

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
    MyBase.HeaderIconImageUrl = "~/images/padlock.gif"
    MyBase.HeaderMessage = "Administer Users"

    If Not IsPostBack Then
      Me.adUsers.Fill(Me.dsData)
      Me.grdUsers.DataBind()
    End If
  End Sub

End Class
