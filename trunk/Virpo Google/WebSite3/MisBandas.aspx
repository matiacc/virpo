<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisBandas.aspx.cs" Inherits="MisBandas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
        
            <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Mis Bandas</titulosubventana>
                </center>
    
    <asp:Label ID="lblBandas" runat="server" style="text-align: left"></asp:Label>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

