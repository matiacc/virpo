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

public partial class NuevoTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
          lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";
          if (Request.QueryString["grupo"] != null)
          {
              int idGrupo = Convert.ToInt32(Request.QueryString["grupo"]);
              ViewState.Add("idGrupo", idGrupo);
          }
        }

    }
    protected void btPublicar_Click(object sender, EventArgs e)
    {
        TopicGrupo topic = new TopicGrupo();
        topic.Creador = (Usuario)Session["Usuario"];
        topic.FechaCreacion = DateTime.Now;

        Grupo grupo=new Grupo();
        grupo.Id = Convert.ToInt32(ViewState["idGrupo"]);
        topic.Grupo = grupo;

        topic.Titulo = txtTitulo.Text.Trim();
        int idTopic = TopicGrupoFactory.Insertar(topic);

        PostGrupo post = new PostGrupo();
        post.Comentario = txtComentario.Text.Trim();
        post.Creador = (Usuario)Session["Usuario"];
        post.FechaCreacion = DateTime.Now;
        post.IdTopic = idTopic;

        PostGrupoFactory.Insertar(post);
        Response.Redirect("Debate.aspx?Id=" + ViewState["idGrupo"]);
    }
}
