<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="../Controls/FriendsFooter.ascx" %>
<%@ Page Trace="true" language="vb" Codebehind="NewUser.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.NewUser" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="../Controls/FriendsHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>NewUser</title>
    <link href="../Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>Fill in the fields below to register as a Friends Reunion member:</p>
      <p>
        <table id="Table1" cellspacing="2" cellpadding="2" width="400" border="0">
          <tr>
            <td>User Name:</td>
            <td><asp:textbox id="txtLogin" runat="server" cssclass="TextBox"></asp:textbox><asp:requiredfieldvalidator id="reqLogin" runat="server" display="None" controltovalidate="txtLogin" errormessage="A user name is required!"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Password:</td>
            <td><asp:textbox id="txtPwd" runat="server" cssclass="TextBox" textmode="Password"></asp:textbox><asp:requiredfieldvalidator id="reqPwd" runat="server" display="None" controltovalidate="txtPwd" errormessage="A password is required!"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td style="HEIGHT: 18px">First Name:</td>
            <td><asp:textbox id="txtFName" runat="server" cssclass="TextBox"></asp:textbox><asp:requiredfieldvalidator id="reqFName" runat="server" display="None" controltovalidate="txtFName" errormessage="Enter your first name."></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Last Name:</td>
            <td><asp:textbox id="txtLName" runat="server" cssclass="TextBox"></asp:textbox><asp:requiredfieldvalidator id="reqLName" runat="server" display="None" controltovalidate="txtLName" errormessage="Enter your last name."></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Address:</td>
            <td><asp:textbox id="txtAddress" runat="server" cssclass="TextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Phone Number:</td>
            <td><asp:textbox id="txtPhone" runat="server" cssclass="TextBox"></asp:textbox><asp:requiredfieldvalidator id="reqPhone" runat="server" display="None" controltovalidate="txtPhone" errormessage="Enter the phone number!"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regPhone" runat="server" display="None" controltovalidate="txtPhone" errormessage="Enter a valid US phone number!"
                validationexpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:regularexpressionvalidator></td>
          </tr>
          <tr>
            <td>Mobile Number:</td>
            <td><asp:textbox id="txtMobile" runat="server" cssclass="TextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>E-mail:</td>
            <td><asp:textbox id="txtEmail" runat="server" cssclass="TextBox"></asp:textbox><asp:requiredfieldvalidator id="reqEmail" runat="server" display="None" controltovalidate="txtEmail" errormessage="E-mail is required."></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regEmail" runat="server" display="None" controltovalidate="txtEmail" errormessage="Enter a valid e-mail address!"
                validationexpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
          </tr>
          <tr>
            <td>Birth Date:</td>
            <td><asp:textbox id="txtBirth" runat="server" cssclass="SmallTextBox"></asp:textbox><asp:comparevalidator id="compBirth" runat="server" display="Dynamic" controltovalidate="txtBirth" errormessage="Enter a valid birth date!"
                type="Date" operator="DataTypeCheck"></asp:comparevalidator></td>
          </tr>
          <tr>
            <td align="center" colspan="2"><asp:button id="btnAccept" runat="server" cssclass="Button" text="Accept"></asp:button></td>
          </tr>
        </table>
      </p>
      <asp:label id="lblMessage" runat="server" cssclass="Normal" forecolor="Red"></asp:label><asp:validationsummary id="valErrors" runat="server" cssclass="Normal"></asp:validationsummary></form>
  </body>
</html>
