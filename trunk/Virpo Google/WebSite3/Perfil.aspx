<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs"
    Inherits="Perfil" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="ModificarPerfil.aspx" title="Modificar Perfil">Modificar Perfil</a></li>
            <li><a href="CambiarPassword.aspx" title="Modificar Perfil">Cambiar Contraseña</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="tabla" style="width: 131%">
        <tr>
            <td colspan="4">
                <center style="width: 528px; background-color: #333333"><tituloSubVentana>Bienvenido
                <asp:Label ID="lblLogin" runat="server"></asp:Label>
                    a tu Perfil</tituloSubVentana></center>&nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label9" runat="server" Text="Barrio:" CssClass="estiloLabel" 
                    Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="lblBarrio" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 11px; " rowspan="13">
                <asp:Image ID="ImgPerfil" runat="server" Height="253px" Width="247px" />
                
            </td>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 105px; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label2" runat="server" Text="Nombre:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label3" runat="server" Text="Apellido:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label13" runat="server" Text="Instrumento:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblInstrumento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblFecNac" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label8" runat="server" Text="Sexo:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblSexo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label4" runat="server" Text="E-mail:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lbleMail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label5" runat="server" Text="Teléfono Fijo:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblTelFijo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label6" runat="server" Text="Teléfono Móvil:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblTelMovil" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label10" runat="server" Text="Ciudad:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label11" runat="server" Text="Estado o Provincia" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblProvincia" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                <asp:Label ID="Label12" runat="server" Text="País:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 105px; ">
                <asp:Label ID="lblPais" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 105px; ">
                &nbsp;</td>
        </tr>

        <tr>
            <td style="width: 11px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 171px; ">
                &nbsp;</td>
            <td style="width: 105px; ">
                &nbsp;</td>
        </tr>

        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
