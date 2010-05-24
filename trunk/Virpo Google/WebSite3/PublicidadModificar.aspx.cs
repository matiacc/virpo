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
                      
            if (Request.QueryString["I"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["I"].ToString());
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
                if (mes<0)//esto es para q los resultados negativos indiquen la cant de meses
                {
                    mes = mes + 12;
                }
                lblMeses.Text = Convert.ToString(mes);
                txtInicio.Text = DateTime.Today.ToShortDateString();
                txtFin.Text = DateTime.Today.AddMonths(mes).ToShortDateString();
            }            
        }
    }


    protected void btnAlta_Click(object sender, EventArgs e)
    {

    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicidadSolicitudes.aspx");
    }
}
