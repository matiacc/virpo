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

public partial class MisGrupos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            lblGrupos.Text = "Grupos de Interés creados por mí:<br><br>";
            
            this.CargarMisGrupos(((Usuario)(Session["Usuario"])).Id);
            this.CargarTodos(((Usuario)(Session["Usuario"])).Id);
        }
    }
    private void CargarMisGrupos(int idUser)
    {
        string restriccion = "";
        if (idUser > 0)
            restriccion = "WHERE idCreador =" + idUser;

        List<Grupo> grupos = GrupoFactory.DevolverTodos(restriccion);
        string html = "<table>";

        int i = 0;
        int miembros = 0;
        foreach (Grupo grupo in grupos)
        {
            if (i % 2 == 0)
                html += "<tr valign='top'>";

            miembros = GrupoFactory.CantidadMiembros(grupo.Id);
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
            lblGrupos.Text += "No has creado ningún grupo todavía<br>";
        else
        {
            if (html.Substring(html.Length - 3, 2) != "tr")
                html += "</tr>";
            html += "</table>";
            lblGrupos.Text += html;
        }

    }

    private void CargarTodos(int idUser)
    {
        List<Grupo> grupos = GrupoFactory.DevolverTodosPorMiembro(idUser);
        string html = "<table>";

        int i = 0;
        int miembros = 0;
        foreach (Grupo grupo in grupos)
        {
            if (i % 2 == 0)
                html += "<tr valign='top'>";

            miembros = GrupoFactory.CantidadMiembros(grupo.Id);
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
            lblColaboro.Text = "Usted no es miembro de ningún Grupo de Interés";
        else
        {
            if (html.Substring(html.Length - 3, 2) != "tr")
                html += "</tr>";
            html += "</table>";
            lblColaboro.Text = html;
        }
    }
}
