<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="PublicidadModificar.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    CssClass="estiloLabel" Width="80px"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:TextBox ID="txtEntidad" runat="server" Width="227px"></asp:TextBox>
            </td>
            <td rowspan="12">
                <asp:ImageButton ID="imgPubli" runat="server" Height="520px" Width="195px" 
                    target='_blank'/>
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
                    CssClass="estiloLabel" Width="80px"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:TextBox ID="txtNombreContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblTel" runat="server" Text="Teléfono:" 
                    CssClass="estiloLabel" Width="70px"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:TextBox ID="txtTelContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblMail" runat="server" Text="E–Mail:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:TextBox ID="txtMailContacto" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="Label5" runat="server" Text="Meses:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:Label ID="lblMeses" runat="server" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="Label1" runat="server" Text="Vigencia desde:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="text-align: left; width: 266px;">
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
                <asp:Label ID="lblFrec" runat="server" Text="Impresiones:" 
                    CssClass="estiloLabel" Font-Size="10pt"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:DropDownList ID="ddlFrecuencia" runat="server" Height="22px" Width="55px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 182px;">
                <asp:Label ID="lblUrl" runat="server" Text="Url:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:TextBox ID="txtUrl" runat="server" Width="227px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 182px;">
                <asp:Label ID="lblImagen" runat="server" Text="Imagen:" 
                    CssClass="estiloLabel"></asp:Label>
            </td>
            <td style="width: 266px">
                <asp:FileUpload ID="upPublicidad" runat="server" Width="220px" Height="26px"/>
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: left; width: 182px;">
                <asp:Label ID="lblConsulta" runat="server" Text="Consulta:" 
                    CssClass="estiloLabel"></asp:Label>
                </td>
            <td style="height: 26px; width: 266px;">
                <asp:Button ID="btnPrevisualizar" runat="server" onclick="btnCargar_Click" 
                    Text="Cargar" Width="229px" CssClass="botones" />
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                &nbsp;</td>
            <td style="width: 266px">
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
            <td style="text-align: right; width: 266px;">
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
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        Está seguro de Rechazar la Solicitud?
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button1" runat="server" Text="SI" OnClick="Button1_Click" CssClass="botones" />
                        <asp:Button ID="Button4" runat="server" Text="NO" OnClick="Button4_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button2"
                    PopupControlID="Panel1" OkControlID="Button3">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button6" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button7" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel2" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Solicitud fue Rechazada.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button5" runat="server" Text="OK" OnClick="Button5_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel2_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button6"
                    PopupControlID="Panel2" OkControlID="Button7">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button9" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button10" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel3" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Publicidad fue dada de Alta con éxito.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button8" runat="server" Text="OK" OnClick="Button8_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel3_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button9"
                    PopupControlID="Panel3" OkControlID="Button10">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button12" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button13" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel4" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Publicidad fue Modificada con éxito.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button11" runat="server" Text="OK" OnClick="Button8_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel4_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button12"
                    PopupControlID="Panel4" OkControlID="Button13">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button15" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button16" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel5" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Publicidad fue Renovada con éxito.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button14" runat="server" Text="OK" OnClick="Button8_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel5_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button15"
                    PopupControlID="Panel5" OkControlID="Button16">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button19" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button20" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel6" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        Está seguro de Eliminar la Publicidad?
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button17" runat="server" Text="SI" OnClick="Button17_Click" CssClass="botones" />
                        <asp:Button ID="Button18" runat="server" Text="NO" OnClick="Button18_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel6_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button19"
                    PopupControlID="Panel6" OkControlID="Button20">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button22" runat="server" Text="False" Style="display: none;" />
                <asp:Button ID="Button23" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel7" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La Publicidad fue Eliminada.
                    </center>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="Button21" runat="server" Text="OK" OnClick="Button21_Click" CssClass="botones" />
                    </center>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="Panel7_ModalPopupExtender" BackgroundCssClass="modalBackground"
                    runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Button22"
                    PopupControlID="Panel7" OkControlID="Button23">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
