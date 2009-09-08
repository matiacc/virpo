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
    public class MensajeFactory
    {
        public static Mensaje Devolver(int id)
        {
            string query = "SELECT idAviso, idRemitente, fechaYHoraMsj, mensaje, fechaYhoraResp, respuesta, idEstado " +
                        "FROM Mensaje " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Mensaje mensaje = new Mensaje();
                mensaje.Aviso = AvisoClasificadoFactory.Devolver((int)dt.Rows[0]["idAviso"]);
                mensaje.Remitente = UsuarioFactory.Devolver((int)dt.Rows[0]["idRemitente"]);
                mensaje.Fecha = Convert.ToDateTime(dt.Rows[0]["fechaYHoraMsj"]);
                mensaje.Msj = dt.Rows[0]["mensaje"].ToString();
                if (dt.Rows[0]["fechaYhoraResp"] != DBNull.Value)
                    mensaje.FechaRespuesta = Convert.ToDateTime(dt.Rows[0]["fechaYhoraResp"]);
                if (dt.Rows[0]["respuesta"] != DBNull.Value)
                    mensaje.Respuesta = dt.Rows[0]["respuesta"].ToString();
                //mensaje.Estado=EstadoFactory.Devolver((int)dt.Rows[0]["idEstado"]);
                mensaje.Id = id;
                return mensaje;
            }
            else
            {
                return null;
            }
        }

        public static List<Mensaje> DevolverTodos()
        {
            string query = "SELECT id, idAviso, idRemitente, fechaYHoraMsj, mensaje, fechaYhoraResp, respuesta, idEstado " +
                           "FROM Mensaje";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Mensaje> mensajes = new List<Mensaje>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Mensaje mensaje = new Mensaje();
                    mensaje.Id = (int)dt.Rows[i]["id"];
                    mensaje.Aviso = AvisoClasificadoFactory.Devolver((int)dt.Rows[i]["idAviso"]);
                    mensaje.Remitente = UsuarioFactory.Devolver((int)dt.Rows[i]["idRemitente"]);
                    mensaje.Fecha = Convert.ToDateTime(dt.Rows[i]["fechaYHoraMsj"]);
                    mensaje.Msj = dt.Rows[i]["mensaje"].ToString();
                    mensaje.FechaRespuesta = Convert.ToDateTime(dt.Rows[i]["fechaYhoraResp"]);
                    mensaje.Respuesta = dt.Rows[i]["respuesta"].ToString();
                    //mensaje.Estado=EstadoFactory.Devolver((int)dt.Rows[0]["idEstado"]);
                    mensajes.Add(mensaje);
                }
                return mensajes;
            }
            else
            {
                return null;
            }
        }

        public static List<Mensaje> HayMensajesSinResponder(int idMusico)
        {
            string query = "SELECT men.id, men.idAviso, men.idRemitente, men.fechaYHoraMsj, men.mensaje " +
                           "FROM Mensaje men, AvisoClasificado avi " +
                           "WHERE avi.id=men.idAviso AND " +
                           "idMusicoDueño=" + idMusico +" AND " +
                           "respuesta is null ";


            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Mensaje> mensajes = new List<Mensaje>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Mensaje mensaje = new Mensaje();
                    mensaje.Id = (int)dt.Rows[i]["id"];
                    mensaje.Aviso = AvisoClasificadoFactory.Devolver((int)dt.Rows[i]["idAviso"]);
                    mensaje.Remitente = UsuarioFactory.Devolver((int)dt.Rows[i]["idRemitente"]);
                    mensaje.Fecha = Convert.ToDateTime(dt.Rows[i]["fechaYHoraMsj"]);
                    mensaje.Msj = dt.Rows[i]["mensaje"].ToString();
                    //mensaje.FechaRespuesta = Convert.ToDateTime(dt.Rows[i]["fechaYhoraResp"]);
                    //mensaje.Respuesta = dt.Rows[i]["respuesta"].ToString();
                    mensajes.Add(mensaje);
                }
                return mensajes;
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
        public static bool Insertar(Mensaje mensaje)
        {
            return Insertar(mensaje, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Mensaje mensaje, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idAviso", DbType.Int32, mensaje.Aviso.Id));
                parametros.Add(BDUtilidades.crearParametro("@idRemitente", DbType.Int32, mensaje.Remitente.Id));
                parametros.Add(BDUtilidades.crearParametro("@mensaje", DbType.String, mensaje.Msj));
                parametros.Add(BDUtilidades.crearParametro("@fechaYHoraMsj", DbType.DateTime, mensaje.Fecha));

                bool ok = BDUtilidades.ExecuteStoreProcedure("MensajeInsertar", parametros, tran);
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
        /// <param name="musico">objeto Mensaje</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Mensaje mensaje)
        {
            return Modificar(mensaje, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un Localidad con transaccion
        /// </summary>
        /// <param name="musico">objeto Localidad</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Mensaje mensaje, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, mensaje.Id));
                parametros.Add(BDUtilidades.crearParametro("@idAviso", DbType.Int32, mensaje.Aviso.Id));
                parametros.Add(BDUtilidades.crearParametro("@idRemitente", DbType.Int32, mensaje.Remitente.Id));
                parametros.Add(BDUtilidades.crearParametro("@mensaje", DbType.String, mensaje.Msj));
                parametros.Add(BDUtilidades.crearParametro("@fechaYhoraResp", DbType.DateTime, mensaje.FechaRespuesta));
                parametros.Add(BDUtilidades.crearParametro("@fechaYHoraMsj", DbType.DateTime, mensaje.Fecha));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, mensaje.Estado.Id));
                parametros.Add(BDUtilidades.crearParametro("@respuesta", DbType.String, mensaje.Respuesta));

                bool ok = BDUtilidades.ExecuteStoreProcedure("MensajeActualizar", parametros, tran);
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

                bool ok = BDUtilidades.ExecuteStoreProcedure("MensajeBorrar", parametros, tran);
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
