<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="NuevaComposicion.aspx.cs" Inherits="NuevaComposicion" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="Pista" 
                    GroupName="Tipo" Checked="True" />&nbsp;
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Cancion No Terminada" 
                    GroupName="Tipo" />&nbsp;
                <asp:RadioButton ID="RadioButton3" runat="server" Text="Cancion Finalizada" />
            </td>
        </tr>
        <tr>
            <td>
                Nombre
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Tempo</td>
            <td>
                <asp:TextBox ID="txtTempo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Tonalidad</td>
            <td>
                <asp:DropDownList ID="ddlTonalidad" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Genero</td>
            <td>
                <asp:TextBox ID="txtGenero" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Tipo Instrumento</td>
            <td rowspan="2">
                
                        <asp:DropDownList ID="ddlTipo" runat="server" 
                            onselectedindexchanged="ddlTipo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br>
                       
                        <asp:DropDownList ID="ddlInstrumento" runat="server">
                        </asp:DropDownList>
                        <br></br>
                        <br></br>
                        </br>
                    
                                </td>
        </tr>
        <tr>
            <td>
                Instrumento</td>
        </tr>
        <tr>
            <td>
                Descripcion</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Archivo de Audio</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btGuardar" runat="server" onclick="btGuardar_Click" 
                    Text="Aceptar" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

