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
    public class GrupoFactory
    {
        public static Grupo Devolver(int id)
        {
            string query = "SELECT nombre, descripcion, tema, imagen, tags, idCreador,enlaces " +
                            "FROM   Grupo " +
                           "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Grupo grupo = new Grupo();
                grupo.Id = id;
                grupo.Nombre = dt.Rows[0]["nombre"].ToString();
                grupo.Descripcion = dt.Rows[0]["descripcion"].ToString();
                grupo.Tema = dt.Rows[0]["tema"].ToString();
                grupo.Imagen = dt.Rows[0]["imagen"].ToString();
                grupo.Tags = dt.Rows[0]["tags"].ToString();
                grupo.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idCreador"]));
                grupo.Enlaces = dt.Rows[0]["enlaces"].ToString();
                return grupo;
            }
            else
            {
                return null;
            }
        }
        public static List<Grupo> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, nombre, descripcion, tema, imagen, tags, idCreador,enlaces " +
                           "FROM   Grupo ";

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Grupo> grupos = new List<Grupo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Grupo grupo = new Grupo();
                    grupo.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    grupo.Nombre = dt.Rows[i]["nombre"].ToString();
                    grupo.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    grupo.Tema = dt.Rows[i]["tema"].ToString();
                    grupo.Imagen = dt.Rows[i]["imagen"].ToString();
                    grupo.Tags = dt.Rows[i]["tags"].ToString();
                    grupo.Creador = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idCreador"]));
                    grupo.Enlaces = dt.Rows[i]["enlaces"].ToString();
                    grupos.Add(grupo);
                }
                return grupos;
            }
            else
            {
                return null;
            }
        }

        public static int CantidadMiembros(int idGrupo)
        {
            string query = "SELECT count(*) " +
                           "FROM UsuarioXGrupo " +
                           "WHERE idGrupo=" + idGrupo;
            return BDUtilidades.EjecutarConsultaEscalar(query);
        }

        public static int DevolverMaxId()
        {
            string query = "SELECT MAX(ID) FROM Grupo";

            return BDUtilidades.EjecutarConsultaEscalar(query);
        }
        #region Insertar
        
        /// <summary>
        /// Alta de un registro 
        /// </summary>
        /// <param name="musico">Objeto Grupo</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Grupo grupo)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, grupo.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, grupo.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@tema", DbType.String, grupo.Tema));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, grupo.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@tags", DbType.String, grupo.Tags));
                parametros.Add(BDUtilidades.crearParametro("@idCreador", DbType.Int32, grupo.Creador.Id));
                parametros.Add(BDUtilidades.crearParametro("@enlaces", DbType.String, grupo.Enlaces));

                bool ok = true;
                int idCreado = BDUtilidades.ExecuteStoreProcedureWithOutParameter("GrupoInsertar", parametros);
                if (idCreado == 0) ok = false;
                if (ok)
                {
                    UsuarioXGrupoInsertar(grupo.Creador.Id, idCreado);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool UsuarioXGrupoInsertar(int idUsuario, int idGrupo)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, idUsuario));
                parametros.Add(BDUtilidades.crearParametro("@idGrupo", DbType.Int32, idGrupo));
                parametros.Add(BDUtilidades.crearParametro("@fechaIngreso", DbType.DateTime, DateTime.Now));

                return BDUtilidades.ExecuteStoreProcedure("UsuarioXGrupoInsertar", parametros);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
