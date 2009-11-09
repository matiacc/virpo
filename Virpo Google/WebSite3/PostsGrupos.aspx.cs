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

public partial class PostsGrupos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";
            if (!string.IsNullOrEmpty(Request.QueryString["topic"]))
            {
                string idTopic = Request.QueryString["topic"];
                TopicGrupo topic = TopicGrupoFactory.Devolver(Convert.ToInt32(idTopic));
                lblTituloTopic.Text = topic.Titulo;
                lblResponder.Text = "<a href='NuevoPost.aspx?idTopic=" + idTopic + "'>Responder</a>"; 
                List<PostGrupo> posts = PostGrupoFactory.DevolverTodosPorTopic(idTopic);
                this.CargarTabla(posts);
                TopicGrupoFactory.IncrementarVisita(idTopic);
            }
        }
    }

    private void CargarTabla(List<PostGrupo> posts)
    {
        string html = "";
        foreach (PostGrupo post in posts)
        {
            html += "<tr>";
            html += "    <td colspan='2' align='right'>"+ post.FechaCreacion.ToLongDateString() +"</td>";
            html += "</tr>";
            html += "<tr>";
            html += "    <td style='width: 50px' align='center'><a href='PerfilPublico.aspx?Id=" + post.Creador.Id + "'>";
            html += "<img title='" + post.Creador.NombreUsuario + "' src='ImagenesUsuario/" + post.Creador.Imagen + "'/></a>";
            html += "<br />"+ post.Creador.NombreUsuario +"</td>";
            html += "    <td style='width: 250px'>" + post.Comentario + "</td>";
            html += "</tr>";     
        }
        lblTabla.Text = html;
    }
}
