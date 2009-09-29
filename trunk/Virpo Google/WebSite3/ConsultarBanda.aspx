<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarBanda.aspx.cs" Inherits="ConsultarBanda" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
             <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
             <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e Integrantes</a></li>
             <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%" class="tabla">
        <tr>
            <td colspan="4">
                <center style="background-color: #333333; width: 523px;">
                    <tituloSubVentana>Perfil de la Banda
                <asp:Label ID="lblNombre" runat="server"  
                                style="text-align: right"></asp:Label>
                        </tituloSubVentana>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" Height="250px" 
                    ImageAlign="Left" Width="250px" />
            </td>
            <td>
                <table style="width: 100%; height: 249px">
                    <tr>
                        <td colspan="2" style="text-align: right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Género:" CssClass="estiloLabel"></asp:Label></td>
                        <td> <asp:Label ID="lblGenero" runat="server" Font-Size="Medium"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Página Web:" 
                                CssClass="estiloLabel" Width="150px"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPaginaWeb" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>
                
                <asp:Label ID="Label1" runat="server" Text="Inicio de la Banda:" 
                    CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                
                <asp:Label ID="lblFecInicio" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Localidad:" 
                                CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                            <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="lblId" runat="server" Text="Oculto" Visible="False"></asp:Label>
                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
                <asp:Button ID="btnModificarBanda" runat="server" 
                    onclick="btnModificarBanda_Click" Text="Modificar" CssClass="botones" />
                </td>
            <td style="text-align: right;" colspan="2">
                
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" CssClass="botones" />
            </td>
        </tr>
        <tr>
            <td style="width: 366px">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
         <tr>
            <td style="width: 366px">
                &nbsp;</td>
            <td style="width: 366px" colspan="2">
                &nbsp;</td>
            <td style="text-align: left; width: 198px;">
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="3">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

