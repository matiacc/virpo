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
        }
        int id = Convert.ToInt32(Request.QueryString["C"]);

        ArticuloWiki articulo = ArticuloWikiFactory.Devolver(id);
        lblTitulo.Text = articulo.Titulo;
        lblCat.Text = articulo.IdCat.Nombre;

        DataTable dt = this.VersionesArticulo(id);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Columns[0].Visible = false;
    }
    private DataTable VersionesArticulo(int idArt)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Version");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Descripcion");
        dt.Columns.Add("Creado");
        dt.Columns.Add("Autor");

        ArticuloWiki articuloVigente = ArticuloWikiFactory.Devolver(idArt);
        row = dt.NewRow();
        row["Id"] = articuloVigente.Id;
        row["Version"] = articuloVigente.Version;
        row["Titulo"] = articuloVigente.Titulo;
        row["Descripcion"] = articuloVigente.Descripcion;
        row["Creado"] = articuloVigente.FecCreacion.ToShortDateString();
        row["Autor"] = articuloVigente.IdAutor.Apellido+" "+articuloVigente.IdAutor.Nombre;
        dt.Rows.Add(row);

        List<HistorialWiki> versiones = HistorialWikiFactory.DevolverHistorial(idArt);
                  
            foreach (HistorialWiki version in versiones)
            {
                ArticuloWiki art = ArticuloWikiFactory.ConvertirAArticuloWiki(version);

                row = dt.NewRow();
                row["Id"] = version.IdArticulo;
                row["Version"] = version.Version;
                row["Titulo"] = version.Titulo;
                row["Descripcion"] = version.Descripcion;
                row["Creado"] = version.FecModificacion.ToShortDateString();
                row["Autor"] = art.IdAutor.Apellido+" "+art.IdAutor.Nombre;
                dt.Rows.Add(row);
            }
            return dt;      
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            string vers = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[1].Text;
            Response.Redirect("ConsultarArticuloWiki.aspx?V="+vers+"&C=" + id);
        }

    }
}
