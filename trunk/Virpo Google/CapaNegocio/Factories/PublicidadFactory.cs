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
    class PublicidadFactory
    {

        #region Devolver

        public static Publicidad Devolver(int id)
        {
            string query = "SELECT id, entidad, nombreContacto, telContacto, mailContacto, fechaInicio, fechaFin, frecuencia, imagen, consulta, idEstado " +
                        "FROM Publicidad " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt.Rows.Count != 0)
            {
                Publicidad Publicidad = new Publicidad();

                Publicidad.Id = id;
                Publicidad.Entidad = dt.Rows[0]["entidad"].ToString();
                Publicidad.NombreContacto = dt.Rows[0]["nombreContacto"].ToString();
                Publicidad.TelContacto = dt.Rows[0]["telContacto"].ToString();
                Publicidad.MailContacto = dt.Rows[0]["mailContacto"].ToString();
                Publicidad.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                Publicidad.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                Publicidad.Frecuencia = (int)dt.Rows[0]["frecuencia"];
                Publicidad.Imagen = dt.Rows[0]["imagen"].ToString();
                Publicidad.Consulta = dt.Rows[0]["consulta"].ToString();
                Publicidad.IdEstado = (int)dt.Rows[0]["idEstado"];

                return Publicidad;
            }
            else
            {
                return null;
            }

        }


        public static List<Publicidad> DevolverTodos()
        {
            string query = "SELECT id, entidad, nombreContacto, telContacto, mailContacto, fechaInicio, fechaFin, frecuencia, imagen, consulta, idEstado FROM Publicidad ";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<Publicidad> Publicidades = new List<Publicidad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                Publicidad Publicidad = new Publicidad();

                Publicidad.Id = id;
                Publicidad.Entidad = dt.Rows[0]["entidad"].ToString();
                Publicidad.NombreContacto = dt.Rows[0]["nombreContacto"].ToString();
                Publicidad.TelContacto = dt.Rows[0]["telContacto"].ToString();
                Publicidad.MailContacto = dt.Rows[0]["mailContacto"].ToString();
                Publicidad.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                Publicidad.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                Publicidad.Frecuencia = (int)dt.Rows[0]["frecuencia"];
                Publicidad.Imagen = dt.Rows[0]["imagen"].ToString();
                Publicidad.Consulta = dt.Rows[0]["consulta"].ToString();
                Publicidad.IdEstado = (int)dt.Rows[0]["idEstado"];

                Publicidades.Add(Publicidad);
                }
                return Publicidades;
            }
            else
            {
                return null;
            }

        }

      
        #endregion


        #region Insertar

        public static bool Insertar(Publicidad Publicidad)
        {
            return Insertar(Publicidad, (SqlTransaction)null);
        }

        public static bool Insertar(Publicidad Publicidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@entidad", DbType.String, Publicidad.Entidad));
                parametros.Add(BDUtilidades.crearParametro("@nombreContacto", DbType.String, Publicidad.NombreContacto));
                parametros.Add(BDUtilidades.crearParametro("@telContacto", DbType.String, Publicidad.TelContacto));
                parametros.Add(BDUtilidades.crearParametro("@mailContacto", DbType.String, Publicidad.MailContacto));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, Publicidad.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, Publicidad.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@frecuencia", DbType.Int32, Publicidad.Frecuencia));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, Publicidad.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@consulta", DbType.Int32, Publicidad.Consulta));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, Publicidad.IdEstado));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PublicidadInsertar", parametros, tran);
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

        public static bool Modificar(Publicidad Publicidad)
        {
            return Modificar(Publicidad, (SqlTransaction)null);
        }

        public static bool Modificar(Publicidad Publicidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@Id", DbType.Int32, Publicidad.Id));
                parametros.Add(BDUtilidades.crearParametro("@entidad", DbType.String, Publicidad.Entidad));
                parametros.Add(BDUtilidades.crearParametro("@nombreContacto", DbType.String, Publicidad.NombreContacto));
                parametros.Add(BDUtilidades.crearParametro("@telContacto", DbType.String, Publicidad.TelContacto));
                parametros.Add(BDUtilidades.crearParametro("@mailContacto", DbType.String, Publicidad.MailContacto));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, Publicidad.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, Publicidad.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@frecuencia", DbType.Int32, Publicidad.Frecuencia));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, Publicidad.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@consulta", DbType.Int32, Publicidad.Consulta));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, Publicidad.IdEstado));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PublicidadActualizar", parametros, tran);
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

        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }

        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PublicidadBorrar", parametros, tran);

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
