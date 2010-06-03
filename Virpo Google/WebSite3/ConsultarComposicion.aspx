<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarComposicion.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisProyectos.aspx?" title="Mis Proyectos">Mis Proyectos</a></li>
            <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
             <li><a href="MisComposiciones.aspx?fin=1" title="Canciones Finalizadas">Canciones 
                 Terminadas</a></li>
                 <li><a href="EditoresDeAudio.aspx" title="Editores de Audio">Editores de Audio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="tabla">
        <tr>
            <td colspan="3" style="height: 14px">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Detalles de la composicion </titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label1" runat="server" Text="Tipo:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTipo" runat="server" Font-Size="Medium"></asp:Label>
            </td>
            <td>
        <asp:Label ID="Label8" runat="server" Text="Autor:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Font-Size="Medium"></asp:Label>
            </td>
            <td rowspan="5">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="54px" 
                                onclick="ImageButton1_Click" Width="54px" />
                            <br />
               
                
            
            
                <asp:Label ID="lblAutor" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label3" runat="server" Text="Tempo:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTempo" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 107px">
                <asp:Label ID="Label4" runat="server" Text="Tonalidad:"></asp:Label>
            </td>
            <td style="height: 23px">
                <asp:Label ID="lblTonalidad" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label5" runat="server" Text="Instrumento:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblInstrumento" runat="server" Font-Size="Medium"></asp:Label>
            </td>
            <td rowspan="5">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="74px" 
                    ImageUrl="~/ImagenesSite/play.png" Width="79px" 
                    onclick="ImageButton2_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDescripcion" runat="server" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                <asp:Label ID="Label9" runat="server" Text="¿Finalizar?"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnFinalizar" runat="server" onclick="Button1_Click" 
                    Text="Si" />
            </td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td colspan="2">
                <a id="aVolver" runat="server">Volver</a></td>
        </tr>
        <tr>
            <td style="width: 107px">
                &nbsp;</td>
            <td colspan="2">
                
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>

