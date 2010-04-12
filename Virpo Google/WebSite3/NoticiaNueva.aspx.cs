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
            ddlPosicion.Items.Add("Izquierda");
            ddlPosicion.Items.Add("Centro");
            ddlPosicion.Items.Add("Derecha");
            ddlPosicion.SelectedIndex = 1;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        elm3.Text = "";

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Noticia noticia = new Noticia();

        noticia.Descripcion = txtDesc.Text;
        noticia.Cuerpo = elm3.Text;
        noticia.FechaCreacion = DateTime.Now;
        
        //Usuario usu = new Usuario();
        //usu = (Usuario)Session["Usuario"];
        Usuario usu = UsuarioFactory.Devolver(1);
        noticia.IdAutor = usu;
        
             
        noticia.CantVisitas = 0;
        noticia.Posicion = ddlPosicion.Text;
        noticia.EsVigente = 1;

        if (NoticiasFactory.Insertar(noticia))
        Response.Redirect("AdminNoticias.aspx?Z=1");
        else
        Response.Redirect("AdminNoticias.aspx?Z=0");
           
    }
}
