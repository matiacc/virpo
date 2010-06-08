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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            hlNombreUsuario.Text = ((Usuario)Session["Usuario"]).Nombre;
            hlNombreUsuario.ForeColor = System.Drawing.Color.Purple;
            hlNombreUsuario.NavigateUrl = "Perfil.aspx";
            hlinkIniciarSesion.Text = "(Cerrar Sesion)";
            hlinkIniciarSesion.NavigateUrl = "admin.aspx?Logout=1";
        }
    }

  
}
