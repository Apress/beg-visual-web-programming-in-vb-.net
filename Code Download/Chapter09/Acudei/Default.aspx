<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="Acudei._Default"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Default</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <p>Welcome to ACUDEI English Academy.</p>
      <p>We are associates of the Friends Reunion community, and
        <asp:label id="txtCount" runat="server"></asp:label>&nbsp;of its members have 
        taken at least one course here.<br>
        To have a quick look at your contacts in the Friends Reunion community, please 
        enter your login and password:</p>
      <p>Login:
        <asp:textbox id="txtLogin" runat="server"></asp:textbox><br>
        Password:
        <asp:textbox id="txtPassword" runat="server"></asp:textbox><br>
        <asp:button id="btnRefresh" runat="server" text="Refresh"></asp:button></p>
      <p>
        <asp:datagrid id="grdContacts" runat="server"></asp:datagrid></p>
      <asp:label id="lblError" runat="server" visible="False" forecolor="Red" enableviewstate="False"></asp:label>
    </form>
  </body>
</html>
