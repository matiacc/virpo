<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupRecomendarWiki.aspx.cs" Inherits="popupRecomendarWiki" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript">
    function mostrarGif(){
 document.getElementById('loading').style.display = '';
}
</script>
    <style type="text/css">
        .style17
        {
            text-align: center;
        }
        .style3
        {
            text-align: center;
            width: 81px;
        }
        .style18
        {
            width: 81px;
        }
        .style19
        {
            width: 375px;
        }
        .style2
        {
            margin-left: 14px;
            background-color: #C0C0C0;
        }
        .style20
        {
            width: 78px;
        }
        .style10
        {
            font-style: italic;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
    <table class="style2" align="center" >
        <tr>
            <td class="style17" colspan="3">
                <b style="font-size: large; text-align: center;">RECOMENDAR</b></td>
        </tr>
        <tr>
            <td class="style18">
            </td>
            <td class="style19">
            </td>
            <td class="style20">
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" 
                    style="color: #333333; font-size: large; font-family: Calibri" 
                    Text="Para"></asp:Label>
            </td>
            <td class="style19">
                <asp:TextBox ID="txtPara" runat="server" Width="370px" Height="21px" 
                    style="margin-bottom: 0px"></asp:TextBox>
            </td>
            <td class="style20">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" 
                    style="font-size: large; font-family: Calibri; color: #333333" 
                    Text="Mensaje"></asp:Label>
            </td>
            <td class="style19">
                <asp:TextBox ID="txtMensaje" runat="server" Height="157px" Width="370px"></asp:TextBox>
            </td>
            <td class="style20">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style18">
                </td>
            <td class="style19">
                <div class="style11">
                    <span class="style10">*</span><label for=""><span class="style10">Para realizar el envío a más de un 
                    destinatario (hasta 5), separá cada casilla de e-mail con punto y coma.<br />
                    </span><br class="style10" />
                    <span class="style10">Ej: nombre1@mail.com.ar;nombre2@mail.com.ar</span></label></div>
                </td>
            <td class="style20">
                </td>
        </tr>
        <tr>
            <td class="style18">
                </td>
            <td style="text-align: right" class="style19"><img alt="" src="ImagenesSite/cargando.gif" id="loading" style="display: none; vertical-align:top;"/>&nbsp;&nbsp;
                <asp:Button ID="btEnviar" runat="server" onclick="btEnviar_Click" OnClientClick="mostrarGif();"
                    Text="Enviar" />
            </td>
            <td style="text-align: right" class="style20">
            </td>
        </tr>
        </table>
   
    
    </div>
    </form>
</body>
</html>
