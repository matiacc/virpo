<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="NoticiaNueva.aspx.cs" 
Inherits="_Default" Title="Untitled Page" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home Admin</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="BajasNoticias.aspx" title="Bajas">Bajas</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
    
        <asp:Label ID="Label1" runat="server" Text="Posicion:"></asp:Label>
        <asp:DropDownList ID="ddlPosicion" runat="server" Height="23px" Width="122px">
        </asp:DropDownList>
        
        
    </p>
    <p>
    
        <asp:TextBox ID="elm3" runat="server" Height="366px" TextMode="MultiLine" 
            Width="402px"></asp:TextBox>
        
        
    </p>
    <p style="text-align: right">
        <asp:Button ID="btnGuardar" runat="server" CssClass="botones" Text="Guardar" 
            Width="87px" onclick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" CssClass="botones" Text="Limpiar" 
            Width="87px" onclick="btnLimpiar_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

