<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="PermisosUsuarios.aspx.cs" Inherits="PermisosUsuarios" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administración">Home</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<center style="width: 527px; background-color: #333333"><tituloSubVentana>
                  <asp:Label ID="lblTituloPermisos" runat="server" 
        Text="Administración de Permisos"></asp:Label></tituloSubVentana></center>
                  
    <table style="width: 527px">
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
                <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">
                <asp:Label ID="lblNombreDeUsuario" runat="server" 
                    Text="Ingrese Nombre de Usuario:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="txtNombreUsr" runat="server" Width="185px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombreUsr" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 20%">
                <asp:Button ID="btnBuscarUsr" runat="server" OnClick="btnBuscarUsr_Click" Style="height: 26px"
                    Text="Buscar" CssClass="botones" Width="100px" />
            </td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" 
                    CssClass="GridViewStyle" Width="100%" GridLines="None" 
                    DataKeyNames="idTipoUsuario" 
                    onselectedindexchanged="gvUsuarios_SelectedIndexChanged">
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                        <asp:ImageField DataImageUrlField="imagen" HeaderText="Foto">
                        </asp:ImageField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="idTipoUsuario" HeaderText="idRol" Visible="False" />
                        <asp:BoundField DataField="tipoUsuario" HeaderText="Rol" />
                        <asp:CommandField ButtonType="Image" InsertVisible="False" 
                            SelectImageUrl="~/ImagenesSite/lupa3.png" SelectText="Editar" 
                            ShowCancelButton="False" ShowSelectButton="True" />
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Outset">
                    <table class="style1">
                        <tr>
                            <td style="width: 60px">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" 
                                    CssClass="estiloLabel"></asp:Label>
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 74px">
                                &nbsp;</td>
                            <td style="width: 87px">
                                <asp:Label ID="lblRol" runat="server" Text="Nuevo Rol:" CssClass="estiloLabel"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRol" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60px">
                                &nbsp;</td>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td style="width: 74px">
                                &nbsp;</td>
                            <td style="width: 87px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 60px">
                                &nbsp;</td>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td style="width: 74px">
                                &nbsp;</td>
                            <td style="width: 87px">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="botones" 
                                    OnClick="btnGuardar_Click" Style="height: 26px" Text="Guardar" Width="100px" />
                            </td>
                        </tr>
                    </table>
                
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 40%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

