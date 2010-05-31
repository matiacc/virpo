<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaClasificado.aspx.cs" Inherits="AltaClasificado" Title="Página sin título" %>

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
    <table style="width: 134%" class="tabla">
        <tr>
            <td style="height: 16px; width: 2747px;">
                </td>
            <td colspan="2" style="height: 16px; ">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center; background-color: #333333">
                <tituloSubVentana><asp:Label ID="lblTitulo" runat="server"></asp:Label><tituloSubVentana>
                </td>
        </tr>
        <tr>
            <td style="width: 2747px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label1" runat="server" Text="Título" CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtTitulo" runat="server" Width="405px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtTitulo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <%--
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Imagen 2"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Imagen 3"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Imagen 4"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" />
            </td>
        </tr>--%>
        
        
        <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label3" runat="server" Text="Descripción" CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="78px" Rows="5" 
                    Width="405px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label4" runat="server" Text="Precio" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left; " colspan="2">
            <asp:DropDownList ID="ddlMoneda" runat="server">
                    <asp:ListItem Value="pesos">$</asp:ListItem>
                    <asp:ListItem Value="dolares">U$S</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtPrecio" runat="server" Width="100px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label9" runat="server" Text="Ubicación" CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtUbicacion" runat="server" 
                    Width="405px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Fecha Inicio"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
         <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label6" runat="server" Text="Duración" CssClass="estiloLabel"></asp:Label>
             </td>
            <td style="text-align: left; " colspan="2">
                <asp:RadioButton ID="rb0dias" runat="server" GroupName="Duracion" 
                    Text="0 días" CssClass="estiloLabel" Visible="False" />
                <asp:RadioButton ID="rb10dias" runat="server" GroupName="Duracion" 
                    Text="10 días" Checked="True" CssClass="estiloLabel" />
                <asp:RadioButton ID="rb20dias" runat="server" GroupName="Duracion" 
                    Text="20 días" CssClass="estiloLabel" />
                <asp:RadioButton ID="rb30dias" runat="server" GroupName="Duracion" 
                    Text="30 días" CssClass="estiloLabel" />
                
             </td>
        </tr>
         <tr>
            <td style="width: 2747px">
                <asp:Label ID="Label7" runat="server" Text="Rubro" CssClass="estiloLabel"></asp:Label>
             </td>
            <td style="text-align: left; " colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlRubro" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlRubro_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSubrubro1" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlSubrubro1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSubrubro2" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </td>
        </tr>
         <tr>
            <td style="width: 2747px">
                
             </td>
            <td colspan="2">
                <asp:Label ID="lblRubro" runat="server" ForeColor="Red" Text="Seleccione un Rubro" 
                    Visible="False"></asp:Label>
             </td>
        </tr>
         <tr>
                        <td style="width: 2747px">
                <asp:Label ID="Label2" runat="server" Text="Imágenes" CssClass="estiloLabel"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
            </td>
            <td style="text-align: left; " colspan="2">
                <br/>
                <table class="style1">
                    <tr>
                        <td>
                <asp:Image ID="Image1" runat="server" Visible="False" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBorrar1" runat="server" Text="Borrar" Visible="False" />
                        </td>
                        <td>
                <asp:FileUpload ID="uploadImagen" runat="server" Width="260px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Image ID="Image2" runat="server" Visible="False" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBorrar2" runat="server" Text="Borrar" Visible="False" />
                        </td>
                        <td>
                <asp:FileUpload ID="uploadImagen0" runat="server" Width="260px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Image ID="Image3" runat="server" Visible="False" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBorrar3" runat="server" Text="Borrar" Visible="False" />
                        </td>
                        <td>
                <asp:FileUpload ID="uploadImagen1" runat="server" Width="260px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Image ID="Image4" runat="server" Visible="False" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBorrar4" runat="server" Text="Borrar" Visible="False" />
                        </td>
                        <td>
                <asp:FileUpload ID="uploadImagen2" runat="server" Width="260px" />
                        </td>
                    </tr>
                </table>
                <br/>
                <br/>
                <br/>
        </tr>
        <tr>
            <td style="width: 2747px">
                &nbsp;</td>
            <td style="text-align: right; width: 1225px;">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                    onclick="btGuardar_Click" CssClass="botones" />
                </td>
            <td style="text-align: right; width: 73px;">
                <input id="btVolver" type="button" value="Volver" class="botones" onclick="history.back()"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

