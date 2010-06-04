<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Debate.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
             <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><a href="MisGrupos.aspx" title="Mis Grupos de Interés">Mis Grupos</a></li>
            <li><asp:Label ID="lblDebate" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblProyectos" runat="server"></asp:Label></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                   Debates</tituloSubVentana></center>
    <table class="tabla" style="width: 531px">
        <tr>
            <td style="width: 37px; ">
                &nbsp;</td>
            <td style="text-align: left; width: 114px; ">
                &nbsp;</td>
            <td style="text-align: right; width: 60px; ">
                &nbsp;</td>
            <td style="text-align: center; ">
                 &nbsp;</td>
        </tr>
     </table>
        <table class="tabla" style="width: 531px">
        <tr>
            <td style="width: 37px; background-color: #C0C0C0;">
                &nbsp;</td>
            <td class="estiloLabel" 
                style="text-align: center; width: 212px; background-color: #C0C0C0">
                <asp:Label ID="Label1" runat="server" Text="Topic" 
                    CssClass="estiloLabelCabecera2" Font-Size="Medium"></asp:Label>
            </td>
            <td style="text-align: left; width: 9px; background-color: #C0C0C0;">
                <asp:Label ID="Label5" runat="server" Text="Respuestas " 
                    CssClass="estiloLabelCabecera2" Font-Size="Medium"></asp:Label>
            </td>
            <td style="text-align: center; width: 50px; background-color: #C0C0C0">
                <asp:Label ID="Label4" runat="server" Text="Visitas " 
                    CssClass="estiloLabelCabecera2" Font-Size="Medium"></asp:Label>
            </td>
            <td style="text-align: center; background-color: #C0C0C0">
                <asp:Label ID="Label6" runat="server" Text="Último" 
                    CssClass="estiloLabelCabecera2" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <asp:Label ID="lblTabla" runat="server"></asp:Label>
        
<%--        <tr style="border-style: inset; border-width: thin">
            <td style="width: 37px">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Imagenes/250_Thumb.jpg" onclick="ImageButton1_Click" 
                    Height="50px" Width="50px" />
            </td>
            <td style="width: 178px">
                topico</td>
            <td style="width: 114px">
                respuestas</td>
            <td style="width: 60px">
                visitas</td>
            <td>
                ultimo post</td>
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
        </tr>--%>
        <tr>
            <td style="width: 37px; ">
                &nbsp;</td>
            <td class="estiloLabel" 
                style="text-align: center; width: 212px; ">
                &nbsp;</td>
            <td style="text-align: left; width: 9px; ">
                &nbsp;</td>
            <td style="text-align: center; width: 50px; ">
                &nbsp;</td>
            <td style="text-align: center; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 37px; background-color: #C0C0C0;">
               <asp:Label ID="lblNuevoTopic" runat="server" Width="150px"></asp:Label>
            </td>
            <td class="estiloLabel" 
                style="text-align: center; width: 212px; background-color: #C0C0C0">
                &nbsp;</td>
            <td style="text-align: left; width: 9px; background-color: #C0C0C0;">
                &nbsp;</td>
            <td style="text-align: center; width: 50px; background-color: #C0C0C0">
                &nbsp;</td>
            <td style="text-align: center; background-color: #C0C0C0">
                &nbsp;</td>
        </tr>
        </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

