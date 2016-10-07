<%@ Register TagPrefix="ap" Namespace="FriendsReunion" Assembly="FriendsReunion" %>
<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="Controls/FriendsFooter.ascx" %>
<%@ Page language="vb" Codebehind="News.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.News" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="Controls/FriendsHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>News</title>
    <link href="Style/iestyle.css" rel="stylesheet" type="text/css">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p class="Normal">
        <uc1:friendsheader id="FriendsHeader1" message="Welcome to the news page!" runat="server"></uc1:friendsheader>
        <ap:subheader id="SubHeader1" runat="server" />
      </p>
      <p class="Normal">Welcome to the news for today! Here is the current calendar:</p>
      <p>
        <asp:calendar id="calDates" runat="server" backcolor="White" width="200px" daynameformat="FirstLetter"
          forecolor="Black" height="180px" font-size="8pt" font-names="Verdana" bordercolor="#999999"
          cellpadding="4">
          <todaydaystyle forecolor="Black" backcolor="#CCCCCC"></todaydaystyle>
          <selectorstyle backcolor="#CCCCCC"></selectorstyle>
          <nextprevstyle verticalalign="Bottom"></nextprevstyle>
          <dayheaderstyle font-size="7pt" font-bold="True" backcolor="#CCCCCC"></dayheaderstyle>
          <selecteddaystyle font-bold="True" forecolor="White" backcolor="#666666"></selecteddaystyle>
          <titlestyle font-bold="True" bordercolor="Black" backcolor="#999999"></titlestyle>
          <weekenddaystyle backcolor="#FFFFCC"></weekenddaystyle>
          <othermonthdaystyle forecolor="#808080"></othermonthdaystyle>
        </asp:calendar></p>
      <p>
        <asp:label id="Label1" runat="server" cssclass="Normal">Selected Date:&nbsp</asp:label>
        <asp:dropdownlist id="cbDay" runat="server" cssclass="TextBox" autopostback="True">
          <asp:listitem value="0" selected="True">Today</asp:listitem>
          <asp:listitem value="1">Tomorrow</asp:listitem>
          <asp:listitem value="-1">Yesterday</asp:listitem>
        </asp:dropdownlist></p>
      <p>
        <asp:label id="lblMessage" runat="server" cssclass="Normal"></asp:label></p>
      <p>
        <uc1:friendsfooter id="FriendsFooter1" runat="server"></uc1:friendsfooter></p>
    </form>
  </body>
</html>
