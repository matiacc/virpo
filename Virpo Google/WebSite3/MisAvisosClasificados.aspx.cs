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

public partial class MisClasificados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            
            Usuario userRemitente = new Usuario();
            userRemitente = (Usuario)Session["Usuario"];

            this.CargarGrillaAvisos(userRemitente.Id);
            GridView1.Columns[0].Visible = false;
        }
    }

    private void CargarGrillaAvisos(int idUsuario)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Precio");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Fecha Fin");
        dt.Columns.Add("Estado");

        List<AvisoClasificado> avisos = new List<AvisoClasificado>();
        avisos = AvisoClasificadoFactory.DevolverTodosPorIdUsuario(idUsuario);
        foreach (AvisoClasificado aviso in avisos)
        {
            row = dt.NewRow();
            row["Imagen"] = aviso.Imagen[0];
            row["Precio"] = "$ " + aviso.Precio;
            row["Titulo"] = aviso.Titulo;
            row["Id"] = aviso.Id;
            row["Fecha Fin"] = aviso.FechaFin.ToShortDateString();
            row["Estado"] = aviso.Estado.Nombre;
            dt.Rows.Add(row);

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void  GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("ConsultarClasificado.aspx?C=" + id);
        }
        else if (e.CommandName == "M")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("AltaClasificado.aspx?E=" + id);
        }
    }

    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
    

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
        AvisoClasificadoFactory.Eliminar(Convert.ToInt32(id));
        Response.Redirect("MisAvisosClasificados.aspx");
    }
}
