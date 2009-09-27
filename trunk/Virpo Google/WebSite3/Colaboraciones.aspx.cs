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

public partial class _Default : System.Web.UI.Page
{
    protected string mp3_seleccionado = "";
    protected string mp3_seleccionado_titulo = "";
    protected string reproducir = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        mp3_seleccionado = "";
        mp3_seleccionado_titulo = "";
        reproducir = "no";

    }
      protected void btn_stones_Click(object sender, EventArgs e)
    {
        this.mp3_seleccionado = "stones.mp3";
        this.mp3_seleccionado_titulo= "Rolling Stones - Start Me Up";
        this.reproducir = "yes";
        Page.DataBind();
    }
    protected void btn_acdc_Click(object sender, EventArgs e)
    {
        this.mp3_seleccionado = "acdc.mp3";
        this.mp3_seleccionado_titulo = "AC/DC - Live in tokio";
        this.reproducir = "yes";
        Page.DataBind();
    }

      
      
     

    

}
