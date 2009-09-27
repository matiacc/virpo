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
    public class TipoInstrumentoFactory
    {
        public static TipoInstrumento Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM TipoTipoInstrumento " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                TipoInstrumento instrumento = new TipoInstrumento();
                instrumento.Nombre = dt.Rows[0]["nombre"].ToString();
                instrumento.Descripcion = dt.Rows[0]["descripcion"].ToString();
                instrumento.Id = id;
                return instrumento;
            }
            else
            {
                return null;
            }
        }

        public static List<TipoInstrumento> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM TipoInstrumento";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<TipoInstrumento> instrumentos = new List<TipoInstrumento>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TipoInstrumento instrumento = new TipoInstrumento();
                    instrumento.Id = (int)dt.Rows[i]["id"];
                    instrumento.Nombre = dt.Rows[i]["nombre"].ToString();
                    instrumento.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    instrumentos.Add(instrumento);
                }
                return instrumentos;
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
        /// <param name="musico">objeto TipoInstrumento</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(TipoInstrumento instrumento)
        {
            return Insertar(instrumento, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto TipoInstrumento</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(TipoInstrumento instrumento, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, instrumento.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, instrumento.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoInstrumentoInsertar", parametros, tran);
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
        /// <param name="musico">objeto TipoInstrumento</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(TipoInstrumento instrumento)
        {
            return Modificar(instrumento, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto TipoInstrumento</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(TipoInstrumento instrumento, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, instrumento.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, instrumento.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, instrumento.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoInstrumentoActualizar", parametros, tran);
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
        /// <param name="musico">Objeto TipoInstrumento</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto TipoInstrumento</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("TipoInstrumentoBorrar", parametros, tran);
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
