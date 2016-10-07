<%@ Page language="vb" Codebehind="News.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.News" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>News</title>
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p><asp:panel id="pnlApproved" runat="server" designtimedragdrop="32">
          <p>These are your approved contacts:</p>
          <p></p>
          <p>
            <asp:datagrid id="grdApproved" runat="server" borderstyle="None" borderwidth="1px" gridlines="Horizontal" autogeneratecolumns="False" backcolor="White" bordercolor="#E7E7FF" cellpadding="3" datasource="<%# dsApproved %>" AllowPaging="True" PageSize="1">
              <selecteditemstyle font-bold="True" forecolor="#F7F7F7" backcolor="#738A9C"></selecteditemstyle>
              <alternatingitemstyle backcolor="#F7F7F7"></alternatingitemstyle>
              <itemstyle forecolor="#4A3C8C" backcolor="#E7E7FF"></itemstyle>
              <headerstyle font-bold="True" forecolor="#F7F7F7" backcolor="#4A3C8C"></headerstyle>
              <footerstyle forecolor="#4A3C8C" backcolor="#B5C7DE"></footerstyle>
              <columns>
                <asp:boundcolumn datafield="FirstName" headertext="FirstName"></asp:boundcolumn>
                <asp:boundcolumn datafield="LastName" headertext="LastName"></asp:boundcolumn>
								<asp:templatecolumn headertext="Info">
									<itemtemplate>
										<asp:image id="Image1" runat="server" imageurl="Images/phone.gif"></asp:image>
										<asp:label id="Label1" runat="server" text='<%# DataBinder.Eval(Container, "DataItem.PhoneNumber") %>'>
										</asp:label><br>
										<asp:image id="Image2" runat="server" imageurl="Images/home.gif"></asp:image>
										<asp:label id="Label2" runat="server" text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'>
										</asp:label>
									</itemtemplate>
								</asp:templatecolumn>
                <asp:hyperlinkcolumn text="Send mail" datanavigateurlfield="Email" datanavigateurlformatstring="mailto:{0}"
                  headertext="Contact"></asp:hyperlinkcolumn>
                <asp:hyperlinkcolumn text="View" datanavigateurlfield="UserID" datanavigateurlformatstring="ViewUser.aspx?UserID={0}"
                  headertext="Details"></asp:hyperlinkcolumn>
              </columns>
							<pagerstyle nextpagetext="Next &amp;gt;" prevpagetext="&amp;lt; Previous" horizontalalign="Left"
								forecolor="#4A3C8C" backcolor="#E7E7FF"></pagerstyle>
            </asp:datagrid></p>
        </asp:panel><asp:panel id="pnlPending" runat="server">
          <p>These users have requested to contact you:</p>
          <p>
            <asp:datagrid id="grdPending" runat="server" borderstyle="Solid" borderwidth="1px" gridlines="Vertical"
              autogeneratecolumns="False" backcolor="White" forecolor="Black" bordercolor="#999999" cellpadding="3">
              <selecteditemstyle font-bold="True" forecolor="White" backcolor="#000099"></selecteditemstyle>
              <alternatingitemstyle backcolor="#CCCCCC"></alternatingitemstyle>
              <headerstyle font-bold="True" forecolor="White" backcolor="Black"></headerstyle>
              <footerstyle backcolor="#CCCCCC"></footerstyle>
              <columns>
                <asp:boundcolumn datafield="FirstName" headertext="First Name"></asp:boundcolumn>
                <asp:boundcolumn datafield="LastName" headertext="Last Name"></asp:boundcolumn>
                <asp:boundcolumn datafield="Notes" headertext="Notes"></asp:boundcolumn>
                <asp:hyperlinkcolumn text="View" datanavigateurlfield="UserID" datanavigateurlformatstring="ViewUser.aspx?RequestID={0}"
                  headertext="Details"></asp:hyperlinkcolumn>
              </columns>
              <pagerstyle horizontalalign="Center" forecolor="Black" backcolor="#999999"></pagerstyle>
            </asp:datagrid></p>
        </asp:panel>
    </form>
  </body>
</html>
