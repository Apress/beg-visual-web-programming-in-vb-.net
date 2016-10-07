Public Class ViewPlace
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.adPlaces = New System.Data.SqlClient.SqlDataAdapter
    Me.cmSelect = New System.Data.SqlClient.SqlCommand
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.cmUpdate = New System.Data.SqlClient.SqlCommand
    Me.dsPlaces = New FriendsReunion.PlaceData
    CType(Me.dsPlaces, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'adPlaces
    '
    Me.adPlaces.SelectCommand = Me.cmSelect
    Me.adPlaces.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Place", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("PlaceID", "PlaceID"), New System.Data.Common.DataColumnMapping("TypeID", "TypeID"), New System.Data.Common.DataColumnMapping("Name", "Name"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("Notes", "Notes"), New System.Data.Common.DataColumnMapping("AdministratorID", "AdministratorID")})})
    Me.adPlaces.UpdateCommand = Me.cmUpdate
    '
    'cmSelect
    '
    Me.cmSelect.CommandText = "SELECT dbo.Place.PlaceID, dbo.Place.TypeID, dbo.Place.Name, dbo.Place.Address, db" & _
    "o.Place.Notes, dbo.Place.AdministratorID, dbo.PlaceType.Name AS TypeName FROM db" & _
    "o.Place INNER JOIN dbo.PlaceType ON dbo.Place.TypeID = dbo.PlaceType.TypeID"
    Me.cmSelect.Connection = Me.cnFriends
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'cmUpdate
    '
    Me.cmUpdate.CommandText = "UPDATE dbo.Place SET PlaceID = @PlaceID, TypeID = @TypeID, Name = @Name, Address " & _
    "= @Address, Notes = @Notes, AdministratorID = @AdministratorID WHERE (PlaceID = " & _
    "@Original_PlaceID)"
    Me.cmUpdate.Connection = Me.cnFriends
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PlaceID", System.Data.SqlDbType.VarChar, 36, "PlaceID"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TypeID", System.Data.SqlDbType.VarChar, 36, "TypeID"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 30, "Name"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.VarChar, 300, "Address"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.VarChar, 300, "Notes"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AdministratorID", System.Data.SqlDbType.VarChar, 36, "AdministratorID"))
    Me.cmUpdate.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PlaceID", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PlaceID", System.Data.DataRowVersion.Original, Nothing))
    '
    'dsPlaces
    '
    Me.dsPlaces.DataSetName = "PlaceData"
    Me.dsPlaces.Locale = New System.Globalization.CultureInfo("en-US")
    CType(Me.dsPlaces, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
  Protected WithEvents dlPlaces As System.Web.UI.WebControls.DataList
  Protected WithEvents adPlaces As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents cmSelect As System.Data.SqlClient.SqlCommand
  Protected WithEvents cmUpdate As System.Data.SqlClient.SqlCommand
  Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Protected WithEvents dsPlaces As FriendsReunion.PlaceData

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
    If Not Page.IsPostBack Then
      BindPlaces()
    End If
  End Sub

  Private Sub BindPlaces()
    adPlaces.Fill(dsPlaces)
    If dsPlaces.Place.Rows.Count = 0 Then
      dlPlaces.Visible = False
    Else
      dlPlaces.DataBind()
    End If
  End Sub

  Private Sub dlPlaces_SelectedIndexChanged(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles dlPlaces.SelectedIndexChanged
    ' Remove the edit index just in case we were editing
    dlPlaces.EditItemIndex = -1
    BindPlaces()
  End Sub

  Private Sub dlPlaces_ItemDataBound(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) _
    Handles dlPlaces.ItemDataBound

    ' Is the item selected?
    If e.Item.ItemType = ListItemType.SelectedItem Then
      ' Locate the hidden Label containing the AdministratorID
      Dim admin As Label = CType(e.Item.FindControl("lblAdministratorID"), Label)
      ' If it matches the current user, show the Edit button
      If admin.Text = Page.User.Identity.Name Then
        e.Item.FindControl("cmdEdit").Visible = True
      End If
    End If

  End Sub

  Private Sub dlPlaces_EditCommand(ByVal source As Object, _
    ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) _
    Handles dlPlaces.EditCommand
    ' Save the edit index
    dlPlaces.EditItemIndex = e.Item.ItemIndex
    BindPlaces()
  End Sub

  Private Sub dlPlaces_CancelCommand(ByVal source As Object, _
    ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) _
    Handles dlPlaces.CancelCommand
    ' Reset the edit index
    dlPlaces.EditItemIndex = -1

    ' Set the selected item to the currently editing item
    dlPlaces.SelectedIndex = e.Item.ItemIndex
    BindPlaces()
  End Sub

  Private Sub dlPlaces_UpdateCommand(ByVal source As Object, _
    ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) _
    Handles dlPlaces.UpdateCommand
    ' Find the updated controls
    Dim addr As TextBox = CType(e.Item.FindControl("txtAddress"), TextBox)
    Dim notes As TextBox = CType(e.Item.FindControl("txtNotes"), TextBox)
    Dim place As Label = CType(e.Item.FindControl("lblPlaceID"), Label)
    ' Reload the dataset and locate the relevant row
    adPlaces.Fill(dsPlaces)
    Dim sql As String = "PlaceID = '" + place.Text + "'"
    Dim row As PlaceData.PlaceRow = CType(dsPlaces.Place.Select(sql)(0), PlaceData.PlaceRow)
    ' Set the values using the typed properties
    row.Address = addr.Text
    row.Notes = notes.Text

    ' Update the row in the database
    adPlaces.Update(New DataRow() {row})

    ' Reset datalist state and bind
    dlPlaces.EditItemIndex = -1
    dlPlaces.SelectedIndex = e.Item.ItemIndex
    dlPlaces.DataBind()
  End Sub
End Class
