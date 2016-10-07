<%@ Page language="vb" Codebehind="Search.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.Search" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>Search</title>
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <table id="tbResults" cellspacing="1" cellpadding="1" width="100%" border="0">
        <tr>
          <td valign="top">
            <asp:panel id="pnlResults" cssclass="SearchResults" runat="server">
      Search 
      results: 
      <hr width="100%" size="1">
<asp:label id="lblLimit" runat="server"></asp:label><br><br>
<asp:datagrid id="grdResults" runat="server" DataSource="<%# dsResults %>" DataMember="User" EnableViewState="False" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
                <selecteditemstyle font-bold="True" forecolor="#F7F7F7" backcolor="#738A9C"></selecteditemstyle>
                <alternatingitemstyle backcolor="#F7F7F7"></alternatingitemstyle>
                <itemstyle forecolor="#4A3C8C" backcolor="#E7E7FF"></itemstyle>
                <headerstyle font-bold="True" forecolor="#F7F7F7" backcolor="#4A3C8C"></headerstyle>
                <footerstyle forecolor="#4A3C8C" backcolor="#B5C7DE"></footerstyle>
                <pagerstyle horizontalalign="Right" forecolor="#4A3C8C" backcolor="#E7E7FF" mode="NumericPages"></pagerstyle>
                <columns>
                  <asp:templatecolumn headertext="Sel">
                    <itemtemplate>
                      <asp:imagebutton id="imgSel" runat="server" tooltip="Toggle user selection" commandargument='<%# 
													DataBinder.Eval(Container, "DataItem.UserID") %>' 
 commandname="SelectUser" imageurl="Images/unok.gif" />
                    </itemtemplate>
                  </asp:templatecolumn>
                  <asp:boundcolumn datafield="FirstName" headertext="First Name" />
                  <asp:boundcolumn datafield="LastName" headertext="Last Name" />
                  <asp:boundcolumn datafield="PlaceName" headertext="Place" />
                  <asp:boundcolumn datafield="PlaceType" headertext="Type" />
                  <asp:boundcolumn datafield="LapseName" headertext="Lapse" />
                  <asp:boundcolumn datafield="YearIn" headertext="Year In" />
                  <asp:boundcolumn datafield="MonthIn" headertext="Month In" />
                  <asp:boundcolumn datafield="YearOut" headertext="Year Out" />
                  <asp:boundcolumn datafield="MonthOut" headertext="Month Out" />
                </columns>
              </asp:datagrid>
    </asp:panel><br>
            <asp:label id="lblSelected" runat="server" enableviewstate="False"></asp:label>
          </td>
          <td valign="top">
            <asp:panel id="pnlSearch" runat="server" cssclass="Search">Search Friends 
      Reunion: 
      <hr width="100%" size="1">

      <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
                <tr>
                  <td>First Name:</td>
                  <td>
                    <asp:textbox id="txtFirstName" runat="server" cssclass="MediumTextBox"></asp:textbox></td>
                </tr>
                <tr>
                  <td>Last Name:</td>
                  <td>
                    <asp:textbox id="txtLastName" runat="server" cssclass="MediumTextBox"></asp:textbox></td>
                </tr>
                <tr>
                  <td style="HEIGHT: 22px">Place:</td>
                  <td style="HEIGHT: 22px">
                    <asp:dropdownlist id="cbPlace" runat="server" cssclass="MediumTextBox" datavaluefield="PlaceID" datatextfield="Name"></asp:dropdownlist></td>
                </tr>
                <tr>
                  <td>Type:</td>
                  <td>
                    <asp:dropdownlist id="cbType" runat="server" cssclass="MediumTextBox" datavaluefield="TypeID" datatextfield="Name"></asp:dropdownlist></td>
                </tr>
                <tr>
                  <td>Year In:</td>
                  <td>
                    <asp:textbox id="txtYearIn" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
                </tr>
                <tr>
                  <td style="HEIGHT: 25px">Year Out:</td>
                  <td style="HEIGHT: 26px">
                    <asp:textbox id="txtYearOut" runat="server" cssclass="SmallTextBox"></asp:textbox></td>
                </tr>
                <tr>
                  <td colspan="2">
                    <asp:button id="btnSearch" runat="server" cssclass="Button" text="New Search"></asp:button>
                    <asp:button id="btnSearchResults" runat="server" cssclass="Button" text="Within Results"></asp:button></td>
                </tr>
              </table></asp:panel><br>
            <asp:panel id="pnlActions" runat="server" cssclass="Search">Actions: 
      <hr width="100%" size="1">

      <table id="Table2" cellspacing="1" cellpadding="4" width="100%" border="0">
                <tr>
                  <td>
                    <asp:imagebutton id="btnClearResults" runat="server" imageurl="Images/results.gif" tooltip="Clear all results from the search"></asp:imagebutton></td>
                  <td width="100%">Clear Results</td>
                </tr>
                <tr>
                  <td>
                    <asp:imagebutton id="btnClearSelection" runat="server" imageurl="Images/clearselection.gif" alternatetext="Clear the current selection."></asp:imagebutton></td>
                  <td width="100%">Clear Selection</td>
                </tr>
                <tr>
                  <td>
                    <asp:imagebutton id="btnRequest" runat="server" imageurl="Images/requestcontact.gif" tooltip="Send a request for contact to the selected users."></asp:imagebutton></td>
                  <td width="100%">Request Contact</td>
                </tr>
              </table></asp:panel></td>
        </tr>
      </table>
    </form>
  </body>
</html>
