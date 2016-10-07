Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.Web.UI.WebControls

Public Class UploadList
  Inherits FriendsBase

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents hySchema As System.Web.UI.WebControls.HyperLink
  Protected WithEvents btnLoad As System.Web.UI.WebControls.Button
  Protected WithEvents btnReport As System.Web.UI.WebControls.Button
  Protected tvXmlView As Microsoft.Web.UI.WebControls.TreeView
  Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
  Protected WithEvents btnAccept As System.Web.UI.WebControls.Button
  Protected WithEvents Image1 As System.Web.UI.WebControls.Image
  Protected WithEvents lblError As System.Web.UI.WebControls.Label
  Protected WithEvents pnlError As System.Web.UI.WebControls.Panel
  Protected WithEvents btnDefaultXml As System.Web.UI.WebControls.LinkButton
  Protected WithEvents hyXmlFile As System.Web.UI.WebControls.HyperLink
  Protected WithEvents fldUpload As System.Web.UI.HtmlControls.HtmlInputFile

  'NOTE: The following placeholder declaration is required by the Web Form Designer.
  'Do not delete or move it.
  Private designerPlaceholderDeclaration As System.Object

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Dim _errors As New StringBuilder

  Private Sub OnValidation(ByVal sender As Object, _
    ByVal e As ValidationEventArgs)
    _errors.AppendFormat("<b>{0}</b>: {1}<br/>", _
      e.Severity.ToString(), e.Message)
  End Sub

  Private Function GetReader() As XmlReader
    If Session("xml") Is Nothing Then
      Throw New InvalidOperationException( _
        "No XML file has been uploaded yet.")
    End If

    ' Build the XmlTextReader from the in-memoryt string saved before
    Dim xmlinput As New StringReader(CType(Session("xml"), String))
    Dim reader = New XmlTextReader(xmlinput)

    ' Configure the validating reader
    Dim validator As New XmlValidatingReader(reader)
    AddHandler validator.ValidationEventHandler, AddressOf OnValidation

    Dim schema As XmlSchema
    Dim fs As FileStream = File.OpenRead( _
      Server.MapPath("~/Friends.xsd"))
    Try
      schema = XmlSchema.Read(fs, Nothing)
    Finally
      fs.Close()
    End Try

    validator.Schemas.Add(schema)
    validator.ValidationType = ValidationType.Schema
    Return validator
  End Function

  Private Sub BuildTreeView()
    ' Keep the current node and its parents
    Dim hierarchy As New Stack(5)
    Dim node As TreeNode
    Dim reader As XmlReader

    pnlError.Visible = False
    ' Save the incoming file if appropriate
    SaveXml()

    Try
      reader = GetReader()
      ' Clear the tree view
      tvXmlView.Nodes.Clear()

      Do While reader.Read()
        ' We create new nodes for all elements.
        If reader.NodeType = XmlNodeType.Element Then
          'Create the new node.
          node = New TreeNode
          node.Text = reader.LocalName
          AddAttributes(reader, node)

          ' Anchor to its parent
          If hierarchy.Count > 0 Then
            CType(hierarchy.Peek(), TreeNode).Nodes.Add(node)
          End If

          ' Set it as the last node in the stack.
          hierarchy.Push(node)
        ElseIf reader.NodeType = XmlNodeType.Text Then
          ' If it's a text, set the text value of the last node.
          CType(hierarchy.Peek(), TreeNode).Text &= _
            ": " & reader.Value
        ElseIf reader.NodeType = XmlNodeType.EndElement Then
          ' Remove the element as we're done with it.
          node = hierarchy.Pop()
        End If
      Loop

      ' Last node will be the root one, with the whole 
      ' hierarchy properly built. Append the file name to it.
      node.Text &= " (" & Session("file").ToString() & ")"

      tvXmlView.Nodes.Add(node)
      tvXmlView.Visible = True

      ' Check for errors accumulated during XSD validation
      Dim msg As String = _errors.ToString()
      If (msg.Length > 0) Then
        pnlError.Visible = True
        lblError.Text = msg
        ' Remove invalid document from session.
        Session.Remove("xml")
      Else
        pnlError.Visible = False
      End If
    Catch ex As Exception
      pnlError.Visible = True
      lblError.Text = ex.Message
      ' Remove invalid document from session.
      Session.Remove("xml")
    End Try
  End Sub

  ' Helper method of BuildTreeView that adds attributes found as 
  ' child nodes of the passed node, using a different icon
  Private Sub AddAttributes(ByVal reader As XmlReader, _
    ByVal node As TreeNode)
    If Not reader.HasAttributes Then
      Return
    End If

    Dim child As TreeNode
    Dim attrs As New TreeNode
    ' Define the node that will contain all attributes.
    attrs.Text = "Attributes (" & _
      reader.AttributeCount & ")"
    attrs.ImageUrl = "Images/attributes.gif"
    attrs.ExpandedImageUrl = "Images/attributes.gif"

    For i As Integer = 0 To reader.AttributeCount - 1
      child = New TreeNode
      ' Move to the appropriate attribute.
      reader.MoveToAttribute(i)
      ' Configure the node and add it to the list of attributes.
      child.Text = reader.Name & ": " & reader.Value
      child.ImageUrl = "Images/emptyfile.gif"
      attrs.Nodes.Add(child)
    Next

    node.Nodes.Add(attrs)
    ' Reposition the reader on the element.
    reader.MoveToElement()
  End Sub

  Private Sub Page_Load(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles MyBase.Load
    HeaderIconImageUrl = "~/Images/pctransfer.gif"
    HeaderMessage = "Upload Attendees"
  End Sub

  Private Sub btnDefaultXml_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnDefaultXml.Click
    Dim sr As New StreamReader(Server.MapPath("~/upload.xml"))

    Try
      Session("xml") = sr.ReadToEnd()
      Session("file") = "Sample file"
    Finally
      sr.Close()
    End Try

    BuildTreeView()
  End Sub

  ' Save the input file if appropriate
  Private Sub SaveXml()
    If Request.Files(0).FileName.Length > 0 Then
      ' Save the uploaded stream to Session for further postbacks
      Dim stm As New StreamReader(Request.Files(0).InputStream)
      Try
        Session("xml") = stm.ReadToEnd()
        Session("file") = Request.Files(0).FileName
      Finally
        stm.Close()
      End Try
    End If
  End Sub

  Private Sub btnLoad_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnLoad.Click
    BuildTreeView()
  End Sub

  ' Recommended approach for caching loaded XSD schema
  Shared _schema As XmlSchema

  Private ReadOnly Property SchemaInstance() As XmlSchema
    Get
      If _schema Is Nothing Then
        Dim fs As Stream = File.OpenRead(Server.MapPath("~/Friends.xsd"))
        Try
          _schema = XmlSchema.Read(fs, Nothing)
        Finally
          fs.Close()
        End Try
      End If
      Return _schema
    End Get
  End Property

  Private Sub btnReport_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles btnReport.Click
    SaveXml()
    Response.Redirect("UploadListReport.aspx")
  End Sub
End Class
