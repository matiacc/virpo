<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisAvisosClasificados.aspx.cs" Inherits="MisClasificados" Title="Mis Clasificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AltaClasificado.aspx" title="About">Nuevo Clasificado</a></li>
            <li><a href="MisAvisosClasificados.aspx" title="Services">Mis Avisos Clasificados</a></li>
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
                    onrowcommand="GridView1_RowCommand" Width="531px">
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
                ImageUrl="~/ImagenesSite/eliminar.png" Text="Modificar" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server"  
                        CommandName="E" ImageUrl="~/ImagenesSite/delete.png" Text="Eliminar" OnClientClick="return confirm('Seguro de borrar?')"/>
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
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 527px">
                <center style="width: 538px; background-color: #333333"><tituloSubVentana>Mis 
                    Mensajes</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td style="width: 527px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="lnkPreguntasPendientes" runat="server" 
                                        onclick="lnkPreguntasPendientes_Click"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" Height="505px" Visible="False">
                                        <table style="width: 100%; height: 66px">
                                            <tr>
                                              
                                                      <td align= "left">
                                                        <%--</asp:gridview>--%>
                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                            CssClass="GridViewStyle" GridLines="None" onrowcommand="GridView2_RowCommand" 
                                                            Width="531px">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
                                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                                <asp:BoundField DataField="De" HeaderText="De" />
                                                                <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" />
                                                                <asp:ButtonField ButtonType="Image" CommandName="C" 
                                                                    ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar" >
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:ButtonField>
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
                                                <td>
                                                    <asp:Panel ID="Panel2" runat="server" Visible="False" Height="205px">
                                                        <table class="style1">
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" CssClass="estiloLabel" Text="Usuario"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" CssClass="estiloLabel" Text="Pregunta"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPregunta" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" CssClass="estiloLabel" Text="Respuesta"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRespuesta" runat="server" Height="60px" 
                                                                        TextMode="MultiLine" Width="445px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    &nbsp;</td>
                                                                <td style="text-align: right"><img alt="" src="ImagenesSite/cargando.gif" id="loading" style="display:none"/>&nbsp;&nbsp;
                                                                    <asp:Button ID="btResponder" runat="server" onclick="btResponder_Click" OnClientClick="mostrarGif()"
                                                                        Text="Responder" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
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
            <td style="text-align: center; width: 527px;">
                &nbsp;</td>
        </tr>   
        <tr>
            <td style="width: 527px">
                &nbsp;</td>
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

