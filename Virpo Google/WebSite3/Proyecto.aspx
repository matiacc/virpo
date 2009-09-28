<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Proyecto.aspx.cs" Inherits="Proyecto" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btUnirse" runat="server" CssClass="botones" 
                    Text="Unirse al Proyecto" onclick="btUnirse_Click" />
            </td>
            <td rowspan="2">
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </td>
            <td>
            
                Colaboradores</td>
        </tr>
        <tr>
            <td colspan="2">
                Usuario Creador:                 <asp:Label ID="lblUsuario" runat="server"></asp:Label>
            </td>
            <td>
            
                <asp:Label ID="lblColaboradores" runat="server"></asp:Label>
            </td>
            <td>
            
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Genero :
                <asp:Label ID="lblGenero" runat="server"></asp:Label>
            </td>
            <td>
                
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                
                                </td>
            <td>
                
                                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Creado el :&nbsp;                 <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Licencia :                 <asp:Label ID="lblLicencia" runat="server"></asp:Label>
            </td>
            <td>
            
                
            </td>
            <td>
            
                
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                Composiciones</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lblComposiciones" runat="server"></asp:Label>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            onrowcommand="GridView1_RowCommand">
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="P" DataTextField="Ruta" 
                                    ImageUrl="~/ImagenesSite/play.png" Text="Play" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                    SortExpression="Nombre" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" 
                                    SortExpression="Instrumento" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" 
                                    SortExpression="Usuario" />
                                <asp:BoundField DataField="Ruta2" HeaderText="Ruta" />
                            </Columns>
                        </asp:GridView>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="331" height="25" id="Object1" >
<param name="allowScriptAccess" value="sameDomain" />
<param id="reproductor" name="movie"/>
<%--<param name="movie" value="Reproductor/mini_player_mp3.swf?my_mp3=Reproductor/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>" />--%>
<param name="quality" value="high" />
<%--<param name="wmode" value="transparent">--%>
<param name="bgcolor" value="#FFFFFF" />
<embed src="Reproductor/mini_player_mp3.swf?my_mp3=Reproductor/<%# this.mp3_seleccionado %>&amp;my_text=<%# this.mp3_seleccionado_titulo %>&amp;autoplay=<%# this.reproducir %>" quality="high"  bgcolor=#FFFFFF width="331" height="25" name="mini_player_mp3" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object></td>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

