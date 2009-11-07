<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaEvento.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Crear un evento"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <table class="style1">
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label3" runat="server" Text="Lugar:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtLugar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label4" runat="server" Text="Pais:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label5" runat="server" Text="Ciudad:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label6" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label7" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label8" runat="server" Text="Hora:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label9" runat="server" Text="Imagen:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label10" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="52px" 
                    TextMode="MultiLine" Width="165px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label ID="Label11" runat="server" Text="Banda:"></asp:Label>
            </td>
            <td style="width: 197px">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

