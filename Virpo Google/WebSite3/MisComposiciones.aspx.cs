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
                //Label1.Visible = false;
                DataTable dt = this.DatosCancionesTerminadas();
                GridView1.Columns[5].Visible = true;

                GridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    Label2.Visible = true;
                    Label2.Text = "No hay canciones terminadas";
                }
                pnlReproductor.Visible = true;
                GridView1.DataBind();
                GridView1.Columns[5].Visible = false;
            }
            else
                this.CargarComposiciones();
            
        }
    }

    private void CargarComposiciones()
    {
        DataTable dt = this.DatosComposiciones();
        GridView1.Columns[5].Visible = true;
        
        GridView1.DataSource = dt;
        if (dt.Rows.Count==0) Label2.Visible = true;
        pnlReproductor.Visible = true;
        GridView1.DataBind();
        GridView1.Columns[5].Visible = false;

    }


    private DataTable DatosComposiciones()
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Ruta");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Tipo");
        dt.Columns.Add("Instrumento");
        //dt.Columns.Add("Ruta2");
        dt.Columns.Add("Id");
        
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
                    row["Instrumento"] = "Instrumento No definido";
                
                if (composicion.Tipo != null)
                    row["Tipo"] = composicion.Tipo;
                else
                    row["Tipo"] = "Tipo No definido";
                //row["Ruta2"] = "./Composiciones/" + composicion.Audio;
                row["Id"] = composicion.Id;

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
        //dt.Columns.Add("Ruta2");
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
                //row["Ruta2"] = "./Composiciones/" + composicion.Audio;
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
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[5].Text;
            ComposicionFactory.Eliminar(Convert.ToInt32(id));
            Response.Redirect("MisComposiciones.aspx");
        }
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[5].Text;
            Response.Redirect("ConsultarComposicion.aspx?C=" + id);
        }
        if (e.CommandName == "P")
        {
            this.mp3_seleccionado = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[4].Text;
            this.mp3_seleccionado_titulo = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[1].Text;
            this.reproducir = "yes";

            this.Page.DataBind();
            this.CargarComposiciones();
        }




    }
    
}
