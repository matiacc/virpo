﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupContactarVendedor.aspx.cs" Inherits="popupContactarVendedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contactar con el Vendedor</title>
    <style type="text/css">
        .style1
        {
            width: 488px;
            height: 352px;
            background-color: #333333;
        }
        .style2
        {
            width: 50px;
        }
        .style3
        {
            width: 50px;
            height: 38px;
        }
        .style4
        {
            height: 38px;
        }
        .style5
        {
            width: 50px;
            height: 172px;
        }
        .style6
        {
            height: 172px;
        }
        .style7
        {
            width: 50px;
            height: 132px;
        }
        .style8
        {
            height: 132px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
    <table class="style1" align="center" >
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" 
                    style="color: #FFFFFF; font-size: large; font-family: Calibri" Text="Asunto:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtAsunto" runat="server" Width="408px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" 
                    style="font-size: large; font-family: Calibri; color: #FFFFFF" Text="Mensaje"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtMensaje" runat="server" Height="157px" Width="408px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td style="text-align: right"><img alt="" src="ImagenesSite/cargando.gif" id="loading" style="display:none"/>&nbsp;&nbsp;
                <asp:Button ID="btEnviar" runat="server" onclick="btEnviar_Click" OnClientClick="mostrarGif()"
                    Text="Enviar" />
            </td>
        </tr>
        </table>
   
    
    </div>
    </form>
  
</body>
</html>
