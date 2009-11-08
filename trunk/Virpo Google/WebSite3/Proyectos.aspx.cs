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

public partial class Proyectos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string restriccion = "";
            if (Request.QueryString["filtro"] != null)
            {
                string filtro = Request.QueryString["filtro"];
                ViewState.Add("Filtro", filtro);
                restriccion = "WHERE nombre like '%" + filtro + "%' or descripcion like '%" + filtro + "%'";
            }
            DataTable dt = this.DatosProyectos(restriccion);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState.Add("SortExpression", "Creado");
            ViewState.Add("SortDirection", "DESC");
            GridView1.Columns[0].Visible = false;
        }
    }

    string GridSortDirection
    {
        get { return ViewState["SortDirection"].ToString(); }
        set { ViewState["SortDirection"] = value; }
    }

    string GridSortExpression
    {
        get { return ViewState["SortExpression"].ToString(); }
        set { ViewState["SortExpression"] = value; }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("Proyecto.aspx?Id=" + id);
        }
    }
    private DataTable DatosProyectos(string restriccion)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Genero");
        dt.Columns.Add("Creado");

        List<CapaNegocio.Entities.Proyecto> proyectos = new List<CapaNegocio.Entities.Proyecto>();
        proyectos = (List<CapaNegocio.Entities.Proyecto>) ProyectoFactory.DevolverTodos(restriccion);
        if (proyectos != null)
        {
            foreach (CapaNegocio.Entities.Proyecto proyecto in proyectos)
            {
                row = dt.NewRow();
                row["Imagen"] = proyecto.Imagen;
                row["Nombre"] = proyecto.Nombre;
                row["Id"] = proyecto.Id;
                row["Creado"] = proyecto.FechaCreacion.ToShortDateString();
                dt.Rows.Add(row);
            }
            return dt;
        }
        else
        {
            lblResultados.Visible = true;
            return null;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string restriccion = "";
        if (ViewState["Filtro"] != null)
        {
            string filtro = ViewState["Filtro"].ToString();
            restriccion = "WHERE nombre like '%" + filtro + "%'";
        }
        DataTable dt = this.DatosProyectos(restriccion);
        DataView dv = dt.DefaultView;

        dv.Sort = GridSortExpression + " " + GridSortDirection;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string restriccion = "";
        if (ViewState["Filtro"] != null)
        {
            string filtro = ViewState["Filtro"].ToString();
            restriccion = "WHERE nombre like '%" + filtro + "%'";
        }
        DataTable dt = this.DatosProyectos(restriccion);
        DataView dv = dt.DefaultView;

        GridSortDirection = GridSortDirection == "ASC" ? "DESC" : "ASC";
        dv.Sort = e.SortExpression + " " + GridSortDirection;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
}
