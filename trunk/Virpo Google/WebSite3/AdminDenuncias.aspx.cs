using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UsuarioAdmin"] == null) Response.Redirect("admin.aspx");
            List<Denuncia> denuncias = new List<Denuncia>();
            denuncias = DenunciaFactory.DevolverTodos();
            if (denuncias.Count > 0) cargarTabla(denuncias);
            else lblListadoDenuncias.Text = "No hay Denuncias reportadas.";
        }
    }

    private void cargarTabla(List<Denuncia> denuncias)
    {
        string html = "";
        foreach (Denuncia denuncia in denuncias)
        {
            html += "<tr>";
            html += "    <td style='width: 50px' align='center'><a href='PerfilPublico.aspx?Id=" + denuncia.IdDenunciante.ToString() + "'>";
            html += "<img title='" + denuncia.UsrDenunciante + "' src='ImagenesUsuario/" + ((Usuario)UsuarioFactory.Devolver(denuncia.UsrDenunciante)).Imagen + "'/></a>";
            html += "<br />" + denuncia.UsrDenunciante + "</td>";
            html += "    <td style='width: 429px' align='left'>" + "Nro. de Denuncia: " + denuncia.Id.ToString();
            html += "<br />Fecha: " + denuncia.Fecha.ToString();
            html += "<br />Sección: " + denuncia.Tipo;
            html += "<br />Documento Denunciado: <a class='feed-link' href='" + denuncia.Url + "&leida=" + denuncia.Id.ToString() + "' AutoPostBack='True' target='_blank' type='application/atom+xml'>" + denuncia.Descripcion + "</a>";
            html += "</td>";
            string leido="";
            if (denuncia.Leido.ToString() == "NO") leido=denuncia.Leido;
            html += "<td style='width: 50px' align='center'>" + leido;
            html += "<br />Leído";
            html += "</td>";
            html += "</tr>";
        }
        lblListadoDenuncias.Text = html;
    }
}
