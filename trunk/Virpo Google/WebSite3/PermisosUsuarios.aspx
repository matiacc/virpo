<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="PermisosUsuarios.aspx.cs" Inherits="_Default" Title="Untitled Page"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="PermisosUsuarios.aspx" title="Permisos">Permisos</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="style1" style="height: 35px">
        <tr>
            <td style="text-align: right;">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Ingrese el id:"></asp:Label>
            </td>
            <td style="text-align: left; ">
                <asp:TextBox ID="txtId" runat="server" Width="37px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ErrorMessage="*" ControlToValidate="txtId"></asp:RequiredFieldValidator>
                &nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="botones" 
                    onclick="btnBuscar_Click" />
                &nbsp;
            </td>
        </tr>
        </table>
    <br />
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right; width: 98px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 124px">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
            <td style="text-align: right; width: 78px">
                <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px">
            </td>
            <td style="height: 21px; width: 98px">
            </td>
            <td style="text-align: right; height: 21px; width: 124px">
                <asp:Label ID="Label4" runat="server" Text="Rol Actual:"></asp:Label>
            </td>
            <td style="height: 21px; width: 78px">
                <asp:Label ID="lblRol" runat="server"></asp:Label>
            </td>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
            </td>
        </tr>
    </table>
    <br />
    <table class="style1" style="width: 100%">
        <tr>
            <td style="text-align: center; width: 77px">
                <asp:Label ID="Label5" runat="server" Text="Nuevo Rol:"></asp:Label>
            </td>
            <td style="text-align: center; width: 308px">
                <asp:DropDownList ID="ddlRol" runat="server" Width="113px">
                </asp:DropDownList>
&nbsp;
                <asp:Button ID="btnCambiar" runat="server" CausesValidation="False" 
                    CssClass="botones" onclick="btnCambiar_Click" Text="Cambiar" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                    CssClass="botones" onclick="btnCancelar_Click" Text="Cancelar" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
