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
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            //lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";
            if (Request.QueryString["grupo"] != null)
            {
                int idGrupo = Convert.ToInt32(Request.QueryString["grupo"]);
                lblProyectos.Text = "<a href='Proyectos.aspx?grupo=" + idGrupo + "' title='Proyectos'>Proyectos</a>";
                lblDebate.Text = "<a href='Debate.aspx?grupo=" + idGrupo + "'>Debates</a>";
                lblNuevoTopic.Text = "<a href='NuevoTopic.aspx?grupo=" + idGrupo + "'>Iniciar Debate</a>";
                List<TopicGrupo> topics = TopicGrupoFactory.DevolverTodosPorGrupo(idGrupo);
                
                this.CrearTabla(topics);

                Grupo grupo = GrupoFactory.Devolver(idGrupo);
                if(grupo != null)
                    centerTitulo.InnerHtml = "<tituloSubVentana>Debates del Grupo: " + grupo.Nombre + "</tituloSubVentana>";
            }
        }
       
    }

    private void CrearTabla(List<TopicGrupo> topics)
    {
        PostGrupo ultimoPost = new PostGrupo();
        string html= "";
        int totalRespuestas = 0;
        int visitas = 0;
        foreach (TopicGrupo topic in topics)
	    {
           totalRespuestas = TopicGrupoFactory.CantidadRespuestas(topic.Id);
           visitas = TopicGrupoFactory.CantidadVisitas(topic.Id);
           ultimoPost = PostGrupoFactory.DevolverUltimo(topic.Id);
                html += "<tr style='border-style: inset; border-width: thin'>";
                html += "<td style='text-align: center;'>";
                html += "<a href='PerfilPublico.aspx?Id="+ topic.Creador.Id+"'>";
                html += "<img src='ImagenesUsuario/" + topic.Creador.Imagen + "' title='" + topic.Creador.NombreUsuario + "' height='50px' width='50px' /></a>";
                html += "</td>";
                html += "<td><a href='PostsGrupos.aspx?topic=" + topic.Id + "'>" + topic.Titulo + "</a><br /> ";
                html += "creado el " + topic.FechaCreacion.ToShortDateString() + " por ";
                html += "<a href='PerfilPublico.aspx?Id=" + topic.Creador.Id + "'>" + topic.Creador.NombreUsuario + "</a></td>";
                html += "<td style='text-align: center;'>" + totalRespuestas + "</td>";
                html += "<td style='text-align: center;'>" + visitas + "</td>";
                html += "<td>"+ ultimoPost.FechaCreacion +" por <a href='PerfilPublico.aspx?Id="+ ultimoPost.Creador.Id +"'>"+ ultimoPost.Creador.NombreUsuario +"</a></td>";
            html += "</tr>";
	    }
        lblTabla.Text = html;    
     }
}
