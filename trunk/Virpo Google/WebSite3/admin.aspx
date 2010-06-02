<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="admin.aspx.cs" Inherits="_Default" Title="Página sin título" %>




<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 93%">
        <tr>
            <td style="width: 275px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 275px">
            <center style="text-align: right">
                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" 
                     DestinationPageUrl="~/AdminHome.aspx" BorderPadding="4" Width="357px" 
                    BackColor="Silver" BorderColor="#000099" BorderStyle="Solid" BorderWidth="1px" 
                    CssClass="botones" Font-Size="Smaller" ForeColor="Black">
        </asp:Login></center>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 275px; text-align: center;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 275px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<p>
<%--        Se loguea y pasa a
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/AdminHome.aspx">AdminHome.aspx</asp:LinkButton>--%>
    </p>
</asp:Content>