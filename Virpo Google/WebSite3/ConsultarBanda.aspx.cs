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
            //Cambia el estado a leido cuando es consultado por la administración de denuncias.
            if (Request.QueryString["leida"] != null)
            {
                DenunciaFactory.ModificarLeida(int.Parse(Request.QueryString["leida"].ToString()));
                ClientScript.RegisterStartupScript(typeof(String), "RefrescaDenunciasLeidas", "window.opener.location.reload()", true);
            }
            //Fin

            if (DenunciaFactory.HayDenuncia(Convert.ToInt32(Request.QueryString["C"]), "Banda") != 0)
            {
                btnDenunciar.Text = "Denunciado";
                btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
                btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
                btnDenunciar.Enabled = false;
            }


            Banda banda = BandaFactory.Devolver(Convert.ToInt32(Request.QueryString["C"]));
            Usuario creador = UsuarioFactory.DevolverCreadorDeBanda(banda.Id);
            if (Session["Usuario"] != null && creador != null && ((Usuario)Session["Usuario"]).Id == creador.Id)
            {
                btnModificarBanda.Visible = true;
                btnAgregarIntegrantes.Visible = true;
            }
            else
            {
                btnModificarBanda.Visible = false;
                btnAgregarIntegrantes.Visible = false;
            }
            if(creador != null)
                lblCreador.Text = "<a href='PerfilPublico.aspx?Id=" + creador.Id + "' title='" + creador.NombreUsuario + "'>" + creador.NombreUsuario + "</a>";

            if (Session["Usuario"] == null)
                btnDenunciar.Visible = false;
            //if (Convert.ToInt32(Request.QueryString["P"]) == 1) //No es el creador
            //{
            //    btnModificarBanda.Visible = false;
            //    btnAgregarIntegrantes.Visible = false;
            //}
            lblId.Text = banda.Id.ToString();
            lblNombre.Text = banda.Nombre;
            lblGenero.Text = banda.Genero.Nombre;
            if (!banda.PaginaWeb.StartsWith("http"))
                banda.PaginaWeb = "http://" + banda.PaginaWeb;
            lblPaginaWeb.Text = "<a href='" + banda.PaginaWeb + "' target='_blank'>" + banda.PaginaWeb + "</a>";
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
            this.CargarEventos();
        }
    }
    protected void btnModificarBanda_Click(object sender, EventArgs e)
    {
        Banda banda = BandaFactory.Devolver(int.Parse(lblId.Text));
        Session["DatosBanda"] = banda;
        Response.Redirect("ModificarBanda.aspx");
    }
    //protected void btnCancelar_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ListarBandas.aspx");
    //}
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

    private void CargarEventos()
    {
        DataTable dt = this.DatosEventos();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Columns[0].Visible = false;
    }

    private DataTable DatosEventos()
    {
        DataTable dt = new DataTable();
        DataRow row;

        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Fecha");
        dt.Columns.Add("Lugar");
        dt.Columns.Add("Consultar");

        List<Evento> eventos = EventoFactory.DevolverTodos("WHERE idBanda = " + Convert.ToInt32(Request.QueryString["C"]));

        if (eventos != null)
        {
            foreach (Evento evento in eventos)
            {
                row = dt.NewRow();
                row["Id"] = evento.Id;
                row["Imagen"] = evento.Imagen;
                row["Nombre"] = evento.Nombre;
                row["Fecha"] = Convert.ToString(evento.Fecha.Day) + "/" + Convert.ToString(evento.Fecha.Month) + "/" + Convert.ToString(evento.Fecha.Year);
                row["Lugar"] = evento.Lugar;

                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("ConsultarEvento.aspx?E=" + id);
        }
    }
    protected void btnDenunciar_Click(object sender, EventArgs e)
    {
        if (btnDenunciar.Text == "Denunciar")
        {
            btnDenunciar.Text = "Denunciado";
            btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
            btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
            btnDenunciar.Enabled = false;

            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            Denuncia denuncia = new Denuncia();
            denuncia.IdDenunciante = Convert.ToInt32(usr.Id);
            denuncia.UsrDenunciante = usr.NombreUsuario.ToString();
            denuncia.Url = Request.Url.ToString().Substring(Request.Url.ToString().LastIndexOf('/') + 1);
            denuncia.Descripcion = lblNombre.Text.ToString();
            denuncia.Tipo = "Bandas";
            denuncia.Fecha = DateTime.Now;
            denuncia.IdDocDenunciado = Convert.ToInt32(Request.QueryString["C"]);
            denuncia.Tabla = "Banda";

            bool ok = DenunciaFactory.Insertar(denuncia);
        }
    }
    protected void btnAgregarIntegrantes_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarUsuarios.aspx?IdBanda=" + lblId.Text);
    }
}
