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

public partial class popupContactarVendedor : System.Web.UI.Page
{
    private int idAviso = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        idAviso = Convert.ToInt32(Request.QueryString[0]);
    }
    protected void btEnviar_Click(object sender, EventArgs e)
    {
        Usuario remitente = new Usuario();
        remitente = (Usuario)Session["Usuario"];

        AvisoClasificado aviso = (AvisoClasificado)Session["Aviso"];
        //Usuario destinatario = UsuarioFactory.Devolver(aviso.Dueño.Id);
        
        Mensaje msj = new Mensaje();
        msj.Msj = txtMensaje.Text.Trim();
        msj.Fecha = DateTime.Now;
        AvisoClasificado soloId = new AvisoClasificado();
        soloId.Id = idAviso;
        msj.Aviso = soloId;
        msj.Remitente = remitente;
        string asunto = "Virpo: " + txtAsunto.Text;
        //string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/inicio.aspx";
        string url = "http://127.0.0.1:50753/WebSite3/inicio.aspx";
        string mensaje = "Hola <b>" + aviso.Dueño.Nombre + "</b>, te hicieron una pregunta sobre el aviso que publicaste en Virpo.<br /><br /><a href='" + url + " '>Virpo Web</a><br /><br /><br />";
        mensaje += txtMensaje.Text.Trim();
        EnviarMail.Mande("Virpo", aviso.Dueño.EMail, asunto , mensaje);
        if (MensajeFactory.Insertar(msj))
        {
            BandejaDeEntrada bande = new BandejaDeEntrada();
            bande.UsrDestinatario = aviso.Dueño.Id;
            bande.UsrRemitente = remitente.Id;
            bande.Fecha = DateTime.Now;
            bande.IdBanda = 0;
            bande.IdAviso = idAviso;
            BandejaDeEntradaFactory.Insertar(bande);

            AlertJS("El mensaje se ha enviado con éxito");
            string cierra = "<script language='javaScript'>" +
                     "window.close();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "cierra", cierra);
        }
         else
            AlertJS("Ha ocurrido un error al intentar enviar el mensaja.\nIntente nuevamente mas tarde.");
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
}
