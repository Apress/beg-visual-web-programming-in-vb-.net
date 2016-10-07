<%@ Page language="vb" Codebehind="Default.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion._Default" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="Controls/FriendsHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="Controls/FriendsFooter.ascx" %>
<%@ Register TagPrefix="ap"
             Namespace="FriendsReunion" Assembly="FriendsReunion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Default</title>
    <link href="Style/iestyle.css" rel="stylesheet" type="text/css">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>
        Welcome to the Friends Reunion application. Select the desired link to access 
        the functionality on the site:
      </p>
      <p class="Normal">
        <asp:placeholder id="phNav" runat="server"></asp:placeholder></p>
      <p>
        <asp:hyperlink id="lnkUsers" runat="server" navigateurl="Admin/Users.aspx">
      Users Administration Page
    </asp:hyperlink>
      </p>
    </form>
  </body>
</html>
