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
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            ArticuloWiki art = new ArticuloWiki();

            int id = Convert.ToInt32(Request.QueryString["C"]);
          
            art = (ArticuloWiki)ArticuloWikiFactory.Devolver(id);

            lblTitulo.Text = art.Titulo;

            lblCat.Text = art.IdCat.Nombre;
            
            elm3.Text=art.Cuerpo;

        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        int idArt = Convert.ToInt32(Request.QueryString["C"]);
        Response.Redirect("ConsultarArticuloWiki.aspx?C=" + idArt);
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        //guardo 2 instancias del articulo
        int idArt = Convert.ToInt32(Request.QueryString["C"]);
        ArticuloWiki articuloViejo =ArticuloWikiFactory.Devolver(idArt);
        ArticuloWiki articuloNuevo = ArticuloWikiFactory.Devolver(idArt);
        
        // uno lo modifico con los nuevos datos
        Usuario usu = new Usuario();
        usu = (Usuario)Session["Usuario"];
        articuloNuevo.IdAutor = usu;

        articuloNuevo.FecCreacion = DateTime.Now;
        articuloNuevo.Cuerpo = elm3.Text;
        articuloNuevo.Version = articuloViejo.Version + 1;
        articuloNuevo.CantVisitas = articuloViejo.CantVisitas;
        articuloNuevo.Descripcion = lblDescripcion.Text;

        //el otro lo tengo que guardar en HISTORIALWIKI para mantener el versionado
        HistorialWiki versionAnterior = new HistorialWiki();
        versionAnterior.IdArticulo = idArt;
        versionAnterior.Version= articuloViejo.Version;
        versionAnterior.IdCat= articuloViejo.IdCat.Id;
        versionAnterior.IdAutor = articuloViejo.IdAutor.Id;
        versionAnterior.FecModificacion= articuloViejo.FecCreacion;
        versionAnterior.Titulo= articuloViejo.Titulo;
        versionAnterior.Cuerpo=articuloViejo.Cuerpo;
        versionAnterior.Descripcion=articuloViejo.Descripcion;

        //
        if (ArticuloWikiFactory.Modificar(articuloNuevo) && HistorialWikiFactory.Insertar(versionAnterior))
            Response.Redirect("Wikimusic.aspx?Z=1");
        else
            Response.Redirect("Wikimusic.aspx?Z=0");
    }
}
