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
    public class PublicidadFactory
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
                Publicidad publicidad = new Publicidad();

                publicidad.Id = id;
                publicidad.Entidad = dt.Rows[0]["entidad"].ToString();
                publicidad.NombreContacto = dt.Rows[0]["nombreContacto"].ToString();
                publicidad.TelContacto = dt.Rows[0]["telContacto"].ToString();
                publicidad.MailContacto = dt.Rows[0]["mailContacto"].ToString();
                publicidad.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                publicidad.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                publicidad.Frecuencia = (int)dt.Rows[0]["frecuencia"];
                publicidad.Imagen = dt.Rows[0]["imagen"].ToString();
                publicidad.Consulta = dt.Rows[0]["consulta"].ToString();
                publicidad.IdEstado = (int)dt.Rows[0]["idEstado"];

                return publicidad;
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
                List<Publicidad> publicidades = new List<Publicidad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                Publicidad publicidad = new Publicidad();


                publicidad.Entidad = dt.Rows[0]["entidad"].ToString();
                publicidad.NombreContacto = dt.Rows[0]["nombreContacto"].ToString();
                publicidad.TelContacto = dt.Rows[0]["telContacto"].ToString();
                publicidad.MailContacto = dt.Rows[0]["mailContacto"].ToString();
                publicidad.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                publicidad.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                publicidad.Frecuencia = (int)dt.Rows[0]["frecuencia"];
                publicidad.Imagen = dt.Rows[0]["imagen"].ToString();
                publicidad.Consulta = dt.Rows[0]["consulta"].ToString();
                publicidad.IdEstado = (int)dt.Rows[0]["idEstado"];

                publicidades.Add(publicidad);
                }
                return publicidades;
            }
            else
            {
                return null;
            }

        }

        

        public static List<Publicidad> DevolverSolicitudes()
        {
            List<Publicidad> lista = DevolverXEstado(0);
            return lista;
        }
       
        public static List<Publicidad> DevolverVigentes()
        {
            List<Publicidad> lista = DevolverXEstado(1);
            return lista;
        }

        public static List<Publicidad> DevolverRenovaciones()
        {
            List<Publicidad> lista = DevolverXEstado(2);
            return lista;
        }

        public static List<Publicidad> DevolverBajasPendientes()
        {
            List<Publicidad> lista = DevolverXEstado(3);
            return lista;
        }

        public static DataTable DevolverXEstadoDT(int idEstado)
        {
            string query = "SELECT id, entidad, nombreContacto, telContacto, mailContacto, fechaInicio, fechaFin, frecuencia, imagen, consulta, idEstado FROM Publicidad WHERE idEstado = " + idEstado;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            return dt;
        }

        public static List<Publicidad> DevolverXEstado(int idEstado)
        {
            string query = "SELECT id, entidad, nombreContacto, telContacto, mailContacto, fechaInicio, fechaFin, frecuencia, imagen, consulta, idEstado FROM Publicidad WHERE idEstado = " + idEstado; 

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<Publicidad> publicidades = new List<Publicidad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Publicidad publicidad = new Publicidad();


                    publicidad.Entidad = dt.Rows[0]["entidad"].ToString();
                    publicidad.NombreContacto = dt.Rows[0]["nombreContacto"].ToString();
                    publicidad.TelContacto = dt.Rows[0]["telContacto"].ToString();
                    publicidad.MailContacto = dt.Rows[0]["mailContacto"].ToString();
                    publicidad.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                    publicidad.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                    publicidad.Frecuencia = (int)dt.Rows[0]["frecuencia"];
                    publicidad.Imagen = dt.Rows[0]["imagen"].ToString();
                    publicidad.Consulta = dt.Rows[0]["consulta"].ToString();
                    publicidad.IdEstado = (int)dt.Rows[0]["idEstado"];

                    publicidades.Add(publicidad);
                }
                return publicidades;
            }
            else
            {
                return null;
            }

        }


        #endregion


        #region Insertar

        public static bool Insertar(Publicidad publicidad)
        {
            return Insertar(publicidad, (SqlTransaction)null);
        }

        public static bool Insertar(Publicidad publicidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@entidad", DbType.String, publicidad.Entidad));
                parametros.Add(BDUtilidades.crearParametro("@nombreContacto", DbType.String, publicidad.NombreContacto));
                parametros.Add(BDUtilidades.crearParametro("@telContacto", DbType.String, publicidad.TelContacto));
                parametros.Add(BDUtilidades.crearParametro("@mailContacto", DbType.String, publicidad.MailContacto));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, publicidad.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, publicidad.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@frecuencia", DbType.Int32, publicidad.Frecuencia));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, publicidad.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@consulta", DbType.String, publicidad.Consulta));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, publicidad.IdEstado));

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

        public static bool Modificar(Publicidad publicidad)
        {
            return Modificar(publicidad, (SqlTransaction)null);
        }

        public static bool Modificar(Publicidad publicidad, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@Id", DbType.Int32, publicidad.Id));
                parametros.Add(BDUtilidades.crearParametro("@entidad", DbType.String, publicidad.Entidad));
                parametros.Add(BDUtilidades.crearParametro("@nombreContacto", DbType.String, publicidad.NombreContacto));
                parametros.Add(BDUtilidades.crearParametro("@telContacto", DbType.String, publicidad.TelContacto));
                parametros.Add(BDUtilidades.crearParametro("@mailContacto", DbType.String, publicidad.MailContacto));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, publicidad.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, publicidad.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@frecuencia", DbType.Int32, publicidad.Frecuencia));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, publicidad.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@consulta", DbType.String, publicidad.Consulta));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, publicidad.IdEstado));

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

        public static int CalcularVencimientos(DateTime fecha)
        {
            fecha = fecha.AddDays(7);

            string FECHA = "'"+ fecha.Year +"/"+fecha.Month+"/"+fecha.Day+ "'";
            
            string query = "UPDATE Publicidad SET idEstado = 2 WHERE idEstado = 1 and fechaFin <= "+FECHA;
            return BDUtilidades.EjecutarNonQuery(query);
        }

        public static Publicidad DevolverAleatoria()
        {
            List<Publicidad> todas = DevolverTodos();
            List<Publicidad> todasFrec = new List<Publicidad>();
            int rdm;
            int frec;
            foreach (Publicidad  publi in todas)//cargo la lista en base a la frecuencia
            {
                frec = 0; 
                while (publi.Frecuencia > frec)
                {
                    todasFrec.Add(publi);
                    frec++;
                }                               
            }
            rdm = new Random().Next(todasFrec.Count);
            int idExistente = todasFrec[rdm].Id;
            Publicidad publi = Devolver(idExistente);
            return publi;
        }
    }

    
}
