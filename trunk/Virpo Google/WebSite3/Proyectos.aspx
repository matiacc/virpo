<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Proyectos.aspx.cs"
    Inherits="Proyectos" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisProyectos.aspx" title="Mis Proyectos">Mis Proyectos</a></li>
            <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
            <li><a href="MisComposiciones.aspx?fin=1" title="Canciones Finalizadas">Canciones 
                Finalizadas</a></li>
            <li><a href="EditoresDeAudio.aspx" title="Editores de Audio">Editores de Audio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1">
        <tr>
            <td>
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Últimos Proyectos</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="label3" runat="server" Text="Proyectos publicados en el Grupo " 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblGrupo" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label4" runat="server" Text="Proyectos publicados en la Banda  " 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblBanda" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultados" runat="server" Text="No se han encontrado resultados para la búsqueda solicitada."
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
        Width="527px" OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnSorting="GridView1_Sorting">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
            </asp:ImageField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
            <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado">
            <ItemStyle Width="100px" />
            </asp:BoundField>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
