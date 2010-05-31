<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="AdminHome.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu8">
        <ul>
            <li><a href="AdminUsuarios.aspx" title="Usuarios">Usuarios</a></li>
            <li><a href="AdminDenuncias.aspx" title="Denuncias">Denuncias</a></li>
            <li><a href="AdminNoticias.aspx" title="Noticias">Noticias</a></li>   
            <li><a href="AdminPublicidad.aspx" title="Publicidad">Publicidad</a></li>         
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   
   <table class="style1" style="width: 127%">
        <tr>
            <td style="text-align: right">
                <table class="style1" style="width: 98%">
                    <tr>
                        <td>
                <asp:Image ID="Image1" runat="server" Height="122px" 
                    ImageUrl="~/ImagenesSite/administrator2.png" Width="122px" />
                        </td>
                        <td style="text-align: center">
                            <asp:Image ID="Image2" runat="server" Height="122px" 
                                ImageUrl="~/ImagenesSite/administrator3.png" Width="122px" />
                        </td>
                        <td style="text-align: center">
                            <asp:Image ID="Image3" runat="server" Height="122px" 
                                ImageUrl="~/ImagenesSite/Administrator4.png" Width="122px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
