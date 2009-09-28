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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MetodosComunes.cargarInstrumentos(ddlInstrumento);
            MetodosComunes.cargarProvincias(ddlProvincia);
            MetodosComunes.cargarLocalidades(ddlLocalidad);
            ddlDia.Items.Add(new ListItem(""));
            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString()));
            }   
            ddlMes.Items.Add(new ListItem(""));
            for (int i = 1; i <= 12; i++)
            {
                ddlMes.Items.Add(new ListItem(i.ToString()));
            }
            ddlAnio.Items.Add(new ListItem(""));
            for (int i = 1920; i <= 2009; i++)
            {
                ddlAnio.Items.Add(new ListItem(i.ToString()));
            }
            ddlSexo.Items.Add(new ListItem("Seleccione una opción"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));


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

    private void LimpiarLocalidades()
    {
        ddlLocalidad.DataSource = null;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        usu.NombreUsuario = txtUsuario.Text.Trim();
        usu.Password = txtPassword.Text.Trim();
        usu.IdInstrumento = int.Parse(ddlInstrumento.SelectedValue);
        usu.Nombre = txtNombre.Text.Trim();
        usu.Apellido = txtApellido.Text.Trim();
        usu.Sexo = ddlSexo.SelectedValue;
        usu.FecNac = DateTime.Parse(ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAnio.Text);
        usu.TelFijo = txtTelFijo.Text.Trim();
        usu.TelMovil = txtTelMovil.Text.Trim();
        usu.EMail = txtEmail.Text.Trim();
        usu.IdLocalidad = int.Parse(ddlLocalidad.SelectedValue);
        usu.Barrio = txtBarrio.Text.Trim();
        string thumb = "";
        string path = this.GuardarImagen(out thumb);
        usu.Imagen = path;
        usu.ImagenThumb = thumb;
        usu.CantPostHechos = 0;
        usu.IdPermiso = 2;
        usu.IdRangoPosteo = 1;
        usu.IdTipoUsuario = 1;
        if (UsuarioFactory.Insertar(usu))
        {
            AlertJS("Ha sido regitrado con éxito!!");
        }
        else
            AlertJS("No ha sido regitrado");
        
        Response.Redirect("Login.aspx?var=1");

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
                return "./ImagenesSite/user_no_avatar.gif";
            }
        }
        catch (Exception ex)
        {
            thumb = "";
            return ex.Message;
        }

    }

    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
}
