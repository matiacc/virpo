<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="PublicidadModificar.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Permisos">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Permisos">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Permisos">Renovacion</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="5">
                 <center style="width: 529px; background-color: #333333">
                     <titulosubventana>
                        &nbsp;Publicidad</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td style="height: 20px">
                </td>
            <td style="height: 20px; text-align: center;" colspan="2">
                &nbsp;</td>
            <td style="height: 20px">
                </td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa a Publicitar:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEntidad" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblContacto" runat="server" Text="Nombre del Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreContacto" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblTel" runat="server" Text="Telefono de Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelContacto" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblMail" runat="server" Text="Mail de Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailContacto" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label5" runat="server" Text="meses solicitados:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMeses" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Vigencia desde:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtInicio" runat="server" Height="18px" Width="70px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Hasta"></asp:Label>
                <asp:TextBox ID="txtFin" runat="server" Height="18px" Width="70px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblFrec" runat="server" Text="Frecuencia de Aparicion:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFrecuencia" runat="server" Height="22px" Width="43px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblImagen" runat="server" Text="Ruta de la Imagen:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtImagen" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblConsulta" runat="server" Text="Consulta:"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtConsulta" runat="server" Height="111px" 
                    TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnAlta" runat="server" CssClass="botones" 
                    onclick="btnAlta_Click" Text="Alta" />
                <asp:Button ID="btnVolver" runat="server" CssClass="botones" 
                    onclick="btnVolver_Click" Text="Volver" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

