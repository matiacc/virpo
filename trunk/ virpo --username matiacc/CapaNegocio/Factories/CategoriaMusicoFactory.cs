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
    public class CategoriaMusicoFactory
    {
        public static CategoriaMusico Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM CategoriaMusico " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                CategoriaMusico categoria = new CategoriaMusico();
                categoria.Nombre = dt.Rows[0]["nombre"].ToString();
                categoria.Descripcion = dt.Rows[0]["descripcion"].ToString();
                categoria.Id = id;
                return categoria;
            }
            else
            {
                return null;
            }
        }

        public static List<CategoriaMusico> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM CategoriaMusico";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<CategoriaMusico> categorias = new List<CategoriaMusico>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoriaMusico categoria = new CategoriaMusico();
                    categoria.Id = (int)dt.Rows[i]["id"];
                    categoria.Nombre = dt.Rows[i]["nombre"].ToString();
                    categoria.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    categorias.Add(categoria);
                }
                return categorias;
            }
            else
            {
                return null;
            }
        }

        #region Insertar
        /// <summary>
        /// Alta de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto CategoriaMusico</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(CategoriaMusico categoria)
        {
            return Insertar(categoria, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto CategoriaMusico</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(CategoriaMusico categoria, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, categoria.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, categoria.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("CategoriaMusicoInsertar", parametros, tran);
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

        #region Modificar
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto CategoriaMusico</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(CategoriaMusico categoria)
        {
            return Modificar(categoria, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto CategoriaMusico</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(CategoriaMusico categoria, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, categoria.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, categoria.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, categoria.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("CategoriaMusicoActualizar", parametros, tran);
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

        #region Eliminar

        /// <summary>
        /// Eliminar un registro sin transacción
        /// </summary>
        /// <param name="musico">Objeto CategoriaMusico</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto CategoriaMusico</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("CategoriaMusicoBorrar", parametros, tran);
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