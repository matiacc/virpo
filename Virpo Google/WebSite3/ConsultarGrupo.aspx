<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarGrupo.aspx.cs" Inherits="ConsultarGrupo" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="4" style="text-align: center; background-color: #333333">
                <tituloSubVentana><asp:Label ID="lblNombre" runat="server"></asp:Label><tituloSubVentana></td>
            
        </tr>
        <tr>
            <td>
                Creado por</td>
            <td>
                <asp:Label ID="lblCreador" runat="server"></asp:Label>
            </td>
            <td colspan="2" align="right" rowspan="3">
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tema</td>
            <td>
                <asp:Label ID="lblTema" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Miembros (<asp:Label ID="lblCantMiembros" runat="server"></asp:Label>
                )</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMiembros" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Enlaces                 <br />
                Recomendados</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblEnlaces" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btUnirme" runat="server" Text="Unirme al Grupo!" 
                    onclick="btUnirme_Click" CssClass="botones" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

