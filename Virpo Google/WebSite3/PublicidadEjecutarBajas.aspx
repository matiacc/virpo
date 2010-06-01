<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="PublicidadEjecutarBajas.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Vuelve al Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Pedidos de Publicidad">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Publicidades Vigentes">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Publicidades Vencidas">Renovacion</a></li>
            <li><a href="PublicidadEjecutarBajas.aspx" title="Publicidades a Eliminar">Ejecutar 
                Bajas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center style="width: 532px; background-color: #333333">
                     <titulosubventana>Ejecutar Bajas</titulosubventana>
                </center>
<table class="style1">
        <tr>
            <td colspan="5">
        <asp:Label ID="lblOk" runat="server" ForeColor="#009900" 
            Text="Se Eliminó con Exito..." Visible="False"></asp:Label>
        <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" 
            Text="Error al Procesar la Transacción..." Visible="False"></asp:Label>
            </td>
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
 <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
            Width="529" PageSize="10">
            <Columns>
                <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                    <HeaderStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="entidad" HeaderText="Empresa" />
                <asp:BoundField DataField="nombreContacto" HeaderText="Contacto" />
                <asp:BoundField DataField="Consulta" HeaderText="Motivo" />
                <asp:ButtonField ButtonType="Image" CommandName="E" ImageUrl="~/ImagenesSite/delete.png" />
                <asp:ButtonField ButtonType="Image" CommandName="C" ImageUrl="~/ImagenesSite/lupa3.png" />
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

