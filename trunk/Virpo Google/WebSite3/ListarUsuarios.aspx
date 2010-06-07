<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="ListarUsuarios.aspx.cs"
    Inherits="ListarUsuarios" Title="Página sin título" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="NuevaBanda.aspx" title="Nueva Banda">Nueva Banda</a></li>
            <li><a href="MisBandas.aspx" title="Mis Bandas">Mis Bandas</a></li>
            <li><a href="ListarBandas.aspx" title="Listar Bandas">Listar Bandas</a></li>
        </ul>
    </div>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Button2_onclick() {

        }

// ]]>
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" runat="server" id="tdTitulo">
                <center style="width: 522px; background-color: #333333">
                    <titulosubventana>Invitar Integrantes</titulosubventana>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 263px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    GridLines="None" OnRowCommand="GridView1_RowCommand" Width="519px" AllowPaging="True"
                    OnSorting="GridView1_Sorting">
                    <Columns>
                        <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" />
                        <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" NullImageUrl="~/ImagenesSite/user_no_avatar.gif">
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle />
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Mensaje:" CssClass="estiloLabel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtMensaje" runat="server" Height="77px" TextMode="MultiLine" Width="518px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnVolver" runat="server" CssClass="botones" OnClick="btnVolver_Click"
                    Text="Volver" />
            </td>
            <td style="text-align: right">
                <img alt="" id="loading" runat="server" class="imagenLoading" src="ImagenesSite/loading.gif"
                    style="display: none; vertical-align: top;" />&nbsp;
                <asp:Button ID="btEnviarInvitacion" runat="server" OnClick="btEnviarInvitacion_Click"
                    Text="Enviar Invitaciones" CssClass="botones" Width="156px" />
            </td>
        </tr>
    </table>
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
                <asp:Button ID="Button3" runat="server" Text="False2" Style="display: none;" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none;" CssClass="modalPopup">
                    <center>
                        La invitación fue enviada con éxito.
                        <br />
                        Desea enviar otra?</center>
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
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
