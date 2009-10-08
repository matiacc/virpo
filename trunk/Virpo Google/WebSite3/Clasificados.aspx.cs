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

public partial class _Default : System.Web.UI.Page
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
                restriccion = "WHERE titulo like '%" + filtro + "%' or descripcion like '%" + filtro + "%'";
            }
            DataTable dt = this.DatosClasificados(restriccion);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState.Add("SortExpression", "Fecha Fin");
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
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("ConsultarClasificado.aspx?C=" + id);
        }
    }

    private DataTable DatosClasificados(string restriccion)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Precio");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Fecha Fin");
        dt.Columns.Add("Ubicacion");
        dt.Columns.Add("Vendedor");

        List<AvisoClasificado> avisos = new List<AvisoClasificado>();
        avisos = AvisoClasificadoFactory.DevolverTodos(restriccion);
        if (avisos != null)
        {
            foreach (AvisoClasificado aviso in avisos)
            {
                //Si ya paso la fecha fin seteo el estado del aviso en 3 - Finalizado -
                if (aviso.FechaFin < DateTime.Now)
                {
                    AvisoClasificadoFactory.CambiarEstado(aviso.Id, 3);
                }
                else
                {
                    row = dt.NewRow();
                    row["Imagen"] = ResolveUrl("~/Imagenes/") + aviso.ImagenThumb;
                    row["Precio"] = "$ " + aviso.Precio;
                    row["Titulo"] = aviso.Titulo;
                    row["Id"] = aviso.Id;
                    if (aviso.Dueño != null)
                        row["Vendedor"] = aviso.Dueño.NombreUsuario;
                    row["Ubicacion"] = aviso.Ubicacion;
                    row["Fecha Fin"] = aviso.FechaFin.ToShortDateString();
                    dt.Rows.Add(row);
                }
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
        DataTable dt = this.DatosClasificados(restriccion);
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
            restriccion = "WHERE titulo like '%" + filtro + "%' or descripcion like '%" + filtro + "%'";
        } 
        DataTable dt = this.DatosClasificados(restriccion);
        DataView dv = dt.DefaultView;
        
        GridSortDirection = GridSortDirection == "ASC" ? "DESC" : "ASC";
        dv.Sort = e.SortExpression + " " + GridSortDirection;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
}
