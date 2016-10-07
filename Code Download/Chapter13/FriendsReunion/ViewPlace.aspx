<%@ Page language="vb" Codebehind="ViewPlace.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.ViewPlace" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
    <title>ViewPlace</title>
    <link href="Style/iestyle.css" type="text/css" rel="stylesheet">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </head>
  <body ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
      <p>These are the places defined for the application:
      </p>
      <p><asp:datalist id=dlPlaces runat="server" Width="220px" BorderWidth="1px" BorderStyle="Solid" DataKeyField="PlaceID" DataMember="Place" DataSource="<%# dsPlaces %>">
          <headertemplate>
            <asp:panel id="Panel1" runat="server" cssclass="PlaceTitle">List of Places</asp:panel>
          </headertemplate>
          <selecteditemtemplate>
            <div class="PlaceItem" style="WIDTH: 100%; COLOR: white; BACKGROUND-COLOR: #5d90c3" ms_positioning="FlowLayout">
              <asp:panel id="Panel5" runat="server" cssclass="PlaceHeader" backcolor="Gray">
                <asp:image id="Image3" runat="server" imagealign="Middle" imageurl="Images/building.gif"></asp:image>
                <asp:Label id="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                </asp:label>
                <asp:Label id="lblAdministratorID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AdministratorID") %>' CssClass="Hidden">
                </asp:label>
              </asp:panel>Type:
              <asp:Label id="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TypeName") %>'>
              </asp:label><br>
              Address:
              <asp:Label id="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'>
              </asp:label><br>
              Notes:
              <asp:Label id="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Notes") %>'>
              </asp:label><br>
              <asp:imagebutton id="cmdEdit" runat="server" imagealign="Right" imageurl="Images/edit.gif" commandname="Edit"
                alternatetext="Edit" visible="False"></asp:imagebutton></div>
          </selecteditemtemplate>
          <footertemplate>
            <asp:panel id="Panel2" runat="server" cssclass="PlaceSummary">Total Places: 
<asp:Label id="Label1" runat="server" Text="<%# dsPlaces.Place.Rows.Count %>">
              </asp:label></asp:panel>
          </footertemplate>
          <itemtemplate>
            <div class="PlaceItem" style="WIDTH: 100%; BACKGROUND-COLOR: white" ms_positioning="FlowLayout">
              <asp:panel id="Panel3" runat="server" cssclass="PlaceHeader" backcolor="Gainsboro">
                <asp:image id="Image1" runat="server" imagealign="Middle" imageurl="Images/building.gif"></asp:image>
                <asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                </asp:label>
              </asp:panel>
              <asp:imagebutton id="ImageButton1" runat="server" imagealign="Right" imageurl="Images/bluearrow.gif"
                commandname="Select" alternatetext="Select"></asp:imagebutton></div>
          </itemtemplate>
          <alternatingitemtemplate>
            <div class="PlaceItem" style="WIDTH: 100%; BACKGROUND-COLOR: lightskyblue" ms_positioning="FlowLayout">
              <asp:panel id="Panel4" runat="server" cssclass="PlaceHeader" backcolor="Gainsboro">
                <asp:image id="Image2" runat="server" imagealign="Middle" imageurl="Images/building.gif"></asp:image>
                <asp:Label id="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                </asp:label>
              </asp:panel>
              <asp:imagebutton id="Imagebutton2" runat="server" imagealign="Right" imageurl="Images/bluearrow.gif"
                commandname="Select" alternatetext="Select"></asp:imagebutton></div>
          </alternatingitemtemplate>
          <edititemtemplate>
            <div class="PlaceItem" style="WIDTH: 100%; BACKGROUND-COLOR: lemonchiffon" ms_positioning="FlowLayout">
              <asp:panel id="Panel6" runat="server" cssclass="PlaceHeader" backcolor="Wheat">
                <asp:image id="Image4" runat="server" imagealign="Middle" imageurl="Images/edit.gif"></asp:image>
                <asp:Label id="Label12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                </asp:label>
                <asp:Label id="lblPlaceID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlaceID") %>' CssClass="Hidden">
                </asp:label>
              </asp:panel>
              <table class="TableLines" id="Table1" cellspacing="1" cellpadding="1" border="0">
                <tr>
                  <td>Type:</td>
                  <td>
                    <asp:Label id="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TypeName") %>'>
                    </asp:label></td>
                </tr>
                <tr>
                  <td>Address:</td>
                  <td>
                    <asp:TextBox id="txtAddress" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>' CssClass="TextBox" TextMode="MultiLine" Rows="3">
                    </asp:textbox></td>
                </tr>
                <tr>
                  <td>Notes:</td>
                  <td>
                    <asp:TextBox id="txtNotes" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Notes") %>' CssClass="TextBox" TextMode="MultiLine" Rows="3">
                    </asp:textbox></td>
                </tr>
              </table>
              <p>
                <asp:imagebutton id="cmdUpdate" runat="server" imageurl="Images/ok.gif" commandname="Update" alternatetext="Save"></asp:imagebutton>
                <asp:imagebutton id="cmdCancel" runat="server" imageurl="Images/cancel.gif" commandname="Cancel"
                  alternatetext="Cancel"></asp:imagebutton></p>
            </div>
          </edititemtemplate>
        </asp:datalist></p>
    </form>
  </body>
</html>
