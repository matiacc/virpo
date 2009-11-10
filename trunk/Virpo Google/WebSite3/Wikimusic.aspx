<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Wikimusic.aspx.cs"
    Inherits="_Default" Title="Virpo - Musica Colaborativa - Wikimusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Articulo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Articulos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Articulos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx?A=1" title="Novedades">Novedades</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    WikiMusic</titulosubventana>
                </center>
            </td>
            <tr>
                <td style="text-align: center; font-family: Calibri; font-size: x-large; color: #777777;">
                    Un espacio dedicado al conocimiento...
                </td>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblOk" runat="server" Style="color: #009900" Text="La Transacción se realizó con exito"
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblMal" runat="server" Style="color: #CC3300" Text="La Transacción no se realizó"
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;<asp:Image ID="Image1" runat="server" Height="179px" ImageUrl="~/images/logos virpo/libros2.png"
                            Width="273px" />
                        &nbsp;
                    </td>
                    <tr>
                        <td style="text-align: center">
                            <hr />
                        </td>
                        <tr>
                            <td style="text-align: left; font-family: Calibri; font-size: x-large; color: #777777;">
                                TOP 5
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
                                    Width="527px" PageSize="6">
                                    <Columns>
                                        <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                                            <HeaderStyle Font-Size="Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Version" HeaderText="Version" />
                                        <asp:BoundField DataField="Posicion" HeaderText="Posicion" />
                                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                        <asp:BoundField DataField="Visitas" HeaderText="Visitas" />
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <hr />
                            </td>
                        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
