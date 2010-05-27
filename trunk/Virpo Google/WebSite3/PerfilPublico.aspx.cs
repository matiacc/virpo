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

public partial class PerfilPublico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Cambia el estado a leido cuando es consultado por la administración de denuncias.
            if (Request.QueryString["leida"] != null)
            {
                DenunciaFactory.ModificarLeida(int.Parse(Request.QueryString["leida"].ToString()));
                ClientScript.RegisterStartupScript(typeof(String), "RefrescaDenunciasLeidas", "window.opener.location.reload()", true);
            }
            //Fin

            if (Request.QueryString["id"] != null)
            {
                if (DenunciaFactory.HayDenuncia(Convert.ToInt32(Request.QueryString["Id"]), "Usuario") != 0)
                {
                    btnDenunciar.Text = "Denunciado";
                    btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
                    btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
                    btnDenunciar.Enabled = false;
                }
            }

            Usuario usr = new Usuario();
            usr = UsuarioFactory.Devolver(int.Parse(Request.QueryString["Id"].ToString()));
            ImgPerfil.ImageUrl = "./ImagenesUsuario/" + usr.Imagen;
            lblLogin.Text = usr.Nombre;
            lblNombre.Text = usr.Nombre;
            lblApellido.Text = usr.Apellido;
            lblInstrumento.Text = (InstrumentoFactory.Devolver(int.Parse(usr.IdInstrumento.ToString()))).Nombre;
            lblFecNac.Text = usr.FecNac.ToShortDateString();
            if (usr.Sexo.ToString() == "M") lblSexo.Text = "Masculino";
            else lblSexo.Text = "Femenino";
            lbleMail.Text = usr.EMail;
            Localidad loc = new Localidad();
            loc = LocalidadFactory.Devolver(int.Parse(usr.IdLocalidad.ToString()));
            lblLocalidad.Text = loc.Nombre;
            lblProvincia.Text = loc.Provincia.Nombre;
            lblPais.Text = loc.Provincia.Pais.Nombre;
        }
    }
    protected void btnDenunciar_Click(object sender, EventArgs e)
    {
        if (btnDenunciar.Text == "Denunciar")
        {
            btnDenunciar.Text = "Denunciado";
            btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
            btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
            btnDenunciar.Enabled = false;

            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            Denuncia denuncia = new Denuncia();
            denuncia.IdDenunciante = (int)usr.Id;
            denuncia.UsrDenunciante = usr.NombreUsuario.ToString();
            denuncia.Url = Request.Url.ToString().Substring(Request.Url.ToString().LastIndexOf('/') + 1);
            denuncia.Descripcion = lblLogin.Text.ToString();
            denuncia.Tipo = "Perfil Público";
            denuncia.Fecha = DateTime.Now;
            denuncia.IdDocDenunciado = Convert.ToInt32(Request.QueryString["Id"]);
            denuncia.Tabla = "Usuario";

            bool ok = DenunciaFactory.Insertar(denuncia);
        }
    }
}
