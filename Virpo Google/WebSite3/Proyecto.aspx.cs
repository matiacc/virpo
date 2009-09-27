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
using System.Collections.Generic;

public partial class Proyecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            if (Request.QueryString["Id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                DataTable dtColaboradores = DatosColaboradores(id);
                GridView1.DataSource = dtColaboradores;
                GridView1.DataBind();
                CapaNegocio.Entities.Proyecto proy = ProyectoFactory.Devolver(id);
                lblNombre.Text = proy.Nombre;
                lblDescripcion.Text = proy.Descripcion;
                lblFecha.Text = proy.FechaCreacion.ToShortDateString();
                lblGenero.Text = proy.Genero;
                Image1.ImageUrl = ResolveUrl(proy.Imagen);
                lblLicencia.Text = proy.Licencia;
                lblUsuario.Text = proy.Usuario.NombreUsuario;
            }
            
        }

    }

    private DataTable DatosColaboradores(int idProyecto)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");

        List<Usuario> usuarios = UsuarioFactory.DevolverIntegrantesDeProyecto(idProyecto);
        if (usuarios != null)
        {
            foreach (Usuario usuario in usuarios)
            {
                row = dt.NewRow();
                row["Imagen"] = ResolveUrl(usuario.Imagen);
                row["Nombre"] = usuario.NombreUsuario;
                dt.Rows.Add(row);
            }
            return dt;
        }
        else
            return null;
        
        

    }
}
