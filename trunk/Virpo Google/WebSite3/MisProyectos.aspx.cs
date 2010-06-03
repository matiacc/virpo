using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio.Entities;
using CapaNegocio.Factories;

public partial class MisProyectos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            DataTable dt = this.DatosProyectos(true);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            DataTable dt2 = this.DatosProyectos(false);
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            if (GridView2.Rows.Count == 0)
                lblResultadosGrilla2.Visible = true;
            else
                lblResultadosGrilla2.Visible = false;

            ViewState.Add("SortExpression", "Creado");
            ViewState.Add("SortDirection", "DESC");
            ViewState.Add("SortExpressionGrilla2", "Creado");
            ViewState.Add("SortDirectionGrilla2", "DESC");
            GridView1.Columns[0].Visible = false;
            GridView2.Columns[0].Visible = false;
        }
    }

    #region Ordenamiento y Paginacion de las grillas

    #region Propiedades

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
    string GridSortDirectionGrilla2
    {
        get { return ViewState["SortDirectionGrilla2"].ToString(); }
        set { ViewState["SortDirectionGrilla2"] = value; }
    }

    string GridSortExpressionGrilla2
    {
        get { return ViewState["SortExpressionGrilla2"].ToString(); }
        set { ViewState["SortExpressionGrilla2"] = value; }
    }

    #endregion

    #region Eventos

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = this.DatosProyectos(true);
        DataView dv = dt.DefaultView;

        dv.Sort = GridSortExpression + " " + GridSortDirection;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = this.DatosProyectos(true);
        DataView dv = dt.DefaultView;

        GridSortDirection = GridSortDirection == "ASC" ? "DESC" : "ASC";
        dv.Sort = e.SortExpression + " " + GridSortDirection;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = this.DatosProyectos(false);
        DataView dv = dt.DefaultView;

        dv.Sort = GridSortExpressionGrilla2 + " " + GridSortDirectionGrilla2;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = this.DatosProyectos(false);
        DataView dv = dt.DefaultView;

        GridSortDirectionGrilla2 = GridSortDirectionGrilla2 == "ASC" ? "DESC" : "ASC";
        dv.Sort = e.SortExpression + " " + GridSortDirectionGrilla2;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }

    #endregion

    #endregion
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("Proyecto.aspx?Id=" + id);
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView2.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("Proyecto.aspx?Id=" + id);
        }
    }

    private DataTable DatosProyectos(bool esCreador)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Genero");
        dt.Columns.Add("Creado");

        List<CapaNegocio.Entities.Proyecto> proyectos = new List<CapaNegocio.Entities.Proyecto>();
        Usuario usuario = (Usuario)Session["Usuario"];
        proyectos = (List<CapaNegocio.Entities.Proyecto>)ProyectoFactory.DevolverTodosPorUsuario(esCreador, usuario.Id);

        if (proyectos != null)
        {
            foreach (CapaNegocio.Entities.Proyecto proyecto in proyectos)
            {
                row = dt.NewRow();
                row["Imagen"] = proyecto.Imagen;
                row["Nombre"] = proyecto.Nombre;
                row["Id"] = proyecto.Id;
                row["Genero"] = proyecto.Genero;
                if (string.IsNullOrEmpty(proyecto.Genero))
                    proyecto.Genero = "N/A";
                Usuario creador = UsuarioFactory.DevolverCreadorDeProyecto(proyecto.Id);
                if (creador != null)
                    row["Creado"] = "El " + proyecto.FechaCreacion.ToShortDateString() + " por " + creador.NombreUsuario;
                else
                    row["Creado"] = proyecto.FechaCreacion.ToShortDateString();

                dt.Rows.Add(row);
            }
            return dt;
        }
        else
        {
            if (esCreador)
                lblResultados.Visible = true;
            else
                lblResultadosGrilla2.Visible = true;
            return null;
        }
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            ProyectoFactory.Eliminar(Convert.ToInt32(id));
            Response.Redirect("MisProyectos.aspx");
        }
        catch { }
    }
}
