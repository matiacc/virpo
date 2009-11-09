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
            if (Request.QueryString["z"] != null)
            {
                int bandera = int.Parse(Request.QueryString["z"].ToString());
                if (bandera == 1) lblOk.Visible = true;
                if (bandera == 0) lblMal.Visible = true;
            }
            DataTable dt = this.DatosRanking();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[1].Visible = false;
        }
    }

    private DataTable DatosRanking()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Version");
        dt.Columns.Add("Posicion");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Visitas");

        
        List<ArticuloWiki> articulos = ArticuloWikiFactory.DevolverTopFive();

        if (articulos.Count  != 0)
        {
            int pos = 0;
            foreach (ArticuloWiki articulo in articulos)
            {
                pos++;
                row = dt.NewRow();
                row["Id"] = articulo.Id;
                row["Version"] = articulo.Version;
                row["Posicion"] = pos;
                row["Titulo"] = articulo.Titulo;
                row["Visitas"] = articulo.CantVisitas;
                dt.Rows.Add(row);
            }
            return dt;
        }
        else
        {
            lblMal.Visible = true;
            return null;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            string vers = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            Response.Redirect("ConsultarArticuloWiki.aspx?V=" +vers  +"&C=" + id);
        }
    }
    
}
