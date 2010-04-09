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
using System.Collections.Generic;

public partial class MisClasificados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            Usuario userRemitente = new Usuario();
            userRemitente = (Usuario)Session["Usuario"];

            List<Mensaje> pendientes = new List<Mensaje>();
            pendientes = MensajeFactory.HayMensajesSinResponder(userRemitente.Id);
            Session["Pendiente"] = pendientes;
            if (pendientes.Count > 0)
            {
                lnkPreguntasPendientes.Text = "Usted tiene mensajes nuevos";
                lnkPreguntasPendientes.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lnkPreguntasPendientes.Text = "No tiene mensajes nuevos";
                lnkPreguntasPendientes.ForeColor = System.Drawing.Color.Black;
            }

            this.CargarGrillaAvisos(userRemitente.Id);
            GridView1.Columns[0].Visible = false;
        }
    }

    private void CargarGrillaAvisos(int idUsuario)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Id");
        dt.Columns.Add("Imagen");
        dt.Columns.Add("Precio");
        dt.Columns.Add("Titulo");
        dt.Columns.Add("Fecha Fin");
        dt.Columns.Add("Estado");

        List<AvisoClasificado> avisos = new List<AvisoClasificado>();
        avisos = AvisoClasificadoFactory.DevolverTodosPorIdUsuario(idUsuario);
        foreach (AvisoClasificado aviso in avisos)
        {
            row = dt.NewRow();
            row["Imagen"] = aviso.Imagen[0];
            row["Precio"] = "$ " + aviso.Precio;
            row["Titulo"] = aviso.Titulo;
            row["Id"] = aviso.Id;
            row["Fecha Fin"] = aviso.FechaFin.ToShortDateString();
            row["Estado"] = aviso.Estado.Nombre;
            dt.Rows.Add(row);

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void  GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("ConsultarClasificado.aspx?C=" + id);
        }
        else if (e.CommandName == "M")
        {
            string id = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("AltaClasificado.aspx?E=" + id);
        }
    }

    protected void btResponder_Click(object sender, EventArgs e)
    {
        int idMsj = (int)Session["IdMsjSeleccionado"];
        int idUserDestinatario = (int)Session["IdUsuarioSeleccionado"];
        Usuario userDestinatario=new Usuario();
        userDestinatario=UsuarioFactory.Devolver(idUserDestinatario);
        string asunto = "Su mensaje sobre el Aviso Clasificado ha sido respondido";
        //string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/MisAvisosClasificados.aspx?Aviso=" + idMsj;
        string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/Login.aspx?url=ConsultarClasificado.aspx?C=" + ViewState["IdAviso"].ToString();
        //string url = "http://127.0.0.1:50753/WebSite3/inicio.aspx";
        string mensaje = "Han respondido su mensaje sobre el Aviso Clasificado. Ingrese a su bandeja de entrada de Virpo: <br /><br /><a href='" + url + " '>Virpo Web</a>";
        string query = "UPDATE Mensaje " +
                    "SET fechaYhoraResp = '" + DateTime.Now + "', " +
                    "respuesta = '" + txtRespuesta.Text.Trim() + "' " +
                    "WHERE id=" + idMsj;
        //Insertar en Bandeja de Entrada
        BandejaDeEntrada bande = new BandejaDeEntrada();
        bande.UsrDestinatario = userDestinatario.Id;
        bande.UsrRemitente = ((Usuario)Session["Usuario"]).Id;
        bande.Fecha = DateTime.Now;
        bande.IdBanda = 0;
        bande.IdAviso = int.Parse(ViewState["IdAviso"].ToString());
        BandejaDeEntradaFactory.Insertar(bande);

        int reg = CapaDatos.BDUtilidades.EjecutarNonQuery(query);
        if (reg > 0)
        {
            EnviarMail.Mande("Virpo", userDestinatario.EMail, asunto, mensaje);
            AlertJS("La respuesta se ha enviado con éxito");
            //Panel1.Visible = false;
            //lnkPreguntasPendientes.Text = "No tiene mensajes nuevos";
            //lnkPreguntasPendientes.ForeColor = System.Drawing.Color.Black;
            if (((List<Mensaje>)Session["Pendiente"]).Count == 1)
                Session["Pendiente"] = null;
        }
        else
            AlertJS("Hubo un error al intentar enviar la respuesta.\nIntente nuevamente mas tarde.");
        Response.Redirect("MisAvisosClasificados.aspx");

    }
    protected void lnkPreguntasPendientes_Click(object sender, EventArgs e)
    {
        List<Mensaje> mensajes = new List<Mensaje>();
        mensajes = (List<Mensaje>)Session["Pendiente"];

        if (mensajes != null)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Id");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("De");
            dt.Columns.Add("Mensaje");

            foreach (Mensaje mensaje in mensajes)
            {
                row = dt.NewRow();
                row["Id"] = mensaje.Id;
                row["Fecha"] = mensaje.Fecha.ToShortDateString();
                row["De"] = mensaje.Remitente.NombreUsuario;
                if(mensaje.Msj.Length > 30)
                    row["Mensaje"] = mensaje.Msj.Remove(30) + "..." ;
                else
                    row["Mensaje"] = mensaje.Msj;
                dt.Rows.Add(row);
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else
            Panel1.Visible = false;
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
    
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
        if (e.CommandName == "C")
        {
            int id = Convert.ToInt32(GridView2.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text);
            Mensaje mensaje = new Mensaje();
            mensaje = MensajeFactory.Devolver(id);
            Session["IdMsjSeleccionado"] = mensaje.Id;
            Session["IdUsuarioSeleccionado"] = mensaje.Remitente.Id;
            ViewState["IdAviso"] = mensaje.Aviso.Id.ToString();
            lblUsuario.Text = mensaje.Remitente.NombreUsuario;
            lblPregunta.Text = mensaje.Msj;
            Panel2.Visible = true;
            Panel2.Focus();
        }
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
        AvisoClasificadoFactory.Eliminar(Convert.ToInt32(id));
        Response.Redirect("MisAvisosClasificados.aspx");
    }
}
