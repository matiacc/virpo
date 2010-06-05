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

public partial class musicamania_Virpo : System.Web.UI.MasterPage
{
    //public string mp3_seleccionado = "";
    //public string mp3_seleccionado_titulo = "";
    //public string reproducir = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            hlBandeja.Visible = true;
            hlNombreUsuario.Text = ((Usuario)Session["Usuario"]).Nombre;
            hlNombreUsuario.ForeColor = System.Drawing.Color.DarkOrange;
            hlNombreUsuario.NavigateUrl = "Perfil.aspx";
            hlinkIniciarSesion.Text = "(Cerrar Sesion)";
            hlinkIniciarSesion.NavigateUrl = "inicio.aspx?Logout=1";
            int mensajes = BandejaDeEntradaFactory.HayMensajesEnBandejaDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));
            if (mensajes != 0)
            {
                //hlBandeja.Visible = true;
                imgMail.Src = "ImagenesSite/conmensajes.png";
                hlBandeja.ToolTip = "Tiene " + mensajes + " mensajes sin leer en la Bandeja de Entrada.";
            }
            else
                imgMail.Src = "ImagenesSite/sinmensajes.png";

        }
        else
            hlBandeja.Visible = false;
        
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string filtro = txtFiltro.Text.Trim();
        switch (ddlBuscarPor.SelectedValue)
        {
            case "Banda":
                Response.Redirect("Bandas.aspx?filtro=" + filtro);
                break;
            case "Clasificado":
                Response.Redirect("Clasificados.aspx?filtro=" + filtro);
                break;
            case "Proyecto":
                Response.Redirect("Proyectos.aspx?filtro=" + filtro);
                break;
            default:
                break;
        }
    }
}
