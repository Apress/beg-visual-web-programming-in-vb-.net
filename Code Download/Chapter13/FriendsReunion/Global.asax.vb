Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState

Public Class Global
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Component Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call
    AddHandler MyBase.BeginRequest, New EventHandler(AddressOf Application_BeginRequest)
  End Sub

  'Required by the Component Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Component Designer
  'It can be modified using the Component Designer.
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    components = New System.ComponentModel.Container
  End Sub

#End Region

  Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    ' Fires at the beginning of each request
  End Sub

  Sub Application_AuthenticateRequest(ByVal sender As Object, _
    ByVal e As EventArgs)
    ' Cast the sender to the application
    Dim app As HttpApplication = CType(sender, HttpApplication)

    ' Only replace the context if it has already been handled
    ' by forms authentication module (user is authenticated)
    If app.Request.IsAuthenticated Then
      Dim con As SqlConnection
      Dim sql As String
      Dim cmd As SqlCommand

      Dim id As String = Context.User.Identity.Name

      con = New SqlConnection( _
        ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
      sql = "SELECT IsAdministrator FROM [User] WHERE UserId='{0}'"
      sql = String.Format(sql, id)
      cmd = New SqlCommand(sql, con)
      con.Open()

      ' Ensure closing the connection
      Try
        Dim admin As Object = cmd.ExecuteScalar()

        ' Was it a valid UserID?
        If Not (admin Is Nothing) Then
          Dim ppal As GenericPrincipal
          Dim roles() As String

          ' If IsAdministrator field is true, add both roles
          If CBool(admin) = True Then
            roles = New String() {"User", "Admin"}
          Else
            roles = New String() {"User"}
          End If

          ppal = New GenericPrincipal(Context.User.Identity, roles)
          Context.User = ppal
        Else
          ' If UserID was invalid, clear the context so they log on again
          Context.User = Nothing
        End If
      Finally
        con.Close()
      End Try
    End If

  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    System.Diagnostics.EventLog.WriteEntry("FriendsReunion", _
      Server.GetLastError().InnerException.ToString(), _
      System.Diagnostics.EventLogEntryType.Error)
  End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    Application.Lock()
    If Application("counter") Is Nothing Then
      Application("counter") = 1
    Else
      Application("counter") = CType(Application("counter"), Integer) + 1
    End If
    Application.UnLock()
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Fires when the session ends
  End Sub

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the connection string from the existing key in Web.config
    Dim con As SqlConnection = New SqlConnection( _
      ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
    Dim cmd As SqlCommand = New SqlCommand("SELECT Visitors FROM Counter", con)
    con.Open()
    Try
      ' Retrieve the counter
      Application("counter") = CType(cmd.ExecuteScalar(), Integer)
    Finally
      con.Close()
    End Try

    ' Force caching of places
    FriendsUtility.GetPlacesDataSet()
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Get the connection string from the existing key in Web.config
    Dim con As SqlConnection = New SqlConnection( _
      ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))
    Dim cmd As SqlCommand = New SqlCommand( _
      "UPDATE Counter SET Visitors=" & Application("counter"), con)
    con.Open()
    Try
      cmd.ExecuteNonQuery()
    Finally
      con.Close()
    End Try
  End Sub

End Class
