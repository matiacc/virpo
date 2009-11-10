using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] != null)
                lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id +"' title='Mis Grupos'>Mis Grupos</a>";
            else
                lblMisGrupos.Text = "<a href='GruposDeInteres.aspx' title='Mis Grupos'>Mis Grupos</a>";

            
            int idUser = 0;
            if(Request.QueryString["Id"] != null)
            {
                idUser = Convert.ToInt32(Request.QueryString["Id"]);
            }
            this.CargarGrupos(idUser);
        }
    }
    private void CargarGrupos(int idUser)
    {
        string restriccion = "";
        if (idUser > 0)
            restriccion = "WHERE idCreador =" + idUser;

        List<Grupo> grupos = GrupoFactory.DevolverTodos(restriccion);
        string html = "<table>";

        int i=0;
        int miembros = 0;
        foreach (Grupo grupo in grupos)
        {
            if (i % 2 == 0)
                html += "<tr valign='top'>";

            miembros=GrupoFactory.CantidadMiembros(grupo.Id);
            html += "<td>" +
            "<div style='border: 1px solid rgb(192, 192, 192); position: relative; margin-right: 15px; margin-bottom: 15px; float: left;'>" +
            "			<a class='blogHeadline' title='" + grupo.Nombre + "' href='ConsultarGrupo.aspx?id=" + grupo.Id + "'><img src='" + grupo.Imagen + "' style='width:250px; height:250px;'/></a>" +
            "		<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);' class='transparent_60'>" + grupo.Nombre + "</h2>" +
            "		<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'>" + grupo.Nombre + "</h2>" +
            "		<div style='padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;' " +
                //"			<a href="http://kompoz.com/site/guitar" style="text-decoration: none; color: rgb(160, 160, 160);">" +
                //"            kompoz.com/site/guitar</a><br>" +
            "			<b>" + miembros + " miembros</b>" +
            "		</div></div></td>";

            if (i % 2 != 0)
                html += "</tr>";

            i++;
        }
        if (i == 0)
            lblGrupos.Text = "No se ha registrado ningun grupo";
        else
            lblGrupos.Text = html;
        
    }
}
