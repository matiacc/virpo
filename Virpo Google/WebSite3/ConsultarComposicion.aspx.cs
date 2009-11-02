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
    protected void Page_Load(object sender, EventArgs e)
    {

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

        if (Session["Usuario"] != comp.Usuario) ; 
        {
            this.CargarFoto(comp);
            
        }
       




    }

    private void CargarFoto(Composicion comp)
    {
        string html = "<table>";

        html += "<td>";
        html += "<a href='PerfilPublico.aspx?Id=" + comp.Usuario.Id + "' title='" + comp.Usuario.NombreUsuario + "'>" +
        "<img src='./ImagenesUsuario/" + comp.Usuario.Imagen + "' width='100' border='0' height='70'></a>";
        html += "</td>";
        html += "</table>";
        lblAutor.Text = html;
    }
    







}
