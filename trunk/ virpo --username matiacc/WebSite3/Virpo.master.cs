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
using CapaNegocio.Entities;

public partial class musicamania_Virpo : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
        {
            lblNombreUsuario.Text = ((Usuario)Session["Usuario"]).Nombre;
            lblNombreUsuario.ForeColor = System.Drawing.Color.DarkOrange;
            hlinkIniciarSesion.Text = "(Cerrar Sesion)";
            hlinkIniciarSesion.NavigateUrl = "inicio.aspx?Logout=1";
        }
        
    }
    
}
