<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="BajasNoticias.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="BajasNoticias.aspx" title="Altas y Bajas">Modificar & Bajas</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        altas y bajas</p>
    <p style="width: 466px">
                        <asp:Label ID="lblMal" runat="server" Style="color: #CC3300" Text="La Transacción no se realizó"
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblOk" runat="server" Style="color: #009900" Text="La Transacción se realizó con exito"
                            Visible="False"></asp:Label>
                        </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
                                    Width="529" PageSize="16">
                                    <Columns>
                                        <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                                            <HeaderStyle Font-Size="Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Noticia" />
                                        <asp:BoundField DataField="Posicion" HeaderText="Posicion" />
                                        <asp:BoundField DataField="IdAutor" HeaderText="Autor" />
                                        <asp:ButtonField ButtonType="Image" CommandName="C" ImageUrl="~/ImagenesSite/eliminar.png" />
                                        <asp:ButtonField ButtonType="Image" CommandName="M" ImageUrl="~/ImagenesSite/edit.png"
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
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

