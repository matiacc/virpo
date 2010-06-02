<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarArticuloWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx?A=1" title="Novedades">Novedades</a></li>
        </ul>
    </div>
    
    <p style="height: 385px; width: 208px; text-align: right">
    <asp:ImageButton ID="imgPubli1" runat="server" Height="385px" Width="145px" 
            onclick="imgPubli1_Click" />
    </p>
    <div style="text-align: right">
        
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<SCRIPT LANGUAGE="JavaScript">
window.opener.location.reload();
</SCRIPT>
--%>
    <table class="style1">
        <tr>
            <td colspan="2">
                <center style="width: 523px; background-color: #333333">
                    <titulosubventana>
                                WikiMusic</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" abbr="btn" colspan="2">
                <asp:Button ID="btnApuntar" runat="server" OnClick="btnApuntar_Click" Text="Apuntar"
                    CssClass="botones" Width="80px" />
                <asp:Button ID="btnRecomendar" runat="server" CssClass="botones" Text="Recomendar"
                    Width="101px" OnClientClick="javascript:abrirPopup3()" />
                <asp:Button ID="btnEditar" runat="server" CssClass="botones" OnClick="btnEditar_Click"
                    Text="Editar" Width="80px" />
                <asp:Button ID="btnHistorial" runat="server" CssClass="botones" Text="Historial"
                    Width="90px" OnClick="btnHistorial_Click" />
                <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" OnClick="btnDenunciar_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right" colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=".v"></asp:Label>
                <asp:Label ID="lblvers" runat="server"></asp:Label>
                <asp:Label ID="lblGuion" runat="server" Text="   -   "></asp:Label>
                <asp:Label ID="lblCat" runat="server" Font-Italic="True"></asp:Label>
                <asp:Label ID="lblOk" runat="server" Style="color: #009933" Text="Articulo Apuntado"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblMal" runat="server" Style="color: #CC3300" Text="Articulo Ya Apuntado"
                    Visible="False" Width="157px"></asp:Label>
                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label ID="lblVisitas" runat="server" Style="color: #164BA0"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Visitas" Style="color: #164BA0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblContenido" runat="server" Style="text-align: justify"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <asp:ImageButton ID="imgPubli2" runat="server" Height="385px" 
        Width="145px" onclick="imgPubli2_Click" />
</asp:Content>
