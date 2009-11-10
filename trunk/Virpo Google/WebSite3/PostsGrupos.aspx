<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="PostsGrupos.aspx.cs" Inherits="PostsGrupos" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><asp:Label ID="lblMisGrupos" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblDebate" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblProyectos" runat="server"></asp:Label></li>
        </ul>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center style="width: 527px; background-color: #333333"><tituloSubVentana>
                  <asp:Label ID="lblTituloTopic" runat="server"></asp:Label></tituloSubVentana></center>

    <table class="tabla" border="1" style="width:529px;">
    <tr>
            <td align="left">
                    <asp:Label ID="lblResponder" runat="server"></asp:Label>
                    
            </tr>
        <tr>
            <td align="left">
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        
        </tr>
        <asp:Label ID="lblTabla" runat="server"></asp:Label>
       <%-- <tr>
            <td colspan="2" align="right">Fecha Post</td>
        </tr>
        <tr>
            <td><img alt="" src="" /><br />NombreUsuario</td>
            <td>Cuerpo</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

