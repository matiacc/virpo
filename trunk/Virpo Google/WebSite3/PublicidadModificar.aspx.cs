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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int frec = 0;
            int mes = 0;

            if (Request.QueryString["EP"] != null)
            {
                int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
                switch (ep)
                {
                    case 0:     
                        break;
                    case 1: btnAlta.Text = "Guardar";
                        //txtInicio.Enabled = false;
                        //txtFin.Enabled = false;
                        //ddlFrecuencia.Enabled = false;
                        lblConsulta.Text = "Observacion:";
                        break;
                    case 2: btnAlta.Text = "Renovar";
                        lblConsulta.Text = "Observacion:";
                        break;
                    case 3: btnAlta.Text = "Renovar";
                        lblConsulta.Text = "Observacion:";
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
                txtImagen.Text = publi.Imagen;
                txtConsulta.Text = publi.Consulta;
                
                frec = publi.Frecuencia;
                mes = publi.FechaInicio.Month;

                ddlFrecuencia.Items.Add("1");
                ddlFrecuencia.Items.Add("2");
                ddlFrecuencia.Items.Add("4");
                ddlFrecuencia.Items.Add("8");
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
                if (mes<=0)//esto es para q los resultados negativos indiquen la cant de meses
                {
                    mes = mes + 12;
                }
                lblMeses.Text = Convert.ToString(mes);
                if (btnAlta.Text.CompareTo("Alta")==0)
                {
                    txtInicio.Text = DateTime.Today.ToShortDateString();
                    txtFin.Text = DateTime.Today.AddMonths(mes).ToShortDateString();
                }
                else
	            {
                    txtInicio.Text = Convert.ToString(publi.FechaInicio);
                    txtFin.Text = Convert.ToString(publi.FechaFin);
	            }
                
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
        publi.Imagen = txtImagen.Text;
        publi.Frecuencia = Convert.ToInt32(ddlFrecuencia.Text);
        publi.Consulta = "";
        publi.IdEstado = 1;

        if (PublicidadFactory.Modificar(publi))
        {
            if (Request.QueryString["EP"] != null)
            {
                int ep = Convert.ToInt32(Request.QueryString["EP"].ToString());
                switch (ep)
                {
                    case 0: Response.Redirect("PublicidadSolicitudes.aspx?C=1");
                        break;
                    case 1: Response.Redirect("PublicidadBajas.aspx?C=1");
                        break;
                    case 2: Response.Redirect("PublicidadRenovacion.aspx?C=1");
                        break;
                    case 3: Response.Redirect("PublicidadEjecutarBajas.aspx?C=1");
                        break;
                }
            }
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
}
