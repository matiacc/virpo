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
    public class TopicGrupoFactory
    {
        public static TopicGrupo Devolver(int id)
        {
            string query = "SELECT titulo, visitas, fechaCreacion, idCreador, idGrupo " +
                        "FROM TopicGrupo " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                TopicGrupo topic = new TopicGrupo();
                topic.Titulo = dt.Rows[0]["titulo"].ToString();
                topic.Visitas = Convert.ToInt32(dt.Rows[0]["visitas"]);
                topic.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                topic.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                topic.Grupo = GrupoFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idGrupo"]));
                topic.Id = id;
                return topic;
            }
            else
            {
                return null;
            }
        }
        

        public static List<TopicGrupo> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, titulo, visitas, fechaCreacion, idCreador, idGrupo " +
                        "FROM TopicGrupo " ;
            
            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<TopicGrupo> topics = new List<TopicGrupo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TopicGrupo topic = new TopicGrupo();
                    topic.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    topic.Titulo = dt.Rows[i]["titulo"].ToString();
                    topic.Visitas = Convert.ToInt32(dt.Rows[i]["visitas"]);
                    topic.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    topic.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    topic.Grupo = GrupoFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idGrupo"]));
                    topics.Add(topic);
                }
                return topics;
            }
            else
            {
                return null;
            }
        }
        public static List<TopicGrupo> DevolverTodosPorGrupo(int idGrupo)
        {
            string query = "SELECT id, titulo, visitas, fechaCreacion, idCreador, idGrupo " +
                        "FROM TopicGrupo " +
                        "WHERE idGrupo =" + idGrupo;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<TopicGrupo> topics = new List<TopicGrupo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TopicGrupo topic = new TopicGrupo();
                    topic.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    topic.Titulo = dt.Rows[i]["titulo"].ToString();
                    topic.Visitas = Convert.ToInt32(dt.Rows[i]["visitas"]);
                    topic.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    topic.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    topic.Grupo = GrupoFactory.Devolver(idGrupo);
                    topics.Add(topic);
                }
                return topics;
            }
            else
            {
                return null;
            }
        }

        public static int CantidadRespuestas(int idTopic)
        {
            string query = "SELECT count(*) " +
                           "FROM PostGrupo " +
                           "WHERE idTopic = " + idTopic;
            return BDUtilidades.EjecutarConsultaEscalar(query);
        }

        public static int CantidadVisitas(int idTopic)
        {
            int visitas = BDUtilidades.EjecutarConsultaEscalar("SELECT visitas FROM TopicGrupo WHERE id =" + idTopic);
            return visitas;
        }
        public static int IncrementarVisita(string id)
        {
            string sql = "UPDATE TopicGrupo SET visitas = visitas + 1 WHERE id =" + id;
            return BDUtilidades.EjecutarNonQuery(sql);
        }

        #region Insertar

        /// <summary>
        /// Alta de un registro 
        /// </summary>
        /// <param name="musico">Objeto TopicGrupo</param>
        /// <returns>true si guardó con éxito</returns>
        public static int Insertar(TopicGrupo topic)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, topic.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, topic.FechaCreacion));
                parametros.Add(BDUtilidades.crearParametro("@idCreador", DbType.Int32, topic.Creador.Id));
                parametros.Add(BDUtilidades.crearParametro("@idGrupo", DbType.Int32, topic.Grupo.Id));

                return BDUtilidades.ExecuteStoreProcedureWithOutParameter("TopicGrupoInsertar", parametros);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
