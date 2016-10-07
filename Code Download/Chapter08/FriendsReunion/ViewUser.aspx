<%@ Page language="vb" Codebehind="ViewUser.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.ViewUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>ViewUser</title>
    <link href="Style/iestyle.css" rel="stylesheet" type="text/css">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>
        <table class="TableLines" id="tbLogin" cellspacing="2" cellpadding="2" width="300" border="0">
          <tr>
            <td>Name</td>
            <td>
              <asp:label id="lblName" runat="server" 
       text='<%# dsUser.Tables(0).Rows(0)("FirstName") + " " + _
        dsUser.Tables(0).Rows(0)("LastName") %>'>
              </asp:label></td>
          </tr>
          <tr>
            <td>Birth Date:</td>
            <td>
              <asp:label id="lblBirth" runat="server"
            text='<%# DataBinder.Eval( _
              dsUser.Tables(0).Rows(0), _
              "(DateOfBirth)", "{0:MMMM dd, yyyy}") %>'/></td>
          <tr>
            <td>Phone Number:</td>
            <td>
              <asp:label id="lblPhone" runat="server" 
       text='<%# DataBinder.Eval( _
          dsUser.Tables("User").Rows(0),"(PhoneNumber)") %>'>
              </asp:label></td>
          </tr>
          <tr>
            <td>Mobile Number:</td>
            <td>
              <asp:label id="lblMobile" runat="server" 
        text='<%# dsUser.Tables("User").Rows(0)("CellNumber") %>'>
              </asp:label></td>
          </tr>
          <tr>
            <td>Address:</td>
            <td>
              <asp:label id="lblAddress" runat="server"
            text='<%# DataBinder.Eval(dsUser.Tables("User").Rows(0), "(Address)") %>'>
              </asp:label></td>
          </tr>
          <tr>
            <td>E-mail:</td>
            <td>
              <asp:hyperlink id="lnkEmail" runat="server" 
            navigateurl='<%# DataBinder.Eval(dsUser.Tables("User").Rows(0), "(Email)", "mailto:{0}") %>'>
            Send mail
          </asp:hyperlink></td>
          </tr>
        </table>
      </p>
      <p>You have
        <asp:label id="lblPending" runat="server"
        text="<%# GetPending() %>">
        </asp:label>&nbsp;pending requests for contact.</p>
      <p>
        <asp:button id="btnAuthorize" runat="server" text="Authorize Contact" cssclass="Button"></asp:button>
      </p>
    </form>
  </body>
</html>
