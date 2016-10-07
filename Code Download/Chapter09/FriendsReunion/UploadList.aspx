<%@ Page language="vb" Codebehind="UploadList.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.UploadList" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>UploadList</title>
    <meta content="False" name="vs_showGrid">
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>You can upload a complete list of attendees and locations using this page. The 
        list must be an XML file in your machine, which must conform to our
        <asp:hyperlink id="hySchema" runat="server" navigateurl="Friends.xsd" target="_blank">schema</asp:hyperlink>. 
        We will show you some statistics about the file prior to actually storing the 
        information in our system. Once the details are accepted, the file will be 
        finally processed and its information stored.</p>
      <p>Select the file to upload: <input class="Button" id="fldUpload" style="WIDTH: 238px" type="file" runat="server">&nbsp;
        <asp:button id="btnLoad" runat="server" text="Load" cssclass="Button"></asp:button>&nbsp;
        <asp:button id="btnReport" runat="server" text="View Report" cssclass="Button"></asp:button></p>
      <p><asp:panel id="Panel1" runat="server">
          <iewc:treeview id="tvXmlView" runat="server" cssclass="TreeView" childtype="Normal" visible="False"
            selectedimageurl="Images/selected.gif" imageurl="Images/findfolder.gif" expandedimageurl="Images/opened.gif">
            <iewc:treenodetype defaultstyle="font-size:8pt;font-family:Tahoma,Verdana,'Times New Roman';" id="Normal"
              type="Normal"></iewc:treenodetype>
            <iewc:treenode text="Friends">
              <iewc:treenode text="User"></iewc:treenode>
            </iewc:treenode>
          </iewc:treeview>
        </asp:panel></p>
      <p><asp:button id="btnAccept" runat="server" text="Accept File" cssclass="Button"></asp:button></p>
      <p><asp:panel id="pnlError" runat="server" visible="False">
          <asp:image id="Image1" runat="server" imageurl="Images/error.gif" imagealign="AbsMiddle"></asp:image>
          <asp:label id="lblError" runat="server" forecolor="Red"></asp:label>
        </asp:panel></p>
      <p>To load a sample XML file existing in our server, click
        <asp:linkbutton id="btnDefaultXml" runat="server">here</asp:linkbutton>. You 
        can also&nbsp;
        <asp:hyperlink id="hyXmlFile" runat="server" navigateurl="upload.xml" target="_blank">view</asp:hyperlink>&nbsp;its 
        content.</p>
    </form>
  </body>
</html>
