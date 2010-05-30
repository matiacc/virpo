<%@ Page Title="" Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisProyectos.aspx.cs" Inherits="MisProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisProyectos.aspx?" title="Mis Proyectos">Mis Proyectos</a></li>
            <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
            <li><a href="MisComposiciones.aspx?fin=1" title="Canciones Finalizadas">Canciones Terminadas</a></li>
            <li><a href="EditoresDeAudio.aspx" title="Editores de Audio">Editores de Audio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <center style="background-color: #333333">
                    <titulosubventana>
                    Proyectos creados por mi</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultados" runat="server" Text="No tenés proyectos creados"
                    Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
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
            <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" >
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
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <center style="background-color: #333333">
                    <titulosubventana>
                    Proyectos en los que colaboro</titulosubventana></td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultadosGrilla2" runat="server" Text="No estás colaborando en ningún proyecto musical"
                    Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView2_RowCommand"
        Width="527px" OnPageIndexChanging="GridView2_PageIndexChanging" OnSorting="GridView2_Sorting"
        PageSize="5">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
            </asp:ImageField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
            <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" >
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
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

