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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)           
        {
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
        //if ()
    }
}
