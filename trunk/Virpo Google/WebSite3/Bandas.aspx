<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Bandas.aspx.cs"
    Inherits="Bandas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
            <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e Integrantes</a></li>
            <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <center style="background-color: #333333; width: 523px;">
        <titulosubventana>
        Bandas
        </titulosubventana>
        <br />
        
    </center>
    <asp:Label ID="lblBandas" runat="server" style="text-align: left"></asp:Label>
</asp:Content>  
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
