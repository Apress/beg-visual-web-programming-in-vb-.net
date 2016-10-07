<%@ Page language="vb" Codebehind="Login.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.Login" %>
<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="../Controls/FriendsFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="../Controls/FriendsHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Login</title>
    <link href="../Style/iestyle.css" rel="stylesheet" type="text/css">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>
        Enter your user name and password to access the special features of this 
        application.</p>
      <table id="Table1" cellspacing="1" cellpadding="1" width="300" border="0">
        <tr>
          <td>User Name:</td>
          <td><input type="text" class="TextBox" id="txtLogin" name="Text1" runat="server"></td>
        </tr>
        <tr>
          <td style="HEIGHT: 24px">Password:</td>
          <td style="HEIGHT: 24px"><input type="password" class="TextBox" id="txtPwd" name="Password1" runat="server"></td>
        </tr>
        <tr>
          <td colspan="2">
            <input type="button" value="Login" class="Button" id="btnLogin" name="Button1" runat="server">
          </td>
        </tr>
      </table>
      <p>
        <asp:panel id="pnlError" runat="server" visible="False"><img src="../Images/error.gif" align="absMiddle">&nbsp; 
<asp:label id="lblError" runat="server" forecolor="Red"></asp:label>
        </asp:panel>
      </p>
    </form>
  </body>
</html>
