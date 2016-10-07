Imports System.Data.SqlClient

Public Class AssignPlaces
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents phPlaces As System.Web.UI.WebControls.PlaceHolder
  Protected WithEvents pnlExisting As System.Web.UI.WebControls.Panel
  Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtYearIn As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtMonthIn As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtYearOut As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtMonthOut As System.Web.UI.WebControls.TextBox
  Protected WithEvents cbPlaces As System.Web.UI.WebControls.DropDownList
  Protected WithEvents txtNotes As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnAdd As System.Web.UI.WebControls.Button

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
    MyBase.HeaderMessage = "Assign Places"

    LoadDataSet()
    InitPlaces()
    InitForm()
  End Sub

  Dim ds As DataSet

  Private Sub LoadDataSet()

    Dim con As New SqlConnection( _
     "data source=.;initial catalog=FriendsData;" + _
     "user id=apress;pwd=apress")

    ' Select the place's timelapse records, descriptions, and type
    Dim sql As String
    sql = "SELECT " + _
     "TimeLapse.*, Place.Name AS Place, " + _
     "PlaceType.Name AS Type " + _
     "FROM " + _
     "TimeLapse, Place, PlaceType " + _
     "WHERE " + _
     "TimeLapse.PlaceID = Place.PlaceID AND " + _
     "Place.TypeID = PlaceType.TypeID AND " + _
     "TimeLapse.UserID = '" + _
     Context.User.Identity.Name + "'"

    ' Initialize the adapters
    Dim adExisting As New SqlDataAdapter(sql, con)
    'Dim adPlaces As New SqlDataAdapter( _
    ' "SELECT * FROM Place ORDER BY TypeID", con)
    Dim adPlaceTypes As New SqlDataAdapter( _
     "SELECT * FROM PlaceType", con)

    con.Open()
    ds = New DataSet

    Try
      ' Proceed to fill the dataset
      adExisting.Fill(ds, "Existing")
      'adPlaces.Fill(ds, "Places")
      adPlaceTypes.Fill(ds, "Types")
    Finally
      con.Close()
    End Try
  End Sub

  Private Sub InitPlaces()
    phPlaces.Controls.Clear()
    Dim msg As String = _
     "Type: {0}, Place: {1}. From {2}/{3} to {4}/{5}. Description: {6}."

    Dim row As DataRow
    For Each row In ds.Tables("Existing").Rows
      Dim lbl As New LiteralControl

      ' Format the msg variable with values in the row
      lbl.Text = String.Format(msg, _
        row("Type"), row("Place"), _
        row("MonthIn"), row("YearIn"), _
        row("MonthOut"), row("YearOut"), row("Name"))

      Dim btn As New LinkButton
      btn.Text = "Delete"

      ' Pass the LapseID when the link is clicked
      btn.CommandArgument = row("LapseID").ToString()

      ' Attach the handler to the event
      AddHandler btn.Command, AddressOf OnDeletePlace

      ' Add the controls to the placeholder
      phPlaces.Controls.Add(lbl)
      phPlaces.Controls.Add(btn)
      phPlaces.Controls.Add(New LiteralControl("<br>"))
    Next
    ' Hide the panel if there are no rows
    If ds.Tables("Existing").Rows.Count > 0 Then
      pnlExisting.Visible = True
    Else
      pnlExisting.Visible = False
    End If
  End Sub

  Private Sub OnDeletePlace(ByVal sender As Object, ByVal e As CommandEventArgs)
    ' e.CommandArgument receives the LapseID to delete
    Dim con As New SqlConnection( _
     "data source=.;initial catalog=FriendsData;" + _
     "user id=sa;pwd=apress")
    Dim cmd As New SqlCommand( _
     "DELETE FROM TimeLapse WHERE LapseID='" + _
     e.CommandArgument.ToString() + "'", con)

    con.Open()

    Try
      cmd.ExecuteNonQuery()
    Finally
      con.Close()
    End Try

    LoadDataSet()
    InitPlaces()
  End Sub

  Private Sub InitForm()
    ' Initialize combo box
    If Not Page.IsPostBack Then
      ' Retrieve the dataset.
      ' If it's not already cached, 
      ' it will be generated automatically and cached.
      Dim cachedDs As DataSet = FriendsUtility.GetPlacesDataSet()

      ' Access the table by index
      Dim row As DataRow
      For Each row In ds.Tables(0).Rows
        ' Find the related row in Types data table (by name now)
        Dim types() As DataRow = ds.Tables("Types").Select( _
         "TypeID='" + row("TypeID") + "'")

        ' Access row columns by name, using default property.
        Dim text As String = types(0)("Name") + ": " + row("Name")
        ' We can access the row's column by index too.
        Dim value As String = row(0).ToString()

        cbPlaces.Items.Add(New ListItem(text, value))
      Next
    End If
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, _
   ByVal e As System.EventArgs) Handles btnAdd.Click
    If Page.IsValid Then
      Dim values As New ArrayList(9)

      Dim sql As String = "INSERT INTO TimeLapse " + _
      "(LapseID, PlaceID, UserID, Name, " + _
      "YearIn, YearOut, MonthIn, MonthOut, Notes) " + _
      "VALUES " + _
      "('{0}', '{1}', '{2}', '{3}', " + _
      "{4}, {5}, {6}, {7}, '{8}')"

      values.Add(Guid.NewGuid().ToString())
      values.Add(cbPlaces.SelectedItem.Value)
      values.Add(Context.User.Identity.Name)
      values.Add(txtDescription.Text)
      values.Add(txtYearIn.Text)
      values.Add(txtYearOut.Text)

      If txtMonthIn.Text.Length <> 0 Then
        values.Add(txtMonthIn.Text)
      Else
        values.Add("Null")
      End If

      If txtMonthOut.Text.Length <> 0 Then
        values.Add(txtMonthOut.Text)
      Else
        values.Add("Null")
      End If

      If txtNotes.Text.Length <> 0 Then
        values.Add(txtNotes.Text)
      Else
        values.Add("Null")
      End If

      sql = String.Format(sql, values.ToArray())

      ' Connect and execute the query
      Dim con As New SqlConnection( _
       "data source=.;initial catalog=FriendsData;" + _
       "user id=sa;pwd=apress")
      Dim cmd As New SqlCommand(sql, con)
      con.Open()
      Try
        cmd.ExecuteNonQuery()
      Finally
        con.Close()
      End Try

      LoadDataSet()
      InitPlaces()
    Else
      Throw New InvalidOperationException("Invalid page data.")
    End If
  End Sub
End Class
