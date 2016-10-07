<%@ Control Language="vb" AutoEventWireup="false" Codebehind="FriendsHeader.ascx.vb" Inherits="FriendsReunion.FriendsHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:panel id="pnlHeaderGlobal" runat="server" cssclass="HeaderFriends">Friends Reunion 
<asp:image id="imgFriends" cssclass="HeaderImage" runat="server" imageurl="../Images/friends.gif"></asp:image></asp:panel>
<asp:panel id="pnlHeaderLocal" runat="server" cssclass="HeaderTitle">
  <asp:image id="imgIcon" cssclass="HeaderImage" runat="server" imageurl="../Images/homeconnected.gif"></asp:image>
  <asp:label id="lblWelcome" runat="server">Welcome!</asp:label>
</asp:panel>
