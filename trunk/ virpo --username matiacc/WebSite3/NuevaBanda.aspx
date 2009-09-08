<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevaBanda.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
            <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Ver Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Nueva Banda</tituloSubVentana></center>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtNombreBanda" runat="server" Width="297px" 
                    style="margin-bottom: 0px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px">
                <asp:Label ID="lblGenero" runat="server" Text="Genero:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left; margin-left: 40px;">
                <asp:DropDownList ID="ddlGenero" runat="server" style="text-align: left">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblFecInicio" runat="server" Text="Fecha de Inicio:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlDia" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlAnio" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblPais" runat="server" Text="Pais:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlPais_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 29px">
                                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlLocalidad" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblSitioWeb" runat="server" Text="Sitio web:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtSitioWeb" runat="server" Width="297px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblFoto" runat="server" Text="Foto:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:FileUpload ID="uploadImagen" runat="server" />
            </td>
        </tr>
        <tr>

            <td style="width: 248px; height: 19px">
                &nbsp;</td>
            <td style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
                &nbsp;</td>
            <td style="height: 19px; text-align: right;">
                <asp:Button ID="btnCrearBanda" runat="server" CssClass="botones" Text="Crear Banda" 
                    Width="148px" onclick="Button3_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
                &nbsp;</td>
            <td style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
                &nbsp;</td>
            <td style="height: 19px; text-align: right;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

