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
    public class ComentarioEventoFactory
    {
        public static ComentarioEvento Devolver(int id)
        {
            string query = "SELECT comentario, IdEvento, idCreador, fechaCreacion " +
                        "FROM ComentarioEvento " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                ComentarioEvento comentario = new ComentarioEvento();
                comentario.Comentario = dt.Rows[0]["comentario"].ToString();
                comentario.IdEvento = Convert.ToInt32(dt.Rows[0]["IdEvento"]);
                comentario.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                comentario.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                comentario.Id = id;
                return comentario;
            }
            else
            {
                return null;
            }
        }

        public static ComentarioEvento DevolverUltimo(int IdEvento)
        {
            string query = "SELECT id, comentario, IdEvento, idCreador, fechaCreacion " +
                        "FROM ComentarioEvento " +
                        "WHERE IdEvento=" + IdEvento +
                        " order by fechaCreacion desc";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                ComentarioEvento comentario = new ComentarioEvento();
                comentario.Comentario = dt.Rows[0]["comentario"].ToString();
                comentario.IdEvento = IdEvento;
                comentario.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                comentario.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                comentario.Id = Convert.ToInt32(dt.Rows[0]["id"]); ;
                return comentario;
            }
            else
            {
                return null;
            }
        }

        public static List<ComentarioEvento> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, comentario, IdEvento, idCreador, fechaCreacion " +
                       "FROM ComentarioEvento ";

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<ComentarioEvento> comentarios = new List<ComentarioEvento>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComentarioEvento comentario = new ComentarioEvento();
                    comentario.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    comentario.Comentario = dt.Rows[i]["comentario"].ToString();
                    comentario.IdEvento = Convert.ToInt32(dt.Rows[i]["IdEvento"]);
                    comentario.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    comentario.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    comentarios.Add(comentario);
                }
                return comentarios;
            }
            else
            {
                return null;
            }
        }
        public static List<ComentarioEvento> DevolverTodosPorEvento(string idEvento)
        {
            string query = "SELECT id, comentario, IdEvento, idCreador, fechaCreacion " +
                       "FROM ComentarioEvento " +
                       "WHERE idEvento =" + idEvento;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<ComentarioEvento> comentarios = new List<ComentarioEvento>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComentarioEvento comentario = new ComentarioEvento();
                    comentario.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    comentario.Comentario = dt.Rows[i]["comentario"].ToString();
                    comentario.IdEvento = Convert.ToInt32(dt.Rows[i]["IdEvento"]);
                    comentario.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    comentario.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    comentarios.Add(comentario);
                }
                return comentarios;
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
        /// <param name="musico">Objeto ComentarioEvento</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(ComentarioEvento comentario)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@comentario", DbType.String, comentario.Comentario));
                parametros.Add(BDUtilidades.crearParametro("@IdEvento", DbType.Int32, comentario.IdEvento));
                parametros.Add(BDUtilidades.crearParametro("@idCreador", DbType.Int32, comentario.Creador.Id));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, comentario.FechaCreacion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ComentarioEventoInsertar", parametros);
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
