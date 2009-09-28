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
        }
        MetodosComunes.cargarCategoriaWiki(ddlCategoria);
        
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Wikimusic.aspx");
        
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ArticuloWiki articulo = new ArticuloWiki();

        articulo.IdCat = CategoriaArticuloWikiFactory.Devolver(Convert.ToInt32(ddlCategoria.SelectedValue));
        
        Usuario usu = new Usuario();
        usu = (Usuario)Session["Usuario"];
        articulo.IdAutor = usu;

        articulo.FecCreacion = DateTime.Now;
        articulo.Titulo = txtTitulo.Text;
        articulo.Cuerpo= elm3.Text;
        articulo.Version = 1;
        articulo.CantVisitas = 0;
        articulo.Descripcion = "Version Inicial";


        if (ArticuloWikiFactory.Insertar(articulo))
        Response.Redirect("Wikimusic.aspx?Z=1");
        else
        Response.Redirect("Wikimusic.aspx?Z=0");

           
    }

}
