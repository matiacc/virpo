<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ModificarArticuloWiki.aspx.cs"
    Inherits="_Default" Title="Untitled Page" ValidateRequest="false"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoArticuloWiki.aspx" title="Nuevo Articulo">Nuevo Artículo</a></li>
            <li><a href="FavoritosWiki.aspx" title="Articulos Favoritos">Artículos Favoritos</a></li>
            <li><a href="MisArticulosWiki.aspx" title="Mis Articulos">Mis Artículos</a></li>
            <li><a href="ConsultarArticuloWiki.aspx" title="Articulo Aleatorio">Artículo 
                Aleatorio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <table class="tabla">
        <tr>
            <td colspan="3" style="text-align: center">
                <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                    Modificar Artículo</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                <asp:Label ID="lblTit" runat="server" Text="Título:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                <asp:Label ID="lblVers" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 13px; width: 258px;" class="submit">
                <asp:Label ID="lblCat" runat="server" Text="Categoría:"></asp:Label>
            </td>
            <td style="height: 13px" class="submit">
                <asp:Label ID="lblCategoria" runat="server"></asp:Label>
            </td>
            <td style="height: 13px" class="submit">
            </td>
        </tr>
        <tr>
            <td style="width: 258px; height: 13px;">
                <asp:Label ID="lblDesc" runat="server" Text="Descripción de la Modificación:"></asp:Label>
            </td>
            <td style="text-align: left; height: 13px;">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="301px"></asp:TextBox>
            </td>
            <td style="height: 13px">
                <asp:RequiredFieldValidator ID="rvDescrip" runat="server" 
                    ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="(*)" 
                    EnableTheming="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            
                <asp:TextBox ID="elm3" runat="server" Height="399px" Style="margin-left: 0px" TextMode="MultiLine"
                    Width="537px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 258px">
                &nbsp;
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnGuardar" runat="server" CssClass="botones" Text="Guardar" 
                    onclick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar" 
                    onclick="btnCancelar_Click" CausesValidation="False" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
<table>
        <tr>
            <td>
        <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
        <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
        <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
            <center>El Documento fue modificado con éxito.</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" CssClass="botones" />
    </center></asp:Panel>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
        <asp:Button ID="Button5" runat="server" Text="False" Style="display: none;" />
        <asp:Button ID="Button6" runat="server" Text="False2" Style="display: none;"/>
        <asp:Panel ID="Panel2" runat="server" Style="display: none;" CssClass="modalPopup">
            <center>El Documento no fue modificado, intente nuevamente.</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button4" runat="server" Text="OK" OnClick="Button4_Click" CssClass="botones" />
    </center></asp:Panel>
    <cc1:ModalPopupExtender ID="Panel2_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button5"
        PopupControlID="Panel2" OkControlID="Button6">
    </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
