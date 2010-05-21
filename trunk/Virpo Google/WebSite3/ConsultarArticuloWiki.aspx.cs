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
            if(DenunciaFactory.HayDenunciaDeWikiMusic(Convert.ToInt32(Request.QueryString["C"])) != 0)
            {
                btnDenunciar.Text = "Denunciado";
                btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
                btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
                btnDenunciar.Enabled = false;
            }
            
            ArticuloWiki art = new ArticuloWiki();

            int id = Convert.ToInt32(Request.QueryString["C"]);
            int vers = Convert.ToInt32(Request.QueryString["V"]);
            Session["urlWiki"] = Request.Url.ToString();
            
            int apun;
            if (Request.QueryString["Z"] != null) // bloque resultado Apuntar
            {
                string z = Request.QueryString["Z"].ToString();
                apun = Convert.ToInt32(z);
                if (apun == 1) lblOk.Visible = true;
                if (apun == 0) lblMal.Visible = true;
            }

            if (id != 0)// bloque muestra articulo/historial especifico
            {
                
                art = (ArticuloWiki)ArticuloWikiFactory.Devolver(id, vers);
                if (art!= null)
	            {                    
                    lblVisitas.Text = Convert.ToString(art.CantVisitas);
                    art.CantVisitas = art.CantVisitas + 1;
                    ArticuloWikiFactory.Modificar(art);                  // suma visitas  
	            }                 
                else
                {                    
                    Label1.Visible=false;
                    btnApuntar.Visible = false;
                    //btnDenunciar.Visible = false;
                    btnRecomendar.Visible = false;
                    btnEditar.Visible = false;

                    HistorialWiki version = (HistorialWiki)HistorialWikiFactory.Devolver(id,vers);
                    art = ArticuloWikiFactory.ConvertirAArticuloWiki(version);
                }                    
            }
            

            if (Request.QueryString["A"] != null)// bloque aleatorio
            {
                List<int> ids = new List<int>();
                ids = ArticuloWikiFactory.DevolverIds();
                int cantArt = ids.Count;
                int random = new Random().Next(cantArt);
                int idExistente = (int)ids[random];
                art = ArticuloWikiFactory.Devolver(idExistente);
                lblVisitas.Text = Convert.ToString(art.CantVisitas);
                art.CantVisitas = art.CantVisitas + 1;
                ArticuloWikiFactory.Modificar(art);                  // suma visitas  
	            
            }

            lblId.Text = Convert.ToString(art.Id);

            lblvers.Text = Convert.ToString(art.Version);

            lblTitulo.Text = art.Titulo;

            lblCat.Text = art.IdCat.Nombre;            

            lblContenido.Text = art.Cuerpo;
        }
    }


    protected void btnApuntar_Click(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
        int idArt = Convert.ToInt32(this.lblId.Text);
        int vers = Convert.ToInt32(this.lblvers.Text);
        Usuario usu = (Usuario)Session["Usuario"];

        ApuntesWiki apunte = new ApuntesWiki();
        apunte.IdArticulo = idArt;
        apunte.IdMusico = usu.Id;
        apunte.FechaAlta = DateTime.Now;


        if (ApuntesWikiFactory.Insertar(apunte))
            Response.Redirect("ConsultarArticuloWiki.aspx?Z=1&C=" + idArt+"&V="+vers);
        else
            Response.Redirect("ConsultarArticuloWiki.aspx?Z=0&C=" + idArt+"&V="+vers);
    }



    protected void btnEditar_Click(object sender, EventArgs e)
    {
        //if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");
        //Usuario usu = (Usuario)Session["Usuario"];
        int idArt = Convert.ToInt32(this.lblId.Text);

        Response.Redirect("ModificarArticuloWiki.aspx?C=" + idArt);


    }
    protected void btnHistorial_Click(object sender, EventArgs e)
    {
        int idArt = Convert.ToInt32(this.lblId.Text);

        Response.Redirect("HistorialArticuloWiki.aspx?C=" + idArt);
    }



    protected void btnDenunciar_Click(object sender, EventArgs e)
    {
        if (btnDenunciar.Text == "Denunciar")
        {
            btnDenunciar.Text = "Denunciado";
            btnDenunciar.ControlStyle.BorderColor = System.Drawing.Color.Red;
            btnDenunciar.ControlStyle.ForeColor = System.Drawing.Color.Red;
            btnDenunciar.Enabled = false;

            Usuario usr = new Usuario();
            usr = (Usuario)Session["Usuario"];
            Denuncia denuncia = new Denuncia();
            denuncia.IdDenunciante = (int)usr.Id;
            denuncia.UsrDenunciante = usr.NombreUsuario.ToString();
            denuncia.Url = Request.Url.ToString();
            denuncia.Descripcion = lblTitulo.Text.ToString();
            denuncia.Tipo = "Artículo WikiMusic";
            denuncia.Fecha = DateTime.Now;
            denuncia.IdArticuloWiki = Convert.ToInt32(Request.QueryString["C"]);
            denuncia.IdEvento = 0;
            denuncia.IdGrupo = 0;
            denuncia.IdProyecto = 0;
            denuncia.IdComposicion = 0;
            denuncia.IdBanda = 0;
            denuncia.IdClasificado = 0;
            denuncia.IdUsuario = 0;

            bool ok = DenunciaFactory.Insertar(denuncia);

            if (ok)
            {
                lblTitulo.Text = "SE GRABO";
            }
        }
    }
}
