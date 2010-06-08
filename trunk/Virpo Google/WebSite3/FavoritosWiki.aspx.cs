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
using CapaDatos;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            DataTable dt = this.DatosArticulo();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
        }
   

        
    }

    private DataTable DatosArticulo()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Version");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Descripcion");
        dt.Columns.Add("Creado");

        Usuario usu = new Usuario();
        usu= (Usuario)Session["Usuario"];
        List<ArticuloWiki> articulos = new List<ArticuloWiki>();
        articulos = ApuntesWikiFactory.DevolverApuntes(usu.Id);

        if (articulos.Count  != 0)
        {
            foreach (ArticuloWiki articulo in articulos)
            {
                row = dt.NewRow();
                row["Id"] = articulo.Id;
                row["Version"] = articulo.Version;
                row["Titulo"] = articulo.Titulo;
                row["Descripcion"] = articulo.Descripcion;
                row["Creado"] = articulo.FecCreacion.ToShortDateString();
                dt.Rows.Add(row);
            }
            return dt;
        }
        else
        {
            lblResultado.Visible = true;
            return null;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            string vers = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            Response.Redirect("ConsultarArticuloWiki.aspx?V=" + vers + "&C=" + id);
        }

        if (e.CommandName == "E")
        {
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            Usuario usu = (Usuario)Session["Usuario"];

            if (ApuntesWikiFactory.Eliminar(usu.Id,int.Parse(id.ToString())))
                Response.Redirect("WikiMusic.aspx?Z=1");
            else Response.Redirect("WikiMusic.aspx?Z=0");
            
        }

    }

}

