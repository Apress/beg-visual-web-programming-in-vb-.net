<%@ Page language="vb" Codebehind="RequestContact.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.RequestContact" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>RequestContact</title>
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>Send a message to your buddies so that they know you are looking for them!
      </p>
      <p>
        <asp:textbox id="txtMessage" runat="server" cssclass="BigTextBox" maxlength="300" textmode="MultiLine"
          width="424px" rows="5"></asp:textbox></p>
      <p>
        <asp:button id="btnSend" runat="server" text="Send" cssclass="Button"></asp:button></p>
      <p>
        <asp:listbox id="lstUsers" runat="server" cssclass="Normal" width="224px" rows="5"></asp:listbox></p>
      <p>
        <asp:label id="lblSuccess" runat="server" font-bold="True" forecolor="#0000C0"></asp:label></p>
    </form>
  </body>
</html>
