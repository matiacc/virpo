<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarEvento.aspx.cs" Inherits="_Default" Title="Página sin título" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AltaEvento.aspx" title="Nuevo Evento">Nuevo Evento</a></li>
            <li><a href="MisEventos.aspx" title="Mis Eventos">Mis Eventos</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="style1">
        <tr>
            <td>
             
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                   <asp:Label ID="lblNombre" runat="server" ForeColor="White" ></asp:Label></tituloSubVentana></center>
                
               
            </td>
        </tr>
        
        
    </table>
<table class="tabla" style="height: 665px">
        <tr>
            <td style="height: 15px">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px;">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px; text-align: right;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 15px">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px;">
                                &nbsp;</td>
            <td style="width: 295px; height: 15px; text-align: right;">
                <asp:Label ID="lblRecomendar" runat="server" BackColor="#FFFFCC"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 15px">
                <asp:Label ID="lblMusico" runat="server" Text="Músico:" CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="width: 295px; height: 15px;">
                <asp:HyperLink ID="HpLMusico" runat="server">[HpLMusico]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label1" runat="server" Text="Lugar:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;">
                                <asp:Label ID="lblLugar" runat="server"></asp:Label>
                            </td>
            <td style="width: 295px" rowspan="6">
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="http://www.google.com.ar">
                <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" width="250px" 
                    Height="250px" BorderStyle="Solid" /></a>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label7" runat="server" Text="Fecha:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;">
                                <asp:Label ID="lblFecha" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label8" runat="server" Text="Hora:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;">
                                <asp:Label ID="lblHora" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label12" runat="server" Text="País:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;">
                                <asp:Label ID="lblPais" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                                <asp:Label ID="Label13" runat="server" Text="Ciudad:" CssClass="estiloLabel"></asp:Label>
                            </td>
            <td style="width: 295px; height: 35px;">
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="height: 36px">
                    <asp:Label ID="Label4" runat="server" Text="Dirección:" CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="width: 295px; height: 36px;">
                    <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblTituloBanda" runat="server" 
                    Font-Bold="False" Text="Banda Auspiciante:" Visible="False" 
                    CssClass="estiloLabel" Width="151px"></asp:Label>
                </td>
            <td style="width: 295px; height: 16px;">
                <asp:Label ID="lblBanda" runat="server"></asp:Label>
            </td>
            <td style="width: 295px; height: 16px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 16px">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;" class="estiloLabel">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 16px">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;">
                &nbsp;</td>
            <td style="width: 295px; height: 16px;" class="estiloLabel">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 17px; text-align: center;" colspan="3">
        <asp:Label ID="Label11" runat="server" 
            Text="Ubicación en el Mapa" Width="193px" CssClass="estiloLabelCabecera2" 
                    Height="23px"></asp:Label>
                &nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 315px">
    <cc1:GMap ID="GMap1" runat="server" Width="527px" />
    
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <asp:Button ID="btEditar" runat="server" CssClass="botones" Text="Editar" />
                <asp:Button ID="btBorrar" runat="server" CssClass="botones" Text="Borrar" 
                    onclick="btBorrar_Click" OnClientClick="return confirm('¿Esta seguro de borrar?')" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
                     
             
                
            <td colspan="2" style="height: 1px">
                &nbsp;</td>
        </tr>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </table>
    
    
      
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                <legend>Comentarios</legend>
                <table class="tabla" border="1" style="width:512px;">
                <asp:Label ID="lblTabla" runat="server" Text="Panel created."></asp:Label>
                    <caption>
                        <br />
                    </caption>
                </table>
                </fieldset>
            
        <table class="tabla" style="height: 100px">
            <tr>
            <td align="left" style="height: 53px">
                
                <asp:TextBox ID="txtComentario" runat="server" Height="55px" Width="529px" 
                    TextMode="MultiLine"></asp:TextBox>
        </tr>
            <tr>
                <td align="right" style="height: 53px">
                    <asp:Button ID="btPublicar" runat="server" CssClass="botones" 
                        Width="95px" onclick="btPublicar_Click" Text="Publicar" />
                        <br />
                        <br />
                        <br />
                    <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" onclick="btnDenunciar_Click" />
                        
                </td>
            </tr>
        </ContentTemplate>
        </asp:UpdatePanel>
         <tr>
            <td align="right" class="tabla">
            </td>
        </tr>
        
        </table>
    
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    

</asp:Content>

