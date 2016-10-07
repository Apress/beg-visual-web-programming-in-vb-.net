Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Text

Public Class UploadListReport
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents tbReport As System.Web.UI.WebControls.Table
  Protected WithEvents txtYearFrom As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtYearTo As System.Web.UI.WebControls.TextBox
  Protected WithEvents btnExecute As System.Web.UI.WebControls.LinkButton
  Protected WithEvents tbDates As System.Web.UI.WebControls.Table
  Protected WithEvents btnBackImg As System.Web.UI.WebControls.ImageButton
  Protected WithEvents btnBackLink As System.Web.UI.WebControls.LinkButton
  Protected WithEvents Image2 As System.Web.UI.WebControls.Image
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents pnlError As System.Web.UI.WebControls.Panel

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
    ' Configure header
    MyBase.HeaderIconImageUrl = "~/Images/print.gif"
    MyBase.HeaderMessage = "Upload Attendees - Report"

    Dim ns As String = "http://www.apress.com/schemas/friendsreunion"
    Try
      ' Retrieve the reader object and initialize the DOM document
      Dim reader As XmlReader = GetReader()
      Dim doc As New XmlDocument
      doc.Load(reader)

      ' Initialize the namespace manager for the document
      Dim mgr As New XmlNamespaceManager(doc.NameTable)
      mgr.AddNamespace("af", ns)

      ' List of new users
      Dim nodes As XmlNodeList = doc.SelectNodes("/af:Friends/af:User", mgr)
      Dim row As TableRow = New TableRow
      Dim cell As TableCell = New TableCell
      cell.Text = "Users: " + nodes.Count.ToString()
      row.Cells.Add(cell)

      Dim sb As StringBuilder = New StringBuilder
      For Each node As XmlNode In nodes
        sb.AppendFormat("{0}, {1} ({2})<br/>", _
          node("LastName", ns).InnerText, _
          node("FirstName", ns).InnerText, _
          node("Email", ns).InnerText)
      Next

      ' Add the cell with the accumulated list.
      cell = New TableCell
      cell.Text = sb.ToString()
      row.Cells.Add(cell)
      tbReport.Rows.Add(row)

      ' Create a navigator over the document.
      Dim nav As XPathNavigator = doc.CreateNavigator()

      ' Total number of attendees anywhere in the document.
      Dim expr As XPathExpression = nav.Compile("count(//af:Attended)")
      ' Set the manager to resolve namespace.
      expr.SetContext(mgr)
      ' Execute expression.
      Dim count As Object = nav.Evaluate(expr)

      ' Build the cell and row that shows the result.
      row = New TableRow
      cell = New TableCell
      cell.Text = "Global count of attendees: " & count
      cell.ColumnSpan = 2
      row.Cells.Add(cell)
      tbReport.Rows.Add(row)

      ' The last attendee in the file, in document order.
      expr = nav.Compile("string(/af:Friends/af:User[position() = last()]/@ID)")
      expr.SetContext(mgr)
      Dim last As Object = nav.Evaluate(expr)

      ' Build the cell and row that shows the result.
      row = New TableRow
      cell = New TableCell
      cell.Text = "Last attendee ID in file: " & last
      cell.ColumnSpan = 2
      row.Cells.Add(cell)
      tbReport.Rows.Add(row)
    Catch ex As Exception
      Me.lblError.Text = ex.Message
      Me.pnlError.Visible = True
    End Try

    If tbReport.Rows.Count = 1 Then
      tbReport.Visible = False
    End If
  End Sub

  Private Function GetReader() As XmlReader
    If Session("xml") Is Nothing Then
      Throw New InvalidOperationException( _
        "No XML file has been uploaded yet.")
    End If

    ' Build the XmlTextReader from the in-memoryt string saved before
    Dim xmlinput As New StringReader(CType(Session("xml"), String))
    Return New XmlTextReader(xmlinput)
  End Function

  Private Sub btnBackImg_Click(ByVal sender As System.Object, _
    ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBackImg.Click
    Response.Redirect("UploadList.aspx")
  End Sub

  Private Sub btnBackLink_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnBackLink.Click
    Response.Redirect("UploadList.aspx")
  End Sub

  Private Sub btnExecute_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnExecute.Click

    Dim ns As String = "http://www.apress.com/schemas/friendsreunion"

    Try
      ' Clear any previous state.
      Dim row As TableRow = tbDates.Rows(0)
      tbDates.Rows.Clear()
      tbDates.Rows.Add(row)

      ' Set up the document.
      Dim doc As New XPathDocument(GetReader())
      ' Get the navigator over the document.
      Dim nav As XPathNavigator = doc.CreateNavigator()
      ' Set up the manager.
      Dim mgr As New XmlNamespaceManager(nav.NameTable)
      mgr.AddNamespace("af", ns)
      ' Build expression to execute
      Dim path As String = String.Format("/af:Friends/af:User/" + _
        "af:Attended[af:YearIn>={0} and af:YearOut<={1}]", _
        txtYearFrom.Text, txtYearTo.Text)
      Dim expr As XPathExpression = nav.Compile(path)
      expr.SetContext(mgr)

      Dim it As XPathNodeIterator = nav.Select(expr)
      Do While it.MoveNext()
        ' Create the empty row and cells.
        row = New TableRow
        row.Cells.Add(New TableCell)
        row.Cells.Add(New TableCell)
        row.Cells.Add(New TableCell)
        row.Cells.Add(New TableCell)
        ' Grab current navigator.
        Dim attended As XPathNavigator = it.Current
        row.Cells(0).Text = attended.GetAttribute("Name", String.Empty)

        ' Iterate children of current Attended element
        attended.MoveToFirstChild()
        Do
          If attended.LocalName = "YearIn" AndAlso _
            attended.NamespaceURI = ns Then
            row.Cells(1).Text = attended.Value
          ElseIf attended.LocalName = "YearOut" AndAlso _
            attended.NamespaceURI = ns Then
            row.Cells(2).Text = attended.Value
          End If
        Loop While attended.MoveToNext()

        ' We have moved to Attended children. 
        ' Reposition to Attended node.
        attended.MoveToParent()
        ' Get the parent (User) ID attribute.
        attended.MoveToParent()
        row.Cells(3).Text = attended.GetAttribute("ID", String.Empty)

        ' Finally add the new row.
        tbDates.Rows.Add(row)
      Loop
      tbDates.Visible = True
    Catch ex As Exception
      lblError.Text = ex.Message
      pnlError.Visible = True
    End Try
  End Sub
End Class
