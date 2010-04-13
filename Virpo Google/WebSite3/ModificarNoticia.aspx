<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="ModificarNoticia.aspx.cs" Inherits="_Default" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="BajasNoticias.aspx" title="Bajas">Modificar &amp; Bajas</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Text="Posicion:"></asp:Label>
        <asp:DropDownList ID="ddlPosicion" runat="server" Height="23px" Width="122px">
        </asp:DropDownList>
    </p>
    <p style="text-align: right">
        <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
        <asp:TextBox ID="txtDesc" runat="server" Height="25px" 
            style="margin-left: 0px; margin-bottom: 1px" Width="219px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtDesc" Display="Dynamic" 
            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox ID="elm3" runat="server" Height="366px" TextMode="MultiLine" Width="402px"></asp:TextBox>
    </p>
    <p style="text-align: right">
        <asp:Button ID="btnGuardar" runat="server" CssClass="botones" 
            onclick="btnGuardar_Click" Text="Guardar" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="botones" 
            onclick="btnCancelar_Click" Text="Cancelar" CausesValidation="False" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
