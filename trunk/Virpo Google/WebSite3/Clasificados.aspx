<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Clasificados.aspx.cs" Inherits="_Default" Title="Virpo - Musica Colaborativa - Clasificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="menu8">
        <ul>
            <li><a href="AltaClasificado.aspx" title="Nueco Clasificado">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Mis Avisos Clasificados">Mis Avisos Clasificados</a></li>
            <li><a href="Clasificados.aspx?rank=1" title="Mas visitados">Más visitados</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lblResultados" runat="server" 
                    Text="No se han encontrado resultados para la búsqueda solicitada." 
                    Visible="False"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td id="tdTitulo" runat="server">
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                    Ultimos Clasificados</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
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
                                <asp:BoundField DataField="Titulo" HeaderText="Titulo" 
                SortExpression="Titulo" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" 
                SortExpression="Precio" />
                                <asp:BoundField DataField="Fecha Fin" HeaderText="Fecha Fin" 
                SortExpression="Fecha Fin" />
                                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" 
                SortExpression="Vendedor" />
                                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" 
                SortExpression="Ubicacion" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
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

