<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ListarUsuarios.aspx.cs" Inherits="ListarUsuarios" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
              <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="ListarBandas.aspx" title="Listar Bandas">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
                        <tr>
                            <td colspan="2">
                                <center style="width: 522px; background-color: #333333">
                                    <tituloSubVentana>Agregar Integrantes</tituloSubVentana></center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="width: 263px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
    
    <asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False" CssClass="GridViewStyle" GridLines="None" 
                    onrowcommand="GridView1_RowCommand" Width="519px" AllowPaging="True" 
                                    onsorting="GridView1_Sorting">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" 
                NullImageUrl="~/ImagenesSite/user_no_avatar.gif">
            </asp:ImageField>
            <asp:TemplateField HeaderText="Seleccionar">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle/>
        <PagerStyle CssClass="PagerStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Mensaje"></asp:Label>
                                :</td>
                        </tr>
                        <tr>
                            <td colspan="2">
    <asp:TextBox ID="txtMensaje" runat="server" Height="77px" TextMode="MultiLine" 
            Width="521px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
    <asp:Button ID="btEnviarInvitacion" runat="server" 
        onclick="btEnviarInvitacion_Click" Text="Enviar Invitaciones"/> 
        <img alt="" id="loading" runat="server" class="imagenLoading" src="ImagenesSite/loading.gif" style="display:none; vertical-align:top;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">
                                &nbsp;</td>
                        </tr>
                    </table>
    
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

