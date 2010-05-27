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
        if (Request.QueryString["C"]!= null)
        {
            int c =Convert.ToInt32(Request.QueryString["C"]);
            if (c == 1)
            {
                lblOk.Visible = true;
            } 
            if (c ==0)
            {
                lblMal.Visible = true;
            }
        }
    }
}
