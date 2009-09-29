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

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            ImgPerfil.ImageUrl = "./ImagenesUsuario/" + usr.Imagen;
            lblLogin.Text = usr.Nombre;
            lblNombre.Text = usr.Nombre;
            lblApellido.Text = usr.Apellido;
            lblInstrumento.Text = (InstrumentoFactory.Devolver(int.Parse(usr.IdInstrumento.ToString()))).Nombre;
            lblFecNac.Text = usr.FecNac.ToShortDateString();
            if (usr.Sexo.ToString() == "M") lblSexo.Text = "Masculino";
            else lblSexo.Text = "Femenino";
            lbleMail.Text = usr.EMail;
            lblTelFijo.Text = usr.TelFijo;
            lblTelMovil.Text = usr.TelMovil;
            lblBarrio.Text = usr.Barrio;
            Localidad loc = new Localidad();
            loc = LocalidadFactory.Devolver(int.Parse(usr.IdLocalidad.ToString()));
            lblLocalidad.Text = loc.Nombre;
            lblProvincia.Text = loc.Provincia.Nombre;
            lblPais.Text = loc.Provincia.Pais.Nombre;
        }
    }
}
