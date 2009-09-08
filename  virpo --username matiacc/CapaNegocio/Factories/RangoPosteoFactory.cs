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
    public class RangoPosteoFactory
    {
        public static RangoPosteo Devolver(int id)
        {
            string query = "SELECT nombre, descripcion, permiso, imagen, limiteSup " +
                        "FROM RangoPosteo " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                RangoPosteo rango = new RangoPosteo();
                rango.Nombre = dt.Rows[0]["nombre"].ToString();
                rango.Descripcion = dt.Rows[0]["descripcion"].ToString();
                rango.Permiso = dt.Rows[0]["permiso"].ToString();
                rango.Imagen = dt.Rows[0]["imagen"].ToString();
                rango.LimiteSup = (int)dt.Rows[0]["limiteSup"];
                rango.Id = id;
                return rango;
            }
            else
            {
                return null;
            }
        }

        public static List<RangoPosteo> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion, permiso, imagen, limiteSup " +
                           "FROM RangoPosteo";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<RangoPosteo> rangos = new List<RangoPosteo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RangoPosteo rango = new RangoPosteo();
                    rango.Id = (int)dt.Rows[i]["id"];
                    rango.Nombre = dt.Rows[i]["nombre"].ToString();
                    rango.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    rango.Permiso = dt.Rows[i]["permiso"].ToString();
                    rango.Imagen = dt.Rows[i]["imagen"].ToString();
                    rango.LimiteSup = (int)dt.Rows[i]["limiteSup"];
                    rangos.Add(rango);
                }
                return rangos;
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
        /// <param name="musico">objeto RangoPosteo</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(RangoPosteo rango)
        {
            return Insertar(rango, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto RangoPosteo</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(RangoPosteo rango, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, rango.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, rango.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@permiso", DbType.String, rango.Permiso));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, rango.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@limiteSup", DbType.Int32, rango.LimiteSup));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RangoPosteoInsertar", parametros, tran);
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
        /// <param name="musico">objeto RangoPosteo</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(RangoPosteo rango)
        {
            return Modificar(rango, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto RangoPosteo</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(RangoPosteo rango, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, rango.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, rango.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, rango.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@permiso", DbType.String, rango.Permiso));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, rango.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@limiteSup", DbType.Int32, rango.LimiteSup));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RangoPosteoActualizar", parametros, tran);
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
        /// <param name="musico">Objeto RangoPosteo</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto RangoPosteo</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("RangoPosteoBorrar", parametros, tran);
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