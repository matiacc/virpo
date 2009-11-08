<%@ Page Language="C#" MasterPageFile="~/Virpo.master" AutoEventWireup="true" CodeFile="GruposDeInteres.aspx.cs" Inherits="_Default" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="menu8">
        <ul>
            <li><a href="NuevoGrupo.aspx" title="Nuevo Grupo">Nuevo Grupo</a></li>
            <li><a href="MisGrupos.aspx" title="Mis Grupos">Mis Grupos</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table border="0" align="center">
<tbody><tr valign="top">
	<td width="600">
		<table border="0">
		<tbody> 
            <asp:Label ID="lblGrupos" runat="server" Text="Label"></asp:Label>
		<%--
		<tr valign="top">
			<td>
				<div style="border: 1px solid rgb(192, 192, 192); position: relative; margin-right: 15px; margin-bottom: 15px; float: left;">
						<a class="blogHeadline" title="Guitar" href="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg"><img src="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg" style="width:250px; height:250px;"/></a>
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);" class="transparent_60">
                        Guitar</h2>
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;">
                        Guitar</h2>
					<div style="padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;" 
						<a href="http://kompoz.com/site/guitar" style="text-decoration: none; color: rgb(160, 160, 160);">
                        kompoz.com/site/guitar</a><br>
						<b>321 members</b>
					</div>	
				</div>
			</td>
			<td>
				<div style="border: 1px solid rgb(192, 192, 192); position: relative; margin-right: 15px; margin-bottom: 15px; float: left;">
						<a class="blogHeadline" title="Guitar" href="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg"><img src="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg" style="width:250px; height:250px;"/></a>
					
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);" class="transparent_60">
                        Guitar</h2>
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;">
                        Guitar</h2>
			
					<div style="padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;" 
                                                                class="transparent_60">
						<a href="http://kompoz.com/site/guitar" style="text-decoration: none; color: rgb(160, 160, 160);">
                        kompoz.com/site/guitar</a><br>
						<b>321 members</b>
					
					</div>	
					
					
				</div>
			</td>
				</tr>
		<tr valign="top">
			<td>
				<div style="border: 1px solid rgb(192, 192, 192); position: relative; margin-right: 15px; margin-bottom: 15px; float: left;">
		
					
						<a class="blogHeadline" title="Guitar" href="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg"><img src="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg" style="width:250px; height:250px;"/></a>
					
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);" class="transparent_60">
                        Guitar</h2>
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;">
                        Guitar</h2>
			
					<div style="padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;" 
                                                                class="transparent_60">
						<a href="http://kompoz.com/site/guitar" style="text-decoration: none; color: rgb(160, 160, 160);">
                        kompoz.com/site/guitar</a><br>
						<b>321 members</b>
					
					</div>	
					
					
				</div>
			</td>
			<td>
				<div style="border: 1px solid rgb(192, 192, 192); position: relative; margin-right: 15px; margin-bottom: 15px; float: left;">
		
					
						<a class="blogHeadline" title="Guitar" href="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg"><img src="http://www.kompoz.com/media/uploads/minisite/1019/s1019-20090103-210235-p1.jpg" style="width:250px; height:250px;"/></a>
					
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);" class="transparent_60">
                        Guitar</h2>
					<h2 style="padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;">
                        Guitar</h2>
			
					<div style="padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;" 
                                                                class="transparent_60">
						<a href="http://kompoz.com/site/guitar" style="text-decoration: none; color: rgb(160, 160, 160);">
                        kompoz.com/site/guitar</a><br>
						<b>321 members</b>
					
					</div>	
					
					
				</div>
			</td>
				</tr>
--%>		</tbody></table>
		
		
		<br>
		
		<table align="center" border="0">
<tbody>
</tbody></table>

	</td>
	</tr>
</tbody></table>
			<br>&nbsp;<br>
		</td>
		<td class="view-port" bgcolor="#ffffff" width="10"></td>
	&nbsp;</tr></tbody></table></div><script src="list.minisite_files/ga.js" type="text/javascript"></script><script type="text/javascript">
var pageTracker = _gat._getTracker("UA-213460-3");
pageTracker._initData();
pageTracker._trackPageview();
</script></body></html></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

