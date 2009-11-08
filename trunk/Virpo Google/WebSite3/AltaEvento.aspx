<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaEvento.aspx.cs" Inherits="_Default" Title="Página sin título" %>

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
            <td colspan="3">
                    <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Nuevo Evento</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td colspan="3">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label3" runat="server" Text="Lugar:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:TextBox ID="txtLugar" runat="server"></asp:TextBox>
            </td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label4" runat="server" Text="Pais:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPaises" runat="server" Width="178px" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td style="width: 197px">
            
                </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label5" runat="server" Text="Ciudad:"></asp:Label>
            </td>
            <td style="width: 92px">
                                <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label6" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td style="width: 197px">
                
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label7" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td style="width: 92px">
                        <asp:Calendar ID="Calendar1" runat="server" Height="199px" 
                    Width="257px">
                        <TodayDayStyle ForeColor="Black" BackColor="#FF9900"></TodayDayStyle>
                        <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                        <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                        <DayHeaderStyle Font-Size="9pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
                        <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#FF9900"></SelectedDayStyle>
                        <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
                        <WeekendDayStyle BackColor="#DBE5EC"></WeekendDayStyle>
                        <OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>

                        
                        
                        </asp:Calendar>
                        
                    </td>
            <td style="width: 197px">
                <asp:UpdatePanel ID="updatePanel" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label8" runat="server" Text="Hora:"></asp:Label>
            </td>
            <td style="width: 92px">
                 <table class="style1" style="width: 104%; margin-left: 0px">
                    <tr>
                        <td style="text-align: right; width: 33px">
                            <asp:DropDownList ID="ddlHora" runat="server" 
                                >
                            </asp:DropDownList>
                        </td>
                        <td style="width: 29px">
                            <asp:Label ID="Label12" runat="server" Text="hs"></asp:Label>
                        </td>
                        <td style="text-align: right; width: 53px">
                            <asp:DropDownList ID="ddlMin" runat="server" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="min"></asp:Label>
                        </td>
                    </tr>
                </table></td>
            <td style="width: 197px">
               
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label9" runat="server" Text="Imagen:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:ImageMap ID="ImageMap1" runat="server" BorderColor="Black" 
                            BorderStyle="Double" BorderWidth="3px" HotSpotMode="PostBack" 
                            ImageUrl="~/ImagenesSite/interrogacion.jpg">
                        </asp:ImageMap>
                        <br />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <br />
                        <asp:Button ID="btnCargar" runat="server" onclick="btnCargar_Click" 
                            Text="Cargar" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCargar" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 197px">
            
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label10" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="52px" 
                    TextMode="MultiLine" Width="165px"></asp:TextBox>
            </td>
            <td style="width: 197px">
               
            </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                <asp:Label ID="Label11" runat="server" Text="Banda:"></asp:Label>
            </td>
            <td style="width: 92px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBandas" runat="server" AutoPostBack="True" 
                            Width="178px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 197px">
                
                </td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="text-align: right;" colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                    onclick="btnGuardar_Click" CssClass="botones" />
            </td>
        </tr>
    </table>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

