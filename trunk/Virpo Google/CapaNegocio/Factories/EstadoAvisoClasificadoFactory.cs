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
    public class EstadoAvisoClasificadoFactory
    {
        public static EstadoAvisoClasificado Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM EstadoAvisoClasificado " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                EstadoAvisoClasificado estado = new EstadoAvisoClasificado();
                estado.Nombre = dt.Rows[0]["nombre"].ToString();
                estado.Descripcion = dt.Rows[0]["descripcion"].ToString();
                estado.Id = id;
                return estado;
            }
            else
            {
                return null;
            }
        }

        public static List<EstadoAvisoClasificado> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM EstadoAvisoClasificado";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<EstadoAvisoClasificado> estados = new List<EstadoAvisoClasificado>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EstadoAvisoClasificado estado = new EstadoAvisoClasificado();
                    estado.Id = (int)dt.Rows[i]["id"];
                    estado.Nombre = dt.Rows[i]["nombre"].ToString();
                    estado.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    estados.Add(estado);
                }
                return estados;
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
        /// <param name="musico">objeto EstadoAvisoClasificado</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(EstadoAvisoClasificado estado)
        {
            return Insertar(estado, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto EstadoAvisoClasificado</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(EstadoAvisoClasificado estado, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, estado.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, estado.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("EstadoAvisoClasificadoInsertar", parametros, tran);
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
        /// <param name="musico">objeto EstadoAvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(EstadoAvisoClasificado estado)
        {
            return Modificar(estado, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un EstadoAvisoClasificado con transaccion
        /// </summary>
        /// <param name="musico">objeto EstadoAvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(EstadoAvisoClasificado estado, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, estado.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, estado.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, estado.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("EstadoAvisoClasificadoActualizar", parametros, tran);
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
        /// <param name="musico">Objeto EstadoAvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto EstadoAvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("EstadoAvisoClasificadoBorrar", parametros, tran);
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
