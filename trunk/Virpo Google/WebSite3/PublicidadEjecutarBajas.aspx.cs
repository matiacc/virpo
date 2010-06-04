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
            int ok = PublicidadFactory.ActualizarVencidas(DateTime.Now);
            DataTable dt = PublicidadFactory.DevolverXEstadoDT(3);//pendiente de baja
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
        string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        if (e.CommandName == "C")
        {
            
            Response.Redirect("PublicidadModificar.aspx?I=" + id + "&EP=3");
        }
        
        if (e.CommandName == "E")
        {
            int ID= Convert.ToInt32(id);
            Publicidad publi = PublicidadFactory.Devolver(ID);
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

            if (PublicidadFactory.Eliminar(ID))
            {
                Response.Redirect("PublicidadEjecutarBajas.aspx?c=1");
            }
            else
            {
                Response.Redirect("PublicidadEjecutarBajas.aspx?c=0");    
            }            
        }
    }
}
