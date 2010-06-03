<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Bandeja.aspx.cs" Inherits="Bandeja" Title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="menu8">
        <ul>
            <li><a href="Bandeja.aspx" title="Bandeja De Entrada">Bandeja De Entrada</a></li>
            <li><a href="ModificarPerfil.aspx" title="Modificar Perfil">Modificar Perfil</a></li>
            <li><a href="CambiarPassword.aspx" title="Cambiar Contraseña">Cambiar Contraseña</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center style="width: 529px; background-color: #333333">
                    <titulosubventana>
                        Bandeja De Entrada</titulosubventana>
                </center>

<script language="JavaScript" type="text/javascript">

var pagina="ConfirmarInvitacion.aspx?idI="
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
        
<%--<head id="Head1" runat="server" />--%>
<head id="Head1" runat="server" />

               <cc1:TabContainer ID="TabContainer1" runat="server" 
                    style="Height: 100%;Width: 523px" ActiveTabIndex="0" >
             <%--   
             <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__myTab" >
                <style type="text/css" Height="100%";Width="750px">
   
    .ajax__myTab .ajax__tab_header {
        font-family: verdana,tahoma,helvetica;
        font-size: 11px;
        border-bottom: solid 1px #999999
     }
    
    .ajax__myTab .ajax__tab_outer {
        padding-right: 4px;
        height: 21px;
        background-color: #C0C0C0;
        margin-right: 2px;
        border-right: solid 1px #666666;
        border-top: solid 1px #aaaaaa
     }
    
    .ajax__myTab .ajax__tab_inner {
        padding-left: 3px;
        background-color: #C0C0C0;
     }
    
    .ajax__myTab .ajax__tab_tab {
        height: 13px;
        padding: 4px;
        margin: 0;
     }
    
    .ajax__myTab .ajax__tab_hover .ajax__tab_outer {
        background-color: #cccccc
     }
    
    .ajax__myTab .ajax__tab_hover .ajax__tab_inner {
        background-color: #cccccc
     }
    
    .ajax__myTab .ajax__tab_hover .ajax__tab_tab {}
   
    .ajax__myTab .ajax__tab_active .ajax__tab_outer {
        background-color: #fff;
        border-left: solid 1px #999999;
     }
    
    .ajax__myTab .ajax__tab_active .ajax__tab_inner {
        background-color:#fff;
     }
    
    .ajax__myTab .ajax__tab_active .ajax__tab_tab {}
   
    .ajax__myTab .ajax__tab_body {
        font-family: verdana,tahoma,helvetica;
        font-size: 10pt;
        border: 1px solid #999999;
        border-top: 0;
        padding: 8px;
        background-color: #ffffff;
      }
     
</style>--%>
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Bandas" TabIndex="0" >
                
                    <HeaderTemplate>
                        Bandas
                    </HeaderTemplate>
                
                <ContentTemplate>
                
                <asp:Label ID="lblInvitacionesBandas" runat="server"></asp:Label>   
                             
                    </ContentTemplate>
                </cc1:TabPanel>
                
                
      <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Proyectos" TabIndex="1" >
                    <HeaderTemplate>
                        Proyectos
                    </HeaderTemplate>
                
                <ContentTemplate>
                        <asp:Button ID="btnBorrarProyectosLeidos" runat="server" Text="Borrar Leídos" onclick="btnBorrarProyectosLeidos_Click" />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                             <ContentTemplate>
                             <asp:GridView ID="gvProyectos" runat="server" CssClass="GridViewStyle" 
                            AutoGenerateColumns="False" CellPadding="4" 
    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="gvProyectos_SelectedIndexChanged" 
                    AllowPaging="True" 
                    onpageindexchanging="gvProyectos_PageIndexChanging" 
                    DataKeyNames="idBandeja" >
                            <RowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idBandeja" 
            HeaderText="idBandeja" Visible="False" />
                                <asp:BoundField DataField="interesado" 
            HeaderText="Colaborador" >
                                    <HeaderStyle Width="100px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" 
            HeaderText="Incorporación" >
                                    <HeaderStyle Width="150px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="idProyecto" HeaderText="" >
                                </asp:BoundField>
                                <asp:BoundField DataField="proyecto" HeaderText="Nombre del Proyecto" >
                                    <HeaderStyle Width="400px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="avisoMotivo" HeaderText="Motivo" />--%>
                                <asp:BoundField DataField="leido" HeaderText="Leído" />
                                <asp:CommandField ButtonType="Image" HeaderText="Ver" 
            SelectImageUrl="~/ImagenesSite/lupa3.png" SelectText="" 
            ShowSelectButton="True" >
                                    <HeaderStyle Width="50px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="#660066" />
                            <PagerStyle ForeColor="#660066" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
        ForeColor="#333333" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" 
        ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                             </ContentTemplate>
                    </asp:UpdatePanel>  
                    <asp:Label ID="lblProyectos" runat="server"></asp:Label>
                 </ContentTemplate>
      </cc1:TabPanel>

                
                 <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Bandas" TabIndex="2" >
                
                    <HeaderTemplate>
                        Grupos
                    </HeaderTemplate>
                
                <ContentTemplate>
                <asp:Button ID="btnBorrarGruposLeidos" runat="server" Text="Borrar Leídos" 
                            onclick="btnBorrarGruposLeidos_Click" />
                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvGrupos" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" onselectedindexchanged="gvGrupos_SelectedIndexChanged" AllowPaging="True" 
                        onpageindexchanging="gvGrupos_PageIndexChanging" DataKeyNames="idBandeja" >
                            <RowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idBandeja" HeaderText="idBandeja" Visible="False" />
                                <asp:BoundField DataField="nvoIntegrante" HeaderText="Nuevo Integrante" >
                                    <HeaderStyle Width="100px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha Adhesión" >
                                    <HeaderStyle Width="150px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="idGrupo" HeaderText="" >
                                </asp:BoundField>
                                <asp:BoundField DataField="grupo" HeaderText="Grupo de Interés" >
                                    <HeaderStyle Width="400px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="leido" HeaderText="Leído" />
                                <asp:CommandField ButtonType="Image" HeaderText="Ver"  SelectImageUrl="~/ImagenesSite/lupa3.png" SelectText="" 
                                ShowSelectButton="True" >
                                    <HeaderStyle Width="50px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="#660066" />
                            <PagerStyle ForeColor="#660066" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>  
                        
                             <asp:Label ID="lblGrupo" runat="server"></asp:Label>
                    </ContentTemplate>
                </cc1:TabPanel>
                
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Clasificados" TabIndex="3" >
                    <HeaderTemplate>
                        Clasificados
                    </HeaderTemplate>
                
                <ContentTemplate>
                        <asp:Button ID="btnBorrarAvisosLeidos" runat="server" Text="Borrar Leídos" onclick="btnBorrarAvisosLeidos_Click" />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvAvisosClasificados" runat="server" CssClass="GridViewStyle" 
                            AutoGenerateColumns="False" CellPadding="4" 
    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="gvAvisosClasificados_SelectedIndexChanged" 
                    AllowPaging="True" 
                    onpageindexchanging="gvAvisosClasificados_PageIndexChanging" 
                    DataKeyNames="idBandeja" >
                            <RowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idBandeja" 
            HeaderText="idBandeja" Visible="False" />
                                <asp:BoundField DataField="interesado" 
            HeaderText="De" >
                                    <HeaderStyle Width="100px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" 
            HeaderText="Fecha Consulta" >
                                    <HeaderStyle Width="150px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="idAviso" HeaderText="" >
                                </asp:BoundField>
                                <asp:BoundField DataField="aviso" HeaderText="Titulo del Aviso Clasificado" >
                                    <HeaderStyle Width="400px" HorizontalAlign="Left"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="avisoMotivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="leido" HeaderText="Leído" />
                                <asp:CommandField ButtonType="Image" HeaderText="Ver" 
            SelectImageUrl="~/ImagenesSite/lupa3.png" SelectText="" 
            ShowSelectButton="True" >
                                    <HeaderStyle Width="50px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="#660066" />
                            <PagerStyle ForeColor="#660066" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
        ForeColor="#333333" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" 
        ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>  
                     <asp:Label ID="lblAvisosClasificados" runat="server"></asp:Label>
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
               
            </td>
        </tr>
        <tr>
            <td>                    &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>

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
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

