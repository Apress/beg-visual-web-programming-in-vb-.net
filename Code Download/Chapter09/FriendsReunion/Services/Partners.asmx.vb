Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Web.Services.Protocols
Imports System.Xml

<System.Web.Services.WebService( _
  Namespace:="http://www.apress.com/services/friendsreunion")> _
Public Class Partners
  Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Web Services Designer.
    InitializeComponent()

    'Add your own initialization code after the InitializeComponent() call

  End Sub

  'Required by the Web Services Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Web Services Designer
  'It can be modified using the Web Services Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Friend WithEvents cmAttendeesCount As System.Data.SqlClient.SqlCommand
  Friend WithEvents cmContacts As System.Data.SqlClient.SqlCommand
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.cmAttendeesCount = New System.Data.SqlClient.SqlCommand
    Me.cmContacts = New System.Data.SqlClient.SqlCommand
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'cmAttendeesCount
    '
    Me.cmAttendeesCount.CommandText = _
      "IF EXISTS(SELECT PlaceID FROM Place WHERE PlaceID = @PlaceID)" & _
      " SELECT COUNT(0) AS Attendees, @PlaceID " & _
      " FROM  (SELECT UserID" & _
      "        FROM   TimeLapse" & _
      "        WHERE PlaceID = @PlaceID" & _
      "        GROUP BY UserID) Users" & _
      "ELSE" & _
      " SELECT -1"
    Me.cmAttendeesCount.Connection = Me.cnFriends
    Me.cmAttendeesCount.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PlaceID", System.Data.SqlDbType.Variant))
    '
    'cmContacts
    '
    Me.cmContacts.CommandText = "SELECT ContactUser.FirstName, ContactUser.LastName, ContactUser.Email, ContactUse" & _
    "r.Notes, ContactUser.IsApproved FROM dbo.[User] INNER JOIN (SELECT [User].FirstN" & _
    "ame, [User].LastName, [User].Email, Contact.Notes, Contact.IsApproved, Contact.D" & _
    "estinationID FROM Contact INNER JOIN [User] ON [User].UserID = Contact.RequestID" & _
    ") ContactUser ON dbo.[User].UserID = ContactUser.DestinationID WHERE (dbo.[User]" & _
    ".Login = @Login) AND (dbo.[User].Password = @Password)"
    Me.cmContacts.Connection = Me.cnFriends
    Me.cmContacts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Login", System.Data.SqlDbType.VarChar, 15, "Login"))
    Me.cmContacts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarChar, 15, "Password"))

  End Sub

  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    'CODEGEN: This procedure is required by the Web Services Designer
    'Do not modify it using the code editor.
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

#End Region

  <WebMethod()> _
  Public Function GetAttendees(ByVal placeId As String) As Integer
    cnFriends.Open()
    Try
      ' Set the place to filter by.
      cmAttendeesCount.Parameters("@PlaceID").Value = placeId

      Dim count As Integer = CType(cmAttendeesCount.ExecuteScalar(), Integer)
      If count = -1 Then
        Throw New SoapException("Invalid Place identifier!", _
          SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri)
      End If

      Return count
    Finally
      cnFriends.Close()
    End Try
  End Function

  <WebMethod(CacheDuration:=600)> _
  Public Function GetContactRequests(ByVal login As String, _
    ByVal password As String) As XmlDocument
    cnFriends.Open()
    Try
      cmContacts.Parameters("@Login").Value = login
      cmContacts.Parameters("@Password").Value = password

      Dim contacts As New DataSet("Contacts")
      Dim ad As New SqlDataAdapter(cmContacts)
      ad.Fill(contacts, "Contact")
      Return New XmlDataDocument(contacts)
    Finally
      cnFriends.Close()
    End Try

  End Function

  <WebMethod(CacheDuration:=600)> _
  Public Function GetContactRequestsCustom(ByVal login As String, _
    ByVal password As String) As _
    <System.Xml.Serialization.XmlRoot("Contacts")> Contact()
    cnFriends.Open()
    Try
      cmContacts.Parameters("@Login").Value = login
      cmContacts.Parameters("@Password").Value = password

      Dim reader As SqlDataReader = cmContacts.ExecuteReader()

      Dim contacts As New ArrayList
      While reader.Read()
        Dim ct As New Contact
        ct.FirstName = CStr(reader("FirstName"))
        ct.LastName = CStr(reader("LastName"))
        ct.Email = CStr(reader("Email"))
        ct.Notes = CStr(reader("Notes"))
        ct.IsApproved = CBool(reader("IsApproved"))
        contacts.Add(ct)
      End While

      Return CType(contacts.ToArray(GetType(Contact)), Contact())
    Finally
      cnFriends.Close()
    End Try

  End Function

End Class

Public Class Contact
  <System.Xml.Serialization.XmlAttribute()> _
   Public FirstName As String
  <System.Xml.Serialization.XmlAttribute()> _
  Public LastName As String
  <System.Xml.Serialization.XmlAttribute()> _
  Public Email As String
  <System.Xml.Serialization.XmlAttribute()> _
  Public Notes As String
  <System.Xml.Serialization.XmlAttribute()> _
  Public IsApproved As Boolean
End Class
