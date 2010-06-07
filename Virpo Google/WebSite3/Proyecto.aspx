<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Proyecto.aspx.cs"
    Inherits="Proyecto" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisProyectos.aspx" title="Mis Proyectos">Mis Proyectos</a></li>
             <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
             <li><a href="MisComposiciones.aspx?fin=1" title="Canciones Finalizadas">Canciones 
                 Finalizadas</a></li>
                 <li><a href="EditoresDeAudio.aspx" title="Editores de Audio">Editores de Audio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

<SCRIPT LANGUAGE="JavaScript">
window.opener.location.reload();
</SCRIPT>

    <table class="tabla">
        <tr>
            <td colspan="3">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Proyecto: 
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td style="width: 141px;" rowspan="11">
                <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" />
                <br />
                <asp:Button ID="btUnirse" runat="server" CssClass="botones" Text="Unirse al Proyecto"
                    OnClick="btUnirse_Click" Width="300px" />&nbsp;&nbsp;
                    
            </td>
            <td style="height: 20px">
                <asp:Label ID="Label1" runat="server" Text="Descripción:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top" style="height: 20px">
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Creado Por:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top">
                
                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Género:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblGenero" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Creado el:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Licencia:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblLicencia" runat="server" CssClass="estiloLabelpeque"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Colaboradores:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblColaboradores" runat="server"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <img alt="" id="loading" runat="server" class="imagenLoading" src="ImagenesSite/loading.gif" style="display:none; vertical-align:top;" /></td>
        </tr>
        <tr>
            <td>
           
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="height: 20px" id="tdProyecto" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="height: 20px; font-size: large;">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Composiciones 
                <asp:Label ID="Label7" runat="server"></asp:Label>
                    </titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lblComposiciones" runat="server" ForeColor="#990000" Visible="False">No 
                se ha cargado ninguna composicion</asp:Label>
            </td>
        </tr>
        <div id="grid">
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    GridLines="Horizontal" BorderStyle="Dotted" 
                    onrowdeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:ButtonField ButtonType="Image" CommandName="P" DataTextField="Ruta" ImageUrl="~/ImagenesSite/play.png"
                            Text="Play" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                        <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" SortExpression="Instrumento" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                        <asp:BoundField DataField="Ruta2" HeaderText="Ruta" />
                        <asp:HyperLinkField DataNavigateUrlFields="Ruta3" HeaderText="" Text="Descargar" />
                        <asp:ButtonField ButtonType="Image" CommandName="C" 
                            ImageUrl="~/ImagenesSite/lupa3.png" Text="Modificar" />
                        <asp:BoundField DataField="Id" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                    CommandName="Delete" ImageUrl="~/ImagenesSite/delete.png"  OnClientClick="return confirm('¿Esta seguro de borrar?')"
                                    Text="Borrar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </div>
        <tr>
            <td colspan="3" align="right">
                &nbsp;
                <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" onclick="btnDenunciar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Panel ID="pnlReproductor" runat="server" Height="42px" Visible="False" Width="506px">
                    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                        width="331" height="25" id="Object1" align="right">
                        <param name="allowScriptAccess" value="sameDomain" />
                        <param name="movie" value="Reproductor/mini_player_mp3.swf?my_mp3=Composiciones/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>" />
                        <param name="quality" value="high" />
                        <%--<param name="wmode" value="transparent"/>--%>
                        <param name="bgcolor" value="#333333" />
                        <embed src="Reproductor/mini_player_mp3.swf?my_mp3=Composiciones/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>"
                            quality="high" bgcolor="#333333" width="331" height="25" name="mini_player_mp3"
                            allowscriptaccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                    </object>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender ID="pnlReproductor_AlwaysVisibleControlExtender"
                    runat="server" Enabled="True" TargetControlID="pnlReproductor" HorizontalOffset="253"
                    HorizontalSide="Right">
                </cc1:AlwaysVisibleControlExtender>
            </td>
        </tr>
    </table>
    
    <asp:Button ID="Button2" runat="server" Text="False" Style="display: none" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>Te has unido, ya puedes comenzar a colaborar en el Proyecto</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="Aceptar" CssClass="botones" />
    </asp:Panel></center>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
