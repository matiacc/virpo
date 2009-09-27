using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CapaNegocio.Entities;
using CapaNegocio.Factories;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage hdMaster = (MasterPage)this.Master;
        ((Label)hdMaster.FindControl("lblTitulo")).Text = "Estadisticas";

        
        GridView2.DataSource = PaisFactory.DevolverTodos();
        GridView2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Pais pais = new Pais();
        pais.Nombre = TextBox1.Text;
        pais.Descripcion = TextBox2.Text;
        if (PaisFactory.Insertar(pais))
            Label1.Text = "Insertado";
        else
            Label1.Text = "Error";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PaisFactory.Eliminar(Convert.ToInt32(TextBox3.Text));
    }
    
    protected void btBuscar_Click(object sender, EventArgs e)
    {
        Pais pais = PaisFactory.Devolver(Convert.ToInt32(TextBox4.Text));
        TextBox1.Text = pais.Nombre;
        TextBox2.Text = pais.Descripcion;
        TextBox3.Text = pais.Id.ToString();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Pais pais = new Pais();
        pais.Id = Convert.ToInt32(TextBox4.Text);
        pais.Nombre = TextBox1.Text;
        pais.Descripcion = TextBox2.Text;
        PaisFactory.Modificar(pais);
    }
}
