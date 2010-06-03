﻿<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="NoticiaModificar.aspx.cs" Inherits="_Default" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="NoticiasBajas.aspx" title="Bajas">Modificar &amp; Bajas</a></li>
        </ul>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Text="Posicion:"></asp:Label>
        <asp:DropDownList ID="ddlPosicion" runat="server" Height="23px" Width="122px">
        </asp:DropDownList>
    </p>
    <p style="text-align: right">
        <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
        <asp:TextBox ID="txtDesc" runat="server" Height="25px" 
            style="margin-left: 0px; margin-bottom: 1px" Width="219px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtDesc" Display="Dynamic" 
            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox ID="elm3" runat="server" Height="366px" TextMode="MultiLine" Width="402px"></asp:TextBox>
    </p>
    <p style="text-align: right">
        <asp:Button ID="btnGuardar" runat="server" CssClass="botones" 
            onclick="btnGuardar_Click" Text="Guardar" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="botones" 
            onclick="btnCancelar_Click" Text="Cancelar" CausesValidation="False" />
    </p>
    <p>
        &nbsp;</p>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <table>
        <tr>
            <td>
        <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
        <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
        <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
            <center>La Noticia fue Modificada con éxito.</center>
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
            <center>La Noticia no fue Modificada, intente nuevamente.</center>
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