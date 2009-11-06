<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarComposicion.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="tabla">
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Detalles de la composicion </titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label1" runat="server" Text="Tipo:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTipo" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label3" runat="server" Text="Tempo:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTempo" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 107px">
                <asp:Label ID="Label4" runat="server" Text="Tonalidad:"></asp:Label>
            </td>
            <td style="height: 23px">
                <asp:Label ID="lblTonalidad" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label5" runat="server" Text="Instrumento:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblInstrumento" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDescripcion" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Autor:"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblAutor" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblNombreAutor" runat="server"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>

