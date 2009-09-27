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
    public class LocalidadFactory
    {
        public static Localidad Devolver(int id)
        {
            string query = "SELECT nombre, descripcion, idProvincia " +
                        "FROM Localidad " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Localidad localidad = new Localidad();
                localidad.Nombre = dt.Rows[0]["nombre"].ToString();
                localidad.Descripcion = dt.Rows[0]["descripcion"].ToString();
                localidad.Provincia = ProvinciaFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idProvincia"]));
                localidad.Id = id;
                return localidad;
            }
            else
            {
                return null;
            }
        }

        public static List<Localidad> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion, idProvincia " +
                           "FROM Localidad";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Localidad> localidades = new List<Localidad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Localidad localidad = new Localidad();
                    localidad.Id = (int)dt.Rows[i]["id"];
                    localidad.Nombre = dt.Rows[i]["nombre"].ToString();
                    localidad.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    localidad.Provincia = ProvinciaFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idProvincia"]));
                    localidades.Add(localidad);
                }
                return localidades;
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
        /// <param name="musico">objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Localidad localidad)
        {
            return Insertar(localidad, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Localidad localidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, localidad.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, localidad.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@idProvincia", DbType.Int32, localidad.Provincia.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("LocalidadInsertar", parametros, tran);
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
        /// <param name="musico">objeto Localidad</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Localidad localidad)
        {
            return Modificar(localidad, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un Localidad con transaccion
        /// </summary>
        /// <param name="musico">objeto Localidad</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Localidad localidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, localidad.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, localidad.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, localidad.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@idProvincia", DbType.Int32, localidad.Provincia.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("LocalidadActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("LocalidadBorrar", parametros, tran);
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
