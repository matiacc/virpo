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

public partial class NuevoPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";

            if (!string.IsNullOrEmpty(Request.QueryString["idTopic"]))
            {
                ViewState.Add("idTopic", Request.QueryString["idTopic"]);
                TopicGrupo topic = TopicGrupoFactory.Devolver(Convert.ToInt32(Request.QueryString["idTopic"]));
                lblTitulo.Text = topic.Titulo;
                lblProyectos.Text = "<a href='Proyectos.aspx?grupo=" + topic.Grupo.Id + "' title='Proyectos'>Proyectos</a>";
                lblDebate.Text = "<a href='Debate.aspx?grupo=" + topic.Grupo.Id + "'>Debates</a>";
            }

        }
    }
    protected void btPublicar_Click(object sender, EventArgs e)
    {
        PostGrupo post = new PostGrupo();
        post.Comentario = txtComentario.Text.Trim();
        post.Creador = (Usuario)Session["Usuario"];
        post.FechaCreacion = DateTime.Now;
        post.IdTopic = Convert.ToInt32(ViewState["idTopic"].ToString());

        if (PostGrupoFactory.Insertar(post))
        {
            Panel1_ModalPopupExtender.Show();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PostsGrupos.aspx?topic=" + ViewState["idTopic"].ToString());
    }
}
