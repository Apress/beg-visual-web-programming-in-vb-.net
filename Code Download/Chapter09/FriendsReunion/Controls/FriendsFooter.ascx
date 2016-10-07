<%@ Control Language="vb" AutoEventWireup="false"
            Codebehind="FriendsFooter.ascx.vb"
            Inherits="FriendsReunion.FriendsFooter"
            TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:panel id="pnlFooterGlobal" cssclass="FooterFriends" runat="server">
  Friends Reunion Application - Courtesy of 
Apress<br><b>Beginning Web Applications<br>
  </b>This site has had 
<asp:label id="lblCounter" runat="server"></asp:label>&nbsp;visitors. 
<asp:image id="imgShow" runat="server" tooltip="Change preferences" imagealign="AbsMiddle"
    imageurl="../Images/down.gif"></asp:image><br>
<div id="tbPrefs" style="DISPLAY: none; TEXT-ALIGN: center">BackColor:
    <asp:dropdownlist id="cbBackColor" runat="server" cssclass="Normal" autopostback="True"></asp:dropdownlist></div>
</asp:panel>
