<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs"
    Inherits="Perfil" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="ModificarPerfil.aspx" title="Modificar Perfil">Modificar Perfil</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1" style="width: 225%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="Mi Perfil"></asp:Label>
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                <asp:Label ID="lblLogin" runat="server"></asp:Label>
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td rowspan="12" style="width: 310px">
                <asp:Image ID="ImgPerfil" runat="server" Height="300px" Width="300px" />
            </td>
            <td style="width: 160px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label13" runat="server" Text="Instrumento:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblInstrumento" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblFecNac" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblSexo" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lbleMail" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label5" runat="server" Text="Teléfono Fijo:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblTelFijo" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label6" runat="server" Text="Teléfono Móvil:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblTelMovil" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label9" runat="server" Text="Barrio:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblBarrio" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label10" runat="server" Text="Localidad:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label11" runat="server" Text="Provincia:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblProvincia" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label12" runat="server" Text="País:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:Label ID="lblPais" runat="server"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
