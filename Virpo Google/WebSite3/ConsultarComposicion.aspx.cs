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

public partial class _Default : System.Web.UI.Page
{
    int idU;
    protected string mp3_seleccionado = "";
    protected string mp3_seleccionado_titulo = "";
    protected string reproducir = "no";

    protected void Page_Load(object sender, EventArgs e)
    {
        mp3_seleccionado = "";
        mp3_seleccionado_titulo = "";
        reproducir = "no";

       


            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            int id = Convert.ToInt32(Request.QueryString["C"]);
            Composicion comp = ComposicionFactory.Devolver(id);

            if (comp.Tipo != null)
                lblTipo.Text = comp.Tipo;
            else
                lblTipo.Text = "Tipo No definido";

            if (comp.Nombre != null)
                lblNombre.Text = comp.Nombre;
            else
                lblTipo.Text = "Nombre No definido";

            if (comp.Descripcion != null)
                lblDescripcion.Text = comp.Descripcion;
            else
                lblTipo.Text = "Sin descripción";

            lblTonalidad.Text = comp.Tonalidad.Nombre;
            lblInstrumento.Text = comp.Instrumento.Nombre;

            

       

        Usuario u = (Usuario)Session["Usuario"];

        idU = comp.Usuario.Id;

        if (u.Id != idU)
        {

            ImageButton1.ImageUrl = "./ImagenesUsuario/" + comp.Usuario.Imagen;
            lblAutor.Text = comp.Usuario.NombreUsuario;

        }
        else
        {
            Label8.Visible = false;
            ImageButton1.Visible = false;
            
        }



    }

    private void CargarFoto(Composicion comp)
    {
        string html = "<table>";

        html += "<td>";
        html += "<a href='PerfilPublico.aspx?Id=" + comp.Usuario.Id + "' title='" + comp.Usuario.NombreUsuario + "'>" +
        "<img src='./ImagenesUsuario/" + comp.Usuario.Imagen + "' width='20' border='0' height='10'></a>";
        html += "</td>";
        html += "</table>";
        lblAutor.Text = html;
    }








    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        

        Response.Redirect("PerfilPublico.aspx?Id=" +idU);

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["C"]);
        Composicion comp = ComposicionFactory.Devolver(id);

        this.mp3_seleccionado = comp.Audio;
        this.mp3_seleccionado_titulo = comp.Nombre;
        this.reproducir = "yes";
        this.Page.DataBind();
        pnlReproductor.Visible = true;



    }
}
