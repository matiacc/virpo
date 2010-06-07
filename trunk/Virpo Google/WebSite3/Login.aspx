<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 275px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 275px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 275px">
            <center>
                <asp:Login ID="LoginVirpo" runat="server" BackColor="#4B7EA9" BorderColor="#000099" 
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="0.8em" ForeColor="White" 
                    onauthenticate="LoginVirpo_Authenticate" Width="359px" CssClass="botones">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#003399" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login></center>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 275px; text-align: center;">
                <asp:Label ID="lblMensaje" runat="server">¿No es usuario registrado?<a href="AltaMusico.aspx">
                    Registrarse aquí</a></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 275px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

