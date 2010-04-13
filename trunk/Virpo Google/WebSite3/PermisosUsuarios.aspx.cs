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
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlRol.Items.Add("Administrador");
            ddlRol.Items.Add("Musico");
            ddlRol.Items.Add("Periodista");
            ddlRol.Items.Add("Inactivo");
            ddlRol.Items.Add("Desadmitido");

            if (Request.QueryString["i"] != null)
            {
                txtId.Text = Request.QueryString["i"].ToString();
                int id = Convert.ToInt32(Request.QueryString["i"].ToString());
                Usuario usr = new Usuario();
                usr = UsuarioFactory.Devolver(id);
                lblNombre.Text = usr.Nombre;
                lblApellido.Text = usr.Apellido;

                switch (usr.IdTipoUsuario)
                {
                    case 0: lblRol.Text = "Administrador";
                            ddlRol.SelectedIndex=0;
                        break;
                    case 1: lblRol.Text = "Musico";
                            ddlRol.SelectedIndex=1;
                        break;
                    case 2: lblRol.Text = "Periodista";
                            ddlRol.SelectedIndex=2;
                        break;
                    case 3: lblRol.Text = "Inactivo";
                            ddlRol.SelectedIndex=3;
                        break;
                    case 4: lblRol.Text = "Desadmitido";
                            ddlRol.SelectedIndex=4;
                        break;
                }

            }
            
            
        }

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("PermisosUsuarios.aspx?i=" + txtId.Text);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUsuarios.aspx");
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["i"] != null)
        {

            int id = Convert.ToInt32(Request.QueryString["i"].ToString());
            Usuario usr = new Usuario();
            usr = UsuarioFactory.Devolver(id);
            usr.IdTipoUsuario = ddlRol.SelectedIndex;

            if (UsuarioFactory.Modificar(usr))
                Response.Redirect("AdminUsuarios.aspx?Z=1");
            else
                Response.Redirect("AdminUsuarios.aspx?Z=0");
        }

    }
}
