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
    public class ProvinciaFactory
    {
        public static Provincia Devolver(int id)
        {
            string query = "SELECT nombre, descripcion, idPais " +
                        "FROM Provincia " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Provincia provincia = new Provincia();
                provincia.Nombre = dt.Rows[0]["nombre"].ToString();
                provincia.Descripcion = dt.Rows[0]["descripcion"].ToString();
                provincia.Pais = PaisFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idPais"]));
                provincia.Id = id;
                return provincia;
            }
            else
            {
                return null;
            }
        }

        public static List<Provincia> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM Provincia";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Provincia> provincias = new List<Provincia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Provincia provincia = new Provincia();
                    provincia.Id = (int)dt.Rows[i]["idProvincia"];
                    provincia.Nombre = dt.Rows[i]["nombre"].ToString();
                    provincia.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    provincia.Pais = PaisFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idPais"]));
                    provincias.Add(provincia);
                }
                return provincias;
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
        /// <param name="musico">objeto Provincia</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Provincia provincia)
        {
            return Insertar(provincia, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Provincia</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Provincia provincia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, provincia.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, provincia.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@idPais", DbType.Int32, provincia.Pais.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProvinciaInsertar", parametros, tran);
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

        #region Modificar
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto Provincia</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Provincia provincia)
        {
            return Modificar(provincia, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un Provincia con transaccion
        /// </summary>
        /// <param name="musico">objeto Provincia</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Provincia provincia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, provincia.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, provincia.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, provincia.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@idPais", DbType.Int32, provincia.Pais.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProvinciaActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Provincia</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Provincia</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProvinciaBorrar", parametros, tran);
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
