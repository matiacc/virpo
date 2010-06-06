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

    protected string mp3_seleccionado = "";
    protected string mp3_seleccionado_titulo = "";
    protected string reproducir = "no";

    protected void Page_Load(object sender, EventArgs e)
    {
        mp3_seleccionado = "";
        mp3_seleccionado_titulo = "";
        reproducir = "no";
        
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            if (Request.QueryString["fin"] != null)
            {
                DataTable dt = this.DatosCancionesTerminadas();
                
                GridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    Label2.Visible = true;
                    Label2.Text = "No hay canciones finalizadas.";
                }
                else
                {
                    pnlReproductor.Visible = true;
                    GridView1.DataBind();
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    prueba.InnerText = "Canciones Finalizadas";
                }
            }
            else
                this.CargarComposiciones();
        }
    }

    private void CargarComposiciones()
    {
        DataTable dt = this.DatosComposiciones();
        
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count == 0)
        {
            Label2.Visible = true;
            pnlReproductor.Visible = false;
        }
        else
        {
            pnlReproductor.Visible = true;
            Label2.Visible = false;
        }
        GridView1.Columns[5].Visible = false;
        GridView1.Columns[8].Visible = false;
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
        dt.Columns.Add("Proyecto");

        Usuario usuario = (Usuario)Session["Usuario"];
        String a = "WHERE Composicion.idUsuario = " + Convert.ToString(usuario.Id);
        List<Composicion> composiciones = ComposicionFactory.DevolverTodos(a);

        if (composiciones != null)
        {
            foreach (Composicion composicion in composiciones)
            {
                row = dt.NewRow();
                row["Ruta"] = "./Composiciones/" + composicion.Audio;
                row["Nombre"] = composicion.Nombre;
                if (composicion.Instrumento != null)
                    row["Instrumento"] = composicion.Instrumento.Nombre;
                else
                    row["Instrumento"] = "N/A";
                
                if (composicion.Tipo != null)
                    row["Tipo"] = composicion.Tipo;
                else
                    row["Tipo"] = "N/A";
                
                row["Ruta2"] = composicion.Audio;
                row["Id"] = composicion.Id;
               CapaNegocio.Entities.Proyecto proy = ProyectoFactory.DevolverProyectoPorComposicion(composicion.Id);
                if(proy != null)
                    row["Proyecto"] = "./Proyecto.aspx?Id="+ proy.Id;
                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;
    }

    private DataTable DatosCancionesTerminadas()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Ruta");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Tipo");
        dt.Columns.Add("Instrumento");
        dt.Columns.Add("Ruta2");
        dt.Columns.Add("Id");

        string restriccion = "WHERE tipo = 'Finalizada'";
        List<Composicion> composiciones = ComposicionFactory.DevolverTodos(restriccion);

        if (composiciones != null)
        {
            foreach (Composicion composicion in composiciones)
            {
                row = dt.NewRow();
                row["Ruta"] = "./Composiciones/" + composicion.Audio;
                row["Nombre"] = composicion.Nombre;
                if (composicion.Instrumento != null)
                    row["Instrumento"] = composicion.Instrumento.Nombre;
                else
                    row["Instrumento"] = "Instrumento No definido";

                if (composicion.Tipo != null)
                    row["Tipo"] = composicion.Tipo;
                else
                    row["Tipo"] = "Tipo No definido";
                row["Ruta2"] = composicion.Audio;
                row["Id"] = composicion.Id;
                
                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;
    }
  
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[5].Text;
            Response.Redirect("ConsultarComposicion.aspx?C=" + id);
        }
        if (e.CommandName == "P")
        {
            this.mp3_seleccionado = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[8].Text;
            this.mp3_seleccionado_titulo = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[1].Text;
            this.reproducir = "yes";

            this.Page.DataBind();
            this.CargarComposiciones();
        }
        if (e.CommandName == "Proy")
        {
            int id = Convert.ToInt32(GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[5].Text);
            CapaNegocio.Entities.Proyecto proy = ProyectoFactory.DevolverProyectoPorComposicion(id);
            if (proy != null)
                Response.Redirect("Proyecto.aspx?Id=" + proy.Id);
        }
    }
    
}
