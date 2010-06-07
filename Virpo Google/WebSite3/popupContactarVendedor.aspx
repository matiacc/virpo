<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupContactarVendedor.aspx.cs" Inherits="popupContactarVendedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contactar con el Vendedor</title>
<script type="text/javascript" language="javascript">
    function mostrarGif(){
 document.getElementById('loading').style.display = '';
}
</script>
    <style type="text/css">
        .style1
        {
            width: 488px;
            height: 352px;
            background-color: #CCCCCC;
        }
        .style2
        {
            width: 50px;
        }
        .style3
        {
            width: 50px;
            height: 38px;
            background-color: #C0C0C0;
        }
        .style4
        {
            height: 38px;
            background-color: #C0C0C0;
        }
        .style5
        {
            width: 50px;
            height: 172px;
            background-color: #C0C0C0;
        }
        .style6
        {
            height: 172px;
            background-color: #C0C0C0;
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
                    style="color: #333333; font-size: large; font-family: Calibri" 
                    Text="Asunto:"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtAsunto" runat="server" Width="408px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" 
                    style="font-size: large; font-family: Calibri; color: #333333" 
                    Text="Mensaje"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtMensaje" runat="server" Height="157px" Width="408px" 
                    TextMode="MultiLine"></asp:TextBox>
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
            <td style="text-align: right"><img alt="" id="loading" src="ImagenesSite/loading.gif" style="display:none; vertical-align:top;" />&nbsp;&nbsp;
                <asp:Button ID="btEnviar" runat="server" onclick="btEnviar_Click" OnClientClick="mostrarGif();"
                    Text="Enviar" />
            </td>
        </tr>
        </table>
   
    
    </div>
    </form>
  
</body>
</html>
