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

public partial class musicamania_Virpo : System.Web.UI.MasterPage
{
    //public string mp3_seleccionado = "";
    //public string mp3_seleccionado_titulo = "";
    //public string reproducir = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            lblNombreUsuario.Text = ((Usuario)Session["Usuario"]).Nombre;
            lblNombreUsuario.ForeColor = System.Drawing.Color.DarkOrange;
            hlinkIniciarSesion.Text = "(Cerrar Sesion)";
            hlinkIniciarSesion.NavigateUrl = "inicio.aspx?Logout=1";
        }
        
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string filtro = txtFiltro.Text.Trim();
        switch (ddlBuscarPor.SelectedValue)
        {
            case "Banda":
                Response.Redirect("BuscarBanda.aspx?filtro=" + filtro);
                break;
            case "Clasificado":
                Response.Redirect("Clasificados.aspx?filtro=" + filtro);
                break;
            case "Composicion":
                Response.Redirect("BuscarComposicion.aspx?filtro=" + filtro);
                break;
            default:
                break;
        }
    }
}
