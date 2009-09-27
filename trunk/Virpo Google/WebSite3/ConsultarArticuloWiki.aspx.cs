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
        ArticuloWiki art = new ArticuloWiki();

        int id = Convert.ToInt32(Request.QueryString["C"]);
        if (id!=0)
        {
            art = (ArticuloWiki)ArticuloWikiFactory.Devolver(id);
        }
        else
        {
            List<int> ids = new List<int>();
            ids = ArticuloWikiFactory.DevolverIds();
            int cantArt = ids.Count;
            int random = new Random().Next(cantArt);

            int idExistente = (int)ids[random];
            art = ArticuloWikiFactory.Devolver(idExistente);
        }
        
        lblTitulo.Text = art.Titulo;

        lblCat.Text = art.IdCat.Nombre;

        lblContenido.Text = art.Cuerpo;

    } 
}
