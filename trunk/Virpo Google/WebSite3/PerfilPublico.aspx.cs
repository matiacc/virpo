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
using CapaNegocio.Factories;
using System.IO; 

public partial class PerfilPublico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usr = new Usuario();
            usr = UsuarioFactory.Devolver(int.Parse(Request.QueryString["Id"].ToString()));
            ImgPerfil.ImageUrl = usr.Imagen;
            lblLogin.Text = usr.NombreUsuario;
            lblNombre.Text = usr.Nombre;
            lblApellido.Text = usr.Apellido;
            lblInstrumento.Text = (InstrumentoFactory.Devolver(int.Parse(usr.IdInstrumento.ToString()))).Nombre;
            lblFecNac.Text = usr.FecNac.ToShortDateString();
            if (usr.Sexo.ToString() == "M") lblSexo.Text = "Masculino";
            else lblSexo.Text = "Femenino";
            lbleMail.Text = usr.EMail;
            Localidad loc = new Localidad();
            loc = LocalidadFactory.Devolver(int.Parse(usr.IdLocalidad.ToString()));
            lblLocalidad.Text = loc.Nombre;
            lblProvincia.Text = loc.Provincia.Nombre;
            lblPais.Text = loc.Provincia.Pais.Nombre;
        }
    }
}