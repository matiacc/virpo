<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Eventos.aspx.cs" Inherits="_Default" Title="Página sin título" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AltaEvento.aspx" title="Nuevo Evento">Nuevo Evento</a></li>
            <li><a href="MisEventos.aspx" title="Mis Eventos">Mis Eventos</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Últimos Eventos</titulosubventana>
                </center></td>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Height="120px" onrowcommand="GridView1_RowCommand" Width="529px" 
            CssClass="GridViewStyle" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:ImageField DataImageUrlField="imagen">
                </asp:ImageField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                <asp:BoundField DataField="Lugar" HeaderText="Lugar" SortExpression="Lugar" />
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
</p>
    <p>
    <br />
</p>
<p>
</p>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

