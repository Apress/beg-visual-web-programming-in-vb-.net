<%@ Page language="vb" Codebehind="Login.aspx.vb" AutoEventWireup="false" Inherits="FriendsReunion.Login" %>
<%@ Register TagPrefix="uc1" TagName="FriendsFooter" Src="../Controls/FriendsFooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FriendsHeader" Src="../Controls/FriendsHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Login</title>
		<link href="../Style/iestyle.css" rel="stylesheet" type="text/css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body ms_positioning="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<p>
				<uc1:friendsheader id="FriendsHeader1" runat="server"></uc1:friendsheader></p>
			<table id="Table1" cellspacing="1" cellpadding="1" width="300" border="0">
				<tr>
					<td>User Name:</td>
					<td><input type="text" class="TextBox" id="txtLogin" name="Text1" runat="server"></td>
				</tr>
				<tr>
					<td style="HEIGHT: 24px">Password:</td>
					<td style="HEIGHT: 24px"><input type="password" class="TextBox" id="txtPwd" name="Password1" runat="server"></td>
				</tr>
				<tr>
					<td colspan="2">
						<input onclick="alert('About to log in!');" type="button" value="Login" class="Button"
							id="btnLogin" name="Button1" runat="server">
					</td>
				</tr>
			</table>
			<div id="lblMessage" runat="server" ms_positioning="FlowLayout">&nbsp;</div>
			<div ms_positioning="FlowLayout" runat="server">
				<uc1:friendsfooter id="FriendsFooter1" runat="server"></uc1:friendsfooter></div>
		</form>
	</body>
</html>
