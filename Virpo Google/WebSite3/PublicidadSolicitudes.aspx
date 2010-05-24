<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="PublicidadSolicitudes.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

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
    <table class="style1">
        <tr>
            <td colspan="5">
                solicitudes</td>
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CssClass="HeaderStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
            Width="529" PageSize="16">
            <Columns>
                <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                    <HeaderStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="Entidad" HeaderText="Empresa" />
                <asp:BoundField DataField="NombreContacto" HeaderText="Contacto" />
                <asp:BoundField DataField="TelContacto" HeaderText="Telefono" />
                <asp:ButtonField ButtonType="Image" CommandName="C" ImageUrl="~/ImagenesSite/lupa3.png"

                    Text="Consultar" />
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
