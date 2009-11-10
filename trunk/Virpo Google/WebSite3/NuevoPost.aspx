<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevoPost.aspx.cs" Inherits="NuevoPost" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><asp:Label ID="lblMisGrupos" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblDebate" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblProyectos" runat="server"></asp:Label></li>
            
        </ul>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table class="style1">
        <tr>
            <td>
                <center style="width: 527px; background-color: #333333"><tituloSubVentana>
                  <asp:Label ID="lblTitulo" runat="server"></asp:Label></tituloSubVentana></center></td>
        </tr>
        <tr>
            <td class="tabla">
                
            </td>
        </tr>
        <tr>
            <td class="tabla">
                Comentario</td>
        </tr>
        <tr>
            <td class="tabla">
                <asp:TextBox ID="txtComentario" runat="server" Rows="15" TextMode="MultiLine" 
                    Width="527px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tabla">
                <asp:Button ID="btPublicar" runat="server" CssClass="botones" 
                    onclick="btPublicar_Click" Text="Publicar" />
            </td>
        </tr>
        <tr>
            <td class="tabla">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        </table>
                    
           <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>El comentario ha sido grabado!</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" CssClass="botones" />
    </asp:Panel></center>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

