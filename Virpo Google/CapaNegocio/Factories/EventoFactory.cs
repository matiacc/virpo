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
    public class EventoFactory
    {

        public static Evento Devolver(int id)
        {
            string query = "SELECT nombre, lugar, ubicacion, fecha, hora, imagen, idMusico, idBanda, descripcion, estado " +
                           "FROM   Eventos " +
                           "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Evento evento = new Evento();
                evento.Id = id;
                evento.Nombre = dt.Rows[0]["nombre"].ToString();
                evento.Lugar = dt.Rows[0]["lugar"].ToString();
                evento.Ubicacion = dt.Rows[0]["ubicacion"].ToString();
                evento.Fecha = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                evento.Hora = Convert.ToDateTime(dt.Rows[0]["hora"].ToString());
                evento.Imagen = dt.Rows[0]["imagen"].ToString();
                evento.Musico = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idMusico"]));
                evento.Banda = BandaFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idBanda"]));
                evento.Descripcion = dt.Rows[0]["descripcion"].ToString();
                evento.Estado = dt.Rows[0]["estado"].ToString();

                return evento;
            }
            else
            {
                return null;
            }
        }


        public static List<Evento> DevolverTodos(string restriccion)
        {

            string query = "SELECT id, nombre, lugar, ubicacion, fecha, hora, imagen, idMusico, idBanda, descripcion, estado " +
                           "FROM   Evento ";
            
                           

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Evento> eventos = new List<Evento>();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Evento evento = new Evento();
                    evento.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    evento.Nombre = dt.Rows[i]["nombre"].ToString();
                    evento.Lugar = dt.Rows[i]["lugar"].ToString();
                    evento.Ubicacion = dt.Rows[i]["ubicacion"].ToString();
                    evento.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"]);
                    evento.Hora = Convert.ToDateTime(dt.Rows[i]["hora"].ToString());
                    evento.Imagen = dt.Rows[i]["imagen"].ToString();
                    evento.Musico = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idMusico"]));
                    evento.Banda = BandaFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idBanda"]));
                    evento.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    evento.Estado = dt.Rows[i]["estado"].ToString();
                    
                    eventos.Add(evento);
                }
                return eventos;
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
        /// <param name="musico">objeto Evento</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Evento evento)
        {
            return Insertar(evento, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Evento</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Evento evento, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, evento.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@lugar", DbType.String, evento.Lugar));
                parametros.Add(BDUtilidades.crearParametro("@ubicacion", DbType.String, evento.Ubicacion));
                parametros.Add(BDUtilidades.crearParametro("@fecha", DbType.DateTime, evento.Fecha));
                parametros.Add(BDUtilidades.crearParametro("@hora", DbType.DateTime, evento.Hora));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, evento.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@idMusico", DbType.Int32, evento.Musico.Id));
                parametros.Add(BDUtilidades.crearParametro("@idBanda", DbType.Int32, evento.Banda.Id));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, evento.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@estado", DbType.String, evento.Estado));

                bool ok = true;
                int idCreado = BDUtilidades.ExecuteStoreProcedureWithOutParameter("EventoInsertar", parametros);

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