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

public partial class ListarBandas : System.Web.UI.Page
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
                restriccion = "WHERE nombre like '%" + filtro + "%'";
                    // or descripcion like '%" + filtro + "%'";
            }
            DataTable dt = this.DatosBandas(restriccion);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState.Add("SortExpression", "Fecha Inicio");
            ViewState.Add("SortDirection", "DESC");
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
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            //string id = (GridView1.SelectedRow.Cells[1].Text).ToString();
            Response.Redirect("ConsultarBanda.aspx?C=" + id);
        }
    }

    private DataTable DatosBandas(string restriccion)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Genero");
        dt.Columns.Add("Fecha Inicio");
        dt.Columns.Add("Pagina Web");
        dt.Columns.Add("Localidad");

        List<Banda> bandas = new List<Banda>();
        bandas = BandaFactory.DevolverTodos(restriccion);
        if (bandas != null)
        {
            foreach (Banda banda in bandas)
            {
                row = dt.NewRow();
                row["Id"] = banda.Id;
                row["Imagen"] = ResolveUrl("~/Imagenes/") + banda.ImagenThumb;
                row["Nombre"] = banda.Nombre;
                row["Genero"] = banda.Genero.Nombre;
                row["Fecha Inicio"] = banda.FechaInicio.ToShortDateString();
                row["Pagina Web"] = banda.PaginaWeb;
                row["Localidad"] = banda.Localidad.Nombre;
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
            restriccion = "WHERE titulo like '%" + filtro + "%' or descripcion like '%" + filtro + "%'";
        }
        DataTable dt = this.DatosBandas(restriccion);
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
            //or descripcion like '%" + filtro + "%'";
        }
        DataTable dt = this.DatosBandas(restriccion);
        DataView dv = dt.DefaultView;

        GridSortDirection = GridSortDirection == "ASC" ? "DESC" : "ASC";
        dv.Sort = e.SortExpression + " " + GridSortDirection;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bandas.aspx");
    }
}
