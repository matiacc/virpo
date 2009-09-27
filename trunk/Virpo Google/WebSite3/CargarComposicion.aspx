<%@ Page Title="" Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="CargarComposicion.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1" style="height: 226px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <tr>
            <td style="text-align: center; " colspan="2">
                <asp:Label ID="lblSubir" runat="server" style="text-align: right" Text="Subir"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 130px">
                &nbsp;</td>
            <td style="width: 233px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left; height: 30px" colspan="2">
                <asp:Label ID="lblTipoComp" runat="server" 
                    Text="Seleccion el tipo de composición"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="rbtnPista" runat="server" GroupName="a" Text="Pista" 
                    oncheckedchanged="rbtnPista_CheckedChanged" />
                <asp:RadioButton ID="rbtnNoTerm" runat="server" GroupName="a" 
                    Text="Canción no terminada" oncheckedchanged="rbtnNoTerm_CheckedChanged" />
                <asp:RadioButton ID="rbtnCanción" runat="server" GroupName="a" Text="Canción" 
                    oncheckedchanged="rbtnCanción_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td style="width: 130px">
                &nbsp;</td>
            <td style="width: 233px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="width: 233px">
                <asp:TextBox ID="txtNombre" runat="server" style="margin-left: 0px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 22px">
            </td>
            <td style="width: 233px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label1" runat="server" Text="Tempo:"></asp:Label>
            </td>
            <td style="width: 233px; height: 23px">
                <asp:TextBox ID="txtTempo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label7" runat="server" Text="Tonalidad"></asp:Label>
            </td>
            <td style="width: 233px; height: 23px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTonalidad" runat="server" 
    Height="16px" Width="127px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlTonalidad_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label3" runat="server" Text="Género:"></asp:Label>
            </td>
            <td style="width: 233px; height: 23px">
                <asp:ListBox ID="lbxGenero" runat="server" Width="144px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 15px">
                </td>
            <td style="width: 233px; height: 15px">
                </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label8" runat="server" Text="Tipo Instrumento:"></asp:Label>
            </td>
            <td style="width: 233px; " rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTipoInstru" runat="server" Height="19px" 
                    
    onselectedindexchanged="ddlTipoInstru_SelectedIndexChanged" Width="138px" 
                    AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlInstrumento" runat="server" AutoPostBack="True" 
                            Height="16px" Width="139px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 42px">
                </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label4" runat="server" Text="Instrumento:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label5" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td style="width: 233px; height: 23px">
                <asp:ListBox ID="lbxDescripcion" runat="server" Width="164px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                <asp:Label ID="Label6" runat="server" Text="Buscar Archivo"></asp:Label>
            </td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px" colspan="2">
                        <asp:FileUpload ID="uploadAudio" runat="server"/>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                        <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                    Text="Guardar" Width="110px" />
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 23px">
                &nbsp;</td>
            <td style="width: 233px; height: 23px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

