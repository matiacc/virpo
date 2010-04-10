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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["z"] != null)
            {
                int bandera = int.Parse(Request.QueryString["z"].ToString());
                if (bandera == 1) lblOk.Visible = true;
                if (bandera == 0) lblMal.Visible = true;
            }


        }

    }
}
