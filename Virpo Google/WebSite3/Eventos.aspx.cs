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
using Subgurim.Controles;
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

            this.CargarEventos();



        }
       
        
        


    }

    private void CargarEventos()
    {

        DataTable dt = this.DatosEventos();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Columns[0].Visible = false;
                
                          
        
    }


    private DataTable DatosEventos()
    {

        DataTable dt = new DataTable();
        DataRow row;

        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Fecha");
        dt.Columns.Add("Lugar");
        dt.Columns.Add("Consultar");
        

        
        List<Evento> eventos = EventoFactory.DevolverTodos("");

        if (eventos != null)
        {
            foreach (Evento evento in eventos)
            {
                row = dt.NewRow();
                row["Id"] = evento.Id;
                row["Imagen"] = evento.Imagen;
                row["Nombre"] = evento.Nombre;
                row["Fecha"] =Convert.ToString(evento.Fecha.Day) + "/" + Convert.ToString(evento.Fecha.Month) + "/" + Convert.ToString(evento.Fecha.Year);
                row["Lugar"] = evento.Lugar;

                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;




    }




    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("ConsultarEvento.aspx?E=" + id);
        }

    }
}
