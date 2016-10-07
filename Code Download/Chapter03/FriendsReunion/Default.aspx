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
        <uc1:friendsheader id="ucHeader" runat="server"></uc1:friendsheader>
        <ap:subheader id="ccSubHeader" runat="server" />
      </p>
      <p class="Normal">Welcome to the Friends Reunion web site - the meeting place for 
        lost friends!</p>
      <p class="Normal">
        <asp:placeholder id="phNav" runat="server"></asp:placeholder></p>
      <p>
        <uc1:friendsfooter id="ucFooter" runat="server"></uc1:friendsfooter></p>
    </form>
  </body>
</html>
