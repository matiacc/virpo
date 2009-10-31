using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Entities;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class ImagenClasificadoFactory
    {
        public static List<string> Devolver(int idClasificado)
        {
            string query = "SELECT nombre " +
                           "FROM ImagenClasificado " +
                           "WHERE idClasificado = " + idClasificado;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<string> imagenes = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    imagenes.Add(dt.Rows[i]["nombre"].ToString());
                }
                return imagenes;
            }
            return null;
        }
        public static bool Insertar(string nombre, int idClasificado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, nombre));
            parametros.Add(BDUtilidades.crearParametro("@idClasificado", DbType.Int32, idClasificado));

            bool ok = BDUtilidades.ExecuteStoreProcedure("ImagenClasificadoInsertar", parametros);

            if (ok)
                return true;
            else
                return false;
        }
        public static int DevolverMaxId()
        {
            string query = "SELECT MAX(ID) FROM ImagenClasificado";

            return BDUtilidades.EjecutarConsultaEscalar(query);
        }
        
    }
}
