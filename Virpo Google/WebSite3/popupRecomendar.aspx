<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupRecomendar.aspx.cs" Inherits="popupRecomendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <script type="text/javascript" language="javascript">
    function mostrarGif(){
 document.getElementById('loading').style.display = '';
}
</script>
    <style type="text/css">

        .style3
        {
            height: 38px;
            background-color: #CCCCCC;
            text-align: center;
            font-size: large;
        }
        .style4
        {
            height: 38px;
            background-color: #CCCCCC;
        }
        .style5
        {
            width: 70px;
            height: 172px;
            background-color: #CCCCCC;
            text-align: center;
        }
        .style6
        {
            height: 172px;
            background-color: #CCCCCC;
        }
        .style7
        {
            width: 70px;
            height: 74px;
            background-color: #CCCCCC;
        }
        .style8
        {
            height: 74px;
            background-color: #CCCCCC;
        }
        .style2
        {
            width: 535px;
            background-color: #CCCCCC;
        }
        .style9
        {
            background-color: #CCCCCC;
            height: 46px;
        }
        .style10
        {
            font-family: Calibri;
            font-size: small;
            color: #333333;
            text-align: center;
            font-style: italic;
        }
        .style11
        {
            text-align: justify;
        }
        .style12
        {
            height: 38px;
            background-color: #CCCCCC;
            width: 359px;
            text-align: left;
        }
        .style13
        {
            height: 172px;
            background-color: #CCCCCC;
            width: 359px;
        }
        .style14
        {
            height: 74px;
            background-color: #CCCCCC;
            width: 359px;
        }
        .style15
        {
            background-color: #CCCCCC;
            width: 359px;
            height: 46px;
        }
        .style16
        {
            width: 70px;
            background-color: #CCCCCC;
            height: 46px;
        }
        .style17
        {
            height: 38px;
            background-color: #CCCCCC;
            text-align: center;
            font-size: large;
        }
        .style18
        {
            height: 15px;
            background-color: #CCCCCC;
            text-align: center;
            font-size: large;
            font-weight: 700;
        }
        .style19
        {
            height: 15px;
            background-color: #CCCCCC;
            width: 359px;
            text-align: left;
        }
        .style20
        {
            height: 15px;
            background-color: #CCCCCC;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="style2" align="center" >
        <tr>
            <td class="style17" colspan="3">
                <b>R</b><b style="font-size: large">ECOMENDAR</b></td>
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
            <td class="style12">
                <asp:TextBox ID="txtPara" runat="server" Width="370px" Height="21px" 
                    style="margin-bottom: 0px"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" 
                    style="font-size: large; font-family: Calibri; color: #333333" 
                    Text="Mensaje"></asp:Label>
            </td>
            <td class="style13">
                <asp:TextBox ID="txtMensaje" runat="server" Height="157px" Width="370px"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                </td>
            <td class="style14">
                <div class="style11">
                    <span class="style10">*</span><label for=""><span class="style10">Para realizar el envío a más de un 
                    destinatario (hasta 5), separá cada casilla de e-mail con punto y coma.<br />
                    </span><br class="style10" />
                    <span class="style10">Ej: nombre1@mail.com.ar;nombre2@mail.com.ar</span></label></div>
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style16">
                </td>
            <td style="text-align: right" class="style15"><img alt="" src="ImagenesSite/cargando.gif" id="loading" style="display: none; vertical-align:top;"/>&nbsp;&nbsp;
                <asp:Button ID="btEnviar" runat="server" onclick="btEnviar_Click" OnClientClick="mostrarGif();"
                    Text="Enviar" />
            </td>
            <td style="text-align: right" class="style9">
            </td>
        </tr>
        </table>
   
    
    </div>
    </form>
</body>
</html>
