Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text

Public Class Search
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Me.cnFriends = New System.Data.SqlClient.SqlConnection
    Me.cmPlace = New System.Data.SqlClient.SqlCommand
    Me.cmType = New System.Data.SqlClient.SqlCommand
    Me.dsResults = New System.Data.DataSet
    CType(Me.dsResults, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'cnFriends
    '
    Me.cnFriends.ConnectionString = CType(configurationAppSettings.GetValue("cnFriends.ConnectionString", GetType(System.String)), String)
    '
    'cmPlace
    '
    Me.cmPlace.CommandText = "SELECT PlaceID, Name FROM Place ORDER BY Name"
    Me.cmPlace.Connection = Me.cnFriends
    '
    'cmType
    '
    Me.cmType.CommandText = "SELECT TypeID, Name FROM PlaceType ORDER BY Name"
    Me.cmType.Connection = Me.cnFriends
    '
    'dsResults
    '
    Me.dsResults.DataSetName = "NewDataSet"
    Me.dsResults.Locale = New System.Globalization.CultureInfo("en-US")
    CType(Me.dsResults, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
  Protected WithEvents lblLimit As System.Web.UI.WebControls.Label
  Protected WithEvents grdResults As System.Web.UI.WebControls.DataGrid
  Protected WithEvents pnlResults As System.Web.UI.WebControls.Panel
  Protected WithEvents lblSelected As System.Web.UI.WebControls.Label
  Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
  Protected WithEvents cbPlace As System.Web.UI.WebControls.DropDownList
  Protected WithEvents cbType As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtYearIn As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtYearOut As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
  Protected WithEvents btnSearchResults As System.Web.UI.WebControls.Button
  Protected WithEvents pnlSearch As System.Web.UI.WebControls.Panel
  Protected WithEvents btnClearResults As System.Web.UI.WebControls.ImageButton
  Protected WithEvents btnClearSelection As System.Web.UI.WebControls.ImageButton
  Protected WithEvents btnRequest As System.Web.UI.WebControls.ImageButton
  Protected WithEvents pnlActions As System.Web.UI.WebControls.Panel
  Protected WithEvents cnFriends As System.Data.SqlClient.SqlConnection
  Protected WithEvents cmPlace As System.Data.SqlClient.SqlCommand
  Protected WithEvents cmType As System.Data.SqlClient.SqlCommand
  Protected WithEvents dsResults As System.Data.DataSet

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
    MyBase.HeaderIconImageUrl = "~/Images/search.gif"
    MyBase.HeaderMessage = "Search Users"

    If Not Page.IsPostBack Then
      cnFriends.Open()
      ' Initialize comboboxes
      Try
        Dim reader As SqlDataReader = cmPlace.ExecuteReader()
        Try
          cbPlace.DataSource = reader
          cbPlace.DataBind()
          cbPlace.Items.Add(New ListItem("-- Not selected --", "0"))
          cbPlace.SelectedIndex = cbPlace.Items.Count - 1
        Finally
          reader.Close()
        End Try

        reader = cmType.ExecuteReader()
        Try
          cbType.DataSource = reader
          cbType.DataBind()
          cbType.Items.Add(New ListItem("-- Not selected --", "0"))
          cbType.SelectedIndex = cbType.Items.Count - 1
        Finally
          reader.Close()
        End Try
      Finally
        cnFriends.Close()
      End Try
    End If

    SetResultsState(Not Session("search") Is Nothing)
  End Sub

  Private Sub btnSearch_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnSearch.Click

    Dim limit As Integer = Convert.ToInt32( _
      ConfigurationSettings.AppSettings("searchLimit"))

    Dim sql As New StringBuilder
    ' Limit maximum resultset size
    sql.Append("SELECT TOP ").Append(limit)
    sql.Append(" [User].UserID, [User].FirstName, [User].LastName, ")
    sql.Append(" Place.PlaceID, Place.Name AS PlaceName, ")
    sql.Append(" PlaceType.Name AS PlaceType, PlaceType.TypeID, ")
    sql.Append(" TimeLapse.Name AS LapseName, TimeLapse.YearIn, ")
    sql.Append(" TimeLapse.MonthIn, TimeLapse.YearOut, ")
    sql.Append(" TimeLapse.MonthOut ")
    sql.Append("FROM [User] ")
    sql.Append("LEFT OUTER JOIN TimeLapse ON ")
    sql.Append(" TimeLapse.UserID = [User].UserID ")
    sql.Append("LEFT OUTER JOIN Place ON ")
    sql.Append(" Place.PlaceID = TimeLapse.PlaceID ")
    sql.Append("LEFT OUTER JOIN PlaceType ON ")
    sql.Append(" Place.TypeID = PlaceType.TypeID ")

    ' Build the WHERE clause and accumulate parameters values now
    Dim values As Hashtable = New Hashtable
    Dim qry As StringBuilder = New StringBuilder
    If Not (txtFirstName.Text = String.Empty) Then
      qry.Append("[User].FirstName LIKE @FName AND ")
      values.Add("@FName", "%" & txtFirstName.Text & "%")
    End If
    If Not (txtLastName.Text = String.Empty) Then
      qry.Append("[User].LastName LIKE @LName AND ")
      values.Add("@LName", "%" & txtLastName.Text & "%")
    End If
    ' All other values can take advantage of ADO.NET parameters.
    If Not (cbPlace.SelectedValue = "0") Then
      qry.Append("[Place].PlaceID = @PlaceID AND ")
      values.Add("@PlaceID", cbPlace.SelectedValue)
    End If
    If Not (cbType.SelectedValue = "0") Then
      qry.Append("[PlaceType].TypeID = @TypeID AND ")
      values.Add("@TypeID", cbType.SelectedValue)
    End If
    If Not (txtYearIn.Text = String.Empty) Then
      qry.Append("TimeLapse.YearIn = @YearIN AND ")
      values.Add("@YearIN", txtYearIn.Text)
    End If
    If Not (txtYearOut.Text = String.Empty) Then
      qry.Append("TimeLapse.YearOut = @YearOut AND ")
      values.Add("@YearOut", txtYearOut.Text)
    End If

    Dim filter As String = qry.ToString()
    If Not (filter.Length = 0) Then
      ' Add the filter without the trailing AND
      sql.Append(" WHERE ").Append(filter.Remove(filter.Length - 4, 4))
    End If

    Dim ad As SqlDataAdapter = New SqlDataAdapter(sql.ToString(), cnFriends)
    ' Now add all parameters to the select command.
    For Each prm As DictionaryEntry In values
      ad.SelectCommand.Parameters.Add(prm.Key.ToString(), prm.Value)
    Next

    dsResults = New DataSet
    ad.Fill(dsResults, "User")

    ' Adjust label for results
    If dsResults.Tables("User").Rows.Count < limit Then
      lblLimit.Text = "Found " & _
      dsResults.Tables("User").Rows.Count & _
      " users matching your criteria on initial search."
    Else
      lblLimit.Text = "You're working with the first " & _
        limit & " results.<br/>" & _
        "If you're looking for someone who's not in this list, " & _
        "please search again with a more precise search criterion."
    End If

    ' Place results in session state
    Session("search") = dsResults

    SetResultsState(True)
  End Sub

  Private Sub BindFromSession()
    dsResults = CType(Session("search"), DataSet)
    grdResults.DataBind()
  End Sub

  Private Sub btnSearchResults_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnSearchResults.Click

    dsResults = CType(Session("search"), DataSet)
    ' If we can't get the previous results, then we lost session
    ' information (failure), or no previous results were available.
    ' Default to normal search.
    If dsResults Is Nothing Then
      btnSearch_Click(sender, e)
    End If

    ' We can't use parameters as this is a common filter 
    ' expression to use with the DataSet.
    Dim qry As StringBuilder = New StringBuilder
    If txtFirstName.Text.Length > 0 Then
      qry.Append("FirstName LIKE '%")
      qry.Append(txtFirstName.Text).Append("%' AND ")
    End If
    If txtLastName.Text.Length > 0 Then
      qry.Append("LastName LIKE '%")
      qry.Append(txtLastName.Text).Append("%' AND ")
    End If
    If cbPlace.SelectedItem.Value <> "0" Then
      qry.Append("PlaceID = '")
      qry.Append(cbPlace.SelectedItem.Value).Append("' AND ")
    End If
    If cbType.SelectedItem.Value <> "0" Then
      qry.Append("TypeID = '")
      qry.Append(cbType.SelectedItem.Value).Append("' AND ")
    End If
    If txtYearIn.Text.Length > 0 Then
      qry.Append("YearIn = ")
      qry.Append(txtYearIn.Text).Append(" AND ")
    End If
    If txtYearOut.Text.Length > 0 Then
      qry.Append("YearOut = ")
      qry.Append(txtYearOut.Text).Append(" AND ")
    End If

    Dim filter As String = qry.ToString()
    If Not (filter.Length = 0) Then
      filter = filter.Remove(filter.Length - 4, 4)
    End If
    Dim rows As DataRow() = dsResults.Tables("User").Select(filter)

    ' Rebuild results with new filtered set of rows, 
    ' maintaining structure
    dsResults = dsResults.Clone()
    For Each row As DataRow In rows
      dsResults.Tables("User").ImportRow(row)
    Next

    ' Place results in session state.
    Session("search") = dsResults
    BindFromSession()
  End Sub

  Private Sub btnClearResults_Click(ByVal sender As System.Object, _
    ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClearResults.Click
    Session.Remove("search")
    ViewState.Remove("selected")
    SetResultsState(False)
  End Sub

  Private Sub SetResultsState(ByVal visible As Boolean)
    pnlActions.Visible = visible
    pnlResults.Visible = visible
    btnSearchResults.Visible = visible
    If visible Then
      btnSearch.Text = "New search"
    Else
      btnSearch.Text = "Search"
    End If

    ' If setting to visible, it's because there are results to bind to
    If visible Then
      BindFromSession()
    End If
  End Sub

  Private Sub grdResults_ItemDataBound(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) _
    Handles grdResults.ItemDataBound
    If ViewState("selected") Is Nothing Then Return

    Dim sel As StringCollection = CType(ViewState("selected"), StringCollection)
    Dim img As ImageButton = CType(e.Item.FindControl("imgSel"), ImageButton)

    If img Is Nothing Then Return

    If sel.Contains(img.CommandArgument) Then
      img.ImageUrl = "Images/ok.gif"
      img.CommandName = "DeselectUser"
      e.Item.ForeColor = Color.Red
    End If
  End Sub

  Private Sub grdResults_ItemCommand(ByVal source As Object, _
    ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) _
    Handles grdResults.ItemCommand

    If e.CommandName = "SelectUser" Then
      Dim sel As StringCollection = _
        CType(ViewState("selected"), StringCollection)
      If sel Is Nothing Then
        sel = New StringCollection
        ViewState("selected") = sel
      End If

      If Not sel.Contains(CType(e.CommandArgument, String)) Then
        sel.Add(CType(e.CommandArgument, String))
      End If

      BindFromSession()
    ElseIf e.CommandName = "DeselectUser" Then
      Dim sel As StringCollection = _
        CType(ViewState("selected"), StringCollection)
      sel.Remove(CType(e.CommandArgument, String))

      BindFromSession()
    End If
  End Sub

  Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
    If Not ViewState("selected") Is Nothing Then
      lblSelected.Text = CType(ViewState("selected"), _
        StringCollection).Count & " users selected."
    End If
    MyBase.OnPreRender(e)
  End Sub

  Private Sub btnClearSelection_Click(ByVal sender As System.Object, _
    ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClearSelection.Click
    ViewState.Remove("selected")
    BindFromSession()
  End Sub

  Private Sub btnRequest_Click(ByVal sender As System.Object, _
    ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRequest.Click
    Context.Items("selected") = ViewState("selected")
    Server.Transfer("RequestContact.aspx")
  End Sub
End Class
