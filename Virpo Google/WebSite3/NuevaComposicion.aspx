<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevaComposicion.aspx.cs"
    Inherits="NuevaComposicion" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="tabla">
        <tr>
            <td colspan="3">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Subir Composicion</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                Tipo de Conposicion:
            </td>
            <td colspan="2">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="Pista" GroupName="Tipo" Checked="True" />
                &nbsp;
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Cancion No Terminada" GroupName="Tipo" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Nombre<br />
            </td>
            <td colspan="2">
                <div class="loginboxdiv">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="loginbox" Width="127px"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Tempo
            </td>
            <td colspan="2">
                <div class="loginboxdiv">
                    <asp:TextBox ID="txtTempo" runat="server" CssClass="loginbox" Width="127px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Tonalidad
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlTonalidad" runat="server" Width="145px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Tipo Instrumento
            </td>
            <td rowspan="2" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged"
                            AutoPostBack="True" Width="145px">
                        </asp:DropDownList>
                        <br>
                            <br></br>
                            <asp:DropDownList ID="ddlInstrumento" runat="server">
                            </asp:DropDownList>
                        </br>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Instrumento
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Descripcion
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="145px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Archivo de Audio
            </td>
            <td colspan="2">
                <%--<asp:FileUpload ID="FileUpload1" runat="server"/>--%>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="145px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: left">
                <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click" Text="Aceptar"
                    CssClass="botones" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="botones"
                    OnClick="btnCancelar_Click" Text="Cancelar" />
            </td>
            <td style="text-align: right">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
