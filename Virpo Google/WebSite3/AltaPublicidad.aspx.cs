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
using System.Collections.Generic;
using System.Globalization;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)           
        {
            if (Request.QueryString["c"]!=null)
            {
                int badera = Convert.ToInt32(Request.QueryString["c"].ToString());
                if ( badera == 0)
                {
                    lblMsj.Visible = false;
                    lblMal.Visible = true;              
                }
                if (badera == 1)
                {
                    lblMsj.Visible = false;
                    lblOk.Visible = true;
                }
            }
            ddlFrecuencia.Items.Add("1000");
            ddlFrecuencia.Items.Add("2000");
            ddlFrecuencia.Items.Add("4000");
            ddlFrecuencia.Items.Add("8000");
            ddlFrecuencia.SelectedIndex =0;

            ddlMeses.Items.Add("1");
            ddlMeses.Items.Add("3");
            ddlMeses.Items.Add("6");
            ddlMeses.Items.Add("12");
            ddlMeses.SelectedIndex = 0;

               
                
            if (Request.QueryString["FN"] != null)
            {
                string nombre = Request.QueryString["FN"].ToString();
                imgPubli.ImageUrl = "~/Temp/" + nombre;
            }
            else
            {
                imgPubli.ImageUrl = "~/ImagenesPublicidad/Publique Aqui.jpg";
            }
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("inicio.aspx");
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Publicidad publi = new Publicidad();

        publi.Entidad = txtEntidad.Text;
        publi.NombreContacto = txtNombreContacto.Text;
        publi.TelContacto = txtTelContacto.Text;
        publi.MailContacto = txtMailContacto.Text;
        publi.FechaInicio = DateTime.Today;
        publi.FechaFin = DateTime.Today.AddMonths(Convert.ToInt32(ddlMeses.Text));
        publi.Frecuencia = Convert.ToInt32(ddlFrecuencia.Text);
        publi.Imagen = "";
        publi.Consulta = txtConsulta.Text;
        publi.IdEstado = 0; // solicitado
        publi.Impresiones = 0;
        publi.Clicks = 0;
        if (txtUrl.Text.Length>7)
        {
           if (txtUrl.Text.Trim().Remove(7) != "http://")
            {
                publi.Url = "http://" + txtUrl.Text.Trim();
            }
            else
            {
                publi.Url = txtUrl.Text.Trim();
            } 
        }
        else
        {
            publi.Url = "";
        }
        
        
        
        publi.Disposicion = 1;

        if (PublicidadFactory.Insertar(publi))
        {
            Response.Redirect("AltaPublicidad.aspx?c=1");
        }
        else
        {
            Response.Redirect("AltaPublicidad.aspx?c=0");
        }

    }
    protected void ddlMeses_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DateTime inicio = DateTime.Today.AddMonths(1);
        //int mes = inicio.Month;
        //int anio = inicio.Year;
        //lblFecIni.Text = "01/" + mes + "/" + anio;

        //DateTime fin = inicio.AddMonths(Convert.ToInt32(ddlMeses.Text));
        //mes = fin.Month;
        //anio = fin.Year;
        //lblFecFin.Text = "01/" + mes + "/" + anio;

    }
    protected void imgPubli_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        if (upPublicidad.HasFile)
        {
            if (imgPubli.ImageUrl.Remove(7) == "~/Temp/")//para que borre de la carpeta Temp las fotos que no va a guardar
            {
                File.Delete(Server.MapPath(@"./Temp/") + imgPubli.ImageUrl.Substring(7));
            }

            upPublicidad.PostedFile.SaveAs(Server.MapPath(@"./Temp/") + upPublicidad.FileName);
            
            Response.Redirect("AltaPublicidad.aspx?&FN=" + upPublicidad.FileName);
            
        }
    }
}
