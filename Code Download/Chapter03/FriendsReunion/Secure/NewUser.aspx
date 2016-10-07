<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="../Controls/FriendsFooter.ascx" %>
<%@ Page language="vb" Codebehind="NewUser.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.NewUser" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="../Controls/FriendsHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>NewUser</title>
    <link href="../Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>
        <uc1:friendsheader id="FriendsHeader1" message="Registration form" iconimageurl="../Images/securekeys.gif"
          runat="server"></uc1:friendsheader></p>
      <p>Fill in the fields below to register as a Friends Reunion member:</p>
      <p>
        <table id="Table1" cellspacing="2" cellpadding="2" width="400" border="0">
          <tr>
            <td>User Name:</td>
            <td>
              <asp:textbox id="txtLogin" runat="server" cssclass="TextBox"></asp:textbox>
              <asp:requiredfieldvalidator id="reqLogin" runat="server" errormessage="A user name is required!" controltovalidate="txtLogin"
                display="None"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Password:</td>
            <td>
              <asp:textbox id="txtPwd" runat="server" cssclass="TextBox" textmode="Password"></asp:textbox>
              <asp:requiredfieldvalidator id="reqPwd" runat="server" errormessage="A password is required!" controltovalidate="txtPwd"
                display="None"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td style="HEIGHT: 18px">First Name:</td>
            <td>
              <asp:textbox id="txtFName" runat="server" cssclass="TextBox"></asp:textbox>
              <asp:requiredfieldvalidator id="reqFName" runat="server" errormessage="Enter your first name." controltovalidate="txtFName"
                display="None"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Last Name:</td>
            <td>
              <asp:textbox id="txtLName" runat="server" cssclass="TextBox"></asp:textbox>
              <asp:requiredfieldvalidator id="reqLName" runat="server" errormessage="Enter your last name." controltovalidate="txtLName"
                display="None"></asp:requiredfieldvalidator></td>
          </tr>
          <tr>
            <td>Address:</td>
            <td>
              <asp:textbox id="txtAddress" runat="server" cssclass="TextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Phone Number:</td>
            <td>
              <asp:textbox id="txtPhone" runat="server" cssclass="TextBox"></asp:textbox>
              <asp:requiredfieldvalidator id="reqPhone" runat="server" errormessage="Enter the phone number!" controltovalidate="txtPhone"
                display="None"></asp:requiredfieldvalidator>
              <asp:regularexpressionvalidator id="regPhone" runat="server" errormessage="Enter a valid US phone number!" controltovalidate="txtPhone"
                display="None" validationexpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:regularexpressionvalidator></td>
          </tr>
          <tr>
            <td>Mobile Number:</td>
            <td>
              <asp:textbox id="txtMobile" runat="server" cssclass="TextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>E-mail:</td>
            <td>
              <asp:textbox id="txtEmail" runat="server" cssclass="TextBox"></asp:textbox>
              <asp:requiredfieldvalidator id="reqEmail" runat="server" errormessage="E-mail is required." controltovalidate="txtEmail"
                display="None"></asp:requiredfieldvalidator>
              <asp:regularexpressionvalidator id="regEmail" runat="server" errormessage="Enter a valid e-mail address!" controltovalidate="txtEmail
                display="None" validationexpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
          </tr>
          <tr>
            <td>Birth Date:</td>
            <td>
              <asp:textbox id="txtBirth" runat="server" cssclass="SmallTextBox"></asp:textbox>
              <asp:comparevalidator id="compBirth" runat="server" errormessage="Enter a valid birth date!" controltovalidate="txtBirth"
                display="Dynamic" operator="DataTypeCheck" type="Date"></asp:comparevalidator></td>
          </tr>
          <tr>
            <td align="center" colspan="2">
              <asp:button id="btnAccept" runat="server" cssclass="Button" text="Accept"></asp:button></td>
          </tr>
        </table>
      </p>
      <asp:label id="lblMessage" runat="server" cssclass="Normal"></asp:label>
      <asp:validationsummary id="valErrors" runat="server" cssclass="Normal"></asp:validationsummary>
      <uc1:friendsfooter id="FriendsFooter1" runat="server"></uc1:friendsfooter>
    </form>
  </body>
</html>
