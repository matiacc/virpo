<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="GruposDeInteres.aspx.cs" Inherits="_Default" Title="Página sin título" %>

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
                    <titulosubventana>
                        Últimos Grupos de Interés</titulosubventana>
                </center>
<table border="0" align="center">
<tr valign="top">
	<td style="width: 719px">
		<table border="0">
		
		<tr><td>
		<asp:Label ID="lblGrupos" runat="server"></asp:Label>
		</td>
		</tr> 
		</table>
		</td></tr>
		</table>
		</asp:Content>


