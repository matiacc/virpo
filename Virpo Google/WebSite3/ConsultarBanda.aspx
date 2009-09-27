<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarBanda.aspx.cs" Inherits="ConsultarBanda" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="5">
                <asp:Label ID="Label9" runat="server" Text="Datos de la Banda"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" Height="219px" 
                    ImageAlign="Left" Width="250px" />
            </td>
            <td colspan="3">
                <table style="width: 100%; height: 249px">
                    <tr>
                        <td colspan="2" style="text-align: right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="lblNombre" runat="server" Font-Bold="True" CssClass="estiloLabelCabecera" 
                                style="text-align: right"></asp:Label>
                        </td>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 366px" rowspan="2">
                
                &nbsp;</td>
            <td colspan="2" rowspan="2">
                
                <asp:Button ID="btnModificarBanda" runat="server" 
                    onclick="btnModificarBanda_Click" Text="Modificar" />
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" />
            </td>
            <td style="text-align: right">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 366px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td style="width: 366px">
                &nbsp;</td>
            <td style="width: 366px">
                &nbsp;</td>
            <td style="text-align: left; width: 198px;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="2">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

