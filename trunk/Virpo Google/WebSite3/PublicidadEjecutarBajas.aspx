<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="PublicidadEjecutarBajas.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Vuelve al Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Pedidos de Publicidad">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Publicidades Vigentes">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Publicidades Vencidas">Renovación</a></li>
            <li><a href="PublicidadEjecutarBajas.aspx" title="Publicidades a Eliminar">Ejecutar
                Bajas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <center style="width: 532px; background-color: #333333">
        <titulosubventana>Ejecutar Bajas</titulosubventana>
    </center>
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="lblOk" runat="server" ForeColor="#009900" Text="Se Eliminó con Exito..."
                    Visible="False"></asp:Label>
                <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" Text="Error al Procesar la Transacción..."
                    Visible="False"></asp:Label>
                <asp:Label ID="lblOk2" runat="server" ForeColor="#009900" Text="Se Renovó con Exito..."
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVacio" runat="server" ForeColor="#0033CC" Text="No hay Publicidades Pendientes de Eliminar..."
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" OnRowCommand="GridView1_RowCommand"
        Width="529" PageSize="10">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
                <HeaderStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="entidad" HeaderText="Empresa" />
            <asp:BoundField DataField="nombreContacto" HeaderText="Contacto" />
            <asp:BoundField DataField="Consulta" HeaderText="Motivo" />
            <asp:ButtonField ButtonType="Image" CommandName="E" ImageUrl="~/ImagenesSite/delete.png" />
            <asp:ButtonField ButtonType="Image" CommandName="C" ImageUrl="~/ImagenesSite/lupa3.png" />
        </Columns>
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
    <table class="style1">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        Está seguro de Eliminar la Publicidad?
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button1" runat="server" Text="SI" OnClick="Button1_Click" CssClass="botones" />
                        <asp:Button ID="Button4" runat="server" Text="NO" OnClick="Button4_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:modalpopupextender id="Panel1_ModalPopupExtender" backgroundcssclass="modalBackground"
                    runat="server" dynamicservicepath="" enabled="True" targetcontrolid="Button2"
                    popupcontrolid="Panel1" okcontrolid="Button3">
                </cc1:modalpopupextender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button6" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button7" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel2" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Publicidad fue Eliminada.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button5" runat="server" Text="OK" OnClick="Button5_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:modalpopupextender id="Panel2_ModalPopupExtender" backgroundcssclass="modalBackground"
                    runat="server" dynamicservicepath="" enabled="True" targetcontrolid="Button6"
                    popupcontrolid="Panel2" okcontrolid="Button7">
                </cc1:modalpopupextender>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
