<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarEvento.aspx.cs" Inherits="_Default" Title="Página sin título" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AltaEvento.aspx" title="Nuevo Evento">Nuevo Evento</a></li>
            <li><a href="MisEventos.aspx" title="Mis Eventos">Mis Eventos</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<SCRIPT LANGUAGE="JavaScript">
window.opener.location.reload();
</SCRIPT>

    <table class="style1">
        <tr>
            <td>
             
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                   <asp:Label ID="lblNombre" runat="server" ForeColor="White" ></asp:Label></tituloSubVentana></center>
                
               
            </td>
        </tr>
        
        
    </table>

<table class="tabla" style="height: 665px; width: 527px">
        <tr>
            <td style="height: 15px">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px;" colspan="2">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label1" runat="server" Text="Lugar:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;" colspan="2">
                                <asp:Label ID="lblLugar" runat="server"></asp:Label>
                            </td>
            <td style="width: 295px" rowspan="6">
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="http://www.google.com.ar">
                <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" width="211px" Height="208px" BorderStyle="Solid" /></a>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label7" runat="server" Text="Fecha:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;" colspan="2">
                                <asp:Label ID="lblFecha" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label8" runat="server" Text="Hora:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;" colspan="2">
                                <asp:Label ID="lblHora" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label12" runat="server" Text="País:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;" colspan="2">
                                <asp:Label ID="lblPais" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label13" runat="server" Text="Ciudad:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;" colspan="2">
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 36px">
                    <asp:Label ID="Label4" runat="server" Text="Dirección:" CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="width: 295px; height: 36px;" colspan="2">
                    <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 16px">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;" colspan="2">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 17px">
        <asp:Label ID="Label11" runat="server" 
            Text="Ubicación en Mapa:" Width="130px" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 295px; height: 17px;" colspan="2">
                &nbsp;</td>
            <td style="width: 295px; height: 17px;">
                <asp:Label ID="lblMusico" runat="server" Text="Musico:"></asp:Label>
                &nbsp;&nbsp;
                <asp:HyperLink ID="HpLMusico" runat="server">[HpLMusico]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;" colspan="2">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" >
             <cc1:GMap ID="GMap1" runat="server" Width="527px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
                     
             
                
            <td colspan="2" style="height: 1px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTituloBanda" runat="server" ForeColor="Black" 
                    Font-Bold="True" Font-Size="12pt" Text="Banda Auspiciante" Visible="False"></asp:Label>
                <br />
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 79px">
                <asp:Label ID="lblBanda" runat="server"></asp:Label>
            </td>
            <td colspan="2" style="height: 79px">
            
                &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                </td>
            <td colspan="2" style="height: 35px" align="right">
                <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" onclick="btnDenunciar_Click" />
                &nbsp;</td>
        </tr>
    </table>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    

</asp:Content>

