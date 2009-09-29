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

public partial class ModificarBanda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Banda banda = new Banda();
            banda = (Banda)Session["DatosBanda"];
            txtNombre.Text = banda.Nombre;
            MetodosComunes.cargarGeneros(ddlGenero);
            ddlGenero.SelectedValue = banda.Genero.Id.ToString();
            txtPaginaWeb.Text = banda.PaginaWeb;
            txtFecInicio.Text = banda.FechaInicio.ToShortDateString();
            MetodosComunes.cargarLocalidades(ddlLocalidad);
            ddlLocalidad.SelectedValue = banda.Localidad.Id.ToString();
            MetodosComunes.cargarPaises(ddlPais);
            ddlPais.SelectedValue = banda.Localidad.Provincia.Pais.Id.ToString();
            MetodosComunes.cargarProvincias(ddlProvincia);
            ddlProvincia.SelectedValue = banda.Localidad.Provincia.Id.ToString();
        }
    }
    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarProvincias();
        LimpiarLocalidades();

        if (ddlPais.SelectedValue != "")
        {
            CargarProvincias(int.Parse(ddlPais.SelectedValue));
        }
    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarLocalidades();

        if (ddlProvincia.SelectedValue != "")
        {
            CargarLocalidades(int.Parse(ddlProvincia.SelectedValue));
        }
    }

    private void CargarLocalidades(int idProvincia)
    {
        MetodosComunes.cargarLocalidades(ddlLocalidad, idProvincia);
    }

    private void CargarProvincias(int idPais)
    {
        MetodosComunes.cargarProvincias(ddlProvincia, idPais);
    }

    private void LimpiarLocalidades()
    {
        ddlLocalidad.DataSource = null;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Clear();
    }

    private void LimpiarProvincias()
    {
        ddlProvincia.DataSource = null;
        ddlProvincia.DataBind();
        ddlProvincia.Items.Clear();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Banda banda = new Banda();
        banda = (Banda)Session["DatosBanda"];
        Response.Redirect("ConsultarBanda.aspx?C=" + banda.Id.ToString());
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Banda banda = new Banda();
        banda = (Banda)Session["DatosBanda"];
        Banda bandaModificada = new Banda();
        bandaModificada.Id = banda.Id;
        bandaModificada.Nombre = txtNombre.Text;
        bandaModificada.Genero = GeneroFactory.Devolver(int.Parse(ddlGenero.SelectedValue.ToString()));
        bandaModificada.PaginaWeb = txtPaginaWeb.Text;
        bandaModificada.FechaInicio = DateTime.Parse(txtFecInicio.Text);
        bandaModificada.Localidad = LocalidadFactory.Devolver(int.Parse(ddlLocalidad.SelectedValue.ToString()));
        bandaModificada.Descripcion = banda.Descripcion;
        bandaModificada.Imagen = banda.Imagen;
        bandaModificada.ImagenThumb = banda.ImagenThumb;
        BandaFactory.Modificar(bandaModificada);
        Response.Redirect("ConsultarBanda.aspx?C=" + bandaModificada.Id.ToString());
    }
}
