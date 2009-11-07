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

public partial class MisBandas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            CargarBandas(usr.Id);
        }
    }

    private void CargarBandas(int idUsuario)
    {
        List<Banda> bandas = BandaFactory.DevolverBandasDeIntegrante(idUsuario);
        string html = "<table>";

        for (int i = 0; i < bandas.Count; i++)
        {
            //if (i == 6)
            //    break;
            if (i % 2 == 0)
                html += "<tr>";
            html += "<td>";
            html += @"<div style='border: 0px solid rgb(192, 192, 192); position: relative; margin-right: 15px; "
                    + "margin-bottom: 15px; float: left;'><a class='blogHeadline' title='" + bandas[i].Nombre +
                    "' href='BandaPublica.aspx?C=" + bandas[i].Id + "'><img src='./ImagenesBandas/" + bandas[i].Imagen + "' style='width:250px; height:250px;'/></a>"
                    + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
                    + " class='transparent_60'>" + bandas[i].Nombre + "</h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
                    + ">" + bandas[i].Nombre + "</h2><div style='padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;'"
                    + " class='transparent_60'><a style='text-decoration: none; color: rgb(160, 160, 160);' href='BandaPublica.aspx?C=" + bandas[i].Id + "'>" + bandas[i].Genero.Nombre + "</a><br>"
                    + "<b>" + bandas[i].PaginaWeb + "</b></div></div>";
            html += "</td>";
            if (i % 2 != 0)
                html += "</tr>";
        }
        if (bandas.Count % 2 == 0 || bandas.Count == 1) html += "</tr>";
        html += "</table>";
        lblBandas.Text = html;
    }
}
