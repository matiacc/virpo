<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Default2" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Estadisticas
        <table style="width: 100%">
            <tr>
                <td style="width: 182px">
                    &nbsp;</td>
                <td style="width: 116px">
                    &nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
                <td style="width: 116px">
                    &nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    &nbsp;</td>
                <td style="width: 116px">
                    &nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width: 182px">
                    Id</td>
                <td style="width: 116px">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td style="width: 48px">
                    <asp:Button ID="btBuscar" runat="server" onclick="btBuscar_Click" 
                        Text="Buscar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    Nombre</td>
                <td style="width: 116px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td style="width: 48px">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    Descripcion</td>
                <td style="width: 116px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td style="width: 48px">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Insertar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    &nbsp;</td>
                                        <td style="width: 116px">
                                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                                Text="Modificar" />
                                        </td>
                                        <td style="width: 48px">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 182px">
                                            Id</td>
                <td style="width: 116px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td style="width: 48px">
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        Text="Eliminar" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 182px">
                    &nbsp;</td>
                <td style="width: 116px">
                    &nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 182px">
                    &nbsp;</td>
                <td style="width: 116px">
                    &nbsp;</td>
                <td style="width: 48px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

