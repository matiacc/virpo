<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarClasificado.aspx.cs" Inherits="ConsultarClasificado" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            
            <li><a href="AltaClasificado.aspx" title="Nuevo Clasificado">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Mis Avisos Clasificados">Mis Avisos 
                Clasificados</a></li>
                <li><a href="Clasificados.aspx?rank=1" title="Mas visitados">Más visitados</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
            
                <asp:Label ID="lblImagen" runat="server"></asp:Label>
            
            </td>
            <td colspan="2">
                <table style="width: 100%; height: 249px">
                    <tr>
                        <td colspan="2" style="text-align: right">
                            
                            <asp:Label ID="lblContactar" runat="server" CssClass="estiloLabelCabeceraPeque"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" CssClass="estiloLabelCabecera" 
                                style="text-align: right"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Precio:" CssClass="estiloLabel"></asp:Label></td>
                        <td> <asp:Label ID="lblPrecio" runat="server" Font-Size="Medium"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Cantidad de Visitas:" 
                                CssClass="estiloLabel" Width="150px"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblVisitas" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>
                
                <asp:Label ID="Label1" runat="server" Text="Inicio de Publicacion:" 
                    CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                
                <asp:Label ID="lblInicio" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Fin Publicación:" 
                                CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server"></asp:Label>
                            </td>
                    </tr>
                     <tr>
                        <td>
                <asp:Label ID="Label5" runat="server" Text="Vendedor:" CssClass="estiloLabel"></asp:Label>
                            </td>
                        <td>
                <asp:Label ID="lblVendedor" runat="server" CssClass="estiloLabelCabeceraPeque"></asp:Label>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td colspan="3">
            <asp:Label ID="lblRecomendar" runat="server" BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 366px" rowspan="2">
                
                <asp:Label ID="Label8" runat="server" CssClass="estiloLabel" 
                    Text="Descripcion:"></asp:Label>
                
            </td>
            <td colspan="2" rowspan="2">
                
              <asp:Label ID="lblDescripcion" runat="server">  </asp:Label>
                
            </td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 366px">
                <asp:Label ID="Label3" runat="server" Text="Ubicación:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblUbicacion" runat="server" style="text-align: right"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td style="width: 366px">
                <asp:Label ID="Label6" runat="server" Text="Rubro:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 366px">
                <asp:Label ID="lblRubro" runat="server"></asp:Label>
            </td>
            <td style="text-align: left; width: 198px;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="2">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblImprimir" runat="server" CssClass="estiloLabel"></asp:Label>
             </td>
        </tr>
         <tr>
            <td colspan="2">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="4">
                <center style="width: 532px; background-color: #333333">
                     <titulosubventana>Preguntas sobre el aviso</titulosubventana>
                </center></td>
        </tr>
         <tr>
            <td colspan="2">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="4">
            <asp:GridView ID="gvMensajes" runat="server" AutoGenerateColumns="False" 
                                                            CssClass="GridViewStyle" 
                    GridLines="None" Width="531px">
                                                            <Columns>
                                                                <asp:BoundField DataField="id" ReadOnly="True" HeaderText="Id" 
                                                                    Visible="False" />
                                                                <asp:BoundField DataField="remitente" HeaderText="De" />
<asp:BoundField DataField="tipo" ShowHeader="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" />
                                                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
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
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
            <td style="width: 198px">
                </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="style1">
                       
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server">
                                    Mensajes Nuevos
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            CssClass="GridViewStyle" GridLines="None" onrowcommand="GridView2_RowCommand" 
                                            Width="531px" onrowdeleting="GridView2_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="De" HeaderText="De" />
                                                <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" />
                                                <asp:ButtonField ButtonType="Image" CommandName="Consultar" 
                                                    ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>
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
                                    </asp:Panel>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                                    <table class="style1">
                                    
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" CssClass="estiloLabel" Text="Usuario"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label10" runat="server" CssClass="estiloLabel" Text="Pregunta"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPregunta" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label11" runat="server" CssClass="estiloLabel" Text="Respuesta"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRespuesta" runat="server" Height="60px" 
                                                                        TextMode="MultiLine" Width="445px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    &nbsp;</td>
                                                                <td style="text-align: right"><img alt="" src="./ImagenesSite/cargando.gif" id="loading" style="display:none"/>&nbsp;&nbsp;
                                                                    <asp:Button ID="btResponder" runat="server" onclick="btResponder_Click" OnClientClick="mostrarGif();"
                                                                        Text="Responder" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
         <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="4" align="right">
                <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" onclick="btnDenunciar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>

