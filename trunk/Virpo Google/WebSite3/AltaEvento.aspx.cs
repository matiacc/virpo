﻿using System;
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
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            if (Session["Usuario"] == null)
            Response.Redirect("ErrorAutentificacion.aspx");
            Usuario musico = (Usuario)Session["Usuario"];
            MetodosComunes.cargarPaises(ddlPaises);
            MetodosComunes.cargarMisBandas(ddlBandas, musico.Id);
            cargarHorasMinutos();

        }
      

        

    }


 
    public void cargarHorasMinutos()
    {
        
        for (int i = 0; i < 24; i++)
        {
            ddlHora.Items.Add(Convert.ToString(i));
	 
        }
        ddlMin.Items.Add(Convert.ToString(0));
        ddlMin.Items.Add(Convert.ToString(15));
        ddlMin.Items.Add(Convert.ToString(30));
        ddlMin.Items.Add(Convert.ToString(45));

    }



    protected void btnCargar_Click(object sender, EventArgs e)
    {

        CargarFoto();
        

    }
    private void CargarFoto()
    {
        if (FileUpload1.HasFile)
        {
            
            string filename = DateTime.Now.Millisecond.ToString();
            //TODO: ponerle un nombre unico
            string serverPath = Server.MapPath(@"./ImagenesEventos/");
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
            string rutaCompleta = serverPath + filename + extension;
            
            if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
            {
                AlertJS("El archivo seleccionado no es una imagen");
                return;
            }
            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"./ImagenesEventos/") + filename + extension);

            
            ImageMap1.ImageUrl = "./ImagenesEventos/" + filename + extension;
            
            
        }

    }

    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }




    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Evento evento = new Evento();
        evento.Nombre = txtNombre.Text;
        evento.Lugar = txtLugar.Text;
        evento.Ubicacion = ddlPaises.SelectedValue;
        evento.Fecha = Calendar1.SelectedDate;
        evento.Hora = Convert.ToDateTime(ddlHora.SelectedItem + ":" + ddlMin.SelectedItem);
        evento.Descripcion = txtDescripcion.Text;
        evento.Estado = "pendiente";
        evento.Musico = (Usuario)Session["Usuario"];
        Banda banda = new Banda();
        evento.Imagen = ImageMap1.ImageUrl;
        banda.Id = Convert.ToInt32(ddlBandas.SelectedValue);
        evento.Banda = banda;
        EventoFactory.Insertar(evento);
        
       






    }
}