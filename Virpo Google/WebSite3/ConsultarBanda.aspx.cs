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

public partial class ConsultarBanda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Banda banda = BandaFactory.Devolver(Convert.ToInt32(Request.QueryString["C"]));
            if (Convert.ToInt32(Request.QueryString["P"]) == 1) btnModificarBanda.Visible = false;
            lblId.Text = banda.Id.ToString();
            lblNombre.Text = banda.Nombre;
            lblGenero.Text = banda.Genero.Nombre;
            lblPaginaWeb.Text = banda.PaginaWeb;
            lblFecInicio.Text = banda.FechaInicio.ToShortDateString();
            lblLocalidad.Text = banda.Localidad.Nombre;
            Image1.ImageUrl = ResolveUrl("./ImagenesBandas/") + banda.Imagen;
            Image1.ToolTip = banda.Nombre;
            lblVideo.Text = @"<table align='center'><tr><td><object width='523' height='290'><param name='movie' value='http://www.youtube.com/v/" + banda.Video + "'>"
                          + "</param><param name='allowFullScreen' value='true'></param><param name='allowscriptaccess' value='always'></param><embed"
                          + " src='http://www.youtube.com/v/" + banda.Video + "' type='application/x-shockwave-flash' allowscriptaccess='always'"
                          + " allowfullscreen='true' width='523' height='290'></embed></object></td></tr></table>";
            //Esta es otra manera de mostrar un video de youtube.
            //lblVideo.Text = @"<table align='center'><tr><td><object type='application/x-shockwave-flash' allowscriptaccess='never' allownetworking='internal' data='http://www.youtube.com/v/" + banda.Video + "&amp;hl=en' width='280' height='234'>"
            //               + "<param name='allowScriptAccess' value='never'><param name='allowNetworking' value='internal'><param name='movie' value='http://www.youtube.com/v/" + banda.Video + "&amp;hl=en'></object></td></tr></table>";
            CargarIntegrantes(banda.Id);
            lblProyectos.Text = "<a href='Proyectos.aspx?banda=" + banda.Id + "' title='Proyectos'>Proyectos</a>";
        }
    }
    protected void btnModificarBanda_Click(object sender, EventArgs e)
    {
        Banda banda = BandaFactory.Devolver(int.Parse(lblId.Text));
        Session["DatosBanda"] = banda;
        Response.Redirect("ModificarBanda.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarBandas.aspx");
    }
    private void CargarIntegrantes(int idBanda)
    {
        List<Usuario> usuarios = UsuarioFactory.DevolverIntegrantesaDeBanda(idBanda);
        string html = "<table align='center'>"; 

        for (int i = 0; i < usuarios.Count; i++)
        {
            if (i % 3 == 0)
                html += "<tr>";
            html += "<td>";
            html += @"<div style='border: 0px solid rgb(192, 192, 192); position: relative; margin-right: 0px; "
                    + "margin-bottom: 0px; float: left;'><a class='blogHeadline' title='" + usuarios[i].Nombre +
                    "' href='PerfilPublico.aspx?Id=" + usuarios[i].Id + "'><img src='./ImagenesUsuario/" + usuarios[i].Imagen + "' style='width:175px; height:175px;'/></a>"
                    + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
                    + " class='transparent_60'>" + usuarios[i].Nombre + "</h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
                    + ">" + usuarios[i].Nombre + "</h2><div style='padding: 5px; margin-top: 0px; width: 165px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;'"
                    + " class='transparent_60'><a style='text-decoration: none; color: rgb(255, 165, 0);' href='PerfilPublico.aspx?Id=" + usuarios[i].Id + "'>" + (InstrumentoFactory.Devolver(int.Parse(usuarios[i].IdInstrumento.ToString()))).Nombre + "</a><br>"
                    + "<b><span style='font-size: 8pt; font-weight: normal;'>" + usuarios[i].EMail + "</b></div></div>";
            html += "</td>";
            if (i != 0 && i+1 % 3 == 0)
                html += "</tr>";
        }
        if (usuarios.Count % 3 == 0 || usuarios.Count == 1) html += "</tr>";
        html += "</table>";
        lblIntegrantes.Text = html;
    }
}
