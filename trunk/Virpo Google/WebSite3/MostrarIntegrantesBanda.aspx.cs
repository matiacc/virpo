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

public partial class MostrarIntegrantesBanda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario musico = new Usuario();
            musico = (Usuario)Session["Usuario"];
            MetodosComunes.cargarMisBandas(ddlMisBandas, int.Parse(musico.Id.ToString()));
        }
    }

    protected void ddlMisBandas_SelectedIndexChanged(object sender, EventArgs e)
    {
        MetodosComunes.CargarListadoMusicos(lbMusicos, int.Parse(ddlMisBandas.SelectedValue));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bandas.aspx");    
    }
}
