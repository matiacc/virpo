<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarPerfil.aspx.cs"
    Inherits="ModificarPerfil" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

                     
           <div id="menu8">
        <ul>
            <li><a href="Bandeja.aspx" title="Bandeja De Entrada">Bandeja De Entrada</a></li>
            <li><a href="ModificarPerfil.aspx" title="Modificar Perfil">Modificar Perfil</a></li>
            <li><a href="CambiarPassword.aspx" title="Cambiar Contraseña">Cambiar Contraseña</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="tabla" style="width: 125%">
        <tr>
            <td colspan="5">
                <center style="width: 528px; background-color: #333333"><tituloSubVentana>Hola  
                <asp:Label ID="lblLogin" runat="server"></asp:Label>
                       ! - Modifica tu Perfil</tituloSubVentana></center>
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 229px" rowspan="13">
                <asp:Image ID="ImgPerfil" runat="server" Height="250px" Width="250px" />
            </td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtNombre" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtApellido" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label13" runat="server" Text="Instrumento:"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlInstrumento" runat="server" AutoPostBack="True" Width="145px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtFecNac" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" Width="145px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtEmail" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label5" runat="server" Text="Teléfono Fijo:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtTelFijo" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label6" runat="server" Text="Teléfono Móvil:"></asp:Label>
            </td>
            <td>
            <div class="loginboxdiv">
                <asp:TextBox ID="txtTelMovil" runat="server" Width="127px" CssClass="loginbox"></asp:TextBox>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px; height: 27px;">
                &nbsp;</td>
            <td style="width: 124px; height: 27px;">
                &nbsp;</td>
            <td style="width: 124px; height: 27px;">
                <asp:Label ID="Label12" runat="server" Text="País:"></asp:Label>
            </td>
            <td rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                            Width="145px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"
                            Width="145px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" Width="145px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td rowspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label11" runat="server" Text="Prov./Edo.:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label10" runat="server" Text="Ciudad:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                <asp:Label ID="Label9" runat="server" Text="Barrio:" Visible="False"></asp:Label>
            </td>
            <td>
            
                <asp:TextBox ID="txtBarrio" runat="server" Width="127px" Visible="False"></asp:TextBox>
                
            </td>
            <td>
            
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 229px">
                &nbsp;
                <asp:FileUpload ID="uploadImagen" runat="server" Width="250px" />
            </td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 229px">
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
                    Text="Cancelar" CssClass="botones" />
            </td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="width: 124px">
                &nbsp;</td>
            <td style="text-align: right;">
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" 
                    Text="Guardar" CssClass="botones" />
            </td>
            <td style="text-align: right;">
                &nbsp;</td>
        </tr>
        </table>
    <asp:Button ID="Button2" runat="server" Text="False" Style="display: none" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>Tus datos fueron modificados con éxito</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" CssClass="botones" />
    </asp:Panel></center>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
