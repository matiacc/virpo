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

public partial class ConsultarClasificado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!Page.IsPostBack)
        {
            

            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            int id = Convert.ToInt32(Request.QueryString["C"]);
            LinkButton1.Attributes.Add("onclick", "javascript:abrirPopup(" + id + ");");

            AvisoClasificado aviso = AvisoClasificadoFactory.Devolver(id);
            Session["Aviso"] = aviso;
            lblDescripcion.Text = aviso.Descripcion;
            lblFin.Text = aviso.FechaFin.ToShortDateString();
            lblInicio.Text = aviso.FechaInicio.ToShortDateString();
            lblPrecio.Text = "$ " + aviso.Precio.ToString();
            ClientScript.RegisterExpandoAttribute("link", "href", ResolveUrl("~/Imagenes/") + aviso.Imagen);
            lblImagen.Text = "<a href='./Imagenes/" + aviso.Imagen + "' rel='lightbox' title='" + aviso.Titulo + "'>" +
                            "<img src='./Imagenes/"+ aviso.Imagen + "' border='0' alt='' height='200' width='200' /></a>"; 
            lblRubro.Text = aviso.Rubro.Nombre;
            lblTitulo.Text = aviso.Titulo;
            lblUbicacion.Text = aviso.Ubicacion;
            lblVendedor.Text = aviso.Dueño.NombreUsuario;
            lblVisitas.Text = "15";

        }
        //No se muestra contactar con el vendedor si el aviso consultado es publicado por el que se logueo
        if (Session["Aviso"] != null) 
            if (((AvisoClasificado)Session["Aviso"]).Dueño.Id == ((Usuario)Session["Usuario"]).Id)
                LinkButton1.Visible = false;
        
    }
    
    
}
