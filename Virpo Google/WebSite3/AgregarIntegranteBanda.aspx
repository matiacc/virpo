<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AgregarIntegranteBanda.aspx.cs" Inherits="AgregarIntegranteBanda" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
             <li><a href="AgregarIntegranteBanda.aspx" title="Agregar Integrante">Ver Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 232px">
                <br />
                Mis Bandas:
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="width: 145px">
                <asp:DropDownList ID="ddlMisBandas" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 232px">
                &nbsp;</td>
            <td style="width: 145px">
                <asp:Label ID="lblMusicos" runat="server" Text="Músicos:"></asp:Label>
            </td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                <asp:Label ID="lblNvoIntegrante" runat="server" Text="Nuevos Integrantes:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 232px">
                &nbsp;</td>
                                <td style="width: 145px">
                                    <asp:ListBox ID="lbMusicos" runat="server" Height="300px" Width="168px">
                                    </asp:ListBox>
                                </td>
                                <td style="width: 17px">
                                    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                                        Text="&gt;&gt;" Width="30px" />
                                    <asp:Button ID="btnQuitar" runat="server" onclick="btnQuitar_Click" 
                                        Text="&lt;&lt;" Width="30px" />
                                </td>
                                <td style="width: 214px">
                                    <asp:ListBox ID="lbNvosIntegrantes" runat="server" Height="300px" Width="218px">
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 232px">
                                    &nbsp;</td>
                                <td style="width: 145px">
                                    &nbsp;</td>
                                <td style="width: 17px">
                                    &nbsp;</td>
                                <td style="width: 214px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 232px">
                                    &nbsp;</td>
                                <td style="width: 145px">
                                    &nbsp;</td>
                                <td style="width: 17px">
                                    &nbsp;</td>
                                <td style="width: 214px; text-align: right">
                                    <asp:Button ID="btnAgregarIntegrante" runat="server" 
                                        onclick="btnAgregarIntegrante_Click" Text="Agregar Integrante" 
                                        CssClass="botones" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 232px">
                                    &nbsp;</td>
                                <td style="width: 145px">
                                    &nbsp;</td>
                                <td style="width: 17px">
                                    &nbsp;</td>
                                <td style="width: 214px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 232px">
                                    &nbsp;</td>
                                <td style="width: 145px">
                                    &nbsp;</td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 232px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 232px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 232px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td style="width: 17px">
                &nbsp;</td>
            <td style="width: 214px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

