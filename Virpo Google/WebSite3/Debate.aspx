<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Debate.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
             <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
             <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e 
                 Integrantes</a></li>
             <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="tabla" style="width: 531px">
        <tr>
            <td style="width: 37px; background-color: #C0C0C0;">
                &nbsp;</td>
            <td class="estiloLabel" 
                style="text-align: center; width: 178px; background-color: #C0C0C0">
                <asp:Label ID="Label1" runat="server" Text="Topic" 
                    CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
            <td style="text-align: left; width: 114px; background-color: #C0C0C0;">
                <asp:Label ID="Label5" runat="server" Text="Respuestas" 
                    CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
            <td style="text-align: right; width: 60px; background-color: #C0C0C0">
                <asp:Label ID="Label4" runat="server" Text="Visitas" 
                    CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
            <td style="text-align: center; background-color: #C0C0C0">
                <asp:Label ID="Label6" runat="server" Text="Ultimo" 
                    CssClass="estiloLabelCabecera2"></asp:Label>
            </td>
        </tr>
        <tr style="border-style: inset; border-width: thin">
            <td style="width: 37px">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Imagenes/250_Thumb.jpg" onclick="ImageButton1_Click" 
                    Height="50px" Width="50px" />
            </td>
            <td style="width: 178px">
                <asp:Label ID="Label2" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 114px">
                <asp:Label ID="Label7" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 60px">
                <asp:Label ID="Label9" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr style="border-style: inset; border-width: thin">
            <td style="width: 37px">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/ImagenesBandas/362_Thumb.jpg" Height="50px" Width="50px" />
            </td>
            <td style="width: 178px">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="width: 114px">
                <asp:Label ID="Label8" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 60px">
                <asp:Label ID="Label10" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Label" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

