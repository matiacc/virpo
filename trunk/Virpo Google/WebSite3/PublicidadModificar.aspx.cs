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
                      
            if (Request.QueryString["c"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["c"].ToString());
                Publicidad publi = new Publicidad();
                publi = PublicidadFactory.Devolver(id);
                frec = publi.Frecuencia;
                mes = publi.FechaInicio.Month;
            }
            ddlFrecuencia.Items.Add("1");
            ddlFrecuencia.Items.Add("2");
            ddlFrecuencia.Items.Add("4");
            ddlFrecuencia.Items.Add("8");
            ddlFrecuencia.SelectedIndex = frec;

            ddlMeses.Items.Add("1");
            ddlMeses.Items.Add("3");
            ddlMeses.Items.Add("6");
            ddlMeses.Items.Add("12");
            ddlMeses.SelectedIndex = mes;

        }
    }
}
