<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="AltaMusico.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AltaMusico.aspx" title="Registrar Musico">Registrar Musico</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
   <table style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
        </tr>
        <tr>
            <td colspan="2">
            <center style="width: 529px; background-color: #333333">
                <tituloSubVentana>Registrar Musico</tituloSubVentana></center></td>
        </tr>
        <tr>
            <td style="width: 187px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblPassword" runat="server" Text="Password:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="339px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblInstrumento" runat="server" Text="Instrumento:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlInstrumento" runat="server" Width="339px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlSexo" runat="server" Width="339px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblFecNac" runat="server" Text="Fecha de Nacimiento:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlDia" runat="server" Width="40px">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMes" runat="server" Width="40px">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlAnio" runat="server" Width="75px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 187px; height: 19px">
                <asp:Label ID="lblTelFijo" runat="server" Text="Telefono:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:TextBox ID="txtTelFijo" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblTelMovil" runat="server" Text="Teléfono Móvil:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelMovil" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px; height: 28px;">
                <asp:Label ID="Label14" runat="server" Text="Provincia:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left" rowspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlLocalidad" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="Label15" runat="server" Text="Localidad:" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="Label16" runat="server" Text="Barrio:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBarrio" runat="server" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                <asp:Label ID="lblFoto" runat="server" Text="Foto:" CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="uploadImagen" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 187px">
                &nbsp;</td>
            <td style="text-align: right">
                <asp:Button ID="Button1" runat="server" Text="Registrar" 
                    onclick="Button1_Click" CssClass="botones" />
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

