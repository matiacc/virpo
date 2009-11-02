<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="FavoritosWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx?A=1" title="Articulo Aleatorio">Articulo 
                Aleatorio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Favoritos WikiMusic</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lblResultado" runat="server" 
                    Text="No has apuntado ningun articulo todavía!" Visible="False" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
                    Width="527px" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                            <HeaderStyle Font-Size="Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                        <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
                        <asp:ButtonField ButtonType="Image" CommandName="C" ImageUrl="~/ImagenesSite/lupa3.png"
                            Text="Consultar" />
                        <asp:ButtonField ButtonType="Image" CommandName="E" ImageUrl="~/ImagenesSite/delete.png"
                            Text="Eliminar" />
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
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
