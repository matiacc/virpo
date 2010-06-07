<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="AdminPublicidad.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Vuelve al Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Pedidos de Publicidad">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Publicidades Vigentes">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Publicidades Vencidas">Renovación</a></li>
            <li><a href="PublicidadEjecutarBajas.aspx" title="Publicidades a Eliminar">Ejecutar 
                Bajas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <center style="width: 530px; background-color: #333333">
                    <titulosubventana>
                        Administrar Publicidad</titulosubventana>
                </center>    
    <p>
        <table class="style1" style="width: 131%">
            <tr>
                <td>
        <asp:Label ID="lblOk" runat="server" ForeColor="#009900" 
            Text="La Transacción fue Exitosa..." Visible="False"></asp:Label>
        <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" 
            Text="Error al Procesar la Transacción..." Visible="False"></asp:Label>        
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="Image1" runat="server" Height="425px" 
                        ImageUrl="~/ImagenesSite/megaphone.png" Width="427px" />
                </td>
            </tr>
        </table>
    </p>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

