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

public partial class Proyecto : System.Web.UI.Page
{
    protected string mp3_seleccionado = "";
    protected string mp3_seleccionado_titulo = "";
    protected string reproducir = "no";
        
    protected void Page_Load(object sender, EventArgs e)
    {
        mp3_seleccionado = "";
        mp3_seleccionado_titulo = "";
        reproducir = "no";
         

        if (!Page.IsPostBack)
        {
            

            if (Session["Usuario"] == null) Response.Redirect("ErrorAutentificacion.aspx");

            if (Request.QueryString["Id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                ViewState.Add("idProyecto", id);
                CapaNegocio.Entities.Proyecto proy = ProyectoFactory.Devolver(id);

                //Texto del boton
                //if(proy.Usuario.Id == ((Usuario)Session["Usuario"]).Id)
                if (ProyectoFactory.EsIntegrante(((Usuario)Session["Usuario"]).Id, id))
                    btUnirse.Text = "Subir una composicion";

                
                lblNombre.Text = proy.Nombre;
                lblDescripcion.Text = proy.Descripcion;
                lblFecha.Text = proy.FechaCreacion.ToShortDateString();
                lblGenero.Text = proy.Genero;
                Image1.ImageUrl = ResolveUrl(proy.Imagen);
                lblLicencia.Text = proy.Licencia;
                lblUsuario.Text = proy.Usuario.NombreUsuario;

                //ViewState.Add("mailCreador", proy.Usuario.EMail);
                //ViewState.Add("nombreCreador", proy.Usuario);
                //Colaboradores
                List<Usuario> usuarios = UsuarioFactory.DevolverIntegrantesDeProyecto(id);
                string html = "<table>";
        
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (i == 6)
                        break;
                    if(i%2 == 0)
                        html += "<tr>";
                    html += "<td>";
                    html += "<a href='PerfilPublico.aspx?Id=" + usuarios[i].Id + "' title='" + usuarios[i].NombreUsuario + "'>" +
                        "<img src='" + usuarios[i].Imagen + "' width='100' border='0' height='70'></a>";
                    html += "</td>";
                    if (i % 2 != 0)
                        html += "</tr>";
                }
                if (usuarios.Count % 2 == 0) html += "</tr>";
                html += "</table>";
                lblColaboradores.Text = html;

                //Composiciones
                DataTable dt = this.DatosComposiciones(id);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
                //string html2 = "<table>";
                //for (int i = 0; i < composiciones.Count; i++)
                //{
                //    html2 += "<tr>";
                //    html2 += "<td>";
                //    html2 += 
                //}
            }
            
        }

    }

    protected void btUnirse_Click(object sender, EventArgs e)
    {
        if (btUnirse.Text.Contains("Subir"))
        {
            string asunto = "Virpo: Un Músico se ha unido a tu proyecto!!!";
            //string url = Request.Url.ToString().Remove(Request.Url.ToString().LastIndexOf('/')) + "/inicio.aspx";
            string url = "http://127.0.0.1:50753/WebSite3/inicio.aspx";
            //DEVOLVER NOMBRE Y EMAIL DEL CREADOR
            string mensaje = "Hola " + ViewState["nombreCreador"].ToString() + "amigo/a, un Músico se ha unido a tu proyecto Virpo <b>" + lblNombre.Text + " y pronto comenzará a colaborar.<br /><br /><a href='" + url + " '>Virpo Web</a><br /><br /><br />";
            //EnviarMail.Mande("Virpo", ViewState["mailCreador"].ToString(), asunto, mensaje);
            Response.Redirect("CargarComposicion.aspx?idProyecto=" + ViewState["idProyecto"]);
        }
        else if (ProyectoFactory.InsertarUsuarioXProyecto(((Usuario)Session["Usuario"]).Id, (int)ViewState["idProyecto"], DateTime.Now))
            btUnirse.Text = "Subir una composicion";
    }

    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterStartupScript(this.GetType(), "buscar", jscript);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
            this.mp3_seleccionado = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[5].Text;
            this.mp3_seleccionado_titulo = GridView1.Rows[Convert.ToUInt16(e.CommandArgument)].Cells[1].Text;

            //string value = "Reproductor/mini_player_mp3.swf?my_mp3=Composiciones/" + mp3_seleccionado + "&amp;my_text=" + mp3_seleccionado_titulo + "&amp;autoplay=yes";
            //ClientScript.RegisterExpandoAttribute("movie", "value", value);
            this.reproducir = "yes";
            this.Page.DataBind();
        
    }
    private DataTable DatosComposiciones(int id)
    {
        DataTable dt = new DataTable();
        DataRow row;
        dt.Columns.Add("Ruta");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Instrumento");
        dt.Columns.Add("Usuario");
        dt.Columns.Add("Tipo");
        dt.Columns.Add("Ruta2");
        List<Composicion> composiciones = ComposicionFactory.DevolverXProyecto(id);

        if (composiciones != null)
        {
            foreach (Composicion composicion in composiciones)
            {
                row = dt.NewRow();
                row["Ruta"] = composicion.Audio;
                row["Ruta2"] =  composicion.Audio;
                row["Nombre"] = composicion.Nombre;
                if(composicion.Instrumento != null)
                    row["Instrumento"] = composicion.Instrumento.Nombre;
                row["Usuario"] = composicion.Usuario.NombreUsuario;
                row["Tipo"] = composicion.Tipo;
                dt.Rows.Add(row);
            }
            return dt;
        }
        return null;
    }
}
