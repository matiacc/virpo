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
using System.Collections.Generic;

public partial class ConsultarGrupo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["Id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Grupo grupo = new Grupo();
                grupo = GrupoFactory.Devolver(id);
                Session["Grupo"] = grupo;
                lblDebate.Text = "<a href='Debate.aspx?grupo=" + id + "'>Debates</a>";

                lblProyectos.Text = "<a href='Proyectos.aspx?grupo="+ id +"' title='Proyectos'>Proyectos</a>";

                if (Session["Usuario"] == null)
                {
                    lblMisGrupos.Text = "<a href='GruposDeInteres.aspx' title='Mis Grupos'>Mis Grupos</a>";
                    btUnirme.Visible = false;
                }
                else
                {
                    lblMisGrupos.Text = "<a href='GruposDeInteres.aspx?Id=" + ((Usuario)Session["Usuario"]).Id + "' title='Mis Grupos'>Mis Grupos</a>";
                    if (grupo.Creador.Id == ((Usuario)Session["Usuario"]).Id ||
                        GrupoFactory.EsMiembro(((Usuario)Session["Usuario"]).Id, id))
                    {
                        btUnirme.Text = "Salir del grupo";
                    }

                }
                
                ViewState.Add("idGrupo", id);
                ViewState.Add("mailCreador", grupo.Creador.EMail);
                lblCreador.Text = grupo.Creador.NombreUsuario;
                lblDescripcion.Text = grupo.Descripcion;
                //string[] enlaces = grupo.Enlaces.Split(' ');
                //foreach (string enlace in enlaces)
                //{
                //    lblEnlaces.Text += "<a href='" + enlace + "'>" + enlace + "</a>";
                //}
                imgGrupo.ImageUrl = grupo.Imagen;
                lblNombre.Text = grupo.Nombre;
                lblTema.Text = grupo.Tema;
                this.CargarMiembros(grupo.Id);
                lblCantMiembros.Text = GrupoFactory.CantidadMiembros(grupo.Id).ToString();
                
            }

        }
    }
    protected void btUnirme_Click(object sender, EventArgs e)
    {
        if (btUnirme.Text.Equals("Salir del grupo"))
        {
            AlertJS("¿Esta seguro que desea salir del grupo " + lblNombre.Text + "?");
            GrupoFactory.Borrar(((Usuario)Session["Usuario"]).Id, (int)ViewState["idGrupo"]);
            btUnirme.Text = "Unirme al Grupo!";
            Response.Redirect("ConsultarGrupo.aspx?Id=" + ViewState["idGrupo"].ToString());
        }
        else if (GrupoFactory.UsuarioXGrupoInsertar(((Usuario)Session["Usuario"]).Id, (int)ViewState["idGrupo"]))
            {
                string asunto = "Virpo: Tu grupo "+ lblNombre.Text +" tiene un nuevo miembro!!!";
                string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/Login.aspx?url=ConsultarGrupo.aspx?id=" + ViewState["idGrupo"].ToString();
                //string url = "http://127.0.0.1:50753/WebSite3/inicio.aspx";
                //DEVOLVER NOMBRE Y EMAIL DEL CREADOR
                string mensaje = "Hola <b>" + lblCreador.Text + "</b>, un Músico se ha unido al grupo <b>" + lblNombre.Text + "</b> que creaste en Virpo.<br /><br />Ingresa al sitio para mas informacion:<br /><br /><a href='" + url + " '>Virpo Web</a><br /><br /><br />";
                EnviarMail.Mande("Virpo", ViewState["mailCreador"].ToString(), asunto, mensaje);

                //Registrar las Adhesiones al Grupo en la tabla "BandejaDeEntrada"
                BandejaDeEntrada bande = new BandejaDeEntrada();
                bande.UsrDestinatario = ((Grupo)Session["Grupo"]).Creador.Id;
                bande.UsrRemitente = int.Parse(((Usuario)Session["Usuario"]).Id.ToString());
                bande.Fecha = DateTime.Now;
                bande.IdBanda = 0;
                bande.IdAviso = 0;
                bande.AvisoMotivo = "NULL";
                bande.IdGrupo = int.Parse(ViewState["idGrupo"].ToString());
                bande.IdProyecto = 0;
                
                BandejaDeEntradaFactory.Insertar(bande);

                this.CargarMiembros((int)ViewState["idGrupo"]);
                Panel1_ModalPopupExtender.Show();
            }
    }
    private void CargarMiembros(int idGrupo)
    {
        List<Usuario> usuarios = UsuarioFactory.DevolverIntegrantesDeGrupo(idGrupo);
        string html = "<table>";

        for (int i = 0; i < usuarios.Count; i++)
        {
            if (i == 6)
                break;
            if (i % 2 == 0)
                html += "<tr>";
            html += "<td>";
            html += "<a href='PerfilPublico.aspx?Id=" + usuarios[i].Id + "' title='" + usuarios[i].NombreUsuario + "'>" +
                "<img src='./ImagenesUsuario/" + usuarios[i].Imagen + "' width='100' border='0' height='70'></a>";
            html += "</td>";
            if (i % 2 != 0)
                html += "</tr>";
        }
        if (usuarios.Count % 2 == 0 || usuarios.Count == 1) html += "</tr>";
        html += "</table>";
        lblMiembros.Text = html;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultarGrupo.aspx?Id=" + ViewState["idGrupo"].ToString());
    }
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
}
