<%@ Page language="vb" Codebehind="UploadListReport.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.UploadListReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>UploadListReport</title>
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>Read from the submitted file:</p>
      <p>
        <asp:table id="tbReport" runat="server" cssclass="TableLines" gridlines="Both" cellpadding="0"
          cellspacing="0">
          <asp:tablerow backcolor="#D3E5FA">
            <asp:tablecell text="Query"></asp:tablecell>
            <asp:tablecell text="Value"></asp:tablecell>
          </asp:tablerow>
        </asp:table></p>
      <p>Query course name and attendee from year&nbsp;
        <asp:textbox id="txtYearFrom" runat="server" cssclass="SmallTextBox" maxlength="4" width="36px"></asp:textbox>
        &nbsp;to
        <asp:textbox id="txtYearTo" runat="server" cssclass="SmallTextBox" maxlength="4" width="36px"></asp:textbox>&nbsp;
        <asp:linkbutton id="btnExecute" runat="server">Execute</asp:linkbutton></p>
      <p>
        <asp:table id="tbDates" runat="server" cssclass="TableLines" gridlines="Both" cellpadding="0"
          cellspacing="0" visible="False">
          <asp:tablerow backcolor="#D3E5FA">
            <asp:tablecell text="Course Name"></asp:tablecell>
            <asp:tablecell text="Year In"></asp:tablecell>
            <asp:tablecell text="Year Out"></asp:tablecell>
            <asp:tablecell text="User ID"></asp:tablecell>
          </asp:tablerow>
        </asp:table></p>
      <p>&nbsp;
        <asp:imagebutton id="btnBackImg" runat="server" alternatetext="Back to Upload" imageurl="Images/back.gif"
          imagealign="Middle"></asp:imagebutton>
        <asp:linkbutton id="btnBackLink" runat="server">Back to Upload</asp:linkbutton></p>
      <p>
        <asp:panel id="pnlError" runat="server" visible="False">
          <asp:image id="Image2" runat="server" imagealign="AbsMiddle" imageurl="Images/error.gif"></asp:image>
          <asp:label id="lblError" runat="server" forecolor="Red"></asp:label>
        </asp:panel></p>
    </form>
  </body>
</html>
