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

public partial class ConsultarClasificado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            //Cambia el estado a leido cuando es consultado por la administración de denuncias.
            if (Request.QueryString["leida"] != null)
            {
                DenunciaFactory.ModificarLeida(int.Parse(Request.QueryString["leida"].ToString()));
                ClientScript.RegisterStartupScript(typeof(String), "RefrescaDenunciasLeidas", "window.opener.location.reload()", true);
            }
            //Fin

            if (DenunciaFactory.HayDenuncia(Convert.ToInt32(Request.QueryString["C"]), "AvisoClasificado") != 0)
            {
                btnDenunciar.Text = "Denunciado";
                btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
                btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
                btnDenunciar.Enabled = false;
            }

            int id = Convert.ToInt32(Request.QueryString["C"]);
            Session["idAviso"] = id;
            lblContactar.Text = "<a href='javascript:abrirPopup(" + id + ")' class='estiloLabelCabeceraPeque'>Contactar con el vendedor</a>";
            Session["urlClasificado"] = Request.Url.ToString();
            lblRecomendar.Text = "<a href='javascript:abrirPopup2()' class='estiloLabelCabeceraPeque'>Recomendar Aviso</a>";
            AvisoClasificado aviso = AvisoClasificadoFactory.Devolver(id);
            Session["idVendedor"] = aviso.Dueño.Id;
            lblDescripcion.Text = aviso.Descripcion;
            lblFin.Text = aviso.FechaFin.ToShortDateString();
            lblInicio.Text = aviso.FechaInicio.ToShortDateString();
            lblPrecio.Text = "$ " + aviso.Precio.ToString();
            for (int i = 0; i < aviso.Imagen.Count; i++)
            {
                if (i > 0)
                    lblImagen.Text += "<a href='" + aviso.Imagen[i] + "' rel='lightbox[aviso]' title='" + aviso.Titulo + "' style='display:none;'>" +
                                "<img src='" + aviso.Imagen[i] + "' border='0' alt='' style='width: 200px; height: 200px;'/></a>";
                else
                    lblImagen.Text += "<a href='" + aviso.Imagen[i] + "' rel='lightbox[aviso]' title='" + aviso.Titulo + "'>" +
                                "<img src='" + aviso.Imagen[i] + "' border='0' alt='' style='width: 200px; height: 200px;'/></a>";
            }

            lblRubro.Text = aviso.Rubro.Nombre;
            lblTitulo.Text = aviso.Titulo;
            lblUbicacion.Text = aviso.Ubicacion;
            lblVendedor.Text = "<a href='PerfilPublico.aspx?Id=" + aviso.Dueño.Id + "'>" + aviso.Dueño.NombreUsuario + "</a>";
            lblVisitas.Text = AvisoClasificadoFactory.IncrementarVisita(aviso.Id).ToString();
            lblImprimir.Text = "<a href='javascript:window.print();'>Imprimir</a>";

            CargarMensajes(id);
        }
        //No se muestra contactar con el vendedor si el aviso consultado es publicado por el que se logueo
        if (Session["idVendedor"] != null)
            if (Convert.ToInt32((Session["idVendedor"])) == ((Usuario)Session["Usuario"]).Id)
            {
                lblContactar.Visible = false;
                //Muestro la grilla de mensajes nuevos al creador del anuncio
                this.CargarGrillaMensajesNuevos((Convert.ToInt32(Session["idAviso"])));
                lblMensajesNuevos.Visible = true;
                if (GridView2.Rows.Count == 0)
                {
                    lblMensajesNuevos.Text = "No tiene mensajes nuevos";
                }
                else
                {
                    lblMensajesNuevos.CssClass = "estiloLabelCabeceraPeque";
                    lblMensajesNuevos.Text = "Tiene mensajes Nuevos";
                }
            }

    }

    private void CargarGrillaMensajesNuevos(int idAviso)
    {
        List<Mensaje> mensajes = new List<Mensaje>();
        mensajes = MensajeFactory.MensajesNuevos(idAviso);

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
                if (mensaje.Msj.Length > 30)
                    row["Mensaje"] = mensaje.Msj.Remove(30) + "...";
                else
                    row["Mensaje"] = mensaje.Msj;
                dt.Rows.Add(row);
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            //Panel1.Visible = true;
            Panel2.Visible = false;
        }
        //else
        //    Panel1.Visible = false;
    }

    private void CargarMensajes(int idAviso)
    {
        gvMensajes.DataSource = MensajeFactory.DevolverMensajesDeAviso(idAviso);
        gvMensajes.DataBind();
    }
    protected void btnDenunciar_Click(object sender, EventArgs e)
    {
        if (btnDenunciar.Text == "Denunciar")
        {
            btnDenunciar.Text = "Denunciado";
            btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
            btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
            btnDenunciar.Enabled = false;

            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            Denuncia denuncia = new Denuncia();
            denuncia.IdDenunciante = (int)usr.Id;
            denuncia.UsrDenunciante = usr.NombreUsuario.ToString();
            denuncia.Url = Request.Url.ToString().Substring(Request.Url.ToString().LastIndexOf('/') + 1);
            denuncia.Descripcion = lblTitulo.Text.ToString();
            denuncia.Tipo = "Avisos Clasificados";
            denuncia.Fecha = DateTime.Now;
            denuncia.IdDocDenunciado = Convert.ToInt32(Request.QueryString["C"]);
            denuncia.Tabla = "AvisoClasificado";

            bool ok = DenunciaFactory.Insertar(denuncia);
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Consultar")
        {
            try
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
            catch { }
        }
        else if (GridView2.Rows.Count > 0 && e.CommandName == "Borrar")
        {
            try
            {
                int id = Convert.ToInt32(GridView2.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[0].Text);
                MensajeFactory.Eliminar(Convert.ToInt32(id));
                Response.Redirect("ConsultarClasificado.aspx?C=" + Session["idAviso"]);
            }
            catch {}
            CargarMensajes(Convert.ToInt32(Session["idAviso"]));
        }
    }

    protected void btResponder_Click(object sender, EventArgs e)
    {
        int idMsj = (int)Session["IdMsjSeleccionado"];
        int idUserDestinatario = (int)Session["IdUsuarioSeleccionado"];
        Usuario userDestinatario = new Usuario();
        userDestinatario = UsuarioFactory.Devolver(idUserDestinatario);
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
        bande.AvisoMotivo = "Respuesta";
        bande.IdGrupo = 0;
        bande.IdProyecto = 0;
        BandejaDeEntradaFactory.Insertar(bande);

        int reg = CapaDatos.BDUtilidades.EjecutarNonQuery(query);
        if (reg > 0)
        {
            EnviarMail.Mande("Virpo", userDestinatario.EMail, asunto, mensaje);
            AlertJS("La respuesta se ha enviado con éxito");
        }
        //else
          //  AlertJS("Hubo un error al intentar enviar la respuesta.\nIntente nuevamente mas tarde.");

        Response.Redirect("ConsultarClasificado.aspx?C=" + Session["idAviso"]);
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string id = GridView2.Rows[e.RowIndex].Cells[0].Text;
    //    AvisoClasificadoFactory.Eliminar(Convert.ToInt32(id));
    //    Response.Redirect("ConsultarClasificado.aspx?C=" + Session["idAviso"]);
    //}
}