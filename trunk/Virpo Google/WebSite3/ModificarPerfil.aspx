<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarPerfil.aspx.cs"
    Inherits="ModificarPerfil" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1" style="width: 225%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="Mi Perfil"></asp:Label>
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                <asp:Label ID="lblLogin" runat="server"></asp:Label>
            </td>
            <td style="width: 160px">
                &nbsp;
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td rowspan="12" style="width: 310px">
                <asp:Image ID="ImgPerfil" runat="server" Height="300px" Width="300px" />
            </td>
            <td style="width: 160px">
                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label13" runat="server" Text="Instrumento:"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlInstrumento" runat="server" AutoPostBack="True" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtFecNac" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label5" runat="server" Text="Teléfono Fijo:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtTelFijo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label6" runat="server" Text="Teléfono Móvil:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtTelMovil" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px; height: 27px;">
                <asp:Label ID="Label12" runat="server" Text="País:"></asp:Label>
            </td>
            <td style="width: 105px" rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                            Width="200px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"
                            Width="200px">
                        </asp:DropDownList>
                        <br>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 118px; height: 27px;">
                &nbsp;
            </td>
            <td style="height: 27px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label11" runat="server" Text="Provincia:"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label10" runat="server" Text="Localidad:"></asp:Label>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 160px">
                <asp:Label ID="Label9" runat="server" Text="Barrio:"></asp:Label>
            </td>
            <td style="width: 105px">
                <asp:TextBox ID="txtBarrio" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
                <asp:FileUpload ID="uploadImagen" runat="server" />
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 160px">
                &nbsp;
            </td>
            <td style="width: 105px">
                &nbsp;
            </td>
            <td style="width: 118px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Button ID="Button2" runat="server" Text="False" Style="display: none" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        Tus datos fueron modificados
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </asp:Panel>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
