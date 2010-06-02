<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoGrupo.aspx.cs" Inherits="NuevoGrupo" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><asp:Label ID="lblMisGrupos" runat="server" Text="Mis Grupos"></asp:Label></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Nuevo Grupo de Interés</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                Nombre:<br />
                <br />
            </td>
            <td class="tabla">
            <div class="loginboxdiv">
                <asp:TextBox ID="txtNombre" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                Descripción:<br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td class="tabla">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="129px" Width="282px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                Tema:</td>
            <td class="tabla">
                <asp:DropDownList ID="ddlTema" runat="server">
                    <asp:ListItem>Instrumento</asp:ListItem>
                    <asp:ListItem>Banda</asp:ListItem>
                    <asp:ListItem>Ubicacion</asp:ListItem>
                    <asp:ListItem>Club de Fan</asp:ListItem>
                    <asp:ListItem>Generico</asp:ListItem>
                    <asp:ListItem>Otro</asp:ListItem>
                    <asp:ListItem>Idioma</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                Imagen:</td>
            <td class="tabla">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                Tags:</td>
            <td class="tabla">
            <div class="loginboxdiv">
                <asp:TextBox ID="txtTags" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            (separados por comas)</td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tabla">
                &nbsp;</td>
            <td class="tabla" style="text-align: right">
                <asp:Button ID="btGuardar" runat="server" onclick="btGuardar_Click" 
                    Text="Guardar" CssClass="botones" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

