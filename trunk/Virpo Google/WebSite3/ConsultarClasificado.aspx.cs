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
            lblContactar.Text = "<a href='javascript:abrirPopup(" + id + ")' class='estiloLabelCabeceraPeque'>Contactar con el vendedor</a>";
            Session["urlClasificado"] = Request.Url.ToString();
            lblRecomendar.Text = "<a href='javascript:abrirPopup2()' class='estiloLabelCabeceraPeque'>Recomendar Aviso</a>";
            AvisoClasificado aviso = AvisoClasificadoFactory.Devolver(id);
            Session["Aviso"] = aviso;
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
        if (Session["Aviso"] != null)
            if (((AvisoClasificado)Session["Aviso"]).Dueño.Id == ((Usuario)Session["Usuario"]).Id)
                lblContactar.Visible = false;

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
}