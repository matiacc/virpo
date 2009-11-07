<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoArticuloWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx?A=1" title="Articulo Aleatorio">Articulo 
                Aleatorio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                                Nuevo Articulo WikiMusic</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 137px">
                <asp:Label ID="lblTitulo" runat="server" Style="text-align: right" Text="Titulo"
                    CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
            <td style="text-align: left">
                <div class="loginboxdiv">
                    <asp:TextBox ID="txtTitulo" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 137px">
                &nbsp;
            </td>
            <td style="text-align: left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria" CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server" Height="20px" Style="margin-left: 3px"
                    Width="165px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlCategoria" ErrorMessage="Falta Categoria"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:TextBox ID="elm3" runat="server" TextMode="MultiLine" Height="403px" Width="534px"></asp:TextBox>
    <table class="style1" style="width: 134%">
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
                    Width="90px" CssClass="botones" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"
                    Width="87px" CssClass="botones" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
