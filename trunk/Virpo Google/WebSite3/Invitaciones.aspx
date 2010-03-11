<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Invitaciones.aspx.cs" Inherits="Invitaciones" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server" >
    
  <script language="JavaScript" type="text/javascript">

var pagina="http://localhost:3734/WebSite3/ConfirmarInvitacion.aspx?idI="
function aceptar(idinv,idu,idb,ac) 
{
location.href=pagina+idinv+"&idU="+idu+"&idB="+idb+"&ace="+ac
}
function rechazar(idinv,ac) 
{
location.href=pagina+idinv+"&ace="+ac
}
 
</script>

    <table style="width: 100%">
        <tr>
            <td style="height: 35px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; color: #FF0000;" align="center">

                <asp:Label ID="lblInvitaciones" runat="server"></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

