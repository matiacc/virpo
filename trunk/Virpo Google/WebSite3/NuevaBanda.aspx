<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevaBanda.aspx.cs"
    Inherits="_Default" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="ListarUsuarios.aspx" title="Agregar Integrante">Agregar Integrante</a></li>
            <li><a href="MostrarIntegrantesBanda.aspx" title="Agregar Integrante">Bandas e Integrantes</a></li>
            <li><a href="ListarBandas.aspx" title="Agregar Integrante">Listar Bandas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%" class="tabla">
        <tr>
            <td colspan="2">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Nueva Banda</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtNombreBanda" runat="server" Width="297px" Style="margin-bottom: 0px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px">
                <asp:Label ID="lblGenero" runat="server" Text="Genero:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left; margin-left: 40px;">
                <asp:DropDownList ID="ddlGenero" runat="server" Style="text-align: left">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblFecInicio" runat="server" Text="Fecha de Inicio:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlDia" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMes" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlAnio" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblPais" runat="server" Text="Pais:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 29px">
                                    <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" Height="22px"
                                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlLocalidad" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia/Estado:" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblLocalidad" runat="server" Text="Ciudad:" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblSitioWeb" runat="server" Text="Sitio web:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtSitioWeb" runat="server" Width="297px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 248px">
                <asp:Label ID="lblFoto" runat="server" Text="Foto:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:FileUpload ID="uploadImagen" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
                <asp:Label ID="lblVideo" runat="server" Text="Video YouTube:" 
                    CssClass="estiloLabel"></asp:Label>
                <br />
                <br />
            </td>
            <td style="height: 19px">
                <asp:TextBox ID="txtVideo" runat="server" Width="127px"></asp:TextBox>
                <br>
                <asp:Label ID="Label1" runat="server" 
                    Text="Introducir el texto que sigue al signo = de la url, ej: http://www.youtube.com/watch?v=" 
                    style="font-size: 7pt"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="xy5JwYOlgvY" style="color: #EF1818"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
                &nbsp;</td>
            <td style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 248px; height: 19px">
            </td>
            <td style="height: 19px; text-align: right;">
                <asp:Button ID="btnCrearBanda" runat="server" CssClass="botones" Text="Crear Banda"
                    Width="148px" OnClick="Button3_Click" />
            </td>
        </tr>
    </table>
    
    <asp:Button ID="Button2" runat="server" Text="False" Style="display: none" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>
            La Banda fue creada con éxito</center>
        <br />
        <br />
        <center>
            <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" CssClass="botones" />
    </asp:Panel>
    </center>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
