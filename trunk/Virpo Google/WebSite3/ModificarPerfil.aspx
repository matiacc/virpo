<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarPerfil.aspx.cs"
    Inherits="ModificarPerfil" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="menu8">
        <ul>
            <li><a href="ModificarPerfil.aspx" title="Modificar Perfil">Modificar Perfil</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  <table class="tabla">
                    <tr>
                        <td colspan="7">
                            <center style="width: 528px; background-color: #333333">
                                <tituloSubVentana>Hola
                                <asp:Label ID="lblLogin" runat="server"></asp:Label>
                                ! - Modificar Perfil</tituloSubVentana></center>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 158px" rowspan="14">
                <asp:Image ID="ImgPerfil" runat="server" Height="319px" Width="281px" />
              
                            <br />
                            <br />
                            <br />
              
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
              
                        </td>
                        <td style="width: 139px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td colspan="3">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 139px">
                        <div class="loginboxdiv">
                <asp:TextBox ID="txtNombre" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                       
                            &nbsp;</td>
                        <td style="width: 90px">
                       
                <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
               
                            <br />
               
                        </td>
                        <td style="width: 90px">
                       
                            &nbsp;</td>
                        <td style="width: 90px">
                       
                            &nbsp;</td>
                        <td style="width: 139px">
                         <div class="loginboxdiv">
                <asp:TextBox ID="txtApellido" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Label ID="Label13" runat="server" Text="Instrumento:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlInstrumento" runat="server" AutoPostBack="True" 
                            Width="145px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td colspan="3">
                <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                        </td>
                        <td style="width: 139px">
                        <div class="loginboxdiv">
                <asp:TextBox ID="txtFecNac" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSexo" runat="server" 
    AutoPostBack="True" Width="145px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                         <div class="loginboxdiv">
                <asp:TextBox ID="txtEmail" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Label ID="Label5" runat="server" Text="Teléfono Fijo:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                         <div class="loginboxdiv">
                <asp:TextBox ID="txtTelFijo" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td colspan="3">
                <asp:Label ID="Label6" runat="server" Text="Teléfono Móvil:"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 139px">
                         <div class="loginboxdiv">
                <asp:TextBox ID="txtTelMovil" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            <br />
                <asp:Label ID="Label12" runat="server" Text="Pais:"></asp:Label>
                            <br />
                            <br />
                <asp:Label ID="Label14" runat="server" Text="Prov./Edo."></asp:Label>
                            <br />
                            <br />
                <asp:Label ID="Label15" runat="server" Text="Ciudad:"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlPais_SelectedIndexChanged" Width="145px">
                                    </asp:DropDownList>
                                    <br>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlProvincia_SelectedIndexChanged" Width="145px">
                                    </asp:DropDownList>
                                  
                                    <asp:DropDownList ID="ddlLocalidad" runat="server" Width="145px">
                                    </asp:DropDownList>
                                   
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Label ID="Label9" runat="server" Text="Barrio:" Visible="False"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                         <div>
                <asp:TextBox ID="txtBarrio" runat="server" Width="127px" CssClass="loginbox" Visible="False"></asp:TextBox>
                 </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                    Text="Guardar" CssClass="botones" />
                        </td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px; text-align: right;">
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" CssClass="botones" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 90px">
                            &nbsp;</td>
                        <td style="width: 139px; text-align: right;">
                            &nbsp;</td>
                    </tr>
                    </table>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
