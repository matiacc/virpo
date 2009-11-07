<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Bandas.aspx.cs" Inherits="Bandas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
             <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
             <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e Integrantes</a></li>
             <li><a href="ListarBandas.aspx" title="Listar Bandas">Listar Bandas</a></li>
             <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
<center style="background-color: #333333; width: 523px;"><tituloSubVentana>Bandas</tituloSubVentana></center></td>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Image ID="Image4" runat="server" Height="128px" 
                    ImageUrl="~/Images/4.png" Width="128px" />
                <asp:Image ID="Image3" runat="server" Height="128px" 
                    ImageUrl="~/Images/3.png" Width="128px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Image ID="Image1" runat="server" Height="128px" 
                    ImageUrl="~/Images/1.png" Width="128px" />
            </td>
            <td>
                <asp:Image ID="Image5" runat="server" Height="256px" 
                    ImageUrl="~/Images/5.png" Width="256px" />
                <asp:Image ID="Image2" runat="server" Height="128px" 
                    ImageUrl="~/Images/2.png" Width="128px" />
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

