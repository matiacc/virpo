<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="PerfilPublico.aspx.cs" Inherits="PerfilPublico" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div id="menu8">
        <ul>
            <li><a href="Perfil.aspx" title="Mi Perfil">Mi Perfil</a></li>
            
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="tabla" style="width: 130%">
    <tr>
        <td colspan="4">
            <center style="width: 529px; background-color: #333333">
                    <tituloSubVentana>
                    Perfil De
            <asp:Label ID="lblLogin" runat="server"></asp:Label>
                    </tituloSubVentana></center>
        </td>
    </tr>
    <tr>
        <td rowspan="9">
            <asp:Image ID="ImgPerfil" runat="server" Height="300px" Width="300px" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblApellido" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label13" runat="server" Text="Instrumento:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblInstrumento" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblFecNac" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblSexo" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbleMail" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Localidad:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Provincia:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblProvincia" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label12" runat="server" Text="País:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblPais" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
    <table style="width: 529px">
    <tr align="right">
       <td>
       </td>
     </tr>
      <tr>
        <td align="right">
           <asp:Button ID="btnDenunciar" runat="server" CssClass="botones" Text="Denunciar"
                    Width="95px" onclick="btnDenunciar_Click" />
                
        </td>
      </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

