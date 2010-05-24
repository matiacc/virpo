<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="AdminPublicidad.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Permisos">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Permisos">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Permisos">Renovacion</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblOk" runat="server" ForeColor="#009900" 
            Text="La Transacción fue Exitosa..." Visible="False"></asp:Label>
        <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" 
            Text="Error al Procesar la Transacción..." Visible="False"></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

