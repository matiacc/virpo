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
            lblContactar.Text = "<a href='javascript:abrirPopup(" + id + ")' class='estiloLabelCabeceraPeque'>Contactar con el vendedor</a>";
            AvisoClasificado aviso = AvisoClasificadoFactory.Devolver(id);
            Session["Aviso"] = aviso;
            lblDescripcion.Text = aviso.Descripcion;
            lblFin.Text = aviso.FechaFin.ToShortDateString();
            lblInicio.Text = aviso.FechaInicio.ToShortDateString();
            lblPrecio.Text = "$ " + aviso.Precio.ToString();
            for (int i = 0; i < aviso.Imagen.Count; i++)
            {
                if(i > 0)
                    lblImagen.Text += "<a href='" + aviso.Imagen[i] + "' rel='lightbox[aviso]' title='" + aviso.Titulo + "' style='display:none;'>" +
                                "<img src='" + aviso.Imagen[i] + "' border='0' alt='' style='width: 200px; height: 200px;'/></a>";     
                else
                    lblImagen.Text += "<a href='" + aviso.Imagen[i] + "' rel='lightbox[aviso]' title='" + aviso.Titulo + "'>" +
                                "<img src='" + aviso.Imagen[i] + "' border='0' alt='' style='width: 200px; height: 200px;'/></a>";     
            }
            
            lblRubro.Text = aviso.Rubro.Nombre;
            lblTitulo.Text = aviso.Titulo;
            lblUbicacion.Text = aviso.Ubicacion;
            lblVendedor.Text = aviso.Dueño.NombreUsuario;
            lblVisitas.Text = "15";

        }
        //No se muestra contactar con el vendedor si el aviso consultado es publicado por el que se logueo
        if (Session["Aviso"] != null) 
            if (((AvisoClasificado)Session["Aviso"]).Dueño.Id == ((Usuario)Session["Usuario"]).Id)
                lblContactar.Visible = false;
        
    }
    
    
}
