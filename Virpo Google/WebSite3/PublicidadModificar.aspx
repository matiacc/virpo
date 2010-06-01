<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="PublicidadModificar.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Vuelve al Home Administracion">Home</a></li>
            <li><a href="PublicidadSolicitudes.aspx" title="Pedidos de Publicidad">Solicitudes</a></li>
            <li><a href="PublicidadBajas.aspx" title="Publicidades Vigentes">Bajas &amp; Modificar</a></li>
            <li><a href="PublicidadRenovacion.aspx" title="Publicidades Vencidas">Renovacion</a></li>
            <li><a href="PublicidadEjecutarBajas.aspx" title="Publicidades a Eliminar">Ejecutar 
                Bajas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" />
    <contenttemplate>
    <table class="style1" style="height: 459px; width: 100%">
        <tr>
            <td colspan="3">
                 <center style="width: 529px; background-color: #333333">
                     <titulosubventana>
                        &nbsp;Publicidad</titulosubventana>
                </center></td>
        </tr>
        <tr>
            <td style="height: 20px; text-align: center;" colspan="3">
                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" 
                    CssClass="estiloLabel" Width="110px"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEntidad" runat="server" Width="227px"></asp:TextBox>
            </td>
            <td rowspan="11">
                <asp:ImageButton ID="imgPubli" runat="server" Height="385px" Width="145px" />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblContacto" runat="server" Text="Nombre:" 
                    CssClass="estiloLabel" Width="110px"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblTel" runat="server" Text="Telefono:" 
                    CssClass="estiloLabel" Width="120px"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblMail" runat="server" Text="Mail:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMailContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="Label5" runat="server" Text="Meses:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMeses" runat="server" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="Label1" runat="server" Text="Vigencia desde:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtInicio" runat="server" Height="18px" Width="68px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text=" Hasta " CssClass="estiloLabel"></asp:Label>
                <asp:TextBox ID="txtFin" runat="server" Height="18px" Width="68px"></asp:TextBox>
                &nbsp;<br />
                <asp:Label ID="lblAlertaFecha" runat="server" ForeColor="#CC0000" 
                    Text="Debe cambiar la fecha fin" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblFrec" runat="server" Text="Frecuencia de Aparicion:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFrecuencia" runat="server" Height="22px" Width="43px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 182px;">
                <asp:Label ID="lblImagen" runat="server" Text="Imagen:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="upPublicidad" runat="server" Width="256px" Height="26px"/>
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: left; width: 182px;">
                <asp:Label ID="lblConsulta" runat="server" Text="Consulta:" 
                    CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="height: 26px;">
                <asp:Button ID="btnPrevisualizar" runat="server" onclick="btnCargar_Click" 
                    Text="Cargar" Width="229px" CssClass="botones" />
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtConsulta" runat="server" Height="111px" 
                    TextMode="MultiLine" Width="227px"></asp:TextBox>
                <br />
                <asp:Label ID="lblAlertaObservacion" runat="server" ForeColor="#CC0000" 
                    Text="Debe ingresar una observación" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                &nbsp;</td>
            <td style="text-align: right; ">
                <asp:Button ID="btnBaja" runat="server" CssClass="botones" 
                    onclick="btnBaja_Click" Text="Baja" Visible="False" />
                <asp:Button ID="btnAlta" runat="server" CssClass="botones" 
                    onclick="btnAlta_Click" Text="Alta" />
                <asp:Button ID="btnVolver" runat="server" CssClass="botones" 
                    onclick="btnVolver_Click" Text="Volver" />
            </td>
        </tr>
        </table>
        
       </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
