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

public partial class popupRecomendar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
    }
    protected void btEnviar_Click(object sender, EventArgs e)
    {
        string asunto = "Virpo: Recomendacion de un Aviso Clasificado";
        string url = Convert.ToString(Session["urlClasificado"]);
        Usuario usuario = (Usuario) Session["Usuario"];
        string mensaje = "Hola!!!<br />El usuario <b>" + usuario.NombreUsuario + "</b> te recomendó un artículo. Sigue el siguiente vínculo para averiguar de que se trata.<br /><br /><a href='" + url + " '>Virpo Web</a><br /><br /><br />";
        mensaje += txtMensaje.Text.Trim();
        string[] mails = txtPara.Text.Split(',');
        int i = 0;
        foreach (string mail in mails)
        {
            if (i == 5) break;   
            EnviarMail.Mande("Virpo", mail, asunto, mensaje);
            i++;
        }
        if (i > 0)
          AlertJS("El mensaje se ha enviado con éxito");

        string cierra = "<script language='javaScript'>" +
                     "window.close();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "cierra", cierra);
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
}
