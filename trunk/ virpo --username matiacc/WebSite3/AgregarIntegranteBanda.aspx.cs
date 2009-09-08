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

public partial class AgregarIntegranteBanda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario musico = new Usuario();
            musico = (Usuario)Session["Usuario"];
            MetodosComunes.cargarMisBandas(ddlMisBandas, int.Parse(musico.Id.ToString()));
            MetodosComunes.CargarListadoMusicos(lbMusicos);


        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        lbNvosIntegrantes.Items.Add(new ListItem(lbMusicos.SelectedItem.Text, lbMusicos.SelectedItem.Value));
    }
    protected void btnQuitar_Click(object sender, EventArgs e)
    {
        lbNvosIntegrantes.Items.Remove(new ListItem(lbNvosIntegrantes.SelectedItem.Text, lbNvosIntegrantes.SelectedItem.Value));
    }
    protected void btnAgregarIntegrante_Click(object sender, EventArgs e)
    {
        DateTime fAgregado = DateTime.Now;
        MusicoXBanda mxbanda = new MusicoXBanda();
        
        if (ddlMisBandas.SelectedValue != "" && lbNvosIntegrantes.Items.Count > 0)
        {
            foreach (ListItem item in lbNvosIntegrantes.Items)
            {
                mxbanda.IdUsuario = int.Parse(item.Value);
                mxbanda.IdBanda = int.Parse(ddlMisBandas.SelectedValue);
                mxbanda.Creador = false;
                mxbanda.FecAgregado = fAgregado;
                MusicoXBandaFactory.Insertar(mxbanda);

            }
            ddlMisBandas.ClearSelection();
            lbMusicos.ClearSelection();
            lbNvosIntegrantes.Items.Clear();
            AlertJS("Los Integrantes fueron agregados a la Banda");

        }
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
}
