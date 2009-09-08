using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocio.Entities;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class PaisFactory
    {
        public static Pais Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM Pais " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Pais pais = new Pais();
                pais.Nombre = dt.Rows[0]["nombre"].ToString();
                pais.Descripcion = dt.Rows[0]["descripcion"].ToString();
                pais.Id = id;
                return pais;
            }
            else
            {
                return null;
            }
        }

        public static List<Pais> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM Pais";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Pais> paises = new List<Pais>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Pais pais = new Pais();
                    pais.Id = (int)dt.Rows[i]["id"];
                    pais.Nombre = dt.Rows[i]["nombre"].ToString();
                    pais.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    paises.Add(pais);
                }
                return paises;
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
        /// <param name="musico">objeto Pais</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Pais pais)
        {
            return Insertar(pais, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Pais</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Pais pais, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, pais.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, pais.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PaisInsertar", parametros, tran);
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
        /// <param name="musico">objeto Pais</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Pais pais)
        {
            return Modificar(pais, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un Pais con transaccion
        /// </summary>
        /// <param name="musico">objeto Pais</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Pais pais, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, pais.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, pais.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, pais.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PaisActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Pais</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Pais</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PaisBorrar", parametros, tran);
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

       
    }
}
