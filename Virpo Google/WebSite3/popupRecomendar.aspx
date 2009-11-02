<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupRecomendar.aspx.cs" Inherits="popupRecomendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">

        .style1
        {
            width: 488px;
            height: 352px;
            background-color: #333333;
        }
        .style3
        {
            width: 50px;
            height: 38px;
            background-color: #CCCCCC;
        }
        .style4
        {
            height: 38px;
            background-color: #CCCCCC;
        }
        .style5
        {
            width: 50px;
            height: 172px;
            background-color: #CCCCCC;
        }
        .style6
        {
            height: 172px;
            background-color: #CCCCCC;
        }
        .style7
        {
            width: 50px;
            height: 132px;
            background-color: #CCCCCC;
        }
        .style8
        {
            height: 132px;
            background-color: #CCCCCC;
        }
        .style2
        {
            width: 50px;
            background-color: #CCCCCC;
        }
        .style9
        {
            background-color: #CCCCCC;
        }
        .style10
        {
            font-family: Calibri;
            font-size: small;
            color: #333333;
        }
        .style11
        {
            text-align: justify;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="style2" align="center" >
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" 
                    style="color: #333333; font-size: large; font-family: Calibri" 
                    Text="Para:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtPara" runat="server" Width="408px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" 
                    style="font-size: large; font-family: Calibri; color: #333333" 
                    Text="Mensaje"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtMensaje" runat="server" Height="157px" Width="408px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                </td>
            <td class="style8">
                <div class="style11">
                    <span class="style10">*</span><label for=""><span class="style10">Para realizar el envío a más de un 
                    destinatario (hasta 5), separá cada casilla de e-mail con punto y coma.<br />
                    </span><br class="style10" />
                    <span class="style10">Ej: nombre1@mail.com.ar;nombre2@mail.com.ar</span></label></div>
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td style="text-align: right" class="style9"><img alt="" src="ImagenesSite/cargando.gif" id="loading" style="display: none;"/>&nbsp;&nbsp;
                <asp:Button ID="btEnviar" runat="server" onclick="btEnviar_Click" OnClientClick="mostrarGif()"
                    Text="Enviar" />
            </td>
        </tr>
        </table>
   
    
    </div>
    </form>
</body>
</html>
