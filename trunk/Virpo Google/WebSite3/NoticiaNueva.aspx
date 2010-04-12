<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="NoticiaNueva.aspx.cs" 
Inherits="_Default" Title="Untitled Page" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home Admin</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="BajasNoticias.aspx" title="Bajas">Modificar &amp; Bajas</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p style="text-align: center">
    
        <asp:Label ID="Label1" runat="server" Text="Posicion:"></asp:Label>
        <asp:DropDownList ID="ddlPosicion" runat="server" Height="22px" Width="138px" 
            style="margin-left: 20px">
        </asp:DropDownList>
        
        
    </p>
    <p style="text-align: right">
    
        <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
        <asp:TextBox ID="txtDesc" runat="server" Width="218px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtDesc" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
        
        
    </p>
    <p>
    
        <asp:TextBox ID="elm3" runat="server" Height="366px" TextMode="MultiLine" 
            Width="402px"></asp:TextBox>
        
        
    </p>
    <p style="text-align: right">
        <asp:Button ID="btnGuardar" runat="server" CssClass="botones" Text="Guardar" 
            Width="87px" onclick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" CssClass="botones" Text="Limpiar" 
            Width="87px" onclick="btnLimpiar_Click" CausesValidation="False" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

