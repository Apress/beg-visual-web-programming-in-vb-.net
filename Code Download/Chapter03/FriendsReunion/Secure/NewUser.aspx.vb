Public Class NewUser
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub
  Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqLogin As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqPwd As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtFName As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqFName As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtLName As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqLName As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPhone As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqPhone As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents regPhone As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtMobile As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
  Protected WithEvents reqEmail As System.Web.UI.WebControls.RequiredFieldValidator
  Protected WithEvents regEmail As System.Web.UI.WebControls.RegularExpressionValidator
  Protected WithEvents txtBirth As System.Web.UI.WebControls.TextBox
  Protected WithEvents compBirth As System.Web.UI.WebControls.CompareValidator
  Protected WithEvents btnAccept As System.Web.UI.WebControls.Button
  Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
  Protected WithEvents valErrors As System.Web.UI.WebControls.ValidationSummary

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

  Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
    If Page.IsValid Then
      lblMessage.Text = "Validation succeeded!"
    Else
      lblMessage.Text = "Fix the following errors and retry:"
    End If
  End Sub
End Class
