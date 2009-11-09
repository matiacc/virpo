
<%@ Control Language="VB" EnableViewState="False" ClassName="Login" Inherits="DMGForums.Global.Login" %>

<%@ Import Namespace="DMGForums.Global" %>

	<% if ShowLoginPanel then %>

		<% if Session("UserLogged") = "1" then %>
			<table width="97%" align="center" border="0" cellpadding="5" cellspacing="0" class="LoginTable">
			<tr>
			<td width="100%">&nbsp;</td>
			<td width="250" align="center" nowrap>
				<table border="0">
				<tr>
				<td align="center" valign="middle">
					<font size="2" color="<%=Settings.LoginFontColor%>">
						Estas <br>
logueado como <a href="usercp.aspx?ID=<%=Session("UserID")%>"><%=Session("UserName")%></a>
					</font>
				</td>
				<td align="left" valign="middle">
					<asp:button id="logoutbutton" onclick="LogoutUser" runat="server" Text="Salir" CssClass="LoginButton"></asp:button>
				</td>
				</tr>
				</table>
			</td>
			</tr>
			</table>
		<% else %>
			<table width="97%" align="center" border="0" cellpadding="5" cellspacing="0" class="LoginTable">
			<tr>
			<td width="100%">&nbsp;</td>
			<td width="250" align="center" nowrap>
				<table border="0">
				<tr>
				<td>
					<font size="1" color="<%=Settings.LoginFontColor%>">
					<b>Nombre de usuario:</b>
					<br /></font>
					<asp:textbox id="usernamebox" size="10" runat="server" TextMode="SingleLine" CssClass="LoginBox" />
				</td>
				<td>
					<font size="1" color="<%=Settings.LoginFontColor%>">
					<b>Contrase�a:</b>
					<br /></font>
					<asp:textbox id="passwordbox" size="10" runat="server" TextMode="Password" CssClass="LoginBox" />
				</td>
				<td valign="bottom">
					<asp:button id="loginbutton" onclick="LoginUser" runat="server" Text="Entrar" CssClass="LoginButton" />
				</td>
				</tr>
				<tr>
				<td colspan="2">
					<font size="1" color="<%=Settings.LoginFontColor%>">
						<asp:CheckBox id="rememberbox" text="�Recordarme?" checked="true" runat="server" />
					</font>
				</td>
				</tr>
				</table>
			</td>
			</tr>
			</table>
		<% end if %>

	<% end if %>
