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

public partial class ConsultarBanda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Banda banda = BandaFactory.Devolver(Convert.ToInt32(Request.QueryString["C"]));
            if (Convert.ToInt32(Request.QueryString["P"]) == 1) btnModificarBanda.Visible = false;
            lblId.Text = banda.Id.ToString();
            lblNombre.Text = banda.Nombre;
            lblGenero.Text = banda.Genero.Nombre;
            lblPaginaWeb.Text = banda.PaginaWeb;
            lblFecInicio.Text = banda.FechaInicio.ToShortDateString();
            lblLocalidad.Text = banda.Localidad.Nombre;
            Image1.ImageUrl = ResolveUrl("./ImagenesBandas/") + banda.Imagen;
            Image1.ToolTip = banda.Nombre;
            lblVideo.Text = @"<table align='center'><tr><td><object width='450' height='290'><param name='movie' value='http://www.youtube.com/v/" + banda.Video + "'>"
                          + "</param><param name='allowFullScreen' value='true'></param><param name='allowscriptaccess' value='always'></param><embed"
                          + " src='http://www.youtube.com/v/" + banda.Video + "' type='application/x-shockwave-flash' allowscriptaccess='always'"
                          + " allowfullscreen='true' width='425' height='290'></embed></object></td></tr></table>";
            //Esta es otra manera de mostrar un video de youtube.
            //lblVideo.Text = @"<table align='center'><tr><td><object type='application/x-shockwave-flash' allowscriptaccess='never' allownetworking='internal' data='http://www.youtube.com/v/" + banda.Video + "&amp;hl=en' width='280' height='234'>"
            //               + "<param name='allowScriptAccess' value='never'><param name='allowNetworking' value='internal'><param name='movie' value='http://www.youtube.com/v/" + banda.Video + "&amp;hl=en'></object></td></tr></table>";
        }
    }
    protected void btnModificarBanda_Click(object sender, EventArgs e)
    {
        Banda banda = BandaFactory.Devolver(int.Parse(lblId.Text));
        Session["DatosBanda"] = banda;
        Response.Redirect("ModificarBanda.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarBandas.aspx");
    }
}
