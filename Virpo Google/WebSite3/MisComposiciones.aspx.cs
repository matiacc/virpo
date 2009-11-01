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
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            this.CargarComposiciones();
            
            

        }

    }

    private void CargarComposiciones()
    {
        DataTable dt = this.DatosComposiciones();

        
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Columns[6].Visible = false;

    }


    private DataTable DatosComposiciones()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Ruta");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Tipo");
        dt.Columns.Add("Instrumento");
        dt.Columns.Add("Ruta2");
        dt.Columns.Add("Id");
        
        Usuario usuario = (Usuario)Session["Usuario"];
        String a = "WHERE Composicion.idUsuario = " + Convert.ToString(usuario.Id);
        List<Composicion> composiciones = ComposicionFactory.DevolverTodos(a);

        if (composiciones != null)
        {
            foreach (Composicion composicion in composiciones)
            {
                row = dt.NewRow();
                row["Ruta"] = composicion.Audio;
                row["Nombre"] = composicion.Nombre;
                if (composicion.Instrumento != null)
                    row["Instrumento"] = composicion.Instrumento.Nombre;
                else
                    row["Instrumento"] = "Instrumento No definido";
                
                if (composicion.Tipo != null)
                    row["Tipo"] = composicion.Tipo;
                else
                    row["Tipo"] = "Tipo No definido";
                row["ruta2"] = composicion.Audio;
                row["Id"] = composicion.Id;

                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;



    }

  
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "E")
        {
           // string id = GridView1.Rows[e.RowIndex].Cells[6].Text;
           // ComposicionFactory.Eliminar(id);
            Response.Redirect("MisComposiciones.aspx");
        }
    }
}
