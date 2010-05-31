<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisAvisosClasificados.aspx.cs" Inherits="MisClasificados" Title="Mis Clasificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AltaClasificado.aspx" title="About">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Services">Mis Avisos Clasificados</a></li>
            <li><a href="Clasificados.aspx?rank=1" title="Mas visitados">Más visitados</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 527px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 527px">
                <center style="width: 537px; background-color: #333333"><tituloSubVentana>Mis Avisos 
                    Clasificados</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td style="width: 527px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 527px">
    <asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" 
                    onrowcommand="GridView1_RowCommand" Width="531px" 
                    onrowdeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" ItemStyle-Height="100%">
<ItemStyle Height="100%"></ItemStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Fecha Fin" HeaderText="Fin Publicación" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:ButtonField ButtonType="Image" CommandName="C" 
                ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar" />
            <asp:ButtonField ButtonType="Image" CommandName="M" 
                ImageUrl="~/ImagenesSite/edit.png" Text="Modificar" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                        CommandName="Delete" ImageUrl="~/ImagenesSite/delete.png" Text="Eliminar" OnClientClick="return confirm('¿Esta seguro de borrar?')" />
                </ItemTemplate>
            </asp:TemplateField>
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
            <td style="width: 527px">
                                    &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 527px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>

