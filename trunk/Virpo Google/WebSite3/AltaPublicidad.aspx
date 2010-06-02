<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaPublicidad.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <p>
        <br />
    </p>
    <table class="style1">
        <tr>
            <td colspan="5">
                 <center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Pedido de Publicidad</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td style="height: 20px">
                </td>
            <td style="height: 20px; text-align: center;" colspan="2">
                &nbsp;</td>
            <td style="height: 20px">
                </td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px; text-align: center;" colspan="3">
                <asp:Label ID="lblMsj" runat="server" Font-Italic="True" 
                    Text="Dejanos estos datos y nos comunicaremos con vos a la brevedad"></asp:Label>
                <asp:Label ID="lblOk" runat="server" ForeColor="#009933" 
                    Text="Su consulta fue enviada con Exito, Desea hacer otra..." Visible="False"></asp:Label>
                <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" 
                    Text="Su consulta no fue enviada, intentelo luego... Gracias" Visible="False"></asp:Label>
            </td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa a Publicitar:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEntidad" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtEntidad" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td rowspan="12">
                <asp:ImageButton ID="imgPubli" runat="server" Height="430px" Width="145px" />
                <br />
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblContacto" runat="server" Text="Nombre del Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNombreContacto" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblTel" runat="server" Text="Telefono de Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="txtTelContacto" Display="Dynamic" ErrorMessage="*" 
                    Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblMail" runat="server" Text="Mail de Contacto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailContacto" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtMailContacto" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblMeses" runat="server" Text="Meses de Publicidad:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMeses" runat="server" Height="22px" Width="55px" 
                    onselectedindexchanged="ddlMeses_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Vigencia:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFecIni" runat="server"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="  a  "></asp:Label>
                <asp:Label ID="lblFecFin" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblFrec" runat="server" Text="Impresiones:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFrecuencia" runat="server" Height="22px" Width="55px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label5" runat="server" Text="Sitio Web:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="227px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label4" runat="server" Text="Imagen:"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="upPublicidad" runat="server" Width="227px" Height="26px"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="lblConsulta" runat="server" Text="Dejanos tu Consulta:"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnPrevisualizar" runat="server" onclick="btnCargar_Click" 
                    Text="Cargar" Width="229px" CssClass="botones" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtConsulta" runat="server" Height="124px" 
                    TextMode="MultiLine" Width="227px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnEnviar" runat="server" CssClass="botones" 
                    onclick="btnEnviar_Click" Text="Enviar" />
                <asp:Button ID="btnVolver" runat="server" CausesValidation="False" 
                    CssClass="botones" onclick="btnVolver_Click" Text="Volver" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <br />
    <p>
    </p>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

