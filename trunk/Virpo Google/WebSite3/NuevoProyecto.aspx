<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoProyecto.aspx.cs" Inherits="NuevoProyecto" Title="Página sin título" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Crear un Proyecto</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="286px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Descripcion</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Height="79px" 
                    TextMode="MultiLine" Width="286px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Imagen</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="286px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Genero</td>
            <td>
                <asp:TextBox ID="txtGenero" runat="server"  autocomplete="off"  
                    Width="286px"></asp:TextBox>
                
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Tipo</td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server" Width="143px">
                    <asp:ListItem Value="0">Publico</asp:ListItem>
                    <asp:ListItem Value="1">Privado</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Licencia</td>
                                <td>
                                    <a href="http://creativecommons.org/licenses/by/2.5/ar/" target="_blank">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Atribución 2.5" 
                                        GroupName="Licencia" Checked="True" /></a>
                                    <br />
                                    <a href="http://creativecommons.org/licenses/by-nc/2.5/ar/">
                                    <asp:RadioButton ID="RadioButton2" runat="server" 
                                        Text="Atribución-No Comercial 2.5" GroupName="Licencia" /></a>
                                    <br />
                                    <a href="http://creativecommons.org/licenses/by-nc-nd/2.5/ar/">
                                    <asp:RadioButton ID="RadioButton3" runat="server" 
                                        Text="Atribución-No Comercial-Sin Obras Derivadas 2.5" /></a>
                                    <br />
                                    <a href="http://creativecommons.org/licenses/by-nc-sa/2.5/ar/">
                                    <asp:RadioButton ID="RadioButton4" runat="server" 
                                        Text="Atribución-No Comercial-Compartir Obras Derivadas Igual 2.5" /></a>
                                    <br />
                                    <a href="http://creativecommons.org/licenses/by-nd/2.5/ar/">
                                    <asp:RadioButton ID="RadioButton5" runat="server" 
                                        Text="Atribución-Sin Obras Derivadas 2.5" /></a>
                                    <br />
                                    <a href="http://creativecommons.org/licenses/by-sa/2.5/ar/">
                                    <asp:RadioButton ID="RadioButton6" runat="server" 
                                        Text="Atribución-Compartir Obras Derivadas Igual 2.5" />
                                        </a>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Tags</td>
            <td>
                <asp:TextBox ID="txtTags" runat="server" Width="286px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btCrear" runat="server" Text="Crear!" onclick="btCrear_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

