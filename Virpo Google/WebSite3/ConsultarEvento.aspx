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

    <table class="style1">
        <tr>
            <td>
             
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                   <asp:Label ID="lblNombre" runat="server" ></asp:Label></tituloSubVentana></center>
                
               
            </td>
        </tr>
        
        
    </table>
<table class="tabla">
        <tr>
            <td>
                                &nbsp;</td>
            <td style="width: 295px">
                                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                                <asp:Label ID="Label1" runat="server" Text="Lugar:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px">
                                <asp:Label ID="lblLugar" runat="server"></asp:Label>
                            </td>
            <td style="width: 295px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label14" runat="server" Text="Creador:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Foto Evento:
                            </td>
        </tr>
        <tr>
            <td>
                                <asp:Label ID="Label7" runat="server" Text="Fecha:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px">
                                <asp:Label ID="lblFecha" runat="server"></asp:Label>
                            </td>
            <td style="width: 295px; text-align: right;" rowspan="4">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="81px" 
            onclick="ImageButton1_Click" Width="81px" />
                    <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" width="81px" 
                    Height="81px" />
        
                            </td>
        </tr>
        <tr>
            <td>
                                <asp:Label ID="Label8" runat="server" Text="Hora:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px">
                                <asp:Label ID="lblHora" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td>
                                <asp:Label ID="Label12" runat="server" Text="País:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px">
                                <asp:Label ID="lblPais" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td>
                                <asp:Label ID="Label13" runat="server" Text="Ciudad:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px">
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td>
                    <asp:Label ID="Label4" runat="server" Text="Dirección:" CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="width: 295px">
                    <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                </td>
            <td style="width: 295px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
        <asp:Label ID="Label11" runat="server" 
            Text="Ubicación en Mapa:" Width="130px" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 295px">
                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
            <td style="width: 295px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
    <cc1:GMap ID="GMap1" runat="server" Width="527px" />
    
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    

</asp:Content>

