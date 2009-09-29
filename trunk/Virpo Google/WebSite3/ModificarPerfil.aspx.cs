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

public partial class ModificarPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            ImgPerfil.ImageUrl = "./ImagenesUsuario/" + usr.Imagen;
            MetodosComunes.cargarLocalidades(ddlLocalidad);
            MetodosComunes.cargarProvincias(ddlProvincia);
            MetodosComunes.cargarPaises(ddlPais);
            MetodosComunes.cargarInstrumentos(ddlInstrumento);
            lblLogin.Text = usr.NombreUsuario;
            txtNombre.Text = usr.Nombre;
            txtApellido.Text = usr.Apellido;
            ddlInstrumento.SelectedValue = usr.IdInstrumento.ToString();
            txtFecNac.Text = usr.FecNac.ToShortDateString();
            ddlSexo.Items.Add(new ListItem("Seleccione una opción"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.SelectedValue = usr.Sexo;
            txtEmail.Text = usr.EMail;
            txtTelFijo.Text = usr.TelFijo;
            txtTelMovil.Text = usr.TelMovil;
            txtBarrio.Text = usr.Barrio;
            Localidad loc = new Localidad();
            loc = LocalidadFactory.Devolver(int.Parse(usr.IdLocalidad.ToString()));
            ddlLocalidad.SelectedValue = loc.Id.ToString();
            ddlProvincia.SelectedValue = loc.Provincia.Id.ToString();
            ddlPais.SelectedValue = loc.Provincia.Pais.Id.ToString();
        }
    }

    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarProvincias();
        LimpiarLocalidades();

        if (ddlPais.SelectedValue != "")
        {
            CargarProvincias(int.Parse(ddlPais.SelectedValue));
        }
    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarLocalidades();

        if (ddlProvincia.SelectedValue != "")
        {
            CargarLocalidades(int.Parse(ddlProvincia.SelectedValue));
        }
    }

    private void CargarLocalidades(int idProvincia)
    {
        MetodosComunes.cargarLocalidades(ddlLocalidad, idProvincia);
    }

    private void CargarProvincias(int idPais)
    {
        MetodosComunes.cargarProvincias(ddlProvincia, idPais);
    }

    private void LimpiarLocalidades()
    {
        ddlLocalidad.DataSource = null;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Clear();
    }

    private void LimpiarProvincias()
    {
        ddlProvincia.DataSource = null;
        ddlProvincia.DataBind();
        ddlProvincia.Items.Clear();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Usuario usr = new Usuario();
        usr = (Usuario)Session["Usuario"];
        Usuario usrModificado = new Usuario();
        usrModificado.Id = usr.Id;
        usrModificado.Nombre = txtNombre.Text;
        usrModificado.Apellido = txtApellido.Text;
        usrModificado.IdInstrumento=int.Parse(ddlInstrumento.SelectedValue.ToString());
        usrModificado.FecNac = DateTime.Parse(txtFecNac.Text);
        usrModificado.Sexo = ddlSexo.SelectedValue.ToString();
        usrModificado.EMail = txtEmail.Text;
        usrModificado.TelFijo = txtTelFijo.Text;
        usrModificado.TelMovil = txtTelMovil.Text;
        usrModificado.IdLocalidad = int.Parse(ddlLocalidad.SelectedValue.ToString());
        usrModificado.Barrio = txtBarrio.Text;
        //usrModificado.Imagen = ImgPerfil.ImageUrl.ToString();
        //usrModificado.ImagenThumb = usr.ImagenThumb;
        string thumb = "";
        string path = this.GuardarImagen(out thumb);
        if (path != "1")
        {
            usrModificado.Imagen = path;
            usrModificado.ImagenThumb = thumb;
        }
        else 
        {
            usrModificado.Imagen = usr.Imagen;
            usrModificado.ImagenThumb = usr.ImagenThumb;
        }
        UsuarioFactory.Modificar(usrModificado);
        Session["Usuario"] = usrModificado;
        Panel1_ModalPopupExtender.Show();
        //Response.Redirect("Perfil.aspx");
    }
    private string GuardarImagen(out string thumb)
    {
        try
        {
            if (uploadImagen.HasFile)
            {
                string filename = DateTime.Now.Millisecond.ToString();
                //TODO: ponerle un nombre unico
                string serverPath = Server.MapPath(@"./ImagenesUsuario/");
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
                thumb = "./ImagenesSite/user_no_avatar.gif";
                return "1";
            }
        }
        catch (Exception ex)
        {
            thumb = "";
            return ex.Message;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
}