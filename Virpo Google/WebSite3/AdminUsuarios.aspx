<%@ Page Language="C#" MasterPageFile="~/VirpoAdmin.master" AutoEventWireup="true" CodeFile="AdminUsuarios.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="AdminHome.aspx" title="Home Administracion">Home</a></li>
            <li><a href="PermisosUsuarios.aspx" title="Permisos">Permisos</a></li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblOk" runat="server" Style="color: #009900" Text="La Transacción se realizó con exito"
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblMal" runat="server" Style="color: #CC3300" Text="La Transacción no se realizó"
                            Visible="False"></asp:Label>
                    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

