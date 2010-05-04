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
            if (Request.QueryString["c"] != null)
            {
                int bandera = int.Parse(Request.QueryString["c"].ToString());
                if (bandera == 1) lblOk.Visible = true;
                if (bandera == 0) lblMal.Visible = true;
            }
            DataTable dt = this.DatosNoticiasVigentes();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    private DataTable DatosNoticiasVigentes()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("FechaCreacion");
        dt.Columns.Add("Descripcion");
        dt.Columns.Add("Posicion");
        dt.Columns.Add("IdAutor");


        List<Noticia> vigentes = NoticiasFactory.DevolverVigentes();

        if (vigentes != null && vigentes.Count != 0)
        {
            int pos = 0;
            foreach (Noticia noticia in vigentes)
            {
                pos++;
                row = dt.NewRow();
                row["Id"] = noticia.Id;
                row["FechaCreacion"] = noticia.FechaCreacion.ToShortDateString();
                row["Descripcion"] = noticia.Descripcion;
                row["Posicion"] = noticia.Posicion;
                row["IdAutor"] = noticia.IdAutor.Apellido + " " + noticia.IdAutor.Nombre;
                dt.Rows.Add(row);
            }
            return dt;
        }
        else
        {
            return null;
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            int id = Convert.ToInt32(GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

            Noticia noticia = NoticiasFactory.Devolver(id);
            noticia.EsVigente = 0;
            if(NoticiasFactory.Modificar(noticia))
                Response.Redirect("BajasNoticias.aspx?&C=1");
            else
                Response.Redirect("BajasNoticias.aspx?&C=0");
        }

        if (e.CommandName == "M")
        {
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;            
            Response.Redirect("ModificarNoticia.aspx?&M="+id);            
        }
    }


}
