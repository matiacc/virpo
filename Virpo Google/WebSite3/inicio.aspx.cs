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
        if (Request.QueryString["Logout"] != null)
        {
            Session.Clear();
            
        }
        if (Session["Usuario"] != null)
            PanelRegistrarme.Visible = false;
        CagarNoticias();
    }
    public void CagarNoticias()
    {
 
        List<Noticia> vigentes = new List<Noticia>();
        vigentes = NoticiasFactory.DevolverVigentes();
        int i = 0;
        int c = 0;
        int d = 0;
        foreach (Noticia  not in vigentes)
        {
           
            if(not.Posicion.CompareTo("Izquierda")==0)
            {   i++;
                if (i <= 3)
                {
                    switch (i)
                    {
                        case 1: izq1.Text = not.Cuerpo;
                            break;
                        case 2: izq2.Text = not.Cuerpo;
                            break;
                        case 3: izq3.Text = not.Cuerpo;
                            break;
                    }
                }
            }
            if(not.Posicion.CompareTo("Centro")==0)
            {
                c++;
                if (c <= 6)
                {
                    switch (c)
                    {
                        case 1: cen1.Text = not.Cuerpo;
                            break;
                        case 2: cen2.Text = not.Cuerpo;
                            break;
                        case 3: cen3.Text = not.Cuerpo;
                            break;
                        case 4: cen4.Text = not.Cuerpo;
                            break;
                        case 5: cen5.Text = not.Cuerpo;
                            break;
                        case 6: cen6.Text = not.Cuerpo;
                            break;
                    } 
                }
            }
            if (not.Posicion.CompareTo("Derecha") == 0)
            {
                d++;
                if (d <= 3)
                {
                    switch (d)
                    {
                        case 1: der1.Text = not.Cuerpo;
                            break;
                        case 2: der2.Text = not.Cuerpo;
                            break;
                        case 3: der3.Text = not.Cuerpo;
                            break;
                    } 
                }
                
            }            
        }
    }
}
