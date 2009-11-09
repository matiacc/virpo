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
    public class PostGrupoFactory
    {
        public static PostGrupo Devolver(int id)
        {
            string query = "SELECT comentario, idTopic, idCreador, fechaCreacion " +
                        "FROM PostGrupo " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                PostGrupo post = new PostGrupo();
                post.Comentario = dt.Rows[0]["comentario"].ToString();
                post.IdTopic = Convert.ToInt32(dt.Rows[0]["idTopic"]);
                post.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                post.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                post.Id = id;
                return post;
            }
            else
            {
                return null;
            }
        }

        public static PostGrupo DevolverUltimo(int idTopic)
        {
            string query = "SELECT id, comentario, idTopic, idCreador, fechaCreacion " +
                        "FROM PostGrupo " +
                        "WHERE idTopic=" + idTopic +
                        " order by fechaCreacion desc";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                PostGrupo post = new PostGrupo();
                post.Comentario = dt.Rows[0]["comentario"].ToString();
                post.IdTopic = idTopic;
                post.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                post.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                post.Id = Convert.ToInt32(dt.Rows[0]["id"]); ;
                return post;
            }
            else
            {
                return null;
            }
        }

        public static List<PostGrupo> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, comentario, idTopic, idCreador, fechaCreacion " +
                       "FROM PostGrupo ";

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<PostGrupo> posts = new List<PostGrupo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PostGrupo post = new PostGrupo();
                    post.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    post.Comentario = dt.Rows[i]["comentario"].ToString();
                    post.IdTopic = Convert.ToInt32(dt.Rows[i]["idTopic"]);
                    post.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    post.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    posts.Add(post);
                }
                return posts;
            }
            else
            {
                return null;
            }
        }
        public static List<PostGrupo> DevolverTodosPorTopic(string idTopic)
        {
            string query = "SELECT id, comentario, idTopic, idCreador, fechaCreacion " +
                       "FROM PostGrupo " +
                       "WHERE idTopic =" + idTopic;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<PostGrupo> posts = new List<PostGrupo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PostGrupo post = new PostGrupo();
                    post.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    post.Comentario = dt.Rows[i]["comentario"].ToString();
                    post.IdTopic = Convert.ToInt32(dt.Rows[i]["idTopic"]);
                    post.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    post.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    posts.Add(post);
                }
                return posts;
            }
            else
            {
                return null;
            }
        }

        #region Insertar

        /// <summary>
        /// Alta de un registro 
        /// </summary>
        /// <param name="musico">Objeto PostGrupo</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(PostGrupo post)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@comentario", DbType.String, post.Comentario));
                parametros.Add(BDUtilidades.crearParametro("@idTopic", DbType.Int32, post.IdTopic));
                parametros.Add(BDUtilidades.crearParametro("@idCreador", DbType.Int32, post.Creador.Id));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, post.FechaCreacion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("PostGrupoInsertar", parametros);
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
