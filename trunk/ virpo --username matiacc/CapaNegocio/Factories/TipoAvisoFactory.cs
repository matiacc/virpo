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
    public class TipoAvisoFactory
    {
        public static TipoAviso Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM TipoAviso " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                TipoAviso tipoAviso = new TipoAviso();
                tipoAviso.Nombre = dt.Rows[0]["nombre"].ToString();
                tipoAviso.Descripcion = dt.Rows[0]["descripcion"].ToString();
                tipoAviso.Id = id;
                return tipoAviso;
            }
            else
            {
                return null;
            }
        }

        public static List<TipoAviso> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM TipoAviso";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<TipoAviso> tipoAvisos = new List<TipoAviso>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TipoAviso tipoAviso = new TipoAviso();
                    tipoAviso.Id = (int)dt.Rows[i]["id"];
                    tipoAviso.Nombre = dt.Rows[i]["nombre"].ToString();
                    tipoAviso.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    tipoAvisos.Add(tipoAviso);
                }
                return tipoAvisos;
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
        /// <param name="musico">objeto TipoAviso</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(TipoAviso tipoAviso)
        {
            return Insertar(tipoAviso, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto TipoAviso</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(TipoAviso tipoAviso, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, tipoAviso.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, tipoAviso.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoAvisoInsertar", parametros, tran);
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
        /// <param name="musico">objeto TipoAviso</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(TipoAviso tipoAviso)
        {
            return Modificar(tipoAviso, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoAviso con transaccion
        /// </summary>
        /// <param name="musico">objeto TipoAviso</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(TipoAviso tipoAviso, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, tipoAviso.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, tipoAviso.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, tipoAviso.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoAvisoActualizar", parametros, tran);
                if (ok)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //LogError.Write(ex, "p_guardar_musico");
                return false;
            }

        }
        #endregion

        #region Eliminar

        /// <summary>
        /// Eliminar un registro sin transacción
        /// </summary>
        /// <param name="musico">Objeto TipoAviso</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto TipoAviso</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoAvisoBorrar", parametros, tran);
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
