<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Clasificados.aspx.cs" Inherits="_Default" Title="Virpo - Musica Colaborativa - Clasificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="menu8">
        <ul>
            <li><a href="AltaClasificado.aspx" title="Nueco Clasificado">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Mis Avisos Clasificados">Mis Avisos 
                Clasificados</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                    Ultimos Clasificados</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" 
                    onrowcommand="GridView1_RowCommand" Width="527px">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
            </asp:ImageField>
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Fecha Fin" HeaderText="Hasta" />
            <asp:BoundField DataField="Dueño" HeaderText="Vendedor" />
            <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" />
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
    </asp:GridView></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>

