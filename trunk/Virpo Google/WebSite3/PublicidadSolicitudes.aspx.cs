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
            DataTable dt = PublicidadFactory.DevolverXEstadoDT(0);//solicitado
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;

            if (dt.Rows.Count == 0)
            {
                lblVacio.Visible = true;
            }

            if (Request.QueryString["C"] != null)
            {
                int c = Convert.ToInt32(Request.QueryString["C"]);
                if (c == 0)
                {
                    lblMal.Visible = true;
                }
                if (c == 1)
                {
                    lblOk.Visible = true;
                }
                if (c == 2)
                {
                    lblOk2.Visible = true;
                }                                
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "C")
        {
            string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=0");
        }
    }
}
