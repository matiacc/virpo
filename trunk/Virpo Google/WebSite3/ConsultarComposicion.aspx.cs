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
using System.Drawing;

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

            if (comp.Tipo == "Finalizada") lblTipo.ForeColor = Color.Red; ;
                
                lblTipo.Text = comp.Tipo;
 
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
            lblTempo.Text = comp.Tempo;
            

       

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
        if (u.Id!= ComposicionFactory.DevolverIdMusicoProyecto(comp.Id) || comp.Tipo =="Finalizada")
        {
            Label9.Visible = false;
            btnFinalizar.Visible = false;
            
        }





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
    protected void Button1_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["C"]);
        ComposicionFactory.Finalizar(id);
        Response.Redirect("ConsultarComposicion.aspx?C=" + id);

    }
}
