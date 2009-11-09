<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarArticuloWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" ValidateRequest="false"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <table class="style1">
        <tr>
            <td colspan="3" style="text-align: center">
                Modificar Articulo Wiki
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                <asp:Label ID="lblTit" runat="server" Text="Titulo"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                <asp:Label ID="lblVers" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 13px; width: 258px;">
                <asp:Label ID="lblCat" runat="server" Text="Categoria"></asp:Label>
            </td>
            <td style="height: 13px">
                <asp:Label ID="lblCategoria" runat="server"></asp:Label>
            </td>
            <td style="height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 258px; height: 13px;">
                <asp:Label ID="lblDesc" runat="server" Text="Descripcion de la Modificacion"></asp:Label>
            </td>
            <td style="text-align: left; height: 13px;">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="301px"></asp:TextBox>
            </td>
            <td style="height: 13px">
                <asp:RequiredFieldValidator ID="rvDescrip" runat="server" 
                    ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="(*)" 
                    EnableTheming="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            
                <asp:TextBox ID="elm3" runat="server" Height="399px" Style="margin-left: 0px" TextMode="MultiLine"
                    Width="537px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                &nbsp;
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnGuardar" runat="server" CssClass="botones" Text="Guardar" 
                    onclick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar" 
                    onclick="btnCancelar_Click" CausesValidation="False" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
