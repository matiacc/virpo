<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="AdminNoticias.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="NoticiaNueva.aspx" title="Nueva Noticia">Nueva Noticia</a></li>
            <li><a href="NoticiasBajas.aspx" title="Bajas">Modificar & Bajas</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <center style="width: 530px; background-color: #333333">
                    <titulosubventana>
                        Administrar Noticias</titulosubventana>
                </center>
     <table class="style1" style="width: 132%">
         <tr>
             <td style="text-align: center">
        <asp:Label ID="lblOk" runat="server" ForeColor="#009900" 
            Text="Se Publicó la Noticia" Visible="False"></asp:Label>
        <asp:Label ID="lblMal" runat="server" ForeColor="#CC0000" 
            Text="No Se Publicó la Noticia" Visible="False"></asp:Label>
             </td>
         </tr>
         <tr>
             <td style="text-align: center">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="text-align: center">
                 <asp:Image ID="Image1" runat="server" Height="408px" 
                     ImageUrl="~/ImagenesSite/noticias.png" Width="321px" />
             </td>
         </tr>
     </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
