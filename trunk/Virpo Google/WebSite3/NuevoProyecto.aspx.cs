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
using System.Drawing.Imaging;
using System.Collections.Generic;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.IO;

public partial class NuevoProyecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

        }
    }
    protected void btCrear_Click(object sender, EventArgs e)
    {
        try
        {
            Proyecto proyecto = new Proyecto();
            proyecto.Descripcion = txtDescripcion.Text.Trim();
            proyecto.FechaCreacion = DateTime.Now;
            proyecto.Genero = txtGenero.Text.Trim();

            //Guardar Imagen
            string filename = (new Random()).Next(999999).ToString();
            if (FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                if (extension != ".png" && extension != ".jpg" && extension != ".bmp")
                    throw new Exception("El archivo ingresado no es una imagen");
                FileUpload1.PostedFile.SaveAs(Server.MapPath(@"./ImagenesProyectos/") + filename + extension);
                proyecto.Imagen = @"./ImagenesProyectos/" + filename + extension;
            }
            else
                proyecto.Imagen = "./ImagenesSite/ProyectoNull.jpg";
            //Fin Guardar imagen

            if (RadioButton1.Checked)
                proyecto.Licencia = RadioButton1.Text;
            if (RadioButton2.Checked)
                proyecto.Licencia = RadioButton2.Text;
            if (RadioButton3.Checked)
                proyecto.Licencia = RadioButton3.Text;
            if (RadioButton4.Checked)
                proyecto.Licencia = RadioButton4.Text;
            if (RadioButton5.Checked)
                proyecto.Licencia = RadioButton5.Text;
            if (RadioButton6.Checked)
                proyecto.Licencia = RadioButton6.Text;

            proyecto.Nombre = txtNombre.Text.Trim();
            proyecto.Tags = txtTags.Text.Trim();
            proyecto.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);//0 Publico 1 Privado
            proyecto.Usuario = (Usuario)Session["Usuario"];
            if (ProyectoFactory.Insertar(proyecto))
            {
                int idProyecto = ProyectoFactory.DevolverIdProyectoCreado(proyecto.FechaCreacion);
                ProyectoFactory.InsertarUsuarioXProyecto(proyecto.Usuario.Id, idProyecto, DateTime.Now);
                Context.Server.Transfer("Proyecto.aspx?Id=" + idProyecto,true);
            }
            else
                AlertJS("Hubo un error al intentar crear el Proyecto");

        }
        catch (Exception ex)
        {
            AlertJS(ex.Message);
        }
        
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
    public string[] GetGeneros(string prefixText)
    {
        string restriccion = " WHERE nombre like '%" + prefixText + "%'";
        List<Genero> generos = GeneroFactory.DevolverTodos(restriccion);
        string[] aux = new string[generos.Count];
        int i=0;
        foreach (Genero genero in generos)
        {
            aux.SetValue(genero.Nombre, i);
            i++;
        }
        return aux;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        if (count == 0)
        {
            count = 10;
        }

        if (prefixText.Equals("xyz"))
        {
            return new string[0];
        }

        Random random = new Random();
        List<string> items = new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            char c1 = (char)random.Next(65, 90);
            char c2 = (char)random.Next(97, 122);
            char c3 = (char)random.Next(97, 122);

            items.Add(prefixText + c1 + c2 + c3);
        }

        return items.ToArray();
    }
}
