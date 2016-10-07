<%@ OutputCache Duration="300" VaryByParam="none" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Users.aspx.vb" Inherits="FriendsReunion.Users"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Users</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Style/iestyle.css" type="text/css" rel="stylesheet">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>Welcome to the Users Administration page. This is the complete list of users:</p>
      <p>
        <asp:DataGrid id="grdUsers" runat="server" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" Width="100%" DataSource="<%# dsData %>" enableviewstate="False">
          <selecteditemstyle font-bold="True" forecolor="#F7F7F7" backcolor="#738A9C"></selecteditemstyle>
          <alternatingitemstyle backcolor="#F7F7F7"></alternatingitemstyle>
          <itemstyle forecolor="#4A3C8C" backcolor="#E7E7FF"></itemstyle>
          <headerstyle font-bold="True" forecolor="#F7F7F7" backcolor="#4A3C8C"></headerstyle>
          <footerstyle forecolor="#4A3C8C" backcolor="#B5C7DE"></footerstyle>
          <pagerstyle horizontalalign="Right" forecolor="#4A3C8C" backcolor="#E7E7FF" mode="NumericPages"></pagerstyle>
        </asp:datagrid></p>
    </form>
  </body>
</html>
