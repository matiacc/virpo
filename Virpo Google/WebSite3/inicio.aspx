<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="inicio.aspx.cs"
    Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center style="width: 222px; background-color: #333333">
        <titulosubventana>
                                . </titulosubventana>
    </center>
    <p style="text-align: center; width: 200px;">
        <br />
        <asp:Label ID="izq1" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 200px;">
        <br />
        <asp:Label ID="izq2" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 200px;">
        <br />
        <asp:Label ID="izq3" runat="server"></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <center style="width: 400px; background-color: #333333">
        <titulosubventana>
                                 Virpo News</titulosubventana>
    </center>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen1" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen2" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen3" runat="server"></asp:Label>
        <br />
    </p>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen4" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen5" runat="server"></asp:Label>
    </p>
    <p style="text-align: center; width: 380px;">
        <br />
        <asp:Label ID="cen6" runat="server"></asp:Label>
    </p>
    <p style="text-align: center">
        &nbsp;<asp:Panel ID="PanelRegistrarme" runat="server">
            <center>
                <h2>
                    &nbsp;Click
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#99CCFF" NavigateUrl="~/AltaMusico.aspx"> 
                    aquí
                    </asp:HyperLink>
                    &nbsp;para registrarte
                </h2>
            </center>
        </asp:Panel>
            <p style="text-align: center">
                &nbsp;<asp:Panel ID="Panel1" runat="server">
                    <center>
                        <h3>
                            &nbsp;Tu negocio tiene un lugar en Virpo,
                            <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#99CCFF" NavigateUrl="~/AltaPublicidad.aspx"> 
                            Publicitá
                            </asp:HyperLink>
                           
                        </h3>
                    </center>
                </asp:Panel>
                <p>
                    &nbsp; &nbsp;<p>
                    <li>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="nosotros.aspx" title="Que es Virpo">Que es Virpo?</a></li>
                </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <center style="width: 130px; background-color: #333333">
        <titulosubventana>
                                . </titulosubventana>
    </center>
    <p style="text-align: center">
        <br />
        <asp:Label ID="der1" runat="server"></asp:Label>
    </p>
    <p style="text-align: center">
        <br />
        <asp:Label ID="der2" runat="server"></asp:Label>
    </p>
    <p style="text-align: center">
        <br />
        <asp:Label ID="der3" runat="server"></asp:Label>
    </p>
</asp:Content>
