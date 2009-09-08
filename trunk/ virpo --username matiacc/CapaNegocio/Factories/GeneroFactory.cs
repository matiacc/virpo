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
    public class GeneroFactory
    {
        public static Genero Devolver(int id)
        {
            string query = "SELECT nombre, descripcion " +
                        "FROM Genero " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Genero genero = new Genero();
                genero.Nombre = dt.Rows[0]["nombre"].ToString();
                genero.Descripcion = dt.Rows[0]["descripcion"].ToString();
                genero.Id = id;
                return genero;
            }
            else
            {
                return null;
            }
        }

        public static List<Genero> DevolverTodos()
        {
            string query = "SELECT id, nombre, descripcion " +
                           "FROM Genero";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Genero> generos = new List<Genero>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Genero genero = new Genero();
                    genero.Id = (int)dt.Rows[i]["id"];
                    genero.Nombre = dt.Rows[i]["nombre"].ToString();
                    genero.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    generos.Add(genero);
                }
                return generos;
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
        /// <param name="musico">objeto Genero</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Genero genero)
        {
            return Insertar(genero, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Genero</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Genero genero, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, genero.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, genero.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("GeneroInsertar", parametros, tran);
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
        /// <param name="musico">objeto Genero</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Genero genero)
        {
            return Modificar(genero, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto Genero</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Genero genero, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, genero.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, genero.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, genero.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("GeneroActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Genero</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Genero</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("GeneroBorrar", parametros, tran);
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