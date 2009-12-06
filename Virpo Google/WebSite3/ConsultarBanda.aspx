<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarBanda.aspx.cs" Inherits="ConsultarBanda" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>      
            <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
            <li><asp:Label ID="lblProyectos" runat="server"></asp:Label></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%" class="tabla">
        <tr>
            <td colspan="3">
                <center style="background-color: #333333; width: 523px;">
                    <tituloSubVentana>Perfil de la Banda
                <asp:Label ID="lblNombre" runat="server"  
                                style="text-align: right"></asp:Label>
                        </tituloSubVentana>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 250px">
                <asp:Image ID="Image1" runat="server" Height="250px" 
                    ImageAlign="Left" Width="250px" />
            </td>
            <td>
                <table style="width: 100%; height: 198px">
                    <tr>
                        <td style="text-align: right; width: 125px;">
                            &nbsp;</td>
                        <td style="text-align: right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 135px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 135px">
                            <asp:Label ID="Label4" runat="server" Text="Género:" CssClass="estiloLabel"></asp:Label></td>
                        <td> <asp:Label ID="lblGenero" runat="server" Font-Size="Medium"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 135px">
                            <asp:Label ID="Label7" runat="server" Text="Página Web:" 
                                CssClass="estiloLabel" Width="100px"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPaginaWeb" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td style="width: 135px">
                
                <asp:Label ID="Label1" runat="server" Text="Inicio de la Banda:" 
                    CssClass="estiloLabel" Width="120px"></asp:Label>
                            </td>
                        <td>
                
                <asp:Label ID="lblFecInicio" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td style="width: 135px">
                            <asp:Label ID="Label2" runat="server" Text="Localidad:" 
                                CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                            <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td style="width: 135px">
                            <asp:Label ID="lblId" runat="server" Text="Oculto" Visible="False"></asp:Label>
                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="btnModificarBanda" runat="server" 
                    onclick="btnModificarBanda_Click" Text="Modificar" CssClass="botones" />
                </td>
            <td style="text-align: right;" colspan="2">
                
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" CssClass="botones" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="background-color: #999999; text-align: center;">
                <asp:Label ID="Label3" runat="server" Text="Integrantes de la Banda" 
                    Font-Bold="True" CssClass="estiloLabelNaranja" Font-Overline="False" 
                    Font-Strikeout="False" ForeColor="#FF6600" style="margin-right: 0px"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="3" style="text-align: left">
                <br />
                <asp:Label ID="lblIntegrantes"  runat="server"></asp:Label>
                <br />
             </td>
        </tr>
         <tr>
            <td colspan="3" style="background-color: #999999; text-align: center;">
                <asp:Label ID="Label8" runat="server" Text="VIDEO" Font-Bold="True" 
                    CssClass="estiloLabelNaranja" ForeColor="#FF6600"></asp:Label>
             </td>
        </tr>
         <tr>
            <td colspan="3" style="text-align: left">
                <br />
                <asp:Label ID="lblVideo"  runat="server"></asp:Label>
                <br />
             </td>
        </tr>
         <tr>
            <td colspan="2" style="width: 250px">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="3" style="text-align: center; background-color: #999999">
                <asp:Label ID="Label9" runat="server" Text="Eventos Publicados" 
                    Font-Bold="True" CssClass="estiloLabelNaranja" ForeColor="#FF6600"></asp:Label>
             </td>
        </tr>
         <tr>
            <td colspan="2" style="width: 250px">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Height="120px" onrowcommand="GridView1_RowCommand" Width="523px" 
            CssClass="GridViewStyle" GridLines="None" gr>
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
             </td>
        </tr>
         <tr>
            <td colspan="2" style="width: 250px">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

