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

public partial class Bandeja : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<BandejaDeEntrada> bandejasB = BandejaDeEntradaFactory.DevolverBandasDeBandejaDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));
        List<BandejaDeEntrada> bandejasC = BandejaDeEntradaFactory.DevolverClasificadosDeBandejaDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));

        if (bandejasB.Count != 0)
        {
            CargarBandeja(bandejasB);
        }
        else
        {
            lblInvitacionesBandas.Text = "Actualmente no posee Invitaciones a Bandas.";
            //TabContainer1.Height = Unit.Pixel(600);
            TabContainer1.Height = Unit.Pixel(600);
        }
        if (bandejasC.Count != 0)
        {
            CargarGrilla(bandejasC);
        }
        else
        {
            lblAvisosClasificados.Text = "Actualmente no posee mensajes sobre Avisos Clasificados";
            //TabContainer1.Height = Unit.Pixel(600);
        }
    }

    private void CargarBandeja(List<BandejaDeEntrada> bandejasB)
    {
        //List<Invitacion> invitaciones = InvitacionFactory.DevolverInvitacionesDeUsuario(int.Parse(((Usuario)Session["Usuario"]).Id.ToString()));
        List<BandejaDeEntrada> bandejas = bandejasB;
        string html = "<table class='tabla' border='1' style='width: 529px'>";

        for (int i = 0; i < bandejas.Count; i++)
        {
            Banda xbanda = new Banda();
            xbanda = BandaFactory.Devolver(bandejas[i].IdBanda);
            Usuario usrRemitente = new Usuario();
            usrRemitente = UsuarioFactory.Devolver(bandejas[i].UsrRemitente);

            //if (i % 2 == 0)
            html += "<tr>";
            html += "<td align='center' colspan='2'>Tienes una invitación a una Banda.</td></tr>";
            html += @"<tr><td style='width: 210px'><div style='border: 3px solid rgb(192, 192, 192); position: relative; margin-top: 5px; margin-left: 5px; margin-right: 5px; "
                    + "margin-bottom: 5px; float: left;'><a class='blogHeadline' title='" + xbanda.Nombre
                    + "' href='ConsultarBanda.aspx?C=" + xbanda.Id + "&P=1'><img src='./ImagenesBandas/" + xbanda.Imagen + "' style='width:200px; height:200px;'/></a>"
                    + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
                    + " class='transparent_60'>" + xbanda.Nombre + "</h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
                    + ">" + xbanda.Nombre + "</h2><div style='padding: 5px; margin-top: 0px; width: 190px; position: absolute; left: 0px; bottom: 0px; background-color: black; color: white;'"
                    + " class='transparent_60'><a style='text-decoration: none; color: rgb(160, 160, 160);' href='PerfilPublico.aspx?Id=" + bandejas[i].UsrRemitente + "'>Invitado por: " + usrRemitente.NombreUsuario + "</a><br>"
                    + "<b>" + xbanda.PaginaWeb + "</b></div></div>"
                    + "</td><td style='width: 299px' align='left'>" + usrRemitente.Nombre + " " + usrRemitente.Apellido + " te ha invitado. <br /><br /><br /><br /><br /></td></tr><tr><td align='right' colspan='2'><input type='button' value='Aceptar' onclick='aceptar("
                    + bandejas[i].Id + "," + bandejas[i].UsrDestinatario + "," + bandejas[i].IdBanda + ",1)'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input type='button' value='Rechazar' onclick='rechazar(" + bandejas[i].Id + ",0)'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp</td></tr>";
        }
        html += "</table>";
        lblInvitacionesBandas.Text = html;
    }
    private void CargarGrilla(List<BandejaDeEntrada> BandejasC)
    {
        List<BandejaDeEntrada> bandejas = BandejasC;
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("idBandeja");
        dt.Columns.Add("interesado");
        dt.Columns.Add("fecha");
        dt.Columns.Add("idAviso");
        dt.Columns.Add("aviso");    
        for (int i = 0; i < bandejas.Count; i++)
        {
            row = dt.NewRow();
            row["idBandeja"] = bandejas[i].Id;
            row["interesado"] = (UsuarioFactory.Devolver(int.Parse(bandejas[i].UsrRemitente.ToString()))).NombreUsuario;
            row["fecha"] = bandejas[i].Fecha;
            row["idAviso"] = bandejas[i].IdAviso;
            row["aviso"] = (AvisoClasificadoFactory.Devolver(int.Parse(bandejas[i].IdAviso.ToString()))).Titulo;

            dt.Rows.Add(row);
        }

        gvAvisosClasificados.DataSource = dt;
        gvAvisosClasificados.DataBind();
    }
}
