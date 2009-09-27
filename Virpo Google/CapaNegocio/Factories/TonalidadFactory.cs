using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Entities;
using CapaDatos;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class TonalidadFactory
    {

        public static Tonalidad Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        " FROM Tonalidad " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Tonalidad tonalidad = new Tonalidad();
                tonalidad.Id = id;
                tonalidad.Nombre = dt.Rows[0]["nombre"].ToString();
                tonalidad.Descripcion = dt.Rows[0]["descripcion"].ToString();

                return tonalidad;
            }
            else
            {
                return null;
            }

        }

        public static List<Tonalidad> DevolverTodos(string restriccion)
        {
            string query = "SELECT nombre, descripcion" +
                        "FROM Tonalidad ";

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Tonalidad> tonalidades = new List<Tonalidad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Tonalidad tonalidad = new Tonalidad();
                    tonalidad.Id = (int)dt.Rows[i]["id"];
                    tonalidad.Nombre = dt.Rows[i]["nombre"].ToString();
                    tonalidad.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    tonalidades.Add(tonalidad);
                }
                return tonalidades;
            }
            else
            {
                return null;
            }
        }        



    }
}
