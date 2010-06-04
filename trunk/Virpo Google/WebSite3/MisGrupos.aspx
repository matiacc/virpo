<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisGrupos.aspx.cs" Inherits="MisGrupos" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><a href="MisGrupos.aspx" title="Mis Grupos de Interés">Mis Grupos</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
                    <center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                        Mis Grupos de Interés</tituloSubVentana></center>
                </td>
                
<table border="0" align="center">
<tr valign="top">
	<td style="width: 719px">
		<table border="0">
		<%--<tbody>--%>
		<tr><td>
		<asp:Label ID="lblGrupos" runat="server"></asp:Label>
		</td>
		</tr> 
            <tr>
            <td><center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Grupos en los que participo</tituloSubVentana></center>
                </td></td>
		    </tr>
        <tr><td>
		<asp:Label ID="lblColaboro" runat="server"></asp:Label></td>
		</tr>
		
		
		<%--</tbody>--%>
		</table>
		</td></tr>
		</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

