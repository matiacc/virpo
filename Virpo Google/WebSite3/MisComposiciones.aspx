<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisComposiciones.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
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
                
                </p>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Text="Mis Composiciones"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" 
            Text="NO SE ENCONTRARON PISTAS Y/O CANCIONES REGISTRADAS POR USTED" 
            Visible="False"></asp:Label>
            
            
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="275px" onrowcommand="GridView1_RowCommand1" 
            style="margin-right: 0px">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="P" DataTextField="Ruta" 
                    ImageUrl="~/ImagenesSite/play.png" Text="Play" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" 
                    SortExpression="Instrumento" />
                <asp:BoundField DataField="Ruta2" HeaderText="Ruta" SortExpression="Ruta" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:ButtonField ButtonType="Image" CommandName="E" DataTextField="Ruta" 
                    ImageUrl="~/ImagenesSite/delete.png" Text="Eliminar" />
                <asp:ButtonField ButtonType="Image" CommandName="C" 
                    ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar" />
            </Columns>
        </asp:GridView>
    </p>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

