<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaPublicidad.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" />
    <contenttemplate>
    <table class="style1">
        <tr>
            <td colspan="4">
                <center style="width: 750px; background-color: #333333">
                    <titulosubventana>
                        Pedido de Publicidad</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; text-align: center;" colspan="2">
                &nbsp;
            </td>
            <td style="height: 20px">
            </td>
            <td style="height: 20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 20px; text-align: left;" colspan="3">
                <asp:Label ID="lblMsj" runat="server" Text="Deje sus datos y nos comunicaremos con usted a la brevedad"
                    CssClass="estiloLabel" Font-Italic="False"></asp:Label>
                <asp:Label ID="lblOk" runat="server" ForeColor="#009933" Text="Su consulta fue enviada con Exito, Desea hacer otra..."
                    Visible="False"></asp:Label>
                <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" Text="Su consulta no fue enviada, intentelo luego... Gracias"
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 20px">
                &nbsp;
            </td>
            <td style="height: 20px">
                &nbsp;
            </td>
            <td style="height: 20px">
                &nbsp;
            </td>
            <td style="height: 20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa a Publicitar:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEntidad" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEntidad"
                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td rowspan="11">
                <asp:ImageButton ID="imgPubli" runat="server" Height="520px" Width="195px" />
                <br />
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblContacto" runat="server" Text="Nombre del Contacto:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreContacto"
                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblTel" runat="server" Text="Telefono de Contacto:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelContacto"
                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblMail" runat="server" Text="Mail de Contacto:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMailContacto"
                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblMeses" runat="server" Text="Meses de Publicidad:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMeses" runat="server" Height="22px" Width="55px" OnSelectedIndexChanged="ddlMeses_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblFrec" runat="server" Text="Impresiones Diarias :" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFrecuencia" runat="server" Height="22px" Width="55px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label5" runat="server" Text="Sitio Web:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="227px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label4" runat="server" Text="Imagen:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="upPublicidad" runat="server" Width="227px" Height="26px" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblConsulta" runat="server" Text="Dejanos tu Consulta:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnPrevisualizar" runat="server" OnClick="btnCargar_Click" Text="Cargar"
                    Width="229px" CssClass="botones" CausesValidation="False" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtConsulta" runat="server" Height="124px" TextMode="MultiLine"
                    Width="227px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnEnviar" runat="server" CssClass="botones" OnClick="btnEnviar_Click"
                    Text="Enviar" />
                <asp:Button ID="btnVolver" runat="server" CausesValidation="False" CssClass="botones"
                    OnClick="btnVolver_Click" Text="Volver" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <p>
    </p>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
