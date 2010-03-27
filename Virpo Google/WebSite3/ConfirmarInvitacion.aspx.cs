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

public partial class ConfirmarInvitacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MusicoXBanda mxbanda = new MusicoXBanda();

            if (Request.QueryString["ace"] == "1")
            {
                mxbanda.IdUsuario = int.Parse(Request.QueryString["idU"].ToString());
                mxbanda.IdBanda = int.Parse(Request.QueryString["idB"].ToString());
                mxbanda.Creador = false;
                mxbanda.FecAgregado = DateTime.Now;

                bool okAlta = MusicoXBandaFactory.Insertar(mxbanda);
                bool okBaja = BandejaDeEntradaFactory.Borrar(int.Parse(Request.QueryString["idI"].ToString()));

                if(okAlta && okBaja)
                {
                    Panel1_ModalPopupExtender.Show();
                }
            }
            if (Request.QueryString["ace"] == "0")
            {
                bool okBaja = BandejaDeEntradaFactory.Borrar(int.Parse(Request.QueryString["idI"].ToString()));

                if (okBaja)
                {
                    Panel2_ModalPopupExtender.Show();
                } 
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bandeja.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bandeja.aspx");
    }
}
