<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="IntegrantesBandas.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="IntegrantesBandas.aspx" title="Nueva Banda">Agregar Integrante</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <asp:Panel ID="pnBandas" runat="server">
        <table class="style1">
            <tr>
                <td colspan="5" style="text-align: center">
                    <asp:Label ID="lblBandas" runat="server" Text="Bandas que Integras"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 82px">
                </td>
                <td colspan="3" style="height: 82px; text-align: center">
                    <asp:GridView ID="gwBandas" runat="server" Height="101px" Width="250px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="height: 82px">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </asp:Panel>
    
    <asp:Panel ID="pnIntegrantes" runat="server">
        <table class="style1">
            <tr>
                <td colspan="5" style="text-align: center">
                    <asp:Label ID="lblIntegrantes" runat="server" Text="Integrantes de "></asp:Label>
                    <asp:Label ID="lblNombreBanda" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 82px">
                </td>
                <td colspan="3" style="height: 82px; text-align: center">
                    <asp:GridView ID="gwIntegrantes" runat="server">
                    </asp:GridView>
                </td>
                <td style="height: 82px">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 200px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="60px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </asp:Panel>
    
    <asp:Panel ID="pnInvitaciones" runat="server">
        <table class="style1">
            <tr>
                <td colspan="5" style="text-align: center; height: 24px;">
                    <asp:Label ID="lblInivitaciones" runat="server" Text="Invitaciones para "></asp:Label>
                    <asp:Label ID="lblNombreBanda2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="height: 27px">
                    <asp:Label ID="ldl" runat="server" style="font-size: x-small" 
                        Text="Ingrese los e-mail separdos por &quot;,&quot;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEMail" runat="server" Width="256px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 220px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </asp:Panel>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
        <br />
    </p>

</asp:Content>

