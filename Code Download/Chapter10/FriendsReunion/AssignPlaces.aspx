<%@ Page language="vb" Codebehind="AssignPlaces.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.AssignPlaces" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>AssignPlaces</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <asp:panel id="pnlExisting" runat="server">
        <p>These are your registered places:</p>
        <p>
          <asp:placeholder id="phPlaces" runat="server"></asp:placeholder></p>
      </asp:panel>
      <p>Add a new place:</p>
      <p>
        <table id="Table1" cellspacing="1" cellpadding="1" width="300" border="0">
          <tr>
            <td>Description:</td>
            <td>
              <asp:textbox id="txtDescription" runat="server" cssclass="BigTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Year In:</td>
            <td>
              <asp:textbox id="txtYearIn" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Month In:</td>
            <td>
              <asp:textbox id="txtMonthIn" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Year Out:</td>
            <td>
              <asp:textbox id="txtYearOut" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Month Out:</td>
            <td>
              <asp:textbox id="txtMonthOut" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td>Place:</td>
            <td>
              <asp:dropdownlist id="cbPlaces" runat="server" cssclass="BigTextBox"></asp:dropdownlist></td>
          </tr>
          <tr>
            <td>Notes:</td>
            <td>
              <asp:textbox id="txtNotes" runat="server" textmode="MultiLine" cssclass="BigTextBox"></asp:textbox></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:button id="btnAdd" runat="server" text="Add" cssclass="Button"></asp:button></td>
          </tr>
        </table>
      </p>
    </form>
  </body>
</html>
