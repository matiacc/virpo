<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Wikimusic.aspx.cs" Inherits="_Default" Title="Virpo - Musica Colaborativa - Wikimusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
             <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
             <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
             <li><a href="ConsultarArticuloWiki.aspx" title="Articulo Aleatorio">Articulo Aleatorio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    WikiMusic</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                Un espacio dedicado al conocimiento...</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:Image ID="Image1" runat="server" Height="117px" 
    ImageUrl="~/images/logos virpo/biblioteca.png" Width="531px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
    </table>

    <p style="text-align: center">
        &nbsp;</p>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

