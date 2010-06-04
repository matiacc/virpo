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
using System.IO;

public partial class NuevaComposicion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("ErrorAutentificacion.aspx");

            if (Request.QueryString["idProyecto"] != null)
                ViewState.Add("idProyecto", Request.QueryString["idProyecto"]);

            MetodosComunes.cargarTipoInstrumentos(ddlTipo);
            MetodosComunes.cargarTonalidades(ddlTonalidad);
            ddlInstrumento.Items.Add("Seleccione el Tipo");
            //trInstrumentos.Visible = false;
        }

    }
    protected void btGuardar_Click(object sender, EventArgs e)
    {
        Composicion composicion = new Composicion();

        composicion.Nombre = txtNombre.Text;
        composicion.Descripcion = txtDescripcion.Text;
        if(RadioButton1.Checked)
            composicion.Tipo = "Pista";
        if (RadioButton2.Checked)
            composicion.Tipo = "Cancion No Terminada";
        
        composicion.Tempo = txtTempo.Text;
        composicion.Usuario = (Usuario)Session["Usuario"];
        if (ddlTonalidad.SelectedIndex == 0)
        {
            lblTonalidad.Visible = true;
            return;
        }
        else
        {
            composicion.Tonalidad = TonalidadFactory.Devolver(Convert.ToInt32(ddlTonalidad.SelectedValue));
            lblTonalidad.Visible = false;
        }
        if (ddlTipo.Text != "5")
            composicion.Instrumento = InstrumentoFactory.Devolver(Convert.ToInt32(ddlInstrumento.SelectedValue));
        else
            composicion.Instrumento = InstrumentoFactory.Devolver(6);

        string path = FileUpload1.PostedFile.FileName;
        if(!this.CargarAudio(path))
            AlertJS("Error al cargar la composición");
        
        composicion.Audio = path;
        bool a = ComposicionFactory.Insertar(composicion);
        int idProyecto = Convert.ToInt32(ViewState["idProyecto"]);
        bool b = ProyectoFactory.InsertarComposicionXProyecto(ComposicionFactory.DevolverIdComposicionCreada(composicion.Usuario.Id), idProyecto, DateTime.Now);

        if (a && b)
            Response.Redirect("./Proyecto.aspx?Id=" + idProyecto);
            //Panel1_ModalPopupExtender.Show();
        else
            AlertJS("Error al cargar la composición");
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }


    private bool CargarAudio(string filename)
    {
        try
        {
            //TODO: ponerle un nombre unico
            string serverPath = Server.MapPath(@"./Composiciones/");
            string rutaCompleta = serverPath + filename;
            FileUpload1.PostedFile.SaveAs(rutaCompleta);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipo.SelectedIndex > 0)
        {
            if (ddlTipo.Text != "5")
            {
                tdInstrumento.Visible = true;
                ddlInstrumento.Visible = true;
                ddlInstrumento.Items.Clear();
                MetodosComunes.cargarInstrumentos(ddlInstrumento, ddlTipo.SelectedValue);
            }
            else
            {
                RadioButton2.Checked = true;
                tdInstrumento.Visible = false;
                ddlInstrumento.Visible = false;
            }
        }
        else
            ddlInstrumento.Items.Clear();
    }
     protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Proyecto.aspx?Id=" + ViewState["idProyecto"].ToString());
    }
     //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
     //{
     //    trInstrumento.Visible = true;
     //    trInstrumento2.Visible = true;
     //    trInstrumentos.Visible = false;
     //}
     //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
     //{
     //    trInstrumento.Visible = false;
     //    trInstrumento2.Visible = false;
     //    trInstrumentos.Visible = true;
     //}
}
