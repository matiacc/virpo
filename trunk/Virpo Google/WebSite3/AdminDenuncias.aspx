<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="AdminDenuncias.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administración">Home</a></li>
            <li><a href="AdminDenuncias.aspx" title="Denuncias">Denuncias</a></li>
            <li><a href="AdminEventos.aspx" title="Eventos">Eventos</a></li>
            <li><a href="AdminProyectos.aspx" title="Proyectos">Proyectos</a></li>
           
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<script language="JavaScript" type="text/javascript">

var pagina="ConfirmarDenuncia.aspx?idD="

function baja(idDen,baj) 
{
location.href=pagina+idDen+"&baj="+baj
}
function ignorar(idDen,baj) 
{
location.href=pagina+idDen+"&baj="+baj
}
 
</script>

<center style="width: 574px; background-color: #333333"><tituloSubVentana>
                  <asp:Label ID="lblTituloDenuncias" runat="server" Text="Denuncias"></asp:Label></tituloSubVentana></center>
                  

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
        
<%--<head id="Head1" runat="server" />--%>
<head id="Head1" runat="server" />

               <cc1:TabContainer ID="TabContainer1" runat="server" 
                    style="Height: 100%;Width: 567px" ActiveTabIndex="0" >

                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Todas" TabIndex="0" >
                
                    <HeaderTemplate>
                        Todas
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblListadoDenuncias" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
<%--                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Composiciones" TabIndex="1" >
                
                    <HeaderTemplate>
                        Composiciones
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:507px;">
                          <asp:Label ID="lblDenunciasComposiciones" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>--%>
                
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Proyectos" TabIndex="2" >
                
                    <HeaderTemplate>
                        Proyectos
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasProyectos" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="WikiMusic" TabIndex="3" >
                
                    <HeaderTemplate>
                        WikiMusic
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasWikiMusic" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Clasificados" TabIndex="4" >
                
                    <HeaderTemplate>
                        Clasificados
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasClasificados" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Bandas" TabIndex="5" >
                
                    <HeaderTemplate>
                        Bandas
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasBandas" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Grupos" TabIndex="6" >
                
                    <HeaderTemplate>
                        Grupos
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasGrupos" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="Eventos" TabIndex="7" >
                
                    <HeaderTemplate>
                        Eventos
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasEventos" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="Usuarios" TabIndex="8" >
                
                    <HeaderTemplate>
                        Usuarios
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                    <table class="tabla" border="1" style="width:550px;">
                          <asp:Label ID="lblDenunciasUsuarios" runat="server"></asp:Label>
                    </table>   
                             
                </ContentTemplate>
                </cc1:TabPanel>
                
               </cc1:TabContainer>
          </td>
        </tr>
</table>
                  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

