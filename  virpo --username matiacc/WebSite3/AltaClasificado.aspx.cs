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

public partial class AltaClasificado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            MetodosComunes.cargarRubro(ddlRubro);
        }
    }
    
    protected void btGuardar_Click(object sender, EventArgs e)
    {
        AvisoClasificado aviso = new AvisoClasificado();
        aviso.Titulo = txtTitulo.Text;
        aviso.Descripcion = txtDescripcion.Text;
        aviso.Precio = Convert.ToDouble(txtPrecio.Text);
        aviso.FechaInicio = DateTime.Now;
        if(rb10dias.Checked)
            aviso.FechaFin = DateTime.Now.AddDays(10);
        if(rb20dias.Checked)
            aviso.FechaFin = DateTime.Now.AddDays(20);
        if(rb30dias.Checked)
            aviso.FechaFin = DateTime.Now.AddDays(30);
        
        Usuario mus = new Usuario();
        mus = (Usuario) Session["Usuario"];
        aviso.Dueño = mus;
        aviso.Estado = EstadoAvisoClasificadoFactory.Devolver(1); //1 Activo 2 Pendiente 3 Finalizado 4 Rechazado
        aviso.Ubicacion = txtUbicacion.Text;
        //TODO: Permitir guardar hasta 4 imagenes, como dice el CU
        string thumb = "";
        string path = this.GuardarImagen(out thumb);
        aviso.Imagen = path;
        aviso.ImagenThumb = thumb;
        Rubro rub = new Rubro();
        if (!string.IsNullOrEmpty(ddlSubrubro2.Text))
            rub.Id = Convert.ToInt32(ddlSubrubro2.SelectedValue);
        else
            if (!string.IsNullOrEmpty(ddlSubrubro1.Text))
                rub.Id = Convert.ToInt32(ddlSubrubro1.SelectedValue);
            else
                rub.Id = Convert.ToInt32(ddlRubro.SelectedValue);

        aviso.Rubro = rub;
        if (AvisoClasificadoFactory.Insertar(aviso))
        {
            AlertJS("El aviso se guardó");
        }
        else
            AlertJS("El aviso no se guardó");
        if(true)
            Response.Redirect("MisAvisosClasificados.aspx");
    }
    private string GuardarImagen(out string thumb)
    {
        try
        {
            string filename = (new Random()).Next(999999).ToString();
            //TODO: ponerle un nombre unico
            string serverPath = Server.MapPath(@"./Imagenes/");
            string extension = Path.GetExtension(uploadImagen.PostedFile.FileName).ToLower();
            string rutaCompleta = serverPath + filename + extension;
            string nombreCompleto = filename + extension;
            thumb=filename + "_Thumb" + extension;
            string imgThum;

            if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                throw new Exception("El archivo ingresado no es una imagen");

            uploadImagen.PostedFile.SaveAs(rutaCompleta);
            //TODO: Redimensionar la imagen a un tamaño fijo para que no suban giladas

            //Ahora guardo el Thumbnail
            System.Drawing.Image objImage;
            System.Drawing.Image objThumbnail;
            int shtWidth;
            int shtHeight;
            Stream my_stream = null;

            my_stream = File.OpenRead(rutaCompleta);
            objImage = System.Drawing.Image.FromStream(my_stream);
            shtWidth = 100;
            shtHeight = objImage.Height / (objImage.Width / shtWidth);
            Response.Clear();
            objThumbnail = objImage.GetThumbnailImage(shtWidth, +
            shtHeight, null, System.IntPtr.Zero);

            imgThum = filename + "_Thumb";
            objThumbnail.Save(serverPath + imgThum + extension);

            objImage.Dispose();
            objImage = null;
            objThumbnail.Dispose();
            objThumbnail = null;
            my_stream.Dispose();
            my_stream = null;

            return nombreCompleto;
        }
        catch (Exception ex)
        {
            thumb = "";
            return ex.Message;
        }

    }

    
    protected void ddlSubrubro1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubrubro2.Items.Clear();
        MetodosComunes.cargarSubRubro(ddlSubrubro2, ddlSubrubro1.SelectedValue);
    }
    protected void ddlRubro_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubrubro1.Items.Clear();
        MetodosComunes.cargarSubRubro(ddlSubrubro1, ddlRubro.SelectedValue);
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
   
}
