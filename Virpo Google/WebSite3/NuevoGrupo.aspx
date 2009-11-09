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
            <td>
                Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="241px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Descripción</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Height="129px" Width="388px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Tema</td>
            <td>
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
            <td>
                Imagen</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Tags</td>
            <td>
                <asp:TextBox ID="txtTags" runat="server" Width="241px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btGuardar" runat="server" onclick="btGuardar_Click" 
                    Text="Guardar" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

