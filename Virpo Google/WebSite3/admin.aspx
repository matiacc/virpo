<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true"
    CodeFile="admin.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <center>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" DestinationPageUrl="~/AdminHome.aspx">
        </asp:Login>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <p>
<%--        Se loguea y pasa a
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/AdminHome.aspx">AdminHome.aspx</asp:LinkButton>--%>
    </p>
</asp:Content>
