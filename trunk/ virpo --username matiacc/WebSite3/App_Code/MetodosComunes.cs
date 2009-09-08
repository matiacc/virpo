using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CapaDatos;

public static class MetodosComunes
{
    private static string cadena = BDUtilidades.Cadena;

    public static void CargarCombo(DropDownList combo, SqlDataReader dr, string text, string value)
    {
        while (dr.Read())
        {
            combo.Items.Add(new ListItem(dr[text].ToString(), dr[value].ToString()));
        }
    }

    public static void CargarCombo(DropDownList combo, SqlDataReader dr, string text, string value, string valorVacio)
    {
        while (dr.Read())
        {
            combo.Items.Add(new ListItem(dr[text].ToString(), dr[value].ToString()));
        }

        ListItem li = new ListItem(valorVacio, string.Empty);
        combo.Items.Insert(0, li);
    }
    public static void cargarInstrumentos(DropDownList ddl)
    {
        string query = "SELECT id, nombre FROM Instrumento";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarPaises(DropDownList ddl)
    {
        string query = "SELECT id, nombre FROM Pais";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarProvincias(DropDownList ddl)
    {
        string query = "SELECT id, nombre FROM Provincia";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarProvincias(DropDownList ddl, int idPais)
    {
        string query = "SELECT id, nombre FROM Provincia WHERE idPais = " + idPais;
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarLocalidades(DropDownList ddl)
    {
        string query = "SELECT id, nombre FROM Localidad";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarLocalidades(DropDownList ddl, int idProvincia)
    {
        string query = "SELECT id, nombre FROM Localidad WHERE idProvincia = " + idProvincia;

        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarGeneros(DropDownList ddl)
    {
        string query = "SELECT id, nombre FROM Genero";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una opción");
        dr.Close();
    }
    public static void cargarMisBandas(DropDownList ddl, int idMusico)
    {
        string query = "SELECT Banda.id, Banda.nombre FROM Banda INNER JOIN MusicoXBanda on Banda.id = MusicoXBanda.idBanda" +
            " WHERE idUsuario = " + idMusico;
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una Banda");
        dr.Close();
    }
    public static void cargarBandas(DropDownList ddl)
    {
        string query = "SELECT Banda.id, Banda.nombre FROM Banda";
        SqlDataReader dr = BDUtilidades.GetReader(query);


        CargarCombo(ddl, dr, "nombre", "id", "Seleccione una Banda");
        dr.Close();
    }
    public static void cargarRubro(DropDownList ddl)
    {
        string query = "SELECT * FROM Rubro where idRubroPadre is null";
        SqlDataReader dr = BDUtilidades.GetReader(query);

        CargarCombo(ddl, dr, "nombre", "id", "- Seleccione -");
        dr.Close();
    }
    public static void cargarSubRubro(DropDownList ddl, string rubroPadre)
    {
        string query = "SELECT * FROM Rubro where idRubroPadre = " + rubroPadre;
        SqlDataReader dr = BDUtilidades.GetReader(query);

        CargarCombo(ddl, dr, "nombre", "id", "");
        dr.Close();

    }

    //Carga de ListBox

    public static void CargarListBox(ListBox listbox, SqlDataReader dr, string text, string value)
    {
        while (dr.Read())
        {
            listbox.Items.Add(new ListItem(dr[text].ToString(), dr[value].ToString()));
        }
    }
    public static void CargarListadoMusicos(ListBox lb, int idBanda)
    {
        string query = "SELECT id, apellido +', '+ nombre AS nomape FROM Usuario INNER JOIN MusicoXBanda ON Usuario.id = MusicoXBanda.idUsuario WHERE idBanda = " + idBanda;
        SqlDataReader dr = BDUtilidades.GetReader(query);

        CargarListBox(lb, dr, "nomape", "id");
        dr.Close();

    }

    /* Copiar el siguiente metodo en el .aspx cuando quieras mostrar un alert
    public void AlertJS(string message)
    {
        string jscript = @"<SCRIPT language='javascript'>alert('" +
                         message +
                        "')</SCRIPT>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "buscar", jscript);
    }
     */
}
