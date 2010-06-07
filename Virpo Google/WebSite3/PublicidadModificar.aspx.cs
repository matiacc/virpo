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
using CapaDatos;
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
            int frec = 0;
            int mes = 0;

            if (Request.QueryString["A"] != null)
            {
                int a = Convert.ToInt32(Request.QueryString["A"].ToString());
                if (a == 1)
                {
                    lblAlertaFecha.Visible = true;
                }
                if (a == 2)
                {
                    lblAlertaObservacion.Visible = true;
                }

            }

            if (Request.QueryString["EP"] != null)
            {
                int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
                switch (ep)
                {
                    case 0: btnBaja.Visible = true;
                        btnBaja.Text = "Rechazar";
                        break;
                    case 1: btnAlta.Text = "Guardar";
                        //txtInicio.Enabled = false;
                        //txtFin.Enabled = false;
                        //ddlFrecuencia.Enabled = false;
                        lblConsulta.Text = "Nota:";
                        break;
                    case 2: btnAlta.Text = "Renovar";
                        lblConsulta.Text = "Nota:";
                        btnBaja.Visible = true;
                        break;
                    case 3: btnAlta.Text = "Renovar";
                        lblConsulta.Text = "Nota:";
                        btnBaja.Visible = true;
                        btnBaja.Text = "Eliminar";
                        break;
                }
            }

            if (Request.QueryString["I"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["I"].ToString());
                lblId.Text = Convert.ToString(id);
                Publicidad publi = new Publicidad();
                publi = PublicidadFactory.Devolver(id);
                txtEntidad.Text = publi.Entidad;
                txtNombreContacto.Text = publi.NombreContacto;
                txtTelContacto.Text = publi.TelContacto;
                txtMailContacto.Text = publi.MailContacto;
                txtConsulta.Text = publi.Consulta;
                frec = publi.Frecuencia;
                mes = publi.FechaInicio.Month;


                ddlFrecuencia.Items.Add("1000");
                ddlFrecuencia.Items.Add("2000");
                ddlFrecuencia.Items.Add("4000");
                ddlFrecuencia.Items.Add("8000");
                for (int i = 0; i < 4; i++)
                {
                    ddlFrecuencia.SelectedIndex = i;
                    if (ddlFrecuencia.Text.CompareTo(Convert.ToString(publi.Frecuencia)) == 0)
                    {
                        frec = i;
                    }
                }
                ddlFrecuencia.SelectedIndex = frec;
                mes = publi.FechaFin.Month - publi.FechaInicio.Month;// cant de meses(resultados positivos
                if (mes <= 0)//esto es para q los resultados negativos indiquen la cant de meses
                {
                    mes = mes + 12;
                }
                lblMeses.Text = Convert.ToString(mes);
                if (btnAlta.Text.CompareTo("Alta") == 0)
                {
                    txtInicio.Text = DateTime.Today.ToShortDateString();
                    txtFin.Text = DateTime.Today.AddMonths(mes).ToShortDateString();
                }
                else
                {
                    txtInicio.Text = Convert.ToString(publi.FechaInicio);
                    txtFin.Text = Convert.ToString(publi.FechaFin);
                }
                if (publi.Imagen != "")
                {
                    imgPubli.ImageUrl = publi.Imagen;
                    imgPubli.PostBackUrl = publi.Url;
                }
                else
                {
                    imgPubli.ImageUrl = "~/ImagenesPublicidad/Sin Imagen.jpg";
                }
                txtUrl.Text = publi.Url.ToString();

            }
            if (Request.QueryString["FN"] != null)
            {
                string nombre = Request.QueryString["FN"].ToString();
                imgPubli.ImageUrl = "~/Temp/" + nombre;
            }
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        Publicidad publi = new Publicidad();
        publi = PublicidadFactory.Devolver(Convert.ToInt32(lblId.Text));
        publi.Entidad = txtEntidad.Text;
        publi.NombreContacto = txtNombreContacto.Text;
        publi.TelContacto = txtTelContacto.Text;
        publi.MailContacto = txtMailContacto.Text;

        publi.FechaInicio = Convert.ToDateTime(txtInicio.Text);
        publi.FechaFin = Convert.ToDateTime(txtFin.Text);

        publi.Frecuencia = Convert.ToInt32(ddlFrecuencia.Text);
        publi.Consulta = "";
        publi.IdEstado = 1;

        if (txtUrl.Text.Length > 7)
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

        try
        {
            if (publi.Imagen != imgPubli.ImageUrl && publi.Imagen != "")//para que borre la foto anterior. si hay. la segunda condicion es por si es la primera imagen que se va a guardar, en tal caso no hay que eliminar nada
            {
                File.Delete(Server.MapPath(@".") + publi.Imagen.Substring(1));
            }
        }
        catch (Exception)
        {
        }

        if (imgPubli.ImageUrl.Remove(7) == "~/Temp/") // bloque de imagen. si hay una imagen nueva para guardar
        {
            string nombre = imgPubli.ImageUrl.Substring(7);
            string origen = Server.MapPath(@"./Temp/") + nombre;
            string destino = Server.MapPath(@"./ImagenesPublicidad/") + nombre;

            try
            {
                File.Move(origen, destino);
            }
            catch (System.IO.IOException)//si entra es por que el nombre ya existe, y lo cambia
            {
                string extension = imgPubli.ImageUrl.Substring(imgPubli.ImageUrl.Length - 4);
                string rdm = (new Random()).Next(99999).ToString();

                int corteExtension = nombre.Length - 4;
                nombre = nombre.Remove(corteExtension);
                nombre = nombre + rdm + extension;
                string destino2 = Server.MapPath(@"./ImagenesPublicidad/") + nombre;
                File.Move(origen, destino2);
            }

            publi.Imagen = "~/ImagenesPublicidad/" + nombre;
        }
        Session["publi"] = publi;
        if (PublicidadFactory.Modificar(publi))
        {
            if (btnAlta.Text == "Alta") Panel3_ModalPopupExtender.Show();
            if (btnAlta.Text == "Guardar") Panel4_ModalPopupExtender.Show();
            if (btnAlta.Text == "Renovar") Panel5_ModalPopupExtender.Show();
            
            //if (Request.QueryString["EP"] != null)
            //{
            //    int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
            //    switch (ep)
            //    {
            //        case 0: Response.Redirect("PublicidadSolicitudes.aspx?C=1");
            //            break;
            //        case 1: Response.Redirect("PublicidadBajas.aspx?C=1");
            //            break;
            //        case 2:
            //            if (btnBaja.Visible && publi.FechaFin <= DateTime.Now.AddDays(7))
            //            {
            //                lblAlertaFecha.Visible = true;
            //                if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
            //                {                                
            //                    string id = Request.QueryString["I"].ToString();
            //                    Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&A=1");
            //                }
            //            }
            //            else
            //            {
            //                Response.Redirect("PublicidadRenovacion.aspx?C=1");
            //            }

            //            break;
            //        case 3: 
            //                if (btnBaja.Visible && publi.FechaFin <= DateTime.Now.AddDays(7))
            //                {
            //                    lblAlertaFecha.Visible = true;
            //                    if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
            //                    {
            //                        string id = Request.QueryString["I"].ToString();
            //                        Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&A=1");
            //                    }
            //                }
            //                else
            //                {
            //                    Response.Redirect("PublicidadEjecutarBajas.aspx?C=2");
            //                }
            //            break;
            //    }
            //}
        }
        else
        {
            if (Request.QueryString["EP"] != null)
            {
                int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
                switch (ep)
                {
                    case 0: Response.Redirect("PublicidadSolicitudes.aspx?C=0");
                        break;
                    case 1: Response.Redirect("PublicidadBajas.aspx?C=0");
                        break;
                    case 2: Response.Redirect("PublicidadRenovacion.aspx?C=0");
                        break;
                    case 3: Response.Redirect("PublicidadEjecutarBajas.aspx?C=0");
                        break;
                }
            }
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        if (imgPubli.ImageUrl.Remove(7) == "~/Temp/")//para que borre de la carpeta Temp las fotos que no va a guardar
        {
            File.Delete(Server.MapPath(@"./Temp/") + imgPubli.ImageUrl.Substring(7));
        }

        if (Request.QueryString["EP"] != null)
        {
            int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
            switch (ep)
            {
                case 0: Response.Redirect("PublicidadSolicitudes.aspx");
                    break;
                case 1: Response.Redirect("PublicidadBajas.aspx");
                    break;
                case 2: Response.Redirect("PublicidadRenovacion.aspx");
                    break;
                case 3: Response.Redirect("PublicidadEjecutarBajas.aspx");
                    break;
            }
        }
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
            if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
            {
                string ep = Request.QueryString["EP"].ToString();
                string id = Request.QueryString["I"].ToString();
                Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&FN=" + upPublicidad.FileName);
            }
        }
    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        Publicidad publi = new Publicidad();
        int ID = Convert.ToInt32(lblId.Text);
        publi = PublicidadFactory.Devolver(ID);
        ViewState["ID"] = ID;

        if (btnBaja.Text == "Baja")
        {
            publi.Consulta = txtConsulta.Text;
            publi.IdEstado = 3; // listo para eliminar
            if (publi.Consulta != "")
            {
                if (PublicidadFactory.Modificar(publi))
                {
                    Response.Redirect("PublicidadRenovacion.aspx?C=2");
                }
                else
                {
                    Response.Redirect("PublicidadRenovacion.aspx?C=0");
                }
            }
            else
            {
                if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
                {
                    string ep = Request.QueryString["EP"].ToString();
                    string id = Request.QueryString["I"].ToString();
                    Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&A=2");
                }
            }

        }

        if (btnBaja.Text == "Eliminar")
        {
            try
            {
                if (publi.Imagen != "")
                {
                    File.Delete(Server.MapPath(@".") + publi.Imagen.Substring(1));
                }
            }
            catch (Exception)
            {
            }
            Panel6_ModalPopupExtender.Show();
            //if (PublicidadFactory.Eliminar(ID))
            //{
            //    Response.Redirect("PublicidadEjecutarBajas.aspx?C=2");
            //}
            //else
            //{
            //    Response.Redirect("PublicidadEjecutarBajas.aspx?C=0");
            //}
        }

        if (btnBaja.Text == "Rechazar")
        {
            try
            {
                if (publi.Imagen != "")
                {
                    File.Delete(Server.MapPath(@".") + publi.Imagen.Substring(1));
                }
            }
            catch (Exception)
            {
            }

            Panel1_ModalPopupExtender.Show();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            PublicidadFactory.Eliminar(int.Parse(ViewState["ID"].ToString()));
            Panel2_ModalPopupExtender.Show();
        }
        catch { }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicidadSolicitudes.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Publicidad publi = new Publicidad();
        publi = (Publicidad)Session["publi"];
        if (Request.QueryString["EP"] != null)
        {
            int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
            switch (ep)
            {
                case 0: Response.Redirect("PublicidadSolicitudes.aspx");
                    break;
                case 1: Response.Redirect("PublicidadBajas.aspx");
                    break;
                case 2:
                    if (btnBaja.Visible && publi.FechaFin <= DateTime.Now.AddDays(7))
                    {
                        lblAlertaFecha.Visible = true;
                        if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
                        {
                            string id = Request.QueryString["I"].ToString();
                            Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&A=1");
                        }
                    }
                    else
                    {
                        Response.Redirect("PublicidadRenovacion.aspx");
                    }

                    break;
                case 3:
                    if (btnBaja.Visible && publi.FechaFin <= DateTime.Now.AddDays(7))
                    {
                        lblAlertaFecha.Visible = true;
                        if (Request.QueryString["EP"] != null && Request.QueryString["I"] != null)
                        {
                            string id = Request.QueryString["I"].ToString();
                            Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=" + ep + "&A=1");
                        }
                    }
                    else
                    {
                        Response.Redirect("PublicidadEjecutarBajas.aspx");
                    }
                    break;
            }
        }
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        try
        {
            PublicidadFactory.Eliminar(int.Parse(ViewState["ID"].ToString()));
            Panel7_ModalPopupExtender.Show();
        }
        catch { }
    }
    protected void Button18_Click(object sender, EventArgs e)
    {

    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicidadEjecutarBajas.aspx");
    }
}
