﻿using System;
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
using Subgurim.Controles;
using CapaNegocio.Entities;
using CapaNegocio.Factories;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    int idU;

    protected void Page_Load(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["E"]);
        Evento evento = EventoFactory.Devolver(id);
        
        setearMapa();

        Ubicar(evento.Ubicacion);

        Image1.ImageUrl = evento.Imagen;
        lblNombre.Text = evento.Nombre;
        lblLugar.Text = evento.Lugar;
        lblFecha.Text = Convert.ToString(evento.Fecha.Day)+"/"+Convert.ToString(evento.Fecha.Month)+"/"+Convert.ToString(evento.Fecha.Year);
        lblHora.Text = Convert.ToString(evento.Hora.Hour) + ":" + Convert.ToString(evento.Hora.Minute);
        char[] delimiterChars = {','};
        string[] ub = evento.Ubicacion.Split(delimiterChars);
        lblPais.Text = ub[2];
        lblCiudad.Text = ub[1];
        lblUbicacion.Text = ub[0];
        Usuario u = (Usuario)Session["Usuario"];

        idU = evento.Musico.Id;
        /*
        if (u.Id != idU)ImageButton1.ImageUrl = "./ImagenesUsuario/" + evento.Musico.Imagen;
        else
        {
            //Label14.Visible = false;
            ImageButton1.Visible = false;
        }*/
        CargarBanda(evento.Banda);



    }

    private void setearMapa()
    {
        GMap1.enableDragging = true;
        GMap1.Language = "es";
        //GMap1.enableGKeyboardHandler = true;
        GMapUIOptions options = new GMapUIOptions();
        options.maptypes_hybrid = false;
        options.keyboard = false;
        options.maptypes_physical = false;
        options.zoom_scrollwheel = true;
        GMap1.Add(new GMapUI(options));
        

    }

    private void Ubicar(String direccion)
    {
                
            string Key = System.Configuration.ConfigurationManager.AppSettings.Get("googlemaps.subgurim.net");

            GeoCode geocode = GMap.geoCodeRequest(direccion, Key);
            Double lat = geocode.Placemark.coordinates.lat;;
            Double lng = geocode.Placemark.coordinates.lng;
            GLatLng ubicacion = new GLatLng(lat,lng);
            GInfoWindowOptions options = new GInfoWindowOptions();
            options.zoomLevel = 14;
            options.mapType = GMapType.GTypes.Hybrid;
            GShowMapBlowUp mBlowUp = new GShowMapBlowUp(new GMarker(ubicacion), options);
            GMap1.addShowMapBlowUp(mBlowUp);
            GMap1.setCenter(ubicacion, 15);
            
                         
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("PerfilPublico.aspx?Id=" + idU);

    }

    private void CargarBanda(Banda banda)
    {
        
        
        string html = "<table>";
            html += "<tr>";
            html += "<td>";
            html += @"<div style='border: 0px solid rgb(192, 192, 192); position: relative; margin-right: 15px; "
            + "margin-bottom: 15px; float: left;'><a class='blogHeadline' title='" + banda.Nombre +
            "' href='ConsultarBanda.aspx?C=" + banda.Id + "&P=1'><img src='./ImagenesBandas/" + banda.Imagen + "' style='width:150px; height:150px;'/></a>"
            + "<h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; background-color: black; color: rgb(51, 51, 51);'"
            + " class='transparent_60'><font size='2'>" + banda.Nombre + "</font></h2><h2 style='padding: 5px; margin-top: 0px; position: absolute; left: 0px; top: 0px; color: white;'"
            + "><font size='2'>" + banda.Nombre + "</font></h2>";
            html += "</td>";
           
       
        html += "</table>";
        lblBanda.Text = html;
    }

}
