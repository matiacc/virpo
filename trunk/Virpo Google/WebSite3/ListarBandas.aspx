﻿<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ListarBandas.aspx.cs" Inherits="ListarBandas" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
             <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
             <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e Integrantes</a></li>
             <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
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
        <tr>
            <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" 
                     onrowcommand="GridView1_RowCommand" Width="527px" 
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
                                <asp:BoundField DataField="Fecha Inicio" HeaderText="Fecha Inicio" 
                SortExpression="Fecha Inicio" />
                                <asp:BoundField DataField="Pagina Web" HeaderText="Pagina Web" 
                SortExpression="Pagina Web" />
                                <asp:BoundField DataField="Localidad" HeaderText="Localidad" 
                SortExpression="Localidad" />
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
                    </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    style="height: 26px" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
