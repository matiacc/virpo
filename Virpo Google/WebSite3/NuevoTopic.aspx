<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoTopic.aspx.cs" Inherits="NuevoTopic" Title="Página sin título" %>

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
    <table class="tabla">
        <tr>
            <td>
               <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Nuevo Debate</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Titulo</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Width="529px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Comentario</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtComentario" runat="server" Rows="15" TextMode="MultiLine" 
                    Width="529px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btPublicar" runat="server" CssClass="botones" 
                    onclick="btPublicar_Click" Text="Publicar" />
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

