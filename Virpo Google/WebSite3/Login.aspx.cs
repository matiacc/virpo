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

public partial class Login : System.Web.UI.Page
{
    private bool volver = false;
    string back = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Request.QueryString["url"] != null)
            {
                back = Request.QueryString["url"];
                volver = true;
            }
        }
        else
        {
            Button buttonLogin = LoginVirpo.FindControl("LoginButton") as Button;
            Page.Master.Page.Form.DefaultButton = buttonLogin.UniqueID;
        }
        if (Request.QueryString["var"] != null)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Purple;
            lblMensaje.Text = "Se ha registrado con exito. Ingrese su Nombre de usuario y Contraseña";
        }
    }
    protected void LoginVirpo_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            //Si el usuario está autenticado?
            if (Seguridad.ValidarUsuario(LoginVirpo.UserName, LoginVirpo.Password))
            {
                //Obtiene un string con todos los roles
                string roles = Seguridad.ObtenerRoles(LoginVirpo.UserName);
                //Crear un ticket de autenticación
                FormsAuthenticationTicket autTicket = new FormsAuthenticationTicket(1, LoginVirpo.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, roles);
                //Encriptar el ticket
                string encrTicket = FormsAuthentication.Encrypt(autTicket);
                // Crea una cookie con el ticket encriptado
                HttpCookie autCookie = new HttpCookie(".VirpoCookie", encrTicket);
                // Agrega la cookie a la Response
                Response.Cookies.Add(autCookie);
                CapaNegocio.Entities.Usuario usu = new CapaNegocio.Entities.Usuario();
                usu = CapaNegocio.Factories.UsuarioFactory.Devolver(LoginVirpo.UserName);
                Session["Usuario"] = usu;
                Session["Rol"] = roles;
                //((Label)hdMaster.FindControl("lnkSesion")).Text = "(Cerrar Sesion)";
                // Redirecciona al usuario a la página que solicitó originalmente
                if (volver)
                    Response.Redirect("./" +back,false);
                else
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(LoginVirpo.UserName, false), false);
            }
            else LoginVirpo.FailureText = "No tiene autorización para ingresar. Debe registrarse y luego ingresar";
        }
        catch (Exception ex)
        {
            // lblMensaje.Text = "Ocurrio un error " + ex.Message;
        }

    }
    
}
