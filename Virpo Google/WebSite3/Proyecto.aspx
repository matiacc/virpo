<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Proyecto.aspx.cs" Inherits="Proyecto" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="botones" 
                    Text="Subir una Composición" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </td>
            <td>
            
                Colaboradores</td>
        </tr>
        <tr>
            <td colspan="2">
                Usuario Creador:                 <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            </td>
            <td>
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    ShowHeader="False" AllowPaging="True" PageSize="5">
                    <Columns>
                        <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
                        </asp:ImageField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Genero :
                <asp:Label ID="lblGenero" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Creado el :&nbsp;
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Licencia :
                <asp:Label ID="lblLicencia" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

