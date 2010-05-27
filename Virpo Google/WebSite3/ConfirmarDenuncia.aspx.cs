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

public partial class ConfirmarDenuncia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["baj"] == "1")
            {
                Denuncia denuncia = new Denuncia();
                denuncia = DenunciaFactory.Devolver(int.Parse(Request.QueryString["idD"].ToString()));
                bool okBajaDoc;
                bool okBajaDen = DenunciaFactory.BorrarDenuncia(int.Parse(Request.QueryString["idD"].ToString())) ;
                switch (denuncia.Tabla)
                {
                    case "Proyecto":
                        okBajaDoc = ProyectoFactory.Eliminar(int.Parse(denuncia.IdDocDenunciado.ToString()));
                        break;

                    case "Banda":
                        okBajaDoc = BandaFactory.Eliminar(int.Parse(denuncia.IdDocDenunciado.ToString()));
                        break;

                    case "Grupo":
                        okBajaDoc = GrupoFactory.Eliminar(int.Parse(denuncia.IdDocDenunciado.ToString()));
                        break;

                    case "Usuario":
                        okBajaDoc = UsuarioFactory.Eliminar(int.Parse(denuncia.IdDocDenunciado.ToString()));
                        break;

                    default: 
                        okBajaDoc = DenunciaFactory.BorrarDocumentoDenunciado(denuncia.Tabla, denuncia.IdDocDenunciado);
                        break;
                }

                if (okBajaDen && okBajaDoc)
                {
                    Panel1_ModalPopupExtender.Show();
                }
            }
            if (Request.QueryString["baj"] == "0")
            {
                bool okBajaDen = DenunciaFactory.BorrarDenuncia(int.Parse(Request.QueryString["idD"].ToString()));

                if (okBajaDen)
                {
                    Panel2_ModalPopupExtender.Show();
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDenuncias.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDenuncias.aspx");
    }
}
