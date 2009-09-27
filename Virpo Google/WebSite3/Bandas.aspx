<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Bandas.aspx.cs" Inherits="Bandas" Title="Página sin título" %>

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
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
<center style="background-color: #333333; width: 523px;"><tituloSubVentana>Bandas</tituloSubVentana></center></td>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Image ID="Image1" runat="server" Height="358px" 
                    ImageUrl="~/ImagenesSite/marsahll15.jpg" Width="359px" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

