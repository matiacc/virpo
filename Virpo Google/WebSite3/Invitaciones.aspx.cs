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

public partial class Invitaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<BandejaDeEntrada> invitaciones = BandejaDeEntradaFactory.DevolverClasificadosDeBandejaDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));

        if (invitaciones.Count != 0)
        {
            CargarInvitaciones(invitaciones);
        }
        else lblInvitaciones.Text = "Actualmente no posee Invitaciones.";
    }

    private void CargarInvitaciones(List<BandejaDeEntrada> invita)
    {
        //List<Invitacion> invitaciones = InvitacionFactory.DevolverInvitacionesDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));
        List<BandejaDeEntrada> invitaciones = invita;
        string html = "<table style='width: 100%'>";

        for (int i = 0; i < invitaciones.Count; i++)
        {
            Banda xbanda=new Banda();
            xbanda = BandaFactory.Devolver(invitaciones[i].IdBanda);
            Usuario usrInvitador = new Usuario();
            usrInvitador = UsuarioFactory.Devolver(invitaciones[i].UsrRemitente);

            //if (i % 2 == 0)
            html += "<tr>";
            html += "<td colspan='2'>Tienes una invitación a una Banda.</td></tr>";
            html += @"<tr><td><div style='border: 0px solid rgb(192, 192, 192); position: relative; margin-right: 15px; "
                    + "margin-bottom: 15px; float: left;'><a class='blogHeadline' title='" + xbanda.Nombre
                    + "' href='ConsultarBanda.aspx?C=" + xbanda.Id + "&P=1'><img src='./ImagenesBandas/" + xbanda.Imagen + "' style='width:200px; height:200px;'/></a>"
                    + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
                    + " class='transparent_60'>" + xbanda.Nombre + "</h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
                    + ">" + xbanda.Nombre + "</h2><div style='padding: 5px; margin-top: 0px; width: 190px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;'"
                    + " class='transparent_60'><a style='text-decoration: none; color: rgb(160, 160, 160);' href='PerfilPublico.aspx?Id=" + invitaciones[i].UsrRemitente + "'>Invitado por: " + usrInvitador.NombreUsuario + "</a><br>"
                    + "<b>" + xbanda.PaginaWeb + "</b></div></div>"
                    + "</td><td>" + usrInvitador.Nombre + " " + usrInvitador.Apellido + " te ha invitado. <br /><br /><br /><br /><br /></td></tr><tr><td colspan='2'><input type='button' value='Aceptar' onclick='aceptar("
                    + invitaciones[i].Id + "," + invitaciones[i].UsrDestinatario + "," + invitaciones[i].IdBanda + ",1)'><input type='button' value='Rechazar' onclick='rechazar(" + invitaciones[i].Id + ",0)'><br /><br /></td></tr>";
          }
        html += "</table>";
        lblInvitaciones.Text = html;
        }
}
