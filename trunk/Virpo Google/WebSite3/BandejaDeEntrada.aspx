<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="BandejaDeEntrada.aspx.cs" Inherits="BandejaDeEntrada" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

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

    <table class="style1">
        <tr>
            <td>

                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>

            </td>
        </tr>
        <tr>
            <td>

            </td>
        </tr>
        <tr>
        <td>
        
<%--<head id="Head2" runat="server" />--%>
<head id="Head1" runat="server" />
        
                <cc1:TabContainer ID="TabContainer1" runat="server" style="Height: 100%;Width: 750px" >
                
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Bandas" TabIndex="0">
                
                    <HeaderTemplate>
                        Bandas
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                <asp:Label ID="lblInvitacionesBandas" runat="server"></asp:Label>   
                             
                    </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Grupos de Interés" TabIndex="1">
                    <HeaderTemplate>
                        Grupos de Interés
                    </HeaderTemplate>
                
                <ContentTemplate>
                Contenido de Tab panel 2 <br />

                
                    </ContentTemplate>
                </cc1:TabPanel>
                
                </cc1:TabContainer>
                </td>
                

        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

