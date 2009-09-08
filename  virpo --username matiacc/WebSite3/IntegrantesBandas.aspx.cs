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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre Banda");
            

            List<Banda> bandas= new List<Banda>();
            bandas = BandaFactory.DevolverBandasDeIntegrante(1);

            foreach (Banda  banda in bandas)
            {
                row = dt.NewRow();
                row["Id"]=banda.Id;
                row["Nombre Banda"]=banda.Nombre;
                dt.Rows.Add(row);
            }
            gwBandas.DataSource = dt;
            gwBandas.DataBind();

        }

    }
}
