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
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlPosicion.Items.Add("Izquierda");
            ddlPosicion.Items.Add("Centro");
            ddlPosicion.Items.Add("Derecha");

            //recuperar noticia
            int id = Convert.ToInt32(Request.QueryString["M"]);
            Noticia noti = new Noticia();
            noti= NoticiasFactory.Devolver(id);
            elm3.Text = noti.Cuerpo;
            txtDesc.Text = noti.Descripcion;
            switch (noti.Posicion)
            {
                case "Izquierda": ddlPosicion.SelectedIndex = 0;
                    break;
                case "Centro": ddlPosicion.SelectedIndex = 1;
                    break;
                case "Derecha": ddlPosicion.SelectedIndex = 2;
                    break;
            }
        }

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        //aqui pongo la noticia modificada
        Noticia not = new Noticia();

        //recupero nuevamente la noticia sin modificar para copiar datos no modificados
        int id = Convert.ToInt32(Request.QueryString["M"]);
        Noticia noti = new Noticia();
        noti= NoticiasFactory.Devolver(id);

        not.Id = id;
        not.Descripcion = txtDesc.Text;
        not.Cuerpo = elm3.Text;
        not.FechaCreacion = noti.FechaCreacion;
        not.IdAutor=noti.IdAutor;
        not.Posicion= ddlPosicion.Text;
        not.EsVigente=1;
        not.CantVisitas=noti.CantVisitas;

        //guardo la noticia modificada
        if (NoticiasFactory.Modificar(not))
            Panel1_ModalPopupExtender.Show();
        else
            Panel2_ModalPopupExtender.Show();

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("NoticiasBajas.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("NoticiasBajas.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("NoticiasBajas.aspx");
    }
}
