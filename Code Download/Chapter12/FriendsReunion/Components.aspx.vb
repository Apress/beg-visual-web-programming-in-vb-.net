Public Class Components
	Inherits System.Web.UI.Page

	Public dsUser As DataSet

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
		Me.cnFriends = New System.Data.SqlClient.SqlConnection
		'
		'cnFriends
		'
		Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)

	End Sub
	Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
	Protected WithEvents Label1 As System.Web.UI.WebControls.Label

	'NOTE: The following placeholder declaration is required by the Web Form Designer.
	'Do not delete or move it.
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: This method call is required by the Web Form Designer
		'Do not modify it using the code editor.
		InitializeComponent()
	End Sub

#End Region

	Private Sub Page_Load(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles MyBase.Load
		'Put user code to initialize the page here

		dsUser = New DataSet
		dsUser.Tables.Add().Columns.Add("DateOfBirth", GetType(DateTime))
    dsUser.Tables(0).Rows.Add( _
     New Object() {DateTime.Now})

    Session("creditcard") = "value"
    Dim card As String = Session("creditcard")
		Page.DataBind()

	End Sub

End Class
