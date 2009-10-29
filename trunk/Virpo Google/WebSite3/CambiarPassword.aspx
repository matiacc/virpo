<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="CambiarPassword.aspx.cs"
    Inherits="CambiarPassword" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style1" style="width: 192%">
        <tr>
            <td style="width: 181px">
                &nbsp;
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Cambiar Contraseña
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre de Usuario:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNomUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Contraseña Actual:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPasswordActual" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPasswordActual"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                <asp:Label ID="lblContraseñaActual" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Contraseña Nueva:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNvaPassword" runat="server" TextMode="Password"></asp:TextBox>
                <cc1:PasswordStrength ID="txtNvaPassword_PasswordStrength" runat="server" TargetControlID="txtNvaPassword"
                    DisplayPosition="RightSide" StrengthIndicatorType="Text" PreferredPasswordLength="5"
                    PrefixText="Fortaleza: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1"
                    MinimumSymbolCharacters="1" RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="muy débil; débil; mejorable; buena; perfecta"
                    TextStrengthDescriptionStyles="cssClass2;cssClass2;cssClass3;cssClass4;cssClass5"
                    CalculationWeightings="50;15;15;20">
                </cc1:PasswordStrength>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNvaPassword"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Repetir Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfrimarPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfrimarPassword"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                <asp:Label ID="lblConfirmaContraseña" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 33px; width: 181px;">
            </td>
            <td style="height: 33px">
                <asp:Button ID="btnCambia" runat="server" Text="Cambiar Contraseña" OnClick="btnCambia_Click" />
                <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver"
                    CausesValidation="False" />
            </td>
        </tr>
    </table>
    
    <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
    <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;"/>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
        <center>El cambio de contraseña se realizó con éxito</center>
        <br />
        <br />
        
        <center><asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" CssClass="botones" CausesValidation="False"/>
    </asp:Panel></center>
    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
        runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
        PopupControlID="Panel1" OkControlID="Button3">
    </cc1:ModalPopupExtender>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
