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

public partial class ConfirmacionUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idBanda"] == null && Request.QueryString["idUsr"] == null)
        {
            if (Request.QueryString["Id"] != null)
            {
                string id = Request.QueryString["Id"];

                if (Session["Usuario"] == null)
                    Response.Redirect("Login.aspx?url=ConfirmacionUsuario.aspx&id=" + id);
            }
        }
        else 
        {
            Panel1_ModalPopupExtender.Show();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MusicoXBanda mxbanda = new MusicoXBanda();
        mxbanda.IdUsuario = int.Parse(Request.QueryString["idUsr"].ToString());
        mxbanda.IdBanda = int.Parse(Request.QueryString["idBanda"].ToString());
        mxbanda.Creador = false;
        mxbanda.FecAgregado = DateTime.Now;
        MusicoXBandaFactory.Insertar(mxbanda);
        Response.Redirect("ConsultarBanda.aspx?C=" + mxbanda.IdBanda + "&P=1");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
}
