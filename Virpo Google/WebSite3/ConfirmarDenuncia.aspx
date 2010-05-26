<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="ConfirmarDenuncia.aspx.cs" Inherits="ConfirmarDenuncia" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="style1">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
        <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
        <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
        <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
            <center>El documento Denunciado fue dado de baja.</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" CssClass="botones" />
        <%--<asp:Button ID="Button7" runat="server" Text="NO" OnClick="Button4_Click" CssClass="botones" />--%>
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
            <center>La denuncia fue descartada.</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button4" runat="server" Text="OK" OnClick="Button4_Click" CssClass="botones" />
        <%--<asp:Button ID="Button4" runat="server" Text="NO" OnClick="Button8_Click" CssClass="botones" />--%>
    </center></asp:Panel>
    <cc1:ModalPopupExtender ID="Panel2_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button5"
        PopupControlID="Panel2" OkControlID="Button6">
    </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>

       

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

