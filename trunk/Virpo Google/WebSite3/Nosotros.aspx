<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="Nosotros.aspx.cs" Inherits="_Default" Title="P�gina sin t�tulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  
  
     <div id="body">
      <div id="body-inner">
        <div id="body-left">
          <div id="topic-pic">  
              <asp:Image ID="Image1" runat="server" Height="182px" 
                  ImageUrl="~/images/pic_1.jpg" Width="261px" />
          
          </div>
          
              <asp:Panel ID="PanelRegistrarme" runat="server">
              
          <center><h2>
              
              Click 
              <asp:HyperLink ID="HyperLink1" runat="server" 
                  ForeColor="#99CCFF" NavigateUrl="~/AltaMusico.aspx">   aqu�  </asp:HyperLink>
              &nbsp;para registrarte </h2></center></asp:Panel>
              
          <p style="font-family: calibri; text-align: justify;">La m�sica se ha transformado 
              significativamente en los �ltimos a�os, la manera de hacerla y escucharla ha 
              cambiado con el uso de la tecnolog�a.</p>

          <p style="font-family: calibri; text-align: justify;">El portal tiene un espacio 
              dedicado a la compra y venta de instrumentos musicales.</p>
        </div>
        <div id="body-right">
          <h2 style="font-family: sans-serif; font-size: xx-large; width: 402px; text-align: center;">
              Virpo es un portal donde...</h2>

          <div class="box"> <img src="images/pic_4.jpg" alt="Pic 1" class="left" />
            <p style="text-align: justify; font-family: Calibri; font-size: small;">...podr�s 
                subir las bases musicales de tu autor�a y fusionarlas con las de otros usuarios, 
                formando as� una canci�n creada de manera colaborativa...</p>

          </div>
          <div class="box"> <img src="images/pic_3.jpg" width="130" height="86" alt="Pic 2" class="left" />
            <p style="font-family: calibri; text-align: justify;">...formar�s tu propia banda 
                buscando los mejores talentos del mundo, de este modo descubrir�s nuevos estilos 
                musicales...</p>
            
          </div>
          <div class="box"> <img src="images/pic_2.jpg" width="130" height="86" alt="Pic 3" class="left" />
            <p style="font-family: calibri; text-align: justify; height: 59px;">...vas a estar 
                siempre informado sobre los �ltimos acontecimientos y eventos del mundo de la 
                m�sica. Podr�s aprender gracias a la experiencia de otros usuarios...&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
          </div>
        </div>
         <br/>
         <br/>
         <br/>
        
      </div>
      
      <div class="clear" 
             style="font-family: Calibri; font-size: medium; text-align: center;">
          &nbsp;&nbsp;www.virpo.com.ar</div>
    </div>
  
  
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>







