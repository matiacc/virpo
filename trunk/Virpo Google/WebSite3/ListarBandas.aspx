<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ListarBandas.aspx.cs"
    Inherits="ListarBandas" Title="Página sin título" %>

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
    <table class="style1" style="width: 151%">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Listar Bandas</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultados" runat="server" Text="No se han encontrado resultados para la búsqueda solicitada."
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
                    Width="527px" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting"
                    PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                            <HeaderStyle Font-Size="Small" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
                        </asp:ImageField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                        <asp:BoundField DataField="Fecha Inicio" HeaderText="Fecha Inicio" SortExpression="Fecha Inicio" />
                        <asp:BoundField DataField="Pagina Web" HeaderText="Pagina Web" SortExpression="Pagina Web" />
                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
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
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Style="height: 26px"
                    Text="Volver" CssClass="botones" />
            </td>
            <td style="text-align: right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
