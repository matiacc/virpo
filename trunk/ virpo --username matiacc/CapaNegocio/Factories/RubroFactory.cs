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
    public class RubroFactory
    {
        public static Rubro Devolver(int id)
        {
            string query = "SELECT nombre, idRubroPadre " +
                        "FROM Rubro " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Rubro rubro = new Rubro();
                rubro.Nombre = dt.Rows[0]["nombre"].ToString();
                if (dt.Rows[0]["idRubroPadre"] != DBNull.Value)
                    rubro.IdRubroPadre = Convert.ToInt32(dt.Rows[0]["idRubroPadre"]);
                else
                    rubro.IdRubroPadre = 0;
                rubro.Id = id;
                return rubro;
            }
            else
            {
                return null;
            }
        }

        public static List<Rubro> DevolverTodos()
        {
            string query = "SELECT id, nombre, idRubroPadre " +
                           "FROM Rubro";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Rubro> rubros = new List<Rubro>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Rubro rubro = new Rubro();
                    rubro.Id = (int)dt.Rows[i]["id"];
                    rubro.Nombre = dt.Rows[i]["nombre"].ToString();
                    rubro.IdRubroPadre = Convert.ToInt32(dt.Rows[i]["idRubroPadre"]);
                    rubros.Add(rubro);
                }
                return rubros;
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
        /// <param name="musico">objeto Rubro</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Rubro rubro)
        {
            return Insertar(rubro, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Rubro</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Rubro rubro, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, rubro.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@idRubroPadre", DbType.Int32, rubro.IdRubroPadre));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RubroInsertar", parametros, tran);
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
        /// <param name="musico">objeto Rubro</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Rubro rubro)
        {
            return Modificar(rubro, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un Rubro con transaccion
        /// </summary>
        /// <param name="musico">objeto Rubro</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Rubro rubro, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, rubro.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, rubro.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@idRubroPadre", DbType.Int32, rubro.IdRubroPadre));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RubroActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Rubro</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Rubro</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RubroBorrar", parametros, tran);
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
