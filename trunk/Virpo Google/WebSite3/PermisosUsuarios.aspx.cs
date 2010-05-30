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

public partial class PermisosUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UsuarioAdmin"] == null) Response.Redirect("admin.aspx");
            else
            {
                Panel1.Visible = false;
            }

        }
    }
    protected void btnBuscarUsr_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }
    protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        txtUsuario.Text = gvUsuarios.SelectedRow.Cells[4].Text.ToString();
        txtUsuario.Enabled = false;
        ddlRol.Items.Clear();
        MetodosComunes.cargarRoles(ddlRol);
        ddlRol.SelectedIndex = int.Parse(gvUsuarios.SelectedDataKey.Value.ToString());
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        UsuarioFactory.ActualizarRol(txtUsuario.Text.Trim(), ddlRol.SelectedIndex);
        Panel1.Visible = false;
        cargarGrilla();
    }
    protected void cargarGrilla()
    {
        gvUsuarios.DataSource = UsuarioFactory.DevolverBusqueda(txtNombreUsr.Text.Trim());
        gvUsuarios.DataBind();
    }
}
