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
            if (denuncias.Count > 0)
            {
                cargarTabla(denuncias);

                ArrayList tablas = DenunciaFactory.DevolverTablas();
                foreach (string tabla in tablas)
                {
                    switch (tabla)
                    {
                        case "Proyecto":
                            denuncias = DenunciaFactory.DevolverTodos("Proyecto");
                            cargarTabla(denuncias, lblDenunciasProyectos);
                            break;
                        
                        case "ArticuloWiki":
                            denuncias = DenunciaFactory.DevolverTodos("ArticuloWiki");
                            cargarTabla(denuncias, lblDenunciasWikiMusic);
                            break;

                        case "AvisoClasificado":
                            denuncias = DenunciaFactory.DevolverTodos("AvisoClasificado");
                            cargarTabla(denuncias, lblDenunciasClasificados);
                            break;

                        case "Banda":
                            denuncias = DenunciaFactory.DevolverTodos("Banda");
                            cargarTabla(denuncias, lblDenunciasBandas);
                            break;

                        case "Grupo":
                            denuncias = DenunciaFactory.DevolverTodos("Grupo");
                            cargarTabla(denuncias, lblDenunciasGrupos);
                            break;

                        case "Evento":
                            denuncias = DenunciaFactory.DevolverTodos("Evento");
                            cargarTabla(denuncias, lblDenunciasEventos);
                            break;

                        case "Usuario":
                            denuncias = DenunciaFactory.DevolverTodos("Usuario");
                            cargarTabla(denuncias, lblDenunciasUsuarios);
                            break;
                    }
                }

            }
            else
            {
                lblListadoDenuncias.Text = "No hay Denuncias reportadas.";
                TabContainer1.Height = Unit.Pixel(600);
            }
         
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
            html += "<br />Documento Denunciado: <a class='feed-link' href='" + denuncia.Url + "&leida=" + denuncia.Id.ToString() + "' target='_blank' type='application/atom+xml'>" + denuncia.Descripcion + "</a>";
            html += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;";
            html += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;";
            html += "&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input type='button' value='Dar de Baja' onClick='baja(" + denuncia.Id + ",1);'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp";
            html += "      <input type='button' value='Ignorar' onClick='ignorar(" + denuncia.Id + ",0);'>";
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
    private void cargarTabla(List<Denuncia> denuncias, Label lbl)
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
            html += "<br />Documento Denunciado: <a class='feed-link' href='" + denuncia.Url + "&leida=" + denuncia.Id.ToString() + "' target='_blank' type='application/atom+xml'>" + denuncia.Descripcion + "</a>";
            html += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;";
            html += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;";
            html += "&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input type='button' value='Dar de Baja' onClick='baja(" + denuncia.Id + ",1);'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp";
            html += "      <input type='button' value='Ignorar' onClick='ignorar(" + denuncia.Id + ",0);'>";
            html += "</td>";
            string leido = "";
            if (denuncia.Leido.ToString() == "NO") leido = denuncia.Leido;
            html += "<td style='width: 50px' align='center'>" + leido;
            html += "<br />Leído";
            html += "</td>";
            html += "</tr>";
        }
        lbl.Text = html;
    }
}
