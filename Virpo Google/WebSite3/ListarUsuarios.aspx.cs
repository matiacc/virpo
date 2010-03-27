using System;
using System.Collections;
using System.Collections.Generic;
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


public partial class ListarUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            Usuario usr = new Usuario();
            usr=(Usuario)Session["Usuario"];
            MetodosComunes.cargarMisBandas(ddlMisBandas, int.Parse(usr.Id.ToString()));
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Id");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Instrumento");
            dt.Columns.Add("Imagen");

            List<Usuario> usuarios = new List<Usuario>();
            usuarios = UsuarioFactory.DevolverTodos();
            foreach (Usuario usuario in usuarios)
            {
                row = dt.NewRow();
                row["Id"] = usuario.Id;
                row["Usuario"] = usuario.NombreUsuario;
                row["Instrumento"] = InstrumentoFactory.Devolver(usuario.IdInstrumento).Nombre;
                if (!string.IsNullOrEmpty(usuario.ImagenThumb))
                    row["Imagen"] = ResolveUrl("~/ImagenesUsuario/") + usuario.ImagenThumb;
                else
                    row["Imagen"] = "ImagenesSite/user_no_avatar.gif";
                
                dt.Rows.Add(row);
                
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
        if (e.CommandName == "C")
            Response.Redirect("ConsultarClasificado.aspx?C=" + id);
    }
    protected void btEnviarInvitacion_Click(object sender, EventArgs e)
    {
        List<int> ids = new List<int>();
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)row.Cells[4].Controls[1];
            if(chk != null)
                if (chk.Checked)
                {
                    ids.Add(Convert.ToInt32(row.Cells[0].Text));
                }
        }
        if (ids != null)
        {
            int enviados = 0;
            foreach (int id in ids)
            {
                //Usuario remitente = new Usuario();
                //remitente = (Usuario)Session["Usuario"];
                //
                //Falta insertar los músico agregados a la banda
                //
        	    Usuario destinatario = new Usuario();
                destinatario = UsuarioFactory.Devolver(id);
                string banda = ddlMisBandas.Items[ddlMisBandas.SelectedIndex].Text;
                string idBanda = ddlMisBandas.SelectedValue;
                //Mensaje msj = new Mensaje();
                //msj.Msj = txtMensaje.Text.Trim();
                //msj.Fecha = DateTime.Now;
                //msj.Remitente = remitente;
                //Tengo que guardar el mensaje en otra tabla, para poder diferenciar los mensajes de clasificados de los de invitaciones a bandas
                string asunto = "Virpo: Usted ha sido invitado para participar de la nueva comunidad musical!!!";
                string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/Login.aspx?url=Bandeja.aspx";//Idbanda
                //string url = "http://127.0.0.1:50753/WebSite3/Invitaciones.aspx?Id=" + idBanda;//Idbanda
                string mensaje = "Hola <b>" + destinatario.Nombre + "</b>.<br /><br />Ha sido invitado para formar parte de la banda <b>"+ banda+ "</b>.<br />" +
                                 "Ingrese a su bandeja de entrada de Virpo: <br /><br /><a href='" + url + " '>Virpo Web</a><br /><br />";
                mensaje += "Mensaje:<br /><br />" + txtMensaje.Text.Trim(); ;
                if (EnviarMail.Mande("Virpo", destinatario.EMail, asunto, mensaje))
                    enviados++;
                //Registrar las invitaciones en la tabla "Invitacion"
                BandejaDeEntrada bande = new BandejaDeEntrada();
                bande.UsrDestinatario = id;
                bande.UsrRemitente = int.Parse(((Usuario)Session["Usuario"]).Id.ToString());
                bande.Fecha = DateTime.Now;
                bande.IdBanda = int.Parse(idBanda.ToString());
                bande.IdAviso =0;
                BandejaDeEntradaFactory.Insertar(bande);
            }
            if (enviados != 0)
                AlertJS("Las invitaciones se enviaron con éxito.");
            else
                AlertJS("Hubo un error al intentar enviar las invitaciones.\nVerifique su conexion a internet.");
        }

    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
}
