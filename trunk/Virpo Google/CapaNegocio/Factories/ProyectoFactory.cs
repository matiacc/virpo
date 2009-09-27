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
    public class ProyectoFactory
    {
        public static Proyecto Devolver(int id)
        {
            string query = "SELECT nombre,descripcion,imagen,licencia, genero, tags, tipo, idUsuario,fechaCreacion " +
                         "FROM Proyecto " +
                         "WHERE id=" + id;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Proyecto proyecto = new Proyecto();
                proyecto.Id = id;
                proyecto.Nombre = dt.Rows[0]["nombre"].ToString();
                proyecto.Descripcion = dt.Rows[0]["descripcion"].ToString();
                proyecto.Imagen = dt.Rows[0]["imagen"].ToString();
                proyecto.Licencia = dt.Rows[0]["licencia"].ToString();
                proyecto.Genero = dt.Rows[0]["genero"].ToString();
                proyecto.Tags = dt.Rows[0]["tags"].ToString();
                proyecto.Tipo = (int)dt.Rows[0]["tipo"];
                proyecto.Usuario = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idUsuario"]));
                proyecto.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"]);
                return proyecto;
            }
            else
            {
                return null;
            }
        }

        public static List<Proyecto> DevolverTodos(string restriccion)
        {
            string query = "SELECT nombre,descripcion,imagen,licencia, genero, tags, tipo, idUsuario,fechaCreacion " +
                         "FROM Proyecto ";
            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Proyecto> proyectos = new List<Proyecto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Proyecto proyecto = new Proyecto();
                    proyecto.Id = (int)dt.Rows[i]["id"];
                    proyecto.Nombre = dt.Rows[i]["nombre"].ToString();
                    proyecto.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    proyecto.Imagen = dt.Rows[i]["imagen"].ToString();
                    proyecto.Licencia = dt.Rows[i]["licencia"].ToString();
                    proyecto.Genero = dt.Rows[i]["genero"].ToString();
                    proyecto.Tags = dt.Rows[i]["tags"].ToString();
                    proyecto.Tipo = (int)dt.Rows[i]["tipo"];
                    proyecto.Usuario = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idUsuario"]));
                    proyecto.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
                    proyectos.Add(proyecto);
                }
                return proyectos;
            }
            else
            {
                return null;
            }
        }

        public static int DevolverIdProyectoCreado(DateTime fecSis)
        {
            string query = "SELECT MAX(ID) FROM Proyecto";

            return BDUtilidades.EjecutarConsultaEscalar(query);

        }

        #region Insertar
        public static bool Insertar(Proyecto proyecto)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, proyecto.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, proyecto.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, proyecto.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@licencia", DbType.String, proyecto.Licencia));
                parametros.Add(BDUtilidades.crearParametro("@genero", DbType.String, proyecto.Genero));
                parametros.Add(BDUtilidades.crearParametro("@tags", DbType.String, proyecto.Tags));
                parametros.Add(BDUtilidades.crearParametro("@tipo", DbType.Int32, proyecto.Tipo));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, proyecto.FechaCreacion));
                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, proyecto.Usuario.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProyectoInsertar", parametros);
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
        public static bool Modificar(Proyecto proyecto)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, proyecto.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, proyecto.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, proyecto.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, proyecto.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@licencia", DbType.Int32, proyecto.Licencia));
                parametros.Add(BDUtilidades.crearParametro("@genero", DbType.String, proyecto.Genero));
                parametros.Add(BDUtilidades.crearParametro("@tags", DbType.String, proyecto.Tags));
                parametros.Add(BDUtilidades.crearParametro("@tipo", DbType.Int32, proyecto.Tipo));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, proyecto.FechaCreacion));
                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, proyecto.Usuario.Id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProyectoInsertar", parametros);
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
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ProyectoBorrar", parametros);
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
