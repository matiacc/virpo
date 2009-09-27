using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaNegocio.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class CategoriaArticuloWikiFactory
    {
        public static CategoriaArticuloWiki Devolver(int id)
        {
            string query = "SELECT id, nombre " +
                          "FROM CategoriaArticuloWiki " +
                          "WHERE id = " + id;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                CategoriaArticuloWiki cat = new CategoriaArticuloWiki();
                cat.Id = id;
                cat.Nombre = dt.Rows[0]["nombre"].ToString();

                return cat;
            }
            else
            {
                return null;
            }
        }

        public static List<CategoriaArticuloWiki> DevolverTodos()
        {
            string query = "SELECT id, nombre " +
                           "FROM CategoriaArticuloWiki ";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                
                List<CategoriaArticuloWiki> categorias = new List<CategoriaArticuloWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoriaArticuloWiki cat = new CategoriaArticuloWiki();
                    cat.Id = (int)dt.Rows[i]["id"];
                    cat.Nombre = dt.Rows[i]["nombre"].ToString();
                    categorias.Add(cat);

                }
                return categorias;
            }
            else 
            {
                return null;            
            }
        }

        #region Eliminar

        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }

        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("CategoriaArticuloWikiBorrar", parametros, tran);
                if (ok)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}
