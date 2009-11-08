<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarEvento.aspx.cs" Inherits="_Default" Title="Página sin título" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <br />
                <asp:Label ID="lblNombre" runat="server" Font-Size="X-Large"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <p>
        <table class="style1">
            <tr>
                <td colspan="2">
                    <table class="style1">
                        <tr>
                            <td style="width: 57px">
                                <asp:Label ID="Label1" runat="server" Text="Lugar:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLugar" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 190px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 190px">
                    <table class="style1" style="width: 99%">
                        <tr>
                            <td style="width: 57px">
                                <asp:Label ID="Label7" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFecha" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table class="style1">
                        <tr>
                            <td style="width: 57px">
                                <asp:Label ID="Label8" runat="server" Text="Hora:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblHora" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 190px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="style1">
                        <tr>
                            <td style="width: 73px">
                                <asp:Label ID="Label12" runat="server" Text="País:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPais" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="style1">
                        <tr>
                            <td style="width: 75px">
                                <asp:Label ID="Label13" runat="server" Text="Ciudad:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 190px">
                    &nbsp;</td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 190px; height: 17px">
                    <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td style="height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 190px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    <br />
</p>
    <p>
        <asp:Label ID="Label11" runat="server" Font-Size="Medium" 
            Text="Ubicación en Mapa:"></asp:Label>
</p>
    <cc1:GMap ID="GMap1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <asp:Image ID="Image1" runat="server" BorderColor="White" 
            BorderStyle="Double" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

