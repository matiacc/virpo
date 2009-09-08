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
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Id");
            dt.Columns.Add("Imagen");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Fecha Fin");
            dt.Columns.Add("Ubicacion");
            dt.Columns.Add("Dueño");

            List<AvisoClasificado> avisos = new List<AvisoClasificado>();
            avisos = AvisoClasificadoFactory.DevolverActivos();
            foreach (AvisoClasificado aviso in avisos)
            {
                row = dt.NewRow();
                row["Imagen"] = ResolveUrl("~/Imagenes/") + aviso.ImagenThumb;
                row["Precio"] = "$ " + aviso.Precio;
                row["Titulo"] = aviso.Titulo;
                row["Id"] = aviso.Id;
                if (aviso.Dueño != null)
                    row["Dueño"] = aviso.Dueño.NombreUsuario;
                row["Ubicacion"] = aviso.Ubicacion;
                row["Fecha Fin"] = aviso.FechaFin.ToShortDateString();
                dt.Rows.Add(row);

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
        if (e.CommandName == "C")
            Response.Redirect("ConsultarClasificado.aspx?C=" + id);
    }

    
}
