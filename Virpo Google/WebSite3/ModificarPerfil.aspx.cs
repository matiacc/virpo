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

public partial class ModificarPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            ImgPerfil.ImageUrl = usr.Imagen;
            MetodosComunes.cargarLocalidades(ddlLocalidad);
            MetodosComunes.cargarProvincias(ddlProvincia);
            MetodosComunes.cargarPaises(ddlPais);
            MetodosComunes.cargarInstrumentos(ddlInstrumento);
            lblLogin.Text = usr.NombreUsuario;
            txtNombre.Text = usr.Nombre;
            txtApellido.Text = usr.Apellido;
            ddlInstrumento.SelectedValue = usr.IdInstrumento.ToString();
            txtFecNac.Text = usr.FecNac.ToShortDateString();
            if (usr.Sexo.ToString() == "M") txtSexo.Text = "Masculino";
            else txtSexo.Text = "Femenino";
            txtEmail.Text = usr.EMail;
            txtTelFijo.Text = usr.TelFijo;
            txtTelMovil.Text = usr.TelMovil;
            txtBarrio.Text = usr.Barrio;
            Localidad loc = new Localidad();
            loc = LocalidadFactory.Devolver(int.Parse(usr.IdLocalidad.ToString()));
            ddlLocalidad.SelectedValue = loc.Id.ToString();
            ddlProvincia.SelectedValue = loc.Provincia.Id.ToString();
            ddlPais.SelectedValue = loc.Provincia.Pais.Id.ToString();
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
        Response.Redirect("Perfil.aspx");
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Usuario usr = new Usuario();
        usr = (Usuario)Session["Usuario"];
        Usuario usrModificado = new Usuario();
        usrModificado.Id = usr.Id;
        usrModificado.Nombre = txtNombre.Text;
        usrModificado.Apellido = txtApellido.Text;
        usrModificado.IdInstrumento=int.Parse(ddlInstrumento.SelectedValue.ToString());
        usrModificado.FecNac = DateTime.Parse(txtFecNac.Text);
        usrModificado.Sexo = txtSexo.Text;
        usrModificado.EMail = txtEmail.Text;
        usrModificado.TelFijo = txtTelFijo.Text;
        usrModificado.TelMovil = txtTelMovil.Text;
        usrModificado.IdLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
        usrModificado.Barrio = txtBarrio.Text;
        usrModificado.Imagen = ImgPerfil.ImageUrl.ToString();
        usrModificado.ImagenThumb = usr.ImagenThumb;
        UsuarioFactory.Modificar(usrModificado);
        Session["Usuario"] = usrModificado;
        Response.Redirect("Perfil.aspx");
    }
}