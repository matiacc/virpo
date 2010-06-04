<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ConsultarGrupo.aspx.cs" Inherits="ConsultarGrupo" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><a href="MisGrupos.aspx" title="Mis Grupos de Interés">Mis Grupos</a></li>
            <li><asp:Label ID="lblDebate" runat="server"></asp:Label></li>
            <li><asp:Label ID="lblProyectos" runat="server"></asp:Label></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <SCRIPT LANGUAGE="JavaScript">
window.opener.location.reload();
</SCRIPT>

    <table class="tabla">
        <tr>
        <td colspan="3" style="text-align: center; background-color: #333333">
        <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Grupo: <asp:Label ID="lblNombre" runat="server"></asp:Label></titulosubventana>
                </center>
            
              </td>
            
        </tr>
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
               
                

                <asp:Label ID="lblDescripcion" runat="server" CssClass="estiloLabelCabecera2"></asp:Label>

                </td>

                </td>

        </tr>
        <tr>
            <td colspan="3" style="text-align: right">
               
                
                <asp:Button ID="btUnirme" runat="server" Text="Unirme!" 
                    onclick="btUnirme_Click" CssClass="botones" Width="120px" />

                </td>
        </tr>
        <%--<tr>
            <td colspan="3" align="right">
               
                
                <asp:Button ID="btUnirme" runat="server" Text="Unirme!" 
                    onclick="btUnirme_Click" CssClass="botones" Width="120px" />

                </td>
        </tr>--%>
        <tr>
            <td>
                Creado por:</td>
            <td>
                <asp:Label ID="lblCreador" runat="server"></asp:Label>
            </td>
            <td rowspan="9" style="text-align: right">
                <asp:Image ID="imgGrupo"  runat="server" style="height:120px" Width="120px"/>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Tema:</td>
            <td>
                <asp:Label ID="lblTema" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                 Miembros (<asp:Label ID="lblCantMiembros" runat="server"></asp:Label>)</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                 &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMiembros" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <%--<tr>
            <td colspan="2">
                Enlaces                 <br />
                Recomendados</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblEnlaces" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="text-align: right">

                <asp:Button ID="btEditar" runat="server" CssClass="botones" Text="Editar" />
                <asp:Button ID="btBorrar" runat="server" CssClass="botones" Text="Borrar" 
                    onclick="btBorrar_Click" OnClientClick="return confirm('¿Esta seguro de borrar?')" />
            </td>
            <td align="right">

                <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="120px" onclick="btnDenunciar_Click" />
            
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="text-align: right">

                &nbsp;</td>
        </tr>
        </table>
                 <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>Se ha unido al grupo!!</center>
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

