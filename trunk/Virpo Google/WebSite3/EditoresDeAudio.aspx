<%@ Page Title="" Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="EditoresDeAudio.aspx.cs" Inherits="HerramientasMusicales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoProyecto.aspx" title="Nuevo Proyecto">Nuevo Proyecto</a></li>
            <li><a href="MisProyectos.aspx?" title="Mis Proyectos">Mis Proyectos</a></li>
            <li><a href="MisComposiciones.aspx" title="Mis Composiciones">Mis Composiciones</a></li>
            <li><a href="MisComposiciones.aspx?fin=1" title="Canciones Finalizadas">Canciones Finalizadas</a></li>
            <li><a href="EditoresDeAudio.aspx" title="Editores de Audio">Editores de Audio</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center style="width: 529px; background-color: #333333">
                    <titulosubventana><div id="prueba" runat="server">
                    Editores De Audio
                    </div></titulosubventana>
                </center>
                <table class="tabla" style="width: 529px">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: justify; font-size: medium">
                                    La edición de los audios disponibles es nuestro portal Virpo se realiza de 
                                    manera local en la computadora de cada uno de los usuarios. Para realizar esta 
                                    tarea es necesario contar con un editor de audio, el cual sirve para grabar y 
                                    mezclar audios. Virpo recomienda el uso de software libre como los que mostramos 
                                    a continuación:</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: justify">
                                    Audacity es un programa libre y de código abierto para grabar y editar sonido. 
                                    Está disponible para Mac OS X, Microsoft Windows, GNU/Linux y otros sistemas 
                                    operativos. Para bajar el programa hacer click sobre el siguiente logo:</td>
                                <td style="text-align: justify">
                                    &nbsp;</td>
                                <td style="text-align: justify">
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl="~/ImagenesSite/Audacity-logo-r_50pct.jpg" 
                                        PostBackUrl="http://audacity.sourceforge.net/" Width="179px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: justify">
                                    Wavosaur es un editor de sonido gratis, editor de audio, wav editor para la 
                                    edición, procesamiento y grabación de sonidos, wav y mp3. Wavosaur tiene todas 
                                    las características para editar audio (cortar, copiar, pegar, etc) producir 
                                    música bucles, analizar, registro, la conversión por lotes.<br />
                                    Para bajar el programa hacer click sobre el siguiente logo:</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        ImageUrl="~/ImagenesSite/wavosaur_logo.jpg" Width="179px" 
                                        PostBackUrl="http://www.wavosaur.com/" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

