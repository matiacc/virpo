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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["e"] != null)
            {
                if (Request.QueryString["e"].ToString() == "1") Login1.FailureText = "Debe ser Administrador o Priodista para poder ingresar.";
            }
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {        
        int existe = CapaNegocio.Factories.UsuarioFactory.DevolverEscalar(Login1.UserName, Login1.Password);
        string roles = "";
        if (existe == 0)
        {
            e.Authenticated = false;
            roles = "Anónimo";
        }
        else
        {
            roles = Seguridad.ObtenerRoles(Login1.UserName);
        }
        
        if ((roles == "Administrador" || roles == "Periodista") && existe != 0)
        {
            Session["UsuarioAdmin"] = CapaNegocio.Factories.UsuarioFactory.Devolver(Login1.UserName);
            e.Authenticated = true;
        }
        else if (roles == "Anónimo") Login1.FailureText = "Debe registrarse para poder ingresar.";
        else Login1.FailureText = "Debe ser Administrador o Priodista para poder ingresar.";
    }
}
