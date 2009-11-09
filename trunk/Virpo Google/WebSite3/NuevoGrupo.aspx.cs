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
using System.Collections.Generic;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.IO;

public partial class NuevoGrupo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
        if (!Page.IsPostBack)
        {
            lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";
            this.Form.DefaultButton = btGuardar.UniqueID;
        }
    }
    protected void btGuardar_Click(object sender, EventArgs e)
    {
        Grupo grupo = new Grupo();

        Usuario user = new Usuario();
        user = (Usuario)Session["Usuario"];
        grupo.Creador = user;

        grupo.Descripcion = txtDescripcion.Text;
        //grupo.Enlaces = txtEnlaces.Text.Trim();
        grupo.Enlaces = "";

        #region Guardo Imagen
        int proxId = GrupoFactory.DevolverMaxId() + 1;
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
            if (extension != ".png" && extension != ".jpg" && extension != ".bmp" && extension != ".gif")
            {
                AlertJS("El archivo seleccionado no es una imagen");
                return;
            }
            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"./ImagenesGrupos/") + proxId.ToString() + extension);
            grupo.Imagen = "./ImagenesGrupos/" + proxId.ToString() + extension;
        }
        #endregion

        grupo.Nombre = txtNombre.Text;
        grupo.Tags = txtTags.Text;
        grupo.Tema = ddlTema.SelectedValue;

        if (GrupoFactory.Insertar(grupo))
            Response.Redirect("GruposDeInteres.aspx");
        else
            AlertJS("Hubo un problema al registrar el grupo");

    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
}
