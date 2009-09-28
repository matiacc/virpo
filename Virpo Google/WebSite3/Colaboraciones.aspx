<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Colaboraciones.aspx.cs" Inherits="_Default" Title="Virpo - Musica Colaborativa - Colaboraciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="Proyectos.aspx" title="Proyectos">Proyectos</a></li>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="style1">
        <tr>
            <td style="width: 118px; height: 51px">
                </td>
            <td style="height: 51px">
                
                
                
                
                
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="331" height="25" id="mini_player_mp3" align="middle">
<param name="allowScriptAccess" value="sameDomain" />
<param name="movie" value="Reproductor/mini_player_mp3.swf?my_mp3=Reproductor/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>" />
<param name="quality" value="high" />
<param name="wmode" value="transparent"/>
<%--<param name="bgcolor" value="#FFFFFF">--%>
<embed src="Reproductor/mini_player_mp3.swf?my_mp3=Reproductor/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>" quality="high" wmode=transparent bgcolor=#FFFFFF width="331" height="25" name="mini_player_mp3" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object></td>
        </tr>
        <tr>
            <td style="width: 118px; height: 36px">
                
                <asp:LinkButton ID="btn_stones" runat="server" onclick="btn_stones_Click">Stones</asp:LinkButton>
                <br />
            </td>
            <td style="height: 36px">
                </td>
        </tr>
        <tr>
            <td style="width: 118px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 118px">
                
                <asp:LinkButton ID="btn_acdc" runat="server" onclick="btn_acdc_Click">AC/DC</asp:LinkButton>
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

