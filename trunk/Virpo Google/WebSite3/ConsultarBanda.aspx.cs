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
            lblId.Text = banda.Id.ToString();
            lblNombre.Text = banda.Nombre;
            lblGenero.Text = banda.Genero.Nombre;
            lblPaginaWeb.Text = banda.PaginaWeb;
            lblFecInicio.Text = banda.FechaInicio.ToShortDateString();
            lblLocalidad.Text = banda.Localidad.Nombre;
            Image1.ImageUrl = ResolveUrl("./ImagenesBandas/") + banda.Imagen;
            Image1.ToolTip = banda.Nombre;
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
