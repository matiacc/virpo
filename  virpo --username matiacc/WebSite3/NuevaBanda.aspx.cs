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
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
            MetodosComunes.cargarGeneros(ddlGenero);
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
            MetodosComunes.cargarPaises(ddlPais);
            MetodosComunes.cargarProvincias(ddlProvincia);
            MetodosComunes.cargarLocalidades(ddlLocalidad);
        }
    }

    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarProvincias();

        if (ddlPais.SelectedValue != "")
        {
            cargarProvincias(int.Parse(ddlPais.SelectedValue));

        }
    }
    private void LimpiarProvincias()
    {
        ddlProvincia.DataSource = null;
        ddlProvincia.DataBind();
        ddlProvincia.Items.Clear();
    }
    private void LimpiarLocalidades()
    {
        ddlLocalidad.DataSource = null;
        ddlLocalidad.DataBind();
        ddlLocalidad.Items.Clear();
    }
    private void cargarProvincias(int idPais)
    {
        MetodosComunes.cargarProvincias(ddlProvincia, idPais);
    }
    private void cargarLocalidades(int idProvincia)
    {
        MetodosComunes.cargarLocalidades(ddlLocalidad, idProvincia);
    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarLocalidades();
        if (ddlProvincia.SelectedValue != "")
        {
            cargarLocalidades(int.Parse(ddlProvincia.SelectedValue));

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Banda banda = new Banda();
        MusicoXBanda mxbanda = new MusicoXBanda();
        MusicoXBanda mzbanda = new MusicoXBanda();
        Genero gen = new Genero();
        Localidad loc = new Localidad();
        Usuario usu = (Usuario)Session["Usuario"];
        DateTime fecSis = DateTime.Now;

        banda.Nombre = txtNombreBanda.Text.Trim();
        gen.Id = int.Parse(ddlGenero.SelectedValue);
        banda.Genero = gen;
        banda.FechaInicio = DateTime.Parse(ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAnio.Text);
        loc.Id = int.Parse(ddlLocalidad.SelectedValue);
        banda.Localidad = loc;
        banda.PaginaWeb = txtSitioWeb.Text.Trim();
        string thumb = "";
        string path = this.GuardarImagen(out thumb);
        banda.Imagen = path;
        banda.ImagenThumb = thumb;
        banda.Descripcion = "";
        banda.FecSistema = fecSis;
        if (BandaFactory.Insertar(banda))
        {
            mxbanda.IdUsuario = usu.Id;
            mxbanda.IdBanda = MusicoXBandaFactory.DevolverIdBandaCreada(fecSis);
            mxbanda.Creador = true;
            mxbanda.FecAgregado = fecSis;
            if(MusicoXBandaFactory.Insertar(mxbanda)) 
            {mzbanda.IdUsuario = 5;
                mzbanda.IdBanda = MusicoXBandaFactory.DevolverIdBandaCreada(fecSis);
                mzbanda.Creador = false;
                mzbanda.FecAgregado = fecSis;
                MusicoXBandaFactory.Insertar(mzbanda);
                Response.Redirect("Bandas.aspx");
            }
        }

    }
    private string GuardarImagen(out string thumb)
    {
        try
        {
            string filename = DateTime.Now.Millisecond.ToString();
            //TODO: ponerle un nombre unico
            string serverPath = Server.MapPath(@"./ImagenesBandas/");
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
        catch (Exception ex)
        {
            thumb = "";
            return ex.Message;
        }

    }
}
