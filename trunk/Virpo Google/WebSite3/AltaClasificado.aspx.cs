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
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;

public partial class AltaClasificado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            MetodosComunes.cargarRubro(ddlRubro);

            if (Request.QueryString["E"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["E"].ToString());
                ViewState["Id"] = id;
                AvisoClasificado aviso = new AvisoClasificado();
                aviso = AvisoClasificadoFactory.Devolver(id);
                txtTitulo.Text = aviso.Titulo;
                txtDescripcion.Text = aviso.Descripcion;
                txtPrecio.Text = aviso.Precio.ToString();
                Label6.Text = "Republicar por ";
                rb0dias.Visible = true;
                rb10dias.Checked = false;
                rb0dias.Checked = true;
                ViewState["FechaF"] = aviso.FechaFin;
                ViewState["FechaI"] = aviso.FechaInicio;
                txtUbicacion.Text = aviso.Ubicacion;
                //ddlRubro.SelectedValue = aviso.Rubro.Id.ToString();
                ViewState["cantImagenes"] = aviso.Imagen.Count;
                Image1.ImageUrl = aviso.Imagen[0];
                for (int i = 1; i < aviso.Imagen.Count; i++)
                {
                    if (i == 1)
                    {
                        Image2.Visible = true;
                        chkBorrar2.Visible = true;
                        uploadImagen0.Visible = true;
                        Image2.ImageUrl = aviso.Imagen[i];
                    }
                    else if (i == 2)
                    {
                        Image3.Visible = true;
                        chkBorrar3.Visible = true;
                        uploadImagen1.Visible = true;
                        Image3.ImageUrl = aviso.Imagen[i];
                    }
                    else if (i == 3)
                    {
                        Image4.Visible = true; 
                        chkBorrar4.Visible = true;
                        uploadImagen2.Visible = true;
                        Image4.ImageUrl = aviso.Imagen[i];
                    }
                }
                List<Rubro> padres = RubroFactory.DevolverPadres(aviso.Rubro.Id);
                
                if (padres != null)
                {
                    padres.Reverse();
                    ddlRubro.SelectedValue = padres[0].Id.ToString();

                    for (int i = 0; i < padres.Count; i++)
                    {
                        if (i == 1)
                        {
                            MetodosComunes.cargarSubRubro(ddlSubrubro1, ddlRubro.SelectedValue.ToString());
                            ddlSubrubro1.SelectedValue = padres[i].Id.ToString();
                        }
                        if (i == 2)
                        {
                            MetodosComunes.cargarSubRubro(ddlSubrubro2, ddlSubrubro1.SelectedValue.ToString());
                            ddlSubrubro2.SelectedValue = padres[i].Id.ToString();
                        }
                    }
                }
            }
        }
    }
    
    protected void btGuardar_Click(object sender, EventArgs e)
    {
        if (ddlRubro.SelectedIndex == 0)
        {
            lblRubro.Visible = true;
            return;
        }

        AvisoClasificado aviso = new AvisoClasificado();
        aviso.Titulo = txtTitulo.Text;
        aviso.Descripcion = txtDescripcion.Text;
        if (txtPrecio.Text.Trim() == "")
            aviso.Precio = 0;
        else
            aviso.Precio = Convert.ToDouble(txtPrecio.Text);
        if (rb0dias.Visible) //Modifica aviso
        {
            #region Guardar Imagenes

            bool tieneImagen = Image1.ImageUrl.Contains("Null") ? false : true;

            int proxId = ImagenClasificadoFactory.DevolverMaxId() + 1;
            if (uploadImagen.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen.PostedFile.SaveAs(Server.MapPath(@"./ImagenesProyectos/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen0.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen0.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen0.PostedFile.SaveAs(Server.MapPath(@"./Imagenes/") + proxId.ToString() + extension);

                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen1.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen1.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen1.PostedFile.SaveAs(Server.MapPath(@"./Imagenes/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen2.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen2.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen2.PostedFile.SaveAs(Server.MapPath(@"./ImagenesProyectos/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
            }
            if (!tieneImagen)
                aviso.Imagen.Add("./ImagenesSite/ProyectoNull.jpg");
            #endregion

            aviso.Id = Convert.ToInt32(ViewState["Id"]);
            aviso.FechaInicio = (DateTime)ViewState["FechaI"];
            if (rb0dias.Checked)
                aviso.FechaFin = (DateTime)ViewState["FechaF"];
            if (rb10dias.Checked)
                aviso.FechaFin = ((DateTime)ViewState["FechaF"]).AddDays(10);
            if (rb20dias.Checked)
                aviso.FechaFin = ((DateTime)ViewState["FechaF"]).AddDays(20);
            if (rb30dias.Checked)
                aviso.FechaFin = ((DateTime)ViewState["FechaF"]).AddDays(30);

            if(aviso.FechaFin < DateTime.Now)
            {
                EstadoAvisoClasificado estado=new EstadoAvisoClasificado();
                estado.Id = 3; //Finalizado
                aviso.Estado = estado;
            }
            if (ViewState["Rubro"] != null)
            {
                int rubro = (int)ViewState["Rubro"];

            }
        }
        else //Nuevo Aviso
        {
            //TODO: Permitir guardar hasta 4 imagenes, como dice el CU
            //string path = this.GuardarImagen();
            //aviso.Imagen = path;
            //aviso.ImagenThumb = thumb;

            //Guardar imagenes

            #region Guardar Imagenes

            bool tieneImagen = false;

            int proxId =ImagenClasificadoFactory.DevolverMaxId() + 1;
            if (uploadImagen.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen.PostedFile.SaveAs(Server.MapPath(@"./ImagenesProyectos/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen0.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen0.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen0.PostedFile.SaveAs(Server.MapPath(@"./Imagenes/") + proxId.ToString() + extension);
                
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen1.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen1.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen1.PostedFile.SaveAs(Server.MapPath(@"./Imagenes/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
                proxId++;
            }
            if (uploadImagen2.HasFile)
            {
                string extension = Path.GetExtension(uploadImagen2.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                {
                    AlertJS("El archivo seleccionado no es una imagen");
                    return;
                }
                uploadImagen2.PostedFile.SaveAs(Server.MapPath(@"./ImagenesProyectos/") + proxId.ToString() + extension);
                aviso.Imagen.Add("./Imagenes/" + proxId.ToString() + extension);
                tieneImagen = true;
            }
            if(!tieneImagen)
                aviso.Imagen.Add("./ImagenesSite/ProyectoNull.jpg");
            #endregion

            aviso.FechaInicio = DateTime.Now;
            if (rb10dias.Checked)
                aviso.FechaFin = DateTime.Now.AddDays(10);
            if (rb20dias.Checked)
                aviso.FechaFin = DateTime.Now.AddDays(20);
            if (rb30dias.Checked)
                aviso.FechaFin = DateTime.Now.AddDays(30);
        }
        Usuario mus = new Usuario();
        mus = (Usuario) Session["Usuario"];
        aviso.Dueño = mus;
        aviso.Estado = EstadoAvisoClasificadoFactory.Devolver(1); //1 Activo 2 Pendiente 3 Finalizado 4 Rechazado
        aviso.Ubicacion = txtUbicacion.Text;
        
        Rubro rub = new Rubro();
        if (!string.IsNullOrEmpty(ddlSubrubro2.Text))
            rub.Id = Convert.ToInt32(ddlSubrubro2.SelectedValue);
        else
            if (!string.IsNullOrEmpty(ddlSubrubro1.Text))
                rub.Id = Convert.ToInt32(ddlSubrubro1.SelectedValue);
            else
                rub.Id = Convert.ToInt32(ddlRubro.SelectedValue);

        aviso.Rubro = rub;
        if(rb0dias.Visible)
            if (AvisoClasificadoFactory.Modificar(aviso))
                AlertJS("Aviso actualizado con éxito");
            else
                AlertJS("Hubo un error al intentar modificar el aviso");
        else
            if (AvisoClasificadoFactory.Insertar(aviso))
                AlertJS("El aviso se guardó");
            else
                AlertJS("El aviso no se guardó");
        
        Response.Redirect("MisAvisosClasificados.aspx");
    }
    private string GuardarImagen(out string thumb)
    {
        try
        {
            if (uploadImagen.HasFile)
            {
                string filename = (new Random()).Next(999999).ToString();
                //TODO: ponerle un nombre unico
                string serverPath = Server.MapPath(@"./Imagenes/");
                string extension = Path.GetExtension(uploadImagen.PostedFile.FileName).ToLower();
                string rutaCompleta = serverPath + filename + extension;
                string nombreCompleto = filename + extension;
                thumb = filename + "_Thumb" + extension;
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
            else
            {
                thumb = "./ImagenesSite/clasificadoNull.png";
                return "./ImagenesSite/clasificadoNull.png";
            }
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
