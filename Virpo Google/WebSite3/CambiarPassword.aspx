<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="CambiarPassword.aspx.cs"
    Inherits="CambiarPassword" Title="Página sin título" %>

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
<center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Cambiar Contraseña</tituloSubVentana></center>
    <table class="tabla" style="width: 132%">
        <tr>
            <td style="width: 171px">
                &nbsp;
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 171px">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 171px; height: 39px;">
                &nbsp;
                <asp:Label ID="Label4" runat="server" Text="Nombre de Usuario:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2" style="height: 39px; text-align: left">
                <asp:Label ID="lblNomUsuario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; height: 39px;">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Contraseña Actual:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2" style="height: 39px; text-align: left">
                <div class="loginboxdiv">            
                <asp:TextBox ID="txtPasswordActual" runat="server" TextMode="Password" 
                        CssClass="loginbox" Width="127px"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPasswordActual"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                <asp:Label ID="lblContraseñaActual" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; height: 39px;">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Contraseña Nueva:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2" style="height: 39px; text-align: left">
                <div class="loginboxdiv">  
                <asp:TextBox ID="txtNvaPassword" runat="server" TextMode="Password" 
                        CssClass="loginbox" Width="127px"></asp:TextBox>
                </div>
                <cc1:PasswordStrength ID="txtNvaPassword_PasswordStrength" runat="server" TargetControlID="txtNvaPassword"
                    DisplayPosition="RightSide" StrengthIndicatorType="Text" PreferredPasswordLength="5"
                    PrefixText="Seguridad: " TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="1"
                    MinimumSymbolCharacters="1" RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Muy Débil; Débil; Mejorable; Buena; Perfecta"
                    TextStrengthDescriptionStyles="estiloLabelRojo;estiloLabelNaranja;estiloLabelAmarillo;estiloLabelCeleste;estiloLabelVerde"
                    CalculationWeightings="50;15;15;20">
                </cc1:PasswordStrength>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNvaPassword"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 171px; height: 38px;">
                &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Repetir Contraseña:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td colspan="2" style="height: 38px; text-align: left">
                <div class="loginboxdiv" id="127">  
                <asp:TextBox ID="txtConfrimarPassword" runat="server" TextMode="Password" 
                        CssClass="loginbox" Width="127px"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfrimarPassword"
                    ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                <asp:Label ID="lblConfirmaContraseña" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 171px">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 33px; width: 171px;">
                <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver"
                    CausesValidation="False" CssClass="botones" Width="100px" />
            </td>
            <td style="height: 33px; text-align: right;">
                &nbsp;</td>
            <td style="height: 33px; text-align: right;">
                <asp:Button ID="btnCambia" runat="server" Text="Aceptar" 
                    OnClick="btnCambia_Click" CssClass="botones" Width="100px" />
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
