<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoProyecto.aspx.cs" Inherits="NuevoProyecto" Title="Página sin título" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Crear Proyecto</tituloSubVentana></center>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px; height: 20px;">
                Nombre<br />
                <br />
            </td>
            <td style="width: 291px; height: 20px;">
                <div class="loginboxdiv">
                 <asp:TextBox ID="txtNombre" runat="server" Width="127px" CssClass="loginbox" 
                    Height="29px"></asp:TextBox></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 20px">
                </td>
        </tr>
        <tr>
            <td style="width: 92px">
                Descripcion</td>
            <td style="width: 291px">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="79px" 
                    TextMode="MultiLine" Width="286px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                Imagen</td>
            <td style="width: 291px">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="286px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                Genero<br />
                <br />
            </td>
            <td style="width: 291px">
                <div class="loginboxdiv">
                    <asp:TextBox ID="txtGenero" runat="server"  autocomplete="off"  
                    Width="127px" CssClass="loginbox" Height="22px"></asp:TextBox></div>
                
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                Tipo</td>
            <td style="width: 291px">
                <asp:DropDownList ID="ddlTipo" runat="server" Width="143px">
                    <asp:ListItem Value="0">Publico</asp:ListItem>
                    <asp:ListItem Value="1">Privado</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                Licencia</td>
                                <td style="width: 291px">
                                    
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Atribución 2.5" 
                                        GroupName="Licencia" Checked="True" CssClass="estiloLabelpeque" />
                                        &nbsp;<a href="http://creativecommons.org/licenses/by/2.5/ar/" 
                                        target="_blank" style="color: #EF1818"><span style="font-size: xx-small">+</span></a>
                                    <br />
                                    
                                    <asp:RadioButton ID="RadioButton2" runat="server" 
                                        Text="Atribución-No Comercial 2.5" GroupName="Licencia" 
                                        CssClass="estiloLabelpeque" />
                                        &nbsp;<a href="http://creativecommons.org/licenses/by-nc/2.5/ar/" 
                                        target="_blank" style="color: #EF1818"><span style="font-size: xx-small">+</span></a>
                                    <br />
                                   
                                    <asp:RadioButton ID="RadioButton3" runat="server" 
                                        Text="Atribución-No Comercial-Sin Obras Derivadas 2.5" 
                                        CssClass="estiloLabelpeque" GroupName="Licencia" />
                                         &nbsp;<a href="http://creativecommons.org/licenses/by-nc-nd/2.5/ar/" 
                                        target="_blank"" style="color: #EF1818"><span style="font-size: xx-small">+</span></a>
                                    <br />
                                    
                                    <asp:RadioButton ID="RadioButton4" runat="server" 
                                        Text="Atribución-No Comercial-Compartir Obras Derivadas Igual 2.5" 
                                        CssClass="estiloLabelpeque" Width="360px" GroupName="Licencia" />
                                        <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/ar/" 
                                        target="_blank" style="color: #EF1818"> <span style="font-size: xx-small">+</span></a>
                                    <br />
                                    
                                    <asp:RadioButton ID="RadioButton5" runat="server" 
                                        Text="Atribución-Sin Obras Derivadas 2.5" CssClass="estiloLabelpeque" 
                                        GroupName="Licencia" />
                                        <span style="color: #FF0000">&nbsp;</span><a href="http://creativecommons.org/licenses/by-nd/2.5/ar/" target="_blank"><span 
                                        style="font-size: xx-small; color: #EF1818">+</span></a>
                                    <br />
                                   
                                    <asp:RadioButton ID="RadioButton6" runat="server" 
                                        Text="Atribución-Compartir Obras Derivadas Igual 2.5" 
                                        CssClass="estiloLabelpeque" GroupName="Licencia" />
                                         <a href="http://creativecommons.org/licenses/by-sa/2.5/ar/" 
                                        target="_blank"" style="color: #EF1818"> <span style="font-size: xx-small">+</span></a>
                                    <br />
                                    <br />
                                         <br />
                                    <span style="font-size: xx-small; color: #EF1818">Hacer click sobre el signo
                                    </span><span style="font-size: medium; color: #000000">+ </span>
                                    <span style="font-size: xx-small; color: #EF1818">para obtener mas info sobre la 
                                    licencia.</span><br />
                                    <br />
            </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 92px">
                                    Tags<br />
                                    <br />
                                </td>
            <td style="width: 291px">
                <div class="loginboxdiv">   <asp:TextBox ID="txtTags" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>   </div>
            &nbsp;<span style="font-size: xx-small; color: #808080">(separados por comas)</span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 291px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 92px">
                &nbsp;</td>
            <td style="width: 291px">
                <asp:Button ID="btCrear" runat="server" Text="Crear!" onclick="btCrear_Click" 
                    CssClass="botones" Width="75px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

