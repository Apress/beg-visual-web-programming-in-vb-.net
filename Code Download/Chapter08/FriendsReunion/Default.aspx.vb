Public Class _Default
	Inherits FriendsBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents phNav As System.Web.UI.WebControls.PlaceHolder

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

    Dim tb As New Table
    Dim row As TableRow
    Dim cell As TableCell
    Dim img As System.Web.UI.WebControls.Image
    Dim lnk As HyperLink

    If (Context.User.Identity.IsAuthenticated) Then
      ' Create a new blank table row
      row = New TableRow

      ' Set up the News image
      img = New System.Web.UI.WebControls.Image
      img.ImageUrl = "Images/winbook.gif"
      img.ImageAlign = ImageAlign.Middle
      img.Width = New Unit(24, UnitType.Pixel)
      img.Height = New Unit(24, UnitType.Pixel)

      ' Create a cell and add the image
      cell = New TableCell
      cell.Controls.Add(img)

      ' Add the new cell to the row
      row.Cells.Add(cell)

      ' Set up the News link
      lnk = New HyperLink
      lnk.Text = "News"
      lnk.NavigateUrl = "News.aspx"

      ' Create the cell and add the link
      cell = New TableCell
      cell.Controls.Add(lnk)

      ' Add the new cell to the row
      row.Cells.Add(cell)

      ' Add the row to the table
			tb.Rows.Add(row)


			' Create a new blank table row, this time for Assign Places link
			row = New TableRow

			' Assign Places link
			img = New System.Web.UI.WebControls.Image
			img.ImageUrl = "Images/flatscreenkeyb.gif"
			img.ImageAlign = ImageAlign.Middle
			img.Width = New Unit(24, UnitType.Pixel)
			img.Height = New Unit(24, UnitType.Pixel)

			' Create the cell and add the image
			cell = New TableCell
			cell.Controls.Add(img)

			' Add the cell to the row
			row.Cells.Add(cell)

			' Set up the Assign Places link
			lnk = New HyperLink
			lnk.Text = "Assign Places"
			lnk.NavigateUrl = "AssignPlaces.aspx"

			' Create the cell and add the link
			cell = New TableCell
			cell.Controls.Add(lnk)

			' Add the new cell to the row
			row.Cells.Add(cell)

			' Add the new row to the table
      tb.Rows.Add(row)

      ' ----- Search button ---- 
      ' Create a new blank table row, this time for Search link
      row = New TableRow
      ' Search link
      img = New System.Web.UI.WebControls.Image
      img.ImageUrl = "Images/search.gif"
      img.ImageAlign = ImageAlign.Middle
      img.Width = New Unit(24, UnitType.Pixel)
      img.Height = New Unit(24, UnitType.Pixel)

      ' Create the cell and add the image
      cell = New TableCell
      cell.Controls.Add(img)
      '  Add the cell to the row
      row.Cells.Add(cell)

      ' Set up the Search link
      lnk = New HyperLink
      lnk.Text = "Search"
      lnk.NavigateUrl = "Search.aspx"

      '  Create the cell and add the link
      cell = New TableCell
      cell.Controls.Add(lnk)
      ' Add the new cell to the row
      row.Cells.Add(cell)

      ' Add the new row to the table
      tb.Rows.Add(row)
    Else
      ' Code for unauthenticated users here...
    End If

    ' Finally, add the table to the placeholder
    phNav.Controls.Add(tb)
  End Sub

End Class
