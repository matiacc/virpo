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

public partial class CambiarPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            lblNomUsuario.ForeColor = System.Drawing.Color.DarkOrange;
            lblNomUsuario.Text = usr.NombreUsuario;
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }

    protected void btnCambia_Click(object sender, EventArgs e)
    {
        Usuario usr = new Usuario();
        usr = (Usuario)Session["Usuario"];
        string pass = (UsuarioFactory.Devolver(int.Parse(usr.Id.ToString()))).Password.ToString();
        if (pass == txtPasswordActual.Text)
        {
            lblContraseñaActual.Text = "";

            if (txtNvaPassword.Text == txtConfrimarPassword.Text)
            {
                lblConfirmaContraseña.Text = "";
                UsuarioFactory.CambiarPassword(int.Parse(usr.Id.ToString()), txtNvaPassword.Text);
                Panel1_ModalPopupExtender.Show();
            }
            else
            {
                lblConfirmaContraseña.Text = "Incorrecto. Reingresar la Nueva Contraseña";
            }
        }
        else
        {
            lblContraseñaActual.Text = "Contraseña Actual Incorrecta";
            lblConfirmaContraseña.Text = "";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
}
