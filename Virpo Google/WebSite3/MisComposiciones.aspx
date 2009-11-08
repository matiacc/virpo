<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="MisComposiciones.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Mis Composiciones"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" 
            Text="NO SE ENCONTRARON PISTAS Y/O CANCIONES REGISTRADAS POR USTED" 
            Visible="False"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="468px" onrowcommand="GridView1_RowCommand1">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="P" DataTextField="Ruta" 
                    ImageUrl="~/ImagenesSite/play.png" Text="Play" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Instrumento" HeaderText="Instrumento" 
                    SortExpression="Instrumento" />
                <asp:BoundField DataField="Ruta2" HeaderText="Ruta" SortExpression="Ruta" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:ButtonField ButtonType="Image" CommandName="E" DataTextField="Ruta" 
                    ImageUrl="~/ImagenesSite/delete.png" Text="Eliminar" />
                <asp:ButtonField ButtonType="Image" CommandName="C" 
                    ImageUrl="~/ImagenesSite/lupa3.png" Text="Consultar" />
            </Columns>
        </asp:GridView>
    </p>
    
    
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

