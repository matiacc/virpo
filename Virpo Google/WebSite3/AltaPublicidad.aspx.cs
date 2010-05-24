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
            ddlFrecuencia.Items.Add("1");
            ddlFrecuencia.Items.Add("2");
            ddlFrecuencia.Items.Add("4");
            ddlFrecuencia.Items.Add("8");
            ddlFrecuencia.SelectedIndex =0;

            ddlMeses.Items.Add("1");
            ddlMeses.Items.Add("3");
            ddlMeses.Items.Add("6");
            ddlMeses.Items.Add("12");
            ddlMeses.SelectedIndex = 0;

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
        publi.Imagen = txtImagen.Text;
        publi.Consulta = txtConsulta.Text;
        publi.IdEstado = 0; // solicitado

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
        //inicio.Day = 1;

        //string mes = inicio.Month;
        //string anio = inicio.Year;

        //lblFecIni.Text = inicio.Day + "/" + mes + "/" + anio;

        //DateTime fin = inicio.AddMonths(Convert.ToInt32(ddlMeses.Text));
        //fin = fin - 1;

        //lblFecFin.Text = fin.ToShortTimeString;
    }
}
