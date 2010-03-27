<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   <center> <asp:Login ID="Login1" runat="server">
    </asp:Login></center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
        Se loguea y pasa a
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/AdminHome.aspx">AdminHome.aspx</asp:LinkButton>
    </p>
</asp:Content>

