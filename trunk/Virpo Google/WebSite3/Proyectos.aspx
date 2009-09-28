﻿<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Proyectos.aspx.cs" Inherits="Proyectos" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Crear Proyecto</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
<asp:Label ID="lblResultados" runat="server" 
                    Text="No se han encontrado resultados para la búsqueda solicitada." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" 
                    onrowcommand="GridView1_RowCommand" Width="500px" 
                    onpageindexchanging="GridView1_PageIndexChanging" onsorting="GridView1_Sorting" 
                    PageSize="5">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" >
                <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
            </asp:ImageField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                SortExpression="Nombre" />
            <asp:BoundField DataField="Genero" HeaderText="Genero" 
                SortExpression="Genero" />
            <asp:BoundField DataField="Creado" HeaderText="Creado" 
                SortExpression="Creado" />
            <asp:ButtonField ButtonType="Image" CommandName="C" 
                ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar" />
        </Columns>
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

