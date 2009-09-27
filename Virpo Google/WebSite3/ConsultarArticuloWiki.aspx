<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarArticuloWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx" title="Articulo Aleatorio">Articulo 
                Aleatorio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    WikiMusic</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lblGuion" runat="server" Text="   -   "></asp:Label>
                <asp:Label ID="lblCat" runat="server" Font-Italic="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            
                <asp:Label ID="lblContenido" runat="server" style="text-align: justify"></asp:Label>
          
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
