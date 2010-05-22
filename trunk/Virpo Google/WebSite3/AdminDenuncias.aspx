<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="AdminDenuncias.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminDenuncias.aspx" title="Denuncias">Denuncias</a></li>
            <li><a href="AdminEventos.aspx" title="Eventos">Eventos</a></li>
            <li><a href="AdminProyectos.aspx" title="Proyectos">Proyectos</a></li>
           
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<script language="JavaScript" type="text/javascript">

function leida(url,id) 
{
location.href=url+id
}
 
</script>

<center style="width: 529px; background-color: #333333"><tituloSubVentana>
                  <asp:Label ID="lblTituloDenuncias" runat="server" Text="Denuncias"></asp:Label></tituloSubVentana></center>
                  
    <table class="tabla" border="1" style="width:529px;">
        <asp:Label ID="lblListadoDenuncias" runat="server"></asp:Label>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

