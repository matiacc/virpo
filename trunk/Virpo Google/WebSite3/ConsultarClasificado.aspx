<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarClasificado.aspx.cs" Inherits="ConsultarClasificado" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            
            <li><a href="AltaClasificado.aspx" title="Nuevo Clasificado">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Mis Avisos Clasificados">Mis Avisos 
                Clasificados</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
            
                <asp:Label ID="lblImagen" runat="server"></asp:Label>
            
            </td>
            <td colspan="3">
                <table style="width: 100%; height: 249px">
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                CssClass="estiloLabelCabeceraPeque" Width="195px">Contactar con el vendedor</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" CssClass="estiloLabelCabecera" 
                                style="text-align: right"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Precio:" CssClass="estiloLabel"></asp:Label></td>
                        <td> <asp:Label ID="lblPrecio" runat="server" Font-Size="Medium"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Cantidad de Visitas:" 
                                CssClass="estiloLabel" Width="150px"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblVisitas" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>
                
                <asp:Label ID="Label1" runat="server" Text="Inicio de Publicacion:" 
                    CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                
                <asp:Label ID="lblInicio" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Fin Publicación:" 
                                CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                <asp:Label ID="Label5" runat="server" Text="Vendedor:" CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                <asp:Label ID="lblVendedor" runat="server" CssClass="estiloLabelCabeceraPeque"></asp:Label>
                            </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 366px" rowspan="2">
                
                <asp:Label ID="Label8" runat="server" CssClass="estiloLabel" 
                    Text="Descripcion:"></asp:Label>
                
            </td>
            <td colspan="2" rowspan="2">
                
              <asp:Label ID="lblDescripcion" runat="server">  </asp:Label>
                
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
                <asp:Label ID="Label3" runat="server" Text="Ubicación:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblUbicacion" runat="server" style="text-align: right"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td style="width: 366px">
                <asp:Label ID="Label6" runat="server" Text="Rubro:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 366px">
                <asp:Label ID="lblRubro" runat="server"></asp:Label>
            </td>
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

