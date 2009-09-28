﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    private string tipo = "Pista";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null)
            {
            
                Response.Redirect("ErrorAutentificacion.aspx");

            }

            if (Request.QueryString["idProyecto"] != null)
            {
                ViewState.Add("idProyecto", Request.QueryString["idProyecto"]);
            }
            
            rbtnPista.Checked = true;
            MetodosComunes.cargarTipoInstrumentos(ddlTipoInstru);
            MetodosComunes.cargarTonalidades(ddlTonalidad);
        
        
        }


    }
    
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Composicion composicion = new Composicion();
        
        composicion.Nombre = txtNombre.Text;
        composicion.Descripcion = lbxDescripcion.Text;
        composicion.Tipo = tipo;
        composicion.Tempo = txtTempo.Text;
        composicion.Usuario = (Usuario)Session["Usuario"];
        composicion.Tonalidad = TonalidadFactory.Devolver(Convert.ToInt32(ddlTonalidad.SelectedValue));
        composicion.Instrumento = InstrumentoFactory.Devolver(Convert.ToInt32(ddlInstrumento.SelectedValue));
        
        string path = "";

        if (!string.IsNullOrEmpty(uploadAudio.PostedFile.FileName))
        {            
            path = this.CargarAudio();
                        
        }
        composicion.Audio = path;
        bool a = ComposicionFactory.Insertar(composicion);
        int idProyecto = Convert.ToInt32(ViewState["idProyecto"]);
        bool b = ProyectoFactory.InsertarComposicionXProyecto(ComposicionFactory.DevolverIdComposicionCreada(composicion.Usuario.Id), idProyecto,DateTime.Now);
        
        if (a && b)
        {

            AlertJS("La composicion se registro con exito");
            //Response.Redirect("./Proyecto.aspx?Id=" + idProyecto);

        }
        else
        {
            AlertJS("Error al cargar la composición");
        }
        

        
    }

    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }


    private string CargarAudio()
    {
        try
        {
            
                string filename = (new Random()).Next(999999).ToString();
                //TODO: ponerle un nombre unico
                string serverPath = Server.MapPath(@"./Composiciones/");
                string extension = Path.GetExtension(uploadAudio.PostedFile.FileName).ToLower();
                string rutaCompleta = serverPath + filename + extension;
                string nombreCompleto = filename + extension;
                uploadAudio.PostedFile.SaveAs(rutaCompleta);
                
                return nombreCompleto;
            
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }



    protected void ddlTipoInstru_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlInstrumento.Items.Clear();
        MetodosComunes.cargarInstrumentos(ddlInstrumento,ddlTipoInstru.SelectedValue);
        
    }
    protected void ddlTonalidad_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rbtnPista_CheckedChanged(object sender, EventArgs e)
    {
        tipo = "Pista";
    }
    protected void rbtnNoTerm_CheckedChanged(object sender, EventArgs e)
    {
        tipo = "Canción no terminada";
    }
    protected void rbtnCanción_CheckedChanged(object sender, EventArgs e)
    {
        tipo = "Canción";
    }
}