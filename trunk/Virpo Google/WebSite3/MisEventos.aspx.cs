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


public partial class MisEventos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMisEventos();
        }

    }
//cargar los eventos
    private void CargarMisEventos()
    {
        Usuario usuario = (Usuario)Session["Usuario"];
        String a = "WHERE idMusico= " + Convert.ToString(usuario.Id);

        List<Evento> eventos = EventoFactory.DevolverTodos(a);
        string html = "<table>";
        DateTime fhoy = DateTime.Today;
        String fecha;
        for (int i = 0; i < eventos.Count; i++)
        {
            fecha = Convert.ToString(eventos[i].Fecha.Day) + "/" + Convert.ToString(eventos[i].Fecha.Month) + "/" + Convert.ToString(eventos[i].Fecha.Year);
            if ( fhoy > eventos[i].Fecha) fecha = "<font size='5'; color ='red'>FINALIZADO</font>";
            
                  


            if (i % 2 == 0)
            html += "<tr>";
            html += "<td>";
            html += @"<div style='border: 0px solid rgb(192, 192, 192); position: relative; margin-right: 15px; "
                    + "margin-bottom: 15px; float: left;'><a class='blogHeadline' title='" + eventos[i].Nombre +
                    "' href='ConsultarEvento.aspx?E=" + eventos[i].Id + "'><img src='" + eventos[i].Imagen + "' style='width:250px; height:250px;'/></a>"
                    + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
                    + " class='transparent_60'>" + eventos[i].Nombre + "</h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
                    + ">" + eventos[i].Nombre + "</h2><div style='padding: 5px; margin-top: 0px; width: 240px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;'"
                    + " class='transparent_60'><a style='text-decoration: none; color: rgb(160, 160, 160);' href='ConsultarEvento.aspx?E=" + eventos[i].Id + "'>" + eventos[i].Lugar + "</a><br>"
                    + "<b>" + fecha + "</b></div></div>";
            html += "</td>";
            if (i % 2 != 0)
                html += "</tr>";
        }
        if (eventos.Count % 2 == 0 || eventos.Count == 1) html += "</tr>";
        html += "</table>";
        lblEventos.Text = html;
    }
}
