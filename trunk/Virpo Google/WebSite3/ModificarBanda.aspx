<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarBanda.aspx.cs" Inherits="ModificarBanda" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td rowspan="11">
                <asp:Image ID="ImgBanda" runat="server" Height="250px" Width="250px" />
            </td>
            <td>
                Modificar Banda</td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGenero" runat="server" Text="Genero:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGenero" runat="server" Width="175px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Página Web:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPaginaWeb" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Inicio de la Banda:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFecInicio" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="País:"></asp:Label>
            </td>
            <td rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlPais_SelectedIndexChanged" Width="175px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlProvincia_SelectedIndexChanged" Width="175px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" 
                            Width="175px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Provincia:"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Localidad:"></asp:Label>
            </td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                    Text="Guardar" />
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

